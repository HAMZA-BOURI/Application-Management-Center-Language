Imports System.Data.SqlClient

Public Class FormP
    ' i nide change SqlCommand to table prof for sql 
    Private Function coon(User As String, Pass As String) As Boolean
        Using con As New SqlConnection("Data Source=DESKTOP-I4FAKQP\NEWSQL;Initial Catalog=british-academy;Integrated Security=True")
            Using com As New SqlCommand("select count(*) from tabprof where  username = @Username AND passwordA = @Password ;", con)
                com.Parameters.AddWithValue("@Username", User)
                com.Parameters.AddWithValue("@Password", Pass)
                con.Open()
                ' to the value 
                Dim count As Integer = Convert.ToInt32(com.ExecuteScalar())
                con.Close()
                Return count > 0
            End Using
        End Using
    End Function
    Private Function active(User As String) As Boolean
        Using con As New SqlConnection("Data Source=DESKTOP-I4FAKQP\NEWSQL;Initial Catalog=british-academy;Integrated Security=True")
            Using com As New SqlCommand("select count(*) from tabprof where  username = @Username AND active = 'Active' ;", con)
                com.Parameters.AddWithValue("@Username", User)
                con.Open()
                ' to the value 
                Dim count As Integer = Convert.ToInt32(com.ExecuteScalar())
                con.Close()
                Return count > 0
            End Using
        End Using
    End Function
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form2_MenuStart(sender As Object, e As EventArgs) Handles Me.MenuStart

    End Sub

    Private Sub Form2_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FormR.Close()
    End Sub
    'to log in for page prof
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
    'To apply checkout
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Application.Exit()
    End Sub
    ' to show the password
    Private Sub ShowPass_Click(sender As Object, e As EventArgs) Handles ShowPass.Click
        ShowPass.Hide()
        NoShow.Show()
        Password.UseSystemPasswordChar = False
    End Sub
    ' to not show the password
    Private Sub NoShow_Click(sender As Object, e As EventArgs) Handles NoShow.Click
        ShowPass.Show()
        NoShow.Hide()
        Password.UseSystemPasswordChar = True
    End Sub
    'to switch form 
    Private Sub Switch_Click(sender As Object, e As EventArgs) Handles Switch.Click
        Dim newForm As New FormR()
        ' Hide the current form
        Me.Hide()

        ' Show the new form
        newForm.Show()
    End Sub

    Private Sub logIn_Click(sender As Object, e As EventArgs) Handles logIn.Click
        Dim user As String = Textuser.Text
        Dim pass As String = Password.Text
        Page_P.Profuser = user
        Page_P.Profpass = pass
        If coon(user, pass) Then
            If active(user) Then
                Me.Hide()
                Textuser.Text = ""
                Password.Text = ""
                Page_P.Show()
            Else
                MessageBox.Show("Your account is inactive", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Invalid username or password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class