<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class mainfrm
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Me.Button1 = New System.Windows.Forms.Button()
		Me.TextBox1 = New System.Windows.Forms.TextBox()
		Me.ListBox1 = New System.Windows.Forms.ListBox()
		Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
		Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.WebbrowserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
		Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.TextBox2 = New System.Windows.Forms.TextBox()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
		Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
		Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
		Me.ListView1 = New System.Windows.Forms.ListView()
		Me.MenuStrip1.SuspendLayout()
		Me.StatusStrip1.SuspendLayout()
		Me.SuspendLayout()
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(845, 31)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(75, 23)
		Me.Button1.TabIndex = 2
		Me.Button1.Text = "Search"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'TextBox1
		'
		Me.TextBox1.Location = New System.Drawing.Point(12, 33)
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.Size = New System.Drawing.Size(692, 20)
		Me.TextBox1.TabIndex = 0
		'
		'ListBox1
		'
		Me.ListBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.ListBox1.FormattingEnabled = True
		Me.ListBox1.Location = New System.Drawing.Point(12, 60)
		Me.ListBox1.Name = "ListBox1"
		Me.ListBox1.Size = New System.Drawing.Size(296, 524)
		Me.ListBox1.TabIndex = 3
		'
		'MenuStrip1
		'
		Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ViewToolStripMenuItem})
		Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
		Me.MenuStrip1.Name = "MenuStrip1"
		Me.MenuStrip1.Size = New System.Drawing.Size(931, 24)
		Me.MenuStrip1.TabIndex = 222
		Me.MenuStrip1.Text = "MenuStrip1"
		'
		'FileToolStripMenuItem
		'
		Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
		Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
		Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
		Me.FileToolStripMenuItem.Text = "File"
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
		'
		'ExitToolStripMenuItem
		'
		Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
		Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
		Me.ExitToolStripMenuItem.Text = "Exit"
		'
		'ViewToolStripMenuItem
		'
		Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WebbrowserToolStripMenuItem})
		Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
		Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
		Me.ViewToolStripMenuItem.Text = "View"
		'
		'WebbrowserToolStripMenuItem
		'
		Me.WebbrowserToolStripMenuItem.Name = "WebbrowserToolStripMenuItem"
		Me.WebbrowserToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
		Me.WebbrowserToolStripMenuItem.Text = "Webbrowser"
		'
		'StatusStrip1
		'
		Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
		Me.StatusStrip1.Location = New System.Drawing.Point(0, 592)
		Me.StatusStrip1.Name = "StatusStrip1"
		Me.StatusStrip1.Size = New System.Drawing.Size(931, 22)
		Me.StatusStrip1.TabIndex = 5
		Me.StatusStrip1.Text = "StatusStrip1"
		'
		'ToolStripStatusLabel1
		'
		Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
		Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(42, 17)
		Me.ToolStripStatusLabel1.Text = "Status:"
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(710, 36)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(61, 13)
		Me.Label1.TabIndex = 231
		Me.Label1.Text = "ScrollItems:"
		Me.ToolTip1.SetToolTip(Me.Label1, "Amount of items you want to be found by WishSorter")
		'
		'TextBox2
		'
		Me.TextBox2.Location = New System.Drawing.Point(777, 33)
		Me.TextBox2.Name = "TextBox2"
		Me.TextBox2.Size = New System.Drawing.Size(62, 20)
		Me.TextBox2.TabIndex = 1
		'
		'WebBrowser1
		'
		Me.WebBrowser1.Location = New System.Drawing.Point(931, 31)
		Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
		Me.WebBrowser1.Name = "WebBrowser1"
		Me.WebBrowser1.Size = New System.Drawing.Size(793, 553)
		Me.WebBrowser1.TabIndex = 8
		'
		'ImageList1
		'
		Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
		Me.ImageList1.ImageSize = New System.Drawing.Size(100, 100)
		Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
		'
		'ListView1
		'
		Me.ListView1.Location = New System.Drawing.Point(382, 60)
		Me.ListView1.Name = "ListView1"
		Me.ListView1.Size = New System.Drawing.Size(537, 524)
		Me.ListView1.TabIndex = 4
		Me.ListView1.UseCompatibleStateImageBehavior = False
		'
		'mainfrm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ClientSize = New System.Drawing.Size(931, 614)
		Me.Controls.Add(Me.ListView1)
		Me.Controls.Add(Me.WebBrowser1)
		Me.Controls.Add(Me.TextBox2)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.StatusStrip1)
		Me.Controls.Add(Me.ListBox1)
		Me.Controls.Add(Me.TextBox1)
		Me.Controls.Add(Me.Button1)
		Me.Controls.Add(Me.MenuStrip1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MainMenuStrip = Me.MenuStrip1
		Me.MaximizeBox = False
		Me.Name = "mainfrm"
		Me.ShowIcon = False
		Me.Text = "WishSorter"
		Me.MenuStrip1.ResumeLayout(False)
		Me.MenuStrip1.PerformLayout()
		Me.StatusStrip1.ResumeLayout(False)
		Me.StatusStrip1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Button1 As Button
	Friend WithEvents TextBox1 As TextBox
	Friend WithEvents ListBox1 As ListBox
	Friend WithEvents MenuStrip1 As MenuStrip
	Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
	Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents WebbrowserToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents StatusStrip1 As StatusStrip
	Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
	Friend WithEvents Label1 As Label
	Friend WithEvents ToolTip1 As ToolTip
	Friend WithEvents TextBox2 As TextBox
	Friend WithEvents WebBrowser1 As WebBrowser
	Friend WithEvents ImageList1 As ImageList
	Friend WithEvents ListView1 As ListView
End Class
