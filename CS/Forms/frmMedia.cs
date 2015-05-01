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
	public partial class frmMedia
	{
		public frmMedia()
		{
			InitializeComponent();
		}
		
		
		private void frmMedia_Load(object sender, System.EventArgs e)
		{
		}

        private void frmMedia_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.axFlash1.Stop();
        }
		
		
	}
}
