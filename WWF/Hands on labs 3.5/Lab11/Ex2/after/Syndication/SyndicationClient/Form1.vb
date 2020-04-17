Imports SyndicationServer
Imports System.ServiceModel.Syndication
Imports System.Xml

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            Dim reader As XmlReader
            reader = XmlReader.Create("http://localhost:8899/sysinfo/atom/")
            Dim feed As SyndicationFeed
            feed = SyndicationFeed.Load(reader)
            Dim c As XmlSyndicationContent = Nothing
            Dim si As SystemInfo = Nothing
            For Each i As SyndicationItem In feed.Items
                c = CType(i.Content, XmlSyndicationContent)
                si = c.ReadContent(Of SystemInfo)()

                ListBox1.Items.Add(i.Title.Text)
                ListBox1.Items.Add(si.ToString())
                ListBox1.Items.Add("* " & si.ProcessorCount)
                ListBox1.Items.Add("* " & si.OSVersion)
                ListBox1.Items.Add("* " & si.Version)

                MsgBox(si.ToString(), MsgBoxStyle.Information, _
                   si.MachineName)
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, ex.Source)
        End Try




    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        WebBrowser1.Navigate("http://localhost:8899/sysinfo/rss/")
    End Sub
End Class
