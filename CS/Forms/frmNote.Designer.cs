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
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class frmNote : System.Windows.Forms.Form
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
		private System.ComponentModel.Container components = null;
		
		//注意: 以下过程是 Windows 窗体设计器所必需的
		//可以使用 Windows 窗体设计器修改它。
		//不要使用代码编辑器修改它。
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNote));
                this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
                this.rtfTemp = new RichTextBoxExtended.RichTextBoxExtended();
                this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
                this.btnOK = new System.Windows.Forms.Button();
                this.btnCancel = new System.Windows.Forms.Button();
                this.Label1 = new System.Windows.Forms.Label();
                this.TableLayoutPanel1.SuspendLayout();
                this.TableLayoutPanel2.SuspendLayout();
                this.SuspendLayout();
                // 
                // TableLayoutPanel1
                // 
                this.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
                this.TableLayoutPanel1.ColumnCount = 1;
                this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                this.TableLayoutPanel1.Controls.Add(this.rtfTemp, 0, 0);
                this.TableLayoutPanel1.Controls.Add(this.TableLayoutPanel2, 0, 1);
                this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
                this.TableLayoutPanel1.Name = "TableLayoutPanel1";
                this.TableLayoutPanel1.RowCount = 2;
                this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.59483F));
                this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.405172F));
                this.TableLayoutPanel1.Size = new System.Drawing.Size(647, 409);
                this.TableLayoutPanel1.TabIndex = 0;
                // 
                // rtfTemp
                // 
                this.rtfTemp.AcceptsTab = true;
                this.rtfTemp.AutoScroll = true;
                this.rtfTemp.AutoWordSelection = true;
                this.rtfTemp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                this.rtfTemp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.rtfTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.rtfTemp.DetectURLs = true;
                this.rtfTemp.Dock = System.Windows.Forms.DockStyle.Fill;
                this.rtfTemp.ForeColor = System.Drawing.Color.Maroon;
                this.rtfTemp.Location = new System.Drawing.Point(3, 3);
                this.rtfTemp.Name = "rtfTemp";
                this.rtfTemp.ShowBold = true;
                this.rtfTemp.ShowBullet = true;
                this.rtfTemp.ShowCenterJustify = true;
                this.rtfTemp.ShowColors = true;
                this.rtfTemp.ShowCopy = true;
                this.rtfTemp.ShowCut = true;
                this.rtfTemp.ShowFont = true;
                this.rtfTemp.ShowItalic = true;
                this.rtfTemp.ShowLeftJustify = true;
                this.rtfTemp.ShowOpen = true;
                this.rtfTemp.ShowPaste = true;
                this.rtfTemp.ShowRedo = true;
                this.rtfTemp.ShowRightJustify = true;
                this.rtfTemp.ShowSave = true;
                this.rtfTemp.ShowShrink = false;
                this.rtfTemp.ShowStamp = false;
                this.rtfTemp.ShowStrikeout = true;
                this.rtfTemp.ShowUnderline = true;
                this.rtfTemp.ShowUndo = false;
                this.rtfTemp.ShowZoom = false;
                this.rtfTemp.Size = new System.Drawing.Size(641, 368);
                this.rtfTemp.StampAction = RichTextBoxExtended.StampActions.EditedBy;
                this.rtfTemp.StampColor = System.Drawing.Color.Blue;
                this.rtfTemp.TabIndex = 1;
                // 
                // TableLayoutPanel2
                // 
                this.TableLayoutPanel2.ColumnCount = 3;
                this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.46313F));
                this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
                this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.53687F));
                this.TableLayoutPanel2.Controls.Add(this.btnOK, 0, 0);
                this.TableLayoutPanel2.Controls.Add(this.btnCancel, 1, 0);
                this.TableLayoutPanel2.Controls.Add(this.Label1, 0, 0);
                this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
                this.TableLayoutPanel2.Location = new System.Drawing.Point(3, 377);
                this.TableLayoutPanel2.Name = "TableLayoutPanel2";
                this.TableLayoutPanel2.RowCount = 1;
                this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
                this.TableLayoutPanel2.Size = new System.Drawing.Size(641, 29);
                this.TableLayoutPanel2.TabIndex = 2;
                // 
                // btnOK
                // 
                this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Right;
                this.btnOK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOK.BackgroundImage")));
                this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.White;
                this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                this.btnOK.ForeColor = System.Drawing.Color.White;
                this.btnOK.Location = new System.Drawing.Point(497, 3);
                this.btnOK.Name = "btnOK";
                this.btnOK.Size = new System.Drawing.Size(70, 22);
                this.btnOK.TabIndex = 3;
                this.btnOK.Text = "确定";
                this.btnOK.UseVisualStyleBackColor = true;
                this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
                // 
                // btnCancel
                // 
                this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
                this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
                this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                this.btnCancel.ForeColor = System.Drawing.Color.White;
                this.btnCancel.Location = new System.Drawing.Point(574, 3);
                this.btnCancel.Name = "btnCancel";
                this.btnCancel.Size = new System.Drawing.Size(64, 22);
                this.btnCancel.TabIndex = 1;
                this.btnCancel.Text = "取消";
                this.btnCancel.UseVisualStyleBackColor = true;
                this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
                // 
                // Label1
                // 
                this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                this.Label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                this.Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                this.Label1.Location = new System.Drawing.Point(3, 2);
                this.Label1.Name = "Label1";
                this.Label1.Size = new System.Drawing.Size(488, 25);
                this.Label1.TabIndex = 2;
                this.Label1.Text = "章节";
                this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // frmNote
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(106F, 106F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                this.BackgroundImage = global::My.Resources.Resources.topnav_bar_shadow;
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.ClientSize = new System.Drawing.Size(647, 409);
                this.ControlBox = false;
                this.Controls.Add(this.TableLayoutPanel1);
                this.DoubleBuffered = true;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Name = "frmNote";
                this.ShowInTaskbar = false;
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "读书笔记";
                this.Deactivate += new System.EventHandler(this.frmNote_Deactivate);
                this.Activated += new System.EventHandler(this.frmNote_Activated);
                this.TableLayoutPanel1.ResumeLayout(false);
                this.TableLayoutPanel2.ResumeLayout(false);
                this.ResumeLayout(false);

		}
		internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
		internal RichTextBoxExtended.RichTextBoxExtended rtfTemp;
		internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
		internal System.Windows.Forms.Button btnCancel;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button btnOK;
	}
	
}
