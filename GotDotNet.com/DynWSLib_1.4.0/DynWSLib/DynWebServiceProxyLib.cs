using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Web.Services.Description;
using System.Web.Services.Discovery;
using System.Web.Services.Protocols;
using Microsoft.CSharp;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Text;
using System.Net;
using System.Security.Cryptography;

// DynamicWebServiceProxy - This sample is provided as is!
// Please notice that this code is only a technology demo
// and should not be included unedited und untested into any serious project.
// -------------------------------------------------------------------------------------
// The usage of the library is shown in the WSLibTester project in the same download file.
//
// (C) Christian Weyer, 2002-2003. All rights reserved.

namespace eYesoft.Tools.WebServices
{
	public enum ProtocolEnum
	{
		HttpGet,
		HttpPost,
		HttpSoap
	}

	// For feedback/questions/comments: cw@eyesoft.de
	public class DynamicWebServiceProxy
	{
		private Assembly ass = null;
		private object proxyInstance = null;
		private string wsdl;
		private string wsdlSource;
		private string typeName;
		private string methodName;
		private string protocolName = "Soap";
		private ArrayList methodParams = new ArrayList();
		private string proxySource;
		private ServiceDescriptionImporter sdi;

		public DynamicWebServiceProxy()
		{
		}

		public DynamicWebServiceProxy(string wsdlLocation)
		{
			wsdl = wsdlLocation;
			BuildProxy();
		}
		
		public DynamicWebServiceProxy(string wsdlLocation, string inTypeName)
		{
			wsdl = wsdlLocation;
			typeName = inTypeName;
			BuildProxy();
		}

		public DynamicWebServiceProxy(string wsdlLocation, string inTypeName, string inMethodName)
		{
			wsdl = wsdlLocation;
			typeName = inTypeName;
			methodName = inMethodName;
			BuildProxy();
		}

		public DynamicWebServiceProxy(string wsdlLocation, string inTypeName, string inMethodName, params object[] inMethodParams)
		{
			wsdl = wsdlLocation;
			typeName = inTypeName;
			methodName = inMethodName;
			methodParams = null;
			methodParams = new ArrayList(inMethodParams);
			BuildProxy();
		}

	
		public void AddParameter(object param)
		{
			methodParams.Add(param);
		}

		public object InvokeCall()
		{
			try
			{
				MethodInfo mi = proxyInstance.GetType().GetMethod(methodName);
				object result = mi.Invoke(proxyInstance, (object[])methodParams.ToArray(typeof(object)));
			
				return result;
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
				return null;
			}
		}

		public string Url
		{
			get
			{
				PropertyInfo propInfo = proxyInstance.GetType().GetProperty("Url");
				object result = propInfo.GetValue(proxyInstance, null);
				
				return (string)result;
			}
			set
			{
				PropertyInfo propInfo = proxyInstance.GetType().GetProperty("Url");
				propInfo.SetValue(proxyInstance, value,
					BindingFlags.NonPublic | BindingFlags.Static |
					BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetField,
					null, null, null
					);
			}
		}


		// TODO: move the init process to an explicit method Init() ...
		public string WSDL
		{
			get
			{
				return wsdl;
			}
			set
			{
				wsdl = value;
				ResetInternalState();
				BuildProxy();
			}
		}

		public string TypeName
		{
			get
			{
				return typeName;
			}
			set
			{
				typeName = value;
			}
		}

		public string MethodName
		{
			get
			{
				return methodName;
			}
			set
			{
				methodName = value;
			}
		}

		public ProtocolEnum ProtocolName
		{
			get
			{
				switch(protocolName)
				{
					case "HttpGet":
						return ProtocolEnum.HttpGet;
					case "HttpPost":
						return ProtocolEnum.HttpPost;
					case "Soap":
						return ProtocolEnum.HttpSoap;
					default:
						return ProtocolEnum.HttpSoap;
				}
			}
			set
			{
				switch(value)
				{
					case ProtocolEnum.HttpGet:
						protocolName = "HttpGet";
						break;
					case ProtocolEnum.HttpPost:
						protocolName = "HttpPost";
						break;
					case ProtocolEnum.HttpSoap:
						protocolName = "Soap";
						break;
				}
			}
		}

		public void ClearCache(string WSDL)
		{
			// clear the cached assembly file for this WSDL
			try
			{
				string path = Path.GetTempPath();
				string newFilename = path + GetMd5Sum(WSDL) + "_eYesoft_tmp.dll";

				File.Delete(newFilename);
			}
			catch(Exception e)
			{
				e = e;
			}
		}


