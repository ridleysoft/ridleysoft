Imports System.Reflection
Imports System.Windows.Forms

Public Class FormUserRights

    Private _dataset As DataSet
    Private _dataset2 As DataSet
    Private _index As Integer
    Private intComboUserID As Integer

    Private Sub FormUserRights_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler MainForm.menuitemSearch.Click, AddressOf searchKlik
        AddHandler MainForm.menuitemFilter.Click, AddressOf filterKlik
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        _index = 0
        Comboboxvullen()
        Listboxvullen()
        Translate.LoadLanguage(Me)
        Mainform.frmOudeForm.Name = "FormUserRights"
        MainForm.FrmOpenForm = Me

        AddHandler MainForm.menuitemToevoegen.Click, AddressOf ToevoegenKlik
        For Each frm As Form In My.Application.OpenForms
            If frm IsNot Me Then
                frm.BackColor = Nothing
            End If
        Next
        Me.BackColor = Color.Lavender
    End Sub

    Private Sub filterKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "FormUserRights" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "FormUserRights"
        End If
        If Mainform.frmOudeForm.Name = "FormUserRights" Or Mainform.frmOudeForm.Name = "" Then
            FilterUser.TopLevel = True
            FilterUser.Show()
            Mainform.frmNieuwForm.Name = "FormUserRights"
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Private Sub searchKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "FormUserRights" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "FormUserRights"
        End If
        If Mainform.frmOudeForm.Name = "FormUserRights" Or Mainform.frmOudeForm.Name = "" Then
            SearchForm.TopLevel = True
            SearchForm.Show()
            Mainform.frmNieuwForm.Name = "FormUserRights"
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Private Function GetDataSetConventional(ByVal list As List(Of DARights)) As DataSet
        Dim _result As New DataSet()
        _result.Tables.Add("rights")
        _result.Tables("rights").Columns.Add("RightID")
        _result.Tables("rights").Columns.Add("Description")

        For Each item As DARights In list
            Dim newRow As DataRow = _
                _result.Tables("rights").NewRow()
            newRow("RightID") = item.RightID
            newRow("Description") = item.Description
            _result.Tables("rights").Rows.Add(newRow)
        Next
        Return _result
    End Function

    Public Sub UserEnModuleLink()
        Dim daUser As DAUser = New DAUser()

        intComboUserID = ComboBoxUser.SelectedValue

        Dim daRights As DARights = New DARights()
        Dim userRightsNietgelinkt As List(Of DARights) = daRights.getRightsNotLinked(intComboUserID)
        Dim userRightsWelgelinkt As List(Of DARights) = daRights.getRightsByID(intComboUserID)

        ListBoxNietGelinkt.DataSource = userRightsNietgelinkt
        ListBoxNietGelinkt.DisplayMember = "description"
        ListBoxNietGelinkt.ValueMember = "RightID"

        ListBoxWelGelinkt.DataSource = userRightsWelgelinkt
        ListBoxWelGelinkt.DisplayMember = "Description"
        ListBoxWelGelinkt.ValueMember = "RightID"
    End Sub

    Public Sub Listboxvullen()
        ListBoxUser.Width = 350
        ListBoxUser.Dock = DockStyle.Left
        Dim daUser As DAUser = New DAUser()
        Dim users As List(Of DAUser) = daUser.GetUsers()

        Dim daModules As DAModule = New DAModule()
        Dim modules As List(Of DAModule) = daModules.getModules()

        ListBoxUser.DataSource = users
        ListBoxUser.DisplayMember = "UserName"
        ListBoxUser.ValueMember = "UserID"
    End Sub

    Public Sub Comboboxvullen()
        Dim daUser As DAUser = New DAUser()
        Dim users As List(Of DAUser) = daUser.GetUsers()

        Dim daModules As DAModule = New DAModule()
        Dim modules As List(Of DAModule) = daModules.getModules()

        ComboBoxUser.DataSource = users
        ComboBoxUser.DisplayMember = "UserName"
        ComboBoxUser.ValueMember = "UserID"

        UserEnModuleLink()
    End Sub

    Public Shared Function ConvertToDataTable(Of T)(ByVal list As IList(Of T)) As DataTable
        Dim table As New DataTable()
        Dim fields() As FieldInfo = GetType(T).GetFields()
        For Each field As FieldInfo In fields
            table.Columns.Add(field.Name, field.FieldType)
        Next
        For Each item As T In list
            Dim row As DataRow = table.NewRow()
            For Each field As FieldInfo In fields
                row(field.Name) = field.GetValue(item)
            Next
            table.Rows.Add(row)
        Next
        Return table
    End Function

    Private Sub ToevoegenKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "FormUserRights" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "FormUserRights"
        End If
        If Mainform.frmOudeForm.Name = "FormUserRights" Or Mainform.frmOudeForm.Name = "" Then
            Mainform.frmNieuwForm.Name = "FormUserRights"
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Private Sub ComboBoxUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxUser.SelectedIndexChanged
        If (intComboUserID <> 0) Then
            intComboUserID = ComboBoxUser.SelectedValue
            UserEnModuleLink()
        End If
    End Sub

    Private Sub ButtonRechts_Click(sender As Object, e As EventArgs) Handles ButtonRechts.Click

        Dim daUserRights As DAUserRights = New DAUserRights()
        Dim userRights As List(Of DAUserRights) = daUserRights.getUserRights()
        intComboUserID = ComboBoxUser.SelectedValue
        'MessageBox.Show(intComboUserID.ToString())
        Dim daUserRight As DAUserRights = New DAUserRights()
        Dim userRight As DAUserRights = New DAUserRights(intComboUserID, ListBoxNietGelinkt.SelectedValue)
        daUserRights.InsertUserRights(userRight)
        UserEnModuleLink()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonAllemaalRechts.Click

        Dim daRights As DARights = New DARights()
        intComboUserID = ComboBoxUser.SelectedValue
        Dim userRightsNietgelinkt As List(Of DARights) = daRights.getRightsNotLinked(intComboUserID)
        Dim daUserRight As DAUserRights = New DAUserRights()

        For Each item In userRightsNietgelinkt
            Dim userRight As DAUserRights = New DAUserRights(intComboUserID, item.RightID)
            daUserRight.InsertUserRights(userRight)
        Next
        UserEnModuleLink()
    End Sub

    Private Sub ButtonLinks_Click(sender As Object, e As EventArgs) Handles ButtonLinks.Click
        Dim daUserRight As DAUserRights = New DAUserRights()
        intComboUserID = ComboBoxUser.SelectedValue
        daUserRight.deleteUserRight(intComboUserID, ListBoxWelGelinkt.SelectedValue)
        UserEnModuleLink()
    End Sub

    Private Sub ButtonAllemaalLinks_Click(sender As Object, e As EventArgs) Handles ButtonAllemaalLinks.Click
        Dim daUserRight As DAUserRights = New DAUserRights()
        daUserRight.deleteUserRight(intComboUserID, ListBoxWelGelinkt.SelectedValue)
        intComboUserID = ComboBoxUser.SelectedValue
        Dim daRights As DARights = New DARights()
        Dim userRightsWelgelinkt As List(Of DARights) = daRights.getRightsByID(intComboUserID)

        For Each item In userRightsWelgelinkt
            daUserRight.deleteUserRight(intComboUserID, item.RightID)
        Next
        UserEnModuleLink()
    End Sub

    Private Sub FormUsersModules_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        Mainform.frmOudeForm.Name = "FormUserRights"
        For Each frm As Form In My.Application.OpenForms
            If frm IsNot Me Then
                frm.BackColor = Nothing
            End If
        Next
        Me.BackColor = Color.Lavender
        Listboxvullen()
        controlLayout()
    End Sub


    Private Sub ListBoxUser_SelectedValueChanged(sender As Object, e As EventArgs) Handles ListBoxUser.SelectedValueChanged
        ComboBoxUser.SelectedValue = ListBoxUser.SelectedValue
        UserEnModuleLink()
    End Sub

    Private Sub Splitter1_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles Splitter1.SplitterMoved
        controlLayout()
    End Sub

    Public Sub controlLayout()
        Dim width As Integer = ListBoxUser.Width
        LabelUser.Location = New Point(width + 50, LabelUser.Location.Y)
        LabelRights.Location = New Point(width + 50, LabelRights.Location.Y)
        ComboBoxUser.Location = New Point((width + LabelUser.Width) + 70, ComboBoxUser.Location.Y)
        ListBoxNietGelinkt.Location = New Point((ComboBoxUser.Location.X), ListBoxNietGelinkt.Location.Y)
        ButtonLinks.Location = New Point((ListBoxNietGelinkt.Location.X + ListBoxNietGelinkt.Width + 20), ButtonLinks.Location.Y)
        ButtonAllemaalLinks.Location = New Point((ListBoxNietGelinkt.Location.X + ListBoxNietGelinkt.Width + 20), ButtonAllemaalLinks.Location.Y)
        ButtonRechts.Location = New Point((ListBoxNietGelinkt.Location.X + ListBoxNietGelinkt.Width + 20), ButtonRechts.Location.Y)
        ButtonAllemaalRechts.Location = New Point((ListBoxNietGelinkt.Location.X + ListBoxNietGelinkt.Width + 20), ButtonAllemaalRechts.Location.Y)
        ListBoxWelGelinkt.Location = New Point((ListBoxNietGelinkt.Location.X + ListBoxNietGelinkt.Width + ButtonLinks.Width + 40), ListBoxWelGelinkt.Location.Y)
    End Sub
End Class