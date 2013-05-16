<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUsersModules
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
        Me.LabelModule = New System.Windows.Forms.Label()
        Me.ComboBoxUser = New System.Windows.Forms.ComboBox()
        Me.ListBoxNietGelinkt = New System.Windows.Forms.ListBox()
        Me.ListBoxWelGelinkt = New System.Windows.Forms.ListBox()
        Me.ButtonRechts = New System.Windows.Forms.Button()
        Me.ButtonAllemaalRechts = New System.Windows.Forms.Button()
        Me.ButtonLinks = New System.Windows.Forms.Button()
        Me.ButtonAllemaalLinks = New System.Windows.Forms.Button()
        Me.ListBoxUser = New System.Windows.Forms.ListBox()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.SuspendLayout()
        '
        'LabelUser
        '
        Me.LabelUser.AutoSize = True
        Me.LabelUser.Location = New System.Drawing.Point(455, 40)
        Me.LabelUser.Name = "LabelUser"
        Me.LabelUser.Size = New System.Drawing.Size(29, 13)
        Me.LabelUser.TabIndex = 24
        Me.LabelUser.Text = "User"
        '
        'LabelModule
        '
        Me.LabelModule.AutoSize = True
        Me.LabelModule.Location = New System.Drawing.Point(455, 75)
        Me.LabelModule.Name = "LabelModule"
        Me.LabelModule.Size = New System.Drawing.Size(42, 13)
        Me.LabelModule.TabIndex = 20
        Me.LabelModule.Text = "Module"
        '
        'ComboBoxUser
        '
        Me.ComboBoxUser.FormattingEnabled = True
        Me.ComboBoxUser.Location = New System.Drawing.Point(530, 37)
        Me.ComboBoxUser.Name = "ComboBoxUser"
        Me.ComboBoxUser.Size = New System.Drawing.Size(267, 21)
        Me.ComboBoxUser.TabIndex = 25
        '
        'ListBoxNietGelinkt
        '
        Me.ListBoxNietGelinkt.FormattingEnabled = True
        Me.ListBoxNietGelinkt.Location = New System.Drawing.Point(530, 75)
        Me.ListBoxNietGelinkt.Name = "ListBoxNietGelinkt"
        Me.ListBoxNietGelinkt.Size = New System.Drawing.Size(267, 329)
        Me.ListBoxNietGelinkt.TabIndex = 26
        '
        'ListBoxWelGelinkt
        '
        Me.ListBoxWelGelinkt.FormattingEnabled = True
        Me.ListBoxWelGelinkt.Location = New System.Drawing.Point(884, 75)
        Me.ListBoxWelGelinkt.Name = "ListBoxWelGelinkt"
        Me.ListBoxWelGelinkt.Size = New System.Drawing.Size(267, 329)
        Me.ListBoxWelGelinkt.TabIndex = 27
        '
        'ButtonRechts
        '
        Me.ButtonRechts.Location = New System.Drawing.Point(803, 121)
        Me.ButtonRechts.Name = "ButtonRechts"
        Me.ButtonRechts.Size = New System.Drawing.Size(75, 23)
        Me.ButtonRechts.TabIndex = 28
        Me.ButtonRechts.Text = ">"
        Me.ButtonRechts.UseVisualStyleBackColor = True
        '
        'ButtonAllemaalRechts
        '
        Me.ButtonAllemaalRechts.Location = New System.Drawing.Point(803, 150)
        Me.ButtonAllemaalRechts.Name = "ButtonAllemaalRechts"
        Me.ButtonAllemaalRechts.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAllemaalRechts.TabIndex = 29
        Me.ButtonAllemaalRechts.Text = ">>"
        Me.ButtonAllemaalRechts.UseVisualStyleBackColor = True
        '
        'ButtonLinks
        '
        Me.ButtonLinks.Location = New System.Drawing.Point(803, 284)
        Me.ButtonLinks.Name = "ButtonLinks"
        Me.ButtonLinks.Size = New System.Drawing.Size(75, 23)
        Me.ButtonLinks.TabIndex = 30
        Me.ButtonLinks.Text = "<"
        Me.ButtonLinks.UseVisualStyleBackColor = True
        '
        'ButtonAllemaalLinks
        '
        Me.ButtonAllemaalLinks.Location = New System.Drawing.Point(803, 313)
        Me.ButtonAllemaalLinks.Name = "ButtonAllemaalLinks"
        Me.ButtonAllemaalLinks.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAllemaalLinks.TabIndex = 31
        Me.ButtonAllemaalLinks.Text = "<<"
        Me.ButtonAllemaalLinks.UseVisualStyleBackColor = True
        '
        'ListBoxUser
        '
        Me.ListBoxUser.FormattingEnabled = True
        Me.ListBoxUser.Location = New System.Drawing.Point(57, 36)
        Me.ListBoxUser.Name = "ListBoxUser"
        Me.ListBoxUser.Size = New System.Drawing.Size(120, 95)
        Me.ListBoxUser.TabIndex = 32
        '
        'Splitter1
        '
        Me.Splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Margin = New System.Windows.Forms.Padding(50, 3, 3, 3)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(11, 470)
        Me.Splitter1.TabIndex = 33
        Me.Splitter1.TabStop = False
        '
        'FormUsersModules
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1183, 470)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.ListBoxUser)
        Me.Controls.Add(Me.ButtonAllemaalLinks)
        Me.Controls.Add(Me.ButtonLinks)
        Me.Controls.Add(Me.ButtonAllemaalRechts)
        Me.Controls.Add(Me.ButtonRechts)
        Me.Controls.Add(Me.ListBoxWelGelinkt)
        Me.Controls.Add(Me.ListBoxNietGelinkt)
        Me.Controls.Add(Me.ComboBoxUser)
        Me.Controls.Add(Me.LabelUser)
        Me.Controls.Add(Me.LabelModule)
        Me.MinimumSize = New System.Drawing.Size(1199, 508)
        Me.Name = "FormUsersModules"
        Me.Text = "UsersModules"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelUser As System.Windows.Forms.Label
    Friend WithEvents LabelModule As System.Windows.Forms.Label
    Friend WithEvents ComboBoxUser As System.Windows.Forms.ComboBox
    Friend WithEvents ListBoxNietGelinkt As System.Windows.Forms.ListBox
    Friend WithEvents ListBoxWelGelinkt As System.Windows.Forms.ListBox
    Friend WithEvents ButtonRechts As System.Windows.Forms.Button
    Friend WithEvents ButtonAllemaalRechts As System.Windows.Forms.Button
    Friend WithEvents ButtonLinks As System.Windows.Forms.Button
    Friend WithEvents ButtonAllemaalLinks As System.Windows.Forms.Button
    Friend WithEvents ListBoxUser As System.Windows.Forms.ListBox
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
End Class
