using System;
using System.ComponentModel;

namespace XPathTester
{
	/// <summary>
	/// Summary description for userPreferences.
	/// </summary>
	public class userPreferences
	{
		private System.Drawing.Color _contextNodeColour; 
		private System.Drawing.Color _matchNodeColour;
		private const string CONTEXT_COLOUR_KEY = "Context";
		private const string MATCH_COLOUR_KEY = "Match";
		private const string INTERACTIVE_EVAL_KEY = "Interactive";
		private const string PREFERENCES_REGISTRY_PATH = "Software\\XpathTester";
		private bool _interactive;

		public userPreferences()
		{
			LoadSettings();
		}

		// save the preferences to the registry
		public void SaveSettings()
		{
			Microsoft.Win32.RegistryKey registryPreferences = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(PREFERENCES_REGISTRY_PATH, true);
			if (registryPreferences == null)
			{
				registryPreferences = CreatePreferencesKey();
			}
			try 
			{
				registryPreferences.SetValue(CONTEXT_COLOUR_KEY, System.Drawing.ColorTranslator.ToHtml(_contextNodeColour));
				registryPreferences.SetValue(MATCH_COLOUR_KEY, System.Drawing.ColorTranslator.ToHtml(_matchNodeColour));
				registryPreferences.SetValue(INTERACTIVE_EVAL_KEY, _interactive.ToString());
			}
			finally 
			{
				registryPreferences.Close();
			}
		}

		// load the settings from the registry
		private void LoadSettings()
		{
			Microsoft.Win32.RegistryKey registryPreferences = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(PREFERENCES_REGISTRY_PATH, false);
			try 
			{
				if (registryPreferences == null)
				{
					_contextNodeColour = System.Drawing.Color.Coral;
					_matchNodeColour = System.Drawing.Color.SeaGreen;
					_interactive = true;
				}
				else 
				{
					_contextNodeColour = System.Drawing.ColorTranslator.FromHtml(registryPreferences.GetValue(CONTEXT_COLOUR_KEY).ToString());
					_matchNodeColour = System.Drawing.ColorTranslator.FromHtml(registryPreferences.GetValue(MATCH_COLOUR_KEY).ToString());
					_interactive = System.Convert.ToBoolean(registryPreferences.GetValue(INTERACTIVE_EVAL_KEY));
				}
			}
			finally 
			{
				if (registryPreferences != null)
				{
					registryPreferences.Close();
				}
			}
		}

		// create the preferences registry key
		private Microsoft.Win32.RegistryKey CreatePreferencesKey()
		{
			Microsoft.Win32.RegistryKey softwareKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software", true);
			if (softwareKey != null)
			{
				return softwareKey.CreateSubKey("XpathTester");
			}
			else 
			{
				throw new System.Exception("Unable to open the registry to save the user preferences.");
			}
		}

		// property procedure for accessing the context node colour
		[Category("Preferences"), ReadOnly(false), Description("The tree-view background color for the expression context node.")]
		public System.Drawing.Color ContextNodeColor
		{
			get { return _contextNodeColour; }
			set { _contextNodeColour = value; }
		}

		// property procedure for accessing the match nodes colour
		[Category("Preferences"), ReadOnly(false), Description("The tree-view background color for nodes that match the expression.")]	
		public System.Drawing.Color MatchNodeColor
		{
			get { return _matchNodeColour; }
			set { _matchNodeColour = value; }
		}

		[Category("Preferences"), ReadOnly(false), Description("Should the expression be evaluated interactively? Choose 'False' for extremely large documents, or if you encounter performance problems evaluating expressions.")]
		// property procedure for accessing the interactive expression eval.
		public bool EvaluateExpressionsInteractively
		{
			get { return _interactive; }
			set { _interactive = value; }
		}
	}
}
