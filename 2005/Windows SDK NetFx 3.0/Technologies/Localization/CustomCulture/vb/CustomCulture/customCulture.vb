'-----------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'-----------------------------------------------------------------------
Imports System
Imports System.Globalization

   '/ <summary>
   '/ customCultureInfo is derived from the System.Globalization.CultureInfo
   '/ in order to provide support for a custom culture that is closely related
   '/ to its parent culture. 
   '/ In this sample, the custom culture's role is limited to providing access 
   '/ to custom culture specific resources and providing a date format but the 
   '/ role of the custom culture could easily be expanded to provide additional 
   '/ differentiation with its parent culture. To do so, it is necessary to 
   '/ implement support for the other properties of the base CultureInfo class 
   '/ by overriding them in the derived class
   '/ </summary>

Namespace Microsoft.Samples.International.CustomCulture

   Public Class customCultureInfo
      Inherits CultureInfo
      Private Dim myDescription As String
      Private Dim myName As String
      Private Dim myParent As String

      ' the constructor takes two parameters: the parent name and the custom name
      Public Sub New(parent As String, customName As String)
         MyBase.New("en-US")
         myParent = parent
         myName   = String.Format("{0}-{1}", parent, customName)
         myDescription = String.Format("Custom Culture ({0})", myName)

	 ' set formatting for date time
         Dim nfi As NumberFormatInfo = CType(MyBase.NumberFormat.Clone(), NumberFormatInfo)
         nfi.CurrencyPositivePattern = 3
         nfi.CurrencyGroupSeparator = "'"
         nfi.CurrencySymbol = "$"
         nfi.CurrencyDecimalDigits = 0
         MyBase.NumberFormat = nfi
      End Sub 'New
      
      Public Overrides ReadOnly Property Name() As String
         Get
            Return myName
         End Get
      End Property 
      
      Public Overrides ReadOnly Property Parent() As CultureInfo
         Get
            Return New CultureInfo(myParent)
         End Get
      End Property 
      
      Public Overrides ReadOnly Property EnglishName() As String
         Get
            Return Me.myDescription
         End Get
      End Property 
      
      Public Overrides ReadOnly Property NativeName() As String
         Get
            Return Me.myDescription
         End Get
      End Property

      Public Overrides ReadOnly Property DisplayName() As String
         Get
            Return Me.myDescription
         End Get
      End Property

   End Class 'customCultureInfo
End Namespace 'CustomCulture
