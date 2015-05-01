using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data;
using AxWMPLib;
using System.IO;


namespace Solution
{
	public partial class frmTpl
	{
		public frmTpl()
		{
			InitializeComponent();
		}
		public int flag = 0;
		
		public void OK_Button_Click(System.Object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}
		
		public void Cancel_Button_Click(System.Object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}
		
		private void frmTpl_Load(object sender, System.EventArgs e)
		{
		}
		
		public void rdP_CheckedChanged(System.Object sender, System.EventArgs e)
		{
			flag = 1;
		}
		
		public void rdR_CheckedChanged(System.Object sender, System.EventArgs e)
		{
			flag = 2;
		}
		
		public void rdF_CheckedChanged(System.Object sender, System.EventArgs e)
		{
			flag = 3;
		}
	}
	
}
