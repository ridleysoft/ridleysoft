<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormHelpFiles
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
        Me.ListBoxHelpFiles = New System.Windows.Forms.ListBox()
        Me.TextBoxCategorie = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxName = New System.Windows.Forms.TextBox()
        Me.LabelName = New System.Windows.Forms.Label()
        Me.TextBoxType = New System.Windows.Forms.TextBox()
        Me.LabelType = New System.Windows.Forms.Label()
        Me.TextBoxPath = New System.Windows.Forms.TextBox()
        Me.LabelPath = New System.Windows.Forms.Label()
        Me.TextBoxDescription = New System.Windows.Forms.TextBox()
        Me.LabelDescription = New System.Windows.Forms.Label()
        Me.ButtonWijzigen = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ListBoxHelpFiles
        '
        Me.ListBoxHelpFiles.FormattingEnabled = True
        Me.ListBoxHelpFiles.Location = New System.Drawing.Point(20, 14)
        Me.ListBoxHelpFiles.Margin = New System.Windows.Forms.Padding(500, 500, 3, 3)
        Me.ListBoxHelpFiles.Name = "ListBoxHelpFiles"
        Me.ListBoxHelpFiles.Size = New System.Drawing.Size(186, 576)
        Me.ListBoxHelpFiles.TabIndex = 12
        '
        'TextBoxCategorie
        '
        Me.TextBoxCategorie.Location = New System.Drawing.Point(438, 198)
        Me.TextBoxCategorie.Name = "TextBoxCategorie"
        Me.TextBoxCategorie.Size = New System.Drawing.Size(460, 20)
        Me.TextBoxCategorie.TabIndex = 70
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(363, 201)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Categorie"
        '
        'TextBoxName
        '
        Me.TextBoxName.Location = New System.Drawing.Point(438, 51)
        Me.TextBoxName.Name = "TextBoxName"
        Me.TextBoxName.Size = New System.Drawing.Size(460, 20)
        Me.TextBoxName.TabIndex = 68
        '
        'LabelName
        '
        Me.LabelName.AutoSize = True
        Me.LabelName.Location = New System.Drawing.Point(363, 54)
        Me.LabelName.Name = "LabelName"
        Me.LabelName.Size = New System.Drawing.Size(35, 13)
        Me.LabelName.TabIndex = 67
        Me.LabelName.Text = "Name"
        '
        'TextBoxType
        '
        Me.TextBoxType.Location = New System.Drawing.Point(438, 163)
        Me.TextBoxType.Name = "TextBoxType"
        Me.TextBoxType.Size = New System.Drawing.Size(460, 20)
        Me.TextBoxType.TabIndex = 66
        '
        'LabelType
        '
        Me.LabelType.AutoSize = True
        Me.LabelType.Location = New System.Drawing.Point(363, 166)
        Me.LabelType.Name = "LabelType"
        Me.LabelType.Size = New System.Drawing.Size(31, 13)
        Me.LabelType.TabIndex = 65
        Me.LabelType.Text = "Type"
        '
        'TextBoxPath
        '
        Me.TextBoxPath.Location = New System.Drawing.Point(438, 124)
        Me.TextBoxPath.Name = "TextBoxPath"
        Me.TextBoxPath.Size = New System.Drawing.Size(460, 20)
        Me.TextBoxPath.TabIndex = 64
        '
        'LabelPath
        '
        Me.LabelPath.AutoSize = True
        Me.LabelPath.Location = New System.Drawing.Point(363, 127)
        Me.LabelPath.Name = "LabelPath"
        Me.LabelPath.Size = New System.Drawing.Size(29, 13)
        Me.LabelPath.TabIndex = 63
        Me.LabelPath.Text = "Path"
        '
        'TextBoxDescription
        '
        Me.TextBoxDescription.Location = New System.Drawing.Point(438, 87)
        Me.TextBoxDescription.Name = "TextBoxDescription"
        Me.TextBoxDescription.Size = New System.Drawing.Size(460, 20)
        Me.TextBoxDescription.TabIndex = 62
        '
        'LabelDescription
        '
        Me.LabelDescription.AutoSize = True
        Me.LabelDescription.Location = New System.Drawing.Point(363, 90)
        Me.LabelDescription.Name = "LabelDescription"
        Me.LabelDescription.Size = New System.Drawing.Size(60, 13)
        Me.LabelDescription.TabIndex = 61
        Me.LabelDescription.Text = "Description"
        '
        'ButtonWijzigen
        '
        Me.ButtonWijzigen.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonWijzigen.Location = New System.Drawing.Point(366, 265)
        Me.ButtonWijzigen.Name = "ButtonWijzigen"
        Me.ButtonWijzigen.Size = New System.Drawing.Size(89, 23)
        Me.ButtonWijzigen.TabIndex = 71
        Me.ButtonWijzigen.Text = "Edit"
        Me.ButtonWijzigen.UseVisualStyleBackColor = True
        '
        'FormHelpFiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1044, 596)
        Me.Controls.Add(Me.ButtonWijzigen)
        Me.Controls.Add(Me.TextBoxCategorie)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxName)
        Me.Controls.Add(Me.LabelName)
        Me.Controls.Add(Me.TextBoxType)
        Me.Controls.Add(Me.LabelType)
        Me.Controls.Add(Me.TextBoxPath)
        Me.Controls.Add(Me.LabelPath)
        Me.Controls.Add(Me.TextBoxDescription)
        Me.Controls.Add(Me.LabelDescription)
        Me.Controls.Add(Me.ListBoxHelpFiles)
        Me.Name = "FormHelpFiles"
        Me.Text = "FormHelpFiles"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListBoxHelpFiles As System.Windows.Forms.ListBox
    Friend WithEvents TextBoxCategorie As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxName As System.Windows.Forms.TextBox
    Friend WithEvents LabelName As System.Windows.Forms.Label
    Friend WithEvents TextBoxType As System.Windows.Forms.TextBox
    Friend WithEvents LabelType As System.Windows.Forms.Label
    Friend WithEvents TextBoxPath As System.Windows.Forms.TextBox
    Friend WithEvents LabelPath As System.Windows.Forms.Label
    Friend WithEvents TextBoxDescription As System.Windows.Forms.TextBox
    Friend WithEvents LabelDescription As System.Windows.Forms.Label
    Friend WithEvents ButtonWijzigen As System.Windows.Forms.Button
End Class
