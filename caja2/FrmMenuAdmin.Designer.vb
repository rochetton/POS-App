<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenuAdmin
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AdministrativoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CargaDeLlavesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CierreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetalleDeVentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TotalDeVentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÚltimaVentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CambioAModoNormalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PollingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnularVentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Disconnect_btn = New System.Windows.Forms.Button()
        Me.Connect_btn = New System.Windows.Forms.Button()
        Me.Port_ddown = New System.Windows.Forms.ComboBox()
        Me.PortName_lbl = New System.Windows.Forms.Label()
        Me.ConnectedPort_lbl = New System.Windows.Forms.Label()
        Me.intermediateMsgTxtBox = New System.Windows.Forms.TextBox()
        Me.LblActividad = New System.Windows.Forms.Label()
        Me.btnLimpiarLog = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdministrativoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AdministrativoToolStripMenuItem
        '
        Me.AdministrativoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CargaDeLlavesToolStripMenuItem, Me.CierreToolStripMenuItem, Me.DetalleDeVentasToolStripMenuItem, Me.TotalDeVentasToolStripMenuItem, Me.ÚltimaVentaToolStripMenuItem, Me.CambioAModoNormalToolStripMenuItem, Me.PollingToolStripMenuItem, Me.AnularVentaToolStripMenuItem})
        Me.AdministrativoToolStripMenuItem.Name = "AdministrativoToolStripMenuItem"
        Me.AdministrativoToolStripMenuItem.Size = New System.Drawing.Size(97, 20)
        Me.AdministrativoToolStripMenuItem.Text = "Administrativo"
        '
        'CargaDeLlavesToolStripMenuItem
        '
        Me.CargaDeLlavesToolStripMenuItem.Name = "CargaDeLlavesToolStripMenuItem"
        Me.CargaDeLlavesToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.CargaDeLlavesToolStripMenuItem.Text = "Carga de Llaves"
        '
        'CierreToolStripMenuItem
        '
        Me.CierreToolStripMenuItem.Name = "CierreToolStripMenuItem"
        Me.CierreToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.CierreToolStripMenuItem.Text = "Cierre"
        '
        'DetalleDeVentasToolStripMenuItem
        '
        Me.DetalleDeVentasToolStripMenuItem.Name = "DetalleDeVentasToolStripMenuItem"
        Me.DetalleDeVentasToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.DetalleDeVentasToolStripMenuItem.Text = "Detalle de Ventas"
        '
        'TotalDeVentasToolStripMenuItem
        '
        Me.TotalDeVentasToolStripMenuItem.Name = "TotalDeVentasToolStripMenuItem"
        Me.TotalDeVentasToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.TotalDeVentasToolStripMenuItem.Text = "Total de Ventas"
        '
        'ÚltimaVentaToolStripMenuItem
        '
        Me.ÚltimaVentaToolStripMenuItem.Name = "ÚltimaVentaToolStripMenuItem"
        Me.ÚltimaVentaToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.ÚltimaVentaToolStripMenuItem.Text = "Última Venta"
        '
        'CambioAModoNormalToolStripMenuItem
        '
        Me.CambioAModoNormalToolStripMenuItem.Name = "CambioAModoNormalToolStripMenuItem"
        Me.CambioAModoNormalToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.CambioAModoNormalToolStripMenuItem.Text = "Cambio a Modo Normal"
        '
        'PollingToolStripMenuItem
        '
        Me.PollingToolStripMenuItem.Name = "PollingToolStripMenuItem"
        Me.PollingToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.PollingToolStripMenuItem.Text = "Polling"
        '
        'AnularVentaToolStripMenuItem
        '
        Me.AnularVentaToolStripMenuItem.Name = "AnularVentaToolStripMenuItem"
        Me.AnularVentaToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.AnularVentaToolStripMenuItem.Text = "Anular Venta"
        '
        'Disconnect_btn
        '
        Me.Disconnect_btn.Enabled = False
        Me.Disconnect_btn.Location = New System.Drawing.Point(200, 36)
        Me.Disconnect_btn.Name = "Disconnect_btn"
        Me.Disconnect_btn.Size = New System.Drawing.Size(83, 23)
        Me.Disconnect_btn.TabIndex = 21
        Me.Disconnect_btn.Text = "Desconectar"
        Me.Disconnect_btn.UseVisualStyleBackColor = True
        '
        'Connect_btn
        '
        Me.Connect_btn.Location = New System.Drawing.Point(119, 36)
        Me.Connect_btn.Name = "Connect_btn"
        Me.Connect_btn.Size = New System.Drawing.Size(75, 23)
        Me.Connect_btn.TabIndex = 20
        Me.Connect_btn.Text = "Conectar"
        Me.Connect_btn.UseVisualStyleBackColor = True
        '
        'Port_ddown
        '
        Me.Port_ddown.FormattingEnabled = True
        Me.Port_ddown.Items.AddRange(New Object() {"COM4"})
        Me.Port_ddown.Location = New System.Drawing.Point(12, 36)
        Me.Port_ddown.Name = "Port_ddown"
        Me.Port_ddown.Size = New System.Drawing.Size(101, 21)
        Me.Port_ddown.TabIndex = 19
        '
        'PortName_lbl
        '
        Me.PortName_lbl.AutoSize = True
        Me.PortName_lbl.Location = New System.Drawing.Point(124, 73)
        Me.PortName_lbl.Name = "PortName_lbl"
        Me.PortName_lbl.Size = New System.Drawing.Size(45, 13)
        Me.PortName_lbl.TabIndex = 23
        Me.PortName_lbl.Text = "ninguno"
        '
        'ConnectedPort_lbl
        '
        Me.ConnectedPort_lbl.AutoSize = True
        Me.ConnectedPort_lbl.Location = New System.Drawing.Point(17, 73)
        Me.ConnectedPort_lbl.Name = "ConnectedPort_lbl"
        Me.ConnectedPort_lbl.Size = New System.Drawing.Size(96, 13)
        Me.ConnectedPort_lbl.TabIndex = 22
        Me.ConnectedPort_lbl.Text = "Puerto Conectado:"
        '
        'intermediateMsgTxtBox
        '
        Me.intermediateMsgTxtBox.Location = New System.Drawing.Point(12, 125)
        Me.intermediateMsgTxtBox.Multiline = True
        Me.intermediateMsgTxtBox.Name = "intermediateMsgTxtBox"
        Me.intermediateMsgTxtBox.Size = New System.Drawing.Size(776, 257)
        Me.intermediateMsgTxtBox.TabIndex = 24
        '
        'LblActividad
        '
        Me.LblActividad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblActividad.Location = New System.Drawing.Point(12, 99)
        Me.LblActividad.Name = "LblActividad"
        Me.LblActividad.Size = New System.Drawing.Size(182, 23)
        Me.LblActividad.TabIndex = 25
        Me.LblActividad.Text = "Log de Actividad"
        '
        'btnLimpiarLog
        '
        Me.btnLimpiarLog.Location = New System.Drawing.Point(200, 99)
        Me.btnLimpiarLog.Name = "btnLimpiarLog"
        Me.btnLimpiarLog.Size = New System.Drawing.Size(83, 23)
        Me.btnLimpiarLog.TabIndex = 26
        Me.btnLimpiarLog.Text = "Limpiar Log"
        Me.btnLimpiarLog.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(702, 499)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(86, 23)
        Me.btnSalir.TabIndex = 27
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'FrmMenuAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 534)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnLimpiarLog)
        Me.Controls.Add(Me.LblActividad)
        Me.Controls.Add(Me.intermediateMsgTxtBox)
        Me.Controls.Add(Me.PortName_lbl)
        Me.Controls.Add(Me.ConnectedPort_lbl)
        Me.Controls.Add(Me.Disconnect_btn)
        Me.Controls.Add(Me.Connect_btn)
        Me.Controls.Add(Me.Port_ddown)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmMenuAdmin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menú Administrativo POS Integrado"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AdministrativoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CargaDeLlavesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CierreToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DetalleDeVentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TotalDeVentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ÚltimaVentaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CambioAModoNormalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PollingToolStripMenuItem As ToolStripMenuItem
    Public WithEvents Disconnect_btn As Button
    Public WithEvents Connect_btn As Button
    Public WithEvents Port_ddown As ComboBox
    Private WithEvents PortName_lbl As Label
    Private WithEvents ConnectedPort_lbl As Label
    Friend WithEvents intermediateMsgTxtBox As TextBox
    Private WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents LblActividad As Label
    Friend WithEvents AnularVentaToolStripMenuItem As ToolStripMenuItem
    Public WithEvents btnLimpiarLog As Button
    Friend WithEvents btnSalir As Button
End Class