		private void GetWsdl(string source) 
		{
			// this could be a valid WSDL representation
			if(source.StartsWith("<?xml version") == true)
			{
				wsdlSource = source;
				return;	
			}
			// this is a URL to the WSDL
			else if(source.StartsWith("http://") == true)
			{
				wsdlSource = GetWsdlFromUri(source);
				return;
			}
							
			// try to get from local file system
			wsdlSource = GetWsdlFromFile(source);
			return;
		}
		
		private string GetWsdlFromUri(string uri)
		{
			WebRequest req = WebRequest.Create(uri);
			WebResponse result = req.GetResponse();
					
			Stream ReceiveStream = result.GetResponseStream();
			Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
			StreamReader sr = new StreamReader(ReceiveStream, encode);
					
			string wsdlSource = sr.ReadToEnd();
			sr.Close();
					
			return wsdlSource;
		}
		
		private string GetWsdlFromFile(string fileFullPathName)
		{
			FileInfo fi = new FileInfo(fileFullPathName);
					
			if(fi.Extension == "wsdl")
			{
				FileStream fs = new FileStream(fileFullPathName, FileMode.Open, FileAccess.Read);
				StreamReader sr = new StreamReader(fs);
							
				char[] buffer = new char[(int)fs.Length];
				sr.ReadBlock(buffer, 0, (int)fs.Length);
				sr.Close();
							
				return new string(buffer);
			}
				
			throw new Exception("This is not a WSDL file");
		}

		private Assembly BuildAssemblyFromWsdl(string strWsdl)
		{
			// Use an XmlTextReader to get the Web Service description
			StringReader  wsdlStringReader = new StringReader(strWsdl);
			XmlTextReader tr = new XmlTextReader(wsdlStringReader);
			ServiceDescription sd = ServiceDescription.Read(tr);
			tr.Close();

			// WSDL service description importer 
			CodeNamespace cns = new CodeNamespace("eYesoft.Tools.WebServices.DynamicProxy");
			sdi = new ServiceDescriptionImporter();
			//sdi.AddServiceDescription(sd, null, null);
			
			// check for optional imports in the root WSDL
			CheckForImports(wsdl);

			sdi.ProtocolName = protocolName;
			sdi.Import(cns, null);

			// change the base class
			CodeTypeDeclaration ctDecl = cns.Types[0];
			cns.Types.Remove(ctDecl);
			ctDecl.BaseTypes[0] = new CodeTypeReference("eYesoft.Tools.WebServices.SoapHttpClientProtocolEx");
			cns.Types.Add(ctDecl);

			// source code generation
			CSharpCodeProvider cscp = new CSharpCodeProvider();
			ICodeGenerator icg = cscp.CreateGenerator();
			StringBuilder srcStringBuilder = new StringBuilder();
			StringWriter sw = new StringWriter(srcStringBuilder);
			icg.GenerateCodeFromNamespace(cns, sw, null);
			proxySource = srcStringBuilder.ToString();
			sw.Close();

			// assembly compilation
			CompilerParameters cp = new CompilerParameters();
			cp.ReferencedAssemblies.Add("System.dll");
			cp.ReferencedAssemblies.Add("System.Xml.dll");
			cp.ReferencedAssemblies.Add("System.Web.Services.dll");
			cp.ReferencedAssemblies.Add("System.Data.dll");
			cp.ReferencedAssemblies.Add(System.Reflection.Assembly.
				GetExecutingAssembly().Location);
	
			cp.GenerateExecutable = false;
			cp.GenerateInMemory = false;
			cp.IncludeDebugInformation = false; 

			ICodeCompiler icc = cscp.CreateCompiler();
			CompilerResults cr = icc.CompileAssemblyFromSource(cp, proxySource);
			
			if(cr.Errors.Count > 0)
				throw new Exception(string.Format(@"Build failed: {0} errors", cr.Errors.Count));

			ass = cr.CompiledAssembly;
			
			//rename temporary assembly in order to cache it for later use
			RenameTempAssembly(cr.PathToAssembly);
			 
			// create proxy instance
			proxyInstance = CreateInstance(typeName);
			
			return ass;
		}
		
		private object CreateInstance(string objTypeName) 
		{
			// check whether the type is already created or not
			if (objTypeName == "" || objTypeName == null)
			{
				foreach (Type ty in ProxyAssembly.GetTypes())
				{
					if(ty.BaseType == typeof(eYesoft.Tools.WebServices.SoapHttpClientProtocolEx))
					{
						objTypeName = ty.Name;
						break;
					}
				}
			}
			Type t = ass.GetType("eYesoft.Tools.WebServices.DynamicProxy." + objTypeName);
			
			return Activator.CreateInstance(t);
		}
		
		private void RenameTempAssembly(string pathToAssembly)
		{			
			string path = Path.GetDirectoryName(pathToAssembly);
			string newFilename = path + @"\" + GetMd5Sum(wsdl) + "_eYesoft_tmp.dll";
			
			File.Copy(pathToAssembly, newFilename);
		}

