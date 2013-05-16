Imports System.Reflection
Imports System.Windows.Forms

Public Class FormUsersModules
    Private _dataset As DataSet
    Private _dataset2 As DataSet
    Private _index As Integer
    Private intComboUserID As Integer
    Private Sub FormUsersModules_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler MainForm.menuitemFilter.Click, AddressOf filterKlik
        AddHandler MainForm.menuitemSearch.Click, AddressOf searchKlik
        _index = 0
        Comboboxvullen()
        Listboxvullen()
        Translate.LoadLanguage(Me)
        Mainform.frmOudeForm.Name = "FormUsersModules"
        MainForm.FrmOpenForm = Me
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None

        AddHandler MainForm.menuitemToevoegen.Click, AddressOf ToevoegenKlik
        For Each frm As Form In My.Application.OpenForms
            If frm IsNot Me Then
                frm.BackColor = Nothing
            End If
        Next
        Me.BackColor = Color.Lavender
    End Sub

    Private Sub filterKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "FormUsersModules" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "FormUsersModules"
        End If
        If Mainform.frmOudeForm.Name = "FormUsersModules" Or Mainform.frmOudeForm.Name = "" Then
            FilterUser.TopLevel = True
            FilterUser.Show()
            Mainform.frmNieuwForm.Name = "FormUsersModules"
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Private Sub searchKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "FormUsersModules" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "FormUsersModules"
        End If
        If Mainform.frmOudeForm.Name = "FormUsersModules" Or Mainform.frmOudeForm.Name = "" Then
            SearchForm.TopLevel = True
            SearchForm.Show()
            Mainform.frmNieuwForm.Name = "FormUsersModules"
        Else
            Mainform.frmOudeForm.Close()
        End If
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

    Private Function GetDataSetConventional(ByVal list As List(Of DAModule)) As DataSet
        Dim _result As New DataSet()
        _result.Tables.Add("modules")
        _result.Tables("modules").Columns.Add("ModuleID")
        _result.Tables("modules").Columns.Add("Modulename")
        _result.Tables("modules").Columns.Add("GroupID")

        For Each item As DAModule In list
            Dim newRow As DataRow = _
                _result.Tables("modules").NewRow()
            newRow("ModuleID") = item.ModuleID
            newRow("Modulename") = item.Description
            newRow("GroupID") = item.GroupID
            _result.Tables("modules").Rows.Add(newRow)
        Next
        Return _result
    End Function

    Public Sub UserEnModuleLink()
        intComboUserID = ComboBoxUser.SelectedIndex + 1
        Dim userModule As DAUserModule = New DAUserModule()

        Dim daModules As DAModule = New DAModule()
        intComboUserID = ComboBoxUser.SelectedValue
        Dim userModulesNietgelinkt As List(Of DAModule) = daModules.getUserModulesNietGelinkt(intComboUserID)
        Dim userModulesWelgelinkt As List(Of DAModule) = daModules.getModulesByID(intComboUserID)

        ListBoxNietGelinkt.DataSource = userModulesNietgelinkt
        ListBoxNietGelinkt.DisplayMember = "description"
        ListBoxNietGelinkt.ValueMember = "ModuleID"



        ListBoxWelGelinkt.DataSource = userModulesWelgelinkt
        ListBoxWelGelinkt.DisplayMember = "Description"
        ListBoxWelGelinkt.ValueMember = "ModuleID"

        'For i As Integer = 0 To CheckedListBoxModules.Items.Count - 1
        'CheckedListBoxModules.SetItemChecked(i, False)
        ' Next

        'For Each item In userModules
        'CheckedListBoxModules.SetItemCheckState(item.ModuleID - 1, CheckState.Checked)
        'Next
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

        'For Each item In CheckedListBoxModules.SelectedItems
        '    MessageBox.Show(CheckedListBoxModules.SelectedValue)
        'Next
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
        If Mainform.frmOudeForm.Name <> "FormUsersModules" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "FormUsersModules"
        End If
        If Mainform.frmOudeForm.Name = "FormUsersModules" Or Mainform.frmOudeForm.Name = "" Then
            Mainform.frmNieuwForm.Name = "FormUsersModules"
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

    Private Sub CheckedListBoxModules_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonWijzigen_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonRechts_Click(sender As Object, e As EventArgs) Handles ButtonRechts.Click
        Dim daUserModules As DAUserModule = New DAUserModule()
        Dim userModules As List(Of DAUserModule) = daUserModules.getUserModules()
        intComboUserID = ComboBoxUser.SelectedValue
        Dim daUserModule As DAUserModule = New DAUserModule()
        Dim userModule As DAUserModule = New DAUserModule(intComboUserID, ListBoxNietGelinkt.SelectedValue)

        daUserModule.InsertUserModule(userModule)
        UserEnModuleLink()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonAllemaalRechts.Click

        Dim daModules As DAModule = New DAModule()
        intComboUserID = ComboBoxUser.SelectedValue
        Dim userModulesNietgelinkt As List(Of DAModule) = daModules.getUserModulesNietGelinkt(intComboUserID)
        Dim daUserModule As DAUserModule = New DAUserModule()

        For Each item In userModulesNietgelinkt
            Dim userModule As DAUserModule = New DAUserModule(intComboUserID, item.ModuleID)
            daUserModule.InsertUserModule(userModule)
        Next
        UserEnModuleLink()
    End Sub


    Private Sub ButtonLinks_Click(sender As Object, e As EventArgs) Handles ButtonLinks.Click
        Dim daUserModule As DAUserModule = New DAUserModule()
        intComboUserID = ComboBoxUser.SelectedValue
        daUserModule.deleteUserModule(intComboUserID, ListBoxWelGelinkt.SelectedValue)
        UserEnModuleLink()
    End Sub

    Private Sub ButtonAllemaalLinks_Click(sender As Object, e As EventArgs) Handles ButtonAllemaalLinks.Click
        Dim daUserModule As DAUserModule = New DAUserModule()
        daUserModule.deleteUserModule(intComboUserID, ListBoxWelGelinkt.SelectedValue)
        intComboUserID = ComboBoxUser.SelectedValue
        Dim daModules As DAModule = New DAModule()
        Dim userModulesWelgelinkt As List(Of DAModule) = daModules.getModulesByID(intComboUserID)

        For Each item In userModulesWelgelinkt
            daUserModule.deleteUserModule(intComboUserID, item.ModuleID)
        Next
        UserEnModuleLink()
    End Sub

    Private Sub FormUsersModules_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        Mainform.frmOudeForm.Name = "FormUsersModules"
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
        LabelModule.Location = New Point(width + 50, LabelModule.Location.Y)
        ComboBoxUser.Location = New Point((width + LabelUser.Width) + 70, ComboBoxUser.Location.Y)
        ListBoxNietGelinkt.Location = New Point((ComboBoxUser.Location.X), ListBoxNietGelinkt.Location.Y)
        ButtonLinks.Location = New Point((ListBoxNietGelinkt.Location.X + ListBoxNietGelinkt.Width + 20), ButtonLinks.Location.Y)
        ButtonAllemaalLinks.Location = New Point((ListBoxNietGelinkt.Location.X + ListBoxNietGelinkt.Width + 20), ButtonAllemaalLinks.Location.Y)
        ButtonRechts.Location = New Point((ListBoxNietGelinkt.Location.X + ListBoxNietGelinkt.Width + 20), ButtonRechts.Location.Y)
        ButtonAllemaalRechts.Location = New Point((ListBoxNietGelinkt.Location.X + ListBoxNietGelinkt.Width + 20), ButtonAllemaalRechts.Location.Y)
        ListBoxWelGelinkt.Location = New Point((ListBoxNietGelinkt.Location.X + ListBoxNietGelinkt.Width + ButtonLinks.Width + 40), ListBoxWelGelinkt.Location.Y)
    End Sub
End Class