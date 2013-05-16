<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLabelEmployee
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
        Me.ListBoxUser = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'ListBoxUser
        '
        Me.ListBoxUser.FormattingEnabled = True
        Me.ListBoxUser.Location = New System.Drawing.Point(13, 11)
        Me.ListBoxUser.Margin = New System.Windows.Forms.Padding(500, 500, 3, 3)
        Me.ListBoxUser.Name = "ListBoxUser"
        Me.ListBoxUser.Size = New System.Drawing.Size(186, 576)
        Me.ListBoxUser.TabIndex = 11
        '
        'FormLabelEmployee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(842, 577)
        Me.Controls.Add(Me.ListBoxUser)
        Me.Name = "FormLabelEmployee"
        Me.Text = "FormLabelEmployee"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBoxUser As System.Windows.Forms.ListBox
End Class
