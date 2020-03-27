Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Reflection
Imports System.Resources
Imports System.Windows.Forms

Public Class IconMenuItem : Inherits MenuItem

    Private m_Icon As Icon
    Private m_Font As Font
    ' By default these are set to the SystemColors Highight and Control values.
    ' This allows the appropriate color to be displayed if the user changes 
    ' themes or display settings.
    ' These can be overriden by calling the appropriate constructor for this 
    ' class.
    Private m_Gradient_Color1 As Color = SystemColors.Highlight
    Private m_Gradient_Color2 As Color = SystemColors.Control

    Public Sub New()
        MyClass.New("", Nothing, Nothing, System.Windows.Forms.Shortcut.None)
    End Sub

    Public Sub New(ByVal text As String, ByVal icon As Icon, ByVal onClick As EventHandler, ByVal shortcut As Shortcut)
        MyBase.New(text, onClick, shortcut)
        ' Owner Draw Property allows you to modify the menu item by handling
        ' OnMeasureItem and OnDrawItem
        OwnerDraw = True
        m_Font = New Font("Times New Roman", 8)
        m_Icon = icon
    End Sub

    ' Additional constructor allows the setting of custom colors for each part of the menu
    ' color gradient.
    Public Sub New(ByVal text As String, ByVal GradientColor1 As System.Drawing.Color, ByVal GradientColor2 As System.Drawing.Color, ByVal icon As Icon, ByVal onClick As EventHandler, ByVal shortcut As Shortcut)
        MyBase.New(text, onClick, shortcut)
        ' Key Property
        OwnerDraw = True
        m_Font = New Font("Times New Roman", 8)
        m_Gradient_Color1 = GradientColor1
        m_Gradient_Color2 = GradientColor2
        m_Icon = icon
    End Sub

    Private Function GetRealText() As String
        Dim s As String = Text

        ' Append shortcut if one is set and it should be visible
        If ShowShortcut And Shortcut <> Shortcut.None Then
            ' To get a string representation of a Shortcut value, cast
            ' it into a Keys value and use the KeysConverter class (via TypeDescriptor).
            Dim k As Keys = CType(Shortcut, Keys)
            s = s & Convert.ToChar(9) & TypeDescriptor.GetConverter(GetType(Keys)).ConvertToString(k)
        End If

        Return s
    End Function


    Protected Overrides Sub OnDrawItem(ByVal e As DrawItemEventArgs)
        ' OnDrawItem perfoms the task of actually drawing the item after
        ' measurement is complete
        MyBase.OnDrawItem(e)

        Dim br As Brush

        If Not m_Icon Is Nothing Then
            e.Graphics.DrawIcon(m_Icon, e.Bounds.Left + 2, e.Bounds.Top + 2)
        End If

        Dim rcBk As Rectangle = e.Bounds
        rcBk.X += 22

        ' Draw a background to the menu item with a linear gradient.
        ' This will use system defaults unless colors and have been
        ' passed on menu item instantiation
        If CBool(e.State And DrawItemState.Selected) Then
            br = New LinearGradientBrush(rcBk, m_Gradient_Color1, m_Gradient_Color2, 0)
        Else
            br = SystemBrushes.Control
        End If

        ' Draw the main rectangle
        e.Graphics.FillRectangle(br, rcBk)

        ' Leave room for accelerator key
        Dim sf As StringFormat = New StringFormat()
        sf.HotkeyPrefix = HotkeyPrefix.Show

        ' Draw the actual menu text
        br = New SolidBrush(e.ForeColor)
        e.Graphics.DrawString(GetRealText(), m_Font, br, e.Bounds.Left + 25, e.Bounds.Top + 2, sf)

    End Sub

    Protected Overrides Sub OnMeasureItem(ByVal e As MeasureItemEventArgs)
        ' The MeasureItem event along with the OnDrawItem event are the two key events
        ' that need to be handled in order to create owner drawn menus.
        ' Measure the string that makes up a given menu item and use it to set the 
        ' size of the menu item being drawn.

        Dim sf As New StringFormat()
        sf.HotkeyPrefix = HotkeyPrefix.Show
        MyBase.OnMeasureItem(e)
        e.ItemHeight = 22
        e.ItemWidth = CInt(e.Graphics.MeasureString(GetRealText(), m_Font, 10000, sf).Width) + 10

    End Sub


End Class