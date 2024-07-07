Imports System.Data.SqlClient
Public Class conn
    Dim con As New SqlConnection("Data Source=DESKTOP-I4FAKQP\NEWSQL;Initial Catalog=british-academy;Integrated Security=True")
    Dim com As New SqlCommand("select * from tabAdmin", con)

End Class
Public Class FormR
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormP.Hide()
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles logIn.TextChanged

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
        FormP.Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Show_Click(sender As Object, e As EventArgs) Handles NoShow.Click
        ShowPass.Show()
        NoShow.Hide()
        Password.UseSystemPasswordChar = True
    End Sub

    Private Sub NoShow_Click(sender As Object, e As EventArgs) Handles ShowPass.Click
        ShowPass.Hide()
        NoShow.Show()
        Password.UseSystemPasswordChar = False
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Switch_Click(sender As Object, e As EventArgs) Handles Switch.Click
        Dim newForm As New FormP()

        ' Hide the current form
        Me.Hide()

        ' Show the new form
        newForm.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class
