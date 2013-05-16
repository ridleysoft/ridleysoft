Public Class FormStart
    Dim WithEvents phidgetRFID As Phidgets.RFID

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub FormStart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        TextBoxRFID.Focus()

        phidgetRFID = New Phidgets.RFID

        phidgetRFID.open()
    End Sub

    'Private Sub FormStartProcedure_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    'When the application is being terminated, close the Phidget.
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)
        RemoveHandler phidgetRFID.Error, AddressOf phidgetRFID_Error
        RemoveHandler phidgetRFID.Tag, AddressOf phidgetRFID_Tag
        RemoveHandler phidgetRFID.TagLost, AddressOf phidgetRFID_TagLost
        Application.DoEvents()

        phidgetRFID.close()
    End Sub

    'attach event handler..populate the details fields as well as display the attached status.  enable the checkboxes to change
    'the values of the attributes of the RFID reader such as enable or disable the antenna and onboard led.
    Private Sub phidgetRFID_Attach(ByVal sender As Object, ByVal e As Phidgets.Events.AttachEventArgs) Handles phidgetRFID.Attach

    End Sub

    'detach event handler...clear all the fields, display the attached status, and disable the checkboxes.
    Private Sub phidgetRFID_Detach(ByVal sender As Object, ByVal e As Phidgets.Events.DetachEventArgs) Handles phidgetRFID.Detach

    End Sub

    Private Sub phidgetRFID_Error(ByVal sender As Object, ByVal e As Phidgets.Events.ErrorEventArgs) Handles phidgetRFID.Error
        MessageBox.Show(e.Description)
    End Sub

    'Tag event handler...we'll display the tag code in the field on the GUI
    Private Sub phidgetRFID_Tag(ByVal sender As Object, ByVal e As Phidgets.Events.TagEventArgs) Handles phidgetRFID.Tag
        TextBoxRFID.Text = e.Tag
        SendKeys.Send(e.Tag)
        SendKeys.Send("{ENTER}")
    End Sub

    'Tag lost event handler...here we simply want to clear our tag field in the GUI
    Private Sub phidgetRFID_TagLost(ByVal sender As Object, ByVal e As Phidgets.Events.TagEventArgs) Handles phidgetRFID.TagLost
        TextBoxRFID.Text = ""
    End Sub

    'Enable or disable the RFID antenna by clicking the checkbox
    'Private Sub antennaChk_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles antennaChk.CheckedChanged
    '   phidgetRFID.Antenna = 
    'End Sub

    'turn on and off the onboard LED by clicking the checkox
    'Private Sub ledChk_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ledChk.CheckedChanged
    '   phidgetRFID.LED = ledChk.Checked
    'End Sub

    'turn on and off output 0, to light a LED for example
    'Private Sub output0Chk_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles output0Chk.CheckedChanged
    '   phidgetRFID.outputs(0) = output0Chk.Checked
    'End Sub

    'turn on and off output 1, to light a LED for example
    'Private Sub output1chk_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles output1chk.CheckedChanged
    '   phidgetRFID.outputs(1) = output1chk.Checked
    'End Sub


End Class