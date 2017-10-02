Imports WishSorter.WishItem
Imports WishSorter.Functions

Public Class mainfrm
	Dim FirstLogin As Boolean = False
	Dim EnteredEmail As Boolean = False
	Dim EnteredPass As Boolean = False
	Dim toggleWebbrowser As Boolean = False

	Dim GroupBoxGraphics As Graphics

	Dim isNavigating As Boolean = False

	Public isLoggedIn As Boolean = False

	Dim listviewGraphics As Graphics

	Dim listOfItems As List(Of WishItem) = New List(Of WishItem)

	Dim currencyStr As String
	Dim listOfFreeItems As New List(Of String)

	Public email As String
	Public password As String

	Public Sub wait(interval As Integer)
		Dim stopW As New Stopwatch
		stopW.Start()
		Do While stopW.ElapsedMilliseconds < interval
			Application.DoEvents()
		Loop
		stopW.Stop()
	End Sub

	Private Sub WaitForDoc()
		wait(500)
		Do While isNavigating
			wait(500)
		Loop
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Dim textboxtxt = TextBox1.Text()
		If listOfItems.Count > 0 Then
			listOfItems.Clear()
		End If

		If FlowLayoutPanel1.Controls.Count > 0 Then
			FlowLayoutPanel1.Controls.Clear()
		End If

		ToolStripStatusLabel1.Text = "Status: Navigating .."

		WebBrowser1.Navigate("https://www.wish.com/")

		WaitForDoc()

		If isLoggedIn Then
			ToolStripStatusLabel1.Text = "Status: Already logged in!"
			GoTo goSearch
		Else
			For Each elemnt As HtmlElement In WebBrowser1.Document.GetElementsByTagName("div")
				If InStr(elemnt.GetAttribute("classname"), "profile-pic-cont left") Then
					ToolStripStatusLabel1.Text = "Status: Already logged in!"
					isLoggedIn = True
					GoTo goSearch
				End If
			Next
		End If

		wait(300)

		Button1.Enabled = False
		WaitForDoc()
		ToolStripStatusLabel1.Text = "Status: Waiting Logging in"
		Button1.Enabled = True

		For Each elemnt As HtmlElement In WebBrowser1.Document.GetElementsByTagName("div")
			If InStr(elemnt.GetAttribute("classname"), "email-login-btn btn") Then
				elemnt.InvokeMember("Click")
				elemnt.InvokeMember("MouseDown")
				elemnt.InvokeMember("MouseUp")
				elemnt.RaiseEvent("OnClick")
				elemnt.Focus()
				ToolStripStatusLabel1.Text = "Status: Waiting . Logging in ."
				FirstLogin = True
			End If
		Next
		wait(300)
		If email = "" Or password = "" Then
			loginForm.Show()
			ToolStripStatusLabel1.Text = "Status: Waiting for user to input login information.."
		End If

		While email = ""
			wait(2000)
		End While
		ToolStripStatusLabel1.Text = "Status: Login information retrieved.."
		wait(200)
		ToolStripStatusLabel1.Text = "Status: Waiting . Logging in ."

		For Each formlogin As HtmlElement In WebBrowser1.Document.GetElementsByTagName("input")
			If formlogin.Id = "login-email" Then
				wait(200)
				formlogin.SetAttribute("value", email)
				ToolStripStatusLabel1.Text = "Status: Waiting .. Logging in .."
				EnteredEmail = True
			End If
			If formlogin.Id = "login-password" Then
				wait(200)
				formlogin.SetAttribute("value", password)
				ToolStripStatusLabel1.Text = "Status: Waiting ... Logging in ..."
				EnteredPass = True
			End If
		Next
		wait(200)
		For Each loginbutton As HtmlElement In WebBrowser1.Document.GetElementsByTagName("button")
			If InStr(loginbutton.GetAttribute("classname"), "submit-btn btn") Then
				loginbutton.InvokeMember("Click")
				loginbutton.InvokeMember("MouseDown")
				loginbutton.InvokeMember("MouseUp")
				loginbutton.RaiseEvent("OnClick")
				loginbutton.Focus()
				ToolStripStatusLabel1.Text = "Status: Logged in!"
				isLoggedIn = True
			End If
		Next

		If Not FirstLogin Then
			ToolStripStatusLabel1.Text = "Status: Failed at first login! Please try again."
			Return
		ElseIf Not EnteredEmail Then
			ToolStripStatusLabel1.Text = "Status: Failed when entering email! Please try again."
			Return
		ElseIf Not EnteredPass Then
			ToolStripStatusLabel1.Text = "Status: Failed when entering password! Please try again."
			Return
		ElseIf Not isLoggedIn Then
			ToolStripStatusLabel1.Text = "Status: Failed when logging in! Please try again."
			Return
		End If

