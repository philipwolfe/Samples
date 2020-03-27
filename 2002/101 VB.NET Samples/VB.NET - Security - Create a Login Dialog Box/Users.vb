Option Strict On

Imports System.Security.Principal
Imports System.Threading
Imports System.IO

Public Class Users
    Function IsLogin(ByVal strName As String, ByVal strPassword As String) As Boolean
        ' Procedure checks that the login exists in the XML file

        Dim dsUsers As New DataSet()
        Dim drRows() As DataRow

        Try
            ' Read the XML into a DataSet and filter on name and password
            ' for a collection of DataRows.  This method is not case-sensitive            
            dsUsers.ReadXml("..\Users.xml")
            drRows = dsUsers.Tables(0).Select("name = '" & _
                        strName & "' and password = '" & strPassword & "'")

            ' Code must be implemented when adding users to the list to insure 
            ' that there are no 2 users with the same name 
            ' If there is a row in the collection then a record was found
            If drRows.Length > 0 Then
                Return True
            Else
                Return False
            End If
        Catch e As FileNotFoundException
            MsgBox("Users.Xml file not found.", MsgBoxStyle.Critical, "Unable to Authenticate user.")
            End
        End Try

    End Function

    Function GetLogin(ByVal strName As String, ByVal strPassword As String) As GenericPrincipal
        ' Procedure returns a Generic Principal representing the login account

        Dim dsUsers As New DataSet()
        Dim drRows() As DataRow

        Try
            ' Read the XML into a DataSet and filter for a collection of DataRows
            dsUsers.ReadXml("..\Users.xml")
            drRows = dsUsers.Tables(0).Select("name = '" & _
                    strName & "' and password = '" & strPassword & "'")
        Catch e As FileNotFoundException
            MsgBox("Users.Xml file not found.", MsgBoxStyle.Critical, "Shutting Down...")
            End
        End Try

        ' Create the Generic Identity representing the User
        Dim GenIdentity As New GenericIdentity(strName)
        ' Define the role membership as an array
        Dim Roles() As String = {CStr(drRows(0).Item("Role")), ""}
        Dim GenPrincipal As New GenericPrincipal(GenIdentity, Roles)

        Return GenPrincipal
    End Function

    Function IsAdministrator() As Boolean
        ' Procedure checks if the Windows Login is an Administrator

        ' For single role-based validation
        ' Dim WinPrincipal As New WindowsPrincipal(WindowsIdentity.GetCurrent())

        ' For repeated role-based validation
        AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal)
        Dim WinPrincipal As WindowsPrincipal = CType(Thread.CurrentPrincipal, WindowsPrincipal)

        ' Check if the user account is an Administrator
        If WinPrincipal.IsInRole(WindowsBuiltInRole.Administrator) Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
