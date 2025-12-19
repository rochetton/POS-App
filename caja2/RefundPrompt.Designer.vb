<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RefundPrompt
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.accept = New System.Windows.Forms.Button()
        Me.closeButton = New System.Windows.Forms.Button()
        Me.opInputText = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'accept
        '
        Me.accept.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.accept.Location = New System.Drawing.Point(97, 126)
        Me.accept.Name = "accept"
        Me.accept.Size = New System.Drawing.Size(75, 23)
        Me.accept.TabIndex = 0
        Me.accept.Text = "Aceptar"
        Me.accept.UseVisualStyleBackColor = True
        '
        'closeButton
        '
        Me.closeButton.Location = New System.Drawing.Point(178, 126)
        Me.closeButton.Name = "closeButton"
        Me.closeButton.Size = New System.Drawing.Size(75, 23)
        Me.closeButton.TabIndex = 1
        Me.closeButton.Text = "Cerrar"
        Me.closeButton.UseVisualStyleBackColor = True
        '
        'opInputText
        '
        Me.opInputText.Location = New System.Drawing.Point(97, 73)
        Me.opInputText.Name = "opInputText"
        Me.opInputText.Size = New System.Drawing.Size(156, 20)
        Me.opInputText.TabIndex = 2
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(73, 42)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(208, 13)
        Me.label1.TabIndex = 3
        Me.label1.Text = "Ingrese el número de la operación a anular"
        '
        'RefundPrompt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(347, 188)
        Me.ControlBox = False
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.opInputText)
        Me.Controls.Add(Me.closeButton)
        Me.Controls.Add(Me.accept)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "RefundPrompt"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Anulación de Transacción"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private accept As System.Windows.Forms.Button
    Private Shadows closeButton As System.Windows.Forms.Button
    Private opInputText As System.Windows.Forms.TextBox
    Private label1 As System.Windows.Forms.Label
End Class
