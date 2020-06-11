using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsposeHelper
{
    public class AsposeHelper
    {
        public void MainExport(DataTable dt)
        {
            string filepath = "";

            Aspose.Cells.Workbook xlBook = new Aspose.Cells.Workbook();
            //清除默认sheet
            xlBook.Worksheets.Clear();
            //设置第一个sheet和name
            xlBook.Worksheets.Add("日占比");
            Aspose.Cells.Worksheet ws1 = xlBook.Worksheets[0];
            RectangleExport(dt, ws1);
            //设置第一个sheet和name
            xlBook.Worksheets.Add("客户总量");
            Aspose.Cells.Worksheet ws2 = xlBook.Worksheets[1];
            RectangleExport(dt, ws2);
            //保存地址
            if (dt.Rows.Count > 60000)
            {
                filepath = System.Windows.Forms.Application.StartupPath + "\\" + "牙模盒使用记录" + ".xlsx";
            }
            else
            {
                filepath = System.Windows.Forms.Application.StartupPath + "\\" + "牙模盒使用记录" + ".xls";
            }
            //保存
            xlBook.Save(filepath);
            //打开
            System.Diagnostics.Process.Start(filepath);

        }
        public void RectangleExport(DataTable table, Aspose.Cells.Worksheet xlSheet)
        {

            if (table.Rows.Count <= 0)
            {
                return;
            }
            //存放列头名称
            ArrayList HeadList = new ArrayList();

            //Aspose.Cells.Style style = new Aspose.Cells.Style();
            //style.Font.Name = "宋体";
            //style.ForegroundColor = Color.LightBlue;

            //Aspose.Cells.StyleFlag flag = new Aspose.Cells.StyleFlag();
            //flag.Font = true;


            //填写表头
            for (int i = 0; i < table.Columns.Count; i++)
            {
                HeadList.Add(i);
                xlSheet.Cells[0, i].PutValue(table.Columns[i].ColumnName);
            }

            //填写表内容
            for (int Rowi = 0; Rowi < table.Rows.Count; Rowi++)
            {
                for (int Colj = 0; Colj < HeadList.Count; Colj++)
                {
                    if (table.Rows[Rowi][Colj].ToString() != null)
                        xlSheet.Cells[Rowi + 1, Colj].PutValue(table.Rows[Rowi][Colj].ToString());
                    else
                        xlSheet.Cells[Rowi + 1, Colj].PutValue("");
                }
            }
            //填写表格式
            //xlSheet.Cells.ApplyStyle(style, flag);
        }

        //internal void RectangleExport()
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// 导出方法
        /// </summary>
        /// <param name="DataGridView"></param>
        /// <param name="dt"></param>
        /// <param name="Export"></param>
        public void DataGridViewToExcel(DataGridView DataGridView, int Export = 0)
        {
            if (DataGridView.Rows.Count < 1)
            {
                return;
            }
            int i = 0;
            int Col = 0;
            ArrayList colList = new ArrayList(); //存放不显示的列
            Aspose.Cells.Workbook xlBook = new Aspose.Cells.Workbook();
            Aspose.Cells.Worksheet xlSheet = default(Aspose.Cells.Worksheet);
            string filepath = "";
            Aspose.Cells.Style style = new Aspose.Cells.Style();
            style.Font.Name = "宋体";
            Aspose.Cells.Style stylecolor = new Aspose.Cells.Style();
            stylecolor.ForegroundColor = Color.LightBlue;
            Aspose.Cells.StyleFlag flag = new Aspose.Cells.StyleFlag();
            flag.Font = true;

            xlSheet = xlBook.Worksheets[0];
            //intExcelTempIndex += 1;
            //xlSheet.Name = "牙模盒使用记录" + intExcelTempIndex.ToString();

            int Rowi = 0;
            int Rown = 0;
            int RownMax = 0;
            //最后Export列不导出
            RownMax = System.Convert.ToInt32(DataGridView.Columns.Count - Export);
            //填写表头
            for (i = 0; i < RownMax; i++)
            {
                if (DataGridView.Columns[i].Width <= 5 || DataGridView.Columns[i].Visible == false)
                {
                }
                else
                {
                    colList.Add(i);
                    xlSheet.Cells[0, Col].PutValue(DataGridView.Columns[i].HeaderText);
                    Col++;
                }
            }
            //表内容
            int intcount = 0;
            for (Rowi = 0; Rowi <= DataGridView.Rows.Count - 1; Rowi++)
            {
                if (DataGridView.Rows[Rowi].Visible == false)
                {
                    intcount++;
                    continue;
                }
                for (Rown = 0; Rown <= colList.Count - 1; Rown++)
                {
                    if (DataGridView.Rows[Rowi].Cells[Rown].Value != null)
                        xlSheet.Cells[Rowi + 1 - intcount, Rown].PutValue(DataGridView.Rows[Rowi].Cells[Rown].Value.ToString());
                    else
                        xlSheet.Cells[Rowi + 1 - intcount, Rown].PutValue("");
                }
            }
            xlSheet.Cells.ApplyStyle(style, flag);
            if (DataGridView.Rows.Count > 60000)
            {
                filepath = System.Windows.Forms.Application.StartupPath + "\\" + xlSheet.Name + ".xlsx";
            }
            else
            {
                filepath = System.Windows.Forms.Application.StartupPath + "\\" + xlSheet.Name + ".xls";
            }
            xlBook.Save(filepath);
            System.Diagnostics.Process.Start(filepath); //'打开导出Excel

        }
    }
}
