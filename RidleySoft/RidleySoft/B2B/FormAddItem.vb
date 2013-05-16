Public Class FormAddItem
    Private intHeadSubMenuID As Integer
    Private intItemMenuClicked As Integer
    Private radiobutton As RadioButton
    Private strItemmenuname As String
    Private strmod As String
    Private strDES As String
    Private strDBGRPDESC As String
    Private strItemNR As String
    Private strButtongeklikt As String
    Private blnOk As Boolean
    Private intMaxID As Integer
    Private Sub FormAddItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Translate.LoadLanguage(Me)
        Me.FormBorderStyle = Forms.FormBorderStyle.None
        Panel1.Size = New Size(905, 500)
        Panel2.Size = New Size(905, 500)
        Panel3.Size = New Size(905, 500)
        Label1.BackColor = Color.Lavender
        Panel2.Hide()
        Panel3.Hide()
        Panel4.Hide()
    End Sub

    Private Sub ButtonFrame_Click(sender As Object, e As EventArgs) Handles ButtonFrame.Click
        strButtongeklikt = "frame"
        Dim daHeadSubMenu As DAHeadSubMenu = New DAHeadSubMenu()
        intHeadSubMenuID = daHeadSubMenu.getHeadSubmenuIDByButtonClicked(ButtonFrame.Tag)
        Panel2.Hide()
        Panel3.Location = Panel1.Location
        Label1.BackColor = MainForm.BackColor
        Label2.BackColor = MainForm.BackColor
        Label3.BackColor = Color.Lavender
        Panel3.Show()

        Dim daTypeMenu As DATypeMenu = New DATypeMenu()
        Dim typemenus As List(Of DATypeMenu) = daTypeMenu.getTypeById(intHeadSubMenuID)
        Dim y As Integer = 10
        For Each item In typemenus

            radiobutton = New RadioButton()
            AddHandler radiobutton.CheckedChanged, AddressOf radiobuttonKlik
            radiobutton.Tag = item.TypeMenuID
            radiobutton.Text = item.TypeMenuName
            radiobutton.Font = New Font("Microsoft Sans Serif", 15)
            radiobutton.Width = 500
            radiobutton.Location = New Point(15, y)
            radiobutton.Height = 40
            GroupBox1.Controls.Add(radiobutton)
            y += 35
        Next

        LabelPanel3.Text = "Frame"
    End Sub

    Private Sub ButtonBike_Click(sender As Object, e As EventArgs) Handles ButtonBike.Click
        Dim daHeadSubMenu As DAHeadSubMenu = New DAHeadSubMenu()
        intHeadSubMenuID = daHeadSubMenu.getHeadSubmenuIDByButtonClicked(ButtonBike.Tag)

        Panel1.Hide()
        Panel2.Location = Panel1.Location
        Label1.BackColor = MainForm.BackColor
        Label2.BackColor = Color.Lavender
        Panel2.Show()
    End Sub

    Private Sub ButtonCollectie_Click(sender As Object, e As EventArgs) Handles ButtonCollectie.Click
        strButtongeklikt = "collectie"
        Panel2.Hide()
        Panel3.Location = Panel1.Location
        Label2.BackColor = MainForm.BackColor
        Label3.BackColor = Color.Lavender
        Panel3.Show()
        LabelPanel3.Text = "Bike/Collectie"
        Dim daTypeMenu As DATypeMenu = New DATypeMenu()
        Dim typemenus As List(Of DATypeMenu) = daTypeMenu.getTypeById(intHeadSubMenuID)
        Dim y As Integer = 10
        For Each item In typemenus

            radiobutton = New RadioButton()
            AddHandler radiobutton.CheckedChanged, AddressOf radiobuttonKlik
            radiobutton.Tag = item.TypeMenuID
            radiobutton.Text = item.TypeMenuName
            radiobutton.Font = New Font("Microsoft Sans Serif", 15)
            radiobutton.Width = 500
            radiobutton.Height = 40
            radiobutton.Location = New Point(15, y)
            GroupBox1.Controls.Add(radiobutton)
            y += 35
        Next
    End Sub

    Private Sub radiobuttonKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim radiobutton2 As RadioButton
        radiobutton2 = CType(sender, RadioButton)
        If radiobutton2.Checked = True Then
            intItemMenuClicked = radiobutton2.Tag
        End If
    End Sub

    Private Sub ButtonActie_Click(sender As Object, e As EventArgs) Handles ButtonActie.Click
        strButtongeklikt = "actie"
        Panel2.Hide()
        Panel3.Location = Panel1.Location
        Label1.BackColor = MainForm.BackColor
        Label2.BackColor = MainForm.BackColor
        Label4.BackColor = Color.Lavender
        Panel4.Show()
        LabelPanel4.Text = "Bike/Actie"
    End Sub

    Private Sub ButtonVolgende_Click(sender As Object, e As EventArgs) Handles ButtonVolgende.Click
        Panel3.Hide()
        Panel4.Location = Panel1.Location
        Label3.BackColor = MainForm.BackColor
        Label4.BackColor = Color.Lavender
        Panel4.Show()
    End Sub

    Private Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click
        If TextBox1.Text = Nothing Then
            If MainForm.StatusStrip1.Visible <> True Then
                MainForm.frmOudeForm.Name = "FormAddItem"
                MainForm.StatusStrip1.Dispose()
                MainForm.StatusStrip1.Items.Clear()
                MainForm.StatusStrip1 = New StatusStrip()
                MainForm.StatusStrip1.Padding = New Padding(10, 10, 0, 0)
                MainForm.ToolStripStatusLabel1.Padding = New Padding(10, 10, 0, 0)
                MainForm.ToolStripStatusLabel1.Text = "Vul een Artikelnummer in aub."
                MainForm.ToolStripStatusLabel1.ForeColor = Color.White
                MainForm.StatusStrip1.BackColor = Color.Red
                MainForm.StatusStrip1.Dock = DockStyle.Top
                MainForm.StatusStrip1.Items.Add(MainForm.ToolStripStatusLabel1)

                For Each frm As Form In My.Application.OpenForms
                    If frm Is Me Then
                        frm.Controls.Add(MainForm.StatusStrip1)
                        MainForm.StatusStrip1.Show()
                    End If
                Next
            End If

        Else
            TextBoxItemMenu.Clear()
            Dim daItemchar As DAItemChars = New DAItemChars()
            Dim itemchar As List(Of DAItemChars) = daItemchar.GetItemInfo(TextBox1.Text)

            'MessageBox.Show(itemmenuname)

            Dim daCountitem As DAItems = New DAItems()
            'Dim Countitem As Integer = daCountitem.getCountValuesByArtikelID(TextBox1.Text)

            Dim item As DAItems = daCountitem.GetItemInfo(TextBox1.Text)
            strmod = Nothing
            strDES = Nothing
            strDBGRPDESC = Nothing
            strItemmenuname = Nothing
            strItemNR = Nothing

            If itemchar.Count = 0 Then
                MainForm.frmOudeForm.Name = "FormAddItem"
                MainForm.StatusStrip1.Dispose()
                MainForm.StatusStrip1 = New StatusStrip()
                MainForm.StatusStrip1.Padding = New Padding(10, 10, 0, 0)
                MainForm.ToolStripStatusLabel1.Padding = New Padding(10, 10, 0, 0)
                MainForm.ToolStripStatusLabel1.Text = "Artikel niet gevonden in Navision."
                MainForm.ToolStripStatusLabel1.ForeColor = Color.White
                MainForm.StatusStrip1.BackColor = Color.Red
                MainForm.StatusStrip1.Dock = DockStyle.Top
                MainForm.StatusStrip1.Items.Add(MainForm.ToolStripStatusLabel1)
                For Each frm As Form In My.Application.OpenForms
                    If frm Is Me Then
                        frm.Controls.Add(MainForm.StatusStrip1)
                        MainForm.StatusStrip1.Show()
                    End If
                Next

            Else
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
                Dim daSetting As DASettings = New DASettings()
                Dim setting As DASettings = daSetting.getImageLink("Image")


                strItemmenuname = (strmod & " " & strDES & " " & strDBGRPDESC)

                Dim daItemMenu As DAItemMenu = New DAItemMenu()
                Dim itemmenu As DAItemMenu = daItemMenu.GetItemInfo(strItemmenuname)

                Dim maxMenuOrder As Integer = daItemMenu.getMaxMenuOrder(intItemMenuClicked)
                MainForm.intMaxMenuOrder2 = (maxMenuOrder + 1)
                Dim maxIDD As Integer = daItemMenu.getMaxID()
                intMaxID = maxIDD


                If item.ItemName <> Nothing Then
                    MainForm.frmOudeForm.Name = "FormAddItem"
                    MainForm.StatusStrip1.Dispose()
                    MainForm.StatusStrip1 = New StatusStrip()
                    MainForm.StatusStrip1.Padding = New Padding(10, 10, 0, 0)
                    MainForm.ToolStripStatusLabel1.Padding = New Padding(10, 10, 0, 0)
                    MainForm.ToolStripStatusLabel1.Text = "Reeds in B2B."
                    MainForm.ToolStripStatusLabel1.ForeColor = Color.White
                    MainForm.StatusStrip1.BackColor = Color.Red

                    For Each frm As Form In My.Application.OpenForms
                        If frm Is Me Then
                            frm.Controls.Add(MainForm.StatusStrip1)
                            MainForm.StatusStrip1.Show()
                        End If
                    Next
                Else

                    If itemmenu.ItemName <> Nothing Then
                        blnOk = True
                        TextBoxItemMenu.Text = strItemmenuname
                        If itemMenuImage.Model <> Nothing Then
                            If itemMenuImage.Image <> "" Then
                                PictureBox1.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(setting.Value & itemMenuImage.Image)))
                                PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
                            End If
                        Else
                            Dim insertImage As DAMenuItemImage = New DAMenuItemImage(strmod, strDES, "")
                            daImage.InsertItemMenu(insertImage)
                            If itemMenuImage.Image <> "" Then
                                PictureBox1.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(setting.Value & itemMenuImage.Image)))
                                PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
                            End If
                        End If
                    Else

                        Dim insertItemmenu As DAItemMenu = New DAItemMenu(intMaxID + 1, strItemmenuname, (MainForm.intMaxMenuOrder2), intItemMenuClicked, "/site/itemmenu", Nothing, 1)

                        If strButtongeklikt = "actie" Then
                            daItemMenu.InsertItemMenuActie(insertItemmenu)
                        Else
                            daItemMenu.InsertItemMenu(insertItemmenu)
                        End If

                        TextBoxItemMenu.Text = insertItemmenu.ItemName
                        blnOk = True
                    End If
                End If
                TextBox1.Clear()
            End If
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            ButtonSearch.Focus()
        End If
    End Sub

    Private Sub ButtonToevoegen_Click(sender As Object, e As EventArgs) Handles ButtonToevoegen.Click
        MainForm.StatusStrip1.Hide()
        If blnOk = True Then
            Dim daItem As DAItems = New DAItems()
            Dim maxItemOrder As Integer = daItem.getMaxItemOrder(MainForm.intMaxMenuOrder2)

            Dim item As DAItems = New DAItems(strItemNR, strItemmenuname, MainForm.intMaxMenuOrder2, (maxItemOrder + 1), 1)
            daItem.InsertItemMenu(item)

            Dim daHeadsubmenuItem As DAHeadSubMenuToTypeItem = New DAHeadSubMenuToTypeItem()

            If strButtongeklikt = "actie" Then
                Dim headsubmenuitemActie As DAHeadSubMenuToTypeItem = New DAHeadSubMenuToTypeItem(0, intHeadSubMenuID, intItemMenuClicked, intMaxID)
                'MessageBox.Show((intHeadSubMenuID & "->" & itemMenuClicked & "->" & maxID).ToString())
                daHeadsubmenuItem.InsertItemMenuActie(headsubmenuitemActie)
            Else
                Dim headsubmenuitemAnders As DAHeadSubMenuToTypeItem = New DAHeadSubMenuToTypeItem(0, intHeadSubMenuID, intItemMenuClicked, intMaxID)
                'MessageBox.Show((intHeadSubMenuID & "->" & itemMenuClicked & "->" & maxID).ToString())
                daHeadsubmenuItem.InsertItemMenu(headsubmenuitemAnders)
            End If

            If MainForm.StatusStrip1.Visible <> True Then
                MainForm.frmOudeForm.Name = "FormAddItem"
                MainForm.StatusStrip1.Dispose()
                MainForm.StatusStrip1 = New StatusStrip()
                MainForm.StatusStrip1.Padding = New Padding(10, 10, 0, 0)
                MainForm.ToolStripStatusLabel1.Padding = New Padding(10, 10, 0, 0)
                MainForm.ToolStripStatusLabel1.Text = "Succesvol toegevoegd."
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
            End If

        End If
    End Sub
End Class