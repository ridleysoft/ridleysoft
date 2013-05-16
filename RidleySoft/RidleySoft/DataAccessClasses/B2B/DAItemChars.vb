Imports System.Data.SqlClient

Public Class DAItemChars
    Inherits DABaseClass
    Private lijst As List(Of DAItemChars)
    Private user As DAItemChars
    Public Sub New()
        MyBase.DABaseClass()
    End Sub

    Public Function GetItemInfo(ByVal itemnr As String) As List(Of DAItemChars)
        DBConnection.ConnectionOpen("NAVDB")
        Dim sql As String = "select * from dbo.[Race Productions$Item Characteristics] where [Item No_] = '" & itemnr & "'"

        Dim command As SqlCommand = New SqlCommand(sql, DBConnectionSQL)
        Dim dataReader As SqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAItemChars)

        While (dataReader.Read())
            Dim nextItem As New DAItemChars
            nextItem.ItemNr = (dataReader("Item No_")).ToString()
            nextItem.Code = (dataReader("Code")).ToString()
            nextItem.Value = dataReader("Value").ToString()
            lijst.Add(nextItem)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("NAVDB")
        Return lijst
    End Function

    Public Function GetItemInfo2(ByVal itemnr As String)
        DBConnection.ConnectionOpen("NAVDB")
        Dim sql As String = "select * from dbo.[Race Productions$Item Characteristics] where [Item No_] = '" & itemnr & "'"

        Dim command As SqlCommand = New SqlCommand(sql, DBConnectionSQL)
        Dim dataReader As SqlDataReader = command.ExecuteReader()


        Dim nextItem As New DAItemChars
        If dataReader.Read() Then
            nextItem.ItemNr = (dataReader("Item No_")).ToString()
            nextItem.Code = (dataReader("Code")).ToString()
            nextItem.Value = dataReader("Value").ToString()
        End If
        dataReader.Close()
        DBConnection.ConnectionClose("NAVDB")
        Return nextItem
    End Function

    Private ItemNr2 As String
    Private Code2 As String
    Private Value2 As String

    Public Sub New(ByVal ItemNr2 As String, ByVal Code2 As String, ByVal Value2 As String)
        Me.ItemNr = ItemNr2
        Me.Code = Code2
        Me.Value = Value2
    End Sub

    Public Property ItemNr() As String
        Get
            Return ItemNr2
        End Get
        Set(value As String)
            ItemNr2 = value
        End Set
    End Property

    Public Property Code() As String
        Get
            Return Code2
        End Get
        Set(value As String)
            Code2 = value
        End Set
    End Property

    Public Property Value() As String
        Get
            Return Value2
        End Get
        Set(value As String)
            Value2 = value
        End Set
    End Property
End Class
