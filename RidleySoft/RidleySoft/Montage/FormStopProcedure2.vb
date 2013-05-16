Public Class FormStopProcedure2
    Private strMechanicName As String
    Private intProvidedlabortime As Integer
    Private intId As Integer
    Private intI As Integer

    Private Sub FormStopProcedure2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Translate.LoadLanguage(Me)
        Timer1.Interval = 1000
        Timer1.Start()
        intI = 0
        Dim DArfid As DARFID = New DARFID()
        Dim rfid As DARFID = DArfid.GetUsers(Mainform.strRfid)

        If rfid.UserID <> Nothing Then
            Dim daMontage2 As DAMontage = New DAMontage()
            Dim montage2 As List(Of DAMontage) = daMontage2.getMontageByMechanic(rfid.UserID)
            For Each item In montage2
                If item.Stoptime = Nothing Then
                    intProvidedlabortime = item.Provided
                    intId = item.ID
                End If
            Next
        End If
        Me.FormBorderStyle = Forms.FormBorderStyle.None

        LabelPRB.Text = MainForm.strPRB
        LabelStartTijd.Text = MainForm.starttijd
        LabelStopTijd.Text = MainForm.stoptijd

        Dim datedif As Long
        datedif = DateDiff(DateInterval.Day, MainForm.starttijd, MainForm.stoptijd)
        Dim weekday As Integer
        weekday = MainForm.starttijd.DayOfWeek

        If rfid.UserID <> Nothing Then
            strMechanicName = rfid.FirstName
        Else
            MessageBox.Show("niet gevonden")
        End If

        Dim days As Long
        Dim weekend As Long

        Select Case datedif
            Case 0
                days = 0
            Case Else
                days = 900 + ((datedif - 1) * 1440)
        End Select

        Select Case weekday
            Case 4
                weekend = 135
            Case Else
                weekend = 0
        End Select

        Dim case3 As Integer
        Dim case4 As Integer
        Dim case5 As Integer
        Dim date1 As DateTime
        date1 = "12:15:00"
        Dim date2 As DateTime
        date2 = "09:27:00"

        Dim date3 As DateTime
        date3 = "14:27:00"

        If date1 >= MainForm.starttijd And date1 <= MainForm.stoptijd Then
            case3 = 30
        Else
            case3 = 0
        End If

        If strMechanicName <> "josef" Then
            If date2 >= MainForm.starttijd And date2 <= MainForm.stoptijd Then
                case4 = 15
            Else
                case4 = 0
            End If
        Else
            case4 = 0
        End If

        If strMechanicName <> "josef" Then
            If date3 >= MainForm.starttijd And date3 <= MainForm.stoptijd Then
                case5 = 15
            Else
                case5 = 0
            End If
        Else
            case4 = 0
        End If

        Dim diff As Long
        diff = (((DateDiff(DateInterval.Hour, MainForm.starttijd, MainForm.stoptijd) * 60) + (DateDiff(DateInterval.Minute, MainForm.starttijd, MainForm.stoptijd)) + (DateDiff(DateInterval.Second, MainForm.starttijd, MainForm.stoptijd) / 60)) - days - weekend - case3 - case4)
        LabelLabor.Text = diff.ToString()

        Dim kpi As Integer = (diff / intProvidedlabortime * 100)
        LabelKPI.Text = kpi.ToString()

        Dim daPRB As DAPrb = New DAPrb()
        Dim prb As DAPrb = daPRB.GetPRBInfo(MainForm.strPRB)

        Dim daMontage As DAMontage = New DAMontage()

        Dim labortime2 As Integer
        If diff = 0 Then
            labortime2 = 1
        Else
            labortime2 = 0
        End If
        Dim montage As DAMontage = New DAMontage(intId, rfid.UserID, MainForm.strPRB, prb.Provided, MainForm.starttijd, 0, MainForm.stoptijd, diff, prb.MontageNiveau, labortime2, MainForm.intReasonID)

        'MessageBox.Show("->" & montage.Labortime & "->" & montage.UnknownLaborTime).ToString()
        daMontage.UpdateMontage(montage)
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
                If frm.Text = "Montage: Stop Productie" Or frm.Text = "Montage: Stop Productie (2)" Then
                    frm.Close()
                End If
            Next
        End If
    End Sub
End Class