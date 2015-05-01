using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data;
using AxWMPLib;
using System.IO;
using Gma.UserActivityMonitor;

namespace Solution
{
    public partial class frmView
    {

        public frmView()
        {
            InitializeComponent();
        }

        public void cmenuClose_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void frmView_Load(object sender, EventArgs e)
        {

            HookManager.MouseDoubleClick += HookManager_KeyDown;

        }

        private void HookManager_KeyDown(object sender,MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left) this.Close();
        }

     }
}
