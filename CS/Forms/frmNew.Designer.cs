namespace Solution
{
    partial class frmNew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtBookName = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSource = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblExcelWeb = new System.Windows.Forms.Label();
            this.lblExcelFile = new System.Windows.Forms.Label();
            this.rbExcelWeb = new System.Windows.Forms.RadioButton();
            this.rbExcelFile = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDNS = new System.Windows.Forms.TextBox();
            this.rbWeb = new System.Windows.Forms.RadioButton();
            this.rbLink = new System.Windows.Forms.RadioButton();
            this.rbInner = new System.Windows.Forms.RadioButton();
            this.dlg = new System.Windows.Forms.OpenFileDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkENC = new System.Windows.Forms.CheckBox();
            this.UpDown1 = new System.Windows.Forms.NumericUpDown();
            this.rbSale = new System.Windows.Forms.RadioButton();
            this.rbTrial = new System.Windows.Forms.RadioButton();
            this.rbFree = new System.Windows.Forms.RadioButton();
            this.lblSourceDirectory = new System.Windows.Forms.Label();
            this.btnSource = new System.Windows.Forms.Button();
            this.lblDestDirectory = new System.Windows.Forms.Label();
            this.btnDest = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnDest);
            this.groupBox1.Controls.Add(this.lblDestDirectory);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(369, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 240);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[保存位置]";
            // 
            // lblPath
            // 
            this.lblPath.AutoEllipsis = true;
            this.lblPath.BackColor = System.Drawing.Color.Transparent;
            this.lblPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPath.ForeColor = System.Drawing.Color.White;
            this.lblPath.Location = new System.Drawing.Point(371, 264);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(300, 21);
            this.lblPath.TabIndex = 1;
            this.lblPath.Text = "\\";
            // 
            // txtBookName
            // 
            this.txtBookName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBookName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtBookName.Font = new System.Drawing.Font("宋体", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBookName.Location = new System.Drawing.Point(11, 457);
            this.txtBookName.Name = "txtBookName";
            this.txtBookName.Size = new System.Drawing.Size(440, 23);
            this.txtBookName.TabIndex = 3;
            this.txtBookName.Text = "（图书名称）";
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Image = global::My.Resources.Resources.form03;
            this.btnOK.Location = new System.Drawing.Point(515, 442);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(68, 30);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Image = global::My.Resources.Resources.form03;
            this.btnCancel.Location = new System.Drawing.Point(606, 442);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnSource);
            this.groupBox2.Controls.Add(this.lblSourceDirectory);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(11, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(343, 237);
            this.groupBox2.TabIndex = 64;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "[素材位置]";
            // 
            // lblSource
            // 
            this.lblSource.AutoEllipsis = true;
            this.lblSource.BackColor = System.Drawing.Color.Transparent;
            this.lblSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSource.ForeColor = System.Drawing.Color.White;
            this.lblSource.Location = new System.Drawing.Point(14, 264);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(338, 21);
            this.lblSource.TabIndex = 65;
            this.lblSource.Text = "\\";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.lblExcelWeb);
            this.groupBox3.Controls.Add(this.lblExcelFile);
            this.groupBox3.Controls.Add(this.rbExcelWeb);
            this.groupBox3.Controls.Add(this.rbExcelFile);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtDNS);
            this.groupBox3.Controls.Add(this.rbWeb);
            this.groupBox3.Controls.Add(this.rbLink);
            this.groupBox3.Controls.Add(this.rbInner);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(11, 300);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(663, 103);
            this.groupBox3.TabIndex = 66;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "[内容设置]";
            // 
            // lblExcelWeb
            // 
            this.lblExcelWeb.AutoSize = true;
            this.lblExcelWeb.Location = new System.Drawing.Point(347, 85);
            this.lblExcelWeb.Name = "lblExcelWeb";
            this.lblExcelWeb.Size = new System.Drawing.Size(11, 12);
            this.lblExcelWeb.TabIndex = 8;
            this.lblExcelWeb.Text = "-";
            // 
            // lblExcelFile
            // 
            this.lblExcelFile.AutoSize = true;
            this.lblExcelFile.Location = new System.Drawing.Point(34, 85);
            this.lblExcelFile.Name = "lblExcelFile";
            this.lblExcelFile.Size = new System.Drawing.Size(11, 12);
            this.lblExcelFile.TabIndex = 7;
            this.lblExcelFile.Text = "-";
            // 
            // rbExcelWeb
            // 
            this.rbExcelWeb.AutoSize = true;
            this.rbExcelWeb.Location = new System.Drawing.Point(394, 63);
            this.rbExcelWeb.Name = "rbExcelWeb";
            this.rbExcelWeb.Size = new System.Drawing.Size(239, 16);
            this.rbExcelWeb.TabIndex = 6;
            this.rbExcelWeb.Text = "网站批量导入（需指定目录文件 Excel）";
            this.rbExcelWeb.UseVisualStyleBackColor = true;
            this.rbExcelWeb.CheckedChanged += new System.EventHandler(this.rbExcelWeb_CheckedChanged);
            // 
            // rbExcelFile
            // 
            this.rbExcelFile.AutoSize = true;
            this.rbExcelFile.Location = new System.Drawing.Point(16, 63);
            this.rbExcelFile.Name = "rbExcelFile";
            this.rbExcelFile.Size = new System.Drawing.Size(239, 16);
            this.rbExcelFile.TabIndex = 5;
            this.rbExcelFile.Text = "本地批量导入（需指定目录文件 Excel）";
            this.rbExcelFile.UseVisualStyleBackColor = true;
            this.rbExcelFile.CheckedChanged += new System.EventHandler(this.rbExcelFile_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 7.471698F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(433, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 10);
            this.label1.TabIndex = 4;
            this.label1.Text = "示例：http://www.google.cn/book/)";
            // 
            // txtDNS
            // 
            this.txtDNS.Location = new System.Drawing.Point(322, 21);
            this.txtDNS.Name = "txtDNS";
            this.txtDNS.Size = new System.Drawing.Size(320, 21);
            this.txtDNS.TabIndex = 3;
            // 
            // rbWeb
            // 
            this.rbWeb.AutoSize = true;
            this.rbWeb.Location = new System.Drawing.Point(245, 22);
            this.rbWeb.Name = "rbWeb";
            this.rbWeb.Size = new System.Drawing.Size(71, 16);
            this.rbWeb.TabIndex = 2;
            this.rbWeb.Text = "网站链接";
            this.rbWeb.UseVisualStyleBackColor = true;
            // 
            // rbLink
            // 
            this.rbLink.AutoSize = true;
            this.rbLink.Checked = true;
            this.rbLink.Location = new System.Drawing.Point(137, 22);
            this.rbLink.Name = "rbLink";
            this.rbLink.Size = new System.Drawing.Size(71, 16);
            this.rbLink.TabIndex = 1;
            this.rbLink.TabStop = true;
            this.rbLink.Text = "外挂文件";
            this.rbLink.UseVisualStyleBackColor = true;
            // 
            // rbInner
            // 
            this.rbInner.AutoSize = true;
            this.rbInner.Location = new System.Drawing.Point(16, 21);
            this.rbInner.Name = "rbInner";
            this.rbInner.Size = new System.Drawing.Size(71, 16);
            this.rbInner.TabIndex = 0;
            this.rbInner.Text = "内容内置";
            this.rbInner.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.checkENC);
            this.groupBox4.Controls.Add(this.UpDown1);
            this.groupBox4.Controls.Add(this.rbSale);
            this.groupBox4.Controls.Add(this.rbTrial);
            this.groupBox4.Controls.Add(this.rbFree);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(11, 408);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(439, 43);
            this.groupBox4.TabIndex = 67;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "[版权设置]";
            // 
            // checkENC
            // 
            this.checkENC.AutoSize = true;
            this.checkENC.ForeColor = System.Drawing.Color.Red;
            this.checkENC.Location = new System.Drawing.Point(350, 18);
            this.checkENC.Name = "checkENC";
            this.checkENC.Size = new System.Drawing.Size(72, 16);
            this.checkENC.TabIndex = 4;
            this.checkENC.Text = "加密文档";
            this.checkENC.UseVisualStyleBackColor = true;
            // 
            // UpDown1
            // 
            this.UpDown1.Location = new System.Drawing.Point(158, 18);
            this.UpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.UpDown1.Name = "UpDown1";
            this.UpDown1.Size = new System.Drawing.Size(50, 21);
            this.UpDown1.TabIndex = 3;
            this.UpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // rbSale
            // 
            this.rbSale.AutoSize = true;
            this.rbSale.Location = new System.Drawing.Point(245, 20);
            this.rbSale.Name = "rbSale";
            this.rbSale.Size = new System.Drawing.Size(59, 16);
            this.rbSale.TabIndex = 2;
            this.rbSale.Text = "收费版";
            this.rbSale.UseVisualStyleBackColor = true;
            // 
            // rbTrial
            // 
            this.rbTrial.AutoSize = true;
            this.rbTrial.Location = new System.Drawing.Point(104, 20);
            this.rbTrial.Name = "rbTrial";
            this.rbTrial.Size = new System.Drawing.Size(47, 16);
            this.rbTrial.TabIndex = 1;
            this.rbTrial.Text = "试读";
            this.rbTrial.UseVisualStyleBackColor = true;
            // 
            // rbFree
            // 
            this.rbFree.AutoSize = true;
            this.rbFree.Checked = true;
            this.rbFree.Location = new System.Drawing.Point(16, 20);
            this.rbFree.Name = "rbFree";
            this.rbFree.Size = new System.Drawing.Size(47, 16);
            this.rbFree.TabIndex = 0;
            this.rbFree.TabStop = true;
            this.rbFree.Text = "免费";
            this.rbFree.UseVisualStyleBackColor = true;
            // 
            // lblSourceDirectory
            // 
            this.lblSourceDirectory.AutoEllipsis = true;
            this.lblSourceDirectory.BackColor = System.Drawing.Color.Transparent;
            this.lblSourceDirectory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSourceDirectory.Location = new System.Drawing.Point(34, 34);
            this.lblSourceDirectory.Name = "lblSourceDirectory";
            this.lblSourceDirectory.Size = new System.Drawing.Size(282, 124);
            this.lblSourceDirectory.TabIndex = 0;
            this.lblSourceDirectory.Text = "(素材目录)";
            // 
            // btnSource
            // 
            this.btnSource.Location = new System.Drawing.Point(241, 186);
            this.btnSource.Name = "btnSource";
            this.btnSource.Size = new System.Drawing.Size(75, 23);
            this.btnSource.TabIndex = 1;
            this.btnSource.Text = "浏览";
            this.btnSource.UseVisualStyleBackColor = true;
            this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
            // 
            // lblDestDirectory
            // 
            this.lblDestDirectory.AutoEllipsis = true;
            this.lblDestDirectory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDestDirectory.Location = new System.Drawing.Point(26, 34);
            this.lblDestDirectory.Name = "lblDestDirectory";
            this.lblDestDirectory.Size = new System.Drawing.Size(258, 124);
            this.lblDestDirectory.TabIndex = 0;
            this.lblDestDirectory.Text = "(图书目录)";
            // 
            // btnDest
            // 
            this.btnDest.Location = new System.Drawing.Point(209, 186);
            this.btnDest.Name = "btnDest";
            this.btnDest.Size = new System.Drawing.Size(75, 23);
            this.btnDest.TabIndex = 1;
            this.btnDest.Text = "浏览";
            this.btnDest.UseVisualStyleBackColor = true;
            this.btnDest.Click += new System.EventHandler(this.btnDest_Click);
            // 
            // frmNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::My.Resources.Resources.topnav_bar_shadow;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(695, 491);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtBookName);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmNew";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建电子书";
            this.Load += new System.EventHandler(this.frmNew_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtBookName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbInner;
        private System.Windows.Forms.RadioButton rbLink;
        private System.Windows.Forms.RadioButton rbWeb;
        private System.Windows.Forms.TextBox txtDNS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbExcelFile;
        private System.Windows.Forms.RadioButton rbExcelWeb;
        private System.Windows.Forms.Label lblExcelFile;
        private System.Windows.Forms.Label lblExcelWeb;
        private System.Windows.Forms.OpenFileDialog dlg;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbFree;
        private System.Windows.Forms.NumericUpDown UpDown1;
        private System.Windows.Forms.RadioButton rbSale;
        private System.Windows.Forms.RadioButton rbTrial;
        private System.Windows.Forms.CheckBox checkENC;
        private System.Windows.Forms.Label lblDestDirectory;
        private System.Windows.Forms.Button btnSource;
        private System.Windows.Forms.Label lblSourceDirectory;
        private System.Windows.Forms.Button btnDest;
    }
}