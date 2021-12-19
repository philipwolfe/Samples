Imports System.IO.Directory
Imports System.Data.OleDb

Namespace Pooch
    
    Public Class clsPoochData

        'This object will be used for connecting to the DB
        Private cn As OleDbConnection

        'The Browse method for getting all the pooches.
        Overloads Function BrowseByBreed() As DataSet
            BrowseByBreed = Me.GetAllBreeds()
            
        End Function
        
        'Browse method to return all the pooches or by particular breed
        Overloads Function BrowseByBreed(ByVal lngBreed As Long) As DataSet
            
            If lngBreed > 0 Then
                BrowseByBreed = Me.GetByBreed(lngBreed)
            Else
                BrowseByBreed = Me.GetAll()
            End If
            
        End Function
        
        'Method to return all pooches by City
        Overloads Function BrowseByCity(ByVal strCity As String) As DataSet
            BrowseByCity = Me.GetByCity(strCity)
            
        End Function
        
        'Method to return all pooches By City and Breed
        Overloads Function BrowseByCity(ByVal strCity As String, ByVal lngBreed As Long) As DataSet
            BrowseByCity = Me.GetByCityBreed(strCity, lngBreed)
            
        End Function
        
        'Method to return all pooches by State
        Overloads Function BrowseByState(ByVal strState As String) As DataSet
            BrowseByState = Me.GetByState(strState)
            
        End Function
        
        'Method to return all pooches by State and City
        Overloads Function BrowseByState(ByVal strState As String, ByVal strCity As String) As DataSet
            BrowseByState = Me.GetByStateCity(strState, strCity)
            
        End Function
        
        'Method to return all pooches by State and Breed
        Overloads Function BrowseByState(ByVal strState As String, ByVal lngBreed As Long) As DataSet
            BrowseByState = Me.GetByStateBreed(strState, lngBreed)
            
        End Function
        
        'Method to return all pooches by State, City, and Breed
        Overloads Function BrowseByState(ByVal strState As String, ByVal strCity As String, ByVal lngBreed As Long) As DataSet
            BrowseByState = Me.GetByStateCityBreed(strState, strCity, lngBreed)
            
        End Function
        
        
        'Method to Return all Breeds in DB
        Private Function GetAllBreeds() As DataSet
            Dim dsBreeds As DataSet
            Dim dsCmd As OleDbDataAdapter
            Dim dsRow As DataRow
            Dim strSQL As String

            strSQL = "SELECT DISTINCT breedid,breeddesc FROM breeds ORDER BY breedid"

            'Create a new dataset object.
            dsBreeds = New DataSet()
            'Create a new OleDbDataAdapter object
            dsCmd = New OleDbDataAdapter(strSQL, cn)
            'Populate the dataset.
            dsCmd.Fill(dsBreeds, "breeds")

            GetAllBreeds = dsBreeds
            
            dsBreeds = Nothing
            dsCmd = Nothing
            dsRow = Nothing
            
        End Function
        
        'Internal method for getting all the pooches from the DB.
        Private Function GetAll() As DataSet
            Dim dsDogs As DataSet
            Dim dsCmd As OleDbDataAdapter
            Dim dsRow As DataRow
            Dim strSQL As String
            
            strSQL = "SELECT dogs.Name,dogs.City,dogs.State,breeds.breeddesc AS Breeds " _
                    & "FROM dogs INNER JOIN BREEDS ON dogs.breedid = breeds.breedid"
            
            dsDogs = New DataSet()
            dsCmd = New OleDbDataAdapter(strSQL, cn)
            dsCmd.Fill(dsDogs, "dogs")
            
            GetAll = dsDogs
            
            dsDogs = Nothing
            dsCmd = Nothing
            dsRow = Nothing
            
        End Function
        
        'Internal method for getting pooches by state from the DB.
        Private Function GetByState(ByVal strState As String) As DataSet
            Dim dsDogs As DataSet
            Dim dsCmd As OleDbDataAdapter
            Dim dsRow As DataRow
            Dim strSQL As String
            
            strSQL = "SELECT Name,City,State,breeds.breeddesc AS Breed FROM dogs INNER JOIN BREEDS ON dogs.breedid = breeds.breedid WHERE state = '" & strState & "'"
            
            dsDogs = New DataSet()
            dsCmd = New OleDbDataAdapter(strSQL, cn)
            dsCmd.Fill(dsDogs, "dogs")
            
            GetByState = dsDogs
            
        End Function
        
        'Internal method for getting pooches by breed from the DB.
        Private Function GetByBreed(ByVal lngBreed As Long) As DataSet
            Dim dsDogs As DataSet
            Dim dsCmd As OleDbDataAdapter
            Dim dsRow As DataRow
            Dim strSQL As String
            
            strSQL = "SELECT Name,City,State,breeds.breeddesc AS Breed FROM dogs INNER JOIN BREEDS ON dogs.breedid = breeds.breedid WHERE breeds.breedid = " & lngBreed
            
            dsDogs = New DataSet()
            dsCmd = New OleDbDataAdapter(strSQL, cn)
            dsCmd.Fill(dsDogs, "dogs")
            
            GetByBreed = dsDogs
            
        End Function
        
        'Internal method for getting pooches by city and state from the DB.
        Private Function GetByStateCity(ByVal strState As String, ByVal strCity As String) As DataSet
            Dim dsDogs As DataSet
            Dim dsCmd As OleDbDataAdapter
            Dim dsRow As DataRow
            Dim strSQL As String
            
            strSQL = "SELECT Name,City,State,breeds.breeddesc AS Breed FROM dogs INNER JOIN BREEDS ON dogs.breedid = breeds.breedid WHERE city = '" & strCity & "' and state = '" & strState & "'"
            
            dsDogs = New DataSet()
            dsCmd = New OleDbDataAdapter(strSQL, cn)
            dsCmd.Fill(dsDogs, "dogs")
            
            GetByStateCity = dsDogs
            
        End Function
        
        'Internal method for getting pooches by city, state and breed from the DB.
        Private Function GetByStateCityBreed(ByVal strState As String, ByVal strCity As String, ByVal lngBreed As Long) As DataSet
            Dim dsDogs As DataSet
            Dim dsCmd As OleDbDataAdapter
            Dim dsRow As DataRow
            Dim strSQL As String
            
            strSQL = "SELECT Name,City,State,breeds.breeddesc AS Breed FROM dogs INNER JOIN BREEDS ON dogs.breedid = breeds.breedid WHERE city = '" & strCity & "' and state = '" & strState & "' and breeds.breedid = " & lngBreed
            
            dsDogs = New DataSet()
            dsCmd = New OleDbDataAdapter(strSQL, cn)
            dsCmd.Fill(dsDogs, "dogs")
            
            GetByStateCityBreed = dsDogs
            
        End Function
        
        'Internal method for getting pooches by state and breed from the DB.
        Private Function GetByStateBreed(ByVal strState As String, ByVal lngBreed As Long) As DataSet
            Dim dsDogs As DataSet
            Dim dsCmd As OleDbDataAdapter
            Dim dsRow As DataRow
            Dim strSQL As String
            
            strSQL = "SELECT Name,City,State,breeds.breeddesc As Breed FROM dogs INNER JOIN BREEDS ON dogs.breedid = breeds.breedid WHERE state = '" & strState & "' and breeds.breedid = " & lngBreed
            
            dsDogs = New DataSet()
            dsCmd = New OleDbDataAdapter(strSQL, cn)
            dsCmd.Fill(dsDogs, "dogs")
            
            GetByStateBreed = dsDogs
            
        End Function
        
        'Internal method for getting pooches by city from the DB.
        Private Function GetByCity(ByVal strCity As String) As DataSet
            Dim dsDogs As DataSet
            Dim dsCmd As OleDbDataAdapter
            Dim dsRow As DataRow
            Dim strSQL As String
            
            strSQL = "SELECT Name,City,State,breeds.breeddesc AS Breed FROM dogs INNER JOIN BREEDS ON dogs.breedid = breeds.breedid WHERE City = '" & strCity & "'"
            
            dsDogs = New DataSet()
            dsCmd = New OleDbDataAdapter(strSQL, cn)
            dsCmd.Fill(dsDogs, "dogs")
            
            GetByCity = dsDogs
            
        End Function
        
        'Internal method for getting pooches by Breed and City
        Private Function GetByCityBreed(ByVal strCity As String, ByVal lngBreed As Long) As DataSet
            Dim dsDogs As DataSet
            Dim dsCmd As OleDbDataAdapter
            Dim dsRow As DataRow
            Dim strSQL As String
            
            strSQL = "SELECT Name,City,State,breeds.breeddesc AS Breed FROM dogs INNER JOIN BREEDS ON dogs.breedid = breeds.breedid WHERE City = '" & strCity & "' and breeds.breedid = " & lngBreed
            
            dsDogs = New DataSet()
            dsCmd = New OleDbDataAdapter(strSQL, cn)
            dsCmd.Fill(dsDogs, "dogs")
            
            GetByCityBreed = dsDogs
        End Function

        Public Sub New()
            cn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Environment.CurrentDirectory & "\FindAPooch.mdb;")
        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()

            If Not (cn Is Nothing) Then
                cn.Close()
                cn = Nothing
            End If
        End Sub
End Class
End Namespace