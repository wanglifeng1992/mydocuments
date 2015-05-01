using System.Windows.Forms;

namespace Solution
{
    public partial class frmSetFile : Form
    {
        public string mfile = "";
        public string nfile = "";
        public string ufile = "";
        public string lfile = "";
        public string hlink = "";
        public string hurl = "";

        public frmSetFile()
        {
            InitializeComponent();
        }

        private void btnM_Click(object sender, System.EventArgs e)
        {
            dlg.Title = "请选择配套视频文件。";
            dlg.Filter = "WMV 文件|*.wmv|AVI 文件|*.avi|flash 文件|*.swf;*.flv|其它视频|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txtMedia.Text = dlg.FileName;
                this.btnOK.Enabled = true;
            }

        }

        private void btnN_Click(object sender, System.EventArgs e)
        {
            dlg.Title = "请选择课程内容文件。";
            dlg.Filter = "Word 文件|*.doc;*.docx|Web 档案文件|*.mht|网页|*.htm;*.html|其它文件|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txtNew.Text = dlg.FileName;
                this.btnOK.Enabled = true;
            }
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            mfile = this.txtMedia.Text;
            nfile = this.txtNew.Text;
            ufile = this.txtUpdate.Text;
            lfile = this.txtLink.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnU_Click(object sender, System.EventArgs e)
        {
            dlg.Title = "请选择要替换的课程内容文件。";
            dlg.Filter = "Web 档案文件|*.mht|Word 文件|*.doc;*.docx|网页|*.htm;*.html|其它文件|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txtUpdate.Text = dlg.FileName;
                this.btnOK.Enabled = true;
            }
        }

        private void btnL_Click(object sender, System.EventArgs e)
        {
            dlg.Title = "请选择要链接的课程文件。";
            dlg.Filter = "PDF 文件|*.pdf|Web 档案文件|*.mht|网页|*.htm;*.html|其它文件|*.*";

            if(dlg.ShowDialog ()==DialogResult .OK )
            {
                this.txtLink.Text = dlg.FileName;
                this.btnOK.Enabled = true;
            }
        }

        private void btnWebLink_Click(object sender, System.EventArgs e)
        {
            this.hlink = this.txtHypLink.Text;
            this.hurl = this.txtWebAddress.Text;
            this.btnOK.Enabled = true;
        }

        private void frmSetFile_Load(object sender, System.EventArgs e)
        {
            this.btnWebLink.Enabled = false;
            this.btnOK.Enabled = false;
        }

        private void txtWebAddress_TextChanged(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtHypLink.Text) && !string.IsNullOrEmpty(this.txtWebAddress.Text))
                this.btnWebLink.Enabled = true;
        }
 
    }
}
