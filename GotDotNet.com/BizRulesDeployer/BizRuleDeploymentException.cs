using System;

namespace BizRulesDeployer
{
	/// <summary>
	/// Custom exception for errors in the Business Rules
	/// </summary>
	internal class BizRuleDeploymentException : Exception
	{
		public BizRuleDeploymentException()
		{}

		public BizRuleDeploymentException(string message) : base(message)
		{}

		public BizRuleDeploymentException(string message, Exception innerException) : base(message, innerException)
		{}
	}
}
