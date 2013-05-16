<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAddHelpFiles
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
        Me.LabelName = New System.Windows.Forms.Label()
        Me.TextBoxType = New System.Windows.Forms.TextBox()
        Me.LabelType = New System.Windows.Forms.Label()
        Me.TextBoxPath = New System.Windows.Forms.TextBox()
        Me.LabelPath = New System.Windows.Forms.Label()
        Me.TextBoxDescription = New System.Windows.Forms.TextBox()
        Me.LabelDescription = New System.Windows.Forms.Label()
        Me.ButtonToevoegen = New System.Windows.Forms.Button()
        Me.ButtonFile = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TextBoxName = New System.Windows.Forms.TextBox()
        Me.TextBoxCategorie = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LabelName
        '
        Me.LabelName.AutoSize = True
        Me.LabelName.Location = New System.Drawing.Point(48, 89)
        Me.LabelName.Name = "LabelName"
        Me.LabelName.Size = New System.Drawing.Size(35, 13)
        Me.LabelName.TabIndex = 55
        Me.LabelName.Text = "Name"
        '
        'TextBoxType
        '
        Me.TextBoxType.Location = New System.Drawing.Point(123, 198)
        Me.TextBoxType.Name = "TextBoxType"
        Me.TextBoxType.Size = New System.Drawing.Size(267, 20)
        Me.TextBoxType.TabIndex = 54
        '
        'LabelType
        '
        Me.LabelType.AutoSize = True
        Me.LabelType.Location = New System.Drawing.Point(48, 201)
        Me.LabelType.Name = "LabelType"
        Me.LabelType.Size = New System.Drawing.Size(31, 13)
        Me.LabelType.TabIndex = 53
        Me.LabelType.Text = "Type"
        '
        'TextBoxPath
        '
        Me.TextBoxPath.Location = New System.Drawing.Point(123, 159)
        Me.TextBoxPath.Name = "TextBoxPath"
        Me.TextBoxPath.Size = New System.Drawing.Size(267, 20)
        Me.TextBoxPath.TabIndex = 52
        '
        'LabelPath
        '
        Me.LabelPath.AutoSize = True
        Me.LabelPath.Location = New System.Drawing.Point(48, 162)
        Me.LabelPath.Name = "LabelPath"
        Me.LabelPath.Size = New System.Drawing.Size(29, 13)
        Me.LabelPath.TabIndex = 51
        Me.LabelPath.Text = "Path"
        '
        'TextBoxDescription
        '
        Me.TextBoxDescription.Location = New System.Drawing.Point(123, 122)
        Me.TextBoxDescription.Name = "TextBoxDescription"
        Me.TextBoxDescription.Size = New System.Drawing.Size(267, 20)
        Me.TextBoxDescription.TabIndex = 50
        '
        'LabelDescription
        '
        Me.LabelDescription.AutoSize = True
        Me.LabelDescription.Location = New System.Drawing.Point(48, 125)
        Me.LabelDescription.Name = "LabelDescription"
        Me.LabelDescription.Size = New System.Drawing.Size(60, 13)
        Me.LabelDescription.TabIndex = 49
        Me.LabelDescription.Text = "Description"
        '
        'ButtonToevoegen
        '
        Me.ButtonToevoegen.Location = New System.Drawing.Point(39, 287)
        Me.ButtonToevoegen.Name = "ButtonToevoegen"
        Me.ButtonToevoegen.Size = New System.Drawing.Size(89, 23)
        Me.ButtonToevoegen.TabIndex = 48
        Me.ButtonToevoegen.Text = "Save"
        Me.ButtonToevoegen.UseVisualStyleBackColor = True
        '
        'ButtonFile
        '
        Me.ButtonFile.Location = New System.Drawing.Point(39, 23)
        Me.ButtonFile.Name = "ButtonFile"
        Me.ButtonFile.Size = New System.Drawing.Size(105, 38)
        Me.ButtonFile.TabIndex = 56
        Me.ButtonFile.Text = "File kiezen"
        Me.ButtonFile.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TextBoxName
        '
        Me.TextBoxName.Location = New System.Drawing.Point(123, 86)
        Me.TextBoxName.Name = "TextBoxName"
        Me.TextBoxName.Size = New System.Drawing.Size(267, 20)
        Me.TextBoxName.TabIndex = 57
        '
        'TextBoxCategorie
        '
        Me.TextBoxCategorie.Location = New System.Drawing.Point(123, 233)
        Me.TextBoxCategorie.Name = "TextBoxCategorie"
        Me.TextBoxCategorie.Size = New System.Drawing.Size(267, 20)
        Me.TextBoxCategorie.TabIndex = 59
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 236)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Categorie"
        '
        'FormAddHelpFiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 492)
        Me.Controls.Add(Me.TextBoxCategorie)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxName)
        Me.Controls.Add(Me.ButtonFile)
        Me.Controls.Add(Me.LabelName)
        Me.Controls.Add(Me.TextBoxType)
        Me.Controls.Add(Me.LabelType)
        Me.Controls.Add(Me.TextBoxPath)
        Me.Controls.Add(Me.LabelPath)
        Me.Controls.Add(Me.TextBoxDescription)
        Me.Controls.Add(Me.LabelDescription)
        Me.Controls.Add(Me.ButtonToevoegen)
        Me.Name = "FormAddHelpFiles"
        Me.Text = "FormAddHelpFiles"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelName As System.Windows.Forms.Label
    Friend WithEvents TextBoxType As System.Windows.Forms.TextBox
    Friend WithEvents LabelType As System.Windows.Forms.Label
    Friend WithEvents TextBoxPath As System.Windows.Forms.TextBox
    Friend WithEvents LabelPath As System.Windows.Forms.Label
    Friend WithEvents TextBoxDescription As System.Windows.Forms.TextBox
    Friend WithEvents LabelDescription As System.Windows.Forms.Label
    Friend WithEvents ButtonToevoegen As System.Windows.Forms.Button
    Friend WithEvents ButtonFile As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TextBoxName As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCategorie As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
