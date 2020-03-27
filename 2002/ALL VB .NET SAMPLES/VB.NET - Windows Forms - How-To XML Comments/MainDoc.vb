'*****************************************************************************
' Copyright (C) 1999-2002, Microsoft Corporation.  All Rights Reserved.
'*****************************************************************************

Option Compare Text     'For case insensitive string comparisons.

Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Diagnostics
Imports System.Reflection
Imports System.Collections
Imports System.Windows.Forms
Imports System.Xml

Public Class MainDoc
    ' A class which represents the core engine of the XML Documentation Tool.
    ' There is one and only one instance of a MainDoc per loaded assembly.  It
    ' performs file loads, reflection, error management, and populates the
    ' Assembly tree with member nodes.  A hash table is used to quickly
    ' determine which entries in the XML Documentation file match members
    ' contained within the assembly.  The key used for the hashtable lookup
    ' is the raw string signature of the member as it would be written to the
    ' XML Documentation file.  These signatures are guaranteed to be unique because
    ' they contain the fully qualified name of the member.

    Private m_Members As Hashtable      'A table for matching members in the assembly and XML Documentation files.
    Private m_ParentForm As MainWindow  'The user interface for the tool.

    Public m_Asm As [Assembly]          'The assembly the user has opened.
    Public m_XMLData As VersionData     'Version information for the XML Documentation file.


    Public Sub New(ByVal form As MainWindow, ByVal asm As [Assembly])
        m_ParentForm = form
        m_Asm = asm

        'We will do case insensitive comparison between hashtable keys.
        m_Members = New Hashtable(New CaseInsensitiveHashCodeProvider(), New CaseInsensitiveComparer())
    End Sub

    Public Sub OpenXML(ByVal filename As String)
        ' Open the XML Documentation file, find the root node and start the
        ' parse.

        If filename = "" Then Throw New Exception("The file name is not valid.")

        Dim xmlDoc As XmlDocument = New XmlDocument()

        xmlDoc.Load(filename)

        Dim root As XmlNode = xmlDoc.FirstChild

        If root Is Nothing Then
            Throw New Exception("Root node cannot be found in the XML Documentation file '" & filename & "'.")
        End If

        'Skip the XML document header.
        If root.Name = "xml" Then
            'The root doc node should be next.
            root = root.NextSibling
        End If

        If LCase(root.Name) = "doc" Then
            'Begin the import.
            ParseXML(root)

            'Make sure all the opened windows get updated if we've imported data for some of them.
            If m_ParentForm.MdiClient.MdiChildren.Length > 0 Then
                Dim nodeWindow As NodeWindow
                For Each nodeWindow In m_ParentForm.MdiClient.MdiChildren
                    nodeWindow.Update()
                Next
            End If
        Else
            Throw New Exception("'doc' node cannot be found.")
        End If

    End Sub

    Private Sub ParseXML(ByVal root As Xml.XmlNode)
        ' Walk the XML Documentation file reading-in all the data.  The format
        ' of the XML Documentation file is roughly:
        ' 
        '               <doc>
        ' Version info:
        '                   <assembly>
        '                       <name>
        '                       <version>
        '                       <fullname>
        '                   <members>
        '                       <member name="the raw signature">
        ' Content nodes:
        '                           <summary>
        '                           <remarks>
        '                           <value>
        '                           <returns>
        '                           <param name="the parameter name">
        '
        ' The signature determines which content nodes are allowed (for
        ' example, fields are not allowed to have param content).  The
        ' signature format is discussed in MemberNode.
        '
        ' This function walks each <member> node, comparing its signature to
        ' the contents of the hashtable.  If it finds a match, then the member
        ' node matches a member imported from the assembly.  If there is no
        ' match, the member is found only in the XML Documentation file.  If
        ' the signature cannot be parsed for some reason, the member is Bad
        ' and an error is reported.
        '
        ' See MSDN for more information.

        Dim child As Xml.XmlNode
        Dim node As Xml.XmlNode
        For Each child In root.ChildNodes

            Select Case LCase(child.Name)
                Case "assembly"
                    'Build a version data structure from the version info contained within the XML Documentation file.
                    Dim Name As String = ""
                    Dim Version As String = ""
                    Dim FullName As String = ""

                    For Each node In child.ChildNodes
                        Select Case LCase(node.Name)
                            Case "name"
                                Name = node.InnerXml.Trim
                            Case "version"
                                Version = node.InnerXml.Trim
                            Case "fullname"
                                FullName = node.InnerXml.Trim
                        End Select
                    Next
                    m_XMLData = New VersionData(Name, Version, FullName)

                Case "members"

                    For Each node In child.ChildNodes

                        If LCase(node.Name) = "member" Then

                            Dim RawSignature As String      'The signature as it appears in the XML Documentation file.
                            Dim CleanSignature As String    'The signature cleaned of inconsistencies, used as a key into the hashtable.

                            Try
                                RawSignature = node.Attributes.GetNamedItem("name").Value.Trim
                                'Parse the raw signature into its parts and reassemble it to "clean" it.
                                CleanSignature = ParseRawSignature(RawSignature).ToString
                            Catch e As Exception
                                'If something goes wrong with the parse, the signature is bad.
                                CleanSignature = BAD_SIG
                            End Try

                            Dim member As MemberNode

                            If m_Members.ContainsKey(CleanSignature) Then
                                'The member has been imported from the Assembly.  Select that member.
                                member = CType(m_Members.Item(CleanSignature), MemberNode)
                            Else
                                'The member only appears in the XML Documentation file.  Construct a new one based off the signature.
                                member = New MemberNode(RawSignature, Me)
                            End If

                            'Populate the content descriptors from the content nodes in the XML Documentation file.
                            member.PopulateFromXML(node)
                        Else
                            'We found a node other than "member" so construct a Bad member and put it in the tree.
                            Dim BadMember As MemberNode = New MemberNode("Bad Member", Me)
                            AddToTree(BadMember)
                            ReportError(BadMember, ErrorID.MemberNotValid1, node.Name)
                        End If
                    Next

                Case Else
                    Dim message As String = "Unexpected node '" & child.Name & "' has been found and will be ignored. Abort load of XML file?"

                    If vbYes = MsgBox(message, MsgBoxStyle.YesNo) Then
                        Exit For
                    End If
            End Select
        Next
    End Sub

    Public Sub SaveXML(ByVal filename As String)
        ' Recursively walk the tree writing out each member to the XML
        ' Documentation file.

        If filename = "" Then Throw New Exception("The file name is not valid.")

        Dim xmlStr As IO.StreamWriter
        xmlStr = New IO.StreamWriter(filename)

        'Write the XML header.
        xmlStr.WriteLine("<?xml version=""1.0""?>")
        xmlStr.WriteLine("<doc>")

        'Write the assembly version info.
        xmlStr.WriteLine(INDENT1 & "<assembly>")
        xmlStr.WriteLine(INDENT2 & "<name>" & m_Asm.GetName.Name & "</name>")
        xmlStr.WriteLine(INDENT2 & "<version>" & m_Asm.GetName.Version.ToString & "</version>")
        xmlStr.WriteLine(INDENT2 & "<fullname>" & m_Asm.GetName.FullName & "</fullname>")
        xmlStr.WriteLine(INDENT1 & "</assembly>")

        xmlStr.WriteLine(INDENT1 & "<members>")

        'Recursively write the members (if there are any).
        If m_ParentForm.TreeView.GetNodeCount(False) > 0 Then
            Dim node As MemberNode
            For Each node In m_ParentForm.TreeView.Nodes
                RecursivelySave(xmlStr, node)
            Next
        End If

        'Write the ending.
        xmlStr.WriteLine(INDENT1 & "</members>")
        xmlStr.WriteLine("</doc>")
        xmlStr.Close()

    End Sub

    Private Sub RecursivelySave(ByVal xmlStr As System.IO.StreamWriter, ByVal node As MemberNode)
        ' Each node is asked to generate its XML form.  This is then written
        ' to the XML Documentation file.

        Dim xmlString As String = node.GenerateXML()
        If Not xmlString Is Nothing Then
            xmlStr.Write(xmlString)
        End If

        If node.GetNodeCount(False) > 0 Then
            'Recurse on the children of this node.
            Dim subnode As MemberNode
            For Each subnode In node.Nodes
                RecursivelySave(xmlStr, subnode)
            Next
        End If
    End Sub

    Public Sub AddToTree(ByVal member As MemberNode)
        ' Add the member node to the appropriate location in the Assembly
        ' tree.  We use the path of the member to walk down the tree.  Because
        ' namespaces are not imported through refelection and may not
        ' necessarily have entries in the XML Documentation file, we need to
        ' create the namespace nodes on the fly if they cannot be found when
        ' walking down the tree.  We find matches based on case-insensitive
        ' name comparison.  Names are case-insensitive unique when built from 
        ' CLS compliant compilers.

        Dim nodes As TreeNodeCollection     'The parent where we will insert the new member.

        nodes = m_ParentForm.TreeView.Nodes

        'First we need to find the insertion point in the tree.
        'If the path is empty, this is a root node.
        If member.Path <> "" Then

            'Split the path into its components.  This will be our search order.
            Dim leaves() As String
            leaves = member.Path.Split("."c)

            'In case we need to build a new node, we need the path to build it with.
            'Keep track of the path as we walk down the tree.
            Dim currentpath As String = ""

            Dim leaf As String
            For Each leaf In leaves

                Dim found As Boolean = False
                Dim node As MemberNode

                'Walk the tree up to the last node
                For Each node In nodes
                    If node.Text = leaf Then    'This is a case-insensitive compare, because of Option Compare Text.
                        found = True
                        Exit For
                    End If
                Next

                'If one of the components of the path is not found then we need to build
                'a node for it.  This is how Namespace nodes get built as they are not exposed
                'as exported types through reflection.

                If Not found Then

                    'We need to create intermediate node, but what kind depends upon the source
                    'of the member we are trying to add.  If the member node comes from the assembly,
                    'then we know we need to build a Namespace for it.  If it comes from the XML Documentation
                    'file, then it is unknown what kind of node this is (could be a namespace, a class,
                    'a structure, etc.), so make it an error node.

                    If member.Source = NodeSource.Assembly Then
                        node = New MemberNode(NodeKind.Namespace, NodeSource.Assembly, leaf, currentpath, Me)
                    Else
                        node = New MemberNode(NodeKind.Error, NodeSource.XML, leaf, currentpath, Me)
                    End If

                    'Add the new node to the tree.
                    nodes.Add(node)
                    AddToHashtable(node)
                End If

                If currentpath <> "" Then
                    currentpath &= "."
                End If

                currentpath &= leaf

                nodes = node.Nodes
            Next
        End If

        'Finally, add the member to the tree in the correct place.
        nodes.Add(member)
    End Sub

    Public Sub ImportAssembly()
        'Iterate through the assembly.
        Dim t As Type
        For Each t In m_Asm.GetTypes()
            If IsExportable(t) Then
                ImportType(t)
            End If
        Next
    End Sub

    Private Sub ImportType(ByVal t As Type)
        ' Import a type object and then iterate over each of its members.
        ' Because some special members are not supposed to be displayed in the
        ' tree (such as property acecssors), we need to defer adding them to
        ' the tree.  Once all members are imported from a type, we can
        ' determine which of these special members to add.  This process works
        ' by way of the Deferred Methods list where each special member is
        ' added to this list.  As we import Properties and Delegates, we add
        ' their associated methods to the list of Methods to Ignore.  Once
        ' the member import is complete, we add those special members which
        ' appear only in the Deferred Methods list.  This has the effect of
        ' filtering-out property accessors and delegate handlers so they don't
        ' appear in the Assembly tree (since they are not valid items to 
        ' add comments for).

        'Take care of the type first.
        Dim node As MemberNode = New MemberNode(t, Me)

        AddToTree(node)
        AddToHashtable(node)

        Dim member As MemberInfo

        Dim DeferredMethods As ArrayList = New ArrayList(4)
        Dim MethodsToIgnore As ArrayList = New ArrayList(4)

        'Now import each of its members.
        For Each member In t.GetMembers(MemberBindingFlags)
            If IsExportable(member) Then
                ImportMember(member, node.FriendlySignatureWithPath, DeferredMethods, MethodsToIgnore)
            End If
        Next

        'Process the deferred methods for this type.  If a deferred method also exists in the list of 
        'methods to ignore, then do nothing (to ignore it).  Otherwise, build a member node and add it to
        'the tree.
        Dim method As MethodInfo
        For Each method In DeferredMethods
            If Not MethodsToIgnore.Contains(method) Then
                Dim membernode As MemberNode = New MemberNode(method, node.FriendlySignatureWithPath, Me)
                AddToTree(membernode)
                AddToHashtable(membernode)
            End If
        Next

    End Sub

    Private Sub ImportMember(ByVal member As MemberInfo, ByVal parentName As String, ByVal DeferredMethods As ArrayList, ByVal MethodsToIgnore As ArrayList)
        ' Import a member.  Construct a new member node for each member and
        ' then add it to the tree (unless the member is special in which case
        ' we either ignore it or add it to the Deferred Methods list,
        ' depending on its kind).

        Dim m As MemberNode = Nothing

        Select Case member.MemberType
            Case MemberTypes.Constructor
                m = New MemberNode(CType(member, ConstructorInfo), parentName, Me)

            Case MemberTypes.Field
                'Skip the special "value__" fields for enums.
                If Not (member.DeclaringType.IsEnum AndAlso Not CType(member, FieldInfo).IsLiteral AndAlso member.Name = "value__") Then
                    m = New MemberNode(CType(member, FieldInfo), parentName, Me)
                End If

            Case MemberTypes.Method
                Dim method As MethodInfo = CType(member, MethodInfo)

                'Some special-named members (like property accessors and event hookups) will not 
                'be added to the tree, so we need to defer adding them to the tree until the entire 
                'type has been imported and we can determine which members not to add.
                If method.IsSpecialName Then
                    DeferredMethods.Add(method)
                Else
                    m = New MemberNode(method, parentName, Me)
                End If

            Case MemberTypes.Property
                Dim prop As PropertyInfo = CType(member, PropertyInfo)

                'Property accessor methods will not be added to the tree, so add these two accessors 
                'to the list of methods to remove.
                MethodsToIgnore.Add(prop.GetGetMethod(True))
                MethodsToIgnore.Add(prop.GetSetMethod(True))

                m = New MemberNode(prop, parentName, Me)

            Case MemberTypes.Event
                Dim e As EventInfo = CType(member, EventInfo)

                'Event hookup methods will not be added to the tree, so add these two hookups 
                'to the list of methods to remove.
                MethodsToIgnore.Add(e.GetAddMethod(True))
                MethodsToIgnore.Add(e.GetRemoveMethod(True))

                m = New MemberNode(e, parentName, Me)

            Case MemberTypes.NestedType
                'Nothing needs to be done here because this nested type will be imported separately (as a type, not a member).

            Case Else
                Debug.Fail("Unexpected member type: ", member.GetType.ToString)

        End Select

        'If we built a member node, add it to the Assembly tree and the hashtable.
        If Not m Is Nothing Then
            AddToTree(m)
            AddToHashtable(m)
        End If

    End Sub

    Public Sub ReportError(ByVal node As MemberNode, ByVal ErrorID As ErrorID, ByVal ParamArray Substitutions As String())
        m_ParentForm.ErrorWindow.ReportError(node, ErrorID, Substitutions)
        m_ParentForm.UpdateErrorStatus()
    End Sub

    Public Sub ReportError(ByVal node As MemberNode, ByVal descriptor As ContentDescriptor, ByVal ErrorID As ErrorID, ByVal ParamArray Substitutions As String())
        m_ParentForm.ErrorWindow.ReportError(node, descriptor, ErrorID, Substitutions)
        m_ParentForm.UpdateErrorStatus()
    End Sub

    Public Sub DeleteNodeFromErrorList(ByVal node As MemberNode)
        'No need to worry about errors in the descriptors because those errors are also sitting in 
        'the node's error list and will be removed.
        Debug.Assert(Not node.Errors Is Nothing, "Why try to delete a node which has no errors?")
        m_ParentForm.ErrorWindow.DeleteNodeFromErrorList(node)
        m_ParentForm.UpdateErrorStatus()
    End Sub

    Public Sub DeleteError(ByVal node As MemberNode, ByVal descriptor As ContentDescriptor, ByVal OldError As ErrorRecord)
        Debug.Assert(Not node.Errors Is Nothing, "Why try to delete a node which has no errors?")
        m_ParentForm.ErrorWindow.DeleteError(node, descriptor, OldError)
        m_ParentForm.UpdateErrorStatus()
    End Sub

    Public Sub AddToHashtable(ByVal member As MemberNode)
        'Add this member to the hashtable using its raw signature as the key.
        m_Members.Add(member.RawSignature, member)
    End Sub

End Class