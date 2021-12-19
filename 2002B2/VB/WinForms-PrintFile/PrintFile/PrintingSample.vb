Imports System
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO

Namespace Microsoft.Samples.Windows.Forms.VB.PrintingExample1

    Public Class PrintingExample1
        Inherits System.Windows.Forms.Form

        Private printFont As Font
        Private streamToPrint As StreamReader

        Public Sub New()

            MyBase.New()

            PrintingExample1 = Me

            'This call is required by the Win Form Designer.
            InitializeComponent()

            'TODO: Add any initialization after the InitializeComponent() call

        End Sub


        'Event fired when the user presses the print button
        Private Sub printButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles printButton.click

            Try
                streamToPrint = New StreamReader("PrintMe.Txt")
                Try
                    printFont = New Font("Arial", 10)
                    Dim pd As New PrintDocument() 'Assumes the default printer
                    AddHandler pd.PrintPage, AddressOf Me.pd_PrintPage
                    'AddHandler pd.PrintPage, New System.Drawing.Printing.PrintPageEventHandler(AddressOf Me.pd_PrintPage)
                    pd.Print()
                Finally
                    streamToPrint.Close()
                End Try

            Catch ex As Exception
                MessageBox.Show("An error occurred printing the file - " + ex.Message)
            End Try

        End Sub

        'Event fired for each page to print
        Private Sub pd_PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)

            Dim lpp As Single = 0
            Dim yPos As Single = 0
            Dim count As Integer = 0
            Dim leftMargin As Single = ev.MarginBounds.Left
            Dim topMargin As Single = ev.MarginBounds.Top
            Dim line As String

            'Work out the number of lines per page 
            'Use the MarginBounds on the event to do this
            lpp = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics)

            'Now iterate through the file printing out each line
            'NOTE WELL: This assumes that a single line is not wider than the page width
            'Check count first so that we don't read line that we won't print
            line = streamToPrint.ReadLine()
            While (count < lpp And (Not (line Is Nothing)))

                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics))

                'NOTE WELL: In the PDC Release you must pass a StringFormat to DrawString or the 
                'Print Preview control will not work. 
                ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, New StringFormat())

                count = count + 1

                If (count < lpp) Then
                    line = streamToPrint.ReadLine()
                End If

            End While

            'If we have more lines then print another page
            If Not (line Is Nothing) Then
                ev.HasMorePages = True
            Else
                ev.HasMorePages = False
            End If
            MsgBox("ere")
        End Sub

        'Form overrides dispose to clean up the component list.
        Public Overloads Overrides Sub Dispose()
            MyBase.Dispose()

        End Sub

#Region " Windows Form Designer generated code "

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.Container
        Private WithEvents printButton As System.Windows.Forms.Button

        Private WithEvents PrintingExample1 As System.Windows.Forms.Form

        ' NOTE: The following code is required by the Windows Forms Designer
        ' Do not modify it 
        Private Sub InitializeComponent()
            Me.printButton = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'printButton
            '
            Me.printButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.printButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.printButton.Location = New System.Drawing.Point(32, 112)
            Me.printButton.Name = "printButton"
            Me.printButton.Size = New System.Drawing.Size(136, 40)
            Me.printButton.TabIndex = 0
            Me.printButton.Text = "Print the file"
            '
            'PrintingExample1
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(504, 381)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.printButton})
            Me.Name = "PrintingExample1"
            Me.Text = "Print Example 1"
            Me.ResumeLayout(False)

        End Sub

#End Region


        'The main entry point for the application
        <STAThread()> Shared Sub Main()
            System.Windows.Forms.Application.Run(New PrintingExample1())
        End Sub

End Class

End Namespace






