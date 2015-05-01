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
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class Splash : System.Windows.Forms.Form
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
        internal System.Windows.Forms.TableLayoutPanel MainLayoutPanel;
		
		//Windows 窗体设计器所必需的
		private System.ComponentModel.Container components = null;
		
		//注意: 以下过程是 Windows 窗体设计器所必需的
		//可以使用 Windows 窗体设计器修改它。
		//不要使用代码编辑器修改它。
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
                this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
                this.MainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
                this.Product = new System.Windows.Forms.Label();
                this.PictureBox2 = new System.Windows.Forms.PictureBox();
                this.Panel1 = new System.Windows.Forms.Panel();
                this.Label1 = new System.Windows.Forms.Label();
                this.TableLayoutPanel1.SuspendLayout();
                this.MainLayoutPanel.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
                this.Panel1.SuspendLayout();
                this.SuspendLayout();
                // 
                // TableLayoutPanel1
                // 
                this.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
                this.TableLayoutPanel1.ColumnCount = 1;
                this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                this.TableLayoutPanel1.Controls.Add(this.MainLayoutPanel, 0, 0);
                this.TableLayoutPanel1.Controls.Add(this.Panel1, 0, 1);
                this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
                this.TableLayoutPanel1.Name = "TableLayoutPanel1";
                this.TableLayoutPanel1.RowCount = 2;
                this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.61364F));
                this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.386364F));
                this.TableLayoutPanel1.Size = new System.Drawing.Size(575, 342);
                this.TableLayoutPanel1.TabIndex = 1;
                // 
                // MainLayoutPanel
                // 
                this.MainLayoutPanel.BackColor = System.Drawing.Color.Transparent;
                this.MainLayoutPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MainLayoutPanel.BackgroundImage")));
                this.MainLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.MainLayoutPanel.ColumnCount = 2;
                this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                this.MainLayoutPanel.Controls.Add(this.Product, 0, 1);
                this.MainLayoutPanel.Controls.Add(this.PictureBox2, 0, 0);
                this.MainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
                this.MainLayoutPanel.Location = new System.Drawing.Point(0, 0);
                this.MainLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
                this.MainLayoutPanel.Name = "MainLayoutPanel";
                this.MainLayoutPanel.RowCount = 2;
                this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.11364F));
                this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.88636F));
                this.MainLayoutPanel.Size = new System.Drawing.Size(575, 316);
                this.MainLayoutPanel.TabIndex = 0;
                // 
                // Product
                // 
                this.Product.BackColor = System.Drawing.Color.Transparent;
                this.Product.Dock = System.Windows.Forms.DockStyle.Fill;
                this.Product.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                this.Product.ForeColor = System.Drawing.Color.Black;
                this.Product.Location = new System.Drawing.Point(0, 253);
                this.Product.Margin = new System.Windows.Forms.Padding(0);
                this.Product.Name = "Product";
                this.Product.Size = new System.Drawing.Size(287, 63);
                this.Product.TabIndex = 3;
                this.Product.Text = "多媒体电子书阅读工具";
                this.Product.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // 
                // PictureBox2
                // 
                this.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.PictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
                this.PictureBox2.Location = new System.Drawing.Point(3, 3);
                this.PictureBox2.Name = "PictureBox2";
                this.PictureBox2.Size = new System.Drawing.Size(281, 247);
                this.PictureBox2.TabIndex = 4;
                this.PictureBox2.TabStop = false;
                this.PictureBox2.Click += new System.EventHandler(this.PictureBox2_Click);
                // 
                // Panel1
                // 
                this.Panel1.BackColor = System.Drawing.Color.Transparent;
                this.Panel1.Controls.Add(this.Label1);
                this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.Panel1.Location = new System.Drawing.Point(3, 319);
                this.Panel1.Name = "Panel1";
                this.Panel1.Size = new System.Drawing.Size(569, 20);
                this.Panel1.TabIndex = 1;
                // 
                // Label1
                // 
                this.Label1.BackColor = System.Drawing.Color.Transparent;
                this.Label1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.Label1.ForeColor = System.Drawing.Color.Black;
                this.Label1.Location = new System.Drawing.Point(0, 0);
                this.Label1.Name = "Label1";
                this.Label1.Size = new System.Drawing.Size(569, 20);
                this.Label1.TabIndex = 0;
                this.Label1.Text = "信箱：renwoxue@sina.com QQ:921128279 www.renwoxue.net";
                this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // Splash
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                this.BackColor = System.Drawing.Color.WhiteSmoke;
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.ClientSize = new System.Drawing.Size(575, 342);
                this.ControlBox = false;
                this.Controls.Add(this.TableLayoutPanel1);
                this.DoubleBuffered = true;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Name = "Splash";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "书童多媒体电子书阅读器";
                this.Load += new System.EventHandler(this.Splash_Load);
                this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Splash_MouseClick);
                this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Splash_MouseDown);
                this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Splash_KeyDown);
                this.TableLayoutPanel1.ResumeLayout(false);
                this.MainLayoutPanel.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
                this.Panel1.ResumeLayout(false);
                this.ResumeLayout(false);

            }
		internal System.Windows.Forms.Label Product;
		internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
		internal System.Windows.Forms.Panel Panel1;
		internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.PictureBox PictureBox2;
		
	}
	
}
