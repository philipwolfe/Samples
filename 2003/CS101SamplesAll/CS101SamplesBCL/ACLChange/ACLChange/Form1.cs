using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Security.Principal;
using System.Security.AccessControl;
using System.IO;

namespace ACLChange
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			this.openFileDialog1.FileName = "";

			this.FileSystemRightsSelection.DataSource = Enum.GetNames(typeof(FileSystemRights));

			this.AccessControlTypeSelection.DataSource = Enum.GetNames(typeof(AccessControlType));
		}

		private void BrowseFile_Click(object sender, EventArgs e)
		{
			if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				this.fileName.Text = this.openFileDialog1.FileName;
				_fileSecurity = File.GetAccessControl(this.fileName.Text);

				RefreshTreeView();
			}
		}

		private void AddRule_Click(object sender, EventArgs e)
		{
            if (_fileSecurity != null & this.UserName.Text.Length > 0)
            {
                if (AddToFileACE(this.UserName.Text,
                    (FileSystemRights)Enum.Parse(typeof(FileSystemRights), this.FileSystemRightsSelection.SelectedItem.ToString()),
                    (AccessControlType)Enum.Parse(typeof(AccessControlType), this.AccessControlTypeSelection.SelectedItem.ToString())
                    ))
                {
                    RefreshTreeView();

                    String sSummary = "\"" + this.UserName.Text + "\", " + this.FileSystemRightsSelection.SelectedItem.ToString() + ", " + this.AccessControlTypeSelection.SelectedItem.ToString();
                    MessageBox.Show("Rule added - " + sSummary, "ACL Sample", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
		}

		private void RemoveRule_Click(object sender, EventArgs e)
		{
			if (this.ACEDetails.Nodes.Count == 0)
				return;

			FileSystemAccessRule rule = this.ACEDetails.SelectedNode.Tag as FileSystemAccessRule;

			if (rule != null)
			{
				if (rule.IsInherited == false)
				{
                    // before we remove, get the current selection info to show after we delete it
                    String name = rule.IdentityReference.ToString();
                    String rights = rule.FileSystemRights.ToString();
                    String aclType = rule.AccessControlType.ToString();

					RemoveFromFileACE(rule);
					RefreshTreeView();

                    String sSummary = "\"" + name + "\", " + rights + ", " + aclType;
                    MessageBox.Show("Rule removed - " + sSummary, "ACL Sample", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
				else
				{
					MessageBox.Show("Can not remove a rule that is Inherited", "ACL Sample", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

			}
			else
			{
				// Not a rule
			}
		}

		private void RefreshTreeView()
		{
			this.ACEDetails.Nodes.Clear();

			_accessRules = new TreeNode();
			_accessRules.Text = "Access Rules";
			this.ACEDetails.Nodes.Add(_accessRules);

			_auditRules = new TreeNode();
			_auditRules.Text = "Audit Rules";
			this.ACEDetails.Nodes.Add(_auditRules);

			ShowFileAccessRules(this.fileName.Text);
			ShowFileAuditRules(this.fileName.Text);
		}

		private void ShowFileAccessRules(string fileName)
		{
			if (this.fileName.Text.Length > 0 & File.Exists(this.fileName.Text))
			{
				int counter = 1;
				
				foreach (FileSystemAccessRule rule in _fileSecurity.GetAccessRules(true, true, typeof(NTAccount)))
				{
					TreeNode ruleNode = new TreeNode();
					ruleNode.Text = "Rule " + counter.ToString();
					ruleNode.Tag = rule;

					TreeNode ruleDetailsNode = new TreeNode();
					ruleDetailsNode.Text = "Access Control Type: " + (rule.AccessControlType == AccessControlType.Allow ? "grant" : "deny");
					ruleNode.Nodes.Add(ruleDetailsNode);

					ruleDetailsNode = new TreeNode();
					ruleDetailsNode.Text = "File System Rights: " + rule.FileSystemRights.ToString();
					ruleNode.Nodes.Add(ruleDetailsNode);

					ruleDetailsNode = new TreeNode();
					ruleDetailsNode.Text = "Identity Ref: " + rule.IdentityReference.ToString();
					ruleNode.Nodes.Add(ruleDetailsNode);

					ruleDetailsNode = new TreeNode();
					ruleDetailsNode.Text = "Source: " + (rule.IsInherited == true ? "inherited" : "direct");
					ruleNode.Nodes.Add(ruleDetailsNode);

					this._accessRules.Nodes.Add(ruleNode);

					counter++;
				}
			}
		}

		private void ShowFileAuditRules(string fileName)
		{
			if (this.fileName.Text.Length > 0 & File.Exists(this.fileName.Text))
			{
				int counter = 1;
				
				foreach (FileSystemAuditRule rule in _fileSecurity.GetAuditRules(true, true, typeof(NTAccount)))
				{
					TreeNode ruleNode = new TreeNode();
					ruleNode.Text = "Rule " + counter.ToString();
					ruleNode.Tag = rule;


					TreeNode ruleDetailsNode = new TreeNode();
					ruleDetailsNode.Text = "Access Control Type: " + rule.AuditFlags.ToString();
					ruleNode.Nodes.Add(ruleDetailsNode);

					ruleDetailsNode = new TreeNode();
					ruleDetailsNode.Text = "File System Rights: " + rule.FileSystemRights.ToString();
					ruleNode.Nodes.Add(ruleDetailsNode);

					ruleDetailsNode = new TreeNode();
					ruleDetailsNode.Text = "Identity Ref: " + rule.IdentityReference.ToString();
					ruleNode.Nodes.Add(ruleDetailsNode);

					ruleDetailsNode = new TreeNode();
					ruleDetailsNode.Text = "Source: " + (rule.IsInherited == true ? "inherited" : "direct");
					ruleNode.Nodes.Add(ruleDetailsNode);

					this._auditRules.Nodes.Add(ruleNode);

					counter++;
				}
			}
		}

		private bool AddToFileACE(string userName, FileSystemRights rights, AccessControlType accessControl)
		{
            bool bAdded = false;
            try
            {
                FileSystemAccessRule ace = new FileSystemAccessRule(new NTAccount(userName), rights, accessControl);
                _fileSecurity.AddAccessRule(ace);
                bAdded = true;
            }
            catch (System.Security.Principal.IdentityNotMappedException)
            {
                MessageBox.Show("Failed to add rule - does username exist?", "ACL Sample", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bAdded;
		}

		private bool RemoveFromFileACE(FileSystemAccessRule rule)
		{
			return _fileSecurity.RemoveAccessRule(rule);
		}


		private FileSecurity _fileSecurity;
		private TreeNode _accessRules;
		private TreeNode _auditRules;
	}
}