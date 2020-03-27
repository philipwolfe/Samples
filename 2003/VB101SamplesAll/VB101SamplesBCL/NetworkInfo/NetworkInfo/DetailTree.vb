Imports System.Net
Imports System.Net.NetworkInformation

Public Class DetailTree

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_ipvStatsNode = New TreeNode("IPV4 Statistics")
        m_ipPropsNode = New TreeNode("IP Properties")

        treeView1.Nodes.Add(m_ipvStatsNode)
        treeView1.Nodes.Add(m_ipPropsNode)

    End Sub

    Public Sub LoadIPv4InterfaceStats(ByVal statistics As IPv4InterfaceStatistics)

        Me.treeView1.BeginUpdate()

        Dim detailsNode As TreeNode = New TreeNode
        detailsNode.Text = "BytesReceived: " + statistics.BytesReceived.ToString("N0")
        m_ipvStatsNode.Nodes.Add(detailsNode)

        detailsNode = New TreeNode
        detailsNode.Text = "BytesSent: " + statistics.BytesSent.ToString("N0")
        m_ipvStatsNode.Nodes.Add(detailsNode)

        detailsNode = New TreeNode
        detailsNode.Text = "IncomingPacketsDiscarded: " + statistics.IncomingPacketsDiscarded.ToString("N0")
        m_ipvStatsNode.Nodes.Add(detailsNode)

        detailsNode = New TreeNode
        detailsNode.Text = "IncomingPacketsWithErrors: " + statistics.IncomingPacketsWithErrors.ToString("N0")
        m_ipvStatsNode.Nodes.Add(detailsNode)

        detailsNode = New TreeNode
        detailsNode.Text = "IncomingUnknownProtocolPackets: " + statistics.IncomingUnknownProtocolPackets.ToString("N0")
        m_ipvStatsNode.Nodes.Add(detailsNode)

        detailsNode = New TreeNode
        detailsNode.Text = "NonUnicastPacketsReceived: " + statistics.IncomingUnknownProtocolPackets.ToString("N0")
        m_ipvStatsNode.Nodes.Add(detailsNode)

        detailsNode = New TreeNode
        detailsNode.Text = "NonUnicastPacketsReceived: " + statistics.NonUnicastPacketsReceived.ToString("N0")
        m_ipvStatsNode.Nodes.Add(detailsNode)

        detailsNode = New TreeNode
        detailsNode.Text = "NonUnicastPacketsSent: " + statistics.NonUnicastPacketsSent.ToString("N0")
        m_ipvStatsNode.Nodes.Add(detailsNode)

        detailsNode = New TreeNode
        detailsNode.Text = "OutgoingPacketsDiscarded: " + statistics.OutgoingPacketsDiscarded.ToString("N0")
        m_ipvStatsNode.Nodes.Add(detailsNode)

        detailsNode = New TreeNode
        detailsNode.Text = "OutgoingPacketsWithErrors: " + statistics.OutgoingPacketsDiscarded.ToString("N0")
        m_ipvStatsNode.Nodes.Add(detailsNode)

        detailsNode = New TreeNode
        detailsNode.Text = "OutputQueueLength: " + statistics.OutputQueueLength.ToString("N0")
        m_ipvStatsNode.Nodes.Add(detailsNode)

        detailsNode = New TreeNode
        detailsNode.Text = "UnicastPacketsReceived: " + statistics.UnicastPacketsReceived.ToString("N0")
        m_ipvStatsNode.Nodes.Add(detailsNode)

        detailsNode = New TreeNode
        detailsNode.Text = "UnicastPacketsSent: " + statistics.UnicastPacketsSent.ToString("N0")
        m_ipvStatsNode.Nodes.Add(detailsNode)

        Me.treeView1.EndUpdate()

    End Sub

    Public Sub LoadIPProperties(ByVal properties As IPInterfaceProperties)

        Me.treeView1.BeginUpdate()

        Dim detailsNode As TreeNode = New TreeNode
        detailsNode.Text = "DnsSuffix: " + (Microsoft.VisualBasic.IIf(properties.DnsSuffix = String.Empty, "" & Microsoft.VisualBasic.Chr(9) & "None", properties.DnsSuffix))
        m_ipPropsNode.Nodes.Add(detailsNode)

        detailsNode = New TreeNode
        detailsNode.Text = "IsDnsEnabled: " + properties.IsDnsEnabled.ToString
        m_ipPropsNode.Nodes.Add(detailsNode)

        detailsNode = New TreeNode
        detailsNode.Text = "IsDynamicDnsEnabled: " + properties.IsDynamicDnsEnabled.ToString
        m_ipPropsNode.Nodes.Add(detailsNode)

        detailsNode = New TreeNode
        detailsNode.Text = "Anycast Addresses"
        m_ipPropsNode.Nodes.Add(detailsNode)
        If properties.AnycastAddresses.Count > 0 Then
            For Each info As IPAddressInformation In properties.AnycastAddresses
                Dim addressNode As TreeNode = New TreeNode
                addressNode.Text = "Address: " + info.Address.ToString
                detailsNode.Nodes.Add(addressNode)
                Dim SubDetailsNode As TreeNode = New TreeNode
                SubDetailsNode.Text = "IsDnsEligible: " + info.IsDnsEligible.ToString
                addressNode.Nodes.Add(SubDetailsNode)
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "IsTransient: " + info.IsTransient.ToString
                addressNode.Nodes.Add(SubDetailsNode)
            Next
        End If

        detailsNode = New TreeNode
        detailsNode.Text = "DhcpServer Addresses"
        m_ipPropsNode.Nodes.Add(detailsNode)
        If properties.DhcpServerAddresses.Count > 0 Then
            For Each address As IPAddress In properties.DhcpServerAddresses
                Dim addressNode As TreeNode = New TreeNode
                addressNode.Text = "Address: " + address.ToString
                detailsNode.Nodes.Add(addressNode)
                Dim SubDetailsNode As TreeNode = New TreeNode
                SubDetailsNode.Text = "AddressFamily: " + address.AddressFamily.ToString
                addressNode.Nodes.Add(SubDetailsNode)
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "IsIPv6LinkLocal: " + address.IsIPv6LinkLocal.ToString
                addressNode.Nodes.Add(SubDetailsNode)
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "IsIPv6Multicast: " + address.IsIPv6Multicast.ToString
                addressNode.Nodes.Add(SubDetailsNode)
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "IsIPv6SiteLocal: " + address.IsIPv6SiteLocal.ToString
                addressNode.Nodes.Add(SubDetailsNode)
            Next
        End If

        detailsNode = New TreeNode
        detailsNode.Text = "Dns Addresses"
        m_ipPropsNode.Nodes.Add(detailsNode)
        If properties.DnsAddresses.Count > 0 Then
            For Each address As IPAddress In properties.DnsAddresses
                Dim addressNode As TreeNode = New TreeNode
                addressNode.Text = "Address: " + address.ToString
                detailsNode.Nodes.Add(addressNode)
                Dim SubDetailsNode As TreeNode = New TreeNode
                SubDetailsNode.Text = "AddressFamily: " + address.AddressFamily.ToString
                addressNode.Nodes.Add(SubDetailsNode)
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "IsIPv6LinkLocal: " + address.IsIPv6LinkLocal.ToString
                addressNode.Nodes.Add(SubDetailsNode)
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "IsIPv6Multicast: " + address.IsIPv6Multicast.ToString
                addressNode.Nodes.Add(SubDetailsNode)
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "IsIPv6SiteLocal: " + address.IsIPv6SiteLocal.ToString
                addressNode.Nodes.Add(SubDetailsNode)
            Next
        End If

        detailsNode = New TreeNode
        detailsNode.Text = "Gateway Addresses"
        m_ipPropsNode.Nodes.Add(detailsNode)
        If properties.GatewayAddresses.Count > 0 Then
            For Each info As GatewayIPAddressInformation In properties.GatewayAddresses
                Dim address As IPAddress = info.Address
                Dim addressNode As TreeNode = New TreeNode
                addressNode.Text = "Address: " + address.ToString
                detailsNode.Nodes.Add(addressNode)
                Dim SubDetailsNode As TreeNode = New TreeNode
                SubDetailsNode.Text = "AddressFamily: " + address.AddressFamily.ToString
                addressNode.Nodes.Add(SubDetailsNode)
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "IsIPv6LinkLocal: " + address.IsIPv6LinkLocal.ToString
                addressNode.Nodes.Add(SubDetailsNode)
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "IsIPv6Multicast: " + address.IsIPv6Multicast.ToString
                addressNode.Nodes.Add(SubDetailsNode)
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "IsIPv6SiteLocal: " + address.IsIPv6SiteLocal.ToString
                addressNode.Nodes.Add(SubDetailsNode)
            Next
        End If

        detailsNode = New TreeNode
        detailsNode.Text = "Multicast Addresses"
        m_ipPropsNode.Nodes.Add(detailsNode)
        If properties.MulticastAddresses.Count > 0 Then
            For Each info As MulticastIPAddressInformation In properties.MulticastAddresses
                Dim addressNode As TreeNode = New TreeNode
                addressNode.Text = "Address: " + info.Address.ToString
                detailsNode.Nodes.Add(addressNode)
                Dim SubDetailsNode As TreeNode = New TreeNode
                SubDetailsNode.Text = "PreferredLifetime: " + info.AddressPreferredLifetime.ToString
                addressNode.Nodes.Add(SubDetailsNode)
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "ValidLifetime: " + info.AddressValidLifetime.ToString
                addressNode.Nodes.Add(SubDetailsNode)
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "DhcpLeaseLifetime: " + info.DhcpLeaseLifetime.ToString
                addressNode.Nodes.Add(SubDetailsNode)
                Dim dupDetectionState As DuplicateAddressDetectionState = info.DuplicateAddressDetectionState
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "DuplicateDetectionState: " + dupDetectionState.ToString
                addressNode.Nodes.Add(SubDetailsNode)
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "IsDnsEligible: " + info.IsDnsEligible.ToString
                addressNode.Nodes.Add(SubDetailsNode)
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "IsTransient: " + info.IsTransient.ToString
                addressNode.Nodes.Add(SubDetailsNode)
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "PrefixOrigin: " + info.PrefixOrigin.ToString
                addressNode.Nodes.Add(SubDetailsNode)
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "SuffixOrigin: " + info.SuffixOrigin.ToString
                addressNode.Nodes.Add(SubDetailsNode)
            Next
        End If

        detailsNode = New TreeNode
        detailsNode.Text = "Unicast Addresses"
        m_ipPropsNode.Nodes.Add(detailsNode)
        If properties.UnicastAddresses.Count > 0 Then
            For Each info As UnicastIPAddressInformation In properties.UnicastAddresses
                Dim addressNode As TreeNode = New TreeNode
                addressNode.Text = "Address: " + info.Address.ToString
                detailsNode.Nodes.Add(addressNode)
                Dim SubDetailsNode As TreeNode = New TreeNode
                SubDetailsNode.Text = "AddressPreferredLifetime: " + info.AddressPreferredLifetime.ToString
                addressNode.Nodes.Add(SubDetailsNode)
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "AddressValidLifetime: " + info.AddressValidLifetime.ToString
                addressNode.Nodes.Add(SubDetailsNode)
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "DhcpLeaseLifetime: " + info.DhcpLeaseLifetime.ToString
                addressNode.Nodes.Add(SubDetailsNode)
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "DuplicateAddressDetectionState: " + info.DuplicateAddressDetectionState.ToString
                addressNode.Nodes.Add(SubDetailsNode)
                Try
                    SubDetailsNode = New TreeNode
                    SubDetailsNode.Text = "IPv4Mask: " + info.IPv4Mask.ToString
                    addressNode.Nodes.Add(SubDetailsNode)
                Catch
                End Try
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "IsDnsEligible: " + info.IsDnsEligible.ToString
                addressNode.Nodes.Add(SubDetailsNode)
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "IsTransient: " + info.IsTransient.ToString
                addressNode.Nodes.Add(SubDetailsNode)
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "PrefixOrigin: " + info.PrefixOrigin.ToString
                addressNode.Nodes.Add(SubDetailsNode)
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "SuffixOrigin: " + info.SuffixOrigin.ToString
                addressNode.Nodes.Add(SubDetailsNode)
            Next
        End If

        detailsNode = New TreeNode
        detailsNode.Text = "WinsServers Addresses"
        m_ipPropsNode.Nodes.Add(detailsNode)
        If properties.WinsServersAddresses.Count > 0 Then
            For Each address As IPAddress In properties.WinsServersAddresses
                Dim addressNode As TreeNode = New TreeNode
                addressNode.Text = "Address: " + address.ToString
                detailsNode.Nodes.Add(addressNode)
                Dim SubDetailsNode As TreeNode = New TreeNode
                SubDetailsNode.Text = "AddressFamily: " + address.AddressFamily.ToString
                addressNode.Nodes.Add(SubDetailsNode)
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "IsIPv6LinkLocal: " + address.IsIPv6LinkLocal.ToString
                addressNode.Nodes.Add(SubDetailsNode)
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "IsIPv6Multicast: " + address.IsIPv6Multicast.ToString
                addressNode.Nodes.Add(SubDetailsNode)
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "IsIPv6SiteLocal: " + address.IsIPv6SiteLocal.ToString
                addressNode.Nodes.Add(SubDetailsNode)
            Next
        End If

        detailsNode = New TreeNode
        detailsNode.Text = "IPv4 Interface Properties"
        m_ipPropsNode.Nodes.Add(detailsNode)
        Dim IPv4InterfaceProps As IPv4InterfaceProperties = properties.GetIPv4Properties

        If Not (IPv4InterfaceProps Is Nothing) Then
            Dim SubDetailsNode As TreeNode = New TreeNode
            SubDetailsNode.Text = "Index: " + IPv4InterfaceProps.Index.ToString
            detailsNode.Nodes.Add(SubDetailsNode)
            SubDetailsNode = New TreeNode
            SubDetailsNode.Text = "Is Automatic Private Addressing Active: " + IPv4InterfaceProps.IsAutomaticPrivateAddressingActive.ToString
            detailsNode.Nodes.Add(SubDetailsNode)
            SubDetailsNode = New TreeNode
            SubDetailsNode.Text = "Is Automatic Private Addressing Enabled: " + IPv4InterfaceProps.IsAutomaticPrivateAddressingEnabled.ToString
            detailsNode.Nodes.Add(SubDetailsNode)
            SubDetailsNode = New TreeNode
            SubDetailsNode.Text = "IsDhcpEnabled: " + IPv4InterfaceProps.IsDhcpEnabled.ToString
            detailsNode.Nodes.Add(SubDetailsNode)
            SubDetailsNode = New TreeNode
            SubDetailsNode.Text = "Is Forwarding Enabled: " + IPv4InterfaceProps.IsForwardingEnabled.ToString
            detailsNode.Nodes.Add(SubDetailsNode)
            SubDetailsNode = New TreeNode
            SubDetailsNode.Text = "Mtu: " + IPv4InterfaceProps.Mtu.ToString
            detailsNode.Nodes.Add(SubDetailsNode)
            SubDetailsNode = New TreeNode
            SubDetailsNode.Text = "Uses Wins: " + IPv4InterfaceProps.UsesWins.ToString
            detailsNode.Nodes.Add(SubDetailsNode)
        End If
        Try
            Dim IPv6InterfaceProps As IPv6InterfaceProperties = properties.GetIPv6Properties
            detailsNode = New TreeNode
            detailsNode.Text = "IPv6 Interface Properties"
            m_ipPropsNode.Nodes.Add(detailsNode)
            If Not (IPv6InterfaceProps Is Nothing) Then
                Dim SubDetailsNode As TreeNode = New TreeNode
                SubDetailsNode.Text = "Index: " + IPv6InterfaceProps.Index.ToString
                detailsNode.Nodes.Add(SubDetailsNode)
                SubDetailsNode = New TreeNode
                SubDetailsNode.Text = "Mtu: " + IPv6InterfaceProps.Mtu.ToString
                detailsNode.Nodes.Add(SubDetailsNode)
            End If
        Catch ex As NetworkInformationException
        End Try

        Me.treeView1.EndUpdate()

    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Me.Close()
    End Sub


    Private m_ipvStatsNode As TreeNode
    Private m_ipPropsNode As TreeNode

End Class