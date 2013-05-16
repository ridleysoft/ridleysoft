Imports MySql.Data.MySqlClient

Public Class DAHeadSubMenuToTypeItem
    Inherits DABaseClass
    Private lijst As List(Of DAHeadSubMenuToTypeItem)
    Private user As DAHeadSubMenuToTypeItem
    Public Sub New()
        MyBase.DABaseClass()
    End Sub
    Public Sub InsertItemMenu(ByVal item As DAHeadSubMenuToTypeItem)
        DBConnection.ConnectionOpen("yii_tour")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("insert into tbl_headsubmenu_to_type_item_menu(headsubmenu_id, type_menu_id, item_menu_id) values (@headsubmenu_id, @type_menu_id, null)", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@headsubmenu_id", item.HeadsubmenuID))
        command.Parameters.Add(New MySqlParameter("@type_menu_id", item.TypeMenuID))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("yii_tour")
    End Sub

    Public Sub InsertItemMenuActie(ByVal item As DAHeadSubMenuToTypeItem)
        DBConnection.ConnectionOpen("yii_tour")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("insert into tbl_headsubmenu_to_type_item_menu(headsubmenu_id,type_menu_id, item_menu_id) values (@headsubmenu_id, null, @item_menu_id)", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@headsubmenu_id", item.HeadsubmenuID))
        command.Parameters.Add(New MySqlParameter("@item_menu_id", item.ItemMenuID))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("yii_tour")
    End Sub

    Private HeadSubmenuToTypeItemID2 As Integer
    Private HeadsubmenuID2 As Integer
    Private TypeMenuID2 As Integer
    Private ItemMenuID2 As Integer


    Public Sub New(ByVal HeadSubmenuToTypeItemID2 As Integer, ByVal HeadsubmenuID2 As Integer, ByVal TypeMenuID2 As Integer, ByVal ItemMenuID2 As Integer)
        Me.HeadSubmenuToTypeItemID = HeadSubmenuToTypeItemID2
        Me.HeadsubmenuID = HeadsubmenuID2
        Me.TypeMenuID = TypeMenuID2
        Me.ItemMenuID = ItemMenuID2
    End Sub

    Public Property HeadSubmenuToTypeItemID() As Integer
        Get
            Return HeadSubmenuToTypeItemID2
        End Get
        Set(value As Integer)
            HeadSubmenuToTypeItemID2 = value
        End Set
    End Property

    Public Property HeadsubmenuID() As Integer
        Get
            Return HeadsubmenuID2
        End Get
        Set(value As Integer)
            HeadsubmenuID2 = value
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

    Public Property ItemMenuID() As Integer
        Get
            Return ItemMenuID2
        End Get
        Set(value As Integer)
            ItemMenuID2 = value
        End Set
    End Property
End Class
