Public Class SearchForm

    Private Sub SearchForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width, Screen.PrimaryScreen.WorkingArea.Height - Me.Height)
        Translate.LoadLanguage(Me)
        MainForm.FrmOpenForm = Me
    End Sub

    Private Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click
        If TextBoxSearch.Text <> Nothing Then
            If Mainform.frmNieuwForm.Name = "UserToevoegen" Then
                Dim fc As ListBox.ObjectCollection = AdminFormUser.ListBoxUser.Items
                For Each item As DAUser In fc.OfType(Of DAUser).ToList()
                    If item.Username.ToLower().Contains(TextBoxSearch.Text.ToLower()) Then
                        AdminFormUser.ListBoxUser.SelectedItem = item
                    End If
                Next
            ElseIf Mainform.frmNieuwForm.Name = "GroupToevoegen" Then
                Dim fc As ListBox.ObjectCollection = FormGroup.ListBox1.Items
                For Each item As DAGroup In fc.OfType(Of DAGroup).ToList()
                    If item.GroupName2.ToLower().Contains(TextBoxSearch.Text.ToLower()) Then
                        FormGroup.ListBox1.SelectedItem = item
                    End If
                Next
            ElseIf Mainform.frmNieuwForm.Name = "MenuToevoegen" Then
                Dim fc As ListBox.ObjectCollection = FormMenu.ListBox1.Items
                For Each item As DAMenu In fc.OfType(Of DAMenu).ToList()
                    If item.Description.ToLower().Contains(TextBoxSearch.Text.ToLower()) Then
                        FormMenu.ListBox1.SelectedItem = item
                    End If
                Next
            ElseIf Mainform.frmNieuwForm.Name = "ModuleToevoegen" Then
                Dim fc As ListBox.ObjectCollection = FormModule.ListBox1.Items
                For Each item As DAModule In fc.OfType(Of DAModule).ToList()
                    If item.Description.ToLower().Contains(TextBoxSearch.Text.ToLower()) Then
                        FormModule.ListBox1.SelectedItem = item
                    End If
                Next
            ElseIf Mainform.frmNieuwForm.Name = "AddRight" Then
                Dim fc As ListBox.ObjectCollection = FormRights.ListBox1.Items
                For Each item As DARights In fc.OfType(Of DARights).ToList()
                    If item.Description.ToLower().Contains(TextBoxSearch.Text.ToLower()) Then
                        FormRights.ListBox1.SelectedItem = item
                    End If
                Next
            ElseIf Mainform.frmNieuwForm.Name = "SettingToevoegen" Then
                Dim fc As ListBox.ObjectCollection = FormSettings.ListBoxUser.Items
                For Each item As DAUser In fc.OfType(Of DAUser).ToList()
                    If item.Username.ToLower().Contains(TextBoxSearch.Text.ToLower()) Then
                        FormSettings.ListBoxUser.SelectedItem = item
                    End If
                Next
            ElseIf Mainform.frmNieuwForm.Name = "SubMenuToevoegen" Then
                Dim fc As ListBox.ObjectCollection = FormSubMenu.ListBox1.Items
                For Each item As DASubmenu In fc.OfType(Of DASubmenu).ToList()
                    If item.Description.ToLower().Contains(TextBoxSearch.Text.ToLower()) Then
                        FormSubMenu.ListBox1.SelectedItem = item
                    End If
                Next
            ElseIf Mainform.frmNieuwForm.Name = "FormUserRights" Then
                Dim fc As ListBox.ObjectCollection = FormUserRights.ListBoxUser.Items
                For Each item As DAUser In fc.OfType(Of DAUser).ToList()
                    If item.Username.ToLower().Contains(TextBoxSearch.Text.ToLower()) Then
                        FormUserRights.ListBoxUser.SelectedItem = item
                    End If
                Next
            ElseIf Mainform.frmNieuwForm.Name = "FormUsersModules" Then
                Dim fc As ListBox.ObjectCollection = FormUsersModules.ListBoxUser.Items
                For Each item As DAUser In fc.OfType(Of DAUser).ToList()
                    If item.Username.ToLower().Contains(TextBoxSearch.Text.ToLower()) Then
                        FormUsersModules.ListBoxUser.SelectedItem = item
                    End If
                Next
            ElseIf Mainform.frmNieuwForm.Name = "FormDeleteItem" Then
                Dim fc As ListBox.ObjectCollection = FormDeleteItem.ListBoxB2B.Items
                For Each item As DAItems In fc.OfType(Of DAItems).ToList()
                    If item.ItemName.ToLower().Contains(TextBoxSearch.Text.ToLower()) Then
                        FormDeleteItem.ListBoxB2B.SelectedItem = item
                    End If
                Next
            ElseIf Mainform.frmNieuwForm.Name = "FormUpdateItem" Then
                Dim fc As ListBox.ObjectCollection = FormUpdateItem.ListBoxB2B.Items
                For Each item As DAItems In fc.OfType(Of DAItems).ToList()
                    If item.ItemName.ToLower().Contains(TextBoxSearch.Text.ToLower()) Then
                        FormUpdateItem.ListBoxB2B.SelectedItem = item
                    End If
                Next
            End If
        End If
        Me.Close()
    End Sub

    Private Sub TextBoxSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxSearch.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub
End Class