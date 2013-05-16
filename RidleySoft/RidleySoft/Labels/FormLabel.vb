Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Imports System.Text

Public Class FormLabel
    Private strdefaultPrinter As String
    Private strLabelPrinter As String
    Private strBarcode As String
    Private intSelectedRadioButton As Integer
    Private ListControls As List(Of Control)

    Dim xlApp As Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dalabel As DALabel = New DALabel()
        Dim label As DALabel = dalabel.GetUsers(TextBox1.Text)

        Panel1.Show()
        strBarcode = label.Barcode
        LabelBarcode.Text = "*" & label.Barcode & "*"
        LabelArticleNr.Text = label.ArticleID
        LabelDescription.Text = label.Description
        If label.ArticleIDLev <> Nothing Then
            LabelVendorItemNr.Text = label.ArticleIDLev
        Else
            LabelVendorItemNr.Text = "---"
        End If
    End Sub

    Private Sub FormLabel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Forms.FormBorderStyle.None
        LabelBarcode.Font = New Font("IDAutomationHC39M", 14)
        Dim f16 As Font = New Font("Calibri", 12, FontStyle.Bold)
        Dim f12 As Font = New Font("Calibri", 10, FontStyle.Bold)

        LabelArticleNr.Font = New Font("Calibri", 12, FontStyle.Bold)
        LabelDescription.Font = New Font("Calibri", 10, FontStyle.Bold)
        LabelVendorItemNr.Font = New Font("Calibri", 10)
        LabelSerial.Font = New Font("Calibri", 10)
        LabelVendorItem.Font = New Font("Calibri", 10)
        Panel1.Hide()

        Opvullen()
    End Sub

    Public Sub Opvullen()
        Dim daLabels As DALabelPath = New DALabelPath()
        Dim labels As List(Of DALabelPath) = daLabels.getLabels()

        Dim radiobutton As RadioButton
        Dim y As Integer = 10
        For Each item In labels
            radiobutton = New RadioButton()
            AddHandler radiobutton.CheckedChanged, AddressOf radiobuttonKlik
            radiobutton.Tag = item.ID
            radiobutton.Text = item.Name
            radiobutton.Font = New Font("Microsoft Sans Serif", 15)
            radiobutton.Width = 500
            radiobutton.Height = 40
            radiobutton.Location = New Point(15, y)
            GroupBox1.Controls.Add(radiobutton)
            y += 35
        Next
    End Sub

    Private Sub radiobuttonKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim radiobutton2 As RadioButton
        radiobutton2 = CType(sender, RadioButton)
        If radiobutton2.Checked = True Then
            intSelectedRadioButton = radiobutton2.Tag
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel1.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim daLabelData As DALabelData = New DALabelData()
        Dim labelData As List(Of DALabelData) = daLabelData.getLabeldatabylabelID(intSelectedRadioButton)

        Dim dalabel As DALabelPath = New DALabelPath()
        Dim LabelPath As DALabelPath = dalabel.GetLabel("articlebarcode")

        If PrintDialog1.ShowDialog = Forms.DialogResult.OK Then
            MainForm.defaultPrinter = PrinterManager.GetDefaultPrinter()
            Dim printer As String = MainForm.defaultPrinter
            PrinterManager.SetDefaultPrinter(PrintDialog1.PrinterSettings.PrinterName)
            strLabelPrinter = PrinterManager.GetDefaultPrinter()

            strBarcode = "*" & strBarcode & "*"
            Dim Label As DYMO.Label.Framework.ILabel
            Label = DYMO.Label.Framework.Framework.Open(My.Application.Info.DirectoryPath & "\" & LabelPath.Path & ".label")

            For Each item2 In Panel1.Controls
                If TypeOf item2 Is Label Then
                    For Each item In labelData
                        If item2.Name = ("Label" & item.LabelName) Then
                            If item2.Name = "LabelBarcode" Then
                                Label.SetObjectText("TXTBARCODE", strBarcode)
                            ElseIf item2.Name = "LabelArticleNr" Then
                                Label.SetObjectText("TXTARTICLE", LabelArticleNr.Text)
                            ElseIf item2.Name = "LabelDescription" Then
                                Label.SetObjectText("TXTDESCRIPTION", LabelDescription.Text)
                            ElseIf item2.Name = "LabelSerial" Then
                                Label.SetObjectText("TXTSERIAL", LabelSerial.Text & " " & TextBoxSerial.Text)
                            ElseIf item2.Name = "LabelVendorItem" Then
                                Label.SetObjectText("TXTVENDORITEMNR", LabelVendorItem.Text & " " & LabelVendorItemNr.Text)
                            End If
                        End If
                    Next
                End If
            Next
            
            Label.Print(strLabelPrinter)
            PrinterManager.SetDefaultPrinter(MainForm.defaultPrinter)
        End If
    End Sub

    Private Sub printDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        'Specify what to print and how to print in this event handler.
        ' The follow code specify a string and a rectangle to be print 
        Dim f As Font = New Font("IDAutomationHC39M", 6)
        Dim f16 As Font = New Font("Calibri", 10, FontStyle.Bold)
        Dim f12B As Font = New Font("Calibri", 8, FontStyle.Bold)
        Dim f12 As Font = New Font("Calibri", 5)
        Dim br As SolidBrush = New SolidBrush(Color.Black)
        Dim p As Pen = New Pen(Color.Black)
        Dim barcode2 As String
        barcode2 = LabelBarcode.Text

        e.Graphics.DrawString((barcode2.Substring(1, barcode2.Length - 2)), f, br, 55, 5)
        e.Graphics.DrawString(LabelArticleNr.Text, f16, br, 60, 45)
        'e.Graphics.DrawString(LabelDescription.Text, f12B, br, 70, 65)
        'e.Graphics.DrawString(LabelSerial.Text & " " & TextBoxSerial.Text, f12, br, (79 + (LabelVendorItem.Text.Length + LabelSerial.Text.Length)), 80)
        'e.Graphics.DrawString(LabelVendorItem.Text & "  " & LabelVendorItemNr.Text, f12, br, 85, 85)
    End Sub

    Private Sub ButtonKlein_Click(sender As Object, e As EventArgs) Handles ButtonKlein.Click
        AddHandler PrintDocument1.PrintPage, AddressOf Me.printDocument1_PrintPage
        Me.PrintPreviewDialog1.Document = Me.PrintDocument1

        'Dim dalabel As DALabelPath = New DALabelPath()
        'Dim LabelPath As DALabelPath = dalabel.GetLabel("articlebarcode")

        If PrintDialog1.ShowDialog = Forms.DialogResult.OK Then
            MainForm.defaultPrinter = PrinterManager.GetDefaultPrinter()
            Dim printer As String = MainForm.defaultPrinter
            PrinterManager.SetDefaultPrinter(PrintDialog1.PrinterSettings.PrinterName)
            strLabelPrinter = PrinterManager.GetDefaultPrinter()

            'Dim _print As New ZebraLabels.ZebraPrint
            '_print.StartWrite("//printserver//zebra001")
            'Dim _Text As String = "Print test"
            '_print.Write("A30,120,0,4,2,1,N,""" & _Text & """")
            '_print.EndWrite()

            Dim daLabelData As DALabelData = New DALabelData()
            Dim labelData As List(Of DALabelData) = daLabelData.getLabeldatabylabelID(intSelectedRadioButton)

            Dim dalabel As DALabelPath = New DALabelPath()
            Dim label As DALabelPath = dalabel.GetLabelbyID(intSelectedRadioButton)

            If label.Name = "Zebra" Then
                ' Bp1,p2,p3,p4,p5,p6,p7,p8,"DATA" is a bar code
                ' p1 = Horizontal Start Position
                ' p2 = Vertical Start Position
                ' p3 = Rotation; 0 = no Rotation
                ' p4 = Bar Code Selection; 1A = Code 128A
                ' p5 = Narrow bar width in dots; p4=1A: 1-10
                ' p6 = Wide bar width in dots; 2-30; value doesn't matter for Code 128
                ' p7 = Bar Code Height in dots
                ' p8 = Print Human Readable code; B = yes; N = no
                ' "DATA" is the string to print

                Dim p As New PrintRaw
                Dim s As New StringBuilder
                s.AppendLine("N")   ' Start new document
                s.AppendLine("D15") ' Set Density
                s.AppendLine("S1")  ' Set Speed
                s.AppendLine("A100,150,0,1,2,1,N,""" & LabelArticleNr.Text & """") ' print text  
                s.AppendLine("B115,20,0,3,1,2,70,B,""" & (strBarcode) & """") ' print barcode  
                s.AppendLine("P1") ' number of times to print  
                p.Print(s, strLabelPrinter)
            End If

            PrinterManager.SetDefaultPrinter(MainForm.defaultPrinter)
        End If
    End Sub

    Private Sub EditEmpDetails(ByVal sFile As String)
        ' THE EXCEL NAMESPACE ALLOWS US TO USE THE EXCEL APPLICATION CLASS

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(sFile)           ' WORKBOOK TO OPEN THE EXCEL FILE.
        xlWorkSheet = xlWorkBook.Worksheets("AfdrukDYMO")    ' THE NAME OF THE WORK SHEET. 

        xlWorkSheet.Cells(1, 1) = LabelBarcode.Text
        xlWorkSheet.Cells(2, 1) = LabelArticleNr.Text
        xlWorkSheet.Cells(4, 1) = LabelDescription.Text
        xlWorkSheet.Cells(6, 1) = LabelSerial.Text
        xlWorkSheet.Cells(8, 1) = LabelVendorItemNr.Text
        xlWorkSheet.SaveAs("C:\Users\stefc\Desktop\NAV-Labels2")

        ' CLEAN UP. (CLOSE INSTANCES OF EXCEL OBJECTS.)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp) : xlApp = Nothing
        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook) : xlWorkBook = Nothing
        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet) : xlWorkSheet = Nothing

        Dim strFile As String = "C:\Users\stefc\Desktop\NAV-Labels2"
        Dim objProcess As New System.Diagnostics.ProcessStartInfo

        With objProcess
            .FileName = strFile
            .WindowStyle = ProcessWindowStyle.Hidden
            .Verb = "print"

            .CreateNoWindow = True
            .UseShellExecute = True
        End With
        Try
            System.Diagnostics.Process.Start(objProcess)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub FormLabel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        PrinterManager.SetDefaultPrinter(strdefaultPrinter)
    End Sub
End Class