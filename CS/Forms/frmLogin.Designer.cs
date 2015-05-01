namespace Solution
{
    partial class frmLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.Panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.TaskPath = new System.Windows.Forms.Label();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnImpData = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.ListView1 = new System.Windows.Forms.ListView();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.ListView2 = new System.Windows.Forms.ListView();
            this.Label4 = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.dlg = new System.Windows.Forms.OpenFileDialog();
            this.fld = new System.Windows.Forms.FolderBrowserDialog();
            this.Panel2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.Panel2.Controls.Add(this.btnCancel);
            this.Panel2.Controls.Add(this.btnOK);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel2.Location = new System.Drawing.Point(0, 346);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(679, 31);
            this.Panel2.TabIndex = 45;
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(590, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOK.BackgroundImage")));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOK.Location = new System.Drawing.Point(500, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(79, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // TaskPath
            // 
            this.TaskPath.BackColor = System.Drawing.Color.Transparent;
            this.TaskPath.Location = new System.Drawing.Point(13, 226);
            this.TaskPath.Name = "TaskPath";
            this.TaskPath.Size = new System.Drawing.Size(343, 23);
            this.TaskPath.TabIndex = 47;
            this.TaskPath.Text = ".";
            this.TaskPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ImageList1
            // 
            this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "png-0758.png");
            this.ImageList1.Images.SetKeyName(1, "png-0814.png");
            // 
            // btnImpData
            // 
            this.btnImpData.BackgroundImage = global::My.Resources.Resources._001;
            this.btnImpData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImpData.ForeColor = System.Drawing.Color.Yellow;
            this.btnImpData.Location = new System.Drawing.Point(572, 226);
            this.btnImpData.Name = "btnImpData";
            this.btnImpData.Size = new System.Drawing.Size(79, 25);
            this.btnImpData.TabIndex = 2;
            this.btnImpData.Text = "图书目录";
            this.ToolTip1.SetToolTip(this.btnImpData, "当前学习的课程的文件存放位置。");
            this.btnImpData.UseVisualStyleBackColor = true;
            this.btnImpData.Click += new System.EventHandler(this.btnImpData_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GroupBox1.Controls.Add(this.tabControl1);
            this.GroupBox1.Controls.Add(this.TaskPath);
            this.GroupBox1.Controls.Add(this.btnImpData);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.lblFile);
            this.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GroupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GroupBox1.ForeColor = System.Drawing.Color.White;
            this.GroupBox1.Location = new System.Drawing.Point(12, 5);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(657, 335);
            this.GroupBox1.TabIndex = 44;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "【资源清单】";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabPage1);
            this.tabControl1.Controls.Add(this.TabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(3, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(651, 201);
            this.tabControl1.TabIndex = 48;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.ListView1);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(643, 175);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "当前书库";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // ListView1
            // 
            this.ListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView1.Location = new System.Drawing.Point(3, 3);
            this.ListView1.Name = "ListView1";
            this.ListView1.Size = new System.Drawing.Size(637, 169);
            this.ListView1.TabIndex = 0;
            this.ListView1.UseCompatibleStateImageBehavior = false;
            this.ListView1.Click += new System.EventHandler(this.ListView1_Click);
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.ListView2);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(643, 175);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "默认书库";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // ListView2
            // 
            this.ListView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView2.Location = new System.Drawing.Point(3, 3);
            this.ListView2.Name = "ListView2";
            this.ListView2.Size = new System.Drawing.Size(637, 169);
            this.ListView2.TabIndex = 0;
            this.ListView2.UseCompatibleStateImageBehavior = false;
            this.ListView2.Click += new System.EventHandler(this.ListView2_Click);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(13, 255);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(70, 14);
            this.Label4.TabIndex = 47;
            this.Label4.Text = "当前图书:";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFile
            // 
            this.lblFile.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblFile.Location = new System.Drawing.Point(13, 281);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(628, 34);
            this.lblFile.TabIndex = 46;
            this.lblFile.Text = "(选择的图书)";
            // 
            // dlg
            // 
            this.dlg.DefaultExt = "bin";
            this.dlg.Filter = "任务文件 |*.baiedu";
            this.dlg.Title = "选择任务文件，并导入到系统中。";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Green;
            this.BackgroundImage = global::My.Resources.Resources.topnav_bar_shadow;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(679, 377);
            this.ControlBox = false;
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.GroupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.Panel2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.ToolTip ToolTip1;
        internal System.Windows.Forms.Label TaskPath;
        internal System.Windows.Forms.ImageList ImageList1;
        internal System.Windows.Forms.Button btnImpData;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label lblFile;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.OpenFileDialog dlg;
        internal System.Windows.Forms.FolderBrowserDialog fld;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabPage1;
        private System.Windows.Forms.TabPage TabPage2;
        private System.Windows.Forms.ListView ListView1;
        private System.Windows.Forms.ListView ListView2;
    }
}