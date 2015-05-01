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
	public partial class frmNote
	{
		public frmNote()
		{
			InitializeComponent();
		}
		internal DialogResult YesNo = System.Windows.Forms.DialogResult.Cancel;
		
		public void btnOK_Click(System.Object sender, System.EventArgs e)
		{
			YesNo = System.Windows.Forms.DialogResult.OK;
			this.Hide();
		}
		
		public void btnCancel_Click(System.Object sender, System.EventArgs e)
		{
			YesNo = System.Windows.Forms.DialogResult.Cancel;
			this.Hide();
		}
		
		private void frmNote_Activated(object sender, System.EventArgs e)
		{
			this.Opacity = 1;
		}
		
		private void frmNote_Deactivate(object sender, System.EventArgs e)
		{
			this.Opacity = 0.5;
		}
		
	}
}
