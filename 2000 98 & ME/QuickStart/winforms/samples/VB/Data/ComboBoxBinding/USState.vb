'/------------------------------------------------------------------------------
'// <copyright from='1997' to='2001' company='Microsoft Corporation'>           
'//    Copyright (c) Microsoft Corporation. All Rights Reserved.                
'//       
'//    This source code is intended only as a supplement to Microsoft
'//    Development Tools and/or on-line documentation.  See these other
'//    materials for detailed information regarding Microsoft code samples.
'//
'// </copyright>                                                                
'/------------------------------------------------------------------------------
namespace Microsoft.Samples.WinForms.VB.ComboBoxBinding 
    
    public class USState 
        
        private strShortName As String
	    private strLongName As String

        public Sub New(ByVal strlongName As String , ByVal strShortName As String)  
            MyBase.New
            Me.strShortName = strShortName
	        Me.strLongName = strLongName 
        End Sub

        public ReadOnly Property ShortName() As String
		    Get
			    return strShortName
		    End Get
	    End Property
	
        public ReadOnly Property LongName() As String
		    Get
			    return strLongName
		    End Get
       end property
       
    End Class

End Namespace
