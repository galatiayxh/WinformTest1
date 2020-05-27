using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Http系列
{
    class Authentication认证
    {
        public void Http() {
            // c#项目中用到调用客户接口，basic身份认证，base64格式加密（用户名:密码）贴上代码以备后用

            //1、使用HttpClient实现basic身份认证

            using (HttpClient client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{Username}:{Password}")));
                HttpContent httpContent = new StringContent("", Encoding.UTF8);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                Uri address = new Uri("接口地址");
                var response = client.PostAsync(address, httpContent).Result.Content.ReadAsStringAsync().Result;//返回值
            }



            //2、使用HttpWebRequest实现basic身份认证

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("接口地址");
            request.Method = "Post";
            request.CookieContainer = new CookieContainer();
            request.ContentType = "application/json;";

            //（1）设置请求Credentials
            CredentialCache credentialCache = new CredentialCache();
            credentialCache.Add(new Uri("接口地址"), "Basic", new NetworkCredential("用户名", "密码"));
            request.Credentials = credentialCache;

            //（2）设置Headers Authorization
           // request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes($"{Username}:{Password}")));


            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string content = reader.ReadToEnd();
                }
            }
        }
    }
}
