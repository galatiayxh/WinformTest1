using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace 多线程的Invoke的使用
{
    public partial class Form2 : Form
    {

        //创建一个Button对象  
        private Button button = new Button();
        //构造函数  
        public Form2()
        {
            InitializeComponent();

            //设置按钮的属性  
            button.Size = new Size(150, 100);   //大小  
            button.Click += Button1_Clicked;    //注册事件  
            button.Text = "点击开始测试";       //设置显示文本  
            this.Controls.Add(button);          //添加到窗体上  
            this.Text = "多线程范例";           //设置窗体的标题栏文本  
        }
        //按钮的Click事件响应方法  
        public void Button1_Clicked(object sender, EventArgs e)
        {
            //启动一个线程  
            new Thread(ThreadProc).Start();
        }
        //线程函数  
        public void ThreadProc()
        {
            //this.Invoke就是跨线程访问ui的方法，也是本文的范例  
            //首先invoke一个匿名委托，将button对象禁用  
            this.Invoke((EventHandler)delegate
            {
                button.Enabled = false;
            });

            //记录一个时间戳，以演示倒计时效果  
            int tick = Environment.TickCount;
            while (Environment.TickCount - tick < 1000)
            {
                //跨线程调用更新窗体上控件的属性，这里是更新这个按钮对象的Text属性  
                this.Invoke((EventHandler)delegate
                {
                    button.Text = (1000 - Environment.TickCount + tick).ToString() + "微秒后开始更新";
                });
                //做一个延迟，避免太快了，视觉效果不好。  
                Thread.Sleep(100);
            }
            //演示，10次数字递增显示  
            for (int i = 0; i < 10; i++)
            {
                this.Invoke((EventHandler)delegate
                {
                    button.Text = i.ToString();
                });
                Thread.Sleep(200);
            }
            //虽然不是循环内，请不要忘记，你的调用依然在辅助线程中，所以，还是需要invoke的。  
            //还原状态，设置按钮的文本为初始状态，设置按钮可用。  
            this.Invoke((EventHandler)delegate
            {
                button.Text = "点击开始测试";
                button.Enabled = true;
            });
        }

    }
}
