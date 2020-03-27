Public Class Order

    Public Sub New(ByVal orderID As Integer, ByVal orderDate As DateTime, ByVal orderAmount As Long)
        Me.m_orderID = orderID
        Me.m_orderDate = orderDate
        Me.m_orderAmount = orderAmount
    End Sub

    Public Property ID() As Integer
        Get
            Return m_orderID
        End Get
        Set(ByVal value As Integer)
            m_orderID = value
        End Set
    End Property

    Public Property OrderDate() As DateTime
        Get
            Return m_orderDate
        End Get
        Set(ByVal value As DateTime)
            m_orderDate = value
        End Set
    End Property

    Public Property Amount() As Long
        Get
            Return m_orderAmount
        End Get
        Set(ByVal value As Long)
            m_orderAmount = value
        End Set
    End Property

    Public Overloads Overrides Function ToString() As String
        Return String.Format("{0}, {1}, {2}", m_orderID, m_orderDate, m_orderAmount)
    End Function


    Private m_orderID As Integer
    Private m_orderDate As DateTime
    Private m_orderAmount As Long

End Class
