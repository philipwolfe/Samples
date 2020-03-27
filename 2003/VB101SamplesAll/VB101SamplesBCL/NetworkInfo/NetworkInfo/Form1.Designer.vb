<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.label6 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.ShowInterfaceDetails = New System.Windows.Forms.Button
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.pingIPAddress = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.DoPing = New System.Windows.Forms.Button
        Me.doPingAsynch = New System.Windows.Forms.Button
        Me.infoTree = New System.Windows.Forms.TreeView
        Me.label1 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.label6)
        Me.groupBox2.Controls.Add(Me.label5)
        Me.groupBox2.Location = New System.Drawing.Point(14, 429)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(388, 62)
        Me.groupBox2.TabIndex = 20
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Network Change"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(6, 36)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(190, 13)
        Me.label6.TabIndex = 1
        Me.label6.Text = "and NetworkAvailabilityChanged raised."
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(6, 18)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(299, 13)
        Me.label5.TabIndex = 0
        Me.label5.Text = "Unplug the network cable to see the NetworkAddressChanged"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(13, 283)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(298, 13)
        Me.label4.TabIndex = 19
        Me.label4.Text = "Double-click an interface to see its IP Statistics and Properties."
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(13, 267)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(211, 13)
        Me.label3.TabIndex = 18
        Me.label3.Text = "Hover over a interface to see its description."
        '
        'ShowInterfaceDetails
        '
        Me.ShowInterfaceDetails.Location = New System.Drawing.Point(252, 6)
        Me.ShowInterfaceDetails.Name = "ShowInterfaceDetails"
        Me.ShowInterfaceDetails.Size = New System.Drawing.Size(150, 23)
        Me.ShowInterfaceDetails.TabIndex = 17
        Me.ShowInterfaceDetails.Text = "Show Interface Details"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.pingIPAddress)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.DoPing)
        Me.groupBox1.Controls.Add(Me.doPingAsynch)
        Me.groupBox1.Location = New System.Drawing.Point(14, 306)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(388, 116)
        Me.groupBox1.TabIndex = 16
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Ping"
        '
        'pingIPAddress
        '
        Me.pingIPAddress.Location = New System.Drawing.Point(74, 29)
        Me.pingIPAddress.Name = "pingIPAddress"
        Me.pingIPAddress.Size = New System.Drawing.Size(298, 20)
        Me.pingIPAddress.TabIndex = 6
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(7, 29)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(44, 13)
        Me.label2.TabIndex = 5
        Me.label2.Text = "Address:"
        '
        'DoPing
        '
        Me.DoPing.Location = New System.Drawing.Point(74, 74)
        Me.DoPing.Name = "DoPing"
        Me.DoPing.Size = New System.Drawing.Size(134, 25)
        Me.DoPing.TabIndex = 3
        Me.DoPing.Text = "Ping Synch"
        '
        'doPingAsynch
        '
        Me.doPingAsynch.Location = New System.Drawing.Point(238, 74)
        Me.doPingAsynch.Name = "doPingAsynch"
        Me.doPingAsynch.Size = New System.Drawing.Size(134, 25)
        Me.doPingAsynch.TabIndex = 4
        Me.doPingAsynch.Text = "Ping Asynch"
        '
        'infoTree
        '
        Me.infoTree.Location = New System.Drawing.Point(14, 37)
        Me.infoTree.Name = "infoTree"
        Me.infoTree.ShowNodeToolTips = True
        Me.infoTree.Size = New System.Drawing.Size(388, 227)
        Me.infoTree.TabIndex = 15
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Tahoma", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(12, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(150, 16)
        Me.label1.TabIndex = 14
        Me.label1.Text = "Network Interface List"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 502)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.ShowInterfaceDetails)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.infoTree)
        Me.Controls.Add(Me.label1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Network Sample"
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents ShowInterfaceDetails As System.Windows.Forms.Button
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pingIPAddress As System.Windows.Forms.TextBox
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents DoPing As System.Windows.Forms.Button
    Friend WithEvents doPingAsynch As System.Windows.Forms.Button
    Friend WithEvents infoTree As System.Windows.Forms.TreeView
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
