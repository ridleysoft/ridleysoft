Public Class SubMenuToevoegen
    Private intComboMenuID As Integer
    Private Sub ButtonWijzigen_Click(sender As Object, e As EventArgs) Handles ButtonToevoegen.Click
        Dim daSubMenus As DASubmenu = New DASubmenu()
        Dim submenus As List(Of DASubmenu) = daSubMenus.getSubMenus()

        Dim daSubMenu As DASubmenu = New DASubmenu()
        intComboMenuID = ComboBoxMenu.SelectedValue()
        Dim submenuu As DASubmenu = New DASubmenu((submenus.Count + 1), TextBoxSubMenu.Text, ComboBoxMenu.SelectedValue())

        daSubMenu.InsertSubMenu(submenuu)
        FormSubMenu.ToonSubmenu(submenus.Count)
        MainForm.frmOudeForm.Name = "SubMenuToevoegen"
        MainForm.StatusStrip1.Dispose()
        MainForm.StatusStrip1 = New StatusStrip()

        MainForm.ToolStripStatusLabel1.Text = "Succesvol toegevoegd"
        MainForm.ToolStripStatusLabel1.ForeColor = Color.White
        MainForm.StatusStrip1.BackColor = Color.Green
        MainForm.StatusStrip1.Dock = DockStyle.Top
        MainForm.StatusStrip1.Items.Add(MainForm.ToolStripStatusLabel1)
        MainForm.StatusStrip1.Show()
        For Each frm As Form In My.Application.OpenForms
            If frm Is FormSubMenu Then
                frm.Controls.Add(MainForm.StatusStrip1)

            End If
        Next
        FormSubMenu.Listboxvullen()
        Me.Close()
    End Sub

    Private Sub MenuToevoegen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Comboboxvullen()
        Translate.LoadLanguage(Me)
        MainForm.FrmOpenForm = Me
    End Sub


    Public Sub Comboboxvullen()
        Dim daMenu As DAMenu = New DAMenu()
        Dim menus As List(Of DAMenu) = daMenu.getMenusAdmin()

        ComboBoxMenu.DataSource = menus
        ComboBoxMenu.DisplayMember = "description"
        ComboBoxMenu.ValueMember = "MenuID"

        labelInvullen()
    End Sub

    Public Sub labelInvullen()
        intComboMenuID = ComboBoxMenu.SelectedValue()
        Dim daSubmenuMod As DASubmenuMod = New DASubmenuMod()
        Dim submenuMod As DASubmenuMod = daSubmenuMod.getModuleByMenuId(intComboMenuID)
    End Sub

    Private Sub ComboBoxMenu_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxMenu.SelectedValueChanged
        If (intComboMenuID <> 0) Then
            labelInvullen()
        End If
    End Sub

    Private Sub TextBoxSubMenu_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxSubMenu.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            ComboBoxMenu.Focus()
        End If
    End Sub

    Private Sub ComboBoxMenu_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBoxMenu.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            ButtonToevoegen.Focus()
        End If
    End Sub
End Class