<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLabel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLabel))
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ButtonKlein = New System.Windows.Forms.Button()
        Me.LabelVendorItem = New System.Windows.Forms.Label()
        Me.TextBoxSerial = New System.Windows.Forms.TextBox()
        Me.LabelSerial = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.LabelVendorItemNr = New System.Windows.Forms.Label()
        Me.LabelDescription = New System.Windows.Forms.Label()
        Me.LabelArticleNr = New System.Windows.Forms.Label()
        Me.LabelBarcode = New System.Windows.Forms.Label()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintDocumentEmployee = New System.Drawing.Printing.PrintDocument()
        Me.PrintDocument3 = New System.Drawing.Printing.PrintDocument()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(65, 51)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(260, 20)
        Me.TextBox1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(65, 95)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Zoeken"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.ButtonKlein)
        Me.Panel1.Controls.Add(Me.LabelVendorItem)
        Me.Panel1.Controls.Add(Me.TextBoxSerial)
        Me.Panel1.Controls.Add(Me.LabelSerial)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.LabelVendorItemNr)
        Me.Panel1.Controls.Add(Me.LabelDescription)
        Me.Panel1.Controls.Add(Me.LabelArticleNr)
        Me.Panel1.Controls.Add(Me.LabelBarcode)
        Me.Panel1.Location = New System.Drawing.Point(65, 51)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(765, 470)
        Me.Panel1.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(62, 249)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(328, 214)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'ButtonKlein
        '
        Me.ButtonKlein.Location = New System.Drawing.Point(412, 411)
        Me.ButtonKlein.Name = "ButtonKlein"
        Me.ButtonKlein.Size = New System.Drawing.Size(128, 23)
        Me.ButtonKlein.TabIndex = 9
        Me.ButtonKlein.Text = "Zebra"
        Me.ButtonKlein.UseVisualStyleBackColor = True
        '
        'LabelVendorItem
        '
        Me.LabelVendorItem.AutoSize = True
        Me.LabelVendorItem.Location = New System.Drawing.Point(59, 220)
        Me.LabelVendorItem.Name = "LabelVendorItem"
        Me.LabelVendorItem.Size = New System.Drawing.Size(79, 13)
        Me.LabelVendorItem.TabIndex = 8
        Me.LabelVendorItem.Text = "Vendor item n°:"
        Me.LabelVendorItem.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TextBoxSerial
        '
        Me.TextBoxSerial.Location = New System.Drawing.Point(198, 186)
        Me.TextBoxSerial.Name = "TextBoxSerial"
        Me.TextBoxSerial.Size = New System.Drawing.Size(202, 20)
        Me.TextBoxSerial.TabIndex = 7
        '
        'LabelSerial
        '
        Me.LabelSerial.AutoSize = True
        Me.LabelSerial.Location = New System.Drawing.Point(59, 189)
        Me.LabelSerial.Name = "LabelSerial"
        Me.LabelSerial.Size = New System.Drawing.Size(52, 13)
        Me.LabelSerial.TabIndex = 6
        Me.LabelSerial.Text = "Serial n°: "
        Me.LabelSerial.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(412, 440)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(128, 23)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Dymo"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(683, 440)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Close"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'LabelVendorItemNr
        '
        Me.LabelVendorItemNr.AutoSize = True
        Me.LabelVendorItemNr.Location = New System.Drawing.Point(195, 220)
        Me.LabelVendorItemNr.Name = "LabelVendorItemNr"
        Me.LabelVendorItemNr.Size = New System.Drawing.Size(76, 13)
        Me.LabelVendorItemNr.TabIndex = 3
        Me.LabelVendorItemNr.Text = "Vendor Item nr"
        '
        'LabelDescription
        '
        Me.LabelDescription.AutoSize = True
        Me.LabelDescription.Location = New System.Drawing.Point(59, 163)
        Me.LabelDescription.Name = "LabelDescription"
        Me.LabelDescription.Size = New System.Drawing.Size(60, 13)
        Me.LabelDescription.TabIndex = 2
        Me.LabelDescription.Text = "Description"
        '
        'LabelArticleNr
        '
        Me.LabelArticleNr.AutoSize = True
        Me.LabelArticleNr.Location = New System.Drawing.Point(59, 136)
        Me.LabelArticleNr.Name = "LabelArticleNr"
        Me.LabelArticleNr.Size = New System.Drawing.Size(47, 13)
        Me.LabelArticleNr.TabIndex = 1
        Me.LabelArticleNr.Text = "ArticleNr"
        '
        'LabelBarcode
        '
        Me.LabelBarcode.AutoSize = True
        Me.LabelBarcode.Location = New System.Drawing.Point(59, 44)
        Me.LabelBarcode.Name = "LabelBarcode"
        Me.LabelBarcode.Size = New System.Drawing.Size(47, 13)
        Me.LabelBarcode.TabIndex = 0
        Me.LabelBarcode.Text = "Barcode"
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'FormLabel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(976, 583)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "FormLabel"
        Me.Text = "FormLabel"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LabelVendorItemNr As System.Windows.Forms.Label
    Friend WithEvents LabelDescription As System.Windows.Forms.Label
    Friend WithEvents LabelArticleNr As System.Windows.Forms.Label
    Friend WithEvents LabelBarcode As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents LabelSerial As System.Windows.Forms.Label
    Friend WithEvents LabelVendorItem As System.Windows.Forms.Label
    Friend WithEvents TextBoxSerial As System.Windows.Forms.TextBox
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents ButtonKlein As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PrintDocumentEmployee As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDocument3 As System.Drawing.Printing.PrintDocument
End Class
