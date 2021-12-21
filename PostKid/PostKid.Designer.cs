namespace PostKid
{
    partial class PostKid
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostKid));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_url = new System.Windows.Forms.TextBox();
            this.textBox_rq = new System.Windows.Forms.TextBox();
            this.textBox_rs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_send = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_content_type = new System.Windows.Forms.TextBox();
            this.comboBox_case_data = new System.Windows.Forms.ComboBox();
            this.checkBox_case = new System.Windows.Forms.CheckBox();
            this.comboBox_http_method = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_key_1 = new System.Windows.Forms.TextBox();
            this.textBox_value_1 = new System.Windows.Forms.TextBox();
            this.textBox_key_2 = new System.Windows.Forms.TextBox();
            this.textBox_value_2 = new System.Windows.Forms.TextBox();
            this.textBox_key_3 = new System.Windows.Forms.TextBox();
            this.textBox_value_3 = new System.Windows.Forms.TextBox();
            this.textBox_key_4 = new System.Windows.Forms.TextBox();
            this.textBox_value_4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.說明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // textBox_url
            // 
            resources.ApplyResources(this.textBox_url, "textBox_url");
            this.textBox_url.Name = "textBox_url";
            // 
            // textBox_rq
            // 
            resources.ApplyResources(this.textBox_rq, "textBox_rq");
            this.textBox_rq.Name = "textBox_rq";
            // 
            // textBox_rs
            // 
            resources.ApplyResources(this.textBox_rs, "textBox_rs");
            this.textBox_rs.Name = "textBox_rs";
            this.textBox_rs.ReadOnly = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // btn_send
            // 
            resources.ApplyResources(this.btn_send, "btn_send");
            this.btn_send.Name = "btn_send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // textBox_content_type
            // 
            resources.ApplyResources(this.textBox_content_type, "textBox_content_type");
            this.textBox_content_type.Name = "textBox_content_type";
            // 
            // comboBox_case_data
            // 
            resources.ApplyResources(this.comboBox_case_data, "comboBox_case_data");
            this.comboBox_case_data.FormattingEnabled = true;
            this.comboBox_case_data.Name = "comboBox_case_data";
            this.comboBox_case_data.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // checkBox_case
            // 
            resources.ApplyResources(this.checkBox_case, "checkBox_case");
            this.checkBox_case.Name = "checkBox_case";
            this.checkBox_case.UseVisualStyleBackColor = true;
            this.checkBox_case.CheckedChanged += new System.EventHandler(this.checkBox_case_CheckedChanged);
            // 
            // comboBox_http_method
            // 
            resources.ApplyResources(this.comboBox_http_method, "comboBox_http_method");
            this.comboBox_http_method.FormattingEnabled = true;
            this.comboBox_http_method.Items.AddRange(new object[] {
            resources.GetString("comboBox_http_method.Items"),
            resources.GetString("comboBox_http_method.Items1")});
            this.comboBox_http_method.Name = "comboBox_http_method";
            this.comboBox_http_method.SelectedIndexChanged += new System.EventHandler(this.comboBox_http_method_SelectedIndexChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox_rq);
            this.panel1.Controls.Add(this.textBox_rs);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.checkBox_case);
            this.panel2.Controls.Add(this.comboBox_case_data);
            this.panel2.Name = "panel2";
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.textBox_url);
            this.panel3.Controls.Add(this.comboBox_http_method);
            this.panel3.Name = "panel3";
            // 
            // panel4
            // 
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.textBox_content_type);
            this.panel4.Name = "panel4";
            // 
            // panel5
            // 
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Controls.Add(this.tableLayoutPanel1);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Name = "panel5";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.label7, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_key_1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_value_1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_key_2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_value_2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_key_3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox_value_3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox_key_4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBox_value_4, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // textBox_key_1
            // 
            resources.ApplyResources(this.textBox_key_1, "textBox_key_1");
            this.textBox_key_1.Name = "textBox_key_1";
            // 
            // textBox_value_1
            // 
            resources.ApplyResources(this.textBox_value_1, "textBox_value_1");
            this.textBox_value_1.Name = "textBox_value_1";
            // 
            // textBox_key_2
            // 
            resources.ApplyResources(this.textBox_key_2, "textBox_key_2");
            this.textBox_key_2.Name = "textBox_key_2";
            // 
            // textBox_value_2
            // 
            resources.ApplyResources(this.textBox_value_2, "textBox_value_2");
            this.textBox_value_2.Name = "textBox_value_2";
            // 
            // textBox_key_3
            // 
            resources.ApplyResources(this.textBox_key_3, "textBox_key_3");
            this.textBox_key_3.Name = "textBox_key_3";
            // 
            // textBox_value_3
            // 
            resources.ApplyResources(this.textBox_value_3, "textBox_value_3");
            this.textBox_value_3.Name = "textBox_value_3";
            // 
            // textBox_key_4
            // 
            resources.ApplyResources(this.textBox_key_4, "textBox_key_4");
            this.textBox_key_4.Name = "textBox_key_4";
            // 
            // textBox_value_4
            // 
            resources.ApplyResources(this.textBox_value_4, "textBox_value_4");
            this.textBox_value_4.Name = "textBox_value_4";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.說明ToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // 說明ToolStripMenuItem
            // 
            resources.ApplyResources(this.說明ToolStripMenuItem, "說明ToolStripMenuItem");
            this.說明ToolStripMenuItem.Name = "說明ToolStripMenuItem";
            this.說明ToolStripMenuItem.Click += new System.EventHandler(this.說明ToolStripMenuItem_Click);
            // 
            // PostKid
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PostKid";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_url;
        private System.Windows.Forms.TextBox textBox_rq;
        private System.Windows.Forms.TextBox textBox_rs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_content_type;
        private System.Windows.Forms.ComboBox comboBox_case_data;
        private System.Windows.Forms.CheckBox checkBox_case;
        private System.Windows.Forms.ComboBox comboBox_http_method;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_key_1;
        private System.Windows.Forms.TextBox textBox_value_1;
        private System.Windows.Forms.TextBox textBox_key_2;
        private System.Windows.Forms.TextBox textBox_value_2;
        private System.Windows.Forms.TextBox textBox_key_3;
        private System.Windows.Forms.TextBox textBox_value_3;
        private System.Windows.Forms.TextBox textBox_key_4;
        private System.Windows.Forms.TextBox textBox_value_4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 說明ToolStripMenuItem;
    }
}

