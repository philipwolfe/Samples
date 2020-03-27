Imports System.IO

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.driveReadyStatus.Text = ""

        'Get a DriveInfo object for each drive on the system
        Dim drives As System.IO.DriveInfo() = System.IO.DriveInfo.GetDrives

        'Populate the drives combo box with all drives
        drivesOnPc.Items.AddRange(drives)
    End Sub

    Private Sub Form1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint

        ' Rectangle to define size of Pie Chart
        Dim rect As Rectangle = New Rectangle(370, 20, 200, 200)

        ' Rectangle to use as a border around Pie Chart
        Dim rect2 As Rectangle = New Rectangle(310, 10, 320, 320)

        ' Rectangles for color legend
        Dim freeLegend As Rectangle = New Rectangle(315, 275, 20, 20)
        Dim usedLegend As Rectangle = New Rectangle(315, 300, 20, 20)

        e.Graphics.DrawRectangle(Pens.Black, rect2)

        If isSpaceInfoAvailable = True Then

            ' Draw Pie Chart
            e.Graphics.FillPie(Brushes.Green, rect, 0, sweep)
            e.Graphics.FillPie(Brushes.Red, rect, sweep, 360 - sweep)

            ' Draw Legend
            e.Graphics.FillRectangle(Brushes.Green, freeLegend)
            e.Graphics.FillRectangle(Brushes.Red, usedLegend)

            ' Add text
            e.Graphics.DrawString("Capacity:", New Font("Tahoma", 10, FontStyle.Regular), Brushes.Black, New PointF(350, 230))
            e.Graphics.DrawString("Used Space:", New Font("Tahoma", 10, FontStyle.Regular), Brushes.Black, New PointF(335, 275))
            e.Graphics.DrawString("Free Space:", New Font("Tahoma", 10, FontStyle.Regular), Brushes.Black, New PointF(335, 300))
            e.Graphics.DrawString(totalSpace.ToString("N") + " bytes", New Font("Tahoma", 10, FontStyle.Regular), Brushes.Black, New PointF(420, 230))
            e.Graphics.DrawString(usedSpace.ToString("N") + " bytes", New Font("Tahoma", 10, FontStyle.Regular), Brushes.Black, New PointF(420, 275))
            e.Graphics.DrawString(freeSpace.ToString("N") + " bytes", New Font("Tahoma", 10, FontStyle.Regular), Brushes.Black, New PointF(420, 300))
        End If
    End Sub

    Private Sub drivesOnPc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drivesOnPc.SelectedIndexChanged

        ' Determine drive info for selected drive letter
        LoadDriveInfo(drivesOnPc.Items(drivesOnPc.SelectedIndex).ToString)

        ' Redraw the pie chart
        Me.Invalidate()

    End Sub

    Private Sub LoadDriveInfo(ByVal driveLetter As String)

        ' Use the DriveInfo class to obtain information on drives. 
        ' Drive name must be either an upper or lower case letter from 'a' to 'z'. 
        ' You can not use this method to obtain information on drive names that are null or use UNC (\\server\share) paths.

        Dim driveInfo As System.IO.DriveInfo

        ' Check for valid drive names
        Try
            driveInfo = New System.IO.DriveInfo(driveLetter)
        Catch ex1 As ArgumentNullException
            MessageBox.Show("The drive letter can not be null./n/r" + ex1.Message, "Drive Letter error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Catch ex2 As ArgumentException
            MessageBox.Show("The drive letter must be in the range of a-z./n/r" + ex2.Message, "Drive Letter error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        Me.driveName.Text = driveInfo.Name

        ' Some drives do not provide all of the info
        ' have to trap for exceptions and just move on to the next drive
        Try
            If driveInfo.VolumeLabel.Length > 0 Then
                Me.driveVolumeLabel.Text = driveInfo.VolumeLabel
            Else
                Me.driveVolumeLabel.Text = "None"
            End If
            Me.driveFormat.Text = driveInfo.DriveFormat
            totalSpace = driveInfo.TotalSize
            freeSpace = driveInfo.TotalFreeSpace
            usedSpace = totalSpace - freeSpace
            sweep = 360.0F * freeSpace / totalSpace
            isSpaceInfoAvailable = True
        Catch
            Me.driveVolumeLabel.Text = "Not available"
            Me.driveFormat.Text = "Not available"
            isSpaceInfoAvailable = False
        End Try

        Me.driveType.Text = driveInfo.DriveType.ToString

        Me.driveRootDirectory.Text = driveInfo.RootDirectory.ToString
        dirInfo = driveInfo.RootDirectory

        If driveInfo.IsReady = True Then
            Me.driveReadyStatus.Text = "Drive is Ready"
        Else
            Me.driveReadyStatus.Text = "Drive is NOT Ready"
        End If

    End Sub

    Private Function ConvertBytesToMB(ByVal bytes As Int64) As String
        Dim mb As Long = bytes / 1048576
        Return mb.ToString("N")
    End Function

    Private Function ConvertBytesToGB(ByVal bytes As Int64) As String
        Dim gb As Long = bytes / 1073741824
        Return gb.ToString("N")
    End Function


    Private dirInfo As DirectoryInfo
    Private totalSpace As Long
    Private freeSpace As Long
    Private usedSpace As Long
    Private sweep As Single
    Private isSpaceInfoAvailable As Boolean

End Class