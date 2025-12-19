<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCliente
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
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txt_rutCliente = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txt_nombre_cliente = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txt_giro_cliente = New System.Windows.Forms.TextBox()
        Me.PnlCliente = New System.Windows.Forms.Panel()
        Me.txt_idCliente = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ChkOrdenCompra = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_celular_cliente = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbx_comuna_cliente = New System.Windows.Forms.ComboBox()
        Me.cbx_ciudad_cliente = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txt_email_cliente = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txt_direccion_cliente = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txt_telefono_fijo_cliente = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.rdbEmpresa = New System.Windows.Forms.RadioButton()
        Me.rdbPersona = New System.Windows.Forms.RadioButton()
        Me.txt_apellido_cliente = New System.Windows.Forms.TextBox()
        Me.lblApellido = New System.Windows.Forms.Label()
        Me.pnl_direcciones = New System.Windows.Forms.Panel()
        Me.txt_celular_direccion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbx_comuna_direccion = New System.Windows.Forms.ComboBox()
        Me.cbx_ciudad_direccion = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_email_direccion = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_direccion_direccion = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txt_telefono_direccion = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnAgregarDireccion = New System.Windows.Forms.Button()
        Me.DgvDireccionesCliente = New System.Windows.Forms.DataGridView()
        Me.ColPartner = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCodigoCiudad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNombreCiudad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCodigoComuna = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNombreComuna = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDireccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTelefono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCelular = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColEmail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCodigoLocalidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAbrevRegion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnGrabarCliente = New System.Windows.Forms.Button()
        Me.PnlCliente.SuspendLayout()
        Me.pnl_direcciones.SuspendLayout()
        CType(Me.DgvDireccionesCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label18.Location = New System.Drawing.Point(12, 40)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(32, 17)
        Me.Label18.TabIndex = 70
        Me.Label18.Text = "RUT"
        '
        'txt_rutCliente
        '
        Me.txt_rutCliente.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rutCliente.Location = New System.Drawing.Point(15, 58)
        Me.txt_rutCliente.MaxLength = 10
        Me.txt_rutCliente.Name = "txt_rutCliente"
        Me.txt_rutCliente.Size = New System.Drawing.Size(131, 27)
        Me.txt_rutCliente.TabIndex = 71
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblNombre.Location = New System.Drawing.Point(152, 40)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(57, 17)
        Me.lblNombre.TabIndex = 72
        Me.lblNombre.Text = "Nombre"
        '
        'txt_nombre_cliente
        '
        Me.txt_nombre_cliente.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_nombre_cliente.Location = New System.Drawing.Point(155, 58)
        Me.txt_nombre_cliente.MaxLength = 100
        Me.txt_nombre_cliente.Name = "txt_nombre_cliente"
        Me.txt_nombre_cliente.Size = New System.Drawing.Size(328, 27)
        Me.txt_nombre_cliente.TabIndex = 73
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label21.Location = New System.Drawing.Point(14, 91)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(33, 17)
        Me.Label21.TabIndex = 76
        Me.Label21.Text = "Giro"
        '
        'txt_giro_cliente
        '
        Me.txt_giro_cliente.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_giro_cliente.Location = New System.Drawing.Point(14, 109)
        Me.txt_giro_cliente.MaxLength = 40
        Me.txt_giro_cliente.Name = "txt_giro_cliente"
        Me.txt_giro_cliente.Size = New System.Drawing.Size(817, 27)
        Me.txt_giro_cliente.TabIndex = 77
        '
        'PnlCliente
        '
        Me.PnlCliente.Controls.Add(Me.txt_idCliente)
        Me.PnlCliente.Controls.Add(Me.Label6)
        Me.PnlCliente.Controls.Add(Me.ChkOrdenCompra)
        Me.PnlCliente.Controls.Add(Me.Label4)
        Me.PnlCliente.Controls.Add(Me.txt_celular_cliente)
        Me.PnlCliente.Controls.Add(Me.Label3)
        Me.PnlCliente.Controls.Add(Me.cbx_comuna_cliente)
        Me.PnlCliente.Controls.Add(Me.cbx_ciudad_cliente)
        Me.PnlCliente.Controls.Add(Me.Label26)
        Me.PnlCliente.Controls.Add(Me.Label25)
        Me.PnlCliente.Controls.Add(Me.txt_email_cliente)
        Me.PnlCliente.Controls.Add(Me.Label24)
        Me.PnlCliente.Controls.Add(Me.txt_direccion_cliente)
        Me.PnlCliente.Controls.Add(Me.Label23)
        Me.PnlCliente.Controls.Add(Me.txt_telefono_fijo_cliente)
        Me.PnlCliente.Controls.Add(Me.Label22)
        Me.PnlCliente.Controls.Add(Me.rdbEmpresa)
        Me.PnlCliente.Controls.Add(Me.rdbPersona)
        Me.PnlCliente.Controls.Add(Me.txt_apellido_cliente)
        Me.PnlCliente.Controls.Add(Me.lblApellido)
        Me.PnlCliente.Controls.Add(Me.pnl_direcciones)
        Me.PnlCliente.Controls.Add(Me.DgvDireccionesCliente)
        Me.PnlCliente.Controls.Add(Me.Label5)
        Me.PnlCliente.Controls.Add(Me.txt_giro_cliente)
        Me.PnlCliente.Controls.Add(Me.Label21)
        Me.PnlCliente.Controls.Add(Me.txt_nombre_cliente)
        Me.PnlCliente.Controls.Add(Me.lblNombre)
        Me.PnlCliente.Controls.Add(Me.txt_rutCliente)
        Me.PnlCliente.Controls.Add(Me.Label18)
        Me.PnlCliente.Location = New System.Drawing.Point(12, 12)
        Me.PnlCliente.Name = "PnlCliente"
        Me.PnlCliente.Size = New System.Drawing.Size(851, 719)
        Me.PnlCliente.TabIndex = 0
        '
        'txt_idCliente
        '
        Me.txt_idCliente.Enabled = False
        Me.txt_idCliente.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_idCliente.Location = New System.Drawing.Point(195, 303)
        Me.txt_idCliente.Name = "txt_idCliente"
        Me.txt_idCliente.ReadOnly = True
        Me.txt_idCliente.Size = New System.Drawing.Size(180, 27)
        Me.txt_idCliente.TabIndex = 152
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label6.Location = New System.Drawing.Point(194, 278)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(181, 17)
        Me.Label6.TabIndex = 151
        Me.Label6.Text = "N° Cliente"
        '
        'ChkOrdenCompra
        '
        Me.ChkOrdenCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkOrdenCompra.Location = New System.Drawing.Point(18, 276)
        Me.ChkOrdenCompra.Name = "ChkOrdenCompra"
        Me.ChkOrdenCompra.Size = New System.Drawing.Size(170, 24)
        Me.ChkOrdenCompra.TabIndex = 150
        Me.ChkOrdenCompra.Text = "Orden de Compra"
        Me.ChkOrdenCompra.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 309)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(352, 31)
        Me.Label4.TabIndex = 149
        Me.Label4.Text = "Direcciones Alternativas"
        '
        'txt_celular_cliente
        '
        Me.txt_celular_cliente.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_celular_cliente.Location = New System.Drawing.Point(195, 168)
        Me.txt_celular_cliente.MaxLength = 12
        Me.txt_celular_cliente.Name = "txt_celular_cliente"
        Me.txt_celular_cliente.Size = New System.Drawing.Size(180, 27)
        Me.txt_celular_cliente.TabIndex = 148
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(192, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 17)
        Me.Label3.TabIndex = 147
        Me.Label3.Text = "Celular"
        '
        'cbx_comuna_cliente
        '
        Me.cbx_comuna_cliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_comuna_cliente.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.cbx_comuna_cliente.FormattingEnabled = True
        Me.cbx_comuna_cliente.Location = New System.Drawing.Point(195, 227)
        Me.cbx_comuna_cliente.Name = "cbx_comuna_cliente"
        Me.cbx_comuna_cliente.Size = New System.Drawing.Size(180, 28)
        Me.cbx_comuna_cliente.TabIndex = 146
        '
        'cbx_ciudad_cliente
        '
        Me.cbx_ciudad_cliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_ciudad_cliente.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.cbx_ciudad_cliente.FormattingEnabled = True
        Me.cbx_ciudad_cliente.Location = New System.Drawing.Point(18, 227)
        Me.cbx_ciudad_cliente.Name = "cbx_ciudad_cliente"
        Me.cbx_ciudad_cliente.Size = New System.Drawing.Size(171, 28)
        Me.cbx_ciudad_cliente.TabIndex = 145
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label26.Location = New System.Drawing.Point(192, 211)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(56, 17)
        Me.Label26.TabIndex = 144
        Me.Label26.Text = "Comuna"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label25.Location = New System.Drawing.Point(15, 211)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(49, 17)
        Me.Label25.TabIndex = 143
        Me.Label25.Text = "Ciudad"
        '
        'txt_email_cliente
        '
        Me.txt_email_cliente.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_email_cliente.Location = New System.Drawing.Point(381, 168)
        Me.txt_email_cliente.Name = "txt_email_cliente"
        Me.txt_email_cliente.Size = New System.Drawing.Size(450, 27)
        Me.txt_email_cliente.TabIndex = 142
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label24.Location = New System.Drawing.Point(381, 148)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(39, 17)
        Me.Label24.TabIndex = 141
        Me.Label24.Text = "Email"
        '
        'txt_direccion_cliente
        '
        Me.txt_direccion_cliente.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_direccion_cliente.Location = New System.Drawing.Point(381, 227)
        Me.txt_direccion_cliente.Name = "txt_direccion_cliente"
        Me.txt_direccion_cliente.Size = New System.Drawing.Size(450, 27)
        Me.txt_direccion_cliente.TabIndex = 140
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label23.Location = New System.Drawing.Point(381, 211)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(425, 17)
        Me.Label23.TabIndex = 139
        Me.Label23.Text = "Calle / número"
        '
        'txt_telefono_fijo_cliente
        '
        Me.txt_telefono_fijo_cliente.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_telefono_fijo_cliente.Location = New System.Drawing.Point(18, 168)
        Me.txt_telefono_fijo_cliente.MaxLength = 12
        Me.txt_telefono_fijo_cliente.Name = "txt_telefono_fijo_cliente"
        Me.txt_telefono_fijo_cliente.Size = New System.Drawing.Size(170, 27)
        Me.txt_telefono_fijo_cliente.TabIndex = 138
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label22.Location = New System.Drawing.Point(15, 148)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(61, 17)
        Me.Label22.TabIndex = 137
        Me.Label22.Text = "Fono Fijo"
        '
        'rdbEmpresa
        '
        Me.rdbEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbEmpresa.Location = New System.Drawing.Point(155, 13)
        Me.rdbEmpresa.Name = "rdbEmpresa"
        Me.rdbEmpresa.Size = New System.Drawing.Size(132, 24)
        Me.rdbEmpresa.TabIndex = 101
        Me.rdbEmpresa.TabStop = True
        Me.rdbEmpresa.Text = "Empresa"
        Me.rdbEmpresa.UseVisualStyleBackColor = True
        '
        'rdbPersona
        '
        Me.rdbPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbPersona.Location = New System.Drawing.Point(14, 13)
        Me.rdbPersona.Name = "rdbPersona"
        Me.rdbPersona.Size = New System.Drawing.Size(132, 24)
        Me.rdbPersona.TabIndex = 100
        Me.rdbPersona.TabStop = True
        Me.rdbPersona.Text = "Persona Natural"
        Me.rdbPersona.UseVisualStyleBackColor = True
        '
        'txt_apellido_cliente
        '
        Me.txt_apellido_cliente.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_apellido_cliente.Location = New System.Drawing.Point(488, 58)
        Me.txt_apellido_cliente.Name = "txt_apellido_cliente"
        Me.txt_apellido_cliente.Size = New System.Drawing.Size(343, 27)
        Me.txt_apellido_cliente.TabIndex = 99
        '
        'lblApellido
        '
        Me.lblApellido.AutoSize = True
        Me.lblApellido.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblApellido.Location = New System.Drawing.Point(485, 40)
        Me.lblApellido.Name = "lblApellido"
        Me.lblApellido.Size = New System.Drawing.Size(56, 17)
        Me.lblApellido.TabIndex = 98
        Me.lblApellido.Text = "Apellido"
        '
        'pnl_direcciones
        '
        Me.pnl_direcciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_direcciones.Controls.Add(Me.txt_celular_direccion)
        Me.pnl_direcciones.Controls.Add(Me.Label7)
        Me.pnl_direcciones.Controls.Add(Me.cbx_comuna_direccion)
        Me.pnl_direcciones.Controls.Add(Me.cbx_ciudad_direccion)
        Me.pnl_direcciones.Controls.Add(Me.Label8)
        Me.pnl_direcciones.Controls.Add(Me.Label9)
        Me.pnl_direcciones.Controls.Add(Me.txt_email_direccion)
        Me.pnl_direcciones.Controls.Add(Me.Label10)
        Me.pnl_direcciones.Controls.Add(Me.txt_direccion_direccion)
        Me.pnl_direcciones.Controls.Add(Me.Label11)
        Me.pnl_direcciones.Controls.Add(Me.txt_telefono_direccion)
        Me.pnl_direcciones.Controls.Add(Me.Label12)
        Me.pnl_direcciones.Controls.Add(Me.btnAgregarDireccion)
        Me.pnl_direcciones.Location = New System.Drawing.Point(15, 346)
        Me.pnl_direcciones.Name = "pnl_direcciones"
        Me.pnl_direcciones.Size = New System.Drawing.Size(817, 188)
        Me.pnl_direcciones.TabIndex = 97
        '
        'txt_celular_direccion
        '
        Me.txt_celular_direccion.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_celular_direccion.Location = New System.Drawing.Point(193, 35)
        Me.txt_celular_direccion.MaxLength = 12
        Me.txt_celular_direccion.Name = "txt_celular_direccion"
        Me.txt_celular_direccion.Size = New System.Drawing.Size(180, 27)
        Me.txt_celular_direccion.TabIndex = 148
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label7.Location = New System.Drawing.Point(190, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 17)
        Me.Label7.TabIndex = 147
        Me.Label7.Text = "Celular"
        '
        'cbx_comuna_direccion
        '
        Me.cbx_comuna_direccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_comuna_direccion.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.cbx_comuna_direccion.FormattingEnabled = True
        Me.cbx_comuna_direccion.Location = New System.Drawing.Point(193, 96)
        Me.cbx_comuna_direccion.Name = "cbx_comuna_direccion"
        Me.cbx_comuna_direccion.Size = New System.Drawing.Size(180, 28)
        Me.cbx_comuna_direccion.TabIndex = 146
        '
        'cbx_ciudad_direccion
        '
        Me.cbx_ciudad_direccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_ciudad_direccion.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.cbx_ciudad_direccion.FormattingEnabled = True
        Me.cbx_ciudad_direccion.Location = New System.Drawing.Point(16, 96)
        Me.cbx_ciudad_direccion.Name = "cbx_ciudad_direccion"
        Me.cbx_ciudad_direccion.Size = New System.Drawing.Size(171, 28)
        Me.cbx_ciudad_direccion.TabIndex = 145
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label8.Location = New System.Drawing.Point(190, 80)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 17)
        Me.Label8.TabIndex = 144
        Me.Label8.Text = "Comuna"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label9.Location = New System.Drawing.Point(13, 80)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 17)
        Me.Label9.TabIndex = 143
        Me.Label9.Text = "Ciudad"
        '
        'txt_email_direccion
        '
        Me.txt_email_direccion.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_email_direccion.Location = New System.Drawing.Point(379, 35)
        Me.txt_email_direccion.Name = "txt_email_direccion"
        Me.txt_email_direccion.Size = New System.Drawing.Size(425, 27)
        Me.txt_email_direccion.TabIndex = 142
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label10.Location = New System.Drawing.Point(379, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 17)
        Me.Label10.TabIndex = 141
        Me.Label10.Text = "Email"
        '
        'txt_direccion_direccion
        '
        Me.txt_direccion_direccion.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_direccion_direccion.Location = New System.Drawing.Point(379, 96)
        Me.txt_direccion_direccion.Name = "txt_direccion_direccion"
        Me.txt_direccion_direccion.Size = New System.Drawing.Size(425, 27)
        Me.txt_direccion_direccion.TabIndex = 140
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label11.Location = New System.Drawing.Point(379, 80)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(180, 17)
        Me.Label11.TabIndex = 139
        Me.Label11.Text = "Calle / número"
        '
        'txt_telefono_direccion
        '
        Me.txt_telefono_direccion.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_telefono_direccion.Location = New System.Drawing.Point(16, 35)
        Me.txt_telefono_direccion.MaxLength = 12
        Me.txt_telefono_direccion.Name = "txt_telefono_direccion"
        Me.txt_telefono_direccion.Size = New System.Drawing.Size(170, 27)
        Me.txt_telefono_direccion.TabIndex = 138
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label12.Location = New System.Drawing.Point(13, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 17)
        Me.Label12.TabIndex = 137
        Me.Label12.Text = "Fono Fijo"
        '
        'btnAgregarDireccion
        '
        Me.btnAgregarDireccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAgregarDireccion.BackColor = System.Drawing.Color.DarkOrange
        Me.btnAgregarDireccion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregarDireccion.FlatAppearance.BorderSize = 0
        Me.btnAgregarDireccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarDireccion.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarDireccion.ForeColor = System.Drawing.Color.White
        Me.btnAgregarDireccion.Location = New System.Drawing.Point(652, 137)
        Me.btnAgregarDireccion.Name = "btnAgregarDireccion"
        Me.btnAgregarDireccion.Size = New System.Drawing.Size(152, 37)
        Me.btnAgregarDireccion.TabIndex = 134
        Me.btnAgregarDireccion.Text = "Agregar Dirección"
        Me.btnAgregarDireccion.UseVisualStyleBackColor = False
        '
        'DgvDireccionesCliente
        '
        Me.DgvDireccionesCliente.AllowUserToAddRows = False
        Me.DgvDireccionesCliente.AllowUserToResizeRows = False
        Me.DgvDireccionesCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDireccionesCliente.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColPartner, Me.ColCodigoCiudad, Me.ColNombreCiudad, Me.ColCodigoComuna, Me.ColNombreComuna, Me.ColDireccion, Me.ColTelefono, Me.ColCelular, Me.ColEmail, Me.ColCodigoLocalidad, Me.ColAbrevRegion})
        Me.DgvDireccionesCliente.Location = New System.Drawing.Point(16, 571)
        Me.DgvDireccionesCliente.Name = "DgvDireccionesCliente"
        Me.DgvDireccionesCliente.Size = New System.Drawing.Size(816, 118)
        Me.DgvDireccionesCliente.TabIndex = 96
        '
        'ColPartner
        '
        Me.ColPartner.HeaderText = "Partner"
        Me.ColPartner.Name = "ColPartner"
        Me.ColPartner.Visible = False
        '
        'ColCodigoCiudad
        '
        Me.ColCodigoCiudad.HeaderText = "Id Ciudad"
        Me.ColCodigoCiudad.Name = "ColCodigoCiudad"
        Me.ColCodigoCiudad.Visible = False
        '
        'ColNombreCiudad
        '
        Me.ColNombreCiudad.HeaderText = "Ciudad"
        Me.ColNombreCiudad.Name = "ColNombreCiudad"
        '
        'ColCodigoComuna
        '
        Me.ColCodigoComuna.HeaderText = "Id Comuna"
        Me.ColCodigoComuna.Name = "ColCodigoComuna"
        Me.ColCodigoComuna.Visible = False
        '
        'ColNombreComuna
        '
        Me.ColNombreComuna.HeaderText = "Comuna"
        Me.ColNombreComuna.Name = "ColNombreComuna"
        '
        'ColDireccion
        '
        Me.ColDireccion.HeaderText = "Dirección"
        Me.ColDireccion.Name = "ColDireccion"
        Me.ColDireccion.Width = 180
        '
        'ColTelefono
        '
        Me.ColTelefono.HeaderText = "Teléfono"
        Me.ColTelefono.Name = "ColTelefono"
        '
        'ColCelular
        '
        Me.ColCelular.HeaderText = "Celular"
        Me.ColCelular.Name = "ColCelular"
        '
        'ColEmail
        '
        Me.ColEmail.HeaderText = "EMail"
        Me.ColEmail.Name = "ColEmail"
        Me.ColEmail.Width = 150
        '
        'ColCodigoLocalidad
        '
        Me.ColCodigoLocalidad.HeaderText = "Id localidad"
        Me.ColCodigoLocalidad.Name = "ColCodigoLocalidad"
        Me.ColCodigoLocalidad.Visible = False
        '
        'ColAbrevRegion
        '
        Me.ColAbrevRegion.HeaderText = "Abreviatura Región"
        Me.ColAbrevRegion.Name = "ColAbrevRegion"
        Me.ColAbrevRegion.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label5.Location = New System.Drawing.Point(15, 551)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 17)
        Me.Label5.TabIndex = 95
        Me.Label5.Text = "Direcciones"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.BackColor = System.Drawing.Color.DarkOrange
        Me.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalir.FlatAppearance.BorderSize = 0
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Location = New System.Drawing.Point(549, 747)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(139, 37)
        Me.btnSalir.TabIndex = 102
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnGrabarCliente
        '
        Me.btnGrabarCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGrabarCliente.BackColor = System.Drawing.Color.DarkOrange
        Me.btnGrabarCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGrabarCliente.FlatAppearance.BorderSize = 0
        Me.btnGrabarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGrabarCliente.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabarCliente.ForeColor = System.Drawing.Color.White
        Me.btnGrabarCliente.Location = New System.Drawing.Point(711, 747)
        Me.btnGrabarCliente.Name = "btnGrabarCliente"
        Me.btnGrabarCliente.Size = New System.Drawing.Size(139, 37)
        Me.btnGrabarCliente.TabIndex = 101
        Me.btnGrabarCliente.Text = "Grabar"
        Me.btnGrabarCliente.UseVisualStyleBackColor = False
        '
        'FrmCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(875, 796)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnGrabarCliente)
        Me.Controls.Add(Me.PnlCliente)
        Me.Name = "FrmCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cliente"
        Me.PnlCliente.ResumeLayout(False)
        Me.PnlCliente.PerformLayout()
        Me.pnl_direcciones.ResumeLayout(False)
        Me.pnl_direcciones.PerformLayout()
        CType(Me.DgvDireccionesCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label18 As Label
    Friend WithEvents txt_rutCliente As TextBox
    Friend WithEvents lblNombre As Label
    Friend WithEvents txt_nombre_cliente As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txt_giro_cliente As TextBox
    Friend WithEvents PnlCliente As Panel
    Friend WithEvents DgvDireccionesCliente As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnGrabarCliente As Button
    Friend WithEvents pnl_direcciones As Panel
    Friend WithEvents btnAgregarDireccion As Button
    Friend WithEvents txt_apellido_cliente As TextBox
    Friend WithEvents lblApellido As Label
    Friend WithEvents rdbEmpresa As RadioButton
    Friend WithEvents rdbPersona As RadioButton
    Friend WithEvents txt_celular_cliente As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cbx_comuna_cliente As ComboBox
    Friend WithEvents cbx_ciudad_cliente As ComboBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents txt_email_cliente As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents txt_direccion_cliente As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents txt_telefono_fijo_cliente As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txt_celular_direccion As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cbx_comuna_direccion As ComboBox
    Friend WithEvents cbx_ciudad_direccion As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txt_email_direccion As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txt_direccion_direccion As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txt_telefono_direccion As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ColPartner As DataGridViewTextBoxColumn
    Friend WithEvents ColCodigoCiudad As DataGridViewTextBoxColumn
    Friend WithEvents ColNombreCiudad As DataGridViewTextBoxColumn
    Friend WithEvents ColCodigoComuna As DataGridViewTextBoxColumn
    Friend WithEvents ColNombreComuna As DataGridViewTextBoxColumn
    Friend WithEvents ColDireccion As DataGridViewTextBoxColumn
    Friend WithEvents ColTelefono As DataGridViewTextBoxColumn
    Friend WithEvents ColCelular As DataGridViewTextBoxColumn
    Friend WithEvents ColEmail As DataGridViewTextBoxColumn
    Friend WithEvents ColCodigoLocalidad As DataGridViewTextBoxColumn
    Friend WithEvents ColAbrevRegion As DataGridViewTextBoxColumn
    Friend WithEvents ChkOrdenCompra As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_idCliente As TextBox
End Class
