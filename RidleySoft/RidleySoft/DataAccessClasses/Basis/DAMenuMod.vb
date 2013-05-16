Imports MySql.Data.MySqlClient

Public Class DAMenuMod
    Private lijst As List(Of DAMenuMod)

    Sub New()
        ' TODO: Complete member initialization 
    End Sub

    Public Function getMenusByFilter(Optional MenuName As String = Nothing, Optional ModuleName As String = Nothing) As List(Of DAMenuMod)
        DBConnection.ConnectionOpen("RidleySoft")
        Dim sql As String = "select mm.module_id, me.description as 'menuDescr', mm.menu_id, m.description as 'modDescr' from tbl_menu_module mm inner join tbl_menu me on mm.menu_id = me.menu_id inner join tbl_module m on mm.module_id = m.module_id where me.description Like '%" & MenuName & "%' and m.description like '%" & ModuleName & "%'"

        Dim command As MySqlCommand = New MySqlCommand(sql, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAMenuMod)

        While (dataReader.Read())
            Dim nextMenu As New DAMenuMod
            nextMenu.ModuleID = (dataReader("module_id"))
            nextMenu.MenuDescr = dataReader("menuDescr").ToString()
            nextMenu.ModDescr = dataReader("modDescr").ToString()
            nextMenu.MenuID = dataReader("menu_id")
            lijst.Add(nextMenu)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Function getMenusByModuleId(moduleID As Integer) As List(Of DAMenuMod)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("SELECT DISTINCT menu_id from tbl_menu_module where module_id=" & moduleID, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAMenuMod)

        While (dataReader.Read())
            Dim nextMenu As New DAMenuMod
            nextMenu.MenuID = (dataReader("menu_id"))
            lijst.Add(nextMenu)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Function getMByModuleId(moduleID As Integer) As List(Of DAMenuMod)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("SELECT DISTINCT menu_id from tbl_menu_module where module_id=" & moduleID, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAMenuMod)

        While (dataReader.Read())
            Dim nextMenu As New DAMenuMod
            nextMenu.MenuID = (dataReader("menu_id"))
            lijst.Add(nextMenu)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Sub InsertMenuModule(ByVal menu As DAMenuMod)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("insert into tbl_menu_module(menu_id, module_id) values (@menu_id, @moduleID)", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@menu_id", menu.MenuID))
        command.Parameters.Add(New MySqlParameter("@moduleID", menu.ModuleID))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Private menuID2 As Integer
    Private moduleID2 As Integer
    Private MenuDescr2 As String
    Private ModDescr2 As String

    Public Sub New(ByVal menuID2 As Integer, ByVal moduleID2 As Integer, ByVal MenuDescr2 As String, ByVal ModDescr2 As String)
        Me.MenuID = menuID2
        Me.ModuleID = moduleID2
        Me.MenuDescr = MenuDescr2
        Me.ModDescr = ModDescr2
    End Sub

    Public Property MenuID() As Integer
        Get
            Return menuID2
        End Get
        Set(value As Integer)
            menuID2 = value
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

    Public Property MenuDescr() As String
        Get
            Return MenuDescr2
        End Get
        Set(value As String)
            MenuDescr2 = value
        End Set
    End Property

    Public Property ModDescr() As String
        Get
            Return ModDescr2
        End Get
        Set(value As String)
            ModDescr2 = value
        End Set
    End Property
End Class
