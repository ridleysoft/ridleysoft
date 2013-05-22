Imports System.IO
Imports System.Runtime.InteropServices

Namespace ZebraLabels
    ''' <summary>
    ''' This class can print zebra labels to either a network share, LPT, or COM port.
    '''
    ''' Programmer: Rick Chronister
    ''' </summary>
    ''' <remarks>Only tested for network share, but in theory works for LPT and COM.</remarks>
    Public Class ZebraPrint

#Region " Private constants "
        Private Const GENERIC_WRITE As Integer = &H40000000
        Private Const OPEN_EXISTING As Integer = 3
#End Region

#Region " Private members "
        ''' <summary>
        '''
        ''' </summary>
        ''' <remarks></remarks>
        Private _SafeFileHandle As Microsoft.Win32.SafeHandles.SafeFileHandle
        ''' <summary>
        '''
        ''' </summary>
        ''' <remarks></remarks>
        Private _fileWriter As StreamWriter
        ''' <summary>
        '''
        ''' </summary>
        ''' <remarks></remarks>
        Private _outFile As FileStream
#End Region

#Region " private structures "
        ''' <summary>
        ''' Structure for CreateFile.  Used only to fill requirement
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)> _
        Public Structure SECURITY_ATTRIBUTES
            Private nLength As Integer
            Private lpSecurityDescriptor As Integer
            Private bInheritHandle As Integer
        End Structure
#End Region

#Region " com calls "
        ''' <summary>
        '''
        ''' </summary>
        ''' <param name="lpFileName"></param>
        ''' <param name="dwDesiredAccess"></param>
        ''' <param name="dwShareMode"></param>
        ''' <param name="lpSecurityAttributes"></param>
        ''' <param name="dwCreationDisposition"></param>
        ''' <param name="dwFlagsAndAttributes"></param>
        ''' <param name="hTemplateFile"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Declare Function CreateFile Lib "kernel32" Alias "CreateFileA" (ByVal lpFileName As String, ByVal dwDesiredAccess As Integer, ByVal dwShareMode As Integer, <MarshalAs(UnmanagedType.Struct)> ByRef lpSecurityAttributes As SECURITY_ATTRIBUTES, ByVal dwCreationDisposition As Integer, ByVal dwFlagsAndAttributes As Integer, ByVal hTemplateFile As Integer) As Microsoft.Win32.SafeHandles.SafeFileHandle
#End Region

#Region " Public methods "
        ''' <summary>
        ''' This function must be called first.  Printer path must be a COM Port or a UNC path.
        ''' </summary>
        Public Sub StartWrite(ByVal printerPath As String)
            Dim SA As SECURITY_ATTRIBUTES

            'Create connection
            _SafeFileHandle = CreateFile(printerPath, GENERIC_WRITE, 0, SA, OPEN_EXISTING, 0, 0)

            'Create file stream
            Try
                _outFile = New FileStream(_SafeFileHandle, FileAccess.Write)
                _fileWriter = New StreamWriter(_outFile)
            Catch ex As Exception
                System.Windows.Forms.MessageBox.Show("Can not find printer.", "Warning", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error, Windows.Forms.MessageBoxDefaultButton.Button1)
            End Try

        End Sub

        ''' <summary>
        ''' This will write a command to the printer.
        ''' </summary>
        Public Sub Write(ByVal rawLine As String)
            If _fileWriter IsNot Nothing Then
                _fileWriter.WriteLine(rawLine)
            End If
        End Sub

        ''' <summary>
        ''' This function must be called after writing to the zebra printer.
        ''' </summary>
        Public Sub EndWrite()
            'Clean up
            If _fileWriter IsNot Nothing Then
                _fileWriter.Flush()
                _fileWriter.Close()
                _outFile.Close()
            End If
            _SafeFileHandle.Close()
            _SafeFileHandle.Dispose()

        End Sub
#End Region


        'Dit is een test

    End Class
End Namespace