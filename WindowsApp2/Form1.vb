Imports System.IO
Imports System.Xml
Imports System.Text.RegularExpressions
Public Class Form1


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label1.Text = "(From FileZilla Installation)"
        Dim ReadXML As StreamReader
        Dim PassXML As String
        Dim XReader
        Dim xmldoc As New XmlDataDocument()
        Dim xmlnode As XmlNodeList
        Dim Str As String
        'MsgBox(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData))
        DataGridView1.Rows.Clear()
        ReadXML = New StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\FileZilla\recentservers.xml")
        PassXML = ReadXML.ReadToEnd()
        ReadXML.Close()
        'MsgBox(PassXML)
        XReader = XElement.Parse(PassXML)
        'MsgBox(PassXML)
        'Dim xmldoc As New XmlDataDocument()
        'Dim xmlnode As XmlNodeList
        If xmldoc.HasChildNodes = True Then
            xmldoc.DocumentElement.RemoveAll()
        End If
        xmldoc.LoadXml(PassXML)
        xmlnode = xmldoc.GetElementsByTagName("Server")
        'Dim Str As String
        Dim output1() As String
        For count = 0 To xmlnode.Count - 1
            xmlnode(count).ChildNodes.Item(0)
            Str = xmlnode(count).ChildNodes.Item(0).InnerText.Trim() & " " & xmlnode(count).ChildNodes.Item(1).InnerText.Trim() & " " & xmlnode(count).ChildNodes.Item(4).InnerText.Trim()
            Dim TempByte As Byte() = Convert.FromBase64String(xmlnode(count).ChildNodes.Item(5).InnerText.Trim())
            Dim TempPass As String = System.Text.Encoding.UTF8.GetString(TempByte)
            Str = Str & " " & TempPass
            output1 = Str.Split(" ")
            DataGridView1.Rows.Add(output1(0), output1(1), output1(2), output1(3))
        Next
        'Dim output1() As String
        'output1 = Regex.Split()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim columns As DataGridTextBoxColumn

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Dim ReadXML As StreamReader
            Dim PassXML As String
            Dim XReader
            Dim xmldoc As New XmlDataDocument()
            Dim xmlnode As XmlNodeList
            'Dim Str As String
            Label1.Text = OpenFileDialog1.FileName
            DataGridView1.Rows.Clear()
            ReadXML = New StreamReader(OpenFileDialog1.FileName)
            PassXML = ReadXML.ReadToEnd()
            ReadXML.Close()
            'MsgBox(PassXML)
            XReader = XElement.Parse(PassXML)
            'MsgBox(PassXML)
            'Dim xmldoc As New XmlDataDocument()
            'Dim xmlnode As XmlNodeList
            'xmldoc.
            xmldoc.LoadXml(PassXML)
            XmlNode = xmldoc.GetElementsByTagName("Server")
            Dim Str As String
            Dim output1() As String
            For count = 0 To XmlNode.Count - 1
                XmlNode(count).ChildNodes.Item(0)
                Str = XmlNode(count).ChildNodes.Item(0).InnerText.Trim() & " " & XmlNode(count).ChildNodes.Item(1).InnerText.Trim() & " " & XmlNode(count).ChildNodes.Item(4).InnerText.Trim()
                Dim TempByte As Byte() = Convert.FromBase64String(XmlNode(count).ChildNodes.Item(5).InnerText.Trim())
                Dim TempPass As String = System.Text.Encoding.UTF8.GetString(TempByte)
                Str = Str & " " & TempPass
                output1 = Str.Split(" ")
                DataGridView1.Rows.Add(output1(0), output1(1), output1(2), output1(3))
            Next
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MsgBox("This program is in no way associated with the FileZilla project or its creators" & vbCrLf & "The author is not responsible for any misuse of this tool", Title:="Disclaimer")
    End Sub
End Class
