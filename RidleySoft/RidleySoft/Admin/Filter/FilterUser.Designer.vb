<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FilterUser
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxUserName = New System.Windows.Forms.TextBox()
        Me.ButtonFilter = New System.Windows.Forms.Button()
        Me.TextBoxType = New System.Windows.Forms.TextBox()
        Me.TextBoxValue = New System.Windows.Forms.TextBox()
        Me.TextBoxDescription = New System.Windows.Forms.TextBox()
        Me.LabelType = New System.Windows.Forms.Label()
        Me.LabelValue = New System.Windows.Forms.Label()
        Me.LabelDescription = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "User"
        '
        'TextBoxUserName
        '
        Me.TextBoxUserName.Location = New System.Drawing.Point(102, 28)
        Me.TextBoxUserName.Name = "TextBoxUserName"
        Me.TextBoxUserName.Size = New System.Drawing.Size(250, 20)
        Me.TextBoxUserName.TabIndex = 1
        '
        'ButtonFilter
        '
        Me.ButtonFilter.Location = New System.Drawing.Point(432, 26)
        Me.ButtonFilter.Name = "ButtonFilter"
        Me.ButtonFilter.Size = New System.Drawing.Size(75, 23)
        Me.ButtonFilter.TabIndex = 2
        Me.ButtonFilter.Text = "Filter"
        Me.ButtonFilter.UseVisualStyleBackColor = True
        '
        'TextBoxType
        '
        Me.TextBoxType.Location = New System.Drawing.Point(102, 126)
        Me.TextBoxType.Name = "TextBoxType"
        Me.TextBoxType.Size = New System.Drawing.Size(250, 20)
        Me.TextBoxType.TabIndex = 13
        '
        'TextBoxValue
        '
        Me.TextBoxValue.Location = New System.Drawing.Point(102, 94)
        Me.TextBoxValue.Name = "TextBoxValue"
        Me.TextBoxValue.Size = New System.Drawing.Size(250, 20)
        Me.TextBoxValue.TabIndex = 12
        '
        'TextBoxDescription
        '
        Me.TextBoxDescription.Location = New System.Drawing.Point(102, 61)
        Me.TextBoxDescription.Name = "TextBoxDescription"
        Me.TextBoxDescription.Size = New System.Drawing.Size(250, 20)
        Me.TextBoxDescription.TabIndex = 11
        '
        'LabelType
        '
        Me.LabelType.AutoSize = True
        Me.LabelType.Location = New System.Drawing.Point(29, 129)
        Me.LabelType.Name = "LabelType"
        Me.LabelType.Size = New System.Drawing.Size(31, 13)
        Me.LabelType.TabIndex = 10
        Me.LabelType.Text = "Type"
        '
        'LabelValue
        '
        Me.LabelValue.AutoSize = True
        Me.LabelValue.Location = New System.Drawing.Point(29, 97)
        Me.LabelValue.Name = "LabelValue"
        Me.LabelValue.Size = New System.Drawing.Size(34, 13)
        Me.LabelValue.TabIndex = 9
        Me.LabelValue.Text = "Value"
        '
        'LabelDescription
        '
        Me.LabelDescription.AutoSize = True
        Me.LabelDescription.Location = New System.Drawing.Point(29, 64)
        Me.LabelDescription.Name = "LabelDescription"
        Me.LabelDescription.Size = New System.Drawing.Size(60, 13)
        Me.LabelDescription.TabIndex = 8
        Me.LabelDescription.Text = "Description"
        '
        'FilterUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 169)
        Me.Controls.Add(Me.TextBoxType)
        Me.Controls.Add(Me.TextBoxValue)
        Me.Controls.Add(Me.TextBoxDescription)
        Me.Controls.Add(Me.LabelType)
        Me.Controls.Add(Me.LabelValue)
        Me.Controls.Add(Me.LabelDescription)
        Me.Controls.Add(Me.ButtonFilter)
        Me.Controls.Add(Me.TextBoxUserName)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FilterUser"
        Me.Text = "UserFilter"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxUserName As System.Windows.Forms.TextBox
    Friend WithEvents ButtonFilter As System.Windows.Forms.Button
    Friend WithEvents TextBoxType As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxValue As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxDescription As System.Windows.Forms.TextBox
    Friend WithEvents LabelType As System.Windows.Forms.Label
    Friend WithEvents LabelValue As System.Windows.Forms.Label
    Friend WithEvents LabelDescription As System.Windows.Forms.Label
End Class
