Imports System.Reflection
Imports Microsoft.Office.Interop
Public Class Form1


    Public txDataPie As New List(Of String)
    Public tyDataPie As New List(Of Integer)
    Public txDataColumn As New List(Of String)
    Public tyDataNo As New List(Of Integer)
    Public tyDataOk As New List(Of Integer)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'txDataPie.Add("不合格")
        'txDataPie.Add("合格")

        tyDataPie.Add(826)
        tyDataPie.Add(185)

        txDataColumn.Add("AAA")
        txDataColumn.Add("BBB")
        txDataColumn.Add("CCC")

        tyDataNo.Add(0)
        tyDataNo.Add(0)
        tyDataNo.Add(641)

        tyDataOk.Add(0)
        tyDataOk.Add(0)
        tyDataOk.Add(185)

    End Sub
    Private Sub btn_out_Click(sender As Object, e As EventArgs) Handles btn_out.Click
        '//申明保存对话框   
        Dim dlg As New SaveFileDialog
        '//默然文件后缀   
        dlg.DefaultExt = "xlsx "
        '//文件后缀列表   
        dlg.Filter = "EXCEL文件(*.XLSX)|*.xlsx "
        ' //默然路径是系统当前路径   
        dlg.InitialDirectory = System.IO.Directory.GetCurrentDirectory()
        '//打开保存对话框   
        If dlg.ShowDialog() = DialogResult.Cancel Then
            Return
        End If

        '//返回文件路径   
        Dim fileNameString As String = dlg.FileName
        If fileNameString.Trim() = " " Then
            Return
        End If

        Dim objExcel As Excel.Application = Nothing
        Dim objWorkbook As Excel.Workbook = Nothing
        Dim objsheet As Excel.Worksheet = Nothing


        Try
            '//申明对象   
            objExcel = New Excel.Application()
            objWorkbook = objExcel.Workbooks.Add(Missing.Value)
            objsheet = CType(objWorkbook.ActiveSheet, Excel.Worksheet)
            '//合格率
            objExcel.Cells(1, 1) = "开始时间"
            objExcel.Cells(1, 2) = dateTimePicker1.Text
            objExcel.Cells(1, 3) = "结束时间"
            objExcel.Cells(1, 4) = dateTimePicker1.Text
            objExcel.Cells(2, 1) = "不合格"
            objExcel.Cells(3, 1) = "合格"
            objExcel.Cells(2, 2) = tyDataPie(0)
            objExcel.Cells(3, 2) = tyDataPie(1)

            '//饼图
            Dim oResizeRange As Excel.Range
            Dim xlChart As Excel.Chart = CType(objWorkbook, Excel.Chart).Charts.Add(Type.Missing, objsheet, Type.Missing, Type.Missing)
            xlChart.ChartType = Excel.XlChartType.xlPie '//设置图形
            xlChart.SetSourceData(objsheet.get_Range("A2", "B3"), Excel.XlRowCol.xlColumns)
            objWorkbook.ActiveChart.Location(Excel.XlChartLocation.xlLocationAutomatic, "合格率")
            objWorkbook.ActiveChart.Location(Excel.XlChartLocation.xlLocationAsObject, objsheet.Name)
            oResizeRange = CType(objsheet, Excel.Range).Rows.get_Item(7, Missing.Value)




            objsheet.Shapes.Item("Chart 1").Top = 70 ' //调图表的位置上边距
            objsheet.Shapes.Item("Chart 1").Left = CType(CType(oResizeRange.Left, Double), Single)
            objsheet.Shapes.Item("Chart 1").Width = 200 ';   //调图表的宽度
            objsheet.Shapes.Item("Chart 1").Height = 150 ';  //调图表的高度
#Region "管理人员"
            Dim col As Integer = 6
            objExcel.Cells(2, col) = "用户名"
            objExcel.Cells(2, col + 1) = "合格"
            objExcel.Cells(2, col + 2) = "不合格"
            Dim row As Integer = 3


            For i As Integer = 0 To txDataColumn.Count - 1
                objExcel.Cells(row, col) = txDataColumn(i)
                row += 1
            Next
            row = 3
            For i As Integer = 0 To tyDataOk.Count - 1
                objExcel.Cells(row, col + 1) = tyDataOk(i)
                row += 1

            Next
            row = 3
            For i As Integer = 0 To tyDataNo.Count - 1
                objExcel.Cells(row, col + 2) = tyDataNo(i)
                row += 1
            Next

#End Region

            '//柱状图
            Dim xlChart2 As Excel.Chart = CType(objWorkbook, Excel.Chart).Charts.Add(Type.Missing, objsheet, Type.Missing, Type.Missing)
            Dim cellRange As Excel.Range = objsheet.get_Range(CType(objsheet, Excel.Range).Cells(2, 6), CType(objsheet, Excel.Range).Cells(3 + txDataColumn.Count - 1, 8))
            '//1-cellRange:数据源的范围， 2 - 图表类型， 3 - Type.Missing， 4 - 在图表上将列或行用作数据系列的方式， 5、6-第五个第六个参数设置图表的x轴和y轴分别是数据源的哪些列/行， 7 - 图表是否有图例， 8、9、10-设置标题
            xlChart2.ChartWizard(cellRange,
                                Excel.XlChartType.xlColumnStacked, Type.Missing,
                               Excel.XlRowCol.xlColumns, 1, 1, True,
                                "管理人员校准情况", "用户名", "校准个数",
                                "")

            xlChart2.Location(Excel.XlChartLocation.xlLocationAsObject, objsheet.Name)
            Dim oResizeRange1 As Excel.Range = CType(objsheet, Excel.Range).Rows.get_Item(1)
            Dim oResizeRange2 As Excel.Range = CType(objsheet, Excel.Range).Columns.get_Item(10)
            objsheet.Shapes.Item("Chart 2").Top = oResizeRange1.Top ';  //调图表的位置上边距--1行的高度
            objsheet.Shapes.Item("Chart 2").Left = oResizeRange2.Left ';//调图表的位置左边距--10列的宽度
            objsheet.Shapes.Item("Chart 2").Width = 300 ';   //调图表的宽度
            objsheet.Shapes.Item("Chart 2").Height = 200 ';  //调图表的高度


            ' //保存文件   
            objWorkbook.SaveAs(fileNameString, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Excel.XlSaveAsAccessMode.xlShared, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value)
















        Catch ex As Exception

        Finally
            ' //关闭Excel应用   
            If IsNothing(objWorkbook) = False Then objWorkbook.Close(Missing.Value, Missing.Value, Missing.Value)
            If IsNothing(objExcel.Workbooks) = False Then objExcel.Workbooks.Close()
            If IsNothing(objExcel) = False Then objExcel.Quit()
            objsheet = Nothing
            objWorkbook = Nothing
            objExcel = Nothing

        End Try



    End Sub

End Class
