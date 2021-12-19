'  This sample demonstrats how to use the code DOM to generate a strongly typed collection
 ' compile with vbc \t:exe ListBuilder.vb \r:System.dll
 '

Option Strict Off
Imports System
Imports System.Collections
Imports System.CodeDOM
Imports System.CodeDOM.Compiler
Imports System.IO
Imports System.Reflection

 
 Public Class ListBuilder 
 
    Private Shared  usage As String = "ListBuilder <TypeName> -L: <Lang> -N: <Namespace>"
    Public Shared Sub Main()
      Dim args As String ()
      args = Environment.GetCommandLineArgs()
      if (args.Length <= 1)
         Console.WriteLine (usage)
         return
      End If
      
      dim typeName As String 
      typeName = args(1)
      dim ns As string 
      dim suffix As string 
      suffix = "cs"
      dim compileLine As String 
      compileLine = "csc /library {0} /r:System.dll"
      
      Dim cg As ICodeGenerator 
      cg = new CSharpCodeGenerator ()
      
      Dim I as Integer
      For i = 1 to args.Length -1
         If (args(i) = "-L:" And (i+1) < args.Length) 
            If (args(i+1).ToUpper() = "CSHARP")
               cg = new CSharpCodeGenerator ()
               suffix = "cs"
               compileLine = "csc /dll {0} /i:System.dll"
            Else
               If (args(i+1).ToUpper() = "VB")
                 cg = new VBCodeGenerator ()
                 suffix = "vb"
                 compileLine = Nothing
               Else
                  If (args(i+1).ToUpper() = "JSCRIPT")
                    cg = new JSCodeGenerator () 
                    suffix = "jscript"
                    compileLine = Nothing
                  Else
                     Console.WriteLine ("unknown lang |{0}|", args(i+1))
                     Console.WriteLine ("Use: CSharp, VB or JScript")
                     Console.WriteLine (usage)
                  End If 'Jscript
               End If 'VB
            End If ' CSharp
            i = i + 1
         End If '-L
         If (args(i) = "-N:" And (i+1) < args.Length)
            ns = args(i+1)
            i = i + 1
         End If  '-N
      Next
      
      dim fileName As string 
      fileName = typeName+"Collection."+suffix
      Console.WriteLine ("Creating source file {0}.", fileName)
      If (compileLine <> Nothing)
        Console.WriteLine ("compile with: '{0}'.", [String].Format (compileLine, fileName))
      End If
      
      Dim t As TextWriter 
      t = new StreamWriter (new FileStream (fileName, FileMode.Create))
      SpitList (t, typeName, cg, ns)
      
      t.Close()
    End Sub 'Main
    
    Public Shared Sub SpitList (w As TextWriter, typeName As String, baseCompiler As ICodeGenerator, ns As String)
      
     
       Dim c As CodeCommentStatement 
       c = new CodeCommentStatement  ([String].Format ("List of {0}", typeName))
    Console.WriteLine ([String].Format ("List of {0}", typeName))
       baseCompiler.GenerateCodeFromStatement  (w, c)
       
       
       Dim cnamespace As CodeNamespace 
       cnamespace = new CodeNamespace("Microsoft.Com2Sdk.TypedCollections")
       cnamespace.Imports.Add (new CodeNamespaceImport ("System") )          
       cnamespace.Imports.Add (new CodeNamespaceImport ("System.Collections") )
       cnamespace.Imports.Add (new CodeNamespaceImport ("System.Collections.Bases") )
   
       
      if ns <> nothing And  ns <> "" Then
          cnamespace.Imports.Add (new CodeNamespaceImport (ns) )
       End If
      
      Dim co As CodeClass 
      co = new CodeClass (typeName +"List")

   
      cnamespace.Classes.Add (co)
      co.BaseTypes.Add ("TypedCollectionBase")
      co.Attributes  = TypeAttributes.Public
          
      
      'Gen: public <TYPE> this[int index] {
      '      get {
      '         return ((<TYPE>)List[index])
      '      }
      '      set {
      '          List[index] = value
      '      }
      '  }
     
      Dim cp As CodeMemberProperty  
      cp = new CodeMemberProperty ()
      cp.Name = "this"
      cp.Attributes = MemberAttributes.Public BitOr MemberAttributes.Final 
      cp.Type = typeName
      cp.Parameters.Add (new CodeParameterDeclarationExpression ("System.Int32", "index"))
      cp.GetStatements.Add (new CodeMethodReturnStatement (new CodeCastExpression (typeName, new CodeIndexerExpression (new CodeTypeReferenceExpression ("List"), new CodeLiteralExpression ("index")))))
      cp.SetStatements.Add (new CodeAssignStatement (new CodeIndexerExpression (new CodeTypeReferenceExpression ("List"), new CodeLiteralExpression ("index")), new CodeLiteralExpression ("value")))
      co.Members.Add (cp)
      
   
      'Gen: public int Add(<TYPE> value) {
      '        return List.Add(value)
      '      }
      Dim cm As CodeMemberMethod 
      cm = new CodeMemberMethod ()
      cm.Name = "Add"
      cm.ReturnType = "System.Int32"
      cm.Parameters.Add (new CodeParameterDeclarationExpression (typeName, "value"))
      cm.Attributes = MemberAttributes.Public BitOr MemberAttributes.Final 
      cm.Statements.Add (new CodeMethodReturnStatement (new CodeMethodInvokeExpression (new CodeTypeReferenceExpression ("List"), "Add", new CodeExpression ()  {new CodeLiteralExpression  ("value")})))
      co.Members.Add (cm)
      
      'Gen: public void Insert(int index, <TYPE> value) 
      '         List.Insert(index, info)
      '     }
      cm = new CodeMemberMethod ()
      cm.Name = "Insert"
      cm.ReturnType = "System.Void"
	  cm.Parameters.Add (new CodeParameterDeclarationExpression ("System.Int32", "index"))
      cm.Parameters.Add (new CodeParameterDeclarationExpression (typeName, "value"))
      cm.Attributes = MemberAttributes.Public BitOr MemberAttributes.Final 
      cm.Statements.Add (new CodeMethodInvokeStatement (new CodeTypeReferenceExpression ("List"), "Insert", new CodeExpression () _
								{new CodeLiteralExpression  ("index"), new CodeLiteralExpression  ("value")}))
      co.Members.Add (cm)
   
   
      'Gen: public int IndexOf(<TYPE> value) {
      '        return List.IndexOf(value)
      '      }
      cm = new CodeMemberMethod ()
      cm.Name = "IndexOf"
      cm.ReturnType = "System.Int32"
      cm.Parameters.Add (new CodeParameterDeclarationExpression (typeName, "value"))
      cm.Attributes = MemberAttributes.Public BitOr MemberAttributes.Final 
      cm.Statements.Add (new CodeMethodReturnStatement (new CodeMethodInvokeExpression (new CodeTypeReferenceExpression ("List"), "IndexOf", new CodeExpression () _
								{new CodeLiteralExpression  ("value")})))
      co.Members.Add (cm)
   
	  'Gen: public bool Contains(<TYPE> value) {
      '        return List.Contains(value)
      '      }
      cm = new CodeMemberMethod ()
      cm.Name = "Contains"
      cm.ReturnType = "System.Boolean"
      cm.Parameters.Add (new CodeParameterDeclarationExpression (typeName, "value"))
      cm.Attributes = MemberAttributes.Public BitOr MemberAttributes.Final 
      cm.Statements.Add (new CodeMethodReturnStatement (new CodeMethodInvokeExpression (new CodeTypeReferenceExpression ("List"), "Contains", new CodeExpression () _
								{new CodeLiteralExpression  ("value")})))
      co.Members.Add (cm)
      
      'Gen: public void Remove(<TYPE> value) {
      '       List.Remove(value)
      '      }
      cm = new CodeMemberMethod ()
      cm.Name = "Remove"
      cm.ReturnType = "System.Void"
      cm.Parameters.Add (new CodeParameterDeclarationExpression (typeName, "value"))
      cm.Attributes = MemberAttributes.Public BitOr MemberAttributes.Final 
      cm.Statements.Add (new CodeMethodInvokeStatement (new CodeTypeReferenceExpression ("List"), "Remove", new CodeExpression () _
								{new CodeLiteralExpression  ("value")}))
      co.Members.Add (cm)
      
      'Gen: public void CopyTo(<Type>[] array, int index) {
      '         List.CopyTo(array, index)
      '     }
      cm = new CodeMemberMethod ()
      cm.Name = "CopyTo"
      cm.ReturnType = "System.Void"
	  cm.Parameters.Add (new CodeParameterDeclarationExpression (typeName+"[]", "array"))
      cm.Parameters.Add (new CodeParameterDeclarationExpression ("System.Int32", "index"))
      cm.Attributes = MemberAttributes.Public BitOr MemberAttributes.Final 
      cm.Statements.Add (new CodeMethodInvokeStatement (new CodeTypeReferenceExpression ("List"), "CopyTo", new CodeExpression () _
								{new CodeLiteralExpression  ("array"), new CodeLiteralExpression  ("index")}))
      co.Members.Add (cm)
      
      
      baseCompiler.GenerateCodeFromNamespace (w,cnamespace)
    
      
     
       
    End Sub

 End Class