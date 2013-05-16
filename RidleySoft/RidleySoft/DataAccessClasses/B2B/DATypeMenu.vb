Imports MySql.Data.MySqlClient

Public Class DATypeMenu
    Inherits DABaseClass
    Private lijst As List(Of DATypeMenu)
    Public Sub New()
        MyBase.DABaseClass()
    End Sub

    Public Function getTypeById(headsubmenuID As Integer) As List(Of DATypeMenu)

        DBConnection.ConnectionOpen("yii_tour")

        Dim command As MySqlCommand = New MySqlCommand("select distinct(tm.type_menu_id), tm.type_menu_name from tbl_headsubmenu_to_type_item_menu tim inner join tbl_type_menu tm on tim.type_menu_id = tm.type_menu_id where tim.headsubmenu_id = " & headsubmenuID, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DATypeMenu)

        While (dataReader.Read())
            Dim nextTypemenu As New DATypeMenu
            nextTypemenu.TypeMenuID = (dataReader("type_menu_id"))
            nextTypemenu.TypeMenuName = (dataReader("type_menu_name")).ToString()
            lijst.Add(nextTypemenu)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("yii_tour")
        Return lijst
    End Function


    Public Function getTypes() As List(Of DATypeMenu)

        DBConnection.ConnectionOpen("yii_tour")

        Dim command As MySqlCommand = New MySqlCommand("select * from tbl_type_menu", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DATypeMenu)

        While (dataReader.Read())
            Dim nextTypemenu As New DATypeMenu
            nextTypemenu.TypeMenuID = (dataReader("type_menu_id"))
            nextTypemenu.TypeMenuName = (dataReader("type_menu_name")).ToString()
            lijst.Add(nextTypemenu)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("yii_tour")
        Return lijst
    End Function

    Public Function GetTypeMenu(ByVal TypeMenuID As Integer) As DATypeMenu
        DBConnection.ConnectionOpen("yii_tour")
        Dim command As MySqlCommand = New MySqlCommand("select * from tbl_type_menu tm where tm.type_menu_id = '" & TypeMenuID & "'", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        Dim nextTypemenu As New DATypeMenu
        If dataReader.Read() Then
            nextTypemenu.TypeMenuID = (dataReader("type_menu_id"))
            nextTypemenu.TypeMenuName = (dataReader("type_menu_name")).ToString()
        End If
        dataReader.Close()
        DBConnection.ConnectionClose("yii_tour")
        Return nextTypemenu
    End Function

    Public Function GetTypeMenuByName(ByVal TypeMenu As String) As DATypeMenu
        DBConnection.ConnectionOpen("yii_tour")
        Dim command As MySqlCommand = New MySqlCommand("select * from tbl_type_menu tm where tm.type_menu_name = '" & TypeMenu & "'", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        Dim nextTypemenu As New DATypeMenu
        If dataReader.Read() Then
            nextTypemenu.TypeMenuID = (dataReader("type_menu_id"))
            nextTypemenu.TypeMenuName = (dataReader("type_menu_name")).ToString()
        End If
        dataReader.Close()
        DBConnection.ConnectionClose("yii_tour")
        Return nextTypemenu
    End Function

    Private TypeMenuID2 As Integer
    Private TypeMenuName2 As String

    Public Sub New(ByVal TypeMenuID2 As Integer, ByVal TypeMenuName2 As String)
        Me.TypeMenuID = TypeMenuID2
        Me.TypeMenuName = TypeMenuName2
    End Sub

    Public Property TypeMenuID() As Integer
        Get
            Return TypeMenuID2
        End Get
        Set(value As Integer)
            TypeMenuID2 = value
        End Set
    End Property

    Public Property TypeMenuName() As String
        Get
            Return TypeMenuName2
        End Get
        Set(value As String)
            TypeMenuName2 = value
        End Set
    End Property
End Class
