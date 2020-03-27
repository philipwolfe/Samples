' Copyright (C) 2002 Microsoft Corporation
' All rights reserved.
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
' EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
' MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

' Requires the Trial or Release version of Visual Studio .NET Professional 2003 (or greater).

Option Strict On

Imports System.IO ' Used to work with Streams
Imports System.Net ' Used for client-side of HTTP communication

Public Class frmMain
	Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

	Public Sub New()
		MyBase.New()

		' This call is required by the Windows Form Designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call

		' So that we only need to set the title of the application once,
		' we use the AssemblyInfo class (defined in the AssemblyInfo.vb file)
		' to read the AssemblyTitle attribute.
		Dim ainfo As New AssemblyInfo()

		Me.Text = ainfo.Title
		Me.mnuAbout.Text = String.Format("&About {0} ...", ainfo.Title)

	End Sub

	' Form overrides dispose to clean up the component list.
	Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If Not (components Is Nothing) Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub

	' Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	' NOTE: The following procedure is required by the Windows Form Designer
	' It can be modified using the Windows Form Designer.  
	' Do not modify it using the code editor.
	Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
	Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
	Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
	Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
	Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
	Friend WithEvents cmdSendFileData As System.Windows.Forms.Button
	Friend WithEvents cmdReceiveDataFile As System.Windows.Forms.Button
	Friend WithEvents cmdReceiveImageFile As System.Windows.Forms.Button
	Friend WithEvents picDownloadImage As System.Windows.Forms.PictureBox
	Friend WithEvents txtDataPassed As System.Windows.Forms.TextBox
	Friend WithEvents lblDataToPass As System.Windows.Forms.Label
	Friend WithEvents grpSendFiles As System.Windows.Forms.GroupBox
	Friend WithEvents grpPassText As System.Windows.Forms.GroupBox
	Friend WithEvents cmdPassText As System.Windows.Forms.Button
	Friend WithEvents lblDataReturned As System.Windows.Forms.Label
	Friend WithEvents txtDataReturned As System.Windows.Forms.TextBox
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.mnuMain = New System.Windows.Forms.MainMenu()
		Me.mnuFile = New System.Windows.Forms.MenuItem()
		Me.mnuExit = New System.Windows.Forms.MenuItem()
		Me.mnuHelp = New System.Windows.Forms.MenuItem()
		Me.mnuAbout = New System.Windows.Forms.MenuItem()
		Me.grpSendFiles = New System.Windows.Forms.GroupBox()
		Me.cmdReceiveImageFile = New System.Windows.Forms.Button()
		Me.cmdReceiveDataFile = New System.Windows.Forms.Button()
		Me.cmdSendFileData = New System.Windows.Forms.Button()
		Me.picDownloadImage = New System.Windows.Forms.PictureBox()
		Me.grpPassText = New System.Windows.Forms.GroupBox()
		Me.lblDataReturned = New System.Windows.Forms.Label()
		Me.txtDataReturned = New System.Windows.Forms.TextBox()
		Me.lblDataToPass = New System.Windows.Forms.Label()
		Me.txtDataPassed = New System.Windows.Forms.TextBox()
		Me.cmdPassText = New System.Windows.Forms.Button()
		Me.grpSendFiles.SuspendLayout()
		Me.grpPassText.SuspendLayout()
		Me.SuspendLayout()
		' 
		' mnuMain
		' 
		Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuHelp})
		' 
		' mnuFile
		' 
		Me.mnuFile.Index = 0
		Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuExit})
		Me.mnuFile.Text = "&File"
		' 
		' mnuExit
		' 
		Me.mnuExit.Index = 0
		Me.mnuExit.Text = "E&xit"
		' 
		' mnuHelp
		' 
		Me.mnuHelp.Index = 1
		Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAbout})
		Me.mnuHelp.Text = "&Help"
		' 
		' mnuAbout
		' 
		Me.mnuAbout.Index = 0
		Me.mnuAbout.Text = "Text Comes from AssemblyInfo"
		' 
		' grpSendFiles
		' 
		Me.grpSendFiles.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdReceiveImageFile, Me.cmdReceiveDataFile, Me.cmdSendFileData})
		Me.grpSendFiles.Location = New System.Drawing.Point(16, 16)
		Me.grpSendFiles.Name = "grpSendFiles"
		Me.grpSendFiles.Size = New System.Drawing.Size(232, 120)
		Me.grpSendFiles.TabIndex = 0
		Me.grpSendFiles.TabStop = False
		Me.grpSendFiles.Text = "S&ending and Receiving data files"
		' 
		' cmdReceiveImageFile
		' 
		Me.cmdReceiveImageFile.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.cmdReceiveImageFile.Location = New System.Drawing.Point(16, 88)
		Me.cmdReceiveImageFile.Name = "cmdReceiveImageFile"
		Me.cmdReceiveImageFile.Size = New System.Drawing.Size(200, 24)
		Me.cmdReceiveImageFile.TabIndex = 3
		Me.cmdReceiveImageFile.Text = "Receiving &Image using HTTP"
		' 
		' cmdReceiveDataFile
		' 
		Me.cmdReceiveDataFile.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.cmdReceiveDataFile.Location = New System.Drawing.Point(16, 56)
		Me.cmdReceiveDataFile.Name = "cmdReceiveDataFile"
		Me.cmdReceiveDataFile.Size = New System.Drawing.Size(200, 24)
		Me.cmdReceiveDataFile.TabIndex = 2
		Me.cmdReceiveDataFile.Text = "Receiving &Data in file using HTTP"
		' 
		' cmdSendFileData
		' 
		Me.cmdSendFileData.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.cmdSendFileData.Location = New System.Drawing.Point(16, 24)
		Me.cmdSendFileData.Name = "cmdSendFileData"
		Me.cmdSendFileData.Size = New System.Drawing.Size(200, 24)
		Me.cmdSendFileData.TabIndex = 1
		Me.cmdSendFileData.Text = "&Send Data in file using HTTP"
		' 
		' picDownloadImage
		' 
		Me.picDownloadImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.picDownloadImage.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.picDownloadImage.Location = New System.Drawing.Point(280, 24)
		Me.picDownloadImage.Name = "picDownloadImage"
		Me.picDownloadImage.Size = New System.Drawing.Size(136, 112)
		Me.picDownloadImage.TabIndex = 5
		Me.picDownloadImage.TabStop = False
		' 
		' grpPassText
		' 
		Me.grpPassText.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDataReturned, Me.txtDataReturned, Me.lblDataToPass, Me.txtDataPassed, Me.cmdPassText})
		Me.grpPassText.Location = New System.Drawing.Point(16, 144)
		Me.grpPassText.Name = "grpPassText"
		Me.grpPassText.Size = New System.Drawing.Size(400, 216)
		Me.grpPassText.TabIndex = 4
		Me.grpPassText.TabStop = False
		Me.grpPassText.Text = "P&assing data directly"
		' 
		' lblDataReturned
		' 
		Me.lblDataReturned.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblDataReturned.Location = New System.Drawing.Point(16, 144)
		Me.lblDataReturned.Name = "lblDataReturned"
		Me.lblDataReturned.Size = New System.Drawing.Size(152, 16)
		Me.lblDataReturned.TabIndex = 8
		Me.lblDataReturned.Text = "Data &Returned"
		' 
		' txtDataReturned
		' 
		Me.txtDataReturned.Location = New System.Drawing.Point(16, 160)
		Me.txtDataReturned.Multiline = True
		Me.txtDataReturned.Name = "txtDataReturned"
		Me.txtDataReturned.ReadOnly = True
		Me.txtDataReturned.Size = New System.Drawing.Size(360, 48)
		Me.txtDataReturned.TabIndex = 9
		Me.txtDataReturned.Text = ""
		' 
		' lblDataToPass
		' 
		Me.lblDataToPass.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.lblDataToPass.Location = New System.Drawing.Point(16, 64)
		Me.lblDataToPass.Name = "lblDataToPass"
		Me.lblDataToPass.Size = New System.Drawing.Size(152, 16)
		Me.lblDataToPass.TabIndex = 6
		Me.lblDataToPass.Text = "Data to &Pass"
		' 
		' txtDataPassed
		' 
		Me.txtDataPassed.Location = New System.Drawing.Point(16, 80)
		Me.txtDataPassed.Multiline = True
		Me.txtDataPassed.Name = "txtDataPassed"
		Me.txtDataPassed.Size = New System.Drawing.Size(360, 48)
		Me.txtDataPassed.TabIndex = 7
		Me.txtDataPassed.Text = "<type data here>"
		' 
		' cmdPassText
		' 
		Me.cmdPassText.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.cmdPassText.Location = New System.Drawing.Point(16, 24)
		Me.cmdPassText.Name = "cmdPassText"
		Me.cmdPassText.Size = New System.Drawing.Size(200, 24)
		Me.cmdPassText.TabIndex = 5
		Me.cmdPassText.Text = "Pass &Text Using HTTP"
		' 
		' frmMain
		' 
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(434, 379)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpPassText, Me.picDownloadImage, Me.grpSendFiles})
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.Menu = Me.mnuMain
		Me.Name = "frmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Title Comes from Assembly Info"
		Me.grpSendFiles.ResumeLayout(False)
		Me.grpPassText.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

