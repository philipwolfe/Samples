VERSION 5.00
Begin VB.Form frmGoodExample 
   Caption         =   "Form1"
   ClientHeight    =   2355
   ClientLeft      =   60
   ClientTop       =   360
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   ScaleHeight     =   2355
   ScaleWidth      =   4680
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox txtOne 
      Height          =   285
      Left            =   480
      TabIndex        =   0
      Text            =   "Text One"
      Top             =   1140
      Width           =   3495
   End
   Begin VB.Label lblOne 
      Caption         =   "Label One"
      Height          =   255
      Left            =   480
      TabIndex        =   1
      Top             =   600
      Width           =   3435
   End
End
Attribute VB_Name = "frmGoodExample"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

'****************************************************************
'This project shows some of the negative things that can happen
'when using late binding of objects in VB6 and what happens when the
'project is converted to VB.Net. See the VB6GoodUpgrade project for
'recommendations for coding to an easier conversion to VB.Net
'****************************************************************

Private Sub TipOne()

    'One problem with late binding is that problems can arise when
    'accessing default properties.  For example, in VB.Net the "Caption"
    'property of a label has been changed to "Text".  The following code
    'will not be properly converted because VB cannot detect what type of
    'object it is, and thus it will not be upgraded.
    
    'Dim obj As Object
    'Set obj = frmPoorUpgrade.lblOne
    'obj.Caption = "New Text for Label."
    
    'To avoid this use early binding of objects.
    
    'Correct Usage:
    Dim obj As Label
    Set obj = frmGoodExample.lblOne
    obj.Caption = "New Text for Label."

End Sub

Private Sub TipTwo()

    'When a VB6 project is upgraded all Variant data types are upgraded to the
    'new Object datatype.  When performing operations of Variant data types or
    'passing them to parameters always perform explicit conversions.
    
'    Dim Var1 As Variant
'    Dim Var2 As Variant
'    Dim Var3 As Variant
'    Var1 = "3"
'    Var2 = 4
'    'The following line of code is unclear as to the operation of the "+" operator.
'    'This line of code may result in a run-time error in VB.Net
'    Var3 = Var1 + Var2
    
    'Correct Usage
    Dim Var1 As Variant
    Dim Var2 As Variant
    Dim Var3 As Variant
    Var1 = "3"
    Var2 = 4
    Var3 = CInt(Var1) + CInt(Var2)

End Sub

Private Sub TipThree()

    'Another reason for explicit conversion of Object/Varint datatypes is
    'that when using an overloaded function, VB.Net makes a determination on
    'which function to call based on the parameter type.  For example, the Environ
    'function now has two forms, one accepting an integer, one accepting a string
    
'    Dim x As Variant
'    Dim a As String
'    x = "Path"
'    a = Environ(x)
    
    'Passing an parameter of Object Type to an Overloaded function may cause
    'compile or runtime errors.

    'Correct Usage
    Dim x As Variant
    Dim a As String
    x = "Path"
    a = Environ(CStr(x))

End Sub

Private Sub TipFour()

    'Visual Basic supported using the Double DataType to store dates.  This should
    'not be done in VB.Net beacuse dates are not stored internally as doubles.
    'The following code will compile fine in VB6 but fail in VB.Net
    
'    Dim dblDate As Double
'    Dim datDate As Date
'
'    datDate = Now
'    dblDate = datDate 'Double cannot be assigned to a date.
'
'    dblDate = DateAdd("d", 1, dblDate) 'Cannot use Double in Date functions.
'    datDate = CDate(dblDate) 'CDate cannot convert double to date.

    'Correct Usage
    Dim dblDate As Date
    Dim datDate As Date
    
    datDate = Now
    dblDate = datDate
    
    dblDate = DateAdd("d", 1, dblDate)
    datDate = CDate(dblDate)

End Sub

Private Sub TipFive()
    
    'Visual Basic does not support the use of parameterless default properties.
    'VB.Net on upgrade perfroms these conversions when the project is upgraded
    'for all usages for which it is able to determine.  This is another reason to
    'not use late binding of objects.
    
    'The following code will not be correctly upgraded because VB.Net is unable to
    'to determine the object type.
    
'    Dim obj As Object
'    Set obj = frmPoorUpgrade.txtOne
'    MsgBox obj
    
    'Correct Usage
    Dim obj As TextBox
    Set obj = frmGoodExample.txtOne
    MsgBox obj.Text
    'Note: VB.Net will populate any default properties that are used at the time
    'the project is upgraded.  So the following line would be upgraded correctly, but
    'it is recommended to not rely on default properties.
    MsgBox Me.txtOne
    
End Sub

