VERSION 5.00
Begin VB.Form frmAccessWebService 
   Caption         =   "Access web services"
   ClientHeight    =   3195
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4680
   LinkTopic       =   "Form2"
   ScaleHeight     =   3195
   ScaleWidth      =   4680
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Command1 
      Caption         =   "Access web services"
      Height          =   495
      Left            =   1200
      TabIndex        =   0
      Top             =   1200
      Width           =   2415
   End
End
Attribute VB_Name = "frmAccessWebService"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim cRetVal As String
Private Sub Command1_Click()

    'Create the SOAP Client
    Dim soapClient
    Set soapClient = CreateObject("MSSOAP.SoapClient30")
    
    'Initialize the soap client and pass the URL for
    'the WSDL file as a parameter
    Call soapClient.MSSoapInit("http://pc-p42244/taxcalculator/service1.asmx?WSDL")
    
'    1. Accessing HelloWorld Web service , it will return HelloWorld String
    cRetVal = soapClient.HelloWorld()
    MsgBox "HelloWorld Web Service accessed.The returned value is = " & cRetVal

'    2. Accessing GetSalesTax Web service with parameter
    cRetVal = soapClient.GetSalesTax(100)  'GetSalesTax with parameter
    MsgBox "GetSalesTax Web Service Accessed. The returned value is =" & cRetVal
    
'    3. Accessing GetSalesTaxAmount Web service without parameter, it will return 1000
    cRetVal = soapClient.GetSalesTaxAmount()  'GetSalesTax withjout parameter
    MsgBox "GetSalesTaxAmount Web Service Accessed without parameter, The returned value is =" & cRetVal

End Sub


