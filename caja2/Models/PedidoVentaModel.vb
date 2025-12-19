Imports CarenSap

Public Class PedidoVentaModel

    Public Property IDlvDate As String
    Public Property IDlvType As String
    Public Property ILifex As String
    Public Property IShipPoint As String
    Public Property IShipTo As String
    Public Property IDlvItems As Idlvitem()

    Public Sub New(dlvDate As String, dlvType As String, lifex As String, shipPoint As String, shipTo As String, dlvItems As Idlvitem())
        IDlvDate = dlvDate
        IDlvType = dlvType
        ILifex = lifex
        IShipPoint = shipPoint
        IShipTo = shipTo
        IDlvItems = dlvItems
    End Sub
End Class

Public Class Idlvitem
    Public Property Material As String
    Public Property DlvQty As String
    Public Property SalesUnit As String
    Public Property Plant As String

    Public Sub New(material As String, dlvQty As String, salesUnit As String, plant As String)
        Me.Material = material
        Me.DlvQty = dlvQty
        Me.SalesUnit = salesUnit
        Me.Plant = plant
    End Sub
End Class

