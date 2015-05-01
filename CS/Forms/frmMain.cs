//#define RELEASE

using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows;
using System.Collections;
using System.Drawing;
using System.Data;
using AxWMPLib;
using System.Data.OleDb;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows;
//using System.Math;
using System.Threading;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Excel;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.AccessControl;
using System.Net;
using System.Runtime.InteropServices;

namespace Solution
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            adv = modGlobals.GetAppPath() + "demo.mht";

            InitializeComponent();
        }

        public static bool g_bState_NodesDirty;
        public static bool g_bState_NodesPresent;
        public static bool g_bState_NodeSelected;
        public static bool g_bState_NodeAdd;
        public static TreeView g_oTv;
        public string sTemp = "";
        public string sCon;
        public string adv;
        public reg regset = new reg();
        public Common cmn = new Common();

        public string type = "内置";
        public string hurl = "";

        public string sVoice = "Welcome!";
        public bool ISCONNECTED = false;

        frmNote fNote = new frmNote();

        CTreeView CTree = new CTreeView();

        bool m_bFormIsActivated;
        TreeNode m_tnSource;
        Uri myurl = null;

        bool loadstatus = true;

        string showFile = string.Empty;
        string oldFile = string.Empty;

        
        private void frmMain_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (g_bState_NodesDirty || g_bState_NodeAdd)
            {
                MessageBox.Show("请先保存标题目录然后再关闭，按鼠标右键，选择【保存标题目录】。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;

            }
            else
            {
                this.WebContent.Dispose();
                try
                {
                    if(modGlobals .chk )
                    foreach (string fl in Directory.GetFiles(Path.GetDirectoryName(showFile), "*" + Path.GetExtension(showFile)))
                    {
                        File.Delete(fl);
                    }
                }
                catch { System.Windows.Forms.Application.Exit(); }

                System.Windows.Forms.Application.Exit();
            }
        }

        [DllImport("wininet.dll")]
        private extern static bool InternetCheckConnection(String url, int flag, int ReservedValue);

        public void frmMain_Load(System.Object sender, System.EventArgs e)
        {


            g_oTv = this.oTv;

            oTv.ShowNodeToolTips = true;

            this.ToolTip1.SetToolTip(oTv, "日记目录");

            this.Text = modGlobals.title;

            ISCONNECTED = InternetCheckConnection(modGlobals.website, 1, 0);

            if (ISCONNECTED)
            {
                this.tabPageWEB.Text = "首页";
                this.WebContent.Navigate(new Uri(modGlobals.website));
            }
            else
            {
                this.tabPageWEB.Text = "导航";
                this.WebContent.Navigate(new Uri(adv));
            }


            this.WebContent.ContextMenuStrip = this.contextMenuStrip1;

            this.WebContent.ScriptErrorsSuppressed = true;

            modGlobals.g_sDbLocation = regset.getSetting("BookDB");

            if (modGlobals.g_sDbLocation == "")
            {
                modGlobals.g_sDbLocation = modGlobals.GetAppPath() + "data\\" + "帮助手册.baiedu";
                regset.saveSetting("BookPath", modGlobals.GetAppPath() + "data\\");
            }

            this.btnSearch.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnTemp.Enabled = false;
            this.btnCollAll.Enabled = false;
            this.btnExpandAll.Enabled = false;
            this.btnVoice.Enabled = false;
            this.WebContent.ContextMenuStrip = this.contextMenuStrip1;

            if (modGlobals.g_sDbLocation != "")
            {
                this.loadDatabase(modGlobals.g_sDbLocation);
            }

#if (RELEASE)

            this.btnAdd.Visible = false;
            this.btnDelete.Visible = false;
            this.btnSaveNode.Visible = false;
            this.btnNew.Visible = false;
            this.oTv.LabelEdit = false;
            this.MenuItemLink.Visible = false;
            this.MenuItemMedia.Visible = false;
            this.MenuItemNew.Visible = false;
            this.MenuItemUpdate.Visible = false;
            this.MenuItemWeb.Visible = false;
            this.rtfDOC.RichTextBox.ReadOnly = true;
            this.rtfDOC.Toolbar.Visible = false;
            this.ContextMenu1.Visible = false;

            //this.WebContent.IsWebBrowserContextMenuEnabled = false;
            //this.WebContent.WebBrowserShortcutsEnabled = false;

#endif
        }


        public static bool JugeWebURL(string URL)
        {
            System.Net.WebResponse myRepTest;
            System.Net.WebRequest myTest = System.Net.WebRequest.Create(URL);
            myTest.Timeout = 500;
            bool link = true;
            try
            {
                myRepTest = myTest.GetResponse();
            }
            catch (Exception)
            {
                link = false;
            }
            return link;
        }

        private void LoadTreeView(bool movable)
        {

            //// Populate the TreeView with nodes.
            oTv.Nodes.Clear();
            try
            {
                CTree.PopulateTree(oTv, movable);
                oTv.SelectedNode = oTv.TopNode;
                oTv.ResumeLayout();
                oTv.TopNode.ExpandAll();
                oTv.Nodes[0].EnsureVisible();

                //// Initialize the state of the UI.
                if (oTv.GetNodeCount(true) > 0)
                {
                    g_bState_NodesPresent = true;
                }
                else
                {
                    g_bState_NodesPresent = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            g_bState_NodeSelected = false;
            g_bState_NodesDirty = false;
            g_bState_NodeAdd = false;

            //// Update the UI.
            SetUIState(g_bState_NodesPresent, g_bState_NodeSelected, g_bState_NodesDirty);

            this.btnSave.Enabled = true;
            this.btnTemp.Enabled = true;
            this.btnCollAll.Enabled = true;
            this.btnExpandAll.Enabled = true;

            this.tabPageCSWF.Visible = false;
            this.tabPageRTF.Visible = false;
            this.tabPageWEB.Visible = true;
            this.tabPageWEB.Title = "主页";
            this.browserTabControl.SelectedItem = this.tabPageWEB;
        }


        public void oTv_AfterSelect(System.Object sender, System.Windows.Forms.TreeViewEventArgs e)
        {

            if (oTv.SelectedNode.Parent == null)
            {
                this.btnVoice.Enabled = false;
                this.btnView.Enabled = false;
                this.btnSave.Enabled = false;
                this.btnTemp.Enabled = false;
            }
            else
            {
                this.btnView.Enabled = true;
                this.btnSave.Enabled = true;
                this.btnTemp.Enabled = true;
            }

            if ((g_bState_NodesDirty || g_bState_NodeAdd) && (oTv.SelectedNode != oTv.TopNode))
            {
                //Me.saveNode(oTv.TopNode)
                //MsgBox("请先保存标题目录，按鼠标右键，选择【保存标题目录】。", MsgBoxStyle.Information, "提示")
                //Exit Sub
            }
            if (!(e.Node == null))
            {
                g_bState_NodeSelected = true;
            }
            else
            {
                g_bState_NodeSelected = false;
            }
            SetUIState(g_bState_NodesPresent, g_bState_NodeSelected, g_bState_NodesDirty);

            if (oTv.SelectedNode.Parent == null)
            {
                //this.WebContent.Navigate(new Uri(adv));
                ShowRecord(oTv.SelectedNode.Tag.ToString());

                return;
            }

            if (g_bState_NodeAdd == false)
            {
                this.axWindowsMediaPlayer1.close();

                ShowRecord(oTv.SelectedNode.Tag.ToString());
            }

        }

        #region show record

        public void ShowRecord(string iUID)
        {


            if (g_bState_NodeAdd == true)
            {
                //MessageBox.Show("请先保存内容，方式丢失数据，然后进行操作。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            OleDbDataReader rdr;

            if (this.oTv.SelectedNode.Level == 0)
            {
                this.WebContent.ContextMenuStrip = this.contextMenuStrip1;
                if (ISCONNECTED)
                {
                    this.WebContent.Navigate(new Uri(modGlobals.website));
                    this.WebContent.ContextMenuStrip = this.contextMenuStrip1;
                }
                else
                {
                    this.WebContent.Navigate(new Uri(adv));
                    this.WebContent.ContextMenuStrip = null;

                }
                return;
            }
            else this.WebContent.ContextMenuStrip = null;

            try
            {
                rdr = modGlobals.CDataSvcs.GetReader("SELECT * FROM [LogX] WHERE uid = " + iUID + ";");

                while (rdr.Read())
                {
                    int scope = int.Parse(rdr["iSort"].ToString());

                    if (scope >= modGlobals.num)
                    {
                        this.WebContent.Navigate(new Uri(adv));
                        return;
                    }

                    this.Label1.Text = rdr["uid"].ToString();
                    this.rtfNote.Rtf = ((rdr["mNote"] == DBNull.Value) ? "{\\rtf1\\ansicpg936 此处 \\b 填写笔记内容。\\b0.}" : (rdr["mNote"])).ToString();

                    string mfile = ((rdr["sMedia"] == DBNull.Value) ? "" : (rdr["sMedia"])).ToString();
                    string sTitle = ((rdr["sName"] == DBNull.Value) ? " " : (rdr["sName"])).ToString();

                    type = rdr["sSaveType"].ToString();

                    this.btnLarge.Enabled =!string.IsNullOrEmpty(mfile) ;

                    if (!string.IsNullOrEmpty(mfile)) showMedia(type, mfile); 

                    this.MenuDownload.Enabled = false;

                    switch (type)
                    {
                        case "内置":
                            this.btnVoice.Enabled = true;
                            this.btnSearch.Enabled = true;
                            string sCon = ((rdr["mContent"] == DBNull.Value) ? " " : (rdr["mContent"].ToString()));
                            showWebContent(sTitle, sCon);
                            break;

                        case "外挂":

                            this.btnVoice.Enabled = false;
                            this.btnSearch.Enabled = false;
                            string lfile = ((rdr["mContent"] == DBNull.Value) ? "" : (rdr["mContent"])).ToString();

                            showLinkContent(sTitle, rdr["sFileType"].ToString(), lfile,modGlobals.chk );

                            break;

                        case "网站":

                            this.btnVoice.Enabled = false;
                            this.btnSearch.Enabled = false;
                            string hurl = ((rdr["mContent"] == DBNull.Value) ? "" : (rdr["mContent"])).ToString();
                            this.MenuDownload.Enabled = true;
                            showHpyLink(sTitle, hurl);
                            break;
                        default:
                            break;
                    }


                    if (fNote.CanFocus)
                    {
                        fNote.rtfTemp.RichTextBox.Rtf = this.rtfNote.Rtf;
                        fNote.Update();
                    }

                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #endregion

        private void showMedia(string type, string mfile)
        {
            if (Path.GetExtension(mfile).Equals(".swf") || Path.GetExtension(mfile).Equals(".flv"))
            {
                   this.tabPageSWF.Visible =true ;
                   this.tabPageWMV.Visible =false ;
                   this.axWindowsMediaPlayer1.Visible = false;

                if (type == "内置" || type == "外挂")
                {
                    this.axShockwaveFlash1.Movie = regset.getSetting("BookPath") + "\\media\\" + mfile;
                    this.axShockwaveFlash1.Play();
                }
                else
                {
                    this.axShockwaveFlash1.Movie = mfile;
                    this.axShockwaveFlash1.Play();
                }
            }
            else
            {
               this.tabPageWMV.Visible =true ;
               this.tabPageSWF.Visible =false ;
               this.axWindowsMediaPlayer1.Visible = true;

                if (type == "内置" || type == "外挂")
                    this.axWindowsMediaPlayer1.URL = regset.getSetting("BookPath") + "\\media\\" + mfile;
                else
                    this.axWindowsMediaPlayer1.URL = mfile;
            }

        }


        private void showWebContent(string sTitle,string sCon)
        {
            try
            {

                //base64 b64 = new base64();

                //sCon = b64.decode(sCon);

                this.tabPageWEB.Visible = true ;
                this.tabPageCSWF.Visible =false  ;
                this.tabPageRTF.Visible = true;
                this.browserTabControl.SelectedItem = this.tabPageRTF;
                this .tabPageRTF.Title = sTitle ;
                this.rtfDOC.RichTextBox .Rtf = sCon;

                sVoice = this.rtfDOC .RichTextBox .Text ;

            }
            catch { }

        }

        private void showLinkContent(string sTitle,string sFileType, string sCon, bool encry)
        {
            string filename = "";

            filename = regset.getSetting("BookPath") + "\\File\\" + sCon;

            try
            {
                showFile = filename;
                oldFile = filename ;

                //MessageBox.Show(encry.ToString ());

                if (encry)
                {
                    CryptoProgressCallBack cb = new CryptoProgressCallBack(this.ProgressCallBackEncrypt);

                    showFile = Path.GetTempFileName() + sFileType;

                    modGlobals.idList.Add(showFile);

                    CryptoHelp.DecryptFile(filename, showFile, "password0!", cb);
                }

                if (sFileType.ToLower().Contains(".swf"))
                {
                    this.tabPageCSWF.Visible = true;
                    this.tabPageWEB.Visible = true ;
                    this.tabPageRTF.Visible = false;
                    this.tabPageCSWF .Title =sTitle ;
                    this.browserTabControl.SelectedItem = this.tabPageCSWF;

                    this.axFlash.Movie = showFile ;
                    this.axFlash.Play();

                }
                else
                {
                    this.tabPageCSWF.Visible = false;
                    this.tabPageWEB.Visible = true;
                    this.tabPageRTF.Visible = false;
                    this .tabPageWEB .Title = sTitle ;
                    this.browserTabControl.SelectedItem = this.tabPageWEB;

                    if (sFileType.ToLower().Contains(".ppt") || sFileType.ToLower().Contains(".pps"))
                    {
                        this.WebContent.Navigate(new Uri(showFile  + ".jpg"));

                        return;
                    }
                    else
                    {

                        this.WebContent.Navigate(new Uri(showFile));

                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("外挂：" + "文档无法打开，或者保存位置错误，或者格式错误。");
            }
            return;

        }

        private void showHpyLink(string sTitle,string sCon)
        {

            try
            {
                //MessageBox.Show(sCon);
                this.tabPageCSWF.Visible = false;
                this.tabPageRTF.Visible = false;
                this.tabPageWEB.Visible = true;
                this.tabPageWEB.Title = sTitle;
                this.browserTabControl.SelectedItem = this.tabPageWEB;

                if (sCon.Contains("http://"))
                    this.WebContent.Navigate(new Uri(sCon));
                else
                    this.WebContent.Navigate(new Uri("http://" + sCon));

            }
            catch { }
        }


        public void oTv_DragEnter(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {

            e.Effect = DragDropEffects.Move;

        }


        public void oTv_DragDrop(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {

            System.Drawing.Point pt;
            TreeNode tnDestination;
            TreeNode tnNew;
            TreeNode tnSourceParent;

            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", true))
            {

                //// Get a handle to the destination node.
                pt = oTv.PointToClient(new System.Drawing.Point(e.X, e.Y));
                tnDestination = oTv.GetNodeAt(pt);

                if (CTree.IsDropAllowed(m_tnSource, tnDestination) == true)
                {
                    //// Need to remember the Source's Parent because the reference
                    //// will be scrambled in the cloning process.
                    tnSourceParent = m_tnSource.Parent;

                    //// Create a new node based on the data contained in the dragged node.
                    tnNew = (TreeNode)(e.Data.GetData("System.Windows.Forms.TreeNode"));
                    tnDestination.Nodes.Add((TreeNode)(tnNew.Clone()));
                    tnDestination.ExpandAll();
                    tnNew.Remove();

                    //// Update node icons based on new state.
                    if (tnSourceParent.GetNodeCount(true) == 0)
                    {
                        tnSourceParent.ImageIndex = modGlobals.g_myAppConsts.ImageIndexLeaf;
                        tnSourceParent.SelectedImageIndex = modGlobals.g_myAppConsts.SelectedImageIndexLeaf;
                    }
                    if (!(tnDestination.Parent == null))
                    {
                        tnDestination.ImageIndex = modGlobals.g_myAppConsts.ImageIndexBranch;
                        tnDestination.SelectedImageIndex = modGlobals.g_myAppConsts.SelectedImageIndexBranch;
                    }

                    //// Update the UI state.
                    g_bState_NodesDirty = true;
                    g_bState_NodeSelected = false;
                    SetUIState(g_bState_NodesPresent, g_bState_NodeSelected, g_bState_NodesDirty);
                    oTv.SelectedNode = null;

                }
                else
                {
                    //// Drop is not allowed because it will create a cyclical reference.
                    //// May want to put a messagebox here explaining to the user why
                    //// the drop cannot be completed.
                    MessageBox.Show("无法进行拖放操作。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                } //// If tv.IsDropAllowed(...)

            }

        }


        public void oTv_ItemDrag(System.Object sender, System.Windows.Forms.ItemDragEventArgs e)
        {

            m_tnSource = (TreeNode)e.Item;
            DoDragDrop(e.Item, DragDropEffects.Move);

        }


        public void SetUIState(bool bNodesPresent, bool bNodeSelected, bool bNodesDirty)
        {

            //// PURPOSE: The following method is used to set the state of
            //// the user interface (UI).

            //ToolBar1.Items(6).Enabled = True
            //ToolBar1.Items(2).Enabled = True

            //If bNodesPresent = True Then

            //    MenuCo.Enabled = True
            //    MenuEx.Enabled = True

            //    If bNodeSelected = True Then
            //        MenuAdd.Enabled = True
            //        MenuDelete.Enabled = True
            //        MenuRename.Enabled = True
            //    Else
            //        MenuAdd.Enabled = False
            //        MenuDelete.Enabled = False
            //        MenuRename.Enabled = False
            //    End If

            //    If bNodesDirty = True Then
            //        ToolBar1.Items(1).Enabled = True
            //    Else
            //        ToolBar1.Items(1).Enabled = False
            //    End If

            //Else

            //    MenuAdd.Enabled = True
            //    MenuDelete.Enabled = False
            //    MenuCo.Enabled = False
            //    MenuEx.Enabled = False
            //    MenuRename.Enabled = False

            //    If bNodesDirty = True Then
            //        ToolBar1.Items(1).Enabled = True
            //    Else
            //        ToolBar1.Items(1).Enabled = False
            //    End If

            //End If

        }

        private void deleteNode()
        {
            //// PURPOSE:  The following will delete the selected node and all of its
            //// child nodes.

            //// NOTE:  The Microsoft treeview control allows you to delete a node
            //// and all of its child nodes using the .Remove() method.  I have
            //// implemented this feature using recursion so that I can synch all
            //// delete actions with the database.  Simply calling the .Remove()
            //// method and not synching the deletes of children with the database will
            //// result in orphan database records.

            TreeNode tn;
            if (!(oTv.SelectedNode == null))
            {
                tn = oTv.SelectedNode;
                DialogResult iRet;

                iRet = MessageBox.Show("确定要删除标题" + tn.Text + "吗？", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (iRet == System.Windows.Forms.DialogResult.Yes)
                {
                    CTree.DeleteNode(tn);
                    g_bState_NodesDirty = true;
                    if (oTv.GetNodeCount(true) > 0)
                    {
                        g_bState_NodesPresent = true;
                    }
                    else
                    {
                        g_bState_NodesPresent = false;
                    }
                    g_bState_NodeSelected = false;
                    SetUIState(g_bState_NodesPresent, g_bState_NodeSelected, g_bState_NodesDirty);
                    oTv.SelectedNode = null;
                }
            }

        }


        private void SaveWebContent(string sfile, string stype)
        {
            string sSql;

            sSql = "UPDATE [LogX] SET ";
            sSql = sSql + "sMedia = ''";
            sSql = sSql + ",sSaveType ='内置'";
            sSql = sSql + ",sFileType='" + stype + "'";
            sSql = sSql + ",mContent = ? ";

            sSql = sSql + " WHERE uid = " + this.oTv.SelectedNode.Tag.ToString() + ";";
            this.Cursor = Cursors.WaitCursor;

            try
            {
                string sCon = File.ReadAllText(sfile);

                //base64 b64 = new base64();
                //sCon = b64.encode(sCon);

                modGlobals.CDataSvcs.UpdateWebRecord(sSql, sCon);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " 请填写完整内容，然后才能保存。", "保存提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            this.Cursor = Cursors.Arrow;

        }

        private void SaveMediaContent(string sfile)
        {
            string sSql;

            sSql = "UPDATE [LogX] SET ";
            sSql = sSql + "sMedia = \'" + sfile + "\'";

            sSql = sSql + " WHERE uid = " + this.oTv.SelectedNode.Tag.ToString() + ";";
            this.Cursor = Cursors.WaitCursor;

            try
            {


                modGlobals.CDataSvcs.ExecuteNonQuery(sSql);

            }
            catch (Exception)
            {
                MessageBox.Show("请填写完整日记内容，然后才能保存。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            this.Cursor = Cursors.Arrow;

        }


        private void SaveStatusContent(int flag)
        {
            string sSql;

            sSql = "UPDATE [LogX] SET iStatus = " + flag.ToString();

            sSql = sSql + " WHERE uid = " + this.oTv.SelectedNode.Tag.ToString() + ";";
            this.Cursor = Cursors.WaitCursor;

            try
            {

                modGlobals.CDataSvcs.ExecuteNonQuery(sSql);

            }
            catch (Exception)
            {
                MessageBox.Show("请填写完整日记内容，然后才能保存。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            this.Cursor = Cursors.Arrow;

        }

        private void SaveNoteContent(string _con)
        {
            string sSql;

            sSql = "UPDATE [LogX] SET ";
            sSql = sSql + " mNote = ? ";

            sSql = sSql + " WHERE uid = " + this.oTv.SelectedNode.Tag.ToString() + ";";
            this.Cursor = Cursors.WaitCursor;

            try
            {

                modGlobals.CDataSvcs.UpdateNoteRecord(sSql,_con);

            }
            catch (Exception)
            {
                MessageBox.Show("请填写完整日记内容，然后才能保存。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            this.Cursor = Cursors.Arrow;

        }

        private void SaveInnerContent(string _con)
        {
            string sSql;

            sSql = "UPDATE [LogX] SET ";
            sSql = sSql + " mContent = ? ";

            sSql = sSql + " WHERE uid = " + this.oTv.SelectedNode.Tag.ToString() + ";";
            this.Cursor = Cursors.WaitCursor;

            try
            {

                modGlobals.CDataSvcs.UpdateWebRecord(sSql, _con);

            }
            catch (Exception)
            {
                MessageBox.Show("请填写完整日记内容，然后才能保存。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            this.Cursor = Cursors.Arrow;

        }

        private void saveNode(TreeNode nd)
        {
            TreeNode tn = null;
            TreeNode tempnode;

            tempnode = oTv.SelectedNode;

            oTv.SelectedNode = nd;
            try
            {
                if (oTv.GetNodeCount(false) > 0)
                {
                    tn = oTv.Nodes[oTv.SelectedNode.Index];
                }

                CTree.SaveNodeCollection(tn);

                //// Update the UI.
                g_bState_NodesDirty = false;
                g_bState_NodeAdd = false;

                SetUIState(g_bState_NodesPresent, g_bState_NodeSelected, g_bState_NodesDirty);
            }
            catch (Exception)
            {
                MessageBox.Show("请选择最顶层标题，然后保存。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            oTv.SelectedNode = tempnode;

        }



        public void axWindowsMediaPlayer1_Enter(System.Object sender, System.EventArgs e)
        {
            try
            {
                this.axWindowsMediaPlayer1.fullScreen = true;
            }
            catch (Exception)
            {

            }
        }

        public void btnHelp_Click(System.Object sender, System.EventArgs e)
        {
            frmHelp f = new frmHelp();

            f.webBrowser1.Navigate(new Uri(modGlobals.GetAppPath() + "help.mht"));
            f.Show();
        }

        #region 工具栏按钮处理代码

        public void btnAdd_Click(System.Object sender, System.EventArgs e)
        {
            frmAddNode fAddNode = new frmAddNode();

            fAddNode.ShowDialog();
            //// Update the UI State.
            SetUIState(g_bState_NodesPresent, g_bState_NodeSelected, g_bState_NodesDirty);

            g_bState_NodeAdd = false;

            if (modGlobals.g_bOk == true)
            {
                g_bState_NodeAdd = true;
                this.saveNode(oTv.TopNode);
            }

        }

        public void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            TreeNode tn;
            if (!(oTv.SelectedNode == null))
            {
                tn = oTv.SelectedNode;
                DialogResult iRet;
                iRet = MessageBox.Show("确定删除类别 " + tn.Text + " 吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (iRet == DialogResult.Yes)
                {
                    CTree.DeleteNode(tn);
                    g_bState_NodesDirty = true;
                    if (oTv.GetNodeCount(true) > 0)
                    {
                        g_bState_NodesPresent = true;
                    }
                    else
                    {
                        g_bState_NodesPresent = false;
                    }
                    g_bState_NodeSelected = false;
                    SetUIState(g_bState_NodesPresent, g_bState_NodeSelected, g_bState_NodesDirty);
                    oTv.SelectedNode = null;
                }
                this.saveNode(oTv.TopNode);
            }
        }

        public void btnSaveNode_Click(System.Object sender, System.EventArgs e)
        {
            this.saveNode(oTv.TopNode);
        }
        public void btnSave_Click(System.Object sender, System.EventArgs e)
        {

            if (this.oTv.SelectedNode != null)
            {
                fNote.rtfTemp.RichTextBox.Rtf = this.rtfNote.Rtf;
                fNote.Show(this);
                fNote.Label1.Text = this.tabPageWEB.Text;

                fNote.TopMost = true;
                if (fNote.YesNo == System.Windows.Forms.DialogResult.OK)
                {
                    this.rtfNote.Rtf = fNote.rtfTemp.RichTextBox.Rtf;
                    SaveNoteContent(this.rtfNote.Rtf.ToString());
                }
            }
        }

        public void btnExpandAll_Click(System.Object sender, System.EventArgs e)
        {
            oTv.ExpandAll();

        }

        public void btnCollAll_Click(System.Object sender, System.EventArgs e)
        {
            oTv.CollapseAll();

        }

        #endregion

        public void btnTemp_Click(System.Object sender, System.EventArgs e)
        {
            frmTpl f = new frmTpl();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.oTv.SelectedNode.ForeColor = modGlobals.getStatus(f.flag);

                this.SaveStatusContent(f.flag);
            }
        }

        public void oTv_AfterExpand(System.Object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            modGlobals.g_List = true;
        }

        //Private Sub oTv_BeforeSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles oTv.BeforeSelect
        //    If g_List Then
        //        Me.SaveIndexContent()
        //    End If
        //End Sub

        public void oTv_AfterLabelEdit(System.Object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
        {
            //MessageBox.Show("请保存标题目录，然后进行编辑。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information)

        }

        private TreeNode nodeAdd(string tbNewItem)
        {
            bool bOk;
            int iLengthOfFullPath = 0;
            DialogResult iRet;
            string sNewNode;
            TreeNode tnNew = null;
            TreeNode tnSelected;

            bOk = true;
            sNewNode = tbNewItem.Trim();

            tnSelected = oTv.SelectedNode;

            if (sNewNode == "")
            {
                MessageBox.Show("类别不能为空白。", modGlobals.g_myAppConsts.MsgCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                bOk = false;
            }

            if (sNewNode.Length >= 250)
            {
                iRet = MessageBox.Show("类别名称不能超过250个字符" + "\r\n" + "希望保留250个字符吗？其他字符丢失！",
                    "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (iRet == DialogResult.Yes)
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
                    iRet = MessageBox.Show("类别名称总长度" + "\r\n" + "最多250字符。 " + "\r\n" + "当前长度是：" + "\r\n" + "" + iLengthOfFullPath + "。本类别无法" + "\r\n" + "添加。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bOk = false;
                }
            }

            if ((!(tnSelected == null)) && bOk == true)
            {
                tnNew = tnSelected.Nodes.Add(sNewNode);
                tnNew.ImageIndex = modGlobals.g_myAppConsts.ImageIndexLeaf;
                tnNew.SelectedImageIndex = modGlobals.g_myAppConsts.SelectedImageIndexLeaf;
                tnSelected.ExpandAll();
                if (!(tnSelected.Parent == null))
                {
                    tnSelected.ImageIndex = modGlobals.g_myAppConsts.ImageIndexBranch;
                    tnSelected.SelectedImageIndex = modGlobals.g_myAppConsts.SelectedImageIndexBranch;
                }
                g_bState_NodesDirty = true;
                g_bState_NodesPresent = true;
                g_bState_NodeSelected = true;
                g_bState_NodeAdd = true;
            }
            return tnNew;
        }
        private void loadDatabase(string db)
        {

            try
            {
                modGlobals.CDataSvcs = null;
                modGlobals.m_cn.Close();

                modGlobals.CDataSvcs = new CDataServices();

                if (!modGlobals.g_bOk)
                {
                    return;
                }

                modGlobals .chk =  checkEncry();

                LoadTreeView(false);
                m_bFormIsActivated = true;

            }
            catch (Exception ex)
            {
                frmDemo f = new frmDemo(ex.Message +'\r'+ "系统提示：电子书库存在问题,请重新选择,或者与供应商联系！");
                f.ShowDialog();
                System.Windows.Forms.Application.Exit();
            }

        }


        private bool checkEncry()
        {
            try
            {
                string s = modGlobals.CDataSvcs.GetColumn("select Encry from [Key] where ID=1;");

                if(s=="Y")  return true ;      else return  false ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
  
        }


        public void btnOpen_Click(System.Object sender, System.EventArgs e)
        {
            frmLogin flog = new frmLogin();
            DialogResult sok;

            modGlobals.g_SQLDB = modGlobals.g_sDbLocation;

            sok = flog.ShowDialog();

            if (sok != DialogResult.OK)
            {
                //MessageBox.Show("不是我们的正式电子书，请验证正确性！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                modGlobals.g_sDbLocation = modGlobals.g_SQLDB;
            }

            if (!string.IsNullOrEmpty(modGlobals.g_sDbLocation))
            {

                if (File.Exists(modGlobals.g_sDbLocation))
                {
                    regset.saveSetting("BookDB", modGlobals.g_sDbLocation);

                    regset.saveSetting("BookPath", Path.GetDirectoryName(modGlobals .g_sDbLocation ));

                    this.loadDatabase(modGlobals.g_sDbLocation);
                }
                else
                {
                    frmDemo f = new frmDemo("电子书库文件已经不存在或移动了位置，请重新设置。");
                    f.ShowDialog();
                }
            }
            else
            {
                frmDemo f = new frmDemo("您是第一次使用本系统，还没有设置电子书库文件，请使用【图书目录】按钮 来选择文件。");
                f.ShowDialog();
            }

        }


        public void WebContent_DocumentCompleted(System.Object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
        {

            sVoice = this.WebContent.Document.Body.InnerText;

            if(modGlobals .chk )       System.IO.File.Delete(sTemp);

            this.pb.Value = 0;
        }

        public void btnSearch_Click(System.Object sender, System.EventArgs e)
        {
            OleDbDataReader rdr;
            //WebContent .Document .ExecCommand
            this.Cursor = Cursors.WaitCursor;
            string webc;
            string id;
            string keys;
            int i = 0;

            pb.Value = 0;

            try
            {
                rdr = modGlobals.CDataSvcs.GetReader("SELECT uid, mContent FROM [LogX] where iParentID <>-1 ;");
                while (rdr.Read())
                {
                    pb.Value = System.Convert.ToInt32(i > 100 ? 100 : i);
                    i++;
                    id = ((rdr["uid"] == DBNull.Value) ? "N/A" : (rdr["uid"])).ToString();
                    webc = ((rdr["mContent"] == DBNull.Value) ? (modGlobals.B64.encode(" ")) : (rdr["mContent"])).ToString();
                    webc = modGlobals.B64.decode(webc);

                    if (modGlobals.WordsHaveChinese2(this.txtIndex.Text))
                    {
                        keys = StringToISO_8859_1(this.txtIndex.Text.Trim());
                    }
                    else
                    {
                        keys = this.txtIndex.Text.Trim();
                    }

                    if (!string.IsNullOrEmpty(webc.Trim()))
                    {

                        if (webc.IndexOf(keys) + 1 > 0)
                        {
                            TreeNode[] nd = oTv.Nodes.Find(id, true);
                            foreach (TreeNode c in nd)
                            {
                                c.ForeColor = Color.Red;
                            }
                        }
                    }

                }
                rdr.Close();
                pb.Value = 0;
                this.Cursor = Cursors.Arrow;
                frmDemo myf = new frmDemo("搜索完成，请看红色目录部分。");
                myf.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("没有这样的关键词或者输入内容非法。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        /// <summary>
        /// 将原始字串转换为格式为&#....;&#....
        /// </summary>
        /// <param name="srcText"></param>
        /// <returns></returns>
        private string StringToISO_8859_1(string srcText)
        {
            string dst = "";
            char[] src = srcText.ToCharArray();
            for (int i = 0; i < src.Length; i++)
            {
                string str = @"&#" + (int)src[i] + ";";
                dst += str;
            }
            return dst;

        }

        /// <summary>
        /// 将字串&#....;&#....;格式字串转换为原始字符串
        /// </summary>
        /// <param name="srcText"></param>
        /// <returns></returns>
        private string ISO_8859_1ToString(string srcText)
        {
            string dst = "";
            string[] src = srcText.Split(';');

            for (int i = 0; i < src.Length; i++)
            {
                if (src[i].Length > 0)
                {
                    string str = ((char)int.Parse(src[i].Substring(2))).ToString();
                    dst += str;
                }
            }
            return dst;


        }

        private string myBook(object fn)
        {

            Microsoft.Office.Interop.Word.ApplicationClass myWordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
            Document myWordDoc = new Document();
            object FileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatRTF;

            object destination;
            object notTrue = false;
            object missing = System.Reflection.Missing.Value;

            myWordApp.Visible = false  ;

            try
            {
                myWordDoc = myWordApp.Documents.Open(ref fn, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

                destination = Path.GetDirectoryName (fn.ToString ()) +"\\"+ Path.GetFileNameWithoutExtension(fn.ToString()) + ".rtf";

                myWordDoc.SaveAs(ref destination, ref FileFormat, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

                Thread.Sleep(1);
                myWordDoc.Close(ref notTrue, ref missing, ref missing);

                myWordApp.Application.Quit(ref notTrue, ref missing, ref missing);

                myWordDoc = null;

                myWordApp = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();
                return destination.ToString();

            }
            catch (Exception)
            {
                //MsgBox(ex.Message)
                MessageBox.Show("系统问题，可能是不符合系统文件命名规则或者输入的内容为空。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        public void txtIndex_TextChanged(System.Object sender, System.EventArgs e)
        {
            this.btnSearch.Enabled = this.txtIndex.Text.Trim() != "";
        }

        public void btnLoad_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                LoadTreeView(loadstatus);
                loadstatus = !loadstatus;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void btnVoice_Click(System.Object sender, System.EventArgs e)
        {
            string temp = "";
            frmVoice fVoice = new frmVoice();

            temp = this.WebContent.Document.Body.InnerText;

            fVoice.txtSpeach.Text = ((string.IsNullOrEmpty(temp)) ? "没有要朗读的内容。" : temp).ToString();
            fVoice.ShowDialog();
        }


        public void axWindowsMediaPlayer1_ErrorEvent(System.Object sender, System.EventArgs e)
        {
            frmDemo f = new frmDemo("请安装正确的解码器，或者解码器安装有问题。");
            f.ShowDialog();

        }

        [method: System.CLSCompliant(false)]
        public void axWindowsMediaPlayer1_DoubleClickEvent(System.Object sender, AxWMPLib._WMPOCXEvents_DoubleClickEvent e)
        {
            try
            {
                this.axWindowsMediaPlayer1.fullScreen = true;
            }
            catch (Exception)
            {

            }
        }

        public void btnView_Click(System.Object sender, System.EventArgs e)
        {
            string _type = Path.GetExtension(this.showFile);

            if (_type.ToLower().Contains(".ppt") || _type.ToLower().Contains(".pps"))
            {
                ShowPresentation(showFile);
                return;
            }

            frmView f = new frmView();
            Uri tempurl = this.WebContent.Url;

            WebBrowser myweb = new WebBrowser();
            myweb = this.WebContent;
            f.Controls.Add(myweb);

            f.ShowDialog();
            this.WebContent.Parent = this.groupBox1;
            this.WebContent.Url = tempurl;

        }

        public void btnRead_Click(System.Object sender, System.EventArgs e)
        {
            oTv.Focus();
            SplitContainer1.Panel1Collapsed = !SplitContainer1.Panel1Collapsed;
        }


        private void oTv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.PageUp)
            {
                oTv.SelectedNode.PrevVisibleNode.Checked = true;
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.PageDown)
            {
                oTv.SelectedNode.NextVisibleNode.Checked = true;
            }
        }

        private void SaveLinkFile(string sFile)
        {
            string sSql;

            sSql = "UPDATE [LogX] SET mContent =  '" + sFile + "'" ;
            sSql = sSql + ", sSaveType = '外挂'";
            sSql = sSql + ", sFileType = '" + Path.GetExtension(sFile) + "'";
            sSql = sSql + " WHERE uid = " + this.oTv.SelectedNode.Tag.ToString() + ";";
            this.Cursor = Cursors.WaitCursor;

            try
            {
                modGlobals.CDataSvcs.UpdateLinkRecord(sSql);

            }
            catch (Exception)
            {
                MessageBox.Show("请选择文件，然后才能链接。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            this.Cursor = Cursors.Arrow;

        }

        private void SaveHpyLink(string sUrl)
        {
            string sSql;

            sSql = "UPDATE [LogX] SET mContent = '" + sUrl + "'";
            sSql = sSql + ", sSaveType = '网站'";
            sSql = sSql + ", sFileType = '" + Path.GetExtension(new Uri(sUrl).LocalPath) + "'";
            sSql = sSql + " WHERE uid = " + this.oTv.SelectedNode.Tag.ToString() + ";";
            this.Cursor = Cursors.WaitCursor;

            try
            {

                modGlobals.CDataSvcs.ExecuteNonQuery(sSql);

            }
            catch (Exception)
            {
                MessageBox.Show("请选择文件，然后才能链接。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            this.Cursor = Cursors.Arrow;

        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            frmNew dlg = new frmNew();

            if (dlg.ShowDialog() == DialogResult.OK)
            {

                regset.saveSetting("BookPath", dlg.bookpath);

                try
                {
                    modGlobals.CDataSvcs = null;
                    modGlobals.m_cn.Close();

                    modGlobals.CDataSvcs = new CDataServices();

                    modGlobals.CDataSvcs.ExecuteNonQuery("Update [LogX] Set sFullName = '" + dlg.bookname + "', sName = '" + dlg.bookname + "', bMoveable = true Where iParentID = -1;");

                    string tempsql="Update [Key] Set KeyCode = '" + dlg.demo + "'";
                    if(modGlobals .chk ) 
                    tempsql =tempsql +", Encry = 'Y' ";
                    else
                        tempsql = tempsql + ", Encry = 'N' ";

                    tempsql = tempsql + " Where ID = 1;";

                    modGlobals.CDataSvcs.ExecuteNonQuery(tempsql);

                    LoadTreeView(false);
                    Thread.Sleep(0);

                    this.pb.Value = 0;
                    int i = 0;

                    switch (dlg.type)
                    {
                        case "Word":
                            foreach (string fl in Directory.GetFiles(dlg.booksource, "*.doc?"))
                            {
                                this.pb.Value = (i > 100 ? 0 : i++);

                                applyWord(fl, this.oTv.TopNode.Nodes);

                            }
                            break;

                        case "内置":
                            foreach (string fl in Directory.GetFiles(dlg.booksource,"*.doc"))
                            {
                                this.pb.Value = (i > 100 ? 0 : i++);
                                this.lblInfo.Text = Path.GetFileName(fl);

                                if(!File.Exists (dlg.booksource +"\\"+Path.GetFileNameWithoutExtension (fl)+".rtf"))  this.myBook(fl);

                            }

                            this.lblInfo.Text = "文档转换完毕！";
                            this.pb.Value = 0;

                            foreach (string fl in Directory.GetFiles(dlg.booksource,"*.rtf"))
                            {
                                this.pb.Value = (i > 100 ? 0 : i++);

                                applySet(fl);

                            }
                            this.lblInfo.Text = "内置处理完毕";
                            break;
                        case "外挂":
                            foreach (string fl in Directory.GetFiles(dlg.booksource))
                            {
                                this.pb.Value = (i > 100 ? 0 : i++);
                                applySet(Path.GetFileNameWithoutExtension(fl), fl);

                            }
                            break;
                        case "网站":

                            foreach (string fl in Directory.GetFiles(dlg.booksource))
                            {
                                this.pb.Value = (i > 100 ? 0 : i++);
                                applySet(Path.GetFileNameWithoutExtension(fl), fl, dlg.dns);

                            }
                            break;

                        case "批量外挂":
                            ExcelFile(dlg.excelfile); break;
                        case "批量网站":
                            ExcelWeb(dlg.excelweb); break;
                        default:
                            break;
                    }

                    this.pb.Value = 0;
                    m_bFormIsActivated = true;

                }
                catch (Exception)
                {
                    frmDemo f = new frmDemo("系统提示：电子书库存在问题,请重新选择,或者与供应商联系！");
                    f.ShowDialog();
                    System.Windows.Forms.Application.Exit();
                }

            }
        }

        private void applyWord(object file, TreeNodeCollection nodes)
        {
            Microsoft.Office.Interop.Word.ApplicationClass myWordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
            Document myWordDoc = new Document();

            object FileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatRTF;

            object destination = "temp.doc";
            object notTrue = false;
            object True = true;
            object wdType = WdDocumentType.wdTypeDocument;
            object missing = System.Reflection.Missing.Value;
            object we = Microsoft.Office.Interop.Word.WdEditorType.wdEditorEveryone;

            object wt = Microsoft.Office.Interop.Word.WdMovementType.wdExtend;
            object up = WdUnits.wdParagraph;
            object ul = WdUnits.wdLine;
            object uw = WdUnits.wdStory;

            myWordApp.Visible = true;

            try
            {
                myWordDoc = myWordApp.Documents.Open(ref file, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                myWordApp.Selection.HomeKey(ref uw, ref missing);

                myWordDoc.Activate();


                string temp = Path.GetRandomFileName();

                destination = modGlobals.GetAppPath() + "data\\File\\" + temp + ".rtf";

                myWordDoc.SaveAs(ref destination, ref FileFormat, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);
                Thread.Sleep(0);

                this.SaveWebContent(destination.ToString(), ".rtf");
                Thread.Sleep(0);

                myWordDoc.Close(ref notTrue, ref missing, ref missing);
                myWordApp.Application.Quit(ref notTrue, ref missing, ref missing);

                GC.Collect();
                GC.WaitForPendingFinalizers();

                if (MessageBox.Show("处理完成，是否删除临时生成的文件？（是/否）", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (string fl in Directory.GetFiles(modGlobals.GetAppPath() + "data\\File\\"))
                    {
                        File.Delete(fl);
                    }
                }
                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Word 处理提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { pb.Value = 0; }
        }

        private bool checkRange(Microsoft.Office.Interop.Word.Range r)
        {
            try
            {
                if (string.IsNullOrEmpty(r.Text.ToString())) return false;
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void applySet(string file)
        {

            //新内容，并自动建立章节名称
            if (!string.IsNullOrEmpty(file))
            {
                string tempfile;
                TreeNode nd = null;

                try
                {

                    tempfile = file;
                    oTv.SelectedNode = oTv.TopNode;

                    nd = nodeAdd(Path.GetFileNameWithoutExtension(file));

                    saveNode(oTv.TopNode);
                    oTv.SelectedNode = nd;

                    if (tempfile != "")
                    {

                        this.SaveWebContent(tempfile, ".rtf");

                        Thread.Sleep(0);
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "导入提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            this.loadDatabase(modGlobals .g_sDbLocation );

        }

        private void applySet(string nodename, string file)
        {
            //设置链接文件
            if (!string.IsNullOrEmpty(file))
            {
                string tempfile;
                TreeNode nd = null;

                try
                {
                    if (!Directory.Exists(Path.GetDirectoryName(modGlobals.g_sDbLocation) + "\\File\\"))
                        Directory.CreateDirectory(Path.GetDirectoryName(modGlobals.g_sDbLocation) + "\\File\\");


                }
                catch { }

                try
                {

                    tempfile = file;
                    file = Path.GetFileName(tempfile);
                    oTv.SelectedNode = oTv.TopNode;

                    nd = nodeAdd(nodename);
                    saveNode(oTv.TopNode);
                    oTv.SelectedNode = nd;

                    if (tempfile != "")
                    {
                        if (Path.GetExtension(tempfile).ToLower().Contains(".ppt") || Path.GetExtension(tempfile).ToLower().Contains(".pps"))
                        {
                            this.getSlideImage(tempfile);
                            File.Copy(tempfile + ".jpg", Path.GetDirectoryName(modGlobals.g_sDbLocation) + "\\File\\" + Path.GetFileName(tempfile) + ".jpg", true);
                        }

                        if (Path.GetExtension(tempfile).ToLower().Contains(".doc"))
                        {
                            tempfile = myBook(tempfile);
                        }

                        this.SaveLinkFile(Path.GetFileName(tempfile));

                        string outfile = Path.GetDirectoryName(modGlobals.g_sDbLocation) + "\\File\\" + Path.GetFileName(tempfile);

                        if (modGlobals.chk)
                        {
                            CryptoProgressCallBack cb = new CryptoProgressCallBack(this.ProgressCallBackEncrypt);

                            CryptoHelp.EncryptFile(tempfile, outfile, "password0!", cb);
                        }
                        else
                            File.Copy(tempfile, outfile, true);

                        Thread.Sleep(0);

                        File.Delete(tempfile + ".jpg");
                        //File.Delete(tempfile);
                        pb.Value = 0;
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "链接文件提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void applySet(string nodename, string file, string dns)
        {
            //设置链接网站
            if (!string.IsNullOrEmpty(file))
            {
                TreeNode nd = null;

                try
                {
                    oTv.SelectedNode = oTv.TopNode;

                    nd = nodeAdd(nodename);
                    saveNode(oTv.TopNode);
                    oTv.SelectedNode = nd;

                    this.SaveHpyLink(dns + Path.GetFileName(file));
                    Thread.Sleep(0);

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "链接文件提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void updateContent(string stype, string file)
        {
            //更新现有章节内容
            if (!string.IsNullOrEmpty(file) && stype.Equals("内置"))
            {
                string tempfile;

                try
                {

                    tempfile = file;

                    string ftype = Path.GetExtension(tempfile).ToLower();

                    if ((ftype == ".doc") || (ftype == ".docx") || (ftype == ".mht") || (ftype == ".htm") || (ftype == ".html") || (ftype == ".txt"))
                    {
                        tempfile = myBook(tempfile);
                    }

                    if (tempfile != "")
                    {

                        this.SaveWebContent(tempfile, ".rtf");

                        Thread.Sleep(0);
                        MessageBox.Show("内容更新处理完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        File.Delete(tempfile);
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "导入提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }

            //更新外挂文件
            if (!string.IsNullOrEmpty(file) && stype.Equals("外挂"))
            {
                string tempfile;
                TreeNode nd = null;

                try
                {
                    if (!Directory.Exists(Path.GetDirectoryName(modGlobals.g_sDbLocation) + "\\File\\"))
                        Directory.CreateDirectory(Path.GetDirectoryName(modGlobals.g_sDbLocation) + "\\File\\");

                }
                catch { }

                try
                {

                    tempfile = file;
                    file = Path.GetFileName(tempfile);

                    if (tempfile != "")
                    {
                        this.SaveLinkFile(Path.GetFileName(tempfile));
                        if (Path.GetExtension(tempfile).ToLower().Contains(".ppt") || Path.GetExtension(tempfile).ToLower().Contains(".pps"))
                        {
                            this.getSlideImage(tempfile);
                            File.Copy(tempfile + ".jpg", Path.GetDirectoryName(modGlobals.g_sDbLocation) + "\\File\\" + Path.GetFileName(tempfile) + ".jpg", true);
                        }

                        Thread.Sleep(0);

                        string outfile = Path.GetDirectoryName(modGlobals.g_sDbLocation) + "\\File\\" + Path.GetFileName(tempfile);

                        if (modGlobals.chk)
                        {
                            CryptoProgressCallBack cb = new CryptoProgressCallBack(this.ProgressCallBackEncrypt);

                            CryptoHelp.EncryptFile(tempfile, outfile, "password0!", cb);
                        }
                        else
                            File.Copy(tempfile, outfile, true);

                        pb.Value = 0;

                        MessageBox.Show("外挂处理完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "链接文件提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            //更新链接网站
            if (!string.IsNullOrEmpty(file) && stype.Equals("网站"))
            {
                TreeNode nd = null;

                try
                {

                    this.SaveHpyLink(file);
                    Thread.Sleep(0);

                    MessageBox.Show("链接处理完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "链接文件提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void MenuDownload_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(this.hurl)) return;

            string url = this.hurl;
            string fn = this.WebContent.Url.LocalPath;
            string filePath = regset.getSetting("BookPath") + "\\File\\" + Path.GetFileName(fn);

            if (!Directory.Exists(regset.getSetting("BookPath") + "\\File\\"))
                Directory.CreateDirectory(regset.getSetting("BookPath") + "\\File\\");
            //MessageBox.Show( Path .GetFileName( url));

            try
            {
                using (WebClient wc = new WebClient())
                {

                    wc.DownloadFile(this.hurl, filePath);

                }

                StringBuilder sql = new StringBuilder("update [LogX] set mContent = '" + Path.GetFileName(fn) + "' ");
                sql.Append(", sSaveType = '外挂'");
                sql.Append(", sFileType = '" + Path.GetExtension(fn) + "'");
                sql.Append(" WHERE uid = " + this.oTv.SelectedNode.Tag.ToString() + ";");

                modGlobals.CDataSvcs.ExecuteNonQuery(sql.ToString());

                MessageBox.Show("下载完成，已经保存到本地。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void MenuItemUpdate_Click(object sender, EventArgs e)
        {
            dlg.Title = "请选择要替换的课程内容文件。";
            dlg.Filter = "RTF 文件|*.rtf|Word 文件|*.doc;*.docx|网页|*.htm;*.html|其它文件|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(dlg.FileName))
                    this.updateContent("内置", dlg.FileName);
            }
        }

        private void MenuItemLink_Click(object sender, EventArgs e)
        {
             string outfile;

            dlg.Title = "请选择要链接的课程文件。";
            dlg.Filter = "PDF 文件|*.pdf|SWF 文件|*.swf|网页|*.htm;*.html|其它文件|*.*";

            CryptoProgressCallBack cb = new CryptoProgressCallBack(this.ProgressCallBackEncrypt);
            

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(dlg.FileName))
                {
                    outfile = Path.GetDirectoryName(modGlobals.g_sDbLocation) + "\\File\\" + Path.GetFileName(dlg.FileName);
                    
                    File.Copy(dlg.FileName, outfile, true);

                    if (dlg.FileName.ToLower().Contains(".ppt") || dlg.FileName.ToLower().Contains(".pps"))
                    {
                        DialogResult ret = MessageBox.Show("是否转换为 Web 档案格式再进行外挂处理？（是/否）", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (ret == DialogResult.Yes)
                        {
                            string temp = ppt2mht(dlg.FileName);

                            if (modGlobals.chk)  CryptoHelp.EncryptFile(temp, outfile, "password0!",cb);

                            this.updateContent("外挂", outfile);
                        }
                        else

                            if (modGlobals.chk)  CryptoHelp.EncryptFile(dlg.FileName , outfile, "password0!",cb);
                            this.updateContent("外挂", dlg.FileName);

                    }

                    if (dlg.FileName.ToLower().Contains(".doc"))
                    {
                        DialogResult ret = MessageBox.Show("是否转换为 Web 档案格式再进行外挂处理？（是/否）", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (ret == DialogResult.Yes)
                        {
                            string temp = myBook(dlg.FileName);
                            if (modGlobals.chk) CryptoHelp.EncryptFile(temp, outfile, "password0!", cb);

                            this.updateContent("外挂", outfile );
                        }
                        else
                        {
                            if (modGlobals.chk) CryptoHelp.EncryptFile(dlg.FileName, outfile, "password0!", cb);

                            this.updateContent("外挂", outfile );
                        }
                    }

                    if (dlg.FileName.ToLower().Contains(".swf") || dlg.FileName.ToLower().Contains(".htm"))
                    {
                        if (modGlobals.chk) CryptoHelp.EncryptFile(dlg.FileName, outfile, "password0!", cb);

                        this.updateContent("外挂", outfile );
                    }
                }

            }
        }

        private void MenuItemWeb_Click(object sender, EventArgs e)
        {
            string hk = cmn.InputBox("输入链接地址", "请输入要链接的网站URL地址：", "http://");

            if (!string.IsNullOrEmpty(hk))
                this.updateContent("网站", hk);
        }

        private void MenuItemMedia_Click(object sender, EventArgs e)
        {
            dlg.Title = "请选择配套视频文件。";
            dlg.Filter = "WMV 文件|*.wmv|AVI 文件|*.avi|flash 文件|*.swf;*.flv|其它视频|*.*";

            try
            {
                if (this.type != "网站")
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        string file = dlg.FileName;
                        //多媒体处理
                        if (!string.IsNullOrEmpty(file))
                        {

                            this.SaveMediaContent(Path.GetFileName(file));

                            File.Copy(file, regset.getSetting("BookPath") + "\\media\\" + Path.GetFileName(file));

                            MessageBox.Show("处理完毕，已经增加了配套视频文件。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
                else
                {
                    string hw = cmn.InputBox("输入视频地址", "在这里输入配套视频的网站链接地址：", "http://");

                    if (!string.IsNullOrEmpty(hw))
                    {
                        this.SaveMediaContent(hw);

                    }
                }
            }
            catch { }


        }

        private void MenuDownAll_Click(object sender, EventArgs e)
        {
            OleDbDataReader rd;


            string url = "";
            string fn = "";
            string id = "";

            try
            {
                this.pb.Value = 0;

                rd = modGlobals.CDataSvcs.GetReader("select uid, sName, mContent from [LogX] where sSaveType = '网站';");

                int i = 0;

                frmInfo fi = new frmInfo();
                fi.Show();
                fi.TopMost = true;

                if (!Directory.Exists(regset.getSetting("BookPath") + "\\File\\"))
                    Directory.CreateDirectory(regset.getSetting("BookPath") + "\\File\\");

                while (rd.Read())
                {
                    string filePath = regset.getSetting("BookPath") + "\\File\\";

                    this.pb.Value = (i++ > 100 ? 0 : i);

                    url = rd["mContent"].ToString();
                    id = rd["uid"].ToString();

                    fn = new Uri(url).LocalPath;

                    filePath = filePath + Path.GetFileName(fn);

                    using (WebClient wc = new WebClient())
                    {

                        fi.label1.Text = "正在下载：" + rd["sName"].ToString();
                        fi.Update();
                        wc.DownloadFile(url, filePath);

                    }

                    StringBuilder sql = new StringBuilder("update [LogX] set mContent = '" + Path.GetFileName(fn) + "' ");
                    sql.Append(", sSaveType = '外挂'");
                    sql.Append(", sFileType = '" + Path.GetExtension(fn) + "'");
                    sql.Append(" WHERE uid = " + id + ";");

                    modGlobals.CDataSvcs.ExecuteNonQuery(sql.ToString());


                }

                rd.Close();
                fi.Close();

                this.pb.Value = 0;

                MessageBox.Show("下载完成，已经保存到本地。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WebContent_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            this.pb.Value = DateTime.Now.Second;
        }
        private void MenuItemNew_Click(object sender, EventArgs e)
        {
            dlg.Title = "请选择课程内容文件。";
            dlg.Filter = "Word 文件|*.doc;*.docx|RTF 文件|*.rtf|网页|*.htm;*.html|其它文件|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(dlg.FileName))
                    this.addNewContent("内置", dlg.FileName);
            }
        }

        private void addNewContent(string stype, string file)
        {
            //新内容，并自动建立章节名称
            if (!string.IsNullOrEmpty(file) && stype.Equals("内置"))
            {
                string tempfile;
                TreeNode nd = null;

                try
                {

                    tempfile = file;

                    nd = nodeAdd(Path.GetFileNameWithoutExtension(tempfile));
                    saveNode(oTv.TopNode);
                    oTv.SelectedNode = nd;

                    string ftype = Path.GetExtension(tempfile);

                    if ((ftype == ".doc") || (ftype == ".docx") || (ftype == ".txt") || (ftype == ".mht") || (ftype == ".htm") || (ftype == ".html") || (ftype == ".txt"))
                    {
                        tempfile = myBook(tempfile);
                    }

                    if (tempfile != "")
                    {

                        this.SaveWebContent(tempfile, ".rtf");

                        Thread.Sleep(0);
                        File.Delete(tempfile);
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "导入提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private void ExcelFile(string fn)
        {
            string strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + fn + ";Extended Properties=Excel 8.0;";
            OleDbDataReader myDataReader = null;
            OleDbConnection myOleDbConnection = new OleDbConnection(strConn);
            OleDbCommand myOleDbCommand = new OleDbCommand("SELECT * FROM [Sheet1$]", myOleDbConnection);

            try
            {
                myOleDbConnection.Open();
                myDataReader = myOleDbCommand.ExecuteReader();
                myDataReader.Read();

                int i = 0;
                this.pb.Value = i;

                while (myDataReader.Read())
                {
                    string sbn = Convert.ToString(myDataReader.GetValue(0));//列1
                    string sfn = Convert.ToString(myDataReader.GetValue(1));//列2

                    this.pb.Value = (i > 100 ? 0 : i++);
                    applySet(sbn.Trim(), sfn.Trim());
                }
                this.pb.Value = 0;
            }

            catch (Exception ex)
            {
                System.Threading.Thread.ResetAbort();
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                // 关闭
                if (myDataReader != null)
                    myDataReader.Close();

                // 关闭连接
                if (myOleDbConnection != null && myOleDbConnection.State == ConnectionState.Open)
                    myOleDbConnection.Close();

            }

        }

        private void ExcelWeb(string fn)
        {

            string strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + fn + ";Extended Properties=Excel 8.0;";
            OleDbDataReader myDataReader = null;
            OleDbConnection myOleDbConnection = new OleDbConnection(strConn);
            OleDbCommand myOleDbCommand = new OleDbCommand("SELECT * FROM [Sheet1$]", myOleDbConnection);

            try
            {
                myOleDbConnection.Open();
                myDataReader = myOleDbCommand.ExecuteReader();
                myDataReader.Read();
                int i = 0;

                while (myDataReader.Read())
                {
                    string sbn = Convert.ToString(myDataReader.GetValue(0));//列1
                    string sht = Convert.ToString(myDataReader.GetValue(1));//列2
                    string sfn = Convert.ToString(myDataReader.GetValue(2));//列3

                    this.pb.Value = (i > 100 ? 0 : i++);
                    applySet(sbn.Trim(), sfn.Trim(), sht.Trim());
                }
                this.pb.Value = 0;
            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                System.Threading.Thread.ResetAbort();
            }
            finally
            {
                // 关闭
                if (myDataReader != null)
                    myDataReader.Close();

                // 关闭连接
                if (myOleDbConnection != null && myOleDbConnection.State == ConnectionState.Open)
                    myOleDbConnection.Close();

            }

        }

        void wb_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.pb.Value = DateTime.Now.Second;
        }

        void wb_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.lblInfo.Text = "下载完成";
        }

        private void MenuItemSaveAs_Click(object sender, EventArgs e)
        {
            myurl = new Uri(this.WebContent.StatusText);

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
                        this.lblInfo.Text = "正在下载 ：" + Path.GetFileName(myurl.LocalPath);
                        wb.DownloadFileAsync(myurl, fld.SelectedPath + "\\" + Path.GetFileName(myurl.LocalPath));
                        this.pb.Value = 0;


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
            myurl = new Uri(this.WebContent.StatusText);

            if (myurl.ToString().ToLower().Contains(".baiedu"))
            {
                this.backgroundWorker1.RunWorkerAsync();
                this.MenuItemFav.Enabled = false;
                while (this.backgroundWorker1.IsBusy)
                {
                    System.Windows.Forms.Application.DoEvents();
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
                this.lblInfo.Text = "下载完成";
                this.pb.Value = 0;
            }
            else
            {
                MessageBox.Show("下载失败，请重新下载！", "下载失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            WebClient wb = new WebClient();

            this.lblInfo.Text = "正在下载 ：" + Path.GetFileName(myurl.LocalPath);
            wb.DownloadFile(myurl, modGlobals.GetAppPath() + "data\\" + Path.GetFileName(myurl.LocalPath));

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.pb.Value = DateTime.Now.Second;
        }

        void ProgressCallBackEncrypt(int min, int max, int value)
        {
            pb.Minimum = min;
            pb.Maximum = max;
            pb.Value = value;
            System.Windows.Forms.Application.DoEvents();
        }

        void ProgressCallBackDecrypt(int min, int max, int value)
        {
            pb.Maximum = max;
            pb.Minimum = min;
            pb.Value = value;
            System.Windows.Forms.Application.DoEvents();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            this.oTv.CheckBoxes = !this.oTv.CheckBoxes;
            //this.oTv.Nodes[0].Checked = true;
        }

        private void btnSaveFilter_Click(object sender, EventArgs e)
        {
            oTv.Nodes[0].Checked = true;

            foreach (TreeNode nd in oTv.Nodes)
            {
                PrintRecursive(nd);
            }

            this.lblInfo.Text = "保存了设置";
        }

        private void PrintRecursive(TreeNode treeNode)
        {
            string ch;

            if (treeNode.Checked) ch = "-1"; else ch = "0";

            modGlobals.CDataSvcs.UpdatePassword("update [LogX] set bMoveable = " + ch + " where uid = " + treeNode.Tag.ToString());

            foreach (TreeNode tn in treeNode.Nodes)
            {
                PrintRecursive(tn);
            }
        }

        private void MenuItemCopyTo_Click(object sender, EventArgs e)
        {

            saveFileDialog1.Title = "请指定电子书副本保存的位置和文件名称。";
            saveFileDialog1.Filter = "电子书文件|*.baiedu";
            saveFileDialog1.FileName = "我的副本";
            OleDbConnection mycn = new OleDbConnection();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                if (!string.IsNullOrEmpty(saveFileDialog1.FileName))
                {

                    string dest = saveFileDialog1.FileName;
                    string dir = Path.GetDirectoryName(dest);

                    dir = dir + "\\" + Path.GetFileNameWithoutExtension(dest);

                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    dest = dir + "\\" + Path.GetFileName(dest);

                    File.Copy(modGlobals.g_sDbLocation, dest, true);

                    if (!Directory.Exists(dir + "\\File"))
                        Directory.CreateDirectory(dir + "\\File");
                    if (!Directory.Exists(dir + "\\media"))
                        Directory.CreateDirectory(dir + "\\media");

                    mycn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dest + ";Jet OLEDB:Database Password=amymax620000;";
                    try
                    {
                        mycn.Open();
                        OleDbCommand mycmd = mycn.CreateCommand();
                        mycmd.CommandText = "delete from [LogX] where bMoveable = False;";
                        mycmd.ExecuteNonQuery();

                        mycmd.CommandText = "select mContent, sMedia, sSaveType from [LogX] where sSaveType = '外挂';";

                        OleDbDataReader rdr = mycmd.ExecuteReader();

                        this.lblInfo.Text = "正在复制...";
                        while (rdr.Read())
                        {
                            if (!string.IsNullOrEmpty(rdr["mContent"].ToString()))
                            {
                                MessageBox.Show(rdr["mContent"].ToString());

                                string source = Path.GetDirectoryName(modGlobals.g_sDbLocation) + "\\File\\" + rdr["mContent"].ToString();
                                string destination = dir + "\\File\\" + rdr["mContent"].ToString();
                                File.Copy(source, destination, true);
                            }

                            if (!string.IsNullOrEmpty(rdr["sMedia"].ToString()))
                            {
                                string source = Path.GetDirectoryName(modGlobals.g_sDbLocation) + "\\media\\" + rdr["sMedia"].ToString();
                                string destination = dir + "\\media\\" + rdr["sMedia"].ToString();
                                File.Copy(source, destination, true);

                            }
                        }
                        this.lblInfo.Text = "复制完毕！";
                        mycmd.Dispose();
                        mycn.Close();
                        mycn.Dispose();

                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
                else
                    MessageBox.Show("文件名不能为空。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void oTv_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null) e.Node.Parent.Checked = true;

            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    /* Calls the CheckAllChildNodes method, passing in the current 
                    Checked value of the TreeNode whose checked state changed. */
                    this.CheckAllChildNodes(e.Node, e.Node.Checked);
                }
            }

        }

        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    // If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }


        private void WebContent_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            try
            {
                foreach (object obj in modGlobals.idList)
                {
                    if (!obj.ToString().Equals(showFile))
                    {
                        if(modGlobals .chk )
                        File.Delete(obj.ToString());
                        modGlobals.idList.Remove(obj);

                    }
                }

            }
            catch { }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static IntPtr SetParent(IntPtr hChild, IntPtr hParent);

        private void ShowPresentation(string file)
        {
            PowerPoint.Application objApp = null;
            PowerPoint.Presentations objPresSet;
            PowerPoint._Presentation objPres;
            PowerPoint.Slides objSlides;
            PowerPoint.SlideShowWindows objSSWs;
            PowerPoint.SlideShowSettings objSSS;

            try
            {


                //Create a new presentation based on a template.
                objApp = new PowerPoint.Application();
                objApp.Visible = MsoTriState.msoTrue;
                objApp.ShowWindowsInTaskbar = MsoTriState.msoFalse;
                objApp.WindowState = PowerPoint.PpWindowState.ppWindowMinimized;

                SetParent((IntPtr)objApp.HWND, (IntPtr)this.pictureBox1.Handle);

                objPresSet = objApp.Presentations;

                objPres = null;


                objPres = objPresSet.Open(file, MsoTriState.msoTrue, MsoTriState.msoTrue, MsoTriState.msoFalse);
                objSlides = objPres.Slides;

                objPres.SlideShowSettings.AdvanceMode = PowerPoint.PpSlideShowAdvanceMode.ppSlideShowManualAdvance;
                //Run the Slide show from slides 1 thru 3.
                objSSS = objPres.SlideShowSettings;

                objSSS.StartingSlide = 1;
                objSSS.EndingSlide = objPres.Slides.Count;
                objSSS.ShowType = PowerPoint.PpSlideShowType.ppShowTypeSpeaker;
                objSSS.LoopUntilStopped = MsoTriState.msoTrue;
                objSSS.Run();

                //Wait for the slide show to end.
                objSSWs = objApp.SlideShowWindows;

                while (objSSWs.Count >= 1) System.Threading.Thread.Sleep(0);

                objApp.Quit();
                objApp = null;

            }
            catch
            {
                objApp.Quit();
                objApp = null;
            }
            killOffice("POWERPNT");
            GC.Collect();

            GC.WaitForPendingFinalizers();

        }


        private void getSlideImage(string file)
        {
            PowerPoint.Application objApp = null;
            PowerPoint.Presentations objPresSet;
            PowerPoint._Presentation objPres;
            PowerPoint.Slides objSlides;
            PowerPoint._Slide objSlide;

            //Create a new presentation based on a template.
            objApp = new PowerPoint.Application();
            objApp.Visible = MsoTriState.msoTrue;
            objApp.ShowWindowsInTaskbar = MsoTriState.msoFalse;
            objPresSet = objApp.Presentations;

            objPres = objPresSet.Open(file, MsoTriState.msoFalse, MsoTriState.msoTrue, MsoTriState.msoTrue);
            objSlides = objPres.Slides;

            objPres.Slides[1].Export(file + ".jpg", "JPG", 1024, 768);

            //this.pictureBox1.Image  = Clipboard.GetImage();

            //this.pictureBox1.Image .Save(file + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            Thread.Sleep(0);
            objPres.Close();
            objApp.Quit();
            objApp = null;
            killOffice("POWERPNT");
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }

        private string ppt2mht(string file)
        {
            PowerPoint.Application objApp = null;
            PowerPoint.Presentations objPresSet;
            PowerPoint._Presentation objPres;
            string destination = string.Empty;

            try
            {
                //Create a new presentation based on a template.
                objApp = new PowerPoint.Application();
                objApp.Visible = MsoTriState.msoTrue;
                objApp.ShowWindowsInTaskbar = MsoTriState.msoFalse;
                objPresSet = objApp.Presentations;

                objPres = objPresSet.Open(file, MsoTriState.msoFalse, MsoTriState.msoTrue, MsoTriState.msoTrue);

                destination = modGlobals.GetAppPath() + "data\\" + Path.GetFileNameWithoutExtension(file) + ".mht";

                objPres.SaveAs(destination, PowerPoint.PpSaveAsFileType.ppSaveAsWebArchive, MsoTriState.msoTrue);

                Thread.Sleep(0);
                objPres.Close();
                objApp.Quit();
                objApp = null;
            }
            catch
            {
            }
            finally
            {
                killOffice("POWERPNT");
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }

            if (File.Exists(destination))
            {
                string temp = string.Empty;

                temp = File.ReadAllText(destination);

                string s = "<frameset cols=3D\"25%,*\" onload=3D\"Load()\" id=3DPPTHorizAdjust framespacin=";
                string d = "<frameset cols=3D\"0%,*\" onload=3D\"Load()\" id=3DPPTHorizAdjust framespacin=";
                temp = temp.Replace(s, d);

                File.WriteAllText(destination, temp);
                Thread.Sleep(0);

            }

            return destination;
        }

        private void killOffice(string processName)
        {
            Process[] p = Process.GetProcesses();
            foreach (Process p1 in p)
            {
                if (p1.ProcessName.Trim() == processName)//这里判断是 appname   
                {
                    Process[] procList = Process.GetProcessesByName(processName);
                    procList[0].Kill();
                    break;
                }
            }
        }


          private void MenuItemWord_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "选择要使用的电子书原稿文件。";
            dlg.FileName = "";
            dlg.Filter = "Word 文档|*.doc;*.docx";

            DialogResult ret = dlg.ShowDialog();

            if (ret == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(dlg.FileName))
                {
                    if (this.oTv.SelectedNode == null)
                        this.oTv.SelectedNode = oTv.TopNode;
                    this.applyWord(dlg.FileName, this.oTv.SelectedNode.Nodes);
                }
            }

        }

        private void frmMain_Activated(object sender, EventArgs e)
        {

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = false;
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        private void btnQ_Click(object sender, EventArgs e)
        {
            if (this.Visible) this.Visible = false; else this.Visible = true;
        }

        private void btnLarge_Click(object sender, EventArgs e)
        {
            this.axShockwaveFlash1.Stop();

            frmMedia f = new frmMedia();

            f.axFlash1.Movie = this.axShockwaveFlash1.Movie;
            f.axFlash1.Play();
            f.ShowDialog();
        }

        private void MenuItemUpdateCon_Click(object sender, EventArgs e)
        {
            this.SaveInnerContent(this.rtfDOC.RichTextBox.Rtf.ToString());
        }

        /*
        private void btnMagic_Click(object sender, EventArgs e)
        {
            frmMagic f = new frmMagic();
            f.ShowDialog(this);
        }
        */
        private void MenuItemToRTF_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.Description = "选择要转换的文档文件夹";

            fd.ShowDialog();

            int i=0;

            foreach (string fl in Directory.GetFiles(fd.SelectedPath , "*.doc*"))
            {
                this.pb.Value = (i > 100 ? 0 : i++);
                this.lblInfo.Text = Path.GetFileName(fl);

                this.lblInfo.Text = fl;

                if (!File.Exists(fd.SelectedPath  + "\\" + Path.GetFileNameWithoutExtension(fl) + ".rtf")) this.myBook(fl);

            }

            this.lblInfo.Text = "文档转换完毕！";
            this.pb.Value = 0;
        }

        private void MenuItemCutWord_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "选择要切割的文件";
            dlg.Filter = "word 文档|*.doc;*.docx";

            if(dlg.ShowDialog ()==DialogResult .OK )         this.cutWord(dlg.FileName );
        }

        private void cutWord(object file)
        {
            Microsoft.Office.Interop.Word.ApplicationClass myWordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
            Document myWordDoc = new Document();
            Document mytempdoc = new Document();

            object FileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocument97  ;

            object destination = "temp.doc";
            object notTrue = false;
            object True = true;
            object wdType = WdDocumentType.wdTypeDocument;
            object missing = System.Reflection.Missing.Value;
            object we = Microsoft.Office.Interop.Word.WdEditorType.wdEditorEveryone;

            object wt = Microsoft.Office.Interop.Word.WdMovementType.wdExtend;
            object up = WdUnits.wdParagraph;
            object ul = WdUnits.wdLine;
            object uw = WdUnits.wdStory;

            object count = 1;

            myWordApp.Visible = true;

            int i = 0;

            try
            {
                myWordDoc = myWordApp.Documents.Open(ref file, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();
                myWordApp.Selection.HomeKey(ref uw, ref missing);

                Microsoft.Office.Interop.Word.Style _style, _ts;

                foreach (Paragraph pa in myWordDoc.Paragraphs)
                {
                    pb.Value = (i > pb.Maximum ? 0 : i++);

                    myWordDoc.Activate();
                    _style = (Microsoft.Office.Interop.Word.Style)pa.get_Style();

                    myWordApp.Selection.MoveDown(ref up, ref count, ref wt);

                    //预先判断下一段落属性
                    try
                    {

                        Paragraph par = pa.Next(ref count);
                        if (par != null)
                        {
                            _ts = (Microsoft.Office.Interop.Word.Style)par.get_Style();
                            if (_ts.NameLocal.Contains("标题 1") || _ts.NameLocal.Contains("标题 2") || _ts.NameLocal.Contains("标题 3"))
                            {


                                //制作文档
                                myWordApp.Selection.Cut();

                                mytempdoc = myWordApp.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                                mytempdoc.Activate();
                                myWordApp.Selection.WholeStory();
                                myWordApp.Selection.Paste();

                                string temp = Path.GetRandomFileName();

                                destination = Path.GetDirectoryName(file.ToString ())+ "\\_w" + i.ToString () + ".doc";

                                mytempdoc.SaveAs(ref destination, ref FileFormat, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref missing);
                                Thread.Sleep(0);

                                mytempdoc.Activate();
                                mytempdoc.Close(ref notTrue, ref missing, ref missing);

                                Thread.Sleep(0);

                                myWordDoc.Activate();


                            }
                        }
                        else
                        {
                            //制作文档
                            myWordApp.Selection.Cut();

                            mytempdoc = myWordApp.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                            mytempdoc.Activate();
                            myWordApp.Selection.WholeStory();
                            myWordApp.Selection.Paste();

                            destination = Path.GetDirectoryName (file.ToString ())+ "\\_w" + i.ToString () + ".doc";

                            mytempdoc.SaveAs(ref destination, ref FileFormat, ref missing, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing);
                            Thread.Sleep(0);

                            mytempdoc.Activate();
                            mytempdoc.Close(ref notTrue, ref missing, ref missing);

                            Thread.Sleep(0);

                            myWordDoc.Activate();

                            break;
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "另存为文件提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

                myWordDoc.Close(ref notTrue, ref missing, ref missing);
                myWordApp.Application.Quit(ref notTrue, ref missing, ref missing);

                myWordDoc = null;

                myWordApp = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();

                MessageBox.Show("处理完成");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "段落处理提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { pb.Value = 0; }
        }

    }
}
