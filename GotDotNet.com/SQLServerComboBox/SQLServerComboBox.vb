Public Class SQLServerComboBox
   Inherits ComboBox

   Dim oApp As sqldmoNET.Application
   Dim oSvrGrp As sqldmoNET.ServerGroup
   Dim oRegisterSvr As sqldmoNET.RegisteredServer

   Sub New()
      Refresh()
   End Sub

   Public Overrides Sub Refresh()
      oApp = New sqldmoNET.Application
      For Each oSvrGrp In oApp.ServerGroups
         For Each oRegisterSvr In oSvrGrp.RegisteredServers
            Me.Items.Add(oRegisterSvr.Name)
         Next
      Next
      oApp.Quit()
      oApp = Nothing
   End Sub

   Protected Overrides Sub RefreshItem(ByVal index As Integer)

   End Sub

   Protected Overrides Sub SetItemsCore(ByVal items As System.Collections.IList)

   End Sub
End Class
