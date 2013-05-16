Public Class UserControlTextbox

    Private form2 As Form

    Public Property form() As Form
        Get
            Return form2
        End Get
        Set(value As Form)
            form2 = value
        End Set
    End Property




    Public Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            form = Mainform.frmverwijderForm
            MessageBox.Show(form.Name)
        End If
    End Sub


End Class
