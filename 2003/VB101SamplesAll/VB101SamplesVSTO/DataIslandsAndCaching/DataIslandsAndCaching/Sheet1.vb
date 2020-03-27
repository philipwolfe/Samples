
Public Class Sheet1

    ' This will automatically be persisted by the VSTO framework
    ' based on the attribute (declarative).
    <Cached()> _
    Public ds As AdventureWorks_DataDataSet

    Dim eta As AdventureWorks_DataDataSetTableAdapters.EmployeeTableAdapter
    Dim ebs As BindingSource

    ' This will be set to be cached manually (imperative).
    ' Any cached object must be a read/write public property/member
    ' which meets the requirements of XmlSerializer and is not null.
    Public cachedString As String


    Private Sub Sheet1_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup
        ' If A1 and C2 are not cleared, it could be confusing.
        ' Since they are being used as status indicators, it makes
        ' sense to clear them as soon as the document is opened.
        Me.Range("B1").Value2 = Nothing
        Me.Range("C2").Value2 = Nothing

        CacheDataSet()
        CacheStringObject()
    End Sub

    ''' <summary>
    ''' To provide a robust solution, data should always be read from
    ''' the underlying source is online.  If offline, the data should
    ''' be pulled from cache, if present.
    ''' </summary>
    Private Sub CacheDataSet()
        Dim status As String
        ' Start by trying to read live data.  If successfull, use this data,
        ' but indicate that cached data was found.
        Try
            eta = New DataIslandsAndCaching.AdventureWorks_DataDataSetTableAdapters.EmployeeTableAdapter

            Dim ds2 As AdventureWorks_DataDataSet = New AdventureWorks_DataDataSet
            eta.Fill(ds2.Employee)

            If ds Is Nothing Then
                status = "ONLINE, LIVE DATA IN USE, NO CACHED DATA FOUND"
            Else
                status = "ONLINE, LIVE DATA IN USE, CACHED DATA FOUND"
            End If
            ds = ds2
        Catch e As Exception
            If ds Is Nothing Then
                status = "OFFLINE, NO CACHED DATA FOUND"
                ds = New AdventureWorks_DataDataSet
            Else
                status = "OFFLINE, CACHED DATA FOUND"
            End If
        End Try

        ebs = New BindingSource(ds.Employee, "")
        employeesList.SetDataBinding(ebs, "", "NationalIDNumber", "LoginID", "Title", "HireDate", "BirthDate")
        Me.Range("B1", System.Type.Missing).Value2 = status
    End Sub

    ''' <summary>
    ''' Set "cachedString" to be a cached object if not already.
    ''' Note: The reference must not be null to be cacheable.
    ''' </summary>
    Private Sub CacheStringObject()
        If Not Me.IsCached("cachedString") Then
            cachedString = String.Format("CACHED: {0:d} @ {0:t}", DateTime.Now)
            Me.StartCaching("cachedString")
            Me.Range("C2").Value2 = "Data in cache was not set.  Save and re-open the document and the data will persist."
        End If

        ' If object is already cached, the value will be set upon initialization
        Me.Range("B2", System.Type.Missing).Value2 = cachedString
    End Sub

    Private Sub Sheet1_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown

    End Sub

End Class
