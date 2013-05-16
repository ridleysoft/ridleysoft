Imports MySql.Data.MySqlClient

Public Class DAMenuItemImage
    Inherits DABaseClass
    Private lijst As List(Of DAMenuItemImage)
    Public Sub New()
        MyBase.DABaseClass()
    End Sub

    Public Function getImageByModelDesign(ByVal model As String, ByVal design As String) As DAMenuItemImage
        DBConnection.ConnectionOpen("yii_tour")
        Dim command As MySqlCommand = New MySqlCommand("select * from tbl_images where model ='" & model & "' and design = '" & design & "'", DBconnectionMYSQL)
        Dim dataReader As MySqlDataReader = command.ExecuteReader()

        Dim nextItem As New DAMenuItemImage
        If dataReader.Read() Then
            nextItem.Model = (dataReader("model")).ToString()
            nextItem.Design = (dataReader("design")).ToString()
            nextItem.Image = (dataReader("image"))
        End If
        dataReader.Close()
        DBConnection.ConnectionClose("yii_tour")
        Return nextItem
    End Function

    Public Sub InsertItemMenu(ByVal Image As DAMenuItemImage)
        DBConnection.ConnectionOpen("yii_tour")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("insert into tbl_images(model, design, image) values (@model, @design, @image)", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@model", Image.Model))
        command.Parameters.Add(New MySqlParameter("@design", Image.Design))
        command.Parameters.Add(New MySqlParameter("@image", Image.Image))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("yii_tour")
    End Sub

    Public Sub DeleteImage(ByVal Image As DAMenuItemImage)
        DBConnection.ConnectionOpen("yii_tour")
        'DBconnectionMYSQL.Open()
        Dim command As MySqlCommand = New MySqlCommand("delete from tbl_images where model = @model and design = @design", DBconnectionMYSQL)
        command.Parameters.Add(New MySqlParameter("@model", Image.Model))
        command.Parameters.Add(New MySqlParameter("@design", Image.Design))
        command.ExecuteNonQuery()
        DBConnection.ConnectionClose("yii_tour")
    End Sub

    Private Model2 As String
    Private Design2 As String
    Private Image2 As String



    Public Sub New(ByVal Model2 As String, ByVal Design2 As String, ByVal Image2 As String)
        Me.Model = Model2
        Me.Design = Design2
        Me.Image = Image2

    End Sub

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

    Public Property Image() As String
        Get
            Return Image2
        End Get
        Set(value As String)
            Image2 = value
        End Set
    End Property
End Class
