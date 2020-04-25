using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 多线程
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //取消跨线程的访问
            Control.CheckForIllegalCrossThreadCalls = false;    
        }
        Thread thread;
        private void button1_Click(object sender, EventArgs e)
        {
            //创建一个新线程去执行这个方法  
             thread = new Thread(Test);
            //标记这个线程准备就绪了，可以随时被执行。具体什么时候被执行，由CPU决定
            var IsAlive = thread.IsAlive;
            var IsThreadPoolThread = thread.IsThreadPoolThread;
            thread.IsBackground = true;　　//后台线程
            //所有前台线程都关闭了，程序关闭；所有前台线程都关闭了，后台线程自动关闭
            thread.Start();
            //Test();
           
        }

        private void Test()
        {
            for (int i = 0; i < 50000; i++)
            {
                textBox1.Text = i.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //关闭窗体事件的作用是防止直接关闭程序时，线程访问不到textbox从而引发的异常
            if (thread != null)
            {
                thread.Abort();
            }
        }
    }
}
