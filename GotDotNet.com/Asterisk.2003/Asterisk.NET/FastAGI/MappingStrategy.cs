using System;
using System.Collections;
using System.Resources;
using System.Reflection;

namespace Asterisk.NET.FastAGI
{
	/// <summary>
	/// A MappingStrategy that is configured via a resource bundle.<br/>
	/// The resource bundle contains the script part of the url as key and the fully
	/// qualified class name of the corresponding AGIScript as value.<br/>
	/// Example:
	/// <pre>
	/// noopcommand = Asterisk.NET.FastAGI.Command.NoopCommand
	/// </pre>
	/// NoopCommand must implement the AGIScript interface and have a default constructor with no parameters.<br/>
	/// </summary>
	public class MappingStrategy
	{
		private const string DEFAULT_RESOURCE_BUNDLE_NAME = "fastagi-mapping.resources";

		private Util.ILog logger;
		private string resourceName;
		private IDictionary mapping;

		virtual public string ResourceBundleName
		{
			set
			{
				this.resourceName = value;
			}
			
		}

		public MappingStrategy()
		{
			logger = Util.LogFactory.getLog(GetType());
			this.resourceName = DEFAULT_RESOURCE_BUNDLE_NAME;
			this.mapping = null;
		}
		
		private void  loadResourceBundle()
		{
			string scriptName;
			string className;
			IAGIScript agiScript;

			if(mapping == null)
				mapping = new Hashtable();
			try
			{
				ResourceReader rr = new ResourceReader(resourceName);
				foreach (DictionaryEntry de in rr)
				{
					scriptName = (string)de.Key;
					className = (string)de.Value;
					agiScript = createAGIScriptInstance(className);
					if (agiScript == null)
					{
						continue;
					}
					mapping[scriptName] = agiScript;
				}
			}
			catch (Exception e)
			{
				logger.error("ResourceReader " + resourceName + " error.", e);
				throw e;
			}
		}
		
		private IAGIScript createAGIScriptInstance(string className)
		{
			Type agiScriptClass;
			ConstructorInfo constructor;
			IAGIScript agiScript;
			
			try
			{
				agiScriptClass = Type.GetType(className);
				constructor = agiScriptClass.GetConstructor(new Type[]{});
				agiScript = (IAGIScript) constructor.Invoke(new object[]{});
			}
			catch(Exception e)
			{
				logger.error("Unable to create AGIScript instance of type " + className, e);
				return null;
			}
			return agiScript;
		}
		
		public virtual IAGIScript DetermineScript(AGIRequest request)
		{
			if (mapping == null)
				loadResourceBundle();
			return (IAGIScript) mapping[request.Script()];
		}
	}
}