<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotaCredito
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
        Me.btnCrearNotaCredito = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.rdbAnularDocumento = New System.Windows.Forms.RadioButton()
        Me.rdbCorrigeTextoDocumento = New System.Windows.Forms.RadioButton()
        Me.rdbCorrigeMontosDocumento = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTipoDocumento = New System.Windows.Forms.Label()
        Me.lblNumeroDocumento = New System.Windows.Forms.Label()
        Me.lblTotalDocumento = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCrearNotaCredito
        '
        Me.btnCrearNotaCredito.Location = New System.Drawing.Point(305, 167)
        Me.btnCrearNotaCredito.Name = "btnCrearNotaCredito"
        Me.btnCrearNotaCredito.Size = New System.Drawing.Size(151, 23)
        Me.btnCrearNotaCredito.TabIndex = 0
        Me.btnCrearNotaCredito.Text = "Crear Nota de Crédito"
        Me.btnCrearNotaCredito.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Location = New System.Drawing.Point(28, 48)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(123, 25)
        Me.Label14.TabIndex = 65
        Me.Label14.Text = "Motivo Referencia"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rdbAnularDocumento
        '
        Me.rdbAnularDocumento.Location = New System.Drawing.Point(174, 48)
        Me.rdbAnularDocumento.Name = "rdbAnularDocumento"
        Me.rdbAnularDocumento.Size = New System.Drawing.Size(125, 24)
        Me.rdbAnularDocumento.TabIndex = 66
        Me.rdbAnularDocumento.TabStop = True
        Me.rdbAnularDocumento.Text = "Anular Documento"
        Me.rdbAnularDocumento.UseVisualStyleBackColor = True
        '
        'rdbCorrigeTextoDocumento
        '
        Me.rdbCorrigeTextoDocumento.Location = New System.Drawing.Point(305, 49)
        Me.rdbCorrigeTextoDocumento.Name = "rdbCorrigeTextoDocumento"
        Me.rdbCorrigeTextoDocumento.Size = New System.Drawing.Size(163, 24)
        Me.rdbCorrigeTextoDocumento.TabIndex = 67
        Me.rdbCorrigeTextoDocumento.TabStop = True
        Me.rdbCorrigeTextoDocumento.Text = "Corrige Texto de Documento"
        Me.rdbCorrigeTextoDocumento.UseVisualStyleBackColor = True
        '
        'rdbCorrigeMontosDocumento
        '
        Me.rdbCorrigeMontosDocumento.Location = New System.Drawing.Point(489, 49)
        Me.rdbCorrigeMontosDocumento.Name = "rdbCorrigeMontosDocumento"
        Me.rdbCorrigeMontosDocumento.Size = New System.Drawing.Size(190, 24)
        Me.rdbCorrigeMontosDocumento.TabIndex = 68
        Me.rdbCorrigeMontosDocumento.TabStop = True
        Me.rdbCorrigeMontosDocumento.Text = "Corrige Monto de Documento"
        Me.rdbCorrigeMontosDocumento.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(28, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 25)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Documento Origen"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTipoDocumento
        '
        Me.lblTipoDocumento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipoDocumento.Location = New System.Drawing.Point(171, 96)
        Me.lblTipoDocumento.Name = "lblTipoDocumento"
        Me.lblTipoDocumento.Size = New System.Drawing.Size(176, 23)
        Me.lblTipoDocumento.TabIndex = 70
        '
        'lblNumeroDocumento
        '
        Me.lblNumeroDocumento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumeroDocumento.Location = New System.Drawing.Point(353, 96)
        Me.lblNumeroDocumento.Name = "lblNumeroDocumento"
        Me.lblNumeroDocumento.Size = New System.Drawing.Size(115, 23)
        Me.lblNumeroDocumento.TabIndex = 71
        '
        'lblTotalDocumento
        '
        Me.lblTotalDocumento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalDocumento.Location = New System.Drawing.Point(474, 96)
        Me.lblTotalDocumento.Name = "lblTotalDocumento"
        Me.lblTotalDocumento.Size = New System.Drawing.Size(115, 23)
        Me.lblTotalDocumento.TabIndex = 72
        '
        'frmNotaCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 270)
        Me.Controls.Add(Me.lblTotalDocumento)
        Me.Controls.Add(Me.lblNumeroDocumento)
        Me.Controls.Add(Me.lblTipoDocumento)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rdbCorrigeMontosDocumento)
        Me.Controls.Add(Me.rdbCorrigeTextoDocumento)
        Me.Controls.Add(Me.rdbAnularDocumento)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.btnCrearNotaCredito)
        Me.Name = "frmNotaCredito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmNotaCredito"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCrearNotaCredito As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents rdbAnularDocumento As RadioButton
    Friend WithEvents rdbCorrigeTextoDocumento As RadioButton
    Friend WithEvents rdbCorrigeMontosDocumento As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents lblTipoDocumento As Label
    Friend WithEvents lblNumeroDocumento As Label
    Friend WithEvents lblTotalDocumento As Label
End Class
