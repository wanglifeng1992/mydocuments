using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Solution
{
    public partial class frmAddNode : Form
    {
        public frmAddNode()
        {
            InitializeComponent();
        }
        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            frmMain.g_bState_NodesDirty = true;
            this.Close();

        }


        private void btnOk_Click(System.Object sender, System.EventArgs e)
        {

            bool bOk;
            int iLengthOfFullPath=0;
            DialogResult  iRet;
            string sNewNode;
            TreeNode tnNew;
            TreeNode tnSelected;

            bOk = true;
            sNewNode = tbNewItem.Text.Trim();

            if (this.rdoChild.Checked)
            {
                tnSelected = frmMain.g_oTv.SelectedNode;

                if (sNewNode == "")
                {
                    //// Test if new node is blank.
                    MessageBox.Show("类别不能为空白。", modGlobals.g_myAppConsts.MsgCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    bOk = false;
                }

                if (sNewNode.Length >= 250)
                {
                    //// Length of Node.Text exceeds the maximum length of 50
                    iRet = MessageBox.Show ("类别名称不能超过250个字符" + "\r\n" + "希望保留250个字符吗？其他字符丢失！", "提示",MessageBoxButtons.YesNo ,MessageBoxIcon.Information );
                    if (iRet == DialogResult .Yes )
                    {
                        sNewNode = sNewNode.Substring(0, 250);
                        bOk = true;
                    }
                    else
                    {
                        bOk = false;
                    }
                }

                if (!(tnSelected == null))
                {
                    if (sNewNode.Length + tnSelected.FullPath.Length > 253)
                    {
                        iRet = MessageBox.Show ("类别名称总长度" + "\r\n" + "最多250字符。 " + "\r\n" + "当前长度是：" + "\r\n" + "" + iLengthOfFullPath + "。本类别无法" + "\r\n" + "添加。", 
                            "提示",MessageBoxButtons.OK , MessageBoxIcon.Error );
                        bOk = false;
                    }
                }

                if ((!(tnSelected == null)) && bOk == true)
                {
                    //// If node is selected then add new node as a child of the new node.
                    tnNew = tnSelected.Nodes.Add(sNewNode);
                    tnNew.ImageIndex = modGlobals.g_myAppConsts.ImageIndexLeaf;
                    tnNew.SelectedImageIndex = modGlobals.g_myAppConsts.SelectedImageIndexLeaf;
                    tnSelected.ExpandAll();
                    //// If the selected node is the not the root then it is a branch node;
                    //// therefore, set the image properties accordingly.
                    if (!(tnSelected.Parent == null))
                    {
                        tnSelected.ImageIndex = modGlobals.g_myAppConsts.ImageIndexBranch;
                        tnSelected.SelectedImageIndex = modGlobals.g_myAppConsts.SelectedImageIndexBranch;
                    }
                    //// Update the UI state.
                    frmMain.g_bState_NodesDirty = true;
                    frmMain.g_bState_NodesPresent = true;
                    frmMain.g_bState_NodeSelected = true;
                    frmMain.g_bState_NodeAdd = true;
                    this.Close();
                }
            }
            else
            {
                if (this.rdoBoot.Checked)
                {
                    //// If there are no nodes, then add this as a root node.
                    tnNew = frmMain.g_oTv.Nodes.Add(sNewNode);
                    tnNew.ImageIndex = modGlobals.g_myAppConsts.ImageIndexRoot;
                    tnNew.SelectedImageIndex = modGlobals.g_myAppConsts.SelectedImageIndexRoot;
                    //// Automatically select the root node that has been added.
                    //// Update the UI state.
                    frmMain.g_bState_NodesDirty = true;
                    frmMain.g_bState_NodesPresent = true;
                    frmMain.g_bState_NodeSelected = true;
                    frmMain.g_bState_NodeAdd = true;
                    frmMain.g_oTv.SelectedNode = tnNew;

                    this.Close();

                } //// If frmmain.g_oTv.GetNodeCount(True) = 0
            } //// If Not (tnSelected Is Nothing)

        }


        private void frmAddNode_Activated(object sender, System.EventArgs e)
        {

            tbNewItem.Focus();

            //// A node may be added without first selecting a node.  Therefore, we must
            //// test if there is a selected node.
            if (!(frmMain.g_oTv.SelectedNode == null))
            {
                lblSelectedNode.Text = frmMain.g_oTv.SelectedNode.FullPath;
            }

        }


        private void frmAddNode_Load(object sender, System.EventArgs e)
        {
            OleDbDataReader rdr;
            rdr = modGlobals.CDataSvcs.GetReader("SELECT DISTINCT sName FROM [LogX];");
            //MsgBox("SELECT * FROM [TreeViewItems] WHERE uid = " & oTv.SelectedNode.Tag & ";", MsgBoxStyle.DefaultButton1, "a")

            ComboBox1.Items.Clear();

            while (rdr.Read())
            {
                ComboBox1.Items.Add((rdr["sName"] == DBNull.Value) ? "" : (rdr["sName"]));

            }
            rdr.Close();


        }

        private void ComboBox1_SelectedValueChanged(object sender, System.EventArgs e)
        {
            this.tbNewItem.Text = this.ComboBox1.Text;
        }
    }
}
