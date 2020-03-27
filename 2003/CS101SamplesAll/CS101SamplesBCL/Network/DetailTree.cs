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
	public partial class DetailTree : Form
	{
		public DetailTree()
		{
			InitializeComponent();

			_ipvStatsNode = new TreeNode("IPV4 Statistics");
			_ipPropsNode = new TreeNode("IP Properties");

			treeView1.Nodes.Add(_ipvStatsNode);
			treeView1.Nodes.Add(_ipPropsNode);
		}

		public void LoadIPv4InterfaceStats(IPv4InterfaceStatistics statistics)
		{
			this.treeView1.BeginUpdate();

			TreeNode detailsNode = new TreeNode();
			detailsNode.Text = "BytesReceived: " + statistics.BytesReceived.ToString("N0");
			_ipvStatsNode.Nodes.Add(detailsNode);

			detailsNode = new TreeNode();
			detailsNode.Text = "BytesSent: " + statistics.BytesSent.ToString("N0");
			_ipvStatsNode.Nodes.Add(detailsNode);

			detailsNode = new TreeNode();
			detailsNode.Text = "IncomingPacketsDiscarded: " + statistics.IncomingPacketsDiscarded.ToString("N0");
			_ipvStatsNode.Nodes.Add(detailsNode);

			detailsNode = new TreeNode();
			detailsNode.Text = "IncomingPacketsWithErrors: " + statistics.IncomingPacketsWithErrors.ToString("N0");
			_ipvStatsNode.Nodes.Add(detailsNode);

			detailsNode = new TreeNode();
			detailsNode.Text = "IncomingUnknownProtocolPackets: " + statistics.IncomingUnknownProtocolPackets.ToString("N0");
			_ipvStatsNode.Nodes.Add(detailsNode);

			detailsNode = new TreeNode();
			detailsNode.Text = "NonUnicastPacketsReceived: " + statistics.IncomingUnknownProtocolPackets.ToString("N0");
			_ipvStatsNode.Nodes.Add(detailsNode);

			detailsNode = new TreeNode();
			detailsNode.Text = "NonUnicastPacketsReceived: " + statistics.NonUnicastPacketsReceived.ToString("N0");
			_ipvStatsNode.Nodes.Add(detailsNode);

			detailsNode = new TreeNode();
			detailsNode.Text = "NonUnicastPacketsSent: " + statistics.NonUnicastPacketsSent.ToString("N0");
			_ipvStatsNode.Nodes.Add(detailsNode);

			detailsNode = new TreeNode();
			detailsNode.Text = "OutgoingPacketsDiscarded: " + statistics.OutgoingPacketsDiscarded.ToString("N0");
			_ipvStatsNode.Nodes.Add(detailsNode);

			detailsNode = new TreeNode();
			detailsNode.Text = "OutgoingPacketsWithErrors: " + statistics.OutgoingPacketsDiscarded.ToString("N0");
			_ipvStatsNode.Nodes.Add(detailsNode);

			detailsNode = new TreeNode();
			detailsNode.Text = "OutputQueueLength: " + statistics.OutputQueueLength.ToString("N0");
			_ipvStatsNode.Nodes.Add(detailsNode);

			detailsNode = new TreeNode();
			detailsNode.Text = "UnicastPacketsReceived: " + statistics.UnicastPacketsReceived.ToString("N0");
			_ipvStatsNode.Nodes.Add(detailsNode);

			detailsNode = new TreeNode();
			detailsNode.Text = "UnicastPacketsSent: " + statistics.UnicastPacketsSent.ToString("N0");
			_ipvStatsNode.Nodes.Add(detailsNode);

			this.treeView1.EndUpdate();
		}

		public void LoadIPProperties(IPInterfaceProperties properties)
		{
			this.treeView1.BeginUpdate();

			TreeNode detailsNode = new TreeNode();
			detailsNode.Text = "DnsSuffix: " + (properties.DnsSuffix == String.Empty ? "\tNone" : properties.DnsSuffix);
			_ipPropsNode.Nodes.Add(detailsNode);

			detailsNode = new TreeNode();
			detailsNode.Text = "IsDnsEnabled: " + properties.IsDnsEnabled.ToString();
			_ipPropsNode.Nodes.Add(detailsNode);


			detailsNode = new TreeNode();
			detailsNode.Text = "IsDynamicDnsEnabled: " + properties.IsDynamicDnsEnabled.ToString();
			_ipPropsNode.Nodes.Add(detailsNode);


			 detailsNode = new TreeNode();
			detailsNode.Text = "Anycast Addresses";
			_ipPropsNode.Nodes.Add(detailsNode);

			if (properties.AnycastAddresses.Count > 0)
			{
				foreach (IPAddressInformation info in properties.AnycastAddresses)
				{
					TreeNode addressNode = new TreeNode();
					addressNode.Text = "Address: " + info.Address.ToString();
					detailsNode.Nodes.Add(addressNode);

					TreeNode SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "IsDnsEligible: " + info.IsDnsEligible.ToString();
					addressNode.Nodes.Add(SubDetailsNode);

					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "IsTransient: " + info.IsTransient.ToString();
					addressNode.Nodes.Add(SubDetailsNode);
				}
			}

			detailsNode = new TreeNode();
			detailsNode.Text = "DhcpServer Addresses";
			_ipPropsNode.Nodes.Add(detailsNode);

			if (properties.DhcpServerAddresses.Count > 0)
			{
				foreach (IPAddress address in properties.DhcpServerAddresses)
				{
					TreeNode addressNode = new TreeNode();
					addressNode.Text = "Address: " + address.ToString();
					detailsNode.Nodes.Add(addressNode);

					TreeNode SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "AddressFamily: " + address.AddressFamily.ToString();
					addressNode.Nodes.Add(SubDetailsNode);

					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "IsIPv6LinkLocal: " + address.IsIPv6LinkLocal.ToString();
					addressNode.Nodes.Add(SubDetailsNode);

					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "IsIPv6Multicast: " + address.IsIPv6Multicast.ToString();
					addressNode.Nodes.Add(SubDetailsNode);

					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "IsIPv6SiteLocal: " + address.IsIPv6SiteLocal.ToString();
					addressNode.Nodes.Add(SubDetailsNode);
				}
			}


			detailsNode = new TreeNode();
			detailsNode.Text = "Dns Addresses";
			_ipPropsNode.Nodes.Add(detailsNode);

			if (properties.DnsAddresses.Count > 0)
			{
				foreach (IPAddress address in properties.DnsAddresses)
				{
					TreeNode addressNode = new TreeNode();
					addressNode.Text = "Address: " + address.ToString();
					detailsNode.Nodes.Add(addressNode);

					TreeNode SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "AddressFamily: " + address.AddressFamily.ToString();
					addressNode.Nodes.Add(SubDetailsNode);

					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "IsIPv6LinkLocal: " + address.IsIPv6LinkLocal.ToString();
					addressNode.Nodes.Add(SubDetailsNode);

					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "IsIPv6Multicast: " + address.IsIPv6Multicast.ToString();
					addressNode.Nodes.Add(SubDetailsNode);

					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "IsIPv6SiteLocal: " + address.IsIPv6SiteLocal.ToString();
					addressNode.Nodes.Add(SubDetailsNode);
				}
			}


			detailsNode = new TreeNode();
			detailsNode.Text = "Gateway Addresses";
			_ipPropsNode.Nodes.Add(detailsNode);

			if (properties.GatewayAddresses.Count > 0)
			{
				foreach (GatewayIPAddressInformation info in properties.GatewayAddresses)
				{
					IPAddress address = info.Address;

					TreeNode addressNode = new TreeNode();
					addressNode.Text = "Address: " + address.ToString();
					detailsNode.Nodes.Add(addressNode);

					TreeNode SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "AddressFamily: " + address.AddressFamily.ToString();
					addressNode.Nodes.Add(SubDetailsNode);

					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "IsIPv6LinkLocal: " + address.IsIPv6LinkLocal.ToString();
					addressNode.Nodes.Add(SubDetailsNode);

					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "IsIPv6Multicast: " + address.IsIPv6Multicast.ToString();
					addressNode.Nodes.Add(SubDetailsNode);

					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "IsIPv6SiteLocal: " + address.IsIPv6SiteLocal.ToString();
					addressNode.Nodes.Add(SubDetailsNode);
				}
			}


			detailsNode = new TreeNode();
			detailsNode.Text = "Multicast Addresses";
			_ipPropsNode.Nodes.Add(detailsNode);

			if (properties.MulticastAddresses.Count > 0)
			{
				foreach (MulticastIPAddressInformation info in properties.MulticastAddresses)
				{
					TreeNode addressNode = new TreeNode();
					addressNode.Text = "Address: " + info.Address.ToString();
					detailsNode.Nodes.Add(addressNode);

					TreeNode SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "PreferredLifetime: " + info.AddressPreferredLifetime.ToString();
					addressNode.Nodes.Add(SubDetailsNode);

					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "ValidLifetime: " + info.AddressValidLifetime.ToString();
					addressNode.Nodes.Add(SubDetailsNode);

					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "DhcpLeaseLifetime: " + info.DhcpLeaseLifetime.ToString();
					addressNode.Nodes.Add(SubDetailsNode);

					DuplicateAddressDetectionState dupDetectionState = info.DuplicateAddressDetectionState;
					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "DuplicateDetectionState: " + dupDetectionState.ToString();
					addressNode.Nodes.Add(SubDetailsNode);

					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "IsDnsEligible: " + info.IsDnsEligible.ToString();
					addressNode.Nodes.Add(SubDetailsNode);

					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "IsTransient: " + info.IsTransient.ToString();
					addressNode.Nodes.Add(SubDetailsNode);

					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "PrefixOrigin: " + info.PrefixOrigin.ToString();
					addressNode.Nodes.Add(SubDetailsNode);

					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "SuffixOrigin: " + info.SuffixOrigin.ToString();
					addressNode.Nodes.Add(SubDetailsNode);
				}
			}


			detailsNode = new TreeNode();
			detailsNode.Text = "Unicast Addresses";
			_ipPropsNode.Nodes.Add(detailsNode);

			if (properties.UnicastAddresses.Count > 0)
			{
				foreach (UnicastIPAddressInformation info in properties.UnicastAddresses)
				{
					TreeNode addressNode = new TreeNode();
					addressNode.Text = "Address: " + info.Address.ToString();
					detailsNode.Nodes.Add(addressNode);

					TreeNode SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "AddressPreferredLifetime: " + info.AddressPreferredLifetime.ToString();
					addressNode.Nodes.Add(SubDetailsNode);

					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "AddressValidLifetime: " + info.AddressValidLifetime.ToString();
					addressNode.Nodes.Add(SubDetailsNode);

					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "DhcpLeaseLifetime: " + info.DhcpLeaseLifetime.ToString();
					addressNode.Nodes.Add(SubDetailsNode);

					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "DuplicateAddressDetectionState: " + info.DuplicateAddressDetectionState.ToString();
					addressNode.Nodes.Add(SubDetailsNode);
					try
					{
						SubDetailsNode = new TreeNode();
						SubDetailsNode.Text = "IPv4Mask: " + info.IPv4Mask.ToString();
						addressNode.Nodes.Add(SubDetailsNode);
					}
					catch
					{
					}

					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "IsDnsEligible: " + info.IsDnsEligible.ToString();
					addressNode.Nodes.Add(SubDetailsNode);
					
					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "IsTransient: " + info.IsTransient.ToString();
					addressNode.Nodes.Add(SubDetailsNode);

					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "PrefixOrigin: " + info.PrefixOrigin.ToString();
					addressNode.Nodes.Add(SubDetailsNode);

					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "SuffixOrigin: " + info.SuffixOrigin.ToString();
					addressNode.Nodes.Add(SubDetailsNode);
				}
			}


			detailsNode = new TreeNode();
			detailsNode.Text = "WinsServers Addresses";
			_ipPropsNode.Nodes.Add(detailsNode);

			if (properties.WinsServersAddresses.Count > 0)
			{
				foreach (IPAddress address in properties.WinsServersAddresses)
				{
					TreeNode addressNode = new TreeNode();
					addressNode.Text = "Address: " + address.ToString();
					detailsNode.Nodes.Add(addressNode);

					TreeNode SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "AddressFamily: " + address.AddressFamily.ToString();
					addressNode.Nodes.Add(SubDetailsNode);

					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "IsIPv6LinkLocal: " + address.IsIPv6LinkLocal.ToString();
					addressNode.Nodes.Add(SubDetailsNode);

					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "IsIPv6Multicast: " + address.IsIPv6Multicast.ToString();
					addressNode.Nodes.Add(SubDetailsNode);

					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "IsIPv6SiteLocal: " + address.IsIPv6SiteLocal.ToString();
					addressNode.Nodes.Add(SubDetailsNode);
				}
			}

			detailsNode = new TreeNode();
			detailsNode.Text = "IPv4 Interface Properties";
			_ipPropsNode.Nodes.Add(detailsNode);

			IPv4InterfaceProperties IPv4InterfaceProps = properties.GetIPv4Properties();

			if (IPv4InterfaceProps != null)
			{
				TreeNode SubDetailsNode = new TreeNode();
				SubDetailsNode.Text = "Index: " + IPv4InterfaceProps.Index.ToString();
				detailsNode.Nodes.Add(SubDetailsNode);

				SubDetailsNode = new TreeNode();
				SubDetailsNode.Text = "Is Automatic Private Addressing Active: " + IPv4InterfaceProps.IsAutomaticPrivateAddressingActive.ToString();
				detailsNode.Nodes.Add(SubDetailsNode);

				SubDetailsNode = new TreeNode();
				SubDetailsNode.Text = "Is Automatic Private Addressing Enabled: " + IPv4InterfaceProps.IsAutomaticPrivateAddressingEnabled.ToString();
				detailsNode.Nodes.Add(SubDetailsNode);

				SubDetailsNode = new TreeNode();
				SubDetailsNode.Text = "IsDhcpEnabled: " + IPv4InterfaceProps.IsDhcpEnabled.ToString();
				detailsNode.Nodes.Add(SubDetailsNode);

				SubDetailsNode = new TreeNode();
				SubDetailsNode.Text = "Is Forwarding Enabled: " + IPv4InterfaceProps.IsForwardingEnabled.ToString();
				detailsNode.Nodes.Add(SubDetailsNode);

				SubDetailsNode = new TreeNode();
				SubDetailsNode.Text = "Mtu: " + IPv4InterfaceProps.Mtu.ToString();
				detailsNode.Nodes.Add(SubDetailsNode);

				SubDetailsNode = new TreeNode();
				SubDetailsNode.Text = "Uses Wins: " + IPv4InterfaceProps.UsesWins.ToString();
				detailsNode.Nodes.Add(SubDetailsNode);
			}


			try
			{
				IPv6InterfaceProperties IPv6InterfaceProps = properties.GetIPv6Properties();

				detailsNode = new TreeNode();
				detailsNode.Text = "IPv6 Interface Properties";
				_ipPropsNode.Nodes.Add(detailsNode);
				
				if (IPv6InterfaceProps != null)
				{
					TreeNode SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "Index: " + IPv6InterfaceProps.Index.ToString();
					detailsNode.Nodes.Add(SubDetailsNode);

					SubDetailsNode = new TreeNode();
					SubDetailsNode.Text = "Mtu: " + IPv6InterfaceProps.Mtu.ToString();
					detailsNode.Nodes.Add(SubDetailsNode);
				}
			}
			catch (NetworkInformationException ex)
			{
				// IPv6 not configured on this machine
			}

			this.treeView1.EndUpdate();
		}

		private void OK_Click(object sender, EventArgs e)
		{
			this.Close();
		}


		private TreeNode _ipvStatsNode;
		private TreeNode _ipPropsNode;
	}
}