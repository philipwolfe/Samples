Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls 
Imports ASPEnterpriseManager
Imports Microsoft.VisualBasic

Namespace ASPEnterpriseManager.Controls

		Public Class Tristate_Checkbox
				Inherits System.Web.UI.UserControl
				Protected WithEvents tri_checkbox As System.Web.UI.WebControls.ImageButton
				Protected WithEvents CheckValue1  As System.Web.UI.WebControls.RadioButton
				Protected WithEvents CheckValue2  As System.Web.UI.WebControls.RadioButton
				Protected WithEvents CheckValue3  As System.Web.UI.WebControls.RadioButton
			
						
				Sub Page_Load(Sender As System.Object, E As System.EventArgs) 
					Dim S as String
					'if not Page.IsPostBack Then
						S = "<script language=""javascript"">"
						S = S & "function changeTriStateCheckBox(cb) { "
						S = S & "    var imageName = cb.src;"
						S = S & "    var inArray = imageName.split(""/"");"
						S = S & "	 imageName = inArray[inArray.length - 1];"
						S = S & " 	 if (imageName==""tristate_unchecked.gif"") { " 
						S = S & "		cb.src = ""tristate_checked.gif"";"
						S = S & "	  } else if (imageName==""tristate_checked.gif"") { " 
						S = S & "		cb.src = ""tristate_redx.gif"";"
						S = S & "	  } else if (imageName==""tristate_redx.gif"") { " 
						S = S & "		cb.src = ""tristate_unchecked.gif"";"
						S = S & "		document.forms(""P"").elements(""GRANT"").checked = true;"
						S = S & "	  }"
						S = S & "	 return false; "
						S = S & "}"
						S = S & "</script>"
						
						If Not Page.IsClientScriptBlockRegistered("TriStateScript") Then
							Page.RegisterClientScriptBlock("TriStateScript", S)
					   End If
					   tri_checkbox.Attributes.Add("onClick", "return changeTriStateCheckBox(this);")
						tri_checkbox.ImageURL = "tristate_checked.gif"
					'end If
				End Sub
				
				
				Public Property Value As String					
					Get
						Select Case tri_checkbox.ImageURL
							Case "tristate_checked.gif": Return ("GRANT")
							Case "tristate_redx.gif": Return ("DENY")
							Case Else : Return (tri_checkbox.ImageURL)		  
						End Select
					End Get
					Set
						Select Case Trim(Value)
							Case "GRANT": tri_checkbox.ImageURL = "tristate_checked.gif"
							Case "DENY": tri_checkbox.ImageURL = "tristate_redx.gif"
							Case Else : tri_checkbox.ImageURL = "tristate_unchecked.gif"				  
						End Select
						
					End Set
				End Property	
				
				
		End Class	


End Namespace	