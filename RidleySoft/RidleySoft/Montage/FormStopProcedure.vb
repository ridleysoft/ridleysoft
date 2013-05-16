Public Class FormStopProcedure
    'Dim WithEvents phidgetRFID As Phidgets.RFID

    Private Sub FormStartProcedure_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Translate.LoadLanguage(Me)
        Me.FormBorderStyle = Forms.FormBorderStyle.None
        TextBox1.Focus()
        For i As Integer = 1 To 25
            SendKeys.Send("{TAB}")
        Next
        'phidgetRFID = New Phidgets.RFID

        'phidgetRFID.open()
    End Sub

    Public Sub isopen()
        Dim DArfid As DARFID = New DARFID()
        Dim rfid As DARFID = DArfid.GetUsers(Mainform.strRfid)

        If rfid.UserID <> Nothing Then
            Dim daMontage As DAMontage = New DAMontage()
            Dim montage As List(Of DAMontage) = daMontage.getMontageByMechanic(rfid.UserID)
            For Each item In montage
                If item.Stoptime = Nothing Then
                    MainForm.starttijd = item.Starttime
                End If
            Next
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If (e.KeyCode = Keys.Enter) Then

            Mainform.strRfid = TextBox1.Text
            MainForm.stoptijd = DateTime.Now()
            MainForm.intReasonID = 2
            isopen()

            Dim DArfid As DARFID = New DARFID()
            Dim rfid As DARFID = DArfid.GetUsers(Mainform.strRfid)

            If rfid.UserID <> Nothing Then
                Dim childformMontage As Form = New Form()

                Dim fc As FormCollection = Application.OpenForms
                For Each frm As Form In fc.OfType(Of Form).ToList()
                    If frm IsNot FormStopProcedure2 Then
                        MainForm.IsMdiContainer = True
                        childformMontage.MdiParent = MainForm
                        childformMontage.WindowState = FormWindowState.Maximized
                        MainForm.SplitContainer1.Panel2.Controls.Add(childformMontage)

                        Dim daTranslations As DATranslation = New DATranslation()
                        Dim translations As List(Of DATranslation) = daTranslations.getTranslations()

                        If (MainForm.strLanguage = "ENG") Then
                            For Each translation In translations
                                If childformMontage.Text = translation.NLB Then
                                    childformMontage.Text = translation.ENG
                                End If
                            Next
                        ElseIf (MainForm.strLanguage = "NLB") Then
                            For Each translation In translations
                                If childformMontage.Text = translation.ENG Then
                                    childformMontage.Text = translation.NLB
                                End If
                            Next
                        End If
                    End If

                Next
                childformMontage.Show()
                FormStopProcedure2.TopLevel = False
                FormStopProcedure2.Parent = MainForm
                FormStopProcedure2.Dock = DockStyle.Fill
                childformMontage.Text = "Montage: Stop Productie (2)"

                childformMontage.TopMost = True
                FormStopProcedure2.Height = childformMontage.Height
                FormStopProcedure2.WindowState = FormWindowState.Maximized
                childformMontage.Controls.Add(FormStopProcedure2)
                FormStopProcedure2.Show()
                Dim fc2 As FormCollection = Application.OpenForms
                For Each frm As Form In fc2.OfType(Of Form).ToList()
                    If frm.Text = "Montage: Stop Productie" Then
                        frm.Close()
                    End If
                Next
            Else
                MessageBox.Show("Monteur niet gevonden", "Monteur niet gevonden", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'MainForm.frmOudeForm.Name = "FormStopProcedure"
                'MainForm.StatusStrip1.Dispose()
                'MainForm.StatusStrip1 = New StatusStrip()
                'MainForm.StatusStrip1.Padding = New Padding(10, 10, 0, 0)
                'MainForm.ToolStripStatusLabel1.Padding = New Padding(10, 10, 0, 0)
                'MainForm.ToolStripStatusLabel1.Text = "Monteur niet gevonden."
                'MainForm.ToolStripStatusLabel1.ForeColor = Color.White
                'MainForm.StatusStrip1.BackColor = Color.Red
                'MainForm.StatusStrip1.Dock = DockStyle.Top
                'MainForm.StatusStrip1.Items.Add(MainForm.ToolStripStatusLabel1)


                'For Each frm As Form In My.Application.OpenForms
                '    If frm Is Me Then
                '        frm.Controls.Add(MainForm.StatusStrip1)
                '        MainForm.StatusStrip1.Show()
                '    End If
                'Next
            End If
        End If
    End Sub
End Class