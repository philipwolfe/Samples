Option Strict Off
Option Explicit On
Namespace LangDemo
	Class clsCustomer
		
		Dim cProxy As clsProxy = New clsProxy
		Dim m_ID As Short
		
		Property CustomerName() As String
			Get
				CustomerName = cProxy.clsAbstract_CustomerName
			End Get
			Set
				cProxy.clsAbstract_CustomerName = Value
			End Set
		End Property
		
        Function GetIDFromTextBox(ByRef txt As System.Windows.Forms.TextBox) As Object
            m_ID = CShort(txt.Text)
        End Function
    End Class
End NameSpace