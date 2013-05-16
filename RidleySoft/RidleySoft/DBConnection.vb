Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient

Module DBConnection
    Public cs As String
    Public DBconnectionMYSQL As MySqlConnection
    Public DBConnectionSQL As SqlConnection
    Public sqlconnectie As Boolean
    Sub ConnectionOpen(ByVal dbName As String)
        Dim daDB As DADatabase = New DADatabase()
        Dim db As List(Of DADatabase) = daDB.getdbs()

        For Each item In db
            If item.Database = dbName Then
                If item.Type = "MYSQL" Then
                    sqlconnectie = False
                Else
                    sqlconnectie = True
                End If
                cs = "Database=" & item.Database & ";Data Source=" & item.Source & ";User Id=" & item.UserID & ";Password=" & item.Password
            End If
        Next

        If sqlconnectie = True Then
            DBConnectionSQL = New SqlConnection(cs)
            DBConnectionSQL.Open()
        ElseIf sqlconnectie = False Then
            DBconnectionMYSQL = New MySqlConnection(cs)
            DBconnectionMYSQL.Open()
        End If
    End Sub

    Sub ConnectionClose(ByVal dbName As String)
        Dim daDB As DADatabase = New DADatabase()
        Dim db As List(Of DADatabase) = daDB.getdbs()

        For Each item In db
            If item.Database = dbName Then
                If item.Type = "MYSQL" Then
                    sqlconnectie = False
                Else
                    sqlconnectie = True
                End If
                cs = "Database=" & item.Database & ";Data Source=" & item.Source & ";User Id=" & item.UserID & ";Password=" & item.Password
            End If
        Next

        If sqlconnectie = True Then
            DBConnectionSQL.Close()
        ElseIf sqlconnectie = False Then
            DBconnectionMYSQL.Close()
        End If
    End Sub
End Module

