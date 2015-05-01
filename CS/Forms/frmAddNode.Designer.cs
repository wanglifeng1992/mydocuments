namespace Solution
{
    partial class frmAddNode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddNode));
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoChild = new System.Windows.Forms.RadioButton();
            this.rdoBoot = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblSelectedNode = new System.Windows.Forms.Label();
            this.lblAddToNode = new System.Windows.Forms.Label();
            this.lblNewItem = new System.Windows.Forms.Label();
            this.tbNewItem = new System.Windows.Forms.TextBox();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(13, 80);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(140, 14);
            this.Label1.TabIndex = 49;
            this.Label1.Text = "选择一个现有的条目:";
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.Controls.Add(this.rdoChild);
            this.GroupBox1.Controls.Add(this.rdoBoot);
            this.GroupBox1.Location = new System.Drawing.Point(13, 184);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(179, 42);
            this.GroupBox1.TabIndex = 48;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "[选项]";
            // 
            // rdoChild
            // 
            this.rdoChild.AutoSize = true;
            this.rdoChild.Checked = true;
            this.rdoChild.Location = new System.Drawing.Point(94, 19);
            this.rdoChild.Name = "rdoChild";
            this.rdoChild.Size = new System.Drawing.Size(67, 18);
            this.rdoChild.TabIndex = 1;
            this.rdoChild.TabStop = true;
            this.rdoChild.Text = "子项级";
            this.rdoChild.UseVisualStyleBackColor = true;
            // 
            // rdoBoot
            // 
            this.rdoBoot.AutoSize = true;
            this.rdoBoot.Location = new System.Drawing.Point(13, 19);
            this.rdoBoot.Name = "rdoBoot";
            this.rdoBoot.Size = new System.Drawing.Size(67, 18);
            this.rdoBoot.TabIndex = 0;
            this.rdoBoot.Text = "最高级";
            this.rdoBoot.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(300, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(59, 26);
            this.btnCancel.TabIndex = 46;
            this.btnCancel.Text = "取消";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ComboBox1
            // 
            this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Location = new System.Drawing.Point(12, 100);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(350, 21);
            this.ComboBox1.TabIndex = 47;
            this.ComboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedValueChanged);
            // 
            // btnOK
            // 
            this.btnOK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOK.BackgroundImage")));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOK.Location = new System.Drawing.Point(222, 200);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(59, 26);
            this.btnOK.TabIndex = 45;
            this.btnOK.Text = "确定";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOK.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblSelectedNode
            // 
            this.lblSelectedNode.BackColor = System.Drawing.Color.White;
            this.lblSelectedNode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSelectedNode.ForeColor = System.Drawing.Color.Red;
            this.lblSelectedNode.Location = new System.Drawing.Point(16, 32);
            this.lblSelectedNode.Name = "lblSelectedNode";
            this.lblSelectedNode.Size = new System.Drawing.Size(351, 26);
            this.lblSelectedNode.TabIndex = 42;
            this.lblSelectedNode.Text = "标题";
            this.lblSelectedNode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAddToNode
            // 
            this.lblAddToNode.BackColor = System.Drawing.Color.Transparent;
            this.lblAddToNode.Location = new System.Drawing.Point(16, 11);
            this.lblAddToNode.Name = "lblAddToNode";
            this.lblAddToNode.Size = new System.Drawing.Size(351, 14);
            this.lblAddToNode.TabIndex = 41;
            this.lblAddToNode.Text = "添加到现有条目下:";
            // 
            // lblNewItem
            // 
            this.lblNewItem.BackColor = System.Drawing.Color.Transparent;
            this.lblNewItem.Location = new System.Drawing.Point(11, 139);
            this.lblNewItem.Name = "lblNewItem";
            this.lblNewItem.Size = new System.Drawing.Size(351, 19);
            this.lblNewItem.TabIndex = 43;
            this.lblNewItem.Text = "新标题名称:";
            // 
            // tbNewItem
            // 
            this.tbNewItem.Location = new System.Drawing.Point(11, 160);
            this.tbNewItem.Name = "tbNewItem";
            this.tbNewItem.Size = new System.Drawing.Size(351, 22);
            this.tbNewItem.TabIndex = 44;
            // 
            // frmAddNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(106F, 106F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(385, 251);
            this.ControlBox = false;
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblSelectedNode);
            this.Controls.Add(this.lblAddToNode);
            this.Controls.Add(this.lblNewItem);
            this.Controls.Add(this.tbNewItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddNode";
            this.ShowInTaskbar = false;
            this.Text = "添加新目录";
            this.Load += new System.EventHandler(this.frmAddNode_Load);
            this.Activated += new System.EventHandler(this.frmAddNode_Activated);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.RadioButton rdoChild;
        internal System.Windows.Forms.RadioButton rdoBoot;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.ComboBox ComboBox1;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Label lblSelectedNode;
        internal System.Windows.Forms.Label lblAddToNode;
        internal System.Windows.Forms.Label lblNewItem;
        internal System.Windows.Forms.TextBox tbNewItem;
    }
}