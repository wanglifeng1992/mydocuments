namespace Solution
{
    partial class frmSetFile
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
            this.btnM = new System.Windows.Forms.Button();
            this.txtMedia = new System.Windows.Forms.TextBox();
            this.btnN = new System.Windows.Forms.Button();
            this.btnU = new System.Windows.Forms.Button();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.btnL = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtNew = new System.Windows.Forms.TextBox();
            this.txtUpdate = new System.Windows.Forms.TextBox();
            this.dlg = new System.Windows.Forms.OpenFileDialog();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtHypLink = new System.Windows.Forms.TextBox();
            this.btnWebLink = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWebAddress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnM
            // 
            this.btnM.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnM.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnM.ForeColor = System.Drawing.Color.White;
            this.btnM.Image = global::My.Resources.Resources.Ftr_BG_reflec;
            this.btnM.Location = new System.Drawing.Point(398, 45);
            this.btnM.Margin = new System.Windows.Forms.Padding(2);
            this.btnM.Name = "btnM";
            this.btnM.Size = new System.Drawing.Size(84, 24);
            this.btnM.TabIndex = 0;
            this.btnM.Text = "配套视频";
            this.btnM.UseVisualStyleBackColor = true;
            this.btnM.Click += new System.EventHandler(this.btnM_Click);
            // 
            // txtMedia
            // 
            this.txtMedia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMedia.Location = new System.Drawing.Point(12, 45);
            this.txtMedia.Margin = new System.Windows.Forms.Padding(2);
            this.txtMedia.Name = "txtMedia";
            this.txtMedia.Size = new System.Drawing.Size(382, 22);
            this.txtMedia.TabIndex = 0;
            // 
            // btnN
            // 
            this.btnN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnN.ForeColor = System.Drawing.Color.White;
            this.btnN.Image = global::My.Resources.Resources.Ftr_BG_reflec;
            this.btnN.Location = new System.Drawing.Point(398, 92);
            this.btnN.Name = "btnN";
            this.btnN.Size = new System.Drawing.Size(84, 24);
            this.btnN.TabIndex = 1;
            this.btnN.Text = "新建内容";
            this.btnN.UseVisualStyleBackColor = true;
            this.btnN.Click += new System.EventHandler(this.btnN_Click);
            // 
            // btnU
            // 
            this.btnU.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnU.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnU.ForeColor = System.Drawing.Color.White;
            this.btnU.Image = global::My.Resources.Resources.Ftr_BG_reflec;
            this.btnU.Location = new System.Drawing.Point(398, 131);
            this.btnU.Margin = new System.Windows.Forms.Padding(2);
            this.btnU.Name = "btnU";
            this.btnU.Size = new System.Drawing.Size(84, 24);
            this.btnU.TabIndex = 2;
            this.btnU.Text = "更换内容";
            this.btnU.UseVisualStyleBackColor = true;
            this.btnU.Click += new System.EventHandler(this.btnU_Click);
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(12, 171);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(381, 22);
            this.txtLink.TabIndex = 55;
            // 
            // btnL
            // 
            this.btnL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnL.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnL.ForeColor = System.Drawing.Color.White;
            this.btnL.Image = global::My.Resources.Resources.Ftr_BG_reflec;
            this.btnL.Location = new System.Drawing.Point(398, 171);
            this.btnL.Margin = new System.Windows.Forms.Padding(2);
            this.btnL.Name = "btnL";
            this.btnL.Size = new System.Drawing.Size(84, 24);
            this.btnL.TabIndex = 3;
            this.btnL.Text = "链接文件";
            this.btnL.UseVisualStyleBackColor = true;
            this.btnL.Click += new System.EventHandler(this.btnL_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitle.Location = new System.Drawing.Point(8, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(477, 23);
            this.lblTitle.TabIndex = 57;
            this.lblTitle.Text = "(章节)";
            // 
            // txtNew
            // 
            this.txtNew.Location = new System.Drawing.Point(12, 93);
            this.txtNew.Name = "txtNew";
            this.txtNew.Size = new System.Drawing.Size(381, 22);
            this.txtNew.TabIndex = 58;
            // 
            // txtUpdate
            // 
            this.txtUpdate.Location = new System.Drawing.Point(12, 132);
            this.txtUpdate.Name = "txtUpdate";
            this.txtUpdate.Size = new System.Drawing.Size(380, 22);
            this.txtUpdate.TabIndex = 59;
            // 
            // dlg
            // 
            this.dlg.InitialDirectory = "c:\\\\";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOK.BackgroundImage = global::My.Resources.Resources.form03;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(281, 285);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 31);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancel.BackgroundImage = global::My.Resources.Resources.form03;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(398, 285);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 31);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtHypLink
            // 
            this.txtHypLink.Location = new System.Drawing.Point(72, 209);
            this.txtHypLink.Name = "txtHypLink";
            this.txtHypLink.Size = new System.Drawing.Size(320, 22);
            this.txtHypLink.TabIndex = 4;
            // 
            // btnWebLink
            // 
            this.btnWebLink.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnWebLink.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWebLink.ForeColor = System.Drawing.Color.White;
            this.btnWebLink.Image = global::My.Resources.Resources.Ftr_BG_reflec;
            this.btnWebLink.Location = new System.Drawing.Point(397, 209);
            this.btnWebLink.Margin = new System.Windows.Forms.Padding(2);
            this.btnWebLink.Name = "btnWebLink";
            this.btnWebLink.Size = new System.Drawing.Size(84, 24);
            this.btnWebLink.TabIndex = 6;
            this.btnWebLink.Text = "链接网站";
            this.btnWebLink.UseVisualStyleBackColor = true;
            this.btnWebLink.Click += new System.EventHandler(this.btnWebLink_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 21);
            this.label1.TabIndex = 64;
            this.label1.Text = "标题：";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 23);
            this.label2.TabIndex = 65;
            this.label2.Text = "地址：";
            // 
            // txtWebAddress
            // 
            this.txtWebAddress.Location = new System.Drawing.Point(73, 237);
            this.txtWebAddress.Name = "txtWebAddress";
            this.txtWebAddress.Size = new System.Drawing.Size(319, 22);
            this.txtWebAddress.TabIndex = 5;
            this.txtWebAddress.TextChanged += new System.EventHandler(this.txtWebAddress_TextChanged);
            // 
            // frmSetFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(106F, 106F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::My.Resources.Resources.border;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(496, 340);
            this.Controls.Add(this.txtWebAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnWebLink);
            this.Controls.Add(this.txtHypLink);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtUpdate);
            this.Controls.Add(this.txtNew);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnL);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.btnN);
            this.Controls.Add(this.btnU);
            this.Controls.Add(this.btnM);
            this.Controls.Add(this.txtMedia);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSetFile";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "章节设置";
            this.Load += new System.EventHandler(this.frmSetFile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnM;
        internal System.Windows.Forms.TextBox txtMedia;
        internal System.Windows.Forms.Button btnN;
        internal System.Windows.Forms.Button btnU;
        internal System.Windows.Forms.Button btnL;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtNew;
        private System.Windows.Forms.TextBox txtUpdate;
        private System.Windows.Forms.OpenFileDialog dlg;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.TextBox txtLink;
        internal System.Windows.Forms.Button btnWebLink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtHypLink;
        public System.Windows.Forms.TextBox txtWebAddress;
    }
}