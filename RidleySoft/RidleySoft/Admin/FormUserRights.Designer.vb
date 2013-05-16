<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUserRights
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
        Me.ButtonAllemaalLinks = New System.Windows.Forms.Button()
        Me.ButtonLinks = New System.Windows.Forms.Button()
        Me.ButtonAllemaalRechts = New System.Windows.Forms.Button()
        Me.ButtonRechts = New System.Windows.Forms.Button()
        Me.ListBoxWelGelinkt = New System.Windows.Forms.ListBox()
        Me.ListBoxNietGelinkt = New System.Windows.Forms.ListBox()
        Me.ComboBoxUser = New System.Windows.Forms.ComboBox()
        Me.LabelUser = New System.Windows.Forms.Label()
        Me.LabelRights = New System.Windows.Forms.Label()
        Me.ListBoxUser = New System.Windows.Forms.ListBox()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.SuspendLayout()
        '
        'ButtonAllemaalLinks
        '
        Me.ButtonAllemaalLinks.Location = New System.Drawing.Point(769, 331)
        Me.ButtonAllemaalLinks.Name = "ButtonAllemaalLinks"
        Me.ButtonAllemaalLinks.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAllemaalLinks.TabIndex = 40
        Me.ButtonAllemaalLinks.Text = "<<"
        Me.ButtonAllemaalLinks.UseVisualStyleBackColor = True
        '
        'ButtonLinks
        '
        Me.ButtonLinks.Location = New System.Drawing.Point(769, 302)
        Me.ButtonLinks.Name = "ButtonLinks"
        Me.ButtonLinks.Size = New System.Drawing.Size(75, 23)
        Me.ButtonLinks.TabIndex = 39
        Me.ButtonLinks.Text = "<"
        Me.ButtonLinks.UseVisualStyleBackColor = True
        '
        'ButtonAllemaalRechts
        '
        Me.ButtonAllemaalRechts.Location = New System.Drawing.Point(769, 168)
        Me.ButtonAllemaalRechts.Name = "ButtonAllemaalRechts"
        Me.ButtonAllemaalRechts.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAllemaalRechts.TabIndex = 38
        Me.ButtonAllemaalRechts.Text = ">>"
        Me.ButtonAllemaalRechts.UseVisualStyleBackColor = True
        '
        'ButtonRechts
        '
        Me.ButtonRechts.Location = New System.Drawing.Point(769, 139)
        Me.ButtonRechts.Name = "ButtonRechts"
        Me.ButtonRechts.Size = New System.Drawing.Size(75, 23)
        Me.ButtonRechts.TabIndex = 37
        Me.ButtonRechts.Text = ">"
        Me.ButtonRechts.UseVisualStyleBackColor = True
        '
        'ListBoxWelGelinkt
        '
        Me.ListBoxWelGelinkt.FormattingEnabled = True
        Me.ListBoxWelGelinkt.Location = New System.Drawing.Point(850, 93)
        Me.ListBoxWelGelinkt.Name = "ListBoxWelGelinkt"
        Me.ListBoxWelGelinkt.Size = New System.Drawing.Size(267, 329)
        Me.ListBoxWelGelinkt.TabIndex = 36
        '
        'ListBoxNietGelinkt
        '
        Me.ListBoxNietGelinkt.FormattingEnabled = True
        Me.ListBoxNietGelinkt.Location = New System.Drawing.Point(496, 93)
        Me.ListBoxNietGelinkt.Name = "ListBoxNietGelinkt"
        Me.ListBoxNietGelinkt.Size = New System.Drawing.Size(267, 329)
        Me.ListBoxNietGelinkt.TabIndex = 35
        '
        'ComboBoxUser
        '
        Me.ComboBoxUser.FormattingEnabled = True
        Me.ComboBoxUser.Location = New System.Drawing.Point(496, 55)
        Me.ComboBoxUser.Name = "ComboBoxUser"
        Me.ComboBoxUser.Size = New System.Drawing.Size(267, 21)
        Me.ComboBoxUser.TabIndex = 34
        '
        'LabelUser
        '
        Me.LabelUser.AutoSize = True
        Me.LabelUser.Location = New System.Drawing.Point(421, 58)
        Me.LabelUser.Name = "LabelUser"
        Me.LabelUser.Size = New System.Drawing.Size(29, 13)
        Me.LabelUser.TabIndex = 33
        Me.LabelUser.Text = "User"
        '
        'LabelRights
        '
        Me.LabelRights.AutoSize = True
        Me.LabelRights.Location = New System.Drawing.Point(421, 93)
        Me.LabelRights.Name = "LabelRights"
        Me.LabelRights.Size = New System.Drawing.Size(37, 13)
        Me.LabelRights.TabIndex = 32
        Me.LabelRights.Text = "Rights"
        '
        'ListBoxUser
        '
        Me.ListBoxUser.FormattingEnabled = True
        Me.ListBoxUser.Location = New System.Drawing.Point(12, 33)
        Me.ListBoxUser.Name = "ListBoxUser"
        Me.ListBoxUser.Size = New System.Drawing.Size(120, 95)
        Me.ListBoxUser.TabIndex = 41
        '
        'Splitter1
        '
        Me.Splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Margin = New System.Windows.Forms.Padding(50, 3, 3, 3)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(11, 599)
        Me.Splitter1.TabIndex = 42
        Me.Splitter1.TabStop = False
        '
        'FormUserRights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1152, 599)
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
        Me.Controls.Add(Me.LabelRights)
        Me.MinimumSize = New System.Drawing.Size(1168, 637)
        Me.Name = "FormUserRights"
        Me.Text = "FormRights"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonAllemaalLinks As System.Windows.Forms.Button
    Friend WithEvents ButtonLinks As System.Windows.Forms.Button
    Friend WithEvents ButtonAllemaalRechts As System.Windows.Forms.Button
    Friend WithEvents ButtonRechts As System.Windows.Forms.Button
    Friend WithEvents ListBoxWelGelinkt As System.Windows.Forms.ListBox
    Friend WithEvents ListBoxNietGelinkt As System.Windows.Forms.ListBox
    Friend WithEvents ComboBoxUser As System.Windows.Forms.ComboBox
    Friend WithEvents LabelUser As System.Windows.Forms.Label
    Friend WithEvents LabelRights As System.Windows.Forms.Label
    Friend WithEvents ListBoxUser As System.Windows.Forms.ListBox
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
End Class
