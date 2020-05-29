using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Http系列
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strImageURL = "http://test-imaging.oss-cn-hangzhou.aliyuncs.com/Picutre/1730a8b0-3fc1-4c94-8f78-cc53447b5d2d/1366/2020/dcea804c-e51a-40f8-b6a3-bea9e9f20194.png?Expires=3738056270&OSSAccessKeyId=w0hFljLIV1wbGBWX&Signature=4TLiKYxPc0EukRWsjNguWJbXrec%3D";

            System.Net.WebClient webClient = new System.Net.WebClient();
            webClient.DownloadFile(strImageURL, @"D:\image\1.png");
        }
    }
}
