Imports System.ComponentModel
Imports System.Runtime.InteropServices

Public Class PrinterManager
    Private Declare Auto Function GetDefaultPrinter Lib "winspool.drv" ( _
        ByVal pszBuffer As String, _
        ByRef pcchBuffer As Int32 _
    ) As Boolean

    Private Const ERROR_FILE_NOT_FOUND As Int32 = 2
    Private Const ERROR_INSUFFICIENT_BUFFER As Int32 = 122

    Private Declare Auto Function SetDefaultPrinter_API _
        Lib "winspool.drv" _
        Alias "SetDefaultPrinter" _
    ( _
        ByVal pszPrinter As String _
    ) As Boolean

    Public Shared Sub SetDefaultPrinter(ByVal PrinterName As String)
        If Not SetDefaultPrinter_API(PrinterName) Then
            Throw New Win32Exception
        End If
    End Sub

    Public Shared Function GetDefaultPrinter() As String
        Dim s As String = Space(128)
        Dim n As Int32 = s.Length
        Dim Success As Boolean = GetDefaultPrinter(s, n)
        If Success Then
            Return Strings.Left(s, n - 1)
        Else
            Dim LastError As Integer = Marshal.GetLastWin32Error()
            If LastError = ERROR_FILE_NOT_FOUND Then
                Throw _
                    New Win32Exception( _
                        LastError, _
                        "There is no default printer." _
                    )
            ElseIf LastError = ERROR_INSUFFICIENT_BUFFER Then
                s = Space(n)
                Success = GetDefaultPrinter(s, n)
                If Success Then
                    Return Strings.Left(s, n - 1)
                Else
                    Throw New Win32Exception
                End If
            Else
                Throw New Win32Exception
            End If
        End If
    End Function
End Class
