<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormModule
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
        Me.TextBoxModulename = New System.Windows.Forms.TextBox()
        Me.LabelGroup = New System.Windows.Forms.Label()
        Me.ComboBoxGroupname = New System.Windows.Forms.ComboBox()
        Me.LabelModule = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.SuspendLayout()
        '
        'ButtonWijzigen
        '
        Me.ButtonWijzigen.Location = New System.Drawing.Point(444, 144)
        Me.ButtonWijzigen.Name = "ButtonWijzigen"
        Me.ButtonWijzigen.Size = New System.Drawing.Size(89, 23)
        Me.ButtonWijzigen.TabIndex = 17
        Me.ButtonWijzigen.Text = "Edit"
        Me.ButtonWijzigen.UseVisualStyleBackColor = True
        '
        'TextBoxModulename
        '
        Me.TextBoxModulename.Location = New System.Drawing.Point(519, 50)
        Me.TextBoxModulename.Name = "TextBoxModulename"
        Me.TextBoxModulename.Size = New System.Drawing.Size(267, 20)
        Me.TextBoxModulename.TabIndex = 16
        '
        'LabelGroup
        '
        Me.LabelGroup.AutoSize = True
        Me.LabelGroup.Location = New System.Drawing.Point(441, 91)
        Me.LabelGroup.Name = "LabelGroup"
        Me.LabelGroup.Size = New System.Drawing.Size(62, 13)
        Me.LabelGroup.TabIndex = 15
        Me.LabelGroup.Text = "Groupname"
        '
        'ComboBoxGroupname
        '
        Me.ComboBoxGroupname.FormattingEnabled = True
        Me.ComboBoxGroupname.Location = New System.Drawing.Point(519, 91)
        Me.ComboBoxGroupname.Name = "ComboBoxGroupname"
        Me.ComboBoxGroupname.Size = New System.Drawing.Size(267, 21)
        Me.ComboBoxGroupname.TabIndex = 18
        '
        'LabelModule
        '
        Me.LabelModule.AutoSize = True
        Me.LabelModule.Location = New System.Drawing.Point(444, 56)
        Me.LabelModule.Name = "LabelModule"
        Me.LabelModule.Size = New System.Drawing.Size(42, 13)
        Me.LabelModule.TabIndex = 19
        Me.LabelModule.Text = "Module"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(12, 11)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 95)
        Me.ListBox1.TabIndex = 20
        '
        'Splitter1
        '
        Me.Splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Margin = New System.Windows.Forms.Padding(50, 3, 3, 3)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(11, 253)
        Me.Splitter1.TabIndex = 21
        Me.Splitter1.TabStop = False
        '
        'FormModule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 253)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.LabelModule)
        Me.Controls.Add(Me.ComboBoxGroupname)
        Me.Controls.Add(Me.ButtonWijzigen)
        Me.Controls.Add(Me.TextBoxModulename)
        Me.Controls.Add(Me.LabelGroup)
        Me.MinimumSize = New System.Drawing.Size(808, 291)
        Me.Name = "FormModule"
        Me.Text = "FormModule"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonWijzigen As System.Windows.Forms.Button
    Friend WithEvents TextBoxModulename As System.Windows.Forms.TextBox
    Friend WithEvents LabelGroup As System.Windows.Forms.Label
    Friend WithEvents ComboBoxGroupname As System.Windows.Forms.ComboBox
    Friend WithEvents LabelModule As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
End Class
