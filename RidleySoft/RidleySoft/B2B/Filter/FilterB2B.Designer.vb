<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FilterB2B
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RadioButtonItemShowVisible = New System.Windows.Forms.RadioButton()
        Me.RadioButtonItemShowNotVisible = New System.Windows.Forms.RadioButton()
        Me.RadioButtonSoldOut = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBoxArtikelNaam = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButtonVisible = New System.Windows.Forms.RadioButton()
        Me.RadioButtonNotVisi = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxItemUrl = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TextBoxItemMenuName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonFilter
        '
        Me.ButtonFilter.Location = New System.Drawing.Point(636, 31)
        Me.ButtonFilter.Name = "ButtonFilter"
        Me.ButtonFilter.Size = New System.Drawing.Size(75, 23)
        Me.ButtonFilter.TabIndex = 16
        Me.ButtonFilter.Text = "Filter"
        Me.ButtonFilter.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadioButtonItemShowVisible)
        Me.GroupBox2.Controls.Add(Me.RadioButtonItemShowNotVisible)
        Me.GroupBox2.Controls.Add(Me.RadioButtonSoldOut)
        Me.GroupBox2.Location = New System.Drawing.Point(116, 211)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(287, 35)
        Me.GroupBox2.TabIndex = 65
        Me.GroupBox2.TabStop = False
        '
        'RadioButtonItemShowVisible
        '
        Me.RadioButtonItemShowVisible.AutoSize = True
        Me.RadioButtonItemShowVisible.Location = New System.Drawing.Point(6, 12)
        Me.RadioButtonItemShowVisible.Name = "RadioButtonItemShowVisible"
        Me.RadioButtonItemShowVisible.Size = New System.Drawing.Size(55, 17)
        Me.RadioButtonItemShowVisible.TabIndex = 28
        Me.RadioButtonItemShowVisible.TabStop = True
        Me.RadioButtonItemShowVisible.Text = "Visible"
        Me.RadioButtonItemShowVisible.UseVisualStyleBackColor = True
        '
        'RadioButtonItemShowNotVisible
        '
        Me.RadioButtonItemShowNotVisible.AutoSize = True
        Me.RadioButtonItemShowNotVisible.Location = New System.Drawing.Point(102, 14)
        Me.RadioButtonItemShowNotVisible.Name = "RadioButtonItemShowNotVisible"
        Me.RadioButtonItemShowNotVisible.Size = New System.Drawing.Size(74, 17)
        Me.RadioButtonItemShowNotVisible.TabIndex = 29
        Me.RadioButtonItemShowNotVisible.TabStop = True
        Me.RadioButtonItemShowNotVisible.Text = "Not visible"
        Me.RadioButtonItemShowNotVisible.UseVisualStyleBackColor = True
        '
        'RadioButtonSoldOut
        '
        Me.RadioButtonSoldOut.AutoSize = True
        Me.RadioButtonSoldOut.Location = New System.Drawing.Point(192, 14)
        Me.RadioButtonSoldOut.Name = "RadioButtonSoldOut"
        Me.RadioButtonSoldOut.Size = New System.Drawing.Size(80, 17)
        Me.RadioButtonSoldOut.TabIndex = 30
        Me.RadioButtonSoldOut.TabStop = True
        Me.RadioButtonSoldOut.Text = "Uitverkocht"
        Me.RadioButtonSoldOut.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 221)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "Item show:"
        '
        'TextBoxArtikelNaam
        '
        Me.TextBoxArtikelNaam.Location = New System.Drawing.Point(116, 33)
        Me.TextBoxArtikelNaam.Name = "TextBoxArtikelNaam"
        Me.TextBoxArtikelNaam.Size = New System.Drawing.Size(421, 20)
        Me.TextBoxArtikelNaam.TabIndex = 62
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 61
        Me.Label6.Text = "Artikelnaam:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButtonVisible)
        Me.GroupBox1.Controls.Add(Me.RadioButtonNotVisi)
        Me.GroupBox1.Location = New System.Drawing.Point(116, 167)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(176, 34)
        Me.GroupBox1.TabIndex = 64
        Me.GroupBox1.TabStop = False
        '
        'RadioButtonVisible
        '
        Me.RadioButtonVisible.AutoSize = True
        Me.RadioButtonVisible.Location = New System.Drawing.Point(6, 11)
        Me.RadioButtonVisible.Name = "RadioButtonVisible"
        Me.RadioButtonVisible.Size = New System.Drawing.Size(55, 17)
        Me.RadioButtonVisible.TabIndex = 19
        Me.RadioButtonVisible.TabStop = True
        Me.RadioButtonVisible.Text = "Visible"
        Me.RadioButtonVisible.UseVisualStyleBackColor = True
        '
        'RadioButtonNotVisi
        '
        Me.RadioButtonNotVisi.AutoSize = True
        Me.RadioButtonNotVisi.Location = New System.Drawing.Point(102, 13)
        Me.RadioButtonNotVisi.Name = "RadioButtonNotVisi"
        Me.RadioButtonNotVisi.Size = New System.Drawing.Size(74, 17)
        Me.RadioButtonNotVisi.TabIndex = 20
        Me.RadioButtonNotVisi.TabStop = True
        Me.RadioButtonNotVisi.Text = "Not visible"
        Me.RadioButtonNotVisi.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 179)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 58
        Me.Label4.Text = "Visibility"
        '
        'TextBoxItemUrl
        '
        Me.TextBoxItemUrl.Location = New System.Drawing.Point(116, 136)
        Me.TextBoxItemUrl.Name = "TextBoxItemUrl"
        Me.TextBoxItemUrl.Size = New System.Drawing.Size(421, 20)
        Me.TextBoxItemUrl.TabIndex = 57
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(116, 102)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(421, 21)
        Me.ComboBox1.TabIndex = 56
        '
        'TextBoxItemMenuName
        '
        Me.TextBoxItemMenuName.Location = New System.Drawing.Point(116, 67)
        Me.TextBoxItemMenuName.Name = "TextBoxItemMenuName"
        Me.TextBoxItemMenuName.Size = New System.Drawing.Size(421, 20)
        Me.TextBoxItemMenuName.TabIndex = 55
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "Item Menu Url:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Type:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Item menu:"
        '
        'FilterB2B
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(722, 364)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextBoxArtikelNaam)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBoxItemUrl)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.TextBoxItemMenuName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonFilter)
        Me.Name = "FilterB2B"
        Me.Text = "FilterB2B"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonFilter As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonItemShowVisible As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonItemShowNotVisible As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonSoldOut As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBoxArtikelNaam As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonVisible As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonNotVisi As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxItemUrl As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxItemMenuName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
