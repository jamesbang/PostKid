using System.Collections.Generic;

namespace PostKid
{
    class SendCase
    {
        private string name;
        private string url;
        private string postData;
        private string httpMethod = "POST";
        private readonly string contentType = "application/json";
        private Dictionary<string,string> headers;

        public SendCase() {
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
            headers.Add(key,value);
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

        public string getHttpMethod() {
            return httpMethod;
        }

        public void clearHeaders() {
            if (headers != null) {
                headers.Clear();
            }
        }
    }
}