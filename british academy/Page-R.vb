Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class Page_R
    ' clear all  textbox 
    Private Sub clear_boxP()
        boxCNI.Clear()
        boxemail.Clear()
        boxnum.Clear()
        boxPassword.Clear()
        boxPrename.Clear()
        boxuser.Clear()
        Boxaddress.Clear()
        Boxname.Clear()
        boxdateD.Value = DateTime.Now
        city.SelectedIndex = -1
        actif.SelectedIndex = -1
        contry.SelectedIndex = -1
    End Sub
    Private Sub clear_boxC()
        NameClass.Clear()
        time.Value = DateTime.Now
        LanguageClass.SelectedIndex = -1
        NiveauBox.SelectedIndex = -1
        UserProf.SelectedIndex = -1

    End Sub
    Private Sub clear_boxE()
        NameBox.Clear()
        DateDE.Value = DateTime.Now
        DateFin.Value = DateTime.Now
        ClassBox.SelectedIndex = -1
    End Sub
    Dim NameClassEtud As String
    'for panal move
    Private Property moveform As Boolean
    Dim A As Integer
    Private Property moveform_mouseP As Point
    Dim idstu(50) As String
    Dim namstu(50) As String
    Private Sub closspage()
        homePage.Visible = False
        pichome.BackColor = Color.SkyBlue
        Buthome.BackColor = Color.SkyBlue
        ' ProfPage
        Profpage.Visible = False
        butprof.BackColor = Color.SkyBlue
        Picprof.BackColor = Color.SkyBlue
        'EtudePage
        EtudPage.Visible = False
        PIcEtud.BackColor = Color.SkyBlue
        ButtEtud.BackColor = Color.SkyBlue
        'AbsPage
        AbsPage.Visible = False
        AbsPage.BackColor = Color.SkyBlue
        buttabs.BackColor = Color.SkyBlue
        PicAbs.BackColor = Color.SkyBlue
        'classPage 
        Classpage.Visible = False
        Classpage.BackColor = Color.SkyBlue
        classBtt.BackColor = Color.SkyBlue
        PicClass.BackColor = Color.SkyBlue
        'endpage
        Endpage.Visible = False
        Endpage.BackColor = Color.SkyBlue
        endbutt.BackColor = Color.SkyBlue
        PicEnd.BackColor = Color.SkyBlue
    End Sub
    Dim con As String = "Data Source=DESKTOP-I4FAKQP\NEWSQL;Initial Catalog=british-academy;Integrated Security=True"
    ''start homepage
    'to afficher absince for page home 
    Private Sub louddata()
        Dim com As String = "SELECT S.name AS 'Student Name' , S.prename AS 'Student surname' , A.NameClass AS Class, usernameProf As 'Teacher UserName' , A.dateA AS 'Date', A.StatusE AS 'Status'
            FROM absence A 
            INNER JOIN student S ON A.idStudent = S.idStudent;"
        Using conn As New SqlConnection(con)
            Using comm As New SqlCommand(com, conn)
                conn.Open()
                Using reader As SqlDataReader = comm.ExecuteReader()
                    ' Create a DataTable to hold the data
                    Dim table As New DataTable()
                    table.Load(reader)
                    ' Bind the DataTable to the DataGridView
                    datahome.DataSource = table
                End Using
            End Using
        End Using
    End Sub
    'So it's the search function on the home page
    Private Sub Se()
        Dim S As String = Textsearch.Text
        Dim se As String = " SELECT S.name AS 'Student Name' , S.prename AS 'Student surname' , A.nameClass AS Class, A.usernameProf As 'Teacher UserName' , A.dateA AS 'Date', A.StatusE AS 'Status'
                            FROM absence A 
                            INNER JOIN student S ON A.idStudent = S.idStudent
							INNER JOIN class C on A.NameClass = C.nameClass
                            where CONCAT(S.name,S.prename,C.nameClass,A.usernameProf) like '%" & S & "%';"
        Using conn As New SqlConnection(con)
            Using com As New SqlCommand(se, conn)
                Using Ad As New SqlDataAdapter(com)
                    Dim table As New DataTable()
                    Ad.Fill(table)
                    datahome.DataSource = table
                End Using
            End Using
        End Using
    End Sub
    'ST it's the select function on the home page
    Private Sub St()
        Dim ST As String = StatusBox.SelectedItem
        Dim se As String = "SELECT S.name AS 'Student Name' , S.prename AS 'Student surname' , A.nameClass AS Class, usernameProf As 'Teacher UserName' , A.dateA AS 'Date', A.StatusE AS 'Status'
                            FROM absence A 
                            INNER JOIN student S ON A.idStudent = S.idStudent
                            where StatusE like '%" & ST & "%';"
        Using conn As New SqlConnection(con)
            Using com As New SqlCommand(se, conn)
                Using Ad As New SqlDataAdapter(com)
                    Dim table As New DataTable()
                    Try
                        Ad.Fill(table)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                    datahome.DataSource = table
                End Using
            End Using
        End Using
    End Sub
    'dateslH it's the select date on the home page
    Private Sub dateslH()
        Dim se As String = "SELECT S.name AS 'Student Name' , S.prename AS 'Student surname' , A.nameClass AS Class, usernameProf As 'Teacher UserName' , A.dateA AS 'Date', A.StatusE AS 'Status'
                            FROM absence A 
                            INNER JOIN student S ON A.idStudent = S.idStudent
                            where CONVERT(DATE, A.dateA, 103) =@dateAV;"

        Using conn As New SqlConnection(con)
            Using com As New SqlCommand(se, conn)

                Using Ad As New SqlDataAdapter(com)
                    com.Parameters.Add(New SqlParameter("@dateAV", SqlDbType.Date)).Value = DateRH.Value.ToString
                    Dim table As New DataTable()
                    Ad.Fill(table)
                    datahome.DataSource = table
                End Using
            End Using
        End Using
    End Sub
    '' end homepage
    ''*start ProfPage 
    'Dataproff is a function to display the table tabProf
    Private Sub Dataproff()
        Using conn As New SqlConnection(con)
            Using com As New SqlCommand("select P.CNI as CNI, P.name AS Name ,P.prename as Surname , P.dateD AS 'Start Date' , P.email as Mail ,P.numTele AS 'Phone Number',country As Country
                                        ,city As City , active as 'Account status '
                                        from tabProf P;", conn)
                conn.Open()
                Using reader As New SqlDataAdapter(com)
                    'Create A DataTable to hold the data
                    Dim table As New DataTable
                    reader.Fill(table)
                    ' Bind the DataTable to the DataGridView
                    tabProf.DataSource = table
                End Using
            End Using
        End Using
    End Sub
    ' to insert new prof for tabele tabProf
    Private Sub addnew()
        Dim com As String = "INSERT INTO tabProf  (name, prename, CNI , address,numTele,dateD,email, username,passwordA,country,city,active ) 
        VALUES(@name,@Prename,@CNI,@address,@Numtele,@dateD,@email,@user,@Password,'" & contry.SelectedItem & "','" & city.SelectedItem & "','" & actif.SelectedItem & "') ;"
        Using conn As New SqlConnection(con)
            conn.Open()
            Try
                Dim add As New SqlCommand(com, conn)
                add.Parameters.AddWithValue("@name", Boxname.Text)
                add.Parameters.AddWithValue("@Prename", boxPrename.Text)
                add.Parameters.AddWithValue("@CNI", boxCNI.Text)
                add.Parameters.AddWithValue("@address", Boxaddress.Text)
                add.Parameters.AddWithValue("@numTele", boxnum.Text)
                add.Parameters.AddWithValue("@email", boxemail.Text)
                add.Parameters.AddWithValue("@user", boxuser.Text)
                add.Parameters.AddWithValue("@Password", boxPassword.Text)
                'For add New date sqldbtype 
                add.Parameters.Add("@dateD", SqlDbType.Date).Value = boxdateD.Value.ToString
                ' Execute the add
                add.ExecuteNonQuery()
                Dataproff()
                MessageBox.Show("Data added successfully!", "success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                clear_boxP()
            Catch ex As Exception
                MessageBox.Show($"Error : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub
    ' the Function idprof 
    Private Function CNI(B As Integer)
        Using conn As New SqlConnection(con)
            conn.Open()
            Dim add As New SqlCommand("select idProf from tabProf  where CNI ='" & tabProf.SelectedRows(0).Cells(0).Value.ToString() & "';", conn)
            Dim Reader As SqlDataReader
            Reader = add.ExecuteReader
            While Reader.Read
                B = Reader.GetInt32(0)
            End While
        End Using
        Return B
    End Function
    ' To update the table
    Private Sub UpdateNew()
        Dim numCIN As Integer
        Dim com As String = "UPDATE tabProf  SET name = @name, prename = @Prename, CNI = @CNI, address = @address, numTele = @numTele, dateD = @dateD, email = @email, username = @user, passwordA = @Password,country='" & contry.SelectedItem & "',city='" & city.SelectedItem & "',active = '" & actif.SelectedItem & "' where idProf=" & CNI(numCIN) & ";"
        Using conn As New SqlConnection(con)
            Try
                Dim update As New SqlCommand(com, conn)
                update.Parameters.AddWithValue("@name", Boxname.Text)
                update.Parameters.AddWithValue("@Prename", boxPrename.Text)
                update.Parameters.AddWithValue("@CNI", boxCNI.Text)
                update.Parameters.AddWithValue("@address", Boxaddress.Text)
                update.Parameters.AddWithValue("@numTele", boxnum.Text)
                update.Parameters.Add("@dateD", SqlDbType.Date).Value = boxdateD.Value
                update.Parameters.AddWithValue("@email", boxemail.Text)
                update.Parameters.AddWithValue("@user", boxuser.Text)
                update.Parameters.AddWithValue("@Password", boxPassword.Text)
                ' Execute the update operation
                conn.Open()
                update.ExecuteNonQuery()
                Dataproff()
                conn.Close()
                MessageBox.Show("Successfully updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                clear_boxP()
            Catch ex As Exception
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub
    'addtotexebox = To insert data into the textbox pageProf
    Private Sub addtotexebox()
        Using conn As New SqlConnection(con)
            conn.Open()
            Dim add As New SqlCommand("select * from tabProf   where CNI ='" & tabProf.SelectedRows(0).Cells(0).Value.ToString() & "';", conn)
            Dim Reader As SqlDataReader
            Reader = add.ExecuteReader
            Dim i As Integer = 1
            While Reader.Read
                Dim datebox As DateTime = Reader.GetDateTime(4) 'datebox is a variable for the date sql
                boxdateD.Value = datebox
                boxCNI.Text = Reader.GetString(1)
                Boxname.Text = Reader.GetString(2)
                boxPrename.Text = Reader.GetString(3)
                boxemail.Text = Reader.GetString(12)
                Boxaddress.Text = Reader.GetString(5)
                boxnum.Text = Reader.GetString(6)
                boxuser.Text = Reader.GetString(7)
                boxPassword.Text = Reader.GetString(8)
                contry.Text = ""
                city.Text = ""
                actif.Text = ""
                contry.SelectedText = Reader.GetString(10)
                city.SelectedText = Reader.GetString(9)
                actif.SelectedText = Reader.GetString(11)
            End While
        End Using

    End Sub
    'addtotexebox= To insert data into the combobox for idclass 
    Private Sub idclass()
        Using conn As New SqlConnection(con)
            conn.Open()
            Dim add As New SqlCommand("select nameClass from class", conn)
            Dim Reader As SqlDataReader
            Reader = add.ExecuteReader
            ClassBoxA.Items.Add("")
            ClassBox.Items.Add("")
            While Reader.Read
                If EtudPage.Visible = True Then
                    Stclassbox.Items.Add(Reader.GetString(0))
                    ClassBox.Items.Add(Reader.GetString(0))
                ElseIf AbsPage.Visible = True Then
                    ClassBoxA.Items.Add(Reader.GetString(0))
                End If
            End While
        End Using
    End Sub
    'deleteT = to delete the table 
    Private Sub deleteT()
        Dim numCIN As Integer
        Using conn As New SqlConnection(con)
            Dim delete As New SqlCommand("DELETE FROM tabProf
                         WHERE idProf=" & CNI(numCIN) & ";", conn)
            conn.Open()
            delete.ExecuteNonQuery()
            conn.Close()
            Dataproff()
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
            Reader = add.ExecuteReader
            While Reader.Read
                contry.Items.Add(Reader.GetString(0))
            End While
        End Using
    End Sub
    'addcity= To insert city into the textboxET
    Private Sub addcity()
        Using conn As New SqlConnection(con)
            conn.Open()
            Dim add As New SqlCommand("Select nameCi from city where IdCo =(select id from Countries where NAME = '" & contry.SelectedItem & "')", conn)
            Dim Reader As SqlDataReader
            Reader = add.ExecuteReader
            While Reader.Read
                city.Items.Add(Reader.GetString(0))
            End While
        End Using
    End Sub

    ''*end Profpage
    ''"start etudPage
    ' to afficher absince for studente page
    Private Sub DataEtud()
        Using conn As New SqlConnection(con)
            Using com As New SqlCommand("SELECT  name As Name 
                                        ,prename As SurName
                                        ,dateD  As 'Start Date'
                                        ,dateF  As 'End Date'
                                        ,email  As Mail
                                        ,numTele As 'Phone Number'
                                        ,nameclass As Class
                                        FROM student ", conn)
                conn.Open()
                Using reader As New SqlDataAdapter(com)
                    com.ExecuteNonQuery()
                    ' Create A DataTable to hold the data
                    Dim table As New DataTable
                    reader.Fill(table)
                    ' Bind the DataTable to the DataGridView
                    tabEtud.DataSource = table
                End Using
            End Using
        End Using
    End Sub
    'Stclass it's the select     function on the studente page
    Private Sub Stclass()
        Dim SLT As String = Stclassbox.SelectedItem
        Dim se As String = "SELECT  name As Name 
                                        ,prename As SurName
                                        ,dateD  As 'Start Date'
                                        ,dateF  As 'End Date'
                                        ,email  As Mail
                                        ,numTele As 'Phone Number'
                                        ,nameclass
                                        As Class
                        from student S
                        where nameclass like '%" & SLT & "%';"
        Using conn As New SqlConnection(con)
            Using com As New SqlCommand(se, conn)
                Using Ad As New SqlDataAdapter(com)
                    Dim table As New DataTable()
                    Ad.Fill(table)
                    tabEtud.DataSource = table
                End Using
            End Using
        End Using
    End Sub
    'SeEtud it's the search function on the studente page
    Private Sub SeEtud()
        Dim SEE As String = searchBox.Text
        Dim se As String = "SELECT  name As Name 
                                        ,prename As SurName
                                        ,dateD  As 'Start Date'
                                        ,dateF  As 'End Date'
                                        ,email  As Mail
                                        ,numTele As 'Phone Number'
                                        ,nameclass
                                        As Class
                        from student
                        where CONCAT(name,prename,email,numTele) like '%" & SEE & "%';"
        Using conn As New SqlConnection(con)
            Using com As New SqlCommand(se, conn)
                Using Ad As New SqlDataAdapter(com)
                    Dim table As New DataTable()
                    Ad.Fill(table)
                    tabEtud.DataSource = table
                End Using
            End Using
        End Using
    End Sub
    Private Function checkEtud() As Boolean
        Dim com As String = "select count(*) from student where name='" & NameBox.Text & "' and prename='" & PrenameBox.Text & "' and numTele='" & NumTeleBox.Text & "'"
        Using conn As New SqlConnection(con)
            conn.Open()
            Dim add As New SqlCommand(com, conn)
            Dim Reader As SqlDataReader
            Reader = add.ExecuteReader
            While Reader.Read()
                Return Reader.GetInt32(0) > 0
            End While
        End Using
    End Function
    ' to insert new studente for tabele studente
    Private Sub addnewEtud()
        Dim com As String = "INSERT INTO student (name, prename,dateD,dateF,email,numTele,nameClass) 
        VALUES(@name,@Prename,@DateD,@DateF,@email,@numTele,'" & ClassBox.SelectedItem & "');"
        Using conn As New SqlConnection(con)
            Dim checkclass As New SqlCommand("select nameclass from student where name='" & NameBox.Text & "' and prename='" & PrenameBox.Text & "' and numTele='" & NumTeleBox.Text & "'", conn)
            Dim checknum As New SqlCommand("select count(*) from student where numTele='" & NumTeleBox.Text & "'", conn)
            conn.Open()
            Dim Reader As SqlDataReader
            Reader = checkclass.ExecuteReader
            'Reader.Read()
            Dim add As New SqlCommand(com, conn)
            add.Parameters.AddWithValue("@name", NameBox.Text)
            add.Parameters.AddWithValue("@Prename", PrenameBox.Text)
            add.Parameters.AddWithValue("@numTele", NumTeleBox.Text)
            add.Parameters.AddWithValue("@email", EmailBox.Text)                'For add New date sqldbtype 
            add.Parameters.Add("@DateD", SqlDbType.Date).Value = DateDE.Value.ToString
            add.Parameters.Add("@DateF", SqlDbType.Date).Value = DateFin.Value.ToString
            Try
                If checkEtud() Then
                    Dim boule As Boolean
                    While Reader.Read
                        If (Reader.GetString(0) = ClassBox.Text) Then
                            boule = True
                            Exit While
                        End If
                    End While
                    If boule Then
                        MessageBox.Show("change Name Class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        ' Execute the add
                        Reader.Close()
                        add.ExecuteNonQuery()
                        DataEtud()
                        clear_boxE()
                        MessageBox.Show("Data added successfully!", "success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    Reader.Close()
                    Dim check As SqlDataReader
                    check = checknum.ExecuteReader
                    check.Read()
                    If check.GetInt32(0) <> 0 Then
                        MessageBox.Show("change numero telephone", "chan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        ' Execute the add
                        check.Close()
                        add.ExecuteNonQuery()
                        DataEtud()
                        clear_boxE()
                        MessageBox.Show("Data added successfully!", "success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            conn.Close()
        End Using
    End Sub
    ' to update the table PageEtud
    Private Sub UpdateE()
        Dim com As String = "UPDATE student SET name = @name, prename = @Prename, numTele = @numTele, dateD = @dateD, email = @email, dateF = @dateF, nameclass='" & ClassBox.SelectedItem & "' where idStudent =(select idStudent from student where name ='" & NameBox.Text & "' and prename  ='" & PrenameBox.Text & "' and email='" & EmailBox.Text & "' and numTele  ='" & NumTeleBox.Text & "' and nameclass='" & NameClassEtud & "');"
        Using conn As New SqlConnection(con)
            Try
                Dim update As New SqlCommand(com, conn)
                update.Parameters.AddWithValue("@name", NameBox.Text)
                update.Parameters.AddWithValue("@Prename", PrenameBox.Text)
                update.Parameters.AddWithValue("@numTele", NumTeleBox.Text)
                update.Parameters.Add("@dateD", SqlDbType.Date).Value = DateDE.Value
                update.Parameters.Add("@dateF", SqlDbType.Date).Value = DateFin.Value
                update.Parameters.AddWithValue("@email", EmailBox.Text)
                ' Execute the update operation
                conn.Open()
                update.ExecuteNonQuery()
                conn.Close()
                clear_boxE()
                DataEtud()
                MessageBox.Show("Successfully updated", "success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub
    'addtotexeboxEt= To insert data into the textboxET
    Private Sub addtotexeboxEt()
        Using conn As New SqlConnection(con)
            conn.Open()
            Dim add As New SqlCommand("select * from student where name = '" & tabEtud.SelectedRows(0).Cells(0).Value.ToString() & "'and prename ='" & tabEtud.SelectedRows(0).Cells(1).Value.ToString() & "'and numTele ='" & tabEtud.SelectedRows(0).Cells(5).Value.ToString() & "'and nameClass ='" & tabEtud.SelectedRows(0).Cells(6).Value.ToString() & "';", conn)
            Dim Reader As SqlDataReader
            Reader = add.ExecuteReader
            Dim i As Integer = 1
            While Reader.Read
                Dim dateD As DateTime = Reader.GetDateTime(3) 'dateD is a variable for the date sql 
                Dim dateF As DateTime = Reader.GetDateTime(4) 'dateF is a variable for the date sql
                DateDE.Value = dateD
                DateFin.Value = dateF
                NameBox.Text = Reader.GetString(1)
                PrenameBox.Text = Reader.GetString(2)
                EmailBox.Text = Reader.GetString(7)
                NumTeleBox.Text = Reader.GetString(5)
                ClassBox.SelectedItem = ""
                ClassBox.SelectedItem = Reader.GetString(6)
            End While
        End Using
    End Sub
    'deleteE = to delete the table 
    Private Sub deleteE()
        MessageBox.Show(tabEtud.SelectedRows(0).Cells(5).Value.ToString())
        Using conn As New SqlConnection(con)
            Dim delete As New SqlCommand("DELETE FROM [dbo].[student]
                                            WHERE numTele='" & NumTeleBox.Text & "'  and nameClass ='" & ClassBox.SelectedItem & "';", conn)
            conn.Open()
            delete.ExecuteNonQuery()
            conn.Close()
            DataEtud()
        End Using
    End Sub
    ''"end etudPage 
    ''/start AbsPage
    'to afficher absince for page home 
    Private Sub dateADS()
        Dim com As String = "SELECT S.name AS 'Student Name' , S.prename AS 'Student Surname' ,
                                    A.nameClass AS Class, usernameProf As 'Teacher UserName' ,
                                    A.dateA AS 'Date', A.StatusE AS 'Status'
            FROM absence A 
            INNER JOIN student S ON A.idStudent = S.idStudent;"
        Using conn As New SqlConnection(con)
            Using comm As New SqlCommand(com, conn)
                conn.Open()
                Using reader As SqlDataReader = comm.ExecuteReader()
                    ' Create a DataTable to hold the data
                    Dim table As New DataTable()
                    table.Load(reader)
                    ' Bind the DataTable to the DataGridView
                    DataABS.DataSource = table
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
                        where StatusE like '%" & SLT & "%';"
        Using conn As New SqlConnection(con)
            Using com As New SqlCommand(se, conn)
                Using Ad As New SqlDataAdapter(com)
                    Dim table As New DataTable()
                    Ad.Fill(table)
                    DataABS.DataSource = table
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
                    DataABS.DataSource = table
                End Using
            End Using
        End Using
    End Sub
    'checkedbox for student
    Public Sub checkedS()
        CheckedEtid.Visible = True
        Using conn As New SqlConnection(con)
            Dim i As Integer = 0
            conn.Open()
            Dim add As New SqlCommand("select name,prename,numTele from student  where  nameclass = '" & ClassBoxA.SelectedItem & "'", conn)
            Dim Reader As SqlDataReader
            Reader = add.ExecuteReader
            While Reader.Read
                CheckedEtid.Items.Add("" & Reader.GetString(0) & " " & Reader.GetString(1) & "")
                idstu(i) = Reader.GetString(2)
                namstu(i) = ("" & Reader.GetString(0) & " " & Reader.GetString(1) & "")
                i = i + 1
            End While
        End Using

    End Sub
    'BOXPROF for add brof
    Public Sub boxProf()
        Using conn As New SqlConnection(con)
            conn.Open()
            Dim add As New SqlCommand("select username from tabProf", conn)
            Dim Reader As SqlDataReader
            Reader = add.ExecuteReader
            ProfBoxA.Items.Add(" ")
            While Reader.Read
                ProfBoxA.Items.Add(Reader.GetString(0))
            End While
        End Using
    End Sub
    ' to insert new abs for tabele Absence
    Private Sub addnewabs(acheck As String, numTele As String)
        Dim com As String = "INSERT INTO [dbo].[Absence]
                             (statusE
                             ,dateA
                             ,usernameProf
                             ,idStudent
                             ,NameClass)
                     VALUES
                           ('" & acheck & "'
                           ,@dateA
                           , '" & ProfBoxA.SelectedItem & "'
                           ,(select idStudent from student where numTele = '" & numTele & "'and NameClass='" & ClassBoxA.SelectedItem & "')
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
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub
    Private Function checkdate(numTele As String)
        Using conn As New SqlConnection(con)
            Using add As New SqlCommand("select count(*) from Absence where idstudent=(select idStudent from student S where numTele = '" & numTele & "' and nameclass='" & ClassBoxA.SelectedItem & "') and dateA=@dateAV and nameclass='" & ClassBoxA.SelectedItem & "' and usernameProf ='" & UserProf.SelectedItem & "'", conn)
                conn.Open()
                ' to the value 
                add.Parameters.Add(New SqlParameter("@dateAV", SqlDbType.Date)).Value = DateA.Value.ToString
                Dim count As Integer = Convert.ToInt32(add.ExecuteScalar())
                conn.Close()
                Return count > 0
            End Using
        End Using
    End Function

    ' for select class to change list prof 
    Public Sub profC()
        If ClassBoxA.SelectedItem <> "" Then
            Using conn As New SqlConnection(con)
                conn.Open()
                Dim add As New SqlCommand("select username from tabProf P , class C where nameClass = '" & ClassBoxA.SelectedItem & "' and P.username = c.usernameProf; ", conn)
                Dim Reader As SqlDataReader
                Reader = add.ExecuteReader
                ProfBoxA.Items.Add("")
                While Reader.Read
                    ProfBoxA.Items.Add(Reader.GetString(0))
                End While
            End Using
        Else
            ClassBoxA.Items.Clear()
            boxProf()
        End If
    End Sub
    ' for select prof to change list class 
    Public Sub classP()
        If ProfBoxA.SelectedItem <> "" Then
            Using conn As New SqlConnection(con)
                conn.Open()
                Dim add As New SqlCommand("select nameclass from class C , tabprof  P where P.username ='" & ProfBoxA.SelectedItem & "' and P.username = c.usernameProf", conn)
                Dim Reader As SqlDataReader
                Reader = add.ExecuteReader
                ClassBoxA.Items.Add("")
                While Reader.Read
                    ClassBoxA.Items.Add(Reader.GetString(0))
                End While
            End Using
        End If
    End Sub
    'dateslA it's the select date on the home page
    Private Sub dateslA()
        Dim se As String = "SELECT S.name AS 'Student Name' , S.prename AS 'Student Surname' , A.nameClass AS Class, usernameProf As 'Teacher UserName' , A.dateA AS 'Date', A.StatusE AS 'Status'
                            FROM absence A 
            INNER JOIN student S ON A.idStudent = S.idStudent
            where CONVERT(DATE, A.dateA, 103) =@dateAV ;"
        Using conn As New SqlConnection(con)
            Using com As New SqlCommand(se, conn)
                Using Ad As New SqlDataAdapter(com)
                    com.Parameters.Add(New SqlParameter("@dateAV", SqlDbType.Date)).Value = DateRH.Value.ToString

                    Dim table As New DataTable()
                    Ad.Fill(table)
                    DataABS.DataSource = table
                End Using
            End Using
        End Using
    End Sub
    ''/end AbsPage
    '';start Class
    'to afficher absince for page home 
    Private Sub dateClass()
        Dim com As String = "select nameClass as Class , LanguageClass as 'Language' , timeClass AS'Class time' , usernameProf As 'Teacher UserName',niveau as Level from class "
        Using conn As New SqlConnection(con)
            Using comm As New SqlCommand(com, conn)
                conn.Open()
                Using reader As SqlDataReader = comm.ExecuteReader()
                    ' Create a DataTable to hold the data
                    Dim table As New DataTable()
                    table.Load(reader)
                    ' Bind the DataTable to the DataGridView
                    tabClass.DataSource = table
                End Using
            End Using
        End Using
    End Sub
    ' to insert new class for tabele dateclass
    Private Sub addnewclass()
        Dim com As String = "INSERT INTO [dbo].[class]
                           (nameClass
                           ,LanguageClass
                           ,timeClass
                           ,usernameProf
                           ,niveau)
                     VALUES
                           ('" & NameClass.Text & "'
                           ,'" & LanguageClass.SelectedItem & "'
                           ,'" & time.Value.TimeOfDay.ToString & "'
                           ,'" & UserProf.SelectedItem & "'
                           ,'" & NiveauBox.SelectedItem & "')"
        Using conn As New SqlConnection(con)
            conn.Open()
            Try
                Dim add As New SqlCommand(com, conn)
                add.ExecuteNonQuery()
                dateClass()
                MessageBox.Show("Data added successfully!", "success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                clear_boxC()
            Catch ex As Exception
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub
    'BOXPROF for add brof
    Public Sub boxProfclass()
        Using conn As New SqlConnection(con)
            conn.Open()
            Dim add As New SqlCommand("select username from tabProf", conn)
            Dim Reader As SqlDataReader
            Reader = add.ExecuteReader
            ProfBoxA.Items.Add(" ")
            While Reader.Read
                UserProf.Items.Add(Reader.GetString(0))
            End While
        End Using
    End Sub
    ' To update the table
    Private Sub UpdateNewClass()
        Dim com As String = "UPDATE [dbo].[class]
                           SET [nameClass] = '" & NameClass.Text & "'
                              ,[LanguageClass] = '" & LanguageClass.SelectedItem & "'
                              ,[timeClass] = '" & time.Value.TimeOfDay.ToString() & "'
                              ,[usernameProf] = '" & UserProf.SelectedItem & "'
                         WHERE idClass = (select idClass from class where nameClass='" & NameClass.Text & "')"
        Using conn As New SqlConnection(con)
            Try
                Dim update As New SqlCommand(com, conn)
                conn.Open()
                update.ExecuteNonQuery()
                dateClass()
                conn.Close()
                MessageBox.Show("Successfully updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                clear_boxC()
            Catch ex As Exception
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub
    'addtotexeboxcl= To insert data into the textbox for table class
    Private Sub addtotexeboxcl()
        Using conn As New SqlConnection(con)
            conn.Open()
            Dim add As New SqlCommand("select * from class where nameClass='" & tabClass.SelectedRows(0).Cells(0).Value & "';", conn)
            Dim Reader As SqlDataReader
            Reader = add.ExecuteReader
            While Reader.Read
                Dim datebox As TimeSpan = Reader.GetTimeSpan(3) 'datebox is a variable for the date sql
                NameClass.Text = Reader.GetString(1)
                LanguageClass.SelectedItem = Reader.GetString(2)
                time.Value.Add(datebox)
                UserProf.SelectedItem = ""
                UserProf.SelectedItem = Reader.GetString(4)
                NiveauBox.SelectedItem = ""
                NiveauBox.SelectedItem = Reader.GetString(5)
            End While
        End Using

    End Sub
    'deletecl = to delete the table 
    Private Sub deletecl()
        Using conn As New SqlConnection(con)
            Dim delete As New SqlCommand("DELETE FROM class
                                            WHERE nameclass = '" & NameClass.Text & "';", conn)
            conn.Open()

            delete.ExecuteNonQuery()
            conn.Close()
            dateClass()
        End Using
    End Sub
    '';end Class
    ''!start page
    ' to afficher absince for studente page
    Private Sub datafinetud()
        Using conn As New SqlConnection(con)
            Using com As New SqlCommand("SELECT  name As Name 
                                        ,prename As SurName
                                        ,dateD  As 'Start Date'
                                        ,dateF  As 'End Date'
                                        ,email  As Mail
                                        ,numTele As 'Phone Number'
                                        ,nameclass As Class
                                        FROM student 
                                        WHERE CONVERT(DATE, dateF, 103) <@CurrentDate ", conn)
                com.Parameters.Add(New SqlParameter("@CurrentDate", SqlDbType.Date)).Value = DateTime.Now
                conn.Open()
                Using reader As New SqlDataAdapter(com)
                    com.ExecuteNonQuery()
                    ' Create A DataTable to hold the data
                    Dim table As New DataTable
                    reader.Fill(table)
                    ' Bind the DataTable to the DataGridView
                    EndStudydata.DataSource = table
                End Using
            End Using
        End Using
    End Sub
    ''!end page

    Private Sub Buthome_Click(sender As Object, e As EventArgs) Handles Buthome.Click
        closspage()
        homePage.Visible = True
        homePage.BackColor = Color.LightSkyBlue
        Buthome.BackColor = Color.LightSkyBlue
        pichome.BackColor = Color.LightSkyBlue
    End Sub
    Private Sub Page_R_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            louddata()
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
        FormR.Close()
        BackColor = Color.LightSkyBlue
        Buthome.BackColor = Color.LightSkyBlue
        pichome.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub AbsenceBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.AbsenceBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me._british_academyDataSet)

    End Sub
    Private Sub AbsenceBindingNavigatorSaveItem_Click_1(sender As Object, e As EventArgs)
        Me.Validate()
        Me.AbsenceBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me._british_academyDataSet)

    End Sub
    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Application.Exit()
    End Sub
    Private Sub FillToolStripButton_Click(sender As Object, e As EventArgs)
        Try
            Me.AbsenceTableAdapter.Fill(Me._british_academyDataSet.absence)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub PicSearch_MouseEnter(sender As Object, e As EventArgs) Handles PicSearch.MouseEnter
        PicSearch.BackColor = Color.DeepSkyBlue
    End Sub
    Private Sub PicSearch_MouseLeave(sender As Object, e As EventArgs) Handles PicSearch.MouseLeave
        PicSearch.BackColor = Color.LightSkyBlue
    End Sub
    Private Sub FillByToolStripButton_Click(sender As Object, e As EventArgs)
        Try
            Me.AbsenceTableAdapter.FillBy(Me._british_academyDataSet.absence)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Textsearch_TextChanged(sender As Object, e As EventArgs) Handles Textsearch.TextChanged
        Try
            Se()
        Catch ex As Exception
            MessageBox.Show("An error occurred while verifying the student: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub PicSearch_Click(sender As Object, e As EventArgs) Handles PicSearch.Click
        Dim S As String = Textsearch.Text
        If S = "" Then
            MessageBox.Show("The field is empty, please write", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Se()
        End If
    End Sub
    Private Sub StatusBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles StatusBox.SelectedIndexChanged
        St()
    End Sub
    'end home page 
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles butprof.Click
        closspage()
        Dataproff()
        addContry()
        Profpage.Visible = True
        Profpage.BackColor = Color.LightSkyBlue
        butprof.BackColor = Color.LightSkyBlue
        Picprof.BackColor = Color.LightSkyBlue
    End Sub
    Private Sub FillToolStripButton_Click_1(sender As Object, e As EventArgs)
        Try
            Me.TabProfTableAdapter.Fill(Me._british_academyDataSet.tabProf)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub butADD_Click(sender As Object, e As EventArgs) Handles butADD.Click
        Try
            If Boxname.Text = "" Or boxPrename.Text = "" Or boxCNI.Text = "" Or boxPassword.Text = "" Or boxuser.Text = "" Then
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                addnew()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub update_Click(sender As Object, e As EventArgs) Handles update.Click
        Try
            If Boxname.Text = "" Or boxPrename.Text = "" Or boxCNI.Text = "" Or boxPassword.Text = "" Or boxuser.Text = "" Then
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                UpdateNew()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TabProfToolStripButton_Click(sender As Object, e As EventArgs)
        Try
            Me.TabProfTableAdapter.tabProf(Me._british_academyDataSet.tabProf)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub TabProfToolStripButton1_Click(sender As Object, e As EventArgs)
        Try
            Me.TabProfTableAdapter.tabProf(Me._british_academyDataSet.tabProf)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub TabProfToolStripButton_Click_1(sender As Object, e As EventArgs)
        Try
            Me.TabProfTableAdapter.tabProf(Me._british_academyDataSet.tabProf)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Profpage_Paint(sender As Object, e As PaintEventArgs) Handles Profpage.Paint
        contry.Items.Clear()
        addContry()
    End Sub
    Private Sub TabProfDataGridView_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tabProf.RowHeaderMouseClick
        'for select row table
        Dim textbo() As TextBox = New TextBox() {boxCNI, Boxname, boxPrename, boxemail, Boxaddress, boxnum, boxuser, boxPassword}
        Try
            If tabProf.SelectedRows.Count <> -1 Then
                addtotexebox()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ' to show the password
    Private Sub ShowPass_Click(sender As Object, e As EventArgs) Handles ShowPass.Click
        ShowPass.Hide()
        NoShow.Show()
        boxPassword.UseSystemPasswordChar = False
    End Sub
    ' to not show the password
    Private Sub NoShow_Click(sender As Object, e As EventArgs) Handles NoShow.Click
        ShowPass.Show()
        NoShow.Hide()
        boxPassword.UseSystemPasswordChar = True
    End Sub

    Private Sub delete_Click(sender As Object, e As EventArgs) Handles delete.Click
        Try
            If MessageBox.Show("Are you really going to get rid of this Teacher?", "Delete Teacher", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If tabProf.SelectedRows.Count <> -1 Then
                    deleteT()
                    MessageBox.Show("Well Delete", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PIcEtud.Click
        closspage()
        DataEtud()
        EtudPage.Visible = True
        EtudPage.BackColor = Color.LightSkyBlue
        ButtEtud.BackColor = Color.LightSkyBlue
        PIcEtud.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Picprof_Click(sender As Object, e As EventArgs) Handles Picprof.Click
        closspage()
        Dataproff()
        Profpage.Visible = True
        Profpage.BackColor = Color.LightSkyBlue
        butprof.BackColor = Color.LightSkyBlue
        Picprof.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub pichome_Click(sender As Object, e As EventArgs) Handles pichome.Click
        closspage()
        homePage.Visible = True
        homePage.BackColor = Color.LightSkyBlue
        Buthome.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub ButtEtud_Click(sender As Object, e As EventArgs) Handles ButtEtud.Click
        closspage()
        DataEtud()
        EtudPage.Visible = True
        EtudPage.BackColor = Color.LightSkyBlue
        ButtEtud.BackColor = Color.LightSkyBlue
        PIcEtud.BackColor = Color.LightSkyBlue
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Stclassbox.SelectedIndexChanged
        Stclass()
    End Sub

    Private Sub GroupBox5_Enter(sender As Object, e As EventArgs) Handles GroupBox5.Enter

    End Sub

    Private Sub EtudPage_Paint(sender As Object, e As PaintEventArgs) Handles EtudPage.Paint
        Stclassbox.Items.Clear()
        ClassBox.Items.Clear()
        idclass()
    End Sub

    Private Sub searchBox_TextChanged(sender As Object, e As EventArgs) Handles searchBox.TextChanged
        Try
            SeEtud()
        Catch ex As Exception
            MessageBox.Show("An error occurred while verifying the student: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub PictureBox4_Click_1(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Dim S As String = searchBox.Text
        If S = "" Then
            MessageBox.Show("The field is empty, please write", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            SeEtud()
        End If
    End Sub

    Private Sub addBut_Click(sender As Object, e As EventArgs) Handles addBut.Click
        If NameBox.Text = "" Or PrenameBox.Text = "" Or NumTeleBox.Text = "" Then
            MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf DateDE.Value = DateFin.Value Then
            MessageBox.Show("Verify that the start date should be different from the end date", "Date", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf DateDE.Value > DateFin.Value Then
            MessageBox.Show("Check that the start date must be greater than the end date", "Date", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            addnewEtud()

        End If
    End Sub

    Private Sub upedat_Click(sender As Object, e As EventArgs) Handles upedat.Click
        Try
            UpdateE()
        Catch ex As Exception
            ' Blank because I don't want any action
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ClassBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ClassBox.SelectedIndexChanged
        Stclass()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles AbsPage.Paint
        Try
            dateADS()
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
        ClassBoxA.Items.Clear()
        CheckedEtid.Items.Clear()
        ProfBoxA.Items.Clear()
        boxProf()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles buttabs.Click
        closspage()
        dateADS()
        AbsPage.Visible = True
        AbsPage.BackColor = Color.LightSkyBlue
        buttabs.BackColor = Color.LightSkyBlue
        PicAbs.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If MessageBox.Show("Are you really going to get rid of this student?", "Delete Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If (tabProf.SelectedRows.Count <> -1) Or (NumTeleBox.Text <> "" And ClassBox.Text <> "") Then
                    deleteE()
                    MessageBox.Show("Well Delete", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub ClassBoxA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ClassBoxA.SelectedIndexChanged
        CheckedEtid.Items.Clear()
        checkedS()
    End Sub
    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedEtid.SelectedIndexChanged

    End Sub



    Friend Structure NewStruct
        Public boxCNI As TextBox
        Public Boxname As TextBox
        Public boxPrename As TextBox
        Public boxdateD As DateTimePicker
        Public boxemail As TextBox
        Public Boxaddress As TextBox
        Public boxnum As TextBox
        Public boxuser As TextBox
        Public boxPassword As TextBox
        Public boxclass As ComboBox

        Public Sub New(boxCNI As TextBox, boxname As TextBox, boxPrename As TextBox, boxdateD As DateTimePicker, boxemail As TextBox, boxaddress As TextBox, boxnum As TextBox, boxuser As TextBox, boxPassword As TextBox, boxclass As ComboBox)
            Me.boxCNI = boxCNI
            Me.Boxname = boxname
            Me.boxPrename = boxPrename
            Me.boxdateD = boxdateD
            Me.boxemail = boxemail
            Me.Boxaddress = boxaddress
            Me.boxnum = boxnum
            Me.boxuser = boxuser
            Me.boxPassword = boxPassword
            Me.boxclass = boxclass
        End Sub

        Public Overrides Function Equals(obj As Object) As Boolean
            If Not (TypeOf obj Is NewStruct) Then
                Return False
            End If

            Dim other = DirectCast(obj, NewStruct)
            Return EqualityComparer(Of TextBox).Default.Equals(boxCNI, other.boxCNI) AndAlso
               EqualityComparer(Of TextBox).Default.Equals(Boxname, other.Boxname) AndAlso
               EqualityComparer(Of TextBox).Default.Equals(boxPrename, other.boxPrename) AndAlso
               EqualityComparer(Of DateTimePicker).Default.Equals(boxdateD, other.boxdateD) AndAlso
               EqualityComparer(Of TextBox).Default.Equals(boxemail, other.boxemail) AndAlso
               EqualityComparer(Of TextBox).Default.Equals(Boxaddress, other.Boxaddress) AndAlso
               EqualityComparer(Of TextBox).Default.Equals(boxnum, other.boxnum) AndAlso
               EqualityComparer(Of TextBox).Default.Equals(boxuser, other.boxuser) AndAlso
               EqualityComparer(Of TextBox).Default.Equals(boxPassword, other.boxPassword) AndAlso
               EqualityComparer(Of ComboBox).Default.Equals(boxclass, other.boxclass)
        End Function

        Public Overrides Function GetHashCode() As Integer
            Return (boxCNI, Boxname, boxPrename, boxdateD, boxemail, Boxaddress, boxnum, boxuser, boxPassword, boxclass).GetHashCode()
        End Function

        Public Sub Deconstruct(ByRef boxCNI As TextBox, ByRef boxname As TextBox, ByRef boxPrename As TextBox, ByRef boxdateD As DateTimePicker, ByRef boxemail As TextBox, ByRef boxaddress As TextBox, ByRef boxnum As TextBox, ByRef boxuser As TextBox, ByRef boxPassword As TextBox, ByRef boxclass As ComboBox)
            boxCNI = Me.boxCNI
            boxname = Me.Boxname
            boxPrename = Me.boxPrename
            boxdateD = Me.boxdateD
            boxemail = Me.boxemail
            boxaddress = Me.Boxaddress
            boxnum = Me.boxnum
            boxuser = Me.boxuser
            boxPassword = Me.boxPassword
            boxclass = Me.boxclass
        End Sub

        Public Shared Widening Operator CType(value As NewStruct) As (boxCNI As TextBox, Boxname As TextBox, boxPrename As TextBox, boxdateD As DateTimePicker, boxemail As TextBox, Boxaddress As TextBox, boxnum As TextBox, boxuser As TextBox, boxPassword As TextBox, boxclass As ComboBox)
            Return (value.boxCNI, value.Boxname, value.boxPrename, value.boxdateD, value.boxemail, value.Boxaddress, value.boxnum, value.boxuser, value.boxPassword, value.boxclass)
        End Operator

        Public Shared Widening Operator CType(value As (boxCNI As TextBox, Boxname As TextBox, boxPrename As TextBox, boxdateD As DateTimePicker, boxemail As TextBox, Boxaddress As TextBox, boxnum As TextBox, boxuser As TextBox, boxPassword As TextBox, boxclass As ComboBox)) As NewStruct
            Return New NewStruct(value.boxCNI, value.Boxname, value.boxPrename, value.boxdateD, value.boxemail, value.Boxaddress, value.boxnum, value.boxuser, value.boxPassword, value.boxclass)
        End Operator
    End Structure

    Private Sub StatusA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles StatusA.SelectedIndexChanged
        StAclass()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextA.TextChanged
        Try
            SeABS()
        Catch ex As Exception
            MessageBox.Show("An error occurred while verifying the student: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        Dim S As String = TextA.Text
        If S = "" Then
            MessageBox.Show("The field is empty, please write", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            SeABS()
        End If
    End Sub

    Private Sub ProfBoxA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProfBoxA.SelectedIndexChanged
        ClassBoxA.Items.Clear()
        ClassBoxA.Text = ""
        Try
            classP()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GroupBox8_Enter(sender As Object, e As EventArgs) Handles GroupBox8.Enter

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles classBtt.Click
        closspage()
        dateClass()
        Classpage.Visible = True
        Classpage.BackColor = Color.LightSkyBlue
        classBtt.BackColor = Color.LightSkyBlue
        PicClass.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub Classpage_Paint(sender As Object, e As PaintEventArgs) Handles Classpage.Paint

        UserProf.Items.Clear()
        boxProfclass()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles UserProf.SelectedIndexChanged

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        addnewclass()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        UpdateNewClass()
    End Sub

    Private Sub tabClass_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tabClass.RowHeaderMouseClick
        Try
            If tabClass.SelectedRows.Count <> -1 Then
                addtotexeboxcl()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        FormR.Show()
    End Sub
    Private Sub DateRA_ValueChanged(sender As Object, e As EventArgs) Handles DateRA.ValueChanged
        dateslA()
    End Sub
    Private Sub DateRH_ValueChanged(sender As Object, e As EventArgs) Handles DateRH.ValueChanged
        dateslH()
    End Sub

    Private Sub contry_SelectedValueChanged(sender As Object, e As EventArgs) Handles contry.SelectedValueChanged
        city.Items.Clear()
        addcity()
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
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.WindowState = WindowState.Minimized
    End Sub
    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If MessageBox.Show("Are you really going to get rid of this Class?", "Delete Class", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If tabProf.SelectedRows.Count <> -1 Then
                    deletecl()
                    MessageBox.Show("Well Delete", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button4_Click_1(sender As Object, e As EventArgs)
        If Me.WindowState = WindowState.Normal Then
            Me.WindowState = WindowState.Maximized
        Else
            Me.WindowState = WindowState.Normal
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click
        closspage()
        homePage.Visible = True
        homePage.BackColor = Color.LightSkyBlue
        Buthome.BackColor = Color.LightSkyBlue
        pichome.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        closspage()
        Dataproff()
        Profpage.Visible = True
        Profpage.BackColor = Color.LightSkyBlue
        butprof.BackColor = Color.LightSkyBlue
        Picprof.BackColor = Color.LightSkyBlue
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        closspage()
        dateClass()
        Classpage.Visible = True
        Classpage.BackColor = Color.LightSkyBlue
        classBtt.BackColor = Color.LightSkyBlue
        PicClass.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        closspage()
        DataEtud()
        EtudPage.Visible = True
        EtudPage.BackColor = Color.LightSkyBlue
        ButtEtud.BackColor = Color.LightSkyBlue
        PIcEtud.BackColor = Color.LightSkyBlue
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        closspage()
        dateADS()
        AbsPage.Visible = True
        AbsPage.BackColor = Color.LightSkyBlue
        buttabs.BackColor = Color.LightSkyBlue
        PicAbs.BackColor = Color.LightSkyBlue
    End Sub
    Private Sub Button4_Click_2(sender As Object, e As EventArgs) Handles endbutt.Click
        closspage()
        datafinetud()
        Endpage.Visible = True
        Endpage.BackColor = Color.LightSkyBlue
        endbutt.BackColor = Color.LightSkyBlue
        PicEnd.BackColor = Color.LightSkyBlue
    End Sub
    Private Sub PicEnd_Click(sender As Object, e As EventArgs) Handles PicEnd.Click
        closspage()
        datafinetud()
        Endpage.Visible = True
        Endpage.BackColor = Color.LightSkyBlue
        endbutt.BackColor = Color.LightSkyBlue
        PicEnd.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub tabEtud_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tabEtud.RowHeaderMouseClick
        'for problem the select name or box

        NameClassEtud = tabEtud.SelectedRows(0).Cells(6).Value.ToString()
        Try
            If tabEtud.SelectedRows.Count <> -1 Then
                addtotexeboxEt()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub EndStudydata_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles EndStudydata.CellContentClick

    End Sub
End Class
