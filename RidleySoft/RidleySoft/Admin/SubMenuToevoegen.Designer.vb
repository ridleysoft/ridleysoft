<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SubMenuToevoegen
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
        Me.LabelSubMenu = New System.Windows.Forms.Label()
        Me.ComboBoxMenu = New System.Windows.Forms.ComboBox()
        Me.ButtonToevoegen = New System.Windows.Forms.Button()
        Me.TextBoxSubMenu = New System.Windows.Forms.TextBox()
        Me.LabelMenu = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LabelSubMenu
        '
        Me.LabelSubMenu.AutoSize = True
        Me.LabelSubMenu.Location = New System.Drawing.Point(56, 62)
        Me.LabelSubMenu.Name = "LabelSubMenu"
        Me.LabelSubMenu.Size = New System.Drawing.Size(53, 13)
        Me.LabelSubMenu.TabIndex = 36
        Me.LabelSubMenu.Text = "SubMenu"
        '
        'ComboBoxMenu
        '
        Me.ComboBoxMenu.FormattingEnabled = True
        Me.ComboBoxMenu.Location = New System.Drawing.Point(131, 97)
        Me.ComboBoxMenu.Name = "ComboBoxMenu"
        Me.ComboBoxMenu.Size = New System.Drawing.Size(267, 21)
        Me.ComboBoxMenu.TabIndex = 35
        '
        'ButtonToevoegen
        '
        Me.ButtonToevoegen.Location = New System.Drawing.Point(59, 148)
        Me.ButtonToevoegen.Name = "ButtonToevoegen"
        Me.ButtonToevoegen.Size = New System.Drawing.Size(89, 23)
        Me.ButtonToevoegen.TabIndex = 34
        Me.ButtonToevoegen.Text = "Save"
        Me.ButtonToevoegen.UseVisualStyleBackColor = True
        '
        'TextBoxSubMenu
        '
        Me.TextBoxSubMenu.Location = New System.Drawing.Point(131, 56)
        Me.TextBoxSubMenu.Name = "TextBoxSubMenu"
        Me.TextBoxSubMenu.Size = New System.Drawing.Size(267, 20)
        Me.TextBoxSubMenu.TabIndex = 33
        '
        'LabelMenu
        '
        Me.LabelMenu.AutoSize = True
        Me.LabelMenu.Location = New System.Drawing.Point(56, 97)
        Me.LabelMenu.Name = "LabelMenu"
        Me.LabelMenu.Size = New System.Drawing.Size(34, 13)
        Me.LabelMenu.TabIndex = 32
        Me.LabelMenu.Text = "Menu"
        '
        'SubMenuToevoegen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(552, 367)
        Me.Controls.Add(Me.LabelSubMenu)
        Me.Controls.Add(Me.ComboBoxMenu)
        Me.Controls.Add(Me.ButtonToevoegen)
        Me.Controls.Add(Me.TextBoxSubMenu)
        Me.Controls.Add(Me.LabelMenu)
        Me.Name = "SubMenuToevoegen"
        Me.Text = "SubMenuToevoegen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelSubMenu As System.Windows.Forms.Label
    Friend WithEvents ComboBoxMenu As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonToevoegen As System.Windows.Forms.Button
    Friend WithEvents TextBoxSubMenu As System.Windows.Forms.TextBox
    Friend WithEvents LabelMenu As System.Windows.Forms.Label
End Class
