Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.IO
Imports System.IO.Compression
Imports System.Text.Encoding
Imports System.Net
Imports ICSharpCode.SharpZipLib.GZip
Imports TestWebServiceZip.Commons.Compression

Public Class frmMain

    Private Sub butGetZipDS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butGetZipDS.Click

        '' create our proxy to the web service
        Dim ws As New srWebZip.WebZipSoapClient

        '' create some stopwatch objects
        Dim sw1, sw2, sw3 As New Stopwatch  '' sw1 = total time  /  sw2 = fetch time  /  sw3 = inflate time

        '' clean our form ouput areas
        rtbOutput.Text = ""
        DataGridView1.DataSource = Nothing

        '' start our total stopwatch
        sw1.Start()

        '' fetch our compressed dataset as a byte array
        sw2.Start()
        Dim dsBytes As Byte() = ws.GetDataSetAsByteArray
        sw2.Stop()

        '' perform decompression
        Dim dsData As DataSet
        sw3.Start()
        dsData = InflateDataSetByteArray(dsBytes)
        sw3.Stop()

        '' stop our total stopwatch
        sw1.Stop()

        '' provide ui feedback
        rtbOutput.AppendText("DataSet Compressed" & vbCrLf)
        rtbOutput.AppendText("Size of download: " & dsBytes.Length & vbCrLf)
        rtbOutput.AppendText("Download took: " & sw2.ElapsedMilliseconds & "ms" & vbCrLf)
        rtbOutput.AppendText("Decompression took: " & sw3.ElapsedMilliseconds & "ms" & vbCrLf)
        rtbOutput.AppendText("Total Time spent: " & sw1.ElapsedMilliseconds & "ms" & vbCrLf)
        DataGridView1.DataSource = dsData
        DataGridView1.DataMember = "WebZip"
    End Sub

    Private Sub butGetDS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butGetDS.Click

        '' create our proxy to the web service
        Dim ws As New srWebZip.WebZipSoapClient


        '' create some stopwatch objects
        Dim sw1, sw2 As New Stopwatch  '' sw1 = total time  /  sw2 = fetch time

        '' clean our form ouput areas
        rtbOutput.Text = ""
        DataGridView1.DataSource = Nothing

        '' start our total stopwatch
        sw1.Start()

        '' fetch our full dataset
        sw2.Start()
        Dim dsData As DataSet = ws.GetDataSet
        sw2.Stop()

        '' stop our total stopwatch
        sw1.Stop()

        '' calc full dataset size by getting the raw xml output from the web service
        Dim size As Int32 = GetPageAsString(New Uri(ws.Endpoint.Address.Uri.ToString & "/GetDataSet"), "POST").Length

        '' provide ui feedback
        rtbOutput.AppendText("DataSet Raw XML" & vbCrLf)
        rtbOutput.AppendText("Size of download: " & size & vbCrLf)
        rtbOutput.AppendText("Download took: " & sw2.ElapsedMilliseconds & "ms" & vbCrLf)
        rtbOutput.AppendText("Total Time spent: " & sw1.ElapsedMilliseconds & "ms" & vbCrLf)
        DataGridView1.DataSource = dsData
        DataGridView1.DataMember = "WebZip"
    End Sub


    Public Shared Function GetPageAsString(ByVal inAddress As Uri, Optional ByVal inMethod As String = "GET") As String

        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim result As String

        Try
            '' create the web request  
            request = DirectCast(WebRequest.Create(inAddress), HttpWebRequest)
            request.Method = inMethod

            '' get the response  
            response = DirectCast(request.GetResponse(), HttpWebResponse)

            '' get the response stream into a reader  
            reader = New StreamReader(response.GetResponseStream())

            '' read the whole contents and return as a string  
            result = reader.ReadToEnd()
        Finally
            If Not response Is Nothing Then response.Close()
        End Try

        Return result

    End Function

    Private Sub butGetDSZipPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butGetDSZipPlus.Click
        '' create our proxy to the web service
        Dim ws As New srWebZip.WebZipSoapClient

        '' create some stopwatch objects
        Dim sw1, sw2, sw3 As New Stopwatch  '' sw1 = total time  /  sw2 = fetch time  /  sw3 = inflate time

        '' clean our form ouput areas
        rtbOutput.Text = ""
        DataGridView1.DataSource = Nothing

        '' start our total stopwatch
        sw1.Start()

        '' fetch our compressed dataset as a byte array
        sw2.Start()
        Dim dsBytes As Byte() = ws.GetDataSetAsByteArrayPlus
        sw2.Stop()

        '' perform decompression
        Dim dsData As DataSet
        sw3.Start()
        dsData = InflateDataSetByteArrayPlus(dsBytes)
        sw3.Stop()

        '' stop our total stopwatch
        sw1.Stop()

        '' provide ui feedback
        rtbOutput.AppendText("DataSet Compressed" & vbCrLf)
        rtbOutput.AppendText("Size of download: " & dsBytes.Length & vbCrLf)
        rtbOutput.AppendText("Download took: " & sw2.ElapsedMilliseconds & "ms" & vbCrLf)
        rtbOutput.AppendText("Decompression took: " & sw3.ElapsedMilliseconds & "ms" & vbCrLf)
        rtbOutput.AppendText("Total Time spent: " & sw1.ElapsedMilliseconds & "ms" & vbCrLf)
        DataGridView1.DataSource = dsData
        DataGridView1.DataMember = "WebZip"
    End Sub
End Class



