using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Collections;
using System.Data.OleDb;
using Google.API.Search;
using Solution.net.bing.api;

namespace Solution
{
    public partial class frmMagic : Form
    {
        public frmMagic()
        {
            InitializeComponent();
        }


        private void frmMagic_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“myDataSet.SearchX”中。您可以根据需要移动或移除它。

            bind("");
        }

        public void bind(string strfilter)
        {
            try
            {
                OleDbCommand sqlcmd = new OleDbCommand("select * from [SearchX];", modGlobals.m_cn);
                OleDbDataAdapter sqldap = new OleDbDataAdapter(sqlcmd);
                BindingSource sqlbs = new BindingSource();
                DataSet dsstudentlist = new DataSet();
                sqldap.Fill(dsstudentlist);
                sqlbs.DataSource = dsstudentlist.Tables[0];
                sqlbs.Filter = strfilter;
                this.dataGridView1.DataSource = sqlbs;

                this.dataGridView1.Columns[0].HeaderText = "编号";
                this.dataGridView1.Columns[1].HeaderText = "关键词";
                this.dataGridView1.Columns[2].HeaderText = "地址";
                dataGridView1.AutoSizeRowsMode =
DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                dataGridView1.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.AllCells;

            }
            catch (Exception ex)
            {
                MessageBox.Show("出现错误,请联系管理员" + '\r' + ex.Message.ToString());
            }

        }

        private void deleterow()
        {
            if (this.dataGridView1.SelectedRows.Count > 0 & MessageBox.Show("确定要删除吗？", "注意", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                OleDbCommand sqlcmd = modGlobals.m_cn.CreateCommand();
                sqlcmd.CommandText = "delete  from [SearchX] where UserID = " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "";

                bind("");

            }

        }

        private void btnGoo_Click(object sender, EventArgs e)
        {
            raiseSearch(this.txtKeys .Text );

            /*
            foreach (IWebResult result in myg.list_result )
            {
                Console.WriteLine("[{0}]\r\n {1}\r\n => {2}", result.Title, result.Content, result.Url);
            }
             * */
        }

        private void txtKeys_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                raiseSearch(this.txtKeys .Text );
            }
        }

        private void raiseSearch(string sKeys)
        {
            StringBuilder builder = new StringBuilder("<html><head><title>搜索结果</title><base target=\"_blank\" /></head><body>");
            Cursor = Cursors.WaitCursor;

            builder .Append ( raiseGoogleSearch(sKeys ));
            builder.Append("<hr size=\"1\" />");
           builder .Append (raiseBingSoapSearch(sKeys));

            builder.Append("</body></html>");

            Thread.Sleep(0);

            webBrowser1.DocumentText = builder.ToString();
            Cursor = Cursors.Default;
        }

        private string raiseGoogleSearch(string sKeys)
        {
            StringBuilder builder = new StringBuilder("");

            CgoogleAPI myg = new CgoogleAPI();

            string txt = sKeys.Replace('\r', ' ');
            myg.googleSearchAPI(txt);

            try
            {
                foreach (IWebResult result in myg.list_result)
                {
                    builder.Append("<a href=\"" + result.Url + "\">" + result.Title + "</a><br/>");
                    builder.Append("<div  style=\"width:600px;height:auto; border:1px solid red; margin:0px; padding:0px;line-height: 1.5;\"> ");
                    builder.Append("" + result.Content + "</div><br/>");
                }

                return builder.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "没有符合要求的结果！";
            }
        }

        private string raiseBingSoapSearch(string sKeys)
        {
            CbingSOAP myb = new CbingSOAP();

            string txt = sKeys.Replace('\r', ' ');
            StringBuilder builder = new StringBuilder("");

            myb.bingSearchSOAP(txt);

            try
            {
                foreach (WebResult result in myb.soap_result.Web.Results)
                {
                    builder.Append("<a href=\"" + result.Url + "\">" + result.Title + "</a><br/>");
                    builder.Append("<div  style=\"width:600px;height:auto; border:1px solid red; margin:0px; padding:0px;line-height: 1.5;\"> ");
                    builder.Append("" + result.Description + "</div><br/>");
                }

                return builder.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "没有符合要求的结果！";
            }
        }
    }
}
