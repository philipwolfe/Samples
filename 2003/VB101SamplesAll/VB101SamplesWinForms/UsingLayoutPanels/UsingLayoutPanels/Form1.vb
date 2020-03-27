Public Class MainForm
    Public Sub New()
        InitializeComponent()

        'Configure layout panels with defaults

        ' CellBorder
        ' By default, no grid lines are shown.
        exclusiveCheck(cellBorderStyles, noneBorderToolStripMenuItem)
        tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.None

        ' FlowLayout
        ' The FlowLayoutPanel flows horizontally, left to right by default.
        flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight
        exclusiveCheck(flowDirectionDropDown, horizontalToolStripMenuItem)

        ' Break the layout flow at the header label.
        ' For FlowDirection.Horizontal, controls after the 
        ' header label control will be placed on a new row
        ' For FlowDirection.Vertical, controls after the 
        ' header label control will be placed on a new column
        Me.flowLayoutPanel.SetFlowBreak(tableLabel, True)
    End Sub

    ' UI interaction event handlers
    Private Sub exclusiveCheck(ByVal parent As ToolStripDropDownButton, ByVal menuItem As ToolStripMenuItem)
        ' Grow styles are exclusive.
        ' Uncheck sibling menu items and check current one
        For Each item As ToolStripItem In parent.DropDownItems
            If item.GetType() Is GetType(ToolStripMenuItem) Then
                CType(item, ToolStripMenuItem).Checked = False
            End If
        Next
        menuItem.Checked = True
    End Sub

    Private Sub horizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles horizontalToolStripMenuItem.Click
        exclusiveCheck(flowDirectionDropDown, CType(sender, ToolStripMenuItem))
        ' Flow horizontally, left to right
        ' Right to left flow is also supported
        Me.flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight
    End Sub

    Private Sub verticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles verticalToolStripMenuItem.Click
        exclusiveCheck(flowDirectionDropDown, CType(sender, ToolStripMenuItem))
        ' Flow vertically, top to bottom
        ' Bottom to top flow is also supported.
        Me.flowLayoutPanel.FlowDirection = FlowDirection.TopDown
    End Sub

    Private Sub borderStyleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles noneBorderToolStripMenuItem.Click, insetBorderToolStripMenuItem.Click, outsetBorderToolStripMenuItem.Click, singleBorderToolStripMenuItem.Click
        Dim styleSelected As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        exclusiveCheck(cellBorderStyles, styleSelected)

        ' Set the style based on the selected item
        Select Case styleSelected.Text
            Case "None"
                Me.tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.None
                Exit Select
            Case "Single"
                Me.tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
                Exit Select
            Case "Inset"
                Me.tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset
                Exit Select
            Case "Outset"
                Me.tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset
                Exit Select
        End Select
    End Sub

End Class
