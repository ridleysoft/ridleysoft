Imports System.Data.SqlClient

Public Class DAPrb
    Inherits DABaseClass
    Private lijst As List(Of DAPrb)
    Private user As DAPrb
    Public Sub New()
        MyBase.DABaseClass()
    End Sub
    Public Function GetPRBInfo(ByVal PRBScan As String) As DAPrb
        DBConnection.ConnectionOpen("NAVDB")
        Dim sql As String = "select A.No_, ISNULL(B.[Item No_], A.[Source No_]) as item, B.Value as provided, C.Value as model, D.Value as design, ISNULL(E.[Montage Niveau], '2011') as montage_niveau from dbo.[Race Productions$Production Order] A left outer join dbo.[Race Productions$Item Characteristics] B on B.[Item No_] = A.[Source No_] and B.Code = 'LTI' left outer join dbo.[Race Productions$Item Characteristics] C on C.[Item No_] = A.[Source No_] and C.Code = 'MOD' left outer join dbo.[Race Productions$Item Characteristics] D on D.[Item No_] = A.[Source No_] and D.Code = 'DES' left outer join dbo.[Race Productions$Sales Line] E on E.[Document No_] = A.[Sales Order No_] and E.[Line No_] = A.[Sales Order Line No_] where A.[No_] = '" & PRBScan & "'"

        Dim command As SqlCommand = New SqlCommand(sql, DBConnectionSQL)
        Dim dataReader As SqlDataReader = command.ExecuteReader()

        Dim nextPRB As New DAPrb
        If dataReader.Read() Then
            nextPRB.PrbID = (dataReader("No_"))
            nextPRB.Item = (dataReader("item")).ToString()
            If Not IsDBNull(dataReader("provided")) Then
                nextPRB.Provided = dataReader("provided")
            Else
                nextPRB.Provided = 30
            End If

            nextPRB.Model = dataReader("model").ToString()
            nextPRB.Design = dataReader("design").ToString()
            nextPRB.MontageNiveau = dataReader("montage_niveau").ToString()
        End If
        dataReader.Close()
        DBConnection.ConnectionClose("NAVDB")
        Return nextPRB
    End Function

    Private PrbID2 As String
    Private Item2 As String
    Private Provided2 As Integer
    Private Model2 As String
    Private Design2 As String
    Private MontageNiveau2 As String

    Public Sub New(ByVal PrbID2 As String, ByVal Item2 As String, ByVal Provided2 As Integer, ByVal Model2 As String, ByVal Design2 As String, ByVal MontageNiveau2 As String)
        Me.PrbID = PrbID2
        Me.Item = Item2
        Me.Provided = Provided2
        Me.Model = Model2
        Me.Design = Design2
        Me.MontageNiveau = MontageNiveau2
    End Sub

    Public Property PrbID() As String
        Get
            Return PrbID2
        End Get
        Set(value As String)
            PrbID2 = value
        End Set
    End Property

    Public Property Item() As String
        Get
            Return Item2
        End Get
        Set(value As String)
            Item2 = value
        End Set
    End Property

    Public Property Provided() As Integer
        Get
            Return Provided2
        End Get
        Set(value As Integer)
            Provided2 = value
        End Set
    End Property

    Public Property Model() As String
        Get
            Return Model2
        End Get
        Set(value As String)
            Model2 = value
        End Set
    End Property

    Public Property Design() As String
        Get
            Return Design2
        End Get
        Set(value As String)
            Design2 = value
        End Set
    End Property

    Public Property MontageNiveau() As String
        Get
            Return MontageNiveau2
        End Get
        Set(value As String)
            MontageNiveau2 = value
        End Set
    End Property
End Class