Private Sub TipSix()

    'VB.Net changes the way that the "And" & "Or" keywords work.  In VB 6 the
    '"And" keyword performed both a logical and bitwise comparison.  In VB.Net the
    '"And" operator now performs only a logical comparison.
    
    'The following code in VB 6 would return a false answer since it is performing
    'as bit wise comparison.
'    Dim a As Integer
'    Dim b As Integer
'    Dim c As Boolean
'
'    a = 1
'    b = 2
'    c = a And b
    
    'This code would be upgraded to use the compatibility functions built into
    'VB.Net
    
    'Correct Usage
    Dim a As Integer
    Dim b As Integer
    Dim c As Boolean
    
    a = 1
    b = 2
    c = (a <> 0) And (b <> 0)
    
    'Note: If you want your comparison to be a bitwise comparison, then you would
    'need to manually change the code after upgrading to use the new
    'BitAnd, BitOr, BitNot, & BitXor operations.
    
End Sub

Private Sub TipSeven()

    'VB.Net also changed the way functions are handled in AND/OR/NOT comparisons.
    'VB.Net now performs short-circuiting of logical operators.
    
'    Dim b As Boolean
'    b = ReturnFalse() And ReturnTrue()
    
    'In VB 6 both functions would be performed and then evaluated.  In VB.Net,
    'the first function would be performed, but not the second.  This could result
    'in ill side effects, if the second function is doing something such as
    'writing to a database.  In this case the And will be upgraded to the
    'Compatibility And.  See the GoodExample on a better method of coding this example.

    'Correct Usage
    Dim b As Boolean
    Dim c As Boolean
    Dim d As Boolean
    c = ReturnFalse()
    d = ReturnTrue()
    b = c And d

End Sub
Private Function ReturnFalse() As Boolean

    ReturnFalse = False

End Function
Private Function ReturnTrue() As Boolean
    
    ReturnTrue = True
    
End Function
Private Sub TipEight()
    
    'In your VB 6 projects you should use constant names instead of their
    'underlying values.  This protects you values of the constants from changing
    'in VB.Net.  One example is the constant value of True and False.  In VB6,
    'the underlying value of True has changed from -1 to 1.
    
'    Dim i As Integer
'    i = True
'    If i = -1 Then
'        MsgBox ("True")
'    Else
'        MsgBox ("False")
'    End If
    
    'This statement would produce a "True" result in VB 6 and a "False" result
    'in VB.Net.  You should always use the constant names of True and False and
    'always use the Boolean data type to ensure a smooth upgrade.

    'Correct Usage
    Dim i As Boolean
    i = True
    If i = True Then
        MsgBox ("True")
    Else
        MsgBox ("False")
    End If

End Sub

Private Sub TipNine()

    'In VB 6 projects you should avoid using Null propagation.  This is the idea that
    'when Null is used in an expression, the result of the expression will be Null.
    
    'The following code in VB 6 would return a value of False because the actual
    'comparison returns a value of Null.
    
'    Dim a As Variant
'
'    a = Null
'
'    If (a < 12) = True Then
'        MsgBox "True"
'    Else
'        MsgBox "False"
'    End If

    'In VB.Net, Null propagation is not supported.  You should always be writing
    'code to test for a Null value.

    'Correct Usage
    Dim a As Variant
    
    a = Null
    
    If IsNull(a < 12) = True Then
        MsgBox "True"
    Else
        MsgBox "False"
    End If

End Sub

Private Sub TipTen()

    'VB 6 allowed the developer to define bounds of arrays of any whole number.
    'In addition, ReDim could be used to redefine a variant as an array.  VB 6 also
    'created an array to the upper bound of the whole number specified.
    
'    'This statement is upgraded to an array wrapper class, but there are limitations
'    'to using a Array Wrapper Class.
'    Dim a(1 To 10) As Integer
'
'    'Redim is not allowed in VB.Net
'    Dim v As Variant
'    ReDim v(10)
'
'    'One change is that now a declaration of:
'    Dim b(10) As Integer
'    'creates an array of 10 integers from 0 to 9.  In VB 6 this would have created
'    'and array of 11 integers from 0 to 10.

    'Correct Usage
    
    'This statement is upgraded to an array wrapper class, but there are limitations
    'to using a Array Wrapper Class.
    'Zero Based Arrays should always be used.
    Dim a(10) As Integer
    
    'Redim of a variant not previously defined as an array is not allowed in VB.Net
    'Redim is safe if the variant has been defined as an array.
    Dim v() As Integer
    ReDim Preserve v(15)
    
    'One change is that now a declaration of:
    Dim b(10) As Integer
    'creates an array of 10 integers from 0 to 9.  In VB 6 this would have created
    'and array of 11 integers from 0 to 10. To ensure a safe upgrade, VB.Net
    'will upgrade this statement to a arrary of 11 integers.

End Sub

