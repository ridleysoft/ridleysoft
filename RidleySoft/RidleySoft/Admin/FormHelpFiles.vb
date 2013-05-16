Imports System.Reflection
Imports System.Windows.Forms

Public Class FormHelpFiles
    Private _dataset As DataSet
    Private _dataset2 As DataSet
    Private _index As Integer
    Private borderColor As Color = Color.Green 'Border Color
    Public strUser As String


    Private Sub FormHelpFiles_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _index = 0
        If MainForm.BlnFilter = False Then
            ToonFile(_index)
        Else
            ToonFile2(_index)
        End If
        Listboxvullen()
        Me.FormBorderStyle = Forms.FormBorderStyle.None
        MainForm.frmOudeForm.Name = "HelpfileToevoegen"
        MainForm.frmverwijderForm.Name = "FormHelpFiles"
        MainForm.FrmOpenForm = Me
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Translate.LoadLanguage(Me)
        AddHandler MainForm.menuitemEerste.Click, AddressOf EersteKlik
        AddHandler MainForm.menuitemVorige.Click, AddressOf VorigeKlik
        AddHandler MainForm.menuitemVolgende.Click, AddressOf VolgendeKlik
        AddHandler MainForm.menuitemLaatste.Click, AddressOf LaatsteKlik
        AddHandler MainForm.menuitemToevoegen.Click, AddressOf ToevoegenKlik
        AddHandler MainForm.menuitemVerwijderen.Click, AddressOf VerwijderenKlik
        'AddHandler MainForm.menuitemSearch.Click, AddressOf searchKlik
        ' AddHandler MainForm.menuitemFilter.Click, AddressOf filterKlik
        For Each frm As Form In My.Application.OpenForms
            If frm IsNot Me Then
                frm.BackColor = Nothing
            End If
        Next
        Me.BackColor = Color.Lavender
    End Sub

    Public Sub Listboxvullen()
        ListBoxHelpFiles.Width = 350
        ListBoxHelpFiles.Dock = DockStyle.Left
        Dim daHelpfile As DAHelpfile = New DAHelpfile()
        Dim helpfiles As List(Of DAHelpfile) = daHelpfile.getHelpfiles()

        ListBoxHelpFiles.DataSource = helpfiles
        ListBoxHelpFiles.DisplayMember = "Name"
        ListBoxHelpFiles.ValueMember = "HelpfileID"
    End Sub

    Private Function GetDataSetConventional(ByVal list As List(Of DAHelpfile)) As DataSet
        Dim _result As New DataSet()
        _result.Tables.Add("helpfiles")
        _result.Tables("helpfiles").Columns.Add("HelpfileID")
        _result.Tables("helpfiles").Columns.Add("Name")
        _result.Tables("helpfiles").Columns.Add("Categorie")
        _result.Tables("helpfiles").Columns.Add("Path")
        _result.Tables("helpfiles").Columns.Add("DocType")
        _result.Tables("helpfiles").Columns.Add("Description")

        For Each item As DAHelpfile In list
            Dim newRow As DataRow = _
                _result.Tables("helpfiles").NewRow()
            newRow("HelpfileID") = item.HelpfileID
            newRow("Name") = item.Name
            newRow("Categorie") = item.Categorie
            newRow("Path") = item.Path
            newRow("DocType") = item.DocType
            newRow("Description") = item.Description
            _result.Tables("helpfiles").Rows.Add(newRow)
        Next
        Return _result
    End Function

    Public Sub ToonFile(ByVal i As Integer)
        Dim daHelpfile As DAHelpfile = New DAHelpfile()
        Dim helpfiles As List(Of DAHelpfile) = daHelpfile.getHelpfiles()

        _dataset = GetDataSetConventional(helpfiles)

        If (_dataset.Tables("helpfiles").Rows(i).RowState <> DataRowState.Deleted) Then
            TextBoxName.Text = _dataset.Tables("helpfiles").Rows(i).Field(Of String)("Name")
            TextBoxCategorie.Text = _dataset.Tables("helpfiles").Rows(i).Field(Of String)("Categorie")
            TextBoxType.Text = _dataset.Tables("helpfiles").Rows(i).Field(Of String)("DocType")
            TextBoxDescription.Text = _dataset.Tables("helpfiles").Rows(i).Field(Of String)("Description")
            TextBoxPath.Text = _dataset.Tables("helpfiles").Rows(i).Field(Of String)("Path")
            TextBoxName.Tag = _dataset.Tables("helpfiles").Rows(i).Field(Of String)("HelpfileID")
        Else
            TextBoxName.Text = "###"
        End If
    End Sub

    Public Sub ToonFile2(ByVal i As Integer)
        Dim daHelpfile As DAHelpfile = New DAHelpfile()
        Dim helpfiles As List(Of DAHelpfile) = daHelpfile.getHelpfiles()

        _dataset = GetDataSetConventional(helpfiles)

        If (_dataset.Tables("helpfiles").Rows(i).RowState <> DataRowState.Deleted) Then
            TextBoxName.Text = _dataset.Tables("helpfiles").Rows(i).Field(Of String)("Name")
            TextBoxCategorie.Text = _dataset.Tables("helpfiles").Rows(i).Field(Of String)("Categorie")
            TextBoxType.Text = _dataset.Tables("helpfiles").Rows(i).Field(Of String)("DocType")
            TextBoxDescription.Text = _dataset.Tables("helpfiles").Rows(i).Field(Of String)("Description")
            TextBoxPath.Text = _dataset.Tables("helpfiles").Rows(i).Field(Of String)("Path")
            TextBoxName.Tag = _dataset.Tables("helpfiles").Rows(i).Field(Of String)("HelpfileID")
        Else
            TextBoxName.Text = "###"
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
        If MainForm.frmOudeForm.Name <> "HelpfileToevoegen" And MainForm.frmOudeForm.Name <> MainForm.frmNieuwForm.Name Then
            MainForm.frmNieuwForm.Name = "HelpfileToevoegen"
        End If
        If MainForm.frmOudeForm.Name = "HelpfileToevoegen" Or MainForm.frmOudeForm.Name = "" Then
            _index = 0
            If MainForm.BlnFilter = False Then
                ToonFile(_index)
            Else
                ToonFile2(_index)
            End If
            MainForm.frmNieuwForm.Name = "HelpfileToevoegen"
        Else
            MainForm.frmOudeForm.Close()
        End If

    End Sub

    Private Sub VorigeKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MainForm.frmOudeForm.Name <> "HelpfileToevoegen" And MainForm.frmOudeForm.Name <> MainForm.frmNieuwForm.Name Then
            MainForm.frmNieuwForm.Name = "HelpfileToevoegen"
        End If
        If MainForm.frmOudeForm.Name = "HelpfileToevoegen" Or MainForm.frmOudeForm.Name = "" Then
            If (_index > 0) Then
                _index -= 1
                If MainForm.BlnFilter = False Then
                    ToonFile(_index)
                Else
                    ToonFile2(_index)
                End If
            End If
            MainForm.frmNieuwForm.Name = "HelpfileToevoegen"
        Else
            MainForm.frmOudeForm.Close()
        End If

    End Sub

    Private Sub VolgendeKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MainForm.frmOudeForm.Name <> "HelpfileToevoegen" And MainForm.frmOudeForm.Name <> MainForm.frmNieuwForm.Name Then
            MainForm.frmNieuwForm.Name = "HelpfileToevoegen"
        End If
        If MainForm.frmOudeForm.Name = "HelpfileToevoegen" Or MainForm.frmOudeForm.Name = "" Then
            If (_index < _dataset.Tables("helpfiles").Rows.Count - 1) Then
                _index += 1
                If MainForm.BlnFilter = False Then
                    ToonFile(_index)
                Else
                    ToonFile2(_index)
                End If
            End If
            MainForm.frmNieuwForm.Name = "HelpfileToevoegen"
        Else
            MainForm.frmOudeForm.Close()
        End If

    End Sub

    Private Sub LaatsteKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MainForm.frmOudeForm.Name <> "HelpfileToevoegen" And MainForm.frmOudeForm.Name <> MainForm.frmNieuwForm.Name Then
            MainForm.frmNieuwForm.Name = "HelpfileToevoegen"
        End If
        If MainForm.frmOudeForm.Name = "HelpfileToevoegen" Or MainForm.frmOudeForm.Name = "" Then
            _index = _dataset.Tables("helpfiles").Rows.Count - 1
            If MainForm.BlnFilter = False Then
                ToonFile(_index)
            Else
                ToonFile2(_index)
            End If
            MainForm.frmNieuwForm.Name = "HelpfileToevoegen"
        Else
            MainForm.frmOudeForm.Close()
        End If

    End Sub

    Private Sub ToevoegenKlik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MainForm.frmOudeForm.Name <> "HelpfileToevoegen" And MainForm.frmOudeForm.Name <> MainForm.frmNieuwForm.Name Then
            MainForm.frmNieuwForm.Name = "HelpfileToevoegen"
        End If
        If MainForm.frmOudeForm.Name = "HelpfileToevoegen" Or MainForm.frmOudeForm.Name = "" Then
            FormAddHelpFiles.TopLevel = True
            FormAddHelpFiles.Show()
            MainForm.frmNieuwForm.Name = "HelpfileToevoegen"
        Else
            MainForm.frmOudeForm.Close()
        End If
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
            If MainForm.frmOudeForm.Name <> "HelpfileToevoegen" And MainForm.frmOudeForm.Name <> MainForm.frmNieuwForm.Name Then
                MainForm.frmNieuwForm.Name = "HelpfileToevoegen"
            End If
            If MainForm.frmOudeForm.Name = "HelpfileToevoegen" Or MainForm.frmOudeForm.Name = "" Then
                Dim daHelpFile As DAHelpfile = New DAHelpfile()
                daHelpFile.deleteHelpFile(TextBoxName.Tag)
                If (_index > 0) Then
                    _index -= 1
                    If MainForm.BlnFilter = False Then
                        ToonFile(_index)
                    Else
                        ToonFile2(_index)
                    End If
                Else
                    TextBoxName.Text = Nothing
                End If
                MainForm.frmNieuwForm.Name = "HelpfileToevoegen"
            Else
                MainForm.frmOudeForm.Close()
            End If
        End If
        If Mainform.BlnFilter = False Then
            ToonFile(_index)
        Else
            ToonFile2(_index)
        End If
        Listboxvullen()
    End Sub

    Private Sub ListBoxHelpFiles_SelectedValueChanged(sender As Object, e As EventArgs) Handles ListBoxHelpFiles.SelectedValueChanged
        If MainForm.BlnFilter = False Then
            ToonFile(ListBoxHelpFiles.SelectedIndex)
        Else
            ToonFile2(ListBoxHelpFiles.SelectedIndex)
        End If
    End Sub

    Private Sub ButtonWijzigen_Click(sender As Object, e As EventArgs) Handles ButtonWijzigen.Click
        If MainForm.frmOudeForm.Name <> "HelpfileToevoegen" And MainForm.frmOudeForm.Name <> MainForm.frmNieuwForm.Name Then
            MainForm.frmNieuwForm.Name = "HelpfileToevoegen"
        End If
        If MainForm.frmOudeForm.Name = "HelpfileToevoegen" Or MainForm.frmOudeForm.Name = "" Then
            Dim daHelpFile As DAHelpfile = New DAHelpfile()
            Dim helpfile As DAHelpfile = New DAHelpfile(TextBoxName.Tag, TextBoxPath.Text, TextBoxType.Text, TextBoxName.Text, TextBoxDescription.Text, TextBoxCategorie.Text)

            daHelpFile.UpdateHelpFile(helpfile)
            MainForm.frmNieuwForm.Name = "HelpfileToevoegen"
        Else
            MainForm.frmOudeForm.Close()
        End If

        Listboxvullen()
    End Sub

    Private Sub FormHelpFiles_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        MainForm.frmOudeForm.Name = "HelpfileToevoegen"
        For Each frm As Form In My.Application.OpenForms
            If frm IsNot Me Then
                frm.BackColor = Nothing
            End If
        Next
        Me.BackColor = Color.Lavender
        MainForm.BlnFilter = False
        Listboxvullen()
    End Sub
End Class