<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMICR
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
        Me.btnExit = New System.Windows.Forms.Button()
        Me.grpInsert = New System.Windows.Forms.GroupBox()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnInsert = New System.Windows.Forms.Button()
        Me.txtRawData = New System.Windows.Forms.TextBox()
        Me.lblRawData = New System.Windows.Forms.Label()
        Me.grpInsert.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(293, 167)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(88, 26)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        '
        'grpInsert
        '
        Me.grpInsert.Controls.Add(Me.btnRemove)
        Me.grpInsert.Controls.Add(Me.btnInsert)
        Me.grpInsert.Controls.Add(Me.txtRawData)
        Me.grpInsert.Controls.Add(Me.lblRawData)
        Me.grpInsert.Location = New System.Drawing.Point(33, 29)
        Me.grpInsert.Name = "grpInsert"
        Me.grpInsert.Size = New System.Drawing.Size(348, 121)
        Me.grpInsert.TabIndex = 2
        Me.grpInsert.TabStop = False
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(220, 69)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(100, 26)
        Me.btnRemove.TabIndex = 3
        Me.btnRemove.Text = "Remove"
        '
        'btnInsert
        '
        Me.btnInsert.Location = New System.Drawing.Point(96, 69)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(100, 26)
        Me.btnInsert.TabIndex = 2
        Me.btnInsert.Text = "Insert"
        '
        'txtRawData
        '
        Me.txtRawData.Location = New System.Drawing.Point(96, 30)
        Me.txtRawData.Name = "txtRawData"
        Me.txtRawData.Size = New System.Drawing.Size(224, 20)
        Me.txtRawData.TabIndex = 1
        '
        'lblRawData
        '
        Me.lblRawData.Location = New System.Drawing.Point(12, 30)
        Me.lblRawData.Name = "lblRawData"
        Me.lblRawData.Size = New System.Drawing.Size(72, 22)
        Me.lblRawData.TabIndex = 0
        Me.lblRawData.Text = "RawData"
        '
        'FrmMICR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(455, 222)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.grpInsert)
        Me.Name = "FrmMICR"
        Me.Text = "FrmMICR"
        Me.grpInsert.ResumeLayout(False)
        Me.grpInsert.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents grpInsert As GroupBox
    Friend WithEvents btnRemove As Button
    Friend WithEvents btnInsert As Button
    Friend WithEvents txtRawData As TextBox
    Friend WithEvents lblRawData As Label
End Class
