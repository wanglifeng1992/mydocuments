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
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class frmView : System.Windows.Forms.Form
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
                this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
                this.cmenuClose = new System.Windows.Forms.ToolStripMenuItem();
                this.ContextMenuStrip1.SuspendLayout();
                this.SuspendLayout();
                // 
                // ContextMenuStrip1
                // 
                this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmenuClose});
                this.ContextMenuStrip1.Name = "ContextMenuStrip1";
                this.ContextMenuStrip1.Size = new System.Drawing.Size(101, 26);
                // 
                // cmenuClose
                // 
                this.cmenuClose.Name = "cmenuClose";
                this.cmenuClose.Size = new System.Drawing.Size(100, 22);
                this.cmenuClose.Text = "关闭";
                this.cmenuClose.Click += new System.EventHandler(this.cmenuClose_Click);
                // 
                // frmView
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                this.BackgroundImage = global::My.Resources.Resources.border;
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.ClientSize = new System.Drawing.Size(584, 420);
                this.ContextMenuStrip = this.ContextMenuStrip1;
                this.DoubleBuffered = true;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Name = "frmView";
                this.ShowInTaskbar = false;
                this.Text = "frmView";
                this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                this.Load += new System.EventHandler(this.frmView_Load);
                this.ContextMenuStrip1.ResumeLayout(false);
                this.ResumeLayout(false);

            }
		internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip1;
		internal System.Windows.Forms.ToolStripMenuItem cmenuClose;
        private System.ComponentModel.IContainer components;
	}
	
}
