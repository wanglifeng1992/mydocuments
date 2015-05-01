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
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class frmMedia : System.Windows.Forms.Form
		{
		
		//Form 重写 Dispose，以清理组件列表。
		[System.Diagnostics.DebuggerNonUserCode()]protected override void Dispose(bool disposing)
			{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
		
		//Windows 窗体设计器所必需的
		private System.ComponentModel.Container components = null;
		
		//注意: 以下过程是 Windows 窗体设计器所必需的
		//可以使用 Windows 窗体设计器修改它。
		//不要使用代码编辑器修改它。
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedia));
                this.axFlash1 = new AxShockwaveFlashObjects.AxShockwaveFlash();
                this.WebBrowser1 = new System.Windows.Forms.WebBrowser();
                ((System.ComponentModel.ISupportInitialize)(this.axFlash1)).BeginInit();
                this.SuspendLayout();
                // 
                // axFlash1
                // 
                this.axFlash1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.axFlash1.Enabled = true;
                this.axFlash1.Location = new System.Drawing.Point(0, 0);
                this.axFlash1.Name = "axFlash1";
                this.axFlash1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axFlash1.OcxState")));
                this.axFlash1.Size = new System.Drawing.Size(563, 382);
                this.axFlash1.TabIndex = 1;
                // 
                // WebBrowser1
                // 
                this.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.WebBrowser1.Location = new System.Drawing.Point(0, 0);
                this.WebBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
                this.WebBrowser1.Name = "WebBrowser1";
                this.WebBrowser1.Size = new System.Drawing.Size(563, 382);
                this.WebBrowser1.TabIndex = 0;
                // 
                // frmMedia
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                this.ClientSize = new System.Drawing.Size(563, 382);
                this.Controls.Add(this.axFlash1);
                this.Controls.Add(this.WebBrowser1);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.Margin = new System.Windows.Forms.Padding(2);
                this.Name = "frmMedia";
                this.Text = "视频播放";
                this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMedia_FormClosing);
                ((System.ComponentModel.ISupportInitialize)(this.axFlash1)).EndInit();
                this.ResumeLayout(false);

		}
        internal System.Windows.Forms.WebBrowser WebBrowser1;
        internal AxShockwaveFlashObjects.AxShockwaveFlash axFlash1;
	}
	
}
