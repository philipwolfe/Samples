'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.312
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On


Namespace ns0
    
    '''<remarks/>
    <System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Web.Services.WebServiceBindingAttribute(Name:="PickServiceSoap", [Namespace]:="http://tempuri.org/"), _
     Microsoft.Workflow.Bpel.Activities.WsdlBindingPortTypeAttribute("PickServiceSoap", "http://tempuri.org/")> _
    Partial Public Class PickService
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol

        '''<remarks/>
        Public Sub New()
            MyBase.New()
            Me.Url = "http://localhost:8083/PickService/PickService.asmx"
        End Sub

        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SendString", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)> _
        Public Sub SendString(ByVal message As String)
            Me.Invoke("SendString", New Object() {message})
        End Sub
    End Class

    '''<remarks/>
    <System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://tempuri.org/"), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://tempuri.org/", IsNullable:=False), _
     Microsoft.Workflow.Bpel.Activities.XsdComplexTypeAttribute()> _
    Partial Public Class SendString

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Order:=0)> _
        Public message As String
    End Class

    '''<remarks/>
    <System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://tempuri.org/"), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://tempuri.org/", IsNullable:=False), _
     Microsoft.Workflow.Bpel.Activities.XsdComplexTypeAttribute()> _
    Partial Public Class SendStringResponse
    End Class

    <System.SerializableAttribute(), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://tempuri.org/"), _
     Microsoft.Workflow.Bpel.Activities.WsdlMessageTypeAttribute()> _
    Public Class SendStringSoapIn

        Public parameters As ns0.SendString
    End Class

    <System.SerializableAttribute(), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://tempuri.org/"), _
     Microsoft.Workflow.Bpel.Activities.WsdlMessageTypeAttribute()> _
    Public Class SendStringSoapOut

        Public parameters As ns0.SendStringResponse
    End Class

    <System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/"), _
     Microsoft.Workflow.Bpel.Activities.WsdlPortTypeAttribute()> _
    Public Interface PickServiceSoap

        Function SendString(ByVal param1 As ns0.SendStringSoapIn) As ns0.SendStringSoapOut
    End Interface
    
    <System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/"), _
     Microsoft.Workflow.Bpel.Activities.RoleAttribute("application", GetType(ns0.PickServiceSoap))> _
    Public Interface pickLinkType
    End Interface
    
    '''<remarks/>
    <System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Web.Services.WebServiceBindingAttribute(Name:="FileServiceSoap", [Namespace]:="http://tempuri.org/"), _
     Microsoft.Workflow.Bpel.Activities.WsdlBindingPortTypeAttribute("FileServiceSoap", "http://tempuri.org/")> _
    Partial Public Class FileService
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol

        '''<remarks/>
        Public Sub New()
            MyBase.New()
            Me.Url = "http://localhost:8082/FileService/FileService.asmx"
        End Sub

        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/writeLine", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)> _
        Public Sub writeLine(ByVal message As String)
            Me.Invoke("writeLine", New Object() {message})
        End Sub
    End Class

    '''<remarks/>
    <System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://tempuri.org/"), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://tempuri.org/", IsNullable:=False), _
     Microsoft.Workflow.Bpel.Activities.XsdComplexTypeAttribute()> _
    Partial Public Class writeLine

        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Order:=0)> _
        Public message As String
    End Class

    '''<remarks/>
    <System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True, [Namespace]:="http://tempuri.org/"), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://tempuri.org/", IsNullable:=False), _
     Microsoft.Workflow.Bpel.Activities.XsdComplexTypeAttribute()> _
    Partial Public Class writeLineResponse
    End Class

    <System.SerializableAttribute(), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://tempuri.org/"), _
     Microsoft.Workflow.Bpel.Activities.WsdlMessageTypeAttribute()> _
    Public Class writeLineSoapIn

        Public parameters As ns0.writeLine
    End Class

    <System.SerializableAttribute(), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://tempuri.org/"), _
     Microsoft.Workflow.Bpel.Activities.WsdlMessageTypeAttribute()> _
    Public Class writeLineSoapOut

        Public parameters As ns0.writeLineResponse
    End Class

    <System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/"), _
     Microsoft.Workflow.Bpel.Activities.WsdlPortTypeAttribute()> _
    Public Interface FileServiceSoap

        Function writeLine(ByVal param1 As ns0.writeLineSoapIn) As ns0.writeLineSoapOut
    End Interface

    <System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/"), _
     Microsoft.Workflow.Bpel.Activities.RoleAttribute("application", GetType(ns0.FileServiceSoap))> _
    Public Interface fileLinkType
    End Interface
End Namespace


Public Class NamespaceMapping
    
    Private nsTable As System.Collections.Hashtable
    
    Public Sub New()
        MyBase.New
        nsTable = New System.Collections.Hashtable
        nsTable.Add("http://tempuri.org/", "ns0")
    End Sub
    
    Public Overridable Function GetMapping() As System.Collections.Hashtable
        Return nsTable
    End Function
End Class
