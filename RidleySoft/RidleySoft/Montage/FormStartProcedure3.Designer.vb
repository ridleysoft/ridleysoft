<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStartProcedure3
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
        Me.components = New System.ComponentModel.Container()
        Me.LabelPRB = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LabelMontageNiveau = New System.Windows.Forms.Label()
        Me.LabelDesign = New System.Windows.Forms.Label()
        Me.LabelModel = New System.Windows.Forms.Label()
        Me.LabelProvidedTijd = New System.Windows.Forms.Label()
        Me.LabelStartTijd = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelPRB
        '
        Me.LabelPRB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelPRB.AutoSize = True
        Me.LabelPRB.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!)
        Me.LabelPRB.Location = New System.Drawing.Point(217, 126)
        Me.LabelPRB.Name = "LabelPRB"
        Me.LabelPRB.Size = New System.Drawing.Size(120, 39)
        Me.LabelPRB.TabIndex = 4
        Me.LabelPRB.Text = "Label2"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!)
        Me.Label1.Location = New System.Drawing.Point(6, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 39)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Starttijd"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!)
        Me.Label2.Location = New System.Drawing.Point(6, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(296, 39)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Voorziene werktijd"
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!)
        Me.Label3.Location = New System.Drawing.Point(6, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 39)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Model"
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!)
        Me.Label4.Location = New System.Drawing.Point(6, 193)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 39)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Design"
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!)
        Me.Label5.Location = New System.Drawing.Point(6, 253)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(250, 39)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Montageniveau"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.LabelMontageNiveau)
        Me.GroupBox1.Controls.Add(Me.LabelDesign)
        Me.GroupBox1.Controls.Add(Me.LabelModel)
        Me.GroupBox1.Controls.Add(Me.LabelProvidedTijd)
        Me.GroupBox1.Controls.Add(Me.LabelStartTijd)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 191)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(827, 318)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'LabelMontageNiveau
        '
        Me.LabelMontageNiveau.AutoSize = True
        Me.LabelMontageNiveau.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!)
        Me.LabelMontageNiveau.Location = New System.Drawing.Point(319, 253)
        Me.LabelMontageNiveau.Name = "LabelMontageNiveau"
        Me.LabelMontageNiveau.Size = New System.Drawing.Size(139, 39)
        Me.LabelMontageNiveau.TabIndex = 13
        Me.LabelMontageNiveau.Text = "Label10"
        '
        'LabelDesign
        '
        Me.LabelDesign.AutoSize = True
        Me.LabelDesign.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!)
        Me.LabelDesign.Location = New System.Drawing.Point(319, 193)
        Me.LabelDesign.Name = "LabelDesign"
        Me.LabelDesign.Size = New System.Drawing.Size(120, 39)
        Me.LabelDesign.TabIndex = 12
        Me.LabelDesign.Text = "Label9"
        '
        'LabelModel
        '
        Me.LabelModel.AutoSize = True
        Me.LabelModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!)
        Me.LabelModel.Location = New System.Drawing.Point(319, 133)
        Me.LabelModel.Name = "LabelModel"
        Me.LabelModel.Size = New System.Drawing.Size(120, 39)
        Me.LabelModel.TabIndex = 11
        Me.LabelModel.Text = "Label8"
        '
        'LabelProvidedTijd
        '
        Me.LabelProvidedTijd.AutoSize = True
        Me.LabelProvidedTijd.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!)
        Me.LabelProvidedTijd.Location = New System.Drawing.Point(319, 81)
        Me.LabelProvidedTijd.Name = "LabelProvidedTijd"
        Me.LabelProvidedTijd.Size = New System.Drawing.Size(120, 39)
        Me.LabelProvidedTijd.TabIndex = 10
        Me.LabelProvidedTijd.Text = "Label7"
        '
        'LabelStartTijd
        '
        Me.LabelStartTijd.AutoSize = True
        Me.LabelStartTijd.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!)
        Me.LabelStartTijd.Location = New System.Drawing.Point(319, 27)
        Me.LabelStartTijd.Name = "LabelStartTijd"
        Me.LabelStartTijd.Size = New System.Drawing.Size(120, 39)
        Me.LabelStartTijd.TabIndex = 9
        Me.LabelStartTijd.Text = "Label6"
        '
        'Timer1
        '
        '
        'FormStartProcedure3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 521)
        Me.Controls.Add(Me.LabelPRB)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormStartProcedure3"
        Me.Text = "FormStartProcedure3"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelPRB As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelMontageNiveau As System.Windows.Forms.Label
    Friend WithEvents LabelDesign As System.Windows.Forms.Label
    Friend WithEvents LabelModel As System.Windows.Forms.Label
    Friend WithEvents LabelProvidedTijd As System.Windows.Forms.Label
    Friend WithEvents LabelStartTijd As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
