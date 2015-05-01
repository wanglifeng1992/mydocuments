using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.IO;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using Microsoft.VisualBasic;

namespace Solution
{
    public partial class frmLogin : Form
    {

        public frmLogin()
        {
            InitializeComponent();
        }


        public reg regset = new reg();
        public Common cmn = new Common();

        private void btnOK_Click(object sender, System.EventArgs e)
        {


            string fn = "";

            if (!CheckLogin()) this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            this.Close();
        }


        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            modGlobals.g_bOk = false;
            this.Close();

        }


        private bool CheckLogin()
        {

            modGlobals.CDataSvcs = null;
            modGlobals.m_cn.Close();
            string sOk = string.Empty;

            try
            {
                modGlobals.CDataSvcs = new CDataServices();
                if (modGlobals.g_bOk)
                {
                    sOk = modGlobals.CDataSvcs.GetColumn("select KeyCode from [Key] where ID =1;");

                    //modGlobals.g_Key = regset.getSetting("MAC");
                    //modGlobals.g_CODE = regset.getSetting("KEY");

                    if ("DEMO".Equals(sOk))
                    {
                        modGlobals.num = int.MaxValue;

                        modGlobals.m_cn.Close();
                        modGlobals.CDataSvcs = null;
                        return true;
                    }

                    if (cmn.isNumber(sOk))
                    {
                        modGlobals.num = int.Parse(sOk);
                        modGlobals.m_cn.Close();
                        modGlobals.CDataSvcs = null;
                        return true;
                    }

                    if (sOk.Contains("RWX"))
                    {
                        string sKey = "";
                        cmn. InputBox("验证", "请输入阅读代码：", sKey);

                        if (sKey.Equals(sOk)) modGlobals.num = int.MaxValue; else modGlobals.num = 2;

                        modGlobals.m_cn.Close();
                        modGlobals.CDataSvcs = null;

                        MessageBox.Show("您已经成功输入验证码，请重新打开该资源文件。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }

                }

            }
            catch (Exception ex)
            {
                frmDemo f = new frmDemo(ex.Message + "密码不对，请向我们申请图书验证码。");
                f.ShowDialog();
                modGlobals.m_cn.Close();
                modGlobals.CDataSvcs = null;
                return false ;
            }

            modGlobals.m_cn.Close();
            modGlobals.CDataSvcs = null;

            return false  ;
        }

 
        private void frmLogin_Load(object sender, System.EventArgs e)
        {

            this.Text = modGlobals.title; //System.Configuration.ConfigurationManager.AppSettings("lang").ToString()

            this.TaskPath.Text = regset.getSetting("BookPath");

            if (this.TaskPath.Text != "")
            {
                this.ListDB(this.TaskPath.Text, this.ListView1, 0);
            }
            else
            {
                this.TaskPath.Text = modGlobals.GetAppPath() + "data";
                regset.saveSetting("BookPath", this.TaskPath.Text);

                this.ListDB(this.TaskPath.Text, this.ListView1, 0);
            }

            this.ListDB(modGlobals.GetAppPath() + "data", this.ListView2, 1);

            this.btnOK.Enabled = false;

            modGlobals.g_sDbLocation = regset.getSetting("BookDB");

            if (modGlobals.g_sDbLocation != "")
            {
                this.lblFile.Text = Path.GetFileNameWithoutExtension(modGlobals.g_sDbLocation);
            }
            else
            {
                this.lblFile.Text = "职场潜规则";
            }

        }


        private string getMAC()
        {
            System.Management.ManagementClass mc;

            try
            {
                mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();

                foreach (ManagementObject mo in moc)
                {
                    if (System.Convert.ToBoolean(mo["IPEnabled"].ToString()) == true)
                    {
                        return mo["MacAddress"].ToString().Replace(":", "").ToUpper();
                    }
                    else
                        return string.Empty;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
            return string.Empty;
        }

        private void ListDB(string spath, ListView lst, int iImg)
        {

            string rg;
            string fn;

            lst.Items.Clear();
            lst.View = View.LargeIcon;
            lst.LargeImageList = this.ImageList1;

            if (regset.getSetting("BookDB") != "" && Directory.Exists(regset.getSetting("BookDB")))
            {
                rg = Path.GetFileName(regset.getSetting("BookDB"));
                modGlobals.g_sDbLocation = Path.GetDirectoryName(regset.getSetting("BookDB"));
                this.btnOK.Enabled = true;
            }
            else
            {
                rg = "";
                this.btnOK.Enabled = false;
            }

            try
            {

                foreach (string fl in Directory.GetFiles(spath, "*.baiedu", SearchOption.AllDirectories))
                {

                    fn = Path.GetFileNameWithoutExtension(fl);
                    ListViewItem item = lst.Items.Add(fn, fn, iImg);
                    item.Tag = Path.GetDirectoryName(fl);

                    if ((fn + ".baiedu") == rg)
                    {
                        lst.Items[fn].Selected = true;
                    }

                    if (rg == "")
                    {
                        rg = lst.Items[0].Text;
                    }
                    modGlobals.g_sDbLocation = lst.Items[0].Tag.ToString() + "\\" + rg + ".baiedu";
                }
            }
            catch (Exception)
            {
            }

        }


        private void ListView1_Click(System.Object sender, System.EventArgs e)
        {
            this.lblFile.Text = this.ListView1.SelectedItems[0].Text;

            this.TaskPath.Text = this.ListView1.SelectedItems[0].Tag.ToString();

            modGlobals.g_sDbLocation = this.TaskPath.Text + "\\" + this.lblFile.Text + ".baiedu";

            this.btnOK.Enabled = true;
        }


        private void btnImpData_Click(System.Object sender, System.EventArgs e)
        {
            fld.Description = "请选择电子书文件的存放位置。只需选择目录即可，无需选择具体文件。";
            if (fld.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (fld.SelectedPath != "")
                {

                    this.ListDB(fld.SelectedPath, this.ListView1, 0);

                    regset.saveSetting("BookPath", fld.SelectedPath);

                    this.TaskPath.Text = fld.SelectedPath;
                    this.btnOK.Enabled = false;
                }
            }
        }

        private void ListView2_Click(object sender, EventArgs e)
        {
            this.lblFile.Text = this.ListView2.SelectedItems[0].Text;

            this.TaskPath.Text = this.ListView2.SelectedItems[0].Tag.ToString();

            modGlobals.g_sDbLocation = this.TaskPath.Text + "\\" + this.lblFile.Text + ".baiedu";

            regset.saveSetting("BookDB", modGlobals.g_sDbLocation);

            this.btnOK.Enabled = true;
        }

    }
}
