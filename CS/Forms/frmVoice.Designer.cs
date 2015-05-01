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
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class frmVoice : System.Windows.Forms.Form
		{
		
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]protected override void Dispose(bool disposing)
			{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
		
		//Required by the Windows Form Designer
		private System.ComponentModel.Container components = null;
		
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVoice));
                this.txtSpeach = new System.Windows.Forms.RichTextBox();
                this.cmbVoices = new System.Windows.Forms.ComboBox();
                this.Label1 = new System.Windows.Forms.Label();
                this.btnSpeak = new System.Windows.Forms.Button();
                this.flTxtFile = new System.Windows.Forms.OpenFileDialog();
                this.trVolume = new System.Windows.Forms.TrackBar();
                this.Label2 = new System.Windows.Forms.Label();
                this.SaveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
                this.Label3 = new System.Windows.Forms.Label();
                this.trRate = new System.Windows.Forms.TrackBar();
                this.btnStop = new System.Windows.Forms.Button();
                this.btnResume = new System.Windows.Forms.Button();
                this.btnClose = new System.Windows.Forms.Button();
                ((System.ComponentModel.ISupportInitialize)(this.trVolume)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.trRate)).BeginInit();
                this.SuspendLayout();
                // 
                // txtSpeach
                // 
                this.txtSpeach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.txtSpeach.Location = new System.Drawing.Point(28, 149);
                this.txtSpeach.Name = "txtSpeach";
                this.txtSpeach.Size = new System.Drawing.Size(413, 152);
                this.txtSpeach.TabIndex = 1;
                this.txtSpeach.Text = "Enter text here";
                // 
                // cmbVoices
                // 
                this.cmbVoices.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                this.cmbVoices.FormattingEnabled = true;
                this.cmbVoices.Location = new System.Drawing.Point(131, 9);
                this.cmbVoices.Name = "cmbVoices";
                this.cmbVoices.Size = new System.Drawing.Size(310, 21);
                this.cmbVoices.TabIndex = 2;
                // 
                // Label1
                // 
                this.Label1.BackColor = System.Drawing.Color.Transparent;
                this.Label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                this.Label1.Location = new System.Drawing.Point(14, 17);
                this.Label1.Name = "Label1";
                this.Label1.Size = new System.Drawing.Size(111, 18);
                this.Label1.TabIndex = 3;
                this.Label1.Text = "选择语音类型：";
                // 
                // btnSpeak
                // 
                this.btnSpeak.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSpeak.BackgroundImage")));
                this.btnSpeak.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.btnSpeak.FlatAppearance.BorderColor = System.Drawing.Color.Black;
                this.btnSpeak.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                this.btnSpeak.ForeColor = System.Drawing.Color.White;
                this.btnSpeak.Location = new System.Drawing.Point(20, 324);
                this.btnSpeak.Name = "btnSpeak";
                this.btnSpeak.Size = new System.Drawing.Size(80, 25);
                this.btnSpeak.TabIndex = 0;
                this.btnSpeak.Text = "朗读文本";
                this.btnSpeak.UseVisualStyleBackColor = true;
                this.btnSpeak.Click += new System.EventHandler(this.btnSpeak_Click);
                // 
                // flTxtFile
                // 
                this.flTxtFile.DefaultExt = "txt";
                // 
                // trVolume
                // 
                this.trVolume.BackColor = System.Drawing.Color.White;
                this.trVolume.Location = new System.Drawing.Point(131, 35);
                this.trVolume.Maximum = 100;
                this.trVolume.Minimum = 10;
                this.trVolume.Name = "trVolume";
                this.trVolume.Size = new System.Drawing.Size(310, 50);
                this.trVolume.TabIndex = 5;
                this.trVolume.TickFrequency = 10;
                this.trVolume.TickStyle = System.Windows.Forms.TickStyle.Both;
                this.trVolume.Value = 50;
                // 
                // Label2
                // 
                this.Label2.BackColor = System.Drawing.Color.Transparent;
                this.Label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                this.Label2.Location = new System.Drawing.Point(14, 53);
                this.Label2.Name = "Label2";
                this.Label2.Size = new System.Drawing.Size(111, 18);
                this.Label2.TabIndex = 6;
                this.Label2.Text = "设置播放音量：";
                // 
                // SaveFileDialog1
                // 
                this.SaveFileDialog1.FileName = "MyVoice.wav";
                this.SaveFileDialog1.Filter = "Wave (*.wav)|*.wav";
                // 
                // Label3
                // 
                this.Label3.BackColor = System.Drawing.Color.Transparent;
                this.Label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                this.Label3.Location = new System.Drawing.Point(14, 103);
                this.Label3.Name = "Label3";
                this.Label3.Size = new System.Drawing.Size(111, 18);
                this.Label3.TabIndex = 8;
                this.Label3.Text = "设置播放速度：";
                // 
                // trRate
                // 
                this.trRate.BackColor = System.Drawing.Color.WhiteSmoke;
                this.trRate.Location = new System.Drawing.Point(131, 86);
                this.trRate.Minimum = -10;
                this.trRate.Name = "trRate";
                this.trRate.Size = new System.Drawing.Size(310, 50);
                this.trRate.TabIndex = 9;
                this.trRate.TickStyle = System.Windows.Forms.TickStyle.Both;
                // 
                // btnStop
                // 
                this.btnStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStop.BackgroundImage")));
                this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.Black;
                this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                this.btnStop.ForeColor = System.Drawing.Color.White;
                this.btnStop.Location = new System.Drawing.Point(106, 324);
                this.btnStop.Name = "btnStop";
                this.btnStop.Size = new System.Drawing.Size(89, 25);
                this.btnStop.TabIndex = 10;
                this.btnStop.Text = "暂停朗读";
                this.btnStop.UseVisualStyleBackColor = true;
                this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
                // 
                // btnResume
                // 
                this.btnResume.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnResume.BackgroundImage")));
                this.btnResume.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.btnResume.FlatAppearance.BorderColor = System.Drawing.Color.Black;
                this.btnResume.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                this.btnResume.ForeColor = System.Drawing.Color.White;
                this.btnResume.Location = new System.Drawing.Point(201, 324);
                this.btnResume.Name = "btnResume";
                this.btnResume.Size = new System.Drawing.Size(90, 25);
                this.btnResume.TabIndex = 11;
                this.btnResume.Text = "继续朗读";
                this.btnResume.UseVisualStyleBackColor = true;
                this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
                // 
                // btnClose
                // 
                this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
                this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black;
                this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                this.btnClose.ForeColor = System.Drawing.Color.White;
                this.btnClose.Location = new System.Drawing.Point(353, 324);
                this.btnClose.Name = "btnClose";
                this.btnClose.Size = new System.Drawing.Size(84, 25);
                this.btnClose.TabIndex = 12;
                this.btnClose.Text = "关闭";
                this.btnClose.UseVisualStyleBackColor = true;
                this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
                // 
                // frmVoice
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(106F, 106F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                this.BackgroundImage = global::My.Resources.Resources.topnav_bar_shadow;
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.ClientSize = new System.Drawing.Size(469, 374);
                this.ControlBox = false;
                this.Controls.Add(this.btnClose);
                this.Controls.Add(this.btnResume);
                this.Controls.Add(this.btnStop);
                this.Controls.Add(this.trRate);
                this.Controls.Add(this.Label3);
                this.Controls.Add(this.Label2);
                this.Controls.Add(this.trVolume);
                this.Controls.Add(this.Label1);
                this.Controls.Add(this.cmbVoices);
                this.Controls.Add(this.txtSpeach);
                this.Controls.Add(this.btnSpeak);
                this.DoubleBuffered = true;
                this.ForeColor = System.Drawing.Color.White;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                this.Name = "frmVoice";
                this.ShowInTaskbar = false;
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "语音助手";
                this.Load += new System.EventHandler(this.frmVoice_Load);
                ((System.ComponentModel.ISupportInitialize)(this.trVolume)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.trRate)).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();

		}
		internal System.Windows.Forms.RichTextBox txtSpeach;
		internal System.Windows.Forms.ComboBox cmbVoices;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button btnSpeak;
		internal System.Windows.Forms.OpenFileDialog flTxtFile;
		internal System.Windows.Forms.TrackBar trVolume;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.SaveFileDialog SaveFileDialog1;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TrackBar trRate;
		internal System.Windows.Forms.Button btnStop;
		internal System.Windows.Forms.Button btnResume;
		internal System.Windows.Forms.Button btnClose;
		
	}
	
}
