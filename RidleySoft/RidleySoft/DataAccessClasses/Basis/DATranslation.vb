Imports MySql.Data.MySqlClient

Public Class DATranslation
    Inherits DABaseClass
    Private lijst As List(Of DATranslation)
    Public Sub New()
        MyBase.DABaseClass()
    End Sub

    Public Function getTranslations() As List(Of DATranslation)
        DBConnection.ConnectionOpen("Translations")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("SELECT * from tbl_translations where type_id = 5", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DATranslation)

        While (dataReader.Read())
            Dim nextTranslation As New DATranslation
            nextTranslation.TranslationID = (dataReader("translations_id"))
            nextTranslation.Name = dataReader("name").ToString()
            nextTranslation.Description = dataReader("description").ToString()
            nextTranslation.NLB = dataReader("NLB").ToString()
            nextTranslation.ENG = dataReader("ENG").ToString()
            nextTranslation.TypeID = dataReader("type_id").ToString()
            lijst.Add(nextTranslation)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("Translations")
        Return lijst
    End Function

    Private translationID2 As Integer
    Private name2 As String
    Private description2 As String
    Private NLB2 As String
    Private ENG2 As String
    Private typeID2 As Integer

    Public Sub New(ByVal translationID2 As Integer, ByVal name2 As String, ByVal description2 As String, ByVal NLB2 As String, ByVal ENG2 As String, ByVal typeID2 As Integer)
        Me.TranslationID = translationID2
        Me.Name = name2
        Me.Description = description2
        Me.NLB = NLB2
        Me.ENG = ENG2
        Me.typeID = typeID2
    End Sub

    Public Property TranslationID() As Integer
        Get
            Return translationID2
        End Get
        Set(value As Integer)
            translationID2 = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return name2
        End Get
        Set(value As String)
            name2 = value
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

    Public Property NLB() As String
        Get
            Return NLB2
        End Get
        Set(value As String)
            NLB2 = value
        End Set
    End Property

    Public Property ENG() As String
        Get
            Return ENG2
        End Get
        Set(value As String)
            ENG2 = value
        End Set
    End Property

    Public Property TypeID() As Integer
        Get
            Return typeID2
        End Get
        Set(value As Integer)
            typeID2 = value
        End Set
    End Property
End Class
