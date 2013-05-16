Public Class GeluktNietGelukt
    Private Itemnr2 As String
    Private ItemName2 As String
    Private Status2 As String
    Private type2 As String
    Private reden2 As String


    Public Sub New(ByVal Itemnr2 As String, ByVal ItemName2 As String, ByVal Status2 As String, ByVal type2 As String, ByVal reden2 As String)
        Me.Itemnr = Itemnr2
        Me.ItemName = ItemName2
        Me.Status = Status2
        Me.Type = type2
        Me.Reden = reden2
    End Sub
    Public Property Itemnr() As String
        Get
            Return Itemnr2
        End Get
        Set(value As String)
            Itemnr2 = value
        End Set
    End Property

    Public Property ItemName() As String
        Get
            Return ItemName2
        End Get
        Set(value As String)
            ItemName2 = value
        End Set
    End Property

    Public Property Status() As String
        Get
            Return Status2
        End Get
        Set(value As String)
            Status2 = value
        End Set
    End Property

    Public Property Type() As String
        Get
            Return type2
        End Get
        Set(value As String)
            type2 = value
        End Set
    End Property

    Public Property Reden() As String
        Get
            Return reden2
        End Get
        Set(value As String)
            reden2 = value
        End Set
    End Property
End Class
