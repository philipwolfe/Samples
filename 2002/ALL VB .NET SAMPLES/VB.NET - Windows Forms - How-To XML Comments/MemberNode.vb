'*****************************************************************************
' Copyright (C) 1999-2002, Microsoft Corporation.  All Rights Reserved.
'*****************************************************************************

Option Compare Text

Imports Microsoft.VisualBasic
Imports System
Imports System.Reflection
Imports System.Diagnostics
Imports System.Drawing
Imports System.Collections
Imports System.Windows.Forms


Public Class MemberNode : Inherits TreeNode
    ' This class is a complete representation of a member and a container for
    ' its associated XML content.  This class inherits from TreeNode so
    ' instances of it can be directly inserted into the Assembly tree.
    ' MemberNode instances are constructed from either reflection objects
    ' (which come from reflecting against the assembly) or from XML
    ' Documentation signatures (read from the XML Documentation file).  Each
    ' member node keeps track of its content descriptors through the use of
    ' five array lists which store the content descriptors.  Each member also
    ' keeps track of its kind, name, path, and associated errors.
    ' 
    ' Before an error can be reported on a member node, the node must first be
    ' added into the Assembly tree.
    '
    ' Every member has a Raw signature and a Friendly signature.  The raw
    ' signature (described below) is written to the XML Documentation file
    ' whereas the Friendly signature (similar to the declaration as it would
    ' appear in VB source) is the representation displayed to the user in the
    ' UI.
    '
    ' The raw signature (used in the "name" item of a "member" XML node) has
    ' the following structure:
    '     kind full-name ( params ) specialending
    ' where:
    '     'kind' is
    '         "N:" for namespace
    '         "T:" for class, structure, enum
    '         "F:" for field
    '         "P:" for property
    '         "M:" for method
    '         "E:" for event
    '         "!:" for error
    '     'full-name' is a dot-delimited, fully-qualified name.  Constructors
    '                 are represented as "#ctor" and "#cctor" (shared).
    '     'params'    is a comma-delimited list of type signatures (see class
    '                 ParameterDescriptor for details).  If there are no 
    '                 parameters, there are no parentheses.
    '     'specialending' is the return type prepended with a "~" for certain
    '                 special cases like op_Implicit and op_Explicit members.
    ' Examples:
    '     "N:Namespace1"
    '     "T:Namespace1.Class1"
    '     "M:Namespace1.Class1.Foo1(System.Int32,System.Int32@)"
    '     "M:Namespace1.Class1.Foo2"
    '
    ' Note: Whitespace is not allowed in the raw signature.

    Private Enum PropertyKind
        [ReadWrite]
        [ReadOnly]
        [WriteOnly]
    End Enum

    Private Const CTOR_SIG As String = "#ctor"              'Raw representation for a constructor.
    Private Const SHARED_CTOR_SIG As String = "#cctor"      'Raw representation for a shared constructor.

    Public Shared ReadOnly NormalColor As System.Drawing.Color = Color.Black    'Nodes with no errors are black.
    Public Shared ReadOnly ErrorColor As System.Drawing.Color = Color.Red       'Nodes with errors are red.

    Public Shared ReadOnly NormalFont As Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular) 'Nodes without content are normal.
    Public Shared ReadOnly EditedFont As Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold)    'Nodes with content are bold.

    Private m_Doc As MainDoc                'The core engine instance.

    Private m_Kind As NodeKind              'Type of the node.
    Private m_Name As String                'Name of the member node.
    Private m_Path As String                'The path in the tree hierarchy.
    Private m_ReturnType As String          'String representation of the return type.
    Private m_SpecialEnding As String       'The special ending if there is one.

    Private m_Errors As ArrayList           'List of errors for this treenode.
    Private m_Source As NodeSource          'Where this node was created from (Assmembly or XML Documentation file).

    Private m_IsShared As Boolean           'True if the member is declared with the Shared keyword.
    Private m_IsProtected As Boolean        'True if the member is declared with Protected accessibility.
    Private m_PropertyKind As PropertyKind  'Whether the property is ReadOnly, WriteOnly, or neither (if the member node represents a property).

    Public m_Summary As ArrayList           '"summary" content descriptors.
    Public m_Remarks As ArrayList           '"remarks" content descriptors.
    Public m_Params As ArrayList            '"param" parameter descriptors.
    Public m_PropertyValue As ArrayList     '"value" content descriptors.
    Public m_ReturnValue As ArrayList       '"returns" content descriptors.


    Private Sub New(ByVal kind As NodeKind, ByVal source As NodeSource, ByVal doc As MainDoc)
        ' Standard constructor for all member nodes.  All other constructors
        ' must call this one for standard initialization.  This constructor
        ' isn't sufficient on its own, however, thus it has private
        ' accessibility.

        MyBase.New()

        m_Doc = doc
        m_Kind = kind
        m_Source = source

        Me.NodeFont = NormalFont
        Me.ForeColor = NormalColor

        m_Summary = New ArrayList(1)  'every node has (at least) one summary field
        m_Remarks = New ArrayList(1)  'every node has (at least) one remarks field
        m_Params = New ArrayList()
        m_PropertyValue = New ArrayList()
        m_ReturnValue = New ArrayList()

        m_Errors = Nothing

        m_ReturnType = Nothing
    End Sub

    Public Sub New(ByVal kind As NodeKind, ByVal source As NodeSource, ByVal name As String, ByVal path As String, ByVal doc As MainDoc)
        ' Builds a node from only the name and path.  Used for namespaces and
        ' error nodes.

        MyClass.New(kind, source, doc)

        If kind = NodeKind.Error Then Me.ForeColor = ErrorColor

        m_Name = name
        m_Path = path

        m_IsShared = False
        m_IsProtected = False

        InitializeVisualElements()
    End Sub

    Public Sub New(ByVal t As Type, ByVal doc As MainDoc)
        ' Builds a member node from a Type reflection object.

        MyClass.New(ClassifyNodeKind(t), NodeSource.Assembly, doc)

        If t.MemberType = MemberTypes.NestedType Then
            'Nested types are delimited by "+", so we need to strip these out and append the parent classes
            'to the namespace for the full path.
            Dim i As Integer = t.FullName.LastIndexOf("+"c)
            m_Path = NormalizeTypeDelimiters(t.FullName.Substring(0, i))
        Else
            m_Path = t.Namespace
        End If

        m_Name = t.Name

        m_IsProtected = IsProtected(t)

        InitializeVisualElements()
    End Sub

    Public Sub New(ByVal ctor As ConstructorInfo, ByVal path As String, ByVal doc As MainDoc)
        ' Builds a member node from a ConstructorInfo reflection object.

        MyClass.New(NodeKind.Constructor, NodeSource.Assembly, doc)

        'Instance constructors have a name of "#ctor" whereas
        'shared constructors have a name of "#cctor".
        If ctor.IsStatic Then
            m_Name = SHARED_CTOR_SIG
            m_IsShared = True
        Else
            m_Name = CTOR_SIG
        End If

        m_Path = path

        AddParams(ctor.GetParameters)

        m_IsProtected = IsProtected(ctor)

        InitializeVisualElements()
    End Sub

    Public Sub New(ByVal field As FieldInfo, ByVal path As String, ByVal doc As MainDoc)
        ' Builds a member node from a Field reflection object.

        MyClass.New(ClassifyNodeKind(field), NodeSource.Assembly, doc)

        m_Name = field.Name
        m_Path = path
        m_IsShared = field.IsStatic
        m_IsProtected = IsProtected(field)

        InitializeVisualElements()
    End Sub

    Public Sub New(ByVal method As MethodInfo, ByVal path As String, ByVal doc As MainDoc)
        ' Builds a member node from a Method reflection object.

        MyClass.New(NodeKind.Method, NodeSource.Assembly, doc)

        m_Name = method.Name
        m_Path = path
        m_IsShared = method.IsStatic

        AddParams(method.GetParameters)

        m_IsProtected = IsProtected(method)

        'Determine the return type.  System.Void is ignored, so leave the return type as Nothing.
        If method.ReturnType.FullName <> "System.Void" Then
            m_ReturnType = NormalizeTypeDelimiters(method.ReturnType.FullName)
        End If

        'Handle the special cases for method names.
        Select Case method.Name
            Case "op_Implicit"
                m_SpecialEnding = "~" & m_ReturnType
            Case "op_Explicit"
                m_SpecialEnding = "~" & m_ReturnType
        End Select

        InitializeVisualElements()
    End Sub

    Public Sub New(ByVal prop As PropertyInfo, ByVal path As String, ByVal doc As MainDoc)
        ' Builds a member node from a Property reflection object.

        MyClass.New(NodeKind.Property, NodeSource.Assembly, doc)

        m_Name = prop.Name
        m_Path = path

        'This property is shared if its accessors are shared. 
        If prop.CanRead Then
            m_IsShared = prop.GetGetMethod(True).IsStatic
        Else
            m_IsShared = prop.GetSetMethod(True).IsStatic
        End If

        AddParams(prop.GetIndexParameters)

        m_IsProtected = IsProtected(prop)

        m_ReturnType = NormalizeTypeDelimiters(prop.PropertyType.FullName)

        'Determine the kind of property this is.
        If Not prop.CanRead Then
            m_PropertyKind = PropertyKind.WriteOnly
        ElseIf Not prop.CanWrite Then
            m_PropertyKind = PropertyKind.ReadOnly
        Else
            m_PropertyKind = PropertyKind.ReadWrite
        End If

        InitializeVisualElements()
    End Sub

    Public Sub New(ByVal ei As EventInfo, ByVal path As String, ByVal doc As MainDoc)
        ' Builds a member node from an Event reflection object.

        MyClass.New(NodeKind.Event, NodeSource.Assembly, doc)

        m_Name = ei.Name
        m_Path = path

        m_IsProtected = IsProtected(ei)

        InitializeVisualElements()
    End Sub

    Public Sub New(ByVal RawSignature As String, ByVal doc As MainDoc)
        ' Builds a member node from a raw signature from an XML Documentation
        ' file. This constructor is used if the matching member was not found
        ' within the Assembly file, therefore member nodes constructed in this
        ' manner automatically have a XML-only error.

        MyClass.New(ClassifyNodeKind(Left(RawSignature, 2)), NodeSource.XML, doc)

        'A bad raw signature results in bad member.
        If RawSignature = BAD_SIG Then
            MakeBad()
            'Before reporting an error, we need to add this new MemberNode to the tree.
            m_Doc.AddToTree(Me)
            m_Doc.ReportError(Me, ErrorID.MemberNameItemNotValid)
            Return
        End If

        Try
            If m_Kind = NodeKind.Error Then  'The node kind has already been set by the standard constructor.
                Throw New Exception()
            End If

            'Parse the signature into its constituent parts.
            Dim ParsedSignature As Signature = ParseRawSignature(RawSignature)

            Dim FullName As String = ParsedSignature.FullName

            'Build the parameter descriptors if the signature contains parameters.
            'The actual content will be filled in later as we continue to parse the XML Documentation file,
            'however the "shell" of the member must be created beforehand.
            If Not ParsedSignature.Params Is Nothing Then
                Dim paramsig As String
                For Each paramsig In ParsedSignature.Params
                    Dim NewParameter As ParameterDescriptor = New ParameterDescriptor(paramsig)
                    m_Params.Add(NewParameter)
                Next
            End If

            'Handle nested types correctly if they've snuck into the XML Documentation file.
            FullName = NormalizeTypeDelimiters(FullName)

            'The name is everything after the last dot, the path is everything before it.
            Dim LastDot As Integer = FullName.LastIndexOf("."c)
            If LastDot = -1 Then
                m_Path = ""
                m_Name = FullName
            Else
                m_Path = FullName.Substring(0, LastDot)
                m_Name = FullName.Substring(LastDot + 1)
            End If

            'If the name is one of the special constructor names, then change this
            'member's kind to Constructor.
            If m_Name = CTOR_SIG OrElse m_Name = SHARED_CTOR_SIG Then
                m_Kind = NodeKind.Constructor

                If m_Name = SHARED_CTOR_SIG Then
                    m_IsShared = True
                End If
            End If

            m_SpecialEnding = ParsedSignature.SpecialEnding

            'This kind of information is not stored in the raw signature, so just set them to false.
            m_IsShared = False
            m_IsProtected = False

            'The member node is now constructed enough that we can setup its visual elements.
            InitializeVisualElements()

            'This is an XML-only node, so report it as such, but before reporting
            'an error, we need to add this new MemberNode to the tree.
            m_Doc.AddToTree(Me)
            m_Doc.AddToHashtable(Me)
            m_Doc.ReportError(Me, ErrorID.NodeInXMLOnly)

        Catch e As Exception
            'Any exception thrown during construction indicates a bad member.
            MakeBad()
            InitializeVisualElements()

            'Before reporting an error, we need to add this new MemberNode to the tree
            m_Doc.AddToTree(Me)
            m_Doc.ReportError(Me, ErrorID.BadSignatureInMemberNode1, RawSignature)
        End Try

    End Sub
    Public Sub New()
        ' Builds an empty node.  This is necessary for cloning.

        MyBase.New()
    End Sub

    Private Shared BadMemberCounter As Integer = 1  'Used to create a unique name for bad members.

    Private Sub MakeBad()
        m_Kind = NodeKind.Error

        m_Path = ""
        m_Name = BAD_MEMBER_NAME & " " & CStr(BadMemberCounter)  'The counter makes sure the name is unique.
        BadMemberCounter += 1
    End Sub

    Private Sub InitializeVisualElements()
        ' Initialize the fields which determine how the member node is
        ' rendered on the screen.  The friendly signature is the text which
        ' appears in the Assembly tree.  Additionally, the correct icon
        ' needs to be selected based on the kind of member node and whether it
        ' has Protected accessibility.

        Me.Text = Me.FriendlySignature

        'Determine the appropriate icon for the tree node.
        Dim index As Integer = MapToImageIndex(m_Kind, m_IsProtected)
        Me.ImageIndex = index
        Me.SelectedImageIndex = index
    End Sub

    Public ReadOnly Property Source() As NodeSource
        Get
            Return m_Source
        End Get
    End Property

    Public ReadOnly Property Path() As String
        Get
            Return m_Path
        End Get
    End Property

    Public ReadOnly Property Name() As String
        Get
            Return m_Name
        End Get
    End Property

    Public Function HasContent() As Boolean
        ' Returns true if this member node has any non-empty content
        ' descriptors, false otherwise.

        Dim CurrentDescriptor As ContentDescriptor

        For Each CurrentDescriptor In m_Summary
            If CurrentDescriptor.Content <> "" Then
                Return True
            End If
        Next

        For Each CurrentDescriptor In m_Params
            If CurrentDescriptor.Content <> "" Then
                Return True
            End If
        Next

        For Each CurrentDescriptor In m_PropertyValue
            If CurrentDescriptor.Content <> "" Then
                Return True
            End If
        Next

        For Each CurrentDescriptor In m_ReturnValue
            If CurrentDescriptor.Content <> "" Then
                Return True
            End If
        Next

        For Each CurrentDescriptor In m_Remarks
            If CurrentDescriptor.Content <> "" Then
                Return True
            End If
        Next

        Return False
    End Function

    Public Sub UpdateEditState()
        ' Member nodes with content are bold, otherwise they have a normal
        ' font style.  This function is called when a modification has been
        ' made to the content of a member node and its font weight needs to be
        ' adjusted.

        If Me.HasContent() Then
            Me.NodeFont = EditedFont
            FileDirty = True
        Else
            Me.NodeFont = NormalFont
        End If
    End Sub

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

        'Most member nodes have no errors, so the error list gets created only when
        'an error gets added.

        If m_Errors Is Nothing Then
            m_Errors = New ArrayList(1)
        End If

        m_Errors.Add(NewError)
        Me.ForeColor = ErrorColor
    End Sub

    Public Sub RemoveError(ByVal OldError As ErrorRecord)
        Debug.Assert(Not OldError Is Nothing, "Must have a valid ErrorRecord to remove.")
        Debug.Assert(Not m_Errors Is Nothing AndAlso m_Errors.Contains(OldError), _
                     "Attempting to remove an error which is not in the list.")

        m_Errors.Remove(OldError)

        'Destroy the error list if there are no more errors.
        If m_Errors.Count = 0 Then
            m_Errors = Nothing
            Me.ForeColor = NormalColor
        End If
    End Sub

    Public Sub RemoveAllErrors()
        Debug.Assert(Not m_Errors Is Nothing, "Attempting to remove errors where no errors exist.")

        m_Errors.Clear()
        m_Errors = Nothing
        Me.ForeColor = NormalColor
    End Sub

    Public Function HasErrors() As Boolean
        Debug.Assert(m_Errors Is Nothing OrElse m_Errors.Count > 0, _
                     "List must have more than 0 items if it is allocated.")
        Return Not m_Errors Is Nothing
    End Function

    Private Function AppendModifiers(ByVal sig As String) As String
        ' Decorates the input with the appropriate VB keywords.

        If m_IsShared Then
            sig = "Shared " & sig
        End If

        If m_PropertyKind = PropertyKind.ReadOnly Then
            sig = "ReadOnly " & sig
        ElseIf m_PropertyKind = PropertyKind.WriteOnly Then
            sig = "WriteOnly " & sig
        End If

        Return sig
    End Function

    Public ReadOnly Property FriendlyKind() As String
        Get
            Return m_Kind.ToString
        End Get
    End Property

    Public ReadOnly Property FriendlySignature() As String
        ' Builds the friendly signature for this member node.  The friendly
        ' signature is what the VB declaration would look like.  This is used
        ' for the node's text as displayed in the Assembly tree.

        Get
            Dim sig As String = ""

            If m_Kind = NodeKind.Constructor Then
                sig &= "New"
            Else
                sig &= m_Name
            End If

            If CanHaveParameters(m_Kind) Then
                Dim UseParens As Boolean = m_Kind <> NodeKind.Property OrElse m_Params.Count > 0

                If UseParens Then
                    sig &= "("
                End If

                Dim first As Boolean = True

                Dim CurrentParameter As ParameterDescriptor
                For Each CurrentParameter In m_Params
                    If Not first Then
                        sig &= ", "
                    Else
                        first = False
                    End If
                    sig &= CurrentParameter.FriendlyType
                Next

                If UseParens Then
                    sig &= ")"
                End If

                sig &= Me.FriendlyReturnType
            End If

            Return sig
        End Get
    End Property

    Public ReadOnly Property FriendlySignatureWithPath() As String
        ' Builds a friendly signature and prepends the path.

        Get
            Dim sig As String = Me.FriendlySignature
            If m_Path <> "" Then
                sig = m_Path & "." & sig
            End If
            Return sig
        End Get
    End Property

    Public ReadOnly Property FriendlySignatureWithPathAndModifiers() As String
        ' Full friendly signature with modifiers.  Used for the titles of node
        ' windows.

        Get
            Return AppendModifiers(Me.FriendlySignatureWithPath)
        End Get
    End Property

    Public ReadOnly Property FriendlyReturnType() As String
        ' Builds the friendly representation of the return type (using
        ' VB-style array notation and type names).

        Get
            Dim ret As String = ""
            If m_ReturnType <> "" Then
                ret &= " As " & UseFriendlyArrayNotation(IntrinsicToVBType(m_ReturnType))
            End If
            Return ret
        End Get
    End Property

    Public ReadOnly Property RawSignature() As String
        ' Builds the raw signature for the member node.  This signature is
        ' written to the XML Documentation file.

        Get
            Dim sig As System.Text.StringBuilder = New System.Text.StringBuilder()

            sig.Append(NodeKindRepresentation(m_Kind))

            If m_Path <> "" Then
                sig.Append(m_Path & ".")
            End If

            sig.Append(m_Name)

            'Parameter parentheses will have to be omitted if there are no parameters.
            If CanHaveParameters(m_Kind) AndAlso m_Params.Count > 0 Then
                Dim first As Boolean = True

                Dim CurrentParameter As ParameterDescriptor
                For Each CurrentParameter In m_Params
                    If first Then
                        sig.Append("("c)
                        first = False
                    Else
                        sig.Append(","c)
                    End If
                    sig.Append(CurrentParameter.RawSignature)
                Next

                sig.Append(")"c)
            End If

            If m_SpecialEnding <> "" Then
                sig.Append(m_SpecialEnding)
            End If

            Return sig.ToString
        End Get
    End Property

    Public Function GenerateXML() As String
        ' Builds the complete XML representation for this member node, using
        ' the raw signature and the content descriptors, in this format:
        '
        '                 <member name="the raw signature">
        ' optional nodes:
        '                     <summary>content</summary>
        '                     <param name="the parameter name">content</param>
        '                     <value>content</value>
        '                     <returns>content</returns>
        '                     <remarks>content</remarks>
        '                 </member>

        'If the node has no content to write, or it's a bad member, then ignore it.
        If Not Me.HasContent() Then
            Return Nothing
        End If

        Dim n As System.Text.StringBuilder = New System.Text.StringBuilder()

        n.Append(INDENT2 & "<member name=" & ControlChars.Quote & Me.RawSignature & ControlChars.Quote & ">" & vbCrLf)

        Dim CurrentDescriptor As ContentDescriptor
        For Each CurrentDescriptor In m_Summary
            If CurrentDescriptor.Content <> "" Then
                n.Append(INDENT3 & "<summary>" & CurrentDescriptor.Content & "</summary>" & vbCrLf)
            End If
        Next

        Dim CurrentParameter As ParameterDescriptor
        For Each CurrentParameter In m_Params
            If CurrentParameter.Content <> "" Then
                n.Append(INDENT3 & "<param name=""" & CurrentParameter.Name & """>" & CurrentParameter.Content & "</param>" & vbCrLf)
            End If
        Next

        For Each CurrentDescriptor In m_PropertyValue
            If CurrentDescriptor.Content <> "" Then
                n.Append(INDENT3 & "<value>" & CurrentDescriptor.Content & "</value>" & vbCrLf)
            End If
        Next

        For Each CurrentDescriptor In m_ReturnValue
            If CurrentDescriptor.Content <> "" Then
                n.Append(INDENT3 & "<returns>" & CurrentDescriptor.Content & "</returns>" & vbCrLf)
            End If
        Next

        For Each CurrentDescriptor In m_Remarks
            If CurrentDescriptor.Content <> "" Then
                n.Append(INDENT3 & "<remarks>" & CurrentDescriptor.Content & "</remarks>" & vbCrLf)
            End If
        Next

        n.Append(INDENT2 & "</member>" & vbCrLf)

        Return n.ToString

    End Function

    Public Sub PopulateFromXML(ByVal node As Xml.XmlNode)
        ' Given an XML node from the XML Documentation file, fill-in the
        ' member node with the content inside the XML node.  Depending on the
        ' member node's kind, the XML node may have errors (for example,
        ' multiple summary fields or param fields for a namespace).  This
        ' function detects these errors and reports them.

        Dim el As Xml.XmlNode

        'Build a list of params on the member node so that once we match content to a parameter,
        'we can remove that parameter from further consideration.
        Dim ParamsToSearch As ArrayList
        ParamsToSearch = CType(m_Params.Clone(), ArrayList)

        For Each el In node.ChildNodes
            Dim content As String = el.InnerXml.Trim()
            'We only care if the XML field contains any content.
            If content <> "" Then
                'Depending on the XML field kind, we will build the appropriate content descriptor,
                'and detect any error conditions.
                Select Case el.Name
                    Case "summary"
                        Dim NewSummary As ContentDescriptor = New ContentDescriptor(content)
                        m_Summary.Add(NewSummary)

                        If m_Summary.Count > 1 Then
                            m_Doc.ReportError(Me, NewSummary, ErrorID.DuplicateField1, "summary")
                        End If

                    Case "remarks"
                        Dim NewRemarks As ContentDescriptor = New ContentDescriptor(content)
                        m_Remarks.Add(NewRemarks)

                        If m_Remarks.Count > 1 Then
                            m_Doc.ReportError(Me, NewRemarks, ErrorID.DuplicateField1, "remarks")
                        End If

                    Case "value"
                        Dim NewValue As ContentDescriptor = New ContentDescriptor(content)
                        m_PropertyValue.Add(NewValue)

                        'Only Properties can have "value" fields.
                        If m_Kind <> NodeKind.Property Then
                            m_Doc.ReportError(Me, NewValue, ErrorID.UnexpectedField2, "value", "properties")
                        End If
                        If m_PropertyValue.Count > 1 Then
                            m_Doc.ReportError(Me, NewValue, ErrorID.DuplicateField1, "value")
                        End If

                    Case "returns"
                        Dim NewReturnValue As ContentDescriptor = New ContentDescriptor(content)
                        m_ReturnValue.Add(NewReturnValue)

                        'Only Methods can have "returns" fields.
                        If m_Kind <> NodeKind.Method Then
                            m_Doc.ReportError(Me, NewReturnValue, ErrorID.UnexpectedField2, "returns", "methods")
                        End If
                        If m_ReturnValue.Count > 1 Then
                            m_Doc.ReportError(Me, NewReturnValue, ErrorID.DuplicateField1, "returns")
                        End If

                    Case "param"

                        Dim paramName As String = ""
                        Try
                            paramName = el.Attributes.GetNamedItem("name").Value().Trim
                        Catch
                            'No "name" item means this is a bad parameter.
                            Dim BadParam As ParameterDescriptor = New ParameterDescriptor(UNKNOWN_PARAM_NAME, content)
                            m_Params.Add(BadParam)
                            m_Doc.ReportError(Me, BadParam, ErrorID.ParamNameItemNotValid1, m_Name)
                            GoTo continue   'VB wish:  add a Continue keyword.
                        End Try

                        Dim CurrentParam As ParameterDescriptor = Nothing

                        'Search the member node's paramters looking for a match.
                        For Each CurrentParam In ParamsToSearch
                            If CurrentParam.Name = UNKNOWN_PARAM_NAME Then
                                'We found a blank name, so match it with this param node and fill in the name and content.
                                'This is useful for XML-only nodes because the param name is not encoded in the 
                                'raw signature.
                                CurrentParam.Name = paramName
                                CurrentParam.Content = content
                                ParamsToSearch.Remove(CurrentParam)
                                Exit For
                            End If

                            If CurrentParam.Name = paramName Then
                                'The names match, so fill in the content.
                                CurrentParam.Content = content
                                ParamsToSearch.Remove(CurrentParam)
                                Exit For
                            End If
                        Next

                        If CurrentParam Is Nothing OrElse paramName = UNKNOWN_PARAM_NAME Then
                            CurrentParam = New ParameterDescriptor(paramName, content)
                            m_Params.Add(CurrentParam)
                            m_Doc.ReportError(Me, CurrentParam, ErrorID.ParamNotFound2, paramName, m_Name)
                        End If

                        If Not CanHaveParameters(m_Kind) Then
                            m_Doc.ReportError(Me, CurrentParam, ErrorID.UnexpectedField2, "param", "methods and properties")
                        End If

                    Case Else
                        m_Doc.ReportError(Me, ErrorID.UnknownField2, el.Name, el.InnerText)
                End Select
            End If
continue:
        Next

        'The member node's content may have changed, so update its visual state.
        UpdateEditState()
    End Sub

    Public Sub EnsureDefaultDescriptors()
        ' Member nodes do not have content descriptors allocated by default to
        ' save memory.  Only when the user adds content do the descriptors get
        ' created.  However it is very useful, during drag-and-drop for
        ' example, to allocated the default set of descriptors.  This makes
        ' comparisons between nodes easier.

        'All nodes have one summary field.
        If m_Summary.Count = 0 Then
            m_Summary.Add(New ContentDescriptor())
        End If

        'All nodes have one remarks field.
        If m_Remarks.Count = 0 Then
            m_Remarks.Add(New ContentDescriptor())
        End If

        'If this is a property, then it has a property value field.
        If m_Kind = NodeKind.Property AndAlso m_PropertyValue.Count = 0 Then
            m_PropertyValue.Add(New ContentDescriptor())
        End If

        'If this is a method with a return type, then it has a return value field.
        If m_Kind = NodeKind.Method AndAlso m_ReturnType <> "" AndAlso m_ReturnValue.Count = 0 Then
            m_ReturnValue.Add(New ContentDescriptor())
        End If

        'Param fields are built only during node construction and populating from the XML file,
        'so there is nothing to do here.
    End Sub

    Public Shared Function ContentCount(ByVal list As ArrayList) As Integer
        ' When comparing nodes for drag-and-drop, the count of content
        ' descriptor objects is not useful.  The last index of the content
        ' descriptor with actual content in it is useful because this
        ' number represents how many content descriptors will actually need to
        ' be copied.

        Dim maxindex As Integer = -1
        Dim i As Integer
        For i = 0 To list.Count - 1
            If CType(list(i), ContentDescriptor).Content <> "" Then
                maxindex = i
            End If
        Next

        Return maxindex + 1
    End Function

    Public Shared Function ClassifyDifference(ByVal source As MemberNode, ByVal dest As MemberNode) As Difference
        ' Determine the difference between the source and destination member
        ' nodes.  This tells us if a copy can succeed.  Before doing any work,
        ' however, it is much easier if we first ensure that all the default
        ' descriptors are allocated.

        source.EnsureDefaultDescriptors()
        dest.EnsureDefaultDescriptors()

        'Determine if there are enough slots in the destination to hold all of the content in the source.
        'First, count how much content is in the source.  If this number is less than or equal to the number
        'of descriptors sitting in the destination, then the copy can succeed.
        'We count the content from the source because empty content ("") will not get copied and should not
        'disqualify a copy from occuring.

        If ContentCount(source.m_Summary) > dest.m_Summary.Count Then
            Return Difference.SummaryNum

        ElseIf ContentCount(source.m_Remarks) > dest.m_Remarks.Count Then
            Return Difference.RemarksNum

        ElseIf ContentCount(source.m_ReturnValue) > dest.m_ReturnValue.Count Then
            Return Difference.ReturnNum

        ElseIf ContentCount(source.m_PropertyValue) > dest.m_PropertyValue.Count Then
            Return Difference.PropertyValueNum

        ElseIf ContentCount(source.m_Params) > dest.m_Params.Count Then
            Return Difference.ParamNum

        End If

        Return Difference.None

    End Function

    Public Sub Copy(ByVal source As MemberNode)
        ' Copy the source's content descriptors to this node.

        Dim dest As MemberNode = Me  'For readability.

        CopyDescriptors(source.m_Summary, dest.m_Summary)
        CopyDescriptors(source.m_Params, dest.m_Params)
        CopyDescriptors(source.m_ReturnValue, dest.m_ReturnValue)
        CopyDescriptors(source.m_Remarks, dest.m_Remarks)
        CopyDescriptors(source.m_PropertyValue, dest.m_PropertyValue)

        dest.UpdateEditState()
    End Sub

    Private Shared Sub CopyDescriptors(ByVal sourceList As ArrayList, ByVal destList As ArrayList)
        ' Copy the content fields of each content descriptor in the source
        ' list to the destination list.

        Debug.Assert(ContentCount(sourceList) <= destList.Count, _
                     "lists should be of similar size, as guaranteed by ClassifyDifference")

        Dim i As Integer
        For i = 0 To ContentCount(sourceList) - 1
            Dim source As ContentDescriptor = CType(sourceList(i), ContentDescriptor)
            Dim dest As ContentDescriptor = CType(destList(i), ContentDescriptor)

            'Don't overwrite existing content with non-existant content.
            If source.Content <> "" Then
                dest.Content = source.Content
            End If
        Next

    End Sub

    Private Sub AddParams(ByVal params() As ParameterInfo)
        ' Create a parameter descriptor out of each parameter reflection
        ' object.

        Dim param As ParameterInfo
        For Each param In params
            m_Params.Add(New ParameterDescriptor(param))
        Next
    End Sub

    Private Shared Function MapToImageIndex(ByVal kind As NodeKind, ByVal isprotected As Boolean) As Integer
        ' Looks up the treenode icon based on the node kind and accessibility.
        ' Returns an icon index into the imagestrip resource.

        Dim indexKind As Integer

        Select Case kind
            Case NodeKind.Class
                indexKind = VB_IMG_CLASS
            Case NodeKind.Delegate
                indexKind = VB_IMG_DELEGATE
            Case NodeKind.Module
                indexKind = VB_IMG_MODULE
            Case NodeKind.Enum
                indexKind = VB_IMG_ENUM
            Case NodeKind.EnumMember
                indexKind = VB_IMG_ENUMMEMBER
            Case NodeKind.Event
                indexKind = VB_IMG_EVENT
            Case NodeKind.Field
                indexKind = VB_IMG_FIELD
            Case NodeKind.Constant
                indexKind = VB_IMG_CONSTANT
            Case NodeKind.Interface
                indexKind = VB_IMG_INTERFACE
            Case NodeKind.Method, NodeKind.Constructor
                indexKind = VB_IMG_METHOD
            Case NodeKind.Namespace
                indexKind = VB_IMG_NAMESPACE
            Case NodeKind.Property
                indexKind = VB_IMG_PROPERTY
            Case NodeKind.Structure
                indexKind = VB_IMG_STRUCT
            Case Else
                Debug.Assert(kind = NodeKind.Error, "Unexpected node kind: ", kind.ToString)
                indexKind = VB_IMG_ERROR
        End Select

        'All nodes are either Public or Protected accessibility.

        Dim indexAccess As Integer
        If isprotected Then
            indexAccess = VB_IMG_ACC_PROTECTED
        Else
            indexAccess = VB_IMG_ACC_PUBLIC
        End If

        Return indexKind + indexAccess
    End Function

    Public Overloads Overrides Function Clone() As Object
        ' Clone this node.  This will be used when copy/pasting nodes.

        'Clone base
        Dim copy As New MemberNode()
        copy = CType(MyBase.Clone(), MemberNode)

        'Clone data
        copy.m_Kind = m_Kind
        copy.m_Name = m_Name
        copy.m_Path = m_Path
        copy.m_ReturnType = m_ReturnType
        copy.m_SpecialEnding = m_SpecialEnding
        copy.m_Errors = Me.Errors
        copy.m_Source = m_Source
        copy.m_IsShared = m_IsShared
        copy.m_IsProtected = m_IsProtected
        copy.m_PropertyKind = m_PropertyKind


        'Clone Summary field
        Dim n As Integer
        Dim content As ContentDescriptor
        copy.m_Summary = New ArrayList(m_Summary.Count)
        For n = 0 To m_Summary.Count - 1
            content = New ContentDescriptor(CType(m_Summary(n), ContentDescriptor).Content)
            copy.m_Summary.Add(content)
        Next

        'Clone Remarks field
        copy.m_Remarks = New ArrayList(m_Remarks.Count)
        For n = 0 To m_Remarks.Count - 1
            content = New ContentDescriptor(CType(m_Remarks(n), ContentDescriptor).Content)
            copy.m_Remarks.Add(content)
        Next

        'Clone Params fields
        Dim param As ParameterDescriptor
        Dim source As ParameterDescriptor
        copy.m_Params = New ArrayList(m_Params.Count)
        For n = 0 To m_Params.Count - 1
            source = CType(m_Params(n), ParameterDescriptor)
            copy.m_Params.Add(source.Clone)
        Next

        'Clone PropertyValue field
        copy.m_PropertyValue = New ArrayList(m_PropertyValue.Count)
        For n = 0 To m_PropertyValue.Count - 1
            content = New ContentDescriptor(CType(m_PropertyValue(n), ContentDescriptor).Content)
            copy.m_PropertyValue.Add(content)
        Next

        'Clone ReturnValue field
        copy.m_ReturnValue = New ArrayList(m_ReturnValue.Count)
        For n = 0 To m_ReturnValue.Count - 1
            content = New ContentDescriptor(CType(m_ReturnValue(n), ContentDescriptor).Content)
            copy.m_ReturnValue.Add(content)
        Next

        Return copy

    End Function
End Class

Public Enum Difference
    'Types of differences between two member nodes.
    None
    ParamNum
    SummaryNum
    RemarksNum
    ReturnNum
    PropertyValueNum
End Enum

Public Enum NodeSource
    'The source from where the member node was created.
    [XML]
    [Assembly]
End Enum

Public Enum NodeKind
    'The member node's kind.
    [Namespace]
    [Class]
    [Delegate]
    [Interface]
    [Module]
    [Structure]
    [Enum]
    [Field]
    [EnumMember]
    [Constant]
    [Method]
    [Constructor]
    [Property]
    [Event]
    [Error]
End Enum
