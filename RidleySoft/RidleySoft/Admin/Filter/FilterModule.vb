Public Class FilterModule

    Private Sub FilterModule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width, Screen.PrimaryScreen.WorkingArea.Height - Me.Height)
        Translate.LoadLanguage(Me)
        MainForm.FrmOpenForm = Me
    End Sub

    Private Sub ButtonFilter_Click(sender As Object, e As EventArgs) Handles ButtonFilter.Click
        listboxOpvullen2()
        Mainform.BlnFilter = True
        FormModule.ToonModule2(0)
        Me.Close()
    End Sub

    Public Sub listboxOpvullen2()
        FormModule.strModule = TextBoxModule.Text
        FormModule.strGroup = TextBoxGroup.Text
        If Mainform.frmNieuwForm.Name = "ModuleToevoegen" Then
            Dim daModules As DAGroupModule = New DAGroupModule()
            Dim modules As List(Of DAGroupModule) = daModules.getModulesByFilter(FormModule.strModule, FormModule.strGroup)

            FormModule.ListBox1.DataSource = modules
            FormModule.ListBox1.DisplayMember = "Description"
            FormModule.ListBox1.ValueMember = "ModuleID"
        End If
    End Sub

    Private Sub TextBoxModule_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxModule.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            TextBoxGroup.Focus()
        End If
    End Sub

    Private Sub TextBoxGroup_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxGroup.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            ButtonFilter.Focus()
        End If
    End Sub
End Class