<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLogin
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogin))
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txt_clave = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txt_usuario = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lbl_tituloCliente = New System.Windows.Forms.Label()
        Me.btnIngresar = New System.Windows.Forms.Button()
        Me.lblVersion = New System.Windows.Forms.Label()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.caja2.My.Resources.Resources.Sin_título
        Me.PictureBox2.Location = New System.Drawing.Point(28, 22)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(30, 28)
        Me.PictureBox2.TabIndex = 104
        Me.PictureBox2.TabStop = False
        '
        'txt_clave
        '
        Me.txt_clave.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_clave.Location = New System.Drawing.Point(44, 145)
        Me.txt_clave.Name = "txt_clave"
        Me.txt_clave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_clave.Size = New System.Drawing.Size(231, 27)
        Me.txt_clave.TabIndex = 103
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label24.Location = New System.Drawing.Point(41, 124)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(39, 17)
        Me.Label24.TabIndex = 102
        Me.Label24.Text = "Clave"
        '
        'txt_usuario
        '
        Me.txt_usuario.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_usuario.Location = New System.Drawing.Point(44, 83)
        Me.txt_usuario.MaxLength = 50
        Me.txt_usuario.Name = "txt_usuario"
        Me.txt_usuario.Size = New System.Drawing.Size(231, 27)
        Me.txt_usuario.TabIndex = 100
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label18.Location = New System.Drawing.Point(40, 63)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(53, 17)
        Me.Label18.TabIndex = 99
        Me.Label18.Text = "Usuario"
        '
        'lbl_tituloCliente
        '
        Me.lbl_tituloCliente.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lbl_tituloCliente.ForeColor = System.Drawing.Color.Black
        Me.lbl_tituloCliente.Location = New System.Drawing.Point(50, 20)
        Me.lbl_tituloCliente.Name = "lbl_tituloCliente"
        Me.lbl_tituloCliente.Size = New System.Drawing.Size(231, 23)
        Me.lbl_tituloCliente.TabIndex = 101
        Me.lbl_tituloCliente.Text = "Inicia Sesión"
        '
        'btnIngresar
        '
        Me.btnIngresar.BackColor = System.Drawing.Color.DarkOrange
        Me.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIngresar.FlatAppearance.BorderSize = 0
        Me.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIngresar.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngresar.ForeColor = System.Drawing.Color.White
        Me.btnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIngresar.Location = New System.Drawing.Point(160, 193)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(114, 37)
        Me.btnIngresar.TabIndex = 105
        Me.btnIngresar.Text = "Ingresar"
        Me.btnIngresar.UseVisualStyleBackColor = False
        '
        'lblVersion
        '
        Me.lblVersion.Location = New System.Drawing.Point(25, 206)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(110, 23)
        Me.lblVersion.TabIndex = 106
        '
        'FrmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(314, 254)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.btnIngresar)
        Me.Controls.Add(Me.lbl_tituloCliente)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.txt_clave)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txt_usuario)
        Me.Controls.Add(Me.Label18)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sistema de Cajas - Login"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents txt_clave As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents txt_usuario As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents lbl_tituloCliente As Label
    Friend WithEvents btnIngresar As Button
    Friend WithEvents lblVersion As Label
End Class
