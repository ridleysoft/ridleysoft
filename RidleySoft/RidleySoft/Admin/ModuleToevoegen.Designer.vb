<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModuleToevoegen
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
        Me.ButtonToevoegen = New System.Windows.Forms.Button()
        Me.LabelModule = New System.Windows.Forms.Label()
        Me.ComboBoxGroupname = New System.Windows.Forms.ComboBox()
        Me.TextBoxModulename = New System.Windows.Forms.TextBox()
        Me.LabelGroup = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ButtonToevoegen
        '
        Me.ButtonToevoegen.Location = New System.Drawing.Point(52, 124)
        Me.ButtonToevoegen.Name = "ButtonToevoegen"
        Me.ButtonToevoegen.Size = New System.Drawing.Size(89, 23)
        Me.ButtonToevoegen.TabIndex = 22
        Me.ButtonToevoegen.Text = "Save"
        Me.ButtonToevoegen.UseVisualStyleBackColor = True
        '
        'LabelModule
        '
        Me.LabelModule.AutoSize = True
        Me.LabelModule.Location = New System.Drawing.Point(52, 34)
        Me.LabelModule.Name = "LabelModule"
        Me.LabelModule.Size = New System.Drawing.Size(42, 13)
        Me.LabelModule.TabIndex = 26
        Me.LabelModule.Text = "Module"
        '
        'ComboBoxGroupname
        '
        Me.ComboBoxGroupname.FormattingEnabled = True
        Me.ComboBoxGroupname.Location = New System.Drawing.Point(127, 69)
        Me.ComboBoxGroupname.Name = "ComboBoxGroupname"
        Me.ComboBoxGroupname.Size = New System.Drawing.Size(267, 21)
        Me.ComboBoxGroupname.TabIndex = 25
        '
        'TextBoxModulename
        '
        Me.TextBoxModulename.Location = New System.Drawing.Point(127, 28)
        Me.TextBoxModulename.Name = "TextBoxModulename"
        Me.TextBoxModulename.Size = New System.Drawing.Size(267, 20)
        Me.TextBoxModulename.TabIndex = 24
        '
        'LabelGroup
        '
        Me.LabelGroup.AutoSize = True
        Me.LabelGroup.Location = New System.Drawing.Point(49, 69)
        Me.LabelGroup.Name = "LabelGroup"
        Me.LabelGroup.Size = New System.Drawing.Size(62, 13)
        Me.LabelGroup.TabIndex = 23
        Me.LabelGroup.Text = "Groupname"
        '
        'ModuleToevoegen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(457, 294)
        Me.Controls.Add(Me.LabelModule)
        Me.Controls.Add(Me.ComboBoxGroupname)
        Me.Controls.Add(Me.TextBoxModulename)
        Me.Controls.Add(Me.LabelGroup)
        Me.Controls.Add(Me.ButtonToevoegen)
        Me.Name = "ModuleToevoegen"
        Me.Text = "ModuleToevoegen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonToevoegen As System.Windows.Forms.Button
    Friend WithEvents LabelModule As System.Windows.Forms.Label
    Friend WithEvents ComboBoxGroupname As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxModulename As System.Windows.Forms.TextBox
    Friend WithEvents LabelGroup As System.Windows.Forms.Label
End Class
