Imports System.Reflection
Imports System.Windows.Forms

Public Class FormModule
    Private _dataset As DataSet
    Private _dataset2 As DataSet
    Private _index As Integer
    Public strModule As String
    Public strGroup As String
    Private intComboGroupID As Integer
    Private Sub FormModule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mainform.BlnFilter = False
        _index = 0
        If Mainform.BlnFilter = False Then
            ToonModule(_index)
        Else
            ToonModule2(_index)
        End If
        Listboxvullen()
        Mainform.frmOudeForm.Name = "ModuleToevoegen"
        MainForm.FrmOpenForm = Me
        Comboboxvullen()
        Translate.LoadLanguage(Me)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        AddHandler MainForm.menuitemEerste.Click, AddressOf EersteKlik
        AddHandler MainForm.menuitemVorige.Click, AddressOf VorigeKlik
        AddHandler MainForm.menuitemVolgende.Click, AddressOf VolgendeKlik
        AddHandler MainForm.menuitemLaatste.Click, AddressOf LaatsteKlik
        AddHandler MainForm.menuitemToevoegen.Click, AddressOf ToevoegenKlik
        AddHandler MainForm.menuitemVerwijderen.Click, AddressOf VerwijderenKlik
        AddHandler MainForm.menuitemSearch.Click, AddressOf searchKlik
        AddHandler MainForm.menuitemFilter.Click, AddressOf filterKlik

        For Each frm As Form In My.Application.OpenForms
            If frm IsNot Me Then
                frm.BackColor = Nothing
            End If
        Next
        Me.BackColor = Color.Lavender
    End Sub

    Private Sub filterKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "ModuleToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "ModuleToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "ModuleToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            FilterModule.TopLevel = True
            FilterModule.Show()
            Mainform.frmNieuwForm.Name = "ModuleToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Private Sub searchKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "ModuleToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "ModuleToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "ModuleToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            SearchForm.TopLevel = True
            SearchForm.Show()
            Mainform.frmNieuwForm.Name = "ModuleToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Public Sub Listboxvullen()
        ListBox1.Width = 350
        ListBox1.Dock = DockStyle.Left

        Dim daModule As DAModule = New DAModule()
        Dim modules As List(Of DAModule) = daModule.getModules()


        ListBox1.DataSource = modules
        ListBox1.DisplayMember = "Description"
        ListBox1.ValueMember = "ModuleID"
    End Sub

    Private Function GetDataSetConventional(ByVal list As List(Of DAModule)) As DataSet
        Dim _result As New DataSet()
        _result.Tables.Add("modules")
        _result.Tables("modules").Columns.Add("ModuleID")
        _result.Tables("modules").Columns.Add("Modulename")
        _result.Tables("modules").Columns.Add("GroupID")

        For Each item As DAModule In list
            Dim newRow As DataRow = _
                _result.Tables("modules").NewRow()
            newRow("ModuleID") = item.ModuleID
            newRow("Modulename") = item.Description
            newRow("GroupID") = item.GroupID
            _result.Tables("modules").Rows.Add(newRow)
        Next
        Return _result
    End Function

    Private Function GetDataSetConventional2(ByVal list As List(Of DAGroupModule)) As DataSet
        Dim _result As New DataSet()
        _result.Tables.Add("modules")
        _result.Tables("modules").Columns.Add("ModuleID")
        _result.Tables("modules").Columns.Add("Modulename")
        _result.Tables("modules").Columns.Add("GroupID")

        For Each item As DAGroupModule In list
            Dim newRow As DataRow = _
                _result.Tables("modules").NewRow()
            newRow("ModuleID") = item.ModuleID
            newRow("Modulename") = item.Description
            newRow("GroupID") = item.GroupID
            _result.Tables("modules").Rows.Add(newRow)
        Next
        Return _result
    End Function

    Public Sub Comboboxvullen()
        Dim daGroup As DAGroup = New DAGroup()
        Dim groups As List(Of DAGroup) = daGroup.getGroups()

        ComboBoxGroupname.DataSource = groups
        ComboBoxGroupname.DisplayMember = "GroupName2"
        ComboBoxGroupname.ValueMember = "GroupID2"
    End Sub

    Public Sub ToonModule(ByVal i As Integer)
        MainForm.StatusStrip1.Hide()
        Dim daModules As DAModule = New DAModule()
        Dim modules As List(Of DAModule) = daModules.getModules()

        _dataset = GetDataSetConventional(modules)

        If (_dataset.Tables("modules").Rows(i).RowState <> DataRowState.Deleted) Then
            TextBoxModulename.Text = _dataset.Tables("modules").Rows(i).Field(Of String)("Modulename")
            TextBoxModulename.Tag = _dataset.Tables("modules").Rows(i).Field(Of String)("ModuleID")
            intComboGroupID = _dataset.Tables("modules").Rows(i).Field(Of String)("GroupID")
            ComboBoxGroupname.SelectedValue = intComboGroupID
        Else
            TextBoxModulename.Text = "###"
        End If
    End Sub

    Public Sub ToonModule2(ByVal i As Integer)
        MainForm.StatusStrip1.Hide()
        Dim daModules As DAGroupModule = New DAGroupModule()
        Dim modules As List(Of DAGroupModule) = daModules.getModulesByFilter(strModule, strGroup)

        _dataset = GetDataSetConventional2(modules)

        If i <> 0 Then
            If (_dataset.Tables("modules").Rows(i).RowState <> DataRowState.Deleted) Then
                TextBoxModulename.Text = _dataset.Tables("modules").Rows(i).Field(Of String)("Modulename")
                TextBoxModulename.Tag = _dataset.Tables("modules").Rows(i).Field(Of String)("ModuleID")
                intComboGroupID = _dataset.Tables("modules").Rows(i).Field(Of String)("GroupID")
                ComboBoxGroupname.SelectedValue = intComboGroupID
            Else
                TextBoxModulename.Text = "###"
            End If
        Else
            TextBoxModulename.Text = ""
        End If

    End Sub

    Public Shared Function ConvertToDataTable(Of T)(ByVal list As IList(Of T)) As DataTable
        Dim table As New DataTable()
        Dim fields() As FieldInfo = GetType(T).GetFields()
        For Each field As FieldInfo In fields
            table.Columns.Add(field.Name, field.FieldType)
        Next
        For Each item As T In list
            Dim row As DataRow = table.NewRow()
            For Each field As FieldInfo In fields
                row(field.Name) = field.GetValue(item)
            Next
            table.Rows.Add(row)
        Next
        Return table
    End Function

    Private Sub EersteKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "ModuleToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "ModuleToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "ModuleToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            _index = 0
            If Mainform.BlnFilter = False Then
                ToonModule(_index)
            Else
                ToonModule2(_index)
            End If
            Mainform.frmNieuwForm.Name = "ModuleToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If


    End Sub

    Private Sub VorigeKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "ModuleToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "ModuleToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "ModuleToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            If (_index > 0) Then
                _index -= 1
                If Mainform.BlnFilter = False Then
                    ToonModule(_index)
                Else
                    ToonModule2(_index)
                End If
            End If
            Mainform.frmNieuwForm.Name = "ModuleToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If

    End Sub

    Private Sub VolgendeKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "ModuleToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "ModuleToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "ModuleToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            If (_index < _dataset.Tables("modules").Rows.Count - 1) Then
                _index += 1
                If Mainform.BlnFilter = False Then
                    ToonModule(_index)
                Else
                    ToonModule2(_index)
                End If
            End If
            Mainform.frmNieuwForm.Name = "ModuleToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If

    End Sub

    Private Sub LaatsteKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "ModuleToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "ModuleToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "ModuleToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            _index = _dataset.Tables("modules").Rows.Count - 1
            If Mainform.BlnFilter = False Then
                ToonModule(_index)
            Else
                ToonModule2(_index)
            End If
            Mainform.frmNieuwForm.Name = "ModuleToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If

    End Sub

    Private Sub ToevoegenKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MainForm.StatusStrip1.Hide()
        If Mainform.frmOudeForm.Name <> "ModuleToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "ModuleToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "ModuleToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            ModuleToevoegen.TopLevel = True
            ModuleToevoegen.Show()
            Mainform.frmNieuwForm.Name = "ModuleToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Private Sub ButtonWijzigen_Click(sender As Object, e As EventArgs) Handles ButtonWijzigen.Click
        MainForm.StatusStrip1.Hide()
        If Mainform.frmOudeForm.Name <> "ModuleToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "ModuleToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "ModuleToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            Dim daModule As DAModule = New DAModule()
            Dim modulee As DAModule = New DAModule(TextBoxModulename.Tag, TextBoxModulename.Text, ComboBoxGroupname.SelectedValue)
            daModule.UpdateModule(modulee)
            Mainform.frmNieuwForm.Name = "ModuleToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If
        Listboxvullen()
    End Sub

    Private Sub VerwijderenKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MainForm.StatusStrip1.Hide()
        Dim daModule2 As DAModule = New DAModule()
        Dim moduleCount As Integer = daModule2.getCountModulesByModuleID(TextBoxModulename.Tag)

        If moduleCount = 0 Then
            MainForm.StatusStrip1.Hide()
            Dim strYes As String
            Dim strCaption As String
            Dim strTitle As String
            strCaption = "Bent u zeker dat u dit item wilt verwijderen?"
            strTitle = "Waarschuwing"
            Dim daTranslations As DATranslation = New DATranslation()
            Dim translations As List(Of DATranslation) = daTranslations.getTranslations()

            If (MainForm.strLanguage = "ENG") Then
                For Each translation In translations
                    If strCaption = translation.NLB Then
                        strCaption = translation.ENG
                    ElseIf strTitle = translation.NLB Then
                        strTitle = translation.ENG
                    End If
                Next
            ElseIf (MainForm.strLanguage = "NLB") Then
                For Each translation In translations
                    If strCaption = translation.ENG Then
                        strCaption = translation.NLB
                    ElseIf strTitle = translation.ENG Then
                        strTitle = translation.NLB
                    End If
                Next
            End If

            strYes = MessageBox.Show(strCaption, strTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If strYes = DialogResult.Yes Then
                If Mainform.frmOudeForm.Name <> "ModuleToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
                    Mainform.frmNieuwForm.Name = "ModuleToevoegen"
                End If
                If Mainform.frmOudeForm.Name = "ModuleToevoegen" Or Mainform.frmOudeForm.Name = "" Then
                    Dim daModule As DAModule = New DAModule()
                    daModule.deleteModule(TextBoxModulename.Tag)
                    If (_index > 0) Then
                        _index -= 1
                        If Mainform.BlnFilter = False Then
                            ToonModule(_index)
                        Else
                            ToonModule2(_index)
                        End If
                    Else
                        TextBoxModulename.Text = Nothing
                    End If
                    Mainform.frmNieuwForm.Name = "ModuleToevoegen"
                Else
                    Mainform.frmOudeForm.Close()
                End If
            End If
            If Mainform.BlnFilter = False Then
                ToonModule(_index)
            Else
                ToonModule2(_index)
            End If
        Else
            MainForm.StatusStrip1.Dispose()
            MainForm.StatusStrip1 = New StatusStrip()
            MainForm.ToolStripStatusLabel1.Text = "Dit item kan niet verwijderd worden, er hangt nog een menu aan vast"
            MainForm.ToolStripStatusLabel1.ForeColor = Color.White
            MainForm.StatusStrip1.BackColor = Color.Red
            MainForm.StatusStrip1.Dock = DockStyle.Top
            MainForm.StatusStrip1.Items.Add(MainForm.ToolStripStatusLabel1)

            MainForm.StatusStrip1.Show()
            For Each frm As Form In My.Application.OpenForms
                If frm Is Me Then
                    frm.Controls.Add(MainForm.StatusStrip1)
                End If
            Next
        End If
        Listboxvullen()
    End Sub

    Private Sub FormModule_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        Mainform.frmOudeForm.Name = "ModuleToevoegen"
        For Each frm As Form In My.Application.OpenForms
            If frm IsNot Me Then
                frm.BackColor = Nothing
            End If
        Next
        Me.BackColor = Color.Lavender
        Mainform.BlnFilter = False
        Listboxvullen()
        ControlLayout()
    End Sub

    Private Sub ListBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedValueChanged
        If Mainform.BlnFilter = False Then
            ToonModule(ListBox1.SelectedIndex)
        Else
            ToonModule2(ListBox1.SelectedIndex)
        End If
    End Sub

    Private Sub TextBoxModulename_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxModulename.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            ComboBoxGroupname.Focus()
        End If
    End Sub

    Private Sub ComboBoxGroupname_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBoxGroupname.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            ButtonWijzigen.Focus()
        End If
    End Sub

    Private Sub Splitter1_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles Splitter1.SplitterMoved
        ControlLayout()
    End Sub

    Public Sub ControlLayout()
        Dim width As Integer = ListBox1.Width
        LabelModule.Location = New Point(width + 50, LabelModule.Location.Y)
        LabelGroup.Location = New Point(width + 50, LabelGroup.Location.Y)
        TextBoxModulename.Location = New Point((width + LabelModule.Width) + 70, TextBoxModulename.Location.Y)
        ComboBoxGroupname.Location = New Point((TextBoxModulename.Location.X), ComboBoxGroupname.Location.Y)
        ButtonWijzigen.Location = New Point(width + 50, ButtonWijzigen.Location.Y)
    End Sub

End Class