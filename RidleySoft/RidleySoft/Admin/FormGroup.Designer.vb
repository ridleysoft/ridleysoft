<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormGroup
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
        Me.LabelGroup = New System.Windows.Forms.Label()
        Me.TextBoxGroupname = New System.Windows.Forms.TextBox()
        Me.ButtonWijzigen = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.SuspendLayout()
        '
        'LabelGroup
        '
        Me.LabelGroup.AutoSize = True
        Me.LabelGroup.Location = New System.Drawing.Point(380, 39)
        Me.LabelGroup.Name = "LabelGroup"
        Me.LabelGroup.Size = New System.Drawing.Size(62, 13)
        Me.LabelGroup.TabIndex = 10
        Me.LabelGroup.Text = "Groupname"
        '
        'TextBoxGroupname
        '
        Me.TextBoxGroupname.Location = New System.Drawing.Point(458, 39)
        Me.TextBoxGroupname.Name = "TextBoxGroupname"
        Me.TextBoxGroupname.Size = New System.Drawing.Size(267, 20)
        Me.TextBoxGroupname.TabIndex = 12
        '
        'ButtonWijzigen
        '
        Me.ButtonWijzigen.Location = New System.Drawing.Point(383, 96)
        Me.ButtonWijzigen.Name = "ButtonWijzigen"
        Me.ButtonWijzigen.Size = New System.Drawing.Size(89, 23)
        Me.ButtonWijzigen.TabIndex = 14
        Me.ButtonWijzigen.Text = "Edit"
        Me.ButtonWijzigen.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(0, 0)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 95)
        Me.ListBox1.TabIndex = 15
        '
        'Splitter1
        '
        Me.Splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Margin = New System.Windows.Forms.Padding(50, 3, 3, 3)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(11, 259)
        Me.Splitter1.TabIndex = 16
        Me.Splitter1.TabStop = False
        '
        'FormGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 259)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.ButtonWijzigen)
        Me.Controls.Add(Me.TextBoxGroupname)
        Me.Controls.Add(Me.LabelGroup)
        Me.MinimumSize = New System.Drawing.Size(754, 297)
        Me.Name = "FormGroup"
        Me.Text = "FormGroup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelGroup As System.Windows.Forms.Label
    Friend WithEvents TextBoxGroupname As System.Windows.Forms.TextBox
    Friend WithEvents ButtonWijzigen As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
End Class
