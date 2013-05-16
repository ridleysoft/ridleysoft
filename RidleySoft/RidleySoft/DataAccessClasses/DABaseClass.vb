Imports System.Configuration
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient

Public Class DABaseClass
    ''Dim connectionstring As String = ConfigurationManager.ConnectionStrings("RidleySoftConnectionString").ConnectionString
    Dim csBase As String = "Database=ridleysoft;Data Source=10.100.0.34;User Id=admin;Password=lrn191"
    'Dim cs2 As String = "Database=translations;Data Source=10.100.0.34;User Id=admin;Password=lrn191"
    'Dim csLocal As String = "Database=montage;Data Source=127.0.0.1;User Id=root;Password="
    'Dim csNav As String = "Database=NAVDB;Data Source=ZELUS\NAV51;User Id=DATAREADER;Password=DATAREADER"
    Protected connectionBase As MySqlConnection
    'Protected connection2 As MySqlConnection
    'Protected connectionNav As SqlConnection
    'Protected connectionLocal As MySqlConnection

    Protected connections As List(Of String)
    Public Sub DABaseClass()
        connectionBase = New MySqlConnection(csBase)
        '    connection2 = New MySqlConnection(cs2)
        '    connectionNav = New SqlConnection(csNav)
        '    connectionLocal = New MySqlConnection(csLocal)
    End Sub
End Class
