<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStopProcedure2
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LabelLabor = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LabelKPI = New System.Windows.Forms.Label()
        Me.LabelStopTijd = New System.Windows.Forms.Label()
        Me.LabelStartTijd = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.LabelPRB.Location = New System.Drawing.Point(288, 152)
        Me.LabelPRB.Name = "LabelPRB"
        Me.LabelPRB.Size = New System.Drawing.Size(120, 39)
        Me.LabelPRB.TabIndex = 6
        Me.LabelPRB.Text = "Label2"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.LabelLabor)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.LabelKPI)
        Me.GroupBox1.Controls.Add(Me.LabelStopTijd)
        Me.GroupBox1.Controls.Add(Me.LabelStartTijd)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 221)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(969, 296)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'LabelLabor
        '
        Me.LabelLabor.AutoSize = True
        Me.LabelLabor.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!)
        Me.LabelLabor.Location = New System.Drawing.Point(337, 152)
        Me.LabelLabor.Name = "LabelLabor"
        Me.LabelLabor.Size = New System.Drawing.Size(139, 39)
        Me.LabelLabor.TabIndex = 15
        Me.LabelLabor.Text = "Label10"
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!)
        Me.Label3.Location = New System.Drawing.Point(6, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(296, 39)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Voorziene werktijd"
        '
        'LabelKPI
        '
        Me.LabelKPI.AutoSize = True
        Me.LabelKPI.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!)
        Me.LabelKPI.ForeColor = System.Drawing.Color.Red
        Me.LabelKPI.Location = New System.Drawing.Point(337, 211)
        Me.LabelKPI.Name = "LabelKPI"
        Me.LabelKPI.Size = New System.Drawing.Size(139, 39)
        Me.LabelKPI.TabIndex = 13
        Me.LabelKPI.Text = "Label10"
        '
        'LabelStopTijd
        '
        Me.LabelStopTijd.AutoSize = True
        Me.LabelStopTijd.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!)
        Me.LabelStopTijd.Location = New System.Drawing.Point(337, 97)
        Me.LabelStopTijd.Name = "LabelStopTijd"
        Me.LabelStopTijd.Size = New System.Drawing.Size(120, 39)
        Me.LabelStopTijd.TabIndex = 12
        Me.LabelStopTijd.Text = "Label9"
        '
        'LabelStartTijd
        '
        Me.LabelStartTijd.AutoSize = True
        Me.LabelStartTijd.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!)
        Me.LabelStartTijd.Location = New System.Drawing.Point(337, 42)
        Me.LabelStartTijd.Name = "LabelStartTijd"
        Me.LabelStartTijd.Size = New System.Drawing.Size(120, 39)
        Me.LabelStartTijd.TabIndex = 9
        Me.LabelStartTijd.Text = "Label6"
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(6, 211)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 39)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "KPI"
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!)
        Me.Label4.Location = New System.Drawing.Point(6, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(131, 39)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Stoptijd"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!)
        Me.Label1.Location = New System.Drawing.Point(6, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 39)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Starttijd"
        '
        'Timer1
        '
        '
        'FormStopProcedure2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1208, 558)
        Me.Controls.Add(Me.LabelPRB)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormStopProcedure2"
        Me.Text = "FormStopProcedure2"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelPRB As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelKPI As System.Windows.Forms.Label
    Friend WithEvents LabelStopTijd As System.Windows.Forms.Label
    Friend WithEvents LabelStartTijd As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelLabor As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
