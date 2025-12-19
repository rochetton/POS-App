Imports System.Runtime.CompilerServices
Imports System.Globalization

Namespace ExtensionesTipo

    Public Module StringExtensions

        <Extension()> Public Function ToNullableInt(texto As String) As Nullable(Of Integer)
            Dim result As Global.System.Nullable(Of Integer)

            If String.IsNullOrEmpty(texto) = False Then
                result = CType(texto, Integer)
            End If

            Return result
        End Function

        <Extension()> Public Function ToNullableSingle(texto As String) As Nullable(Of Single)
            Dim result As Global.System.Nullable(Of Single)

            If String.IsNullOrEmpty(texto) = False Then
                result = CType(texto, Single)
            End If

            Return result
        End Function

        <Extension()> Public Function ToNullableDouble(texto As String) As Nullable(Of Double)
            Dim result As Global.System.Nullable(Of Double)

            If String.IsNullOrEmpty(texto) = False Then
                result = CType(texto, Double)
            End If

            Return result
        End Function

        <Extension()> Public Function ToNullableDateTime(texto As String, Optional format As String = "dd-MM-yyyy") As Nullable(Of DateTime)
            Dim result As Global.System.Nullable(Of DateTime)

            Try
                If String.IsNullOrEmpty(texto) = False Then
                    result = DateTime.ParseExact(texto, format, CultureInfo.InvariantCulture)
                End If
            Catch ex As Exception
            End Try

            Return result
        End Function

        <Extension()> Public Function ToDblEng(texto As String) As Nullable(Of Double)
            Dim result As Global.System.Nullable(Of Double)
            Dim nbfInfo As NumberFormatInfo = Nothing

            If String.IsNullOrEmpty(texto) = False Then
                nbfInfo = New NumberFormatInfo()
                nbfInfo.NumberDecimalSeparator = "." 'utilizamos el separador decimal US-English 
                nbfInfo.NumberGroupSeparator = ","   'utilizamos el separador de miles US-English 
                result = Convert.ToDouble(texto, nbfInfo)
            End If

            Return result
        End Function

        <Extension()> Public Function ToIntEng(texto As String) As Nullable(Of Integer)
            Dim result As Global.System.Nullable(Of Integer)
            Dim nbfInfo As NumberFormatInfo = Nothing

            If String.IsNullOrEmpty(texto) = False Then
                nbfInfo = New NumberFormatInfo()
                nbfInfo.NumberDecimalSeparator = "." 'utilizamos el separador decimal US-English 
                nbfInfo.NumberGroupSeparator = ","   'utilizamos el separador de miles US-English 
                result = Convert.ToInt32(texto, nbfInfo)
            End If

            Return result
        End Function

    End Module

End Namespace

