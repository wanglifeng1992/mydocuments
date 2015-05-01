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
	public sealed partial class Splash
	{
		public Splash()
		{
			InitializeComponent();
			
			//Added to support default instance behavour in C#
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
		#region Default Instance
		
		private static Splash defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
		public static Splash Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new Splash();
					defaultInstance.FormClosed += new FormClosedEventHandler(defaultInstance_FormClosed);
				}
				
				return defaultInstance;
			}
		}
		
		static void defaultInstance_FormClosed(object sender, FormClosedEventArgs e)
		{
			defaultInstance = null;
		}
		
		#endregion
		
		
		
		//TODO: 可轻松将此窗体设置为应用程序的初始屏幕，方法是转到
		//  “项目设计器”的“应用程序”选项卡(“项目”菜单下的“属性”)。
		
		
		private void Splash_Load(object sender, System.EventArgs e)
		{
			//根据应用程序的程序集信息在运行时设置对话框文本。
			
			//TODO: 在项目属性对话框(“项目”菜单下)中的“应用程序”面板
			//  中自定义应用程序的程序集信息。
			
			//应用程序标题
			
			//Me.ApplicationTitle.Text = ""
			
			//使用在设计时作为格式字符串设置到 Version 控件中的文本格式化版本信息。
			//  以便根据需要进行有效的本地化。
			//  使用以下代码，将Version 控件的设计时文本
			//  更改为“Version {0}.{1:00}.{2}.{3}”或类似格式，将内部版本和修订信息包括在内。
			//  有关更多信息，请参阅帮助中的 String.Format()。
			//
			
			Product.Text = modGlobals.title ;
            this.Text = modGlobals.title;

            this.MainLayoutPanel.BackgroundImage = (Image)modGlobals.cover;
		}
		
		public void Splash_KeyDown(System.Object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.Close();
		}
		
		
		public void Splash_MouseClick(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			this.Close();
		}
		
		public void Splash_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			this.Close();
		}
		
		public void PictureBox2_Click(System.Object sender, System.EventArgs e)
		{
			this.Close();
		}
		
		public void PictureBox1_Click(System.Object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
	
}
