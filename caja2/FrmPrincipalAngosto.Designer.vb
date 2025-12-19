<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPrincipalAngosto
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrincipalAngosto))
        Me.TabPagos = New System.Windows.Forms.TabControl()
        Me.TbpPago = New System.Windows.Forms.TabPage()
        Me.Panel_BotonesPago = New System.Windows.Forms.Panel()
        Me.Panel_BotonesMedioPago = New System.Windows.Forms.Panel()
        Me.lbl_creditoDispCliente = New System.Windows.Forms.Label()
        Me.btnEfectivo = New System.Windows.Forms.Button()
        Me.btnAnticipos = New System.Windows.Forms.Button()
        Me.btnTarjeta = New System.Windows.Forms.Button()
        Me.btnTransferencia = New System.Windows.Forms.Button()
        Me.btnLineaFuncionario = New System.Windows.Forms.Button()
        Me.btnMarketPlace = New System.Windows.Forms.Button()
        Me.btnCheque = New System.Windows.Forms.Button()
        Me.btnValeVista = New System.Windows.Forms.Button()
        Me.btnLineaCredito = New System.Windows.Forms.Button()
        Me.btnNotaCredito = New System.Windows.Forms.Button()
        Me.DgvDetallePagos = New System.Windows.Forms.DataGridView()
        Me.col_tipoMedioPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_monto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_detalle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comprobante = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.col_montoOriginal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_numeroOperacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_numCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_fechaCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_bancoCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_NroOrsan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_nroCuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_rutGirador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_codEmpresa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_ejercicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_numeroSAP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_montoRedondeo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNumeroTarjeta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIDTerminal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNumeroCuotas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_correlativo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_CodigoRechazoOrsan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.lbl_vuelto = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.lbl_total = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.lbl_Saldo = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.lbl_pago = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.lbl_totalDocumentos = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.lbl_totalPedido = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.lblTituloPago = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Panel_NotaCredito = New System.Windows.Forms.Panel()
        Me.lblTituloNotaCredito = New System.Windows.Forms.Label()
        Me.btnAgregarNotaCredito = New System.Windows.Forms.Button()
        Me.DgvNotasCredito = New System.Windows.Forms.DataGridView()
        Me.ColNCTipoDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNCNumeroDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNCFechaEmision = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNCValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNCFactura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNCNumeroSap = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNCCodEmpresa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNCEjercicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbx_notasCredito = New System.Windows.Forms.ComboBox()
        Me.cmbTipoDoc = New System.Windows.Forms.ComboBox()
        Me.txt_FolioPagar = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.btnFiltrarPagos = New System.Windows.Forms.Button()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Panel_marketPlace = New System.Windows.Forms.Panel()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.cbx_marketPlace = New System.Windows.Forms.ComboBox()
        Me.btnAgregarMontoMarketPlace = New System.Windows.Forms.Button()
        Me.txt_montoMarketPlace = New System.Windows.Forms.TextBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Panel_Efectivo = New System.Windows.Forms.Panel()
        Me.lbl_efectivoRedondeado = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.lbl_redondeoEfectivo = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.txt_vueltoEfectivo = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.btnAgregarEfectivo = New System.Windows.Forms.Button()
        Me.txt_montoEfectivo = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Panel_Transferencia = New System.Windows.Forms.Panel()
        Me.txt_nombreArchivoComprobante = New System.Windows.Forms.TextBox()
        Me.btnAdjuntarComprobante = New System.Windows.Forms.Button()
        Me.btnAgregarTransferencia = New System.Windows.Forms.Button()
        Me.cbx_bcoTransferencia = New System.Windows.Forms.ComboBox()
        Me.txt_montoTransferencia = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txt_numeroOperacion = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Panel_Cheque = New System.Windows.Forms.Panel()
        Me.lbl_codigoRechazoOrsan = New System.Windows.Forms.Label()
        Me.NudFecVencimientoCheque = New System.Windows.Forms.NumericUpDown()
        Me.lblCantidadCheques = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.cbx_tipoVencimientoCheque = New System.Windows.Forms.ComboBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.btnChequeSiguiente = New System.Windows.Forms.Button()
        Me.btnChequeAnterior = New System.Windows.Forms.Button()
        Me.lblPosicionCheque = New System.Windows.Forms.Label()
        Me.btnValidarCheque = New System.Windows.Forms.Button()
        Me.txt_montoTotalCheques = New System.Windows.Forms.TextBox()
        Me.btnEscanearCheque = New System.Windows.Forms.Button()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.cbx_plazaBanco = New System.Windows.Forms.ComboBox()
        Me.txt_rutGirador = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lbl_codigoAutorizacion = New System.Windows.Forms.Label()
        Me.txt_codigoAutorizacion = New System.Windows.Forms.TextBox()
        Me.Imagen_Validacion_Cheque = New System.Windows.Forms.PictureBox()
        Me.btnAgregarCheque = New System.Windows.Forms.Button()
        Me.txt_montoCheque = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.DtpFechaVencCheque = New System.Windows.Forms.DateTimePicker()
        Me.btnImprimirCheque = New System.Windows.Forms.Button()
        Me.txt_nroCheque = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cbx_banco = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_numeroCuenta = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Panel_Tarjeta = New System.Windows.Forms.Panel()
        Me.txt_NumeroCuotas = New System.Windows.Forms.TextBox()
        Me.lblNumeroCuotas = New System.Windows.Forms.Label()
        Me.txt_NumeroTarjeta = New System.Windows.Forms.TextBox()
        Me.lblTituloNumeroTarjeta = New System.Windows.Forms.Label()
        Me.cmbTipoTarjetaCredito = New System.Windows.Forms.ComboBox()
        Me.lblTipoTarjeta = New System.Windows.Forms.Label()
        Me.txt_AutorizacionTarjeta = New System.Windows.Forms.TextBox()
        Me.lblAutorizacionTarjeta = New System.Windows.Forms.Label()
        Me.rdbPagoManual = New System.Windows.Forms.RadioButton()
        Me.rdbPagoSerial = New System.Windows.Forms.RadioButton()
        Me.Label_OK_Tarjeta = New System.Windows.Forms.PictureBox()
        Me.txt_montoTarjeta = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.btnPagarTarjeta = New System.Windows.Forms.Button()
        Me.panel_LineaFuncionario = New System.Windows.Forms.Panel()
        Me.btnAgregarMontoFuncionario = New System.Windows.Forms.Button()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txt_montoLineaFuncionario = New System.Windows.Forms.TextBox()
        Me.Panel_Anticipos = New System.Windows.Forms.Panel()
        Me.DgvAnticipos = New System.Windows.Forms.DataGridView()
        Me.ColAntTipoDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAntNumeroDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAntFechaEmision = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAntValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAntFacturaAsoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAntNumeroSAP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAntCodEmpresa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAntEjercicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAgregarAnticipo = New System.Windows.Forms.Button()
        Me.cbx_abonos = New System.Windows.Forms.ComboBox()
        Me.Anticipos = New System.Windows.Forms.Label()
        Me.Panel_CtaCAREN = New System.Windows.Forms.Panel()
        Me.DgvDocPorPagar = New System.Windows.Forms.DataGridView()
        Me.Sel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TipoDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Folio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaVto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Monto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Morosidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bloqueado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Numero_SAP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Numero_NotaVenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre_Banco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cod_Autorizacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Imprimir = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Correo = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnAgregarMontoCuenta = New System.Windows.Forms.Button()
        Me.txt_montoLineaCredito = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.TbpNotaVenta = New System.Windows.Forms.TabPage()
        Me.CmbEstadoNotaVenta = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnFiltrarNotaVenta = New System.Windows.Forms.Button()
        Me.txt_nombreClienteNV = New System.Windows.Forms.TextBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.txt_numeroNV = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.WbbNotaVenta = New System.Windows.Forms.WebBrowser()
        Me.DgvNotasVenta = New System.Windows.Forms.DataGridView()
        Me.TipoDocOrigen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoDocImagen = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colNumeroNVOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFechaNVOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nvc_totalFinal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombreClienteNVOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRut = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEMail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTelefono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombreEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TbpNotaCredito = New System.Windows.Forms.TabPage()
        Me.DgvNotasCreditoWorkflow = New System.Windows.Forms.DataGridView()
        Me.ColNumero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRutCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNombreCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMontoTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombreEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTipoDte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFolioDte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VwwebnotaVentaCabBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSetcatalogoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet_catalogo = New caja2.DataSet_catalogo()
        Me.BancoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SpwebbusquedageneralBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblReintento = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.chk_anticipo = New System.Windows.Forms.CheckBox()
        Me.btnPagarDocumentos = New System.Windows.Forms.Button()
        Me.txt_datosDespacho = New System.Windows.Forms.TextBox()
        Me.lblDatosDespacho = New System.Windows.Forms.Label()
        Me.lblNumeroDocumento = New System.Windows.Forms.Label()
        Me.txt_medioPago = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.chk_emailDocumento = New System.Windows.Forms.CheckBox()
        Me.chk_imprimirDocumento = New System.Windows.Forms.CheckBox()
        Me.Label_OK_Cupon = New System.Windows.Forms.PictureBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txt_cupon = New System.Windows.Forms.TextBox()
        Me.txt_OC = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txt_NotaVenta = New System.Windows.Forms.TextBox()
        Me.lbl_docOrigen = New System.Windows.Forms.Label()
        Me.txt_vendedor = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt_nombreCajero = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnRestablecer = New System.Windows.Forms.Button()
        Me.pnl_totalProductos = New System.Windows.Forms.Panel()
        Me.txt_totalDescuentoCupon = New System.Windows.Forms.Label()
        Me.txt_totalIva = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.lbl_totalFinal = New System.Windows.Forms.Label()
        Me.txt_totalNeto = New System.Windows.Forms.Label()
        Me.txt_totalDescuento = New System.Windows.Forms.Label()
        Me.txt_subtotal = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.RadioButton_notaCredito = New System.Windows.Forms.RadioButton()
        Me.RadioButton_boleta = New System.Windows.Forms.RadioButton()
        Me.RadioButton_factura = New System.Windows.Forms.RadioButton()
        Me.btnFacturar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.btnBuscarProducto = New System.Windows.Forms.Button()
        Me.DgvDetalleProductos = New System.Windows.Forms.DataGridView()
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescrip = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitarioNeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalNeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_cantidad = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnAgregarProducto = New System.Windows.Forms.Button()
        Me.txt_codigo_CAREN = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.imagen_conexion_basedatos = New System.Windows.Forms.PictureBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.cbx_direcciones_cliente = New System.Windows.Forms.ComboBox()
        Me.txt_apellido_cliente = New System.Windows.Forms.TextBox()
        Me.lblApellidoCliente = New System.Windows.Forms.Label()
        Me.txt_idCliente = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.cbx_comuna_cliente = New System.Windows.Forms.ComboBox()
        Me.cbx_ciudad_cliente = New System.Windows.Forms.ComboBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txt_giro_cliente = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txt_email_cliente = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txt_direccion_cliente = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txt_telefono_cliente = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txt_nombre_cliente = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txt_rutCliente = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lbl_tituloCliente = New System.Windows.Forms.Label()
        Me.pnl_totalDocumentos = New System.Windows.Forms.Panel()
        Me.btnGrabarCliente = New System.Windows.Forms.Button()
        Me.btnVerDatosCliente = New System.Windows.Forms.Button()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.txt_totalDocumentos = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.btnCierreCaja = New System.Windows.Forms.Button()
        Me.iml_botones_columnas = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BancoBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Ofd_importar = New System.Windows.Forms.OpenFileDialog()
        Me.iml_imagenes_grilla = New System.Windows.Forms.ImageList(Me.components)
        Me.btnMenuAdmin = New System.Windows.Forms.Button()
        Me.WebcarroCompra2BindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.WebcarroCompra2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.WebcarroCompra2BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.WebcarroCompra2TableAdapterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Sp_web_busqueda_generalTableAdapter = New caja2.DataSet_catalogoTableAdapters.sp_web_busqueda_generalTableAdapter()
        Me.Vw_web_notaVentaCabTableAdapter = New caja2.DataSet_catalogoTableAdapters.vw_web_notaVentaCabTableAdapter()
        Me.TableAdapterManager = New caja2.DataSet_catalogoTableAdapters.TableAdapterManager()
        Me.BancoTableAdapter = New caja2.DataSet_catalogoTableAdapters.bancoTableAdapter()
        Me.TabPagos.SuspendLayout()
        Me.TbpPago.SuspendLayout()
        Me.Panel_BotonesPago.SuspendLayout()
        Me.Panel_BotonesMedioPago.SuspendLayout()
        CType(Me.DgvDetallePagos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_NotaCredito.SuspendLayout()
        CType(Me.DgvNotasCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_marketPlace.SuspendLayout()
        Me.Panel_Efectivo.SuspendLayout()
        Me.Panel_Transferencia.SuspendLayout()
        Me.Panel_Cheque.SuspendLayout()
        CType(Me.NudFecVencimientoCheque, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Imagen_Validacion_Cheque, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_Tarjeta.SuspendLayout()
        CType(Me.Label_OK_Tarjeta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_LineaFuncionario.SuspendLayout()
        Me.Panel_Anticipos.SuspendLayout()
        CType(Me.DgvAnticipos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_CtaCAREN.SuspendLayout()
        CType(Me.DgvDocPorPagar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TbpNotaVenta.SuspendLayout()
        CType(Me.DgvNotasVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TbpNotaCredito.SuspendLayout()
        CType(Me.DgvNotasCreditoWorkflow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VwwebnotaVentaCabBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetcatalogoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet_catalogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BancoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SpwebbusquedageneralBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.Label_OK_Cupon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_totalProductos.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvDetalleProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imagen_conexion_basedatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_totalDocumentos.SuspendLayout()
        CType(Me.BancoBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WebcarroCompra2BindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WebcarroCompra2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WebcarroCompra2BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WebcarroCompra2TableAdapterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabPagos
        '
        Me.TabPagos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TabPagos.Controls.Add(Me.TbpPago)
        Me.TabPagos.Controls.Add(Me.TbpNotaVenta)
        Me.TabPagos.Controls.Add(Me.TbpNotaCredito)
        Me.TabPagos.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.TabPagos.Location = New System.Drawing.Point(752, 0)
        Me.TabPagos.Name = "TabPagos"
        Me.TabPagos.Padding = New System.Drawing.Point(12, 3)
        Me.TabPagos.SelectedIndex = 0
        Me.TabPagos.Size = New System.Drawing.Size(889, 700)
        Me.TabPagos.TabIndex = 0
        '
        'TbpPago
        '
        Me.TbpPago.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.TbpPago.Controls.Add(Me.Panel_NotaCredito)
        Me.TbpPago.Controls.Add(Me.DgvDocPorPagar)
        Me.TbpPago.Controls.Add(Me.Panel_BotonesPago)
        Me.TbpPago.Controls.Add(Me.cmbTipoDoc)
        Me.TbpPago.Controls.Add(Me.txt_FolioPagar)
        Me.TbpPago.Controls.Add(Me.Label16)
        Me.TbpPago.Controls.Add(Me.Label36)
        Me.TbpPago.Controls.Add(Me.btnFiltrarPagos)
        Me.TbpPago.Controls.Add(Me.Label46)
        Me.TbpPago.Controls.Add(Me.PictureBox4)
        Me.TbpPago.Controls.Add(Me.Panel_marketPlace)
        Me.TbpPago.Controls.Add(Me.Panel_Efectivo)
        Me.TbpPago.Controls.Add(Me.Panel_Transferencia)
        Me.TbpPago.Controls.Add(Me.Panel_Cheque)
        Me.TbpPago.Controls.Add(Me.Panel_Tarjeta)
        Me.TbpPago.Controls.Add(Me.panel_LineaFuncionario)
        Me.TbpPago.Controls.Add(Me.Panel_Anticipos)
        Me.TbpPago.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbpPago.Location = New System.Drawing.Point(4, 22)
        Me.TbpPago.Name = "TbpPago"
        Me.TbpPago.Size = New System.Drawing.Size(881, 674)
        Me.TbpPago.TabIndex = 1
        Me.TbpPago.Text = "Pago"
        '
        'Panel_BotonesPago
        '
        Me.Panel_BotonesPago.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_BotonesPago.Controls.Add(Me.Panel_BotonesMedioPago)
        Me.Panel_BotonesPago.Controls.Add(Me.DgvDetallePagos)
        Me.Panel_BotonesPago.Controls.Add(Me.Panel7)
        Me.Panel_BotonesPago.Controls.Add(Me.lblTituloPago)
        Me.Panel_BotonesPago.Controls.Add(Me.PictureBox5)
        Me.Panel_BotonesPago.Location = New System.Drawing.Point(2, 168)
        Me.Panel_BotonesPago.Name = "Panel_BotonesPago"
        Me.Panel_BotonesPago.Size = New System.Drawing.Size(586, 496)
        Me.Panel_BotonesPago.TabIndex = 39
        '
        'Panel_BotonesMedioPago
        '
        Me.Panel_BotonesMedioPago.Controls.Add(Me.lbl_creditoDispCliente)
        Me.Panel_BotonesMedioPago.Controls.Add(Me.btnEfectivo)
        Me.Panel_BotonesMedioPago.Controls.Add(Me.btnAnticipos)
        Me.Panel_BotonesMedioPago.Controls.Add(Me.btnTarjeta)
        Me.Panel_BotonesMedioPago.Controls.Add(Me.btnTransferencia)
        Me.Panel_BotonesMedioPago.Controls.Add(Me.btnLineaFuncionario)
        Me.Panel_BotonesMedioPago.Controls.Add(Me.btnMarketPlace)
        Me.Panel_BotonesMedioPago.Controls.Add(Me.btnCheque)
        Me.Panel_BotonesMedioPago.Controls.Add(Me.btnValeVista)
        Me.Panel_BotonesMedioPago.Controls.Add(Me.btnLineaCredito)
        Me.Panel_BotonesMedioPago.Controls.Add(Me.btnNotaCredito)
        Me.Panel_BotonesMedioPago.Location = New System.Drawing.Point(0, 0)
        Me.Panel_BotonesMedioPago.Name = "Panel_BotonesMedioPago"
        Me.Panel_BotonesMedioPago.Size = New System.Drawing.Size(800, 80)
        Me.Panel_BotonesMedioPago.TabIndex = 111
        '
        'lbl_creditoDispCliente
        '
        Me.lbl_creditoDispCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_creditoDispCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_creditoDispCliente.ForeColor = System.Drawing.Color.DarkOrange
        Me.lbl_creditoDispCliente.Location = New System.Drawing.Point(4, 57)
        Me.lbl_creditoDispCliente.Name = "lbl_creditoDispCliente"
        Me.lbl_creditoDispCliente.Size = New System.Drawing.Size(123, 18)
        Me.lbl_creditoDispCliente.TabIndex = 121
        Me.lbl_creditoDispCliente.Text = "( $ 0 )"
        Me.lbl_creditoDispCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.lbl_creditoDispCliente, "Detalle de La cuenta Corriente :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Clase de Riesgo = bajo")
        '
        'btnEfectivo
        '
        Me.btnEfectivo.BackColor = System.Drawing.Color.SteelBlue
        Me.btnEfectivo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEfectivo.FlatAppearance.BorderSize = 0
        Me.btnEfectivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEfectivo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnEfectivo.ForeColor = System.Drawing.Color.White
        Me.btnEfectivo.Location = New System.Drawing.Point(6, 5)
        Me.btnEfectivo.Name = "btnEfectivo"
        Me.btnEfectivo.Size = New System.Drawing.Size(118, 26)
        Me.btnEfectivo.TabIndex = 113
        Me.btnEfectivo.Text = "Efectivo"
        Me.btnEfectivo.UseVisualStyleBackColor = False
        '
        'btnAnticipos
        '
        Me.btnAnticipos.BackColor = System.Drawing.Color.SteelBlue
        Me.btnAnticipos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAnticipos.FlatAppearance.BorderSize = 0
        Me.btnAnticipos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAnticipos.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnAnticipos.ForeColor = System.Drawing.Color.White
        Me.btnAnticipos.Location = New System.Drawing.Point(254, 32)
        Me.btnAnticipos.Name = "btnAnticipos"
        Me.btnAnticipos.Size = New System.Drawing.Size(118, 26)
        Me.btnAnticipos.TabIndex = 119
        Me.btnAnticipos.Text = "Anticipos"
        Me.btnAnticipos.UseVisualStyleBackColor = False
        '
        'btnTarjeta
        '
        Me.btnTarjeta.BackColor = System.Drawing.Color.SteelBlue
        Me.btnTarjeta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTarjeta.FlatAppearance.BorderSize = 0
        Me.btnTarjeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTarjeta.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnTarjeta.ForeColor = System.Drawing.Color.White
        Me.btnTarjeta.Location = New System.Drawing.Point(130, 5)
        Me.btnTarjeta.Name = "btnTarjeta"
        Me.btnTarjeta.Size = New System.Drawing.Size(118, 26)
        Me.btnTarjeta.TabIndex = 115
        Me.btnTarjeta.Text = "Tarj. Crédito/Débito"
        Me.btnTarjeta.UseVisualStyleBackColor = False
        '
        'btnTransferencia
        '
        Me.btnTransferencia.BackColor = System.Drawing.Color.SteelBlue
        Me.btnTransferencia.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTransferencia.FlatAppearance.BorderSize = 0
        Me.btnTransferencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTransferencia.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnTransferencia.ForeColor = System.Drawing.Color.White
        Me.btnTransferencia.Location = New System.Drawing.Point(378, 5)
        Me.btnTransferencia.Name = "btnTransferencia"
        Me.btnTransferencia.Size = New System.Drawing.Size(118, 26)
        Me.btnTransferencia.TabIndex = 114
        Me.btnTransferencia.Text = "Transferencia"
        Me.btnTransferencia.UseVisualStyleBackColor = False
        '
        'btnLineaFuncionario
        '
        Me.btnLineaFuncionario.BackColor = System.Drawing.Color.SteelBlue
        Me.btnLineaFuncionario.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLineaFuncionario.FlatAppearance.BorderSize = 0
        Me.btnLineaFuncionario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLineaFuncionario.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnLineaFuncionario.ForeColor = System.Drawing.Color.White
        Me.btnLineaFuncionario.Location = New System.Drawing.Point(502, 5)
        Me.btnLineaFuncionario.Name = "btnLineaFuncionario"
        Me.btnLineaFuncionario.Size = New System.Drawing.Size(118, 26)
        Me.btnLineaFuncionario.TabIndex = 117
        Me.btnLineaFuncionario.Text = "Línea Funcionario"
        Me.btnLineaFuncionario.UseVisualStyleBackColor = False
        Me.btnLineaFuncionario.Visible = False
        '
        'btnMarketPlace
        '
        Me.btnMarketPlace.BackColor = System.Drawing.Color.SteelBlue
        Me.btnMarketPlace.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMarketPlace.FlatAppearance.BorderSize = 0
        Me.btnMarketPlace.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMarketPlace.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnMarketPlace.ForeColor = System.Drawing.Color.White
        Me.btnMarketPlace.Location = New System.Drawing.Point(378, 32)
        Me.btnMarketPlace.Name = "btnMarketPlace"
        Me.btnMarketPlace.Size = New System.Drawing.Size(118, 26)
        Me.btnMarketPlace.TabIndex = 118
        Me.btnMarketPlace.Text = "Market Place"
        Me.btnMarketPlace.UseVisualStyleBackColor = False
        Me.btnMarketPlace.Visible = False
        '
        'btnCheque
        '
        Me.btnCheque.BackColor = System.Drawing.Color.SteelBlue
        Me.btnCheque.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCheque.FlatAppearance.BorderSize = 0
        Me.btnCheque.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCheque.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnCheque.ForeColor = System.Drawing.Color.White
        Me.btnCheque.Location = New System.Drawing.Point(254, 5)
        Me.btnCheque.Name = "btnCheque"
        Me.btnCheque.Size = New System.Drawing.Size(118, 26)
        Me.btnCheque.TabIndex = 112
        Me.btnCheque.Text = "Cheque"
        Me.btnCheque.UseVisualStyleBackColor = False
        '
        'btnValeVista
        '
        Me.btnValeVista.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnValeVista.BackColor = System.Drawing.Color.SteelBlue
        Me.btnValeVista.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnValeVista.FlatAppearance.BorderSize = 0
        Me.btnValeVista.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnValeVista.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnValeVista.ForeColor = System.Drawing.Color.White
        Me.btnValeVista.Location = New System.Drawing.Point(502, 32)
        Me.btnValeVista.Name = "btnValeVista"
        Me.btnValeVista.Size = New System.Drawing.Size(118, 26)
        Me.btnValeVista.TabIndex = 120
        Me.btnValeVista.Text = "Vale Vista"
        Me.btnValeVista.UseVisualStyleBackColor = False
        Me.btnValeVista.Visible = False
        '
        'btnLineaCredito
        '
        Me.btnLineaCredito.BackColor = System.Drawing.Color.SteelBlue
        Me.btnLineaCredito.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLineaCredito.FlatAppearance.BorderSize = 0
        Me.btnLineaCredito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLineaCredito.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnLineaCredito.ForeColor = System.Drawing.Color.White
        Me.btnLineaCredito.Location = New System.Drawing.Point(6, 32)
        Me.btnLineaCredito.Name = "btnLineaCredito"
        Me.btnLineaCredito.Size = New System.Drawing.Size(118, 26)
        Me.btnLineaCredito.TabIndex = 111
        Me.btnLineaCredito.Text = "Línea Crédito"
        Me.btnLineaCredito.UseVisualStyleBackColor = False
        '
        'btnNotaCredito
        '
        Me.btnNotaCredito.BackColor = System.Drawing.Color.SteelBlue
        Me.btnNotaCredito.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNotaCredito.FlatAppearance.BorderSize = 0
        Me.btnNotaCredito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNotaCredito.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnNotaCredito.ForeColor = System.Drawing.Color.White
        Me.btnNotaCredito.Location = New System.Drawing.Point(130, 32)
        Me.btnNotaCredito.Name = "btnNotaCredito"
        Me.btnNotaCredito.Size = New System.Drawing.Size(118, 26)
        Me.btnNotaCredito.TabIndex = 116
        Me.btnNotaCredito.Text = "Nota Crédito"
        Me.btnNotaCredito.UseVisualStyleBackColor = False
        '
        'DgvDetallePagos
        '
        Me.DgvDetallePagos.AllowUserToAddRows = False
        Me.DgvDetallePagos.AllowUserToDeleteRows = False
        Me.DgvDetallePagos.AllowUserToResizeRows = False
        DataGridViewCellStyle29.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.DgvDetallePagos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle29
        Me.DgvDetallePagos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvDetallePagos.BackgroundColor = System.Drawing.Color.White
        Me.DgvDetallePagos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DgvDetallePagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDetallePagos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_tipoMedioPago, Me.col_monto, Me.col_detalle, Me.Comprobante, Me.col_montoOriginal, Me.col_numeroOperacion, Me.col_numCheque, Me.col_fechaCheque, Me.col_bancoCheque, Me.col_NroOrsan, Me.col_nroCuenta, Me.col_rutGirador, Me.col_codEmpresa, Me.col_ejercicio, Me.col_numeroSAP, Me.col_montoRedondeo, Me.ColNumeroTarjeta, Me.ColIDTerminal, Me.ColNumeroCuotas, Me.col_correlativo, Me.col_CodigoRechazoOrsan})
        Me.DgvDetallePagos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DgvDetallePagos.GridColor = System.Drawing.Color.White
        Me.DgvDetallePagos.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.DgvDetallePagos.Location = New System.Drawing.Point(0, 283)
        Me.DgvDetallePagos.MultiSelect = False
        Me.DgvDetallePagos.Name = "DgvDetallePagos"
        Me.DgvDetallePagos.ReadOnly = True
        Me.DgvDetallePagos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvDetallePagos.RowTemplate.Height = 25
        Me.DgvDetallePagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvDetallePagos.Size = New System.Drawing.Size(580, 123)
        Me.DgvDetallePagos.TabIndex = 86
        '
        'col_tipoMedioPago
        '
        DataGridViewCellStyle30.NullValue = Nothing
        Me.col_tipoMedioPago.DefaultCellStyle = DataGridViewCellStyle30
        Me.col_tipoMedioPago.HeaderText = "Tipo"
        Me.col_tipoMedioPago.Name = "col_tipoMedioPago"
        Me.col_tipoMedioPago.ReadOnly = True
        Me.col_tipoMedioPago.Width = 170
        '
        'col_monto
        '
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle31.Format = "$ #,##0"
        Me.col_monto.DefaultCellStyle = DataGridViewCellStyle31
        Me.col_monto.HeaderText = "Monto"
        Me.col_monto.Name = "col_monto"
        Me.col_monto.ReadOnly = True
        Me.col_monto.Width = 90
        '
        'col_detalle
        '
        Me.col_detalle.HeaderText = "Detalle"
        Me.col_detalle.Name = "col_detalle"
        Me.col_detalle.ReadOnly = True
        Me.col_detalle.Width = 490
        '
        'Comprobante
        '
        Me.Comprobante.HeaderText = " Ver"
        Me.Comprobante.Name = "Comprobante"
        Me.Comprobante.ReadOnly = True
        Me.Comprobante.Text = ""
        Me.Comprobante.UseColumnTextForButtonValue = True
        Me.Comprobante.Width = 40
        '
        'col_montoOriginal
        '
        Me.col_montoOriginal.HeaderText = "Monto Original"
        Me.col_montoOriginal.Name = "col_montoOriginal"
        Me.col_montoOriginal.ReadOnly = True
        Me.col_montoOriginal.Visible = False
        '
        'col_numeroOperacion
        '
        Me.col_numeroOperacion.HeaderText = "Número Operación"
        Me.col_numeroOperacion.Name = "col_numeroOperacion"
        Me.col_numeroOperacion.ReadOnly = True
        Me.col_numeroOperacion.Visible = False
        '
        'col_numCheque
        '
        Me.col_numCheque.HeaderText = "Número Cheque"
        Me.col_numCheque.Name = "col_numCheque"
        Me.col_numCheque.ReadOnly = True
        Me.col_numCheque.Visible = False
        '
        'col_fechaCheque
        '
        Me.col_fechaCheque.HeaderText = "Fecha Cheque"
        Me.col_fechaCheque.Name = "col_fechaCheque"
        Me.col_fechaCheque.ReadOnly = True
        Me.col_fechaCheque.Visible = False
        '
        'col_bancoCheque
        '
        Me.col_bancoCheque.HeaderText = "Banco Cheque"
        Me.col_bancoCheque.Name = "col_bancoCheque"
        Me.col_bancoCheque.ReadOnly = True
        Me.col_bancoCheque.Visible = False
        '
        'col_NroOrsan
        '
        Me.col_NroOrsan.HeaderText = "Código Autorización"
        Me.col_NroOrsan.Name = "col_NroOrsan"
        Me.col_NroOrsan.ReadOnly = True
        Me.col_NroOrsan.Visible = False
        '
        'col_nroCuenta
        '
        Me.col_nroCuenta.HeaderText = "Número Cuenta"
        Me.col_nroCuenta.Name = "col_nroCuenta"
        Me.col_nroCuenta.ReadOnly = True
        Me.col_nroCuenta.Visible = False
        '
        'col_rutGirador
        '
        Me.col_rutGirador.HeaderText = "Rut Girador"
        Me.col_rutGirador.Name = "col_rutGirador"
        Me.col_rutGirador.ReadOnly = True
        Me.col_rutGirador.Visible = False
        '
        'col_codEmpresa
        '
        Me.col_codEmpresa.HeaderText = "Código Empresa"
        Me.col_codEmpresa.Name = "col_codEmpresa"
        Me.col_codEmpresa.ReadOnly = True
        Me.col_codEmpresa.Visible = False
        '
        'col_ejercicio
        '
        Me.col_ejercicio.HeaderText = "Ejercicio"
        Me.col_ejercicio.Name = "col_ejercicio"
        Me.col_ejercicio.ReadOnly = True
        Me.col_ejercicio.Visible = False
        '
        'col_numeroSAP
        '
        Me.col_numeroSAP.HeaderText = "número SAP"
        Me.col_numeroSAP.Name = "col_numeroSAP"
        Me.col_numeroSAP.ReadOnly = True
        Me.col_numeroSAP.Visible = False
        '
        'col_montoRedondeo
        '
        Me.col_montoRedondeo.HeaderText = "Monto redondeo"
        Me.col_montoRedondeo.Name = "col_montoRedondeo"
        Me.col_montoRedondeo.ReadOnly = True
        Me.col_montoRedondeo.Visible = False
        '
        'ColNumeroTarjeta
        '
        Me.ColNumeroTarjeta.HeaderText = "Numero Tarjeta"
        Me.ColNumeroTarjeta.Name = "ColNumeroTarjeta"
        Me.ColNumeroTarjeta.ReadOnly = True
        Me.ColNumeroTarjeta.Visible = False
        '
        'ColIDTerminal
        '
        Me.ColIDTerminal.HeaderText = "ID Terminal"
        Me.ColIDTerminal.Name = "ColIDTerminal"
        Me.ColIDTerminal.ReadOnly = True
        Me.ColIDTerminal.Visible = False
        '
        'ColNumeroCuotas
        '
        Me.ColNumeroCuotas.HeaderText = "Número Cuotas"
        Me.ColNumeroCuotas.Name = "ColNumeroCuotas"
        Me.ColNumeroCuotas.ReadOnly = True
        Me.ColNumeroCuotas.Visible = False
        '
        'col_correlativo
        '
        Me.col_correlativo.HeaderText = "Correlativo"
        Me.col_correlativo.Name = "col_correlativo"
        Me.col_correlativo.ReadOnly = True
        Me.col_correlativo.Visible = False
        '
        'col_CodigoRechazoOrsan
        '
        Me.col_CodigoRechazoOrsan.HeaderText = "Código Rechazo ORSAN"
        Me.col_CodigoRechazoOrsan.Name = "col_CodigoRechazoOrsan"
        Me.col_CodigoRechazoOrsan.ReadOnly = True
        '
        'Panel7
        '
        Me.Panel7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel7.BackColor = System.Drawing.Color.Transparent
        Me.Panel7.Controls.Add(Me.lbl_vuelto)
        Me.Panel7.Controls.Add(Me.Label57)
        Me.Panel7.Controls.Add(Me.lbl_total)
        Me.Panel7.Controls.Add(Me.Label48)
        Me.Panel7.Controls.Add(Me.lbl_Saldo)
        Me.Panel7.Controls.Add(Me.Label39)
        Me.Panel7.Controls.Add(Me.lbl_pago)
        Me.Panel7.Controls.Add(Me.Label37)
        Me.Panel7.Controls.Add(Me.lbl_totalDocumentos)
        Me.Panel7.Controls.Add(Me.Label49)
        Me.Panel7.Controls.Add(Me.lbl_totalPedido)
        Me.Panel7.Controls.Add(Me.Label55)
        Me.Panel7.Location = New System.Drawing.Point(5, 410)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(573, 79)
        Me.Panel7.TabIndex = 94
        '
        'lbl_vuelto
        '
        Me.lbl_vuelto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_vuelto.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_vuelto.ForeColor = System.Drawing.Color.DarkOrange
        Me.lbl_vuelto.Location = New System.Drawing.Point(129, 45)
        Me.lbl_vuelto.Name = "lbl_vuelto"
        Me.lbl_vuelto.Size = New System.Drawing.Size(96, 23)
        Me.lbl_vuelto.TabIndex = 98
        Me.lbl_vuelto.Text = "$ 0"
        Me.lbl_vuelto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label57
        '
        Me.Label57.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label57.Location = New System.Drawing.Point(6, 49)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(64, 20)
        Me.Label57.TabIndex = 97
        Me.Label57.Text = "VUELTO"
        '
        'lbl_total
        '
        Me.lbl_total.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_total.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.lbl_total.Location = New System.Drawing.Point(439, 2)
        Me.lbl_total.Name = "lbl_total"
        Me.lbl_total.Size = New System.Drawing.Size(125, 18)
        Me.lbl_total.TabIndex = 96
        Me.lbl_total.Text = "$ 0"
        Me.lbl_total.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label48.Location = New System.Drawing.Point(321, 2)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(77, 19)
        Me.Label48.TabIndex = 95
        Me.Label48.Text = "Total Final"
        '
        'lbl_Saldo
        '
        Me.lbl_Saldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Saldo.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Saldo.ForeColor = System.Drawing.Color.DarkOrange
        Me.lbl_Saldo.Location = New System.Drawing.Point(432, 48)
        Me.lbl_Saldo.Name = "lbl_Saldo"
        Me.lbl_Saldo.Size = New System.Drawing.Size(135, 23)
        Me.lbl_Saldo.TabIndex = 94
        Me.lbl_Saldo.Text = "$ 0"
        Me.lbl_Saldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label39.Location = New System.Drawing.Point(323, 49)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(58, 20)
        Me.Label39.TabIndex = 93
        Me.Label39.Text = "SALDO"
        '
        'lbl_pago
        '
        Me.lbl_pago.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_pago.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.lbl_pago.ForeColor = System.Drawing.Color.Black
        Me.lbl_pago.Location = New System.Drawing.Point(464, 23)
        Me.lbl_pago.Name = "lbl_pago"
        Me.lbl_pago.Size = New System.Drawing.Size(100, 18)
        Me.lbl_pago.TabIndex = 92
        Me.lbl_pago.Text = "$ 0"
        Me.lbl_pago.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label37
        '
        Me.Label37.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label37.Location = New System.Drawing.Point(324, 26)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(70, 18)
        Me.Label37.TabIndex = 91
        Me.Label37.Text = "Pago"
        '
        'lbl_totalDocumentos
        '
        Me.lbl_totalDocumentos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_totalDocumentos.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.lbl_totalDocumentos.Location = New System.Drawing.Point(300, 26)
        Me.lbl_totalDocumentos.Name = "lbl_totalDocumentos"
        Me.lbl_totalDocumentos.Size = New System.Drawing.Size(78, 18)
        Me.lbl_totalDocumentos.TabIndex = 47
        Me.lbl_totalDocumentos.Text = "$ 0"
        Me.lbl_totalDocumentos.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label49.Location = New System.Drawing.Point(4, 27)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(129, 19)
        Me.Label49.TabIndex = 44
        Me.Label49.Text = "Total Documentos"
        '
        'lbl_totalPedido
        '
        Me.lbl_totalPedido.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_totalPedido.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.lbl_totalPedido.Location = New System.Drawing.Point(298, 5)
        Me.lbl_totalPedido.Name = "lbl_totalPedido"
        Me.lbl_totalPedido.Size = New System.Drawing.Size(78, 18)
        Me.lbl_totalPedido.TabIndex = 42
        Me.lbl_totalPedido.Text = "$ 0"
        Me.lbl_totalPedido.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label55.Location = New System.Drawing.Point(4, 6)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(94, 19)
        Me.Label55.TabIndex = 38
        Me.Label55.Text = "Total Pedido"
        '
        'lblTituloPago
        '
        Me.lblTituloPago.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTituloPago.ForeColor = System.Drawing.Color.Black
        Me.lblTituloPago.Location = New System.Drawing.Point(25, 3)
        Me.lblTituloPago.Name = "lblTituloPago"
        Me.lblTituloPago.Size = New System.Drawing.Size(43, 18)
        Me.lblTituloPago.TabIndex = 19
        Me.lblTituloPago.Text = "Pago"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.caja2.My.Resources.Resources.Sin_título4
        Me.PictureBox5.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(16, 20)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 101
        Me.PictureBox5.TabStop = False
        '
        'Panel_NotaCredito
        '
        Me.Panel_NotaCredito.Controls.Add(Me.lblTituloNotaCredito)
        Me.Panel_NotaCredito.Controls.Add(Me.btnAgregarNotaCredito)
        Me.Panel_NotaCredito.Controls.Add(Me.DgvNotasCredito)
        Me.Panel_NotaCredito.Controls.Add(Me.cbx_notasCredito)
        Me.Panel_NotaCredito.Controls.Add(Me.Panel_CtaCAREN)
        Me.Panel_NotaCredito.Location = New System.Drawing.Point(0, 250)
        Me.Panel_NotaCredito.Name = "Panel_NotaCredito"
        Me.Panel_NotaCredito.Size = New System.Drawing.Size(815, 147)
        Me.Panel_NotaCredito.TabIndex = 107
        '
        'lblTituloNotaCredito
        '
        Me.lblTituloNotaCredito.AutoSize = True
        Me.lblTituloNotaCredito.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblTituloNotaCredito.Location = New System.Drawing.Point(7, 2)
        Me.lblTituloNotaCredito.Name = "lblTituloNotaCredito"
        Me.lblTituloNotaCredito.Size = New System.Drawing.Size(94, 13)
        Me.lblTituloNotaCredito.TabIndex = 94
        Me.lblTituloNotaCredito.Text = "Notas de Crédito"
        '
        'btnAgregarNotaCredito
        '
        Me.btnAgregarNotaCredito.BackColor = System.Drawing.Color.DarkOrange
        Me.btnAgregarNotaCredito.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregarNotaCredito.FlatAppearance.BorderSize = 0
        Me.btnAgregarNotaCredito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarNotaCredito.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarNotaCredito.ForeColor = System.Drawing.Color.White
        Me.btnAgregarNotaCredito.Location = New System.Drawing.Point(688, 29)
        Me.btnAgregarNotaCredito.Name = "btnAgregarNotaCredito"
        Me.btnAgregarNotaCredito.Size = New System.Drawing.Size(114, 34)
        Me.btnAgregarNotaCredito.TabIndex = 98
        Me.btnAgregarNotaCredito.Text = "Agregar"
        Me.btnAgregarNotaCredito.UseVisualStyleBackColor = False
        '
        'DgvNotasCredito
        '
        Me.DgvNotasCredito.AllowUserToAddRows = False
        Me.DgvNotasCredito.AllowUserToDeleteRows = False
        Me.DgvNotasCredito.AllowUserToResizeRows = False
        Me.DgvNotasCredito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvNotasCredito.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColNCTipoDoc, Me.ColNCNumeroDoc, Me.ColNCFechaEmision, Me.ColNCValor, Me.ColNCFactura, Me.ColNCNumeroSap, Me.ColNCCodEmpresa, Me.ColNCEjercicio})
        Me.DgvNotasCredito.Location = New System.Drawing.Point(4, 18)
        Me.DgvNotasCredito.MultiSelect = False
        Me.DgvNotasCredito.Name = "DgvNotasCredito"
        Me.DgvNotasCredito.Size = New System.Drawing.Size(585, 126)
        Me.DgvNotasCredito.TabIndex = 100
        '
        'ColNCTipoDoc
        '
        Me.ColNCTipoDoc.HeaderText = "Tipo Documento"
        Me.ColNCTipoDoc.Name = "ColNCTipoDoc"
        '
        'ColNCNumeroDoc
        '
        Me.ColNCNumeroDoc.HeaderText = "Número Documento"
        Me.ColNCNumeroDoc.Name = "ColNCNumeroDoc"
        '
        'ColNCFechaEmision
        '
        Me.ColNCFechaEmision.HeaderText = "Fecha Emisión"
        Me.ColNCFechaEmision.Name = "ColNCFechaEmision"
        '
        'ColNCValor
        '
        Me.ColNCValor.HeaderText = "Valor"
        Me.ColNCValor.Name = "ColNCValor"
        '
        'ColNCFactura
        '
        Me.ColNCFactura.HeaderText = "Factura Asociada"
        Me.ColNCFactura.Name = "ColNCFactura"
        '
        'ColNCNumeroSap
        '
        Me.ColNCNumeroSap.HeaderText = "Numero SAP"
        Me.ColNCNumeroSap.Name = "ColNCNumeroSap"
        '
        'ColNCCodEmpresa
        '
        Me.ColNCCodEmpresa.HeaderText = "Codigo Empresa"
        Me.ColNCCodEmpresa.Name = "ColNCCodEmpresa"
        '
        'ColNCEjercicio
        '
        Me.ColNCEjercicio.HeaderText = "Ejercicio"
        Me.ColNCEjercicio.Name = "ColNCEjercicio"
        '
        'cbx_notasCredito
        '
        Me.cbx_notasCredito.DisplayMember = "bc_nombre"
        Me.cbx_notasCredito.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.cbx_notasCredito.FormattingEnabled = True
        Me.cbx_notasCredito.Location = New System.Drawing.Point(688, 72)
        Me.cbx_notasCredito.Name = "cbx_notasCredito"
        Me.cbx_notasCredito.Size = New System.Drawing.Size(114, 28)
        Me.cbx_notasCredito.TabIndex = 95
        Me.cbx_notasCredito.ValueMember = "bc_id"
        Me.cbx_notasCredito.Visible = False
        '
        'cmbTipoDoc
        '
        Me.cmbTipoDoc.AutoCompleteCustomSource.AddRange(New String() {"(Todas)", "Liberadas", "Por Liberar"})
        Me.cmbTipoDoc.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.cmbTipoDoc.FormattingEnabled = True
        Me.cmbTipoDoc.Location = New System.Drawing.Point(70, 28)
        Me.cmbTipoDoc.Name = "cmbTipoDoc"
        Me.cmbTipoDoc.Size = New System.Drawing.Size(132, 21)
        Me.cmbTipoDoc.TabIndex = 107
        '
        'txt_FolioPagar
        '
        Me.txt_FolioPagar.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txt_FolioPagar.Location = New System.Drawing.Point(225, 28)
        Me.txt_FolioPagar.Name = "txt_FolioPagar"
        Me.txt_FolioPagar.Size = New System.Drawing.Size(104, 22)
        Me.txt_FolioPagar.TabIndex = 106
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label16.Location = New System.Drawing.Point(202, 28)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(23, 16)
        Me.Label16.TabIndex = 105
        Me.Label16.Text = "N°"
        '
        'Label36
        '
        Me.Label36.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label36.Location = New System.Drawing.Point(6, 28)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(64, 16)
        Me.Label36.TabIndex = 104
        Me.Label36.Text = "Tipo Doc."
        '
        'btnFiltrarPagos
        '
        Me.btnFiltrarPagos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFiltrarPagos.BackColor = System.Drawing.Color.SteelBlue
        Me.btnFiltrarPagos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFiltrarPagos.FlatAppearance.BorderSize = 0
        Me.btnFiltrarPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFiltrarPagos.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnFiltrarPagos.ForeColor = System.Drawing.Color.White
        Me.btnFiltrarPagos.Location = New System.Drawing.Point(329, 28)
        Me.btnFiltrarPagos.Name = "btnFiltrarPagos"
        Me.btnFiltrarPagos.Size = New System.Drawing.Size(122, 22)
        Me.btnFiltrarPagos.TabIndex = 103
        Me.btnFiltrarPagos.Text = "Filtrar"
        Me.btnFiltrarPagos.UseVisualStyleBackColor = False
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label46.ForeColor = System.Drawing.Color.Black
        Me.Label46.Location = New System.Drawing.Point(30, 6)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(166, 19)
        Me.Label46.TabIndex = 48
        Me.Label46.Text = "Documentos por pagar"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.caja2.My.Resources.Resources.Sin_título3
        Me.PictureBox4.Location = New System.Drawing.Point(5, 1)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(20, 24)
        Me.PictureBox4.TabIndex = 100
        Me.PictureBox4.TabStop = False
        '
        'Panel_marketPlace
        '
        Me.Panel_marketPlace.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Panel_marketPlace.Controls.Add(Me.Label60)
        Me.Panel_marketPlace.Controls.Add(Me.cbx_marketPlace)
        Me.Panel_marketPlace.Controls.Add(Me.btnAgregarMontoMarketPlace)
        Me.Panel_marketPlace.Controls.Add(Me.txt_montoMarketPlace)
        Me.Panel_marketPlace.Controls.Add(Me.Label59)
        Me.Panel_marketPlace.Location = New System.Drawing.Point(3, 262)
        Me.Panel_marketPlace.Name = "Panel_marketPlace"
        Me.Panel_marketPlace.Size = New System.Drawing.Size(501, 71)
        Me.Panel_marketPlace.TabIndex = 109
        '
        'Label60
        '
        Me.Label60.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label60.Location = New System.Drawing.Point(8, 10)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(106, 16)
        Me.Label60.TabIndex = 121
        Me.Label60.Text = "Market Place"
        '
        'cbx_marketPlace
        '
        Me.cbx_marketPlace.DisplayMember = "nvmp_nombre"
        Me.cbx_marketPlace.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbx_marketPlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_marketPlace.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.cbx_marketPlace.FormattingEnabled = True
        Me.cbx_marketPlace.Location = New System.Drawing.Point(9, 29)
        Me.cbx_marketPlace.Name = "cbx_marketPlace"
        Me.cbx_marketPlace.Size = New System.Drawing.Size(184, 28)
        Me.cbx_marketPlace.TabIndex = 120
        Me.cbx_marketPlace.ValueMember = "nvmp_id"
        '
        'btnAgregarMontoMarketPlace
        '
        Me.btnAgregarMontoMarketPlace.BackColor = System.Drawing.Color.DarkOrange
        Me.btnAgregarMontoMarketPlace.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregarMontoMarketPlace.FlatAppearance.BorderSize = 0
        Me.btnAgregarMontoMarketPlace.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarMontoMarketPlace.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarMontoMarketPlace.ForeColor = System.Drawing.Color.White
        Me.btnAgregarMontoMarketPlace.Location = New System.Drawing.Point(357, 19)
        Me.btnAgregarMontoMarketPlace.Name = "btnAgregarMontoMarketPlace"
        Me.btnAgregarMontoMarketPlace.Size = New System.Drawing.Size(114, 34)
        Me.btnAgregarMontoMarketPlace.TabIndex = 89
        Me.btnAgregarMontoMarketPlace.Text = "Agregar"
        Me.btnAgregarMontoMarketPlace.UseVisualStyleBackColor = False
        '
        'txt_montoMarketPlace
        '
        Me.txt_montoMarketPlace.Enabled = False
        Me.txt_montoMarketPlace.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_montoMarketPlace.Location = New System.Drawing.Point(199, 29)
        Me.txt_montoMarketPlace.MaxLength = 9
        Me.txt_montoMarketPlace.Name = "txt_montoMarketPlace"
        Me.txt_montoMarketPlace.Size = New System.Drawing.Size(152, 27)
        Me.txt_montoMarketPlace.TabIndex = 89
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label59.Location = New System.Drawing.Point(196, 10)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(42, 13)
        Me.Label59.TabIndex = 88
        Me.Label59.Text = "Monto"
        '
        'Panel_Efectivo
        '
        Me.Panel_Efectivo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Panel_Efectivo.Controls.Add(Me.lbl_efectivoRedondeado)
        Me.Panel_Efectivo.Controls.Add(Me.Label64)
        Me.Panel_Efectivo.Controls.Add(Me.lbl_redondeoEfectivo)
        Me.Panel_Efectivo.Controls.Add(Me.Label62)
        Me.Panel_Efectivo.Controls.Add(Me.txt_vueltoEfectivo)
        Me.Panel_Efectivo.Controls.Add(Me.Label42)
        Me.Panel_Efectivo.Controls.Add(Me.btnAgregarEfectivo)
        Me.Panel_Efectivo.Controls.Add(Me.txt_montoEfectivo)
        Me.Panel_Efectivo.Controls.Add(Me.Label41)
        Me.Panel_Efectivo.Location = New System.Drawing.Point(4, 262)
        Me.Panel_Efectivo.Name = "Panel_Efectivo"
        Me.Panel_Efectivo.Size = New System.Drawing.Size(585, 66)
        Me.Panel_Efectivo.TabIndex = 92
        '
        'lbl_efectivoRedondeado
        '
        Me.lbl_efectivoRedondeado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_efectivoRedondeado.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_efectivoRedondeado.Location = New System.Drawing.Point(138, 44)
        Me.lbl_efectivoRedondeado.Name = "lbl_efectivoRedondeado"
        Me.lbl_efectivoRedondeado.Size = New System.Drawing.Size(140, 18)
        Me.lbl_efectivoRedondeado.TabIndex = 114
        '
        'Label64
        '
        Me.Label64.Location = New System.Drawing.Point(137, 26)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(141, 18)
        Me.Label64.TabIndex = 113
        Me.Label64.Text = "Monto a pagar"
        '
        'lbl_redondeoEfectivo
        '
        Me.lbl_redondeoEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_redondeoEfectivo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lbl_redondeoEfectivo.Location = New System.Drawing.Point(3, 44)
        Me.lbl_redondeoEfectivo.Name = "lbl_redondeoEfectivo"
        Me.lbl_redondeoEfectivo.Size = New System.Drawing.Size(128, 18)
        Me.lbl_redondeoEfectivo.TabIndex = 112
        '
        'Label62
        '
        Me.Label62.Location = New System.Drawing.Point(3, 26)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(128, 18)
        Me.Label62.TabIndex = 111
        Me.Label62.Text = "Redondeo pesos"
        '
        'txt_vueltoEfectivo
        '
        Me.txt_vueltoEfectivo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_vueltoEfectivo.Location = New System.Drawing.Point(184, 3)
        Me.txt_vueltoEfectivo.MaxLength = 9
        Me.txt_vueltoEfectivo.Name = "txt_vueltoEfectivo"
        Me.txt_vueltoEfectivo.ReadOnly = True
        Me.txt_vueltoEfectivo.Size = New System.Drawing.Size(110, 23)
        Me.txt_vueltoEfectivo.TabIndex = 91
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label42.Location = New System.Drawing.Point(141, 6)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(41, 13)
        Me.Label42.TabIndex = 90
        Me.Label42.Text = "Vuelto"
        '
        'btnAgregarEfectivo
        '
        Me.btnAgregarEfectivo.BackColor = System.Drawing.Color.DarkOrange
        Me.btnAgregarEfectivo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregarEfectivo.FlatAppearance.BorderSize = 0
        Me.btnAgregarEfectivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarEfectivo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarEfectivo.ForeColor = System.Drawing.Color.White
        Me.btnAgregarEfectivo.Location = New System.Drawing.Point(297, 2)
        Me.btnAgregarEfectivo.Name = "btnAgregarEfectivo"
        Me.btnAgregarEfectivo.Size = New System.Drawing.Size(87, 23)
        Me.btnAgregarEfectivo.TabIndex = 89
        Me.btnAgregarEfectivo.Text = "Agregar"
        Me.btnAgregarEfectivo.UseVisualStyleBackColor = False
        '
        'txt_montoEfectivo
        '
        Me.txt_montoEfectivo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_montoEfectivo.Location = New System.Drawing.Point(48, 3)
        Me.txt_montoEfectivo.MaxLength = 9
        Me.txt_montoEfectivo.Name = "txt_montoEfectivo"
        Me.txt_montoEfectivo.Size = New System.Drawing.Size(91, 23)
        Me.txt_montoEfectivo.TabIndex = 89
        '
        'Label41
        '
        Me.Label41.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label41.Location = New System.Drawing.Point(3, 3)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(42, 16)
        Me.Label41.TabIndex = 88
        Me.Label41.Text = "Monto"
        '
        'Panel_Transferencia
        '
        Me.Panel_Transferencia.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Panel_Transferencia.Controls.Add(Me.txt_nombreArchivoComprobante)
        Me.Panel_Transferencia.Controls.Add(Me.btnAdjuntarComprobante)
        Me.Panel_Transferencia.Controls.Add(Me.btnAgregarTransferencia)
        Me.Panel_Transferencia.Controls.Add(Me.cbx_bcoTransferencia)
        Me.Panel_Transferencia.Controls.Add(Me.txt_montoTransferencia)
        Me.Panel_Transferencia.Controls.Add(Me.Label44)
        Me.Panel_Transferencia.Controls.Add(Me.Label38)
        Me.Panel_Transferencia.Controls.Add(Me.txt_numeroOperacion)
        Me.Panel_Transferencia.Controls.Add(Me.Label43)
        Me.Panel_Transferencia.Location = New System.Drawing.Point(2, 262)
        Me.Panel_Transferencia.Name = "Panel_Transferencia"
        Me.Panel_Transferencia.Size = New System.Drawing.Size(594, 94)
        Me.Panel_Transferencia.TabIndex = 93
        '
        'txt_nombreArchivoComprobante
        '
        Me.txt_nombreArchivoComprobante.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txt_nombreArchivoComprobante.Location = New System.Drawing.Point(146, 59)
        Me.txt_nombreArchivoComprobante.Name = "txt_nombreArchivoComprobante"
        Me.txt_nombreArchivoComprobante.Size = New System.Drawing.Size(430, 22)
        Me.txt_nombreArchivoComprobante.TabIndex = 95
        '
        'btnAdjuntarComprobante
        '
        Me.btnAdjuntarComprobante.BackColor = System.Drawing.Color.SteelBlue
        Me.btnAdjuntarComprobante.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdjuntarComprobante.FlatAppearance.BorderSize = 0
        Me.btnAdjuntarComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdjuntarComprobante.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnAdjuntarComprobante.ForeColor = System.Drawing.Color.White
        Me.btnAdjuntarComprobante.Location = New System.Drawing.Point(8, 52)
        Me.btnAdjuntarComprobante.Name = "btnAdjuntarComprobante"
        Me.btnAdjuntarComprobante.Size = New System.Drawing.Size(137, 32)
        Me.btnAdjuntarComprobante.TabIndex = 94
        Me.btnAdjuntarComprobante.Text = "Adjuntar Comprobante"
        Me.btnAdjuntarComprobante.UseVisualStyleBackColor = False
        '
        'btnAgregarTransferencia
        '
        Me.btnAgregarTransferencia.BackColor = System.Drawing.Color.DarkOrange
        Me.btnAgregarTransferencia.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregarTransferencia.FlatAppearance.BorderSize = 0
        Me.btnAgregarTransferencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarTransferencia.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarTransferencia.ForeColor = System.Drawing.Color.White
        Me.btnAgregarTransferencia.Location = New System.Drawing.Point(625, 18)
        Me.btnAgregarTransferencia.Name = "btnAgregarTransferencia"
        Me.btnAgregarTransferencia.Size = New System.Drawing.Size(114, 34)
        Me.btnAgregarTransferencia.TabIndex = 93
        Me.btnAgregarTransferencia.Text = "Agregar"
        Me.btnAgregarTransferencia.UseVisualStyleBackColor = False
        '
        'cbx_bcoTransferencia
        '
        Me.cbx_bcoTransferencia.DisplayMember = "bc_nombre"
        Me.cbx_bcoTransferencia.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbx_bcoTransferencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_bcoTransferencia.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.cbx_bcoTransferencia.FormattingEnabled = True
        Me.cbx_bcoTransferencia.Location = New System.Drawing.Point(267, 22)
        Me.cbx_bcoTransferencia.Name = "cbx_bcoTransferencia"
        Me.cbx_bcoTransferencia.Size = New System.Drawing.Size(309, 23)
        Me.cbx_bcoTransferencia.TabIndex = 90
        Me.cbx_bcoTransferencia.ValueMember = "bc_id"
        '
        'txt_montoTransferencia
        '
        Me.txt_montoTransferencia.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txt_montoTransferencia.Location = New System.Drawing.Point(147, 22)
        Me.txt_montoTransferencia.MaxLength = 9
        Me.txt_montoTransferencia.Name = "txt_montoTransferencia"
        Me.txt_montoTransferencia.Size = New System.Drawing.Size(121, 22)
        Me.txt_montoTransferencia.TabIndex = 92
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label44.Location = New System.Drawing.Point(143, 5)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(42, 13)
        Me.Label44.TabIndex = 91
        Me.Label44.Text = "Monto"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label38.Location = New System.Drawing.Point(264, 5)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(38, 13)
        Me.Label38.TabIndex = 89
        Me.Label38.Text = "Banco"
        '
        'txt_numeroOperacion
        '
        Me.txt_numeroOperacion.Enabled = False
        Me.txt_numeroOperacion.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txt_numeroOperacion.Location = New System.Drawing.Point(7, 22)
        Me.txt_numeroOperacion.Name = "txt_numeroOperacion"
        Me.txt_numeroOperacion.Size = New System.Drawing.Size(140, 22)
        Me.txt_numeroOperacion.TabIndex = 89
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label43.Location = New System.Drawing.Point(5, 5)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(76, 13)
        Me.Label43.TabIndex = 88
        Me.Label43.Text = "N° Operación"
        '
        'Panel_Cheque
        '
        Me.Panel_Cheque.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Panel_Cheque.Controls.Add(Me.lbl_codigoRechazoOrsan)
        Me.Panel_Cheque.Controls.Add(Me.NudFecVencimientoCheque)
        Me.Panel_Cheque.Controls.Add(Me.lblCantidadCheques)
        Me.Panel_Cheque.Controls.Add(Me.Label58)
        Me.Panel_Cheque.Controls.Add(Me.Label54)
        Me.Panel_Cheque.Controls.Add(Me.cbx_tipoVencimientoCheque)
        Me.Panel_Cheque.Controls.Add(Me.Label56)
        Me.Panel_Cheque.Controls.Add(Me.btnChequeSiguiente)
        Me.Panel_Cheque.Controls.Add(Me.btnChequeAnterior)
        Me.Panel_Cheque.Controls.Add(Me.lblPosicionCheque)
        Me.Panel_Cheque.Controls.Add(Me.btnValidarCheque)
        Me.Panel_Cheque.Controls.Add(Me.txt_montoTotalCheques)
        Me.Panel_Cheque.Controls.Add(Me.btnEscanearCheque)
        Me.Panel_Cheque.Controls.Add(Me.Label50)
        Me.Panel_Cheque.Controls.Add(Me.cbx_plazaBanco)
        Me.Panel_Cheque.Controls.Add(Me.txt_rutGirador)
        Me.Panel_Cheque.Controls.Add(Me.Label12)
        Me.Panel_Cheque.Controls.Add(Me.lbl_codigoAutorizacion)
        Me.Panel_Cheque.Controls.Add(Me.txt_codigoAutorizacion)
        Me.Panel_Cheque.Controls.Add(Me.Imagen_Validacion_Cheque)
        Me.Panel_Cheque.Controls.Add(Me.btnAgregarCheque)
        Me.Panel_Cheque.Controls.Add(Me.txt_montoCheque)
        Me.Panel_Cheque.Controls.Add(Me.Label40)
        Me.Panel_Cheque.Controls.Add(Me.Label28)
        Me.Panel_Cheque.Controls.Add(Me.DtpFechaVencCheque)
        Me.Panel_Cheque.Controls.Add(Me.btnImprimirCheque)
        Me.Panel_Cheque.Controls.Add(Me.txt_nroCheque)
        Me.Panel_Cheque.Controls.Add(Me.Label27)
        Me.Panel_Cheque.Controls.Add(Me.cbx_banco)
        Me.Panel_Cheque.Controls.Add(Me.Label3)
        Me.Panel_Cheque.Controls.Add(Me.txt_numeroCuenta)
        Me.Panel_Cheque.Controls.Add(Me.Label20)
        Me.Panel_Cheque.Location = New System.Drawing.Point(2, 262)
        Me.Panel_Cheque.Name = "Panel_Cheque"
        Me.Panel_Cheque.Size = New System.Drawing.Size(588, 142)
        Me.Panel_Cheque.TabIndex = 77
        Me.Panel_Cheque.Visible = False
        '
        'lbl_codigoRechazoOrsan
        '
        Me.lbl_codigoRechazoOrsan.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lbl_codigoRechazoOrsan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_codigoRechazoOrsan.Location = New System.Drawing.Point(672, 93)
        Me.lbl_codigoRechazoOrsan.Name = "lbl_codigoRechazoOrsan"
        Me.lbl_codigoRechazoOrsan.Size = New System.Drawing.Size(126, 12)
        Me.lbl_codigoRechazoOrsan.TabIndex = 123
        Me.lbl_codigoRechazoOrsan.Visible = False
        '
        'NudFecVencimientoCheque
        '
        Me.NudFecVencimientoCheque.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudFecVencimientoCheque.Location = New System.Drawing.Point(443, 117)
        Me.NudFecVencimientoCheque.Name = "NudFecVencimientoCheque"
        Me.NudFecVencimientoCheque.Size = New System.Drawing.Size(18, 25)
        Me.NudFecVencimientoCheque.TabIndex = 122
        Me.NudFecVencimientoCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblCantidadCheques
        '
        Me.lblCantidadCheques.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadCheques.Location = New System.Drawing.Point(387, 24)
        Me.lblCantidadCheques.Margin = New System.Windows.Forms.Padding(1, 0, 3, 0)
        Me.lblCantidadCheques.Name = "lblCantidadCheques"
        Me.lblCantidadCheques.Size = New System.Drawing.Size(17, 28)
        Me.lblCantidadCheques.TabIndex = 121
        Me.lblCantidadCheques.Text = "1"
        Me.lblCantidadCheques.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label58
        '
        Me.Label58.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.Location = New System.Drawing.Point(375, 24)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(12, 28)
        Me.Label58.TabIndex = 120
        Me.Label58.Text = "/"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label54
        '
        Me.Label54.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label54.Location = New System.Drawing.Point(7, 6)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(87, 16)
        Me.Label54.TabIndex = 110
        Me.Label54.Text = "Monto Total"
        '
        'cbx_tipoVencimientoCheque
        '
        Me.cbx_tipoVencimientoCheque.DisplayMember = "bc_nombre"
        Me.cbx_tipoVencimientoCheque.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbx_tipoVencimientoCheque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_tipoVencimientoCheque.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbx_tipoVencimientoCheque.FormattingEnabled = True
        Me.cbx_tipoVencimientoCheque.Location = New System.Drawing.Point(100, 24)
        Me.cbx_tipoVencimientoCheque.Name = "cbx_tipoVencimientoCheque"
        Me.cbx_tipoVencimientoCheque.Size = New System.Drawing.Size(191, 24)
        Me.cbx_tipoVencimientoCheque.TabIndex = 119
        Me.cbx_tipoVencimientoCheque.ValueMember = "bc_id"
        '
        'Label56
        '
        Me.Label56.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label56.Location = New System.Drawing.Point(97, 6)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(126, 19)
        Me.Label56.TabIndex = 118
        Me.Label56.Text = "Tipo Vencimiento"
        '
        'btnChequeSiguiente
        '
        Me.btnChequeSiguiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnChequeSiguiente.BackColor = System.Drawing.Color.SteelBlue
        Me.btnChequeSiguiente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnChequeSiguiente.FlatAppearance.BorderSize = 0
        Me.btnChequeSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChequeSiguiente.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChequeSiguiente.ForeColor = System.Drawing.Color.White
        Me.btnChequeSiguiente.Location = New System.Drawing.Point(404, 18)
        Me.btnChequeSiguiente.Name = "btnChequeSiguiente"
        Me.btnChequeSiguiente.Size = New System.Drawing.Size(46, 32)
        Me.btnChequeSiguiente.TabIndex = 117
        Me.btnChequeSiguiente.Text = ">"
        Me.btnChequeSiguiente.UseVisualStyleBackColor = False
        '
        'btnChequeAnterior
        '
        Me.btnChequeAnterior.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnChequeAnterior.BackColor = System.Drawing.Color.SteelBlue
        Me.btnChequeAnterior.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnChequeAnterior.FlatAppearance.BorderSize = 0
        Me.btnChequeAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChequeAnterior.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChequeAnterior.ForeColor = System.Drawing.Color.White
        Me.btnChequeAnterior.Location = New System.Drawing.Point(306, 18)
        Me.btnChequeAnterior.Name = "btnChequeAnterior"
        Me.btnChequeAnterior.Size = New System.Drawing.Size(46, 32)
        Me.btnChequeAnterior.TabIndex = 116
        Me.btnChequeAnterior.Text = "<"
        Me.btnChequeAnterior.UseVisualStyleBackColor = False
        '
        'lblPosicionCheque
        '
        Me.lblPosicionCheque.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPosicionCheque.Location = New System.Drawing.Point(357, 24)
        Me.lblPosicionCheque.Margin = New System.Windows.Forms.Padding(3, 0, 1, 0)
        Me.lblPosicionCheque.Name = "lblPosicionCheque"
        Me.lblPosicionCheque.Size = New System.Drawing.Size(17, 28)
        Me.lblPosicionCheque.TabIndex = 115
        Me.lblPosicionCheque.Text = "1"
        Me.lblPosicionCheque.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnValidarCheque
        '
        Me.btnValidarCheque.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnValidarCheque.BackColor = System.Drawing.Color.SteelBlue
        Me.btnValidarCheque.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnValidarCheque.FlatAppearance.BorderSize = 0
        Me.btnValidarCheque.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnValidarCheque.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnValidarCheque.ForeColor = System.Drawing.Color.White
        Me.btnValidarCheque.Location = New System.Drawing.Point(469, 60)
        Me.btnValidarCheque.Name = "btnValidarCheque"
        Me.btnValidarCheque.Size = New System.Drawing.Size(111, 32)
        Me.btnValidarCheque.TabIndex = 78
        Me.btnValidarCheque.Text = "Validar >"
        Me.btnValidarCheque.UseVisualStyleBackColor = False
        Me.btnValidarCheque.Visible = False
        '
        'txt_montoTotalCheques
        '
        Me.txt_montoTotalCheques.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_montoTotalCheques.Location = New System.Drawing.Point(9, 23)
        Me.txt_montoTotalCheques.MaxLength = 9
        Me.txt_montoTotalCheques.Name = "txt_montoTotalCheques"
        Me.txt_montoTotalCheques.Size = New System.Drawing.Size(85, 23)
        Me.txt_montoTotalCheques.TabIndex = 111
        '
        'btnEscanearCheque
        '
        Me.btnEscanearCheque.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEscanearCheque.BackColor = System.Drawing.Color.SteelBlue
        Me.btnEscanearCheque.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEscanearCheque.FlatAppearance.BorderSize = 0
        Me.btnEscanearCheque.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEscanearCheque.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnEscanearCheque.ForeColor = System.Drawing.Color.White
        Me.btnEscanearCheque.Location = New System.Drawing.Point(469, 19)
        Me.btnEscanearCheque.Name = "btnEscanearCheque"
        Me.btnEscanearCheque.Size = New System.Drawing.Size(111, 32)
        Me.btnEscanearCheque.TabIndex = 109
        Me.btnEscanearCheque.Text = "Escanear >"
        Me.btnEscanearCheque.UseVisualStyleBackColor = False
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label50.Location = New System.Drawing.Point(669, 3)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(67, 13)
        Me.Label50.TabIndex = 108
        Me.Label50.Text = "Plaza Banco"
        Me.Label50.Visible = False
        '
        'cbx_plazaBanco
        '
        Me.cbx_plazaBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_plazaBanco.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.cbx_plazaBanco.FormattingEnabled = True
        Me.cbx_plazaBanco.Location = New System.Drawing.Point(670, 19)
        Me.cbx_plazaBanco.Name = "cbx_plazaBanco"
        Me.cbx_plazaBanco.Size = New System.Drawing.Size(128, 28)
        Me.cbx_plazaBanco.TabIndex = 107
        Me.cbx_plazaBanco.Visible = False
        '
        'txt_rutGirador
        '
        Me.txt_rutGirador.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_rutGirador.Location = New System.Drawing.Point(10, 68)
        Me.txt_rutGirador.MaxLength = 12
        Me.txt_rutGirador.Name = "txt_rutGirador"
        Me.txt_rutGirador.Size = New System.Drawing.Size(84, 23)
        Me.txt_rutGirador.TabIndex = 106
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.Location = New System.Drawing.Point(7, 53)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 15)
        Me.Label12.TabIndex = 105
        Me.Label12.Text = "RUT Girador"
        '
        'lbl_codigoAutorizacion
        '
        Me.lbl_codigoAutorizacion.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lbl_codigoAutorizacion.Location = New System.Drawing.Point(670, 50)
        Me.lbl_codigoAutorizacion.Name = "lbl_codigoAutorizacion"
        Me.lbl_codigoAutorizacion.Size = New System.Drawing.Size(129, 16)
        Me.lbl_codigoAutorizacion.TabIndex = 104
        Me.lbl_codigoAutorizacion.Text = "Código Autorización"
        Me.lbl_codigoAutorizacion.Visible = False
        '
        'txt_codigoAutorizacion
        '
        Me.txt_codigoAutorizacion.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.txt_codigoAutorizacion.Location = New System.Drawing.Point(672, 66)
        Me.txt_codigoAutorizacion.Name = "txt_codigoAutorizacion"
        Me.txt_codigoAutorizacion.Size = New System.Drawing.Size(128, 27)
        Me.txt_codigoAutorizacion.TabIndex = 103
        Me.txt_codigoAutorizacion.Visible = False
        '
        'Imagen_Validacion_Cheque
        '
        Me.Imagen_Validacion_Cheque.Location = New System.Drawing.Point(644, 66)
        Me.Imagen_Validacion_Cheque.Name = "Imagen_Validacion_Cheque"
        Me.Imagen_Validacion_Cheque.Size = New System.Drawing.Size(27, 26)
        Me.Imagen_Validacion_Cheque.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Imagen_Validacion_Cheque.TabIndex = 102
        Me.Imagen_Validacion_Cheque.TabStop = False
        Me.Imagen_Validacion_Cheque.Visible = False
        '
        'btnAgregarCheque
        '
        Me.btnAgregarCheque.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAgregarCheque.BackColor = System.Drawing.Color.DarkOrange
        Me.btnAgregarCheque.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregarCheque.FlatAppearance.BorderSize = 0
        Me.btnAgregarCheque.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarCheque.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarCheque.ForeColor = System.Drawing.Color.White
        Me.btnAgregarCheque.Location = New System.Drawing.Point(672, 102)
        Me.btnAgregarCheque.Name = "btnAgregarCheque"
        Me.btnAgregarCheque.Size = New System.Drawing.Size(127, 34)
        Me.btnAgregarCheque.TabIndex = 88
        Me.btnAgregarCheque.Text = "Agregar"
        Me.btnAgregarCheque.UseVisualStyleBackColor = False
        '
        'txt_montoCheque
        '
        Me.txt_montoCheque.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_montoCheque.Location = New System.Drawing.Point(99, 69)
        Me.txt_montoCheque.MaxLength = 9
        Me.txt_montoCheque.Name = "txt_montoCheque"
        Me.txt_montoCheque.Size = New System.Drawing.Size(191, 23)
        Me.txt_montoCheque.TabIndex = 87
        '
        'Label40
        '
        Me.Label40.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label40.Location = New System.Drawing.Point(97, 53)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(98, 18)
        Me.Label40.TabIndex = 86
        Me.Label40.Text = "Monto Cheque"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label28.Location = New System.Drawing.Point(293, 98)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(73, 15)
        Me.Label28.TabIndex = 84
        Me.Label28.Text = "Vencimiento"
        '
        'DtpFechaVencCheque
        '
        Me.DtpFechaVencCheque.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DtpFechaVencCheque.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFechaVencCheque.Location = New System.Drawing.Point(296, 116)
        Me.DtpFechaVencCheque.Name = "DtpFechaVencCheque"
        Me.DtpFechaVencCheque.Size = New System.Drawing.Size(141, 23)
        Me.DtpFechaVencCheque.TabIndex = 83
        '
        'btnImprimirCheque
        '
        Me.btnImprimirCheque.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImprimirCheque.BackColor = System.Drawing.Color.SteelBlue
        Me.btnImprimirCheque.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimirCheque.FlatAppearance.BorderSize = 0
        Me.btnImprimirCheque.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimirCheque.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnImprimirCheque.ForeColor = System.Drawing.Color.White
        Me.btnImprimirCheque.Location = New System.Drawing.Point(469, 108)
        Me.btnImprimirCheque.Name = "btnImprimirCheque"
        Me.btnImprimirCheque.Size = New System.Drawing.Size(111, 31)
        Me.btnImprimirCheque.TabIndex = 82
        Me.btnImprimirCheque.Text = "Imprimir"
        Me.btnImprimirCheque.UseVisualStyleBackColor = False
        '
        'txt_nroCheque
        '
        Me.txt_nroCheque.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_nroCheque.Location = New System.Drawing.Point(100, 116)
        Me.txt_nroCheque.Name = "txt_nroCheque"
        Me.txt_nroCheque.Size = New System.Drawing.Size(191, 23)
        Me.txt_nroCheque.TabIndex = 81
        Me.txt_nroCheque.Text = "1234567890"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label27.Location = New System.Drawing.Point(97, 97)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(65, 15)
        Me.Label27.TabIndex = 80
        Me.Label27.Text = "N° Cheque"
        '
        'cbx_banco
        '
        Me.cbx_banco.DisplayMember = "bc_nombre"
        Me.cbx_banco.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbx_banco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_banco.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cbx_banco.FormattingEnabled = True
        Me.cbx_banco.Location = New System.Drawing.Point(296, 68)
        Me.cbx_banco.Name = "cbx_banco"
        Me.cbx_banco.Size = New System.Drawing.Size(154, 24)
        Me.cbx_banco.TabIndex = 79
        Me.cbx_banco.ValueMember = "bc_id"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(293, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 15)
        Me.Label3.TabIndex = 78
        Me.Label3.Text = "Banco"
        '
        'txt_numeroCuenta
        '
        Me.txt_numeroCuenta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_numeroCuenta.Location = New System.Drawing.Point(10, 114)
        Me.txt_numeroCuenta.Name = "txt_numeroCuenta"
        Me.txt_numeroCuenta.Size = New System.Drawing.Size(84, 23)
        Me.txt_numeroCuenta.TabIndex = 77
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label20.Location = New System.Drawing.Point(7, 96)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(62, 15)
        Me.Label20.TabIndex = 76
        Me.Label20.Text = "N° Cuenta"
        '
        'Panel_Tarjeta
        '
        Me.Panel_Tarjeta.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Panel_Tarjeta.Controls.Add(Me.txt_NumeroCuotas)
        Me.Panel_Tarjeta.Controls.Add(Me.lblNumeroCuotas)
        Me.Panel_Tarjeta.Controls.Add(Me.txt_NumeroTarjeta)
        Me.Panel_Tarjeta.Controls.Add(Me.lblTituloNumeroTarjeta)
        Me.Panel_Tarjeta.Controls.Add(Me.cmbTipoTarjetaCredito)
        Me.Panel_Tarjeta.Controls.Add(Me.lblTipoTarjeta)
        Me.Panel_Tarjeta.Controls.Add(Me.txt_AutorizacionTarjeta)
        Me.Panel_Tarjeta.Controls.Add(Me.lblAutorizacionTarjeta)
        Me.Panel_Tarjeta.Controls.Add(Me.rdbPagoManual)
        Me.Panel_Tarjeta.Controls.Add(Me.rdbPagoSerial)
        Me.Panel_Tarjeta.Controls.Add(Me.Label_OK_Tarjeta)
        Me.Panel_Tarjeta.Controls.Add(Me.txt_montoTarjeta)
        Me.Panel_Tarjeta.Controls.Add(Me.Label34)
        Me.Panel_Tarjeta.Controls.Add(Me.btnPagarTarjeta)
        Me.Panel_Tarjeta.Location = New System.Drawing.Point(1, 293)
        Me.Panel_Tarjeta.Name = "Panel_Tarjeta"
        Me.Panel_Tarjeta.Size = New System.Drawing.Size(581, 98)
        Me.Panel_Tarjeta.TabIndex = 83
        '
        'txt_NumeroCuotas
        '
        Me.txt_NumeroCuotas.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_NumeroCuotas.Location = New System.Drawing.Point(139, 70)
        Me.txt_NumeroCuotas.MaxLength = 9
        Me.txt_NumeroCuotas.Name = "txt_NumeroCuotas"
        Me.txt_NumeroCuotas.Size = New System.Drawing.Size(167, 23)
        Me.txt_NumeroCuotas.TabIndex = 111
        '
        'lblNumeroCuotas
        '
        Me.lblNumeroCuotas.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblNumeroCuotas.Location = New System.Drawing.Point(139, 54)
        Me.lblNumeroCuotas.Name = "lblNumeroCuotas"
        Me.lblNumeroCuotas.Size = New System.Drawing.Size(100, 16)
        Me.lblNumeroCuotas.TabIndex = 110
        Me.lblNumeroCuotas.Text = "Número Cuotas"
        '
        'txt_NumeroTarjeta
        '
        Me.txt_NumeroTarjeta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_NumeroTarjeta.Location = New System.Drawing.Point(6, 70)
        Me.txt_NumeroTarjeta.MaxLength = 9
        Me.txt_NumeroTarjeta.Name = "txt_NumeroTarjeta"
        Me.txt_NumeroTarjeta.Size = New System.Drawing.Size(131, 23)
        Me.txt_NumeroTarjeta.TabIndex = 109
        '
        'lblTituloNumeroTarjeta
        '
        Me.lblTituloNumeroTarjeta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTituloNumeroTarjeta.Location = New System.Drawing.Point(6, 53)
        Me.lblTituloNumeroTarjeta.Name = "lblTituloNumeroTarjeta"
        Me.lblTituloNumeroTarjeta.Size = New System.Drawing.Size(99, 16)
        Me.lblTituloNumeroTarjeta.TabIndex = 108
        Me.lblTituloNumeroTarjeta.Text = "Número Tarjeta"
        '
        'cmbTipoTarjetaCredito
        '
        Me.cmbTipoTarjetaCredito.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTipoTarjetaCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoTarjetaCredito.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbTipoTarjetaCredito.FormattingEnabled = True
        Me.cmbTipoTarjetaCredito.Location = New System.Drawing.Point(248, 25)
        Me.cmbTipoTarjetaCredito.Name = "cmbTipoTarjetaCredito"
        Me.cmbTipoTarjetaCredito.Size = New System.Drawing.Size(167, 24)
        Me.cmbTipoTarjetaCredito.TabIndex = 107
        '
        'lblTipoTarjeta
        '
        Me.lblTipoTarjeta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTipoTarjeta.Location = New System.Drawing.Point(183, 33)
        Me.lblTipoTarjeta.Name = "lblTipoTarjeta"
        Me.lblTipoTarjeta.Size = New System.Drawing.Size(77, 16)
        Me.lblTipoTarjeta.TabIndex = 106
        Me.lblTipoTarjeta.Text = "Tipo Tarjeta"
        '
        'txt_AutorizacionTarjeta
        '
        Me.txt_AutorizacionTarjeta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_AutorizacionTarjeta.Location = New System.Drawing.Point(416, 70)
        Me.txt_AutorizacionTarjeta.MaxLength = 9
        Me.txt_AutorizacionTarjeta.Name = "txt_AutorizacionTarjeta"
        Me.txt_AutorizacionTarjeta.Size = New System.Drawing.Size(131, 23)
        Me.txt_AutorizacionTarjeta.TabIndex = 105
        '
        'lblAutorizacionTarjeta
        '
        Me.lblAutorizacionTarjeta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblAutorizacionTarjeta.Location = New System.Drawing.Point(417, 50)
        Me.lblAutorizacionTarjeta.Name = "lblAutorizacionTarjeta"
        Me.lblAutorizacionTarjeta.Size = New System.Drawing.Size(123, 16)
        Me.lblAutorizacionTarjeta.TabIndex = 104
        Me.lblAutorizacionTarjeta.Text = "Autorización Tarjeta"
        '
        'rdbPagoManual
        '
        Me.rdbPagoManual.AutoSize = True
        Me.rdbPagoManual.Checked = True
        Me.rdbPagoManual.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbPagoManual.Location = New System.Drawing.Point(119, 2)
        Me.rdbPagoManual.Name = "rdbPagoManual"
        Me.rdbPagoManual.Size = New System.Drawing.Size(95, 19)
        Me.rdbPagoManual.TabIndex = 103
        Me.rdbPagoManual.TabStop = True
        Me.rdbPagoManual.Text = "Pago Manual"
        Me.rdbPagoManual.UseVisualStyleBackColor = True
        '
        'rdbPagoSerial
        '
        Me.rdbPagoSerial.AutoSize = True
        Me.rdbPagoSerial.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdbPagoSerial.Location = New System.Drawing.Point(8, 2)
        Me.rdbPagoSerial.Name = "rdbPagoSerial"
        Me.rdbPagoSerial.Size = New System.Drawing.Size(83, 19)
        Me.rdbPagoSerial.TabIndex = 102
        Me.rdbPagoSerial.Text = "Pago Serial"
        Me.rdbPagoSerial.UseVisualStyleBackColor = True
        '
        'Label_OK_Tarjeta
        '
        Me.Label_OK_Tarjeta.Image = Global.caja2.My.Resources.Resources.Check
        Me.Label_OK_Tarjeta.Location = New System.Drawing.Point(509, 23)
        Me.Label_OK_Tarjeta.Name = "Label_OK_Tarjeta"
        Me.Label_OK_Tarjeta.Size = New System.Drawing.Size(27, 26)
        Me.Label_OK_Tarjeta.TabIndex = 101
        Me.Label_OK_Tarjeta.TabStop = False
        Me.Label_OK_Tarjeta.Visible = False
        '
        'txt_montoTarjeta
        '
        Me.txt_montoTarjeta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_montoTarjeta.Location = New System.Drawing.Point(48, 27)
        Me.txt_montoTarjeta.MaxLength = 9
        Me.txt_montoTarjeta.Name = "txt_montoTarjeta"
        Me.txt_montoTarjeta.Size = New System.Drawing.Size(131, 23)
        Me.txt_montoTarjeta.TabIndex = 89
        '
        'Label34
        '
        Me.Label34.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label34.Location = New System.Drawing.Point(6, 29)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(47, 16)
        Me.Label34.TabIndex = 88
        Me.Label34.Text = "Monto"
        '
        'btnPagarTarjeta
        '
        Me.btnPagarTarjeta.BackColor = System.Drawing.Color.SteelBlue
        Me.btnPagarTarjeta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPagarTarjeta.FlatAppearance.BorderSize = 0
        Me.btnPagarTarjeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPagarTarjeta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnPagarTarjeta.ForeColor = System.Drawing.Color.White
        Me.btnPagarTarjeta.Location = New System.Drawing.Point(417, 17)
        Me.btnPagarTarjeta.Name = "btnPagarTarjeta"
        Me.btnPagarTarjeta.Size = New System.Drawing.Size(86, 32)
        Me.btnPagarTarjeta.TabIndex = 78
        Me.btnPagarTarjeta.Text = "Pagar >"
        Me.btnPagarTarjeta.UseVisualStyleBackColor = False
        '
        'panel_LineaFuncionario
        '
        Me.panel_LineaFuncionario.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.panel_LineaFuncionario.Controls.Add(Me.btnAgregarMontoFuncionario)
        Me.panel_LineaFuncionario.Controls.Add(Me.Label30)
        Me.panel_LineaFuncionario.Controls.Add(Me.txt_montoLineaFuncionario)
        Me.panel_LineaFuncionario.Location = New System.Drawing.Point(5, 262)
        Me.panel_LineaFuncionario.Name = "panel_LineaFuncionario"
        Me.panel_LineaFuncionario.Size = New System.Drawing.Size(349, 71)
        Me.panel_LineaFuncionario.TabIndex = 110
        '
        'btnAgregarMontoFuncionario
        '
        Me.btnAgregarMontoFuncionario.BackColor = System.Drawing.Color.DarkOrange
        Me.btnAgregarMontoFuncionario.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregarMontoFuncionario.FlatAppearance.BorderSize = 0
        Me.btnAgregarMontoFuncionario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarMontoFuncionario.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarMontoFuncionario.ForeColor = System.Drawing.Color.White
        Me.btnAgregarMontoFuncionario.Location = New System.Drawing.Point(211, 18)
        Me.btnAgregarMontoFuncionario.Name = "btnAgregarMontoFuncionario"
        Me.btnAgregarMontoFuncionario.Size = New System.Drawing.Size(114, 34)
        Me.btnAgregarMontoFuncionario.TabIndex = 89
        Me.btnAgregarMontoFuncionario.Text = "Agregar"
        Me.btnAgregarMontoFuncionario.UseVisualStyleBackColor = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label30.Location = New System.Drawing.Point(6, 10)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(42, 13)
        Me.Label30.TabIndex = 88
        Me.Label30.Text = "Monto"
        '
        'txt_montoLineaFuncionario
        '
        Me.txt_montoLineaFuncionario.Enabled = False
        Me.txt_montoLineaFuncionario.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_montoLineaFuncionario.Location = New System.Drawing.Point(8, 27)
        Me.txt_montoLineaFuncionario.MaxLength = 9
        Me.txt_montoLineaFuncionario.Name = "txt_montoLineaFuncionario"
        Me.txt_montoLineaFuncionario.Size = New System.Drawing.Size(186, 27)
        Me.txt_montoLineaFuncionario.TabIndex = 89
        '
        'Panel_Anticipos
        '
        Me.Panel_Anticipos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel_Anticipos.Controls.Add(Me.DgvAnticipos)
        Me.Panel_Anticipos.Controls.Add(Me.btnAgregarAnticipo)
        Me.Panel_Anticipos.Controls.Add(Me.cbx_abonos)
        Me.Panel_Anticipos.Controls.Add(Me.Anticipos)
        Me.Panel_Anticipos.Location = New System.Drawing.Point(4, 249)
        Me.Panel_Anticipos.Name = "Panel_Anticipos"
        Me.Panel_Anticipos.Size = New System.Drawing.Size(586, 164)
        Me.Panel_Anticipos.TabIndex = 109
        '
        'DgvAnticipos
        '
        Me.DgvAnticipos.AllowUserToAddRows = False
        Me.DgvAnticipos.AllowUserToDeleteRows = False
        Me.DgvAnticipos.AllowUserToResizeRows = False
        Me.DgvAnticipos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DgvAnticipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvAnticipos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColAntTipoDoc, Me.ColAntNumeroDoc, Me.ColAntFechaEmision, Me.ColAntValor, Me.ColAntFacturaAsoc, Me.ColAntNumeroSAP, Me.ColAntCodEmpresa, Me.ColAntEjercicio})
        Me.DgvAnticipos.Location = New System.Drawing.Point(4, 22)
        Me.DgvAnticipos.MultiSelect = False
        Me.DgvAnticipos.Name = "DgvAnticipos"
        Me.DgvAnticipos.Size = New System.Drawing.Size(582, 126)
        Me.DgvAnticipos.TabIndex = 109
        '
        'ColAntTipoDoc
        '
        Me.ColAntTipoDoc.HeaderText = "Tipo Documento"
        Me.ColAntTipoDoc.Name = "ColAntTipoDoc"
        '
        'ColAntNumeroDoc
        '
        Me.ColAntNumeroDoc.HeaderText = "Número Documento"
        Me.ColAntNumeroDoc.Name = "ColAntNumeroDoc"
        '
        'ColAntFechaEmision
        '
        Me.ColAntFechaEmision.HeaderText = "Fecha Emisión"
        Me.ColAntFechaEmision.Name = "ColAntFechaEmision"
        '
        'ColAntValor
        '
        Me.ColAntValor.HeaderText = "Valor"
        Me.ColAntValor.Name = "ColAntValor"
        '
        'ColAntFacturaAsoc
        '
        Me.ColAntFacturaAsoc.HeaderText = "Factura Asociada"
        Me.ColAntFacturaAsoc.Name = "ColAntFacturaAsoc"
        '
        'ColAntNumeroSAP
        '
        Me.ColAntNumeroSAP.HeaderText = "Numero SAP"
        Me.ColAntNumeroSAP.Name = "ColAntNumeroSAP"
        '
        'ColAntCodEmpresa
        '
        Me.ColAntCodEmpresa.HeaderText = "Codigo Empresa"
        Me.ColAntCodEmpresa.Name = "ColAntCodEmpresa"
        '
        'ColAntEjercicio
        '
        Me.ColAntEjercicio.HeaderText = "Ejercicio"
        Me.ColAntEjercicio.Name = "ColAntEjercicio"
        '
        'btnAgregarAnticipo
        '
        Me.btnAgregarAnticipo.BackColor = System.Drawing.Color.DarkOrange
        Me.btnAgregarAnticipo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregarAnticipo.FlatAppearance.BorderSize = 0
        Me.btnAgregarAnticipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarAnticipo.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarAnticipo.ForeColor = System.Drawing.Color.White
        Me.btnAgregarAnticipo.Location = New System.Drawing.Point(689, 25)
        Me.btnAgregarAnticipo.Name = "btnAgregarAnticipo"
        Me.btnAgregarAnticipo.Size = New System.Drawing.Size(114, 34)
        Me.btnAgregarAnticipo.TabIndex = 98
        Me.btnAgregarAnticipo.Text = "Agregar"
        Me.btnAgregarAnticipo.UseVisualStyleBackColor = False
        '
        'cbx_abonos
        '
        Me.cbx_abonos.DisplayMember = "bc_nombre"
        Me.cbx_abonos.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.cbx_abonos.FormattingEnabled = True
        Me.cbx_abonos.Location = New System.Drawing.Point(689, 60)
        Me.cbx_abonos.Name = "cbx_abonos"
        Me.cbx_abonos.Size = New System.Drawing.Size(114, 28)
        Me.cbx_abonos.TabIndex = 95
        Me.cbx_abonos.ValueMember = "bc_id"
        Me.cbx_abonos.Visible = False
        '
        'Anticipos
        '
        Me.Anticipos.AutoSize = True
        Me.Anticipos.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Anticipos.Location = New System.Drawing.Point(3, 2)
        Me.Anticipos.Name = "Anticipos"
        Me.Anticipos.Size = New System.Drawing.Size(55, 13)
        Me.Anticipos.TabIndex = 94
        Me.Anticipos.Text = "Anticipos"
        '
        'Panel_CtaCAREN
        '
        Me.Panel_CtaCAREN.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Panel_CtaCAREN.Controls.Add(Me.btnAgregarMontoCuenta)
        Me.Panel_CtaCAREN.Controls.Add(Me.txt_montoLineaCredito)
        Me.Panel_CtaCAREN.Controls.Add(Me.Label35)
        Me.Panel_CtaCAREN.Location = New System.Drawing.Point(2, 10)
        Me.Panel_CtaCAREN.Name = "Panel_CtaCAREN"
        Me.Panel_CtaCAREN.Size = New System.Drawing.Size(349, 71)
        Me.Panel_CtaCAREN.TabIndex = 91
        '
        'DgvDocPorPagar
        '
        Me.DgvDocPorPagar.AllowUserToAddRows = False
        Me.DgvDocPorPagar.AllowUserToDeleteRows = False
        Me.DgvDocPorPagar.AllowUserToResizeColumns = False
        Me.DgvDocPorPagar.AllowUserToResizeRows = False
        Me.DgvDocPorPagar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvDocPorPagar.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle21.NullValue = Nothing
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvDocPorPagar.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.DgvDocPorPagar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDocPorPagar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Sel, Me.TipoDoc, Me.Folio, Me.Fecha, Me.FechaVto, Me.Monto, Me.Morosidad, Me.Bloqueado, Me.CME, Me.Numero_SAP, Me.Numero_NotaVenta, Me.Nombre_Banco, Me.Cod_Autorizacion, Me.Imprimir, Me.Correo})
        Me.DgvDocPorPagar.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgvDocPorPagar.Location = New System.Drawing.Point(4, 51)
        Me.DgvDocPorPagar.Name = "DgvDocPorPagar"
        DataGridViewCellStyle28.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DgvDocPorPagar.RowsDefaultCellStyle = DataGridViewCellStyle28
        Me.DgvDocPorPagar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvDocPorPagar.ShowEditingIcon = False
        Me.DgvDocPorPagar.Size = New System.Drawing.Size(579, 117)
        Me.DgvDocPorPagar.TabIndex = 47
        '
        'Sel
        '
        Me.Sel.DataPropertyName = "Sel"
        Me.Sel.HeaderText = "Sel"
        Me.Sel.Name = "Sel"
        Me.Sel.Width = 40
        '
        'TipoDoc
        '
        Me.TipoDoc.DataPropertyName = "TipoDoc"
        Me.TipoDoc.HeaderText = "Tipo Doc."
        Me.TipoDoc.Name = "TipoDoc"
        Me.TipoDoc.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TipoDoc.Width = 180
        '
        'Folio
        '
        Me.Folio.DataPropertyName = "Folio"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Folio.DefaultCellStyle = DataGridViewCellStyle22
        Me.Folio.HeaderText = "Folio"
        Me.Folio.Name = "Folio"
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "Fecha"
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle23
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        '
        'FechaVto
        '
        Me.FechaVto.DataPropertyName = "FechaVto"
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.FechaVto.DefaultCellStyle = DataGridViewCellStyle24
        Me.FechaVto.HeaderText = "Fecha Vto."
        Me.FechaVto.Name = "FechaVto"
        '
        'Monto
        '
        Me.Monto.DataPropertyName = "Monto"
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle25.Format = "$ #,000"
        Me.Monto.DefaultCellStyle = DataGridViewCellStyle25
        Me.Monto.HeaderText = "Monto"
        Me.Monto.Name = "Monto"
        '
        'Morosidad
        '
        Me.Morosidad.DataPropertyName = "Morosidad"
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Morosidad.DefaultCellStyle = DataGridViewCellStyle26
        Me.Morosidad.HeaderText = "Morosidad"
        Me.Morosidad.Name = "Morosidad"
        Me.Morosidad.Width = 80
        '
        'Bloqueado
        '
        Me.Bloqueado.DataPropertyName = "Bloqueado"
        Me.Bloqueado.HeaderText = "Bloqueado"
        Me.Bloqueado.Name = "Bloqueado"
        Me.Bloqueado.Width = 80
        '
        'CME
        '
        Me.CME.DataPropertyName = "CME"
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CME.DefaultCellStyle = DataGridViewCellStyle27
        Me.CME.HeaderText = "CME"
        Me.CME.Name = "CME"
        Me.CME.Width = 40
        '
        'Numero_SAP
        '
        Me.Numero_SAP.DataPropertyName = "Numero_SAP"
        Me.Numero_SAP.HeaderText = "Numero SAP"
        Me.Numero_SAP.Name = "Numero_SAP"
        '
        'Numero_NotaVenta
        '
        Me.Numero_NotaVenta.DataPropertyName = "Numero_NotaVenta"
        Me.Numero_NotaVenta.HeaderText = "Nota de Venta"
        Me.Numero_NotaVenta.Name = "Numero_NotaVenta"
        '
        'Nombre_Banco
        '
        Me.Nombre_Banco.DataPropertyName = "Nombre_Banco"
        Me.Nombre_Banco.HeaderText = "Nombre Banco"
        Me.Nombre_Banco.Name = "Nombre_Banco"
        '
        'Cod_Autorizacion
        '
        Me.Cod_Autorizacion.DataPropertyName = "Cod_Autorizacion"
        Me.Cod_Autorizacion.HeaderText = "Código Autorización"
        Me.Cod_Autorizacion.Name = "Cod_Autorizacion"
        '
        'Imprimir
        '
        Me.Imprimir.HeaderText = ""
        Me.Imprimir.Name = "Imprimir"
        Me.Imprimir.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Imprimir.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Imprimir.Width = 40
        '
        'Correo
        '
        Me.Correo.HeaderText = ""
        Me.Correo.Name = "Correo"
        Me.Correo.Width = 40
        '
        'btnAgregarMontoCuenta
        '
        Me.btnAgregarMontoCuenta.BackColor = System.Drawing.Color.DarkOrange
        Me.btnAgregarMontoCuenta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregarMontoCuenta.FlatAppearance.BorderSize = 0
        Me.btnAgregarMontoCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarMontoCuenta.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarMontoCuenta.ForeColor = System.Drawing.Color.White
        Me.btnAgregarMontoCuenta.Location = New System.Drawing.Point(211, 18)
        Me.btnAgregarMontoCuenta.Name = "btnAgregarMontoCuenta"
        Me.btnAgregarMontoCuenta.Size = New System.Drawing.Size(114, 34)
        Me.btnAgregarMontoCuenta.TabIndex = 89
        Me.btnAgregarMontoCuenta.Text = "Agregar"
        Me.btnAgregarMontoCuenta.UseVisualStyleBackColor = False
        '
        'txt_montoLineaCredito
        '
        Me.txt_montoLineaCredito.Enabled = False
        Me.txt_montoLineaCredito.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_montoLineaCredito.Location = New System.Drawing.Point(8, 27)
        Me.txt_montoLineaCredito.MaxLength = 9
        Me.txt_montoLineaCredito.Name = "txt_montoLineaCredito"
        Me.txt_montoLineaCredito.Size = New System.Drawing.Size(186, 27)
        Me.txt_montoLineaCredito.TabIndex = 89
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label35.Location = New System.Drawing.Point(6, 10)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(42, 13)
        Me.Label35.TabIndex = 88
        Me.Label35.Text = "Monto"
        '
        'TbpNotaVenta
        '
        Me.TbpNotaVenta.AutoScroll = True
        Me.TbpNotaVenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.TbpNotaVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TbpNotaVenta.Controls.Add(Me.CmbEstadoNotaVenta)
        Me.TbpNotaVenta.Controls.Add(Me.Label8)
        Me.TbpNotaVenta.Controls.Add(Me.btnFiltrarNotaVenta)
        Me.TbpNotaVenta.Controls.Add(Me.txt_nombreClienteNV)
        Me.TbpNotaVenta.Controls.Add(Me.Label53)
        Me.TbpNotaVenta.Controls.Add(Me.txt_numeroNV)
        Me.TbpNotaVenta.Controls.Add(Me.Label52)
        Me.TbpNotaVenta.Controls.Add(Me.WbbNotaVenta)
        Me.TbpNotaVenta.Controls.Add(Me.DgvNotasVenta)
        Me.TbpNotaVenta.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbpNotaVenta.Location = New System.Drawing.Point(4, 22)
        Me.TbpNotaVenta.Name = "TbpNotaVenta"
        Me.TbpNotaVenta.Size = New System.Drawing.Size(881, 674)
        Me.TbpNotaVenta.TabIndex = 0
        Me.TbpNotaVenta.Text = "Notas de Venta / Ordenes de Servicio"
        '
        'CmbEstadoNotaVenta
        '
        Me.CmbEstadoNotaVenta.AutoCompleteCustomSource.AddRange(New String() {"(Todas)", "Liberadas", "Por Liberar"})
        Me.CmbEstadoNotaVenta.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.CmbEstadoNotaVenta.FormattingEnabled = True
        Me.CmbEstadoNotaVenta.Location = New System.Drawing.Point(3, 23)
        Me.CmbEstadoNotaVenta.Name = "CmbEstadoNotaVenta"
        Me.CmbEstadoNotaVenta.Size = New System.Drawing.Size(132, 21)
        Me.CmbEstadoNotaVenta.TabIndex = 97
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label8.Location = New System.Drawing.Point(136, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 17)
        Me.Label8.TabIndex = 96
        Me.Label8.Text = "N°"
        '
        'btnFiltrarNotaVenta
        '
        Me.btnFiltrarNotaVenta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFiltrarNotaVenta.BackColor = System.Drawing.Color.SteelBlue
        Me.btnFiltrarNotaVenta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFiltrarNotaVenta.FlatAppearance.BorderSize = 0
        Me.btnFiltrarNotaVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFiltrarNotaVenta.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnFiltrarNotaVenta.ForeColor = System.Drawing.Color.White
        Me.btnFiltrarNotaVenta.Location = New System.Drawing.Point(855, 25)
        Me.btnFiltrarNotaVenta.Name = "btnFiltrarNotaVenta"
        Me.btnFiltrarNotaVenta.Size = New System.Drawing.Size(100, 27)
        Me.btnFiltrarNotaVenta.TabIndex = 95
        Me.btnFiltrarNotaVenta.Text = "Filtrar"
        Me.btnFiltrarNotaVenta.UseVisualStyleBackColor = False
        '
        'txt_nombreClienteNV
        '
        Me.txt_nombreClienteNV.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_nombreClienteNV.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txt_nombreClienteNV.Location = New System.Drawing.Point(249, 22)
        Me.txt_nombreClienteNV.Name = "txt_nombreClienteNV"
        Me.txt_nombreClienteNV.Size = New System.Drawing.Size(337, 22)
        Me.txt_nombreClienteNV.TabIndex = 94
        '
        'Label53
        '
        Me.Label53.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label53.Location = New System.Drawing.Point(246, 6)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(47, 17)
        Me.Label53.TabIndex = 93
        Me.Label53.Text = "Cliente"
        '
        'txt_numeroNV
        '
        Me.txt_numeroNV.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txt_numeroNV.Location = New System.Drawing.Point(139, 23)
        Me.txt_numeroNV.Name = "txt_numeroNV"
        Me.txt_numeroNV.Size = New System.Drawing.Size(104, 22)
        Me.txt_numeroNV.TabIndex = 92
        '
        'Label52
        '
        Me.Label52.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label52.Location = New System.Drawing.Point(1, 6)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(48, 17)
        Me.Label52.TabIndex = 91
        Me.Label52.Text = "Estado"
        '
        'WbbNotaVenta
        '
        Me.WbbNotaVenta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WbbNotaVenta.Location = New System.Drawing.Point(4, 347)
        Me.WbbNotaVenta.MinimumSize = New System.Drawing.Size(20, 18)
        Me.WbbNotaVenta.Name = "WbbNotaVenta"
        Me.WbbNotaVenta.Size = New System.Drawing.Size(582, 285)
        Me.WbbNotaVenta.TabIndex = 47
        Me.WbbNotaVenta.Url = New System.Uri("", System.UriKind.Relative)
        '
        'DgvNotasVenta
        '
        Me.DgvNotasVenta.AllowUserToAddRows = False
        Me.DgvNotasVenta.AllowUserToDeleteRows = False
        Me.DgvNotasVenta.AllowUserToResizeRows = False
        DataGridViewCellStyle32.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.DgvNotasVenta.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle32
        Me.DgvNotasVenta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvNotasVenta.BackgroundColor = System.Drawing.Color.White
        Me.DgvNotasVenta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DgvNotasVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvNotasVenta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TipoDocOrigen, Me.TipoDocImagen, Me.colNumeroNVOS, Me.colFechaNVOS, Me.nvc_totalFinal, Me.colNombreClienteNVOS, Me.colRut, Me.colEMail, Me.colTelefono, Me.estado, Me.nombreEstado})
        Me.DgvNotasVenta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DgvNotasVenta.GridColor = System.Drawing.Color.White
        Me.DgvNotasVenta.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.DgvNotasVenta.Location = New System.Drawing.Point(3, 52)
        Me.DgvNotasVenta.Name = "DgvNotasVenta"
        Me.DgvNotasVenta.ReadOnly = True
        Me.DgvNotasVenta.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgvNotasVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvNotasVenta.Size = New System.Drawing.Size(583, 285)
        Me.DgvNotasVenta.TabIndex = 46
        '
        'TipoDocOrigen
        '
        Me.TipoDocOrigen.DataPropertyName = "tipoDoc"
        Me.TipoDocOrigen.HeaderText = "TipoDoc Origen"
        Me.TipoDocOrigen.Name = "TipoDocOrigen"
        Me.TipoDocOrigen.ReadOnly = True
        Me.TipoDocOrigen.Visible = False
        '
        'TipoDocImagen
        '
        Me.TipoDocImagen.HeaderText = ""
        Me.TipoDocImagen.Name = "TipoDocImagen"
        Me.TipoDocImagen.ReadOnly = True
        Me.TipoDocImagen.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TipoDocImagen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.TipoDocImagen.Width = 32
        '
        'colNumeroNVOS
        '
        Me.colNumeroNVOS.DataPropertyName = "numero"
        Me.colNumeroNVOS.HeaderText = "Núm."
        Me.colNumeroNVOS.Name = "colNumeroNVOS"
        Me.colNumeroNVOS.ReadOnly = True
        Me.colNumeroNVOS.Width = 70
        '
        'colFechaNVOS
        '
        Me.colFechaNVOS.DataPropertyName = "fecha"
        Me.colFechaNVOS.HeaderText = "fecha"
        Me.colFechaNVOS.Name = "colFechaNVOS"
        Me.colFechaNVOS.ReadOnly = True
        Me.colFechaNVOS.Width = 120
        '
        'nvc_totalFinal
        '
        Me.nvc_totalFinal.DataPropertyName = "monto"
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle33.Format = "$ #,000"
        Me.nvc_totalFinal.DefaultCellStyle = DataGridViewCellStyle33
        Me.nvc_totalFinal.HeaderText = "Monto"
        Me.nvc_totalFinal.Name = "nvc_totalFinal"
        Me.nvc_totalFinal.ReadOnly = True
        '
        'colNombreClienteNVOS
        '
        Me.colNombreClienteNVOS.DataPropertyName = "nombreCliente"
        Me.colNombreClienteNVOS.HeaderText = "nombre"
        Me.colNombreClienteNVOS.Name = "colNombreClienteNVOS"
        Me.colNombreClienteNVOS.ReadOnly = True
        Me.colNombreClienteNVOS.Width = 240
        '
        'colRut
        '
        Me.colRut.DataPropertyName = "rut"
        Me.colRut.HeaderText = "Rut"
        Me.colRut.Name = "colRut"
        Me.colRut.ReadOnly = True
        '
        'colEMail
        '
        Me.colEMail.DataPropertyName = "email"
        Me.colEMail.HeaderText = "e-mail"
        Me.colEMail.Name = "colEMail"
        Me.colEMail.ReadOnly = True
        '
        'colTelefono
        '
        Me.colTelefono.DataPropertyName = "telefono"
        Me.colTelefono.HeaderText = "Teléfono"
        Me.colTelefono.Name = "colTelefono"
        Me.colTelefono.ReadOnly = True
        '
        'estado
        '
        Me.estado.DataPropertyName = "estado"
        Me.estado.HeaderText = "estado"
        Me.estado.Name = "estado"
        Me.estado.ReadOnly = True
        Me.estado.Visible = False
        '
        'nombreEstado
        '
        Me.nombreEstado.DataPropertyName = "nombreEstado"
        Me.nombreEstado.HeaderText = "Nombre Estado"
        Me.nombreEstado.Name = "nombreEstado"
        Me.nombreEstado.ReadOnly = True
        '
        'TbpNotaCredito
        '
        Me.TbpNotaCredito.Controls.Add(Me.DgvNotasCreditoWorkflow)
        Me.TbpNotaCredito.Location = New System.Drawing.Point(4, 22)
        Me.TbpNotaCredito.Name = "TbpNotaCredito"
        Me.TbpNotaCredito.Size = New System.Drawing.Size(881, 674)
        Me.TbpNotaCredito.TabIndex = 2
        Me.TbpNotaCredito.Text = "Notas de Crédito"
        Me.TbpNotaCredito.UseVisualStyleBackColor = True
        '
        'DgvNotasCreditoWorkflow
        '
        Me.DgvNotasCreditoWorkflow.AllowUserToAddRows = False
        Me.DgvNotasCreditoWorkflow.AllowUserToDeleteRows = False
        Me.DgvNotasCreditoWorkflow.AllowUserToResizeRows = False
        Me.DgvNotasCreditoWorkflow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvNotasCreditoWorkflow.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColNumero, Me.ColFecha, Me.ColRutCliente, Me.ColNombreCliente, Me.ColMontoTotal, Me.colNombreEstado, Me.colEstado, Me.ColTipoDte, Me.ColFolioDte})
        Me.DgvNotasCreditoWorkflow.Location = New System.Drawing.Point(12, 20)
        Me.DgvNotasCreditoWorkflow.Name = "DgvNotasCreditoWorkflow"
        Me.DgvNotasCreditoWorkflow.Size = New System.Drawing.Size(581, 204)
        Me.DgvNotasCreditoWorkflow.TabIndex = 0
        '
        'ColNumero
        '
        Me.ColNumero.DataPropertyName = "numero"
        Me.ColNumero.HeaderText = "Número"
        Me.ColNumero.Name = "ColNumero"
        '
        'ColFecha
        '
        Me.ColFecha.DataPropertyName = "fecha"
        Me.ColFecha.HeaderText = "Fecha"
        Me.ColFecha.Name = "ColFecha"
        '
        'ColRutCliente
        '
        Me.ColRutCliente.DataPropertyName = "rut"
        Me.ColRutCliente.HeaderText = "Rut Cliente"
        Me.ColRutCliente.Name = "ColRutCliente"
        '
        'ColNombreCliente
        '
        Me.ColNombreCliente.DataPropertyName = "nombreCliente"
        Me.ColNombreCliente.HeaderText = "Nombre Cliente"
        Me.ColNombreCliente.Name = "ColNombreCliente"
        Me.ColNombreCliente.Width = 250
        '
        'ColMontoTotal
        '
        Me.ColMontoTotal.DataPropertyName = "monto"
        DataGridViewCellStyle34.Format = "$ #,000"
        Me.ColMontoTotal.DefaultCellStyle = DataGridViewCellStyle34
        Me.ColMontoTotal.HeaderText = "Monto"
        Me.ColMontoTotal.Name = "ColMontoTotal"
        '
        'colNombreEstado
        '
        Me.colNombreEstado.DataPropertyName = "nombreEstado"
        Me.colNombreEstado.HeaderText = "Nombre Estado"
        Me.colNombreEstado.Name = "colNombreEstado"
        Me.colNombreEstado.Width = 150
        '
        'colEstado
        '
        Me.colEstado.DataPropertyName = "estado"
        Me.colEstado.HeaderText = "Estado"
        Me.colEstado.Name = "colEstado"
        Me.colEstado.Visible = False
        '
        'ColTipoDte
        '
        Me.ColTipoDte.DataPropertyName = "tipoDte"
        Me.ColTipoDte.HeaderText = "Tipo Dte"
        Me.ColTipoDte.Name = "ColTipoDte"
        Me.ColTipoDte.Visible = False
        '
        'ColFolioDte
        '
        Me.ColFolioDte.DataPropertyName = "folioDte"
        Me.ColFolioDte.HeaderText = "Folio Dte"
        Me.ColFolioDte.Name = "ColFolioDte"
        Me.ColFolioDte.Visible = False
        '
        'VwwebnotaVentaCabBindingSource
        '
        Me.VwwebnotaVentaCabBindingSource.DataMember = "vw_web_notaVentaCab"
        Me.VwwebnotaVentaCabBindingSource.DataSource = Me.DataSetcatalogoBindingSource
        '
        'DataSetcatalogoBindingSource
        '
        Me.DataSetcatalogoBindingSource.DataSource = Me.DataSet_catalogo
        Me.DataSetcatalogoBindingSource.Position = 0
        '
        'DataSet_catalogo
        '
        Me.DataSet_catalogo.DataSetName = "DataSet_catalogo"
        Me.DataSet_catalogo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BancoBindingSource
        '
        Me.BancoBindingSource.DataMember = "banco"
        Me.BancoBindingSource.DataSource = Me.DataSetcatalogoBindingSource
        '
        'SpwebbusquedageneralBindingSource
        '
        Me.SpwebbusquedageneralBindingSource.DataMember = "sp_web_busqueda_general"
        Me.SpwebbusquedageneralBindingSource.DataSource = Me.DataSetcatalogoBindingSource
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Panel4.Controls.Add(Me.lblReintento)
        Me.Panel4.Controls.Add(Me.btnImprimir)
        Me.Panel4.Controls.Add(Me.chk_anticipo)
        Me.Panel4.Controls.Add(Me.btnPagarDocumentos)
        Me.Panel4.Controls.Add(Me.txt_datosDespacho)
        Me.Panel4.Controls.Add(Me.lblDatosDespacho)
        Me.Panel4.Controls.Add(Me.lblNumeroDocumento)
        Me.Panel4.Controls.Add(Me.txt_medioPago)
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Controls.Add(Me.Panel8)
        Me.Panel4.Controls.Add(Me.Label_OK_Cupon)
        Me.Panel4.Controls.Add(Me.Label29)
        Me.Panel4.Controls.Add(Me.txt_cupon)
        Me.Panel4.Controls.Add(Me.txt_OC)
        Me.Panel4.Controls.Add(Me.Label31)
        Me.Panel4.Controls.Add(Me.txt_NotaVenta)
        Me.Panel4.Controls.Add(Me.lbl_docOrigen)
        Me.Panel4.Controls.Add(Me.txt_vendedor)
        Me.Panel4.Controls.Add(Me.Label15)
        Me.Panel4.Controls.Add(Me.txt_nombreCajero)
        Me.Panel4.Controls.Add(Me.Label14)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Controls.Add(Me.btnRestablecer)
        Me.Panel4.Controls.Add(Me.pnl_totalProductos)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Controls.Add(Me.btnFacturar)
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Controls.Add(Me.PictureBox1)
        Me.Panel4.Controls.Add(Me.imagen_conexion_basedatos)
        Me.Panel4.Controls.Add(Me.Panel6)
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(752, 732)
        Me.Panel4.TabIndex = 3
        '
        'lblReintento
        '
        Me.lblReintento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblReintento.BackColor = System.Drawing.Color.Transparent
        Me.lblReintento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReintento.ForeColor = System.Drawing.Color.White
        Me.lblReintento.Location = New System.Drawing.Point(828, 696)
        Me.lblReintento.Name = "lblReintento"
        Me.lblReintento.Size = New System.Drawing.Size(17, 18)
        Me.lblReintento.TabIndex = 114
        Me.lblReintento.Text = "10"
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.BackColor = System.Drawing.Color.DarkOrange
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.FlatAppearance.BorderSize = 0
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnImprimir.ForeColor = System.Drawing.Color.White
        Me.btnImprimir.Location = New System.Drawing.Point(105, 688)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(95, 34)
        Me.btnImprimir.TabIndex = 111
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = False
        Me.btnImprimir.Visible = False
        '
        'chk_anticipo
        '
        Me.chk_anticipo.AutoCheck = False
        Me.chk_anticipo.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.chk_anticipo.Location = New System.Drawing.Point(404, 23)
        Me.chk_anticipo.Name = "chk_anticipo"
        Me.chk_anticipo.Size = New System.Drawing.Size(81, 22)
        Me.chk_anticipo.TabIndex = 110
        Me.chk_anticipo.Text = "Anticipo"
        Me.chk_anticipo.UseVisualStyleBackColor = True
        '
        'btnPagarDocumentos
        '
        Me.btnPagarDocumentos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPagarDocumentos.BackColor = System.Drawing.Color.DarkOrange
        Me.btnPagarDocumentos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPagarDocumentos.Enabled = False
        Me.btnPagarDocumentos.FlatAppearance.BorderSize = 0
        Me.btnPagarDocumentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPagarDocumentos.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnPagarDocumentos.ForeColor = System.Drawing.Color.White
        Me.btnPagarDocumentos.Location = New System.Drawing.Point(201, 688)
        Me.btnPagarDocumentos.Name = "btnPagarDocumentos"
        Me.btnPagarDocumentos.Size = New System.Drawing.Size(150, 34)
        Me.btnPagarDocumentos.TabIndex = 108
        Me.btnPagarDocumentos.Text = "Pagar Documentos"
        Me.btnPagarDocumentos.UseVisualStyleBackColor = False
        '
        'txt_datosDespacho
        '
        Me.txt_datosDespacho.Enabled = False
        Me.txt_datosDespacho.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txt_datosDespacho.Location = New System.Drawing.Point(381, 102)
        Me.txt_datosDespacho.Name = "txt_datosDespacho"
        Me.txt_datosDespacho.Size = New System.Drawing.Size(359, 22)
        Me.txt_datosDespacho.TabIndex = 107
        '
        'lblDatosDespacho
        '
        Me.lblDatosDespacho.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblDatosDespacho.ForeColor = System.Drawing.Color.Black
        Me.lblDatosDespacho.Location = New System.Drawing.Point(276, 107)
        Me.lblDatosDespacho.Name = "lblDatosDespacho"
        Me.lblDatosDespacho.Size = New System.Drawing.Size(105, 16)
        Me.lblDatosDespacho.TabIndex = 106
        Me.lblDatosDespacho.Text = "Datos Despacho"
        '
        'lblNumeroDocumento
        '
        Me.lblNumeroDocumento.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblNumeroDocumento.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblNumeroDocumento.Location = New System.Drawing.Point(264, 23)
        Me.lblNumeroDocumento.Name = "lblNumeroDocumento"
        Me.lblNumeroDocumento.Size = New System.Drawing.Size(117, 31)
        Me.lblNumeroDocumento.TabIndex = 105
        Me.lblNumeroDocumento.Text = "0"
        Me.lblNumeroDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_medioPago
        '
        Me.txt_medioPago.Enabled = False
        Me.txt_medioPago.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txt_medioPago.Location = New System.Drawing.Point(94, 103)
        Me.txt_medioPago.Name = "txt_medioPago"
        Me.txt_medioPago.Size = New System.Drawing.Size(182, 22)
        Me.txt_medioPago.TabIndex = 104
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(11, 107)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(69, 13)
        Me.Label17.TabIndex = 103
        Me.Label17.Text = "Medio Pago"
        '
        'Panel8
        '
        Me.Panel8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.Panel8.Controls.Add(Me.chk_emailDocumento)
        Me.Panel8.Controls.Add(Me.chk_imprimirDocumento)
        Me.Panel8.Location = New System.Drawing.Point(351, 688)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(182, 34)
        Me.Panel8.TabIndex = 102
        '
        'chk_emailDocumento
        '
        Me.chk_emailDocumento.AutoSize = True
        Me.chk_emailDocumento.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.chk_emailDocumento.Location = New System.Drawing.Point(109, 10)
        Me.chk_emailDocumento.Name = "chk_emailDocumento"
        Me.chk_emailDocumento.Size = New System.Drawing.Size(53, 17)
        Me.chk_emailDocumento.TabIndex = 1
        Me.chk_emailDocumento.Text = "Email"
        Me.chk_emailDocumento.UseVisualStyleBackColor = True
        '
        'chk_imprimirDocumento
        '
        Me.chk_imprimirDocumento.AutoSize = True
        Me.chk_imprimirDocumento.Checked = True
        Me.chk_imprimirDocumento.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_imprimirDocumento.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.chk_imprimirDocumento.Location = New System.Drawing.Point(13, 10)
        Me.chk_imprimirDocumento.Name = "chk_imprimirDocumento"
        Me.chk_imprimirDocumento.Size = New System.Drawing.Size(68, 17)
        Me.chk_imprimirDocumento.TabIndex = 0
        Me.chk_imprimirDocumento.Text = "Imprimir"
        Me.chk_imprimirDocumento.UseVisualStyleBackColor = True
        '
        'Label_OK_Cupon
        '
        Me.Label_OK_Cupon.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label_OK_Cupon.Image = Global.caja2.My.Resources.Resources.Check
        Me.Label_OK_Cupon.Location = New System.Drawing.Point(248, 612)
        Me.Label_OK_Cupon.Name = "Label_OK_Cupon"
        Me.Label_OK_Cupon.Size = New System.Drawing.Size(27, 26)
        Me.Label_OK_Cupon.TabIndex = 101
        Me.Label_OK_Cupon.TabStop = False
        Me.Label_OK_Cupon.Visible = False
        '
        'Label29
        '
        Me.Label29.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label29.Location = New System.Drawing.Point(11, 595)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(116, 13)
        Me.Label29.TabIndex = 96
        Me.Label29.Text = "Cupón de Descuento"
        '
        'txt_cupon
        '
        Me.txt_cupon.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_cupon.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txt_cupon.Location = New System.Drawing.Point(14, 613)
        Me.txt_cupon.Name = "txt_cupon"
        Me.txt_cupon.Size = New System.Drawing.Size(228, 22)
        Me.txt_cupon.TabIndex = 95
        '
        'txt_OC
        '
        Me.txt_OC.Enabled = False
        Me.txt_OC.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txt_OC.Location = New System.Drawing.Point(593, 79)
        Me.txt_OC.Name = "txt_OC"
        Me.txt_OC.Size = New System.Drawing.Size(147, 22)
        Me.txt_OC.TabIndex = 94
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(693, 61)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(23, 13)
        Me.Label31.TabIndex = 93
        Me.Label31.Text = "OC"
        '
        'txt_NotaVenta
        '
        Me.txt_NotaVenta.Enabled = False
        Me.txt_NotaVenta.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txt_NotaVenta.Location = New System.Drawing.Point(523, 79)
        Me.txt_NotaVenta.Name = "txt_NotaVenta"
        Me.txt_NotaVenta.Size = New System.Drawing.Size(70, 22)
        Me.txt_NotaVenta.TabIndex = 92
        '
        'lbl_docOrigen
        '
        Me.lbl_docOrigen.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lbl_docOrigen.ForeColor = System.Drawing.Color.Black
        Me.lbl_docOrigen.Location = New System.Drawing.Point(518, 61)
        Me.lbl_docOrigen.Name = "lbl_docOrigen"
        Me.lbl_docOrigen.Size = New System.Drawing.Size(135, 16)
        Me.lbl_docOrigen.TabIndex = 91
        Me.lbl_docOrigen.Text = "Nota de Venta / O.S."
        '
        'txt_vendedor
        '
        Me.txt_vendedor.Enabled = False
        Me.txt_vendedor.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txt_vendedor.Location = New System.Drawing.Point(276, 79)
        Me.txt_vendedor.Name = "txt_vendedor"
        Me.txt_vendedor.Size = New System.Drawing.Size(245, 22)
        Me.txt_vendedor.TabIndex = 90
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(273, 61)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(57, 13)
        Me.Label15.TabIndex = 89
        Me.Label15.Text = "Vendedor"
        '
        'txt_nombreCajero
        '
        Me.txt_nombreCajero.Enabled = False
        Me.txt_nombreCajero.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txt_nombreCajero.Location = New System.Drawing.Point(9, 79)
        Me.txt_nombreCajero.Name = "txt_nombreCajero"
        Me.txt_nombreCajero.Size = New System.Drawing.Size(267, 22)
        Me.txt_nombreCajero.TabIndex = 88
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(7, 61)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 13)
        Me.Label14.TabIndex = 87
        Me.Label14.Text = "Cajero"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label13.Location = New System.Drawing.Point(168, 18)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(96, 40)
        Me.Label13.TabIndex = 86
        Me.Label13.Text = "Venta N°"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnRestablecer
        '
        Me.btnRestablecer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRestablecer.BackColor = System.Drawing.Color.DarkOrange
        Me.btnRestablecer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRestablecer.FlatAppearance.BorderSize = 0
        Me.btnRestablecer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRestablecer.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnRestablecer.ForeColor = System.Drawing.Color.White
        Me.btnRestablecer.Location = New System.Drawing.Point(9, 688)
        Me.btnRestablecer.Name = "btnRestablecer"
        Me.btnRestablecer.Size = New System.Drawing.Size(95, 34)
        Me.btnRestablecer.TabIndex = 85
        Me.btnRestablecer.Text = "Restablecer"
        Me.btnRestablecer.UseVisualStyleBackColor = False
        '
        'pnl_totalProductos
        '
        Me.pnl_totalProductos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnl_totalProductos.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.pnl_totalProductos.Controls.Add(Me.txt_totalDescuentoCupon)
        Me.pnl_totalProductos.Controls.Add(Me.txt_totalIva)
        Me.pnl_totalProductos.Controls.Add(Me.Label32)
        Me.pnl_totalProductos.Controls.Add(Me.Label33)
        Me.pnl_totalProductos.Controls.Add(Me.lbl_totalFinal)
        Me.pnl_totalProductos.Controls.Add(Me.txt_totalNeto)
        Me.pnl_totalProductos.Controls.Add(Me.txt_totalDescuento)
        Me.pnl_totalProductos.Controls.Add(Me.txt_subtotal)
        Me.pnl_totalProductos.Controls.Add(Me.Label11)
        Me.pnl_totalProductos.Controls.Add(Me.Label9)
        Me.pnl_totalProductos.Controls.Add(Me.Label5)
        Me.pnl_totalProductos.Controls.Add(Me.Label2)
        Me.pnl_totalProductos.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.pnl_totalProductos.Location = New System.Drawing.Point(341, 594)
        Me.pnl_totalProductos.Name = "pnl_totalProductos"
        Me.pnl_totalProductos.Size = New System.Drawing.Size(405, 88)
        Me.pnl_totalProductos.TabIndex = 47
        '
        'txt_totalDescuentoCupon
        '
        Me.txt_totalDescuentoCupon.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.txt_totalDescuentoCupon.Location = New System.Drawing.Point(293, 28)
        Me.txt_totalDescuentoCupon.Name = "txt_totalDescuentoCupon"
        Me.txt_totalDescuentoCupon.Size = New System.Drawing.Size(100, 18)
        Me.txt_totalDescuentoCupon.TabIndex = 49
        Me.txt_totalDescuentoCupon.Text = "-$ 0"
        Me.txt_totalDescuentoCupon.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_totalIva
        '
        Me.txt_totalIva.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.txt_totalIva.Location = New System.Drawing.Point(293, 48)
        Me.txt_totalIva.Name = "txt_totalIva"
        Me.txt_totalIva.Size = New System.Drawing.Size(100, 18)
        Me.txt_totalIva.TabIndex = 47
        Me.txt_totalIva.Text = "$ 0"
        Me.txt_totalIva.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(188, 27)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(88, 20)
        Me.Label32.TabIndex = 45
        Me.Label32.Text = "Des. Cupón"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(188, 48)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(34, 20)
        Me.Label33.TabIndex = 44
        Me.Label33.Text = "IVA"
        '
        'lbl_totalFinal
        '
        Me.lbl_totalFinal.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_totalFinal.ForeColor = System.Drawing.Color.DarkOrange
        Me.lbl_totalFinal.Location = New System.Drawing.Point(262, 64)
        Me.lbl_totalFinal.Name = "lbl_totalFinal"
        Me.lbl_totalFinal.Size = New System.Drawing.Size(135, 23)
        Me.lbl_totalFinal.TabIndex = 43
        Me.lbl_totalFinal.Text = "$ 0"
        Me.lbl_totalFinal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_totalNeto
        '
        Me.txt_totalNeto.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.txt_totalNeto.Location = New System.Drawing.Point(293, 8)
        Me.txt_totalNeto.Name = "txt_totalNeto"
        Me.txt_totalNeto.Size = New System.Drawing.Size(100, 18)
        Me.txt_totalNeto.TabIndex = 42
        Me.txt_totalNeto.Text = "$ 0"
        Me.txt_totalNeto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_totalDescuento
        '
        Me.txt_totalDescuento.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.txt_totalDescuento.Location = New System.Drawing.Point(88, 26)
        Me.txt_totalDescuento.Name = "txt_totalDescuento"
        Me.txt_totalDescuento.Size = New System.Drawing.Size(83, 18)
        Me.txt_totalDescuento.TabIndex = 41
        Me.txt_totalDescuento.Text = "-$ 0"
        Me.txt_totalDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.txt_totalDescuento.Visible = False
        '
        'txt_subtotal
        '
        Me.txt_subtotal.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.txt_subtotal.Location = New System.Drawing.Point(88, 6)
        Me.txt_subtotal.Name = "txt_subtotal"
        Me.txt_subtotal.Size = New System.Drawing.Size(83, 18)
        Me.txt_subtotal.TabIndex = 40
        Me.txt_subtotal.Text = "$ 0"
        Me.txt_subtotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.txt_subtotal.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(188, 65)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 20)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "TOTAL"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(188, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 20)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Total Neto"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 20)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "Descuento"
        Me.Label5.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 20)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Sub Total"
        Me.Label2.Visible = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.Panel5.Controls.Add(Me.RadioButton_notaCredito)
        Me.Panel5.Controls.Add(Me.RadioButton_boleta)
        Me.Panel5.Controls.Add(Me.RadioButton_factura)
        Me.Panel5.Location = New System.Drawing.Point(487, 9)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(253, 49)
        Me.Panel5.TabIndex = 55
        '
        'RadioButton_notaCredito
        '
        Me.RadioButton_notaCredito.Enabled = False
        Me.RadioButton_notaCredito.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.RadioButton_notaCredito.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.RadioButton_notaCredito.Location = New System.Drawing.Point(145, 12)
        Me.RadioButton_notaCredito.Name = "RadioButton_notaCredito"
        Me.RadioButton_notaCredito.Size = New System.Drawing.Size(102, 25)
        Me.RadioButton_notaCredito.TabIndex = 20
        Me.RadioButton_notaCredito.Text = "N. Crédito"
        Me.RadioButton_notaCredito.UseVisualStyleBackColor = True
        '
        'RadioButton_boleta
        '
        Me.RadioButton_boleta.AutoSize = True
        Me.RadioButton_boleta.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.RadioButton_boleta.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.RadioButton_boleta.Location = New System.Drawing.Point(79, 13)
        Me.RadioButton_boleta.Name = "RadioButton_boleta"
        Me.RadioButton_boleta.Size = New System.Drawing.Size(63, 21)
        Me.RadioButton_boleta.TabIndex = 19
        Me.RadioButton_boleta.Text = "Boleta"
        Me.RadioButton_boleta.UseVisualStyleBackColor = True
        '
        'RadioButton_factura
        '
        Me.RadioButton_factura.AutoSize = True
        Me.RadioButton_factura.Checked = True
        Me.RadioButton_factura.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.RadioButton_factura.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.RadioButton_factura.Location = New System.Drawing.Point(4, 13)
        Me.RadioButton_factura.Name = "RadioButton_factura"
        Me.RadioButton_factura.Size = New System.Drawing.Size(69, 21)
        Me.RadioButton_factura.TabIndex = 18
        Me.RadioButton_factura.TabStop = True
        Me.RadioButton_factura.Text = "Factura"
        Me.RadioButton_factura.UseVisualStyleBackColor = True
        '
        'btnFacturar
        '
        Me.btnFacturar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnFacturar.BackColor = System.Drawing.Color.DarkOrange
        Me.btnFacturar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFacturar.Enabled = False
        Me.btnFacturar.FlatAppearance.BorderSize = 0
        Me.btnFacturar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFacturar.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnFacturar.ForeColor = System.Drawing.Color.White
        Me.btnFacturar.Location = New System.Drawing.Point(533, 689)
        Me.btnFacturar.Name = "btnFacturar"
        Me.btnFacturar.Size = New System.Drawing.Size(173, 34)
        Me.btnFacturar.TabIndex = 43
        Me.btnFacturar.Text = "Facturar"
        Me.btnFacturar.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.PictureBox3)
        Me.Panel2.Controls.Add(Me.btnBuscarProducto)
        Me.Panel2.Controls.Add(Me.DgvDetalleProductos)
        Me.Panel2.Controls.Add(Me.txt_cantidad)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.btnAgregarProducto)
        Me.Panel2.Controls.Add(Me.txt_codigo_CAREN)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(7, 315)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(739, 277)
        Me.Panel2.TabIndex = 39
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.caja2.My.Resources.Resources.Sin_título2
        Me.PictureBox3.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(20, 24)
        Me.PictureBox3.TabIndex = 99
        Me.PictureBox3.TabStop = False
        '
        'btnBuscarProducto
        '
        Me.btnBuscarProducto.BackColor = System.Drawing.Color.SteelBlue
        Me.btnBuscarProducto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarProducto.FlatAppearance.BorderSize = 0
        Me.btnBuscarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscarProducto.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnBuscarProducto.ForeColor = System.Drawing.Color.White
        Me.btnBuscarProducto.Location = New System.Drawing.Point(409, 30)
        Me.btnBuscarProducto.Name = "btnBuscarProducto"
        Me.btnBuscarProducto.Size = New System.Drawing.Size(100, 27)
        Me.btnBuscarProducto.TabIndex = 72
        Me.btnBuscarProducto.Text = "Buscar"
        Me.btnBuscarProducto.UseVisualStyleBackColor = False
        '
        'DgvDetalleProductos
        '
        Me.DgvDetalleProductos.AllowUserToAddRows = False
        DataGridViewCellStyle35.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.DgvDetalleProductos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle35
        Me.DgvDetalleProductos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DgvDetalleProductos.BackgroundColor = System.Drawing.Color.White
        Me.DgvDetalleProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        DataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle36.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        DataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle36.NullValue = Nothing
        DataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvDetalleProductos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle36
        Me.DgvDetalleProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDetalleProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCodigo, Me.colDescrip, Me.colCantidad, Me.colUnitarioNeto, Me.colTotalNeto, Me.colTotal})
        Me.DgvDetalleProductos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DgvDetalleProductos.GridColor = System.Drawing.Color.White
        Me.DgvDetalleProductos.Location = New System.Drawing.Point(6, 62)
        Me.DgvDetalleProductos.Name = "DgvDetalleProductos"
        Me.DgvDetalleProductos.ReadOnly = True
        Me.DgvDetalleProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvDetalleProductos.Size = New System.Drawing.Size(727, 212)
        Me.DgvDetalleProductos.TabIndex = 46
        '
        'colCodigo
        '
        DataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colCodigo.DefaultCellStyle = DataGridViewCellStyle37
        Me.colCodigo.HeaderText = "Código"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.ReadOnly = True
        Me.colCodigo.Width = 80
        '
        'colDescrip
        '
        Me.colDescrip.HeaderText = "Descripción"
        Me.colDescrip.Name = "colDescrip"
        Me.colDescrip.ReadOnly = True
        Me.colDescrip.Width = 330
        '
        'colCantidad
        '
        DataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colCantidad.DefaultCellStyle = DataGridViewCellStyle38
        Me.colCantidad.HeaderText = "Cant"
        Me.colCantidad.Name = "colCantidad"
        Me.colCantidad.ReadOnly = True
        Me.colCantidad.Width = 50
        '
        'colUnitarioNeto
        '
        DataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle39.Format = "$ #,000"
        DataGridViewCellStyle39.NullValue = Nothing
        Me.colUnitarioNeto.DefaultCellStyle = DataGridViewCellStyle39
        Me.colUnitarioNeto.HeaderText = "Val.Uni.Neto"
        Me.colUnitarioNeto.Name = "colUnitarioNeto"
        Me.colUnitarioNeto.ReadOnly = True
        '
        'colTotalNeto
        '
        DataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle40.Format = "$ #,000"
        DataGridViewCellStyle40.NullValue = Nothing
        Me.colTotalNeto.DefaultCellStyle = DataGridViewCellStyle40
        Me.colTotalNeto.HeaderText = "Total Neto"
        Me.colTotalNeto.Name = "colTotalNeto"
        Me.colTotalNeto.ReadOnly = True
        '
        'colTotal
        '
        Me.colTotal.HeaderText = "Total"
        Me.colTotal.Name = "colTotal"
        Me.colTotal.ReadOnly = True
        Me.colTotal.Visible = False
        '
        'txt_cantidad
        '
        Me.txt_cantidad.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txt_cantidad.Location = New System.Drawing.Point(313, 30)
        Me.txt_cantidad.Name = "txt_cantidad"
        Me.txt_cantidad.Size = New System.Drawing.Size(90, 22)
        Me.txt_cantidad.TabIndex = 71
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label4.Location = New System.Drawing.Point(247, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "Cantidad"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(30, 7)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 23)
        Me.Label10.TabIndex = 43
        Me.Label10.Text = "Pedido"
        '
        'btnAgregarProducto
        '
        Me.btnAgregarProducto.BackColor = System.Drawing.Color.DarkOrange
        Me.btnAgregarProducto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregarProducto.FlatAppearance.BorderSize = 0
        Me.btnAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarProducto.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnAgregarProducto.ForeColor = System.Drawing.Color.White
        Me.btnAgregarProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregarProducto.Location = New System.Drawing.Point(619, 22)
        Me.btnAgregarProducto.Name = "btnAgregarProducto"
        Me.btnAgregarProducto.Size = New System.Drawing.Size(114, 34)
        Me.btnAgregarProducto.TabIndex = 21
        Me.btnAgregarProducto.Text = "Agregar"
        Me.btnAgregarProducto.UseVisualStyleBackColor = False
        '
        'txt_codigo_CAREN
        '
        Me.txt_codigo_CAREN.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txt_codigo_CAREN.Location = New System.Drawing.Point(102, 30)
        Me.txt_codigo_CAREN.Name = "txt_codigo_CAREN"
        Me.txt_codigo_CAREN.Size = New System.Drawing.Size(139, 22)
        Me.txt_codigo_CAREN.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label1.Location = New System.Drawing.Point(6, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Código CAREN"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Image = Global.caja2.My.Resources.Resources.logo4
        Me.PictureBox1.Location = New System.Drawing.Point(10, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(158, 52)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 37
        Me.PictureBox1.TabStop = False
        '
        'imagen_conexion_basedatos
        '
        Me.imagen_conexion_basedatos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.imagen_conexion_basedatos.Image = Global.caja2.My.Resources.Resources.wifi
        Me.imagen_conexion_basedatos.Location = New System.Drawing.Point(706, 689)
        Me.imagen_conexion_basedatos.Name = "imagen_conexion_basedatos"
        Me.imagen_conexion_basedatos.Size = New System.Drawing.Size(37, 34)
        Me.imagen_conexion_basedatos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imagen_conexion_basedatos.TabIndex = 112
        Me.imagen_conexion_basedatos.TabStop = False
        Me.imagen_conexion_basedatos.Visible = False
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.cbx_direcciones_cliente)
        Me.Panel6.Controls.Add(Me.txt_apellido_cliente)
        Me.Panel6.Controls.Add(Me.lblApellidoCliente)
        Me.Panel6.Controls.Add(Me.txt_idCliente)
        Me.Panel6.Controls.Add(Me.Label47)
        Me.Panel6.Controls.Add(Me.cbx_comuna_cliente)
        Me.Panel6.Controls.Add(Me.cbx_ciudad_cliente)
        Me.Panel6.Controls.Add(Me.PictureBox2)
        Me.Panel6.Controls.Add(Me.txt_giro_cliente)
        Me.Panel6.Controls.Add(Me.Label26)
        Me.Panel6.Controls.Add(Me.Label25)
        Me.Panel6.Controls.Add(Me.txt_email_cliente)
        Me.Panel6.Controls.Add(Me.Label24)
        Me.Panel6.Controls.Add(Me.txt_direccion_cliente)
        Me.Panel6.Controls.Add(Me.Label23)
        Me.Panel6.Controls.Add(Me.Label21)
        Me.Panel6.Controls.Add(Me.txt_telefono_cliente)
        Me.Panel6.Controls.Add(Me.Label22)
        Me.Panel6.Controls.Add(Me.txt_nombre_cliente)
        Me.Panel6.Controls.Add(Me.Label19)
        Me.Panel6.Controls.Add(Me.txt_rutCliente)
        Me.Panel6.Controls.Add(Me.Label18)
        Me.Panel6.Controls.Add(Me.lbl_tituloCliente)
        Me.Panel6.Controls.Add(Me.pnl_totalDocumentos)
        Me.Panel6.Location = New System.Drawing.Point(6, 126)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(737, 187)
        Me.Panel6.TabIndex = 51
        '
        'cbx_direcciones_cliente
        '
        Me.cbx_direcciones_cliente.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbx_direcciones_cliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_direcciones_cliente.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.cbx_direcciones_cliente.FormattingEnabled = True
        Me.cbx_direcciones_cliente.Location = New System.Drawing.Point(283, 130)
        Me.cbx_direcciones_cliente.Name = "cbx_direcciones_cliente"
        Me.cbx_direcciones_cliente.Size = New System.Drawing.Size(448, 23)
        Me.cbx_direcciones_cliente.TabIndex = 110
        '
        'txt_apellido_cliente
        '
        Me.txt_apellido_cliente.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txt_apellido_cliente.Location = New System.Drawing.Point(351, 47)
        Me.txt_apellido_cliente.Name = "txt_apellido_cliente"
        Me.txt_apellido_cliente.Size = New System.Drawing.Size(256, 22)
        Me.txt_apellido_cliente.TabIndex = 109
        '
        'lblApellidoCliente
        '
        Me.lblApellidoCliente.AutoSize = True
        Me.lblApellidoCliente.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblApellidoCliente.Location = New System.Drawing.Point(348, 30)
        Me.lblApellidoCliente.Name = "lblApellidoCliente"
        Me.lblApellidoCliente.Size = New System.Drawing.Size(50, 13)
        Me.lblApellidoCliente.TabIndex = 108
        Me.lblApellidoCliente.Text = "Apellido"
        '
        'txt_idCliente
        '
        Me.txt_idCliente.Enabled = False
        Me.txt_idCliente.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_idCliente.Location = New System.Drawing.Point(85, 158)
        Me.txt_idCliente.Name = "txt_idCliente"
        Me.txt_idCliente.ReadOnly = True
        Me.txt_idCliente.Size = New System.Drawing.Size(218, 25)
        Me.txt_idCliente.TabIndex = 106
        '
        'Label47
        '
        Me.Label47.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label47.ForeColor = System.Drawing.Color.Black
        Me.Label47.Location = New System.Drawing.Point(5, 161)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(78, 23)
        Me.Label47.TabIndex = 105
        Me.Label47.Text = "N° Cliente"
        '
        'cbx_comuna_cliente
        '
        Me.cbx_comuna_cliente.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbx_comuna_cliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_comuna_cliente.Enabled = False
        Me.cbx_comuna_cliente.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.cbx_comuna_cliente.FormattingEnabled = True
        Me.cbx_comuna_cliente.Location = New System.Drawing.Point(138, 130)
        Me.cbx_comuna_cliente.Name = "cbx_comuna_cliente"
        Me.cbx_comuna_cliente.Size = New System.Drawing.Size(145, 23)
        Me.cbx_comuna_cliente.TabIndex = 69
        '
        'cbx_ciudad_cliente
        '
        Me.cbx_ciudad_cliente.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbx_ciudad_cliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_ciudad_cliente.Enabled = False
        Me.cbx_ciudad_cliente.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.cbx_ciudad_cliente.FormattingEnabled = True
        Me.cbx_ciudad_cliente.Location = New System.Drawing.Point(6, 130)
        Me.cbx_ciudad_cliente.Name = "cbx_ciudad_cliente"
        Me.cbx_ciudad_cliente.Size = New System.Drawing.Size(132, 23)
        Me.cbx_ciudad_cliente.TabIndex = 68
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.caja2.My.Resources.Resources.Sin_título
        Me.PictureBox2.Location = New System.Drawing.Point(6, 6)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(20, 24)
        Me.PictureBox2.TabIndex = 98
        Me.PictureBox2.TabStop = False
        '
        'txt_giro_cliente
        '
        Me.txt_giro_cliente.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txt_giro_cliente.Location = New System.Drawing.Point(282, 89)
        Me.txt_giro_cliente.Name = "txt_giro_cliente"
        Me.txt_giro_cliente.Size = New System.Drawing.Size(448, 22)
        Me.txt_giro_cliente.TabIndex = 59
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label26.Location = New System.Drawing.Point(142, 114)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(50, 13)
        Me.Label26.TabIndex = 66
        Me.Label26.Text = "Comuna"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label25.Location = New System.Drawing.Point(3, 114)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(44, 13)
        Me.Label25.TabIndex = 64
        Me.Label25.Text = "Ciudad"
        '
        'txt_email_cliente
        '
        Me.txt_email_cliente.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txt_email_cliente.Location = New System.Drawing.Point(7, 89)
        Me.txt_email_cliente.Name = "txt_email_cliente"
        Me.txt_email_cliente.Size = New System.Drawing.Size(275, 22)
        Me.txt_email_cliente.TabIndex = 63
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label24.Location = New System.Drawing.Point(5, 72)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(34, 13)
        Me.Label24.TabIndex = 62
        Me.Label24.Text = "Email"
        '
        'txt_direccion_cliente
        '
        Me.txt_direccion_cliente.Enabled = False
        Me.txt_direccion_cliente.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_direccion_cliente.Location = New System.Drawing.Point(283, 130)
        Me.txt_direccion_cliente.Name = "txt_direccion_cliente"
        Me.txt_direccion_cliente.Size = New System.Drawing.Size(448, 25)
        Me.txt_direccion_cliente.TabIndex = 61
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label23.Location = New System.Drawing.Point(280, 112)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(55, 13)
        Me.Label23.TabIndex = 60
        Me.Label23.Text = "Dirección"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label21.Location = New System.Drawing.Point(288, 72)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(29, 13)
        Me.Label21.TabIndex = 58
        Me.Label21.Text = "Giro"
        '
        'txt_telefono_cliente
        '
        Me.txt_telefono_cliente.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txt_telefono_cliente.Location = New System.Drawing.Point(613, 47)
        Me.txt_telefono_cliente.Name = "txt_telefono_cliente"
        Me.txt_telefono_cliente.Size = New System.Drawing.Size(118, 22)
        Me.txt_telefono_cliente.TabIndex = 57
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label22.Location = New System.Drawing.Point(610, 29)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(52, 13)
        Me.Label22.TabIndex = 56
        Me.Label22.Text = "Teléfono"
        '
        'txt_nombre_cliente
        '
        Me.txt_nombre_cliente.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txt_nombre_cliente.Location = New System.Drawing.Point(89, 47)
        Me.txt_nombre_cliente.Name = "txt_nombre_cliente"
        Me.txt_nombre_cliente.Size = New System.Drawing.Size(256, 22)
        Me.txt_nombre_cliente.TabIndex = 55
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label19.Location = New System.Drawing.Point(86, 30)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(48, 13)
        Me.Label19.TabIndex = 54
        Me.Label19.Text = "Nombre"
        '
        'txt_rutCliente
        '
        Me.txt_rutCliente.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txt_rutCliente.Location = New System.Drawing.Point(6, 47)
        Me.txt_rutCliente.MaxLength = 10
        Me.txt_rutCliente.Name = "txt_rutCliente"
        Me.txt_rutCliente.Size = New System.Drawing.Size(77, 22)
        Me.txt_rutCliente.TabIndex = 51
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.Label18.Location = New System.Drawing.Point(4, 30)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(28, 13)
        Me.Label18.TabIndex = 50
        Me.Label18.Text = "RUT"
        '
        'lbl_tituloCliente
        '
        Me.lbl_tituloCliente.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lbl_tituloCliente.ForeColor = System.Drawing.Color.Black
        Me.lbl_tituloCliente.Location = New System.Drawing.Point(30, 7)
        Me.lbl_tituloCliente.Margin = New System.Windows.Forms.Padding(0)
        Me.lbl_tituloCliente.Name = "lbl_tituloCliente"
        Me.lbl_tituloCliente.Size = New System.Drawing.Size(231, 21)
        Me.lbl_tituloCliente.TabIndex = 53
        Me.lbl_tituloCliente.Text = "Datos del Cliente"
        Me.lbl_tituloCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnl_totalDocumentos
        '
        Me.pnl_totalDocumentos.Controls.Add(Me.btnGrabarCliente)
        Me.pnl_totalDocumentos.Controls.Add(Me.btnVerDatosCliente)
        Me.pnl_totalDocumentos.Controls.Add(Me.Label45)
        Me.pnl_totalDocumentos.Controls.Add(Me.txt_totalDocumentos)
        Me.pnl_totalDocumentos.Location = New System.Drawing.Point(311, 155)
        Me.pnl_totalDocumentos.Name = "pnl_totalDocumentos"
        Me.pnl_totalDocumentos.Size = New System.Drawing.Size(405, 32)
        Me.pnl_totalDocumentos.TabIndex = 109
        Me.pnl_totalDocumentos.Visible = False
        '
        'btnGrabarCliente
        '
        Me.btnGrabarCliente.BackColor = System.Drawing.Color.SteelBlue
        Me.btnGrabarCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGrabarCliente.FlatAppearance.BorderSize = 0
        Me.btnGrabarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGrabarCliente.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnGrabarCliente.ForeColor = System.Drawing.Color.White
        Me.btnGrabarCliente.Location = New System.Drawing.Point(173, 3)
        Me.btnGrabarCliente.Name = "btnGrabarCliente"
        Me.btnGrabarCliente.Size = New System.Drawing.Size(130, 27)
        Me.btnGrabarCliente.TabIndex = 107
        Me.btnGrabarCliente.Text = "Nuevo Cliente"
        Me.btnGrabarCliente.UseVisualStyleBackColor = False
        '
        'btnVerDatosCliente
        '
        Me.btnVerDatosCliente.BackColor = System.Drawing.Color.SteelBlue
        Me.btnVerDatosCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVerDatosCliente.FlatAppearance.BorderSize = 0
        Me.btnVerDatosCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVerDatosCliente.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btnVerDatosCliente.ForeColor = System.Drawing.Color.White
        Me.btnVerDatosCliente.Location = New System.Drawing.Point(307, 3)
        Me.btnVerDatosCliente.Name = "btnVerDatosCliente"
        Me.btnVerDatosCliente.Size = New System.Drawing.Size(110, 27)
        Me.btnVerDatosCliente.TabIndex = 72
        Me.btnVerDatosCliente.Text = "Ver más..."
        Me.btnVerDatosCliente.UseVisualStyleBackColor = False
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(192, 9)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(97, 20)
        Me.Label45.TabIndex = 52
        Me.Label45.Text = "Total Doctos"
        '
        'txt_totalDocumentos
        '
        Me.txt_totalDocumentos.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        Me.txt_totalDocumentos.Location = New System.Drawing.Point(297, 9)
        Me.txt_totalDocumentos.Name = "txt_totalDocumentos"
        Me.txt_totalDocumentos.Size = New System.Drawing.Size(100, 18)
        Me.txt_totalDocumentos.TabIndex = 53
        Me.txt_totalDocumentos.Text = "$ 0"
        Me.txt_totalDocumentos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVersion
        '
        Me.lblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVersion.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblVersion.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblVersion.Location = New System.Drawing.Point(1224, 703)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(117, 24)
        Me.lblVersion.TabIndex = 102
        Me.lblVersion.Text = "xxxx"
        '
        'btnCierreCaja
        '
        Me.btnCierreCaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCierreCaja.BackColor = System.Drawing.Color.DarkOrange
        Me.btnCierreCaja.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCierreCaja.FlatAppearance.BorderSize = 0
        Me.btnCierreCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCierreCaja.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnCierreCaja.ForeColor = System.Drawing.Color.White
        Me.btnCierreCaja.Location = New System.Drawing.Point(987, 702)
        Me.btnCierreCaja.Name = "btnCierreCaja"
        Me.btnCierreCaja.Size = New System.Drawing.Size(114, 26)
        Me.btnCierreCaja.TabIndex = 51
        Me.btnCierreCaja.Text = "Cierre Caja"
        Me.btnCierreCaja.UseVisualStyleBackColor = False
        '
        'iml_botones_columnas
        '
        Me.iml_botones_columnas.ImageStream = CType(resources.GetObject("iml_botones_columnas.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml_botones_columnas.TransparentColor = System.Drawing.Color.Transparent
        Me.iml_botones_columnas.Images.SetKeyName(0, "eliminar.png")
        Me.iml_botones_columnas.Images.SetKeyName(1, "eliminarDTE16x16.png")
        Me.iml_botones_columnas.Images.SetKeyName(2, "ViewPDF16x16.png")
        Me.iml_botones_columnas.Images.SetKeyName(3, "print.png")
        Me.iml_botones_columnas.Images.SetKeyName(4, "email.png")
        '
        'BancoBindingSource1
        '
        Me.BancoBindingSource1.DataMember = "banco"
        Me.BancoBindingSource1.DataSource = Me.DataSetcatalogoBindingSource
        '
        'Timer1
        '
        Me.Timer1.Interval = 4000
        '
        'Ofd_importar
        '
        Me.Ofd_importar.FileName = "OpenFileDialog1"
        '
        'iml_imagenes_grilla
        '
        Me.iml_imagenes_grilla.ImageStream = CType(resources.GetObject("iml_imagenes_grilla.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml_imagenes_grilla.TransparentColor = System.Drawing.Color.Transparent
        Me.iml_imagenes_grilla.Images.SetKeyName(0, "Car.PNG")
        Me.iml_imagenes_grilla.Images.SetKeyName(1, "White.png")
        '
        'btnMenuAdmin
        '
        Me.btnMenuAdmin.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMenuAdmin.BackColor = System.Drawing.Color.DarkOrange
        Me.btnMenuAdmin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMenuAdmin.FlatAppearance.BorderSize = 0
        Me.btnMenuAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMenuAdmin.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnMenuAdmin.ForeColor = System.Drawing.Color.White
        Me.btnMenuAdmin.Location = New System.Drawing.Point(1107, 702)
        Me.btnMenuAdmin.Name = "btnMenuAdmin"
        Me.btnMenuAdmin.Size = New System.Drawing.Size(114, 26)
        Me.btnMenuAdmin.TabIndex = 111
        Me.btnMenuAdmin.Text = "Menú POS"
        Me.btnMenuAdmin.UseVisualStyleBackColor = False
        '
        'Sp_web_busqueda_generalTableAdapter
        '
        Me.Sp_web_busqueda_generalTableAdapter.ClearBeforeFill = True
        '
        'Vw_web_notaVentaCabTableAdapter
        '
        Me.Vw_web_notaVentaCabTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.bancoTableAdapter = Nothing
        Me.TableAdapterManager.cliente_rangosLineaCreditoTableAdapter = Nothing
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.desis_logTableAdapter = Nothing
        Me.TableAdapterManager.desis_mensajeUsuarioTableAdapter = Nothing
        Me.TableAdapterManager.dte_cabTableAdapter = Nothing
        Me.TableAdapterManager.dte_detTableAdapter = Nothing
        Me.TableAdapterManager.dte_dsc_rcgTableAdapter = Nothing
        Me.TableAdapterManager.dte_refTableAdapter = Nothing
        Me.TableAdapterManager.orsan_codigoRechazoTableAdapter = Nothing
        Me.TableAdapterManager.orsan_logTableAdapter = Nothing
        Me.TableAdapterManager.pos_accionUsuarioTableAdapter = Nothing
        Me.TableAdapterManager.pos_cierreCaja_detTableAdapter = Nothing
        Me.TableAdapterManager.pos_cierreCaja_totalesTableAdapter = Nothing
        Me.TableAdapterManager.pos_codigoPartidaClienteTableAdapter = Nothing
        Me.TableAdapterManager.pos_cuentaDepositoTableAdapter = Nothing
        Me.TableAdapterManager.pos_documentoCabTableAdapter = Nothing
        Me.TableAdapterManager.pos_documentoDetPagoDocTableAdapter = Nothing
        Me.TableAdapterManager.pos_documentoDetPagoTableAdapter = Nothing
        Me.TableAdapterManager.pos_documentoDetTableAdapter = Nothing
        Me.TableAdapterManager.pos_empresaDteTableAdapter = Nothing
        Me.TableAdapterManager.pos_formatoImpresionChequeTableAdapter = Nothing
        Me.TableAdapterManager.pos_sucursalBancoTableAdapter = Nothing
        Me.TableAdapterManager.pos_vencimientoChequeTableAdapter = Nothing
        Me.TableAdapterManager.sap_logTableAdapter = Nothing
        Me.TableAdapterManager.tienda_ciudadTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = caja2.DataSet_catalogoTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.web_ciudadTableAdapter = Nothing
        Me.TableAdapterManager.web_comunaTableAdapter = Nothing
        Me.TableAdapterManager.web_notaVentaCab_marketPlaceTableAdapter = Nothing
        Me.TableAdapterManager.web_notaVentaCabTableAdapter = Nothing
        Me.TableAdapterManager.web_notaVentaDetTableAdapter = Nothing
        Me.TableAdapterManager.web_solicitud_garantia_resolucionTableAdapter = Nothing
        Me.TableAdapterManager.web_solicitud_garantiaTableAdapter = Nothing
        '
        'BancoTableAdapter
        '
        Me.BancoTableAdapter.ClearBeforeFill = True
        '
        'FrmPrincipalAngosto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1350, 729)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.btnMenuAdmin)
        Me.Controls.Add(Me.TabPagos)
        Me.Controls.Add(Me.btnCierreCaja)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "FrmPrincipalAngosto"
        Me.Text = "Sistema de Cajas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabPagos.ResumeLayout(False)
        Me.TbpPago.ResumeLayout(False)
        Me.TbpPago.PerformLayout()
        Me.Panel_BotonesPago.ResumeLayout(False)
        Me.Panel_BotonesMedioPago.ResumeLayout(False)
        CType(Me.DgvDetallePagos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_NotaCredito.ResumeLayout(False)
        Me.Panel_NotaCredito.PerformLayout()
        CType(Me.DgvNotasCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_marketPlace.ResumeLayout(False)
        Me.Panel_marketPlace.PerformLayout()
        Me.Panel_Efectivo.ResumeLayout(False)
        Me.Panel_Efectivo.PerformLayout()
        Me.Panel_Transferencia.ResumeLayout(False)
        Me.Panel_Transferencia.PerformLayout()
        Me.Panel_Cheque.ResumeLayout(False)
        Me.Panel_Cheque.PerformLayout()
        CType(Me.NudFecVencimientoCheque, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Imagen_Validacion_Cheque, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_Tarjeta.ResumeLayout(False)
        Me.Panel_Tarjeta.PerformLayout()
        CType(Me.Label_OK_Tarjeta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_LineaFuncionario.ResumeLayout(False)
        Me.panel_LineaFuncionario.PerformLayout()
        Me.Panel_Anticipos.ResumeLayout(False)
        Me.Panel_Anticipos.PerformLayout()
        CType(Me.DgvAnticipos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_CtaCAREN.ResumeLayout(False)
        Me.Panel_CtaCAREN.PerformLayout()
        CType(Me.DgvDocPorPagar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TbpNotaVenta.ResumeLayout(False)
        Me.TbpNotaVenta.PerformLayout()
        CType(Me.DgvNotasVenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TbpNotaCredito.ResumeLayout(False)
        CType(Me.DgvNotasCreditoWorkflow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VwwebnotaVentaCabBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetcatalogoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet_catalogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BancoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SpwebbusquedageneralBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        CType(Me.Label_OK_Cupon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_totalProductos.ResumeLayout(False)
        Me.pnl_totalProductos.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvDetalleProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imagen_conexion_basedatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_totalDocumentos.ResumeLayout(False)
        Me.pnl_totalDocumentos.PerformLayout()
        CType(Me.BancoBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WebcarroCompra2BindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WebcarroCompra2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WebcarroCompra2BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WebcarroCompra2TableAdapterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabPagos As System.Windows.Forms.TabControl
    Friend WithEvents TbpNotaVenta As System.Windows.Forms.TabPage
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnFacturar As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnAgregarProducto As System.Windows.Forms.Button
    Friend WithEvents txt_codigo_CAREN As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents WbbNotaVenta As System.Windows.Forms.WebBrowser
    Friend WithEvents DgvNotasVenta As System.Windows.Forms.DataGridView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents DgvDetalleProductos As System.Windows.Forms.DataGridView
    Friend WithEvents pnl_totalProductos As System.Windows.Forms.Panel
    Friend WithEvents lbl_totalFinal As System.Windows.Forms.Label
    Friend WithEvents txt_totalNeto As System.Windows.Forms.Label
    Friend WithEvents txt_totalDescuento As System.Windows.Forms.Label
    Friend WithEvents txt_subtotal As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents RadioButton_boleta As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton_factura As System.Windows.Forms.RadioButton
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents cbx_comuna_cliente As System.Windows.Forms.ComboBox
    Friend WithEvents cbx_ciudad_cliente As System.Windows.Forms.ComboBox
    Friend WithEvents txt_giro_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txt_email_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txt_direccion_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txt_telefono_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txt_nombre_cliente As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txt_rutCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lbl_tituloCliente As System.Windows.Forms.Label
    Friend WithEvents Panel_Cheque As System.Windows.Forms.Panel
    Friend WithEvents txt_nroCheque As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cbx_banco As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_numeroCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btnImprimirCheque As System.Windows.Forms.Button
    Friend WithEvents btnValidarCheque As System.Windows.Forms.Button
    Friend WithEvents Panel_Tarjeta As System.Windows.Forms.Panel
    Friend WithEvents btnPagarTarjeta As System.Windows.Forms.Button
    Friend WithEvents txt_cantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DataSetcatalogoBindingSource As BindingSource
    Friend WithEvents DataSet_catalogo As DataSet_catalogo
    Friend WithEvents WebcarroCompra2BindingSource As BindingSource
    'Friend WithEvents Web_carroCompra2TableAdapter As DataSet_catalogoTableAdapters.web_carroCompra2TableAdapter
    Friend WithEvents WebcarroCompra2BindingSource1 As BindingSource
    Friend WithEvents WebcarroCompra2TableAdapterBindingSource As BindingSource
    Friend WithEvents txt_totalDescuentoCupon As Label
    Friend WithEvents txt_totalIva As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents WebcarroCompra2BindingSource2 As BindingSource
    'Friend WithEvents Web_carroCompra2TableAdapter1 As DataSet_catalogoTableAdapters.web_carroCompra2TableAdapter
    Friend WithEvents btnCierreCaja As Button
    Friend WithEvents TbpPago As TabPage
    Friend WithEvents SpwebbusquedageneralBindingSource As BindingSource
    Friend WithEvents Sp_web_busqueda_generalTableAdapter As DataSet_catalogoTableAdapters.sp_web_busqueda_generalTableAdapter
    Friend WithEvents Panel_BotonesPago As Panel
    Friend WithEvents lblTituloPago As Label
    Friend WithEvents btnRestablecer As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents txt_vendedor As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txt_nombreCajero As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txt_NotaVenta As TextBox
    Friend WithEvents lbl_docOrigen As Label
    Friend WithEvents txt_OC As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents txt_cupon As TextBox
    Friend WithEvents DgvDetallePagos As DataGridView
    Friend WithEvents DtpFechaVencCheque As DateTimePicker
    Friend WithEvents Label28 As Label
    Friend WithEvents btnAgregarCheque As Button
    Friend WithEvents txt_montoCheque As TextBox
    Friend WithEvents Label40 As Label
    Friend WithEvents Panel_CtaCAREN As Panel
    Friend WithEvents btnAgregarMontoCuenta As Button
    Friend WithEvents txt_montoLineaCredito As TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents Button12 As Button
    Friend WithEvents txt_montoTarjeta As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents Panel_Efectivo As Panel
    Friend WithEvents txt_vueltoEfectivo As TextBox
    Friend WithEvents Label42 As Label
    Friend WithEvents btnAgregarEfectivo As Button
    Friend WithEvents txt_montoEfectivo As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents Panel_Transferencia As Panel
    Friend WithEvents txt_montoTransferencia As TextBox
    Friend WithEvents Label44 As Label
    Friend WithEvents cbx_bcoTransferencia As ComboBox
    Friend WithEvents Label38 As Label
    Friend WithEvents txt_numeroOperacion As TextBox
    Friend WithEvents Label43 As Label
    Friend WithEvents iml_botones_columnas As ImageList
    Friend WithEvents Label46 As Label
    Friend WithEvents DgvDocPorPagar As DataGridView
    Friend WithEvents btnVerDatosCliente As Button
    Friend WithEvents btnBuscarProducto As Button
    Friend WithEvents Panel7 As Panel
    Friend WithEvents lbl_total As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents lbl_Saldo As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents lbl_pago As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents lbl_totalDocumentos As Label
    Friend WithEvents Label49 As Label
    Friend WithEvents lbl_totalPedido As Label
    Friend WithEvents Label55 As Label
    Friend WithEvents btnFiltrarNotaVenta As Button
    Friend WithEvents txt_nombreClienteNV As TextBox
    Friend WithEvents Label53 As Label
    Friend WithEvents txt_numeroNV As TextBox
    Friend WithEvents Label52 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label_OK_Tarjeta As PictureBox
    Friend WithEvents Imagen_Validacion_Cheque As PictureBox
    Friend WithEvents Label_OK_Cupon As PictureBox
    Friend WithEvents lblVersion As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents chk_emailDocumento As CheckBox
    Friend WithEvents chk_imprimirDocumento As CheckBox
    Friend WithEvents Vw_web_notaVentaCabTableAdapter As DataSet_catalogoTableAdapters.vw_web_notaVentaCabTableAdapter
    Friend WithEvents TableAdapterManager As DataSet_catalogoTableAdapters.TableAdapterManager
    Friend WithEvents VwwebnotaVentaCabBindingSource As BindingSource
    Friend WithEvents BancoBindingSource As BindingSource
    Friend WithEvents BancoTableAdapter As DataSet_catalogoTableAdapters.bancoTableAdapter
    Friend WithEvents BancoBindingSource1 As BindingSource
    Friend WithEvents CmbEstadoNotaVenta As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents txt_codigoAutorizacion As TextBox
    Friend WithEvents Ofd_importar As OpenFileDialog
    Friend WithEvents lbl_codigoAutorizacion As Label
    Friend WithEvents btnAgregarTransferencia As Button
    Friend WithEvents btnAdjuntarComprobante As Button
    Friend WithEvents txt_medioPago As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txt_nombreArchivoComprobante As TextBox
    Friend WithEvents txt_rutGirador As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents cmbTipoDoc As ComboBox
    Friend WithEvents txt_FolioPagar As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents btnFiltrarPagos As Button
    Friend WithEvents txt_idCliente As TextBox
    Friend WithEvents Label47 As Label
    Friend WithEvents Panel_NotaCredito As Panel
    Friend WithEvents btnAgregarNotaCredito As Button
    Friend WithEvents cbx_notasCredito As ComboBox
    Friend WithEvents lblTituloNotaCredito As Label
    Friend WithEvents Panel_Anticipos As Panel
    Friend WithEvents btnAgregarAnticipo As Button
    Friend WithEvents cbx_abonos As ComboBox
    Friend WithEvents Anticipos As Label
    Friend WithEvents btnGrabarCliente As Button
    Friend WithEvents DgvNotasCredito As DataGridView
    Friend WithEvents txt_apellido_cliente As TextBox
    Friend WithEvents lblApellidoCliente As Label
    Friend WithEvents TbpNotaCredito As TabPage
    Friend WithEvents DgvNotasCreditoWorkflow As DataGridView
    Friend WithEvents Label50 As Label
    Friend WithEvents cbx_plazaBanco As ComboBox
    Friend WithEvents txt_montoTotalCheques As TextBox
    Friend WithEvents Label54 As Label
    Friend WithEvents btnEscanearCheque As Button
    Friend WithEvents btnChequeSiguiente As Button
    Friend WithEvents btnChequeAnterior As Button
    Friend WithEvents lblPosicionCheque As Label
    Friend WithEvents cbx_tipoVencimientoCheque As ComboBox
    Friend WithEvents Label56 As Label
    Friend WithEvents lblCantidadCheques As Label
    Friend WithEvents Label58 As Label
    Friend WithEvents lblNumeroDocumento As Label
    Friend WithEvents txt_datosDespacho As TextBox
    Friend WithEvents lblDatosDespacho As Label
    Friend WithEvents Panel_marketPlace As Panel
    Friend WithEvents Label60 As Label
    Friend WithEvents cbx_marketPlace As ComboBox
    Friend WithEvents btnAgregarMontoMarketPlace As Button
    Friend WithEvents txt_montoMarketPlace As TextBox
    Friend WithEvents Label59 As Label
    Friend WithEvents btnPagarDocumentos As Button
    Friend WithEvents iml_imagenes_grilla As ImageList
    Friend WithEvents pnl_totalDocumentos As Panel
    Friend WithEvents txt_totalDocumentos As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents TipoDocOrigen As DataGridViewTextBoxColumn
    Friend WithEvents TipoDocImagen As DataGridViewButtonColumn
    Friend WithEvents colNumeroNVOS As DataGridViewTextBoxColumn
    Friend WithEvents colFechaNVOS As DataGridViewTextBoxColumn
    Friend WithEvents nvc_totalFinal As DataGridViewTextBoxColumn
    Friend WithEvents colNombreClienteNVOS As DataGridViewTextBoxColumn
    Friend WithEvents colRut As DataGridViewTextBoxColumn
    Friend WithEvents colEMail As DataGridViewTextBoxColumn
    Friend WithEvents colTelefono As DataGridViewTextBoxColumn
    Friend WithEvents estado As DataGridViewTextBoxColumn
    Friend WithEvents nombreEstado As DataGridViewTextBoxColumn
    Friend WithEvents DgvAnticipos As DataGridView
    Friend WithEvents ColAntTipoDoc As DataGridViewTextBoxColumn
    Friend WithEvents ColAntNumeroDoc As DataGridViewTextBoxColumn
    Friend WithEvents ColAntFechaEmision As DataGridViewTextBoxColumn
    Friend WithEvents ColAntValor As DataGridViewTextBoxColumn
    Friend WithEvents ColAntFacturaAsoc As DataGridViewTextBoxColumn
    Friend WithEvents ColAntNumeroSAP As DataGridViewTextBoxColumn
    Friend WithEvents ColAntCodEmpresa As DataGridViewTextBoxColumn
    Friend WithEvents ColAntEjercicio As DataGridViewTextBoxColumn
    Friend WithEvents chk_anticipo As CheckBox
    Friend WithEvents panel_LineaFuncionario As Panel
    Friend WithEvents btnAgregarMontoFuncionario As Button
    Friend WithEvents txt_montoLineaFuncionario As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents ColNCTipoDoc As DataGridViewTextBoxColumn
    Friend WithEvents ColNCNumeroDoc As DataGridViewTextBoxColumn
    Friend WithEvents ColNCFechaEmision As DataGridViewTextBoxColumn
    Friend WithEvents ColNCValor As DataGridViewTextBoxColumn
    Friend WithEvents ColNCFactura As DataGridViewTextBoxColumn
    Friend WithEvents ColNCNumeroSap As DataGridViewTextBoxColumn
    Friend WithEvents ColNCCodEmpresa As DataGridViewTextBoxColumn
    Friend WithEvents ColNCEjercicio As DataGridViewTextBoxColumn
    Friend WithEvents ColNumero As DataGridViewTextBoxColumn
    Friend WithEvents ColFecha As DataGridViewTextBoxColumn
    Friend WithEvents ColRutCliente As DataGridViewTextBoxColumn
    Friend WithEvents ColNombreCliente As DataGridViewTextBoxColumn
    Friend WithEvents ColMontoTotal As DataGridViewTextBoxColumn
    Friend WithEvents colNombreEstado As DataGridViewTextBoxColumn
    Friend WithEvents colEstado As DataGridViewTextBoxColumn
    Friend WithEvents ColTipoDte As DataGridViewTextBoxColumn
    Friend WithEvents ColFolioDte As DataGridViewTextBoxColumn
    Friend WithEvents RadioButton_notaCredito As RadioButton
    Friend WithEvents cmbTipoTarjetaCredito As ComboBox
    Friend WithEvents lblTipoTarjeta As Label
    Friend WithEvents txt_AutorizacionTarjeta As TextBox
    Friend WithEvents lblAutorizacionTarjeta As Label
    Friend WithEvents rdbPagoManual As RadioButton
    Friend WithEvents rdbPagoSerial As RadioButton
    Friend WithEvents txt_NumeroTarjeta As TextBox
    Friend WithEvents lblTituloNumeroTarjeta As Label
    Friend WithEvents lbl_redondeoEfectivo As Label
    Friend WithEvents Label62 As Label
    Friend WithEvents lbl_efectivoRedondeado As Label
    Friend WithEvents Label64 As Label
    Friend WithEvents txt_NumeroCuotas As TextBox
    Friend WithEvents lblNumeroCuotas As Label
    Friend WithEvents cbx_direcciones_cliente As ComboBox
    Friend WithEvents NudFecVencimientoCheque As NumericUpDown
    Friend WithEvents btnMenuAdmin As Button
    Friend WithEvents Sel As DataGridViewCheckBoxColumn
    Friend WithEvents TipoDoc As DataGridViewTextBoxColumn
    Friend WithEvents Folio As DataGridViewTextBoxColumn
    Friend WithEvents Fecha As DataGridViewTextBoxColumn
    Friend WithEvents FechaVto As DataGridViewTextBoxColumn
    Friend WithEvents Monto As DataGridViewTextBoxColumn
    Friend WithEvents Morosidad As DataGridViewTextBoxColumn
    Friend WithEvents Bloqueado As DataGridViewTextBoxColumn
    Friend WithEvents CME As DataGridViewTextBoxColumn
    Friend WithEvents Numero_SAP As DataGridViewTextBoxColumn
    Friend WithEvents Numero_NotaVenta As DataGridViewTextBoxColumn
    Friend WithEvents Nombre_Banco As DataGridViewTextBoxColumn
    Friend WithEvents Cod_Autorizacion As DataGridViewTextBoxColumn
    Friend WithEvents Imprimir As DataGridViewButtonColumn
    Friend WithEvents Correo As DataGridViewButtonColumn
    Friend WithEvents lbl_codigoRechazoOrsan As Label
    Friend WithEvents col_tipoMedioPago As DataGridViewTextBoxColumn
    Friend WithEvents col_monto As DataGridViewTextBoxColumn
    Friend WithEvents col_detalle As DataGridViewTextBoxColumn
    Friend WithEvents Comprobante As DataGridViewButtonColumn
    Friend WithEvents col_montoOriginal As DataGridViewTextBoxColumn
    Friend WithEvents col_numeroOperacion As DataGridViewTextBoxColumn
    Friend WithEvents col_numCheque As DataGridViewTextBoxColumn
    Friend WithEvents col_fechaCheque As DataGridViewTextBoxColumn
    Friend WithEvents col_bancoCheque As DataGridViewTextBoxColumn
    Friend WithEvents col_NroOrsan As DataGridViewTextBoxColumn
    Friend WithEvents col_nroCuenta As DataGridViewTextBoxColumn
    Friend WithEvents col_rutGirador As DataGridViewTextBoxColumn
    Friend WithEvents col_codEmpresa As DataGridViewTextBoxColumn
    Friend WithEvents col_ejercicio As DataGridViewTextBoxColumn
    Friend WithEvents col_numeroSAP As DataGridViewTextBoxColumn
    Friend WithEvents col_montoRedondeo As DataGridViewTextBoxColumn
    Friend WithEvents ColNumeroTarjeta As DataGridViewTextBoxColumn
    Friend WithEvents ColIDTerminal As DataGridViewTextBoxColumn
    Friend WithEvents ColNumeroCuotas As DataGridViewTextBoxColumn
    Friend WithEvents col_correlativo As DataGridViewTextBoxColumn
    Friend WithEvents col_CodigoRechazoOrsan As DataGridViewTextBoxColumn
    Friend WithEvents btnImprimir As Button
    Friend WithEvents imagen_conexion_basedatos As PictureBox
    Friend WithEvents lblReintento As Label
    Friend WithEvents colCodigo As DataGridViewTextBoxColumn
    Friend WithEvents colDescrip As DataGridViewTextBoxColumn
    Friend WithEvents colCantidad As DataGridViewTextBoxColumn
    Friend WithEvents colUnitarioNeto As DataGridViewTextBoxColumn
    Friend WithEvents colTotalNeto As DataGridViewTextBoxColumn
    Friend WithEvents colTotal As DataGridViewTextBoxColumn
    Friend WithEvents lbl_vuelto As Label
    Friend WithEvents Label57 As Label
    Friend WithEvents Panel_BotonesMedioPago As Panel
    Friend WithEvents lbl_creditoDispCliente As Label
    Friend WithEvents btnEfectivo As Button
    Friend WithEvents btnAnticipos As Button
    Friend WithEvents btnTarjeta As Button
    Friend WithEvents btnTransferencia As Button
    Friend WithEvents btnLineaFuncionario As Button
    Friend WithEvents btnMarketPlace As Button
    Friend WithEvents btnCheque As Button
    Friend WithEvents btnValeVista As Button
    Friend WithEvents btnLineaCredito As Button
    Friend WithEvents btnNotaCredito As Button
End Class
