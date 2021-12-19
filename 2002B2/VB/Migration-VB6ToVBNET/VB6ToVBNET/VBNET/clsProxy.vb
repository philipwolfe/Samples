Option Strict Off
Option Explicit On
Namespace LangDemo
	Class clsProxy
		Implements _clsAbstract
		
		
		Dim m_CustomerName As String
		
		Public  Property clsAbstract_CustomerName() As String Implements _clsAbstract.CustomerName
			Get
				clsAbstract_CustomerName = m_CustomerName
			End Get
			Set
				m_CustomerName = Value
			End Set
		End Property
		
	End Class
End NameSpace