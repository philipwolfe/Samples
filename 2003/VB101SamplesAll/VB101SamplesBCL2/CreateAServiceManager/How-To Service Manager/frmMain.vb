'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio 2005.

Option Strict On

Imports System.ServiceProcess


Public Class frmMain
    ' Used to access an instance of the selected service.
    Private msvc As ServiceController
    Private mcolSvcs As New Collection()

    ' Used to control UI updates.
    Private fUpdatingUI As Boolean

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        ' So that we only need to set the title of the application once,
        ' we use the AssemblyInfo class (defined in the AssemblyInfo.vb file)
        ' to read the AssemblyTitle attribute.
        Dim ainfo As New AssemblyInfo()

        Me.Text = ainfo.Title
        Me.mnuAbout.Text = String.Format("&About {0} ...", ainfo.Title)

    End Sub

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

    Private Sub chkAutoRefresh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoRefresh.CheckedChanged, chkAutoRefresh.Click
        ' Turn the timer on or off
        If Me.chkAutoRefresh.CheckState = CheckState.Checked Then
            Me.tmrStatus.Enabled = True
        Else
            Me.tmrStatus.Enabled = False
        End If
    End Sub

    Private Sub cmdPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPause.Click
        Try
            msvc.Pause()
            fUpdatingUI = True
            UpdateUIForSelectedService()
            fUpdatingUI = False

        Catch exp As Exception
            MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdResume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdResume.Click
        Try
            msvc.[Continue]()
            fUpdatingUI = True
            UpdateUIForSelectedService()
            fUpdatingUI = False
        Catch exp As Exception
            MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart.Click
        Try
            msvc.Start()
            fUpdatingUI = True
            UpdateUIForSelectedService()
            fUpdatingUI = False
        Catch exp As Exception
            MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click
        Try
            msvc.Stop()
            fUpdatingUI = True
            UpdateUIForSelectedService()
            fUpdatingUI = False
        Catch exp As Exception
            MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EnumServices()
    End Sub

    Private Sub lvServices_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvServices.SelectedIndexChanged
        fUpdatingUI = True
        UpdateUIForSelectedService()
        fUpdatingUI = False
    End Sub

    Private Sub tmrStatus_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrStatus.Tick
        If Not fUpdatingUI Then
            UpdateServiceStatus()
        End If
    End Sub

    Private Sub EnumServices()
        ' Get the list of available services and
        ' load the list view control with the information
        Try
            fUpdatingUI = True
            Me.sbInfo.Text = "Loading Service List, pleasse wait"
            Me.sbInfo.Refresh()

            Me.lvServices.Items.Clear()

            If Not mcolSvcs Is Nothing Then
                mcolSvcs = New Collection()
            End If

            Dim svc As ServiceController
            Dim svcs As ServiceController() = ServiceController.GetServices()

            For Each svc In svcs
                With Me.lvServices.Items.Add(svc.DisplayName)
                    .SubItems.Add(svc.Status.ToString())
                    .SubItems.Add(svc.ServiceType.ToString())
                End With
                mcolSvcs.Add(svc, svc.DisplayName)
            Next svc

        Catch exp As Exception
            MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            Me.sbInfo.Text = "Ready"
            fUpdatingUI = False
        End Try
    End Sub

    Private Sub UpdateServiceStatus()
        ' Check each service
        Try
            fUpdatingUI = True

            Me.sbInfo.Text = "Checking Service Status . . "
            Me.sbInfo.Refresh()

            Dim lvi As ListViewItem

            ' We could walk through the collection of services
            ' two ways. One would be to enumerate all the services
            ' via mcolSvc and then find the particular item in the
            ' list view control to update its status.
            ' The second method is to do the following code which
            ' seems a bit easier since the collection is keyed by
            ' the service display name which we get from the list view 
            ' control.
            For Each lvi In Me.lvServices.Items
                msvc = CType(mcolSvcs.Item(lvi.Text), ServiceController)
                msvc.Refresh()

                lvi.SubItems(1).Text = msvc.Status.ToString()
            Next lvi


            UpdateUIForSelectedService()

        Catch exp As Exception
            MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.sbInfo.Text = "Ready"
            fUpdatingUI = False
        End Try
    End Sub

    Private Sub UpdateUIForSelectedService()
        ' Update the command buttons for the selected service.
        Dim strName As String

        Try
            If Me.lvServices.SelectedItems.Count = 1 Then
                strName = Me.lvServices.SelectedItems(0).SubItems(0).Text
                msvc = CType(mcolSvcs.Item(strName), ServiceController)
                With msvc
                    ' If it's stopped, we should be able to start it
                    Me.cmdStart.Enabled = (.Status = ServiceControllerStatus.Stopped)
                    ' Check if we're allowed to try and stop it and make sure it's not
                    ' already stopped.
                    Me.cmdStop.Enabled = (.CanStop AndAlso (Not .Status = ServiceControllerStatus.Stopped))
                    ' Check if we're allowed to pause it and see if it is not paused
                    ' already.
                    Me.cmdPause.Enabled = (.CanPauseAndContinue AndAlso (Not .Status = ServiceControllerStatus.Paused))
                    ' If it's paused, we must be able to resume it.
                    Me.cmdResume.Enabled = (.Status = ServiceControllerStatus.Paused)
                End With
            End If
        Catch exp As Exception
            MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub mnuRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRefresh.Click
        If Not fUpdatingUI Then
            UpdateServiceStatus()
        End If
    End Sub

    Private Sub mnuRelist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelist.Click
        If Not fUpdatingUI Then
            EnumServices()
        End If
    End Sub
End Class
