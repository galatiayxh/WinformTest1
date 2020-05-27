Imports Commom
Imports Microsoft.Office.Interop.Excel
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    '    Sub test1()
    '        '
    '        ' test1 宏
    '        ' test
    '        '

    '        '
    '        ActiveSheet.Shapes.AddChart2(201, xlColumnClustered).Select
    '        ActiveChart.SetSourceData Source:=Range("Sheet1!$A$1:$C$31")
    'End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As New ToolHelper
        a.Export()
    End Sub
End Class
