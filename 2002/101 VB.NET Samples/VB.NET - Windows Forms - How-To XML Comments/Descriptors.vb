'*****************************************************************************
' Copyright (C) 1999-2002, Microsoft Corporation.  All Rights Reserved.
'*****************************************************************************

Imports System
Imports System.Collections
Imports System.Reflection
Imports System.Diagnostics

Public Class ContentDescriptor
    ' A container for content and its associated error(s).
    ' See the MemberNode class for more details.

    Private m_Content As String     'The content which is contained by this class.
    Private m_Errors As ArrayList   'List of errors associated with the content.


    Public Sub New(ByVal Content As String)
        Me.Content = Content
    End Sub

    Public Sub New()
        MyClass.New(Content:="")
    End Sub

    Public Property Content() As String
        Get
            Return m_Content
        End Get
        Set(ByVal Value As String)
            m_Content = Value
        End Set
    End Property

    Public ReadOnly Property Errors() As ArrayList
        Get
            If Me.HasErrors Then
                'Make a copy of the error list to avoid others from directly modifying the list.
                'Modifications should only be performed by members of this class.
                Return CType(m_Errors.Clone, ArrayList)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Sub AddError(ByVal NewError As ErrorRecord)
        Debug.Assert(Not NewError Is Nothing, "Must have a valid ErrorRecord to add.")

        'Most descriptors have no errors, so the error list gets created only when
        'an error gets added.

        If m_Errors Is Nothing Then
            m_Errors = New ArrayList(1)
        End If

        m_Errors.Add(NewError)
    End Sub

    Public Sub RemoveError(ByVal OldError As ErrorRecord)
        Debug.Assert(Not OldError Is Nothing, "Must have a valid ErrorRecord to remove.")
        Debug.Assert(Not m_Errors Is Nothing AndAlso m_Errors.Contains(OldError), _
                     "Attempting to remove an error which is not in the list.")

        m_Errors.Remove(OldError)

        'Destroy the error list if there are no more errors.
        If m_Errors.Count = 0 Then
            m_Errors = Nothing
        End If
    End Sub

    Public Function HasErrors() As Boolean
        Debug.Assert(m_Errors Is Nothing OrElse m_Errors.Count > 0, _
                     "List must have more than 0 items if it is allocated.")
        Return Not m_Errors Is Nothing
    End Function

End Class

