Option Strict On
Option Explicit On 

'  This class is used to store the text and primary key of a record
'  that you want to list in list box.

Public Class ListItem
    Private mValue As String   ' Stores a named description of the item
    Private mID As Integer     ' Stores a primary key to the record

    Public Sub New(ByVal strValue As String, ByVal intID As Integer)
        mValue = strValue
        mID = intID
    End Sub

    Public Sub New()
        mValue = ""
        mID = 0
    End Sub

    Property ID() As Integer
        Get
            Return mID
        End Get
        Set(ByVal Value As Integer)
            mID = Value
        End Set
    End Property

    Property Value() As String
        Get
            Return mValue
        End Get
        Set(ByVal Value As String)
            mValue = Value
        End Set
    End Property

    ' When a list box displays an item in its collection
    ' it calls the ToString method to get the value to
    ' display so we will need to override this method
    ' so our class will return mValue.
    Public Overrides Function ToString() As String
        Return mValue
    End Function
End Class
