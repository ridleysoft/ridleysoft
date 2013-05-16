Imports System.Reflection
Imports System.Windows.Forms

Public Class FormGroup
    Private _dataset As DataSet
    Private _dataset2 As DataSet
    Private _index As Integer
    Public strGroup As String

    Private Sub FormGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mainform.BlnFilter = False
        _index = 0
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        If Mainform.BlnFilter = False Then
            ToonGroup(_index)
        Else
            ToonGroup2(_index)
        End If
        Listboxvullen()
        Mainform.frmOudeForm.Name = "GroupToevoegen"
        MainForm.FrmOpenForm = Me
        Translate.LoadLanguage(Me)
        AddHandler MainForm.menuitemEerste.Click, AddressOf EersteKlik
        AddHandler MainForm.menuitemVorige.Click, AddressOf VorigeKlik
        AddHandler MainForm.menuitemVolgende.Click, AddressOf VolgendeKlik
        AddHandler MainForm.menuitemLaatste.Click, AddressOf LaatsteKlik
        AddHandler MainForm.menuitemToevoegen.Click, AddressOf ToevoegenKlik
        AddHandler MainForm.menuitemVerwijderen.Click, AddressOf VerwijderenKlik
        AddHandler MainForm.menuitemSearch.Click, AddressOf searchKlik
        AddHandler MainForm.menuitemFilter.Click, AddressOf filterKlik

        TextBoxGroupname.Select(0, TextBoxGroupname.Text.Length)
        For Each frm As Form In My.Application.OpenForms
            If frm IsNot Me Then
                frm.BackColor = Nothing
            End If
        Next
        Me.BackColor = Color.Lavender
    End Sub

    Private Sub filterKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "GroupToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "GroupToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "GroupToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            FilterGroup.TopLevel = True
            FilterGroup.Show()
            Mainform.frmNieuwForm.Name = "GroupToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Private Sub searchKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "GroupToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "GroupToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "GroupToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            SearchForm.TopLevel = True
            SearchForm.Show()
            Mainform.frmNieuwForm.Name = "GroupToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Public Sub Listboxvullen()
        ListBox1.Width = 350
        ListBox1.Dock = DockStyle.Left

        Dim daGroup As DAGroup = New DAGroup()
        Dim groups As List(Of DAGroup) = daGroup.getGroups()


        ListBox1.DataSource = groups
        ListBox1.DisplayMember = "GroupName2"
        ListBox1.ValueMember = "GroupID2"
    End Sub

    Private Function GetDataSetConventional(ByVal list As List(Of DAGroup)) As DataSet
        Dim _result As New DataSet()
        _result.Tables.Add("groups")
        _result.Tables("groups").Columns.Add("GroupID")
        _result.Tables("groups").Columns.Add("Groupname")

        For Each item As DAGroup In list
            Dim newRow As DataRow = _
                _result.Tables("groups").NewRow()
            newRow("GroupID") = item.GroupID2
            newRow("Groupname") = item.GroupName2
            _result.Tables("groups").Rows.Add(newRow)
        Next
        Return _result
    End Function

    Public Sub ToonGroup(ByVal i As Integer)
        MainForm.StatusStrip1.Hide()
        Dim daGroups As DAGroup = New DAGroup()
        Dim groups As List(Of DAGroup) = daGroups.getGroups()

        _dataset = GetDataSetConventional(groups)

        If (_dataset.Tables("groups").Rows(i).RowState <> DataRowState.Deleted) Then
            Dim savedIndex As Integer = TextBoxGroupname.SelectionStart
            TextBoxGroupname.Text = _dataset.Tables("groups").Rows(i).Field(Of String)("Groupname")
            TextBoxGroupname.SelectionStart = Math.Min(savedIndex, TextBoxGroupname.Text.Length)
            TextBoxGroupname.SelectionLength = 0
            TextBoxGroupname.Tag = _dataset.Tables("groups").Rows(i).Field(Of String)("GroupID")
        Else
            TextBoxGroupname.Text = "###"
        End If
    End Sub

    Public Sub ToonGroup2(ByVal i As Integer)
        MainForm.StatusStrip1.Hide()
        Dim daGroups As DAGroup = New DAGroup()
        Dim groups As List(Of DAGroup) = daGroups.GetGroupsByFilter(strGroup)

        _dataset = GetDataSetConventional(groups)
        If i <> 0 Then
            If (_dataset.Tables("groups").Rows(i).RowState <> DataRowState.Deleted) Then
                Dim savedIndex As Integer = TextBoxGroupname.SelectionStart
                TextBoxGroupname.Text = _dataset.Tables("groups").Rows(i).Field(Of String)("Groupname")
                TextBoxGroupname.SelectionStart = Math.Min(savedIndex, TextBoxGroupname.Text.Length)
                TextBoxGroupname.SelectionLength = 0
                TextBoxGroupname.Tag = _dataset.Tables("groups").Rows(i).Field(Of String)("GroupID")
            Else
                TextBoxGroupname.Text = "###"
            End If
        Else
            TextBoxGroupname.Text = ""
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
        If Mainform.frmOudeForm.Name <> "GroupToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "GroupToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "GroupToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            _index = 0
            If Mainform.BlnFilter = False Then
                ToonGroup(_index)
            Else
                ToonGroup2(_index)
            End If
            Mainform.frmNieuwForm.Name = "GroupToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If

    End Sub

    Private Sub VorigeKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "GroupToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "GroupToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "GroupToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            If (_index > 0) Then
                _index -= 1
                If Mainform.BlnFilter = False Then
                    ToonGroup(_index)
                Else
                    ToonGroup2(_index)
                End If
            End If
            Mainform.frmNieuwForm.Name = "GroupToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If

    End Sub

    Private Sub VolgendeKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "GroupToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "GroupToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "GroupToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            If (_index < _dataset.Tables("groups").Rows.Count - 1) Then
                _index += 1
                If Mainform.BlnFilter = False Then
                    ToonGroup(_index)
                Else
                    ToonGroup2(_index)
                End If
            End If
            Mainform.frmNieuwForm.Name = "GroupToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If

    End Sub

    Private Sub LaatsteKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "GroupToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "GroupToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "GroupToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            _index = _dataset.Tables("groups").Rows.Count - 1
            If Mainform.BlnFilter = False Then
                ToonGroup(_index)
            Else
                ToonGroup2(_index)
            End If
            Mainform.frmNieuwForm.Name = "GroupToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If

    End Sub

    Private Sub ToevoegenKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MainForm.StatusStrip1.Hide()
        If Mainform.frmOudeForm.Name <> "GroupToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "GroupToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "GroupToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            GroupToevoegen.TopLevel = True
            GroupToevoegen.Show()
            Mainform.frmNieuwForm.Name = "GroupToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Private Sub ButtonWijzigen_Click(sender As Object, e As EventArgs) Handles ButtonWijzigen.Click
        MainForm.StatusStrip1.Hide()
        If Mainform.frmOudeForm.Name <> "GroupToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "GroupToevoegen"
        End If
        If Mainform.frmOudeForm.Name = "GroupToevoegen" Or Mainform.frmOudeForm.Name = "" Then
            Dim daGroup As DAGroup = New DAGroup()
            Dim group As DAGroup = New DAGroup(TextBoxGroupname.Tag, TextBoxGroupname.Text)
            daGroup.UpdateGroup(group)
            Mainform.frmNieuwForm.Name = "GroupToevoegen"
        Else
            Mainform.frmOudeForm.Close()
        End If
        Listboxvullen()
    End Sub

    Private Sub VerwijderenKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MainForm.StatusStrip1.Hide()
        Dim daGroup2 As DAGroup = New DAGroup()
        Dim groupCount As Integer = daGroup2.getCountGroupsByGroupID(TextBoxGroupname.Tag)

        If groupCount = 0 Then
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
                If Mainform.frmOudeForm.Name <> "GroupToevoegen" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
                    Mainform.frmNieuwForm.Name = "GroupToevoegen"
                End If
                If Mainform.frmOudeForm.Name = "GroupToevoegen" Or Mainform.frmOudeForm.Name = "" Then
                    Dim daGroup As DAGroup = New DAGroup()
                    daGroup.deleteGroup(TextBoxGroupname.Tag)
                    If (_index > 0) Then
                        _index -= 1
                        If Mainform.BlnFilter = False Then
                            ToonGroup(_index)
                        Else
                            ToonGroup2(_index)
                        End If
                    Else
                        TextBoxGroupname.Text = Nothing
                    End If
                    Mainform.frmNieuwForm.Name = "GroupToevoegen"
                Else
                    Mainform.frmOudeForm.Close()
                End If
            End If
            If Mainform.BlnFilter = False Then
                ToonGroup(_index)
            Else
                ToonGroup2(_index)
            End If
        Else
            MainForm.StatusStrip1.Dispose()
            MainForm.StatusStrip1 = New StatusStrip()
            MainForm.ToolStripStatusLabel1.Text = "Dit item kan niet verwijderd worden, er hangt nog een module aan vast"
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

    Private Sub FormGroup_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        Mainform.frmOudeForm.Name = "GroupToevoegen"
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
            ToonGroup(ListBox1.SelectedIndex)
        Else
            ToonGroup2(ListBox1.SelectedIndex)
        End If
    End Sub

    Private Sub TextBoxGroupname_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxGroupname.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub Splitter1_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles Splitter1.SplitterMoved
        ControlLayout()
    End Sub

    Public Sub ControlLayout()
        Dim width As Integer = ListBox1.Width
        LabelGroup.Location = New Point(width + 50, LabelGroup.Location.Y)
        TextBoxGroupname.Location = New Point((width + LabelGroup.Width) + 70, TextBoxGroupname.Location.Y)
        ButtonWijzigen.Location = New Point(width + 50, ButtonWijzigen.Location.Y)
    End Sub
End Class