		private void ResetInternalState()
		{
			typeName = "";
			methodName = "";
			protocolName = "Soap";
			methodParams.Clear();
			sdi = null;
		}

		private void BuildProxy()
		{
			// inject SOAP extensions in (client side) ASMX pipeline
			InjectExtension(typeof(SoapMessageAccessClientExtension));
			
			//check cache first
			if (!CheckCache())
			{
				GetWsdl(wsdl);
				BuildAssemblyFromWsdl(wsdlSource);
			}
		}

		private bool CheckCache()
		{
			string path = Path.GetTempPath() + GetMd5Sum(wsdl) + "_eYesoft_tmp.dll";

			if(File.Exists(path))
			{
				ass = Assembly.LoadFrom(path);
				// create proxy instance
				proxyInstance = CreateInstance(typeName);

				return true;
			}
			
			return false;
		}
		
		private void CheckForImports(string baseWSDLUrl)
		{
			DiscoveryClientProtocol dcp = new DiscoveryClientProtocol();
			dcp.DiscoverAny(baseWSDLUrl);
			dcp.ResolveAll();

			foreach (object osd in dcp.Documents.Values)
			{
				if (osd is ServiceDescription) sdi.AddServiceDescription((ServiceDescription)osd, null, null);;
				if (osd is XmlSchema) sdi.Schemas.Add((XmlSchema)osd);
			}
		}

		static void InjectExtension(Type extension)
		{
			Assembly assBase;
			Type webServiceConfig;
			object currentProp;
			PropertyInfo propInfo;
			object[] value;
			Type myType;
			object[] objArray;
			object myObj;
			FieldInfo myField;

			try
			{
				assBase = typeof(SoapExtensionAttribute).Assembly;
				webServiceConfig =
					assBase.GetType("System.Web.Services.Configuration.WebServicesConfiguration");

				if (webServiceConfig == null)
					throw new Exception("Error ...");

				currentProp = webServiceConfig.GetProperty("Current",
					BindingFlags.NonPublic | BindingFlags.Static |
					BindingFlags.Instance | BindingFlags.Public
					).GetValue(null, null);
				propInfo = webServiceConfig.GetProperty("SoapExtensionTypes",
					BindingFlags.NonPublic | BindingFlags.Static |
					BindingFlags.Instance | BindingFlags.Public
					);
				value = (object[])propInfo.GetValue(currentProp, null);
				myType = value.GetType().GetElementType();
				objArray = (object[])Array.CreateInstance(myType, (int)value.Length + 1);
				Array.Copy(value, objArray, (int)value.Length);

				myObj = Activator.CreateInstance(myType);
				myField = myType.GetField("Type",
					BindingFlags.NonPublic | BindingFlags.Static |
					BindingFlags.Instance | BindingFlags.Public
					);
				myField.SetValue(myObj, extension,
					BindingFlags.NonPublic | BindingFlags.Static |
					BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetField,
					null, null
					);
				objArray[(int)objArray.Length - 1] = myObj;
				propInfo.SetValue(currentProp, objArray,
					BindingFlags.NonPublic | BindingFlags.Static |
					BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty,
					null, null, null
					);
			}
			catch (Exception e)
			{
				e = e;
			}
		}

		private string GetMd5Sum(string str)
		{
			// First we need to convert the string into bytes, which
			// means using a text encoder
			Encoder enc = System.Text.Encoding.Unicode.GetEncoder();

			// Create a buffer large enough to hold the string
			byte[] unicodeText = new byte[str.Length * 2];
			enc.GetBytes(str.ToCharArray(), 0, str.Length, unicodeText, 0, true);

			// Now that we have a byte array we can ask the CSP to hash it
			MD5 md5 = new MD5CryptoServiceProvider();
			byte[] result = md5.ComputeHash(unicodeText);

			// Build the final string by converting each byte
			// into hex and appending it to a StringBuilder
			StringBuilder sb = new StringBuilder();
			for (int i=0;i<result.Length;i++)
			{
				sb.Append(result[i].ToString("X2"));
			}

			return sb.ToString();
		}

		public string SoapRequest
		{
			get
			{
				PropertyInfo propInfo = proxyInstance.GetType().GetProperty("SoapRequest");
				object result = propInfo.GetValue(proxyInstance, null);
				System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
				
				return enc.GetString((byte[])result);
			}
		}

		public string SoapResponse
		{
			get
			{
				PropertyInfo propInfo = proxyInstance.GetType().GetProperty("SoapResponse");
				object result = propInfo.GetValue(proxyInstance, null);
				System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
				
				return enc.GetString((byte[])result);
			}
		}

		public Assembly ProxyAssembly
		{
			get
			{
				return ass;
			}
		}

	}
}
