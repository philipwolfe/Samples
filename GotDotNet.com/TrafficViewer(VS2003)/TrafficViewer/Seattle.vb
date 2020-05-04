Public Class Seattle
    Inherits System.Windows.Forms.Form
    Private SelectedCamera As New System.Text.StringBuilder

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
    Friend WithEvents LFauntleroy_Way_SW_and_SW_Alaska As System.Windows.Forms.Label
    Friend WithEvents L35th_Avenue_SW_and_Fauntleroy_Way_SW As System.Windows.Forms.Label
    Friend WithEvents L4th_Avenue_and_Atlantic As System.Windows.Forms.Label
    Friend WithEvents LRoyal_Brougham_at_Safeco_Field As System.Windows.Forms.Label
    Friend WithEvents L4th_Ave_S_at_Izv90_Ramps As System.Windows.Forms.Label
    Friend WithEvents LAurora_Avenue_N_and_145th_Street_Wzx As System.Windows.Forms.Label
    Friend WithEvents LNorthgate_Way_and_1st_Ave_NE As System.Windows.Forms.Label
    Friend WithEvents LAurora_Avenue_N_and_130th_Street_Szx As System.Windows.Forms.Label
    Friend WithEvents LAurora_Avenue_N_and_145th_Street_Ezx As System.Windows.Forms.Label
    Friend WithEvents LAurora_Ave_N_and_105th_St As System.Windows.Forms.Label
    Friend WithEvents LAurora_Ave_N_and_87th_St As System.Windows.Forms.Label
    Friend WithEvents LNorthgate_Way_and_5th_Ave_NE_East As System.Windows.Forms.Label
    Friend WithEvents LFairview_and_Valley_St As System.Windows.Forms.Label
    Friend WithEvents LAurora_Ave_and_Mercer_St As System.Windows.Forms.Label
    Friend WithEvents LAurora_Ave_N_and_Winona_Ave_N As System.Windows.Forms.Label
    Friend WithEvents LFairview_and_Mercer_St As System.Windows.Forms.Label
    Friend WithEvents LAurora_Ave_N_and_103rd_St As System.Windows.Forms.Label
    Friend WithEvents LNorthgate_Way_and_5th_Ave_NE As System.Windows.Forms.Label
    Friend WithEvents LAurora_Avenue_N_and_130th_Street_Nzx As System.Windows.Forms.Label
    Friend WithEvents LAurora_Ave_N_and_85th_St As System.Windows.Forms.Label
    Friend WithEvents LIzv5_NE_145th_Stzx As System.Windows.Forms.Label
    Friend WithEvents LIzv5_Northgate_Wy As System.Windows.Forms.Label
    Friend WithEvents LIzv5_Lake_City_Wy As System.Windows.Forms.Label
    Friend WithEvents LIzv5_NE_45th_Stzx As System.Windows.Forms.Label
    Friend WithEvents LIzv5_NE_85th As System.Windows.Forms.Label
    Friend WithEvents LIzv5_Pine As System.Windows.Forms.Label
    Friend WithEvents LIzv5_Roanoke As System.Windows.Forms.Label
    Friend WithEvents LIzv5_Mercer As System.Windows.Forms.Label
    Friend WithEvents LIzv5_zw_Izv90_IC As System.Windows.Forms.Label
    Friend WithEvents LIzv5_Yesler As System.Windows.Forms.Label
    Friend WithEvents LIzv90_Midspan As System.Windows.Forms.Label
    Friend WithEvents LIzv90_18th_Ave_Sozx As System.Windows.Forms.Label
    Friend WithEvents LIzv5_Sozx_Holgate As System.Windows.Forms.Label
    Friend WithEvents LAlaskan_Way_at_Royal_Brougham As System.Windows.Forms.Label
    Friend WithEvents LAlaskan_Way_at_Terminal_42 As System.Windows.Forms.Label
    Friend WithEvents LIzv5_Sozx_Spokane_Stzx As System.Windows.Forms.Label
    Friend WithEvents LHarbor_Island As System.Windows.Forms.Label
    Friend WithEvents LSRzv520_Midspan As System.Windows.Forms.Label
    Friend WithEvents LSRzv520_Montlake_Blvd As System.Windows.Forms.Label
    Friend WithEvents LIzv5_MidzvBoeing_Field As System.Windows.Forms.Label
    Friend WithEvents LIzv5_Albro_Pl As System.Windows.Forms.Label
    Friend WithEvents LSRzv99_Wzx_Marginal_Way As System.Windows.Forms.Label
    Friend WithEvents LSRzv99_at_Michigan_Stzx As System.Windows.Forms.Label
    Friend WithEvents LNorth_on_Montlake_Blvd_at_SRzv520 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Seattle))
        Me.Link = New System.Windows.Forms.LinkLabel
        Me.LAurora_Avenue_N_and_145th_Street_Wzx = New System.Windows.Forms.Label
        Me.LNorthgate_Way_and_1st_Ave_NE = New System.Windows.Forms.Label
        Me.LAurora_Avenue_N_and_130th_Street_Szx = New System.Windows.Forms.Label
        Me.LAurora_Avenue_N_and_145th_Street_Ezx = New System.Windows.Forms.Label
        Me.LAurora_Ave_N_and_105th_St = New System.Windows.Forms.Label
        Me.LAurora_Ave_N_and_87th_St = New System.Windows.Forms.Label
        Me.LNorthgate_Way_and_5th_Ave_NE_East = New System.Windows.Forms.Label
        Me.MapLabel = New System.Windows.Forms.Label
        Me.LFairview_and_Valley_St = New System.Windows.Forms.Label
        Me.LAurora_Ave_and_Mercer_St = New System.Windows.Forms.Label
        Me.LIzv5_NE_145th_Stzx = New System.Windows.Forms.Label
        Me.LSRzv520_Midspan = New System.Windows.Forms.Label
        Me.LIzv90_Midspan = New System.Windows.Forms.Label
        Me.LIzv5_Northgate_Wy = New System.Windows.Forms.Label
        Me.LIzv5_Lake_City_Wy = New System.Windows.Forms.Label
        Me.LIzv5_NE_45th_Stzx = New System.Windows.Forms.Label
        Me.LSRzv520_Montlake_Blvd = New System.Windows.Forms.Label
        Me.LIzv5_NE_85th = New System.Windows.Forms.Label
        Me.LIzv90_18th_Ave_Sozx = New System.Windows.Forms.Label
        Me.LIzv5_Sozx_Holgate = New System.Windows.Forms.Label
        Me.LNorth_on_Montlake_Blvd_at_SRzv520 = New System.Windows.Forms.Label
        Me.LIzv5_zw_Izv90_IC = New System.Windows.Forms.Label
        Me.LIzv5_Pine = New System.Windows.Forms.Label
        Me.LIzv5_Yesler = New System.Windows.Forms.Label
        Me.LAlaskan_Way_at_Royal_Brougham = New System.Windows.Forms.Label
        Me.LAlaskan_Way_at_Terminal_42 = New System.Windows.Forms.Label
        Me.LIzv5_Sozx_Spokane_Stzx = New System.Windows.Forms.Label
        Me.LHarbor_Island = New System.Windows.Forms.Label
        Me.LSRzv99_at_Michigan_Stzx = New System.Windows.Forms.Label
        Me.LSRzv99_Wzx_Marginal_Way = New System.Windows.Forms.Label
        Me.LIzv5_Albro_Pl = New System.Windows.Forms.Label
        Me.LIzv5_MidzvBoeing_Field = New System.Windows.Forms.Label
        Me.LIzv5_Roanoke = New System.Windows.Forms.Label
        Me.LIzv5_Mercer = New System.Windows.Forms.Label
        Me.LAurora_Ave_N_and_Winona_Ave_N = New System.Windows.Forms.Label
        Me.LFairview_and_Mercer_St = New System.Windows.Forms.Label
        Me.LAurora_Ave_N_and_103rd_St = New System.Windows.Forms.Label
        Me.LNorthgate_Way_and_5th_Ave_NE = New System.Windows.Forms.Label
        Me.LAurora_Avenue_N_and_130th_Street_Nzx = New System.Windows.Forms.Label
        Me.LAurora_Ave_N_and_85th_St = New System.Windows.Forms.Label
        Me.L4th_Avenue_and_Atlantic = New System.Windows.Forms.Label
        Me.LRoyal_Brougham_at_Safeco_Field = New System.Windows.Forms.Label
        Me.LFauntleroy_Way_SW_and_SW_Alaska = New System.Windows.Forms.Label
        Me.L4th_Ave_S_at_Izv90_Ramps = New System.Windows.Forms.Label
        Me.L35th_Avenue_SW_and_Fauntleroy_Way_SW = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Link
        '
        Me.Link.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Link.Location = New System.Drawing.Point(83, 11)
        Me.Link.Name = "Link"
        Me.Link.Size = New System.Drawing.Size(168, 24)
        Me.Link.TabIndex = 2
        Me.Link.TabStop = True
        Me.Link.Text = "Seattle Traffic Website"
        '
        'LAurora_Avenue_N_and_145th_Street_Wzx
        '
        Me.LAurora_Avenue_N_and_145th_Street_Wzx.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LAurora_Avenue_N_and_145th_Street_Wzx.Image = CType(resources.GetObject("LAurora_Avenue_N_and_145th_Street_Wzx.Image"), System.Drawing.Image)
        Me.LAurora_Avenue_N_and_145th_Street_Wzx.Location = New System.Drawing.Point(143, 52)
        Me.LAurora_Avenue_N_and_145th_Street_Wzx.Name = "LAurora_Avenue_N_and_145th_Street_Wzx"
        Me.LAurora_Avenue_N_and_145th_Street_Wzx.Size = New System.Drawing.Size(7, 9)
        Me.LAurora_Avenue_N_and_145th_Street_Wzx.TabIndex = 18
        '
        'LNorthgate_Way_and_1st_Ave_NE
        '
        Me.LNorthgate_Way_and_1st_Ave_NE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LNorthgate_Way_and_1st_Ave_NE.Image = CType(resources.GetObject("LNorthgate_Way_and_1st_Ave_NE.Image"), System.Drawing.Image)
        Me.LNorthgate_Way_and_1st_Ave_NE.Location = New System.Drawing.Point(174, 94)
        Me.LNorthgate_Way_and_1st_Ave_NE.Name = "LNorthgate_Way_and_1st_Ave_NE"
        Me.LNorthgate_Way_and_1st_Ave_NE.Size = New System.Drawing.Size(7, 9)
        Me.LNorthgate_Way_and_1st_Ave_NE.TabIndex = 17
        '
        'LAurora_Avenue_N_and_130th_Street_Szx
        '
        Me.LAurora_Avenue_N_and_130th_Street_Szx.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LAurora_Avenue_N_and_130th_Street_Szx.Image = CType(resources.GetObject("LAurora_Avenue_N_and_130th_Street_Szx.Image"), System.Drawing.Image)
        Me.LAurora_Avenue_N_and_130th_Street_Szx.Location = New System.Drawing.Point(144, 70)
        Me.LAurora_Avenue_N_and_130th_Street_Szx.Name = "LAurora_Avenue_N_and_130th_Street_Szx"
        Me.LAurora_Avenue_N_and_130th_Street_Szx.Size = New System.Drawing.Size(9, 7)
        Me.LAurora_Avenue_N_and_130th_Street_Szx.TabIndex = 16
        '
        'LAurora_Avenue_N_and_145th_Street_Ezx
        '
        Me.LAurora_Avenue_N_and_145th_Street_Ezx.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LAurora_Avenue_N_and_145th_Street_Ezx.Image = CType(resources.GetObject("LAurora_Avenue_N_and_145th_Street_Ezx.Image"), System.Drawing.Image)
        Me.LAurora_Avenue_N_and_145th_Street_Ezx.Location = New System.Drawing.Point(154, 52)
        Me.LAurora_Avenue_N_and_145th_Street_Ezx.Name = "LAurora_Avenue_N_and_145th_Street_Ezx"
        Me.LAurora_Avenue_N_and_145th_Street_Ezx.Size = New System.Drawing.Size(9, 7)
        Me.LAurora_Avenue_N_and_145th_Street_Ezx.TabIndex = 15
        '
        'LAurora_Ave_N_and_105th_St
        '
        Me.LAurora_Ave_N_and_105th_St.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LAurora_Ave_N_and_105th_St.Image = CType(resources.GetObject("LAurora_Ave_N_and_105th_St.Image"), System.Drawing.Image)
        Me.LAurora_Ave_N_and_105th_St.Location = New System.Drawing.Point(144, 104)
        Me.LAurora_Ave_N_and_105th_St.Name = "LAurora_Ave_N_and_105th_St"
        Me.LAurora_Ave_N_and_105th_St.Size = New System.Drawing.Size(9, 7)
        Me.LAurora_Ave_N_and_105th_St.TabIndex = 32
        '
        'LAurora_Ave_N_and_87th_St
        '
        Me.LAurora_Ave_N_and_87th_St.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LAurora_Ave_N_and_87th_St.Image = CType(resources.GetObject("LAurora_Ave_N_and_87th_St.Image"), System.Drawing.Image)
        Me.LAurora_Ave_N_and_87th_St.Location = New System.Drawing.Point(154, 128)
        Me.LAurora_Ave_N_and_87th_St.Name = "LAurora_Ave_N_and_87th_St"
        Me.LAurora_Ave_N_and_87th_St.Size = New System.Drawing.Size(7, 9)
        Me.LAurora_Ave_N_and_87th_St.TabIndex = 25
        '
        'LNorthgate_Way_and_5th_Ave_NE_East
        '
        Me.LNorthgate_Way_and_5th_Ave_NE_East.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LNorthgate_Way_and_5th_Ave_NE_East.Image = CType(resources.GetObject("LNorthgate_Way_and_5th_Ave_NE_East.Image"), System.Drawing.Image)
        Me.LNorthgate_Way_and_5th_Ave_NE_East.Location = New System.Drawing.Point(186, 99)
        Me.LNorthgate_Way_and_5th_Ave_NE_East.Name = "LNorthgate_Way_and_5th_Ave_NE_East"
        Me.LNorthgate_Way_and_5th_Ave_NE_East.Size = New System.Drawing.Size(9, 7)
        Me.LNorthgate_Way_and_5th_Ave_NE_East.TabIndex = 24
        '
        'MapLabel
        '
        Me.MapLabel.Image = CType(resources.GetObject("MapLabel.Image"), System.Drawing.Image)
        Me.MapLabel.Location = New System.Drawing.Point(3, 48)
        Me.MapLabel.Name = "MapLabel"
        Me.MapLabel.Size = New System.Drawing.Size(304, 510)
        Me.MapLabel.TabIndex = 57
        '
        'LFairview_and_Valley_St
        '
        Me.LFairview_and_Valley_St.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LFairview_and_Valley_St.Image = CType(resources.GetObject("LFairview_and_Valley_St.Image"), System.Drawing.Image)
        Me.LFairview_and_Valley_St.Location = New System.Drawing.Point(159, 277)
        Me.LFairview_and_Valley_St.Name = "LFairview_and_Valley_St"
        Me.LFairview_and_Valley_St.Size = New System.Drawing.Size(7, 9)
        Me.LFairview_and_Valley_St.TabIndex = 41
        '
        'LAurora_Ave_and_Mercer_St
        '
        Me.LAurora_Ave_and_Mercer_St.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LAurora_Ave_and_Mercer_St.Image = CType(resources.GetObject("LAurora_Ave_and_Mercer_St.Image"), System.Drawing.Image)
        Me.LAurora_Ave_and_Mercer_St.Location = New System.Drawing.Point(147, 283)
        Me.LAurora_Ave_and_Mercer_St.Name = "LAurora_Ave_and_Mercer_St"
        Me.LAurora_Ave_and_Mercer_St.Size = New System.Drawing.Size(9, 7)
        Me.LAurora_Ave_and_Mercer_St.TabIndex = 40
        '
        'LIzv5_NE_145th_Stzx
        '
        Me.LIzv5_NE_145th_Stzx.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LIzv5_NE_145th_Stzx.Image = CType(resources.GetObject("LIzv5_NE_145th_Stzx.Image"), System.Drawing.Image)
        Me.LIzv5_NE_145th_Stzx.Location = New System.Drawing.Point(186, 54)
        Me.LIzv5_NE_145th_Stzx.Name = "LIzv5_NE_145th_Stzx"
        Me.LIzv5_NE_145th_Stzx.Size = New System.Drawing.Size(10, 7)
        Me.LIzv5_NE_145th_Stzx.TabIndex = 59
        '
        'LSRzv520_Midspan
        '
        Me.LSRzv520_Midspan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LSRzv520_Midspan.Image = CType(resources.GetObject("LSRzv520_Midspan.Image"), System.Drawing.Image)
        Me.LSRzv520_Midspan.Location = New System.Drawing.Point(269, 265)
        Me.LSRzv520_Midspan.Name = "LSRzv520_Midspan"
        Me.LSRzv520_Midspan.Size = New System.Drawing.Size(10, 7)
        Me.LSRzv520_Midspan.TabIndex = 63
        '
        'LIzv90_Midspan
        '
        Me.LIzv90_Midspan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LIzv90_Midspan.Image = CType(resources.GetObject("LIzv90_Midspan.Image"), System.Drawing.Image)
        Me.LIzv90_Midspan.Location = New System.Drawing.Point(255, 367)
        Me.LIzv90_Midspan.Name = "LIzv90_Midspan"
        Me.LIzv90_Midspan.Size = New System.Drawing.Size(10, 7)
        Me.LIzv90_Midspan.TabIndex = 64
        '
        'LIzv5_Northgate_Wy
        '
        Me.LIzv5_Northgate_Wy.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LIzv5_Northgate_Wy.Image = CType(resources.GetObject("LIzv5_Northgate_Wy.Image"), System.Drawing.Image)
        Me.LIzv5_Northgate_Wy.Location = New System.Drawing.Point(161, 97)
        Me.LIzv5_Northgate_Wy.Name = "LIzv5_Northgate_Wy"
        Me.LIzv5_Northgate_Wy.Size = New System.Drawing.Size(10, 7)
        Me.LIzv5_Northgate_Wy.TabIndex = 66
        '
        'LIzv5_Lake_City_Wy
        '
        Me.LIzv5_Lake_City_Wy.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LIzv5_Lake_City_Wy.Image = CType(resources.GetObject("LIzv5_Lake_City_Wy.Image"), System.Drawing.Image)
        Me.LIzv5_Lake_City_Wy.Location = New System.Drawing.Point(189, 162)
        Me.LIzv5_Lake_City_Wy.Name = "LIzv5_Lake_City_Wy"
        Me.LIzv5_Lake_City_Wy.Size = New System.Drawing.Size(10, 7)
        Me.LIzv5_Lake_City_Wy.TabIndex = 76
        '
        'LIzv5_NE_45th_Stzx
        '
        Me.LIzv5_NE_45th_Stzx.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LIzv5_NE_45th_Stzx.Image = CType(resources.GetObject("LIzv5_NE_45th_Stzx.Image"), System.Drawing.Image)
        Me.LIzv5_NE_45th_Stzx.Location = New System.Drawing.Point(187, 208)
        Me.LIzv5_NE_45th_Stzx.Name = "LIzv5_NE_45th_Stzx"
        Me.LIzv5_NE_45th_Stzx.Size = New System.Drawing.Size(10, 7)
        Me.LIzv5_NE_45th_Stzx.TabIndex = 75
        '
        'LSRzv520_Montlake_Blvd
        '
        Me.LSRzv520_Montlake_Blvd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LSRzv520_Montlake_Blvd.Image = CType(resources.GetObject("LSRzv520_Montlake_Blvd.Image"), System.Drawing.Image)
        Me.LSRzv520_Montlake_Blvd.Location = New System.Drawing.Point(206, 229)
        Me.LSRzv520_Montlake_Blvd.Name = "LSRzv520_Montlake_Blvd"
        Me.LSRzv520_Montlake_Blvd.Size = New System.Drawing.Size(7, 10)
        Me.LSRzv520_Montlake_Blvd.TabIndex = 73
        '
        'LIzv5_NE_85th
        '
        Me.LIzv5_NE_85th.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LIzv5_NE_85th.Image = CType(resources.GetObject("LIzv5_NE_85th.Image"), System.Drawing.Image)
        Me.LIzv5_NE_85th.Location = New System.Drawing.Point(164, 132)
        Me.LIzv5_NE_85th.Name = "LIzv5_NE_85th"
        Me.LIzv5_NE_85th.Size = New System.Drawing.Size(10, 7)
        Me.LIzv5_NE_85th.TabIndex = 71
        '
        'LIzv90_18th_Ave_Sozx
        '
        Me.LIzv90_18th_Ave_Sozx.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LIzv90_18th_Ave_Sozx.Image = CType(resources.GetObject("LIzv90_18th_Ave_Sozx.Image"), System.Drawing.Image)
        Me.LIzv90_18th_Ave_Sozx.Location = New System.Drawing.Point(195, 356)
        Me.LIzv90_18th_Ave_Sozx.Name = "LIzv90_18th_Ave_Sozx"
        Me.LIzv90_18th_Ave_Sozx.Size = New System.Drawing.Size(10, 7)
        Me.LIzv90_18th_Ave_Sozx.TabIndex = 80
        '
        'LIzv5_Sozx_Holgate
        '
        Me.LIzv5_Sozx_Holgate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LIzv5_Sozx_Holgate.Image = CType(resources.GetObject("LIzv5_Sozx_Holgate.Image"), System.Drawing.Image)
        Me.LIzv5_Sozx_Holgate.Location = New System.Drawing.Point(172, 355)
        Me.LIzv5_Sozx_Holgate.Name = "LIzv5_Sozx_Holgate"
        Me.LIzv5_Sozx_Holgate.Size = New System.Drawing.Size(10, 7)
        Me.LIzv5_Sozx_Holgate.TabIndex = 82
        '
        'LNorth_on_Montlake_Blvd_at_SRzv520
        '
        Me.LNorth_on_Montlake_Blvd_at_SRzv520.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LNorth_on_Montlake_Blvd_at_SRzv520.Image = CType(resources.GetObject("LNorth_on_Montlake_Blvd_at_SRzv520.Image"), System.Drawing.Image)
        Me.LNorth_on_Montlake_Blvd_at_SRzv520.Location = New System.Drawing.Point(200, 220)
        Me.LNorth_on_Montlake_Blvd_at_SRzv520.Name = "LNorth_on_Montlake_Blvd_at_SRzv520"
        Me.LNorth_on_Montlake_Blvd_at_SRzv520.Size = New System.Drawing.Size(10, 7)
        Me.LNorth_on_Montlake_Blvd_at_SRzv520.TabIndex = 81
        '
        'LIzv5_zw_Izv90_IC
        '
        Me.LIzv5_zw_Izv90_IC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LIzv5_zw_Izv90_IC.Image = CType(resources.GetObject("LIzv5_zw_Izv90_IC.Image"), System.Drawing.Image)
        Me.LIzv5_zw_Izv90_IC.Location = New System.Drawing.Point(189, 332)
        Me.LIzv5_zw_Izv90_IC.Name = "LIzv5_zw_Izv90_IC"
        Me.LIzv5_zw_Izv90_IC.Size = New System.Drawing.Size(10, 7)
        Me.LIzv5_zw_Izv90_IC.TabIndex = 83
        '
        'LIzv5_Pine
        '
        Me.LIzv5_Pine.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LIzv5_Pine.Image = CType(resources.GetObject("LIzv5_Pine.Image"), System.Drawing.Image)
        Me.LIzv5_Pine.Location = New System.Drawing.Point(160, 292)
        Me.LIzv5_Pine.Name = "LIzv5_Pine"
        Me.LIzv5_Pine.Size = New System.Drawing.Size(10, 7)
        Me.LIzv5_Pine.TabIndex = 85
        '
        'LIzv5_Yesler
        '
        Me.LIzv5_Yesler.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LIzv5_Yesler.Image = CType(resources.GetObject("LIzv5_Yesler.Image"), System.Drawing.Image)
        Me.LIzv5_Yesler.Location = New System.Drawing.Point(178, 311)
        Me.LIzv5_Yesler.Name = "LIzv5_Yesler"
        Me.LIzv5_Yesler.Size = New System.Drawing.Size(10, 7)
        Me.LIzv5_Yesler.TabIndex = 84
        '
        'LAlaskan_Way_at_Royal_Brougham
        '
        Me.LAlaskan_Way_at_Royal_Brougham.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LAlaskan_Way_at_Royal_Brougham.Image = CType(resources.GetObject("LAlaskan_Way_at_Royal_Brougham.Image"), System.Drawing.Image)
        Me.LAlaskan_Way_at_Royal_Brougham.Location = New System.Drawing.Point(156, 349)
        Me.LAlaskan_Way_at_Royal_Brougham.Name = "LAlaskan_Way_at_Royal_Brougham"
        Me.LAlaskan_Way_at_Royal_Brougham.Size = New System.Drawing.Size(10, 7)
        Me.LAlaskan_Way_at_Royal_Brougham.TabIndex = 89
        '
        'LAlaskan_Way_at_Terminal_42
        '
        Me.LAlaskan_Way_at_Terminal_42.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LAlaskan_Way_at_Terminal_42.Image = CType(resources.GetObject("LAlaskan_Way_at_Terminal_42.Image"), System.Drawing.Image)
        Me.LAlaskan_Way_at_Terminal_42.Location = New System.Drawing.Point(158, 340)
        Me.LAlaskan_Way_at_Terminal_42.Name = "LAlaskan_Way_at_Terminal_42"
        Me.LAlaskan_Way_at_Terminal_42.Size = New System.Drawing.Size(10, 7)
        Me.LAlaskan_Way_at_Terminal_42.TabIndex = 88
        '
        'LIzv5_Sozx_Spokane_Stzx
        '
        Me.LIzv5_Sozx_Spokane_Stzx.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LIzv5_Sozx_Spokane_Stzx.Image = CType(resources.GetObject("LIzv5_Sozx_Spokane_Stzx.Image"), System.Drawing.Image)
        Me.LIzv5_Sozx_Spokane_Stzx.Location = New System.Drawing.Point(171, 383)
        Me.LIzv5_Sozx_Spokane_Stzx.Name = "LIzv5_Sozx_Spokane_Stzx"
        Me.LIzv5_Sozx_Spokane_Stzx.Size = New System.Drawing.Size(10, 7)
        Me.LIzv5_Sozx_Spokane_Stzx.TabIndex = 87
        '
        'LHarbor_Island
        '
        Me.LHarbor_Island.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LHarbor_Island.Image = CType(resources.GetObject("LHarbor_Island.Image"), System.Drawing.Image)
        Me.LHarbor_Island.Location = New System.Drawing.Point(136, 384)
        Me.LHarbor_Island.Name = "LHarbor_Island"
        Me.LHarbor_Island.Size = New System.Drawing.Size(10, 7)
        Me.LHarbor_Island.TabIndex = 86
        '
        'LSRzv99_at_Michigan_Stzx
        '
        Me.LSRzv99_at_Michigan_Stzx.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LSRzv99_at_Michigan_Stzx.Image = CType(resources.GetObject("LSRzv99_at_Michigan_Stzx.Image"), System.Drawing.Image)
        Me.LSRzv99_at_Michigan_Stzx.Location = New System.Drawing.Point(168, 434)
        Me.LSRzv99_at_Michigan_Stzx.Name = "LSRzv99_at_Michigan_Stzx"
        Me.LSRzv99_at_Michigan_Stzx.Size = New System.Drawing.Size(10, 7)
        Me.LSRzv99_at_Michigan_Stzx.TabIndex = 93
        '
        'LSRzv99_Wzx_Marginal_Way
        '
        Me.LSRzv99_Wzx_Marginal_Way.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LSRzv99_Wzx_Marginal_Way.Image = CType(resources.GetObject("LSRzv99_Wzx_Marginal_Way.Image"), System.Drawing.Image)
        Me.LSRzv99_Wzx_Marginal_Way.Location = New System.Drawing.Point(161, 442)
        Me.LSRzv99_Wzx_Marginal_Way.Name = "LSRzv99_Wzx_Marginal_Way"
        Me.LSRzv99_Wzx_Marginal_Way.Size = New System.Drawing.Size(10, 7)
        Me.LSRzv99_Wzx_Marginal_Way.TabIndex = 92
        '
        'LIzv5_Albro_Pl
        '
        Me.LIzv5_Albro_Pl.AllowDrop = True
        Me.LIzv5_Albro_Pl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LIzv5_Albro_Pl.Image = CType(resources.GetObject("LIzv5_Albro_Pl.Image"), System.Drawing.Image)
        Me.LIzv5_Albro_Pl.Location = New System.Drawing.Point(202, 434)
        Me.LIzv5_Albro_Pl.Name = "LIzv5_Albro_Pl"
        Me.LIzv5_Albro_Pl.Size = New System.Drawing.Size(10, 7)
        Me.LIzv5_Albro_Pl.TabIndex = 91
        '
        'LIzv5_MidzvBoeing_Field
        '
        Me.LIzv5_MidzvBoeing_Field.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LIzv5_MidzvBoeing_Field.Image = CType(resources.GetObject("LIzv5_MidzvBoeing_Field.Image"), System.Drawing.Image)
        Me.LIzv5_MidzvBoeing_Field.Location = New System.Drawing.Point(212, 446)
        Me.LIzv5_MidzvBoeing_Field.Name = "LIzv5_MidzvBoeing_Field"
        Me.LIzv5_MidzvBoeing_Field.Size = New System.Drawing.Size(10, 7)
        Me.LIzv5_MidzvBoeing_Field.TabIndex = 90
        '
        'LIzv5_Roanoke
        '
        Me.LIzv5_Roanoke.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LIzv5_Roanoke.Image = CType(resources.GetObject("LIzv5_Roanoke.Image"), System.Drawing.Image)
        Me.LIzv5_Roanoke.Location = New System.Drawing.Point(168, 242)
        Me.LIzv5_Roanoke.Name = "LIzv5_Roanoke"
        Me.LIzv5_Roanoke.Size = New System.Drawing.Size(10, 7)
        Me.LIzv5_Roanoke.TabIndex = 95
        '
        'LIzv5_Mercer
        '
        Me.LIzv5_Mercer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LIzv5_Mercer.Image = CType(resources.GetObject("LIzv5_Mercer.Image"), System.Drawing.Image)
        Me.LIzv5_Mercer.Location = New System.Drawing.Point(162, 268)
        Me.LIzv5_Mercer.Name = "LIzv5_Mercer"
        Me.LIzv5_Mercer.Size = New System.Drawing.Size(10, 7)
        Me.LIzv5_Mercer.TabIndex = 94
        '
        'LAurora_Ave_N_and_Winona_Ave_N
        '
        Me.LAurora_Ave_N_and_Winona_Ave_N.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LAurora_Ave_N_and_Winona_Ave_N.Image = CType(resources.GetObject("LAurora_Ave_N_and_Winona_Ave_N.Image"), System.Drawing.Image)
        Me.LAurora_Ave_N_and_Winona_Ave_N.Location = New System.Drawing.Point(150, 151)
        Me.LAurora_Ave_N_and_Winona_Ave_N.Name = "LAurora_Ave_N_and_Winona_Ave_N"
        Me.LAurora_Ave_N_and_Winona_Ave_N.Size = New System.Drawing.Size(7, 9)
        Me.LAurora_Ave_N_and_Winona_Ave_N.TabIndex = 103
        '
        'LFairview_and_Mercer_St
        '
        Me.LFairview_and_Mercer_St.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LFairview_and_Mercer_St.Image = CType(resources.GetObject("LFairview_and_Mercer_St.Image"), System.Drawing.Image)
        Me.LFairview_and_Mercer_St.Location = New System.Drawing.Point(168, 282)
        Me.LFairview_and_Mercer_St.Name = "LFairview_and_Mercer_St"
        Me.LFairview_and_Mercer_St.Size = New System.Drawing.Size(9, 7)
        Me.LFairview_and_Mercer_St.TabIndex = 102
        '
        'LAurora_Ave_N_and_103rd_St
        '
        Me.LAurora_Ave_N_and_103rd_St.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LAurora_Ave_N_and_103rd_St.Image = CType(resources.GetObject("LAurora_Ave_N_and_103rd_St.Image"), System.Drawing.Image)
        Me.LAurora_Ave_N_and_103rd_St.Location = New System.Drawing.Point(155, 108)
        Me.LAurora_Ave_N_and_103rd_St.Name = "LAurora_Ave_N_and_103rd_St"
        Me.LAurora_Ave_N_and_103rd_St.Size = New System.Drawing.Size(7, 9)
        Me.LAurora_Ave_N_and_103rd_St.TabIndex = 101
        '
        'LNorthgate_Way_and_5th_Ave_NE
        '
        Me.LNorthgate_Way_and_5th_Ave_NE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LNorthgate_Way_and_5th_Ave_NE.Image = CType(resources.GetObject("LNorthgate_Way_and_5th_Ave_NE.Image"), System.Drawing.Image)
        Me.LNorthgate_Way_and_5th_Ave_NE.Location = New System.Drawing.Point(177, 104)
        Me.LNorthgate_Way_and_5th_Ave_NE.Name = "LNorthgate_Way_and_5th_Ave_NE"
        Me.LNorthgate_Way_and_5th_Ave_NE.Size = New System.Drawing.Size(7, 9)
        Me.LNorthgate_Way_and_5th_Ave_NE.TabIndex = 99
        '
        'LAurora_Avenue_N_and_130th_Street_Nzx
        '
        Me.LAurora_Avenue_N_and_130th_Street_Nzx.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LAurora_Avenue_N_and_130th_Street_Nzx.Image = CType(resources.GetObject("LAurora_Avenue_N_and_130th_Street_Nzx.Image"), System.Drawing.Image)
        Me.LAurora_Avenue_N_and_130th_Street_Nzx.Location = New System.Drawing.Point(155, 67)
        Me.LAurora_Avenue_N_and_130th_Street_Nzx.Name = "LAurora_Avenue_N_and_130th_Street_Nzx"
        Me.LAurora_Avenue_N_and_130th_Street_Nzx.Size = New System.Drawing.Size(7, 9)
        Me.LAurora_Avenue_N_and_130th_Street_Nzx.TabIndex = 97
        '
        'LAurora_Ave_N_and_85th_St
        '
        Me.LAurora_Ave_N_and_85th_St.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LAurora_Ave_N_and_85th_St.Image = CType(resources.GetObject("LAurora_Ave_N_and_85th_St.Image"), System.Drawing.Image)
        Me.LAurora_Ave_N_and_85th_St.Location = New System.Drawing.Point(142, 132)
        Me.LAurora_Ave_N_and_85th_St.Name = "LAurora_Ave_N_and_85th_St"
        Me.LAurora_Ave_N_and_85th_St.Size = New System.Drawing.Size(9, 7)
        Me.LAurora_Ave_N_and_85th_St.TabIndex = 96
        '
        'L4th_Avenue_and_Atlantic
        '
        Me.L4th_Avenue_and_Atlantic.Cursor = System.Windows.Forms.Cursors.Hand
        Me.L4th_Avenue_and_Atlantic.Image = CType(resources.GetObject("L4th_Avenue_and_Atlantic.Image"), System.Drawing.Image)
        Me.L4th_Avenue_and_Atlantic.Location = New System.Drawing.Point(181, 346)
        Me.L4th_Avenue_and_Atlantic.Name = "L4th_Avenue_and_Atlantic"
        Me.L4th_Avenue_and_Atlantic.Size = New System.Drawing.Size(9, 7)
        Me.L4th_Avenue_and_Atlantic.TabIndex = 120
        '
        'LRoyal_Brougham_at_Safeco_Field
        '
        Me.LRoyal_Brougham_at_Safeco_Field.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LRoyal_Brougham_at_Safeco_Field.Image = CType(resources.GetObject("LRoyal_Brougham_at_Safeco_Field.Image"), System.Drawing.Image)
        Me.LRoyal_Brougham_at_Safeco_Field.Location = New System.Drawing.Point(170, 346)
        Me.LRoyal_Brougham_at_Safeco_Field.Name = "LRoyal_Brougham_at_Safeco_Field"
        Me.LRoyal_Brougham_at_Safeco_Field.Size = New System.Drawing.Size(9, 7)
        Me.LRoyal_Brougham_at_Safeco_Field.TabIndex = 119
        '
        'LFauntleroy_Way_SW_and_SW_Alaska
        '
        Me.LFauntleroy_Way_SW_and_SW_Alaska.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LFauntleroy_Way_SW_and_SW_Alaska.Image = CType(resources.GetObject("LFauntleroy_Way_SW_and_SW_Alaska.Image"), System.Drawing.Image)
        Me.LFauntleroy_Way_SW_and_SW_Alaska.Location = New System.Drawing.Point(94, 408)
        Me.LFauntleroy_Way_SW_and_SW_Alaska.Name = "LFauntleroy_Way_SW_and_SW_Alaska"
        Me.LFauntleroy_Way_SW_and_SW_Alaska.Size = New System.Drawing.Size(9, 7)
        Me.LFauntleroy_Way_SW_and_SW_Alaska.TabIndex = 116
        '
        'L4th_Ave_S_at_Izv90_Ramps
        '
        Me.L4th_Ave_S_at_Izv90_Ramps.Cursor = System.Windows.Forms.Cursors.Hand
        Me.L4th_Ave_S_at_Izv90_Ramps.Image = CType(resources.GetObject("L4th_Ave_S_at_Izv90_Ramps.Image"), System.Drawing.Image)
        Me.L4th_Ave_S_at_Izv90_Ramps.Location = New System.Drawing.Point(173, 337)
        Me.L4th_Ave_S_at_Izv90_Ramps.Name = "L4th_Ave_S_at_Izv90_Ramps"
        Me.L4th_Ave_S_at_Izv90_Ramps.Size = New System.Drawing.Size(9, 7)
        Me.L4th_Ave_S_at_Izv90_Ramps.TabIndex = 115
        '
        'L35th_Avenue_SW_and_Fauntleroy_Way_SW
        '
        Me.L35th_Avenue_SW_and_Fauntleroy_Way_SW.Cursor = System.Windows.Forms.Cursors.Hand
        Me.L35th_Avenue_SW_and_Fauntleroy_Way_SW.Image = CType(resources.GetObject("L35th_Avenue_SW_and_Fauntleroy_Way_SW.Image"), System.Drawing.Image)
        Me.L35th_Avenue_SW_and_Fauntleroy_Way_SW.Location = New System.Drawing.Point(104, 398)
        Me.L35th_Avenue_SW_and_Fauntleroy_Way_SW.Name = "L35th_Avenue_SW_and_Fauntleroy_Way_SW"
        Me.L35th_Avenue_SW_and_Fauntleroy_Way_SW.Size = New System.Drawing.Size(9, 7)
        Me.L35th_Avenue_SW_and_Fauntleroy_Way_SW.TabIndex = 121
        '
        'Seattle
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(309, 560)
        Me.Controls.Add(Me.L35th_Avenue_SW_and_Fauntleroy_Way_SW)
        Me.Controls.Add(Me.L4th_Avenue_and_Atlantic)
        Me.Controls.Add(Me.LRoyal_Brougham_at_Safeco_Field)
        Me.Controls.Add(Me.LFauntleroy_Way_SW_and_SW_Alaska)
        Me.Controls.Add(Me.L4th_Ave_S_at_Izv90_Ramps)
        Me.Controls.Add(Me.LAurora_Ave_N_and_Winona_Ave_N)
        Me.Controls.Add(Me.LFairview_and_Mercer_St)
        Me.Controls.Add(Me.LAurora_Ave_N_and_103rd_St)
        Me.Controls.Add(Me.LNorthgate_Way_and_5th_Ave_NE)
        Me.Controls.Add(Me.LAurora_Avenue_N_and_130th_Street_Nzx)
        Me.Controls.Add(Me.LAurora_Ave_N_and_85th_St)
        Me.Controls.Add(Me.LIzv5_Roanoke)
        Me.Controls.Add(Me.LIzv5_Mercer)
        Me.Controls.Add(Me.LSRzv99_at_Michigan_Stzx)
        Me.Controls.Add(Me.LSRzv99_Wzx_Marginal_Way)
        Me.Controls.Add(Me.LIzv5_Albro_Pl)
        Me.Controls.Add(Me.LIzv5_MidzvBoeing_Field)
        Me.Controls.Add(Me.LAlaskan_Way_at_Royal_Brougham)
        Me.Controls.Add(Me.LAlaskan_Way_at_Terminal_42)
        Me.Controls.Add(Me.LIzv5_Sozx_Spokane_Stzx)
        Me.Controls.Add(Me.LHarbor_Island)
        Me.Controls.Add(Me.LIzv5_Pine)
        Me.Controls.Add(Me.LIzv5_Yesler)
        Me.Controls.Add(Me.LIzv5_zw_Izv90_IC)
        Me.Controls.Add(Me.LIzv5_Sozx_Holgate)
        Me.Controls.Add(Me.LNorth_on_Montlake_Blvd_at_SRzv520)
        Me.Controls.Add(Me.LIzv90_18th_Ave_Sozx)
        Me.Controls.Add(Me.LIzv5_Lake_City_Wy)
        Me.Controls.Add(Me.LIzv5_NE_45th_Stzx)
        Me.Controls.Add(Me.LSRzv520_Montlake_Blvd)
        Me.Controls.Add(Me.LIzv5_NE_85th)
        Me.Controls.Add(Me.LIzv5_Northgate_Wy)
        Me.Controls.Add(Me.LIzv90_Midspan)
        Me.Controls.Add(Me.LSRzv520_Midspan)
        Me.Controls.Add(Me.LIzv5_NE_145th_Stzx)
        Me.Controls.Add(Me.LFairview_and_Valley_St)
        Me.Controls.Add(Me.LAurora_Ave_and_Mercer_St)
        Me.Controls.Add(Me.LAurora_Ave_N_and_105th_St)
        Me.Controls.Add(Me.LAurora_Ave_N_and_87th_St)
        Me.Controls.Add(Me.LNorthgate_Way_and_5th_Ave_NE_East)
        Me.Controls.Add(Me.LAurora_Avenue_N_and_145th_Street_Wzx)
        Me.Controls.Add(Me.LNorthgate_Way_and_1st_Ave_NE)
        Me.Controls.Add(Me.LAurora_Avenue_N_and_130th_Street_Szx)
        Me.Controls.Add(Me.LAurora_Avenue_N_and_145th_Street_Ezx)
        Me.Controls.Add(Me.Link)
        Me.Controls.Add(Me.MapLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Seattle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Seattle"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Link_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles Link.LinkClicked
        MainViewerForm.MainForm.OpenLink("Seattle")
    End Sub

    Private Sub CityCamera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles LFauntleroy_Way_SW_and_SW_Alaska.Click, L35th_Avenue_SW_and_Fauntleroy_Way_SW.Click, LHarbor_Island.Click, _
    L4th_Avenue_and_Atlantic.Click, LRoyal_Brougham_at_Safeco_Field.Click, L4th_Ave_S_at_Izv90_Ramps.Click, _
    LAurora_Avenue_N_and_145th_Street_Wzx.Click, LNorthgate_Way_and_1st_Ave_NE.Click, LAurora_Ave_N_and_85th_St.Click, _
    LAurora_Avenue_N_and_130th_Street_Szx.Click, LAurora_Avenue_N_and_145th_Street_Ezx.Click, LNorth_on_Montlake_Blvd_at_SRzv520.Click, _
    LAurora_Ave_N_and_105th_St.Click, LAurora_Ave_N_and_87th_St.Click, LNorthgate_Way_and_5th_Ave_NE_East.Click, _
    LFairview_and_Valley_St.Click, LAurora_Ave_and_Mercer_St.Click, LAurora_Ave_N_and_Winona_Ave_N.Click, _
    LFairview_and_Mercer_St.Click, LAurora_Ave_N_and_103rd_St.Click, LNorthgate_Way_and_5th_Ave_NE.Click, _
    LAurora_Avenue_N_and_130th_Street_Nzx.Click, LAlaskan_Way_at_Royal_Brougham.Click, LAlaskan_Way_at_Terminal_42.Click
        '
        MainViewerForm.MainForm.VScrollRoutes.Value = 11
        If Not MainViewerForm.MainForm.MapRegion = "NW" Then
            MainViewerForm.MainForm.SetNWRegion(MainViewerForm.MainForm.SRLabel_14)
        ElseIf Not MainViewerForm.MainForm.SRLabel Is MainViewerForm.MainForm.SRLabel_14 Then
            MainViewerForm.MainForm.StateRouteLabels_MouseDown(MainViewerForm.MainForm.SRLabel_14, Nothing)
        End If
        '
        'find the index of the camera label name, and select the camera image
        MainViewerForm.MainForm.CameraList.SelectedIndex = MainViewerForm.MainForm.CameraList.Items.IndexOf _
        (DirectCast(sender, Label).Name.Substring(1).Replace("_", " ").Replace _
        ("zv", "-").Replace("zw", "/").Replace("zx", ".").Replace("zL", "(").Replace _
        ("zR", ")").Replace("zy", "&").Replace("zz", ":"))
    End Sub

    Private Sub StateCamera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LIzv5_NE_145th_Stzx.Click, LIzv5_Lake_City_Wy.Click, LIzv5_NE_45th_Stzx.Click, LIzv5_NE_85th.Click, LIzv5_Pine.Click, LIzv5_Roanoke.Click, LIzv5_Mercer.Click, LIzv5_zw_Izv90_IC.Click, LIzv5_Yesler.Click, LIzv90_Midspan.Click, LIzv90_18th_Ave_Sozx.Click, LIzv5_Sozx_Holgate.Click, LIzv5_Sozx_Spokane_Stzx.Click, LIzv5_Northgate_Wy.Click, LSRzv520_Midspan.Click, LSRzv520_Montlake_Blvd.Click, LIzv5_MidzvBoeing_Field.Click, LIzv5_Albro_Pl.Click, LSRzv99_Wzx_Marginal_Way.Click, LSRzv99_at_Michigan_Stzx.Click
        MainViewerForm.MainForm.VScrollRoutes.Value = 0
        SelectedCamera.Remove(0, SelectedCamera.Length)
        SelectedCamera.Append(DirectCast(sender, Label).Name.Substring(1).Replace("_", " ").Replace("zv", "-").Replace _
         ("zw", "/").Replace("zx", ".").Replace("zL", "(").Replace("zR", ")").Replace("zy", "&").Replace("zz", ":"))
        Select Case Not -1
            Case SelectedCamera.ToString.IndexOf("I-5")
                ' MainForm.VScrollRoutes.Value = 11
                If Not MainViewerForm.MainForm.MapRegion = "NW" Then
                    MainViewerForm.MainForm.SetNWRegion(MainViewerForm.MainForm.SRLabel_0)
                ElseIf Not MainViewerForm.MainForm.SRLabel Is MainViewerForm.MainForm.SRLabel_0 Then
                    MainViewerForm.MainForm.StateRouteLabels_MouseDown(MainViewerForm.MainForm.SRLabel_0, Nothing)
                End If
            Case SelectedCamera.ToString.IndexOf("SR-520")
                If Not MainViewerForm.MainForm.MapRegion = "NW" Then
                    MainViewerForm.MainForm.SetNWRegion(MainViewerForm.MainForm.SRLabel_6)
                ElseIf Not MainViewerForm.MainForm.SRLabel Is MainViewerForm.MainForm.SRLabel_6 Then
                    MainViewerForm.MainForm.StateRouteLabels_MouseDown(MainViewerForm.MainForm.SRLabel_6, Nothing)
                End If
            Case SelectedCamera.ToString.IndexOf("SR-99")
                If Not MainViewerForm.MainForm.MapRegion = "NW" Then
                    MainViewerForm.MainForm.SetNWRegion(MainViewerForm.MainForm.SRLabel_3)
                ElseIf Not MainViewerForm.MainForm.SRLabel Is MainViewerForm.MainForm.SRLabel_3 Then
                    MainViewerForm.MainForm.StateRouteLabels_MouseDown(MainViewerForm.MainForm.SRLabel_3, Nothing)
                End If
            Case SelectedCamera.ToString.IndexOf("I-90")
                If Not MainViewerForm.MainForm.MapRegion = "NW" Then
                    MainViewerForm.MainForm.SetNWRegion(MainViewerForm.MainForm.SRLabel_1)
                ElseIf Not MainViewerForm.MainForm.SRLabel Is MainViewerForm.MainForm.SRLabel_1 Then
                    MainViewerForm.MainForm.StateRouteLabels_MouseDown(MainViewerForm.MainForm.SRLabel_1, Nothing)
                End If
            Case Else
                If Not MainViewerForm.MainForm.MapRegion = "NW" Then
                    MainViewerForm.MainForm.SetNWRegion(MainViewerForm.MainForm.SRLabel_0)
                ElseIf Not MainViewerForm.MainForm.SRLabel Is MainViewerForm.MainForm.SRLabel_0 Then
                    MainViewerForm.MainForm.StateRouteLabels_MouseDown(MainViewerForm.MainForm.SRLabel_0, Nothing)
                End If
        End Select
        Set_CameraList_Index(SelectedCamera.ToString)
    End Sub

    Private Sub Set_CameraList_Index(ByVal SelectedCamera As String)
        If MainViewerForm.MainForm.CameraList.FindString(SelectedCamera) > -1 Then
            MainViewerForm.MainForm.CameraList.SelectedIndex = MainViewerForm.MainForm.CameraList.FindString(SelectedCamera)
        Else
            MessageBox.Show("Unable to Auto-locate: " & SelectedCamera, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Seattle_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Hide()
        e.Cancel = True
    End Sub
End Class
