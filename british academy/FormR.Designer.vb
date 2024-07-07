<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormR
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormR))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Textuser = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ShowPass = New System.Windows.Forms.PictureBox()
        Me.NoShow = New System.Windows.Forms.PictureBox()
        Me.Password = New System.Windows.Forms.TextBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.logIn = New System.Windows.Forms.Button()
        Me.Switch = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.ShowPass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NoShow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Switch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Textuser)
        Me.Panel2.Controls.Add(Me.PictureBox2)
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.Name = "Panel2"
        '
        'Textuser
        '
        Me.Textuser.BackColor = System.Drawing.Color.White
        Me.Textuser.BorderStyle = System.Windows.Forms.BorderStyle.None
        resources.ApplyResources(Me.Textuser, "Textuser")
        Me.Textuser.Name = "Textuser"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.british_academy.My.Resources.Resources.user
        resources.ApplyResources(Me.PictureBox2, "PictureBox2")
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.ShowPass)
        Me.Panel1.Controls.Add(Me.NoShow)
        Me.Panel1.Controls.Add(Me.Password)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'ShowPass
        '
        Me.ShowPass.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ShowPass.Image = Global.british_academy.My.Resources.Resources.show
        resources.ApplyResources(Me.ShowPass, "ShowPass")
        Me.ShowPass.Name = "ShowPass"
        Me.ShowPass.TabStop = False
        '
        'NoShow
        '
        Me.NoShow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NoShow.Image = Global.british_academy.My.Resources.Resources.hide
        resources.ApplyResources(Me.NoShow, "NoShow")
        Me.NoShow.Name = "NoShow"
        Me.NoShow.TabStop = False
        '
        'Password
        '
        Me.Password.BackColor = System.Drawing.Color.White
        Me.Password.BorderStyle = System.Windows.Forms.BorderStyle.None
        resources.ApplyResources(Me.Password, "Password")
        Me.Password.Name = "Password"
        Me.Password.UseSystemPasswordChar = True
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.british_academy.My.Resources.Resources.lock_alt_regular_40
        resources.ApplyResources(Me.PictureBox3, "PictureBox3")
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.TabStop = False
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'logIn
        '
        resources.ApplyResources(Me.logIn, "logIn")
        Me.logIn.BackColor = System.Drawing.Color.DodgerBlue
        Me.logIn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.logIn.FlatAppearance.BorderSize = 0
        Me.logIn.ForeColor = System.Drawing.Color.White
        Me.logIn.Name = "logIn"
        Me.logIn.UseVisualStyleBackColor = False
        '
        'Switch
        '
        Me.Switch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Switch.Image = Global.british_academy.My.Resources.Resources.switch_camera
        resources.ApplyResources(Me.Switch, "Switch")
        Me.Switch.Name = "Switch"
        Me.Switch.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox4.Image = Global.british_academy.My.Resources.Resources.exit_full_screen
        resources.ApplyResources(Me.PictureBox4, "PictureBox4")
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.TabStop = False
        '
        'FormR
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SkyBlue
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.logIn)
        Me.Controls.Add(Me.Switch)
        Me.Controls.Add(Me.PictureBox4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormR"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.ShowPass, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NoShow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Switch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Textuser As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ShowPass As PictureBox
    Friend WithEvents NoShow As PictureBox
    Friend WithEvents Password As TextBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents logIn As Button
    Friend WithEvents Switch As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
End Class
