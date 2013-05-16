Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class FormResizeImages
    Private myimg As System.Drawing.Image
    Private myimg2 As System.Drawing.Image
    Private myimg3 As System.Drawing.Image
    Private myimgGroot As System.Drawing.Image
    Private newImage As System.Drawing.Image
    Private strAfbeelding As String
    Private strPath As String
    Private lengte As Integer
    Private Sub FormResizeImages_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Forms.FormBorderStyle.None
        Translate.LoadLanguage(Me)
    End Sub

    Public Function ThumbnailCallback() As Boolean
        Return False
    End Function

    Public Shared Function ResizeImage(ByVal image As Image, ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image
        Dim newWidth As Integer
        Dim newHeight As Integer
        If preserveAspectRatio Then
            Dim originalWidth As Integer = image.Width
            Dim originalHeight As Integer = image.Height
            Dim percentWidth As Single = CSng(size.Width) / CSng(originalWidth)
            Dim percentHeight As Single = CSng(size.Height) / CSng(originalHeight)
            Dim percent As Single = If(percentHeight < percentWidth,
                    percentHeight, percentWidth)
            newWidth = CInt(originalWidth * percent)
            newHeight = CInt(originalHeight * percent)
        Else
            newWidth = size.Width
            newHeight = size.Height
        End If
        Dim newImage As Image = New Bitmap(newWidth, newHeight)
        Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
            graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
            graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight)
        End Using
        Return newImage
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim daDB As DADatabase = New DADatabase()
        Dim DB As DADatabase = daDB.getFTP()

        OpenFileDialog1.ShowDialog()
        strAfbeelding = OpenFileDialog1.FileName.ToString()
        Dim list As List(Of String)
        list = New List(Of String)
        list.AddRange(strAfbeelding.Split("\"))
        Dim teller As Integer
        teller = 0
        For Each item In list
            teller += 1
            If teller = 5 Then
                strPath = item
            End If
        Next

        If strAfbeelding.Substring((Len(strAfbeelding) - 4)) = ".jpg" Then
            myimg = System.Drawing.Image.FromFile(strAfbeelding)
            myimgGroot = System.Drawing.Image.FromFile(strAfbeelding)

            Try
                myimg2 = System.Drawing.Image.FromFile(Application.StartupPath & "\ResizedImages\" & (strPath.Substring(0, Len(strPath) - 4)) & "Resized" & ".jpg")
                myimg3 = System.Drawing.Image.FromFile(Application.StartupPath & "\ResizedImages\" & (strPath.Substring(0, Len(strPath) - 4)) & "ResizedGroot" & ".jpg")
            Catch ex As Exception
                newImage = ResizeImage(myimg, New Size(184, 184), True)
                'Dim img As Bitmap = New Bitmap(myimg, New Size(184, 184))
                newImage.Save((Application.StartupPath & "\ResizedImages\" & strPath.Substring(0, Len(strPath) - 4)) & "Resized" & ".jpg", myimg.RawFormat)

                Dim imgGroot As Image = ResizeImage(myimgGroot, New Size(800, 600), True)
                imgGroot.Save(Application.StartupPath & "\ResizedImages\" & (strPath.Substring(0, Len(strPath) - 4)) & "ResizedGroot" & ".jpg", myimg.RawFormat)
            End Try

            For i As Integer = 1 To 2
                If i = 1 Then
                    Dim clsRequest As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(DB.Source & strPath), System.Net.FtpWebRequest)
                    clsRequest.Credentials = New System.Net.NetworkCredential(DB.UserID, DB.Password)
                    clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile
                    ' read in file...
                    Dim bFile() As Byte = System.IO.File.ReadAllBytes(Application.StartupPath & "\ResizedImages\" & (strPath.Substring(0, Len(strPath) - 4)) & "Resized" & ".jpg")

                    ' upload file...
                    Dim clsStream As System.IO.Stream = clsRequest.GetRequestStream()
                    clsStream.Write(bFile, 0, bFile.Length)

                    clsStream.Close()
                    clsStream.Dispose()
                Else
                    Dim clsRequest As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(DB.Source & (strPath.Substring(0, Len(strPath) - 4)) & "Groot" & ".jpg"), System.Net.FtpWebRequest)
                    clsRequest.Credentials = New System.Net.NetworkCredential(DB.UserID, DB.Password)
                    clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile
                    ' read in file...
                    Dim bFile2() As Byte = System.IO.File.ReadAllBytes(Application.StartupPath & "\ResizedImages\" & (strPath.Substring(0, Len(strPath) - 4)) & "ResizedGroot" & ".jpg")
                    ' upload file...
                    Dim clsStream As System.IO.Stream = clsRequest.GetRequestStream()
                    clsStream.Write(bFile2, 0, bFile2.Length)

                    clsStream.Close()
                    clsStream.Dispose()
                End If
            Next
            MainForm.StatusStrip1.Items.Remove(MainForm.ToolStripStatusLabel1)
            MainForm.frmOudeForm.Name = "FormResizeImages"
            MainForm.StatusStrip1.Dispose()
            MainForm.StatusStrip1 = New StatusStrip()
            MainForm.StatusStrip1.Padding = New Padding(10, 10, 0, 0)
            MainForm.ToolStripStatusLabel1.Padding = New Padding(0, 0, 0, 0)
            MainForm.ToolStripStatusLabel1.Text = "Succesvol geresized en naar ftp geschreven."
            MainForm.ToolStripStatusLabel1.ForeColor = Color.White
            MainForm.StatusStrip1.BackColor = Color.Green
            MainForm.StatusStrip1.Dock = DockStyle.Top
            MainForm.StatusStrip1.Items.Add(MainForm.ToolStripStatusLabel1)


            For Each frm As Form In My.Application.OpenForms
                If frm Is Me Then
                    MainForm.StatusStrip1.Show()
                    frm.Controls.Add(MainForm.StatusStrip1)
                    MainForm.StatusStrip1.Show()
                End If
            Next
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim daDB As DADatabase = New DADatabase()
        Dim DB As DADatabase = daDB.getFTP()

        FolderBrowserDialog1.ShowDialog()
        Dim images As String
        images = FolderBrowserDialog1.SelectedPath

        Dim di As New IO.DirectoryInfo(images)
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo

        'list the names of all files in the specified directory
        For Each dra In diar1
            lengte = Len(dra.Name)
            If dra.Name.Substring((Len(dra.Name) - 4)) = ".jpg" Then
                myimg = System.Drawing.Image.FromFile(images & "\" & dra.Name)
                myimgGroot = System.Drawing.Image.FromFile(images & "\" & dra.Name)

                Try
                    myimg2 = System.Drawing.Image.FromFile(Application.StartupPath & "\ResizedImages\" & (dra.Name.Substring(0, Len(dra.Name) - 4)) & "Resized" & ".jpg")
                    myimg3 = System.Drawing.Image.FromFile(Application.StartupPath & "\ResizedImages\" & (dra.Name.Substring(0, Len(dra.Name) - 4)) & "ResizedGroot" & ".jpg")
                Catch ex As Exception
                    Dim img As Image = ResizeImage(myimg, New Size(184, 184), True)
                    img.Save(Application.StartupPath & "\ResizedImages\" & (dra.Name.Substring(0, Len(dra.Name) - 4)) & "Resized" & ".jpg", myimg.RawFormat)

                    Dim imgGroot As Image = ResizeImage(myimgGroot, New Size(800, 600), True)
                    imgGroot.Save(Application.StartupPath & "\ResizedImages\" & (dra.Name.Substring(0, Len(dra.Name) - 4)) & "ResizedGroot" & ".jpg", myimg.RawFormat)
                End Try

                For i As Integer = 1 To 2
                    If i = 1 Then
                        Dim clsRequest As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(DB.Source & dra.Name), System.Net.FtpWebRequest)
                        clsRequest.Credentials = New System.Net.NetworkCredential(DB.UserID, DB.Password)
                        clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile
                        ' read in file...
                        Dim bFile() As Byte = System.IO.File.ReadAllBytes(Application.StartupPath & "\ResizedImages\" & (dra.Name.Substring(0, (lengte - 4))) & "Resized" & ".jpg")

                        ' upload file...
                        Dim clsStream As System.IO.Stream = clsRequest.GetRequestStream()
                        clsStream.Write(bFile, 0, bFile.Length)

                        clsStream.Close()
                        clsStream.Dispose()
                    Else
                        Dim clsRequest As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(DB.Source & (dra.Name.Substring(0, (lengte - 4))) & "Groot" & ".jpg"), System.Net.FtpWebRequest)
                        clsRequest.Credentials = New System.Net.NetworkCredential(DB.UserID, DB.Password)
                        clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile
                        ' read in file...
                        Dim bFile2() As Byte = System.IO.File.ReadAllBytes(Application.StartupPath & "\ResizedImages\" & (dra.Name.Substring(0, Len(dra.Name) - 4)) & "ResizedGroot" & ".jpg")
                        ' upload file...
                        Dim clsStream As System.IO.Stream = clsRequest.GetRequestStream()
                        clsStream.Write(bFile2, 0, bFile2.Length)

                        clsStream.Close()
                        clsStream.Dispose()
                    End If
                Next

                MainForm.frmOudeForm.Name = "FormResizeImages"
                MainForm.StatusStrip1.Items.Remove(MainForm.ToolStripStatusLabel1)
                MainForm.StatusStrip1.Dispose()
                MainForm.StatusStrip1 = New StatusStrip()
                MainForm.StatusStrip1.Padding = New Padding(10, 10, 0, 0)
                MainForm.ToolStripStatusLabel1.Padding = New Padding(0, 0, 0, 0)
                MainForm.ToolStripStatusLabel1.Text = "Succesvol geresized en naar ftp geschreven."
                MainForm.ToolStripStatusLabel1.ForeColor = Color.White
                MainForm.StatusStrip1.BackColor = Color.Green
                MainForm.StatusStrip1.Dock = DockStyle.Top
                MainForm.StatusStrip1.Items.Add(MainForm.ToolStripStatusLabel1)


                For Each frm As Form In My.Application.OpenForms
                    If frm Is Me Then
                        MainForm.StatusStrip1.Show()
                        frm.Controls.Add(MainForm.StatusStrip1)
                        MainForm.StatusStrip1.Show()
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub FormResizeImages_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
       
    End Sub
End Class