Public Class UserToevoegen

    Private Sub ButtonToevoegen_Click(sender As Object, e As EventArgs) Handles ButtonToevoegen.Click
        If TextBoxUsername123.Text <> Nothing And TextBoxPassword123.Text <> Nothing Then
            Dim daUsers As DAUser = New DAUser()
            Dim users As List(Of DAUser) = daUsers.GetUsers()

            Dim daUser As DAUser = New DAUser()
            Dim user As DAUser = New DAUser((users.Count + 1), TextBoxUsername123.Text, TextBoxPassword123.Text, 0)

            daUser.InsertUser(user)
            AdminFormUser.ToonUser(users.Count)
            MainForm.frmOudeForm.Name = "UserToevoegen"
            MainForm.StatusStrip1.Dispose()
            MainForm.StatusStrip1 = New StatusStrip()
            MainForm.ToolStripStatusLabel1.Text = "Succesvol toegevoegd"
            MainForm.ToolStripStatusLabel1.ForeColor = Color.White
            MainForm.StatusStrip1.BackColor = Color.Green
            MainForm.StatusStrip1.Dock = DockStyle.Top
            MainForm.StatusStrip1.Items.Add(MainForm.ToolStripStatusLabel1)
            MainForm.StatusStrip1.Show()
            For Each frm As Form In My.Application.OpenForms
                If frm Is AdminFormUser Then
                    frm.Controls.Add(MainForm.StatusStrip1)
                End If
            Next
            AdminFormUser.Listboxvullen()
            Me.Close()

        End If
    End Sub

    Private Sub UserToevoegen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Translate.LoadLanguage(Me)
        MainForm.FrmOpenForm = Me
    End Sub

    Private Sub TextBoxUsername123_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxUsername123.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub TextBoxPassword123_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxPassword123.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub
End Class