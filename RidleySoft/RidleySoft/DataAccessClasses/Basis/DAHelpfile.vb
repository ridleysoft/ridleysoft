Imports MySql.Data.MySqlClient

Public Class DAHelpfile
    Inherits DABaseClass
    Private lijst As List(Of DAHelpfile)

    Public Sub New()
        MyBase.DABaseClass()
    End Sub

    Public Function getHelpfiles() As List(Of DAHelpfile)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("select name, categorie, id, path, document_type, description from tbl_help group by 2,1", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAHelpfile)

        While (dataReader.Read())
            Dim nextHelpFile As New DAHelpfile
            nextHelpFile.HelpfileID = (dataReader("id"))
            nextHelpFile.Name = dataReader("name").ToString()
            nextHelpFile.Categorie = dataReader("categorie").ToString()
            nextHelpFile.Path = dataReader("path").ToString()
            nextHelpFile.DocType = dataReader("document_type").ToString()
            nextHelpFile.Description = dataReader("description").ToString()
            lijst.Add(nextHelpFile)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Function getHelpfilesCategories() As List(Of DAHelpfile)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("select distinct categorie from tbl_help", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAHelpfile)

        While (dataReader.Read())
            Dim nextHelpFile As New DAHelpfile
            nextHelpFile.Categorie = dataReader("categorie").ToString()
            lijst.Add(nextHelpFile)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Function getHelpFilesByCategorie(ByVal categorie As String) As List(Of DAHelpfile)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("select * from tbl_help where categorie like '" & categorie & "'", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAHelpfile)

        While (dataReader.Read())
            Dim nextHelpFile As New DAHelpfile
            nextHelpFile.HelpfileID = (dataReader("id"))
            nextHelpFile.Name = dataReader("name").ToString()
            nextHelpFile.Categorie = dataReader("categorie").ToString()
            nextHelpFile.Path = dataReader("path").ToString()
            nextHelpFile.DocType = dataReader("document_type").ToString()
            nextHelpFile.Description = dataReader("description").ToString()
            lijst.Add(nextHelpFile)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Public Sub InsertHelpfile(ByVal helpfile As DAHelpfile)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("insert into tbl_help(path, document_type, name, description, categorie) values (@path, @Doctype, @Name, @Description, @Categorie)", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@path", helpfile.Path))
        command.Parameters.Add(New MySqlParameter("@Doctype", helpfile.DocType))
        command.Parameters.Add(New MySqlParameter("@Name", helpfile.Name))
        command.Parameters.Add(New MySqlParameter("@Description", helpfile.Description))
        command.Parameters.Add(New MySqlParameter("@Categorie", helpfile.Categorie))

        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Public Sub UpdateHelpFile(ByVal helpfile As DAHelpfile)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("update tbl_help set path = @path, document_type = @Doctype, name = @Name, description = @description, categorie = @categorie where id = @ID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@path", helpfile.Path))
        command.Parameters.Add(New MySqlParameter("@Doctype", helpfile.DocType))
        command.Parameters.Add(New MySqlParameter("@Name", helpfile.Name))
        command.Parameters.Add(New MySqlParameter("@Description", helpfile.Description))
        command.Parameters.Add(New MySqlParameter("@Categorie", helpfile.Categorie))
        command.Parameters.Add(New MySqlParameter("@ID", helpfile.HelpfileID))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Public Sub deleteHelpFile(ByVal id As Integer)
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("delete from tbl_help where id = @ID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@ID", id))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("RidleySoft")
    End Sub

    Private HelpfileID2 As Integer
    Private Path2 As String
    Private DocType2 As String
    Private Name2 As String
    Private Description2 As String
    Private Categorie2 As String

    Public Sub New(ByVal HelpfileID2 As Integer, ByVal Path2 As String, ByVal DocType2 As String, ByVal Name2 As String, ByVal Description2 As String, ByVal Categorie2 As String)
        Me.HelpfileID = HelpfileID2
        Me.Path = Path2
        Me.DocType = DocType2
        Me.Name = Name2
        Me.Description = Description2
        Me.Categorie = Categorie2
    End Sub


    Public Property HelpfileID() As Integer
        Get
            Return HelpfileID2
        End Get
        Set(value As Integer)
            HelpfileID2 = value
        End Set
    End Property

    Public Property Path() As String
        Get
            Return Path2
        End Get
        Set(value As String)
            Path2 = value
        End Set
    End Property

    Public Property DocType() As String
        Get
            Return DocType2
        End Get
        Set(value As String)
            DocType2 = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return Name2
        End Get
        Set(value As String)
            Name2 = value
        End Set
    End Property

    Public Property Description() As String
        Get
            Return Description2
        End Get
        Set(value As String)
            Description2 = value
        End Set
    End Property
    Public Property Categorie() As String
        Get
            Return Categorie2
        End Get
        Set(value As String)
            Categorie2 = value
        End Set
    End Property
End Class
