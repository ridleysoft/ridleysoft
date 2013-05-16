Imports MySql.Data.MySqlClient

Public Class DASubmenuMod
    Inherits DABaseClass
    Private lijst As List(Of DASubmenuMod)
    Private nextAlles As DASubmenuMod
    Public Sub New()
        MyBase.DABaseClass()
    End Sub

    Public Function getSubMenusByFilter(Optional SubMenuName As String = Nothing, Optional MenuName As String = Nothing) As List(Of DASubmenuMod)

        Dim sql As String = "select sm.submenu_id, sm.description as 'subMenuDescr', me.menu_id, me.description as 'menuDescr' from tbl_submenu sm inner join tbl_menu me on sm.menu_id = me.menu_id where sm.description Like '%" & SubMenuName & "%' and me.description like '%" & MenuName & "%'"
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand(sql, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DASubmenuMod)

        While (dataReader.Read())
            Dim nextMenu As New DASubmenuMod
            nextMenu.submenuID = (dataReader("submenu_id"))
            nextMenu.submenuDescr = dataReader("subMenuDescr").ToString()
            nextMenu.MenuDescription = dataReader("menuDescr").ToString()
            nextMenu.MenuID = dataReader("menu_id")
            lijst.Add(nextMenu)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Function getModuleByMenuId(menuID As Integer) As DASubmenuMod

        Dim sql As String = "select m2.module_id, m2.description as ModuleDescription from tbl_menu_module mm inner join tbl_menu m on mm.menu_id = m.menu_id inner join tbl_module m2 on mm.module_id = m2.module_id where mm.menu_id ="
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand(sql & menuID, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DASubmenuMod)

        dataReader.Read()
        Dim nextAlles As New DASubmenuMod
        nextAlles.ModuleID = dataReader("module_id")
        nextAlles.ModuleDescription = (dataReader("ModuleDescription")).ToString()
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return nextAlles
    End Function

    Public Function getModuleByMenuId2(menuID As Integer) As DASubmenuMod
        DBConnection.ConnectionOpen("RidleySoft")
        Dim sql As String = "select m2.module_id, m2.description as ModuleDescription from tbl_menu_module mm inner join tbl_menu m on mm.menu_id = m.menu_id inner join tbl_module m2 on mm.module_id = m2.module_id where mm.menu_id ="

        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand(sql & menuID, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DASubmenuMod)

        While (dataReader.Read())
            Dim nextAlles As New DASubmenuMod
            nextAlles.ModuleID = dataReader("module_id")
            nextAlles.ModuleDescription = (dataReader("ModuleDescription")).ToString()
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return nextAlles
    End Function

    Private menuID2 As Integer
    Private menudescription2 As String
    Private moduleID2 As Integer
    Private moduledescription2 As String
    Private submenuID2 As Integer
    Private submenuDescr2 As String

    Public Sub New(ByVal menuID2 As Integer, ByVal menudescription2 As String, ByVal moduleID2 As Integer, ByVal moduledescription2 As String, ByVal submenuID2 As Integer, ByVal submenuDescr2 As String)
        Me.MenuID = menuID2
        Me.MenuDescription = menudescription2
        Me.ModuleID = moduleID2
        Me.ModuleDescription = moduledescription2
        Me.submenuID = submenuID2
        Me.submenuDescr = submenuDescr2

    End Sub

    Public Property MenuID() As Integer
        Get
            Return menuID2
        End Get
        Set(value As Integer)
            menuID2 = value
        End Set
    End Property

    Public Property MenuDescription() As String
        Get
            Return menudescription2
        End Get
        Set(value As String)
            menudescription2 = value
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

    Public Property ModuleDescription() As String
        Get
            Return moduledescription2
        End Get
        Set(value As String)
            moduledescription2 = value
        End Set
    End Property

    Public Property submenuID() As Integer
        Get
            Return submenuID2
        End Get
        Set(value As Integer)
            submenuID2 = value
        End Set
    End Property

    Public Property submenuDescr() As String
        Get
            Return submenuDescr2
        End Get
        Set(value As String)
            submenuDescr2 = value
        End Set
    End Property
End Class
