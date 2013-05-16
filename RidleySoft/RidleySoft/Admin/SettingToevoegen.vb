Public Class SettingToevoegen

    Private Sub ButtonToevoegen_Click(sender As Object, e As EventArgs) Handles ButtonToevoegen.Click
        Dim daSettings As DASettings = New DASettings()
        Dim settings As List(Of DASettings) = daSettings.GetSettings()

        Dim daSetting As DASettings = New DASettings()
        Dim setting As DASettings = New DASettings((settings.Count + 1), TextBoxDescription.Text, TextBoxValue.Text, TextBoxType.Text, ComboBoxUser.SelectedValue)

        daSettings.InsertSetting(setting)

        FormSettings.ToonSetting(settings.Count)
        MainForm.frmOudeForm.Name = "SettingToevoegen"
        MainForm.StatusStrip1.Dispose()
        MainForm.StatusStrip1 = New StatusStrip()
        MainForm.ToolStripStatusLabel1.Text = "Succesvol toegevoegd"
        MainForm.ToolStripStatusLabel1.ForeColor = Color.White
        MainForm.StatusStrip1.BackColor = Color.Green
        MainForm.StatusStrip1.Dock = DockStyle.Top
        MainForm.StatusStrip1.Items.Add(MainForm.ToolStripStatusLabel1)
        MainForm.StatusStrip1.Show()
        For Each frm As Form In My.Application.OpenForms
            If frm Is FormSettings Then
                frm.Controls.Add(MainForm.StatusStrip1)
            End If
        Next
        FormSettings.Listboxvullen()
        Me.Close()
    End Sub

    Private Sub ModuleToevoegen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Comboboxvullen()
        Translate.LoadLanguage(Me)
        MainForm.FrmOpenForm = Me
    End Sub


    Public Sub Comboboxvullen()
        Dim daUser As DAUser = New DAUser()
        Dim users As List(Of DAUser) = daUser.GetUsers()

        ComboBoxUser.DataSource = users
        ComboBoxUser.DisplayMember = "UserName"
        ComboBoxUser.ValueMember = "UserID"
    End Sub

    Private Sub ComboBoxUser_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBoxUser.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            TextBoxDescription.Focus()
        End If
    End Sub

    Private Sub TextBoxDescription_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxDescription.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            TextBoxValue.Focus()
        End If
    End Sub

    Private Sub TextBoxValue_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxValue.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            TextBoxType.Focus()
        End If
    End Sub

    Private Sub TextBoxType_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxType.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            ButtonToevoegen.Focus()
        End If
    End Sub
End Class