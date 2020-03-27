'*****************************************************************************
' Copyright (C) 1999-2002, Microsoft Corporation.  All Rights Reserved.
'*****************************************************************************

Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Reflection
Imports System.Collections


Public Module Constants
    ' A collection of global constants.

    Public Const ASSEMBLY_FILE_FILTER As String = "Assembly Files (*.dll)|*.dll|Executable Files (*.exe)|*.exe|All Files (*.*)|*.*"
    Public Const XML_FILE_FILTER As String = "XML Documentation Files (*.xml)|*.xml|All files (*.*)|*.*"

    'Indentation for XML nodes.
    Public Const INDENT1 As String = "    "
    Public Const INDENT2 As String = INDENT1 & INDENT1
    Public Const INDENT3 As String = INDENT2 & INDENT1

    Public Const BAD_MEMBER_NAME As String = "{BAD_MEMBER}"
    Public Const UNKNOWN_PARAM_NAME As String = "{UNKNOWN_NAME}"

End Module

Public Module GlobalFlags
    ' A collection of global flags.

    Public FileDirty As Boolean = False
End Module

Public Module SignatureHelpers
    ' A collection of functions for manipulating and parsing raw and friendly
    ' signatures.

    Public Const BAD_SIG As String = "{BAD_SIG}"    'Represents a bad signature.


    Public Function IntrinsicToVBType(ByVal Type As String) As String
        ' Maps the fully-qualified .Net runtime name to the VB .Net friendly
        ' name.

        If Type.StartsWith("System.") Then  'A simple optimization

            If Type.StartsWith("System.Boolean") Then
                Return Type.Replace("System.Boolean", "Boolean")
            End If

            If Type.StartsWith("System.Byte") Then
                Return Type.Replace("System.Byte", "Byte")
            End If

            If Type.StartsWith("System.Int16") Then
                Return Type.Replace("System.Int16", "Short")
            End If

            If Type.StartsWith("System.Int32") Then
                Return Type.Replace("System.Int32", "Integer")
            End If

            If Type.StartsWith("System.Int64") Then
                Return Type.Replace("System.Int64", "Long")
            End If

            If Type.StartsWith("System.Single") Then
                Return Type.Replace("System.Single", "Single")
            End If

            If Type.StartsWith("System.Double") Then
                Return Type.Replace("System.Double", "Double")
            End If

            If Type.StartsWith("System.Decimal") Then
                Return Type.Replace("System.Decimal", "Decimal")
            End If

            If Type.StartsWith("System.Char") Then
                Return Type.Replace("System.Char", "Char")
            End If

            If Type.StartsWith("System.String") Then
                Return Type.Replace("System.String", "String")
            End If

            If Type.StartsWith("System.Object") Then
                Return Type.Replace("System.Object", "Object")
            End If

            If Type.StartsWith("System.DateTime") Then
                Return Type.Replace("System.DateTime", "Date")
            End If

        End If

        Return Type
    End Function

    Public Function UseFriendlyArrayNotation(ByVal s As String) As String
        'XML Documentation uses square brackets whereas VB uses parentheses for Array notation.
        Return s.Replace("["c, "("c).Replace("]"c, ")"c)
    End Function

    Public Function NormalizeNodePath(ByVal s As String) As String
        'Paths of treenodes are delimited with "\".  These need to be changed to ".".
        Return s.Replace("\"c, "."c)
    End Function

    Public Function NormalizeTypeDelimiters(ByVal s As String) As String
        'Nested types are delimited with "+".  These need to be changed to ".".
        Return s.Replace("+"c, "."c)
    End Function

    Public Function NormalizeArrayNotation(ByVal s As String) As String
        'Array notation from a raw signature will have bound instances.  These
        'need to be removed.
        If s.IndexOf(","c) <> -1 AndAlso s.IndexOf("0:") <> -1 Then
            s = s.Replace("0:", Nothing)
        End If
        Return s
    End Function

    Public Function NormalizeType(ByVal s As String) As String
        Return NormalizeArrayNotation(NormalizeTypeDelimiters(s))
    End Function

    Public Function SplitParams(ByVal s As String) As String()
        'This function splits on all commas contained in "s" except for commas embedded in square brackets.

        If s Is Nothing Then
            Return Nothing
        End If

        'Use a stack to determine if a comma is embedded in square brackets.
        Dim BracketStack As Stack = New Stack()
        Dim FragmentList As ArrayList = New ArrayList()

        Dim start As Integer = 0

        Dim index As Integer
        For index = 0 To s.Length - 1
            Select Case s.Chars(index)
                Case "["c
                    BracketStack.Push(New Object())
                Case "]"c
                    BracketStack.Pop()
                Case ","c
                    If BracketStack.Count = 0 Then
                        FragmentList.Add(s.Substring(start, index - start))
                        start = index + 1
                    End If
            End Select
        Next

        'Don't fail if the last character is a comma.
        If start <> index Then
            'Special case: attach the last fragment after the last comma encountered.
            FragmentList.Add(s.Substring(start, index - start))
        End If

        Return CType(FragmentList.ToArray(GetType(String)), String())
    End Function

    Public Structure Signature
        ' This structure represents a raw signature parsed into its
        ' constituent parts.

        Public Kind As String               'The member's kind.
        Public FullName As String           'The fully-qualified name.
        Public Params As String()           'An array of parameter type signatures.
        Public SpecialEnding As String      'The return type prepended with a "~" for certain special cases.

        Public Overrides Function ToString() As String
            ' Re-assembles the raw signature into one string.

            Dim result As String = ""

            If Kind <> "" Then result &= Kind
            If FullName <> "" Then result &= FullName

            If Not Params Is Nothing AndAlso Params.Length > 0 Then
                result &= "("c
                Dim i As Integer
                For i = 0 To Params.Length - 1
                    If i <> 0 Then
                        result &= ","c
                    End If
                    result &= Params(i)
                Next
                result &= ")"c
            End If

            If SpecialEnding <> "" Then result &= SpecialEnding

            Return result
        End Function

    End Structure

    Public Function ParseRawSignature(ByVal RawSig As String) As Signature
        ' Given a raw signature, break it up into its constituent parts.
        ' This function will either throw exceptions or have undefined
        ' behavior if the signature is not in the correct form;  the caller
        ' must handle these cases appropriately.

        Dim Result As Signature

        Result.Kind = Left(RawSig, 2)

        'Strip off the Kind now that we are done with it.
        RawSig = RawSig.Substring(2)

        Dim FirstParen As Integer = RawSig.IndexOf("("c)
        Dim LastParen As Integer = RawSig.LastIndexOf(")"c)

        If FirstParen = -1 Then
            'No params found.
            Result.FullName = RawSig
        Else
            Result.Params = SplitParams(RawSig.Substring(FirstParen + 1, LastParen - FirstParen - 1))

            Dim i As Integer
            For i = 0 To Result.Params.Length - 1
                Result.Params(i) = UseRawArrayNotation(Result.Params(i))
            Next

            Result.FullName = Left(RawSig, FirstParen)
        End If

        'If there are characters after the last paren, they are considered the special ending used
        'for op_Implicit and op_Explicit.
        If LastParen <> -1 AndAlso LastParen < RawSig.Length - 1 Then
            Result.SpecialEnding = RawSig.Substring(LastParen + 1)
        End If

        Return Result
    End Function

    Public Function UseRawArrayNotation(ByVal paramsig As String) As String
        ' Multi-dim arrays need to be represented as "[0:,0:]" rather than
        ' "[,]" for the C# Object Browser to work.  Patch up the raw signature
        ' to include the "0:" notation.

        If paramsig.IndexOf(","c) <> -1 Then
            'First clean the string of all special notation.  This normalizes for the algorithm below.
            paramsig = NormalizeType(paramsig)

            Dim fragments As String() = paramsig.Split(","c)

            paramsig = fragments(0)

            Dim i As Integer
            For i = 1 To fragments.Length - 1
                'Special case if there are two or more commas next to each other "[,,]"
                'Do a run of "0:" for every directly adjacent comma (signified by empty string from the split).
                If fragments(i) = "" Then
                    paramsig &= "0:,"
                Else
                    paramsig &= "0:,0:" & fragments(i)
                End If
            Next
        End If

        Return paramsig

    End Function

End Module

Public Module NodeKindHelpers
    ' A collection of helpers for determining and classifying node kinds.

    Public Function IsType(ByVal k As NodeKind) As Boolean
        Return k = NodeKind.Class OrElse _
               k = NodeKind.Delegate OrElse _
               k = NodeKind.Enum OrElse _
               k = NodeKind.Interface OrElse _
               k = NodeKind.Module OrElse _
               k = NodeKind.Structure
    End Function

    Public Function IsField(ByVal k As NodeKind) As Boolean
        Return k = NodeKind.Field OrElse _
               k = NodeKind.EnumMember OrElse _
               k = NodeKind.Constant
    End Function

    Public Function CanHaveParameters(ByVal k As NodeKind) As Boolean
        Return k = NodeKind.Method OrElse _
               k = NodeKind.Constructor OrElse _
               k = NodeKind.Property
    End Function

    Public Function ClassifyNodeKind(ByVal t As System.Type) As NodeKind
        ' Given a reflection type object, this function returns the
        ' corresponding node kind.

        If t.IsClass Then
            If t.IsSubclassOf(GetType(System.Delegate)) Then
                Return NodeKind.Delegate
            ElseIf t.IsDefined(GetType(Microsoft.VisualBasic.CompilerServices.StandardModuleAttribute), False) Then
                'This type is a VB Module if it has the standard module attribute attached to it.
                Return NodeKind.Module
            Else
                Return NodeKind.Class
            End If
        ElseIf t.IsInterface Then
            Return NodeKind.Interface
        ElseIf t.IsEnum Then
            Return NodeKind.Enum
        ElseIf t.IsValueType Then
            Return NodeKind.Structure
        End If

        '"System.Enum" actually falls through to here, which is a bug.  Return NodeKind.Class as the default.
        Debug.Assert(t Is GetType(System.Enum), "Unexpected type: " & t.FullName)
        Return NodeKind.Class
    End Function

    Public Function ClassifyNodeKind(ByVal f As FieldInfo) As NodeKind
        ' Given a reflection field object, this function returns the
        ' corresponding node kind.

        If f.IsLiteral Then
            If f.DeclaringType.IsEnum Then
                Return NodeKind.EnumMember
            Else
                Return NodeKind.Constant
            End If
        End If

        Return NodeKind.Field
    End Function

    Public Function ClassifyNodeKind(ByVal s As String) As NodeKind
        ' Given the "kind" component of a raw signature, this function returns
        ' the corresponding node kind.

        Select Case UCase(s)
            Case "N:" : Return NodeKind.Namespace
            Case "T:" : Return NodeKind.Class
            Case "F:" : Return NodeKind.Field
            Case "P:" : Return NodeKind.Property
            Case "M:" : Return NodeKind.Method
            Case "E:" : Return NodeKind.Event
            Case "!:" : Return NodeKind.Error
        End Select

        Return NodeKind.Error
    End Function

    Public Function NodeKindRepresentation(ByVal k As NodeKind) As String
        ' Give a node kind, this function returns the "kind" component
        ' representation for the raw signature.

        If IsType(k) Then
            Return "T:"
        End If

        If IsField(k) Then
            Return "F:"
        End If

        Select Case k
            Case NodeKind.Method, NodeKind.Constructor
                Return "M:"
            Case NodeKind.Property
                Return "P:"
            Case NodeKind.Namespace
                Return "N:"
            Case NodeKind.Event
                Return "E:"
        End Select

        Debug.Assert(k = NodeKind.Error, "The value of m_Kind should be 'Error': ", k.ToString)
        Return "!:"
    End Function

End Module

Public Module ReflectionHelpers
    ' A collection of helpers used for Reflection.  We care about asking two
    ' questions:
    '   1) Is a Member visible outside of the assembly?  (Protected and Public
    '       members are, Private and Friend members are not)
    '   2) Does a Member have Protected accessiblity?
    ' These questions are answered with the helpers below, overloaded for each
    ' type of reflection object.

    'Reflect on all members public or private on a type, except those which are inherited.
    Public Const MemberBindingFlags As BindingFlags = _
        BindingFlags.Instance Or _
        BindingFlags.Static Or _
        BindingFlags.Public Or _
        BindingFlags.NonPublic Or _
        BindingFlags.DeclaredOnly

    Public Function IsProtected(ByVal t As Type) As Boolean
        Return t.IsNestedFamily OrElse t.IsNestedFamORAssem
    End Function

    Public Function IsProtected(ByVal method As MethodBase) As Boolean
        Return method.IsFamily OrElse method.IsFamilyOrAssembly
    End Function

    Public Function IsProtected(ByVal field As FieldInfo) As Boolean
        Return field.IsFamily OrElse field.IsFamilyOrAssembly
    End Function

    Public Function IsProtected(ByVal evt As EventInfo) As Boolean
        'Accessibilty is determined by the accessibily of the hookups.
        Return IsProtected(evt.GetAddMethod(True))
    End Function

    Public Function IsProtected(ByVal prop As PropertyInfo) As Boolean
        'Accessibilty is determined by the accessibily of the accessors.
        If prop.CanRead Then
            Return IsProtected(prop.GetGetMethod(True))
        Else
            Return IsProtected(prop.GetSetMethod(True))
        End If
    End Function

    Public Function IsExportable(ByVal t As Type) As Boolean
        Return t.IsPublic OrElse t.IsNestedPublic OrElse IsProtected(t)
    End Function

    Public Function IsExportable(ByVal method As MethodBase) As Boolean
        Return method.IsPublic OrElse IsProtected(method)
    End Function

    Public Function IsExportable(ByVal field As FieldInfo) As Boolean
        Return field.IsPublic OrElse IsProtected(field)
    End Function

    Public Function IsExportable(ByVal evt As EventInfo) As Boolean
        'Accessibilty is determined by the accessibily of the hookups.
        Return IsExportable(evt.GetAddMethod(True))
    End Function

    Public Function IsExportable(ByVal prop As PropertyInfo) As Boolean
        'Accessibilty is determined by the accessibily of the accessors.
        If prop.CanRead Then
            Return IsExportable(prop.GetGetMethod(True))
        Else
            Return IsExportable(prop.GetSetMethod(True))
        End If
    End Function

    Public Function IsExportable(ByVal m As MemberInfo) As Boolean

        Select Case m.MemberType
            Case MemberTypes.Method, MemberTypes.Constructor
                Return IsExportable(CType(m, MethodBase))

            Case MemberTypes.Event
                Return IsExportable(CType(m, EventInfo))

            Case MemberTypes.Field
                Return IsExportable(CType(m, FieldInfo))

            Case MemberTypes.Property
                Return IsExportable(CType(m, PropertyInfo))

            Case MemberTypes.NestedType
                Return IsExportable(CType(m, Type))

        End Select

        Debug.Fail("Unexpected member type: ", m.GetType.ToString)
        Return False

    End Function

End Module