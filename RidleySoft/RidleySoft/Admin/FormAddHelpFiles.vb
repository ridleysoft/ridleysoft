

Public Class FormAddHelpFiles
    Private file As String
    Private path As String
    Private doctype As String
    Private Sub ButtonFile_Click(sender As Object, e As EventArgs) Handles ButtonFile.Click
        OpenFileDialog1.ShowDialog()
        path = OpenFileDialog1.FileName.ToString()

        Dim list As List(Of String)
        list = New List(Of String)
        list.AddRange(path.Split("\"))
        Dim teller As Integer
        teller = 0
        For Each item In list
            teller += 1
            If teller = list.Count Then
                file = item
            End If
        Next
        

        Dim list2 As List(Of String)
        list2 = New List(Of String)
        list2.AddRange(file.Split("."))
        Dim teller2 As Integer
        teller2 = 0
        For Each item In list2
            teller2 += 1
            If teller2 = 1 Then
                file = item
            ElseIf teller2 = list2.Count Then
                doctype = item
            End If
        Next

        TextBoxName.Text = file
        TextBoxPath.Text = path
        TextBoxType.Text = doctype
    End Sub

    Private Sub FormAddHelpFiles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub ButtonToevoegen_Click(sender As Object, e As EventArgs) Handles ButtonToevoegen.Click
        Dim daHelpfile As DAHelpfile = New DAHelpfile()
        Dim HelpFile As DAHelpfile = New DAHelpfile(0, TextBoxPath.Text, TextBoxType.Text, TextBoxName.Text, TextBoxDescription.Text, TextBoxCategorie.Text)

        daHelpfile.InsertHelpfile(HelpFile)

        MainForm.StatusStrip1.Items.Remove(MainForm.ToolStripStatusLabel1)
        MainForm.frmOudeForm.Name = "FormAddHelpFiles"
        MainForm.StatusStrip1.Dispose()
        MainForm.StatusStrip1 = New StatusStrip()
        MainForm.StatusStrip1.Padding = New Padding(10, 10, 0, 0)
        MainForm.ToolStripStatusLabel1.Padding = New Padding(0, 0, 0, 0)
        MainForm.ToolStripStatusLabel1.Text = "Succesvol toegevoegd"
        MainForm.ToolStripStatusLabel1.ForeColor = Color.White
        MainForm.StatusStrip1.BackColor = Color.Green
        MainForm.StatusStrip1.Dock = DockStyle.Top
        MainForm.StatusStrip1.Items.Add(MainForm.ToolStripStatusLabel1)


        For Each frm As Form In My.Application.OpenForms
            If frm Is FormHelpFiles Then
                MainForm.StatusStrip1.Show()
                frm.Controls.Add(MainForm.StatusStrip1)
                MainForm.StatusStrip1.Show()
            End If
        Next
        'FormRights.Listboxvullen()
        Me.Close()
    End Sub
End Class