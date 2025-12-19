Public Class frmNotaCredito

    Public tipoDocumento As String = ""
    Public numeroDocumento As Integer = 0
    Public totalDocumento As Double = 0

    Private Sub frmNotaCredito_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblTipoDocumento.Text = tipoDocumento
        lblNumeroDocumento.Text = numeroDocumento.ToString()
        lblTotalDocumento.Text = totalDocumento.ToString()
    End Sub

    Private Sub btnCrearNotaCredito_Click(sender As Object, e As EventArgs) Handles btnCrearNotaCredito.Click
        Dim frmPrincipal As FrmPrincipal = Nothing

        frmPrincipal = Me.Owner.Owner
        If Not frmPrincipal Is Nothing Then
            frmPrincipal.cbx_notasCredito.Items.Add((" " & frmPrincipal.cbx_notasCredito.Items.Count() + 1).ToString() & " / " & Now.ToString("dd-MM-yyyy") & " / " & totalDocumento.ToString("$ #,##0"))
            MessageBox.Show("Nota de Crédito " & frmPrincipal.cbx_notasCredito.Items.Count().ToString() & " creada correctamente", "Nota de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
    End Sub
End Class