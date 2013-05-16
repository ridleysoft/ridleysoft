<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSettings
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
        Me.LabelUser = New System.Windows.Forms.Label()
        Me.LabelDescription = New System.Windows.Forms.Label()
        Me.LabelValue = New System.Windows.Forms.Label()
        Me.LabelType = New System.Windows.Forms.Label()
        Me.TextBoxUser = New System.Windows.Forms.TextBox()
        Me.TextBoxDescription = New System.Windows.Forms.TextBox()
        Me.TextBoxValue = New System.Windows.Forms.TextBox()
        Me.TextBoxType = New System.Windows.Forms.TextBox()
        Me.ButtonWijzigen = New System.Windows.Forms.Button()
        Me.ListBoxUser = New System.Windows.Forms.ListBox()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.SuspendLayout()
        '
        'LabelUser
        '
        Me.LabelUser.AutoSize = True
        Me.LabelUser.Location = New System.Drawing.Point(451, 52)
        Me.LabelUser.Name = "LabelUser"
        Me.LabelUser.Size = New System.Drawing.Size(29, 13)
        Me.LabelUser.TabIndex = 0
        Me.LabelUser.Text = "User"
        '
        'LabelDescription
        '
        Me.LabelDescription.AutoSize = True
        Me.LabelDescription.Location = New System.Drawing.Point(451, 88)
        Me.LabelDescription.Name = "LabelDescription"
        Me.LabelDescription.Size = New System.Drawing.Size(60, 13)
        Me.LabelDescription.TabIndex = 1
        Me.LabelDescription.Text = "Description"
        '
        'LabelValue
        '
        Me.LabelValue.AutoSize = True
        Me.LabelValue.Location = New System.Drawing.Point(451, 125)
        Me.LabelValue.Name = "LabelValue"
        Me.LabelValue.Size = New System.Drawing.Size(34, 13)
        Me.LabelValue.TabIndex = 2
        Me.LabelValue.Text = "Value"
        '
        'LabelType
        '
        Me.LabelType.AutoSize = True
        Me.LabelType.Location = New System.Drawing.Point(451, 164)
        Me.LabelType.Name = "LabelType"
        Me.LabelType.Size = New System.Drawing.Size(31, 13)
        Me.LabelType.TabIndex = 3
        Me.LabelType.Text = "Type"
        '
        'TextBoxUser
        '
        Me.TextBoxUser.Location = New System.Drawing.Point(539, 49)
        Me.TextBoxUser.Name = "TextBoxUser"
        Me.TextBoxUser.Size = New System.Drawing.Size(250, 20)
        Me.TextBoxUser.TabIndex = 4
        '
        'TextBoxDescription
        '
        Me.TextBoxDescription.Location = New System.Drawing.Point(539, 85)
        Me.TextBoxDescription.Name = "TextBoxDescription"
        Me.TextBoxDescription.Size = New System.Drawing.Size(250, 20)
        Me.TextBoxDescription.TabIndex = 5
        '
        'TextBoxValue
        '
        Me.TextBoxValue.Location = New System.Drawing.Point(539, 122)
        Me.TextBoxValue.Name = "TextBoxValue"
        Me.TextBoxValue.Size = New System.Drawing.Size(250, 20)
        Me.TextBoxValue.TabIndex = 6
        '
        'TextBoxType
        '
        Me.TextBoxType.Location = New System.Drawing.Point(539, 157)
        Me.TextBoxType.Name = "TextBoxType"
        Me.TextBoxType.Size = New System.Drawing.Size(250, 20)
        Me.TextBoxType.TabIndex = 7
        '
        'ButtonWijzigen
        '
        Me.ButtonWijzigen.Location = New System.Drawing.Point(454, 208)
        Me.ButtonWijzigen.Name = "ButtonWijzigen"
        Me.ButtonWijzigen.Size = New System.Drawing.Size(75, 23)
        Me.ButtonWijzigen.TabIndex = 8
        Me.ButtonWijzigen.Text = "Edit"
        Me.ButtonWijzigen.UseVisualStyleBackColor = True
        '
        'ListBoxUser
        '
        Me.ListBoxUser.FormattingEnabled = True
        Me.ListBoxUser.Location = New System.Drawing.Point(12, 17)
        Me.ListBoxUser.Name = "ListBoxUser"
        Me.ListBoxUser.Size = New System.Drawing.Size(120, 95)
        Me.ListBoxUser.TabIndex = 11
        '
        'Splitter1
        '
        Me.Splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Margin = New System.Windows.Forms.Padding(50, 3, 3, 3)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(11, 1000)
        Me.Splitter1.TabIndex = 12
        Me.Splitter1.TabStop = False
        '
        'FormSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1902, 1000)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.ListBoxUser)
        Me.Controls.Add(Me.ButtonWijzigen)
        Me.Controls.Add(Me.TextBoxType)
        Me.Controls.Add(Me.TextBoxValue)
        Me.Controls.Add(Me.TextBoxDescription)
        Me.Controls.Add(Me.TextBoxUser)
        Me.Controls.Add(Me.LabelType)
        Me.Controls.Add(Me.LabelValue)
        Me.Controls.Add(Me.LabelDescription)
        Me.Controls.Add(Me.LabelUser)
        Me.MinimumSize = New System.Drawing.Size(1918, 1038)
        Me.Name = "FormSettings"
        Me.Text = "FormSettings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelUser As System.Windows.Forms.Label
    Friend WithEvents LabelDescription As System.Windows.Forms.Label
    Friend WithEvents LabelValue As System.Windows.Forms.Label
    Friend WithEvents LabelType As System.Windows.Forms.Label
    Friend WithEvents TextBoxUser As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxDescription As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxValue As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxType As System.Windows.Forms.TextBox
    Friend WithEvents ButtonWijzigen As System.Windows.Forms.Button
    Friend WithEvents ListBoxUser As System.Windows.Forms.ListBox
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
End Class
