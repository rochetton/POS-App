Imports CarenSap

Public Class MedioPagoModel

    Public Property Tienda As String
    Public Property Cliente As String
    Public Property Fecha_operacion As String
    Public Property Orsan_G As String
    Public Property Canal_Venta As String
    Public Property Anticipo As String
    Public Property Pagos As Pago()
    Public Property Documentos As Documento()

    Public Sub New()
        'constructor predeterminado
    End Sub

    Public Sub New(tienda As String, cliente As String, fecha_operacion As String, orsan_G As String, canal_Venta As String, anticipo As String, pagos() As Pago, documentos() As Documento)
        Me.Tienda = tienda
        Me.Cliente = cliente
        Me.Fecha_operacion = fecha_operacion
        Me.Orsan_G = orsan_G
        Me.Canal_Venta = canal_Venta
        Me.Anticipo = anticipo
        Me.Pagos = pagos
        Me.Documentos = documentos
    End Sub
End Class

Public Class Pago
    Public Property Medio_pago As String
    Public Property Importe As String
    Public Property Moneda As String
    Public Property Num_Oper As String
    Public Property Soc_SAP As String
    Public Property Ejercicio_SAP As String
    Public Property Documento_SAP As String
    Public Property Num_Cheque As String
    Public Property Fecha_Cheque As String
    Public Property Banco_Cheque As String
    Public Property Nro_Orsan As String
    Public Property RutGirador As String
    Public Property NumCuenta As String

    Public Sub New(medio_pago As String, importe As String, moneda As String, num_Oper As String, soc_SAP As String, ejercicio_SAP As String, documento_SAP As String, num_Cheque As String, fecha_Cheque As String, banco_Cheque As String,
                   nro_Orsan As String, rutGirador As String, numCuenta As String)
        Me.Medio_pago = medio_pago
        Me.Importe = importe
        Me.Moneda = moneda
        Me.Num_Oper = num_Oper
        Me.Soc_SAP = soc_SAP
        Me.Ejercicio_SAP = ejercicio_SAP
        Me.Documento_SAP = documento_SAP
        Me.Num_Cheque = num_Cheque
        Me.Fecha_Cheque = fecha_Cheque
        Me.Banco_Cheque = banco_Cheque
        Me.Nro_Orsan = nro_Orsan
        Me.RutGirador = rutGirador
        Me.NumCuenta = numCuenta
    End Sub
End Class

Public Class Documento
    Public Property Nota_Venta As String
    Public Property Importe_Pago As String
    Public Property Doc_SAP As String

    Public Sub New(Nota_Venta As String, Importe_Pago As String, Doc_SAP As String)
        Me.Nota_Venta = Nota_Venta
        Me.Importe_Pago = Importe_Pago
        Me.Doc_SAP = Doc_SAP
    End Sub

End Class

