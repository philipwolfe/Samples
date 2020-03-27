Imports System.Text
Imports System.Net.NetworkInformation
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.Devices

Public Class Form1

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' get a list of all network interfaces on this computer
        If NetworkInterface.GetIsNetworkAvailable Then
            interfaces = NetworkInterface.GetAllNetworkInterfaces
        End If

        Me.toolTip1.IsBalloon = True
        Me.ToolTip1.ToolTipIcon = ToolTipIcon.Info

        LoadTreeView(interfaces)

        ping = New Ping

        ' register with the NetworkChange events
        AddHandler NetworkChange.NetworkAddressChanged, AddressOf NetworkChange_NetworkAddressChanged
        AddHandler NetworkChange.NetworkAvailabilityChanged, AddressOf NetworkChange_NetworkAvailabilityChanged

    End Sub

    Private Sub LoadTreeView(ByVal interfaces As NetworkInterface())

        ' Load the details about each network interface into the treeview
        Me.infoTree.BeginUpdate()

        Dim rootNode As TreeNode = New TreeNode
        rootNode.Text = "Network Interfaces"

        If interfaces.GetLength(0) > 0 Then
            For Each networkInterface As NetworkInterface In interfaces

                Dim address As PhysicalAddress = networkInterface.GetPhysicalAddress
                Dim bytes As Byte() = address.GetAddressBytes

                Dim networkInterfaceNode As TreeNode = New TreeNode
                networkInterfaceNode.Text = networkInterface.Name
                networkInterfaceNode.Tag = networkInterface

                Dim networkInterfaceDetailNode As TreeNode = New TreeNode
                networkInterfaceDetailNode.Text = "MAC Address: " + (Microsoft.VisualBasic.IIf(address.ToString = String.Empty, "None", address.ToString))
                networkInterfaceNode.Nodes.Add(networkInterfaceDetailNode)

                networkInterfaceDetailNode = New TreeNode
                networkInterfaceDetailNode.Text = "Id: " + networkInterface.Id.ToString
                networkInterfaceNode.Nodes.Add(networkInterfaceDetailNode)

                networkInterfaceDetailNode = New TreeNode
                networkInterfaceDetailNode.Text = "Type: " + networkInterface.NetworkInterfaceType.ToString
                networkInterfaceNode.Nodes.Add(networkInterfaceDetailNode)

                networkInterfaceDetailNode = New TreeNode
                networkInterfaceDetailNode.Text = "Operational Status: " + networkInterface.OperationalStatus.ToString
                networkInterfaceNode.Nodes.Add(networkInterfaceDetailNode)

                networkInterfaceDetailNode = New TreeNode
                networkInterfaceDetailNode.Text = "Speed: " + networkInterface.Speed.ToString("N") + " bytes"
                networkInterfaceNode.Nodes.Add(networkInterfaceDetailNode)

                networkInterfaceDetailNode = New TreeNode
                networkInterfaceDetailNode.Text = "Receive Only: " + networkInterface.IsReceiveOnly.ToString
                networkInterfaceNode.Nodes.Add(networkInterfaceDetailNode)

                networkInterfaceDetailNode = New TreeNode
                networkInterfaceDetailNode.Text = "Support Multicast: " + networkInterface.SupportsMulticast.ToString
                networkInterfaceNode.Nodes.Add(networkInterfaceDetailNode)

                networkInterfaceDetailNode = New TreeNode
                networkInterfaceDetailNode.Text = "Support IPv4: " + networkInterface.Supports(NetworkInterfaceComponent.IPv4).ToString
                networkInterfaceNode.Nodes.Add(networkInterfaceDetailNode)

                networkInterfaceDetailNode = New TreeNode
                networkInterfaceDetailNode.Text = "Support IPv6: " + networkInterface.Supports(NetworkInterfaceComponent.IPv6).ToString
                networkInterfaceNode.Nodes.Add(networkInterfaceDetailNode)

                rootNode.Nodes.Add(networkInterfaceNode)
            Next

        End If

        Me.infoTree.Nodes.Add(rootNode)

        rootNode.Expand()

        Me.infoTree.EndUpdate()

    End Sub

    Private Sub infoTree_NodeMouseHover(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseHoverEventArgs) Handles infoTree.NodeMouseHover

        ' Show the network interface description as a tooltip when hovering
        ' over a network interface node
        Dim networkInterface As NetworkInterface = CType(e.Node.Tag, NetworkInterface)
        If Not (networkInterface Is Nothing) Then
            e.Node.ToolTipText = networkInterface.Description
        End If
    End Sub

    Private Sub infoTree_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles infoTree.AfterSelect

        'if the selected node is a network interface enable the Show Interface Details button
        Dim networkInterface As NetworkInterface = CType(e.Node.Tag, NetworkInterface)
        If Not (networkInterface Is Nothing) Then
            ShowInterfaceDetails.Enabled = True
            _currentInterface = networkInterface
        Else
            ShowInterfaceDetails.Enabled = False
            _currentInterface = Nothing
        End If
    End Sub

    Private Sub ShowInterfaceDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowInterfaceDetails.Click

        ' Show the detail subform
        Dim detailTree As DetailTree = New DetailTree
        detailTree.LoadIPv4InterfaceStats(_currentInterface.GetIPv4Statistics)
        detailTree.LoadIPProperties(_currentInterface.GetIPProperties)
        detailTree.ShowDialog()

    End Sub

    Private Sub DoPing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoPing.Click

        ' ping the IP address provided.
        ' This call blocks until the ping is successful or 
        ' the timeout expires
        If Me.pingIPAddress.Text.Length > 0 Then
            Me.DoPing.Enabled = Me.doPingAsynch.Enabled = False
            Try
                Dim reply As PingReply = ping.Send(Me.pingIPAddress.Text)

                'Show the ping results
                ShowPingResultInfo(reply)
            Catch ex As PingException
                MessageBox.Show("The following error occured:" & Microsoft.VisualBasic.Chr(10) & "" & Microsoft.VisualBasic.Chr(13) & "" + ex.Message, "Network Sample", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Me.DoPing.Enabled = Me.doPingAsynch.Enabled = True
        Else
            MessageBox.Show("You must enter an address to ping first", "Network Sample", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub doPingAsynch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles doPingAsynch.Click

        ' Do an asynch ping. The results are displayed after the
        ' delegate invokes the ping_PingCompleted method
        If Me.pingIPAddress.Text.Length > 0 Then
            Me.DoPing.Enabled = Me.doPingAsynch.Enabled = False
            Try
                ping.SendAsync(Me.pingIPAddress.Text, Me)
            Catch ex As PingException
                MessageBox.Show("The following error occured:" & Microsoft.VisualBasic.Chr(10) & "" & Microsoft.VisualBasic.Chr(13) & "" + ex.Message, "Network Sample", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("You must enter an address to ping first", "Network Sample", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        System.Threading.Thread.Sleep(1000)
    End Sub

    Sub ping_PingCompleted(ByVal sender As Object, ByVal e As PingCompletedEventArgs) Handles ping.PingCompleted

        ' re-enable the two Ping buttons
        Me.DoPing.Enabled = Me.doPingAsynch.Enabled = True

        ' Called by the PingCompletedEventHandler
        If e.Cancelled = True Then
            MessageBox.Show("The Async ping was cancelled", "Network Sample", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Not (e.Error Is Nothing) Then
            MessageBox.Show("The following error occured:" & Microsoft.VisualBasic.Chr(10) & "" & Microsoft.VisualBasic.Chr(13) & "" + e.Error.Message, "Network Sample", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        ShowPingResultInfo(e.Reply)

    End Sub

    Private Sub ShowPingResultInfo(ByVal reply As PingReply)

        ' Show the details of the PingReply
        If reply.Status = IPStatus.Success Then
            Dim builder As StringBuilder = New StringBuilder

            builder.Append("You pinged: " & Microsoft.VisualBasic.Chr(9) & "" & Microsoft.VisualBasic.Chr(9) & "")
            builder.AppendLine(reply.Address.ToString)
            builder.AppendLine()

            builder.Append("The status returned was: " & Microsoft.VisualBasic.Chr(9) & "")
            builder.AppendLine(reply.Status.ToString)
            builder.AppendLine()

            builder.Append("The roundtrip time was: " & Microsoft.VisualBasic.Chr(9) & "")
            builder.AppendLine(reply.RoundtripTime.ToString("N"))
            builder.AppendLine()

            If Not (reply.Buffer Is Nothing) Then
                builder.Append("The reply message was: " & Microsoft.VisualBasic.Chr(9) & "")
                builder.AppendLine(ConvertByteBufferToString(reply.Buffer))
                builder.AppendLine()
            End If

            Dim options As PingOptions = reply.Options
            builder.Append("Ttl: " & Microsoft.VisualBasic.Chr(9) & "" & Microsoft.VisualBasic.Chr(9) & "" & Microsoft.VisualBasic.Chr(9) & "")
            builder.AppendLine(options.Ttl.ToString)
            builder.AppendLine()

            builder.Append("Dont Fragment: " & Microsoft.VisualBasic.Chr(9) & "" & Microsoft.VisualBasic.Chr(9) & "")
            builder.AppendLine(options.DontFragment.ToString)
            builder.AppendLine()

            MessageBox.Show(builder.ToString, "Ping Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return

        End If

        MessageBox.Show("Ping was not Successfull." & Microsoft.VisualBasic.Chr(10) & "" & Microsoft.VisualBasic.Chr(13) & "Status Code: " + reply.Status.ToString, "Ping Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Function ConvertByteBufferToString(ByVal inputBuffer As Byte()) As String
        Return System.Text.Encoding.ASCII.GetString(inputBuffer, 0, inputBuffer.Length)
    End Function

    Sub NetworkChange_NetworkAvailabilityChanged(ByVal sender As Object, ByVal e As NetworkAvailabilityEventArgs)
        'this method is called by the NetworkAvailabilityChangedEventHandler delegate
        MessageBox.Show("The network avialability has changed." & Microsoft.VisualBasic.Chr(13) & "" & Microsoft.VisualBasic.Chr(10) & "The network is now " + (Microsoft.VisualBasic.IIf(e.IsAvailable = True, "on line", "off line")), "Network Change Event", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Sub NetworkChange_NetworkAddressChanged(ByVal sender As Object, ByVal e As EventArgs)
        ' this method is called by the NetworkAddressChangedEventHandler delegate
        MessageBox.Show("The network address has changed.", "Network Change Event", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Private interfaces As NetworkInterface()
    Private _currentInterface As NetworkInterface
    Private WithEvents ping As Ping

End Class
