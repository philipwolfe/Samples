using System;
using Microsoft.RuleEngine;
using System.Collections;

namespace BizRulesDeployer
{
	/// <summary>
	/// Class to manage deployment tasks for the Business Rules Engine
	/// </summary>
	public class BizRulesDeploymentUtil
	{

		private string m_server = string.Empty;
		private string m_database = string.Empty;

		/// <summary>
		/// Retrieves the Server and Database name for the Rules Engine deployment
		/// </summary>
		/// <returns>An arraylist with the values</returns>
		private ArrayList GetConnectionValues()
		{
			ArrayList list1 = new ArrayList();
			list1.Add(m_server);
			list1.Add(m_database);

			return list1;
		}

		/// <summary>
		/// Constructs a new BizRulesDeploymentUtil
		/// </summary>
		/// <param name="server">The Server that hosts the Rules Engine</param>
		/// <param name="database">The name of the Rules Engine Database</param>
		public BizRulesDeploymentUtil(string server, string database)
		{
			m_server = server;
			m_database = database;

			if(m_server.Length == 0)
			{
				m_server = (Configuration.DatabaseServer.Length > 0) ? Configuration.DatabaseServer : Environment.MachineName;
			}

			if(m_database.Length == 0)
			{
				m_database = Configuration.DatabaseName;
			}
		}

		/// <summary>
		/// Default constructor
		/// </summary>
		public BizRulesDeploymentUtil() : this(string.Empty, string.Empty)
		{}

		/// <summary>
		/// Import and Publish a Policy or Vocabulary into the Rule Engine Database
		/// </summary>
		/// <param name="fileName">The path to the file</param>
		public void ImportPolicyOrVocab(string fileName)
		{
			IRuleSetDeploymentDriver driver1 = GetRulesDeployer();
			driver1.ImportAndPublishFileRuleStore(fileName);
			Console.WriteLine("Policy/Vocab in {0} was successfully imported and published", fileName);
		}
		
		private IRuleSetDeploymentDriver GetRulesDeployer()
		{
			ArrayList list1 = GetConnectionValues();
			IRuleSetDeploymentDriver driver1 = (IRuleSetDeploymentDriver) Microsoft.RuleEngine.RemoteUpdateService.RemoteUpdateService.LocateObject(Configuration.DeploymentDriverClass, Configuration.DeploymentDriverDll, list1.ToArray());
			return driver1;
		}

		private RuleSetInfo FindMostRecentRuleSet(RuleSetInfoCollection rules, string policyName)
		{
			int MajorRevision = 0;
			int MinorRevision = 0;
			RuleSetInfo ruleToDeploy = null;


			//find the latest revision
			foreach(RuleSetInfo rule in rules)
			{
				//only find ones where the name matches
				if(string.Compare(rule.Name, policyName, true) != 0)
					continue;

				if(rule.MajorRevision > MajorRevision)
				{
					MajorRevision = rule.MajorRevision;
					MinorRevision = rule.MinorRevision;
					ruleToDeploy = rule;
				}
				else if(rule.MajorRevision == MajorRevision)
				{
					if(rule.MinorRevision >= MinorRevision)
					{
						MajorRevision = rule.MajorRevision;
						MinorRevision = rule.MinorRevision;
						ruleToDeploy = rule;
					}
				}
			}

			return ruleToDeploy;
		}


		private RuleSetInfo FindRuleSetByVersion(RuleSetInfoCollection rules, string policyName, int majorRevision, int minorRevision)
		{
			foreach(RuleSetInfo rule in rules)
			{
				if(string.Compare(rule.Name, policyName, true) == 0 && rule.MajorRevision == majorRevision && rule.MinorRevision == minorRevision)
				{
					return rule;
				}
			}

			return null;
		}

		/// <summary>
		/// Undeploys the most recent version of a Policy
		/// </summary>
		/// <param name="policyName">The policy name</param>
		public void UndeployPolicy(string policyName)
		{
			UndeployPolicy(policyName, false);
		}

		/// <summary>
		/// Undeploys a policy
		/// </summary>
		/// <param name="policyName">The name of the policy to undeploy</param>
		/// <param name="undeployAll">flag to indicate whether all revisions should be undeployed.  If false, only undeploys the most recent version</param>
		public void UndeployPolicy(string policyName, bool undeployAll)
		{
			IRuleSetDeploymentDriver driver = GetRulesDeployer();

			RuleSetInfoCollection rules = driver.GetDeployedRuleSets(policyName);

			if(rules == null || rules.Count == 0)
			{
				throw new BizRuleDeploymentException(string.Format("There were no deployed versions of the Policy {0} to undeploy", policyName));
			}

			if(undeployAll)
			{
				foreach(RuleSetInfo rule in rules)
				{
					//sanity check
					if(string.Compare(rule.Name, policyName, true) == 0)
					{
						UndeployPolicyInternal(driver, rule);
					}
				}
			}
			else
			{
				RuleSetInfo rule = FindMostRecentRuleSet(rules, policyName);
				UndeployPolicyInternal(driver, rule);
			}
          
		}

