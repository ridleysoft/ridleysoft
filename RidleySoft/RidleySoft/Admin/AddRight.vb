Public Class AddRight
    Private Sub ButtonToevoegen_Click(sender As Object, e As EventArgs) Handles ButtonToevoegen.Click
        If TextBoxRight.Text <> Nothing Then
            Dim daRights As DARights = New DARights()
            Dim rights As List(Of DARights) = daRights.getRights()

            Dim daRight As DARights = New DARights()
            Dim right As DARights = New DARights((rights.Count + 1), TextBoxRight.Text)

            daRight.InsertUserRights(right)

            FormRights.ToonRight(rights.Count)
            MainForm.StatusStrip1 = New StatusStrip()
            MainForm.frmOudeForm.Name = "AddRight"
            MainForm.FrmOpenForm = Me
            MainForm.StatusStrip1.Dispose()
            MainForm.frmOudeForm.Name = "AddRight"
            MainForm.ToolStripStatusLabel1.Text = "Succesvol toegevoegd"
            MainForm.ToolStripStatusLabel1.ForeColor = Color.White
            MainForm.StatusStrip1.BackColor = Color.Green
            MainForm.StatusStrip1.Dock = DockStyle.Top
            MainForm.StatusStrip1.Items.Add(MainForm.ToolStripStatusLabel1)

            MainForm.StatusStrip1.Show()
            For Each frm As Form In My.Application.OpenForms
                If frm Is FormRights Then
                    frm.Controls.Add(MainForm.StatusStrip1)
                End If
            Next
            FormRights.Listboxvullen()
            Me.Close()
        End If
    End Sub

    Private Sub AddRight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Translate.LoadLanguage(Me)
    End Sub

    Private Sub AddRight_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub TextBoxRight_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxRight.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub
End Class