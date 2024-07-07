<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormR
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.logIn = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ShowPass = New System.Windows.Forms.PictureBox()
        Me.NoShow = New System.Windows.Forms.PictureBox()
        Me.Password = New System.Windows.Forms.TextBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Switch = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.ShowPass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NoShow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Switch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.logIn)
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Location = New System.Drawing.Point(57, 283)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(297, 50)
        Me.Panel2.TabIndex = 7
        '
        'logIn
        '
        Me.logIn.BackColor = System.Drawing.Color.White
        Me.logIn.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.logIn.Location = New System.Drawing.Point(53, 20)
        Me.logIn.Name = "logIn"
        Me.logIn.Size = New System.Drawing.Size(241, 15)
        Me.logIn.TabIndex = 9
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.british_academy.My.Resources.Resources.user
        Me.PictureBox2.Location = New System.Drawing.Point(7, 5)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 8
        Me.PictureBox2.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.ShowPass)
        Me.Panel1.Controls.Add(Me.NoShow)
        Me.Panel1.Controls.Add(Me.Password)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Location = New System.Drawing.Point(57, 339)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(297, 50)
        Me.Panel1.TabIndex = 8
        '
        'ShowPass
        '
        Me.ShowPass.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ShowPass.Image = Global.british_academy.My.Resources.Resources.show
        Me.ShowPass.Location = New System.Drawing.Point(261, 19)
        Me.ShowPass.Name = "ShowPass"
        Me.ShowPass.Size = New System.Drawing.Size(33, 21)
        Me.ShowPass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ShowPass.TabIndex = 14
        Me.ShowPass.TabStop = False
        '
        'NoShow
        '
        Me.NoShow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NoShow.Image = Global.british_academy.My.Resources.Resources.hide
        Me.NoShow.Location = New System.Drawing.Point(261, 19)
        Me.NoShow.Name = "NoShow"
        Me.NoShow.Size = New System.Drawing.Size(33, 21)
        Me.NoShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.NoShow.TabIndex = 13
        Me.NoShow.TabStop = False
        '
        'Password
        '
        Me.Password.BackColor = System.Drawing.Color.White
        Me.Password.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Password.Location = New System.Drawing.Point(53, 19)
        Me.Password.Name = "Password"
        Me.Password.Size = New System.Drawing.Size(241, 15)
        Me.Password.TabIndex = 9
        Me.Password.UseSystemPasswordChar = True
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.british_academy.My.Resources.Resources.lock_alt_regular_40
        Me.PictureBox3.Location = New System.Drawing.Point(7, 5)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 8
        Me.PictureBox3.TabStop = False
        '
        'Button1
        '
        Me.Button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Button1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(57, 438)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(297, 49)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Se connecter"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Perpetua Titling MT", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(52, 181)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(329, 29)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Responsable Account"
        '
        'Switch
        '
        Me.Switch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Switch.Image = Global.british_academy.My.Resources.Resources.switch_camera
        Me.Switch.Location = New System.Drawing.Point(188, 229)
        Me.Switch.Name = "Switch"
        Me.Switch.Size = New System.Drawing.Size(34, 32)
        Me.Switch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Switch.TabIndex = 15
        Me.Switch.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox4.Image = Global.british_academy.My.Resources.Resources.exit_full_screen
        Me.PictureBox4.Location = New System.Drawing.Point(385, 12)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox4.TabIndex = 11
        Me.PictureBox4.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.LightCyan
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.No
        Me.PictureBox1.Image = Global.british_academy.My.Resources.Resources.logo
        Me.PictureBox1.Location = New System.Drawing.Point(43, 47)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(344, 100)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'FormR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(423, 640)
        Me.Controls.Add(Me.Switch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormR"
        Me.Text = "Form1"
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
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents logIn As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Password As TextBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ShowPass As PictureBox
    Friend WithEvents NoShow As PictureBox
    Friend WithEvents Switch As PictureBox
End Class
