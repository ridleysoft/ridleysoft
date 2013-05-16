Imports MySql.Data.MySqlClient

Public Class DASettings
    Inherits DABaseClass
    Private lijst As List(Of DASettings)
    Public Sub New()
        MyBase.DABaseClass()
    End Sub
    Public Function getSettingsByUserId(userID As Integer) As List(Of DASettings)

        DBConnection.ConnectionOpen("RidleySoft")

        Dim command As MySqlCommand = New MySqlCommand("SELECT * from tbl_settings where user_id=" & userID & "or user_id  = ''", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DASettings)

        While (dataReader.Read())
            Dim nextSetting As New DASettings
            nextSetting.SettingID = (dataReader("setting_id"))
            nextSetting.Description = (dataReader("description")).ToString()
            nextSetting.Value = dataReader("value").ToString()
            nextSetting.Type = (dataReader("type")).ToString()
            nextSetting.UserID = dataReader("user_id").ToString()
            lijst.Add(nextSetting)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Function getLanguageByUserId(userID As Integer) As DASettings
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("SELECT * from tbl_settings where description = 'Language' and user_id=" & userID, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        dataReader.Read()
        Dim nextSetting As New DASettings
        nextSetting.SettingID = (dataReader("setting_id"))
        nextSetting.Description = (dataReader("description")).ToString()
        nextSetting.Value = dataReader("value").ToString()
        nextSetting.Type = (dataReader("type")).ToString()
        nextSetting.UserID = dataReader("user_id").ToString()
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return nextSetting
    End Function

    Public Function getImageLink(ByVal description As String) As DASettings
        DBConnection.ConnectionOpen("RidleySoft")
        Dim command As MySqlCommand = New MySqlCommand("select * from tbl_settings where description = 'Image'", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = Command.ExecuteReader()

        Dim nextImage As New DASettings
        If dataReader.Read() Then
            nextImage.Value = (dataReader("value")).ToString()
        End If
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return nextImage
    End Function

    Public Function GetSettings() As List(Of DASettings)
        DBConnection.ConnectionOpen("RidleySoft")
        Dim sql As String = "select * from tbl_settings order by user_ID"


        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand(sql, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DASettings)

        While (dataReader.Read())
            Dim nextSetting As New DASettings
            nextSetting.SettingID = (dataReader("setting_id"))
            nextSetting.Description = (dataReader("description")).ToString()
            nextSetting.Value = dataReader("value").ToString()
            nextSetting.Type = (dataReader("type")).ToString()
            nextSetting.UserID = dataReader("user_id").ToString()
            lijst.Add(nextSetting)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Sub InsertSetting(ByVal setting As DASettings)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("insert into tbl_settings(description, value, type, user_id) values (@description, @value, @type, @userID)", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@description", setting.Description))
        command.Parameters.Add(New MySqlParameter("@value", setting.Value))
        command.Parameters.Add(New MySqlParameter("@type", setting.Type))
        command.Parameters.Add(New MySqlParameter("@userID", setting.UserID))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Public Sub UpdateSetting(ByVal setting As DASettings)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("update tbl_settings set description = @description, value = @value, type = @type where user_id = @userID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@description", setting.Description))
        command.Parameters.Add(New MySqlParameter("@value", setting.Value))
        command.Parameters.Add(New MySqlParameter("@type", setting.Type))
        command.Parameters.Add(New MySqlParameter("@userID", setting.UserID))

        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

   

    Public Sub deleteSetting(ByVal id As Integer)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("delete from tbl_settings where setting_id = @ID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@ID", id))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Private settingID2 As Integer
    Private description2 As String
    Private value2 As String
    Private type2 As String
    Private userID2 As Integer

    Public Sub New(ByVal settingID2 As Integer, ByVal description2 As String, ByVal value2 As String, ByVal type2 As String, ByVal userID2 As Integer)
        Me.SettingID = settingID2
        Me.Description = description2
        Me.Value = value2
        Me.Type = type2
        Me.UserID = userID2
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
End Class
