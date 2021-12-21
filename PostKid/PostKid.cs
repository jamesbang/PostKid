using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace PostKid
{
    public partial class PostKid : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private SendCase[] caseData;
        private TextBox[] headerKeys;
        private TextBox[] headerValues;

        public PostKid()
        {
            InitializeComponent();
            init();
        }

        /// <summary>
        /// 
        /// </summary>
        private void init() {
            this.Text = String.Format("{0} {1}", Application.ProductName, Application.ProductVersion);
            string postData = "{\"to\":\"devide_reg_token\",\"data\":{\"title\":\"偉大的航道\",\"message\":\"我要當海賊王\"}}";
            caseData = new SendCase[2];

            //FCM
            SendCase fcm = new SendCase();
            fcm.setName("FCM");
            fcm.setPostData(postData);
            fcm.setURL("https://fcm.googleapis.com/fcm/send");
            fcm.setHeader("Authorization", "key=fcm_key");
            caseData[0] = fcm;

            //GCM
            SendCase gcm = new SendCase();
            gcm.setName("GCM");
            gcm.setPostData(postData);
            gcm.setURL("https://gcm-http.googleapis.com/gcm/send");
            gcm.setHeader("Authorization", "key=gcm_key");
            caseData[1] = gcm;

            this.comboBox_case_data.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox_http_method.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox_case_data.Items.Add(fcm.getName());
            this.comboBox_case_data.Items.Add(gcm.getName());
            this.comboBox_http_method.SelectedIndex = 0;

            headerKeys = new TextBox[]{ textBox_key_1, textBox_key_2, textBox_key_3, textBox_key_4 };
            headerValues = new TextBox[] { textBox_value_1, textBox_value_2, textBox_value_3, textBox_value_4 };
            this.ActiveControl = textBox_url;//讓游標停在這個 textbox

            Assembly asm = Assembly.GetExecutingAssembly();
            string name = asm.GetName().Name+ ".NLog.config";
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name)) {
                if (stream == null) {
                    return;
                }
                using (StreamReader reader = new StreamReader(stream))
                {
                    string result = reader.ReadToEnd();
                    string currentDir = System.IO.Directory.GetCurrentDirectory();
                    System.IO.StringReader sr = new System.IO.StringReader(result);
                    System.Xml.XmlReader xr = System.Xml.XmlReader.Create(sr);
                    NLog.LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(xr, currentDir);
                }
            }
        }

        private void cleanInputFieldData() {
            this.comboBox_case_data.Enabled = false;
            this.comboBox_case_data.SelectedIndex = -1;
            this.textBox_url.Text = "";
            this.textBox_rq.Text = "";
            this.textBox_rs.Text = "";
            for (int i = 0; i < headerKeys.Length; i++)
            {
                headerKeys[i].Text = "";
                headerValues[i].Text = "";
            }
        }

        private void enableHeaders(bool enable) {
            SendCase sendCaseData = caseData[comboBox_case_data.SelectedIndex];
            int index = checkBox_case.Checked != true ? 0 : sendCaseData.getHeaders().Count;
            for (int i = 0; i < headerKeys.Length; i++)
            {
                headerKeys[i].Enabled = enable;
                headerValues[i].Enabled = (checkBox_case.Checked && i<index)? checkBox_case.Checked : enable;
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            string url = textBox_url.Text.Replace(" ","");
            if (url.Length == 0) {
                MessageBox.Show("請輸入URL");
                return;
            }
            string contentType = textBox_content_type.Text.Replace(" ", "");
            if (contentType.Length == 0)
            {
                MessageBox.Show("請輸入ContentType");
                return;
            }
            string request = textBox_rq.Text.Replace("\r\n", "").Replace(" ", "");
            if (request.Length == 0 && isHttpPOST(comboBox_http_method.SelectedItem.ToString()))
            {
                MessageBox.Show("請輸入Request內容");
                return;
            }

            System.Net.ServicePointManager.Expect100Continue = false;
            btn_send.Enabled = false;
            textBox_rs.Text = "";
            Uri target = new Uri(url);
            //HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebRequest webRequest = HttpWebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = comboBox_http_method.SelectedItem.ToString();
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/94.0.4606.81 Safari/537.36";
            webRequest.Timeout = 30000;
            
            //是否選擇預設case
            if (checkBox_case.Checked)
            {
                SendCase sendCaseData = caseData[comboBox_case_data.SelectedIndex];
                Dictionary<string, string> headers = sendCaseData.getHeaders();
                foreach (string key in headers.Keys)
                {
                    if (key.Length == 0) {
                        continue;
                    }
                    webRequest.Headers.Set(key, headers[key]);
                }
            }

            System.Net.ServicePointManager.Expect100Continue = false;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            if (isHttpPOST(webRequest.Method))
            {
                post(webRequest, request, contentType);
            }
            else if (isHttpGET(webRequest.Method))
            {
                get(webRequest);
            }
            else {
                MessageBox.Show("尚未支援【" + webRequest.Method + "】");
            }
                                   
        }

        private bool isHttpPOST(string value) {
            return "POST".Equals(value.ToUpper());
        }

        private bool isHttpGET(string value)
        {
            return "GET".Equals(value.ToUpper());
        }

        private void post(HttpWebRequest webRequest,string request,string contentType) {
            byte[] byteArray = Encoding.UTF8.GetBytes(request);
            webRequest.AllowAutoRedirect = false;  // 禁止重新導向網頁
            webRequest.ContentType = contentType;
            //webRequest.ContentLength = byteArray.Length;
            //set Headers
            for (int i = 0; i < headerKeys.Length; i++) {
                string key = headerKeys[i].Text.Replace(" ","");
                if ("".Equals(key)) {
                    continue;
                }
                string value = headerValues[i].Text.Replace(" ", "");
                if ("Accept".Equals(key)) {
                    webRequest.Accept = value;
                } else if ("Connection".Equals(key)) {
                    webRequest.Connection = value;
                } else {
                    webRequest.Headers.Set(key, value);
                }
            }

            //Request
            
            try
            {
                logger.Info(String.Format("Request：{0}",request));
                /*
                StreamWriter write = new StreamWriter(webRequest.GetRequestStream(), Encoding.UTF8);
                write.Write(request,0, webRequest.ContentLength);
                write.Flush();
                */
                
                using (var dataStream = webRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }
                
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                btn_send.Enabled = true;
                textBox_rs.Text = ex.Message;
            }
            get(webRequest);
        }

        private void get(HttpWebRequest webRequest) {
            //Response
            try
            {
                using (HttpWebResponse response = webRequest.GetResponse() as HttpWebResponse)
                {

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var reader = new StreamReader(response.GetResponseStream());
                        string content = reader.ReadToEnd();
                        logger.Info(String.Format("Response：{0}", content));
                        textBox_rs.Text = content;
                    }
                    else
                    {
                        string tipMessage = "Status Code: " + response.StatusCode + "\n" +
                            "Status Description: " + response.StatusDescription;
                        logger.Warn(tipMessage);
                        textBox_rs.Text = tipMessage;
                    }

                    response.Close();
                    btn_send.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                btn_send.Enabled = true;
                textBox_rs.Text = ex.Message;
            }
        }

        /// <summary>
        /// 選擇 Send Case 範例
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;
            if (selectedIndex == -1)
            {
                return;
            }
            //設定 SendCase Data
            SendCase sendCaseData = caseData[selectedIndex];
            textBox_url.Text = sendCaseData.getURL();
            textBox_content_type.Text = sendCaseData.getContentType();
            textBox_rq.Text = sendCaseData.getPostData();
            comboBox_http_method.SelectedText = sendCaseData.getHttpMethod();
            
            //帶出預設的 header
            Dictionary<string, string> headers = sendCaseData.getHeaders();
            int i = 0;
            foreach (string key in headers.Keys)
            {
                headerKeys[i].Text = key;
                headerValues[i].Text = headers[key];
                i++;
            }
        }

        /// <summary>
        /// 是否啟用 Send Case
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_case_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked)
            {
                this.comboBox_case_data.Enabled = true;
                this.comboBox_case_data.SelectedIndex = 0;
                enableHeaders(false);
            }
            else
            {
                enableHeaders(true);
                cleanInputFieldData();
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 說明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Format("這是一個不能使用 Postman 而生的小程式...{0}{1}", Environment.NewLine, this.Text));
        }

        /// <summary>
        /// 選擇 HTTP Method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_http_method_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            if (isHttpGET(cmb.SelectedItem.ToString()))
            {
                textBox_rq.Enabled = false;
            }
            else {
                textBox_rq.Enabled = true;
            }
        }
    }
}
