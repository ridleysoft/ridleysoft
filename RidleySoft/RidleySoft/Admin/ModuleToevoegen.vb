Public Class ModuleToevoegen

    Private Sub ButtonToevoegen_Click(sender As Object, e As EventArgs) Handles ButtonToevoegen.Click
        Dim damodules As DAModule = New DAModule()
        Dim modules As List(Of DAModule) = damodules.getModules()

        Dim daModule As DAModule = New DAModule()
        Dim modulee As DAModule = New DAModule((modules.Count + 1), TextBoxModulename.Text, ComboBoxGroupname.SelectedValue)

        daModule.InsertModule(modulee)

        FormModule.ToonModule(modules.Count)
        FormModule.Listboxvullen()
        Me.Close()
        MainForm.frmOudeForm.Name = "ModuleToevoegen"
        MainForm.StatusStrip1.Dispose()
        MainForm.StatusStrip1 = New StatusStrip()
        MainForm.ToolStripStatusLabel1.Text = "Succesvol toegevoegd"
        MainForm.ToolStripStatusLabel1.ForeColor = Color.White
        MainForm.StatusStrip1.BackColor = Color.Green
        MainForm.StatusStrip1.Dock = DockStyle.Top
        MainForm.StatusStrip1.Items.Add(MainForm.ToolStripStatusLabel1)
        MainForm.StatusStrip1.Show()
        For Each frm As Form In My.Application.OpenForms
            If frm Is FormModule Then
                frm.Controls.Add(MainForm.StatusStrip1)

            End If
        Next

    End Sub

    Private Sub ModuleToevoegen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Comboboxvullen()
        Translate.LoadLanguage(Me)
        MainForm.FrmOpenForm = Me
    End Sub


    Public Sub Comboboxvullen()
        Dim daGroup As DAGroup = New DAGroup()
        Dim groups As List(Of DAGroup) = daGroup.getGroups()

        ComboBoxGroupname.DataSource = groups
        ComboBoxGroupname.DisplayMember = "GroupName2"
        ComboBoxGroupname.ValueMember = "GroupID2"

    End Sub

    Private Sub ComboBoxGroupname_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBoxGroupname.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            ButtonToevoegen.Focus()
        End If
    End Sub

    Private Sub TextBoxModulename_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxModulename.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            ComboBoxGroupname.Focus()
        End If
    End Sub
End Class