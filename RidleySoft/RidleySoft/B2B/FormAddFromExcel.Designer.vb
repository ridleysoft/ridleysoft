<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAddFromExcel
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.ButtonExcel = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.SuspendLayout()
        '
        'ButtonExcel
        '
        Me.ButtonExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.ButtonExcel.Location = New System.Drawing.Point(22, 50)
        Me.ButtonExcel.Name = "ButtonExcel"
        Me.ButtonExcel.Size = New System.Drawing.Size(169, 46)
        Me.ButtonExcel.TabIndex = 0
        Me.ButtonExcel.Text = "Excel kiezen"
        Me.ButtonExcel.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ListView1
        '
        Me.ListView1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ListView1.Location = New System.Drawing.Point(22, 129)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(391, 418)
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'FormAddFromExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1293, 650)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.ButtonExcel)
        Me.Name = "FormAddFromExcel"
        Me.Text = "FormAddFromExcel"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonExcel As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
End Class
