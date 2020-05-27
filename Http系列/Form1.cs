using Newtonsoft.Json;
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

        internal class Test
        {
            public string grant_type { get; set; }
            public string scope { get; set; }
            public string client_id { get; set; }
            public string client_secret { get; set; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GetAccessToken("https://openplatform-app.lctest.cn:11001/connect/token");
        }
        public void GetAccessToken(string JijiaUrl)
        {
            //Dictionary<string, string> dic = new Dictionary<string, string> {
            //    {"grant_type", "client_credentials"},
            //    {"scope", "dimConnector.manufacturer"},
            //    {"client_id", "dimmanufacturer1"},
            //    {"client_secret", "8CLw0osGWJzE8IHYcjip"},
            //};
            //Test test = new Test() {
            //   grant_type = "client_credentials",
            //    scope = "dimConnector.manufacturer",
            //    client_id = "dimmanufacturer1",
            //    client_secret= "8CLw0osGWJzE8IHYcjip"
            //};


            string sss = "grant_type=client_credentials&scope=dimConnector.manufacturer&client_id=dimmanufacturer1&client_secret=8CLw0osGWJzE8IHYcjip";

            byte[] postData = Encoding.UTF8.GetBytes(sss);

            var request = (HttpWebRequest)WebRequest.Create(JijiaUrl);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postData.Length;
            //request.KeepAlive = false;
            //request.Timeout = 60000;

            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(postData, 0, postData.Length);
            }
            using (var response = request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    using (var streamReader = new StreamReader(responseStream))
                    {
                        var ssss = streamReader.ReadToEnd();
                        var responseModel = JsonConvert.DeserializeObject<JiJiaAccessToken>(ssss);
                        //var json = responseModel.access_token;
                        //if (responseModel != null)
                        //{
                        //    var accessToken = new FactoryAccessToken()
                        //    {
                        //        AccessToken = responseModel.access_token,
                        //        IsLogin = true,
                        //        ExpireTime = DateTime.Now.AddSeconds(Convert.ToInt32(responseModel.expires_in)),
                        //    };
                        //    return accessToken;
                        //    else
                        //    {
                        //        var accessToken = new FactoryAccessToken()
                        //        {
                        //            IsLogin = false,
                        //        };
                        //        return accessToken;
                        //    }
                        //}
                        //else
                        //{
                        //    return null;
                        //}
                    }
                }
            }
        }
    }


    public class FactoryAccessToken
    {
        public bool IsLogin { get; set; }
        public string AccessToken { get; set; }
        public DateTime ExpireTime { get; set; }
        public string ServerIPAddress { get; set; }
        public int ServerPort_WebHttp { get; set; }
        public bool EnableSSL_WebHttp { get; set; }
        public int ServerPort_WebSocket { get; set; }
        public bool EnableSSL_WebSocket { get; set; }
        public string ServerDomainName { get; set; }
        public int FactoryId { get; set; }
        public string FactoryServiceHttpUrl { get; set; }
        public string FactoryURL { get; set; }
    }
    internal class JiJiaAccessToken
    {
        /// 
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string expires_in { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string token_type { get; set; }
        //public bool IsLogin { get; set; }
    }
}
