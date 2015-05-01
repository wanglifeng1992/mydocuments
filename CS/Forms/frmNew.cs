using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Solution
{
    public partial class frmNew : Form
    {
        public string bookname = "新电子书";
        public string demo = string.Empty ;
        public string bookpath = "";
        public string booksource = "";
        public string dns = "";
        public string type = "";
        public string excelfile = "";
        public string excelweb = "";

        public frmNew()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rbFree.Checked) demo = "DEMO";
            if (rbTrial.Checked) demo = UpDown1 .Value .ToString ();
            if (rbSale.Checked)
            {
                Random ro = new Random();
                int ivalue = ro.Next(100000, 999999);
                demo = "RWX-"+ivalue.ToString ();
            }

            modGlobals . chk = checkENC.Checked;

            if (!string.IsNullOrEmpty(this.lblPath.Text) && !string.IsNullOrEmpty(this.txtBookName.Text))
            {
                try
                {
                    if (!Directory.Exists(this.lblPath.Text + "\\" + this.txtBookName.Text))
                        Directory.CreateDirectory(this.lblPath.Text + "\\" + this.txtBookName.Text);

                    string fname = this.lblPath.Text + "\\" + this.txtBookName.Text + "\\" + this.txtBookName.Text + ".baiedu";

                    if(!File.Exists (fname))
                        File.Copy(modGlobals.GetAppPath() + "\\data\\" + "电子书模版.tpl", fname, true);
                    else
                        if(MessageBox .Show ("文件已经存在，是否覆盖？","提示!",MessageBoxButtons .YesNo ,MessageBoxIcon .Warning )==DialogResult .Yes )
                        File.Copy(modGlobals.GetAppPath() + "\\data\\" + "电子书模版.tpl", fname,true );

                    Directory.CreateDirectory(this.lblPath.Text + "\\" + this.txtBookName.Text + "\\File\\");
                    Directory.CreateDirectory(this.lblPath.Text + "\\" + this.txtBookName.Text + "\\media\\");
                    File.Copy(modGlobals.GetAppPath() + "\\data\\media\\OlkAttc.swf", this.lblPath.Text + "\\" + this.txtBookName.Text + "\\media\\OlkAttc.swf",true );

                    modGlobals.g_sDbLocation = fname;

                    this.bookname = this.txtBookName.Text;
                    this.bookpath = this.lblPath.Text + "\\" + this.txtBookName.Text;
                    this.booksource = this.lblSource.Text ;

                    this.excelfile = this.lblExcelFile.Text;
                    this.excelweb = this.lblExcelWeb.Text;

                    if (rbInner.Checked) type = "内置";
                    if (rbLink.Checked) type = "外挂";
                    if (rbWeb.Checked) { type = "网站"; dns = txtDNS.Text.Trim(); }
                    if (rbExcelFile.Checked) type = "批量外挂";
                    if (rbExcelWeb.Checked) type = "批量网站";

                    this.DialogResult = DialogResult.OK;

                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

 
        private void frmNew_Load(object sender, EventArgs e)
        {
            
        }

         private void rbExcelFile_CheckedChanged(object sender, EventArgs e)
        {
            dlg.Title = "选择图书目录索引文件";
            dlg.Filter = "Excel 文件|*.xls";

            if (dlg.ShowDialog() == DialogResult.Cancel) return;

            if (string.IsNullOrEmpty(dlg.FileName)) return;

            this.lblExcelFile.Text = dlg.FileName;
            this.lblExcelWeb.Text = "-";
        }

        private void rbExcelWeb_CheckedChanged(object sender, EventArgs e)
        {
            dlg.Title = "选择图书目录索引文件";
            dlg.Filter = "Excel 文件|*.xls";

            if (dlg.ShowDialog() == DialogResult.Cancel) return;

            if (string.IsNullOrEmpty(dlg.FileName)) return;

            this.lblExcelWeb.Text = dlg.FileName;
            this.lblExcelFile.Text = "-";
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdlg = new FolderBrowserDialog();

            if (fdlg.ShowDialog() != DialogResult.Cancel)
            {
                DirectoryInfo info = new DirectoryInfo(fdlg.SelectedPath);

                this.lblSourceDirectory.Text = fdlg.SelectedPath;
                this.lblSource.Text = fdlg.SelectedPath;
                this.txtBookName.Text = info.Name;
            }
        }

        private void btnDest_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd=new FolderBrowserDialog ();
            if (fd.ShowDialog() != DialogResult.Cancel)
            {
                this.lblDestDirectory.Text = fd.SelectedPath;
                this.lblPath.Text = fd.SelectedPath;
            }
        }


    }
}
