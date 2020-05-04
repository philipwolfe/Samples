using System;
using Genghis;
using System.IO;

namespace BizRulesDeployer
{
	/// <summary>
	/// Command-Line parser for the Business Rules Deployer
	/// </summary>
	internal class DeployerCommandLine : CommandLineParser
	{
		public DeployerCommandLine() : base()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// Does custom parsing to validate Parameter dependencies
		/// </summary>
		/// <param name="args">The arguments</param>
		/// <param name="ignoreFirstArg">Whatever this means</param>
		protected override void Parse(string[] args, bool ignoreFirstArg)
		{
			base.Parse (args, ignoreFirstArg);
			ValidateParams();
		}


		#region Parms
		/// <summary>
		/// The action to be performed.  Either Deploy or Import
		/// </summary>
		[CommandLineParser.ValueUsage("The deployment action.  Valid parameters are: \nImport\nDeploy\nUndeploy", Name="a", IgnoreCase=true)]
		public string Action = string.Empty;

		
		[CommandLineParser.NoUsage()]
		private string m_fileName = string.Empty;

		/// <summary>
		/// The file name containing the Policy or Vocabulary Definition
		/// </summary>
		[CommandLineParser.ValueUsage("The File to Import", Name = "file", Optional=true)]
		public string FileName
		{
			get { return m_fileName; }
			set 
			{
				if( !(new FileInfo(value)).Exists )
				{
					throw new UsageException("FileName", value + " not found");
				}

				m_fileName = value;
			}
							
		}

		/// <summary>
		/// The Policy Name to deploy/undeploy
		/// </summary>
		[CommandLineParser.ValueUsage("The name of the Policy to Deploy/Undeploy. Only valid when Action is Deploy or Undeploy.", Name="policyName", IgnoreCase=true, Optional=true)]
		public string PolicyName = string.Empty;


		[CommandLineParser.NoUsage()]
		private string m_version = string.Empty;

		/// <summary>
		/// The version (Major.Minor) of the Policy to undeploy/Deploy
		/// </summary>
		[CommandLineParser.ValueUsage("The version of the policy to Deploy/Undeploy.  Should be formatted <MajorRevision>.<MinorRevision>", IgnoreCase=true, Optional=true)]
		private string PolicyVersion
		{
			get
			{
				return m_version;
			}
			set
			{
				try
				{
					m_version = value;
					if(m_version.Length == 0)
					{
						MajorRevision = 0;
						MinorRevision = 0;
					}
					else
					{

						string[] versions = m_version.Split('.');

						MajorRevision = Int32.Parse(versions[0]);
						MinorRevision = Int32.Parse(versions[1]);
					}
				}
				catch
				{
					throw new UsageException("Version", string.Format("Version {0} was invalid.  Version must be in the format <MajorRevision>.<MinorRevision>", value));
				}
			}
		}

		/// <summary>
		/// Flag indicating whether to undeploy/deploy all versions of a Policy
		/// </summary>
		[CommandLineParser.FlagUsage("Flag indicating whether to Deploy/Undeploy all versions of a policy", Optional=true)]
		public bool AllVersions = false;

		/// <summary>
		/// The database server that contains the rules engine db
		/// </summary>
		[CommandLineParser.ValueUsage("The Database Server that hosts the Rule Engine Database", Name="Server", IgnoreCase=true, Optional=true)]
		public string Server = string.Empty;

		/// <summary>
		/// The name of the Rule Engine DB
		/// </summary>
		[CommandLineParser.ValueUsage("The name of the Rule Engine Database on the server", Name="Db", IgnoreCase=true, Optional=true)]
		public string Database = string.Empty;

		#endregion

		/// <summary>
		/// The Major Revision of the Policy to Undeploy/Deploy
		/// </summary>
		[CommandLineParser.NoUsage()]
		public int MajorRevision = 0;
		
		/// <summary>
		/// The Minor Revision of the Policy to Undeploy/Deploy
		/// </summary>
		[CommandLineParser.NoUsage()]
		public int MinorRevision = 0;


		private bool StringEqual(string str1, string str2)
		{
			return string.Compare(str1, str2, true) == 0;
		}


		private void ValidateParams()
		{
			if(StringEqual(Action, "Import") && FileName.Length == 0)
				throw new UsageException("FileName", "FileName is required when the Action is Import");

			if(StringEqual(Action, "Deploy") && PolicyName.Length == 0)
				throw new UsageException("PolicyName", "PolicyName is required when the Action is Deploy");

			if(StringEqual(Action, "UnDeploy") && PolicyName.Length == 0)
				throw new UsageException("PolicyName", "PolicyName is required when the Action is UnDeploy");
		}

	}
}
