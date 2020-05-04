using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Reflection;

using ASOGS.Reflection;
using ASOGS.Patterns;
using ASOGS.Serialization;

using MbUnit.Core.Framework;
using MbUnit.Framework;

namespace mbUnitTests
{
	[TestSuiteFixture]
	public class tExceptionSerializationOnTheFly
	{
		
		public delegate void TestDelegate(Type exceptionType);

#region Fields

		private UniversalClassFactory _ClassFactory;
		private Serializer _Serializer;

#endregion

#region Properties
    
		private Serializer Serializer {
			get {
				if (this._Serializer == null) 
				{
					this._Serializer = new Serializer();
				}
				return _Serializer;
			}
			set {
				_Serializer = value;
			}
		}
    
		private UniversalClassFactory ClassFactory {
			get {
				if (this._ClassFactory == null) 
				{
					this._ClassFactory = new UniversalClassFactory();
					this.ClassFactory.AddGenericDefinedValue("TestString");
					this.ClassFactory.AddGenericDefinedValue(1);
				}
				return _ClassFactory;
			}
			set {
				_ClassFactory = value;
			}
		}

#endregion

		[TestSuite]
		public TestSuite TestGenerator(){
			this.LoadAssemblies(); 
			TestSuite suite = new TestSuite("ExceptionSuite"); 
			foreach (Assembly Asm in AppDomain.CurrentDomain.GetAssemblies()) 
			{ 
				if (!(Asm.FullName.StartsWith("MbUnit"))) 
				{ 
					foreach (Type Tp in Asm.GetExportedTypes()) 
					{ 
						if (Tp.IsSubclassOf(typeof(Exception))) 
						{ 
							suite.Add(Tp.FullName, new TestDelegate(GenericTest), Tp); 
						} 
					} 
				} 
			} 
			return suite;
		}

		public void GenericTest(Type exceptionType){
			if (exceptionType == typeof(System.Data.SqlTypes.SqlTypeException)) 
			{ 
				Assert.Ignore("The type {0} does not implement ISerializable correctly.", exceptionType.FullName); 
			} 
			else if (exceptionType == typeof(System.Data.SqlTypes.SqlNullValueException)) 
			{ 
				Assert.Ignore("The type {0} does not implement ISerializable correctly.", exceptionType.FullName); 
			} 
			else if (exceptionType == typeof(System.Data.SqlTypes.SqlTruncateException)) 
			{ 
				Assert.Ignore("The type {0} does not implement ISerializable correctly.", exceptionType.FullName); 
			} 

			Exception ThrownException = null; 
			Stream Stream = null; 
			Exception Clone = null; 
			
			try 
			{ 
				throw ((Exception)(this.ClassFactory.CreateInstanceOf(exceptionType))); 
			} 
			catch (Exception ex) 
			{ 
				if (ex.GetType() == exceptionType) 
				{ 
					ThrownException = ex; 
				} 
				else 
				{ 
					Assert.Ignore(string.Format("Not able to create {0} {1}", exceptionType.FullName, ex.ToString())); 
				} 
			}

			try 
			{ 
				try 
				{ 
					Stream = this.Serializer.SerializeToStream(ThrownException); 
				} 
				catch (SerializationException SerEx) 
				{ 
					Assert.Fail(string.Format("Not able to serialize {0} {1}", exceptionType.FullName, SerEx.Message)); 
				} 
				catch (Exception OtherEx) 
				{ 
					if (!(OtherEx.InnerException is SerializationException)) 
					{ 
						Assert.Fail(string.Format("Problem with {0} {1}", exceptionType.FullName, OtherEx.ToString())); 
					} 
					else 
					{ 
						Assert.Fail(string.Format("Not able to serialize {0} {1}", exceptionType.FullName, OtherEx.ToString())); 
					} 
				} 
				try 
				{ 
					Clone = ((Exception)(this.Serializer.DeserializeToObject(Stream))); 
				} 
				catch (SerializationException SerEx) 
				{ 
					Assert.Fail(string.Format("Not able to deserialize {0} {1}", exceptionType.FullName, SerEx.Message)); 
				} 
				catch (Exception OtherEx) 
				{ 
					if (!(OtherEx.InnerException is SerializationException)) 
					{ 
						Assert.Fail(string.Format("Problem with {0} {1}", exceptionType.FullName, OtherEx.ToString())); 
					} 
					else 
					{ 
						Assert.Fail(string.Format("Not able to deserialize {0} {1}", exceptionType.FullName, OtherEx.ToString())); 
					} 
				} 
			} 
			finally 
			{ 
				if (Clone != null) 
				{ 
					Assert.AreEqual(ThrownException.StackTrace, Clone.StackTrace); 
				} 
				if (Stream != null) 
				{ 
					Stream.Close(); 
				} 
			}
		}

		private void LoadAssemblies()
		{
			AssemblyInformationList assemblies = null;
			XmlSerializer Serializer = new XmlSerializer(typeof(AssemblyInformationList));
			FileStream Stream = null;

			try
			{
				Stream = new FileStream("../../ExceptionAssemblies.xml", FileMode.Open, FileAccess.Read);
				assemblies = (AssemblyInformationList) Serializer.Deserialize(Stream);
			}
			finally{
				if (Stream != null) {
					Stream.Close();
				}
			}
			
			
			foreach (AssemblyInformation asm in assemblies)
			{
				Assembly.Load(asm.ToString());

			}
			
		}

	}
}
