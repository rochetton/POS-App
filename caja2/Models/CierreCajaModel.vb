Public Class CierreCajaModel

    Public Property Tienda As String
    Public Property Fecha_Operacion As String
    Public Property Orsan_G As String
    Public Property Banco As String
    Public Property Num_Deposito As String
    Public Property Efectivo As String
    Public Property Cheques As Cheque()

    Public Sub New()
        'constructor predeterminado
    End Sub

    Public Sub New(tienda As String, fecha_Operacion As String, orsan_G As String, banco As String, num_Deposito As String, efectivo As String, cheques As Cheque())
        Me.Tienda = tienda
        Me.Fecha_Operacion = fecha_Operacion
        Me.Orsan_G = orsan_G
        Me.Banco = banco
        Me.Num_Deposito = num_Deposito
        Me.Efectivo = efectivo
        Me.Cheques = cheques
    End Sub
End Class

Public Class Cheque
    Public Property Importe As String
    Public Property Moneda As String
    Public Property Cliente As String
    Public Property Num_Cheque As String
    Public Property Fecha_Cheque As String
    Public Property Banco_Cheque As String
    Public Property Nro_Orsan As String

    Public Sub New()
        'constructor predeterminado
    End Sub

    Public Sub New(importe As String, moneda As String, cliente As String, num_Cheque As String, fecha_Cheque As String, banco_Cheque As String, nro_Orsan As String)
        Me.Importe = importe
        Me.Moneda = moneda
        Me.Cliente = cliente
        Me.Num_Cheque = num_Cheque
        Me.Fecha_Cheque = fecha_Cheque
        Me.Banco_Cheque = banco_Cheque
        Me.Nro_Orsan = nro_Orsan
    End Sub
End Class

