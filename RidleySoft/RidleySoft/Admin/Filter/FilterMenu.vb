Public Class FilterMenu

    Private Sub ButtonFilter_Click(sender As Object, e As EventArgs) Handles ButtonFilter.Click
        listboxOpvullen2()
        Mainform.BlnFilter = True
        FormMenu.ToonMenu2(0)
        Me.Close()
    End Sub

    Public Sub listboxOpvullen2()
        FormMenu.strMenu = TextBoxMenu.Text
        FormMenu.strModule = TextBoxModule.Text
        If Mainform.frmNieuwForm.Name = "MenuToevoegen" Then
            Dim daMenus As DAMenuMod = New DAMenuMod()
            Dim menus As List(Of DAMenuMod) = daMenus.getMenusByFilter(FormMenu.strMenu, FormMenu.strModule)

            FormMenu.ListBox1.DataSource = menus
            FormMenu.ListBox1.DisplayMember = "menuDescr"
            FormMenu.ListBox1.ValueMember = "MenuID"
        End If
    End Sub

    Private Sub FilterMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width, Screen.PrimaryScreen.WorkingArea.Height - Me.Height)
        Translate.LoadLanguage(Me)
        MainForm.FrmOpenForm = Me
    End Sub

    Private Sub TextBoxMenu_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxMenu.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            TextBoxModule.Focus()
        End If
    End Sub

    Private Sub TextBoxModule_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxModule.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            ButtonFilter.Focus()
        End If
    End Sub
End Class