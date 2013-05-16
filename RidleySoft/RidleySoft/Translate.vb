Module Translate
    Sub LoadLanguage(ByVal form As Form)
        Dim daTranslations As DATranslation = New DATranslation()
        Dim translations As List(Of DATranslation) = daTranslations.getTranslations()


        For Each item In form.Controls
            If TypeOf item Is Label Then
                Dim itemLabel As Label = item
                If (MainForm.strLanguage = "ENG") Then
                    For Each translation In translations
                        If itemLabel.Text = translation.NLB Then
                            itemLabel.Text = translation.ENG
                        End If
                    Next
                ElseIf (MainForm.strLanguage = "NLB") Then
                    For Each translation In translations
                        If itemLabel.Text = translation.ENG Then
                            itemLabel.Text = translation.NLB
                        End If
                    Next
                End If
            ElseIf TypeOf item Is Button Then
                Dim itemButton As Button = item
                If (MainForm.strLanguage = "ENG") Then
                    For Each translation In translations
                        If itemButton.Text = translation.NLB Then
                            itemButton.Text = translation.ENG
                        End If
                    Next
                ElseIf (MainForm.strLanguage = "NLB") Then
                    For Each translation In translations
                        If itemButton.Text = translation.ENG Then
                            itemButton.Text = translation.NLB
                        End If
                    Next
                End If
            End If
        Next
    End Sub
End Module
