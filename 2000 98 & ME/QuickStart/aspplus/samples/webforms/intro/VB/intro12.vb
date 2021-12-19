Option Strict Off

Imports System
Imports System.Data
Imports System.Data.SQL
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Public Class MyCodeBehind : Inherits Page

    Public Name As TextBox
    Public Category As DropDownList
    Public MyList As DataList

    Public Sub SubmitBtn_Click(Sender As Object, E As EventArgs)

        If (Page.IsValid)

          Dim DS As DataSet
          Dim MyConnection As SQLConnection
          Dim MyCommand As SQLDataSetCommand

          MyConnection = New SQLConnection("server=localhost;uid=sa;pwd=;database=pubs")

          Dim query As String
          query = "select * from Titles where type='" & Category.SelectedItem.Value & "'"

          MyCommand = New SQLDataSetCommand("select * from Titles where type='" & Category.SelectedItem.Value & "'", myConnection)

          DS = new DataSet()
          MyCommand.FillDataSet(DS, "Titles")

          MyList.DataSource = DS.Tables("Titles").DefaultView
          MyList.DataBind()

        End If
        
    End Sub

End Class