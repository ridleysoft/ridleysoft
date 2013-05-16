<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRights
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
        Me.ButtonWijzigen = New System.Windows.Forms.Button()
        Me.TextBoxRight = New System.Windows.Forms.TextBox()
        Me.LabelGroup = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.SuspendLayout()
        '
        'ButtonWijzigen
        '
        Me.ButtonWijzigen.Location = New System.Drawing.Point(438, 100)
        Me.ButtonWijzigen.Name = "ButtonWijzigen"
        Me.ButtonWijzigen.Size = New System.Drawing.Size(89, 23)
        Me.ButtonWijzigen.TabIndex = 17
        Me.ButtonWijzigen.Text = "Edit"
        Me.ButtonWijzigen.UseVisualStyleBackColor = True
        '
        'TextBoxRight
        '
        Me.TextBoxRight.Location = New System.Drawing.Point(513, 43)
        Me.TextBoxRight.Name = "TextBoxRight"
        Me.TextBoxRight.Size = New System.Drawing.Size(267, 20)
        Me.TextBoxRight.TabIndex = 16
        '
        'LabelGroup
        '
        Me.LabelGroup.AutoSize = True
        Me.LabelGroup.Location = New System.Drawing.Point(435, 46)
        Me.LabelGroup.Name = "LabelGroup"
        Me.LabelGroup.Size = New System.Drawing.Size(32, 13)
        Me.LabelGroup.TabIndex = 15
        Me.LabelGroup.Text = "Right"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(57, 33)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 95)
        Me.ListBox1.TabIndex = 18
        '
        'Splitter1
        '
        Me.Splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Margin = New System.Windows.Forms.Padding(50, 3, 3, 3)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(11, 261)
        Me.Splitter1.TabIndex = 19
        Me.Splitter1.TabStop = False
        '
        'FormRights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 261)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.ButtonWijzigen)
        Me.Controls.Add(Me.TextBoxRight)
        Me.Controls.Add(Me.LabelGroup)
        Me.MinimumSize = New System.Drawing.Size(805, 299)
        Me.Name = "FormRights"
        Me.Text = "FormRights"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonWijzigen As System.Windows.Forms.Button
    Friend WithEvents TextBoxRight As System.Windows.Forms.TextBox
    Friend WithEvents LabelGroup As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
End Class
