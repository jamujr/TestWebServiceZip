Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.IO
Imports System.IO.Compression
Imports System.Text.Encoding
Imports ICSharpCode.SharpZipLib.GZip
Imports TestWebServiceZip.Commons.Compression

<System.Web.Services.WebService(Namespace:="http://webzip.testing/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WebZip
    Inherits System.Web.Services.WebService

    <WebMethod(Description:="Returns our full dataset")> _
    Public Function GetDataSet() As DataSet

        '' build a simple dataset
        Dim nDS As New DataSet
        nDS = SimpleDS()

        '' return the full dataset with all the trimmings!
        Return nDS

    End Function

    <WebMethod(Description:="Returns our compressed dataset in the form of a byte array")> _
    Public Function GetDataSetAsByteArray() As Byte()

        '' build a simple dataset
        Dim nDS As New DataSet
        nDS = SimpleDS()

        '' return our smaller compressed dataset as byte array
        Return DeflateDataSet(nDS)

    End Function

    <WebMethod(Description:="Returns our compressed dataset in the form of a byte array")> _
    Public Function GetDataSetAsByteArrayPlus() As Byte()

        '' build a simple dataset
        Dim nDS As New DataSet
        nDS = SimpleDS()

        '' return our smaller compressed dataset as byte array
        Return DeflateDataSetPlus(nDS)

    End Function

    '' Create a simple test dataset; so we need to db server
    Private Function SimpleDS() As DataSet
        Dim ds As New DataSet
        Dim dt As DataTable
        Dim dr As DataRow
        Dim idCoulumn As DataColumn
        Dim nameCoulumn As DataColumn
        Dim i As Integer

        '' give our table a name
        dt = New DataTable("WebZip")

        '' create some columns
        idCoulumn = New DataColumn("ID", Type.GetType("System.Int32"))
        nameCoulumn = New DataColumn("Name", Type.GetType("System.String"))

        '' add our columns to the datatable
        dt.Columns.Add(idCoulumn)
        dt.Columns.Add(nameCoulumn)

        '' this is how you add just one new datarow
        dr = dt.NewRow()
        dr("ID") = 0
        dr("Name") = "Name0"
        dt.Rows.Add(dr)

        '' generate a few datarows in a simple for loop
        For i = 1 To 3000
            dr = dt.NewRow
            dr("ID") = i
            dr("Name") = "Name" & i
            dt.Rows.Add(dr)
        Next

        '' add the table to the dataset
        ds.Tables.Add(dt)

        '' return our simple dataset
        Return ds

    End Function

End Class