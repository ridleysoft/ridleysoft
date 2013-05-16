Public Class MenuToevoegen
    Private Sub ButtonToevoegen_Click(sender As Object, e As EventArgs) Handles ButtonToevoegen.Click
        If TextBoxMenuname.Text <> Nothing Then
            Dim daMenus As DAMenu = New DAMenu()
            Dim menus As List(Of DAMenu) = daMenus.getMenus()

            Dim daMenu As DAMenu = New DAMenu()
            Dim menuu As DAMenu = New DAMenu((menus.Count + 1), TextBoxMenuname.Text, ComboBoxModule.SelectedValue)

            daMenu.InsertMenu(menuu)
            Dim menuID As Integer = daMenu.getMaxMenuID()
            Dim daMenuModule As DAMenuMod = New DAMenuMod()
            Dim menuuModule As DAMenuMod = New DAMenuMod(menuID, ComboBoxModule.SelectedValue, "", "")
            daMenuModule.InsertMenuModule(menuuModule)

            FormMenu.ToonMenu(menus.Count)
            FormMenu.Listboxvullen()
            Me.Close()
            MainForm.StatusStrip1.Dispose()
            Mainform.frmOudeForm.Name = "MenuToevoegen"
            MainForm.StatusStrip1 = New StatusStrip()
            MainForm.ToolStripStatusLabel1.Text = "Succesvol toegevoegd"
            MainForm.ToolStripStatusLabel1.ForeColor = Color.White
            MainForm.StatusStrip1.BackColor = Color.Green
            MainForm.StatusStrip1.Dock = DockStyle.Top
            MainForm.StatusStrip1.Items.Add(MainForm.ToolStripStatusLabel1)
            MainForm.StatusStrip1.Show()
            For Each frm As Form In My.Application.OpenForms
                If frm Is FormMenu Then
                    frm.Controls.Add(MainForm.StatusStrip1)
                End If
            Next


        End If
    End Sub

    Private Sub MenuToevoegen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Comboboxvullen()
        Translate.LoadLanguage(Me)
        MainForm.FrmOpenForm = Me
    End Sub


    Public Sub Comboboxvullen()
        Dim daModule As DAModule = New DAModule()
        Dim modules As List(Of DAModule) = daModule.getModules()

        ComboBoxModule.DataSource = modules
        ComboBoxModule.DisplayMember = "description"
        ComboBoxModule.ValueMember = "ModuleID"

    End Sub

    Private Sub MenuToevoegen_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            ComboBoxModule.Focus()
        End If
    End Sub

    Private Sub ComboBoxModule_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBoxModule.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            ButtonToevoegen.Focus()
        End If
    End Sub
End Class