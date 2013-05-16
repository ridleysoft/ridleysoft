Imports MySql.Data.MySqlClient

Public Class DAGroup
    Inherits DABaseClass
    Private lijst As List(Of DAGroup)
    Private groupID35 As DAGroup
    Public Sub New()
        MyBase.DABaseClass()
    End Sub

    Public Function getGroups() As List(Of DAGroup)
        DBConnection.ConnectionOpen("RidleySoft")
        Dim command As MySqlCommand = New MySqlCommand("SELECT distinct * from tbl_groups", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAGroup)

        While (dataReader.Read())
            Dim nextGroup As New DAGroup
            nextGroup.GroupID2 = (dataReader("group_id"))
            nextGroup.GroupName2 = dataReader("groupname").ToString()
            lijst.Add(nextGroup)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Function GetGroupsByFilter(ByVal text As String) As List(Of DAGroup)
        DBConnection.ConnectionOpen("RidleySoft")
        Dim sql As String = "select * from tbl_groups g where g.groupname Like '%" & text & "%'"
        Dim command As MySqlCommand = New MySqlCommand(sql, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAGroup)

        While (dataReader.Read())
            Dim nextUser As New DAGroup
            nextUser.GroupID2 = (dataReader("group_id"))
            nextUser.GroupName2 = (dataReader("groupname")).ToString()
            lijst.Add(nextUser)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Function getCountGroupsByGroupID(ByVal GroupID As Integer) As Integer
        DBConnection.ConnectionOpen("RidleySoft")
        Dim command As MySqlCommand = New MySqlCommand("select count(g.group_id) from tbl_groups g inner join tbl_module m on g.group_id = m.group_id where g.group_id = " & GroupID, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        dataReader.Read()
        Dim CountSetting As New Integer
        CountSetting = (dataReader("count(g.group_id)"))
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return CountSetting
    End Function

    Public Function getGroupByID(groupID As Integer) As List(Of DAGroup)
        DBConnection.ConnectionOpen("RidleySoft")
        Dim command As MySqlCommand = New MySqlCommand("SELECT distinct * from tbl_groups where group_id=" & groupID, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAGroup)

        While (dataReader.Read())
            Dim nextGroup As New DAGroup
            nextGroup.GroupID2 = (dataReader("group_id"))
            nextGroup.GroupName2 = dataReader("groupname").ToString()
            lijst.Add(nextGroup)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Function getGroupIDByGroup(GroupName As String) As List(Of DAGroup)
        DBConnection.ConnectionOpen("RidleySoft")
        Dim command As MySqlCommand = New MySqlCommand("SELECT * from tbl_groups where groupname like '%" & GroupName & "%'", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAGroup)

        While (dataReader.Read())
            Dim nextGroup As New DAGroup
            nextGroup.GroupID2 = (dataReader("group_id"))
            nextGroup.GroupName2 = dataReader("groupname").ToString()
            lijst.Add(nextGroup)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Function GetMaxGroupID() As DAGroup
        DBConnection.ConnectionOpen("RidleySoft")
        Dim command As MySqlCommand = New MySqlCommand("select max(group_id) from tbl_groups", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()
        While (dataReader.Read())
            groupID35 = New DAGroup()
            groupID35.GroupID2 = (dataReader("group_id"))
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return groupID35
    End Function

    Public Function GetGroupByGroupIDCombo(groupID As Integer) As DAGroup
        DBConnection.ConnectionOpen("RidleySoft")
        Dim command As MySqlCommand = New MySqlCommand("SELECT * from tbl_groups where group_id=" & groupID, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()
        While (dataReader.Read())
            groupID35 = New DAGroup()
            groupID35.GroupID2 = (dataReader("group_id"))
            groupID35.GroupName2 = dataReader("groupname").ToString()
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return groupID35
    End Function

    Public Sub InsertGroup(ByVal group As DAGroup)
        DBConnection.ConnectionOpen("RidleySoft")
        Dim command As MySqlCommand = New MySqlCommand("insert into tbl_groups(groupname) values (@groupname)", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@groupname", group.groupname))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Public Sub UpdateGroup(ByVal group As DAGroup)
        DBConnection.ConnectionOpen("RidleySoft")
        Dim command As MySqlCommand = New MySqlCommand("update tbl_groups set groupname = @groupname where group_id = @ID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@ID", group.groupID))
        command.Parameters.Add(New MySqlParameter("@groupname", group.groupname))

        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Public Sub deleteGroup(ByVal id As Integer)

        DBConnection.ConnectionOpen("RidleySoft")
        Dim command As MySqlCommand = New MySqlCommand("delete from tbl_groups where group_id = @ID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@ID", id))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Private groupID As Integer
    Private groupname As String

    Public Sub New(ByVal groupID As Integer, ByVal groupname As String)
        Me.GroupID2 = groupID
        Me.GroupName2 = groupname
    End Sub

    Public Property GroupID2() As Integer
        Get
            Return groupID
        End Get
        Set(value As Integer)
            groupID = value
        End Set
    End Property

    Public Property GroupName2() As String
        Get
            Return groupname
        End Get
        Set(value As String)
            groupname = value
        End Set
    End Property
End Class

