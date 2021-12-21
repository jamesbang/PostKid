using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PostKid.src
{
    class ConnectionManager
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static HttpMethod httpMethod;
        private static IConnectionListener connectionListener;
        public enum HttpMethod
        {
            POST,GET
        }
        public static bool IsHttpPOST()
        {
            return httpMethod == HttpMethod.POST;
        }

        public static bool IsHttpGET()
        {
            return httpMethod == HttpMethod.GET;
        }

        public static void Connection(HttpMethod method, SendData sendData, IConnectionListener listener) {
            httpMethod = method;
            connectionListener = listener;

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(sendData.getURL());
            webRequest.Method = method.ToString();
            webRequest.ContentType = sendData.getContentType();
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.103 Safari/537.36";

            switch (method) {
                case HttpMethod.GET:
                    Get(webRequest);
                    break;
                case HttpMethod.POST:
                    Post(webRequest, sendData);
                    break;
                default:
                    if (listener != null)
                    {
                        listener.OnConnectionFailed(String.Format("不支援的 Method: {0}",method));
                    }
                    break;
            }
        }

        private static void Post(HttpWebRequest webRequest, SendData sendData)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(sendData.getPostData());
            webRequest.ContentLength = byteArray.Length;
            //set Headers
            Dictionary<string, string> headers = sendData.getHeaders();
            foreach (string key in headers.Keys)
            {
                string headerKey = key.Replace(" ", "");
                if ("".Equals(headerKey))
                {
                    continue;
                }
                string headerValue = headers[key].Replace(" ", "");
                webRequest.Headers.Set(headerKey, headerValue);
            }
           
            //Request
            try
            {
                logger.Info(String.Format("Request：{0}", sendData.getPostData()));
                using (var dataStream = webRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                if (connectionListener != null) {
                    connectionListener.OnConnectionFailed(ex.Message);
                }
            }
            Get(webRequest);
        }

        private static void Get(HttpWebRequest webRequest)
        {
            //Response
            try
            {
                using (var response = (HttpWebResponse)webRequest.GetResponse())
                {

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var reader = new StreamReader(response.GetResponseStream());
                        string content = reader.ReadToEnd();
                        logger.Info(String.Format("Response：{0}", content));
                        if (connectionListener != null)
                        {
                            connectionListener.OnConnectionSuccess(content);
                        }
                        
                    }
                    else
                    {
                        string tipMessage = "Status Code: " + response.StatusCode + "\n" +
                            "Status Description: " + response.StatusDescription;
                        logger.Warn(tipMessage);
                        if (connectionListener != null)
                        {
                            connectionListener.OnConnectionFailed(tipMessage);
                        }
                        
                    }

                    response.Close();
                    
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                if (connectionListener != null)
                {
                    connectionListener.OnConnectionFailed(ex.Message);
                }
            }
        }

        public interface IConnectionListener{
            void OnConnectionSuccess(string content);
            void OnConnectionFailed(string errorMsg);
        }

    }
    
}
