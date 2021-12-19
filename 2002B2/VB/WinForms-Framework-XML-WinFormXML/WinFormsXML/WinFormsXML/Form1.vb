Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Xml
Imports System.Data.OleDb
Imports Microsoft.VisualBasic.ControlChars


Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New

        Form1 = Me

        'This call is required by the Win Form Designer.
        InitializeComponent

        'TODO: Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents cmdXSLTransform As System.Windows.Forms.Button



    Private WithEvents cmdXMLDocumentLoad As System.Windows.Forms.Button




    Private WithEvents txtTextBox As System.Windows.Forms.TextBox



    Private WithEvents cmdXMLTextReaderURL As System.Windows.Forms.Button

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cmdXSLTransform = New System.Windows.Forms.Button()
        Me.cmdXMLTextReaderURL = New System.Windows.Forms.Button()
        Me.cmdXMLDocumentLoad = New System.Windows.Forms.Button()
        Me.txtTextBox = New System.Windows.Forms.TextBox()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        cmdXSLTransform.Location = New System.Drawing.Point(376, 48)
        cmdXSLTransform.Size = New System.Drawing.Size(152, 23)
        cmdXSLTransform.TabIndex = 6
        cmdXSLTransform.Text = "Transform XML using XSLT"

        cmdXMLTextReaderURL.Location = New System.Drawing.Point(24, 48)
        cmdXMLTextReaderURL.Size = New System.Drawing.Size(144, 23)
        cmdXMLTextReaderURL.TabIndex = 0
        cmdXMLTextReaderURL.Text = "XMLTextReaderURL"

        cmdXMLDocumentLoad.Location = New System.Drawing.Point(192, 48)
        cmdXMLDocumentLoad.Size = New System.Drawing.Size(152, 23)
        cmdXMLDocumentLoad.TabIndex = 5
        cmdXMLDocumentLoad.Text = "XMLDocumentLoad"

        txtTextBox.Location = New System.Drawing.Point(24, 88)
        txtTextBox.Multiline = True
        txtTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        txtTextBox.TabIndex = 3
        txtTextBox.Size = New System.Drawing.Size(664, 392)
        Me.Text = "Form1"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(704, 501)

        Me.Controls.Add(cmdXSLTransform)
        Me.Controls.Add(cmdXMLDocumentLoad)
        Me.Controls.Add(txtTextBox)
        Me.Controls.Add(cmdXMLTextReaderURL)
    End Sub

#End Region

    Protected Sub cmdXSLTransform_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdXSLTransform.Click
        Dim XmlDocument As XmlDocument
        Dim XslTransform As Xsl.XslTransform
        Dim Navigator As XPath.XPathNavigator
        Dim XmlReader As XmlReader
        Dim XslNSParams As Xsl.XsltArgumentList
        Dim XmlTextWriter As XmlTextWriter
        Dim Encoding As System.Text.Encoding
        'NSParamList
        XmlDocument = New XmlDocument()

        'Load shirts.xml, found in the bin folder into a XmlDocument
        XmlDocument.Load(Application.StartupPath.ToString & "\shirts.xml")

        'Load the XmlDocument into a DocumentNavigator
        Navigator = (CType(XmlDocument, XPath.IXPathNavigable)).CreateNavigator()

        'Create a new instance of an XSLTransform
        XslTransform = New Xsl.XslTransform()

        'Load the xslt document found in the bin folder into the Transform Object
        XslTransform.Load(Application.StartupPath & "\shirts.xslt")

        'Create a new instance of Name Space Parameters object
        XslNSParams = New Xsl.XsltArgumentList()

        'Transform XmlDocument in Navigator using xslt document
        'Output to an XmlReader
        XmlReader = XslTransform.Transform(Navigator, XslNSParams)

        'Create a new instance of a XMLTextWriter with a .html file in the bin directory
        'Once you run the form once and close the debugger you can view the html file in
        'the bin directory
        XmlTextWriter = New XmlTextWriter(Application.StartupPath & "\shirts.html", Encoding)

        'Transform XmlDocument in Navigator using xslt document
        'Output new html file to bin directory using the XmlTextWriter
        XslTransform.Transform(Navigator, XslNSParams, XmlTextWriter)

        XmlTextWriter.Close()

        'Start a process of IE to display results
        Process.Start("iexplore.exe", Application.StartupPath.ToString & "\shirts.html")


    End Sub

    Protected Sub cmdXMLDocumentLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdXMLDocumentLoad.Click
        Dim XmlDocument As XmlDocument
        Dim objXmlRootNode As XmlNode
        Dim objXmlNode As XmlNode
        Dim objChildNode1 As XmlNode
        Dim objChildNode2 As XmlNode
        Dim objChildNode3 As XmlNode
        Dim objChildNode4 As XmlNode

        'Clear TextBox
        Me.txtTextBox.Text = ""

        XmlDocument = New XmlDocument()

        'Load shirts.xml, found in the bin folder into a XmlDocument
        XmlDocument.Load(Application.StartupPath & "\shirts.xml")
        'Load the Document Element
        objXmlRootNode = XmlDocument.DocumentElement

        Me.txtTextBox.Text = objXmlRootNode.InnerXml


    End Sub




    Protected Sub cmdXMLTextReaderURL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdXMLTextReaderURL.Click
        Dim objXmlTextReader As System.Xml.XmlTextReader
        Dim strTab As String

        Me.txtTextBox.Text = ""

        'Point the XMLTextReader at the shirts.xml file in the bin directory
        objXmlTextReader = New System.Xml.XmlTextReader(Application.StartupPath & "\shirts.xml")
        'While the TextReader Reads the stream we will test the node type  
        While objXmlTextReader.Read

            Select Case objXmlTextReader.NodeType
                'If the node type is an element we grab its Depth property 
                'to determine how we should display it
            Case System.Xml.XmlNodeType.Element
                    If objXmlTextReader.Depth.ToString = "1" Then
                        strTab = Tab
                    ElseIf objXmlTextReader.Depth.ToString = "2" Then
                        strTab = Tab & Tab
                    ElseIf objXmlTextReader.Depth.ToString = "3" Then
                        strTab = Tab & Tab & Tab
                    ElseIf objXmlTextReader.Depth.ToString = "4" Then
                        strTab = Tab & Tab & Tab & Tab
                    Else
                        strTab = ""
                    End If


                    'Display The Element name
                    Me.txtTextBox.Text += strTab & "Element: " & objXmlTextReader.Name.ToString & CrLf

                    'If its text then it's the value of the element and we display it as such
                Case Xml.XmlNodeType.Text
                    Me.txtTextBox.Text += strTab & Tab & "Value: " & objXmlTextReader.Value.ToString & CrLf

            End Select
        End While

    End Sub

End Class
