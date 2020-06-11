using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsposeHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DateTime startTime = DateTime.Now;
            Console.WriteLine("开始           " + startTime.ToString());


            string sql = " SELECT ID ,FactureNo ,HName ,DName FROM dbo.Mechanic";
            DataTable dt = SqlHelper.ExcuteDataTable(sql);
            AsposeHelper aspose = new AsposeHelper();

            aspose.MainExport(dt);


            string slExecutedTime = (DateTime.Now - startTime).ToString();
            Console.WriteLine("结束       " + slExecutedTime);
        }
    }
}
