Public Class GroupToevoegen
    Private Sub ButtonToevoegen_Click(sender As Object, e As EventArgs) Handles ButtonToevoegen.Click
        If TextBoxGroupname.Text <> Nothing Then
            Dim dagroups As DAGroup = New DAGroup()
            Dim groups As List(Of DAGroup) = dagroups.getGroups()

            Dim daGroup As DAGroup = New DAGroup()
            Dim group As DAGroup = New DAGroup((groups.Count + 1), TextBoxGroupname.Text)

            daGroup.InsertGroup(group)

            FormGroup.ToonGroup(groups.Count)
            Mainform.frmOudeForm.Name = "GroupToevoegen"
            FormGroup.Listboxvullen()
            Me.Close()
            MainForm.frmOudeForm.Name = "GroupToevoegen"
            MainForm.StatusStrip1.Dispose()
            MainForm.StatusStrip1 = New StatusStrip()
            MainForm.ToolStripStatusLabel1.Text = "Succesvol toegevoegd"
            MainForm.ToolStripStatusLabel1.ForeColor = Color.White
            MainForm.StatusStrip1.BackColor = Color.Green
            MainForm.StatusStrip1.Dock = DockStyle.Top
            MainForm.StatusStrip1.Items.Add(MainForm.ToolStripStatusLabel1)
            MainForm.StatusStrip1.Show()
            For Each frm As Form In My.Application.OpenForms
                If frm Is FormGroup Then
                    frm.Controls.Add(MainForm.StatusStrip1)
                End If
            Next
        End If
    End Sub

    Private Sub GroupToevoegen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Translate.LoadLanguage(Me)
        MainForm.FrmOpenForm = Me
    End Sub

    Private Sub TextBoxGroupname_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxGroupname.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub
End Class