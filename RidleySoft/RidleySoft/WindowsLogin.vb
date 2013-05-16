Module WindowsLogin

    ' Makes sure all variables are dimensioned in each subroutine.
    'Option Explicit

    ' Access the GetUserNameA function in advapi32.dll and
    ' call the function GetUserName.
    Declare Function GetUserName Lib "advapi32.dll" Alias "GetUserNameA" _
    (ByVal lpBuffer As String, nSize As Long) As Long

    ' Main routine to Dimension variables, retrieve user name
    ' and display answer.
    Sub Get_User_Name()

        ' Dimension variables
        Dim lpBuff As String = ""
        Dim UserNameWindows As String

        ' Get the user name minus any trailing spaces found in the name.
        lpBuff = System.Security.Principal.WindowsIdentity.GetCurrent().Name
        UserNameWindows = lpBuff.Substring(3)

        ' Display the User Name
        Dim daUsers As DAUser = New DAUser()
        Dim users As List(Of DAUser) = daUsers.GetUsers()
        For Each user In users
            If user.Username = UserNameWindows Then
                UserID = user.UserID
                Username = user.Username
                Password = user.Password
                RightID = user.RightID
            End If
        Next
    End Sub

    Private userID2 As Integer
    Private username2 As String
    Private password2 As String
    Private RightID2 As Integer

    Public Property UserID() As Integer
        Get
            Return userID2
        End Get
        Set(value As Integer)
            userID2 = value
        End Set
    End Property

    Public Property Username() As String
        Get
            Return username2
        End Get
        Set(value As String)
            username2 = value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return password2
        End Get
        Set(value As String)
            password2 = value
        End Set
    End Property

    Public Property RightID() As Integer
        Get
            Return RightID2
        End Get
        Set(value As Integer)
            RightID2 = value
        End Set
    End Property
End Module
