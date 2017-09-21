Public Class loginForm
	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		mainfrm.email = TextBox1.Text
		mainfrm.password = TextBox2.Text
		mainfrm.isLoggedIn = True
		Me.Hide()
	End Sub
End Class