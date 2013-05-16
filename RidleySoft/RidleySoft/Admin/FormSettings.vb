Imports System.Reflection
Imports System.Windows.Forms

Public Class FormSettings

    Private _dataset As DataSet
    Private _dataset2 As DataSet
    Private _index As Integer
    Private intComboGroupID As Integer
    Private strLanguage As String
    Public strdescr As String
    Public strvalue As String
    Public strtype As String
    Public strusername As String

    Private Sub FormSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mainform.BlnFilter = False
        Me.AutoSize = True
        Me.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
        _index = 0
        If Mainform.BlnFilter = False Then
            ToonSetting(_index)
        Else
            ToonSetting2(_index)
        End If
        Listboxvullen()
        Mainform.frmOudeForm.Name = "SettingToevoegen"
        Mainform.frmverwijderForm.Name = "FormSettings"
        MainForm.FrmOpenForm = Me
        Me.Dock = DockStyle.Fill
        Translate.LoadLanguage(Me)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        AddHandler MainForm.menuitemEerste.Click, AddressOf EersteKlik
        AddHandler MainForm.menuitemVorige.Click, AddressOf VorigeKlik
        AddHandler MainForm.menuitemVolgende.Click, AddressOf VolgendeKlik
        AddHandler MainForm.menuitemLaatste.Click, AddressOf LaatsteKlik
        AddHandler MainForm.menuitemToevoegen.Click, AddressOf ToevoegenKlik
        AddHandler MainForm.menuitemVerwijderen.Click, AddressOf VerwijderenKlik
        AddHandler MainForm.menuitemSearch.Click, AddressOf searchKlik
        AddHandler MainForm.menuitemFilter.Click, AddressOf filterKlik

        For Each frm As Form In My.Application.OpenForms
            If frm IsNot Me And frm.Name IsNot "childformSettings" Then
                frm.BackColor = Nothing
            End If
        Next
        Me.BackColor = Color.Lavender

    End Sub

    Private Sub filterKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "SettingToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "SettingToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "SettingToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            FilterUser.TopLevel = True
            FilterUser.Show()
            Mainform.frmNieuwForm.Name = "SettingToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Private Sub searchKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "SettingToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "SettingToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "SettingToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            SearchForm.TopLevel = True
            SearchForm.Show()
            Mainform.frmNieuwForm.Name = "SettingToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Private Function GetDataSetConventional(ByVal list As List(Of DASettings)) As DataSet
        Dim _result As New DataSet()
        _result.Tables.Add("settings")
        _result.Tables("settings").Columns.Add("SettingID")
        _result.Tables("settings").Columns.Add("Description")
        _result.Tables("settings").Columns.Add("Value")
        _result.Tables("settings").Columns.Add("Type")
        _result.Tables("settings").Columns.Add("UserID")

        For Each item As DASettings In list
            Dim newRow As DataRow = _
                _result.Tables("settings").NewRow()
            newRow("SettingID") = item.SettingID
            newRow("Description") = item.Description
            newRow("Value") = item.Value
            newRow("Type") = item.Type
            newRow("UserID") = item.UserID
            _result.Tables("settings").Rows.Add(newRow)
        Next
        Return _result
    End Function

    Private Function GetDataSetConventional2(ByVal list As List(Of DAUserSettings)) As DataSet
        Dim _result As New DataSet()
        _result.Tables.Add("settings")
        _result.Tables("settings").Columns.Add("SettingID")
        _result.Tables("settings").Columns.Add("Description")
        _result.Tables("settings").Columns.Add("Value")
        _result.Tables("settings").Columns.Add("Type")
        _result.Tables("settings").Columns.Add("UserID")

        For Each item As DAUserSettings In list
            Dim newRow As DataRow = _
                _result.Tables("settings").NewRow()
            newRow("SettingID") = item.SettingID
            newRow("Description") = item.Description
            newRow("Value") = item.Value
            newRow("Type") = item.Type
            newRow("UserID") = item.UserID
            _result.Tables("settings").Rows.Add(newRow)
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

    Public Sub ToonSetting(ByVal i As Integer)
        Dim daSettings As DASettings = New DASettings()
        Dim settings As List(Of DASettings) = daSettings.GetSettings()

        _dataset = GetDataSetConventional(settings)

        TextBoxUser.Text = Nothing
        TextBoxDescription.Text = Nothing
        TextBoxValue.Text = Nothing

        Try
            If (_dataset.Tables("settings").Rows(i).RowState <> DataRowState.Deleted) Then
                'Dim userID As Integer = _dataset.Tables("settings").Rows(i).Field(Of String)("UserID")
                Dim daUser As DAUser = New DAUser()
                Dim user As DAUser = daUser.GetUserByUserID(ListBoxUser.SelectedValue)
                TextBoxUser.Text = user.Username
                TextBoxUser.Tag = user.UserID

                TextBoxDescription.Tag = _dataset.Tables("settings").Rows(i).Field(Of String)("SettingID")
                Dim type As String = _dataset.Tables("settings").Rows(i).Field(Of String)("Type")
                TextBoxDescription.Text = _dataset.Tables("settings").Rows(i).Field(Of String)("Description")
                TextBoxValue.Text = _dataset.Tables("settings").Rows(i).Field(Of String)("Value")
                TextBoxType.Text = type
            End If
        Catch ex As Exception
            TextBoxUser.Text = Nothing
            TextBoxDescription.Text = Nothing
            TextBoxValue.Text = Nothing
            TextBoxType.Text = Nothing
        End Try

    End Sub

    Public Sub ToonSetting2(ByVal i As Integer)
        Dim daSetting As DAUserSettings = New DAUserSettings()
        Dim settings As List(Of DAUserSettings) = daSetting.getSettingsByFilter(strusername, strdescr, strvalue, strtype)

        _dataset = GetDataSetConventional2(settings)

        TextBoxUser.Text = Nothing
        TextBoxDescription.Text = Nothing
        TextBoxValue.Text = Nothing

        Try
            If (_dataset.Tables("settings").Rows(i).RowState <> DataRowState.Deleted) Then
                'Dim userID As Integer = _dataset.Tables("settings").Rows(i).Field(Of String)("UserID")
                Dim daUser As DAUser = New DAUser()
                Dim user As DAUser = daUser.GetUserByUserID(ListBoxUser.SelectedValue)
                TextBoxUser.Text = user.Username
                TextBoxUser.Tag = user.UserID

                TextBoxDescription.Tag = _dataset.Tables("settings").Rows(i).Field(Of String)("SettingID")
                Dim type As String = _dataset.Tables("settings").Rows(i).Field(Of String)("Type")
                TextBoxDescription.Text = _dataset.Tables("settings").Rows(i).Field(Of String)("Description")
                TextBoxValue.Text = _dataset.Tables("settings").Rows(i).Field(Of String)("Value")
                TextBoxType.Text = type
            End If
        Catch ex As Exception
            TextBoxUser.Text = Nothing
            TextBoxDescription.Text = Nothing
            TextBoxValue.Text = Nothing
            TextBoxType.Text = Nothing
        End Try
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
        If Mainform.frmOudeForm.Name <> "SettingToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "SettingToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "SettingToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            _index = 0
            If Mainform.BlnFilter = False Then
                ToonSetting(_index)
            Else
                ToonSetting2(_index)
            End If
            Mainform.frmNieuwForm.Name = "SettingToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If


    End Sub

    Private Sub VorigeKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "SettingToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "SettingToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "SettingToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            If (_index > 0) Then
                _index -= 1
                If Mainform.BlnFilter = False Then
                    ToonSetting(_index)
                Else
                    ToonSetting2(_index)
                End If
            End If
            Mainform.frmNieuwForm.Name = "SettingToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If

    End Sub

    Private Sub VolgendeKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "SettingToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "SettingToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "SettingToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            If (_index < _dataset.Tables("settings").Rows.Count - 1) Then
                _index += 1
                If Mainform.BlnFilter = False Then
                    ToonSetting(_index)
                Else
                    ToonSetting2(_index)
                End If
            End If
            Mainform.frmNieuwForm.Name = "SettingToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If

    End Sub

    Private Sub LaatsteKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "SettingToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "SettingToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "SettingToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            _index = _dataset.Tables("settings").Rows.Count - 1
            If Mainform.BlnFilter = False Then
                ToonSetting(_index)
            Else
                ToonSetting2(_index)
            End If
            Mainform.frmNieuwForm.Name = "SettingToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If

    End Sub

    Private Sub ToevoegenKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "SettingToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "SettingToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "SettingToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            SettingToevoegen.TopLevel = True
            SettingToevoegen.Show()
            Mainform.frmNieuwForm.Name = "SettingToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Private Sub VerwijderenKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim strYes As String
        Dim strCaption As String
        Dim strTitle As String
        strCaption = "Bent u zeker dat u dit item wilt verwijderen?"
        strTitle = "Waarschuwing"


        If MainForm.frmverwijderForm.Name <> "Formsettings" And MainForm.frmverwijderForm.Name <> MainForm.frmNieuweverwijderForm.Name Then
            MainForm.frmNieuweverwijderForm.Name = "Formsettings"
        End If
        If MainForm.frmverwijderForm.Name = "Formsettings" Or MainForm.frmverwijderForm.Name = "" Then
            strYes = MessageBox.Show(strCaption, strTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If strYes = DialogResult.Yes Then
                If MainForm.frmverwijderForm.Name <> "Formsettings" And MainForm.frmverwijderForm.Name <> MainForm.frmNieuweverwijderForm.Name Then
                    MainForm.frmNieuweverwijderForm.Name = "Formsettings"
                End If
                If MainForm.frmverwijderForm.Name = "Formsettings" Or MainForm.frmverwijderForm.Name = "" Then
                    Dim daSetting As DASettings = New DASettings()
                    daSetting.deleteSetting(TextBoxDescription.Tag)

                    If (_index > 0) Then
                        _index -= 1
                        If MainForm.BlnFilter = False Then
                            ToonSetting(_index)
                        Else
                            ToonSetting2(_index)
                        End If
                    Else
                    End If
                    MainForm.frmNieuweverwijderForm.Name = "Formsettings"
                Else
                    MainForm.frmOudeForm.Close()
                End If
            End If
            If MainForm.BlnFilter = False Then
                ToonSetting(_index)
            Else
                ToonSetting2(_index)
            End If
            MainForm.frmNieuweverwijderForm.Name = "Formsettings"
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


    Private Sub AdminFormSettings_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        Mainform.frmOudeForm.Name = "SettingToevoegen"
        For Each frm As Form In My.Application.OpenForms
            If frm IsNot Me Then
                frm.BackColor = Nothing
            End If
        Next
        Me.BackColor = Color.Lavender
        Mainform.BlnFilter = False
        Listboxvullen()
    End Sub

    Private Sub ListBoxUser_SelectedValueChanged(sender As Object, e As EventArgs) Handles ListBoxUser.SelectedValueChanged
        If Mainform.BlnFilter = False Then
            ToonSetting(ListBoxUser.SelectedIndex)
        Else
            ToonSetting2(ListBoxUser.SelectedIndex)
        End If
    End Sub

    Private Sub ButtonWijzigen_Click_1(sender As Object, e As EventArgs) Handles ButtonWijzigen.Click
        If Mainform.frmOudeForm.Name <> "SettingToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "SettingToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "SettingToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            Dim daSetting As DASettings = New DASettings()
            Dim setting As DASettings = New DASettings(TextBoxDescription.Tag, TextBoxDescription.Text, TextBoxValue.Text, TextBoxType.Text, TextBoxUser.Tag)
            daSetting.UpdateSetting(setting)
            Mainform.frmNieuwForm.Name = "SettingToevoegen"
        Else
            Mainform.frmOudeForm.Close()
            Listboxvullen()
            ControlLayout()
        End If
    End Sub

    Private Sub TextBoxUser_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxUser.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub TextBoxDescription_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxDescription.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub TextBoxValue_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxValue.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub TextBoxType_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxType.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub Splitter1_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles Splitter1.SplitterMoved
        ControlLayout()
    End Sub

    Public Sub ControlLayout()
        Dim width As Integer = ListBoxUser.Width
        LabelUser.Location = New Point(width + 50, LabelUser.Location.Y)
        LabelDescription.Location = New Point(width + 50, LabelDescription.Location.Y)
        LabelValue.Location = New Point(width + 50, LabelValue.Location.Y)
        LabelType.Location = New Point(width + 50, LabelType.Location.Y)
        TextBoxUser.Location = New Point((width + LabelUser.Width) + 70, TextBoxUser.Location.Y)
        TextBoxDescription.Location = New Point((TextBoxUser.Location.X), TextBoxDescription.Location.Y)
        TextBoxValue.Location = New Point((TextBoxUser.Location.X), TextBoxValue.Location.Y)
        TextBoxType.Location = New Point((TextBoxUser.Location.X), TextBoxType.Location.Y)
        ButtonWijzigen.Location = New Point(width + 50, ButtonWijzigen.Location.Y)
    End Sub
End Class