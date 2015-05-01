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
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class frmDemo : System.Windows.Forms.Form
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
		
		internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
		
		//Windows 窗体设计器所必需的
		private System.ComponentModel.Container components = null;
		
		//注意: 以下过程是 Windows 窗体设计器所必需的
		//可以使用 Windows 窗体设计器修改它。
		//不要使用代码编辑器修改它。
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDemo));
                this.TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
                this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
                this.OKButton = new System.Windows.Forms.Button();
                this.Label1 = new System.Windows.Forms.Label();
                this.PictureBox1 = new System.Windows.Forms.PictureBox();
                this.TableLayoutPanel.SuspendLayout();
                this.TableLayoutPanel1.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
                this.SuspendLayout();
                // 
                // TableLayoutPanel
                // 
                this.TableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
                this.TableLayoutPanel.ColumnCount = 2;
                this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
                this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 98F));
                this.TableLayoutPanel.Controls.Add(this.TableLayoutPanel1, 1, 1);
                this.TableLayoutPanel.Controls.Add(this.Label1, 1, 0);
                this.TableLayoutPanel.Controls.Add(this.PictureBox1, 0, 0);
                this.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
                this.TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
                this.TableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
                this.TableLayoutPanel.Name = "TableLayoutPanel";
                this.TableLayoutPanel.RowCount = 2;
                this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78F));
                this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21F));
                this.TableLayoutPanel.Size = new System.Drawing.Size(404, 226);
                this.TableLayoutPanel.TabIndex = 0;
                // 
                // TableLayoutPanel1
                // 
                this.TableLayoutPanel1.ColumnCount = 2;
                this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19F));
                this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
                this.TableLayoutPanel1.Controls.Add(this.OKButton, 1, 0);
                this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.TableLayoutPanel1.Location = new System.Drawing.Point(73, 181);
                this.TableLayoutPanel1.Name = "TableLayoutPanel1";
                this.TableLayoutPanel1.RowCount = 1;
                this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
                this.TableLayoutPanel1.Size = new System.Drawing.Size(328, 42);
                this.TableLayoutPanel1.TabIndex = 2;
                // 
                // OKButton
                // 
                this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.OKButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OKButton.BackgroundImage")));
                this.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.OKButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                this.OKButton.ForeColor = System.Drawing.Color.White;
                this.OKButton.Location = new System.Drawing.Point(242, 11);
                this.OKButton.Name = "OKButton";
                this.OKButton.Size = new System.Drawing.Size(83, 28);
                this.OKButton.TabIndex = 1;
                this.OKButton.Text = "关闭(&O)";
                this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
                // 
                // Label1
                // 
                this.Label1.AutoSize = true;
                this.Label1.BackColor = System.Drawing.Color.Transparent;
                this.Label1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.Label1.Font = new System.Drawing.Font("Courier New", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label1.ForeColor = System.Drawing.Color.White;
                this.Label1.Location = new System.Drawing.Point(73, 0);
                this.Label1.Name = "Label1";
                this.Label1.Size = new System.Drawing.Size(328, 178);
                this.Label1.TabIndex = 4;
                this.Label1.Text = "Label1";
                this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // PictureBox1
                // 
                this.PictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PictureBox1.BackgroundImage")));
                this.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
                this.PictureBox1.Location = new System.Drawing.Point(3, 3);
                this.PictureBox1.Name = "PictureBox1";
                this.PictureBox1.Size = new System.Drawing.Size(64, 63);
                this.PictureBox1.TabIndex = 3;
                this.PictureBox1.TabStop = false;
                // 
                // frmDemo
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(106F, 106F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                this.BackColor = System.Drawing.Color.White;
                this.BackgroundImage = global::My.Resources.Resources.topnav_bar_shadow;
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.ClientSize = new System.Drawing.Size(404, 226);
                this.ControlBox = false;
                this.Controls.Add(this.TableLayoutPanel);
                this.DoubleBuffered = true;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Name = "frmDemo";
                this.ShowInTaskbar = false;
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "提示！";
                this.TableLayoutPanel.ResumeLayout(false);
                this.TableLayoutPanel.PerformLayout();
                this.TableLayoutPanel1.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
                this.ResumeLayout(false);

		}
		internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
		internal System.Windows.Forms.Button OKButton;
		internal System.Windows.Forms.PictureBox PictureBox1;
		internal System.Windows.Forms.Label Label1;
		
	}
	
}
