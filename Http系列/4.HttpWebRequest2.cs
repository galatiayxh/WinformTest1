using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Http系列
{
    static class HttpWebRequest2
    {
        //静态方法传递两个参数，Post_String是单纯的链接，Post_Data是post的参数用以请求
        public static string Info_Geter_Post_Get(string Post_String, string Post_Data)
        {
            try
            {
                string s_Connection_String = Post_String;

                //实例化一个HttpWebrequst对象
                HttpWebRequest Info_Request = (HttpWebRequest)WebRequest.Create(s_Connection_String);

                //设置Requst的模式
                Info_Request.Method = "POST";

                //设置Content-Type Http标头的值，该值为默认值
                Info_Request.ContentType = "application/x-www-form-urlencoded";

                //预设响应等待时间
                Info_Request.Timeout = 20000;

                //建立一个Stream对象来写入Requst请求的参数流内涵url和key值等
                Stream Info_Stream = Info_Request.GetRequestStream();

                //调用Write方法第一个参数是获取传递参数的值得类型，第二个是流起始位置，第三个参数指流的长度
                Info_Stream.Write(Encoding.UTF8.GetBytes(Post_Data), 0, Encoding.UTF8.GetBytes(Post_Data).Length);

                //实例化一个HttpWebResponse用GetResponse方法用以获取服务器返回的响应
                HttpWebResponse Info_Response = (HttpWebResponse)Info_Request.GetResponse();

                //实例化一个StreamReader对象来获取Response的GetResponseStream返回的响应的体
                StreamReader Info_Reader = new StreamReader(Info_Response.GetResponseStream(), Encoding.UTF8);

                return Info_Reader.ReadToEnd() + "";



            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
                return "";
            }
        }
        /// <summary>
        /// 获取url的返回值
        /// </summary>
        /// <param name="url">eg:http://m.weather.com.cn/atad/101010100.html </param>
        public static string GetInfo(string url)
        {
            string strBuff = "";
            Uri httpURL = new Uri(url);
            ///HttpWebRequest类继承于WebRequest，并没有自己的构造函数，需通过WebRequest的Creat方法 建立，并进行强制的类型转换 
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(httpURL);
            ///通过HttpWebRequest的GetResponse()方法建立HttpWebResponse,强制类型转换 
            HttpWebResponse httpResp = (HttpWebResponse)httpReq.GetResponse();
            ///GetResponseStream()方法获取HTTP响应的数据流,并尝试取得URL中所指定的网页内容 
            ///若成功取得网页的内容，则以System.IO.Stream形式返回，若失败则产生ProtoclViolationException错 误。在此正确的做法应将以下的代码放到一个try块中处理。这里简单处理 
            Stream respStream = httpResp.GetResponseStream();
            ///返回的内容是Stream形式的，所以可以利用StreamReader类获取GetResponseStream的内容，并以 
            //StreamReader类的Read方法依次读取网页源程序代码每一行的内容，直至行尾（读取的编码格式：UTF8） 
            StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
            strBuff = respStreamReader.ReadToEnd();
            return strBuff;
        }
        /// <summary> 
        /// Get方式获取url地址输出内容 
        /// </summary> /// <param name="url">url</param> 
        /// <param name="encoding">返回内容编码方式，例如：Encoding.UTF8</param> 
        public static String SendRequest(String url, Encoding encoding)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "GET";
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader sr = new StreamReader(webResponse.GetResponseStream(), encoding);
            return sr.ReadToEnd();
        }
    }
}
