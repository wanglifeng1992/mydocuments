using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data;
using AxWMPLib;

namespace Solution
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class frmTpl : System.Windows.Forms.Form
		{
		
		//Form 重写 Dispose，以清理组件列表。
		[System.Diagnostics.DebuggerNonUserCode()]protected override void Dispose(bool disposing)
			{
			try
			{
				if (disposing && (components != null))
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

        //Windows 窗体设计器所必需的
		
		//注意: 以下过程是 Windows 窗体设计器所必需的
		//可以使用 Windows 窗体设计器修改它。
		//不要使用代码编辑器修改它。
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
                this.components = new System.ComponentModel.Container();
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTpl));
                this.OK_Button = new System.Windows.Forms.Button();
                this.Cancel_Button = new System.Windows.Forms.Button();
                this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
                this.GroupBox1 = new System.Windows.Forms.GroupBox();
                this.rdF = new System.Windows.Forms.RadioButton();
                this.rdR = new System.Windows.Forms.RadioButton();
                this.rdP = new System.Windows.Forms.RadioButton();
                this.GroupBox1.SuspendLayout();
                this.SuspendLayout();
                // 
                // OK_Button
                // 
                this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
                this.OK_Button.BackColor = System.Drawing.Color.White;
                this.OK_Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OK_Button.BackgroundImage")));
                this.OK_Button.FlatAppearance.BorderColor = System.Drawing.Color.White;
                this.OK_Button.FlatAppearance.BorderSize = 0;
                this.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                this.OK_Button.ForeColor = System.Drawing.Color.White;
                this.OK_Button.Location = new System.Drawing.Point(185, 126);
                this.OK_Button.Name = "OK_Button";
                this.OK_Button.Size = new System.Drawing.Size(74, 23);
                this.OK_Button.TabIndex = 0;
                this.OK_Button.Text = "确定";
                this.OK_Button.UseVisualStyleBackColor = true;
                this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
                // 
                // Cancel_Button
                // 
                this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
                this.Cancel_Button.BackColor = System.Drawing.Color.White;
                this.Cancel_Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Cancel_Button.BackgroundImage")));
                this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Cancel_Button.FlatAppearance.BorderColor = System.Drawing.Color.White;
                this.Cancel_Button.FlatAppearance.BorderSize = 0;
                this.Cancel_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                this.Cancel_Button.ForeColor = System.Drawing.Color.White;
                this.Cancel_Button.Location = new System.Drawing.Point(278, 126);
                this.Cancel_Button.Name = "Cancel_Button";
                this.Cancel_Button.Size = new System.Drawing.Size(74, 23);
                this.Cancel_Button.TabIndex = 1;
                this.Cancel_Button.Text = "取消";
                this.Cancel_Button.UseVisualStyleBackColor = false;
                this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
                // 
                // ImageList1
                // 
                this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
                this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
                this.ImageList1.Images.SetKeyName(0, "108_51.gif");
                // 
                // GroupBox1
                // 
                this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
                this.GroupBox1.Controls.Add(this.rdF);
                this.GroupBox1.Controls.Add(this.rdR);
                this.GroupBox1.Controls.Add(this.rdP);
                this.GroupBox1.Location = new System.Drawing.Point(14, 6);
                this.GroupBox1.Name = "GroupBox1";
                this.GroupBox1.Size = new System.Drawing.Size(338, 97);
                this.GroupBox1.TabIndex = 1;
                this.GroupBox1.TabStop = false;
                // 
                // rdF
                // 
                this.rdF.AutoSize = true;
                this.rdF.ForeColor = System.Drawing.Color.Purple;
                this.rdF.Location = new System.Drawing.Point(242, 46);
                this.rdF.Name = "rdF";
                this.rdF.Size = new System.Drawing.Size(81, 18);
                this.rdF.TabIndex = 2;
                this.rdF.TabStop = true;
                this.rdF.Text = "已经阅读";
                this.rdF.UseVisualStyleBackColor = true;
                this.rdF.CheckedChanged += new System.EventHandler(this.rdF_CheckedChanged);
                // 
                // rdR
                // 
                this.rdR.AutoSize = true;
                this.rdR.ForeColor = System.Drawing.Color.LightSeaGreen;
                this.rdR.Location = new System.Drawing.Point(129, 46);
                this.rdR.Name = "rdR";
                this.rdR.Size = new System.Drawing.Size(81, 18);
                this.rdR.TabIndex = 1;
                this.rdR.TabStop = true;
                this.rdR.Text = "正在阅读";
                this.rdR.UseVisualStyleBackColor = true;
                this.rdR.CheckedChanged += new System.EventHandler(this.rdR_CheckedChanged);
                // 
                // rdP
                // 
                this.rdP.AutoSize = true;
                this.rdP.ForeColor = System.Drawing.Color.Blue;
                this.rdP.Location = new System.Drawing.Point(18, 46);
                this.rdP.Name = "rdP";
                this.rdP.Size = new System.Drawing.Size(81, 18);
                this.rdP.TabIndex = 0;
                this.rdP.TabStop = true;
                this.rdP.Text = "计划阅读";
                this.rdP.UseVisualStyleBackColor = true;
                this.rdP.CheckedChanged += new System.EventHandler(this.rdP_CheckedChanged);
                // 
                // frmTpl
                // 
                this.AcceptButton = this.OK_Button;
                this.AutoScaleDimensions = new System.Drawing.SizeF(106F, 106F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                this.BackColor = System.Drawing.Color.WhiteSmoke;
                this.BackgroundImage = global::My.Resources.Resources.topnav_bar_shadow;
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.CancelButton = this.Cancel_Button;
                this.ClientSize = new System.Drawing.Size(365, 151);
                this.ControlBox = false;
                this.Controls.Add(this.Cancel_Button);
                this.Controls.Add(this.OK_Button);
                this.Controls.Add(this.GroupBox1);
                this.DoubleBuffered = true;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Name = "frmTpl";
                this.ShowInTaskbar = false;
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                this.Text = "状态设置";
                this.Load += new System.EventHandler(this.frmTpl_Load);
                this.GroupBox1.ResumeLayout(false);
                this.GroupBox1.PerformLayout();
                this.ResumeLayout(false);

		}
		internal System.Windows.Forms.Button OK_Button;
		internal System.Windows.Forms.Button Cancel_Button;
		internal System.Windows.Forms.ImageList ImageList1;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.RadioButton rdF;
		internal System.Windows.Forms.RadioButton rdR;
		internal System.Windows.Forms.RadioButton rdP;
        private System.ComponentModel.IContainer components;
		
	}
	
}
