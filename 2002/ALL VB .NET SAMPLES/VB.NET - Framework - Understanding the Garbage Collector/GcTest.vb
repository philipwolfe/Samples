Option Explicit On 

' Sets up the class that is used to test the Garbage Collector. 
Public Class GcTest

    ' Two private variables are declared. One for the name of the
    '   current object and one to hold a GcTest child object.
    Private m_Name As String
    Private m_Child As GcTest

    ' Events should be declared with a corresponding event handler. This
    ' combination is used when relevant changes occur in the object.
    ' Verify that the declared event is of the type defined by the delegate.
    Public Delegate Sub InfoEventHandler(ByVal message As String)
    Public Event ObjectGcInfo As InfoEventHandler

    ' Ensure a constructor is created that accepts two parameters -- the
    ' name of the object and the number of levels of child
    ' elements that should be created.
    ' New() is the keyword used to create a constructor in Visual Basic.NET.
    Public Sub New(ByVal name As String, ByVal numLevels As Integer)
        ' Just set the name of the current object to the passed name parameter.
        m_Name = name

        ' Only objects declared using WithEvents will receive this
        ' event, since event handlers pointed to by AddHandler can only
        ' be associated after the object is created. Since in this How-To, they
        ' are created dynamically, this event won't be caught.
        RaiseEvent ObjectGcInfo(m_Name + " Created")

        ' Ensure the object hierarchy isn't too deep, since it doesn't help with
        ' understanding the Garbage Collector and it makes for 
        ' a messy user iterface.
        ' Limit the number of levels to 5.
        If numLevels > 5 Then
            numLevels = 5
        End If

        ' Begin by testing that the numLevels is greater than zero, so 
        '   that our hierarchy is limited. If it is greater than zero, then
        '   create a child object, naming it the name of the current object
        '   except prefixing it with an "*" to distinguish it. Also, be sure
        '   to decrement the number of 
        '   levels (so that it doesn't create objects indefinitely).
        If numLevels > 0 Then
            m_Child = New GcTest("*" + m_Name, numLevels - 1)
            ' ObjectGcInfo can be raised by the child object, as well
            '   as this object, so ensure that the myChildHandler has been
            '   associated with the child's ObjectGcInfo event.
            AddHandler m_Child.ObjectGcInfo, AddressOf myChildHandler
        End If


    End Sub

    ' Return the GC Generation as a read-only property.
    Public ReadOnly Property Generation() As Integer
        Get
            ' GetGeneration returns the generation of the current object.
            Return GC.GetGeneration(Me)
        End Get
    End Property

    Public ReadOnly Property Name() As String
        Get
            ' Return the name of the current object.
            Return m_Name
        End Get
    End Property

    ' Declare a Dispose method.
    Sub Dispose(Optional ByVal isFinalizeSupressed As Boolean = True)
        ' If SuppressFinalize is requested, tell the Garbage Collector
        '   to suppress the finalization of this object. This can dramatically
        '   increase the performance of the garbage collector.
        If isFinalizeSupressed Then
            GC.SuppressFinalize(Me)
        End If

        ' Dispose of any Children and set them to Nothing
        If Not m_Child Is Nothing Then
            m_Child.Dispose(isFinalizeSupressed)
            m_Child = Nothing
        End If

        ' Raise event showing that the object was disposed. Include in
        '   parenthesis the value of SuppressFinalize.
        RaiseEvent ObjectGcInfo(m_Name + " Disposed (" + _
            isFinalizeSupressed.ToString() + ")")

    End Sub

    ' This function kills the object with the name passed
    '   in the parameter. It is called recursively through
    '   the entire hierarchy. It returns true if the object
    '   was killed, false otherwise.
    Public Function DisposeChildNamed(ByVal name As String, _
        ByVal isFinalizeSupressed As Boolean) As Boolean

        ' Check to see if m_child is nothing
        If Not m_Child Is Nothing Then
            ' Check to see if the current child is the object
            '   to be disposed of.
            If m_Child.Name = name Then
                ' Dispose of m_Child
                m_Child.Dispose(isFinalizeSupressed)
                Return True
            Else
                ' Try to find object to Dispose by searching through
                '   child hierarchy.
                m_Child.DisposeChildNamed(name, isFinalizeSupressed)
            End If
        Else
            ' We've reached the end of the chain and 
            '   didn't find the object so return False
            Return False
        End If

    End Function

    ' This function returns an ArrayList containing the names
    '   of all of the created objects and their children.
    Public Function GetSelfAndChildGenerations() As ArrayList

        ' Create an ArrayList to use.
        Dim myArrayList As ArrayList

        ' If child exists, call the GetSelfAndChildNames() function
        '   recursively, to get list of children.
        If Not m_Child Is Nothing Then
            ' Get ArrayList from child.
            myArrayList = m_Child.GetSelfAndChildGenerations()
        Else
            ' No child exists, so the program is at the bottom
            '   of its chain. Create a new ArrayList.
            myArrayList = New ArrayList()
        End If

        ' Add the name of the current object to the ArrayList at the
        '   first position.
        myArrayList.Insert(0, m_Name + " - Gen: " + Me.Generation.ToString())

        ' Return the ArrayList.
        Return myArrayList

    End Function

    ' This function returns an ArrayList containing the names
    '   of all of the created objects and their children.
    Public Function GetSelfAndChildNames() As ArrayList

        ' Create an ArrayList to use.
        Dim myArrayList As ArrayList

        ' If child exists, call the GetSelfAndChildNames() function
        '   recursively, to get list of children.
        If Not m_Child Is Nothing Then
            ' Get ArrayList from child.
            myArrayList = m_Child.GetSelfAndChildNames()
        Else
            ' No child exists, so the program is at the bottom
            '   of its chain. Create a new ArrayList.
            myArrayList = New ArrayList()
        End If

        ' Add the name of the current object to the ArrayList at the
        '   first position.
        myArrayList.Insert(0, m_Name)

        ' Return the ArrayList.
        Return myArrayList

    End Function

    ' Override the Finalize method to raise information
    Protected Overrides Sub Finalize()
        ' Let the parent of this object know that
        '   finalization was called.
        RaiseEvent ObjectGcInfo(m_Name + " Finalized")
    End Sub

    ' This function kills the object with the name passed
    '   in the parameter. It is called recursively through
    '   the entire hierarchy. It returns true if the object
    '   was killed, false otherwise.
    Public Function KillChildNamed(ByVal name As String) As Boolean

        ' Check to see if m_child is nothing
        If Not m_Child Is Nothing Then
            ' Check to see if the current child is the object
            '   to be disposed of.
            If m_Child.Name = name Then
                ' Kill m_Child
                m_Child = Nothing
                Return True
            Else
                ' Try to find object to kill by searching through
                '   child hierarchy.
                m_Child.KillChildNamed(name)
            End If
        Else
            ' We've reached the end of the chain and 
            '   didn't find the object so return False
            Return False
        End If
    End Function

    ' Set up an event handler for the child that will simply
    '   pass the events up the chain.
    Public Sub myChildHandler(ByVal message As String)
        ' Raise an ObjectGcInfo event, passing the information
        '   up the object tree.
        RaiseEvent ObjectGcInfo(message)
    End Sub

    ' Override the ToString to return the name of the object.
    Public Overrides Function ToString() As String
        Return m_Name
    End Function
End Class
