using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Net.NetworkInformation;

namespace NetworkSample
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			// get a list of all network interfaces on this computer
			if (NetworkInterface.GetIsNetworkAvailable())
			{
				_interfaces = NetworkInterface.GetAllNetworkInterfaces();
			}

			this.toolTip1.IsBalloon = true;
			this.toolTip1.ToolTipIcon = ToolTipIcon.Info;

			LoadTreeView(_interfaces);

			_ping = new Ping();
			// Register with the event for the Asynch ping
			_ping.PingCompleted += new PingCompletedEventHandler(ping_PingCompleted);

			// register with the NetworkChange events
			NetworkChange.NetworkAddressChanged += new NetworkAddressChangedEventHandler(NetworkChange_NetworkAddressChanged);
			NetworkChange.NetworkAvailabilityChanged += new NetworkAvailabilityChangedEventHandler(NetworkChange_NetworkAvailabilityChanged);
		}

		private void LoadTreeView(NetworkInterface[] interfaces)
		{
			// Load the details about each network interface into the treeview
			this.infoTree.BeginUpdate();

			TreeNode rootNode = new TreeNode();
			rootNode.Text = "Network Interfaces";

			if (interfaces.GetLength(0) > 0)
			{
				foreach (NetworkInterface networkInterface in interfaces)
				{
					PhysicalAddress address = networkInterface.GetPhysicalAddress();

					byte[] bytes = address.GetAddressBytes();

					TreeNode networkInterfaceNode = new TreeNode();

					networkInterfaceNode.Text = networkInterface.Name;
					networkInterfaceNode.Tag = networkInterface;

					TreeNode networkInterfaceDetailNode = new TreeNode();
					networkInterfaceDetailNode.Text = "MAC Address: " + (address.ToString() == String.Empty ? "None" : address.ToString());
					networkInterfaceNode.Nodes.Add(networkInterfaceDetailNode);

					networkInterfaceDetailNode = new TreeNode();
					networkInterfaceDetailNode.Text = "Id: " + networkInterface.Id.ToString();
					networkInterfaceNode.Nodes.Add(networkInterfaceDetailNode);

					networkInterfaceDetailNode = new TreeNode();
					networkInterfaceDetailNode.Text = "Type: " + networkInterface.NetworkInterfaceType.ToString();
					networkInterfaceNode.Nodes.Add(networkInterfaceDetailNode);

					networkInterfaceDetailNode = new TreeNode();
					networkInterfaceDetailNode.Text = "Operational Status: " + networkInterface.OperationalStatus.ToString();
					networkInterfaceNode.Nodes.Add(networkInterfaceDetailNode);

					networkInterfaceDetailNode = new TreeNode();
					networkInterfaceDetailNode.Text = "Speed: " + networkInterface.Speed.ToString("N") + " bytes";
					networkInterfaceNode.Nodes.Add(networkInterfaceDetailNode);

					networkInterfaceDetailNode = new TreeNode();
					networkInterfaceDetailNode.Text = "Receive Only: " + networkInterface.IsReceiveOnly.ToString();
					networkInterfaceNode.Nodes.Add(networkInterfaceDetailNode);

					networkInterfaceDetailNode = new TreeNode();
					networkInterfaceDetailNode.Text = "Support Multicast: " + networkInterface.SupportsMulticast.ToString();
					networkInterfaceNode.Nodes.Add(networkInterfaceDetailNode);

					networkInterfaceDetailNode = new TreeNode();
					networkInterfaceDetailNode.Text = "Support IPv4: " + networkInterface.Supports(NetworkInterfaceComponent.IPv4).ToString();
					networkInterfaceNode.Nodes.Add(networkInterfaceDetailNode);

					networkInterfaceDetailNode = new TreeNode();
					networkInterfaceDetailNode.Text = "Support IPv6: " + networkInterface.Supports(NetworkInterfaceComponent.IPv6).ToString();
					networkInterfaceNode.Nodes.Add(networkInterfaceDetailNode);


					rootNode.Nodes.Add(networkInterfaceNode);
				}
			}

			this.infoTree.Nodes.Add(rootNode);

			rootNode.Expand();

			this.infoTree.EndUpdate();
		}

		private void infoTree_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
		{
			// Show the network interface description as a tooltip when hovering
			// over a network interface node
			NetworkInterface networkInterface = e.Node.Tag as NetworkInterface;

			if (networkInterface != null)
			{
				e.Node.ToolTipText = networkInterface.Description;
			}
		}

		private void infoTree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			// if the selected node is a network interface enable the Show Interface Details button
			NetworkInterface networkInterface = e.Node.Tag as NetworkInterface;

			if (networkInterface != null)
			{
				ShowInterfaceDetails.Enabled = true;
				_currentInterface = networkInterface;
			}
			else
			{
				ShowInterfaceDetails.Enabled = false;
				_currentInterface = null;
			}
		}

		private void ShowInterfaceDetails_Click(object sender, EventArgs e)
		{
			// Show the detail subform
			DetailTree detailTree = new DetailTree();
			detailTree.LoadIPv4InterfaceStats(_currentInterface.GetIPv4Statistics());
			detailTree.LoadIPProperties(_currentInterface.GetIPProperties());
			detailTree.ShowDialog();
		}

		# region Ping

		private void DoPing_Click(object sender, EventArgs e)
		{
			// ping the IP address provided.
			// This call blocks until the ping is successful or 
			// the timeout expires
			if (this.pingIPAddress.Text.Length > 0)
			{
                this.DoPing.Enabled = this.doPingAsynch.Enabled = false;
                
                try
				{
					PingReply reply = _ping.Send(this.pingIPAddress.Text);

					// Show the ping results
					ShowPingResultInfo ( reply );
				}
				catch (PingException ex)
				{
					MessageBox.Show("The following error occured:\n\r" + ex.Message, "Network Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
                this.DoPing.Enabled = this.doPingAsynch.Enabled = true;
            }
			else
			{
				MessageBox.Show("You must enter an address to ping first", "Network Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void doPingAsynch_Click(object sender, EventArgs e)
		{
			// Do an asynch ping. The results are displayed after the
			// delegate invokes the ping_PingCompleted method
			if (this.pingIPAddress.Text.Length > 0)
			{
                // disable both buttons while async ping is operational
                this.DoPing.Enabled = this.doPingAsynch.Enabled = false;
                try
				{
					_ping.SendAsync(this.pingIPAddress.Text,this);
				}
				catch (PingException ex)
				{
					MessageBox.Show("The following error occured:\n\r" + ex.Message, "Network Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show("You must enter an address to ping first", "Network Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			System.Threading.Thread.Sleep(1000);
		}

		private void ShowPingResultInfo(PingReply reply)
		{
			// Show the details of the PingReply
			if (reply.Status == IPStatus.Success)
			{
				StringBuilder builder = new StringBuilder();

				builder.Append("You pinged: \t\t");
				builder.AppendLine(reply.Address.ToString());
				builder.AppendLine();
				builder.Append("The status returned was: \t");
				builder.AppendLine(reply.Status.ToString());
				builder.AppendLine();
				builder.Append("The roundtrip time was: \t");
				builder.AppendLine(reply.RoundtripTime.ToString("N"));
				builder.AppendLine();

				if (reply.Buffer != null)
				{
					builder.Append("The reply message was: \t");
					//builder.AppendLine(reply.Buffer.ToString());

					builder.AppendLine(ConvertByteBufferToString(reply.Buffer));
					builder.AppendLine();
				}

				PingOptions options = reply.Options;

				builder.Append("Ttl: \t\t\t");
				builder.AppendLine(options.Ttl.ToString());
				builder.AppendLine();

				builder.Append("Dont Fragment: \t\t");
				builder.AppendLine(options.DontFragment.ToString());
				builder.AppendLine();

				MessageBox.Show(builder.ToString(), "Ping Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			MessageBox.Show("Ping was not Successfull.\n\rStatus Code: " + reply.Status.ToString(), "Ping Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		void ping_PingCompleted(object sender, PingCompletedEventArgs e)
		{
            // re-enable the two Ping buttons
            this.DoPing.Enabled = this.doPingAsynch.Enabled = true;

            // Called by the PingCompletedEventHandler
			if (e.Cancelled == true)
			{
				MessageBox.Show("The Async ping was cancelled", "Network Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (e.Error != null )
			{
				MessageBox.Show("The following error occured:\n\r" + e.Error.Message, "Network Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			ShowPingResultInfo(e.Reply);
		}

		# endregion

		void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
		{
			// this method is called by the NetworkAvailabilityChangedEventHandler delegate
			MessageBox.Show("The network avialability has changed.\r\nThe network is now " + (e.IsAvailable == true ? "on line" : "off line"), "Network Change Event", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		void NetworkChange_NetworkAddressChanged(object sender, EventArgs e)
		{
			// this method is called by the NetworkAddressChangedEventHandler delegate
			MessageBox.Show("The network address has changed.", "Network Change Event", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		private string ConvertByteBufferToString(byte[] inputBuffer)
		{
			return System.Text.Encoding.ASCII.GetString(inputBuffer, 0, inputBuffer.Length);
		}


		private NetworkInterface[] _interfaces;
		private NetworkInterface _currentInterface;
		private Ping _ping;
	}
}