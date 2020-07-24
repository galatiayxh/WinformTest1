using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 窗体间传值__事件的方式
{
    public partial class Form2 : Form
    {
        public delegate void mydel(string str);
        public event mydel changeText;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string aa = "nihao 事件";
            changeText(aa);
        }
    }
}
