<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminFormUser
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxUsername = New System.Windows.Forms.TextBox()
        Me.TextBoxPassword1 = New System.Windows.Forms.TextBox()
        Me.ButtonWijzigen = New System.Windows.Forms.Button()
        Me.ListBoxUser = New System.Windows.Forms.ListBox()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(389, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Username"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(389, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Password"
        '
        'TextBoxUsername
        '
        Me.TextBoxUsername.AcceptsReturn = True
        Me.TextBoxUsername.Location = New System.Drawing.Point(501, 48)
        Me.TextBoxUsername.Name = "TextBoxUsername"
        Me.TextBoxUsername.Size = New System.Drawing.Size(134, 20)
        Me.TextBoxUsername.TabIndex = 2
        '
        'TextBoxPassword1
        '
        Me.TextBoxPassword1.AcceptsReturn = True
        Me.TextBoxPassword1.Location = New System.Drawing.Point(501, 79)
        Me.TextBoxPassword1.Name = "TextBoxPassword1"
        Me.TextBoxPassword1.Size = New System.Drawing.Size(134, 20)
        Me.TextBoxPassword1.TabIndex = 3
        '
        'ButtonWijzigen
        '
        Me.ButtonWijzigen.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonWijzigen.Location = New System.Drawing.Point(392, 156)
        Me.ButtonWijzigen.Name = "ButtonWijzigen"
        Me.ButtonWijzigen.Size = New System.Drawing.Size(89, 23)
        Me.ButtonWijzigen.TabIndex = 9
        Me.ButtonWijzigen.Text = "Edit"
        Me.ButtonWijzigen.UseVisualStyleBackColor = True
        '
        'ListBoxUser
        '
        Me.ListBoxUser.FormattingEnabled = True
        Me.ListBoxUser.Location = New System.Drawing.Point(0, 0)
        Me.ListBoxUser.Name = "ListBoxUser"
        Me.ListBoxUser.Size = New System.Drawing.Size(120, 95)
        Me.ListBoxUser.TabIndex = 10
        '
        'Splitter1
        '
        Me.Splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Margin = New System.Windows.Forms.Padding(3, 3, 150, 3)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Padding = New System.Windows.Forms.Padding(0, 0, 150, 0)
        Me.Splitter1.Size = New System.Drawing.Size(10, 251)
        Me.Splitter1.TabIndex = 11
        Me.Splitter1.TabStop = False
        '
        'AdminFormUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(725, 251)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.ListBoxUser)
        Me.Controls.Add(Me.ButtonWijzigen)
        Me.Controls.Add(Me.TextBoxPassword1)
        Me.Controls.Add(Me.TextBoxUsername)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "AdminFormUser"
        Me.Text = "AdminFormUser"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPassword1 As System.Windows.Forms.TextBox
    Friend WithEvents ButtonWijzigen As System.Windows.Forms.Button
    Friend WithEvents TextBoxUsername As System.Windows.Forms.TextBox
    Friend WithEvents ListBoxUser As System.Windows.Forms.ListBox
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
End Class
