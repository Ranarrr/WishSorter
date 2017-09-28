<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
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
		Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
		Me.SuspendLayout()
		'
		'WebBrowser1
		'
		Me.WebBrowser1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.WebBrowser1.Location = New System.Drawing.Point(12, 12)
		Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
		Me.WebBrowser1.Name = "WebBrowser1"
		Me.WebBrowser1.ScriptErrorsSuppressed = True
		Me.WebBrowser1.Size = New System.Drawing.Size(1218, 608)
		Me.WebBrowser1.TabIndex = 0
		Me.WebBrowser1.Url = New System.Uri("", System.UriKind.Relative)
		'
		'Form2
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1242, 632)
		Me.Controls.Add(Me.WebBrowser1)
		Me.Name = "Form2"
		Me.ShowIcon = False
		Me.Text = "Webbrowser"
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents WebBrowser1 As WebBrowser
End Class
