using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            string url = "http://test-imaging.oss-cn-hangzhou.aliyuncs.com/Picutre/e8a5b2d4-4ff9-4bad-b0fe-dbfca2d95deb/103/2019/1efc4cf8-9bbb-4ee7-a0d9-e2c4b008c3f5.png?Expires=3701239328&OSSAccessKeyId=w0hFljLIV1wbGBWX&Signature=LfyORWen5It2JO45q7OmrXRrWRw%3D";


            var stream = RequestFromUrl.GetBytesFromUrl(url);
            RequestFromUrl.WriteBytesToFile(@"F:\Image\1.png", stream);
        }
    }
}
