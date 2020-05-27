using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace 生成Excel饼图_柱状图
{
    // public partial class Form1 : Form
    //{
    // public Form1()
    // {
    //    InitializeComponent();
    //}
    //  }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> txDataPie = new List<string>() { "不合格", "合格" };
        List<int> tyDataPie = new List<int>() { 826, 185 };
        List<string> txDataColumn = new List<string>() { "AAA", "BBB", "CCC" };
        List<int> tyDataNo = new List<int>() { 0, 0, 641 };
        List<int> tyDataOk = new List<int>() { 0, 0, 185 };

        private void btn_out_Click(object sender, EventArgs e)
        {
            //申明保存对话框   
            SaveFileDialog dlg = new SaveFileDialog();
            //默然文件后缀   
            dlg.DefaultExt = "xlsx ";
            //文件后缀列表   
            dlg.Filter = "EXCEL文件(*.XLSX)|*.xlsx ";
            //默然路径是系统当前路径   
            dlg.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            //打开保存对话框   
            if (dlg.ShowDialog() == DialogResult.Cancel) return;
            //返回文件路径   
            string fileNameString = dlg.FileName;
            //验证strFileName是否为空或值无效   
            if (fileNameString.Trim() == " ")
            { return; }
            Excel.Application objExcel = null;
            Excel.Workbook objWorkbook = null;
            Excel.Worksheet objsheet = null;
            try
            {
                //申明对象   
                objExcel = new Excel.Application();
                objWorkbook = objExcel.Workbooks.Add(Missing.Value);
                objsheet = (Excel.Worksheet)objWorkbook.ActiveSheet;
                //合格率
                objExcel.Cells[1, 1] = "开始时间";
                objExcel.Cells[1, 2] = dateTimePicker1.Text;
                objExcel.Cells[1, 3] = "结束时间";
                objExcel.Cells[1, 4] = dateTimePicker1.Text;
                objExcel.Cells[2, 1] = "不合格";
                objExcel.Cells[3, 1] = "合格";
                objExcel.Cells[2, 2] = tyDataPie[0];
                objExcel.Cells[3, 2] = tyDataPie[1];
                //饼图
                Excel.Range oResizeRange;
                Excel.Chart xlChart = (Excel.Chart)objWorkbook.Charts.Add(Type.Missing, objsheet, Type.Missing, Type.Missing);
                xlChart.ChartType = Excel.XlChartType.xlPie;//设置图形
                xlChart.SetSourceData(objsheet.get_Range("A2", "B3"), Excel.XlRowCol.xlColumns);
                objWorkbook.ActiveChart.Location(Excel.XlChartLocation.xlLocationAutomatic, "合格率");
                objWorkbook.ActiveChart.Location(Excel.XlChartLocation.xlLocationAsObject, objsheet.Name);
                oResizeRange = (Excel.Range)objsheet.Rows.get_Item(7, Missing.Value);

                objsheet.Shapes.Item("Chart 1").Top = 70;  //调图表的位置上边距
                objsheet.Shapes.Item("Chart 1").Left = (float)(double)oResizeRange.Left;
                objsheet.Shapes.Item("Chart 1").Width = 200;   //调图表的宽度
                objsheet.Shapes.Item("Chart 1").Height = 150;  //调图表的高度
                #region 管理人员
                int col = 6;
                objExcel.Cells[2, col] = "用户名";
                objExcel.Cells[2, col + 1] = "合格";
                objExcel.Cells[2, col + 2] = "不合格";
                int row = 3;
                for (int i = 0; i < txDataColumn.Count; i++)
                {
                    objExcel.Cells[row, col] = txDataColumn[i];
                    row++;
                }
                row = 3;
                for (int i = 0; i < tyDataOk.Count; i++)
                {
                    objExcel.Cells[row, col + 1] = tyDataOk[i];
                    row++;
                }
                row = 3;
                for (int i = 0; i < tyDataNo.Count; i++)
                {
                    objExcel.Cells[row, col + 2] = tyDataNo[i];
                    row++;
                }
                #endregion
                //柱状图
                Excel.Chart xlChart2 = (Excel.Chart)objWorkbook.Charts.Add(Type.Missing, objsheet, Type.Missing, Type.Missing);
                Excel.Range cellRange = objsheet.get_Range((Excel.Range)objsheet.Cells[2, 6], (Excel.Range)objsheet.Cells[3 + txDataColumn.Count - 1, 8]);
                //1-cellRange:数据源的范围，2-图表类型，3-Type.Missing，4-在图表上将列或行用作数据系列的方式，5、6-第五个第六个参数设置图表的x轴和y轴分别是数据源的哪些列/行，7-图表是否有图例，8、9、10-设置标题
                xlChart2.ChartWizard(cellRange,
                                Excel.XlChartType.xlColumnStacked, Type.Missing,
                                Excel.XlRowCol.xlColumns, 1, 1, true,
                                "管理人员校准情况", "用户名", "校准个数",
                                "");





                xlChart2.Location(Excel.XlChartLocation.xlLocationAsObject, objsheet.Name);
                Excel.Range oResizeRange1 = (Excel.Range)objsheet.Rows.get_Item(1);
                Excel.Range oResizeRange2 = (Excel.Range)objsheet.Columns.get_Item(10);
                objsheet.Shapes.Item("Chart 2").Top = (float)oResizeRange1.Top;  //调图表的位置上边距--1行的高度
                objsheet.Shapes.Item("Chart 2").Left = (float)(double)oResizeRange2.Left;//调图表的位置左边距--10列的宽度
                objsheet.Shapes.Item("Chart 2").Width = 300;   //调图表的宽度
                objsheet.Shapes.Item("Chart 2").Height = 200;  //调图表的高度
                //保存文件   
                objWorkbook.SaveAs(fileNameString, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Excel.XlSaveAsAccessMode.xlShared, Missing.Value, Missing.Value, Missing.Value,
                        Missing.Value, Missing.Value);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "警告 ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            finally
            {
                //关闭Excel应用   
                if (objWorkbook != null) objWorkbook.Close(Missing.Value, Missing.Value, Missing.Value);
                if (objExcel.Workbooks != null) objExcel.Workbooks.Close();
                if (objExcel != null) objExcel.Quit();
                objsheet = null;
                objWorkbook = null;
                objExcel = null;
            }
        }
    }

}
