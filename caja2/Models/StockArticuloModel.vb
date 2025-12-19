Public Class StockArticuloModel

    Public Property ET_STOCK_DISP As ET_STOCK_DISP_ART

    Public Class ET_STOCK_DISP_ART
        Public Property item As Item()
    End Class

    Public Class Item
        Public Property TIENDA As String
        Public Property DISPONIBLE As String
        Public Property STOCK_CURSO As String
    End Class

End Class


