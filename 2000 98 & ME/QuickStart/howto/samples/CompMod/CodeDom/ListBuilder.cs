/*  This sample demonstrats how to use the code DOM to generate a strongly typed collection
 * compile with csc ListBuilder.cs \r:System.dll
 */

using System;
using System.CodeDOM;
using System.CodeDOM.Compiler;
using System.IO;
using System.Reflection;

 
 public class ListBuilder 
 {
    private static String usage = "ListBuilder <TypeName> -L: <Lang> -N: <Namespace>";
    public static void Main (String [] args)
    {
      if (args.Length < 1)
      {
         Console.WriteLine (usage);
         return;
      }
      string typeName = args[0];
      string ns = null;
      string suffix = "cs";
      string compileLine = "csc /library {0} /r:System.dll";
      
      ICodeGenerator cg = new CSharpCodeGenerator ();
      for (int i = 1; i < args.Length; i++)
      {
         if (args[i] == "-L:" && (i + 1) < args.Length) 
         {
            if (args[i+1].ToUpper() == "CSHARP")
            {
               cg = new CSharpCodeGenerator ();
               suffix = "cs";
               compileLine = "csc /dll {0} /i:System.dll";
            }else
            if (args[i+1].ToUpper() == "VB")
            {
               cg = new VBCodeGenerator ();
               suffix = "vb";
               compileLine = null;
            }else
            if (args[i+1].ToUpper() == "JSCRIPT")
            {
               cg = new JSCodeGenerator (); 
               suffix = "jscript";
               compileLine = null;
            }else{
               Console.WriteLine ("unknown lang |{0}|", args[i+1]);
               Console.WriteLine ("Use: CSharp, VB or JScript");
               Console.WriteLine (usage);
                return;
            }
            i++;
         }
         if (args[i] == "-N:" && (i + 1) < args.Length)
         {
            ns = args[i+1];
            i++;
         }
      
      }
      string fileName = typeName+"Collection."+suffix;
      Console.WriteLine ("Creating source file {0}.", fileName);
      if (compileLine != null)
        Console.WriteLine ("compile with: '{0}'.", String.Format (compileLine, fileName));
      
      TextWriter t = new StreamWriter (new FileStream (fileName, FileMode.Create));
      SpitList (t, typeName, cg, ns);
      t.Close();
    }
    
    public  static void SpitList (TextWriter w, String typeName, ICodeGenerator  baseCompiler, String ns)
    {
      
       
       CodeCommentStatement c = new CodeCommentStatement  (String.Format ("List of {0}", typeName));
       baseCompiler.GenerateCodeFromStatement  (w, c);
       
       
       CodeNamespace cnamespace = new CodeNamespace("Microsoft.Com2Sdk.TypedCollections");
       cnamespace.Imports.Add (new CodeNamespaceImport ("System") );          
       cnamespace.Imports.Add (new CodeNamespaceImport ("System.Collections") );
       cnamespace.Imports.Add (new CodeNamespaceImport ("System.Collections.Bases") );
       if (ns != null &&  ns != "") cnamespace.Imports.Add (new CodeNamespaceImport (ns) );
      CodeClass co = new CodeClass (typeName +"List");
      cnamespace.Classes.Add (co);
      co.BaseTypes.Add ("TypedCollectionBase");
      co.Attributes  = TypeAttributes.Public;
          
      
      //Gen: public <TYPE> this[int index] {
      //      get {
      //         return ((<TYPE>)List[index]);
      //      }
      //      set {
      //          List[index] = value;
      //      }
      //  }
      CodeMemberProperty  cp = new CodeMemberProperty ();
      cp.Name = "this";
      cp.Attributes = MemberAttributes.Public | MemberAttributes.Final ;;
      cp.Type = typeName;
      cp.Parameters.Add (new CodeParameterDeclarationExpression ("System.Int32", "index"));
      cp.GetStatements.Add (new CodeMethodReturnStatement (new CodeCastExpression (typeName, new CodeIndexerExpression (new CodeTypeReferenceExpression ("List"), new CodeLiteralExpression ("index")))));
      cp.SetStatements.Add (new CodeAssignStatement (new CodeIndexerExpression (new CodeTypeReferenceExpression ("List"), new CodeLiteralExpression ("index")), new CodeLiteralExpression ("value")));
      co.Members.Add (cp);
      
      
      //Gen: public int Add(<TYPE> value) {
      //        return List.Add(value);
      //      }
      CodeMemberMethod cm = new CodeMemberMethod ();
      cm.Name = "Add";
      cm.ReturnType = "System.Int32";
      cm.Parameters.Add (new CodeParameterDeclarationExpression (typeName, "value"));
      cm.Attributes = MemberAttributes.Public | MemberAttributes.Final ;
      cm.Statements.Add (new CodeMethodReturnStatement (new CodeMethodInvokeExpression (new CodeTypeReferenceExpression ("List"), "Add", new CodeExpression [] 
								{new CodeLiteralExpression  ("value")})));
      co.Members.Add (cm);
      
      //Gen: public void Insert(int index, <TYPE> value) 
      //         List.Insert(index, info);
      //     }
      cm = new CodeMemberMethod ();
      cm.Name = "Insert";
      cm.ReturnType = "System.Void";
	  cm.Parameters.Add (new CodeParameterDeclarationExpression ("System.Int32", "index"));
      cm.Parameters.Add (new CodeParameterDeclarationExpression (typeName, "value"));
      cm.Attributes = MemberAttributes.Public | MemberAttributes.Final ;
      cm.Statements.Add (new CodeMethodInvokeStatement (new CodeTypeReferenceExpression ("List"), "Insert", new CodeExpression [] 
								{new CodeLiteralExpression  ("index"), new CodeLiteralExpression  ("value")}));
      co.Members.Add (cm);
   
   
      //Gen: public int IndexOf(<TYPE> value) {
      //        return List.IndexOf(value);
      //      }
      cm = new CodeMemberMethod ();
      cm.Name = "IndexOf";
      cm.ReturnType = "System.Int32";
      cm.Parameters.Add (new CodeParameterDeclarationExpression (typeName, "value"));
      cm.Attributes = MemberAttributes.Public | MemberAttributes.Final ;
      cm.Statements.Add (new CodeMethodReturnStatement (new CodeMethodInvokeExpression (new CodeTypeReferenceExpression ("List"), "IndexOf", new CodeExpression [] 
								{new CodeLiteralExpression  ("value")})));
      co.Members.Add (cm);
   
	  //Gen: public bool Contains(<TYPE> value) {
      //        return List.Contains(value);
      //      }
      cm = new CodeMemberMethod ();
      cm.Name = "Contains";
      cm.ReturnType = "System.Boolean";
      cm.Parameters.Add (new CodeParameterDeclarationExpression (typeName, "value"));
      cm.Attributes = MemberAttributes.Public | MemberAttributes.Final ;
      cm.Statements.Add (new CodeMethodReturnStatement (new CodeMethodInvokeExpression (new CodeTypeReferenceExpression ("List"), "Contains", new CodeExpression [] 
								{new CodeLiteralExpression  ("value")})));
      co.Members.Add (cm);
      
      //Gen: public void Remove(<TYPE> value) {
      //       List.Remove(value);
      //      }
      cm = new CodeMemberMethod ();
      cm.Name = "Remove";
      cm.ReturnType = "System.Void";
      cm.Parameters.Add (new CodeParameterDeclarationExpression (typeName, "value"));
      cm.Attributes = MemberAttributes.Public | MemberAttributes.Final ;
      cm.Statements.Add (new CodeMethodInvokeStatement (new CodeTypeReferenceExpression ("List"), "Remove", new CodeExpression [] 
								{new CodeLiteralExpression  ("value")}));
      co.Members.Add (cm);
      
      //Gen: public void CopyTo(<Type>[] array, int index) {
      //         List.CopyTo(array, index);
      //     }
      cm = new CodeMemberMethod ();
      cm.Name = "CopyTo";
      cm.ReturnType = "System.Void";
	  cm.Parameters.Add (new CodeParameterDeclarationExpression (typeName+"[]", "array"));
      cm.Parameters.Add (new CodeParameterDeclarationExpression ("System.Int32", "index"));
      cm.Attributes = MemberAttributes.Public | MemberAttributes.Final ;
      cm.Statements.Add (new CodeMethodInvokeStatement (new CodeTypeReferenceExpression ("List"), "CopyTo", new CodeExpression [] 
								{new CodeLiteralExpression  ("array"), new CodeLiteralExpression  ("index")}));
      co.Members.Add (cm);
      
      
      baseCompiler.GenerateCodeFromNamespace (w,cnamespace);
       
    }

 }  