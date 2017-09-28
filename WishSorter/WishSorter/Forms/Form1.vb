Public Class mainfrm
	Dim FirstLogin As Boolean = False
	Dim EnteredEmail As Boolean = False
	Dim EnteredPass As Boolean = False
	Dim listOfItems As String()

	Public isLoggedIn As Boolean = False
	Public email As String
	Public password As String

	Public Sub wait(ByVal interval As Integer)
		Dim stopW As New Stopwatch
		stopW.Start()
		Do While stopW.ElapsedMilliseconds < interval
			Application.DoEvents()
		Loop
		stopW.Stop()
	End Sub

	Public Function GetStringInRange(fromidx As Integer, toidx As Integer, strparam As String) As String
		Dim result As String = ""
		If fromidx > toidx Then
			Return result
		ElseIf toidx > strparam.Length Then
			Return result
		ElseIf toidx < 0 Or fromidx < 0 Then
			Return result
		End If

		result = strparam.Remove(0, fromidx)
		result = result.Remove(toidx - fromidx, strparam.Length - toidx)
		Return result
	End Function

	Public Function GetPrice(fromidx As Integer, strparam As String, seperator As String) As String
		Dim result As String = ""
		If seperator = "" Or strparam = "" Then
			Return result
		End If

		result = strparam.Insert(strparam.IndexOf("krNOK"), " ")
		result = result.Split(seperator)(1)

		Return result
	End Function

	Public Function GetHTML(strparam As String) As String
		Dim result As String = ""

		result = strparam.Split("Link:")(1)
		result = result.Remove(0, 5)
		result.Trim()

		Return result
	End Function

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Dim textboxtxt = TextBox1.Text()

		ToolStripStatusLabel1.Text = "Status: Navigating .."

		If Not Form2.Visible() Then
			Form2.Show()
			wait(200)
			Form2.WebBrowser1.Navigate("https://www.wish.com/")
		Else
			Form2.WebBrowser1.Navigate("https://www.wish.com/")
		End If

		wait(3000)

		If isLoggedIn Then
			ToolStripStatusLabel1.Text = "Status: Already logged in!"
			GoTo goSearch
		Else
			For Each elemnt As HtmlElement In Form2.WebBrowser1.Document.GetElementsByTagName("div")
				If InStr(elemnt.GetAttribute("classname"), "profile-pic-cont left") Then
					ToolStripStatusLabel1.Text = "Status: Already logged in!"
					isLoggedIn = True
					GoTo goSearch
				End If
			Next
		End If

		Button1.Enabled = False
		wait(1000)
		ToolStripStatusLabel1.Text = "Status: Waiting Logging in"
		Button1.Enabled = True

		For Each elemnt As HtmlElement In Form2.WebBrowser1.Document.GetElementsByTagName("div")
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
		wait(200)
		If email = "" Or password = "" Then
			loginForm.Show()
			ToolStripStatusLabel1.Text = "Status: Waiting for user to input login information.."
		End If

		While email = ""
			wait(4000)
		End While
		ToolStripStatusLabel1.Text = "Status: Login information retrieved.."
		wait(200)
		ToolStripStatusLabel1.Text = "Status: Waiting . Logging in ."

		For Each formlogin As HtmlElement In Form2.WebBrowser1.Document.GetElementsByTagName("input")
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
		For Each loginbutton As HtmlElement In Form2.WebBrowser1.Document.GetElementsByTagName("button")
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
		wait(2000)

		ToolStripStatusLabel1.Text = "Status: Continuing to search for " + textboxtxt + " .."
		Form2.WebBrowser1.Navigate("https://www.wish.com/search/" + textboxtxt)
		ToolStripStatusLabel1.Text = "Status: Searched!"

		wait(2000)

		Dim amountOfItems As Integer = 0

		While amountOfItems <= Integer.Parse(TextBox2.Text)
			Form2.WebBrowser1.Navigate("javascript:window.scroll(0,document.body.scrollHeight);")
			wait(200)
			amountOfItems = amountOfItems + 25
		End While

		ToolStripStatusLabel1.Text = "Status: Parsing .."

		For Each items As HtmlElement In Form2.WebBrowser1.Document.GetElementsByTagName("div")
			If InStr(items.GetAttribute("classname"), "feed-actual-price") Then
				If Not items.InnerText = "" Then
					For Each link As HtmlElement In items.Parent.Parent.Parent.GetElementsByTagName("a")
						ListBox1.Items.Add("pris: " + IIf(items.InnerText.Contains("Gratis"), "0krNOK", items.InnerText.Replace(" ", "")) + " Link: " + link.GetAttribute("href"))
						Exit For
					Next
				End If
			End If
		Next

		listOfItems = (From item1 As String In ListBox1.Items Order By Integer.Parse(GetPrice(6, item1, " ")) Ascending Select item1).ToArray()
		ListBox1.Items.Clear()
		ListBox1.Items.AddRange(listOfItems)

		ToolStripStatusLabel1.Text = "Status: Done!"
		wait(500)
		ToolStripStatusLabel1.Text = "Status: Idle"
	End Sub

	Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
		Process.Start(GetHTML(ListBox1.GetItemText(ListBox1.SelectedItem)))
	End Sub

	Private Sub WebbrowserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WebbrowserToolStripMenuItem.Click
		Form2.Show()
	End Sub

	Private Sub mainfrm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
		StatusStrip1.Text = "Status: Idle"
		If Not isLoggedIn Then
			loginForm.Show()
		End If
	End Sub

	Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
		Application.Exit()
	End Sub
End Class