using System.Collections.Generic;
using static PostKid.src.ConnectionManager;

namespace PostKid
{
    class SendData
    {
        private string name;
        private string url;
        private string postData;
        private HttpMethod httpMethod = HttpMethod.POST;
        private readonly string contentType = "application/json";
        private Dictionary<string,string> headers;

        public SendData() {
            headers = new Dictionary<string, string>();
        }

        public void setName(string value) {
            this.name = value;
        }
        public void setURL(string value)
        {
            this.url = value;
        }

        public void setPostData(string value)
        {
            this.postData = value;
        }

        public void setHeader(string key, string value) {
            if (headers.ContainsKey(key))
            {
                headers[key] = value;
            }
            else
            {
                headers.Add(key, value);
            }
            
        }

        public string getName() {
            return name;
        }

        public string getURL()
        {
            return url;
        }

        public string getPostData()
        {
            return postData;
        }

        public string getContentType() {
            return contentType;
        }

        public Dictionary<string, string> getHeaders() {
            return headers;
        }

        public HttpMethod getHttpMethod() {
            return httpMethod;
        }

        public void setHttpMethod(string method) {
            method = method.ToUpper();
            if ("POST".Equals(method)) {
                httpMethod = HttpMethod.POST;
            } else if ("GET".Equals(method)) {
                httpMethod = HttpMethod.GET;
            } else {
                httpMethod = HttpMethod.POST;
            }
        }

    }
}