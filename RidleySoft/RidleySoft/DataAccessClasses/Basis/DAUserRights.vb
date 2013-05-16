Imports MySql.Data.MySqlClient

Public Class DAUserRights
    Inherits DABaseClass
    Private lijst As List(Of DAUserRights)
    Private user As DAUserRights
    Public Sub New()
        MyBase.DABaseClass()
    End Sub

    Public Function getUserRights() As List(Of DAUserRights)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("SELECT * from tbl_user_rights", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAUserRights)

        While (dataReader.Read())
            Dim nextUserRight As New DAUserRights
            nextUserRight.UserID = (dataReader("user_id"))
            nextUserRight.RightID = dataReader("right_id")
            lijst.Add(nextUserRight)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Function getRightsNotLinked(userID As Integer) As List(Of DAUserRights)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("select * from tbl_user_rights where right_id not in (select right_id from tbl_users where user_id =" & userID & ")", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAUserRights)

        While (dataReader.Read())
            Dim nextUserRight As New DAUserRights
            nextUserRight.RightID = dataReader("right_id")
            nextUserRight.UserID = dataReader("user_id")
            lijst.Add(nextUserRight)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Function getRightsByID(userID As Integer) As List(Of DAUserRights)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("select * from tbl_user_rights where user_id =" & userID, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAUserRights)

        While (dataReader.Read())
            Dim nextRight As New DAUserRights
            nextRight.RightID = (dataReader("right_id"))
            nextRight.UserID = dataReader("user_id").ToString()
            lijst.Add(nextRight)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Sub InsertUserRights(ByVal user As DAUserRights)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("insert into tbl_user_rights(user_id, right_id) values (@UserID, @RightID)", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@UserID", user.UserID))
        command.Parameters.Add(New MySqlParameter("@RightID", user.RightID))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Public Sub UpdateUserRight(ByVal userRight As DAUserRights)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("update tbl_user_rights set right_id = @RightID where user_id = @UserID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@UserID", userRight.UserID))
        command.Parameters.Add(New MySqlParameter("@RightID", userRight.RightID))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Public Sub deleteUserRight(ByVal UserID As Integer, ByVal RightID As Integer)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("delete from tbl_user_rights where user_id = @UserID and right_id = @RightID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@UserID", UserID))
        command.Parameters.Add(New MySqlParameter("@RightID", RightID))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Private userID2 As Integer
    Private rightID2 As Integer

    Public Sub New(ByVal userID2 As Integer, ByVal rightID2 As Integer)
        Me.UserID = userID2
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

    Public Property RightID() As Integer
        Get
            Return rightID2
        End Get
        Set(value As Integer)
            rightID2 = value
        End Set
    End Property
End Class
