<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSubMenu
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
        Me.ButtonWijzigen = New System.Windows.Forms.Button()
        Me.TextBoxSubMenu = New System.Windows.Forms.TextBox()
        Me.LabelMenu = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.SuspendLayout()
        '
        'LabelSubMenu
        '
        Me.LabelSubMenu.AutoSize = True
        Me.LabelSubMenu.Location = New System.Drawing.Point(445, 29)
        Me.LabelSubMenu.Name = "LabelSubMenu"
        Me.LabelSubMenu.Size = New System.Drawing.Size(53, 13)
        Me.LabelSubMenu.TabIndex = 29
        Me.LabelSubMenu.Text = "SubMenu"
        '
        'ComboBoxMenu
        '
        Me.ComboBoxMenu.FormattingEnabled = True
        Me.ComboBoxMenu.Location = New System.Drawing.Point(520, 64)
        Me.ComboBoxMenu.Name = "ComboBoxMenu"
        Me.ComboBoxMenu.Size = New System.Drawing.Size(267, 21)
        Me.ComboBoxMenu.TabIndex = 28
        '
        'ButtonWijzigen
        '
        Me.ButtonWijzigen.Location = New System.Drawing.Point(448, 121)
        Me.ButtonWijzigen.Name = "ButtonWijzigen"
        Me.ButtonWijzigen.Size = New System.Drawing.Size(89, 23)
        Me.ButtonWijzigen.TabIndex = 27
        Me.ButtonWijzigen.Text = "Edit"
        Me.ButtonWijzigen.UseVisualStyleBackColor = True
        '
        'TextBoxSubMenu
        '
        Me.TextBoxSubMenu.Location = New System.Drawing.Point(520, 23)
        Me.TextBoxSubMenu.Name = "TextBoxSubMenu"
        Me.TextBoxSubMenu.Size = New System.Drawing.Size(267, 20)
        Me.TextBoxSubMenu.TabIndex = 26
        '
        'LabelMenu
        '
        Me.LabelMenu.AutoSize = True
        Me.LabelMenu.Location = New System.Drawing.Point(445, 64)
        Me.LabelMenu.Name = "LabelMenu"
        Me.LabelMenu.Size = New System.Drawing.Size(34, 13)
        Me.LabelMenu.TabIndex = 25
        Me.LabelMenu.Text = "Menu"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(12, 12)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 95)
        Me.ListBox1.TabIndex = 30
        '
        'Splitter1
        '
        Me.Splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Margin = New System.Windows.Forms.Padding(50, 3, 3, 3)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(11, 226)
        Me.Splitter1.TabIndex = 31
        Me.Splitter1.TabStop = False
        '
        'FormSubMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(795, 226)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.LabelSubMenu)
        Me.Controls.Add(Me.ComboBoxMenu)
        Me.Controls.Add(Me.ButtonWijzigen)
        Me.Controls.Add(Me.TextBoxSubMenu)
        Me.Controls.Add(Me.LabelMenu)
        Me.MinimumSize = New System.Drawing.Size(811, 264)
        Me.Name = "FormSubMenu"
        Me.Text = "FormSubMenu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelSubMenu As System.Windows.Forms.Label
    Friend WithEvents ComboBoxMenu As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonWijzigen As System.Windows.Forms.Button
    Friend WithEvents TextBoxSubMenu As System.Windows.Forms.TextBox
    Friend WithEvents LabelMenu As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
End Class
