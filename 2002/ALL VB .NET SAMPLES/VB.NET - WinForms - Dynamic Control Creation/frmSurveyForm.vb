Option Explicit On 

' This class represents a Survey form.  However, all of the 
'   controls are added dynamically in code.
Public Class frmSurveyForm
    Inherits System.Windows.Forms.Form

    ' Create necessary private variables to hold information.
    Private m_Title As String = "Survey"
    Private m_SurveyResponse As String = "Survey Not Completed"

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
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSurveyForm))
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.AccessibleDescription = resources.GetString("btnOK.AccessibleDescription")
        Me.btnOK.AccessibleName = resources.GetString("btnOK.AccessibleName")
        Me.btnOK.Anchor = CType(resources.GetObject("btnOK.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnOK.BackgroundImage = CType(resources.GetObject("btnOK.BackgroundImage"), System.Drawing.Image)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Dock = CType(resources.GetObject("btnOK.Dock"), System.Windows.Forms.DockStyle)
        Me.btnOK.Enabled = CType(resources.GetObject("btnOK.Enabled"), Boolean)
        Me.btnOK.FlatStyle = CType(resources.GetObject("btnOK.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnOK.Font = CType(resources.GetObject("btnOK.Font"), System.Drawing.Font)
        Me.btnOK.Image = CType(resources.GetObject("btnOK.Image"), System.Drawing.Image)
        Me.btnOK.ImageAlign = CType(resources.GetObject("btnOK.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnOK.ImageIndex = CType(resources.GetObject("btnOK.ImageIndex"), Integer)
        Me.btnOK.ImeMode = CType(resources.GetObject("btnOK.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnOK.Location = CType(resources.GetObject("btnOK.Location"), System.Drawing.Point)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.RightToLeft = CType(resources.GetObject("btnOK.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnOK.Size = CType(resources.GetObject("btnOK.Size"), System.Drawing.Size)
        Me.btnOK.TabIndex = CType(resources.GetObject("btnOK.TabIndex"), Integer)
        Me.btnOK.Text = resources.GetString("btnOK.Text")
        Me.btnOK.TextAlign = CType(resources.GetObject("btnOK.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnOK.Visible = CType(resources.GetObject("btnOK.Visible"), Boolean)
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleDescription = resources.GetString("btnCancel.AccessibleDescription")
        Me.btnCancel.AccessibleName = resources.GetString("btnCancel.AccessibleName")
        Me.btnCancel.Anchor = CType(resources.GetObject("btnCancel.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackgroundImage = CType(resources.GetObject("btnCancel.BackgroundImage"), System.Drawing.Image)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Dock = CType(resources.GetObject("btnCancel.Dock"), System.Windows.Forms.DockStyle)
        Me.btnCancel.Enabled = CType(resources.GetObject("btnCancel.Enabled"), Boolean)
        Me.btnCancel.FlatStyle = CType(resources.GetObject("btnCancel.FlatStyle"), System.Windows.Forms.FlatStyle)
        Me.btnCancel.Font = CType(resources.GetObject("btnCancel.Font"), System.Drawing.Font)
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = CType(resources.GetObject("btnCancel.ImageAlign"), System.Drawing.ContentAlignment)
        Me.btnCancel.ImageIndex = CType(resources.GetObject("btnCancel.ImageIndex"), Integer)
        Me.btnCancel.ImeMode = CType(resources.GetObject("btnCancel.ImeMode"), System.Windows.Forms.ImeMode)
        Me.btnCancel.Location = CType(resources.GetObject("btnCancel.Location"), System.Drawing.Point)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = CType(resources.GetObject("btnCancel.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.btnCancel.Size = CType(resources.GetObject("btnCancel.Size"), System.Drawing.Size)
        Me.btnCancel.TabIndex = CType(resources.GetObject("btnCancel.TabIndex"), Integer)
        Me.btnCancel.Text = resources.GetString("btnCancel.Text")
        Me.btnCancel.TextAlign = CType(resources.GetObject("btnCancel.TextAlign"), System.Drawing.ContentAlignment)
        Me.btnCancel.Visible = CType(resources.GetObject("btnCancel.Visible"), Boolean)
        '
        'frmSurveyForm
        '
        Me.AccessibleDescription = CType(resources.GetObject("$this.AccessibleDescription"), String)
        Me.AccessibleName = CType(resources.GetObject("$this.AccessibleName"), String)
        Me.Anchor = CType(resources.GetObject("$this.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.AutoScaleBaseSize = CType(resources.GetObject("$this.AutoScaleBaseSize"), System.Drawing.Size)
        Me.AutoScroll = CType(resources.GetObject("$this.AutoScroll"), Boolean)
        Me.AutoScrollMargin = CType(resources.GetObject("$this.AutoScrollMargin"), System.Drawing.Size)
        Me.AutoScrollMinSize = CType(resources.GetObject("$this.AutoScrollMinSize"), System.Drawing.Size)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = CType(resources.GetObject("$this.ClientSize"), System.Drawing.Size)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancel, Me.btnOK})
        Me.Dock = CType(resources.GetObject("$this.Dock"), System.Windows.Forms.DockStyle)
        Me.Enabled = CType(resources.GetObject("$this.Enabled"), Boolean)
        Me.Font = CType(resources.GetObject("$this.Font"), System.Drawing.Font)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = CType(resources.GetObject("$this.ImeMode"), System.Windows.Forms.ImeMode)
        Me.Location = CType(resources.GetObject("$this.Location"), System.Drawing.Point)
        Me.MaximumSize = CType(resources.GetObject("$this.MaximumSize"), System.Drawing.Size)
        Me.MinimumSize = CType(resources.GetObject("$this.MinimumSize"), System.Drawing.Size)
        Me.Name = "frmSurveyForm"
        Me.RightToLeft = CType(resources.GetObject("$this.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.StartPosition = CType(resources.GetObject("$this.StartPosition"), System.Windows.Forms.FormStartPosition)
        Me.Text = resources.GetString("$this.Text")
        Me.Visible = CType(resources.GetObject("$this.Visible"), Boolean)
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Create a property so the controls can be easily retrieved.
    Public ReadOnly Property SurveyFormControls() As Control.ControlCollection
        Get
            Return Me.Controls
        End Get
    End Property

    ' Create a height property so height can be changed easily.
    Public Property SurveyHeight() As Integer
        Get
            Return Me.Height
        End Get
        Set(ByVal Value As Integer)
            Me.Height = Value
        End Set
    End Property

    ' Create a property so the response can be easily retrieved.
    Public ReadOnly Property SurveyResponse() As String
        Get
            Return m_SurveyResponse
        End Get
    End Property

    ' Create a property so the title of the form can be easily
    '   retrieved and set.
    Public Property SurveyTitle() As String
        Get
            Return m_Title
        End Get
        Set(ByVal Value As String)
            m_Title = Value
            Me.Text = m_Title
        End Set
    End Property

    ' Create a width property so width can be changed easily.
    Public Property SurveyWidth() As Integer
        Get
            Return Me.Width
        End Get
        Set(ByVal Value As Integer)
            Me.Width = Value
        End Set
    End Property

    ' This simply resets the SurveyResponse string and closes the form.
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        ' Reset the SurveyResponse string.
        m_SurveyResponse = "Survey Not Completed"

        ' Close the form.
        Me.Close()
    End Sub

    ' This button first fills out the SurveyResponse string then closes the form.
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        ' Create the controls we'll be using in all of the later loops.
        Dim myControl As Control
        Dim myGroupControl As Control
        Dim myGroupBox As GroupBox
        Dim myObject As Object
        Dim myRadio As RadioButton

        ' Reset the Response string
        Me.m_SurveyResponse = ""

        ' Loop through each control and output the user response into the
        '   the SurveyResponse string. (The string could easily be replaced
        '   with a collection of some sort.)
        For Each myControl In Me.Controls
            ' Differentiate output based on the type of the control
            Select Case TypeName(myControl)
                Case "ComboBox"
                    ' Simple get the text out of the group box and add it to the
                    '   response string, along with the question name
                    m_SurveyResponse += myControl.Name + " - "
                    m_SurveyResponse += myControl.Text
                    m_SurveyResponse += vbCrLf
                Case "TextBox"
                    ' Simple get the text out of the group box and add it to the
                    '   response string, along with the question name
                    m_SurveyResponse += myControl.Name + " - "
                    m_SurveyResponse += myControl.Text
                    m_SurveyResponse += vbCrLf
                Case "GroupBox"
                    ' Need to go inside of the GroupBox to yank out the 
                    '   RadioButtons
                    For Each myGroupControl In CType(myControl, GroupBox).Controls
                        If TypeOf myGroupControl Is RadioButton Then
                            If CType(myGroupControl, RadioButton).Checked Then
                                ' Simple get the question and response of the 
                                '   user being surveyed.
                                m_SurveyResponse += myControl.Name + " - "
                                m_SurveyResponse += myGroupControl.Text
                                m_SurveyResponse += vbCrLf
                            End If
                        End If

                    Next
                Case "ListBox"
                    ' For this one we must get each of the selected lines, and 
                    '   return them.
                    m_SurveyResponse += myControl.Name + " - "
                    For Each myObject In CType(myControl, ListBox).SelectedItems
                        If TypeOf myObject Is String Then
                            ' Simple get the question and response of the 
                            '   user being surveyed.
                            m_SurveyResponse += vbTab + CStr(myObject)
                            m_SurveyResponse += vbCrLf
                        End If
                    Next
            End Select
        Next

        ' Close the form.
        Me.Close()
    End Sub

End Class