goSearch:
		WaitForDoc()

		ToolStripStatusLabel1.Text = "Status: Getting currency .."

		For Each spanTag As HtmlElement In WebBrowser1.Document.GetElementsByTagName("span")
			If InStr(spanTag.GetAttribute("classname"), "currency-subscript") Then
				currencyStr = FunctionsObject.GetCurrencyString(spanTag.InnerText)
				Exit For
			End If
		Next

		wait(300)

		ToolStripStatusLabel1.Text = "Status: Currency retrieved! You use " + currencyStr

		wait(300)

		ToolStripStatusLabel1.Text = "Status: Continuing to search for " + textboxtxt + " .."
		WebBrowser1.Navigate("https://www.wish.com/search/" + textboxtxt)
		ToolStripStatusLabel1.Text = "Status: Searched!"

		WaitForDoc()

		Dim amountOfItems As Integer = 0

		ToolStripStatusLabel1.Text = "Status: Scrolling " + TextBox2.Text + " items into view"

		Try
			amountOfItems = Integer.Parse(TextBox2.Text)
		Catch ex As Exception
		End Try

		While amountOfItems
			WebBrowser1.Navigate("javascript:window.scroll(0,document.body.scrollHeight);")
			wait(300)
			amountOfItems = amountOfItems - 25
		End While

		ToolStripStatusLabel1.Text = "Status: Parsing all .."

		For Each items As HtmlElement In WebBrowser1.Document.GetElementsByTagName("div")
			If InStr(items.GetAttribute("classname"), "feed-actual-price") Then
				If Not items.InnerText = "" Then
					For Each link As HtmlElement In items.Parent.Parent.Parent.GetElementsByTagName("a")
						If items.InnerText.Contains("Gratis") Then
							listOfFreeItems.Add(link.GetAttribute("href") + " " + FunctionsObject.GetImageLink(items.Parent.Parent.Parent.InnerHtml))
						Else
							listOfItems.Add(New WishItem(link.GetAttribute("href"), items.InnerText.Replace(" " + currencyStr, ""), False, FunctionsObject.GetImageLink(items.Parent.Parent.Parent.InnerHtml)))
						End If
						Exit For
					Next
				End If
			End If
		Next

		wait(400)

		Dim paidStuffCount As Integer = listOfItems.Count

		ToolStripStatusLabel1.Text = "Status: Parsing free items .."

		For Each item As String In listOfFreeItems
			WebBrowser1.Navigate(item.Split(" ")(0))
			WaitForDoc()
			For Each htmlitem As HtmlElement In WebBrowser1.Document.GetElementsByTagName("div")
				If InStr(htmlitem.GetAttribute("classname"), "shipping-details details-section") Then
					If InStr(htmlitem.InnerText, "levering") Then
						Dim pricestr As String = htmlitem.InnerText
						pricestr = pricestr.Replace("Antatt levering", "")
						pricestr = pricestr.Replace(" ", "")
						pricestr = pricestr.Replace(currencyStr, "")
						listOfItems.Add(New WishItem(item.Split(" ")(0), pricestr, True, item.Split(" ")(1)))
						Exit For
					End If
				End If
			Next
		Next

		GroupBox1.Text = "Items found " + paidStuffCount.ToString() + " | " + (listOfItems.Count - paidStuffCount).ToString() + " free stuff"

		' Picture
		For Each item As WishItem In FunctionsObject.SortWishItemByPrice(listOfItems)
			Dim picToMake As New PictureBox
			Dim TextUnderPic As New Label

			With TextUnderPic
				.Text = IIf(item.getsetIsFree, "Free " + item.getsetPrice.ToString() + " " + currencyStr + vbNewLine + " shipping", item.getsetPrice.ToString() + " " + currencyStr)
				.Name = item.getsetLinkSite
				.Location = New Point(0, 75)
				.Width = 78
				.Height = 35
			End With

			With picToMake
				.Name = item.getsetLinkImage
				.Image = New Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(item.getsetLinkImage)))
				.Size = New Size(75, 75)
				.Margin = New Padding(.Margin.Left, 0, .Margin.Right, 0)
				.SetBounds(.Location.X, .Location.Y, 75, 105)
				.SizeMode = PictureBoxSizeMode.Zoom
			End With

			picToMake.Controls.Add(TextUnderPic)
			Me.FlowLayoutPanel1.Controls.Add(picToMake)

			TextUnderPic.BringToFront()
			picToMake.BringToFront()

			AddHandler TextUnderPic.DoubleClick, AddressOf ClickedText
			AddHandler picToMake.DoubleClick, AddressOf ClickedPic

			picToMake.DrawToBitmap(New Bitmap(GroupBox1.Width, GroupBox1.Height, GroupBoxGraphics), New Rectangle(GroupBox1.Location.X, GroupBox1.Location.Y, GroupBox1.Width, GroupBox1.Height))
		Next

		ToolStripStatusLabel1.Text = "Status: Done!"
			wait(500)
		ToolStripStatusLabel1.Text = "Status: Idle"
	End Sub

	Private Sub ClickedText(ByVal sender As Object, ByVal e As EventArgs)
		Dim textLabel = DirectCast(sender, Label)
		For Each linkToProcess As WishItem In FunctionsObject.SortWishItemByPrice(listOfItems)
			If textLabel.Name = linkToProcess.getsetLinkSite Then
				Process.Start(linkToProcess.getsetLinkSite)
				Exit For
			End If
		Next
	End Sub

	Private Sub ClickedPic(ByVal sender As Object, ByVal e As EventArgs)
		Dim picBox = DirectCast(sender, PictureBox)
		For Each linkToProcess As WishItem In FunctionsObject.SortWishItemByPrice(listOfItems)
			If picBox.Name = linkToProcess.getsetLinkImage Then
				Process.Start(linkToProcess.getsetLinkSite)
				Exit For
			End If
		Next
	End Sub

	Private Sub WebbrowserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WebbrowserToolStripMenuItem.Click
		If toggleWebbrowser Then
			Me.Width = Me.Width - 804
			toggleWebbrowser = False
		Else
			Me.Width = Me.Width + 804
			toggleWebbrowser = True
		End If
	End Sub

	Private Sub mainfrm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
		StatusStrip1.Text = "Status: Idle"
		If Not isLoggedIn Or email = "" Then
			loginForm.Show()
		End If
	End Sub

	Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
		Application.Exit()
	End Sub

	Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
		wait(500)
		isNavigating = False
	End Sub

	Private Sub WebBrowser1_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles WebBrowser1.Navigating
		isNavigating = True
	End Sub

	Private Sub mainfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		GroupBoxGraphics = GroupBox1.CreateGraphics()
	End Sub
End Class