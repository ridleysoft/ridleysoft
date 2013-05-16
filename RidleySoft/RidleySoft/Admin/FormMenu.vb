Imports System.Reflection
Imports System.Windows.Forms

Public Class FormMenu
    Private _dataset As DataSet
    Private _dataset2 As DataSet
    Private _index As Integer
    Private intComboModuleID As Integer
    Public strMenu As String
    Public strModule As String

    Private Sub FormMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mainform.BlnFilter = False
        _index = 0
        If Mainform.BlnFilter = False Then
            ToonMenu(_index)
        Else
            ToonMenu2(_index)
        End If
        Listboxvullen()
        Mainform.frmOudeForm.Name = "MenuToevoegen"
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
        If Mainform.frmOudeForm.Name <> "MenuToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "MenuToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "MenuToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            FilterMenu.TopLevel = True
            FilterMenu.Show()
            Mainform.frmNieuwForm.Name = "MenuToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Private Sub searchKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "MenuToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "MenuToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "MenuToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            SearchForm.TopLevel = True
            SearchForm.Show()
            Mainform.frmNieuwForm.Name = "MenuToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Public Sub Listboxvullen()
        ListBox1.Width = 350
        ListBox1.Dock = DockStyle.Left

        Dim daMenu As DAMenu = New DAMenu()
        Dim menus As List(Of DAMenu) = daMenu.getMenus()


        ListBox1.DataSource = menus
        ListBox1.DisplayMember = "Description"
        ListBox1.ValueMember = "MenuID"
    End Sub

    Private Function GetDataSetConventional(ByVal list As List(Of DAMenu)) As DataSet
        Dim _result As New DataSet()
        _result.Tables.Add("menus")
        _result.Tables("menus").Columns.Add("MenuID")
        _result.Tables("menus").Columns.Add("description")
        _result.Tables("menus").Columns.Add("ModuleID")

        For Each item As DAMenu In list
            Dim newRow As DataRow = _
                _result.Tables("menus").NewRow()
            newRow("MenuID") = item.MenuID
            newRow("description") = item.Description
            newRow("ModuleID") = item.ModuleID
            _result.Tables("menus").Rows.Add(newRow)
        Next
        Return _result
    End Function

    Private Function GetDataSetConventional2(ByVal list As List(Of DAMenuMod)) As DataSet
        Dim _result As New DataSet()
        _result.Tables.Add("menus")
        _result.Tables("menus").Columns.Add("MenuID")
        _result.Tables("menus").Columns.Add("description")
        _result.Tables("menus").Columns.Add("ModuleID")

        For Each item As DAMenuMod In list
            Dim newRow As DataRow = _
                _result.Tables("menus").NewRow()
            newRow("MenuID") = item.MenuID
            newRow("description") = item.MenuDescr
            newRow("ModuleID") = item.ModuleID
            _result.Tables("menus").Rows.Add(newRow)
        Next
        Return _result
    End Function

    Public Sub Comboboxvullen()
        Dim daModule As DAModule = New DAModule()
        Dim modules As List(Of DAModule) = daModule.getModules()

        ComboBoxModule.DataSource = modules
        ComboBoxModule.DisplayMember = "description"
        ComboBoxModule.ValueMember = "ModuleID"

    End Sub

    Public Sub ToonMenu(ByVal i As Integer)
        MainForm.StatusStrip1.Hide()
        Dim daMenu As DAMenu = New DAMenu()
        Dim menus As List(Of DAMenu) = daMenu.getMenus()

        _dataset = GetDataSetConventional(menus)

        If (_dataset.Tables("menus").Rows(i).RowState <> DataRowState.Deleted) Then
            TextBoxMenuname.Text = _dataset.Tables("menus").Rows(i).Field(Of String)("description")
            TextBoxMenuname.Tag = _dataset.Tables("menus").Rows(i).Field(Of String)("MenuID")
            intComboModuleID = _dataset.Tables("menus").Rows(i).Field(Of String)("ModuleID")
            ComboBoxModule.SelectedValue = intComboModuleID
        Else
            TextBoxMenuname.Text = "###"
        End If
    End Sub

    Public Sub ToonMenu2(ByVal i As Integer)
        MainForm.StatusStrip1.Hide()
        Dim daMenus As DAMenuMod = New DAMenuMod()
        Dim menus As List(Of DAMenuMod) = daMenus.getMenusByFilter(strMenu, strModule)

        _dataset = GetDataSetConventional2(menus)
        If i <> 0 Then
            If (_dataset.Tables("menus").Rows(i).RowState <> DataRowState.Deleted) Then
                TextBoxMenuname.Text = _dataset.Tables("menus").Rows(i).Field(Of String)("description")
                TextBoxMenuname.Tag = _dataset.Tables("menus").Rows(i).Field(Of String)("MenuID")
                intComboModuleID = _dataset.Tables("menus").Rows(i).Field(Of String)("ModuleID")
                ComboBoxModule.SelectedValue = intComboModuleID
            Else
                TextBoxMenuname.Text = "###"
            End If
        Else
            TextBoxMenuname.Text = ""
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
        If Mainform.frmOudeForm.Name <> "MenuToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "MenuToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "MenuToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            _index = 0
            If Mainform.BlnFilter = False Then
                ToonMenu(_index)
            Else
                ToonMenu2(_index)
            End If
            Mainform.frmNieuwForm.Name = "MenuToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If


    End Sub

    Private Sub VorigeKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "MenuToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "MenuToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "MenuToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            If (_index > 0) Then
                _index -= 1
                If Mainform.BlnFilter = False Then
                    ToonMenu(_index)
                Else
                    ToonMenu2(_index)
                End If
            End If
            Mainform.frmNieuwForm.Name = "MenuToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If

    End Sub

    Private Sub VolgendeKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "MenuToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "MenuToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "MenuToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            If (_index < _dataset.Tables("menus").Rows.Count - 1) Then
                _index += 1
                If Mainform.BlnFilter = False Then
                    ToonMenu(_index)
                Else
                    ToonMenu2(_index)
                End If
            End If
            Mainform.frmNieuwForm.Name = "MenuToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If

    End Sub

    Private Sub LaatsteKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "MenuToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "MenuToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "MenuToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            _index = _dataset.Tables("menus").Rows.Count - 1
            If Mainform.BlnFilter = False Then
                ToonMenu(_index)
            Else
                ToonMenu2(_index)
            End If
            Mainform.frmNieuwForm.Name = "MenuToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If

    End Sub

    Private Sub ToevoegenKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MainForm.StatusStrip1.Hide()
        If Mainform.frmOudeForm.Name <> "MenuToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "MenuToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "MenuToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            MenuToevoegen.TopLevel = True
            MenuToevoegen.Show()
            Mainform.frmNieuwForm.Name = "MenuToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Private Sub ButtonWijzigen_Click(sender As Object, e As EventArgs) Handles ButtonWijzigen.Click
        MainForm.StatusStrip1.Hide()
        If Mainform.frmOudeForm.Name <> "MenuToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "MenuToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "MenuToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            Dim daMenu As DAMenu = New DAMenu()
            Dim menu As DAMenu = New DAMenu(TextBoxMenuname.Tag, TextBoxMenuname.Text, ComboBoxModule.SelectedValue)

            daMenu.UpdateMenu(menu)
            Mainform.frmNieuwForm.Name = "MenuToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If
        Listboxvullen()
    End Sub

    Private Sub VerwijderenKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MainForm.StatusStrip1.Hide()
        Dim daMenu2 As DAMenu = New DAMenu()
        Dim menuCount As Integer = daMenu2.getCountMenusByMenuID(TextBoxMenuname.Tag)

        If menuCount = 0 Then
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
                If Mainform.frmOudeForm.Name <> "MenuToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
                    Mainform.frmNieuwForm.Name = "MenuToevoegen"
                End If
                If Mainform.frmOudeForm.Name = "MenuToevoegen" Or Mainform.frmOudeForm.Name = "" Then
                    Dim daMenu As DAMenu = New DAMenu()
                    daMenu.deleteMenu(TextBoxMenuname.Tag)
                    If (_index > 0) Then
                        _index -= 1
                        If Mainform.BlnFilter = False Then
                            ToonMenu(_index)
                        Else
                            ToonMenu2(_index)
                        End If
                    Else
                        TextBoxMenuname.Text = Nothing
                    End If
                    Mainform.frmNieuwForm.Name = "MenuToevoegen"
                Else
                    Mainform.frmOudeForm.Close()
                End If
            End If
            If Mainform.BlnFilter = False Then
                ToonMenu(_index)
            Else
                ToonMenu2(_index)
            End If
        Else
            MainForm.StatusStrip1.Dispose()
            MainForm.StatusStrip1 = New StatusStrip()
            MainForm.ToolStripStatusLabel1.Text = "Dit item kan niet verwijderd worden, er hangt nog een Submenu aan vast"
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

    Private Sub FormMenu_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        Mainform.frmOudeForm.Name = "MenuToevoegen"
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
            ToonMenu(ListBox1.SelectedIndex)
        Else
            ToonMenu2(ListBox1.SelectedIndex)
        End If
    End Sub

    Private Sub TextBoxMenuname_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxMenuname.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            ComboBoxModule.Focus()
        End If
    End Sub

    Private Sub ComboBoxModule_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBoxModule.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            ButtonWijzigen.Focus()
        End If
    End Sub

    Private Sub Splitter1_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles Splitter1.SplitterMoved
        ControlLayout()
    End Sub

    Public Sub ControlLayout()
        Dim width As Integer = ListBox1.Width
        LabelMenu.Location = New Point(width + 50, LabelMenu.Location.Y)
        LabelModule.Location = New Point(width + 50, LabelModule.Location.Y)
        TextBoxMenuname.Location = New Point((width + LabelMenu.Width) + 70, TextBoxMenuname.Location.Y)
        ComboBoxModule.Location = New Point((TextBoxMenuname.Location.X), ComboBoxModule.Location.Y)
        ButtonWijzigen.Location = New Point(width + 50, ButtonWijzigen.Location.Y)
    End Sub
End Class