<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingToevoegen
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
        Me.TextBoxType = New System.Windows.Forms.TextBox()
        Me.LabelType = New System.Windows.Forms.Label()
        Me.TextBoxValue = New System.Windows.Forms.TextBox()
        Me.LabelValue = New System.Windows.Forms.Label()
        Me.TextBoxDescription = New System.Windows.Forms.TextBox()
        Me.LabelDescription = New System.Windows.Forms.Label()
        Me.ButtonToevoegen = New System.Windows.Forms.Button()
        Me.ComboBoxUser = New System.Windows.Forms.ComboBox()
        Me.LabelUser = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TextBoxType
        '
        Me.TextBoxType.Location = New System.Drawing.Point(123, 154)
        Me.TextBoxType.Name = "TextBoxType"
        Me.TextBoxType.Size = New System.Drawing.Size(267, 20)
        Me.TextBoxType.TabIndex = 45
        '
        'LabelType
        '
        Me.LabelType.AutoSize = True
        Me.LabelType.Location = New System.Drawing.Point(48, 157)
        Me.LabelType.Name = "LabelType"
        Me.LabelType.Size = New System.Drawing.Size(31, 13)
        Me.LabelType.TabIndex = 44
        Me.LabelType.Text = "Type"
        '
        'TextBoxValue
        '
        Me.TextBoxValue.Location = New System.Drawing.Point(123, 115)
        Me.TextBoxValue.Name = "TextBoxValue"
        Me.TextBoxValue.Size = New System.Drawing.Size(267, 20)
        Me.TextBoxValue.TabIndex = 42
        '
        'LabelValue
        '
        Me.LabelValue.AutoSize = True
        Me.LabelValue.Location = New System.Drawing.Point(48, 118)
        Me.LabelValue.Name = "LabelValue"
        Me.LabelValue.Size = New System.Drawing.Size(34, 13)
        Me.LabelValue.TabIndex = 41
        Me.LabelValue.Text = "Value"
        '
        'TextBoxDescription
        '
        Me.TextBoxDescription.Location = New System.Drawing.Point(123, 78)
        Me.TextBoxDescription.Name = "TextBoxDescription"
        Me.TextBoxDescription.Size = New System.Drawing.Size(267, 20)
        Me.TextBoxDescription.TabIndex = 40
        '
        'LabelDescription
        '
        Me.LabelDescription.AutoSize = True
        Me.LabelDescription.Location = New System.Drawing.Point(48, 81)
        Me.LabelDescription.Name = "LabelDescription"
        Me.LabelDescription.Size = New System.Drawing.Size(60, 13)
        Me.LabelDescription.TabIndex = 39
        Me.LabelDescription.Text = "Description"
        '
        'ButtonToevoegen
        '
        Me.ButtonToevoegen.Location = New System.Drawing.Point(39, 243)
        Me.ButtonToevoegen.Name = "ButtonToevoegen"
        Me.ButtonToevoegen.Size = New System.Drawing.Size(89, 23)
        Me.ButtonToevoegen.TabIndex = 37
        Me.ButtonToevoegen.Text = "Save"
        Me.ButtonToevoegen.UseVisualStyleBackColor = True
        '
        'ComboBoxUser
        '
        Me.ComboBoxUser.FormattingEnabled = True
        Me.ComboBoxUser.Location = New System.Drawing.Point(123, 42)
        Me.ComboBoxUser.Name = "ComboBoxUser"
        Me.ComboBoxUser.Size = New System.Drawing.Size(267, 21)
        Me.ComboBoxUser.TabIndex = 47
        '
        'LabelUser
        '
        Me.LabelUser.AutoSize = True
        Me.LabelUser.Location = New System.Drawing.Point(48, 45)
        Me.LabelUser.Name = "LabelUser"
        Me.LabelUser.Size = New System.Drawing.Size(29, 13)
        Me.LabelUser.TabIndex = 46
        Me.LabelUser.Text = "User"
        '
        'SettingToevoegen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 483)
        Me.Controls.Add(Me.ComboBoxUser)
        Me.Controls.Add(Me.LabelUser)
        Me.Controls.Add(Me.TextBoxType)
        Me.Controls.Add(Me.LabelType)
        Me.Controls.Add(Me.TextBoxValue)
        Me.Controls.Add(Me.LabelValue)
        Me.Controls.Add(Me.TextBoxDescription)
        Me.Controls.Add(Me.LabelDescription)
        Me.Controls.Add(Me.ButtonToevoegen)
        Me.Name = "SettingToevoegen"
        Me.Text = "SettingToevoegen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBoxType As System.Windows.Forms.TextBox
    Friend WithEvents LabelType As System.Windows.Forms.Label
    Friend WithEvents TextBoxValue As System.Windows.Forms.TextBox
    Friend WithEvents LabelValue As System.Windows.Forms.Label
    Friend WithEvents TextBoxDescription As System.Windows.Forms.TextBox
    Friend WithEvents LabelDescription As System.Windows.Forms.Label
    Friend WithEvents ButtonToevoegen As System.Windows.Forms.Button
    Friend WithEvents ComboBoxUser As System.Windows.Forms.ComboBox
    Friend WithEvents LabelUser As System.Windows.Forms.Label
End Class
