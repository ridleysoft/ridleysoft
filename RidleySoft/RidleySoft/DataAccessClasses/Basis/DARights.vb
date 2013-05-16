Imports MySql.Data.MySqlClient

Public Class DARights
    Inherits DABaseClass
    Private lijst As List(Of DARights)
    Private user As DARights
    Public Sub New()
        MyBase.DABaseClass()
    End Sub

    Public Function getRights() As List(Of DARights)
        DBConnection.ConnectionOpen("RidleySoft")
        Dim command As MySqlCommand = New MySqlCommand("SELECT * from tbl_rights", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DARights)

        While (dataReader.Read())
            Dim nextUserModule As New DARights
            nextUserModule.RightID = (dataReader("right_id"))
            nextUserModule.Description = dataReader("description")
            lijst.Add(nextUserModule)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Function GetRightsByFilter(ByVal text As String) As List(Of DARights)
        DBConnection.ConnectionOpen("RidleySoft")
        Dim sql As String = "select * from tbl_rights r where r.description Like '%" & text & "%'"
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand(sql, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DARights)

        While (dataReader.Read())
            Dim nextUser As New DARights
            nextUser.RightID = (dataReader("right_id"))
            nextUser.Description = (dataReader("description")).ToString()
            lijst.Add(nextUser)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Function getRightsNotLinked(userID As Integer) As List(Of DARights)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("select * from tbl_rights where right_id not in (select right_id from tbl_user_rights where user_id =" & userID & ")", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DARights)

        While (dataReader.Read())
            Dim nextUserRight As New DARights
            nextUserRight.RightID = dataReader("right_id")
            nextUserRight.Description = dataReader("description")
            lijst.Add(nextUserRight)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Function getRightsByID(userID As Integer) As List(Of DARights)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("select r.right_id, r.description from tbl_rights r inner join tbl_user_rights ur on r.right_id = ur.right_id where ur.user_id = " & userID, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DARights)

        While (dataReader.Read())
            Dim nextRight As New DARights
            nextRight.RightID = (dataReader("right_id"))
            nextRight.Description = dataReader("description").ToString()
            lijst.Add(nextRight)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Function getCountRightsByRightID(ByVal RightID As Integer) As Integer
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("select count(r.right_id) from tbl_rights r inner join tbl_user_rights ur on r.right_id = ur.right_id where r.right_id = " & RightID, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        dataReader.Read()
        Dim CountSetting As New Integer
        CountSetting = (dataReader("count(r.right_id)"))
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return CountSetting
    End Function
    Public Sub InsertUserRights(ByVal right As DARights)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("insert into tbl_rights(description) values (@Description)", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@Description", right.Description))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Public Sub UpdateRight(ByVal right As DARights)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("update tbl_rights set description = @description where right_id = @ID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@ID", right.RightID))
        command.Parameters.Add(New MySqlParameter("@description", right.Description))

        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Public Sub deleteRight(ByVal id As Integer)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("delete from tbl_rights where right_id = @ID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@ID", id))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub


    Private rightID2 As Integer
    Private description2 As String

    Public Sub New(ByVal rightID2 As Integer, ByVal description2 As String)
        Me.RightID = rightID2
        Me.Description = description2
    End Sub

    Public Property RightID() As Integer
        Get
            Return rightID2
        End Get
        Set(value As Integer)
            rightID2 = value
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
End Class