		/// <summary>
		/// Undeploys a specific version of a policy
		/// </summary>
		/// <param name="policyName">The policy name to undeploy</param>
		/// <param name="majorRevision">The Major Revision of the policy</param>
		/// <param name="minorRevision">The Minor Revision of the policy</param>
		public void UndeployPolicy(string policyName, int majorRevision, int minorRevision)
		{
			IRuleSetDeploymentDriver driver = GetRulesDeployer();

			RuleSetInfoCollection rules = driver.GetDeployedRuleSets(policyName);

			if(rules == null || rules.Count == 0)
			{
				throw new BizRuleDeploymentException(string.Format("There were no deployed versions of the Policy {0} to undeploy", policyName));
			}

			RuleSetInfo rule = FindRuleSetByVersion(rules, policyName, majorRevision, minorRevision);

			if(rule == null)
			{
				throw new BizRuleDeploymentException(string.Format("Version {0}.{1} of the policy {2} could not be found to undeploy.", majorRevision, minorRevision, policyName));
			}

			UndeployPolicyInternal(driver, rule);
		}


		private void UndeployPolicyInternal(IRuleSetDeploymentDriver driver, RuleSetInfo rule)
		{
			try
			{
				driver.Undeploy(rule);
				Console.WriteLine("The rule {0}, versions {1}.{2} has been successfully undeployed", rule.Name, rule.MajorRevision, rule.MinorRevision);
			}
			catch(RuleEngineDeploymentException ex)
			{
				Console.WriteLine("The rule {0}, version {1}.{2} could not be undeployed for the following reason : {3}", rule.Name, rule.MajorRevision, rule.MinorRevision, ex.Message);
			}
		}

		private void DeployPolicyInternal(IRuleSetDeploymentDriver driver, RuleSetInfo rule)
		{
			try
			{
				driver.Deploy(rule);
				Console.WriteLine("The rule {0}, versions {1}.{2} has been successfully deployed", rule.Name, rule.MajorRevision, rule.MinorRevision);
			}
			catch(RuleEngineDeploymentException ex)
			{
				Console.WriteLine("The rule {0}, version {1}.{2} could not be deployed for the following reason : {3}", rule.Name, rule.MajorRevision, rule.MinorRevision, ex.Message);
			}
		}

		/// <summary>
		/// Deploys a specific version of a published policy
		/// </summary>
		/// <param name="policyName">The Policy Name to deploy</param>
		/// <param name="majorRevision">The Major Revision to deploy</param>
		/// <param name="minorRevision">The Minor Revision to deploy</param>
		public void DeployPolicy(string policyName, int majorRevision, int minorRevision)
		{
			IRuleSetDeploymentDriver driver1 = GetRulesDeployer();
			RuleSetInfoCollection rules = driver1.GetPublishedUndeployedRuleSets();
			
			if(rules == null || rules.Count == 0)
			{
				throw new BizRuleDeploymentException("No Published, Undeployed policies could be found");
			}


			RuleSetInfo rule = FindRuleSetByVersion(rules, policyName, majorRevision, minorRevision);

			if(rule == null)
			{
				throw new BizRuleDeploymentException(string.Format("Version {0}.{1} of the policy {2} could not be found to deploy.", majorRevision, minorRevision, policyName));
			}

			DeployPolicyInternal(driver1, rule);

		}

		/// <summary>
		/// Deploys a published policy
		/// </summary>
		/// <param name="policyName">The Policy Name to deploy</param>
		/// <param name="deployAll">flag indicating whether all versions should be deployed.  If false, deploys the most recent version</param>
		public void DeployPolicy(string policyName, bool deployAll)
		{
			IRuleSetDeploymentDriver driver1 = GetRulesDeployer();
			RuleSetInfoCollection rules = driver1.GetPublishedUndeployedRuleSets();
			
			if(rules == null || rules.Count == 0)
			{
				throw new BizRuleDeploymentException("No Published, Undeployed policies could be found");
			}

			if(deployAll)
			{
				foreach(RuleSetInfo rule in rules)
				{
					if(string.Compare(rule.Name, policyName, true) == 0)
					{
						DeployPolicyInternal(driver1, rule);
					}
				}	
			}
			else
			{

				RuleSetInfo ruleToDeploy = FindMostRecentRuleSet(rules, policyName);

				if(ruleToDeploy == null)
				{
					throw new BizRuleDeploymentException(string.Format("Could not find a published, undeployed version of the {0} Policy.", policyName));
				}

				DeployPolicyInternal(driver1, ruleToDeploy);
			}
			
		}

		/// <summary>
		/// Deploys the latest version of a Policy
		/// </summary>
		/// <param name="policyName">The name of the policy to deploy</param>
		public void DeployPolicy(string policyName)
		{	
			DeployPolicy(policyName, false);
		}
	}
}
