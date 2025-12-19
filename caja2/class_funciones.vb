Public Class class_funciones

    Public Shared Function validacionRut(ByVal rut As String) As Boolean
        Dim validacion As Boolean = False

        Try
            If rut.Contains("-") = False Then
                Return validacion
            End If

            Dim aRut() As String = Split(rut.Trim().Replace(".", "").Replace(",", ""), "-")
            Dim NumeroTexto As String = aRut(0)
            Dim Resultado As String = ""
            Dim Multiplicador As Integer = 2
            Dim iNum As Integer = 0
            Dim Suma As Integer = 0

            NumeroTexto = NumeroTexto.PadLeft(8, "0")
            For i As Integer = 8 To 1 Step -1
                If i <= NumeroTexto.Length Then
                    iNum = NumeroTexto.Substring(i - 1, 1)
                    Suma += iNum * Multiplicador
                End If
                Multiplicador += 1
                If Multiplicador = 8 Then
                    Multiplicador = 2
                End If
            Next
            Resultado = CStr(11 - (Suma Mod 11))
            If Resultado = "10" Then Resultado = "K"
            If Resultado = "11" Then Resultado = "0"
            validacion = (aRut(1) = Resultado)

        Catch ex As Exception
            Dim mensaje As String = ex.Message
        End Try
        Return validacion
    End Function

End Class
