Imports MySql.Data.MySqlClient
Imports RidleySoft.DBConnection

Public Class DAModule
    Inherits DABaseClass
    Private lijst As List(Of DAModule)

    Public Sub New()
        MyBase.DABaseClass()
    End Sub

    Public Function getModules() As List(Of DAModule)
        DBConnection.ConnectionOpen("RidleySoft")
        Dim command As MySqlCommand = New MySqlCommand("SELECT module_id, description, group_id from tbl_module", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAModule)

        While (dataReader.Read())
            Dim nextModule As New DAModule
            nextModule.ModuleID = (dataReader("module_id"))
            nextModule.Description = dataReader("description").ToString()
            nextModule.GroupID = (dataReader("group_id"))
            lijst.Add(nextModule)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Function GetModulesByFilter(Optional ModuleName As String = Nothing, Optional GroupName As String = Nothing) As List(Of DAModule)
        DBConnection.ConnectionOpen("RidleySoft")
        Dim sql As String = "select * from tbl_module m inner join tbl_groups g on m.group_id = g.group_id where m.description Like '%" & ModuleName & "%' and g.groupname like '%" & GroupName & "%'"
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand(sql, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAModule)

        While (dataReader.Read())
            Dim nextModule As New DAModule
            nextModule.ModuleID = (dataReader("module_id"))
            nextModule.Description = dataReader("description").ToString()
            nextModule.GroupID = (dataReader("group_id"))
            lijst.Add(nextModule)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Function getCountModulesByModuleID(ByVal ModuleID As Integer) As Integer
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("select count(m.module_id) from tbl_module m inner join tbl_menu_module mm on m.module_id = mm.module_id where m.module_id = " & ModuleID, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        dataReader.Read()
        Dim CountSetting As New Integer
        CountSetting = (dataReader("count(m.module_id)"))
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return CountSetting
    End Function

    Public Function getUserModulesNietGelinkt(userID As Integer) As List(Of DAModule)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("select * from tbl_module where module_id not in (select module_id from tbl_user_module where user_id =" & userID & ")", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAModule)

        While (dataReader.Read())
            Dim nextUserModule As New DAModule
            nextUserModule.ModuleID = dataReader("module_id")
            nextUserModule.Description = dataReader("description")
            lijst.Add(nextUserModule)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Function getModulesByID(userID As Integer) As List(Of DAModule)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("select m.module_id, m.description from tbl_module m inner join tbl_user_module um on m.module_id = um.module_id where um.user_id =" & userID, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAModule)

        While (dataReader.Read())
            Dim nextModule As New DAModule
            nextModule.ModuleID = (dataReader("module_id"))
            nextModule.Description = dataReader("description").ToString()
            lijst.Add(nextModule)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Sub InsertModule(ByVal modulee As DAModule)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("insert into tbl_module(description, group_id) values (@description, @groupID)", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@description", modulee.Description))
        command.Parameters.Add(New MySqlParameter("@groupID", modulee.GroupID))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Public Sub UpdateModule(ByVal modulee As DAModule)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("update tbl_module set description = @description, group_id = @groupID where module_id = @ID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@description", modulee.Description))
        command.Parameters.Add(New MySqlParameter("@groupID", modulee.GroupID))
        command.Parameters.Add(New MySqlParameter("@ID", modulee.ModuleID))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Public Sub deleteModule(ByVal id As Integer)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("delete from tbl_module where module_id = @ID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@ID", id))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Private moduleID2 As Integer
    Private description2 As String
    Private groupID2 As Integer

    Public Sub New(ByVal moduleID2 As Integer, ByVal description2 As String, ByVal groupID2 As Integer)
        Me.ModuleID = moduleID2
        Me.Description = description2
        Me.groupID2 = groupID2
    End Sub


    Public Property ModuleID() As Integer
        Get
            Return moduleID2
        End Get
        Set(value As Integer)
            moduleID2 = value
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

    Public Property GroupID() As Integer
        Get
            Return groupID2
        End Get
        Set(value As Integer)
            groupID2 = value
        End Set
    End Property
End Class
