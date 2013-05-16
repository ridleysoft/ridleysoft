<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuToevoegen
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
        Me.LabelMenu = New System.Windows.Forms.Label()
        Me.ComboBoxModule = New System.Windows.Forms.ComboBox()
        Me.TextBoxMenuname = New System.Windows.Forms.TextBox()
        Me.LabelModule = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ButtonToevoegen
        '
        Me.ButtonToevoegen.Location = New System.Drawing.Point(71, 143)
        Me.ButtonToevoegen.Name = "ButtonToevoegen"
        Me.ButtonToevoegen.Size = New System.Drawing.Size(89, 23)
        Me.ButtonToevoegen.TabIndex = 27
        Me.ButtonToevoegen.Text = "Save"
        Me.ButtonToevoegen.UseVisualStyleBackColor = True
        '
        'LabelMenu
        '
        Me.LabelMenu.AutoSize = True
        Me.LabelMenu.Location = New System.Drawing.Point(71, 41)
        Me.LabelMenu.Name = "LabelMenu"
        Me.LabelMenu.Size = New System.Drawing.Size(34, 13)
        Me.LabelMenu.TabIndex = 31
        Me.LabelMenu.Text = "Menu"
        '
        'ComboBoxModule
        '
        Me.ComboBoxModule.FormattingEnabled = True
        Me.ComboBoxModule.Location = New System.Drawing.Point(146, 76)
        Me.ComboBoxModule.Name = "ComboBoxModule"
        Me.ComboBoxModule.Size = New System.Drawing.Size(267, 21)
        Me.ComboBoxModule.TabIndex = 30
        '
        'TextBoxMenuname
        '
        Me.TextBoxMenuname.Location = New System.Drawing.Point(146, 35)
        Me.TextBoxMenuname.Name = "TextBoxMenuname"
        Me.TextBoxMenuname.Size = New System.Drawing.Size(267, 20)
        Me.TextBoxMenuname.TabIndex = 29
        '
        'LabelModule
        '
        Me.LabelModule.AutoSize = True
        Me.LabelModule.Location = New System.Drawing.Point(68, 76)
        Me.LabelModule.Name = "LabelModule"
        Me.LabelModule.Size = New System.Drawing.Size(42, 13)
        Me.LabelModule.TabIndex = 28
        Me.LabelModule.Text = "Module"
        '
        'MenuToevoegen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(597, 352)
        Me.Controls.Add(Me.LabelMenu)
        Me.Controls.Add(Me.ComboBoxModule)
        Me.Controls.Add(Me.TextBoxMenuname)
        Me.Controls.Add(Me.LabelModule)
        Me.Controls.Add(Me.ButtonToevoegen)
        Me.Name = "MenuToevoegen"
        Me.Text = "MenuToevoegen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonToevoegen As System.Windows.Forms.Button
    Friend WithEvents LabelMenu As System.Windows.Forms.Label
    Friend WithEvents ComboBoxModule As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxMenuname As System.Windows.Forms.TextBox
    Friend WithEvents LabelModule As System.Windows.Forms.Label
End Class
