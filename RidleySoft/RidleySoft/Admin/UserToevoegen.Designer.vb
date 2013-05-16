<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserToevoegen
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
        Me.TextBoxPassword123 = New System.Windows.Forms.TextBox()
        Me.TextBoxUsername123 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ButtonToevoegen
        '
        Me.ButtonToevoegen.Location = New System.Drawing.Point(22, 135)
        Me.ButtonToevoegen.Name = "ButtonToevoegen"
        Me.ButtonToevoegen.Size = New System.Drawing.Size(89, 23)
        Me.ButtonToevoegen.TabIndex = 14
        Me.ButtonToevoegen.Text = "Save"
        Me.ButtonToevoegen.UseVisualStyleBackColor = True
        '
        'TextBoxPassword123
        '
        Me.TextBoxPassword123.Location = New System.Drawing.Point(131, 87)
        Me.TextBoxPassword123.Name = "TextBoxPassword123"
        Me.TextBoxPassword123.Size = New System.Drawing.Size(134, 20)
        Me.TextBoxPassword123.TabIndex = 13
        '
        'TextBoxUsername123
        '
        Me.TextBoxUsername123.Location = New System.Drawing.Point(131, 56)
        Me.TextBoxUsername123.Name = "TextBoxUsername123"
        Me.TextBoxUsername123.Size = New System.Drawing.Size(134, 20)
        Me.TextBoxUsername123.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Password"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Username"
        '
        'UserToevoegen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.ButtonToevoegen)
        Me.Controls.Add(Me.TextBoxPassword123)
        Me.Controls.Add(Me.TextBoxUsername123)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "UserToevoegen"
        Me.Text = "UserToevoegen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonToevoegen As System.Windows.Forms.Button
    Friend WithEvents TextBoxPassword123 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxUsername123 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
