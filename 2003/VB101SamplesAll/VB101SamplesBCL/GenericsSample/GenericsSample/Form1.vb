Public Class Form1

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Create the two lists
        _unsafeList = New ArrayList()
        _safeList = New List(Of Order)()

        ' Load in the sample objects
        LoadObjects()

    End Sub

    Private Sub LoadObjects()

        ' Load in a set of order objects
        Me.masterObjectList.Items.Add(New Order(1, DateTime.Now, 200))
        Me.masterObjectList.Items.Add(New Order(2, DateTime.Now, 200))
        Me.masterObjectList.Items.Add(New Order(3, DateTime.Now, 200))
        Me.masterObjectList.Items.Add(New Order(4, DateTime.Now, 200))

        ' and a number of other types
        Dim aString As String = "test String"
        Dim anInt As Integer = 2
        Dim aLong As Long = 300
        Dim aFloat As Single = 300.0F
        Dim anObject As Object = New Object

        Me.masterObjectList.Items.Add(aString)
        Me.masterObjectList.Items.Add(anInt)
        Me.masterObjectList.Items.Add(aLong)
        Me.masterObjectList.Items.Add(aFloat)
        Me.masterObjectList.Items.Add(anObject)

    End Sub

    Private Sub AddSafeList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddSafeList.Click

        ' try to add the object to the list and write the exception
        ' to the log window
        ' You have to cast the object to order for the code to even compile
        ' hence the name compile type safety
        For Each o As Object In masterObjectList.CheckedItems
            Try
                _safeList.Add(CType(o, Order))
                Me.safeObjectList.Items.Add(o)
            Catch ex As Exception
                Me.exceptionLog.Text += ex.Message + "" & Microsoft.VisualBasic.Chr(13) & "" & Microsoft.VisualBasic.Chr(10) & ""
            End Try
        Next

    End Sub

    Private Sub AddUnsafeList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddUnsafeList.Click

        ' try to add the object to the list and write the exception
        ' to the log window
        ' here no casting is needed as everything in the list is an object
        For Each o As Object In masterObjectList.CheckedItems
            Try
                _unsafeList.Add(o)
                Me.unsafeObjectList.Items.Add(o)
            Catch ex As Exception
                Me.exceptionLog.Text += ex.Message + "" & Microsoft.VisualBasic.Chr(13) & "" & Microsoft.VisualBasic.Chr(10) & ""
            End Try
        Next

    End Sub

    Private Sub startSpeedTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startSpeedTest.Click

        ' Add 10000 items to a list and then iterate over the list
        Dim newUnsafeList As ArrayList = New ArrayList
        Dim newSafeList As List(Of Order) = New List(Of Order)

        Dim stopWatch As Stopwatch = New Stopwatch
        Dim loadSafeListMs As Long
        Dim loadUnsafeMs As Long
        Dim iterateSafeListMs As Long
        Dim iterateUnsafeListMs As Long

        stopWatch.Start()
        Dim i As Integer = 1
        While i < 100000
            Dim newOrder As Order = New Order(i, DateTime.Now, i + 100)
            newSafeList.Add(newOrder)
            i += 1
        End While
        stopWatch.Stop()
        loadSafeListMs = stopWatch.ElapsedMilliseconds
        stopWatch.Reset()


        stopWatch.Start()
        Dim i2 As Integer = 1
        While i2 < 100000
            Dim newOrder As Order = New Order(i2, DateTime.Now, i2 + 100)
            newUnsafeList.Add(newOrder)
            i2 += 1
        End While
        stopWatch.Stop()
        loadUnsafeMs = stopWatch.ElapsedMilliseconds
        stopWatch.Reset()


        stopWatch.Start()
        IterateSafeList(newSafeList)
        stopWatch.Stop()
        iterateSafeListMs = stopWatch.ElapsedMilliseconds
        stopWatch.Reset()


        stopWatch.Start()
        IterateUnsafeList(newUnsafeList)
        stopWatch.Stop()
        iterateUnsafeListMs = stopWatch.ElapsedMilliseconds
        stopWatch.Reset()


        Me.LoadSafeListMs.Text = loadSafeListMs.ToString
        Me.LoadUnsafeListMs.Text = loadUnsafeMs.ToString
        Me.iterateSafeListMs.Text = iterateSafeListMs.ToString
        Me.IterateUnsafeListMs.Text = iterateUnsafeListMs.ToString

    End Sub

    Private Sub IterateUnsafeList(ByVal list As ArrayList)

        ' No casting needed
        For Each _object As Object In list
            Dim _order As Order = CType(_object, Order)
            If Not (_order Is Nothing) Then
                Dim _amount As Long = _order.Amount
                Dim _orderDate As DateTime = _order.OrderDate
                Dim orderID As Integer = _order.ID
            End If
        Next

    End Sub

    Private Sub IterateSafeList(ByVal list As List(Of Order))

        ' have to cast from object to order
        For Each _order As Order In list
            Dim _amount As Long = _order.Amount
            Dim _orderDate As DateTime = _order.OrderDate
            Dim orderID As Integer = _order.ID
        Next

    End Sub


    Private _unsafeList As ArrayList
    Private _safeList As List(Of Order)
End Class
