Imports MySql.Data.MySqlClient

Public Class DAGroupModule
    Inherits DABaseClass
    Private lijst As List(Of DAGroupModule)
    Private groupModule As DAGroupModule

    Public Sub New()
        MyBase.DABaseClass()
    End Sub

    Public Function getModulesByFilter(Optional ModuleName As String = Nothing, Optional GroupName As String = Nothing) As List(Of DAGroupModule)

        Dim sql As String = "select * from tbl_module m inner join tbl_groups g on m.group_id = g.group_id where m.description Like '%" & ModuleName & "%' and g.groupname like '%" & GroupName & "%'"
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand(sql, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAGroupModule)

        While (dataReader.Read())
            Dim nextModule As New DAGroupModule
            nextModule.ModuleID = (dataReader("module_id"))
            nextModule.Description = dataReader("description").ToString()
            nextModule.GroupID = (dataReader("group_id"))
            nextModule.GroupName = dataReader("groupname").ToString()
            lijst.Add(nextModule)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Function getModulesById(groupID As Integer) As List(Of DAGroupModule)


        DBConnection.ConnectionOpen("RidleySoft")


        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("SELECT * from tbl_module where group_id=" & groupID, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAGroupModule)

        While (dataReader.Read())
            Dim nextModule As New DAGroupModule
            nextModule.ModuleID = (dataReader("module_id"))
            nextModule.Description = (dataReader("description"))
            nextModule.GroupID = (dataReader("group_id"))
            lijst.Add(nextModule)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Function getGroupIDByModule(moduleID As Integer) As Integer
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("SELECT group_id from tbl_module where module_id=" & moduleID, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        Dim groupModule As Integer

        While (dataReader.Read())
            groupModule = dataReader("group_id")
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return groupModule
    End Function

    Private moduleID2 As Integer
    Private description2 As String
    Private groupID2 As Integer
    Private groupname2 As String

    Public Sub New(ByVal moduleID2 As Integer, ByVal description2 As String, ByVal groupID2 As Integer, ByVal groupname2 As String)
        Me.ModuleID = moduleID2
        Me.Description = description2
        Me.GroupID = groupID2
        Me.GroupName = groupname2
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

    Public Property GroupName() As String
        Get
            Return groupname2
        End Get
        Set(value As String)
            groupname2 = value
        End Set
    End Property

End Class
