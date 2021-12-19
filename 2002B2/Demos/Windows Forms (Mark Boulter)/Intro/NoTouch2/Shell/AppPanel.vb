Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Collections
Imports System.Reflection

    'AppPanel is a control starter in the lh pane
    Public class AppPanel 
        Inherits Panel
        
        Private MyParent  as IAppOwningControl
        Private MyControl as UserControl
    Private MyFormInfo As localhost.FormInfo

        Private WithEvents DescLabel As Label
        Private WithEvents TopBarPanel As Panel
        Private WithEvents NameLabel As Label
        Private WithEvents Filler1 As Label
        Private WithEvents ActivateButton As Button
        
        
    Public Sub New(ByVal parentControl As IAppOwningControl, ByVal formInfo As localhost.FormInfo)
        MyBase.New()

        MyParent = parentControl
        MyFormInfo = formInfo

        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.BackColor = SystemColors.ControlLight
        Me.DockPadding.All = 5

        CreateControls()

        NameLabel.Text = MyFormInfo.Name
        DescLabel.Text = MyFormInfo.Description


    End Sub

    Private Sub ActivateButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ActivateButton.Click

        If (MyControl Is Nothing) Then
            Dim formAsm As [Assembly] = [Assembly].LoadFrom(Me.MyFormInfo.UrlLocation + Me.MyFormInfo.AssemblyName)
            Dim formtype As Type = formAsm.GetType(Me.MyFormInfo.TypeName)

            Dim FormObj As Object
            FormObj = Activator.CreateInstance(formtype)
            MyControl = CType(FormObj, UserControl)
            MyParent.AddPanel(MyControl)
        Else
            MyParent.ShowPanel(MyControl)
        End If

    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal pevent As PaintEventArgs)
        MyBase.OnPaintBackground(pevent)
        Dim reg As New [Region](Me.ClientRectangle)
        Dim nonPaintRect As New Rectangle(Me.ClientRectangle.Location, Me.ClientRectangle.Size)
        nonPaintRect.Inflate(-2, -2)
        reg.Exclude(nonPaintRect)
        pevent.Graphics.FillRegion(New SolidBrush(SystemColors.ControlDark), reg)
    End Sub

    Private Sub CreateControls()


        DescLabel = New Label()
        TopBarPanel = New Panel()
        NameLabel = New Label()
        Filler1 = New Label()
        ActivateButton = New Button()

        ActivateButton.Location = New Point(275, 2)
        ActivateButton.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        ActivateButton.Size = New Size(14, 18)
        ActivateButton.FlatStyle = FlatStyle.Popup
        'Dim backgroundImage As Image = new Bitmap(gettype(Main), "arrow.bmp")
        'ActivateButton.Image = BackgroundImage
        ActivateButton.BackColor = Color.DarkGray
        ActivateButton.Text = ">"


        DescLabel.Location = New Point(0, 46)
        DescLabel.Size = New Size(292, 227)
        DescLabel.Dock = DockStyle.Fill
        DescLabel.TabIndex = 2

        TopBarPanel.Text = ""
        TopBarPanel.Size = New Size(292, 23)
        TopBarPanel.Dock = DockStyle.Top
        TopBarPanel.TabIndex = 1
        TopBarPanel.BackColor = SystemColors.Control
        TopBarPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D

        NameLabel.Location = New Point(0, 23)
        NameLabel.Size = New Size(292, 23)
        NameLabel.Dock = DockStyle.Fill
        NameLabel.TabIndex = 0
        NameLabel.Font = New Font("Verdana", 8!, System.Drawing.FontStyle.Bold)

        Filler1.Location = New Point(0, 23)
        Filler1.Text = ""
        Filler1.Size = New Size(292, 2)
        Filler1.Dock = DockStyle.Top
        Filler1.TabIndex = 0

        Me.Controls.Add(DescLabel)
        Me.Controls.Add(TopBarPanel)
        TopBarPanel.Controls.Add(ActivateButton)
        TopBarPanel.Controls.Add(NameLabel)
        TopBarPanel.Controls.Add(Filler1)

    End Sub


End Class
        


