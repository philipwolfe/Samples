' ------------------------------------------------------------------------------
'  <copyright from='1997' to='2001' company='Microsoft Corporation'>           
'     Copyright (c) Microsoft Corporation. All Rights Reserved.                
'        
'     This source code is intended only as a supplement to Microsoft
'     Development Tools and/or on-line documentation.  See these other
'     materials for detailed information regarding Microsoft code samples.
' 
'  </copyright>                                                                
' ------------------------------------------------------------------------------
imports System
imports System.ComponentModel
imports System.IO
imports Microsoft.VisualBasic.ControlChars

Option Explicit On

namespace Microsoft.Samples.WinForms.VB.CustomerControl

    public class Customer
        inherits Component

        private vid As string
        private vtitle As string 
        private vfirstName As string
        private vlastName As string
        private vaddress As string

        shared public Function  ReadCustomer() As Customer
            dim cust As Customer = new Customer("536-45-1245")

            with cust 
                .Title = "Mr."
                .FirstName = "Otis"
                .LastName = "Redding"
                .Address = "1 Dock Street," & crlf & "The Bay," & crlf & "SomeWhere," & crlf & "USA"
            end with

            return cust
        End Function

        Sub New(strID As string)
            MyBase.New

            Me.vid = strID     
        End Sub

        public ReadOnly property ID() As string
            get 
                return vid 
            end get
        end property

        public property FirstName() As string 
            get
                return vfirstName 
            end get

            set
                vfirstName = value 
            end set
        end property

        public property Title() As string
            get
                return vtitle 
            end get

            set
                vtitle = value 
            end set
        end property

        public property LastName() As string
            get
                return vlastName 
            end get

            set
                vlastName = value 
            end set
        end property

        public property Address() As string
            get
                return vaddress 
            end get

            set
                vaddress = value 
            end set
        end property

        overrides public function ToString() As string
            dim sb As StringWriter = new StringWriter() 
            sb.WriteLine("Customer: " & CrLf)
            sb.WriteLine(Me.ID)
            sb.Write(Me.Title)
            sb.Write(Me.FirstName)
            sb.WriteLine(Me.LastName)
            sb.WriteLine(Me.Address)
            return sb.ToString()
        end function


    End Class	' Customer

End Namespace	' namespace Microsoft.Samples.WinForms.VB.CustomerControl
