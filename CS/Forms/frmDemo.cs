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
	public sealed partial class frmDemo
	{
		public frmDemo(string info)
		{
			
			// 此调用是 Windows 窗体设计器所必需的。
			InitializeComponent();
			
			// 在 InitializeComponent() 调用之后添加任何初始化。
			this.Label1.Text = info;
		}
		public void OKButton_Click(System.Object sender, System.EventArgs e)
		{
			this.Close();
		}
		
	}
	
}
