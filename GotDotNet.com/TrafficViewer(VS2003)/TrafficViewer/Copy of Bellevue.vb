Option Strict On
Public Class Bellevue
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Link As System.Windows.Forms.LinkLabel
    Friend WithEvents MapLabel As System.Windows.Forms.Label
    Friend WithEvents L3600_Richards_Rd_Factoria_blvd As System.Windows.Forms.Label
    Friend WithEvents LRichards_Rd_at_SE_32nd_Stzx As System.Windows.Forms.Label
    Friend WithEvents LSE_28th_at_148th_Ave_NE As System.Windows.Forms.Label
    Friend WithEvents LSE_5th_St_at_116th_Ave_SE As System.Windows.Forms.Label
    Friend WithEvents LLakes_Hillszz_116th_Ave_SE_at_Railroad As System.Windows.Forms.Label
    Friend WithEvents L108th_Ave_NE_at_NE_4th_Stzx As System.Windows.Forms.Label
    Friend WithEvents LNE_8th_at_116th_Ave_NE As System.Windows.Forms.Label
    Friend WithEvents LBellevue_Way_at_NE_8th_Stzx As System.Windows.Forms.Label
    Friend WithEvents L100th_Ave_NE_at_NE_4th_Stzx As System.Windows.Forms.Label
    Friend WithEvents L112th_Ave_NE_at_NE_8th_Stzx As System.Windows.Forms.Label
    Friend WithEvents LNE_12th_at_112th_AVE_NE As System.Windows.Forms.Label
    Friend WithEvents LBellevue_Way_at_NE_4th_Stzx As System.Windows.Forms.Label
    Friend WithEvents L110th_Ave_NE_at_Main As System.Windows.Forms.Label
    Friend WithEvents L110th_Ave_NE_at_NE_4th_Stzx As System.Windows.Forms.Label
    Friend WithEvents LNE_4th_St_at_112th_Ave_NE As System.Windows.Forms.Label
    Friend WithEvents L156th_Ave_NE_at_NE_8th As System.Windows.Forms.Label
    Friend WithEvents L110th_at_NE_6th As System.Windows.Forms.Label
    Friend WithEvents L148th_Ave_NE_at_NE_8th As System.Windows.Forms.Label
    Friend WithEvents LNorthup_Way_at_148th_Ave_NE As System.Windows.Forms.Label
    Friend WithEvents LSE_8th_at_114th_Ave_NE As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Bellevue))
        Me.MapLabel = New System.Windows.Forms.Label
        Me.Link = New System.Windows.Forms.LinkLabel
        Me.L3600_Richards_Rd_Factoria_blvd = New System.Windows.Forms.Label
        Me.LSE_28th_at_148th_Ave_NE = New System.Windows.Forms.Label
        Me.LRichards_Rd_at_SE_32nd_Stzx = New System.Windows.Forms.Label
        Me.LSE_8th_at_114th_Ave_NE = New System.Windows.Forms.Label
        Me.LSE_5th_St_at_116th_Ave_SE = New System.Windows.Forms.Label
        Me.LLakes_Hillszz_116th_Ave_SE_at_Railroad = New System.Windows.Forms.Label
        Me.L108th_Ave_NE_at_NE_4th_Stzx = New System.Windows.Forms.Label
        Me.LNE_8th_at_116th_Ave_NE = New System.Windows.Forms.Label
        Me.LBellevue_Way_at_NE_8th_Stzx = New System.Windows.Forms.Label
        Me.L100th_Ave_NE_at_NE_4th_Stzx = New System.Windows.Forms.Label
        Me.L112th_Ave_NE_at_NE_8th_Stzx = New System.Windows.Forms.Label
        Me.LNE_12th_at_112th_AVE_NE = New System.Windows.Forms.Label
        Me.LBellevue_Way_at_NE_4th_Stzx = New System.Windows.Forms.Label
        Me.L110th_Ave_NE_at_Main = New System.Windows.Forms.Label
        Me.L110th_Ave_NE_at_NE_4th_Stzx = New System.Windows.Forms.Label
        Me.LNE_4th_St_at_112th_Ave_NE = New System.Windows.Forms.Label
        Me.L156th_Ave_NE_at_NE_8th = New System.Windows.Forms.Label
        Me.L110th_at_NE_6th = New System.Windows.Forms.Label
        Me.L148th_Ave_NE_at_NE_8th = New System.Windows.Forms.Label
        Me.LNorthup_Way_at_148th_Ave_NE = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'MapLabel
        '
        Me.MapLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MapLabel.Image = CType(resources.GetObject("MapLabel.Image"), System.Drawing.Image)
        Me.MapLabel.Location = New System.Drawing.Point(2, 48)
        Me.MapLabel.Name = "MapLabel"
        Me.MapLabel.Size = New System.Drawing.Size(400, 479)
        Me.MapLabel.TabIndex = 0
        '
        'Link
        '
        Me.Link.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link.Location = New System.Drawing.Point(122, 16)
        Me.Link.Name = "Link"
        Me.Link.Size = New System.Drawing.Size(176, 24)
        Me.Link.TabIndex = 2
        Me.Link.TabStop = True
        Me.Link.Text = "Bellevue Traffic Website"
        '
        'L3600_Richards_Rd_Factoria_blvd
        '
        Me.L3600_Richards_Rd_Factoria_blvd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.L3600_Richards_Rd_Factoria_blvd.Image = CType(resources.GetObject("L3600_Richards_Rd_Factoria_blvd.Image"), System.Drawing.Image)
        Me.L3600_Richards_Rd_Factoria_blvd.Location = New System.Drawing.Point(188, 414)
        Me.L3600_Richards_Rd_Factoria_blvd.Name = "L3600_Richards_Rd_Factoria_blvd"
        Me.L3600_Richards_Rd_Factoria_blvd.Size = New System.Drawing.Size(15, 10)
        Me.L3600_Richards_Rd_Factoria_blvd.TabIndex = 3
        '
        'LSE_28th_at_148th_Ave_NE
        '
        Me.LSE_28th_at_148th_Ave_NE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LSE_28th_at_148th_Ave_NE.Image = CType(resources.GetObject("LSE_28th_at_148th_Ave_NE.Image"), System.Drawing.Image)
        Me.LSE_28th_at_148th_Ave_NE.Location = New System.Drawing.Point(306, 347)
        Me.LSE_28th_at_148th_Ave_NE.Name = "LSE_28th_at_148th_Ave_NE"
        Me.LSE_28th_at_148th_Ave_NE.Size = New System.Drawing.Size(15, 10)
        Me.LSE_28th_at_148th_Ave_NE.TabIndex = 4
        '
        'LRichards_Rd_at_SE_32nd_Stzx
        '
        Me.LRichards_Rd_at_SE_32nd_Stzx.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LRichards_Rd_at_SE_32nd_Stzx.Image = CType(resources.GetObject("LRichards_Rd_at_SE_32nd_Stzx.Image"), System.Drawing.Image)
        Me.LRichards_Rd_at_SE_32nd_Stzx.Location = New System.Drawing.Point(202, 370)
        Me.LRichards_Rd_at_SE_32nd_Stzx.Name = "LRichards_Rd_at_SE_32nd_Stzx"
        Me.LRichards_Rd_at_SE_32nd_Stzx.Size = New System.Drawing.Size(15, 10)
        Me.LRichards_Rd_at_SE_32nd_Stzx.TabIndex = 5
        '
        'LSE_8th_at_114th_Ave_NE
        '
        Me.LSE_8th_at_114th_Ave_NE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LSE_8th_at_114th_Ave_NE.Image = CType(resources.GetObject("LSE_8th_at_114th_Ave_NE.Image"), System.Drawing.Image)
        Me.LSE_8th_at_114th_Ave_NE.Location = New System.Drawing.Point(113, 256)
        Me.LSE_8th_at_114th_Ave_NE.Name = "LSE_8th_at_114th_Ave_NE"
        Me.LSE_8th_at_114th_Ave_NE.Size = New System.Drawing.Size(15, 10)
        Me.LSE_8th_at_114th_Ave_NE.TabIndex = 6
        '
        'LSE_5th_St_at_116th_Ave_SE
        '
        Me.LSE_5th_St_at_116th_Ave_SE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LSE_5th_St_at_116th_Ave_SE.Image = CType(resources.GetObject("LSE_5th_St_at_116th_Ave_SE.Image"), System.Drawing.Image)
        Me.LSE_5th_St_at_116th_Ave_SE.Location = New System.Drawing.Point(134, 232)
        Me.LSE_5th_St_at_116th_Ave_SE.Name = "LSE_5th_St_at_116th_Ave_SE"
        Me.LSE_5th_St_at_116th_Ave_SE.Size = New System.Drawing.Size(15, 10)
        Me.LSE_5th_St_at_116th_Ave_SE.TabIndex = 8
        '
        'LLakes_Hillszz_116th_Ave_SE_at_Railroad
        '
        Me.LLakes_Hillszz_116th_Ave_SE_at_Railroad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LLakes_Hillszz_116th_Ave_SE_at_Railroad.Image = CType(resources.GetObject("LLakes_Hillszz_116th_Ave_SE_at_Railroad.Image"), System.Drawing.Image)
        Me.LLakes_Hillszz_116th_Ave_SE_at_Railroad.Location = New System.Drawing.Point(142, 244)
        Me.LLakes_Hillszz_116th_Ave_SE_at_Railroad.Name = "LLakes_Hillszz_116th_Ave_SE_at_Railroad"
        Me.LLakes_Hillszz_116th_Ave_SE_at_Railroad.Size = New System.Drawing.Size(15, 10)
        Me.LLakes_Hillszz_116th_Ave_SE_at_Railroad.TabIndex = 7
        '
        'L108th_Ave_NE_at_NE_4th_Stzx
        '
        Me.L108th_Ave_NE_at_NE_4th_Stzx.Cursor = System.Windows.Forms.Cursors.Hand
        Me.L108th_Ave_NE_at_NE_4th_Stzx.Image = CType(resources.GetObject("L108th_Ave_NE_at_NE_4th_Stzx.Image"), System.Drawing.Image)
        Me.L108th_Ave_NE_at_NE_4th_Stzx.Location = New System.Drawing.Point(80, 459)
        Me.L108th_Ave_NE_at_NE_4th_Stzx.Name = "L108th_Ave_NE_at_NE_4th_Stzx"
        Me.L108th_Ave_NE_at_NE_4th_Stzx.Size = New System.Drawing.Size(15, 10)
        Me.L108th_Ave_NE_at_NE_4th_Stzx.TabIndex = 12
        '
        'LNE_8th_at_116th_Ave_NE
        '
        Me.LNE_8th_at_116th_Ave_NE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LNE_8th_at_116th_Ave_NE.Image = CType(resources.GetObject("LNE_8th_at_116th_Ave_NE.Image"), System.Drawing.Image)
        Me.LNE_8th_at_116th_Ave_NE.Location = New System.Drawing.Point(151, 426)
        Me.LNE_8th_at_116th_Ave_NE.Name = "LNE_8th_at_116th_Ave_NE"
        Me.LNE_8th_at_116th_Ave_NE.Size = New System.Drawing.Size(15, 10)
        Me.LNE_8th_at_116th_Ave_NE.TabIndex = 11
        '
        'LBellevue_Way_at_NE_8th_Stzx
        '
        Me.LBellevue_Way_at_NE_8th_Stzx.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LBellevue_Way_at_NE_8th_Stzx.Image = CType(resources.GetObject("LBellevue_Way_at_NE_8th_Stzx.Image"), System.Drawing.Image)
        Me.LBellevue_Way_at_NE_8th_Stzx.Location = New System.Drawing.Point(44, 423)
        Me.LBellevue_Way_at_NE_8th_Stzx.Name = "LBellevue_Way_at_NE_8th_Stzx"
        Me.LBellevue_Way_at_NE_8th_Stzx.Size = New System.Drawing.Size(15, 10)
        Me.LBellevue_Way_at_NE_8th_Stzx.TabIndex = 10
        '
        'L100th_Ave_NE_at_NE_4th_Stzx
        '
        Me.L100th_Ave_NE_at_NE_4th_Stzx.Cursor = System.Windows.Forms.Cursors.Hand
        Me.L100th_Ave_NE_at_NE_4th_Stzx.Image = CType(resources.GetObject("L100th_Ave_NE_at_NE_4th_Stzx.Image"), System.Drawing.Image)
        Me.L100th_Ave_NE_at_NE_4th_Stzx.Location = New System.Drawing.Point(9, 458)
        Me.L100th_Ave_NE_at_NE_4th_Stzx.Name = "L100th_Ave_NE_at_NE_4th_Stzx"
        Me.L100th_Ave_NE_at_NE_4th_Stzx.Size = New System.Drawing.Size(15, 10)
        Me.L100th_Ave_NE_at_NE_4th_Stzx.TabIndex = 9
        '
        'L112th_Ave_NE_at_NE_8th_Stzx
        '
        Me.L112th_Ave_NE_at_NE_8th_Stzx.Cursor = System.Windows.Forms.Cursors.Hand
        Me.L112th_Ave_NE_at_NE_8th_Stzx.Image = CType(resources.GetObject("L112th_Ave_NE_at_NE_8th_Stzx.Image"), System.Drawing.Image)
        Me.L112th_Ave_NE_at_NE_8th_Stzx.Location = New System.Drawing.Point(115, 424)
        Me.L112th_Ave_NE_at_NE_8th_Stzx.Name = "L112th_Ave_NE_at_NE_8th_Stzx"
        Me.L112th_Ave_NE_at_NE_8th_Stzx.Size = New System.Drawing.Size(15, 10)
        Me.L112th_Ave_NE_at_NE_8th_Stzx.TabIndex = 16
        '
        'LNE_12th_at_112th_AVE_NE
        '
        Me.LNE_12th_at_112th_AVE_NE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LNE_12th_at_112th_AVE_NE.Image = CType(resources.GetObject("LNE_12th_at_112th_AVE_NE.Image"), System.Drawing.Image)
        Me.LNE_12th_at_112th_AVE_NE.Location = New System.Drawing.Point(115, 389)
        Me.LNE_12th_at_112th_AVE_NE.Name = "LNE_12th_at_112th_AVE_NE"
        Me.LNE_12th_at_112th_AVE_NE.Size = New System.Drawing.Size(15, 10)
        Me.LNE_12th_at_112th_AVE_NE.TabIndex = 15
        '
        'LBellevue_Way_at_NE_4th_Stzx
        '
        Me.LBellevue_Way_at_NE_4th_Stzx.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LBellevue_Way_at_NE_4th_Stzx.Image = CType(resources.GetObject("LBellevue_Way_at_NE_4th_Stzx.Image"), System.Drawing.Image)
        Me.LBellevue_Way_at_NE_4th_Stzx.Location = New System.Drawing.Point(44, 458)
        Me.LBellevue_Way_at_NE_4th_Stzx.Name = "LBellevue_Way_at_NE_4th_Stzx"
        Me.LBellevue_Way_at_NE_4th_Stzx.Size = New System.Drawing.Size(15, 10)
        Me.LBellevue_Way_at_NE_4th_Stzx.TabIndex = 14
        '
        'L110th_Ave_NE_at_Main
        '
        Me.L110th_Ave_NE_at_Main.Cursor = System.Windows.Forms.Cursors.Hand
        Me.L110th_Ave_NE_at_Main.Image = CType(resources.GetObject("L110th_Ave_NE_at_Main.Image"), System.Drawing.Image)
        Me.L110th_Ave_NE_at_Main.Location = New System.Drawing.Point(85, 495)
        Me.L110th_Ave_NE_at_Main.Name = "L110th_Ave_NE_at_Main"
        Me.L110th_Ave_NE_at_Main.Size = New System.Drawing.Size(15, 10)
        Me.L110th_Ave_NE_at_Main.TabIndex = 13
        '
        'L110th_Ave_NE_at_NE_4th_Stzx
        '
        Me.L110th_Ave_NE_at_NE_4th_Stzx.Cursor = System.Windows.Forms.Cursors.Hand
        Me.L110th_Ave_NE_at_NE_4th_Stzx.Image = CType(resources.GetObject("L110th_Ave_NE_at_NE_4th_Stzx.Image"), System.Drawing.Image)
        Me.L110th_Ave_NE_at_NE_4th_Stzx.Location = New System.Drawing.Point(97, 459)
        Me.L110th_Ave_NE_at_NE_4th_Stzx.Name = "L110th_Ave_NE_at_NE_4th_Stzx"
        Me.L110th_Ave_NE_at_NE_4th_Stzx.Size = New System.Drawing.Size(15, 10)
        Me.L110th_Ave_NE_at_NE_4th_Stzx.TabIndex = 17
        '
        'LNE_4th_St_at_112th_Ave_NE
        '
        Me.LNE_4th_St_at_112th_Ave_NE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LNE_4th_St_at_112th_Ave_NE.Image = CType(resources.GetObject("LNE_4th_St_at_112th_Ave_NE.Image"), System.Drawing.Image)
        Me.LNE_4th_St_at_112th_Ave_NE.Location = New System.Drawing.Point(115, 460)
        Me.LNE_4th_St_at_112th_Ave_NE.Name = "LNE_4th_St_at_112th_Ave_NE"
        Me.LNE_4th_St_at_112th_Ave_NE.Size = New System.Drawing.Size(15, 10)
        Me.LNE_4th_St_at_112th_Ave_NE.TabIndex = 18
        '
        'L156th_Ave_NE_at_NE_8th
        '
        Me.L156th_Ave_NE_at_NE_8th.Cursor = System.Windows.Forms.Cursors.Hand
        Me.L156th_Ave_NE_at_NE_8th.Image = CType(resources.GetObject("L156th_Ave_NE_at_NE_8th.Image"), System.Drawing.Image)
        Me.L156th_Ave_NE_at_NE_8th.Location = New System.Drawing.Point(354, 158)
        Me.L156th_Ave_NE_at_NE_8th.Name = "L156th_Ave_NE_at_NE_8th"
        Me.L156th_Ave_NE_at_NE_8th.Size = New System.Drawing.Size(15, 10)
        Me.L156th_Ave_NE_at_NE_8th.TabIndex = 23
        '
        'L110th_at_NE_6th
        '
        Me.L110th_at_NE_6th.Cursor = System.Windows.Forms.Cursors.Hand
        Me.L110th_at_NE_6th.Image = CType(resources.GetObject("L110th_at_NE_6th.Image"), System.Drawing.Image)
        Me.L110th_at_NE_6th.Location = New System.Drawing.Point(98, 442)
        Me.L110th_at_NE_6th.Name = "L110th_at_NE_6th"
        Me.L110th_at_NE_6th.Size = New System.Drawing.Size(15, 10)
        Me.L110th_at_NE_6th.TabIndex = 22
        '
        'L148th_Ave_NE_at_NE_8th
        '
        Me.L148th_Ave_NE_at_NE_8th.Cursor = System.Windows.Forms.Cursors.Hand
        Me.L148th_Ave_NE_at_NE_8th.Image = CType(resources.GetObject("L148th_Ave_NE_at_NE_8th.Image"), System.Drawing.Image)
        Me.L148th_Ave_NE_at_NE_8th.Location = New System.Drawing.Point(308, 157)
        Me.L148th_Ave_NE_at_NE_8th.Name = "L148th_Ave_NE_at_NE_8th"
        Me.L148th_Ave_NE_at_NE_8th.Size = New System.Drawing.Size(15, 10)
        Me.L148th_Ave_NE_at_NE_8th.TabIndex = 21
        '
        'LNorthup_Way_at_148th_Ave_NE
        '
        Me.LNorthup_Way_at_148th_Ave_NE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LNorthup_Way_at_148th_Ave_NE.Image = CType(resources.GetObject("LNorthup_Way_at_148th_Ave_NE.Image"), System.Drawing.Image)
        Me.LNorthup_Way_at_148th_Ave_NE.Location = New System.Drawing.Point(311, 88)
        Me.LNorthup_Way_at_148th_Ave_NE.Name = "LNorthup_Way_at_148th_Ave_NE"
        Me.LNorthup_Way_at_148th_Ave_NE.Size = New System.Drawing.Size(15, 10)
        Me.LNorthup_Way_at_148th_Ave_NE.TabIndex = 20
        '
        'Bellevue
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(403, 528)
        Me.Controls.Add(Me.L156th_Ave_NE_at_NE_8th)
        Me.Controls.Add(Me.L110th_at_NE_6th)
        Me.Controls.Add(Me.L148th_Ave_NE_at_NE_8th)
        Me.Controls.Add(Me.LNorthup_Way_at_148th_Ave_NE)
        Me.Controls.Add(Me.LNE_4th_St_at_112th_Ave_NE)
        Me.Controls.Add(Me.L110th_Ave_NE_at_NE_4th_Stzx)
        Me.Controls.Add(Me.L112th_Ave_NE_at_NE_8th_Stzx)
        Me.Controls.Add(Me.LNE_12th_at_112th_AVE_NE)
        Me.Controls.Add(Me.LBellevue_Way_at_NE_4th_Stzx)
        Me.Controls.Add(Me.L110th_Ave_NE_at_Main)
        Me.Controls.Add(Me.L108th_Ave_NE_at_NE_4th_Stzx)
        Me.Controls.Add(Me.LNE_8th_at_116th_Ave_NE)
        Me.Controls.Add(Me.LBellevue_Way_at_NE_8th_Stzx)
        Me.Controls.Add(Me.L100th_Ave_NE_at_NE_4th_Stzx)
        Me.Controls.Add(Me.LSE_5th_St_at_116th_Ave_SE)
        Me.Controls.Add(Me.LLakes_Hillszz_116th_Ave_SE_at_Railroad)
        Me.Controls.Add(Me.LSE_8th_at_114th_Ave_NE)
        Me.Controls.Add(Me.LRichards_Rd_at_SE_32nd_Stzx)
        Me.Controls.Add(Me.LSE_28th_at_148th_Ave_NE)
        Me.Controls.Add(Me.L3600_Richards_Rd_Factoria_blvd)
        Me.Controls.Add(Me.Link)
        Me.Controls.Add(Me.MapLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Bellevue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Bellevue"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Link_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Link.LinkClicked
        MainViewerForm.MainForm.OpenLink("Bellevue")
    End Sub

    Private Sub Camera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L3600_Richards_Rd_Factoria_blvd.Click, _
    LRichards_Rd_at_SE_32nd_Stzx.Click, LSE_28th_at_148th_Ave_NE.Click, LSE_5th_St_at_116th_Ave_SE.Click, LLakes_Hillszz_116th_Ave_SE_at_Railroad.Click, _
    L108th_Ave_NE_at_NE_4th_Stzx.Click, LNE_8th_at_116th_Ave_NE.Click, LBellevue_Way_at_NE_8th_Stzx.Click, L100th_Ave_NE_at_NE_4th_Stzx.Click, _
    L112th_Ave_NE_at_NE_8th_Stzx.Click, LNE_12th_at_112th_AVE_NE.Click, LBellevue_Way_at_NE_4th_Stzx.Click, L110th_Ave_NE_at_Main.Click, _
    L110th_Ave_NE_at_NE_4th_Stzx.Click, LNE_4th_St_at_112th_Ave_NE.Click, L156th_Ave_NE_at_NE_8th.Click, L110th_at_NE_6th.Click, L148th_Ave_NE_at_NE_8th.Click, _
    LNorthup_Way_at_148th_Ave_NE.Click, LSE_8th_at_114th_Ave_NE.Click
        '
        MainViewerForm.MainForm.VScrollRoutes.Value = 11
        If Not MainViewerForm.MainForm.MapRegion = "NW" Then
            MainViewerForm.MainForm.SetNWRegion(MainViewerForm.MainForm.SRLabel_15)
        ElseIf Not MainViewerForm.MainForm.SRLabel Is MainViewerForm.MainForm.SRLabel_15 Then
            MainViewerForm.MainForm.StateRouteLabels_MouseDown(MainViewerForm.MainForm.SRLabel_15, Nothing)
        End If
        '
        'camera label names are the camera list names, with invalid label name chars changed
        'change invalid chars back to their original values
        'change  "_" to " "
        'change  "zz" to ":"
        'change  "zx" to "."
        'change  "zy" to "&"
        'change  "zL" to "("
        'change  "zR" to ")"
        'change  "zw" to "/"
        'change  "zv" to "-"
        'find the index of the camera label name, and select the camera image
        MainViewerForm.MainForm.CameraList.SelectedIndex = MainViewerForm.MainForm.CameraList.Items.IndexOf _
        (DirectCast(sender, Label).Name.Substring(1).Replace("_", " ").Replace _
        ("zv", "-").Replace("zw", "/").Replace("zx", ".").Replace("zL", "(").Replace _
        ("zR", ")").Replace("zy", "&").Replace("zz", ":"))
    End Sub

    Private Sub Bellevue_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Hide()
        e.Cancel = True
    End Sub
End Class
