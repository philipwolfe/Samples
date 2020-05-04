using System;
using Genghis;
using Microsoft.RuleEngine;

namespace BizRulesDeployer
{
	/// <summary>
	/// Entry Point for the Business Rules Deployer
	/// </summary>
	class BizRulesDeployerEntryPoint
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			DeployerCommandLine parser = new DeployerCommandLine();
			if(!parser.ParseAndContinue(args))
				return;

			try
			{
				BizRulesDeploymentUtil deployer = new BizRulesDeploymentUtil(parser.Server, parser.Database);

				string action = parser.Action.ToLower().Trim();
				switch(action)
				{
					case "import" :
						deployer.ImportPolicyOrVocab(parser.FileName);
						break;
					case "deploy" :
						if(parser.MajorRevision > 0)
						{
							deployer.DeployPolicy(parser.PolicyName, parser.MajorRevision, parser.MinorRevision);
						}
						else
						{
							deployer.DeployPolicy(parser.PolicyName, parser.AllVersions);
						}
						break;
					case "undeploy" :
						if(parser.MajorRevision > 0)
						{
							deployer.UndeployPolicy(parser.PolicyName, parser.MajorRevision, parser.MinorRevision);
						}
						else
						{	
							deployer.UndeployPolicy(parser.PolicyName, parser.AllVersions);
						}
						break;
				}
			}
			catch(BizRuleDeploymentException ex1)
			{
				Console.WriteLine("The Action {0} could not be performed for the following reason: {1}{2}", parser.Action, Environment.NewLine, ex1.Message);
			}
			catch(RuleEngineDeploymentVocabularyExistsException vocabExists)
			{
				Console.WriteLine("The {0} Vocabulary, Version {1}.{2} already exists.", vocabExists.VocabularyName, vocabExists.MajorVersion, vocabExists.MinorVersion);
			}
			catch(RuleEngineDeploymentRuleSetExistsException rulesetExists)
			{
				Console.WriteLine("The {0} RuleSet, Version {1}.{2} already exists.", rulesetExists.RuleSetName, rulesetExists.MajorVersion, rulesetExists.MinorVersion);
			}
			catch(Exception ex)
			{
				Console.WriteLine("An unexpected error occurred while processing the {0} Action.{1}{2}", parser.Action, Environment.NewLine, ex.ToString());
			}

			Console.WriteLine("Finished");
		}
	}
}


