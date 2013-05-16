Public Class FormHelp
    Private nodeClicked As TreeNode
    Private treenode As TreeNode
    Public strLanguage As String

    Private Sub FormHelp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Forms.FormBorderStyle.None
        TreeView1.Height = (Me.Height - 25)
        Treeview()
    End Sub

    Public Sub Treeview()
        TreeView1.Nodes.Clear()



        Dim imagelist1 As ImageList
        imagelist1 = New ImageList()
        imagelist1.Images.Add(System.Drawing.Image.FromFile(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images\folder.png")))
        imagelist1.Images.Add(System.Drawing.Image.FromFile(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images\PDF.ico")))
        imagelist1.Images.Add(System.Drawing.Image.FromFile(System.IO.Path.Combine(My.Application.Info.DirectoryPath, "Images\selected.png")))

        Dim daHelpFiles As DAHelpfile = New DAHelpfile()
        Dim helpfiles As List(Of DAHelpfile) = daHelpFiles.getHelpfilesCategories()

        TreeView1.SelectedImageIndex = 0

        For Each categorie In helpfiles
            TreeView1.ImageList = imagelist1
            TreeNode = New TreeNode()
            treenode.Text = categorie.Categorie
            treenode.ImageIndex = 0
            TreeView1.Nodes.Add(TreeNode)

            Dim daTranslations As DATranslation = New DATranslation()
            Dim translations As List(Of DATranslation) = daTranslations.getTranslations()

            For Each translation In translations
                If TreeNode.Text = translation.NLB Then
                    TreeNode.Text = translation.ENG
                End If
            Next

            Dim helpfilesbycategorie As List(Of DAHelpfile) = daHelpFiles.getHelpFilesByCategorie(categorie.Categorie)

            For Each helpfile In helpfilesbycategorie
                Dim treenode2 As TreeNode
                treenode2 = New TreeNode()
                treenode2.Tag = helpfile.HelpfileID
                treenode2.Text = helpfile.Name
                treenode2.ToolTipText = helpfile.Description
                treenode2.Name = helpfile.Path
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
            Next
        Next
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        Dim treeNoode As TreeNode
        treeNoode = TreeView1.SelectedNode
        nodeClicked = treeNoode
        nodeClicked.SelectedImageIndex = 2
        If treeNoode.Name IsNot "" Then
            Try
                System.Diagnostics.Process.Start(treeNoode.Name)
            Catch ex As Exception
                MessageBox.Show("PDF niet gevonden")
            End Try
        End If
    End Sub

    Private Sub TreeView1_DoubleClick(sender As Object, e As EventArgs) Handles TreeView1.DoubleClick
        Dim treeNoode As TreeNode
        treeNoode = TreeView1.SelectedNode
        nodeClicked = treeNoode
        nodeClicked.SelectedImageIndex = 2
        If treeNoode.Name IsNot "" Then
            Try
                System.Diagnostics.Process.Start(treeNoode.Name)
            Catch ex As Exception
                MessageBox.Show("PDF niet gevonden")
            End Try
        End If
    End Sub
End Class