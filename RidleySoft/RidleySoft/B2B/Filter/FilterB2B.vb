Public Class FilterB2B

    Private Sub ButtonFilter_Click(sender As Object, e As EventArgs) Handles ButtonFilter.Click
        listboxOpvullen2
        Mainform.BlnFilter = True

        Dim fc As ListBox.ObjectCollection = FormUpdateItem.ListBoxB2B.Items
        For Each item As DAItems In fc.OfType(Of DAItems).ToList()
            If item.ItemName.ToLower().Contains(TextBoxArtikelNaam.Text.ToLower()) Then
                FormUpdateItem.ListBoxB2B.SelectedItem = item
            End If
        Next
        Me.Close()
    End Sub

    Public Sub comboboxvullen()
        Dim daTypes As DATypeMenu = New DATypeMenu()
        Dim types As List(Of DATypeMenu) = daTypes.getTypes()

        ComboBox1.DataSource = types
        ComboBox1.DisplayMember = "TypeMenuName"
        ComboBox1.ValueMember = "TypeMenuID"
    End Sub

    Public Sub listboxOpvullen2()
        If Mainform.frmOudeForm.Name = "FormUpdateItem" Or Mainform.frmOudeForm.Name = "FormDeleteItem" Or Mainform.frmOudeForm.Name = "" Then
            Dim daItem As DAItems = New DAItems()
            Dim itemShow As Integer

            If RadioButtonItemShowVisible.Checked = True Then
                itemShow = 1
            ElseIf RadioButtonSoldOut.Checked = True Then
                itemShow = 2
            ElseIf RadioButtonItemShowNotVisible.Checked = True Then
                itemShow = 0
            Else
                itemShow = Nothing
            End If

            Dim visible As Integer

            If RadioButtonVisible.Checked = True Then
                visible = 1
            ElseIf RadioButtonNotVisi.Checked = True Then
                visible = 0
            Else
                visible = Nothing
            End If

            Dim Items As List(Of DAItems) = daItem.GetItemsByFilter(TextBoxArtikelNaam.Text, TextBoxItemMenuName.Text, ComboBox1.SelectedText, TextBoxItemUrl.Text, visible, itemShow)

            If Mainform.frmOudeForm.Name = "FormUpdateItem" Then
                FormUpdateItem.ListBoxB2B.DataSource = Items
                FormUpdateItem.ListBoxB2B.DisplayMember = "ItemName"
                FormUpdateItem.ListBoxB2B.ValueMember = "ItemNr"
                Mainform.frmNieuwForm.Name = "FormUpdateItem"
            Else
                FormDeleteItem.ListBoxB2B.DataSource = Items
                FormDeleteItem.ListBoxB2B.DisplayMember = "ItemName"
                FormDeleteItem.ListBoxB2B.ValueMember = "ItemNr"
                Mainform.frmNieuwForm.Name = "FormDeleteItem"
            End If

        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Private Sub FilterB2B_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width, Screen.PrimaryScreen.WorkingArea.Height - Me.Height)
        Translate.LoadLanguage(Me)
        MainForm.FrmOpenForm = Me
        comboboxvullen()
        'RadioButtonVisible.Checked = True
        'RadioButtonItemShowVisible.Checked = True
    End Sub
End Class