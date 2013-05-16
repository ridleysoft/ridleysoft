Imports MySql.Data.MySqlClient

Public Class DAMontage
    Inherits DABaseClass
    Private lijst As List(Of DAMontage)
    Private montage As DAMontage
    Public Sub New()
        MyBase.DABaseClass()
    End Sub
    Public Sub InsertMontage(ByVal montage As DAMontage)
        DBConnection.ConnectionOpen("Montage")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("insert into registration(mechanic, prb_no, provided_labor_time, starttime, montage_niveau) values (@mechanic, @prb_no, @provided_labor_time, @starttime, @montage_niveau)", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@mechanic", montage.Mechanic))
        command.Parameters.Add(New MySqlParameter("@prb_no", montage.Prb))
        command.Parameters.Add(New MySqlParameter("@provided_labor_time", montage.Provided))
        command.Parameters.Add(New MySqlParameter("@starttime", montage.Starttime))
        command.Parameters.Add(New MySqlParameter("@montage_niveau", montage.MontageNiveau))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("Montage")
    End Sub

    Public Sub UpdateMontage(ByVal montage As DAMontage)
        DBConnection.ConnectionOpen("Montage")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("update registration set stoptime = @stoptime, labor_time = @labor_time, unknown_labor_time = @unknown_labor_time, reason_id = @reason_id where id = @ID", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@ID", montage.ID))
        command.Parameters.Add(New MySqlParameter("@stoptime", montage.Stoptime))
        command.Parameters.Add(New MySqlParameter("@labor_time", montage.Labortime))
        command.Parameters.Add(New MySqlParameter("@unknown_labor_time", montage.UnknownLaborTime))
        command.Parameters.Add(New MySqlParameter("@reason_id", montage.ReasonID))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("Montage")
    End Sub

    Public Function getMontageByPRB(prb As String) As DAMontage
        DBConnection.ConnectionOpen("Montage")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("SELECT * from registration where prb_no = " & prb, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        dataReader.Read()
        Dim nextMontage As New DAMontage
        nextMontage.ID = dataReader("id")
        nextMontage.Mechanic = (dataReader("mechanic")).ToString()
        nextMontage.Prb = (dataReader("prb_no")).ToString()
        nextMontage.Provided = dataReader("provided_labor_time")
        nextMontage.Starttime = (dataReader("starttime"))
        nextMontage.Stoptime = dataReader("stoptime")
        nextMontage.Labortime = dataReader("labor_time")
        nextMontage.MontageNiveau = dataReader("montage_niveau").ToString()
        nextMontage.UnknownLaborTime = dataReader("unknown_labor_time")
        nextMontage.ReasonID = dataReader("reason_id").ToString()
        dataReader.Close()
        DBConnection.ConnectionClose("Montage")
        Return nextMontage
    End Function

    Public Function getMontageByMechanic(mechanic As String) As List(Of DAMontage)
        DBConnection.ConnectionOpen("Montage")
        ' DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("SELECT * from registration where mechanic = " & mechanic, DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        lijst = New List(Of DAMontage)

        While (dataReader.Read())
            Dim nextMontage As New DAMontage
            nextMontage.ID = dataReader("id")
            nextMontage.Mechanic = (dataReader("mechanic")).ToString()
            nextMontage.Prb = (dataReader("prb_no")).ToString()
            nextMontage.Provided = dataReader("provided_labor_time")
            nextMontage.Starttime = (dataReader("starttime"))
            If Not IsDBNull(dataReader("stoptime")) Then
                nextMontage.Stoptime = dataReader("stoptime")
            End If
            If Not IsDBNull(dataReader("labor_time")) Then
                nextMontage.Labortime = dataReader("labor_time")
            End If
            nextMontage.MontageNiveau = dataReader("montage_niveau").ToString()
            nextMontage.UnknownLaborTime = dataReader("unknown_labor_time")
            nextMontage.ReasonID = dataReader("reason_id").ToString()
            lijst.Add(nextMontage)
        End While
        dataReader.Close()
        DBConnection.ConnectionClose("Montage")
        Return lijst
    End Function

    Public Function getMontageByMechanicEmpty(mechanic As String) As DAMontage
        DBConnection.ConnectionOpen("Montage")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("SELECT * from registration where mechanic = '" & mechanic & "' and stoptime is null", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        Dim nextMontage As New DAMontage

        If dataReader.Read() Then
            nextMontage.ID = dataReader("id")
            nextMontage.Mechanic = (dataReader("mechanic")).ToString()
            nextMontage.Prb = (dataReader("prb_no")).ToString()
            nextMontage.Provided = dataReader("provided_labor_time")
            nextMontage.Starttime = (dataReader("starttime"))
            If Not IsDBNull(dataReader("stoptime")) Then
                nextMontage.Stoptime = dataReader("stoptime")
            End If
            If Not IsDBNull(dataReader("labor_time")) Then
                nextMontage.Labortime = dataReader("labor_time")
            End If
            nextMontage.MontageNiveau = dataReader("montage_niveau").ToString()
            nextMontage.UnknownLaborTime = dataReader("unknown_labor_time")
            nextMontage.ReasonID = dataReader("reason_id").ToString()
        End If
        dataReader.Close()
        DBConnection.ConnectionClose("Montage")
        Return nextMontage
    End Function

    Private ID2 As Integer
    Private mechanic2 As String
    Private prb2 As String
    Private provided2 As Integer
    Private startTime2 As DateTime
    Private pause2 As Integer
    Private stoptime2 As DateTime
    Private laborTime2 As Integer
    Private montageNiveau2 As String
    Private unknownLaborTime2 As Integer
    Private reasonID2 As Integer

    Public Sub New(ByVal ID2 As Integer, ByVal mechanic2 As String, ByVal prb2 As String, ByVal provided2 As Integer, ByVal startTime2 As DateTime, ByVal pause2 As Integer, ByVal stoptime2 As DateTime, ByVal laborTime2 As Integer, ByVal MontageNiveau2 As String, ByVal unknownLaborTime2 As Integer, ByVal reasonID2 As Integer)
        Me.ID = ID2
        Me.Mechanic = mechanic2
        Me.Prb = prb2
        Me.Provided = provided2
        Me.Starttime = startTime2
        Me.Pause = pause2
        Me.Stoptime = stoptime2
        Me.Labortime = laborTime2
        Me.MontageNiveau = MontageNiveau2
        Me.UnknownLaborTime = unknownLaborTime2
        Me.ReasonID = reasonID2
    End Sub

    Public Property ID() As Integer
        Get
            Return ID2
        End Get
        Set(value As Integer)
            ID2 = value
        End Set
    End Property

    Public Property Mechanic() As String
        Get
            Return mechanic2
        End Get
        Set(value As String)
            mechanic2 = value
        End Set
    End Property

    Public Property Prb() As String
        Get
            Return prb2
        End Get
        Set(value As String)
            prb2 = value
        End Set
    End Property

    Public Property Provided() As Integer
        Get
            Return provided2
        End Get
        Set(value As Integer)
            provided2 = value
        End Set
    End Property

    Public Property Starttime() As DateTime
        Get
            Return startTime2
        End Get
        Set(value As DateTime)
            startTime2 = value
        End Set
    End Property

    Public Property Pause() As Integer
        Get
            Return pause2
        End Get
        Set(value As Integer)
            pause2 = value
        End Set
    End Property

    Public Property Stoptime() As DateTime
        Get
            Return stoptime2
        End Get
        Set(value As DateTime)
            stoptime2 = value
        End Set
    End Property

    Public Property Labortime() As Integer
        Get
            Return laborTime2
        End Get
        Set(value As Integer)
            laborTime2 = value
        End Set
    End Property

    Public Property MontageNiveau() As String
        Get
            Return montageNiveau2
        End Get
        Set(value As String)
            montageNiveau2 = value
        End Set
    End Property

    Public Property UnknownLaborTime() As Integer
        Get
            Return unknownLaborTime2
        End Get
        Set(value As Integer)
            unknownLaborTime2 = value
        End Set
    End Property

    Public Property ReasonID() As Integer
        Get
            Return reasonID2
        End Get
        Set(value As Integer)
            reasonID2 = value
        End Set
    End Property
End Class
