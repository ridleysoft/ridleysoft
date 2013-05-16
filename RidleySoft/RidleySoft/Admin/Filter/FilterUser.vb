Public Class FilterUser

    Private Sub UserFilter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width, Screen.PrimaryScreen.WorkingArea.Height - Me.Height)

        If Mainform.frmOudeForm.Name = "UserToevoegen" Or Mainform.frmOudeForm.Name = "FormUsersModules" Or Mainform.frmOudeForm.Name = "FormUserRights" Then
            Me.Height = 100
            Me.StartPosition = FormStartPosition.Manual
            Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width, Screen.PrimaryScreen.WorkingArea.Height - Me.Height)
            LabelDescription.Visible = False
            TextBoxDescription.Visible = False
            LabelType.Visible = False
            TextBoxType.Visible = False
            LabelValue.Visible = False
            TextBoxValue.Visible = False
        End If
        Translate.LoadLanguage(Me)
        MainForm.FrmOpenForm = Me
    End Sub

    Private Sub ButtonFilter_Click(sender As Object, e As EventArgs) Handles ButtonFilter.Click

        listboxOpvullen2()
        Mainform.BlnFilter = True
        AdminFormUser.ToonUser2(0)
        Me.Close()
    End Sub

    Public Sub listboxOpvullen2()
        AdminFormUser.strUser = TextBoxUserName.Text
        If Mainform.frmOudeForm.Name <> "UserToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "UserToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "UserToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            Dim daUser As DAUser = New DAUser()
            Dim users As List(Of DAUser) = daUser.GetUsersByFilter(AdminFormUser.strUser)

            AdminFormUser.ListBoxUser.DataSource = users
            AdminFormUser.ListBoxUser.DisplayMember = "UserName"
            AdminFormUser.ListBoxUser.ValueMember = "UserID"
            Mainform.frmNieuwForm.Name = "UserToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If
        If Mainform.frmOudeForm.Name <> "FormUsersModules" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "FormUsersModules"
        End If
        If Mainform.frmOudeForm.Name = "FormUsersModules" Or Mainform.frmOudeForm.Name = "" Then
            Dim daUser As DAUser = New DAUser()
            Dim users As List(Of DAUser) = daUser.GetUsersByFilter(AdminFormUser.strUser)

            FormUsersModules.ListBoxUser.DataSource = users
            FormUsersModules.ListBoxUser.DisplayMember = "UserName"
            FormUsersModules.ListBoxUser.ValueMember = "UserID"
            Mainform.frmNieuwForm.Name = "FormUsersModules"
        Else
            Mainform.frmOudeForm.Close()
        End If
        If Mainform.frmOudeForm.Name <> "FormUserRights" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "FormUserRights"
        End If
        If Mainform.frmOudeForm.Name = "FormUserRights" Or Mainform.frmOudeForm.Name = "" Then
            Dim daUser As DAUser = New DAUser()
            Dim users As List(Of DAUser) = daUser.GetUsersByFilter(AdminFormUser.strUser)

            FormUserRights.ListBoxUser.DataSource = users
            FormUserRights.ListBoxUser.DisplayMember = "UserName"
            FormUserRights.ListBoxUser.ValueMember = "UserID"
            Mainform.frmNieuwForm.Name = "FormUserRights"
        Else
            Mainform.frmOudeForm.Close()
        End If
        If Mainform.frmOudeForm.Name <> "SettingToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "SettingToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "SettingToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            FormSettings.strusername = TextBoxUserName.Text
            FormSettings.strdescr = TextBoxDescription.Text
            FormSettings.strvalue = TextBoxValue.Text
            FormSettings.strtype = TextBoxType.Text

            Dim daUser As DAUser = New DAUser()
            Dim user As DAUser = daUser.GetUserIDByUser(FormSettings.strusername)
            Dim daSetting As DAUserSettings = New DAUserSettings()
            Dim settings As List(Of DAUserSettings) = daSetting.getSettingsByFilter(FormSettings.strusername, FormSettings.strdescr, FormSettings.strvalue, FormSettings.strtype)

            FormSettings.ListBoxUser.DataSource = settings
            FormSettings.ListBoxUser.DisplayMember = "UserName"
            FormSettings.ListBoxUser.ValueMember = "UserID"
            Mainform.frmNieuwForm.Name = "SettingToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Private Sub TextBoxUserName_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxUserName.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            If TextBoxDescription.Visible = True Then
                TextBoxDescription.Focus()
            Else
                ButtonFilter.Focus()
            End If
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
            ButtonFilter.Focus()
        End If
    End Sub
End Class