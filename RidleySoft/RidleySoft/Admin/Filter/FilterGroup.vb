Public Class FilterGroup

    Private Sub FilterGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width, Screen.PrimaryScreen.WorkingArea.Height - Me.Height)
        Translate.LoadLanguage(Me)
        MainForm.FrmOpenForm = Me
    End Sub

    Private Sub ButtonFilter_Click(sender As Object, e As EventArgs) Handles ButtonFilter.Click
        listboxOpvullen2()
        Mainform.BlnFilter = True
        FormGroup.ToonGroup2(0)
        Me.Close()
    End Sub

    Public Sub listboxOpvullen2()
        FormGroup.strGroup = TextBoxGroup.Text
        If Mainform.frmNieuwForm.Name = "GroupToevoegen" Then
            Dim daGroup As DAGroup = New DAGroup()
            Dim groups As List(Of DAGroup) = daGroup.GetGroupsByFilter(FormGroup.strGroup)

            FormGroup.ListBox1.DataSource = groups
            FormGroup.ListBox1.DisplayMember = "GroupName2"
            FormGroup.ListBox1.ValueMember = "GroupID2"
        End If
    End Sub

    Private Sub TextBoxGroup_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxGroup.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub
End Class