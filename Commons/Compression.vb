Imports System.Text
Imports System.Text.Encoding
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports ICSharpCode.SharpZipLib.GZip

Namespace Commons

    Public Class Compression

#Region " // Compression SharpZipLib Gzip Routines // "

        '' Compress the passed dataset to a byte array
        Public Shared Function DeflateDataSet(ByVal ds As DataSet) As Byte()
            '' convert dataset to xml
            Dim strXml As String
            Dim sb As New StringBuilder
            Dim oSerializer As New System.Xml.Serialization.XmlSerializer(GetType(DataSet))
            Using sw As New StringWriter(sb)
                oSerializer.Serialize(sw, ds)
                strXml = sb.ToString
            End Using

            '' perform compression
            Dim compressedDS() As Byte
            compressedDS = DeflateData(UTF8.GetBytes(strXml))

            '' return our compressed dataset
            Return compressedDS
        End Function

        '' Decompresses the passed byte array to a dataset
        Public Shared Function InflateDataSetByteArray(ByVal dsBytes As Byte()) As DataSet
            '' uncompress the data
            Dim decompressed_dsBytes() As Byte
            decompressed_dsBytes = InflateData(dsBytes)

            '' convert back to xml 
            Dim xmlString As String = ASCII.GetString(decompressed_dsBytes)

            '' convert xml to dataset
            Dim dsData As DataSet
            Dim oSerializer As New System.Xml.Serialization.XmlSerializer(GetType(DataSet))
            Using sr As New StringReader(xmlString)
                dsData = DirectCast(oSerializer.Deserialize(sr), DataSet)
            End Using

            '' return our data
            Return dsData
        End Function

        '' Converts the passed string to a byte array in UTF8 encoding.
        Public Shared Function StrToByteArray(ByVal str As String) As Byte()
            Return Encoding.UTF8.GetBytes(str)
        End Function

        '' Compress the raw data using gzip compression
        Public Shared Function DeflateData1(ByVal data As String) As String
            Dim b As Byte()
            b = DeflateData(StrToByteArray(data))
            Return Encoding.UTF8.GetString(b, 0, b.Length)
        End Function

        '' Compress the raw data using gzip compression
        Public Shared Function DeflateData(ByVal data As String) As Byte()
            Return (DeflateData(StrToByteArray(data)))
        End Function

        '' Compress the raw data using gzip compression
        Public Shared Function DeflateData(ByVal data As Byte()) As Byte()
            Dim stream As New MemoryStream()
            Dim gzipOut As New GZipOutputStream(stream)
            gzipOut.Write(data, 0, data.Length)
            gzipOut.SetLevel(3)
            gzipOut.Finish()
            Return stream.ToArray()
        End Function

        '' Decompress the data using gzip compression
        Public Shared Function InflateData(ByVal data As Byte()) As Byte()
            Dim ms As New MemoryStream()
            ms.Write(data, 0, data.Length)
            ms.Seek(0, SeekOrigin.Begin)
            Dim gzin As Stream = New GZipInputStream(ms)
            Dim decompMemStream As New MemoryStream()
            Dim size As Integer = 2048
            Dim buffer As Byte() = New Byte(size - 1) {}
            While size > 0
                size = gzin.Read(buffer, 0, size)
                If size > 0 Then
                    decompMemStream.Write(buffer, 0, size)
                End If
            End While

            Return decompMemStream.ToArray()
        End Function

        '' == TESTING a FASTER WAY =====================================================

        '' Compress the passed dataset to a byte array
        Public Shared Function DeflateDataSetPlus(ByVal ds As DataSet) As Byte()
            '' convert dataset to xml
            Dim strXml As String
            Dim sb As New StringBuilder
            Dim oSerializer As New System.Xml.Serialization.XmlSerializer(GetType(DataSet))
            Using sw As New StringWriter(sb)
                oSerializer.Serialize(sw, ds)
                strXml = sb.ToString
            End Using

            '' perform compression
            Dim compressedDS() As Byte
            compressedDS = DeflateDataPlus(UTF8.GetBytes(strXml))

            '' return our compressed dataset
            Return compressedDS
        End Function

        '' Decompresses the passed byte array to a dataset
        Public Shared Function InflateDataSetByteArrayPlus(ByVal dsBytes As Byte()) As DataSet
            '' uncompress the data
            Dim decompressed_dsBytes() As Byte
            decompressed_dsBytes = InflateDataPlus(dsBytes)

            '' convert back to xml 
            Dim xmlString As String = ASCII.GetString(decompressed_dsBytes)

            '' convert xml to dataset
            Dim dsData As DataSet
            Dim oSerializer As New System.Xml.Serialization.XmlSerializer(GetType(DataSet))
            Using sr As New StringReader(xmlString)
                dsData = DirectCast(oSerializer.Deserialize(sr), DataSet)
            End Using

            '' return our data
            Return dsData
        End Function

        Public Shared Function DeflateDataPlus(ByVal data As Byte()) As Byte()
            Using ms As New MemoryStream(data.Length + 4)
                '' prepare a 4-bytes buffer containing the length of the original (uncompressed) data buffer; and add it to the stream
                Dim buf As Byte() = BitConverter.GetBytes(data.Length)
                ms.Write(buf, 0, buf.Length)

                '' do our compression as normal; knowing that the first 4 bytes are uncompressed
                Dim gzipOut As New GZipOutputStream(ms)
                gzipOut.Write(data, 0, data.Length)
                gzipOut.SetLevel(1)
                gzipOut.Finish()

                Return ms.ToArray()

            End Using
        End Function

        Public Shared Function InflateDataPlus(ByVal data As Byte()) As Byte()

            '' retrieve the length of the original uncompressed buffer
            Dim length As Integer = BitConverter.ToInt32(data, 0)

            '' initialize the input stream starting with the 5th byte, said different, eliminate the first 4 bytes that we used for the buffer length
            Using ms As New MemoryStream(data, 4, data.Length - 4)

                '' since we know the size of the resulting buffer, we can safely allocate the needed space
                Dim gzin As Stream = New GZipInputStream(ms)
                Dim buffer As Byte() = New Byte(length) {}
                gzin.Read(buffer, 0, length)
                Return buffer

            End Using

        End Function

#End Region

    End Class

End Namespace