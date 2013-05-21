Public Class FormStartProcedure3
    Private intI As Integer
    Private Sub FormStartProcedure3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Translate.LoadLanguage(Me)
        Timer1.Interval = 1000
        Timer1.Start()
        intI = 0
        Me.FormBorderStyle = Forms.FormBorderStyle.None
        LabelPRB.Text = MainForm.strPRB

        Dim daPRB As DAPrb = New DAPrb()
        Dim prb As DAPrb = daPRB.GetPRBInfo(MainForm.strPRB)

        LabelStartTijd.Text = MainForm.starttijd.ToString()
        LabelProvidedTijd.Text = prb.Provided & " minuten"
        LabelModel.Text = prb.Model
        LabelDesign.Text = prb.Design
        LabelMontageNiveau.Text = prb.MontageNiveau

        Dim DArfid As DARFID = New DARFID()
        Dim rfid As DARFID = DArfid.GetUsers(MainForm.strRfid)

        Dim daUser As DAMontage = New DAMontage()

        If rfid.UserID <> Nothing Then
            Dim daMontage As DAMontage = New DAMontage()
            Dim montage As DAMontage = New DAMontage(0, rfid.UserID, MainForm.strPRB, prb.Provided, MainForm.starttijd, 0, DateTime.Now, 0, prb.MontageNiveau, 0, 0)

            'MessageBox.Show(montage.Mechanic & "->" & montage.Prb & "->" & montage.Starttime).ToString()
            daMontage.InsertMontage(montage)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        intI += 1
        If intI = 5 Then

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
                If frm.Text = "Montage: Start Productie (2)" Or frm.Text = "Montage: Start Productie (3)" Then
                    frm.Close()
                End If
            Next
        End If
    End Sub
End Class