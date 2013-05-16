Imports MySql.Data.MySqlClient

Public Class DADatabase

    Inherits DABaseClass
    Private lijst As List(Of DADatabase)
    Private groupID35 As DADatabase
    Public Sub New()
        MyBase.DABaseClass()
    End Sub
    Public Function getdbs() As List(Of DADatabase)
        connectionBase.Open()
        Dim command As MySqlCommand = New MySqlCommand("SELECT * from tbl_db_settings where active = 1", connectionBase)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DADatabase)

        While (dataReader.Read())
            Dim nextDBSetting As New DADatabase
            nextDBSetting.Database = dataReader("database").ToString()
            nextDBSetting.Source = dataReader("source").ToString()
            nextDBSetting.UserID = dataReader("user_id").ToString()
            nextDBSetting.Password = dataReader("password").ToString()
            nextDBSetting.Active = dataReader("active")
            nextDBSetting.Type = dataReader("type").ToString()
            lijst.Add(nextDBSetting)

        End While
        dataReader.Close()
        connectionBase.Close()
        Return lijst
    End Function


    Public Function getFTP() As DADatabase
        connectionBase.Open()
        Dim command As MySqlCommand = New MySqlCommand("SELECT * from tbl_db_settings where type = 'FTP'", connectionBase)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()
        Dim nextDBSetting As New DADatabase
        If dataReader.Read() Then
            nextDBSetting.Database = dataReader("database").ToString()
            nextDBSetting.Source = dataReader("source").ToString()
            nextDBSetting.UserID = dataReader("user_id").ToString()
            nextDBSetting.Password = dataReader("password").ToString()
            nextDBSetting.Active = dataReader("active")
            nextDBSetting.Type = dataReader("type").ToString()
        End If
        dataReader.Close()
        connectionBase.Close()
        Return nextDBSetting
    End Function

    Private database2 As String
    Private source2 As String
    Private userID2 As String
    Private password2 As String
    Private active2 As Integer
    Private type2 As String

    Public Sub New(ByVal database2 As String, ByVal source2 As String, ByVal userID2 As String, ByVal password2 As String, ByVal active2 As Integer, ByVal type2 As String)
        Me.Database = database2
        Me.Source = source2
        Me.UserID = userID2
        Me.Password = password2
        Me.Active = active2
        Me.Type = type2
    End Sub

    Public Property Database() As String
        Get
            Return database2
        End Get
        Set(value As String)
            database2 = value
        End Set
    End Property

    Public Property Source() As String
        Get
            Return source2
        End Get
        Set(value As String)
            source2 = value
        End Set
    End Property
    Public Property UserID() As String
        Get
            Return userID2
        End Get
        Set(value As String)
            userID2 = value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return password2
        End Get
        Set(value As String)
            password2 = value
        End Set
    End Property

    Public Property Active() As Integer
        Get
            Return active2
        End Get
        Set(value As Integer)
            active2 = value
        End Set
    End Property

    Public Property Type() As String
        Get
            Return type2
        End Get
        Set(value As String)
            type2 = value
        End Set
    End Property
End Class
