Imports System.Reflection
Imports System.Windows.Forms

Public Class AdminFormUser
    Private _dataset As DataSet
    Private _dataset2 As DataSet
    Private _index As Integer
    Private borderColor As Color = Color.Green 'Border Color
    Public strUser As String

    Private Sub AdminFormUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _index = 0
        If MainForm.BlnFilter = False Then
            ToonUser(_index)
        Else
            ToonUser2(_index)
        End If
        Listboxvullen()
        Mainform.frmOudeForm.Name = "UserToevoegen"
        Mainform.frmverwijderForm.Name = "AdminFormUser"
        MainForm.FrmOpenForm = Me
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Translate.LoadLanguage(Me)
        AddHandler MainForm.menuitemEerste.Click, AddressOf EersteKlik
        AddHandler MainForm.menuitemVorige.Click, AddressOf VorigeKlik
        AddHandler MainForm.menuitemVolgende.Click, AddressOf VolgendeKlik
        AddHandler MainForm.menuitemLaatste.Click, AddressOf LaatsteKlik
        AddHandler MainForm.menuitemToevoegen.Click, AddressOf ToevoegenKlik
        AddHandler MainForm.menuitemVerwijderen.Click, AddressOf VerwijderenKlik
        AddHandler MainForm.menuitemSearch.Click, AddressOf searchKlik
        AddHandler MainForm.menuitemFilter.Click, AddressOf filterKlik
        For Each frm As Form In My.Application.OpenForms
            If frm IsNot Me Then
                frm.BackColor = Nothing
            End If
        Next
        Me.BackColor = Color.Lavender
    End Sub

    Private Sub filterKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "UserToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "UserToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "UserToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            FilterUser.TopLevel = True
            FilterUser.Show()
            Mainform.frmNieuwForm.Name = "UserToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Private Sub searchKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "UserToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "UserToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "UserToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            SearchForm.TopLevel = True
            SearchForm.Show()
            Mainform.frmNieuwForm.Name = "UserToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Private Function GetDataSetConventional(ByVal list As List(Of DAUser)) As DataSet
        Dim _result As New DataSet()
        _result.Tables.Add("users")
        _result.Tables("users").Columns.Add("UserID")
        _result.Tables("users").Columns.Add("Username")
        _result.Tables("users").Columns.Add("Password")

        For Each item As DAUser In list
            Dim newRow As DataRow = _
                _result.Tables("users").NewRow()
            newRow("UserID") = item.UserID
            newRow("Username") = item.Username
            newRow("Password") = item.Password
            _result.Tables("users").Rows.Add(newRow)
        Next
        Return _result
    End Function

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

    Public Sub ToonUser(ByVal i As Integer)
        Dim daUsers As DAUser = New DAUser()
        Dim users As List(Of DAUser) = daUsers.GetUsers()

        _dataset = GetDataSetConventional(users)

        If (_dataset.Tables("users").Rows(i).RowState <> DataRowState.Deleted) Then
            TextBoxUsername.Text = _dataset.Tables("users").Rows(i).Field(Of String)("Username")
            TextBoxPassword1.Text = _dataset.Tables("users").Rows(i).Field(Of String)("Password")
            TextBoxUsername.Tag = _dataset.Tables("users").Rows(i).Field(Of String)("UserID")
        Else
            TextBoxUsername.Text = "###"
        End If
    End Sub

    Public Sub ToonUser2(ByVal i As Integer)
        Dim daUsers As DAUser = New DAUser()
        Dim users As List(Of DAUser) = daUsers.GetUsersByFilter(strUser)

        _dataset = GetDataSetConventional(users)
        If i <> 0 Then
            If (_dataset.Tables("users").Rows(i).RowState <> DataRowState.Deleted) Then
                TextBoxUsername.Text = _dataset.Tables("users").Rows(i).Field(Of String)("Username")
                TextBoxPassword1.Text = _dataset.Tables("users").Rows(i).Field(Of String)("Password")
                TextBoxUsername.Tag = _dataset.Tables("users").Rows(i).Field(Of String)("UserID")
            Else
                TextBoxUsername.Text = "###"
            End If
        Else
            TextBoxUsername.Text = ""
            TextBoxPassword1.Text = ""
        End If

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

    Private Sub EersteKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "UserToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "UserToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "UserToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            _index = 0
            If Mainform.BlnFilter = False Then
                ToonUser(_index)
            Else
                ToonUser2(_index)
            End If
            Mainform.frmNieuwForm.Name = "UserToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If

    End Sub

    Private Sub VorigeKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "UserToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "UserToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "UserToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            If (_index > 0) Then
                _index -= 1
                If Mainform.BlnFilter = False Then
                    ToonUser(_index)
                Else
                    ToonUser2(_index)
                End If
            End If
            Mainform.frmNieuwForm.Name = "UserToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If

    End Sub

    Private Sub VolgendeKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "UserToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "UserToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "UserToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            If (_index < _dataset.Tables("users").Rows.Count - 1) Then
                _index += 1
                If Mainform.BlnFilter = False Then
                    ToonUser(_index)
                Else
                    ToonUser2(_index)
                End If
            End If
            Mainform.frmNieuwForm.Name = "UserToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If

    End Sub

    Private Sub LaatsteKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "UserToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "UserToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "UserToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            _index = _dataset.Tables("users").Rows.Count - 1
            If Mainform.BlnFilter = False Then
                ToonUser(_index)
            Else
                ToonUser2(_index)
            End If
            Mainform.frmNieuwForm.Name = "UserToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If

    End Sub

    Private Sub ToevoegenKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "UserToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "UserToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "UserToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            UserToevoegen.TopLevel = True
            UserToevoegen.Show()
            Mainform.frmNieuwForm.Name = "UserToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If
        Listboxvullen()
    End Sub

    Private Sub ButtonWijzigen_Click(sender As Object, e As EventArgs) Handles ButtonWijzigen.Click
        If Mainform.frmOudeForm.Name <> "UserToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "UserToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "UserToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            Dim daUser As DAUser = New DAUser()
            Dim user As DAUser = New DAUser(TextBoxUsername.Tag, TextBoxUsername.Text, TextBoxPassword1.Text, 0)

            daUser.UpdateUser(user)
            Mainform.frmNieuwForm.Name = "UserToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If

        Listboxvullen()
    End Sub

    Private Sub VerwijderenKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim strYes As String
        Dim strCaption As String
        Dim strTitle As String
        strCaption = "Bent u zeker dat u dit item wilt verwijderen?"
        strTitle = "Waarschuwing"

        If MainForm.frmverwijderForm.Name <> "AdminFormUser" And MainForm.frmverwijderForm.Name <> MainForm.frmNieuweverwijderForm.Name Then
            MainForm.frmNieuweverwijderForm.Name = "AdminFormUser"
        End If
        If MainForm.frmverwijderForm.Name = "AdminFormUser" Or MainForm.frmverwijderForm.Name = "" Then
            strYes = MessageBox.Show(strCaption, strTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If strYes = DialogResult.Yes Then
                If MainForm.frmverwijderForm.Name <> "AdminFormUser" And MainForm.frmverwijderForm.Name <> MainForm.frmNieuweverwijderForm.Name Then
                    MainForm.frmNieuweverwijderForm.Name = "AdminFormUser"
                End If
                If MainForm.frmverwijderForm.Name = "AdminFormUser" Or MainForm.frmverwijderForm.Name = "" Then
                    Dim daUser As DAUser = New DAUser()
                    daUser.deleteUser(TextBoxUsername.Tag)
                    daUser.deleteRights(TextBoxUsername.Tag)
                    daUser.deleteUserModules(TextBoxUsername.Tag)
                    daUser.deleteSettings(TextBoxUsername.Tag)
                    If (_index > 0) Then
                        _index -= 1
                        If MainForm.BlnFilter = False Then
                            ToonUser(_index)
                        Else
                            ToonUser2(_index)
                        End If
                    Else
                        TextBoxUsername.Text = Nothing
                        TextBoxPassword1.Text = Nothing
                    End If
                    MainForm.frmNieuweverwijderForm.Name = "AdminFormUser"
                Else
                    MainForm.frmOudeForm.Close()
                End If
            End If
            If MainForm.BlnFilter = False Then
                ToonUser(_index)
            Else
                ToonUser2(_index)
            End If
            MainForm.frmNieuwForm.Name = "UserToevoegen"
        Else
            MainForm.frmverwijderForm.Close()
        End If

        Dim daTranslations As DATranslation = New DATranslation()
        Dim translations As List(Of DATranslation) = daTranslations.getTranslations()

        If (MainForm.strLanguage = "ENG") Then
            For Each translation In translations
                If strCaption = translation.NLB Then
                    strCaption = translation.ENG
                ElseIf strTitle = translation.NLB Then
                    strTitle = translation.ENG
                End If
            Next
        ElseIf (MainForm.strLanguage = "NLB") Then
            For Each translation In translations
                If strCaption = translation.ENG Then
                    strCaption = translation.NLB
                ElseIf strTitle = translation.ENG Then
                    strTitle = translation.NLB
                End If
            Next
        End If

        Listboxvullen()
    End Sub

    Private Sub AdminFormUser_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        Mainform.frmOudeForm.Name = "UserToevoegen"
        For Each frm As Form In My.Application.OpenForms
            If frm IsNot Me Then
                frm.BackColor = Nothing
            End If
        Next
        Me.BackColor = Color.Lavender
        Mainform.BlnFilter = False
        Listboxvullen()
        ControlLayout()
    End Sub

    Private Sub ListBoxUser_SelectedValueChanged(sender As Object, e As EventArgs) Handles ListBoxUser.SelectedValueChanged
        If Mainform.BlnFilter = False Then
            ToonUser(ListBoxUser.SelectedIndex)
        Else
            ToonUser2(ListBoxUser.SelectedIndex)
        End If
    End Sub

    Private Sub TextBoxUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxUsername.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub TextBoxPassword1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxPassword1.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub


    Private Sub Splitter1_SplitterMoved_1(sender As Object, e As SplitterEventArgs) Handles Splitter1.SplitterMoved
        ControlLayout()
    End Sub

    Public Sub ControlLayout()
        Dim width As Integer = ListBoxUser.Width
        Label1.Location = New Point(width + 50, Label1.Location.Y)
        Label2.Location = New Point(width + 50, Label2.Location.Y)
        TextBoxUsername.Location = New Point((width + Label1.Width) + 70, TextBoxUsername.Location.Y)
        TextBoxPassword1.Location = New Point((TextBoxUsername.Location.X), TextBoxPassword1.Location.Y)
        ButtonWijzigen.Location = New Point(width + 50, ButtonWijzigen.Location.Y)
    End Sub
End Class