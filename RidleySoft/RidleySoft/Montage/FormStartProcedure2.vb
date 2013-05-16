Public Class FormStartProcedure2
    Private intI As Integer
    Private Sub FormStartProcedure2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Focus()
        Translate.LoadLanguage(Me)
        Timer1.Interval = 1000
        Timer1.Start()
        intI = 0
        Me.FormBorderStyle = Forms.FormBorderStyle.None
        'MessageBox.Show(Mainform.strRfid)

        Dim DArfid As DARFID = New DARFID()
        Dim rfid As DARFID = DArfid.GetUsers(MainForm.strRfid)

        If rfid.UserID <> Nothing Then
            LabelRFID.Text = rfid.FirstName & " " & rfid.LastName & " (" & rfid.UserID & ")"
        Else
            MessageBox.Show("niet gevonden")
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        intI += 1
        If intI = 10 Then
            If TextBox1.Text = Nothing Then
                Dim childformStart As Form = New Form()
                Dim fc As FormCollection = Application.OpenForms
                For Each frm As Form In fc.OfType(Of Form).ToList()
                    If frm IsNot Me Then
                        MainForm.IsMdiContainer = True
                        childformStart.MdiParent = MainForm
                        childformStart.WindowState = FormWindowState.Maximized
                        MainForm.SplitContainer1.Panel2.Controls.Add(childformStart)

                        Dim daTranslations As DATranslation = New DATranslation()
                        Dim translations As List(Of DATranslation) = daTranslations.getTranslations()

                        If (MainForm.strLanguage = "ENG") Then
                            For Each translation In translations
                                If childformStart.Text = translation.NLB Then
                                    childformStart.Text = translation.ENG
                                End If
                            Next
                        ElseIf (MainForm.strLanguage = "NLB") Then
                            For Each translation In translations
                                If childformStart.Text = translation.ENG Then
                                    childformStart.Text = translation.NLB
                                End If
                            Next
                        End If
                    End If
                Next
                childformStart.Show()
                FormStartProcedure.TopLevel = False
                FormStartProcedure.Parent = MainForm
                FormStartProcedure.Dock = DockStyle.Fill
                childformStart.Text = "Montage: Start Productie"

                childformStart.TopMost = True
                FormStartProcedure.Height = childformStart.Height
                FormStartProcedure.WindowState = FormWindowState.Maximized
                childformStart.Controls.Add(FormStartProcedure)
                FormStartProcedure.Show()
                Dim fc2 As FormCollection = Application.OpenForms
                For Each frm As Form In fc2.OfType(Of Form).ToList()
                    If frm.Text = "Montage: Start Productie (2)" Then
                        frm.Close()
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            MainForm.strPRB = TextBox1.Text
            Dim childformMontage2 As Form = New Form()


            Dim daPRB As DAPrb = New DAPrb()
            Dim prb As DAPrb = daPRB.GetPRBInfo(MainForm.strPRB)

            If prb.PrbID <> Nothing Then
                Dim fc As FormCollection = Application.OpenForms
                For Each frm As Form In fc.OfType(Of Form).ToList()
                    If frm IsNot FormStartProcedure3 Then
                        MainForm.IsMdiContainer = True
                        childformMontage2.MdiParent = MainForm
                        childformMontage2.WindowState = FormWindowState.Maximized
                        MainForm.SplitContainer1.Panel2.Controls.Add(childformMontage2)

                        Dim daTranslations As DATranslation = New DATranslation()
                        Dim translations As List(Of DATranslation) = daTranslations.getTranslations()

                        If (MainForm.strLanguage = "ENG") Then
                            For Each translation In translations
                                If childformMontage2.Text = translation.NLB Then
                                    childformMontage2.Text = translation.ENG
                                End If
                            Next
                        ElseIf (MainForm.strLanguage = "NLB") Then
                            For Each translation In translations
                                If childformMontage2.Text = translation.ENG Then
                                    childformMontage2.Text = translation.NLB
                                End If
                            Next
                        End If
                    End If

                Next
                childformMontage2.Show()
                FormStartProcedure3.TopLevel = False
                FormStartProcedure3.Parent = MainForm
                FormStartProcedure3.Dock = DockStyle.Fill
                childformMontage2.Text = "Montage: Start Productie (3)"

                childformMontage2.TopMost = True
                FormStartProcedure3.Height = childformMontage2.Height
                FormStartProcedure3.WindowState = FormWindowState.Maximized
                childformMontage2.Controls.Add(FormStartProcedure3)
                FormStartProcedure3.Show()
                Dim fc2 As FormCollection = Application.OpenForms
                For Each frm As Form In fc2.OfType(Of Form).ToList()
                    If frm.Text = "Montage: Start Productie (2)" Then
                        frm.Close()
                    End If
                Next
            Else
                MessageBox.Show("PRB niet gevonden", "PRB niet gevonden", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'MainForm.frmOudeForm.Name = "FormStartProcedure2"
                'MainForm.StatusStrip1.Dispose()
                'MainForm.StatusStrip1 = New StatusStrip()
                'MainForm.StatusStrip1.Padding = New Padding(10, 10, 0, 0)
                'MainForm.ToolStripStatusLabel1.Padding = New Padding(10, 10, 0, 0)
                'MainForm.ToolStripStatusLabel1.Text = "PRB niet gevonden."
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