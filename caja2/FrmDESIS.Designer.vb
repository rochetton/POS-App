<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDESIS
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
        Me.btnProcesarDTE = New System.Windows.Forms.Button()
        Me.txtResultado = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnProcesarDTE
        '
        Me.btnProcesarDTE.Location = New System.Drawing.Point(310, 125)
        Me.btnProcesarDTE.Name = "btnProcesarDTE"
        Me.btnProcesarDTE.Size = New System.Drawing.Size(171, 23)
        Me.btnProcesarDTE.TabIndex = 0
        Me.btnProcesarDTE.Text = "Procesar DTE"
        Me.btnProcesarDTE.UseVisualStyleBackColor = True
        '
        'txtResultado
        '
        Me.txtResultado.Location = New System.Drawing.Point(138, 200)
        Me.txtResultado.Multiline = True
        Me.txtResultado.Name = "txtResultado"
        Me.txtResultado.Size = New System.Drawing.Size(535, 250)
        Me.txtResultado.TabIndex = 1
        '
        'FrmDESIS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(823, 497)
        Me.Controls.Add(Me.txtResultado)
        Me.Controls.Add(Me.btnProcesarDTE)
        Me.Name = "FrmDESIS"
        Me.Text = "FrmDESIS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnProcesarDTE As Button
    Friend WithEvents txtResultado As TextBox
End Class
