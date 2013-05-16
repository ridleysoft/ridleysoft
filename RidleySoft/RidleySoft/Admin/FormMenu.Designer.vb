<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMenu
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
        Me.LabelMenu = New System.Windows.Forms.Label()
        Me.ComboBoxModule = New System.Windows.Forms.ComboBox()
        Me.ButtonWijzigen = New System.Windows.Forms.Button()
        Me.TextBoxMenuname = New System.Windows.Forms.TextBox()
        Me.LabelModule = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.SuspendLayout()
        '
        'LabelMenu
        '
        Me.LabelMenu.AutoSize = True
        Me.LabelMenu.Location = New System.Drawing.Point(478, 30)
        Me.LabelMenu.Name = "LabelMenu"
        Me.LabelMenu.Size = New System.Drawing.Size(34, 13)
        Me.LabelMenu.TabIndex = 24
        Me.LabelMenu.Text = "Menu"
        '
        'ComboBoxModule
        '
        Me.ComboBoxModule.FormattingEnabled = True
        Me.ComboBoxModule.Location = New System.Drawing.Point(553, 65)
        Me.ComboBoxModule.Name = "ComboBoxModule"
        Me.ComboBoxModule.Size = New System.Drawing.Size(267, 21)
        Me.ComboBoxModule.TabIndex = 23
        '
        'ButtonWijzigen
        '
        Me.ButtonWijzigen.Location = New System.Drawing.Point(478, 118)
        Me.ButtonWijzigen.Name = "ButtonWijzigen"
        Me.ButtonWijzigen.Size = New System.Drawing.Size(89, 23)
        Me.ButtonWijzigen.TabIndex = 22
        Me.ButtonWijzigen.Text = "Edit"
        Me.ButtonWijzigen.UseVisualStyleBackColor = True
        '
        'TextBoxMenuname
        '
        Me.TextBoxMenuname.Location = New System.Drawing.Point(553, 24)
        Me.TextBoxMenuname.Name = "TextBoxMenuname"
        Me.TextBoxMenuname.Size = New System.Drawing.Size(267, 20)
        Me.TextBoxMenuname.TabIndex = 21
        '
        'LabelModule
        '
        Me.LabelModule.AutoSize = True
        Me.LabelModule.Location = New System.Drawing.Point(475, 65)
        Me.LabelModule.Name = "LabelModule"
        Me.LabelModule.Size = New System.Drawing.Size(42, 13)
        Me.LabelModule.TabIndex = 20
        Me.LabelModule.Text = "Module"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(12, 12)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 95)
        Me.ListBox1.TabIndex = 25
        '
        'Splitter1
        '
        Me.Splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Margin = New System.Windows.Forms.Padding(50, 3, 3, 3)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(11, 256)
        Me.Splitter1.TabIndex = 26
        Me.Splitter1.TabStop = False
        '
        'FormMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 256)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.LabelMenu)
        Me.Controls.Add(Me.ComboBoxModule)
        Me.Controls.Add(Me.ButtonWijzigen)
        Me.Controls.Add(Me.TextBoxMenuname)
        Me.Controls.Add(Me.LabelModule)
        Me.MinimumSize = New System.Drawing.Size(860, 294)
        Me.Name = "FormMenu"
        Me.Text = "FormMenu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelMenu As System.Windows.Forms.Label
    Friend WithEvents ComboBoxModule As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonWijzigen As System.Windows.Forms.Button
    Friend WithEvents TextBoxMenuname As System.Windows.Forms.TextBox
    Friend WithEvents LabelModule As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
End Class
