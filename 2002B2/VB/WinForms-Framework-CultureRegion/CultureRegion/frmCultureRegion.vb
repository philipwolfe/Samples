Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Globalization


Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New

        Form1 = Me

        'This call is required by the Win Form Designer.
        InitializeComponent

        'TODO: Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents btnCultureRegion As System.Windows.Forms.Button

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnCultureRegion = New System.Windows.Forms.Button()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        btnCultureRegion.Location = New System.Drawing.Point(24, 32)
        btnCultureRegion.Size = New System.Drawing.Size(112, 24)
        btnCultureRegion.TabIndex = 0
        btnCultureRegion.Text = "CultureRegion"
        Me.Text = "CultureRegion"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(192, 93)

        Me.Controls.Add(btnCultureRegion)
    End Sub

#End Region

    Protected Sub btnCultureRegion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCultureRegion.click

        'set the culture to English - US and retrieve the information
        Dim Culture As CultureInfo
        Dim ReturnVal As String
        Culture = New CultureInfo("en-us")

        ReturnVal = "The CultureInfo is set to: " & Culture.DisplayName & Chr(10)
        ReturnVal = ReturnVal & "The parent culture is: " & Culture.Parent.DisplayName & Chr(10)
        ReturnVal = ReturnVal & "The three leter ISO language name is: " & Culture.ThreeLetterISOLanguageName & Chr(10)
        ReturnVal = ReturnVal & "The default calendar for this culture is: " & Culture.Calendar.ToString() & Chr(10)
        ReturnVal = ReturnVal & Chr(10)

        Dim Region As RegionInfo
        Region = New RegionInfo("us")
        ReturnVal = ReturnVal & "The name of this region is: " & Region.Name & Chr(10)
        ReturnVal = ReturnVal & "The currency symbol for the region is: " & Region.CurrencySymbol & Chr(10)
        ReturnVal = ReturnVal & "Is this region metric : " & Region.IsMetric & Chr(10)
        ReturnVal = ReturnVal & Chr(10)

        'Set the Culture to German - Switzerland and retrieve the information
        Dim Culture2 As CultureInfo
        Culture2 = New CultureInfo("de-ch")
        ReturnVal = ReturnVal & "The CultureInfo is set to: " & Culture2.DisplayName & Chr(10)
        ReturnVal = ReturnVal & "The parent culture is: " & Culture2.Parent.DisplayName & Chr(10)
        ReturnVal = ReturnVal & "The three leter ISO language name is:" & Culture2.ThreeLetterISOLanguageName & Chr(10)
        ReturnVal = ReturnVal & "The default calendar for this culture is: " & Culture2.Calendar.ToString() & Chr(10)
        ReturnVal = ReturnVal & Chr(10)

        Dim Region2 As RegionInfo
        Region2 = New RegionInfo("de")
        ReturnVal = ReturnVal & "The name of this region is: " & Region2.Name & Chr(10)
        ReturnVal = ReturnVal & "The currency symbol for the region is: " & Region2.CurrencySymbol & Chr(10)
        ReturnVal = ReturnVal & "Is this region metric : " & Region2.IsMetric & Chr(10)

        MessageBox.Show(ReturnVal, "CultureRegion Information")
    End Sub

End Class
