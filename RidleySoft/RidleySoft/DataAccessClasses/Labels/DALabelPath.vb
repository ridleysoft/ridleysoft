Imports MySql.Data.MySqlClient

Public Class DALabelPath
    Inherits DABaseClass
    Private lijst As List(Of DALabelPath)
    Private user As DALabelPath
    Public Sub New()
        MyBase.DABaseClass()
    End Sub

    Public Function GetLabel(ByVal Label As String) As DALabelPath
        DBConnection.ConnectionOpen("RidleySoft")
        Dim sql As String = "select * from tbl_labels where name = '" & Label & "'"

        Dim command As MySqlCommand = New MySqlCommand(sql, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        Dim nextLabel As New DALabelPath
        If dataReader.Read() Then
            nextLabel.Name = (dataReader("Name")).ToString()
            nextLabel.Path = (dataReader("Path")).ToString()
        End If
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return nextLabel
    End Function

    Public Function GetLabelbyID(ByVal id As Integer) As DALabelPath
        DBConnection.ConnectionOpen("RidleySoft")
        Dim sql As String = "select * from tbl_labels where id = " & id & ""

        Dim command As MySqlCommand = New MySqlCommand(sql, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        Dim nextLabel As New DALabelPath
        If dataReader.Read() Then
            nextLabel.ID = (dataReader("id"))
            nextLabel.Name = (dataReader("Name")).ToString()
            nextLabel.Path = (dataReader("Path")).ToString()
        End If
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return nextLabel
    End Function

    Public Function getLabels() As List(Of DALabelPath)

        Dim sql As String = "select * from tbl_labels"
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand(sql, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DALabelPath)

        While (dataReader.Read())
            Dim nextLabel As New DALabelPath
            nextLabel.ID = (dataReader("id"))
            nextLabel.Name = dataReader("name").ToString()
            nextLabel.Path = (dataReader("path")).ToString()
            lijst.Add(nextLabel)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Private ID2 As Integer
    Private Name2 As String
    Private Path2 As String

    Public Sub New(ByVal ID2 As Integer, ByVal Name2 As String, ByVal Path2 As String)
        Me.ID = ID2
        Me.Name = Name2
        Me.Path = Path2
    End Sub

    Public Property ID() As Integer
        Get
            Return ID2
        End Get
        Set(value As Integer)
            ID2 = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return Name2
        End Get
        Set(value As String)
            Name2 = value
        End Set
    End Property

    Public Property Path() As String
        Get
            Return Path2
        End Get
        Set(value As String)
            Path2 = value
        End Set
    End Property
End Class
