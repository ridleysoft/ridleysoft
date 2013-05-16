Public Class FilterSubmenu

    Private Sub FilterSubmenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width, Screen.PrimaryScreen.WorkingArea.Height - Me.Height)
        Translate.LoadLanguage(Me)
        MainForm.FrmOpenForm = Me
    End Sub

    Private Sub ButtonFilter_Click(sender As Object, e As EventArgs) Handles ButtonFilter.Click
        listboxOpvullen2()
        Mainform.BlnFilter = True
        FormSubMenu.ToonSubmenu2(0)
        Me.Close()
    End Sub

    Public Sub listboxOpvullen2()
        FormSubMenu.strMenu = TextBoxMenu.Text
        FormSubMenu.strSubmenu = TextBoxSubMenu.Text
        If Mainform.frmNieuwForm.Name = "SubMenuToevoegen" Then
            Dim daSubMenu As DASubmenuMod = New DASubmenuMod()
            Dim submenus As List(Of DASubmenuMod) = daSubMenu.getSubMenusByFilter(FormSubMenu.strSubmenu, FormSubMenu.strMenu)

            FormSubMenu.ListBox1.DataSource = submenus
            FormSubMenu.ListBox1.DisplayMember = "SubMenuDescr"
            FormSubMenu.ListBox1.ValueMember = "SubMenuID"
        End If
    End Sub

    Private Sub TextBoxSubMenu_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxSubMenu.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            TextBoxMenu.Focus()
        End If
    End Sub

    Private Sub TextBoxMenu_KeyDown(sender As Object, e As KeyEventArgs)
        If (e.KeyCode = Keys.Enter) Then
            ButtonFilter.Focus()
        End If
    End Sub
End Class