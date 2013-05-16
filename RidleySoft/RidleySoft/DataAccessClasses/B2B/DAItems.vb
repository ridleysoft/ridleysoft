Imports MySql.Data.MySqlClient

Public Class DAItems
    Inherits DABaseClass
    Private lijst As List(Of DAItems)
    Private user As DAItems
    Public Sub New()
        MyBase.DABaseClass()
    End Sub

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

    Public Function GetItems() As List(Of DAItems)
        DBConnection.ConnectionOpen("yii_tour")
        Dim sql As String = "select * from tbl_items"

        Dim command As MySqlCommand = New MySqlCommand(sql, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAItems)

        While (dataReader.Read())
            Dim nextItem As New DAItems
            nextItem.ItemNr = (dataReader("item_no")).ToString()
            nextItem.ItemName = (dataReader("item_name")).ToString()
            nextItem.ItemMenuID = (dataReader("item_menu_id"))
            nextItem.itemOrder = dataReader("item_order")
            nextItem.ItemShow = dataReader("item_show")
            lijst.Add(nextItem)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("yii_tour")
        Return lijst
    End Function

    Public Function GetItemsByFilter(ByVal itemName As String, ByVal itemMenuName As String, ByVal TypeMenuName As String, ByVal ItemMenuUrl As String, ByVal ItemVisible As Integer, ByVal ItemShow As Integer) As List(Of DAItems)
        DBConnection.ConnectionOpen("yii_tour")
        Dim sql As String
        If ItemVisible = Nothing And ItemShow <> Nothing Then
            sql = "select * from tbl_item_menu im inner join tbl_items i on i.item_menu_id = im.item_menu_id inner join tbl_type_menu tm on im.type_menu_id = tm.type_menu_id where i.item_name like '%" & itemName & "%' and im.item_menu_name like '%" & itemMenuName & "%' and tm.type_menu_name like '%" & TypeMenuName & "%' and im.item_menu_url like '%" & ItemMenuUrl & "%' and im.item_visible like '%%' and i.item_show like '%" & ItemShow & "%'"
        ElseIf ItemShow = Nothing And ItemVisible <> Nothing Then
            sql = "select * from tbl_item_menu im inner join tbl_items i on i.item_menu_id = im.item_menu_id inner join tbl_type_menu tm on im.type_menu_id = tm.type_menu_id where i.item_name like '%" & itemName & "%' and im.item_menu_name like '%" & itemMenuName & "%' and tm.type_menu_name like '%" & TypeMenuName & "%' and im.item_menu_url like '%" & ItemMenuUrl & "%' and im.item_visible like '%" & ItemVisible & "%' and i.item_show like '%%'"
        ElseIf ItemShow = Nothing And ItemVisible = Nothing Then
            sql = "select * from tbl_item_menu im inner join tbl_items i on i.item_menu_id = im.item_menu_id inner join tbl_type_menu tm on im.type_menu_id = tm.type_menu_id where i.item_name like '%" & itemName & "%' and im.item_menu_name like '%" & itemMenuName & "%' and tm.type_menu_name like '%" & TypeMenuName & "%' and im.item_menu_url like '%" & ItemMenuUrl & "%' and im.item_visible like '%%' and i.item_show like '%%'"
        Else
            sql = "select * from tbl_item_menu im inner join tbl_items i on i.item_menu_id = im.item_menu_id inner join tbl_type_menu tm on im.type_menu_id = tm.type_menu_id where i.item_name like '%" & itemName & "%' and im.item_menu_name like '%" & itemMenuName & "%' and tm.type_menu_name like '%" & TypeMenuName & "%' and im.item_menu_url like '%" & ItemMenuUrl & "%' and im.item_visible like '%" & ItemVisible & "%' and i.item_show like '%" & ItemShow & "%'"
        End If

        Dim command As MySqlCommand = New MySqlCommand(sql, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAItems)

        While (dataReader.Read())
            Dim nextItem As New DAItems
            nextItem.ItemNr = (dataReader("item_no")).ToString()
            nextItem.ItemName = (dataReader("item_name")).ToString()
            nextItem.ItemMenuID = (dataReader("item_menu_id"))
            nextItem.itemOrder = dataReader("item_order")
            nextItem.ItemShow = dataReader("item_show")
            lijst.Add(nextItem)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("yii_tour")
        Return lijst
    End Function

    Public Function getMaxItemOrder(ByVal ItemOrderID As Integer) As Integer
        DBConnection.ConnectionOpen("yii_tour")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("select max(item_order) from tbl_items where item_menu_id =" & ItemOrderID, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        dataReader.Read()
        Dim CountValues As New Integer
        CountValues = (dataReader("max(item_order)"))
        dataReader.Close()
        DBConnection.ConnectionClose("yii_tour")
        Return CountValues
    End Function

    Public Function GetItemInfo(ByVal itemnr As String) As DAItems
        DBConnection.ConnectionOpen("yii_tour")
        Dim command As MySqlCommand = New MySqlCommand("select * from tbl_items where Item_no ='" & itemnr & "'", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        Dim nextItem As New DAItems
        If dataReader.Read() Then
            nextItem.ItemNr = (dataReader("item_no")).ToString()
            nextItem.ItemName = (dataReader("item_name")).ToString()
            nextItem.ItemMenuID = (dataReader("item_menu_id"))
            nextItem.itemOrder = dataReader("item_order")
            nextItem.ItemShow = dataReader("item_show")
        End If
        dataReader.Close()
        DBConnection.ConnectionClose("yii_tour")
        Return nextItem
    End Function

    Public Sub InsertItemMenu(ByVal item As DAItems)
        DBConnection.ConnectionOpen("yii_tour")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("insert into tbl_items(item_no, item_name, item_menu_id, item_order, item_show) values (@item_no, @item_name, @item_menu_id, @item_order, @item_show)", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@item_no", item.ItemNr))
        command.Parameters.Add(New MySqlParameter("@item_name", item.ItemName))
        command.Parameters.Add(New MySqlParameter("@item_menu_id", item.ItemMenuID))
        command.Parameters.Add(New MySqlParameter("@item_order", item.itemOrder))
        command.Parameters.Add(New MySqlParameter("@item_show", item.ItemShow))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("yii_tour")
    End Sub

    Public Sub UpdateItem(ByVal item As DAItems)
        DBConnection.ConnectionOpen("yii_tour")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("update tbl_items set item_name = @item_name, item_menu_id = @item_menu_id, item_show = @item_show where item_no = @ID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@ID", item.ItemNr))
        command.Parameters.Add(New MySqlParameter("@item_name", item.ItemName))
        command.Parameters.Add(New MySqlParameter("@item_menu_id", item.ItemMenuID))
        command.Parameters.Add(New MySqlParameter("@item_show", item.ItemShow))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("yii_tour")
    End Sub

    Public Sub UpdateItemActie(ByVal item As DAItems)
        DBConnection.ConnectionOpen("yii_tour")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("update tbl_items set item_name = @item_name, item_show = @item_show where item_no = @ID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@ID", item.ItemNr))
        command.Parameters.Add(New MySqlParameter("@item_name", item.ItemName))
        command.Parameters.Add(New MySqlParameter("@item_show", item.ItemShow))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("yii_tour")
    End Sub

    Public Sub deleteItem(ByVal id As String)
        DBConnection.ConnectionOpen("yii_tour")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("delete from tbl_items where item_no = @ID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@ID", id))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("yii_tour")
    End Sub

    Private ItemNr2 As String
    Private ItemName2 As String
    Private ItemMenuID2 As Integer
    Private itemOrder2 As Integer
    Private ItemShow2 As Integer


    Public Sub New(ByVal ItemNr2 As String, ByVal ItemName2 As String, ByVal ItemMenuID2 As Integer, ByVal itemOrder2 As Integer, ByVal ItemShow2 As Integer)
        Me.ItemNr = ItemNr2
        Me.ItemName = ItemName2
        Me.ItemMenuID = ItemMenuID2
        Me.itemOrder = itemOrder2
        Me.ItemShow = ItemShow2
    End Sub

    Public Property ItemNr() As String
        Get
            Return ItemNr2
        End Get
        Set(value As String)
            ItemNr2 = value
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

    Public Property ItemMenuID() As Integer
        Get
            Return ItemMenuID2
        End Get
        Set(value As Integer)
            ItemMenuID2 = value
        End Set
    End Property

    Public Property itemOrder() As Integer
        Get
            Return itemOrder2
        End Get
        Set(value As Integer)
            itemOrder2 = value
        End Set
    End Property

    Public Property ItemShow() As Integer
        Get
            Return ItemShow2
        End Get
        Set(value As Integer)
            ItemShow2 = value
        End Set
    End Property
End Class
