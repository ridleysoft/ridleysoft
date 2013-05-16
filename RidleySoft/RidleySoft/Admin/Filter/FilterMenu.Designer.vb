<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FilterMenu
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
        Me.ButtonFilter = New System.Windows.Forms.Button()
        Me.TextBoxMenu = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxModule = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ButtonFilter
        '
        Me.ButtonFilter.Location = New System.Drawing.Point(424, 29)
        Me.ButtonFilter.Name = "ButtonFilter"
        Me.ButtonFilter.Size = New System.Drawing.Size(75, 23)
        Me.ButtonFilter.TabIndex = 30
        Me.ButtonFilter.Text = "Filter"
        Me.ButtonFilter.UseVisualStyleBackColor = True
        '
        'TextBoxMenu
        '
        Me.TextBoxMenu.Location = New System.Drawing.Point(73, 31)
        Me.TextBoxMenu.Name = "TextBoxMenu"
        Me.TextBoxMenu.Size = New System.Drawing.Size(205, 20)
        Me.TextBoxMenu.TabIndex = 29
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Menu"
        '
        'TextBoxModule
        '
        Me.TextBoxModule.Location = New System.Drawing.Point(73, 57)
        Me.TextBoxModule.Name = "TextBoxModule"
        Me.TextBoxModule.Size = New System.Drawing.Size(205, 20)
        Me.TextBoxModule.TabIndex = 32
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Module"
        '
        'FilterMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(522, 95)
        Me.Controls.Add(Me.TextBoxModule)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ButtonFilter)
        Me.Controls.Add(Me.TextBoxMenu)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FilterMenu"
        Me.Text = "FilterMenu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonFilter As System.Windows.Forms.Button
    Friend WithEvents TextBoxMenu As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxModule As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
