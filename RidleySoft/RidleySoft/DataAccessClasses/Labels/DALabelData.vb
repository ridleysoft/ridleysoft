Imports MySql.Data.MySqlClient

Public Class DALabelData
    Inherits DABaseClass
    Private lijst As List(Of DALabelData)
    Private user As DALabel
    Public Sub New()
        MyBase.DABaseClass()
    End Sub

    Public Function getLabeldatabylabelID(ByVal labelID As Integer) As List(Of DALabelData)

        Dim sql As String = "select * from tbl_label_data ld where ld.label_id =" & labelID
        DBConnection.ConnectionOpen("RidleySoft")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand(sql, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DALabelData)

        While (dataReader.Read())
            Dim nextLabelData As New DALabelData
            nextLabelData.ID = (dataReader("id"))
            nextLabelData.LabelName = dataReader("label_name").ToString()
            nextLabelData.LabelID = (dataReader("label_id"))
            lijst.Add(nextLabelData)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("RidleySoft")
        Return lijst
    End Function

    Private ID2 As Integer
    Private LabelName2 As String
    Private LabelID2 As Integer

    Public Sub New(ByVal ID2 As Integer, ByVal LabelName2 As String, ByVal LabelID2 As Integer)
        Me.ID = ID2
        Me.LabelName = LabelName2
        Me.LabelID = LabelID2
    End Sub

    Public Property ID() As Integer
        Get
            Return ID2
        End Get
        Set(value As Integer)
            ID2 = value
        End Set
    End Property

    Public Property LabelName() As String
        Get
            Return LabelName2
        End Get
        Set(value As String)
            LabelName2 = value
        End Set
    End Property

    Public Property LabelID() As Integer
        Get
            Return LabelID2
        End Get
        Set(value As Integer)
            LabelID2 = value
        End Set
    End Property
End Class
