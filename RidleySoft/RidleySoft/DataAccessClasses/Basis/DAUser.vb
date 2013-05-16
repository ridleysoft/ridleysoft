Imports MySql.Data.MySqlClient

Public Class DAUser
    Inherits DABaseClass
    Private lijst As List(Of DAUser)
    Private user As DAUser
    Public Sub New()
        MyBase.DABaseClass()
    End Sub
    Public Function GetUsers() As List(Of DAUser)

        DBConnection.ConnectionOpen("RidleySoft")
        Dim sql As String = "select * from tbl_users order by user_id"

        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand(sql, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAUser)

        While (dataReader.Read())
            Dim nextUser As New DAUser
            nextUser.UserID = (dataReader("user_id"))
            nextUser.Username = (dataReader("username")).ToString()
            nextUser.Password = dataReader("password").ToString()
            nextUser.RightID = dataReader("right")
            lijst.Add(nextUser)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function


    Public Function GetUsersByFilter(ByVal text As String) As List(Of DAUser)
        DBConnection.ConnectionOpen("RidleySoft")
        Dim sql As String = "select * from tbl_users u where u.username Like '%" & text & "%' order by username"
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand(sql, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAUser)

        While (dataReader.Read())
            Dim nextUser As New DAUser
            nextUser.UserID = (dataReader("user_id"))
            nextUser.Username = (dataReader("username")).ToString()
            nextUser.Password = dataReader("password").ToString()
            lijst.Add(nextUser)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function
    


    Public Function getCountSettingsByUserID(ByVal userID2 As Integer) As Integer
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("select count(u.user_id) from tbl_users u inner join tbl_settings s on u.user_id = s.user_id where u.user_id =" & userID2, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        dataReader.Read()
        Dim CountSetting As New Integer
        CountSetting = (dataReader("count(u.user_id)"))
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return CountSetting
    End Function

    Public Function getMinUserID() As Integer
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("select min(user_id) from tbl_users", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        dataReader.Read()
        Dim UserID As New Integer
        UserID = (dataReader("min(user_id)"))
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return UserID
    End Function

    Public Sub InsertUser(ByVal user As DAUser)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("insert into tbl_users(username, password) values (@username, @password)", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@username", user.Username))
        command.Parameters.Add(New MySqlParameter("@password", user.Password))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Public Function GetUserByUserID(userID As Integer) As DAUser
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("SELECT * from tbl_users where user_ID=" & userID, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        dataReader.Read()
        user = New DAUser()
        user.UserID = (dataReader("user_id"))
        user.Username = (dataReader("username")).ToString()
        user.Password = dataReader("password").ToString()

        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return user
    End Function

    Public Function GetUserIDByUser(UserName As String) As DAUser
        DBConnection.ConnectionOpen("RidleySoft")
        ' DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("SELECT * from tbl_users where username like '%" & UserName & "%'", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        While (dataReader.Read())
            dataReader.Read()
            user = New DAUser()
            user.UserID = (dataReader("user_id"))
            user.Username = (dataReader("username")).ToString()
            user.Password = dataReader("password").ToString()
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return user
    End Function

    Public Sub UpdateUser(ByVal user As DAUser)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("update tbl_users set username = @username, password = @password where user_id = @ID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@id", user.UserID))
        command.Parameters.Add(New MySqlParameter("@username", user.Username))
        command.Parameters.Add(New MySqlParameter("@password", user.Password))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Public Sub deleteUser(ByVal id As Integer)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("delete from tbl_users where user_id = @ID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@id", id))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Public Sub deleteRights(ByVal id As Integer)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("delete from tbl_user_rights where user_id = @ID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@id", id))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Public Sub deleteUserModules(ByVal id As Integer)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("delete from tbl_user_module where user_id = @ID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@id", id))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Public Sub deleteSettings(ByVal id As Integer)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("delete from tbl_settings where user_id = @ID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@id", id))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Private userID2 As Integer
    Private username2 As String
    Private password2 As String
    Private rightID2 As Integer

    Public Sub New(ByVal userID2 As Integer, ByVal username2 As String, ByVal password2 As String, ByVal rightID2 As Integer)
        Me.UserID = userID2
        Me.Username = username2
        Me.Password = password2
        Me.RightID = rightID2
    End Sub

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

    Public Property Password() As String
        Get
            Return password2
        End Get
        Set(value As String)
            password2 = value
        End Set
    End Property

    Public Property RightID() As Integer
        Get
            Return rightID2
        End Get
        Set(value As Integer)
            rightID2 = value
        End Set
    End Property

End Class