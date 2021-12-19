Option Strict Off
Option Explicit On
Namespace LangDemo
Interface _clsAbstract
        Property CustomerName() As String
End Interface
	Class clsAbstract
		Implements _clsAbstract
		
		Property CustomerName() As String Implements _clsAbstract.CustomerName
			Get
				
			End Get
			Set
				
			End Set
		End Property
		
	End Class
End NameSpace