#End Region

#Region " Standard Menu Code "
	' <System.Diagnostics.DebuggerStepThrough()> has been added to some procedures since they are
	' not the focus of the demo. Remove them if you wish to debug the procedures.
	' This code simply shows the About form.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
		' Open the About form in Dialog Mode
		Dim frm As New frmAbout()
		frm.ShowDialog(Me)
		frm.Dispose()
	End Sub

	' This code will close the form.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
		' Close the current form
		Me.Close()
	End Sub
#End Region

	Private Sub cmdPassText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPassText.Click
		' This method sends and receives text to/from a website. Some text 
		' is streamed in both directions using the RequestStream of the 
		' WebRequest class and the ResponseStream of the WebResponse class, 
		' Respectively. The stream access is wrapped in Try/Catch blocks 
		' to ensure timely release of the resources.

		Dim req As WebRequest
		Dim rsp As WebResponse

		Try
			' Setup the WebRequest instance
			req = WebRequest.Create("http://localhost/VDir1/PassText.aspx")

			' Use POST since we' re sending data
			req.Method = "POST"

			' Wrap the request stream with a text-based writer
			Dim sw As New StreamWriter(req.GetRequestStream())

			' Write the text from the textbox into the stream
			sw.WriteLine(txtDataPassed.Text())
			sw.Close()

			' Send the text to the webserver
			rsp = req.GetResponse()

			' Wrap the response stream with a text-based reader
			Dim sr As New StreamReader(rsp.GetResponseStream())

			' Read the returned text into a textbox
			txtDataReturned.Text = sr.ReadLine()

			MessageBox.Show("Passing text completed successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

		Catch exp As Exception
			' Will catch any error that we're not explicitly trapping.
			MessageBox.Show(exp.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

		Finally
			Try
				' Guarantee the streams will be closed
				If Not req Is Nothing Then req.GetRequestStream().Close()
				If Not rsp Is Nothing Then rsp.GetResponseStream().Close()
			Catch
				' Eat the error if we get one
			End Try
		End Try
	End Sub

	Private Sub cmdReceiveDataFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReceiveDataFile.Click
		' This method requests and receives an XML file from a website.
		' The file is streamed back to this method, which copies the contents
		' into a local file named ReceivedXMLFile.xml. The contents are streamed
		' using the ResponseStream of the WebResponse class. The stream access
		' is wrapped in Try/Catch blocks to ensure timely release of the 
		' resources.

        Dim strMsg As String = "In order to run this part of the sample, you must adjust the security settings" & _
        " for the physical directory that contains the ASPX files." & vbCrLf & vbCrLf & _
        "Please see the ReadMe.htm file for more information." & vbCrLf & _
        "Also see the source code (for the procedure cmdReceiveImageFile_Click) to remove this warning after the security settings have been adjusted."

        Dim fs As FileStream    ' To access the local file
        Dim req As WebRequest
        Dim stm As Stream
        Dim sr As StreamReader

		Try
			' This sets up the Request instance
            req = WebRequest.Create("http://localhost/SendAndReceiveDataWebPages/ReceiveData.aspx")

            ' Use a GET since no data is being sent to the web server
            req.Method = "GET"

            ' This causes the round-trip
            Dim rsp As WebResponse = req.GetResponse()

            Try
                ' Open the file to stream in the content
                fs = New FileStream("ReceivedXMLFile.xml", FileMode.Create)


                ' Copy the content from the response stream to the file.
                CopyData(rsp.GetResponseStream(), fs)

            Catch exp As Exception
                ' Will catch any error that we're not explicitly trapping.
                MessageBox.Show(exp.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Finally

                ' Guarantee the streams will be closed
                If Not rsp Is Nothing Then rsp.GetResponseStream.Close()
                If Not fs Is Nothing Then fs.Close()


            End Try

            MessageBox.Show("Receive of data file completed successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch exp As Exception
            ' Will catch any error that we're not explicitly trapping.
            MessageBox.Show(exp.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub cmdReceiveImageFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReceiveImageFile.Click
        ' This method requests and receives an image from a website. The file 
        ' is streamed back to this method, which copies the contents into a 
        ' MemoryStream, then associates the MemoryStream with a PictureBox on 
        ' the form. The contents are streamed using the ResponseStream of the 
        ' WebResponse class. The stream access is wrapped in Try/Catch blocks 
        ' to ensure timely release of the resources.

        Dim strMsg As String = "In order to run this part of the sample, you must adjust the security settings" & _
         " for the physical directory that contains the ASPX files." & vbCrLf & vbCrLf & _
         "Please see the ReadMe.htm file for more information." & vbCrLf & _
         "Also see the source code (for the procedure cmdReceiveImageFile_Click) to remove this warning after the security settings have been adjusted."

        Dim req As WebRequest   ' used to get the stream back from the server
        Dim ms As MemoryStream   ' used to move the image into the PictureBox

        Try
            ' You could use the following line listed below *IF* you knew the name & location
            ' of the image. The example provided here has the server 'pick' the image.
            ' req = WebRequest.Create("http://localhost/vDir1/mypic.jpg")

            ' This creates the WebRequest object
            req = WebRequest.Create("http://localhost/SendAndReceiveDataWebPages/ReceiveImage.aspx")
            ' Use a GET since we' re not sending any data
            req.Method = "GET"

            ' ObjRef to get the server's response.
            Dim rsp As WebResponse

            Try
                ' This causes the round-trip to retrieve the image.
                rsp = req.GetResponse()

                ' Create a MemoryStream to hold the image
                ms = New MemoryStream()

                ' Copy the streamed image into the MemoryStream
                CopyData(rsp.GetResponseStream(), ms)

                ' Load the image into the PictureBox
                picDownloadImage.Image = Image.FromStream(ms)

                MessageBox.Show("Image file received successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch exp As Exception
                ' Will catch any error that we're not explicitly trapping.
                MessageBox.Show(exp.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Finally

                ' Guarantee the streams will be closed
                If Not ms Is Nothing Then ms.Close()
                If Not rsp Is Nothing Then rsp.GetResponseStream.Close()

            End Try

        Catch exp As Exception
            ' Will catch any error that we're not explicitly trapping.
            MessageBox.Show(exp.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub cmdSendFileData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSendFileData.Click
        ' This method takes a local file named datafile.txt and sends its 
        ' contents via a WebRequest to a website. The contents are sent via
        ' HTTP using the Request stream of the WebRequest object. The file
        ' is accessed using a FileStream.

        Dim strMsg As String = "In order to run this part of the sample, you must adjust the security settings" & _
         " for the physical directory that contains the ASPX files." & vbCrLf & vbCrLf & _
         "Please see the ReadMe.htm file for more information." & vbCrLf & _
         "Also see the source code (for the procedure cmdSendFileData_Click) to remove this warning after the security settings have been adjusted."

        Dim fs As FileStream    ' To access the local file
        Dim req As WebRequest    ' Reference to the Webrequest

        ' Wrap the stream access in a Try/Finally block to guarantee a timely 
        ' release of the stream resources.
        Try
            ' Access the file
            fs = New FileStream("datafile.txt", FileMode.Open)

            ' Create the WebRequest instance
            req = WebRequest.Create("http://localhost/SendAndReceiveDataWebPages/SendData.aspx")

            ' Use POST since we're sending content in the body.
            req.Method = "POST"

            ' Copy from the file into the RequestStream
            CopyData(fs, req.GetRequestStream())

        Catch exp As Exception
            MessageBox.Show(exp.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            Try
                ' Guarantee the streams will be closed
                If Not req Is Nothing Then req.GetRequestStream.Close()
                If Not fs Is Nothing Then fs.Close()
            Catch
                ' Eat the error if we get one
            End Try
        End Try

        Dim rsp As WebResponse
        Try
            ' This actually sends the data to the Web Server
            rsp = req.GetResponse()

            If CType(rsp.Headers("Content-Length"), Double) = 0 Then
                MessageBox.Show("Data Sent Sucessfully.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch exp As Exception
            MessageBox.Show(exp.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Try
                If Not rsp Is Nothing Then
                    rsp.Close()
                End If
            Catch

            End Try
        End Try
    End Sub

    Private Sub CopyData(ByVal FromStream As Stream, ByVal ToStream As Stream)
        ' This routine copies content from one stream to another, regardless
        ' of the media represented by the stream.

        ' This will track the # bytes read from the FromStream
        Dim intBytesRead As Integer

        ' The maximum size of each read
        Const intSize As Integer = 4096
        Dim bytes(intSize) As Byte

        ' Read the first bit of content, then write and read all the content
        ' From the FromStream to the ToStream.
        intBytesRead = FromStream.Read(bytes, 0, intSize)
        While intBytesRead > 0
            ToStream.Write(bytes, 0, intBytesRead)
            intBytesRead = FromStream.Read(bytes, 0, intSize)
        End While
    End Sub

End Class