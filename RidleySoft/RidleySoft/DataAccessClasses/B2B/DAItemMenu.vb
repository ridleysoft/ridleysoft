Imports MySql.Data.MySqlClient

Public Class DAItemMenu
    Inherits DABaseClass
    Private lijst As List(Of DAItemMenu)
    Private user As DAItemMenu
    Public Sub New()
        MyBase.DABaseClass()
    End Sub

    Public Function GetItems() As List(Of DAItemMenu)
        DBConnection.ConnectionOpen("yii_tour")
        Dim sql As String = "select * from tbl_item_menu"

        Dim command As MySqlCommand = New MySqlCommand(sql, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAItemMenu)

        While (dataReader.Read())
            Dim nextItem As New DAItemMenu
            nextItem.ItemMenuID = (dataReader("item_menu_id"))
            nextItem.ItemName = (dataReader("item_menu_name")).ToString()
            nextItem.ItemMenuOrder = (dataReader("item_menu_order"))
            nextItem.TypeMenuID = dataReader("type_menu_id")
            nextItem.ItemMenuURL = dataReader("item_menu_url").ToString()
            nextItem.ItemMenuPicture = dataReader("item_menu_picture").ToString()
            nextItem.ItemVisible = dataReader("item_visible")
            lijst.Add(nextItem)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("yii_tour")
        Return lijst
    End Function

    Public Function getCountValuesByArtikelID(ByVal ArtikelID As String) As Integer
        DBConnection.ConnectionOpen("yii_tour")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("select count(*) from tbl_items where Item_no ='" & ArtikelID & "'", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        dataReader.Read()
        Dim CountValues As New Integer
        CountValues = (dataReader("count(*)"))
        dataReader.Close()
        DBConnection.ConnectionClose("yii_tour")
        Return CountValues
    End Function

    Public Function getMaxMenuOrder(ByVal typeMenuID As Integer) As Integer
        DBConnection.ConnectionOpen("yii_tour")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("select max(im.item_menu_order) from tbl_item_menu im where im.type_menu_id = " & typeMenuID, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        dataReader.Read()
        Dim CountValues As New Integer
        If Not IsDBNull((dataReader("max(im.item_menu_order)"))) Then
            CountValues = (dataReader("max(im.item_menu_order)"))
        Else
            CountValues = 0
        End If
        dataReader.Close()
        DBConnection.ConnectionClose("yii_tour")
        Return CountValues
    End Function

    Public Function getMaxID() As Integer
        DBConnection.ConnectionOpen("yii_tour")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("select max(m.item_menu_id) from tbl_item_menu m", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        dataReader.Read()
        Dim CountValues As New Integer
        CountValues = (dataReader("max(m.item_menu_id)"))
        dataReader.Close()
        DBConnection.ConnectionClose("yii_tour")
        Return CountValues
    End Function

    Public Function GetItemInfo(ByVal ItemName As String) As DAItemMenu
        DBConnection.ConnectionOpen("yii_tour")
        Dim command As MySqlCommand = New MySqlCommand("select * from tbl_item_menu im where im.item_menu_name = '" & ItemName & "'", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        Dim nextItem As New DAItemMenu
        If dataReader.Read() Then
            nextItem.ItemMenuID = (dataReader("item_menu_id")).ToString()
            nextItem.ItemName = (dataReader("item_menu_name")).ToString()
            nextItem.ItemMenuOrder = (dataReader("item_menu_order"))
            If Not IsDBNull(dataReader("type_menu_id")) Then
                nextItem.TypeMenuID = dataReader("type_menu_id")
            Else
                nextItem.TypeMenuID = Nothing
            End If

            nextItem.ItemMenuURL = dataReader("item_menu_url")
            If nextItem.ItemMenuPicture IsNot Nothing Then
                nextItem.ItemMenuPicture = dataReader("item_menu_picture")
            End If
            nextItem.ItemVisible = dataReader("item_visible")
        End If
        dataReader.Close()
        DBConnection.ConnectionClose("yii_tour")
        Return nextItem
    End Function

    Public Function GetItemByID(ByVal ID As Integer) As DAItemMenu
        DBConnection.ConnectionOpen("yii_tour")
        Dim command As MySqlCommand = New MySqlCommand("select * from tbl_item_menu im where im.item_menu_id =" & ID, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        Dim nextItem As New DAItemMenu
        If dataReader.Read() Then
            nextItem.ItemMenuID = (dataReader("item_menu_id")).ToString()
            nextItem.ItemName = (dataReader("item_menu_name")).ToString()
            nextItem.ItemMenuOrder = (dataReader("item_menu_order"))
            If Not IsDBNull(dataReader("type_menu_id")) Then
                nextItem.TypeMenuID = dataReader("type_menu_id")
            Else
                nextItem.TypeMenuID = Nothing
            End If

            nextItem.ItemMenuURL = dataReader("item_menu_url")
            If nextItem.ItemMenuPicture IsNot Nothing Then
                nextItem.ItemMenuPicture = dataReader("item_menu_picture")
            End If
            nextItem.ItemVisible = dataReader("item_visible")
        End If
        dataReader.Close()
        DBConnection.ConnectionClose("yii_tour")
        Return nextItem
    End Function

    Public Sub InsertItemMenu(ByVal itemMenu As DAItemMenu)
        DBConnection.ConnectionOpen("yii_tour")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("insert into tbl_item_menu(item_menu_name, item_menu_order, type_menu_id, item_menu_url, item_menu_picture, item_visible) values (@itemMenuName, @itemMenuOrder, @typeMenuID, @itemMenuURL, @itemMenuPicture, @itemVisible)", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@itemMenuName", itemMenu.ItemName))
        command.Parameters.Add(New MySqlParameter("@itemMenuOrder", itemMenu.ItemMenuOrder))
        command.Parameters.Add(New MySqlParameter("@typeMenuID", itemMenu.TypeMenuID))
        command.Parameters.Add(New MySqlParameter("@itemMenuURL", itemMenu.ItemMenuURL))
        command.Parameters.Add(New MySqlParameter("@itemMenuPicture", itemMenu.ItemMenuPicture))
        command.Parameters.Add(New MySqlParameter("@itemVisible", itemMenu.ItemVisible))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("yii_tour")
    End Sub

    Public Sub InsertItemMenuActie(ByVal itemMenu As DAItemMenu)
        DBConnection.ConnectionOpen("yii_tour")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("insert into tbl_item_menu(item_menu_name, item_menu_order, type_menu_id, item_menu_url, item_menu_picture, item_visible) values (@itemMenuName, @itemMenuOrder, null, @itemMenuURL, @itemMenuPicture, @itemVisible)", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@itemMenuName", itemMenu.ItemName))
        command.Parameters.Add(New MySqlParameter("@itemMenuOrder", itemMenu.ItemMenuOrder))
        command.Parameters.Add(New MySqlParameter("@itemMenuURL", itemMenu.ItemMenuURL))
        command.Parameters.Add(New MySqlParameter("@itemMenuPicture", itemMenu.ItemMenuPicture))
        command.Parameters.Add(New MySqlParameter("@itemVisible", itemMenu.ItemVisible))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("yii_tour")
    End Sub

    Public Sub UpdateItemMenu(ByVal itemMenu As DAItemMenu)
        DBConnection.ConnectionOpen("yii_tour")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("update tbl_item_menu set item_menu_name = @item_menu_name, type_menu_id = @type_menu_id, item_menu_url = @item_menu_url, item_visible = @item_visible where item_menu_id = @ID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@ID", itemMenu.ItemMenuID))
        command.Parameters.Add(New MySqlParameter("@item_menu_name", itemMenu.ItemName))
        command.Parameters.Add(New MySqlParameter("@type_menu_id", itemMenu.TypeMenuID))
        command.Parameters.Add(New MySqlParameter("@item_menu_url", itemMenu.ItemMenuURL))
        command.Parameters.Add(New MySqlParameter("@item_visible", itemMenu.ItemVisible))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("yii_tour")
    End Sub

    Public Sub UpdateItemMenuTypeisNull(ByVal itemMenu As DAItemMenu)
        DBConnection.ConnectionOpen("yii_tour")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("update tbl_item_menu set item_menu_name = @item_menu_name, type_menu_id = null, item_menu_url = @item_menu_url, item_visible = @item_visible where item_menu_id = @ID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@ID", itemMenu.ItemMenuID))
        command.Parameters.Add(New MySqlParameter("@item_menu_name", itemMenu.ItemName))
        command.Parameters.Add(New MySqlParameter("@item_menu_url", itemMenu.ItemMenuURL))
        command.Parameters.Add(New MySqlParameter("@item_visible", itemMenu.ItemVisible))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("yii_tour")
    End Sub

    Public Sub deleteItem(ByVal id As Integer)
        DBConnection.ConnectionOpen("yii_tour")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("delete from tbl_item_menu where item_menu_id = @ID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@ID", id))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("yii_tour")
    End Sub

    Private ItemMenuID2 As Integer
    Private ItemName2 As String
    Private ItemMenuOrder2 As Integer
    Private TypeMenuID2 As Integer
    Private ItemMenuURL2 As String
    Private ItemMenuPicture2 As String
    Private ItemVisible2 As Integer

    Public Sub New(ByVal ItemMenuID2 As Integer, ByVal ItemName2 As String, ByVal ItemMenuOrder2 As Integer, ByVal TypeMenuID2 As Integer, ByVal ItemMenuURL2 As String, ByVal ItemMenuPicture2 As String, ByVal ItemVisible2 As Integer)
        Me.ItemMenuID = ItemMenuID2
        Me.ItemName = ItemName2
        Me.ItemMenuOrder = ItemMenuOrder2
        Me.TypeMenuID = TypeMenuID2
        Me.ItemMenuURL = ItemMenuURL2
        Me.ItemMenuPicture = ItemMenuPicture2
        Me.ItemVisible = ItemVisible2
    End Sub

    Public Property ItemMenuID() As Integer
        Get
            Return ItemMenuID2
        End Get
        Set(value As Integer)
            ItemMenuID2 = value
        End Set
    End Property

    Public Property ItemName() As String
        Get
            Return ItemName2
        End Get
        Set(value As String)
            ItemName2 = value
        End Set
    End Property

    Public Property ItemMenuOrder() As Integer
        Get
            Return ItemMenuOrder2
        End Get
        Set(value As Integer)
            ItemMenuOrder2 = value
        End Set
    End Property

    Public Property TypeMenuID() As Integer
        Get
            Return TypeMenuID2
        End Get
        Set(value As Integer)
            TypeMenuID2 = value
        End Set
    End Property

    Public Property ItemMenuURL() As String
        Get
            Return ItemMenuURL2
        End Get
        Set(value As String)
            ItemMenuURL2 = value
        End Set
    End Property

    Public Property ItemMenuPicture() As String
        Get
            Return ItemMenuPicture2
        End Get
        Set(value As String)
            ItemMenuPicture2 = value
        End Set
    End Property

    Public Property ItemVisible() As Integer
        Get
            Return ItemVisible2
        End Get
        Set(value As Integer)
            ItemVisible2 = value
        End Set
    End Property
End Class
