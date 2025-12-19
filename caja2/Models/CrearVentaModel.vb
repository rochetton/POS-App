Imports caja2

Public Class CrearVentaModel

    Public Property Tienda As String
    Public Property TipoDoc As String
    Public Property Caja As String
    Public Property Fecha As String
    Public Property NumDTE As String
    Public Property Cliente As String
    Public Property Cajero As String
    Public Property Moneda As String
    Public Property Vendedor As String
    Public Property Nota_Venta As String
    Public Property Tienda_Stock As String
    Public Property Tienda_Despacho As String
    Public Property Id_Entrega As String
    Public Property GrupoVendedor As String
    Public Property Despachado_a As String
    Public Property Dir_despacho As String
    Public Property FechaEntrega As String
    Public Property Canal_Venta As String
    Public Property Anticipo As String
    Public Property Num_OC As String
    Public Property Fecha_OC As String
    Public Property Observaciones As String
    Public Property Transportista As String
    Public Property Vendedor_Retira As String
    Public Property Tipo_Transporte As String
    Public Property Posiciones As Posicion()
    Public Property Pago As PagoModel()

    Public Sub New()
        'constructor predeterminado
    End Sub

    Public Sub New(tienda As String, tipoDoc As String, caja As String, fecha As String, numDTE As String, cliente As String, cajero As String, moneda As String, vendedor As String, nota_Venta As String, tienda_Stock As String,
                   tienda_Despacho As String, id_Entrega As String, grupoVendedor As String, despachado_a As String, dir_despacho As String, fechaEntrega As String, canal_Venta As String, anticipo As String, num_OC As String,
                   fecha_OC As String, observaciones As String, transportista As String, vendedor_Retira As String, tipo_Transporte As String, posiciones() As Posicion, pago() As PagoModel)
        Me.Tienda = tienda
        Me.TipoDoc = tipoDoc
        Me.Caja = caja
        Me.Fecha = fecha
        Me.NumDTE = numDTE
        Me.Cliente = cliente
        Me.Cajero = cajero
        Me.Moneda = moneda
        Me.Vendedor = vendedor
        Me.Nota_Venta = nota_Venta
        Me.Tienda_Stock = tienda_Stock
        Me.Tienda_Despacho = tienda_Despacho
        Me.Id_Entrega = id_Entrega
        Me.GrupoVendedor = grupoVendedor
        Me.Despachado_a = despachado_a
        Me.Dir_despacho = dir_despacho
        Me.FechaEntrega = fechaEntrega
        Me.Canal_Venta = canal_Venta
        Me.Anticipo = anticipo
        Me.Num_OC = num_OC
        Me.Fecha_OC = fecha_OC
        Me.Observaciones = observaciones
        Me.Transportista = transportista
        Me.Vendedor_Retira = vendedor_Retira
        Me.Tipo_Transporte = tipo_Transporte
        Me.Posiciones = posiciones
        Me.Pago = pago
    End Sub
End Class

Public Class Posicion
    Public Property Tipo As String
    Public Property Material As String
    Public Property Cantidad As String
    Public Property Precios As Precio()
    Public Property Adicionales As Adicionales

    Public Sub New()
        'constructor predeterminado
    End Sub

    Public Sub New(tipo As String, material As String, cantidad As String, precios() As Precio, adicionales As Adicionales)
        Me.Tipo = tipo
        Me.Material = material
        Me.Cantidad = cantidad
        Me.Precios = precios
        Me.Adicionales = adicionales
    End Sub
End Class

Public Class Precio
    Public Property Id As String
    Public Property Monto As Integer

    Public Sub New()
        'constructor predeterminado
    End Sub

    Public Sub New(id As String, monto As Integer)
        Me.Id = id
        Me.Monto = monto
    End Sub
End Class

Public Class Adicionales
    Public Property OrdenServicio As String

    Public Sub New()
        'constructor predeterminado
    End Sub

    Public Sub New(ordenServicio As String)
        Me.OrdenServicio = ordenServicio
    End Sub
End Class

Public Class PagoModel
    Public Property Medio_pago As String
    Public Property Importe As Integer
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
    Public Property Terminal As String
    Public Property Cuotas As String
    Public Property Num_Tarjeta As String

    Public Sub New()
        'constructor predeterminado
    End Sub

    Public Sub New(medio_pago As String, importe As Integer, num_Oper As String, soc_SAP As String, ejercicio_SAP As String, documento_SAP As String, num_Cheque As String, fecha_Cheque As String, banco_Cheque As String, nro_Orsan As String,
                   rutGirador As String, numCuenta As String, terminal As String, cuotas As String, num_Tarjeta As String)
        Me.Medio_pago = medio_pago
        Me.Importe = importe
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
        Me.Terminal = terminal
        Me.Cuotas = cuotas
        Me.Num_Tarjeta = num_Tarjeta
    End Sub

End Class




