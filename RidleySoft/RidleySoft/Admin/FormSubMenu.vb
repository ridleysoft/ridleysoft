Imports System.Reflection
Imports System.Windows.Forms

Public Class FormSubMenu
    Private _dataset As DataSet
    Private _dataset2 As DataSet
    Private _index As Integer
    Private intComboMenuID As Integer
    Public strMenu As String
    Public strSubmenu As String

    Private Sub FormSubMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mainform.BlnFilter = False
        _index = 0
        If Mainform.BlnFilter = False Then
            ToonSubmenu(_index)
        Else
            ToonSubmenu2(_index)
        End If
        Listboxvullen()
        Mainform.frmOudeForm.Name = "SubMenuToevoegen"
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
        If Mainform.frmOudeForm.Name <> "SubMenuToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "SubMenuToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "SubMenuToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            FilterSubmenu.TopLevel = True
            FilterSubmenu.Show()
            Mainform.frmNieuwForm.Name = "SubMenuToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Private Sub searchKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "SubMenuToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "SubMenuToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "SubMenuToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            SearchForm.TopLevel = True
            SearchForm.Show()
            Mainform.frmNieuwForm.Name = "SubMenuToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Public Sub Listboxvullen()
        ListBox1.Width = 350
        ListBox1.Dock = DockStyle.Left

        Dim daSubMenu As DASubmenu = New DASubmenu()
        Dim menus As List(Of DASubmenu) = daSubMenu.getSubMenus()


        ListBox1.DataSource = menus
        ListBox1.DisplayMember = "Description"
        ListBox1.ValueMember = "SubmenuID"
    End Sub

    Private Function GetDataSetConventional(ByVal list As List(Of DASubmenu)) As DataSet
        Dim _result As New DataSet()
        _result.Tables.Add("submenus")
        _result.Tables("submenus").Columns.Add("SubMenuID")
        _result.Tables("submenus").Columns.Add("description")
        _result.Tables("submenus").Columns.Add("MenuID")

        For Each item As DASubmenu In list
            Dim newRow As DataRow = _
                _result.Tables("submenus").NewRow()
            newRow("SubMenuID") = item.SubmenuID
            newRow("description") = item.Description
            newRow("MenuID") = item.MenuID
            _result.Tables("submenus").Rows.Add(newRow)
        Next
        Return _result
    End Function

    Private Function GetDataSetConventional2(ByVal list As List(Of DASubmenuMod)) As DataSet
        Dim _result As New DataSet()
        _result.Tables.Add("submenus")
        _result.Tables("submenus").Columns.Add("SubMenuID")
        _result.Tables("submenus").Columns.Add("description")
        _result.Tables("submenus").Columns.Add("MenuID")

        For Each item As DASubmenuMod In list
            Dim newRow As DataRow = _
                _result.Tables("submenus").NewRow()
            newRow("SubMenuID") = item.submenuID
            newRow("description") = item.submenuDescr
            newRow("MenuID") = item.MenuID
            _result.Tables("submenus").Rows.Add(newRow)
        Next
        Return _result
    End Function

    Public Sub Comboboxvullen()
        Dim daMenu As DAMenu = New DAMenu()
        Dim menus As List(Of DAMenu) = daMenu.getMenusAdmin()

        ComboBoxMenu.DataSource = menus
        ComboBoxMenu.DisplayMember = "description"
        ComboBoxMenu.ValueMember = "MenuID"
    End Sub

    Public Sub ToonSubmenu(ByVal i As Integer)
        Dim daSubMenu As DASubmenu = New DASubmenu()
        Dim submenus As List(Of DASubmenu) = daSubMenu.getSubMenus()

        _dataset = GetDataSetConventional(submenus)

        If (_dataset.Tables("submenus").Rows(i).RowState <> DataRowState.Deleted) Then
            TextBoxSubMenu.Text = _dataset.Tables("submenus").Rows(i).Field(Of String)("description")
            TextBoxSubMenu.Tag = _dataset.Tables("submenus").Rows(i).Field(Of String)("SubMenuID")
            intComboMenuID = _dataset.Tables("submenus").Rows(i).Field(Of String)("MenuID")
            If intComboMenuID <> 0 Then
                ComboBoxMenu.SelectedValue = intComboMenuID
                Dim daSubmenuMod As DASubmenuMod = New DASubmenuMod()
                Dim submenuMod As DASubmenuMod = daSubmenuMod.getModuleByMenuId(intComboMenuID)
            End If
        Else
            TextBoxSubMenu.Text = "###"
        End If
    End Sub

    Public Sub ToonSubmenu2(ByVal i As Integer)
        Dim daSubMenu As DASubmenuMod = New DASubmenuMod()
        Dim submenus As List(Of DASubmenuMod) = daSubMenu.getSubMenusByFilter(strSubmenu, strMenu)

        _dataset = GetDataSetConventional2(submenus)
        If i <> 0 Then
            If (_dataset.Tables("submenus").Rows(i).RowState <> DataRowState.Deleted) Then
                TextBoxSubMenu.Text = _dataset.Tables("submenus").Rows(i).Field(Of String)("description")
                TextBoxSubMenu.Tag = _dataset.Tables("submenus").Rows(i).Field(Of String)("SubMenuID")
                intComboMenuID = _dataset.Tables("submenus").Rows(i).Field(Of String)("MenuID")
                If intComboMenuID <> 0 Then
                    ComboBoxMenu.SelectedValue = intComboMenuID
                    Dim daSubmenuMod As DASubmenuMod = New DASubmenuMod()
                    Dim submenuMod As DASubmenuMod = daSubmenuMod.getModuleByMenuId(intComboMenuID)
                End If
            Else
                TextBoxSubMenu.Text = "###"
            End If
        Else
            TextBoxSubMenu.Text = ""
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
        If Mainform.frmOudeForm.Name <> "SubMenuToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "SubMenuToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "SubMenuToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            _index = 0
            If Mainform.BlnFilter = False Then
                ToonSubmenu(_index)
            Else
                ToonSubmenu2(_index)
            End If
            Mainform.frmNieuwForm.Name = "SubMenuToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If


    End Sub

    Private Sub VorigeKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "SubMenuToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "SubMenuToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "SubMenuToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            If (_index > 0) Then
                _index -= 1
                If Mainform.BlnFilter = False Then
                    ToonSubmenu(_index)
                Else
                    ToonSubmenu2(_index)
                End If
            End If
            Mainform.frmNieuwForm.Name = "SubMenuToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If

    End Sub

    Private Sub VolgendeKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "SubMenuToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "SubMenuToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "SubMenuToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            If (_index < _dataset.Tables("submenus").Rows.Count - 1) Then
                _index += 1
                If Mainform.BlnFilter = False Then
                    ToonSubmenu(_index)
                Else
                    ToonSubmenu2(_index)
                End If
            End If
            Mainform.frmNieuwForm.Name = "SubMenuToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If

    End Sub

    Private Sub LaatsteKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "SubMenuToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "SubMenuToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "SubMenuToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            _index = _dataset.Tables("submenus").Rows.Count - 1
            If Mainform.BlnFilter = False Then
                ToonSubmenu(_index)
            Else
                ToonSubmenu2(_index)
            End If
            Mainform.frmNieuwForm.Name = "SubMenuToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If

    End Sub

    Private Sub ToevoegenKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "SubMenuToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "SubMenuToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "SubMenuToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            SubMenuToevoegen.TopLevel = True
            SubMenuToevoegen.Show()
            Mainform.frmNieuwForm.Name = "SubMenuToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Private Sub ButtonWijzigen_Click(sender As Object, e As EventArgs) Handles ButtonWijzigen.Click
        If Mainform.frmOudeForm.Name <> "SubMenuToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "SubMenuToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "SubMenuToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            Dim daSubMenu As DASubmenu = New DASubmenu()
            Dim subMenu As DASubmenu = New DASubmenu(TextBoxSubMenu.Tag, TextBoxSubMenu.Text, ComboBoxMenu.SelectedValue)

            daSubMenu.UpdateSubMenu(subMenu)
            Mainform.frmNieuwForm.Name = "SubMenuToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If
        Listboxvullen()
    End Sub

    Private Sub VerwijderenKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
            If Mainform.frmOudeForm.Name <> "SubMenuToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
                Mainform.frmNieuwForm.Name = "SubMenuToevoegen"
            End If
            If Mainform.frmOudeForm.Name = "SubMenuToevoegen" Or Mainform.frmOudeForm.Name = "" Then
                Dim daSubMenu As DASubmenu = New DASubmenu()
                daSubMenu.deleteSubMenu(TextBoxSubMenu.Tag)
                If (_index > 0) Then
                    _index -= 1
                    If Mainform.BlnFilter = False Then
                        ToonSubmenu(_index)
                    Else
                        ToonSubmenu2(_index)
                    End If
                Else
                    TextBoxSubMenu.Text = Nothing
                End If
                Mainform.frmNieuwForm.Name = "SubMenuToevoegen"
            Else
                Mainform.frmOudeForm.Close()
            End If
        End If
        If Mainform.BlnFilter = False Then
            ToonSubmenu(_index)
        Else
            ToonSubmenu2(_index)
        End If
        Listboxvullen()
    End Sub

    Private Sub FormSubMenu_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        Mainform.frmOudeForm.Name = "SubMenuToevoegen"
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
            ToonSubmenu(ListBox1.SelectedIndex)
        Else
            ToonSubmenu2(ListBox1.SelectedIndex)
        End If
    End Sub

    Private Sub TextBoxSubMenu_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxSubMenu.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            ComboBoxMenu.Focus()
        End If
    End Sub

    Private Sub ComboBoxMenu_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBoxMenu.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            ButtonWijzigen.Focus()
        End If
    End Sub

    Private Sub Splitter1_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles Splitter1.SplitterMoved
        ControlLayout()
    End Sub

    Public Sub ControlLayout()
        Dim width As Integer = ListBox1.Width
        LabelSubMenu.Location = New Point(width + 50, LabelSubMenu.Location.Y)
        LabelMenu.Location = New Point(width + 50, LabelMenu.Location.Y)
        TextBoxSubMenu.Location = New Point((width + LabelSubMenu.Width) + 70, TextBoxSubMenu.Location.Y)
        ComboBoxMenu.Location = New Point((TextBoxSubMenu.Location.X), ComboBoxMenu.Location.Y)
        ButtonWijzigen.Location = New Point(width + 50, ButtonWijzigen.Location.Y)
    End Sub
End Class