using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressBar进度条
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pbTest.Value = 0;
            pbTest.Step = 5;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pbTest.PerformStep();
        }
    }
}
