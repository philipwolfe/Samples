Imports System
Imports System.IO
Imports System.Diagnostics
Imports System.Reflection
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization.Formatters.Soap
Imports System.Text
Imports System.Collections
Imports Microsoft.VisualBasic


    Public Class SimpleGraph
        Public Shared Sub Main()
            Console.WriteLine("Create object graph")
            Dim node As TreeNode = New TreeNode("")

            Console.WriteLine("before fill")
            FillTree(node)
            Console.WriteLine("after fill")


            node.PrintTree(Console.Out)
		
            Console.Write("Serializing object graph to disk..")
            Dim s As Stream = (New File("foo.xml")).Open(FileMode.Create)
            ' BinaryFormatter b = new BinaryFormatter();
            Dim b As SoapFormatter = New SoapFormatter
            b.Serialize(s, node)
            s.Close()
            Console.WriteLine("Complete.")
        
            Console.Write("Deserializing object graph from disk..")
            Dim r As Stream = (New File("foo.xml")).Open(FileMode.Open)
            ' BinaryFormatter c = new BinaryFormatter();
            Dim c As SoapFormatter = New SoapFormatter
		
            Dim n As TreeNode = CType(c.Deserialize(r), TreeNode)
            Console.WriteLine("Complete.")
            r.Close()
            n.PrintTree(Console.Out)
        
            Console.WriteLine()
            Console.WriteLine("Press Return to exit.")
            Console.Read()
        End Sub

        Public Shared Sub FillTree(ByVal node As TreeNode)
            Dim types() As Type = GetType(Object).Module.Assembly.GetTypes()
            node.AddChild(New TreeNode(GetType(Object).FullName))
        
            Dim o As Object
            For Each o In types
                Dim t As Type = CType(o, Type)
                If CObj (t.BaseType) = Nothing Then
                    Goto EndLoop
                End If
                If Not t.IsPublic Then
                    Goto EndLoop
                End If
                Dim n As TreeNode = node.Find(t.BaseType.FullName)
                If CObj (n) <> Nothing Then
                    n.AddChild(New TreeNode(t))
                End If
EndLoop:
            Next o
        End Sub
    End Class

    Public Class <serializable()> TreeNode
        Implements ISerializable

        Private m_value As Object
        Private children As ArrayList
 
        Overloads Private Sub new(ByVal info As SerializationInfo, ByVal c As StreamingContext)
            MyBase.new()
            m_value = info.GetValue("value", GetType(Object))
            children = New ArrayList
            Dim o As Object
        
            Dim i As Integer
            For i = 1 To info.MemberCount - 1
                o = info.GetValue(i.ToString(), GetType(Object))
                children.Add(o)
            Next i
        End Sub

        Overloads Public Sub new(ByVal val As Object)
            MyBase.new()
            If val Is Nothing Then
                Throw New Exception("val must not be null")
            End If
            m_value = val
            children = New ArrayList
        End Sub
	
        Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext) Implements ISerializable.GetObjectData
            If m_value = Nothing Then
                info.AddValue("value", "NULL")
            Else
                info.AddValue("value", value.ToString() + "(SAVED)")
            End If
            Dim i As Integer = 1
            Dim o As Object
            For Each o In children
                If o = Nothing Then
                    Goto LoopEnd
                End If
                info.AddValue(i.ToString(), o)
                i += 1
LoopEnd:
            Next o
        End Sub

        Public ReadOnly Property Value() As Object
            Get
                Return m_value
            End Get
        End Property

        Public Sub AddChild(ByVal child As TreeNode)
            If Not children.Contains(child) Then
                children.Add(child)
            End If
        End Sub
 
        Public Function Find(ByVal val As Object) As TreeNode
            If val = Nothing Then
                Throw New Exception("val must not be null")
            End If
            If m_value.Equals(val) Then
                Return Me
            End If
            Dim t As TreeNode
            For Each t In children
                Dim w As TreeNode = t.Find(val)
                If CObj(w) <> Nothing Then
                    Return w
                End If
            Next t
            Return Nothing
        End Function

        Overrides Public Function Equals(ByVal obj As Object) As Boolean
            If Not (TypeOf (obj) Is TreeNode) Then
                Return False
            End If
            Dim t As TreeNode = CType(obj, TreeNode)
            Return t.value.Equals(Me.value)
        End Function

        Overrides Public Function ToString() As String
            Return m_value.ToString()
        End Function
    
        Overloads Public Sub PrintTree(ByVal output As TextWriter)
            PrintTree(output, 0)
        End Sub
    
        Overloads Private Sub PrintTree(ByVal output As TextWriter, ByVal offset As Integer)
            Dim sb1 As StringBuilder = New StringBuilder
            Dim sb2 As StringBuilder = New StringBuilder
            Dim i As Integer
            For i = 0 To offset - 2
                sb1.Append(" ")
                sb1.Append("|")
                sb2.Append(" ")
                sb2.Append("|")
            Next i
            If offset >= 1 Then
                sb1.Append(" ")
                sb1.Append("+-")
                sb2.Append(" ")
                sb2.Append("|")
            End If
            output.WriteLine("{0}", sb2)
            output.WriteLine("{0}{1}", sb1, value)
            Dim t As TreeNode
            For Each t In children
                t.PrintTree(output, offset + 1)
            Next t
        End Sub

    End Class

