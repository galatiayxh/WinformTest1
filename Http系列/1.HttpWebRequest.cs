using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Http系列
{
    public class HttpWebRequestDemo
    {
        //POST方法
        public static string HttpPost(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            Encoding encoding = Encoding.UTF8;
            byte[] postData = encoding.GetBytes(postDataStr);
            request.ContentLength = postData.Length;
            //request.Headers.Add("Authorization", "Bearer " + Convert.ToBase64String(Encoding.UTF8.GetBytes($"{Username}:{Password}"))); //Outh2 Client 方式认证。

            Stream myRequestStream = request.GetRequestStream();
            myRequestStream.Write(postData, 0, postData.Length);
            myRequestStream.Close();

            //GetResponse 方法对 RequestUri 属性中指定的资源进行同步请求，并返回包含响应对象的 HttpWebResponse。
            //RequestUri 属性指定url
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();//同步的
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, encoding);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
                
            return retString;
        }
        //GET方法
        public static string HttpGet(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            //返回来自internet的响应
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //读取响应体的流
            Stream myResponseStream = response.GetResponseStream();
            //用指定的字符编码为指定的流初始化 System.IO.StreamReader 类的一个新实例。
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }
    }
}
