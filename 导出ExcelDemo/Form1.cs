using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aspose.Cells;


namespace 导出ExcelDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int intExcelTempIndex = 0;
        private void btn导出_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
            {
                return;
            }
            Workbook work = new Aspose.Cells.Workbook();
            //Worksheet sheet = work.Worksheets["New Worksheet1"];
            Worksheet sheet = default(Aspose.Cells.Worksheet);
            Aspose.Cells.Style style = new Aspose.Cells.Style();
            style.Font.Name = "宋体";
            Aspose.Cells.Style stylecolor = new Aspose.Cells.Style();
            stylecolor.ForegroundColor = Color.LightBlue;
            Aspose.Cells.StyleFlag flag = new Aspose.Cells.StyleFlag();
            flag.Font = true;


            //
           
            sheet = work.Worksheets[0];
            intExcelTempIndex += 1;
            sheet.Name = "使用记录" + intExcelTempIndex.ToString();

            int Rowi = 0;
            int Rown = 0;
            int RownMax = 0;
            //最后Export列不导出
            RownMax = System.Convert.ToInt32(dataGridView1.Columns.Count - 0);
            ArrayList colList = new ArrayList(); //存放不显示的列
            int Col = 0;
            for ( int i = 0; i < RownMax; i++)
            {
                if (dataGridView1.Columns[i].Width <= 5 || dataGridView1.Columns[i].Visible == false)
                {
                }
                else
                {
                    colList.Add(i);
                    sheet.Cells[0, Col].PutValue(dataGridView1.Columns[i].HeaderText);
                    Col++;
                }
            }
            //表内容
            int intcount = 0;
            for (Rowi = 0; Rowi <= dataGridView1.Rows.Count - 1; Rowi++)
            {
                if (dataGridView1.Rows[Rowi].Visible == false)
                {
                    intcount++;
                    continue;
                }
                for (Rown = 0; Rown <= colList.Count - 1; Rown++)
                {
                    if (dataGridView1.Rows[Rowi].Cells[Rown].Value != null)
                        sheet.Cells[Rowi + 1 - intcount, Rown].PutValue(dataGridView1.Rows[Rowi].Cells[Rown].Value.ToString());
                    else
                        sheet.Cells[Rowi + 1 - intcount, Rown].PutValue("");
                }
            }
            //reportToexcel();
            string filepath = "";
            sheet.Cells.ApplyStyle(style, flag);
            if (dataGridView1.Rows.Count > 60000)
            {
                filepath = System.Windows.Forms.Application.StartupPath + "\\" + sheet.Name + ".xlsx";
            }
            else
            {
                filepath = System.Windows.Forms.Application.StartupPath + "\\" + sheet.Name + ".xls";
            }
            work.Save(filepath);
            System.Diagnostics.Process.Start(filepath); //'打开导出Excel
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM dbo.DentalBox";
            LoadData(sql);
        }
        public void LoadData(string sql) {
            var date = SqlHelper.ExcuteDataTable(sql);
            for (int i = 0; i < date.Rows.Count; i++)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = date.Rows[i]["ID"].ToString();
                dataGridView1.Rows[index].Cells[1].Value = date.Rows[i]["BoxNo"].ToString();
                dataGridView1.Rows[index].Cells[2].Value = date.Rows[i]["status"].ToString();
                //加一行            index
                dataGridView1.Rows[index].HeaderCell.Value = (index + 1).ToString();
            }
        }
    }
}
