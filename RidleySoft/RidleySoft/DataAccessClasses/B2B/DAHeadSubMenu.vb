Imports MySql.Data.MySqlClient

Public Class DAHeadSubMenu
    Inherits DABaseClass
    Public Sub New()
        MyBase.DABaseClass()
    End Sub

    Public Function getHeadSubmenuIDByButtonClicked(ByVal ButtonTag As Integer) As Integer
        DBConnection.ConnectionOpen("yii_tour")

        Dim command As MySqlCommand = New MySqlCommand("select headsubmenu_id from tbl_headsubmenu where ridley_soft = " & ButtonTag, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        dataReader.Read()
        Dim HeadsubmenuID As New Integer
        HeadsubmenuID = (dataReader("headsubmenu_id"))
        dataReader.Close()
        DBConnection.ConnectionClose("yii_tour")
        Return HeadsubmenuID
    End Function

    Private headsubmenuID2 As Integer

    Public Sub New(ByVal headsubmenuID2 As Integer)
        Me.HeadSubMenuID = headsubmenuID2
    End Sub

    Public Property HeadSubMenuID() As Integer
        Get
            Return headsubmenuID2
        End Get
        Set(value As Integer)
            headsubmenuID2 = value
        End Set
    End Property
End Class
