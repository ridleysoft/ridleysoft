Imports System.Drawing.Printing

Public Class PCPrint : Inherits Printing.PrintDocument
    Private _font As Font
    Private _text As String

    Public Property TextToPrint() As String
        Get
            Return _text
        End Get
        Set(value As String)
            _text = value
        End Set
    End Property

    Public Property PrinterFont() As Font
        Get
            Return _font
        End Get
        Set(value As Font)
            _font = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()

        _text = String.Empty
    End Sub

    Public Sub New(ByVal str As String)
        MyBase.New()

        _text = str
    End Sub

    Protected Overrides Sub OnBeginPrint(ByVal e As PrintEventArgs)
        MyBase.OnBeginPrint(e)

        If _font Is Nothing Then
            _font = New Font("Times New Roman", 10)
        End If
    End Sub

    Protected Overrides Sub OnPrintPage(ByVal e As PrintPageEventArgs)
        MyBase.OnPrintPage(e)

        Static curChar As Integer
        Dim printHeight As Integer
        Dim printWidth As Integer
        Dim leftMargin As Integer
        Dim rightMargin As Integer
        Dim lines As Int32
        Dim chars As Int32

        With MyBase.DefaultPageSettings
            printHeight = .PaperSize.Height - .Margins.Top - .Margins.Bottom
            printWidth = .PaperSize.Width - .Margins.Left - .Margins.Right
            leftMargin = .Margins.Left
            rightMargin = .Margins.Top
        End With

        If MyBase.DefaultPageSettings.Landscape Then
            Dim tmp As Integer
            tmp = printHeight
            printHeight = printWidth
            printWidth = tmp
        End If

        Dim numLines As Int32 = CInt(printHeight / PrinterFont.Height)

        Dim printArea As New RectangleF(leftMargin, rightMargin, printWidth, printHeight)

        Dim format As New StringFormat(StringFormatFlags.LineLimit)

        e.Graphics.MeasureString(_text.Substring(curChar), PrinterFont, New SizeF(printWidth, printHeight), format, chars, lines)

        e.Graphics.DrawString(TextToPrint.Substring(curChar), PrinterFont, Brushes.Black, printArea, format)

        curChar += chars

        If curChar < _text.Length Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            curChar = 0
        End If
    End Sub
    Public Function RemoveZeros(ByVal value As Integer) As Integer
        'Check the value passed into the function,
        'if the value is a 0 (zero) then return a 1,
        'otherwise return the value passed in
        Select Case value
            Case 0
                Return 1
            Case Else
                Return value
        End Select
    End Function


End Class
