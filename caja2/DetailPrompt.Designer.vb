<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DetailPrompt
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
        components = New System.ComponentModel.Container
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Text = "DetailPrompt"

        Me.infoDetailPrompt = New System.Windows.Forms.Label()
        Me.printBtn = New System.Windows.Forms.Button()
        Me.noPrintBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        Me.infoDetailPrompt.AutoSize = True
        Me.infoDetailPrompt.Location = New System.Drawing.Point(174, 60)
        Me.infoDetailPrompt.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.infoDetailPrompt.Name = "infoDetailPrompt"
        Me.infoDetailPrompt.Size = New System.Drawing.Size(328, 25)
        Me.infoDetailPrompt.TabIndex = 0
        Me.infoDetailPrompt.Text = "Obtener listado de transacciones"
        Me.printBtn.Location = New System.Drawing.Point(216, 214)
        Me.printBtn.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.printBtn.Name = "printBtn"
        Me.printBtn.Size = New System.Drawing.Size(240, 44)
        Me.printBtn.TabIndex = 1
        Me.printBtn.Text = "Imprimir en POS"
        Me.printBtn.UseVisualStyleBackColor = True
        AddHandler Me.printBtn.Click, New System.EventHandler(AddressOf Me.printToPOS_Click)
        Me.noPrintBtn.Location = New System.Drawing.Point(216, 132)
        Me.noPrintBtn.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.noPrintBtn.Name = "noPrintBtn"
        Me.noPrintBtn.Size = New System.Drawing.Size(240, 44)
        Me.noPrintBtn.TabIndex = 2
        Me.noPrintBtn.Text = "Por Pantalla"
        Me.noPrintBtn.UseVisualStyleBackColor = True
        AddHandler Me.noPrintBtn.Click, New System.EventHandler(AddressOf Me.noPrintBtn_Click)
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0F, 25.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 362)
        Me.Controls.Add(Me.noPrintBtn)
        Me.Controls.Add(Me.printBtn)
        Me.Controls.Add(Me.infoDetailPrompt)
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Name = "DetailPrompt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle de Ventas"
        AddHandler Me.Load, New System.EventHandler(AddressOf Me.DetailPrompt_Load)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Private infoDetailPrompt As System.Windows.Forms.Label
    Private printBtn As System.Windows.Forms.Button
    Private noPrintBtn As System.Windows.Forms.Button
End Class