Public Class ParameterDescriptor : Inherits ContentDescriptor
    ' A container for a parameter's content, associated error(s), and
    ' modifiers like ByRef and Optional.  It also renders the signature for 
    ' the parameter using these modifiers.
    ' See the MemberNode class for more details.

    Private m_Name As String            'The name of the parameter.
    Private m_NormalizedType As String  'A standard representation of the parameter's type.
    Private m_IsByRef As Boolean        'Has a value of True if the parameter is ByRef.
    Private m_IsOptional As Boolean     'Has a value of True if the parameter is Optional.
    Private m_IsParamArray As Boolean   'Has a value of True if the parameter is a ParamArray.


    Public Sub New(ByVal Info As ParameterInfo)
        ' Takes a parameter reflection object and builds a descriptor from it.
        ' The content is not known at this point.

        MyBase.New(Content:="")

        Me.Name = Info.Name

        m_IsOptional = Info.IsOptional

        Dim TypeInfo As Type = Info.ParameterType

        If TypeInfo.IsByRef Then
            m_IsByRef = True
            'Dig through the ByRef identifier.
            TypeInfo = TypeInfo.GetElementType
        End If

        'This parameter is a ParamArray if it has the ParamArray custom attribute attached to it.
        If Info.IsDefined(GetType(System.ParamArrayAttribute), False) Then
            m_IsParamArray = True
        End If

        'The normalized type is a standard representation of the string from which we build all 
        'required type-signature forms (such as the form displayed to the user (friendly) and 
        'the form written to the XML Documentation file (raw)).  Reflection delimits nested types with
        '"+".  These must be changed to "." to normalize the type.

        m_NormalizedType = NormalizeType(TypeInfo.FullName)
    End Sub

    Public Sub New(ByVal TypeSig As String)
        ' Takes an XML Documentation type signature and builds a descriptor from it.
        ' The content is not known at this point.
        '
        ' XML Documentation type signature format:
        '     typename [arrayrank] [@]
        ' where
        '     'typename' is the name of the type
        '     'arrayrank' is an optional description of the array dimensions
        '     '@' is an optional postfix signifying ByRef
        '
        ' 'arrayrank' is comprised of zero or more (but never one) instances
        ' of the string "0:" separated by commas with the whole encased in
        ' square brackets "[ ]".
        '     Examples:  [0:,0:]
        '                []
        '                [][0:,0:,0:][][0:,0:]
        '
        ' See MSDN for more information.

        MyBase.New(Content:="")

        'We don't know the name yet because we are building this param from the XML Documentation file.
        'Set it to a special string so we know to set the names sequentially when we populate the
        'rest of the data from the XML Documentation file.
        Me.Name = UNKNOWN_PARAM_NAME

        If TypeSig.EndsWith("@") Then
            'The @-sign denotes a ByRef parameter.
            m_IsByRef = True
            'Remove the @-sign at the end.
            TypeSig = TypeSig.Remove(TypeSig.Length - 1, 1)
        End If

        'The normalized type is a standard representation of the string from which we build all 
        'required type-signature forms (such as the form displayed to the user (Friendly) and 
        'the form written to the XML Documentation file (Raw)).  Array notation from the
        'XML Documentation file if considered Raw and in the form 'arrayrank' (see above).
        'Instances of "0:" must be removed to normalize the type.

        m_NormalizedType = NormalizeType(TypeSig)
    End Sub

    Public Sub New(ByVal Name As String, ByVal Content As String)
        ' Build a descriptor using just the name and content.  This is done
        ' when all we can know about a parameter are these values, such as
        ' when a bad parameter is detected or a param node is found in the XML
        ' without a corresponding entry in the member signature.

        MyBase.New(Content)
        Me.Name = Name
    End Sub

    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(ByVal Value As String)
            m_Name = Value
        End Set
    End Property

    Public ReadOnly Property RawSignature() As String
        ' Builds a signature as it would appear in the XML Documentation file.

        Get
            Dim sig As String = ""
            If m_NormalizedType <> "" Then
                sig &= m_NormalizedType
                If m_IsByRef Then
                    'The @-sign denotes a ByRef parameter.
                    sig &= "@"
                End If

                'This adds the "0:" notation if needed.
                sig = UseRawArrayNotation(sig)
            End If
            Return sig
        End Get
    End Property

    Public ReadOnly Property FriendlySignature() As String
        ' Builds a signature as it would appear to the user.

        Get
            Dim sig As String = ""

            If m_IsOptional Then sig &= "Optional "
            If m_IsByRef Then sig &= "ByRef " Else sig &= "ByVal "
            If m_IsParamArray Then sig &= "ParamArray "

            sig &= Me.Name

            If m_NormalizedType <> "" Then
                sig &= " As " & Me.FriendlyType
            End If

            Return sig
        End Get
    End Property

    Public ReadOnly Property FriendlyType() As String
        ' Builds a type-signature as it would appear to the user.

        Get
            Dim sig As String = ""
            If m_NormalizedType <> "" Then
                sig &= UseFriendlyArrayNotation(IntrinsicToVBType(m_NormalizedType))
            End If
            Return sig
        End Get
    End Property

    Public Function Clone() As ParameterDescriptor
        ' Clone this descriptor.  This will be used when copy/pasting nodes.

        Dim copy As New ParameterDescriptor(Me.Name, Me.Content)
        copy.m_IsByRef = Me.m_IsByRef
        copy.m_IsOptional = Me.m_IsOptional
        copy.m_IsParamArray = Me.m_IsParamArray
        copy.m_NormalizedType = Me.m_NormalizedType
        Return copy
    End Function
End Class
