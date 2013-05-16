Imports MySql.Data.MySqlClient

Public Class DAUserSettings
    Inherits DABaseClass
    Private lijst As List(Of DAUserSettings)
    Public Sub New()
        MyBase.DABaseClass()
    End Sub

    Public Function getSettingsByFilter(Optional userNAME As String = Nothing, Optional description As String = Nothing, Optional value As String = Nothing, Optional type As String = Nothing) As List(Of DAUserSettings)

        Dim sql As String = "select * from tbl_settings s inner join tbl_users u on s.user_id = u.user_id where s.description Like '%" & description & "%' and s.value like '%" & value & "%' and s.`type` like '%" & type & "%' and u.username like '%" & userNAME & "%'"

        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand(sql, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAUserSettings)

        While (dataReader.Read())
            Dim nextSetting As New DAUserSettings
            nextSetting.SettingID = (dataReader("setting_id"))
            nextSetting.Description = (dataReader("description")).ToString()
            nextSetting.Value = dataReader("value").ToString()
            nextSetting.Type = (dataReader("type")).ToString()
            nextSetting.UserID = dataReader("user_id").ToString()
            nextSetting.Username = dataReader("username").ToString()
            lijst.Add(nextSetting)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function


    Private settingID2 As Integer
    Private description2 As String
    Private value2 As String
    Private type2 As String
    Private userID2 As Integer
    Private username2 As String

    Public Sub New(ByVal settingID2 As Integer, ByVal description2 As String, ByVal value2 As String, ByVal type2 As String, ByVal userID2 As Integer, ByVal username2 As String)
        Me.SettingID = settingID2
        Me.Description = description2
        Me.Value = value2
        Me.Type = type2
        Me.UserID = userID2
        Me.Username = username2
    End Sub


    Public Property SettingID() As Integer
        Get
            Return settingID2
        End Get
        Set(value As Integer)
            settingID2 = value
        End Set
    End Property

    Public Property Description() As String
        Get
            Return description2
        End Get
        Set(value As String)
            description2 = value
        End Set
    End Property

    Public Property Value() As String
        Get
            Return value2
        End Get
        Set(value As String)
            value2 = value
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

    Public Property UserID() As Integer
        Get
            Return userID2
        End Get
        Set(value As Integer)
            userID2 = value
        End Set

    End Property
    Public Property Username() As String
        Get
            Return username2
        End Get
        Set(value As String)
            username2 = value
        End Set
    End Property
End Class
