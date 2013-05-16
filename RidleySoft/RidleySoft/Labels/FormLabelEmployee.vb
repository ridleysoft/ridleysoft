Public Class FormLabelEmployee

    Private Sub FormLabelEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Forms.FormBorderStyle.None
        Listboxvullen()

    End Sub

    Public Sub Listboxvullen()
        ListBoxUser.Width = 350
        'ListBoxUser.Dock = DockStyle.Left

        Dim daEmployee As DARFID = New DARFID()
        Dim employees As List(Of DARFID) = daEmployee.GetEmployees()

        ListBoxUser.DataSource = employees
        ListBoxUser.DisplayMember = "Name"
        ListBoxUser.ValueMember = "UserID"
    End Sub
End Class