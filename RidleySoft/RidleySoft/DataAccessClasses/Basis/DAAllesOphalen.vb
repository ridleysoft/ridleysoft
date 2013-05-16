Imports MySql.Data.MySqlClient
Public Class DAAllesOphalen
    Inherits DABaseClass
    Private lijst As List(Of DAAllesOphalen)
    Public Sub New()
        MyBase.DABaseClass()
    End Sub
    Public Function getAllesByUserId(userID As Integer) As List(Of DAAllesOphalen)
        DBConnection.ConnectionOpen("RidleySoft")
        Dim sql As String = "select distinct gr.group_id, gr.groupname, m.module_id, m.description, um.user_id from tbl_module m inner join  tbl_groups gr on m.group_id = gr.group_id inner join tbl_user_module um on m.module_id = um.module_id where user_id ="


        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand(sql & userID & " group by gr.group_id", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAAllesOphalen)

        While (dataReader.Read())
            Dim nextAlles As New DAAllesOphalen
            nextAlles.GroupID = (dataReader("group_id"))
            nextAlles.GroupName = (dataReader("groupname")).ToString()
            nextAlles.ModuleID = dataReader("module_id")
            nextAlles.Description = (dataReader("description")).ToString()
            nextAlles.UserID = dataReader("user_id").ToString()
            lijst.Add(nextAlles)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function


    Private groupID2 As Integer
    Private groupName2 As String
    Private moduleID2 As Integer
    Private description2 As String
    Private userID2 As Integer

    Public Sub New(ByVal groupID2 As Integer, ByVal groupName2 As String, ByVal moduleID2 As Integer, ByVal description2 As String, ByVal userID2 As Integer)
        Me.GroupID = groupID2
        Me.GroupName = groupName2
        Me.ModuleID = moduleID2
        Me.Description = description2
        Me.UserID = userID2
    End Sub

    Public Property GroupID() As Integer
        Get
            Return groupID2
        End Get
        Set(value As Integer)
            groupID2 = value
        End Set
    End Property

    Public Property GroupName() As String
        Get
            Return groupName2
        End Get
        Set(value As String)
            groupName2 = value
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

    Public Property Description() As String
        Get
            Return description2
        End Get
        Set(value As String)
            description2 = value
        End Set
    End Property

    Public Property UserID() As Integer
        Get
            Return userID2
        End Get
        Set(value As Integer)
            userID2 = value
        End Set
    End Property
End Class
