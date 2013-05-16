Imports MySql.Data.MySqlClient

Public Class DAUserModule
    Inherits DABaseClass
    Private lijst As List(Of DAUserModule)

    Public Sub New()
        MyBase.DABaseClass()
    End Sub

    Public Function getUserModules() As List(Of DAUserModule)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("SELECT * from tbl_user_module", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAUserModule)

        While (dataReader.Read())
            Dim nextUserModule As New DAUserModule
            nextUserModule.UserID = (dataReader("user_id"))
            nextUserModule.ModuleID = dataReader("module_id")
            lijst.Add(nextUserModule)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Function getModuleIDsByUserId(userID As Integer) As List(Of DAUserModule)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("SELECT DISTINCT module_id from tbl_user_module where user_id=" & userID, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAUserModule)

        While (dataReader.Read())
            Dim nextModule As New DAUserModule
            nextModule.ModuleID = (dataReader("module_id"))
            lijst.Add(nextModule)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Sub InsertUserModule(ByVal userModule As DAUserModule)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("insert into tbl_user_module(user_id, module_id) values (@UserID, @ModuleID)", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@UserID", userModule.UserID))
        command.Parameters.Add(New MySqlParameter("@ModuleID", userModule.ModuleID))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Public Sub UpdateUserModule(ByVal userModule As DAUserModule)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("update tbl_user_module set module_id = @ModuleID where user_id = @UserID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@UserID", userModule.UserID))
        command.Parameters.Add(New MySqlParameter("@ModuleID", userModule.ModuleID))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Public Sub deleteUserModule(ByVal UserID As Integer, ByVal moduleID As Integer)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("delete from tbl_user_module where user_id = @UserID and module_id = @ModuleID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@UserID", UserID))
        command.Parameters.Add(New MySqlParameter("@ModuleID", moduleID))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Private userID2 As Integer
    Private moduleID2 As Integer

    Public Sub New(ByVal userID2 As Integer, ByVal moduleID2 As Integer)
        Me.UserID = userID2
        Me.ModuleID = moduleID2
    End Sub

    Public Property UserID() As Integer
        Get
            Return userID2
        End Get
        Set(value As Integer)
            userID2 = value
        End Set
    End Property

    Public Property ModuleID() As Integer
        Get
            Return moduleID2
        End Get
        Set(value As Integer)
            moduleID2 = value
        End Set
    End Property
End Class
