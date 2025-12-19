<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPos
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPos))
        Me.Port_ddown = New System.Windows.Forms.ComboBox()
        Me.Connect_btn = New System.Windows.Forms.Button()
        Me.flowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Cofee_img = New System.Windows.Forms.PictureBox()
        Me.Juice_img = New System.Windows.Forms.PictureBox()
        Me.Cookies_img = New System.Windows.Forms.PictureBox()
        Me.Icecream_img = New System.Windows.Forms.PictureBox()
        Me.Pizza_img = New System.Windows.Forms.PictureBox()
        Me.Donut_img = New System.Windows.Forms.PictureBox()
        Me.Burger_img = New System.Windows.Forms.PictureBox()
        Me.Salad_img = New System.Windows.Forms.PictureBox()
        Me.Fries_img = New System.Windows.Forms.PictureBox()
        Me.ConnectedPort_lbl = New System.Windows.Forms.Label()
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Price_lbl = New System.Windows.Forms.Label()
        Me.Total_lbl = New System.Windows.Forms.Label()
        Me.PortName_lbl = New System.Windows.Forms.Label()
        Me.ShopingList_lbl = New System.Windows.Forms.Label()
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.connectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pollToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.loadKeysToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.setNormalModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.getTotalsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lastSaleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.refundToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.salesDetailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox()
        Me.Disconnect_btn = New System.Windows.Forms.Button()
        Me.ShopingList_lst = New System.Windows.Forms.ListView()
        Me.Item = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.precio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ShopingListLeyend_lbl = New System.Windows.Forms.Label()
        Me.Pay_btn = New System.Windows.Forms.Button()
        Me.Clean_btn = New System.Windows.Forms.Button()
        Me.btn_onepay = New System.Windows.Forms.Button()
        Me.intermediateMsgTxtBox = New System.Windows.Forms.TextBox()
        Me.flowLayoutPanel1.SuspendLayout()
        CType(Me.Cofee_img, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Juice_img, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cookies_img, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Icecream_img, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pizza_img, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Donut_img, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Burger_img, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Salad_img, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Fries_img, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tableLayoutPanel1.SuspendLayout()
        Me.menuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Port_ddown
        '
        Me.Port_ddown.FormattingEnabled = True
        Me.Port_ddown.Items.AddRange(New Object() {"COM4"})
        Me.Port_ddown.Location = New System.Drawing.Point(36, 36)
        Me.Port_ddown.Name = "Port_ddown"
        Me.Port_ddown.Size = New System.Drawing.Size(101, 21)
        Me.Port_ddown.TabIndex = 9
        '
        'Connect_btn
        '
        Me.Connect_btn.Location = New System.Drawing.Point(143, 34)
        Me.Connect_btn.Name = "Connect_btn"
        Me.Connect_btn.Size = New System.Drawing.Size(75, 23)
        Me.Connect_btn.TabIndex = 10
        Me.Connect_btn.Text = "Conectar"
        Me.Connect_btn.UseVisualStyleBackColor = True
        '
        'flowLayoutPanel1
        '
        Me.flowLayoutPanel1.Controls.Add(Me.Cofee_img)
        Me.flowLayoutPanel1.Controls.Add(Me.Juice_img)
        Me.flowLayoutPanel1.Controls.Add(Me.Cookies_img)
        Me.flowLayoutPanel1.Controls.Add(Me.Icecream_img)
        Me.flowLayoutPanel1.Controls.Add(Me.Pizza_img)
        Me.flowLayoutPanel1.Controls.Add(Me.Donut_img)
        Me.flowLayoutPanel1.Controls.Add(Me.Burger_img)
        Me.flowLayoutPanel1.Controls.Add(Me.Salad_img)
        Me.flowLayoutPanel1.Controls.Add(Me.Fries_img)
        Me.flowLayoutPanel1.Location = New System.Drawing.Point(12, 80)
        Me.flowLayoutPanel1.Name = "flowLayoutPanel1"
        Me.flowLayoutPanel1.Size = New System.Drawing.Size(445, 302)
        Me.flowLayoutPanel1.TabIndex = 11
        '
        'Cofee_img
        '
        Me.Cofee_img.Image = CType(resources.GetObject("Cofee_img.Image"), System.Drawing.Image)
        Me.Cofee_img.Location = New System.Drawing.Point(3, 3)
        Me.Cofee_img.MaximumSize = New System.Drawing.Size(142, 94)
        Me.Cofee_img.MinimumSize = New System.Drawing.Size(142, 94)
        Me.Cofee_img.Name = "Cofee_img"
        Me.Cofee_img.Size = New System.Drawing.Size(142, 94)
        Me.Cofee_img.TabIndex = 9
        Me.Cofee_img.TabStop = False
        '
        'Juice_img
        '
        Me.Juice_img.Image = CType(resources.GetObject("Juice_img.Image"), System.Drawing.Image)
        Me.Juice_img.Location = New System.Drawing.Point(151, 3)
        Me.Juice_img.Name = "Juice_img"
        Me.Juice_img.Size = New System.Drawing.Size(142, 94)
        Me.Juice_img.TabIndex = 10
        Me.Juice_img.TabStop = False
        '
        'Cookies_img
        '
        Me.Cookies_img.Image = CType(resources.GetObject("Cookies_img.Image"), System.Drawing.Image)
        Me.Cookies_img.Location = New System.Drawing.Point(299, 3)
        Me.Cookies_img.Name = "Cookies_img"
        Me.Cookies_img.Size = New System.Drawing.Size(142, 94)
        Me.Cookies_img.TabIndex = 11
        Me.Cookies_img.TabStop = False
        '
        'Icecream_img
        '
        Me.Icecream_img.Image = CType(resources.GetObject("Icecream_img.Image"), System.Drawing.Image)
        Me.Icecream_img.Location = New System.Drawing.Point(3, 103)
        Me.Icecream_img.Name = "Icecream_img"
        Me.Icecream_img.Size = New System.Drawing.Size(142, 94)
        Me.Icecream_img.TabIndex = 12
        Me.Icecream_img.TabStop = False
        '
        'Pizza_img
        '
        Me.Pizza_img.Image = CType(resources.GetObject("Pizza_img.Image"), System.Drawing.Image)
        Me.Pizza_img.Location = New System.Drawing.Point(151, 103)
        Me.Pizza_img.Name = "Pizza_img"
        Me.Pizza_img.Size = New System.Drawing.Size(142, 94)
        Me.Pizza_img.TabIndex = 13
        Me.Pizza_img.TabStop = False
        '
        'Donut_img
        '
        Me.Donut_img.Image = CType(resources.GetObject("Donut_img.Image"), System.Drawing.Image)
        Me.Donut_img.Location = New System.Drawing.Point(299, 103)
        Me.Donut_img.Name = "Donut_img"
        Me.Donut_img.Size = New System.Drawing.Size(142, 94)
        Me.Donut_img.TabIndex = 14
        Me.Donut_img.TabStop = False
        '
        'Burger_img
        '
        Me.Burger_img.Image = CType(resources.GetObject("Burger_img.Image"), System.Drawing.Image)
        Me.Burger_img.Location = New System.Drawing.Point(3, 203)
        Me.Burger_img.Name = "Burger_img"
        Me.Burger_img.Size = New System.Drawing.Size(142, 94)
        Me.Burger_img.TabIndex = 15
        Me.Burger_img.TabStop = False
        '
        'Salad_img
        '
        Me.Salad_img.Image = CType(resources.GetObject("Salad_img.Image"), System.Drawing.Image)
        Me.Salad_img.Location = New System.Drawing.Point(151, 203)
        Me.Salad_img.Name = "Salad_img"
        Me.Salad_img.Size = New System.Drawing.Size(142, 94)
        Me.Salad_img.TabIndex = 16
        Me.Salad_img.TabStop = False
        '
        'Fries_img
        '
        Me.Fries_img.Image = CType(resources.GetObject("Fries_img.Image"), System.Drawing.Image)
        Me.Fries_img.Location = New System.Drawing.Point(299, 203)
        Me.Fries_img.Name = "Fries_img"
        Me.Fries_img.Size = New System.Drawing.Size(142, 94)
        Me.Fries_img.TabIndex = 17
        Me.Fries_img.TabStop = False
        '
        'ConnectedPort_lbl
        '
        Me.ConnectedPort_lbl.AutoSize = True
        Me.ConnectedPort_lbl.Location = New System.Drawing.Point(33, 60)
        Me.ConnectedPort_lbl.Name = "ConnectedPort_lbl"
        Me.ConnectedPort_lbl.Size = New System.Drawing.Size(96, 13)
        Me.ConnectedPort_lbl.TabIndex = 12
        Me.ConnectedPort_lbl.Text = "Puerto Conectado:"
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tableLayoutPanel1.ColumnCount = 2
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tableLayoutPanel1.Controls.Add(Me.Price_lbl, 1, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.Total_lbl, 0, 0)
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(475, 331)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowCount = 1
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39.0!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(157, 39)
        Me.tableLayoutPanel1.TabIndex = 13
        '
        'Price_lbl
        '
        Me.Price_lbl.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Price_lbl.AutoSize = True
        Me.Price_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Price_lbl.Location = New System.Drawing.Point(109, 11)
        Me.Price_lbl.Name = "Price_lbl"
        Me.Price_lbl.Size = New System.Drawing.Size(16, 17)
        Me.Price_lbl.TabIndex = 16
        Me.Price_lbl.Text = "0"
        Me.Price_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Total_lbl
        '
        Me.Total_lbl.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Total_lbl.AutoSize = True
        Me.Total_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Total_lbl.Location = New System.Drawing.Point(3, 7)
        Me.Total_lbl.Name = "Total_lbl"
        Me.Total_lbl.Size = New System.Drawing.Size(72, 25)
        Me.Total_lbl.TabIndex = 2
        Me.Total_lbl.Text = "Total $"
        Me.Total_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PortName_lbl
        '
        Me.PortName_lbl.AutoSize = True
        Me.PortName_lbl.Location = New System.Drawing.Point(140, 60)
        Me.PortName_lbl.Name = "PortName_lbl"
        Me.PortName_lbl.Size = New System.Drawing.Size(45, 13)
        Me.PortName_lbl.TabIndex = 14
        Me.PortName_lbl.Text = "ninguno"
        '
        'ShopingList_lbl
        '
        Me.ShopingList_lbl.AutoSize = True
        Me.ShopingList_lbl.Location = New System.Drawing.Point(476, 34)
        Me.ShopingList_lbl.Name = "ShopingList_lbl"
        Me.ShopingList_lbl.Size = New System.Drawing.Size(88, 13)
        Me.ShopingList_lbl.TabIndex = 16
        Me.ShopingList_lbl.Text = "Lista de Compras"
        '
        'menuStrip1
        '
        Me.menuStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.connectionToolStripMenuItem})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(641, 24)
        Me.menuStrip1.TabIndex = 17
        Me.menuStrip1.Text = "menuStrip1"
        '
        'connectionToolStripMenuItem
        '
        Me.connectionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pollToolStripMenuItem, Me.loadKeysToolStripMenuItem, Me.CloseToolStripMenuItem, Me.setNormalModeToolStripMenuItem, Me.getTotalsToolStripMenuItem, Me.lastSaleToolStripMenuItem, Me.refundToolStripMenuItem, Me.salesDetailToolStripMenuItem, Me.toolStripComboBox1})
        Me.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem"
        Me.connectionToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.connectionToolStripMenuItem.Text = "POS"
        '
        'pollToolStripMenuItem
        '
        Me.pollToolStripMenuItem.Name = "pollToolStripMenuItem"
        Me.pollToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.pollToolStripMenuItem.Text = "Check Connection"
        '
        'loadKeysToolStripMenuItem
        '
        Me.loadKeysToolStripMenuItem.Name = "loadKeysToolStripMenuItem"
        Me.loadKeysToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.loadKeysToolStripMenuItem.Text = "Load Keys"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'setNormalModeToolStripMenuItem
        '
        Me.setNormalModeToolStripMenuItem.Name = "setNormalModeToolStripMenuItem"
        Me.setNormalModeToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.setNormalModeToolStripMenuItem.Text = "Set Normal Mode"
        '
        'getTotalsToolStripMenuItem
        '
        Me.getTotalsToolStripMenuItem.Name = "getTotalsToolStripMenuItem"
        Me.getTotalsToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.getTotalsToolStripMenuItem.Text = "Get Totals"
        '
        'lastSaleToolStripMenuItem
        '
        Me.lastSaleToolStripMenuItem.Name = "lastSaleToolStripMenuItem"
        Me.lastSaleToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.lastSaleToolStripMenuItem.Text = "Last Sale"
        '
        'refundToolStripMenuItem
        '
        Me.refundToolStripMenuItem.Name = "refundToolStripMenuItem"
        Me.refundToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.refundToolStripMenuItem.Text = "Refund"
        '
        'salesDetailToolStripMenuItem
        '
        Me.salesDetailToolStripMenuItem.Name = "salesDetailToolStripMenuItem"
        Me.salesDetailToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.salesDetailToolStripMenuItem.Text = "Sales Detail"
        '
        'toolStripComboBox1
        '
        Me.toolStripComboBox1.Items.AddRange(New Object() {"True", "False"})
        Me.toolStripComboBox1.Name = "toolStripComboBox1"
        Me.toolStripComboBox1.Size = New System.Drawing.Size(121, 23)
        Me.toolStripComboBox1.Text = "Intermediate Msg"
        '
        'Disconnect_btn
        '
        Me.Disconnect_btn.Location = New System.Drawing.Point(224, 34)
        Me.Disconnect_btn.Name = "Disconnect_btn"
        Me.Disconnect_btn.Size = New System.Drawing.Size(75, 23)
        Me.Disconnect_btn.TabIndex = 18
        Me.Disconnect_btn.Text = "Desconectar"
        Me.Disconnect_btn.UseVisualStyleBackColor = True
        '
        'ShopingList_lst
        '
        Me.ShopingList_lst.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Item, Me.precio})
        Me.ShopingList_lst.FullRowSelect = True
        Me.ShopingList_lst.GridLines = True
        Me.ShopingList_lst.HideSelection = False
        Me.ShopingList_lst.Location = New System.Drawing.Point(479, 76)
        Me.ShopingList_lst.Name = "ShopingList_lst"
        Me.ShopingList_lst.Size = New System.Drawing.Size(157, 249)
        Me.ShopingList_lst.TabIndex = 19
        Me.ShopingList_lst.UseCompatibleStateImageBehavior = False
        Me.ShopingList_lst.View = System.Windows.Forms.View.Details
        '
        'Item
        '
        Me.Item.Text = "Item"
        Me.Item.Width = 74
        '
        'precio
        '
        Me.precio.Text = "Valor"
        '
        'ShopingListLeyend_lbl
        '
        Me.ShopingListLeyend_lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.25!)
        Me.ShopingListLeyend_lbl.Location = New System.Drawing.Point(477, 47)
        Me.ShopingListLeyend_lbl.Name = "ShopingListLeyend_lbl"
        Me.ShopingListLeyend_lbl.Size = New System.Drawing.Size(156, 26)
        Me.ShopingListLeyend_lbl.TabIndex = 20
        Me.ShopingListLeyend_lbl.Text = "* Haga click en un elemento de la lista para eliminarlo"
        '
        'Pay_btn
        '
        Me.Pay_btn.Location = New System.Drawing.Point(562, 376)
        Me.Pay_btn.Name = "Pay_btn"
        Me.Pay_btn.Size = New System.Drawing.Size(70, 28)
        Me.Pay_btn.TabIndex = 21
        Me.Pay_btn.Text = "Pagar"
        Me.Pay_btn.UseVisualStyleBackColor = True
        '
        'Clean_btn
        '
        Me.Clean_btn.Location = New System.Drawing.Point(475, 376)
        Me.Clean_btn.Name = "Clean_btn"
        Me.Clean_btn.Size = New System.Drawing.Size(81, 28)
        Me.Clean_btn.TabIndex = 22
        Me.Clean_btn.Text = "Limpiar Carro"
        Me.Clean_btn.UseVisualStyleBackColor = True
        '
        'btn_onepay
        '
        Me.btn_onepay.Location = New System.Drawing.Point(475, 410)
        Me.btn_onepay.Name = "btn_onepay"
        Me.btn_onepay.Size = New System.Drawing.Size(157, 24)
        Me.btn_onepay.TabIndex = 23
        Me.btn_onepay.Text = "Pagar con Onepay"
        Me.btn_onepay.UseVisualStyleBackColor = True
        '
        'intermediateMsgTxtBox
        '
        Me.intermediateMsgTxtBox.Location = New System.Drawing.Point(12, 388)
        Me.intermediateMsgTxtBox.Multiline = True
        Me.intermediateMsgTxtBox.Name = "intermediateMsgTxtBox"
        Me.intermediateMsgTxtBox.ReadOnly = True
        Me.intermediateMsgTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.intermediateMsgTxtBox.Size = New System.Drawing.Size(445, 46)
        Me.intermediateMsgTxtBox.TabIndex = 24
        '
        'FrmPos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 446)
        Me.Controls.Add(Me.intermediateMsgTxtBox)
        Me.Controls.Add(Me.btn_onepay)
        Me.Controls.Add(Me.Clean_btn)
        Me.Controls.Add(Me.Pay_btn)
        Me.Controls.Add(Me.ShopingListLeyend_lbl)
        Me.Controls.Add(Me.ShopingList_lst)
        Me.Controls.Add(Me.Disconnect_btn)
        Me.Controls.Add(Me.ShopingList_lbl)
        Me.Controls.Add(Me.PortName_lbl)
        Me.Controls.Add(Me.tableLayoutPanel1)
        Me.Controls.Add(Me.ConnectedPort_lbl)
        Me.Controls.Add(Me.flowLayoutPanel1)
        Me.Controls.Add(Me.Connect_btn)
        Me.Controls.Add(Me.Port_ddown)
        Me.Controls.Add(Me.menuStrip1)
        Me.MainMenuStrip = Me.menuStrip1
        Me.Name = "FrmPos"
        Me.Text = "Form1"
        Me.flowLayoutPanel1.ResumeLayout(False)
        CType(Me.Cofee_img, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Juice_img, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cookies_img, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Icecream_img, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pizza_img, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Donut_img, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Burger_img, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Salad_img, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Fries_img, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.tableLayoutPanel1.PerformLayout()
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private ConnectedPort_lbl As System.Windows.Forms.Label
    Private PortName_lbl As System.Windows.Forms.Label
    Private tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Private ShopingList_lbl As System.Windows.Forms.Label
    Private Price_lbl As System.Windows.Forms.Label
    Private Total_lbl As System.Windows.Forms.Label
    Private menuStrip1 As System.Windows.Forms.MenuStrip
    Private connectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private Item As System.Windows.Forms.ColumnHeader
    Private precio As System.Windows.Forms.ColumnHeader
    Private ShopingListLeyend_lbl As System.Windows.Forms.Label
    Private WithEvents Cofee_img As PictureBox
    Private WithEvents Juice_img As PictureBox
    Private WithEvents Cookies_img As PictureBox
    Private WithEvents Icecream_img As PictureBox
    Private WithEvents Pizza_img As PictureBox
    Private WithEvents Donut_img As PictureBox
    Private WithEvents Burger_img As PictureBox
    Private WithEvents Salad_img As PictureBox
    Private WithEvents Fries_img As PictureBox
    Public WithEvents pollToolStripMenuItem As ToolStripMenuItem
    Public WithEvents Connect_btn As Button
    Public WithEvents Disconnect_btn As Button
    Public WithEvents Pay_btn As Button
    Public WithEvents Clean_btn As Button
    Public WithEvents btn_onepay As Button
    Public WithEvents loadKeysToolStripMenuItem As ToolStripMenuItem
    Public WithEvents CloseToolStripMenuItem As ToolStripMenuItem
    Public WithEvents setNormalModeToolStripMenuItem As ToolStripMenuItem
    Public WithEvents getTotalsToolStripMenuItem As ToolStripMenuItem
    Public WithEvents lastSaleToolStripMenuItem As ToolStripMenuItem
    Public WithEvents refundToolStripMenuItem As ToolStripMenuItem
    Public WithEvents salesDetailToolStripMenuItem As ToolStripMenuItem
    Public WithEvents toolStripComboBox1 As ToolStripComboBox
    Public WithEvents Port_ddown As ComboBox
    Public WithEvents flowLayoutPanel1 As FlowLayoutPanel
    Public WithEvents ShopingList_lst As ListView
    Public WithEvents intermediateMsgTxtBox As TextBox
End Class
