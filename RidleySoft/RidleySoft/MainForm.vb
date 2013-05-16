Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Configuration
Imports System.Data.SqlClient
Imports RidleySoft.WindowsLogin
Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient

Public Class MainForm
    Inherits Form
    Private intTimerI As Integer
    Public FrmOpenForm As Form
    Private intButtongeklikt As Integer
    Private nodeClicked As TreeNode
    Private alles As List(Of DAAllesOphalen)
    Private daAlles As DAAllesOphalen
    Private treenode As TreeNode

    Public menustrip As MenuStrip
    Public menustrip2 As MenuStrip
    Public menuitemPrint As ToolStripMenuItem
    Public menuitemCopy As ToolStripMenuItem
    Public menuitemCut As ToolStripMenuItem
    Public menuitemPaste As ToolStripMenuItem
    Public menuitemEerste As ToolStripMenuItem
    Public menuitemVolgende As ToolStripMenuItem
    Public menuitemVorige As ToolStripMenuItem
    Public menuitemLaatste As ToolStripMenuItem
    Public menuitemToevoegen As ToolStripMenuItem
    Public menuitemVerwijderen As ToolStripMenuItem
    Public menuitemBewerken As ToolStripMenuItem
    Public menuitemAdmin As ToolStripMenuItem
    Public menuitemSearch As ToolStripMenuItem
    Public menuitemFilter As ToolStripMenuItem

    Public menuitemUser As ToolStripMenuItem
    Public menuitemRight As ToolStripMenuItem
    Public menuitemUserRight As ToolStripMenuItem
    Public menuitemGroup As ToolStripMenuItem
    Public menuitemModule As ToolStripMenuItem
    Public menuitemMenu As ToolStripMenuItem
    Public menuitemUsersModules As ToolStripMenuItem
    Public menuitemSubmenu As ToolStripMenuItem
    Public menuitemSettings As ToolStripMenuItem
    Public menuitemHelpFiles As ToolStripMenuItem

    Public BlnFilter As Boolean

    Public clickedForm As ToolStripMenuItem
    Public strLanguage As String
    Public frmOudeForm As Form
    Public frmNieuwForm As Form
    Public frmverwijderForm As Form
    Public frmNieuweverwijderForm As Form
    Public toolStripStatusLabel As ToolStripStatusLabel
    Public statusStrip As StatusStrip
    Private flowLayoutPanel As FlowLayoutPanel = New FlowLayoutPanel()
    Private blnOpen As Boolean

    Public starttijd As DateTime
    Public stoptijd As DateTime
    Public strRfid As String
    Public strPRB As String
    Public intReasonID As Integer
    Public intMaxMenuOrder2 As Integer


    Public defaultPrinter
    Protected connections As List(Of String)
    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Private Sub ButtonKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        intButtongeklikt = CType(sender, Button).Tag

        TreeView1.Nodes.Clear()

        daAlles = New DAAllesOphalen()
        alles = daAlles.getAllesByUserId(2)

        Dim old_moduleID As Integer

        old_moduleID = 0

        Dim daModules As DAGroupModule = New DAGroupModule()

        Dim groupModules As List(Of DAGroupModule) = daModules.getModulesById(intButtongeklikt)

        Dim daTranslations As DATranslation = New DATranslation()
        Dim translations As List(Of DATranslation) = daTranslations.getTranslations()

        Dim imagelist1 As ImageList
        imagelist1 = New ImageList()
        imagelist1.Images.Add(System.Drawing.Image.FromFile(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images\folder.png")))
        imagelist1.Images.Add(System.Drawing.Image.FromFile(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images\list.png")))
        imagelist1.Images.Add(System.Drawing.Image.FromFile(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images\report.png")))
        imagelist1.Images.Add(System.Drawing.Image.FromFile(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images\selected.png")))

        For Each groupModule In groupModules
            TreeView1.ImageList = imagelist1
            treenode = New TreeNode()
            treenode.Tag = groupModule.ModuleID
            treenode.Text = groupModule.Description
            treenode.ImageIndex = 0
            TreeView1.Nodes.Add(treenode)

            For Each translation In translations
                If treenode.Text = translation.NLB Then
                    treenode.Text = translation.ENG
                End If
            Next

            Dim daMenus As DAMenu = New DAMenu()

            Dim menus As List(Of DAMenu) = daMenus.getMenusByModuleId(groupModule.ModuleID)

            For Each menuu In menus
                Dim treenode2 As TreeNode
                treenode2 = New TreeNode()
                treenode2.Tag = menuu.MenuID
                treenode2.Text = menuu.Description
                treenode2.ImageIndex = 1
                treenode.Nodes.Add(treenode2)

                If (strLanguage = "ENG") Then
                    For Each translation In translations
                        If treenode2.Text = translation.NLB Then
                            treenode2.Text = translation.ENG
                        End If
                    Next
                ElseIf (strLanguage = "NLB") Then
                    For Each translation In translations
                        If treenode2.Text = translation.ENG Then
                            treenode2.Text = translation.NLB
                        End If
                    Next
                End If

                Dim daSubmenus As DASubmenu = New DASubmenu()

                Dim submenus As List(Of DASubmenu) = daSubmenus.getSubMenusByMenuId(menuu.MenuID)
                For Each submenu In submenus
                    Dim treenode3 As TreeNode
                    treenode3 = New TreeNode()
                    treenode3.Tag = submenu.SubmenuID
                    treenode3.Text = submenu.Description
                    treenode3.ImageIndex = 1
                    treenode2.Nodes.Add(treenode3)

                    If (strLanguage = "ENG") Then
                        For Each translation In translations
                            If treenode3.Text = translation.NLB Then
                                treenode3.Text = translation.ENG
                            End If
                        Next
                    ElseIf (strLanguage = "NLB") Then
                        For Each translation In translations
                            If treenode3.Text = translation.ENG Then
                                treenode3.Text = translation.NLB
                            End If
                        Next
                    End If
                Next
            Next
        Next
    End Sub

    Private Sub MainForm_Closed(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        PrinterManager.SetDefaultPrinter(defaultPrinter)

        Application.Exit()
        Kill(Application.StartupPath & "\ResizedImages\*.*")
    End Sub



    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LayoutMainForm()
            statusStrip = New StatusStrip()
            toolStripStatusLabel = New ToolStripStatusLabel()
            ToolStripStatusLabel1.Text = "Succesvol toegevoegd"
            StatusStrip1.Hide()
            StatusStrip1.BackColor = Color.Green
            Me.AutoSize = True
            WindowsLogin.Get_User_Name()
            If WindowsLogin.UserID = Nothing Then
                MessageBox.Show("Contacteer de IT afdeling om een account aan te maken.")
                Application.Exit()
                Me.Close()
            Else
                Try
                    Dim daSettings As DASettings = New DASettings()
                    Dim setting As DASettings = daSettings.getLanguageByUserId(WindowsLogin.UserID)

                    strLanguage = setting.Value
                Catch ex As Exception
                    MessageBox.Show("Language moet nog ingesteld worden.")
                End Try
                
            End If

            strRfid = Nothing

            Me.SplitContainer2.Panel2.Controls.Add(flowLayoutPanel)
            flowLayoutPanel.Dock = DockStyle.Fill

            frmverwijderForm = New Form()
            frmNieuweverwijderForm = New Form()
            frmverwijderForm.Name = "leeg"

            frmOudeForm = New Form()
            frmNieuwForm = New Form()
            frmOudeForm.Name = "leeg"
            FrmOpenForm = New Form()
            Me.WindowState = FormWindowState.Minimized
            Laden()
            menuItem()
            LoadLanguage()
            AddHandler PrintDocument1.PrintPage, AddressOf Me.printDocument1_PrintPage
            Me.PrintPreviewDialog1.Document = Me.PrintDocument1

            'timer opmaak
            Timer1.Interval = 500
            intTimerI = 0
            Timer1.Enabled = True
            Timer1.Start()
        Catch ex As Exception
            MessageBox.Show("Make sure you have a working internet connection")
        End Try
    End Sub

    Public Sub menuItem()

        menustrip = New MenuStrip()
        Dim menuitemBestand As ToolStripMenuItem = New ToolStripMenuItem()
        menustrip.Dock = DockStyle.Top
        Me.Controls.Add(menustrip)

        'Bestand
        menuitemBestand.Text = "Bestand"
        menustrip.Items.Add(menuitemBestand)
        AddHandler menuitemBestand.Click, AddressOf BestandKlik

        'Printen
        Dim menuitemPrint As ToolStripMenuItem = New ToolStripMenuItem()
        menuitemPrint.Text = "Printen"
        menuitemBestand.DropDownItems.Add(menuitemPrint)
        AddHandler menuitemPrint.Click, AddressOf PrintKlik

        'Bewerken
        menuitemBewerken = New ToolStripMenuItem()
        menuitemBewerken.Text = "Bewerken"
        menustrip.Items.Add(menuitemBewerken)
        AddHandler menuitemBewerken.Click, AddressOf BewerkenKlik

        'Knippen
        Dim menuitemKnippen As ToolStripMenuItem = New ToolStripMenuItem()
        menuitemKnippen.Text = "Knippen"
        menuitemBewerken.DropDownItems.Add(menuitemKnippen)
        AddHandler menuitemPrint.Click, AddressOf KnipKlik

        'Kopiëren
        Dim menuitemCopy As ToolStripMenuItem = New ToolStripMenuItem()
        menuitemCopy.Text = "Kopiëren"
        menuitemBewerken.DropDownItems.Add(menuitemCopy)
        AddHandler menuitemPrint.Click, AddressOf CopyKlik

        'Plakken
        Dim menuitemPaste As ToolStripMenuItem = New ToolStripMenuItem()
        menuitemPaste.Text = "Plakken"
        menuitemBewerken.DropDownItems.Add(menuitemPaste)
        AddHandler menuitemPrint.Click, AddressOf PasteKlik

        WindowsLogin.Get_User_Name()
        If WindowsLogin.RightID = 1 Then
            'Admin
            menuitemAdmin = New ToolStripMenuItem()
            menuitemAdmin.Text = "Admin"
            Dim old As Padding = menuitemAdmin.Margin
            Dim width1 As Integer
            Dim width2 As Integer
            width1 = SplitContainer1.Panel1.Width
            If strLanguage = "ENG" Then
                width2 = (((width1 - menuitemBestand.Width) - menuitemBewerken.Width) - menuitemAdmin.Width + 50)
            Else
                width2 = (((width1 - menuitemBestand.Width) - menuitemBewerken.Width) - menuitemAdmin.Width)
            End If

            menuitemAdmin.Margin = New Padding(old.Left, old.Top, width2, old.Bottom)
            menustrip.Items.Add(menuitemAdmin)
            AddHandler menuitemAdmin.Click, AddressOf AdminKlik

            'Users beheren
            menuitemUser = New ToolStripMenuItem()
            menuitemUser.Text = "Users beheren"
            menuitemUser.Name = "Users"
            menuitemAdmin.DropDownItems.Add(menuitemUser)
            AddHandler menuitemUser.Click, AddressOf UserKlik

            'UserRechten beheren
            menuitemUserRight = New ToolStripMenuItem()
            menuitemUserRight.Text = "Userrechten beheren"
            menuitemUserRight.Name = "Userrechten"
            menuitemAdmin.DropDownItems.Add(menuitemUserRight)
            AddHandler menuitemUserRight.Click, AddressOf UserRightsKlik

            'Rechten beheren
            menuitemRight = New ToolStripMenuItem()
            menuitemRight.Text = "Rechten beheren"
            menuitemRight.Name = "Rechten"
            menuitemAdmin.DropDownItems.Add(menuitemRight)
            AddHandler menuitemRight.Click, AddressOf RightsKlik

            'Groepen Beheren
            menuitemGroup = New ToolStripMenuItem()
            menuitemGroup.Text = "Groepen beheren"
            menuitemGroup.Name = "Groepen"
            menuitemAdmin.DropDownItems.Add(menuitemGroup)
            AddHandler menuitemGroup.Click, AddressOf GroupKlik

            'Modules beheren
            menuitemModule = New ToolStripMenuItem()
            menuitemModule.Text = "Modules beheren"
            menuitemModule.Name = "Modules"
            menuitemAdmin.DropDownItems.Add(menuitemModule)
            AddHandler menuitemModule.Click, AddressOf ModuleKlik

            'UserModules beheren
            menuitemUsersModules = New ToolStripMenuItem()
            menuitemUsersModules.Text = "Users aan modules linken"
            menuitemUsersModules.Name = "UsersModules"
            menuitemAdmin.DropDownItems.Add(menuitemUsersModules)
            AddHandler menuitemUsersModules.Click, AddressOf UserModuleKlik

            'Menus beheren
            menuitemMenu = New ToolStripMenuItem()
            menuitemMenu.Text = "Menu's beheren"
            menuitemMenu.Name = "Menu's"
            menuitemAdmin.DropDownItems.Add(menuitemMenu)
            AddHandler menuitemMenu.Click, AddressOf MenuKlik

            'SubMenus beheren
            menuitemSubmenu = New ToolStripMenuItem()
            menuitemSubmenu.Text = "Submenu's beheren"
            menuitemSubmenu.Name = "Submenu's"
            menuitemAdmin.DropDownItems.Add(menuitemSubmenu)
            AddHandler menuitemSubmenu.Click, AddressOf SubMenuKlik

            'Settings beheren
            menuitemSettings = New ToolStripMenuItem()
            menuitemSettings.Text = "Settings beheren"
            menuitemSettings.Name = "Settings"
            menuitemAdmin.DropDownItems.Add(menuitemSettings)
            AddHandler menuitemSettings.Click, AddressOf SettingsKlik

            'HelpFiles beheren
            menuitemHelpFiles = New ToolStripMenuItem()
            menuitemHelpFiles.Text = "Helpfiles beheren"
            menuitemHelpFiles.Name = "Helpfiles"
            menuitemAdmin.DropDownItems.Add(menuitemHelpFiles)
            AddHandler menuitemHelpFiles.Click, AddressOf HelpfilesKlik
        End If
        'Printen
        menuitemPrint = New ToolStripMenuItem()
        menuitemPrint.Height = 150
        menuitemPrint.Width = 150
        menuitemPrint.Image = System.Drawing.Image.FromFile(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images\Printer-trans-carousel.gif"))
        MenuStrip1.Items.Add(menuitemPrint)
        AddHandler menuitemPrint.Click, AddressOf PrintKlik

        'Cut
        menuitemCut = New ToolStripMenuItem()
        menuitemCut.Height = 150
        menuitemCut.Width = 150
        menuitemCut.Image = System.Drawing.Image.FromFile(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images\Cut.png"))
        MenuStrip1.Items.Add(menuitemCut)
        AddHandler menuitemCut.Click, AddressOf KnipKlik

        'Copy
        menuitemCopy = New ToolStripMenuItem()
        menuitemCopy.Height = 150
        menuitemCopy.Width = 150
        menuitemCopy.Size = New Size(150, 150)
        menuitemCopy.Image = System.Drawing.Image.FromFile(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images\copy.png"))
        MenuStrip1.Items.Add(menuitemCopy)
        AddHandler menuitemCopy.Click, AddressOf CopyKlik

        'Paste
        menuitemPaste = New ToolStripMenuItem()
        menuitemPaste.Height = 150
        menuitemPaste.Width = 150
        menuitemPaste.Image = System.Drawing.Image.FromFile(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images\paste.png"))
        MenuStrip1.Items.Add(menuitemPaste)
        AddHandler menuitemPaste.Click, AddressOf PasteKlik

        'Eerste
        menuitemEerste = New ToolStripMenuItem()
        menuitemEerste.Image = System.Drawing.Image.FromFile(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images\first.png"))
        MenuStrip1.Items.Add(menuitemEerste)

        'Vorige
        menuitemVorige = New ToolStripMenuItem()
        menuitemVorige.Image = System.Drawing.Image.FromFile(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images\left.png"))
        MenuStrip1.Items.Add(menuitemVorige)

        'Volgende
        menuitemVolgende = New ToolStripMenuItem()
        menuitemVolgende.Image = System.Drawing.Image.FromFile(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images\next.png"))
        MenuStrip1.Items.Add(menuitemVolgende)

        'laatste
        menuitemLaatste = New ToolStripMenuItem()
        menuitemLaatste.Image = System.Drawing.Image.FromFile(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images\last.png"))
        MenuStrip1.Items.Add(menuitemLaatste)

        'Toevoegen
        menuitemToevoegen = New ToolStripMenuItem()
        menuitemToevoegen.Image = System.Drawing.Image.FromFile(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images\add.png"))
        MenuStrip1.Items.Add(menuitemToevoegen)

        'Verwijderen
        menuitemVerwijderen = New ToolStripMenuItem()
        menuitemVerwijderen.Image = System.Drawing.Image.FromFile(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images\delete.png"))
        MenuStrip1.Items.Add(menuitemVerwijderen)

        'Verwijderen
        menuitemSearch = New ToolStripMenuItem()
        menuitemSearch.Image = System.Drawing.Image.FromFile(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images\search.png"))
        MenuStrip1.Items.Add(menuitemSearch)

        'Verwijderen
        menuitemFilter = New ToolStripMenuItem()
        menuitemFilter.Image = System.Drawing.Image.FromFile(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images\filter.png"))
        MenuStrip1.Items.Add(menuitemFilter)
    End Sub

    Private Sub BestandKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        menustrip.Show()
    End Sub

    Private Sub AdminKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        menustrip.Show()
    End Sub

    Private Sub BewerkenKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        menustrip.Show()
    End Sub

    Private Sub FormUser(ByVal sender As System.Object, ByVal e As System.EventArgs)
        blnOpen = False

        Dim test As Form
        test = New Form()
        test = CType(sender, Form)

        'Dim deel1 As String = test.Text.Substring(0, test.Text.Length)

        Dim parts() As String = test.Text.Split(" ".ToCharArray())
        Dim parts2 As List(Of String) = Nothing
        Dim test2 As String = Nothing
        Dim daTranslations As DATranslation = New DATranslation()
        Dim translations As List(Of DATranslation) = daTranslations.getTranslations()


        For i = 0 To parts.GetUpperBound(0) Step 1
            For Each item As ToolStripMenuItem In menuitemAdmin.DropDownItems
                If (strLanguage = "ENG") Then
                    For Each translation In translations
                        If item.Name = translation.NLB Then
                            item.Name = translation.ENG
                        End If
                    Next
                ElseIf (strLanguage = "NLB") Then
                    For Each translation In translations
                        If item.Name = translation.ENG Then
                            item.Name = translation.NLB
                        End If
                    Next
                End If
            Next
            If parts(i) <> "management" And parts(i) <> "linken" And parts(i) <> "en" And parts(i) <> "beheren" Then
                test2 += parts(i)
            End If
        Next i
        For Each item As ToolStripMenuItem In menuitemAdmin.DropDownItems
            If item.Name = test2 Then
                item.Checked = False
            End If
        Next
    End Sub

    Private Sub RightsKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        menuitemRight.Checked = True
        Dim childformRights As Form = New Form()
        childformRights.AutoSize = True
        AddHandler childformRights.FormClosing, AddressOf FormUser

        Dim fc As FormCollection = Application.OpenForms
        For Each frm As Form In fc.OfType(Of Form).ToList()
            If frm Is FormRights Then
                blnOpen = True
            End If
        Next
        If blnOpen = False Then
            Me.IsMdiContainer = True
            childformRights.MdiParent = Me
            childformRights.WindowState = FormWindowState.Maximized
            Me.SplitContainer1.Panel2.Controls.Add(childformRights)
            childformRights.Show()

            FormRights.TopLevel = False
            FormRights.Parent = Me
            FormRights.Dock = DockStyle.Fill
            childformRights.Text = "Rechten beheren"

            Dim daTranslations As DATranslation = New DATranslation()
            Dim translations As List(Of DATranslation) = daTranslations.getTranslations()

            If (strLanguage = "ENG") Then
                For Each translation In translations
                    If childformRights.Text = translation.NLB Then
                        childformRights.Text = translation.ENG
                    End If
                Next
            ElseIf (strLanguage = "NLB") Then
                For Each translation In translations
                    If childformRights.Text = translation.ENG Then
                        childformRights.Text = translation.NLB
                    End If
                Next
            End If
            childformRights.TopMost = True
            FormRights.Height = childformRights.Height
            childformRights.MinimumSize = New Size(805, 299)
            FormRights.WindowState = FormWindowState.Normal
            childformRights.Controls.Add(FormRights)
            FormRights.AutoSize = True
            FormRights.Show()
            FormRights.Focus()
        End If
    End Sub

    Private Sub UserRightsKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        menuitemUserRight.Checked = True
        Dim childformUserRights As Form = New Form()

        childformUserRights.AutoSize = True
        AddHandler childformUserRights.FormClosing, AddressOf FormUser

        Dim fc As FormCollection = Application.OpenForms
        For Each frm As Form In fc.OfType(Of Form).ToList()
            If frm Is FormUserRights Then
                blnOpen = True
            End If
        Next
        If blnOpen = False Then
            Me.IsMdiContainer = True
            childformUserRights.MdiParent = Me
            childformUserRights.WindowState = FormWindowState.Maximized
            Me.SplitContainer1.Panel2.Controls.Add(childformUserRights)
            childformUserRights.Show()

            FormUserRights.TopLevel = False
            FormUserRights.Parent = Me
            FormUserRights.Dock = DockStyle.Fill
            childformUserRights.Text = "Userrechten beheren"

            Dim daTranslations As DATranslation = New DATranslation()
            Dim translations As List(Of DATranslation) = daTranslations.getTranslations()

            If (strLanguage = "ENG") Then
                For Each translation In translations
                    If childformUserRights.Text = translation.NLB Then
                        childformUserRights.Text = translation.ENG
                    End If
                Next
            ElseIf (strLanguage = "NLB") Then
                For Each translation In translations
                    If childformUserRights.Text = translation.ENG Then
                        childformUserRights.Text = translation.NLB
                    End If
                Next
            End If
            childformUserRights.TopMost = True
            FormUserRights.Height = childformUserRights.Height
            childformUserRights.MinimumSize = New Size(1168, 637)
            FormUserRights.WindowState = FormWindowState.Normal
            childformUserRights.Controls.Add(FormUserRights)
            FormUserRights.AutoSize = True
            FormUserRights.Show()
            FormUserRights.Focus()
        End If
    End Sub

    Private Sub UserKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        menuitemUser.Checked = True
        Dim childformUser As Form = New Form()

        AddHandler childformUser.FormClosed, AddressOf FormUser

        Dim fc As FormCollection = Application.OpenForms
        For Each frm As Form In fc.OfType(Of Form).ToList()
            If frm Is AdminFormUser Then
                blnOpen = True
            End If
        Next
        If blnOpen = False Then
            Me.IsMdiContainer = True
            childformUser.MdiParent = Me
            childformUser.WindowState = FormWindowState.Maximized
            childformUser.KeyPreview = True
            Me.SplitContainer1.Panel2.Controls.Add(childformUser)
            childformUser.Show()

            AdminFormUser.TopLevel = False
            AdminFormUser.Parent = Me
            AdminFormUser.Dock = DockStyle.Fill
            AdminFormUser.KeyPreview = True
            childformUser.Text = "Users beheren"

            Dim daTranslations As DATranslation = New DATranslation()
            Dim translations As List(Of DATranslation) = daTranslations.getTranslations()

            If (strLanguage = "ENG") Then
                For Each translation In translations
                    If childformUser.Text = translation.NLB Then
                        childformUser.Text = translation.ENG
                    End If
                Next
            ElseIf (strLanguage = "NLB") Then
                For Each translation In translations
                    If childformUser.Text = translation.ENG Then
                        childformUser.Text = translation.NLB
                    End If
                Next
            End If
            childformUser.AutoSize = True
            AdminFormUser.Height = childformUser.Height
            childformUser.MinimumSize = New Size(661, 289)
            childformUser.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowOnly
            childformUser.Controls.Add(AdminFormUser)
            AdminFormUser.Show()
        End If
    End Sub

    Private Sub GroupKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        menuitemGroup.Checked = True
        Dim childformGroup As Form = New Form()


        clickedForm = New ToolStripMenuItem()
        clickedForm = menuitemGroup

        AddHandler childformGroup.FormClosed, AddressOf FormUser

        Dim fc As FormCollection = Application.OpenForms
        For Each frm As Form In fc.OfType(Of Form).ToList()
            If frm Is FormGroup Then
                blnOpen = True
            End If
        Next
        If blnOpen = False Then
            Me.IsMdiContainer = True
            childformGroup.MdiParent = Me
            childformGroup.WindowState = FormWindowState.Maximized
            childformGroup.KeyPreview = True
            Me.SplitContainer1.Panel2.Controls.Add(childformGroup)
            childformGroup.Show()


            FormGroup.TopLevel = False
            FormGroup.Parent = Me
            FormGroup.Dock = DockStyle.Fill
            FormGroup.KeyPreview = True
            childformGroup.Text = "Groepen beheren"

            Dim daTranslations As DATranslation = New DATranslation()
            Dim translations As List(Of DATranslation) = daTranslations.getTranslations()

            If (strLanguage = "ENG") Then
                For Each translation In translations
                    If childformGroup.Text = translation.NLB Then
                        childformGroup.Text = translation.ENG
                    End If
                Next
            ElseIf (strLanguage = "NLB") Then
                For Each translation In translations
                    If childformGroup.Text = translation.ENG Then
                        childformGroup.Text = translation.NLB
                    End If
                Next
            End If
            childformGroup.TopMost = True
            FormGroup.Height = childformGroup.Height
            childformGroup.MinimumSize = New Size(754, 297)
            FormGroup.WindowState = FormWindowState.Normal
            childformGroup.Controls.Add(FormGroup)
            FormGroup.Show()
        End If
    End Sub

    Private Sub ModuleKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        menuitemModule.Checked = True
        Dim childformModule As Form = New Form()

        AddHandler childformModule.FormClosed, AddressOf FormUser

        Dim fc As FormCollection = Application.OpenForms
        For Each frm As Form In fc.OfType(Of Form).ToList()
            If frm Is FormModule Then
                blnOpen = True
            End If
        Next
        If blnOpen = False Then
            Me.IsMdiContainer = True
            childformModule.MdiParent = Me
            childformModule.WindowState = FormWindowState.Maximized
            Me.SplitContainer1.Panel2.Controls.Add(childformModule)
            childformModule.Show()

            FormModule.TopLevel = False
            FormModule.Parent = Me
            FormModule.Dock = DockStyle.Fill
            childformModule.Text = "Modules beheren"

            Dim daTranslations As DATranslation = New DATranslation()
            Dim translations As List(Of DATranslation) = daTranslations.getTranslations()

            If (strLanguage = "ENG") Then
                For Each translation In translations
                    If childformModule.Text = translation.NLB Then
                        childformModule.Text = translation.ENG
                    End If
                Next
            ElseIf (strLanguage = "NLB") Then
                For Each translation In translations
                    If childformModule.Text = translation.ENG Then
                        childformModule.Text = translation.NLB
                    End If
                Next
            End If
            childformModule.TopMost = True
            FormModule.Height = childformModule.Height
            childformModule.MinimumSize = New Size(808, 291)
            FormModule.WindowState = FormWindowState.Normal
            childformModule.Controls.Add(FormModule)
            FormModule.Show()
        End If
    End Sub

    Private Sub UserModuleKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        menuitemUsersModules.Checked = True
        Dim childformUserModule As Form = New Form()

        AddHandler childformUserModule.FormClosed, AddressOf FormUser

        Dim fc As FormCollection = Application.OpenForms
        For Each frm As Form In fc.OfType(Of Form).ToList()
            If frm Is FormUsersModules Then
                blnOpen = True
            End If
        Next
        If blnOpen = False Then
            Me.IsMdiContainer = True
            childformUserModule.MdiParent = Me
            childformUserModule.WindowState = FormWindowState.Maximized
            Me.SplitContainer1.Panel2.Controls.Add(childformUserModule)
            childformUserModule.Show()

            FormUsersModules.TopLevel = False
            FormUsersModules.Parent = Me
            FormUsersModules.Dock = DockStyle.Fill
            childformUserModule.Text = "Users en Modules linken"

            Dim daTranslations As DATranslation = New DATranslation()
            Dim translations As List(Of DATranslation) = daTranslations.getTranslations()

            If (strLanguage = "ENG") Then
                For Each translation In translations
                    If childformUserModule.Text = translation.NLB Then
                        childformUserModule.Text = translation.ENG
                    End If
                Next
            ElseIf (strLanguage = "NLB") Then
                For Each translation In translations
                    If childformUserModule.Text = translation.ENG Then
                        childformUserModule.Text = translation.NLB
                    End If
                Next
            End If
            FormUsersModules.Height = childformUserModule.Height
            childformUserModule.MinimumSize = New Size(1199, 508)
            FormUsersModules.WindowState = FormWindowState.Normal
            childformUserModule.Controls.Add(FormUsersModules)
            FormUsersModules.Show()
        End If
    End Sub

    Private Sub MenuKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        menuitemMenu.Checked = True
        Dim childformMenu As Form = New Form()

        AddHandler childformMenu.FormClosed, AddressOf FormUser

        Dim fc As FormCollection = Application.OpenForms
        For Each frm As Form In fc.OfType(Of Form).ToList()
            If frm Is FormMenu Then
                blnOpen = True
            End If
        Next
        If blnOpen = False Then
            Me.IsMdiContainer = True
            childformMenu.MdiParent = Me
            childformMenu.WindowState = FormWindowState.Maximized
            Me.SplitContainer1.Panel2.Controls.Add(childformMenu)
            childformMenu.Show()

            FormMenu.TopLevel = False
            FormMenu.Parent = Me
            FormMenu.Dock = DockStyle.Fill
            childformMenu.Text = "Menu's beheren"

            Dim daTranslations As DATranslation = New DATranslation()
            Dim translations As List(Of DATranslation) = daTranslations.getTranslations()

            If (strLanguage = "ENG") Then
                For Each translation In translations
                    If childformMenu.Text = translation.NLB Then
                        childformMenu.Text = translation.ENG
                    End If
                Next
            ElseIf (strLanguage = "NLB") Then
                For Each translation In translations
                    If childformMenu.Text = translation.ENG Then
                        childformMenu.Text = translation.NLB
                    End If
                Next
            End If
            FormMenu.Height = childformMenu.Height
            childformMenu.MinimumSize = New Size(860, 294)
            FormMenu.WindowState = FormWindowState.Normal
            childformMenu.Controls.Add(FormMenu)
            FormMenu.Show()
        End If
    End Sub

    Private Sub SubMenuKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        menuitemSubmenu.Checked = True
        Dim childformSubmenu As Form = New Form()

        AddHandler childformSubmenu.FormClosed, AddressOf FormUser

        Dim fc As FormCollection = Application.OpenForms
        For Each frm As Form In fc.OfType(Of Form).ToList()
            If frm Is FormSubMenu Then
                blnOpen = True
            End If
        Next
        If blnOpen = False Then

            Me.IsMdiContainer = True
            childformSubmenu.MdiParent = Me
            childformSubmenu.WindowState = FormWindowState.Maximized
            Me.SplitContainer1.Panel2.Controls.Add(childformSubmenu)
            childformSubmenu.Show()

            FormSubMenu.TopLevel = False
            FormSubMenu.Parent = Me
            FormSubMenu.Dock = DockStyle.Fill
            childformSubmenu.Text = "Submenu's beheren"

            Dim daTranslations As DATranslation = New DATranslation()
            Dim translations As List(Of DATranslation) = daTranslations.getTranslations()

            If (strLanguage = "ENG") Then
                For Each translation In translations
                    If childformSubmenu.Text = translation.NLB Then
                        childformSubmenu.Text = translation.ENG
                    End If
                Next
            ElseIf (strLanguage = "NLB") Then
                For Each translation In translations
                    If childformSubmenu.Text = translation.ENG Then
                        childformSubmenu.Text = translation.NLB
                    End If
                Next
            End If
            FormSubMenu.Height = childformSubmenu.Height
            childformSubmenu.MinimumSize = New Size(811, 264)
            FormSubMenu.WindowState = FormWindowState.Normal
            childformSubmenu.Controls.Add(FormSubMenu)
            FormSubMenu.Show()
        End If
    End Sub

    Private Sub SettingsKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        menuitemSettings.Checked = True
        Dim childformSettings As Form = New Form()

        AddHandler childformSettings.FormClosing, AddressOf FormUser

        Dim fc As FormCollection = Application.OpenForms
        For Each frm As Form In fc.OfType(Of Form).ToList()
            If frm Is FormSettings Then
                blnOpen = True
            End If
        Next
        If blnOpen = False Then
            Me.IsMdiContainer = True
            childformSettings.MdiParent = Me
            childformSettings.WindowState = FormWindowState.Maximized
            Me.SplitContainer1.Panel2.Controls.Add(childformSettings)
            childformSettings.Show()

            FormSettings.TopLevel = False
            FormSettings.Parent = Me
            FormSettings.Dock = DockStyle.Fill
            childformSettings.Text = "Settings beheren"

            Dim daTranslations As DATranslation = New DATranslation()
            Dim translations As List(Of DATranslation) = daTranslations.getTranslations()

            If (strLanguage = "ENG") Then
                For Each translation In translations
                    If childformSettings.Text = translation.NLB Then
                        childformSettings.Text = translation.ENG
                    End If
                Next
            ElseIf (strLanguage = "NLB") Then
                For Each translation In translations
                    If childformSettings.Text = translation.ENG Then
                        childformSettings.Text = translation.NLB
                    End If
                Next
            End If
            FormSettings.Height = childformSettings.Height
            FormSettings.WindowState = FormWindowState.Normal
            childformSettings.Controls.Add(FormSettings)
            childformSettings.MinimumSize = New Size(904, 470)
            FormSettings.AutoSize = True
            FormSettings.Show()
            FormSettings.Focus()
        End If
    End Sub

    Private Sub HelpfilesKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        menuitemHelpFiles.Checked = True
        Dim childformHelpfiles As Form = New Form()

        AddHandler childformHelpfiles.FormClosing, AddressOf FormUser

        Dim fc As FormCollection = Application.OpenForms
        For Each frm As Form In fc.OfType(Of Form).ToList()
            If frm Is FormHelpFiles Then
                blnOpen = True
            End If
        Next
        If blnOpen = False Then
            Me.IsMdiContainer = True
            childformHelpfiles.MdiParent = Me
            childformHelpfiles.WindowState = FormWindowState.Maximized
            Me.SplitContainer1.Panel2.Controls.Add(childformHelpfiles)
            childformHelpfiles.Show()

            FormHelpFiles.TopLevel = False
            FormHelpFiles.Parent = Me
            FormHelpFiles.Dock = DockStyle.Fill
            childformHelpfiles.Text = "Helpfiles beheren"

            Dim daTranslations As DATranslation = New DATranslation()
            Dim translations As List(Of DATranslation) = daTranslations.getTranslations()

            If (strLanguage = "ENG") Then
                For Each translation In translations
                    If childformHelpfiles.Text = translation.NLB Then
                        childformHelpfiles.Text = translation.ENG
                    End If
                Next
            ElseIf (strLanguage = "NLB") Then
                For Each translation In translations
                    If childformHelpfiles.Text = translation.ENG Then
                        childformHelpfiles.Text = translation.NLB
                    End If
                Next
            End If
            FormHelpFiles.Height = childformHelpfiles.Height
            FormHelpFiles.WindowState = FormWindowState.Normal
            childformHelpfiles.Controls.Add(FormHelpFiles)
            childformHelpfiles.MinimumSize = New Size(904, 470)
            FormHelpFiles.AutoSize = True
            FormHelpFiles.Show()
            FormHelpFiles.Focus()
        End If
    End Sub
    Private Sub LayoutMainForm()
        SplitContainer2.BorderStyle = BorderStyle.Fixed3D
        SplitContainer1.BorderStyle = BorderStyle.Fixed3D
        SplitContainer2.VerticalScroll.Enabled = True
        SplitContainer2.VerticalScroll.Visible = True
        SplitContainer2.HorizontalScroll.Enabled = True
        SplitContainer2.HorizontalScroll.Visible = True
        GroupBox1.Dock = DockStyle.Fill
        TreeView1.Dock = DockStyle.Fill
    End Sub

    Private Sub CopyKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Clipboard.SetText(TextBox1.SelectedText)
    End Sub

    Private Sub KnipKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Clipboard.SetText(TextBox1.SelectedText)
        'TextBox1.SelectedText = ""
    End Sub

    Private Sub PasteKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'TextBox2.SelectedText = Clipboard.GetText
    End Sub

    Private Sub printDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        ' Specify what to print and how to print in this event handler.
        ' The follow code specify a string and a rectangle to be print 

        Dim f As Font = New Font("Times New Roman", 10)
        Dim br As SolidBrush = New SolidBrush(Color.Black)
        Dim p As Pen = New Pen(Color.Black)
        e.Graphics.DrawString("This is a test.", f, br, 50, 50)
        e.Graphics.DrawRectangle(p, 50, 100, 300, 150)
    End Sub

    Private Sub PrintKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.PrintPreviewDialog1.ShowDialog()
    End Sub

    Public Sub PrintDocument()
        Dim printer As New PCPrint()

        printer.PrinterFont = New Font("Verdana", 10)

        'printer.TextToPrint = TextBox1.Text

        printer.Print()
    End Sub

    Public Sub Laden()

        Dim userID As Integer
        userID = WindowsLogin.UserID
        daAlles = New DAAllesOphalen()
        alles = daAlles.getAllesByUserId(userID)

        Dim intI As Integer
        Dim old_groupID As Integer

        old_groupID = 0

        For Each item In alles
            If old_groupID = item.GroupID Then
            Else
                intI += 1
                Dim button(intI) As Button
                button(intI) = New Button()
                button(intI).Tag = item.GroupID
                button(intI).Text = item.GroupName
                button(intI).TextAlign = ContentAlignment.MiddleLeft
                button(intI).Dock = DockStyle.Top
                button(intI).Height = 40
                button(intI).Font = New Font("Microsoft Sans Serif", 10)
                GroupBox1.Controls.Add(button(intI))

                AddHandler button(intI).Click, AddressOf ButtonKlik
                old_groupID = item.GroupID
            End If
        Next
    End Sub

    Public Sub LoadLanguage()
        Dim daTranslations As DATranslation = New DATranslation()
        Dim translations As List(Of DATranslation) = daTranslations.getTranslations()

        For Each item As ToolStripMenuItem In menustrip.Items
            If (strLanguage = "ENG") Then
                For Each translation In translations
                    If item.Text = translation.NLB Then
                        item.Text = translation.ENG
                    End If
                Next
            ElseIf (strLanguage = "NLB") Then
                For Each translation In translations
                    If item.Text = translation.ENG Then
                        item.Text = translation.NLB
                    End If
                Next
            End If

        Next

        For Each item As ToolStripMenuItem In menuitemBewerken.DropDownItems
            If (strLanguage = "ENG") Then
                For Each translation In translations
                    If item.Text = translation.NLB Then
                        item.Text = translation.ENG
                    End If
                Next
            ElseIf (strLanguage = "NLB") Then
                For Each translation In translations
                    If item.Text = translation.ENG Then
                        item.Text = translation.NLB
                    End If
                Next
            End If
        Next
        If WindowsLogin.RightID = 1 Then
            For Each item As ToolStripMenuItem In menuitemAdmin.DropDownItems
                If (strLanguage = "ENG") Then
                    For Each translation In translations
                        If item.Text = translation.NLB Then
                            item.Text = translation.ENG
                        End If
                    Next
                ElseIf (strLanguage = "NLB") Then
                    For Each translation In translations
                        If item.Text = translation.ENG Then
                            item.Text = translation.NLB
                        End If
                    Next
                End If
            Next
        End If
    End Sub

    Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Dim fc As FormCollection = Application.OpenForms
            For Each frm As Form In fc.OfType(Of Form).ToList()
                If frm IsNot Me And frm IsNot SplashScreen1 Then
                    If frm Is FrmOpenForm.Parent Then
                        frm.Close()
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim i As Integer
        i = i + 1

        If (i <> 2) Then
            'While (SplashScreen1.Visible = True)
            LayoutMainForm()
            Me.Visible = True
            Me.WindowState = FormWindowState.Maximized
        End If
        'End While
        Timer1.Stop()
    End Sub

    Private Sub TreeView1_AfterSelect_1(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        Dim daMenu As DAMenu = New DAMenu()
        Dim menus As List(Of DAMenu) = daMenu.getMenusByModuleId(23)
        blnOpen = False
        Dim childformTreenode As Form = New Form()
        Dim treeNoode As TreeNode
        treeNoode = TreeView1.SelectedNode
        nodeClicked = treeNoode
        nodeClicked.SelectedImageIndex = 3
        nodeClicked.Expand()
        AddHandler childformTreenode.FormClosed, AddressOf FormUser

        Dim fc As FormCollection = Application.OpenForms
        For Each frm As Form In fc.OfType(Of Form).ToList()
            If frm Is FormStartProcedure Then
                blnOpen = True
                If treeNoode.Text = "Stop" Then
                    blnOpen = False
                End If
            End If
            If frm Is FormStopProcedure Then
                blnOpen = True
                If treeNoode.Text = "Start" Then
                    blnOpen = False
                End If
            End If
        Next

        If blnOpen = False Then
            Me.IsMdiContainer = True
            childformTreenode.MdiParent = Me
            childformTreenode.WindowState = FormWindowState.Maximized
            childformTreenode.Text = treeNoode.Text
            Me.SplitContainer1.Panel2.Controls.Add(childformTreenode)

            Dim daTranslations As DATranslation = New DATranslation()
            Dim translations As List(Of DATranslation) = daTranslations.getTranslations()

            If (strLanguage = "ENG") Then
                For Each translation In translations
                    If childformTreenode.Text = translation.NLB Then
                        childformTreenode.Text = translation.ENG
                    End If
                Next
            ElseIf (strLanguage = "NLB") Then
                For Each translation In translations
                    If childformTreenode.Text = translation.ENG Then
                        childformTreenode.Text = translation.NLB
                    End If
                Next
            End If

            If treeNoode.Text = "Start" Then
                childformTreenode.Show()
                FormStartProcedure.TopLevel = False
                FormStartProcedure.Parent = Me
                FormStartProcedure.Dock = DockStyle.Fill
                childformTreenode.Text = "Montage: Start Productie"
                FormStartProcedure.TextBox1.Focus()

                childformTreenode.TopMost = True
                FormStartProcedure.Height = childformTreenode.Height
                'childformTreenode.MinimumSize = New Size(808, 291)
                FormStartProcedure.WindowState = FormWindowState.Maximized
                childformTreenode.Controls.Add(FormStartProcedure)
                FormStartProcedure.Show()
            ElseIf treeNoode.Text = "Stop" Then
                childformTreenode.Show()
                FormStopProcedure.TopLevel = False
                FormStopProcedure.Parent = Me
                FormStopProcedure.Dock = DockStyle.Fill
                childformTreenode.Text = "Montage: Stop Productie"

                childformTreenode.TopMost = True
                FormStopProcedure.Height = childformTreenode.Height
                'childformTreenode.MinimumSize = New Size(808, 291)
                FormStopProcedure.WindowState = FormWindowState.Maximized
                childformTreenode.Controls.Add(FormStopProcedure)
                FormStopProcedure.Show()
            ElseIf treeNoode.Text = "Item toevoegen" Then
                childformTreenode.Show()
                FormAddItem.TopLevel = False
                FormAddItem.Parent = Me
                FormAddItem.Dock = DockStyle.Fill
                childformTreenode.Text = "B2B: Item toevoegen"

                childformTreenode.TopMost = True
                FormAddItem.Height = childformTreenode.Height
                'childformTreenode.MinimumSize = New Size(808, 291)
                FormAddItem.WindowState = FormWindowState.Maximized
                childformTreenode.Controls.Add(FormAddItem)
                FormAddItem.Show()
            ElseIf treeNoode.Text = "Item wijzigen" Then
                childformTreenode.Show()
                FormUpdateItem.TopLevel = False
                FormUpdateItem.Parent = Me
                FormUpdateItem.Dock = DockStyle.Fill
                childformTreenode.Text = "B2B: Item Wijzigen"

                childformTreenode.TopMost = True
                FormUpdateItem.Height = childformTreenode.Height
                'childformTreenode.MinimumSize = New Size(808, 291)
                FormUpdateItem.WindowState = FormWindowState.Maximized
                childformTreenode.Controls.Add(FormUpdateItem)
                FormUpdateItem.Show()
            ElseIf treeNoode.Text = "Item verwijderen" Then
                childformTreenode.Show()
                FormDeleteItem.TopLevel = False
                FormDeleteItem.Parent = Me
                FormDeleteItem.Dock = DockStyle.Fill
                childformTreenode.Text = "B2B: Item verwijderen"

                childformTreenode.TopMost = True
                FormDeleteItem.Height = childformTreenode.Height
                'childformTreenode.MinimumSize = New Size(808, 291)
                FormDeleteItem.WindowState = FormWindowState.Maximized
                childformTreenode.Controls.Add(FormDeleteItem)
                FormDeleteItem.Show()
            ElseIf treeNoode.Text = "Items toevoegen vanuit Excel" Then
                childformTreenode.Show()
                FormAddFromExcel.TopLevel = False
                FormAddFromExcel.Parent = Me
                FormAddFromExcel.Dock = DockStyle.Fill
                childformTreenode.Text = "B2B: Item toevoegen vanuit Excel"

                childformTreenode.TopMost = True
                FormAddFromExcel.Height = childformTreenode.Height
                'childformTreenode.MinimumSize = New Size(808, 291)
                FormAddFromExcel.WindowState = FormWindowState.Maximized
                childformTreenode.Controls.Add(FormAddFromExcel)
                FormAddFromExcel.Show()
            ElseIf treeNoode.Text = "Resize images" Then
                childformTreenode.Show()
                FormResizeImages.TopLevel = False
                FormResizeImages.Parent = Me
                FormResizeImages.Dock = DockStyle.Fill
                childformTreenode.Text = "B2B: Resize images"

                childformTreenode.TopMost = True
                FormResizeImages.Height = childformTreenode.Height
                'childformTreenode.MinimumSize = New Size(808, 291)
                FormResizeImages.WindowState = FormWindowState.Maximized
                childformTreenode.Controls.Add(FormResizeImages)
                FormResizeImages.Show()
            ElseIf treeNoode.Text = "Label printen" Then
                childformTreenode.Show()
                FormLabel.TopLevel = False
                FormLabel.Parent = Me
                FormLabel.Dock = DockStyle.Fill
                childformTreenode.Text = "Label printen"

                childformTreenode.TopMost = True
                FormLabel.Height = childformTreenode.Height
                'childformTreenode.MinimumSize = New Size(808, 291)
                FormLabel.WindowState = FormWindowState.Maximized
                childformTreenode.Controls.Add(FormLabel)
                FormLabel.Show()
            ElseIf treeNoode.Text = "Label werknemer" Then
                childformTreenode.Show()
                FormLabelEmployee.TopLevel = False
                FormLabelEmployee.Parent = Me
                FormLabelEmployee.Dock = DockStyle.Fill
                childformTreenode.Text = "Label werknemer"

                childformTreenode.TopMost = True
                FormLabelEmployee.Height = childformTreenode.Height
                'childformTreenode.MinimumSize = New Size(808, 291)
                FormLabelEmployee.WindowState = FormWindowState.Maximized
                childformTreenode.Controls.Add(FormLabelEmployee)
                FormLabelEmployee.Show()
            Else
                Dim blnFrmHelp As Boolean
                blnFrmHelp = True
                Dim fc2 As FormCollection = Application.OpenForms
                For Each frm As Form In fc2.OfType(Of Form).ToList()
                    If frm.Name Is "MainForm" Or frm.Name Is "FormHelp" Or frm.Name Is "" Then
                        If frm.Name Is "FormHelp" Then
                            blnFrmHelp = False
                        End If
                    End If
                Next
                If blnFrmHelp = True Then
                    For Each item In menus
                        If treeNoode.Text = item.Description Then
                            childformTreenode.Show()
                            FormHelp.TopLevel = False
                            FormHelp.Parent = Me
                            FormHelp.Dock = DockStyle.Fill
                            childformTreenode.Text = "Help"

                            childformTreenode.TopMost = True
                            FormHelp.Height = childformTreenode.Height
                            'childformTreenode.MinimumSize = New Size(808, 291)
                            FormHelp.WindowState = FormWindowState.Maximized
                            childformTreenode.Controls.Add(FormHelp)
                            FormHelp.Show()
                        End If
                    Next
                End If


            End If
        End If
    End Sub

    Private Sub TreeView1_DoubleClick(sender As Object, e As EventArgs) Handles TreeView1.DoubleClick
        Dim daMenu As DAMenu = New DAMenu()
        Dim menus As List(Of DAMenu) = daMenu.getMenusByModuleId(23)
        blnOpen = False
        Dim childformTreenode As Form = New Form()
        Dim treeNoode As TreeNode
        treeNoode = TreeView1.SelectedNode
        nodeClicked = treeNoode
        nodeClicked.SelectedImageIndex = 3
        nodeClicked.Expand()
        AddHandler childformTreenode.FormClosed, AddressOf FormUser

        Dim fc As FormCollection = Application.OpenForms
        For Each frm As Form In fc.OfType(Of Form).ToList()
            If frm Is FormStartProcedure Then
                blnOpen = True
                If treeNoode.Text = "Stop" Then
                    blnOpen = False
                End If
            End If
            If frm Is FormStopProcedure Then
                blnOpen = True
                If treeNoode.Text = "Start" Then
                    blnOpen = False
                End If
            End If
        Next

        If blnOpen = False Then
            Me.IsMdiContainer = True
            childformTreenode.MdiParent = Me
            childformTreenode.WindowState = FormWindowState.Maximized
            childformTreenode.Text = treeNoode.Text
            Me.SplitContainer1.Panel2.Controls.Add(childformTreenode)

            Dim daTranslations As DATranslation = New DATranslation()
            Dim translations As List(Of DATranslation) = daTranslations.getTranslations()

            If (strLanguage = "ENG") Then
                For Each translation In translations
                    If childformTreenode.Text = translation.NLB Then
                        childformTreenode.Text = translation.ENG
                    End If
                Next
            ElseIf (strLanguage = "NLB") Then
                For Each translation In translations
                    If childformTreenode.Text = translation.ENG Then
                        childformTreenode.Text = translation.NLB
                    End If
                Next
            End If

            If treeNoode.Text = "Start" Then
                childformTreenode.Show()
                FormStartProcedure.TopLevel = False
                FormStartProcedure.Parent = Me
                FormStartProcedure.Dock = DockStyle.Fill
                childformTreenode.Text = "Montage: Start Productie"

                childformTreenode.TopMost = True
                FormStartProcedure.Height = childformTreenode.Height
                'childformTreenode.MinimumSize = New Size(808, 291)
                FormStartProcedure.WindowState = FormWindowState.Maximized
                childformTreenode.Controls.Add(FormStartProcedure)
                FormStartProcedure.Show()
            ElseIf treeNoode.Text = "Stop" Then
                childformTreenode.Show()
                FormStopProcedure.TopLevel = False
                FormStopProcedure.Parent = Me
                FormStopProcedure.Dock = DockStyle.Fill
                childformTreenode.Text = "Montage: Stop Productie"

                childformTreenode.TopMost = True
                FormStopProcedure.Height = childformTreenode.Height
                'childformTreenode.MinimumSize = New Size(808, 291)
                FormStopProcedure.WindowState = FormWindowState.Maximized
                childformTreenode.Controls.Add(FormStopProcedure)
                FormStopProcedure.Show()
            ElseIf treeNoode.Text = "Item toevoegen" Then
                childformTreenode.Show()
                FormAddItem.TopLevel = False
                FormAddItem.Parent = Me
                FormAddItem.Dock = DockStyle.Fill
                childformTreenode.Text = "B2B: Item toevoegen"

                childformTreenode.TopMost = True
                FormAddItem.Height = childformTreenode.Height
                'childformTreenode.MinimumSize = New Size(808, 291)
                FormAddItem.WindowState = FormWindowState.Maximized
                childformTreenode.Controls.Add(FormAddItem)
                FormAddItem.Show()
            ElseIf treeNoode.Text = "Item wijzigen" Then
                childformTreenode.Show()
                FormUpdateItem.TopLevel = False
                FormUpdateItem.Parent = Me
                FormUpdateItem.Dock = DockStyle.Fill
                childformTreenode.Text = "B2B: Item wijzigen"

                childformTreenode.TopMost = True
                FormUpdateItem.Height = childformTreenode.Height
                'childformTreenode.MinimumSize = New Size(808, 291)
                FormUpdateItem.WindowState = FormWindowState.Maximized
                childformTreenode.Controls.Add(FormUpdateItem)
                FormUpdateItem.Show()
            ElseIf treeNoode.Text = "Item verwijderen" Then
                childformTreenode.Show()
                FormDeleteItem.TopLevel = False
                FormDeleteItem.Parent = Me
                FormDeleteItem.Dock = DockStyle.Fill
                childformTreenode.Text = "B2B: Item verwijderen"

                childformTreenode.TopMost = True
                FormDeleteItem.Height = childformTreenode.Height
                'childformTreenode.MinimumSize = New Size(808, 291)
                FormDeleteItem.WindowState = FormWindowState.Maximized
                childformTreenode.Controls.Add(FormDeleteItem)
                FormDeleteItem.Show()
            ElseIf treeNoode.Text = "Items toevoegen vanuit Excel" Then
                childformTreenode.Show()
                FormAddFromExcel.TopLevel = False
                FormAddFromExcel.Parent = Me
                FormAddFromExcel.Dock = DockStyle.Fill
                childformTreenode.Text = "B2B: Item toevoegen vanuit Excel"

                childformTreenode.TopMost = True
                FormAddFromExcel.Height = childformTreenode.Height
                'childformTreenode.MinimumSize = New Size(808, 291)
                FormAddFromExcel.WindowState = FormWindowState.Maximized
                childformTreenode.Controls.Add(FormAddFromExcel)
                FormAddFromExcel.Show()
            ElseIf treeNoode.Text = "Resize images" Then
                childformTreenode.Show()
                FormResizeImages.TopLevel = False
                FormResizeImages.Parent = Me
                FormResizeImages.Dock = DockStyle.Fill
                childformTreenode.Text = "B2B: Resize images"

                childformTreenode.TopMost = True
                FormResizeImages.Height = childformTreenode.Height
                'childformTreenode.MinimumSize = New Size(808, 291)
                FormResizeImages.WindowState = FormWindowState.Maximized
                childformTreenode.Controls.Add(FormResizeImages)
                FormResizeImages.Show()
            ElseIf treeNoode.Text = "Label printen" Then
                childformTreenode.Show()
                FormLabel.TopLevel = False
                FormLabel.Parent = Me
                FormLabel.Dock = DockStyle.Fill
                childformTreenode.Text = "Label printen"

                childformTreenode.TopMost = True
                FormLabel.Height = childformTreenode.Height
                'childformTreenode.MinimumSize = New Size(808, 291)
                FormLabel.WindowState = FormWindowState.Maximized
                childformTreenode.Controls.Add(FormLabel)
                FormLabel.Show()
            ElseIf treeNoode.Text = "Label werknemer" Then
                childformTreenode.Show()
                FormLabelEmployee.TopLevel = False
                FormLabelEmployee.Parent = Me
                FormLabelEmployee.Dock = DockStyle.Fill
                childformTreenode.Text = "Label werknemer"

                childformTreenode.TopMost = True
                FormLabelEmployee.Height = childformTreenode.Height
                'childformTreenode.MinimumSize = New Size(808, 291)
                FormLabelEmployee.WindowState = FormWindowState.Maximized
                childformTreenode.Controls.Add(FormLabelEmployee)
                FormLabelEmployee.Show()
            Else
                Dim blnFrmHelp As Boolean
                blnFrmHelp = True
                Dim fc2 As FormCollection = Application.OpenForms
                For Each frm As Form In fc2.OfType(Of Form).ToList()
                    If frm.Name Is "MainForm" Or frm.Name Is "FormHelp" Or frm.Name Is "" Then
                        If frm.Name Is "FormHelp" Then
                            blnFrmHelp = False
                        End If
                    End If
                Next
                If blnFrmHelp = True Then
                    For Each item In menus
                        If treeNoode.Text = item.Description Then
                            childformTreenode.Show()
                            FormHelp.TopLevel = False
                            FormHelp.Parent = Me
                            FormHelp.Dock = DockStyle.Fill
                            childformTreenode.Text = "Help"

                            childformTreenode.TopMost = True
                            FormHelp.Height = childformTreenode.Height
                            'childformTreenode.MinimumSize = New Size(808, 291)
                            FormHelp.WindowState = FormWindowState.Maximized
                            childformTreenode.Controls.Add(FormHelp)
                            FormHelp.Show()
                        End If
                    Next
                End If
            End If
        End If
    End Sub
End Class
