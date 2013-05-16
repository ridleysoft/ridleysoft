Imports System.Data.SqlClient

Public Class DARFID
    Inherits DABaseClass
    Private lijst As List(Of DARFID)
    Private user As DARFID
    Public Sub New()
        MyBase.DABaseClass()
    End Sub
    Public Function GetUsers(ByVal RFIDScan As String) As DARFID
        DBConnection.ConnectionOpen("NAVDB")
        Dim sql As String = "select * from dbo.[Race Productions$Employee] where RFID = '" & RFIDScan & "'"
        'DBConnectionSQL.Open()
        Dim command As SqlCommand = New SqlCommand(sql, DBConnectionSQL)
        Dim dataReader As SqlDataReader = command.ExecuteReader()

        Dim nextUser As New DARFID
        If dataReader.Read() Then
            nextUser.UserID = (dataReader("No_"))
            nextUser.FirstName = (dataReader("First Name")).ToString()
            nextUser.LastName = dataReader("Last Name").ToString()
            nextUser.RFID = dataReader("RFID").ToString()
        End If
        dataReader.Close()
        DBConnection.ConnectionClose("NAVDB")
        Return nextuser
    End Function

    Public Function GetEmployees() As List(Of DARFID)
        DBConnection.ConnectionOpen("NAVDB")
        ' DBconnectionMYSQL.Open()
        Dim command As SqlCommand = New SqlCommand("select No_, ([First Name] + ' ' + [Last Name]) as 'Name', RFID from dbo.[Race Productions$Employee]", DBConnectionSQL)
        Dim dataReader As SqlDataReader = command.ExecuteReader()

        lijst = New List(Of DARFID)

        While (dataReader.Read())
            Dim nextMontage As New DARFID
            nextMontage.UserID = (dataReader("No_"))
            nextMontage.Name = (dataReader("Name")).ToString()
            nextMontage.RFID = dataReader("RFID").ToString()
            lijst.Add(nextMontage)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("NAVDB")
        Return lijst
    End Function

    Private UserID2 As String
    Private FirstName2 As String
    Private LastName2 As String
    Private RFID2 As String
    Private Name2 As String

    Public Sub New(ByVal UserID2 As String, ByVal FirstName2 As String, ByVal LastName2 As String, ByVal RFID2 As String, ByVal Name2 As String)
        Me.UserID = UserID2
        Me.FirstName = FirstName2
        Me.LastName = LastName2
        Me.RFID = RFID2
        Me.Name = Name2
    End Sub

    Public Property UserID() As String
        Get
            Return UserID2
        End Get
        Set(value As String)
            UserID2 = value
        End Set
    End Property

    Public Property FirstName() As String
        Get
            Return FirstName2
        End Get
        Set(value As String)
            FirstName2 = value
        End Set
    End Property

    Public Property LastName() As String
        Get
            Return LastName2
        End Get
        Set(value As String)
            LastName2 = value
        End Set
    End Property

    Public Property RFID() As String
        Get
            Return RFID2
        End Get
        Set(value As String)
            RFID2 = value
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
End Class
