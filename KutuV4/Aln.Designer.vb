<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Aln
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Dgr = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Dgr
        '
        Me.Dgr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Dgr.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.Dgr.Location = New System.Drawing.Point(1, 1)
        Me.Dgr.Name = "Dgr"
        Me.Dgr.Size = New System.Drawing.Size(60, 22)
        Me.Dgr.TabIndex = 0
        '
        'Aln
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Dgr)
        Me.Name = "Aln"
        Me.Size = New System.Drawing.Size(100, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Dgr As System.Windows.Forms.TextBox

End Class
