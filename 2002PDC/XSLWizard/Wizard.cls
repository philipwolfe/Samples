VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Wizard"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Implements IDTWizard


Private Sub IDTWizard_Execute(ByVal Application As Object, ByVal hwndOwner As Long, ContextParams() As Variant, CustomParams() As Variant, retval As EnvDTE.wizardResult)
    Dim objDTE As EnvDTE.DTE
    Dim pisProjectItems As ProjectItems
    Dim piProjectItemXML As ProjectItem
    Dim piProjectItemXSL As ProjectItem
    Dim tdXMLTextDocument As TextDocument
    Dim wXMLWindow As Window
    Set piProjectItems = ContextParams(2)
    Set objDTE = Application
    Set piProjectItemXML = piProjectItems.AddFromTemplate(CustomParams(0) & "\xmltemplate.xml", ContextParams(4) & ".xml")
    Set piProjectItemXSL = piProjectItems.AddFromTemplate(CustomParams(0) & "\xsltemplate.xsl", ContextParams(4) & ".xsl")
    
    Set wXMLWindow = piProjectItemXML.Open(vsViewKindPrimary)
    Set tdXMLTextDocument = wXMLWindow.Document.Object("TextDocument")
    
    tdXMLTextDocument.ReplacePattern "%FILENAME%", ContextParams(4)
    piProjectItemXSL.Open (vsViewKindPrimary)
End Sub
