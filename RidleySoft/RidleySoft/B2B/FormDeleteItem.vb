Public Class FormDeleteItem
    Private intItemmenuname As String
    Private strmod As String
    Private strDES As String
    Private strDBGRPDESC As String
    Private strItemNR As String
    Private selecteditem As DAItems
    Private intMaxID As Integer
    Private intItemmenuID As Integer
    Private Sub FormDeleteItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Translate.LoadLanguage(Me)
        AddHandler MainForm.menuitemVerwijderen.Click, AddressOf VerwijderenKlik
        Panel1.Hide()
        Listboxvullen()
        comboboxvullen()
        MainForm.FrmOpenForm = Me
        Mainform.frmOudeForm.Name = "FormDeleteItem"
        Mainform.frmverwijderForm.Name = "FormDeleteItem"
        AddHandler MainForm.menuitemSearch.Click, AddressOf searchKlik
        AddHandler MainForm.menuitemFilter.Click, AddressOf filterKlik
        Me.FormBorderStyle = Forms.FormBorderStyle.None
    End Sub

    Private Sub filterKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "FormDeleteItem" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "FormDeleteItem"
        End If
        If Mainform.frmOudeForm.Name = "FormDeleteItem" Or Mainform.frmOudeForm.Name = "" Then
            FilterB2B.TopLevel = True
            FilterB2B.Show()
            Mainform.frmNieuwForm.Name = "FormDeleteItem"
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Private Sub searchKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "FormDeleteItem" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "FormDeleteItem"
        End If
        If Mainform.frmOudeForm.Name = "FormDeleteItem" Or Mainform.frmOudeForm.Name = "" Then
            Mainform.frmNieuwForm.Name = "FormDeleteItem"
            SearchForm.TopLevel = True
            SearchForm.Show()

        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Private Sub VerwijderenKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim strYes As String
        Dim strCaption As String
        Dim strTitle As String
        strCaption = "Bent u zeker dat u dit item wilt verwijderen?"
        strTitle = "Waarschuwing"

        strYes = MessageBox.Show(strCaption, strTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If strYes = DialogResult.Yes Then
            Dim daitem As DAItems = New DAItems()
            daitem.deleteItem(selecteditem.ItemNr)
            Listboxvullen()
        End If
    End Sub
    Public Sub Listboxvullen()
        ListBoxB2B.Width = 450
        ListBoxB2B.Height = (Me.Height - 10)
        'ListBoxB2B.Dock = DockStyle.Left
        ListBoxB2B.Location = New Point(10, 10)

        Dim daItems As DAItems = New DAItems()
        Dim items As List(Of DAItems) = daItems.GetItems()

        ListBoxB2B.DataSource = items
        ListBoxB2B.DisplayMember = "ItemName"
        ListBoxB2B.ValueMember = "ItemNr"
    End Sub

    Public Sub comboboxvullen()
        Dim daTypes As DATypeMenu = New DATypeMenu()
        Dim types As List(Of DATypeMenu) = daTypes.getTypes()

        ComboBox1.Items.Add("NULL")
        ComboBox1.DataSource = types
        ComboBox1.DisplayMember = "TypeMenuName"
        ComboBox1.ValueMember = "TypeMenuID"
    End Sub

    Private Sub ButtonImage_Click(sender As Object, e As EventArgs) Handles ButtonImage.Click
        Dim daSetting As DASettings = New DASettings()
        Dim setting As DASettings = daSetting.getImageLink("Image")
        Try
            PictureBox1.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(setting.Value & TextBoxImage.Text)))
            Panel1.Show()
        Catch ex As Exception
            MessageBox.Show("Image niet gevonden", "Image niet gevonden", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonClosePanel_Click(sender As Object, e As EventArgs) Handles ButtonClosePanel.Click
        Panel1.Hide()
    End Sub

    Private Sub ListBoxB2B_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ListBoxB2B.SelectedIndexChanged
        Panel1.Hide()
        selecteditem = New DAItems()
        selecteditem = ListBoxB2B.SelectedItem()
        Dim daItemchar As DAItemChars = New DAItemChars()
        Dim itemchar As List(Of DAItemChars) = daItemchar.GetItemInfo(selecteditem.ItemNr)

        Dim daCountitem As DAItems = New DAItems()

        Dim item3 As DAItems = daCountitem.GetItemInfo(selecteditem.ItemNr)
        strmod = Nothing
        strDES = Nothing
        strDBGRPDESC = Nothing
        intItemmenuname = Nothing
        strItemNR = Nothing

        For Each item2 In itemchar
            If item2.Code = "MOD" Then
                strmod = item2.Value
            End If
            If item2.Code = "DES" Then
                strDES = item2.Value
            End If
            If item2.Code = "DB-GRP-DESC" Then
                strDBGRPDESC = item2.Value
            ElseIf item2.Code = "MOR" Then
                strDBGRPDESC = item2.Value
            End If
            strItemNR = item2.ItemNr
        Next
        Dim daImage As DAMenuItemImage = New DAMenuItemImage()
        Dim itemMenuImage As DAMenuItemImage = daImage.getImageByModelDesign(strmod, strDES)

        intItemmenuname = (strmod & " " & strDES & " " & strDBGRPDESC)

        Dim daItemMenu As DAItemMenu = New DAItemMenu()
        Dim itemmenu As DAItemMenu = daItemMenu.GetItemByID(item3.ItemMenuID)
        intItemmenuID = itemmenu.ItemMenuID

        Dim daTypeMenu As DATypeMenu = New DATypeMenu()
        Dim typeMenu As DATypeMenu = daTypeMenu.GetTypeMenu(itemmenu.TypeMenuID)

        TextBoxItemMenuName.Text = itemmenu.ItemName

        ComboBox1.SelectedValue = typeMenu.TypeMenuID
        TextBoxItemUrl.Text = itemmenu.ItemMenuURL

        If itemmenu.ItemVisible = 1 Then
            RadioButtonVisible.Checked = True
            RadioButtonNotVisi.Checked = False
        Else
            RadioButtonVisible.Checked = False
            RadioButtonNotVisi.Checked = True
        End If

        TextBoxImage.Text = itemMenuImage.Image
        TextBoxArtikelNaam.Text = selecteditem.ItemName

        If selecteditem.ItemShow = 1 Then
            RadioButtonItemShowVisible.Checked = True
            RadioButtonItemShowNotVisible.Checked = False
            RadioButtonSoldOut.Checked = False
        ElseIf selecteditem.ItemShow = 2 Then
            RadioButtonItemShowVisible.Checked = False
            RadioButtonItemShowNotVisible.Checked = False
            RadioButtonSoldOut.Checked = True
        Else
            RadioButtonItemShowVisible.Checked = False
            RadioButtonItemShowNotVisible.Checked = True
            RadioButtonSoldOut.Checked = False
        End If

    End Sub

    Private Sub ButtonDeleteItem_Click(sender As Object, e As EventArgs) Handles ButtonDeleteItem.Click
        Dim strYes As String
        Dim strCaption As String
        Dim strTitle As String
        strCaption = "Bent u zeker dat u dit item wilt verwijderen?"
        strTitle = "Waarschuwing"

        strYes = MessageBox.Show(strCaption, strTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If strYes = DialogResult.Yes Then
            Dim daitem As DAItems = New DAItems()
            daitem.deleteItem(selecteditem.ItemNr)
            Listboxvullen()
        End If
    End Sub

    Private Sub ButtonDeleteImage_Click(sender As Object, e As EventArgs) Handles ButtonDeleteImage.Click
        Dim strYes As String
        Dim strCaption As String
        Dim strTitle As String
        strCaption = "Bent u zeker dat u dit item wilt verwijderen?"
        strTitle = "Waarschuwing"

        strYes = MessageBox.Show(strCaption, strTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If strYes = DialogResult.Yes Then
            Dim daimage As DAMenuItemImage = New DAMenuItemImage()
            Dim image As DAMenuItemImage = New DAMenuItemImage(strmod, strDES, "")
            daimage.DeleteImage(image)
        End If

    End Sub

    Private Sub FormDeleteItem_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        Mainform.frmOudeForm.Name = "FormDeleteItem"
        For Each frm As Form In My.Application.OpenForms
            If frm IsNot Me Then
                frm.BackColor = Nothing
            End If
        Next
        Me.BackColor = Color.Lavender
        Mainform.BlnFilter = False
        Listboxvullen()
    End Sub
End Class