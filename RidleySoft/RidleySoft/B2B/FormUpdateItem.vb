Public Class FormUpdateItem
    Private strItemmenuname As String
    Private strmod As String
    Private strDES As String
    Private strDBGRPDESC As String
    Private strItemNR As String
    Private selecteditem As DAItems
    Private intMaxID As Integer
    Private Sub FormUpdateItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Translate.LoadLanguage(Me)
        Panel1.Hide()
        Listboxvullen()
        comboboxvullen()
        MainForm.FrmOpenForm = Me
        Mainform.frmOudeForm.Name = "FormUpdateItem"
        Mainform.frmverwijderForm.Name = "FormUpdateItem"
        AddHandler MainForm.menuitemSearch.Click, AddressOf searchKlik
        AddHandler MainForm.menuitemFilter.Click, AddressOf filterKlik
        Me.FormBorderStyle = Forms.FormBorderStyle.None
    End Sub

    Private Sub filterKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "FormUpdateItem" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "FormUpdateItem"
        End If
        If Mainform.frmOudeForm.Name = "FormUpdateItem" Or Mainform.frmOudeForm.Name = "" Then
            FilterB2B.TopLevel = True
            FilterB2B.Show()
            Mainform.frmNieuwForm.Name = "FormUpdateItem"
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Private Sub searchKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "FormUpdateItem" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "FormUpdateItem"
        End If
        If Mainform.frmOudeForm.Name = "FormUpdateItem" Or Mainform.frmOudeForm.Name = "" Then
            Mainform.frmNieuwForm.Name = "FormUpdateItem"
            SearchForm.TopLevel = True
            SearchForm.Show()
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Public Sub Listboxvullen()
        ListBoxB2B.Width = 450
        ListBoxB2B.Dock = DockStyle.Left
        ListBoxB2B.Height = (Me.Height - 10)

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

    Private Sub ListBoxB2B_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxB2B.SelectedIndexChanged
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
        strItemmenuname = Nothing
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

        strItemmenuname = (strmod & " " & strDES & " " & strDBGRPDESC)

        Dim daItemMenu As DAItemMenu = New DAItemMenu()
        Dim itemmenu As DAItemMenu = daItemMenu.GetItemByID(item3.ItemMenuID)

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

    Private Sub ButtonWijzigen_Click(sender As Object, e As EventArgs) Handles ButtonWijzigen.Click
        Dim daItemmenu As DAItemMenu = New DAItemMenu()
        Dim itemmenu As DAItemMenu = daItemmenu.GetItemInfo(strItemmenuname)
        Dim maxIDD As Integer = daItemmenu.getMaxID()
        intMaxID = maxIDD

        Dim daItems As DAItems = New DAItems()
        Dim itemShow As Integer

        If RadioButtonItemShowVisible.Checked = True Then
            itemShow = 1
        ElseIf RadioButtonSoldOut.Checked = True Then
            itemShow = 2
        Else
            itemShow = 0
        End If

        Dim visible As Integer

        If RadioButtonVisible.Checked = True Then
            visible = 1
        Else
            visible = 0
        End If

        If itemmenu.ItemMenuID <> 0 Then
            Dim item As DAItems = New DAItems(ListBoxB2B.SelectedValue, TextBoxArtikelNaam.Text, itemmenu.ItemMenuID, 35, itemShow)
            If ComboBox1.SelectedValue = Nothing Then
                daItems.UpdateItemActie(item)
            Else
                daItems.UpdateItem(item)
            End If

        Else
            Dim itemmenu2 As DAItemMenu = daItemmenu.GetItemInfo(TextBoxItemMenuName.Text)
            If itemmenu2.ItemMenuID = 0 Then

                Dim maxMenuOrder As Integer = daItemmenu.getMaxMenuOrder(ComboBox1.SelectedValue)
                Mainform.intMaxMenuOrder2 = (maxMenuOrder + 1)

                Dim url As String

                If TextBoxItemUrl.Text = "" Then
                    url = "/site/itemmenu"
                Else
                    url = TextBoxItemUrl.Text
                End If

                Dim insertItemmenu As DAItemMenu = New DAItemMenu(intMaxID + 1, TextBoxItemMenuName.Text, (MainForm.intMaxMenuOrder2), ComboBox1.SelectedValue, url, TextBoxImage.Text, 1)
                If ComboBox1.SelectedValue = 0 Then
                    daItemmenu.InsertItemMenuActie(insertItemmenu)
                Else
                    daItemmenu.InsertItemMenu(insertItemmenu)
                End If
                Dim maxIDD2 As Integer = daItemmenu.getMaxID()
                intMaxID = maxIDD2
                Dim item2 As DAItems = New DAItems(ListBoxB2B.SelectedValue, TextBoxArtikelNaam.Text, intMaxID, 35, itemShow)
                daItems.UpdateItem(item2)
            Else
                Dim itemmenu3 As DAItemMenu = New DAItemMenu(itemmenu.ItemMenuID, TextBoxItemMenuName.Text, 0, ComboBox1.SelectedValue, TextBoxItemUrl.Text, "", visible)
                Dim item As DAItems = New DAItems(ListBoxB2B.SelectedValue, TextBoxArtikelNaam.Text, intMaxID, 35, itemShow)
                daItems.UpdateItem(item)
                If ComboBox1.SelectedValue = Nothing Then
                    daItemmenu.UpdateItemMenuTypeisNull(itemmenu3)
                Else
                    daItemmenu.UpdateItemMenu(itemmenu3)

                End If
            End If

        End If
        MainForm.frmOudeForm.Name = "FormUpdateItem"
        MainForm.StatusStrip1.Dispose()
        MainForm.StatusStrip1 = New StatusStrip()
        MainForm.StatusStrip1.Padding = New Padding(10, 10, 0, 0)
        MainForm.ToolStripStatusLabel1.Padding = New Padding(0, 0, 0, 0)
        MainForm.ToolStripStatusLabel1.Text = "Succesvol gewijzigd."
        MainForm.ToolStripStatusLabel1.ForeColor = Color.White
        MainForm.StatusStrip1.BackColor = Color.Green
        MainForm.StatusStrip1.Dock = DockStyle.Top
        MainForm.StatusStrip1.Items.Add(MainForm.ToolStripStatusLabel1)


        For Each frm As Form In My.Application.OpenForms
            If frm Is Me Then
                MainForm.StatusStrip1.Show()
                frm.Controls.Add(MainForm.StatusStrip1)
                MainForm.StatusStrip1.Show()
            End If
        Next
    End Sub

    Private Sub FormUpdateItem_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        Mainform.frmOudeForm.Name = "FormUpdateItem"
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