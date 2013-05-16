Imports MySql.Data.MySqlClient
Public Class DAMenu
    Inherits DABaseClass
    Private lijst As List(Of DAMenu)
    Private _p1 As String
    Private _p2 As Object

    Public Sub New()
        MyBase.DABaseClass()
    End Sub

    Sub New(p1 As String, p2 As Object)
        ' TODO: Complete member initialization 
        _p1 = p1
        _p2 = p2
    End Sub

    Public Function getCountMenusByMenuID(ByVal MenuID As Integer) As Integer
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("select count(m.menu_id) from tbl_menu m inner join tbl_submenu sm on m.menu_id = sm.menu_id where m.menu_id = " & MenuID, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        dataReader.Read()
        Dim CountSetting As New Integer
        CountSetting = (dataReader("count(m.menu_id)"))
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return CountSetting
    End Function

    Public Function getMenusByModuleId(moduleID As Integer) As List(Of DAMenu)
        Dim sql As String = "select m.menu_id, m.description, mm.module_id from tbl_menu m inner join tbl_menu_module mm on m.menu_id = mm.menu_id where module_id ="
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand(sql & moduleID, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAMenu)

        While (dataReader.Read())
            Dim nextMenu As New DAMenu
            nextMenu.MenuID = (dataReader("menu_id"))
            nextMenu.Description = (dataReader("description")).ToString()
            nextMenu.ModuleID = dataReader("module_id")
            lijst.Add(nextMenu)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Function GetMenusByFilter(ByVal text As String) As List(Of DAMenu)

        Dim sql As String = "select m.menu_id, m.description, mm.module_id from tbl_menu m inner join tbl_menu_module mm on m.menu_id = mm.menu_id where m.description Like '%" & text & "%'"
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()

        Dim command As MySqlCommand = New MySqlCommand(sql, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAMenu)

        While (dataReader.Read())
            Dim nextUser As New DAMenu
            nextUser.MenuID = (dataReader("menu_id"))
            nextUser.Description = (dataReader("description")).ToString()
            nextUser.ModuleID = dataReader("module_id")
            lijst.Add(nextUser)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Function getMenus() As List(Of DAMenu)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()

        Dim command As MySqlCommand = New MySqlCommand("select m.menu_id, description, mm.module_id from tbl_menu m inner join tbl_menu_module mm on m.menu_id = mm.menu_id order by m.menu_id", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAMenu)

        While (dataReader.Read())
            Dim nextMenu As New DAMenu
            nextMenu.MenuID = (dataReader("menu_id"))
            nextMenu.Description = dataReader("description").ToString()
            nextMenu.ModuleID = dataReader("module_id")
            lijst.Add(nextMenu)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Function getMenusAdmin() As List(Of DAMenu)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()

        Dim command As MySqlCommand = New MySqlCommand("select CONCAT(m.description, ' - ',  m2.description) as 'description', mm.menu_id from tbl_menu_module mm inner join tbl_menu m on mm.menu_id = m.menu_id  inner join tbl_module m2 on mm.module_id = m2.module_id ", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAMenu)

        While (dataReader.Read())
            Dim nextSubMenu As New DAMenu
            nextSubMenu.Description = dataReader("description").ToString()
            nextSubMenu.MenuID = dataReader("menu_id")
            lijst.Add(nextSubMenu)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Function getMaxMenuID() As Integer
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()

        Dim command As MySqlCommand = New MySqlCommand("select max(menu_id) from tbl_menu", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        dataReader.Read()
        Dim MenuID2 As New Integer
        MenuID2 = (dataReader("max(menu_id)"))
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return MenuID2
    End Function

    Public Sub InsertMenu(ByVal menu As DAMenu)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()

        Dim command As MySqlCommand = New MySqlCommand("insert into tbl_menu(description) values (@description)", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@description", menu.Description))
        command.ExecuteNonQuery()
        DBconnectionMYSQL.Close()
    End Sub

    Public Sub UpdateMenu(ByVal menu As DAMenu)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()

        Dim command As MySqlCommand = New MySqlCommand("update tbl_menu set description = @description where menu_id = @ID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@description", menu.Description))
        command.Parameters.Add(New MySqlParameter("@ID", menu.MenuID))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Public Sub deleteMenu(ByVal id As Integer)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()

        Dim command As MySqlCommand = New MySqlCommand("delete from tbl_menu where menu_id = @ID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@ID", id))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Private menuID2 As Integer
    Private description2 As String
    Private moduleID2 As Integer

    Public Sub New(ByVal menuID2 As Integer, ByVal description2 As String, ByVal moduleID2 As Integer)
        Me.MenuID = menuID2
        Me.Description = description2
        Me.ModuleID = moduleID2
    End Sub

    Public Property MenuID() As Integer
        Get
            Return menuID2
        End Get
        Set(value As Integer)
            menuID2 = value
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

    Public Property ModuleID() As Integer
        Get
            Return moduleID2
        End Get
        Set(value As Integer)
            moduleID2 = value
        End Set
    End Property
End Class
