Public Class FormStartProcedure
    'Dim WithEvents phidgetRFID As Phidgets.RFID

    Private Sub FormStartProcedure_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Focus()
        Me.ActiveControl = TextBox1
        TextBox1.Select()
        Me.FormBorderStyle = Forms.FormBorderStyle.None
        Translate.LoadLanguage(Me)
        TextBox1.Focus()
        For i As Integer = 1 To 25
            SendKeys.Send("{TAB}")
        Next

        'phidgetRFID = New Phidgets.RFID
        'phidgetRFID.open()
    End Sub

    Public Sub isopen()
        Dim DArfid As DARFID = New DARFID()
        Dim rfid As DARFID = New DARFID()
        rfid = DArfid.GetUsers(MainForm.strRfid)

        If rfid.UserID <> Nothing Then
            Dim daMontage As DAMontage = New DAMontage()
            Dim montage As DAMontage = daMontage.getMontageByMechanicEmpty(rfid.UserID)
            If montage.Mechanic <> Nothing Then
                If montage.Stoptime = Nothing And montage.Starttime <> Nothing Then
                    MainForm.intReasonID = 1
                    MainForm.strPRB = montage.Prb
                    If montage.Starttime = Nothing Then
                        MainForm.starttijd = DateTime.Now()
                    Else
                        MainForm.starttijd = montage.Starttime()
                    End If
                    MainForm.stoptijd = DateTime.Now()
                    If rfid.UserID <> Nothing Then
                        Dim childformMontage As Form = New Form()

                        Dim fc As FormCollection = Application.OpenForms
                        For Each frm As Form In fc.OfType(Of Form).ToList()
                            If frm IsNot FormStartProcedure2 Then
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
                            If frm.Text = "Montage: Start Productie" Then
                                frm.Close()
                            End If
                        Next
                    End If

                Else
                    MessageBox.Show("Monteur niet gevonden", "Monteur niet gevonden", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    MainForm.frmOudeForm.Name = "FormStartProcedure"
                    '    MainForm.StatusStrip1.Dispose()
                    '    MainForm.StatusStrip1 = New StatusStrip()
                    '    MainForm.StatusStrip1.Padding = New Padding(10, 10, 0, 0)
                    '    MainForm.ToolStripStatusLabel1.Padding = New Padding(10, 10, 0, 0)
                    '    MainForm.ToolStripStatusLabel1.Text = "Monteur niet gevonden."
                    '    MainForm.ToolStripStatusLabel1.ForeColor = Color.White
                    '    MainForm.StatusStrip1.BackColor = Color.Red

                    '    MainForm.StatusStrip1.Dock = DockStyle.Top
                    '    MainForm.StatusStrip1.Items.Add(MainForm.ToolStripStatusLabel1)

                    '    For Each frm As Form In My.Application.OpenForms
                    '        If frm Is Me Then
                    '            frm.Controls.Add(MainForm.StatusStrip1)
                    '            MainForm.StatusStrip1.Show()
                    '        End If
                    '    Next
                End If
            Else
                If rfid.UserID <> Nothing Then
                    MainForm.starttijd = DateTime.Now()
                    Dim childformMontage As Form = New Form()

                    Dim fc As FormCollection = Application.OpenForms
                    For Each frm As Form In fc.OfType(Of Form).ToList()
                        If frm IsNot FormStartProcedure2 Then
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
                    FormStartProcedure2.TopLevel = False
                    FormStartProcedure2.Parent = MainForm
                    FormStartProcedure2.Dock = DockStyle.Fill
                    childformMontage.Text = "Montage: Start Productie (2)"

                    childformMontage.TopMost = True
                    FormStartProcedure2.Height = childformMontage.Height
                    FormStartProcedure2.WindowState = FormWindowState.Maximized
                    childformMontage.Controls.Add(FormStartProcedure2)
                    FormStartProcedure2.Show()
                    Dim fc2 As FormCollection = Application.OpenForms
                    For Each frm As Form In fc2.OfType(Of Form).ToList()
                        If frm.Text = "Montage: Start Productie" Then
                            frm.Close()
                        End If
                    Next
                End If
            End If
        Else
            MessageBox.Show("Monteur niet gevonden", "Monteur niet gevonden", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'MainForm.StatusStrip1.Dispose()
            'MainForm.frmOudeForm.Name = "FormStartProcedure"
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
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            MainForm.strRfid = Nothing
            MainForm.strRfid = TextBox1.Text
            TextBox1.Clear()
            isopen()
        End If
    End Sub
End Class