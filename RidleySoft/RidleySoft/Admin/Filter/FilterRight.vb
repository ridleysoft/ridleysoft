Public Class FilterRight
    Private Sub FilterRight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width, Screen.PrimaryScreen.WorkingArea.Height - Me.Height)
        Translate.LoadLanguage(Me)
        MainForm.FrmOpenForm = Me
    End Sub

    Private Sub ButtonFilter_Click(sender As Object, e As EventArgs) Handles ButtonFilter.Click
        listboxOpvullen2()
        Mainform.BlnFilter = True
        FormRights.ToonRight2(0)
        Me.Close()
    End Sub

    Public Sub listboxOpvullen2()
        FormRights.strRight = TextBoxRight.Text
        If Mainform.frmNieuwForm.Name = "AddRight" Then
            Dim daRight As DARights = New DARights()
            Dim rights As List(Of DARights) = daRight.GetRightsByFilter(FormRights.strRight)

            FormRights.ListBox1.DataSource = rights
            FormRights.ListBox1.DisplayMember = "Description"
            FormRights.ListBox1.ValueMember = "RightID"
        End If
    End Sub

    Private Sub TextBoxRight_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxRight.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub
End Class