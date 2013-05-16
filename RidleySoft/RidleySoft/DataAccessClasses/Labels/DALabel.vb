Imports System.Data.SqlClient

Public Class DALabel
    Inherits DABaseClass
    Private lijst As List(Of DALabel)
    Private user As DALabel
    Public Sub New()
        MyBase.DABaseClass()
    End Sub
    Public Function GetUsers(ByVal ArticleNr As String) As DALabel
        DBConnection.ConnectionOpen("NAVDB")
        Dim sql As String = "select i.No_, i.Description, i.[Description 2], iv.[Vendor Item No_], cr.[Cross-Reference No_], iv.[Vendor No_] from dbo.[Race Productions$Item] i left outer join dbo.[Race Productions$Item Vendor] iv on i.No_ = iv.[Item No_] left outer join dbo.[Race Productions$Item Cross Reference] cr on i.No_ = cr.[Item No_] where cr.[Cross-Reference Type] = 3 and i.No_ = '" & ArticleNr & "'"
        'DBConnectionSQL.Open()
        Dim command As SqlCommand = New SqlCommand(sql, DBConnectionSQL)
        Dim dataReader As SqlDataReader = command.ExecuteReader()

        Dim nextArticle As New DALabel
        If dataReader.Read() Then
            nextArticle.ArticleID = (dataReader("No_")).ToString()
            nextArticle.Description = (dataReader("Description")).ToString()
            nextArticle.Description2 = dataReader("Description 2").ToString()
            nextArticle.ArticleIDLev = dataReader("Vendor Item No_").ToString()
            nextArticle.Barcode = dataReader("Cross-Reference No_").ToString()
            nextArticle.LevNr = dataReader("Vendor No_").ToString()
        End If
        dataReader.Close()
        DBConnection.ConnectionClose("NAVDB")
        Return nextArticle
    End Function

    Private ArticleID2 As String
    Private Description2a As String
    Private Description2b As String
    Private AltNr2 As String
    Private ArticleIDLev2 As String
    Private Barcode2 As String
    Private LevNr2 As String

    Public Sub New(ByVal ArticleID2 As String, ByVal Description2a As String, ByVal Description2b As String, ByVal AltNr2 As String, ByVal ArticleIDLev2 As String, ByVal Barcode2 As String, ByVal LevNr2 As String)
        Me.ArticleID = ArticleID2
        Me.Description = Description2a
        Me.Description2 = Description2b
        Me.AltNr = AltNr2
        Me.ArticleIDLev = ArticleIDLev2
        Me.Barcode = Barcode2
        Me.LevNr = LevNr2
    End Sub

    Public Property ArticleID() As String
        Get
            Return ArticleID2
        End Get
        Set(value As String)
            ArticleID2 = value
        End Set
    End Property

    Public Property Description() As String
        Get
            Return Description2a
        End Get
        Set(value As String)
            Description2a = value
        End Set
    End Property

    Public Property Description2() As String
        Get
            Return Description2b
        End Get
        Set(value As String)
            Description2b = value
        End Set
    End Property

    Public Property AltNr() As String
        Get
            Return AltNr2
        End Get
        Set(value As String)
            AltNr2 = value
        End Set
    End Property

    Public Property ArticleIDLev() As String
        Get
            Return ArticleIDLev2
        End Get
        Set(value As String)
            ArticleIDLev2 = value
        End Set
    End Property

    Public Property Barcode() As String
        Get
            Return Barcode2
        End Get
        Set(value As String)
            Barcode2 = value
        End Set
    End Property

    Public Property LevNr() As String
        Get
            Return LevNr2
        End Get
        Set(value As String)
            LevNr2 = value
        End Set
    End Property
End Class
