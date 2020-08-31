using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressBar进度条
{
    public partial class 执行进度条 : Form
    {
        public 执行进度条()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int list = 1000000;

            Thread work = new Thread(() =>
            {
                Action method = null;
                try
                {
                    method = delegate ()
                    {
                        pbDelete.Visible = true;
                        pbDelete.Maximum = list;
                        pbDelete.Value = 0;

                        while (list > 0)
                        {
                            list--;
                            pbDelete.Value += 1;
                            Application.DoEvents();
                        }
                    };
                    this.BeginInvoke(method);
                }
                catch
                {
                    method = delegate ()
                    {
                        //dataGridView1.Enabled = true;
                    };
                    this.BeginInvoke(method);
                }
            });

            work.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pbDelete.PerformStep();
        }
    }
}
