Option Strict On
Option Explicit On

Public Class DiskOrbling
    Implements ILocalOrbling

    'GetOptions Method

    Function GetOptions() As OrbOptions Implements ILocalOrbling.GetOptions

        Dim myOptions As New OrbOptions

        myOptions.ComponentName = "DiskOrbling"
        myOptions.ComponentDescription = "Status Indicator of free disk space"

        Dim diskDriveCollection As New OrbValuePairOption()

        Dim drive As System.IO.DriveInfo

        For Each drive In My.Computer.FileSystem.Drives
            If (drive.DriveType = IO.DriveType.Fixed) Then
                diskDriveCollection.Add(drive.Name, drive.VolumeLabel + " (" + drive.Name + ")")
            End If
        Next

        'Create the options to be used
        myOptions.ComponentProperties = New Dictionary(Of String, Object)
        myOptions.ComponentProperties.Add("Disk Drive", diskDriveCollection)
        myOptions.ComponentProperties.Add("Indigo Percent", New OrbPercentOption(0.75))
        myOptions.ComponentProperties.Add("Green Percent", New OrbPercentOption(0.5))
        myOptions.ComponentProperties.Add("Yellow Percent", New OrbPercentOption(0.25))

        Return myOptions
    End Function

    'GetName Method

    Function GetName() As String Implements ILocalOrbling.GetName
        Return "DiskOrbling"
    End Function


    'GetType Method

    Function GetConnectionType() As OrblingType Implements ILocalOrbling.GetConnectionType
        Return OrblingType.Local
    End Function

    'GetTime Method

    Function GetTime() As TimeSpan Implements ILocalOrbling.GetTime
        Return TimeSpan.FromSeconds(20)
    End Function

    'GetInformation Method

    Function GetInformation(ByVal Options As OrbOptionValues) As OrbDisplay Implements ILocalOrbling.GetInformation

        Dim returnDisplay As New OrbDisplay

        returnDisplay.DisplayType = OrbAnimationType.StaticColor

        Dim diskDrive As System.IO.DriveInfo = Nothing

        Dim diskOption As OrbValuePairOption = CType(Options.ComponentProperties("Disk Drive"), OrbValuePairOption)

        'Find the correct disk drive
        For Each diskDrive In My.Computer.FileSystem.Drives
            If (diskDrive.Name = diskOption.Value) Then
                Exit For
            End If
        Next

        'Grab the color ranges
        Dim yellowOption As Double = CType(Options.ComponentProperties("Yellow Percent"), OrbPercentOption).Value
        Dim greenOption As Double = CType(Options.ComponentProperties("Green Percent"), OrbPercentOption).Value
        Dim indigoOption As Double = CType(Options.ComponentProperties("Indigo Percent"), OrbPercentOption).Value

        'Choose the correct color below
        returnDisplay.DisplayColor = New OrbColor(Colors.Red)

        If (diskDrive.TotalFreeSpace() / diskDrive.TotalSize()) >= yellowOption Then
            returnDisplay.DisplayColor = New OrbColor(Colors.Yellow)
        End If

        If (diskDrive.TotalFreeSpace() / diskDrive.TotalSize()) > greenOption Then
            returnDisplay.DisplayColor = New OrbColor(Colors.Green)
        End If

        If (diskDrive.TotalFreeSpace() / diskDrive.TotalSize()) > indigoOption Then
            returnDisplay.DisplayColor = New OrbColor(Colors.Indigo)
        End If

        Return returnDisplay
    End Function

End Class

