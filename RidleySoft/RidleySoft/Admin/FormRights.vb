Imports System.Reflection
Imports System.Windows.Forms

Public Class FormRights
    Private _dataset As DataSet
    Private _dataset2 As DataSet
    Private _index As Integer
    Public strRight As String

    Private Sub FormRights_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mainform.BlnFilter = False
        _index = 0
        If Mainform.BlnFilter = False Then
            ToonRight(_index)
        Else
            ToonRight2(_index)
        End If

        Listboxvullen()
        Mainform.frmOudeForm.Name = "AddRight"

        MainForm.FrmOpenForm = Me
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
        If Mainform.frmOudeForm.Name <> "AddRight" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "AddRight"
        End If
        If Mainform.frmOudeForm.Name = "AddRight" Or Mainform.frmOudeForm.Name = "" Then
            FilterRight.TopLevel = True
            FilterRight.Show()
            Mainform.frmNieuwForm.Name = "AddRight"
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Private Sub searchKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "AddRight" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "AddRight"
        End If
        If Mainform.frmOudeForm.Name = "AddRight" Or Mainform.frmOudeForm.Name = "" Then
            SearchForm.TopLevel = True
            SearchForm.Show()
            Mainform.frmNieuwForm.Name = "AddRight"
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Public Sub Listboxvullen()
        ListBox1.Width = 350
        ListBox1.Dock = DockStyle.Left

        Dim daRight As DARights = New DARights()
        Dim rights As List(Of DARights) = daRight.getRights()

        ListBox1.DataSource = rights
        ListBox1.DisplayMember = "Description"
        ListBox1.ValueMember = "RightID"
    End Sub

    Private Function GetDataSetConventional(ByVal list As List(Of DARights)) As DataSet
        Dim _result As New DataSet()
        _result.Tables.Add("rights")
        _result.Tables("rights").Columns.Add("RightID")
        _result.Tables("rights").Columns.Add("Description")

        For Each item As DARights In list
            Dim newRow As DataRow = _
                _result.Tables("rights").NewRow()
            newRow("RightID") = item.RightID
            newRow("Description") = item.Description
            _result.Tables("rights").Rows.Add(newRow)
        Next
        Return _result
    End Function

    Public Sub ToonRight(ByVal i As Integer)
        MainForm.StatusStrip1.Hide()
        Dim daRights As DARights = New DARights()
        Dim rights As List(Of DARights) = daRights.getRights()

        _dataset = GetDataSetConventional(rights)

        If (_dataset.Tables("rights").Rows(i).RowState <> DataRowState.Deleted) Then
            TextBoxRight.Text = _dataset.Tables("rights").Rows(i).Field(Of String)("Description")
            TextBoxRight.Tag = _dataset.Tables("rights").Rows(i).Field(Of String)("RightID")
        Else
            TextBoxRight.Text = "###"
        End If
    End Sub

    Public Sub ToonRight2(ByVal i As Integer)
        MainForm.StatusStrip1.Hide()

        Dim daRights As DARights = New DARights()
        Dim rights As List(Of DARights) = daRights.GetRightsByFilter(Me.strRight)

        _dataset = GetDataSetConventional(rights)
        If i <> 0 Then
            If (_dataset.Tables("rights").Rows(i).RowState <> DataRowState.Deleted) Then
                TextBoxRight.Text = _dataset.Tables("rights").Rows(i).Field(Of String)("Description")
                TextBoxRight.Tag = _dataset.Tables("rights").Rows(i).Field(Of String)("RightID")
            Else
                TextBoxRight.Text = "###"
            End If
        Else
            TextBoxRight.Text = ""
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
        If Mainform.frmOudeForm.Name <> "AddRight" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "AddRight"
        End If
        If Mainform.frmOudeForm.Name = "AddRight" Or Mainform.frmOudeForm.Name = "" Then
            _index = 0
            If Mainform.BlnFilter = False Then
                ToonRight(_index)
            Else
                ToonRight2(_index)
            End If
            Mainform.frmNieuwForm.Name = "AddRight"
        Else
            Mainform.frmOudeForm.Close()
        End If

    End Sub

    Private Sub VorigeKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "AddRight" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "AddRight"
        End If
        If Mainform.frmOudeForm.Name = "AddRight" Or Mainform.frmOudeForm.Name = "" Then
            If (_index > 0) Then
                _index -= 1
                If Mainform.BlnFilter = False Then
                    ToonRight(_index)
                Else
                    ToonRight2(_index)
                End If
            End If
            Mainform.frmNieuwForm.Name = "AddRight"
        Else
            Mainform.frmOudeForm.Close()
        End If

    End Sub

    Private Sub VolgendeKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "AddRight" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "AddRight"
        End If
        If Mainform.frmOudeForm.Name = "AddRight" Or Mainform.frmOudeForm.Name = "" Then
            If (_index < _dataset.Tables("rights").Rows.Count - 1) Then
                _index += 1
                If Mainform.BlnFilter = False Then
                    ToonRight(_index)
                Else
                    ToonRight2(_index)
                End If
            End If
            Mainform.frmNieuwForm.Name = "AddRight"
        Else
            Mainform.frmOudeForm.Close()
        End If

    End Sub

    Private Sub LaatsteKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Mainform.frmOudeForm.Name <> "AddRight" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "AddRight"
        End If
        If Mainform.frmOudeForm.Name = "AddRight" Or Mainform.frmOudeForm.Name = "" Then
            _index = _dataset.Tables("rights").Rows.Count - 1
            If Mainform.BlnFilter = False Then
                ToonRight(_index)
            Else
                ToonRight2(_index)
            End If
            Mainform.frmNieuwForm.Name = "AddRight"
        Else
            Mainform.frmOudeForm.Close()
        End If

    End Sub

    Private Sub ToevoegenKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MainForm.StatusStrip1.Hide()
        If Mainform.frmOudeForm.Name <> "AddRight" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "AddRight"
        End If
        If Mainform.frmOudeForm.Name = "AddRight" Or Mainform.frmOudeForm.Name = "" Then
            AddRight.TopLevel = True
            AddRight.Show()
            Mainform.frmNieuwForm.Name = "AddRight"
        Else
            Mainform.frmOudeForm.Close()
        End If
    End Sub

    Private Sub ButtonWijzigen_Click(sender As Object, e As EventArgs) Handles ButtonWijzigen.Click
        MainForm.StatusStrip1.Hide()
        If Mainform.frmOudeForm.Name <> "AddRight" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
            Mainform.frmNieuwForm.Name = "AddRight"
        End If
        If Mainform.frmOudeForm.Name = "AddRight" Or Mainform.frmOudeForm.Name = "" Then
            Dim daRight As DARights = New DARights()
            Dim right As DARights = New DARights(TextBoxRight.Tag, TextBoxRight.Text)
            daRight.UpdateRight(right)
            Mainform.frmNieuwForm.Name = "AddRight"
        Else
            Mainform.frmOudeForm.Close()
            Listboxvullen()
        End If

    End Sub

    Private Sub VerwijderenKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MainForm.StatusStrip1.Hide()
        Dim daRight2 As DARights = New DARights()
        Dim rightCount As Integer = daRight2.getCountRightsByRightID(TextBoxRight.Tag)

        If rightCount = 0 Then
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
                If Mainform.frmOudeForm.Name <> "AddRight" And Mainform.frmOudeForm.Name <> Mainform.frmNieuwForm.Name Then
                    Mainform.frmNieuwForm.Name = "AddRight"
                End If
                If Mainform.frmOudeForm.Name = "AddRight" Or Mainform.frmOudeForm.Name = "" Then
                    Dim daRight As DARights = New DARights()
                    daRight.deleteRight(TextBoxRight.Tag)
                    If (_index > 0) Then
                        _index -= 1
                        If Mainform.BlnFilter = False Then
                            ToonRight(_index)
                        Else
                            ToonRight2(_index)
                        End If
                    Else
                        TextBoxRight.Text = Nothing
                    End If
                    Mainform.frmNieuwForm.Name = "AddRight"
                Else
                    Mainform.frmOudeForm.Close()
                End If
            End If
            If Mainform.BlnFilter = False Then
                ToonRight(_index)
            Else
                ToonRight2(_index)
            End If
        Else
            MainForm.StatusStrip1.Dispose()
            MainForm.StatusStrip1 = New StatusStrip()
            MainForm.ToolStripStatusLabel1.Text = "Dit item kan niet verwijderd worden, er hangt nog een gebruiker aan vast"
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

    Private Sub FormRights_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        Mainform.frmOudeForm.Name = "AddRight"
        Mainform.BlnFilter = False
        For Each frm As Form In My.Application.OpenForms
            If frm IsNot Me Then
                frm.BackColor = Nothing
            End If
        Next
        Me.BackColor = Color.Lavender
        Listboxvullen()
        ControlLayout()
    End Sub


    Private Sub ListBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedValueChanged
        If Mainform.BlnFilter = False Then
            ToonRight(ListBox1.SelectedIndex())
        Else
            ToonRight2(ListBox1.SelectedIndex())
        End If
    End Sub

    Private Sub TextBoxRight_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBoxRight.KeyUp
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
        TextBoxRight.Location = New Point((width + LabelGroup.Width) + 70, TextBoxRight.Location.Y)
        ButtonWijzigen.Location = New Point(width + 50, ButtonWijzigen.Location.Y)
    End Sub
End Class