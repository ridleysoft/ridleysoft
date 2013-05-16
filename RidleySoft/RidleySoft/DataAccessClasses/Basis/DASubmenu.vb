Imports MySql.Data.MySqlClient
Public Class DASubmenu
    Inherits DABaseClass
    Private lijst As List(Of DASubmenu)
    Public Sub New()
        MyBase.DABaseClass()
    End Sub
    Public Function getSubMenusByMenuId(menuID As Integer) As List(Of DASubmenu)
        DBConnection.ConnectionOpen("RidleySoft")
        Dim sql As String = "select * from tbl_submenu where menu_id="

        Dim command As MySqlCommand = New MySqlCommand(sql & menuID, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DASubmenu)

        While (dataReader.Read())
            Dim nextMenu As New DASubmenu
            nextMenu.SubmenuID = (dataReader("submenu_id"))
            nextMenu.Description = (dataReader("description")).ToString()
            nextMenu.MenuID = dataReader("menu_id")
            lijst.Add(nextMenu)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Function getSubMenus() As List(Of DASubmenu)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("select * from tbl_submenu", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DASubmenu)

        While (dataReader.Read())
            Dim nextSubMenu As New DASubmenu
            nextSubMenu.SubmenuID = (dataReader("submenu_id"))
            nextSubMenu.Description = dataReader("description").ToString()
            nextSubMenu.MenuID = dataReader("menu_id")
            lijst.Add(nextSubMenu)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function


    Public Function getMaxSubMenuID() As Integer
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("select max(submenu_id) from tbl_submenu", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        dataReader.Read()
        Dim MenuID2 As New Integer
        MenuID2 = (dataReader("max(menu_id)"))
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return MenuID2
    End Function

    Public Sub InsertSubMenu(ByVal subMenu As DASubmenu)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("insert into tbl_submenu(description, menu_id) values (@description, @MenuID)", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@description", subMenu.Description))
        command.Parameters.Add(New MySqlParameter("@MenuID", subMenu.MenuID))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Public Sub UpdateSubMenu(ByVal subMenu As DASubmenu)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("update tbl_submenu set description = @description, menu_id = @MenuID where submenu_id = @ID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@description", subMenu.Description))
        command.Parameters.Add(New MySqlParameter("@MenuID", subMenu.MenuID))
        command.Parameters.Add(New MySqlParameter("@ID", subMenu.SubmenuID))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Public Sub deleteSubMenu(ByVal id As Integer)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("delete from tbl_submenu where submenu_id = @ID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@ID", id))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Private submenuID2 As Integer
    Private description2 As String
    Private menuID2 As Integer

    Public Sub New(ByVal submenuID2 As Integer, ByVal description2 As String, ByVal menuID2 As Integer)
        Me.SubmenuID = submenuID2
        Me.Description = description2
        Me.MenuID = menuID2
    End Sub

    Public Property SubmenuID() As Integer
        Get
            Return submenuID2
        End Get
        Set(value As Integer)
            submenuID2 = value
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

    Public Property MenuID() As Integer
        Get
            Return menuID2
        End Get
        Set(value As Integer)
            menuID2 = value
        End Set
    End Property
End Class
