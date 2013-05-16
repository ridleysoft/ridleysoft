Imports Microsoft.Office.Interop

Public Class FormAddFromExcel
    Private strFileName As String
    Private intCount As Integer
    Private strItemNRs As List(Of String)
    Private menuitems As List(Of String)
    Private types As List(Of String)

    Private intHeadSubMenuID As Integer
    Private strItemmenuname As String
    Private strmod As String
    Private strDES As String
    Private strDBGRPDESC As String
    Private strItemNR As String
    Private strButtongeklikt As String
    Private blnOk As Boolean
    Private intMaxID As Integer

    Private Gelukt As GeluktNietGelukt
    Private GeluktList As List(Of GeluktNietGelukt)
    Private NietGeluktList As List(Of GeluktNietGelukt)

    Private lijstGelukt As List(Of String)
    Private lijstNietGelukt As List(Of String)
    Public Sub Import()
        intCount = 0
        If strFileName <> "OpenFileDialog1" Then
            'we starten excel
            Dim moExcelApp As New Excel.Application()
            'moExcelApp.Visible = True
            'we laden een opgeslagen bestand
            Dim oWBoek As Excel.Workbook = moExcelApp.Workbooks.Open(strFileName)
            'we zorgen ervoor dat het eerste blad in de werkboek het blad is waarmee we werken
            Dim oWBlad As Excel.Worksheet
            oWBlad = oWBoek.Worksheets.Item(1)
            'we maken een range aan
            Dim oRange As Excel.Range
            Dim oRange2 As Excel.Range
            Dim oRange3 As Excel.Range

            'we starten bij A1 om in te lezen
            oRange = oWBlad.Range("A2")
            oRange2 = oWBlad.Range("B2")
            oRange3 = oWBlad.Range("C2")
            Dim j As Integer = 0
            intCount = oWBlad.UsedRange.Rows.Count()

            'Om alle kolommen te overlopen gebruik je
            'oRange.Offset(0, 1)
            'waarbij de 0 staat voor het aantal rijen dat je opschuift en 1 voor het aantal kolommen dat je opschuift

            strItemNRs = New List(Of String)

            For iRij As Integer = 1 To (intCount - 1)
                For iKolom As Integer = 1 To 1
                    'MessageBox.Show(oRange.Value.ToString())

                    strItemNRs.Add(oRange.Value.ToString())
                    oRange = oRange.Offset(0, 1)
                Next
                oRange = oRange.Offset(1, -1)
            Next

            menuitems = New List(Of String)

            For iRij As Integer = 1 To (intCount - 1)
                For iKolom As Integer = 1 To 1

                    menuitems.Add(oRange2.Value.ToString())
                    oRange2 = oRange2.Offset(0, 1)
                Next
                oRange2 = oRange2.Offset(1, -1)
            Next

            types = New List(Of String)

            For iRij As Integer = 1 To (intCount - 1)
                For iKolom As Integer = 1 To 1

                    types.Add(oRange3.Value.ToString())
                    oRange3 = oRange3.Offset(0, 1)
                Next
                oRange3 = oRange3.Offset(1, -1)
            Next
            'excel afsluiten
            moExcelApp.Quit()


            Dim tempStr(2) As String
            Dim tempNode As ListViewItem

            tempStr(2) = Nothing

            For i As Integer = 0 To (strItemNRs.Count() - 1)
                tempStr(0) = strItemNRs(i)
                tempStr(1) = menuitems(i)
                tempStr(2) = types(i)
                tempNode = New ListViewItem(tempStr)
                ListView1.Items.Add(tempNode)
            Next

            ListView1.Show()

            Insert()
        End If
    End Sub

    Private Sub ButtonExcel_Click(sender As Object, e As EventArgs) Handles ButtonExcel.Click
        OpenFileDialog1.ShowDialog()
        strFileName = OpenFileDialog1.FileName
        ListView1.Items.Clear()
        Import()
    End Sub

    Private Sub FormAddFromExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormBorderStyle = Forms.FormBorderStyle.None
        Translate.LoadLanguage(Me)
        ListView1.ShowItemToolTips = True
        ListView1.Width = 780
        ListView1.View = View.Details
        ListView1.Columns.Clear()
        ListView1.Columns.Add("Artikelnr", 125)
        ListView1.Columns.Add("Omschrijving", 250)
        ListView1.Columns.Add("Type", 150)
        ListView1.Columns.Add("Status", 100)
        ListView1.Columns.Add("Reden", 150)
        ListView1.Hide()
    End Sub

    Public Sub Insert()
        GeluktList = New List(Of GeluktNietGelukt)
        NietGeluktList = New List(Of GeluktNietGelukt)

        For i As Integer = 0 To (strItemNRs.Count() - 1)
            Dim daItemchar As DAItemChars = New DAItemChars()
            Dim itemchar As List(Of DAItemChars) = daItemchar.GetItemInfo(strItemNRs(i))

            Dim daintCountitem As DAItems = New DAItems()
            Dim item As DAItems = daintCountitem.GetItemInfo(strItemNRs(i))

            strmod = Nothing
            strDES = Nothing
            strDBGRPDESC = Nothing
            strItemmenuname = Nothing
            strItemNR = Nothing
            If itemchar.Count() = 0 Then
                Gelukt = New GeluktNietGelukt(strItemNRs(i), menuitems(i), "Niet gelukt", types(i), "Item niet in Nav")
                NietGeluktList.Add(Gelukt)
            Else
                For Each item2 In itemchar
                    If item2.Code = "MOD" Then
                        strmod = item2.Value
                    End If
                    If item2.Code = "DES" Then
                        strDES = item2.Value
                    End If
                    If item2.Code = "DB-GRP-DESC" Then
                        strDBGRPDESC = item2.Value
                    ElseIf item2.Code = "MOR" Then
                        strDBGRPDESC = item2.Value
                    End If
                    strItemNR = item2.ItemNr
                Next

                If item.ItemName <> Nothing Then
                    Gelukt = New GeluktNietGelukt(strItemNRs(i), menuitems(i), "Niet gelukt", types(i), "Item reeds in B2B")
                    NietGeluktList.Add(Gelukt)
                Else

                    Dim daImage As DAMenuItemImage = New DAMenuItemImage()
                    Dim itemMenuImage As DAMenuItemImage = daImage.getImageByModelDesign(strmod, strDES)
                    Dim daSetting As DASettings = New DASettings()
                    Dim setting As DASettings = daSetting.getImageLink("Image")

                    strItemmenuname = (strmod & " " & strDES & " " & strDBGRPDESC)

                    Dim daItemMenu As DAItemMenu = New DAItemMenu()
                    Dim itemmenu As DAItemMenu = daItemMenu.GetItemInfo(strItemmenuname)

                    Dim datypemenu As DATypeMenu = New DATypeMenu()
                    Dim typemenu As DATypeMenu = datypemenu.GetTypeMenuByName(types(i))

                    Dim maxMenuOrder As Integer = daItemMenu.getMaxMenuOrder(typemenu.TypeMenuID)
                    MainForm.intMaxMenuOrder2 = (maxMenuOrder + 1)
                    Dim intMaxIDD As Integer = daItemMenu.getMaxID()
                    intMaxID = intMaxIDD


                    If itemMenuImage.Model <> Nothing Then
                        If itemMenuImage.Image = "" Then
                            Dim insertImage As DAMenuItemImage = New DAMenuItemImage(strmod, strDES, "")
                            daImage.InsertItemMenu(insertImage)
                        End If
                    End If
                    If itemmenu.ItemName <> Nothing Then
                        blnOk = True
                    Else
                        Dim insertItemmenu As DAItemMenu = New DAItemMenu(intMaxID + 1, strItemmenuname, (MainForm.intMaxMenuOrder2), typemenu.TypeMenuID, "/site/itemmenu", Nothing, 1)
                        If types(i) = Nothing Then
                            daItemMenu.InsertItemMenuActie(insertItemmenu)
                        Else
                            daItemMenu.InsertItemMenu(insertItemmenu)
                        End If

                        If blnOk = True Then
                            Dim daItem As DAItems = New DAItems()
                            Dim maxItemOrder As Integer = daItem.getMaxItemOrder(MainForm.intMaxMenuOrder2)

                            Dim itemAdd As DAItems = New DAItems(strItemNR, strItemmenuname, MainForm.intMaxMenuOrder2, (maxItemOrder + 1), 1)
                            daItem.InsertItemMenu(itemAdd)

                            Dim daHeadsubmenuItem As DAHeadSubMenuToTypeItem = New DAHeadSubMenuToTypeItem()

                            If types(i) = Nothing Then
                                Dim headsubmenuitemActie As DAHeadSubMenuToTypeItem = New DAHeadSubMenuToTypeItem(0, intHeadSubMenuID, typemenu.TypeMenuID, intMaxID)
                                'MessageBox.Show((headSubMenuID & "->" & itemMenuClicked & "->" & intMaxID).ToString())
                                daHeadsubmenuItem.InsertItemMenuActie(headsubmenuitemActie)
                            Else
                                Dim headsubmenuitemAnders As DAHeadSubMenuToTypeItem = New DAHeadSubMenuToTypeItem(0, intHeadSubMenuID, typemenu.TypeMenuID, intMaxID)
                                'MessageBox.Show((headSubMenuID & "->" & itemMenuClicked & "->" & intMaxID).ToString())
                                daHeadsubmenuItem.InsertItemMenu(headsubmenuitemAnders)
                            End If
                        End If

                        Gelukt = New GeluktNietGelukt(strItemNRs(i), menuitems(i), "Gelukt", types(i), "")
                        GeluktList.Add(Gelukt)
                        blnOk = True
                    End If
                End If
            End If
        Next
        'ListView2.Show()

        Dim tempStr(4) As String
        Dim tempNode As ListViewItem

        ListView1.Items.Clear()
        tempStr(4) = Nothing

        For Each item In GeluktList
            tempStr(0) = item.Itemnr
            tempStr(1) = item.ItemName
            tempStr(2) = item.Type
            tempStr(3) = item.Status
            tempNode = New ListViewItem(tempStr)
            ListView1.Items.Add(tempNode)
        Next

        For Each item In NietGeluktList
            tempStr(0) = item.Itemnr
            tempStr(1) = item.ItemName
            tempStr(2) = item.Type
            tempStr(3) = item.Status
            tempStr(4) = item.Reden
            tempNode = New ListViewItem(tempStr)
            ListView1.Items.Add(tempNode)
        Next
    End Sub
End Class