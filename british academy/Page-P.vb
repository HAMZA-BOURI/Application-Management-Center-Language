Imports System.Data.SqlClient
Public Class Page_P
    'for panal move
    Private Property moveform As Boolean
    Dim A As Integer
    Private Property moveform_mouseP As Point
    Dim idstu(50) As String
    Dim namstu(50) As String
    'for return value from Form-P
    Public Property Profuser As String
    Public Property Profpass As String
    Private Sub closspage()
        AbsPage.Visible = False
        AbsPage.BackColor = Color.Transparent
        buttabs.BackColor = Color.Transparent
        PicAbs.BackColor = Color.Transparent
        profilpqge.Visible = False
        profilpqge.BackColor = Color.Transparent
        Profile.BackColor = Color.Transparent
        Picprofil.BackColor = Color.Transparent

    End Sub
    ''Data Source=DESKTOP-I4FAKQP\NEWSQL;Initial Catalog=british-academy;Integrated Security=True
    Dim con As String = "Data Source=DESKTOP-I4FAKQP\NEWSQL;Initial Catalog=british-academy;Integrated Security=True "
    ''/start AbsPage
    'to afficher absince for page home 
    Private Sub dateADS()
        Dim com As String = "SELECT S.name AS 'Student Name' , S.prename AS 'Student Surname' 
            , A.NameClass AS Class, usernameProf As 'Teacher UserName' , A.dateA AS 'Date', A.StatusE AS 'Status'
            FROM absence A 
            INNER JOIN student S ON A.idStudent = S.idStudent
            where usernameProf='" & Profuser & "' ;"
        Using conn As New SqlConnection(con)
            Using comm As New SqlCommand(com, conn)
                conn.Open()
                Using reader As SqlDataReader = comm.ExecuteReader()
                    ' Create a DataTable to hold the data
                    Dim table As New DataTable()
                    table.Load(reader)
                    ' Bind the DataTable to the DataGridView
                    dateabs.DataSource = table
                End Using
            End Using
        End Using
    End Sub
    'Stclass it's the select function on the studente page
    Private Sub StAclass()
        Dim SLT As String = StatusA.SelectedItem
        Dim se As String = "SELECT S.name AS 'Student Name' , S.prename AS 'Student Surname' , S.nameClass AS Class, usernameProf As 'Teacher UserName' , A.dateA AS 'Date', A.StatusE AS 'Status'
            FROM absence A 
                        INNER JOIN student S ON A.idStudent = S.idStudent
                        where StatusE like '%" & SLT & "%' and usernameProf='" & Profuser & "';"
        Using conn As New SqlConnection(con)
            Using com As New SqlCommand(se, conn)
                Using Ad As New SqlDataAdapter(com)
                    Dim table As New DataTable()
                    Ad.Fill(table)
                    dateabs.DataSource = table
                End Using
            End Using
        End Using
    End Sub
    'SeABS it's the search function on the studente page
    Private Sub SeABS()
        Dim SEE As String = TextA.Text
        Dim se As String = "SELECT S.name AS 'Student Name' , S.prename AS 'Student Surname' , nameClass AS Class, usernameProf As 'Teacher UserName' , A.dateA AS 'Date', A.StatusE AS 'Status'
                            FROM absence A  
                            INNER JOIN student S ON A.idStudent = S.idStudent
                            where CONCAT(S.name,prename,email,nameclass) like '%" & SEE & "%';"
        Using conn As New SqlConnection(con)
            Using com As New SqlCommand(se, conn)
                Using Ad As New SqlDataAdapter(com)
                    Dim table As New DataTable()
                    Ad.Fill(table)
                    dateabs.DataSource = table
                End Using
            End Using
        End Using
    End Sub
    'checkedbox for student
    Public Sub checkedS()
        CheckedEtid.Visible = True
        Using conn As New SqlConnection(con)
            Try
                Dim i As Integer = 0
                conn.Open()
                Dim add As New SqlCommand("select name,prename,numTele from student  where nameclass = '" & ClassBoxA.SelectedItem & "'", conn)
                Dim Reader As SqlDataReader
                Reader = add.ExecuteReader
                While Reader.Read
                    CheckedEtid.Items.Add("" & Reader.GetString(0) & " " & Reader.GetString(1) & "")
                    idstu(i) = Reader.GetString(2)
                    namstu(i) = ("" & Reader.GetString(0) & " " & Reader.GetString(1) & "")
                    i = i + 1
                End While
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End Using

    End Sub
    Private Function checkdate(numTele As String)
        Using conn As New SqlConnection(con)
            Using add As New SqlCommand("select count(*) from Absence where idstudent=(select idStudent from student S where numTele = '" & numTele & "' and nameclass='" & ClassBoxA.SelectedItem & "') and dateA=@dateAV and nameclass='" & ClassBoxA.SelectedItem & "';", conn)
                conn.Open()
                ' to the value 
                add.Parameters.Add(New SqlParameter("@dateAV", SqlDbType.Date)).Value = DateA.Value.ToString
                Dim count As Integer = Convert.ToInt32(add.ExecuteScalar())
                conn.Close()
                Return count > 0
            End Using
        End Using
    End Function
    ' to insert new abs for tabele Absence
    Private Sub addnewabs(acheck As String, numTele As String)
        '  ifabs(numTele)  Not working now but needed last day work
        Dim com As String = "INSERT INTO [dbo].[Absence]
                             (statusE
                             ,dateA
                             ,usernameProf
                             ,idStudent
                             ,NameClass)
                     VALUES
                           ('" & acheck & "'
                           ,@dateA
                           ,'" & Profuser & "'
                           ,(select idStudent from student where numTele = '" & numTele & "')
                           ,'" & ClassBoxA.SelectedItem & "')"
        Using conn As New SqlConnection(con)
            conn.Open()
            Try
                Dim add As New SqlCommand(com, conn)
                'For add New date sqldbtype 
                add.Parameters.Add("@dateA", SqlDbType.Date).Value = DateA.Value.ToString
                ' Execute the add
                add.ExecuteNonQuery()
                dateADS()
            Catch ex As Exception
                MessageBox.Show($"hammaz Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub
    ' for select prof to change list class 
    Public Sub classP()
        Using conn As New SqlConnection(con)
            conn.Open()
            Dim add As New SqlCommand("select nameclass from class C , tabprof  P where P.username ='" & Profuser & "' and P.username = c.usernameProf", conn)
            Dim Reader As SqlDataReader
            Reader = add.ExecuteReader
            ClassBoxA.Items.Add("")
            While Reader.Read
                ClassBoxA.Items.Add(Reader.GetString(0))
            End While
        End Using
    End Sub
    'dateslA it's the select date on the home page
    Private Sub dateslA()
        Dim dateSElect As String = DateRA.Value.Date
        Dim se As String = "SELECT S.name AS 'Student Name' , S.prename AS 'Student Surname' , S.nameClass AS Class, usernameProf As 'Teacher UserName' , A.dateA AS 'Date', A.StatusE AS 'Status'
                            FROM absence A 
            INNER JOIN student S ON A.idStudent = S.idStudent
            where A.dateA = '" & dateSElect & "' and
            usernameProf='" & Profuser & "';"
        Using conn As New SqlConnection(con)
            Using com As New SqlCommand(se, conn)
                Using Ad As New SqlDataAdapter(com)
                    Dim table As New DataTable()
                    Ad.Fill(table)
                    dateabs.DataSource = table
                End Using
            End Using
        End Using
    End Sub
    ''/end AbsPage
    ''*start prifil page
    Private Sub addtotexebox()
        Using conn As New SqlConnection(con)
            conn.Open()
            Dim add As New SqlCommand("select * from [dbo].[tabProf]   where username ='" & Profuser & "';", conn)
            Dim Reader As SqlDataReader
            Try
                Reader = add.ExecuteReader
                boxuser.Text = Profuser
                ' Dim i As Integer = 1
                While Reader.Read
                    boxPassword.Text = Reader.GetString(8)
                    boxdateD.Text = Reader.GetDateTime(4)
                    boxCNI.Text = Reader.GetString(1)
                    Boxname.Text = Reader.GetString(2)
                    boxPrename.Text = Reader.GetString(3)
                    boxemail.Text = Reader.GetString(12)
                    Boxaddress.Text = Reader.GetString(5)
                    boxnum.Text = Reader.GetString(6)
                End While
                P1.Clear()
                P2.Clear()
            Catch ex As Exception
                MessageBox.Show("error" + ex.Message)
            End Try
        End Using

    End Sub
    'addContry= To insert contry into the textboxET
    Private Sub addContry()
        Using conn As New SqlConnection(con)
            conn.Open()
            Dim add As New SqlCommand("SELECT 
                                       NAME
                                       FROM Countries", conn)
            Dim Reader As SqlDataReader
            Try
                Reader = add.ExecuteReader
                While Reader.Read
                    Country.Items.Add(Reader.GetString(0))
                End While
            Catch ex As Exception
                MessageBox.Show("error" + ex.Message)
            End Try

        End Using
    End Sub
    'addcity= To insert city into the textboxET
    Private Sub addcity()
        Using conn As New SqlConnection(con)
            conn.Open()
            Dim add As New SqlCommand("Select nameCi from city where IdCo =(select id from Countries where NAME = '" & Country.SelectedItem & "')", conn)
            Dim Reader As SqlDataReader

            Reader = add.ExecuteReader
            While Reader.Read
                city.Items.Add(Reader.GetString(0))
            End While
        End Using
    End Sub
    ' To update the table
    Private Sub UpdateNew()
        Using conn As New SqlConnection(con)
            Try
                Dim X As Boolean = False
                Dim com As New SqlCommand("UPDATE [british-academy].[dbo].[tabProf]  SET name = @name, prename = @Prename, address = @address, numTele = @numTele,email = @email, passwordA =@Password,country='" & Country.SelectedItem & "',city='" & City.SelectedItem & "'where [username] ='" & boxuser.Text & "';", conn)
                com.Parameters.AddWithValue("@name", Boxname.Text)
                com.Parameters.AddWithValue("@Prename", boxPrename.Text)
                com.Parameters.AddWithValue("@address", Boxaddress.Text)
                com.Parameters.AddWithValue("@numTele", boxnum.Text)
                com.Parameters.AddWithValue("@email", boxemail.Text)
                Dim Reader As SqlDataReader
                Try
                    If P1.Text <> "" And P1.Text <> "" Then
                        If boxPassword.Text = Profpass Then
                            com.Parameters.AddWithValue("@Password", P1.Text)
                        Else
                            com.Parameters.AddWithValue("@Password", Profpass)
                            MessageBox.Show("The current password is incorrect. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        com.Parameters.AddWithValue("@Password", Profpass)
                    End If
                    X = True
                Catch ex As Exception

                End Try
                If (X) Then
                    ' Execute the com operation
                    conn.Open()
                    com.ExecuteNonQuery()
                    conn.Close()
                    MessageBox.Show("Saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    addtotexebox()
                End If

            Catch ex As Exception
                MessageBox.Show($"Error : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ''*end porfil page
    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub PanelMenu_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub ClassBoxA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ClassBoxA.SelectedIndexChanged
        CheckedEtid.Items.Clear()
        checkedS()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim check As String
        Dim a As Integer
        For itm As Integer = 0 To CheckedEtid.Items.Count - 1
            If checkdate(idstu(itm)) = True Then
                MessageBox.Show("The date entered for this for a previously registered (" & CheckedEtid.Items(itm).ToString & ") student", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                a = 0
            ElseIf CheckedEtid.GetItemChecked(itm) And namstu(itm) = CheckedEtid.Items(itm).ToString() Then
                check = "Absent"
                addnewabs(check, idstu(itm))
            Else
                check = "Present"
                addnewabs(check, idstu(itm))
            End If
        Next
        If a > 0 Then
            MessageBox.Show("Data added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub DateRA_ValueChanged(sender As Object, e As EventArgs) Handles DateRA.ValueChanged
        dateslA()
    End Sub

    Private Sub StatusA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles StatusA.SelectedIndexChanged
        StAclass()
    End Sub

    Private Sub TextA_TextChanged(sender As Object, e As EventArgs) Handles TextA.TextChanged
        SeABS()
    End Sub

    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click
        Dim S As String = TextA.Text
        If S = "" Then
            MessageBox.Show("The field is empty, please write", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            SeABS()
        End If
    End Sub

    Private Sub AbsPage_Paint(sender As Object, e As PaintEventArgs) Handles AbsPage.Paint
        dateADS()
        ClassBoxA.Items.Clear()
        ClassBoxA.Text = ""
        Try
            classP()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Application.Exit()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles buttabs.Click
        closspage()
        AbsPage.Visible = True
        AbsPage.BackColor = Color.DeepSkyBlue
        buttabs.BackColor = Color.DeepSkyBlue
        PicAbs.BackColor = Color.DeepSkyBlue
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = WindowState.Minimized
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs)
        If Me.WindowState = WindowState.Normal Then
            Me.WindowState = WindowState.Maximized
        ElseIf Me.WindowState = WindowState.Maximized Then
            Me.WindowState = WindowState.Normal
        End If

    End Sub

    Private Sub Panel2_Paint_1(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
    End Sub

    Private Sub Panel2_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel2.MouseDown
        If e.Button = MouseButtons.Left Then
            moveform = True
            Me.Cursor = Cursors.Default
            moveform_mouseP = e.Location
        End If
    End Sub

    Private Sub Panel2_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel2.MouseUp
        If e.Button = MouseButtons.Left Then
            moveform = True
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Panel2_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel2.MouseMove
        
        If A = 1 Then
            If moveform Then
                Me.Location = Me.Location + (e.Location - moveform_mouseP)
            End If
        End If
    End Sub

    Private Sub Panel2_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel2.MouseClick
        A = 1
    End Sub

    Private Sub Panel2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Panel2.MouseDoubleClick
        A = 0
    End Sub

    Private Sub PictureBox8_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox8.MouseEnter
        PictureBox8.BackColor = Color.Red
    End Sub

    Private Sub PictureBox8_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox8.MouseLeave
        PictureBox8.BackColor = Color.Transparent
    End Sub

    Private Sub TabProfBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.TabProfBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me._british_academyDataSet1)

    End Sub

    Private Sub Page_P_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        closspage()
        AbsPage.Visible = True
        AbsPage.BackColor = Color.DeepSkyBlue
        buttabs.BackColor = Color.DeepSkyBlue
        PicAbs.BackColor = Color.DeepSkyBlue
        'TODO: cette ligne de code charge les données dans la table '_british_academyDataSet1.tabProf'. Vous pouvez la déplacer ou la supprimer selon les besoins.
        Me.TabProfTableAdapter.Fill(Me._british_academyDataSet1.tabProf)

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Profile_Click(sender As Object, e As EventArgs) Handles Profile.Click
        addtotexebox()
        Country.Items.Clear()
        closspage()
        addContry()
        profilpqge.Visible = True
        profilpqge.BackColor = Color.DeepSkyBlue
        Profile.BackColor = Color.DeepSkyBlue
        Picprofil.BackColor = Color.DeepSkyBlue
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles P2.TextChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
        FormP.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If MessageBox.Show("Do you want to save this information?", "Saving information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If P1.Text = P2.Text Then
                UpdateNew()
            Else
                MessageBox.Show("The new password does not match, Enter your new password here again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If

    End Sub

    Private Sub CityComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles City.SelectedIndexChanged

    End Sub

    Private Sub profilpqge_Paint(sender As Object, e As PaintEventArgs) Handles profilpqge.Paint
        'Country.Items.Clear()
        'addContry()
    End Sub

    Private Sub PicAbs_Click(sender As Object, e As EventArgs) Handles PicAbs.Click
        closspage()
        AbsPage.Visible = True
        AbsPage.BackColor = Color.DeepSkyBlue
        buttabs.BackColor = Color.DeepSkyBlue
        PicAbs.BackColor = Color.DeepSkyBlue
    End Sub

    Private Sub Picprofil_Click(sender As Object, e As EventArgs) Handles Picprofil.Click
        addtotexebox()
        closspage()
        addContry()
        profilpqge.Visible = True
        profilpqge.BackColor = Color.DeepSkyBlue
        Profile.BackColor = Color.DeepSkyBlue
        Picprofil.BackColor = Color.DeepSkyBlue
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Me.Hide()
        FormP.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        addtotexebox()
        P1.Clear()
        P2.Clear()
    End Sub

    Private Sub Country_SelectedValueChanged(sender As Object, e As EventArgs) Handles Country.SelectedValueChanged
        City.Items.Clear()
        addcity()
    End Sub

    Private Sub NoShow_Click(sender As Object, e As EventArgs) Handles NoNShow.Click
        ShowNPass.Show()
        NoNShow.Hide()
        P1.UseSystemPasswordChar = True
    End Sub

    Private Sub ShowPass_Click(sender As Object, e As EventArgs) Handles ShowOPass.Click
        ShowOPass.Hide()
        NoOShow.Show()
        boxPassword.UseSystemPasswordChar = False
    End Sub

    Private Sub PictureBox4_Click_1(sender As Object, e As EventArgs) Handles NoCShow.Click
        ShowCPass.Show()
        NoCShow.Hide()
        P2.UseSystemPasswordChar = True
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles ShowNPass.Click
        ShowNPass.Hide()
        NoNShow.Show()
        P1.UseSystemPasswordChar = False
    End Sub

    Private Sub NoCShow_Click(sender As Object, e As EventArgs) Handles NoOShow.Click
        ShowOPass.Show()
        NoOShow.Hide()
        boxPassword.UseSystemPasswordChar = True
    End Sub

    Private Sub ShowCPass_Click(sender As Object, e As EventArgs) Handles ShowCPass.Click
        ShowCPass.Hide()
        NoCShow.Show()
        P2.UseSystemPasswordChar = False
    End Sub
End Class