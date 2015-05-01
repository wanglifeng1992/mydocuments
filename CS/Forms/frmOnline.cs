using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace Solution
{
    public partial class frmOnline : Form
    {
        Uri myurl;

        public frmOnline()
        {
            InitializeComponent();
        }

        private void frmOnline_Load(object sender, EventArgs e)
        {
            this.webOnline.Url = new Uri("http://sites.google.com/site/baiyuyanhua/");
            this.ListFav(modGlobals.GetAppPath() + "data", listView1);
        }

         void wb_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.toolStripProgressBar1.Value = DateTime.Now.Second;
        }

        void wb_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.toolStripStatusLabel1.Text = "下载完成";
        }

        private void MenuItemSaveAs_Click(object sender, EventArgs e)
        {
            myurl  = new Uri (this.webOnline.StatusText);

            try
            {
                if (myurl.ToString().ToLower().Contains(".baiedu") || myurl.ToString().ToLower().Contains(".rar") || myurl.ToString().ToLower().Contains(".zip"))
                {
                    FolderBrowserDialog fld = new FolderBrowserDialog();
                    fld.Description = "请选择保存图书的磁盘目录，也可以新建一个目录。";
                    fld.RootFolder = Environment.SpecialFolder.MyDocuments;
                    fld.ShowNewFolderButton = true;

                    if (fld.ShowDialog() == DialogResult.OK)
                    {
                        string folder = fld.SelectedPath;

                        WebClient wb = new WebClient();
                        wb.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wb_DownloadProgressChanged);
                        wb.DownloadFileCompleted += new AsyncCompletedEventHandler(wb_DownloadFileCompleted);
                        this.toolStripStatusLabel1.Text = "正在下载 ：" + Path.GetFileName(myurl.LocalPath);
                        wb.DownloadFileAsync(myurl, fld.SelectedPath + "\\" + Path.GetFileName(myurl.LocalPath));
                        this.toolStripProgressBar1.Value = 0;


                    }
                    //MessageBox.Show(e.Url .LocalPath );
                }
                else
                    MessageBox.Show("不是标准图书格式，无法下载！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { }

        }

        private void MenuItemFav_Click(object sender, EventArgs e)
        {
            myurl = new Uri ( this.webOnline.StatusText);

            if (myurl.ToString().ToLower().Contains(".baiedu"))
            {
                this.backgroundWorker1.RunWorkerAsync();
                this.MenuItemFav.Enabled = false;
                while (this.backgroundWorker1.IsBusy)
                {
                    Application.DoEvents();
                }
            }
            else
                MessageBox.Show("不是标准图书格式，无法下载！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.MenuItemFav.Enabled = true;

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                this.toolStripStatusLabel1.Text = "下载完成";
                this.ListFav(modGlobals.GetAppPath() + "data", listView1);
                this.toolStripProgressBar1.Value = 0;
            }
            else
            {
                MessageBox.Show("下载失败，请重新下载！", "下载失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            WebClient wb = new WebClient();

             this.toolStripStatusLabel1.Text = "正在下载 ：" + Path.GetFileName(myurl.LocalPath);
            wb.DownloadFile(myurl, modGlobals.GetAppPath() + "data\\" + Path.GetFileName(myurl.LocalPath));

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.toolStripProgressBar1.Value = DateTime.Now.Second;
        }

        private void ListFav(string spath, ListView lst)
        {
            lst.Items.Clear();
            lst.View = View.Details;
            lst.Columns.Add("已经收藏的电子书",200);
            
            try
            {

                foreach (string fl in Directory.GetFiles(spath, "*.baiedu", SearchOption.AllDirectories))
                {

                    string fn = Path.GetFileNameWithoutExtension(fl);
                    ListViewItem item = lst.Items.Add(fn);
                }
            }
            catch (Exception)
            {
            }

        }
    }
}
