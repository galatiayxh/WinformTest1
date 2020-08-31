using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Application_DoEvents
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int num = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            num++;
            label2.Text = num.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
            this.timer1.Interval = 1000;
            this.timer1.Tick += new EventHandler(timer1_Tick);
            for (int q = 0; q < 10000; q++)
            {
                textBox1.Text = q.ToString();
                Application.DoEvents();
                if (q == 9999)
                {
                    this.timer1.Stop();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
            //this.timer1.Interval = 1000;
            this.timer1.Tick += new EventHandler(timer1_Tick);

            for (int q = 0; q < 100000; q++)
            {
                textBox2.Text = q.ToString();
                Application.DoEvents();
                if (q == 99999)
                {
                    this.timer1.Stop();
                }
            }
            label2.Text = num.ToString();
        }
    }
}
