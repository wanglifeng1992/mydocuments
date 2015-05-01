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
	public partial class frmMain : System.Windows.Forms.Form
		{
		
		//Form 重写 Dispose，以清理组件列表。
		protected override void Dispose(bool disposing)
			{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

        //Windows 窗体设计器所必需的
		
		//注意: 以下过程是 Windows 窗体设计器所必需的
		//可以使用 Windows 窗体设计器修改它。
		//不要使用代码编辑器修改它。
		private void InitializeComponent()
			{
                this.components = new System.ComponentModel.Container();
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
                this.ContextMenu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
                this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
                this.MenuDownAll = new System.Windows.Forms.ToolStripMenuItem();
                this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
                this.MenuDownload = new System.Windows.Forms.ToolStripMenuItem();
                this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
                this.MenuItemNew = new System.Windows.Forms.ToolStripMenuItem();
                this.MenuItemUpdate = new System.Windows.Forms.ToolStripMenuItem();
                this.MenuItemUpdateCon = new System.Windows.Forms.ToolStripMenuItem();
                this.MenuItemLink = new System.Windows.Forms.ToolStripMenuItem();
                this.MenuItemWeb = new System.Windows.Forms.ToolStripMenuItem();
                this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
                this.MenuItemMedia = new System.Windows.Forms.ToolStripMenuItem();
                this.MenuItemCopyTo = new System.Windows.Forms.ToolStripMenuItem();
                this.MenuItemWord = new System.Windows.Forms.ToolStripMenuItem();
                this.MenuItemToRTF = new System.Windows.Forms.ToolStripMenuItem();
                this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
                this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
                this.Panel2 = new System.Windows.Forms.Panel();
                this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
                this.oTv = new System.Windows.Forms.TreeView();
                this.ImageList4 = new System.Windows.Forms.ImageList(this.components);
                this.tabVideo = new FarsiLibrary.Win.FATabStrip();
                this.tabPageWMV = new FarsiLibrary.Win.FATabStripItem();
                this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
                this.tabPageSWF = new FarsiLibrary.Win.FATabStripItem();
                this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
                this.axShockwaveFlash1 = new AxShockwaveFlashObjects.AxShockwaveFlash();
                this.btnLarge = new System.Windows.Forms.Button();
                this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
                this.TableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
                this.pb = new System.Windows.Forms.ProgressBar();
                this.rtfNote = new System.Windows.Forms.RichTextBox();
                this.txtIndex = new System.Windows.Forms.TextBox();
                this.Label3 = new System.Windows.Forms.Label();
                this.lblInfo = new System.Windows.Forms.Label();
                this.btnSearch = new System.Windows.Forms.Button();
                this.pictureBox1 = new System.Windows.Forms.PictureBox();
                this.btnQ = new System.Windows.Forms.Button();
                this.browserTabControl = new FarsiLibrary.Win.FATabStrip();
                this.tabPageWEB = new FarsiLibrary.Win.FATabStripItem();
                this.groupBox1 = new System.Windows.Forms.GroupBox();
                this.WebContent = new System.Windows.Forms.WebBrowser();
                this.tabPageCSWF = new FarsiLibrary.Win.FATabStripItem();
                this.groupBox2 = new System.Windows.Forms.GroupBox();
                this.axFlash = new AxShockwaveFlashObjects.AxShockwaveFlash();
                this.tabPageRTF = new FarsiLibrary.Win.FATabStripItem();
                this.groupBox3 = new System.Windows.Forms.GroupBox();
                this.rtfDOC = new RichTextBoxExtended.RichTextBoxExtended();
                this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
                this.MenuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
                this.MenuItemFav = new System.Windows.Forms.ToolStripMenuItem();
                this.TableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
                this.btnGo = new System.Windows.Forms.Button();
                this.TextBox1 = new System.Windows.Forms.TextBox();
                this.Label5 = new System.Windows.Forms.Label();
                this.ImageList3 = new System.Windows.Forms.ImageList(this.components);
                this.ImageList2 = new System.Windows.Forms.ImageList(this.components);
                this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
                this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
                this.Timer1 = new System.Windows.Forms.Timer(this.components);
                this.TableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
                this.TableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
                this.SysToolBar = new System.Windows.Forms.ToolStrip();
                this.Label1 = new System.Windows.Forms.ToolStripLabel();
                this.btnOpen = new System.Windows.Forms.ToolStripButton();
                this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
                this.btnExpandAll = new System.Windows.Forms.ToolStripButton();
                this.btnCollAll = new System.Windows.Forms.ToolStripButton();
                this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
                this.btnSave = new System.Windows.Forms.ToolStripButton();
                this.btnTemp = new System.Windows.Forms.ToolStripButton();
                this.btnRead = new System.Windows.Forms.ToolStripButton();
                this.btnView = new System.Windows.Forms.ToolStripButton();
                this.ToolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
                this.btnVoice = new System.Windows.Forms.ToolStripButton();
                this.btnFilter = new System.Windows.Forms.ToolStripButton();
                this.btnSaveFilter = new System.Windows.Forms.ToolStripButton();
                this.btnLoad = new System.Windows.Forms.ToolStripButton();
                this.btnHelp = new System.Windows.Forms.ToolStripButton();
                this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
                this.btnAdd = new System.Windows.Forms.ToolStripButton();
                this.btnDelete = new System.Windows.Forms.ToolStripButton();
                this.btnSaveNode = new System.Windows.Forms.ToolStripButton();
                this.btnNew = new System.Windows.Forms.ToolStripButton();
                this.btnMagic = new System.Windows.Forms.ToolStripButton();
                this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
                this.dlg = new System.Windows.Forms.OpenFileDialog();
                this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
                this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
                this.MenuItemCutWord = new System.Windows.Forms.ToolStripMenuItem();
                this.ContextMenu1.SuspendLayout();
                this.SplitContainer1.Panel1.SuspendLayout();
                this.SplitContainer1.Panel2.SuspendLayout();
                this.SplitContainer1.SuspendLayout();
                this.Panel2.SuspendLayout();
                this.TableLayoutPanel2.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.tabVideo)).BeginInit();
                this.tabVideo.SuspendLayout();
                this.tabPageWMV.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
                this.tabPageSWF.SuspendLayout();
                this.tableLayoutPanel3.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).BeginInit();
                this.TableLayoutPanel1.SuspendLayout();
                this.TableLayoutPanel5.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.browserTabControl)).BeginInit();
                this.browserTabControl.SuspendLayout();
                this.tabPageWEB.SuspendLayout();
                this.groupBox1.SuspendLayout();
                this.tabPageCSWF.SuspendLayout();
                this.groupBox2.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.axFlash)).BeginInit();
                this.tabPageRTF.SuspendLayout();
                this.groupBox3.SuspendLayout();
                this.contextMenuStrip1.SuspendLayout();
                this.TableLayoutPanel4.SuspendLayout();
                this.TableLayoutPanel6.SuspendLayout();
                this.TableLayoutPanel7.SuspendLayout();
                this.SysToolBar.SuspendLayout();
                this.SuspendLayout();
                // 
                // ContextMenu1
                // 
                this.ContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.MenuDownAll,
            this.toolStripMenuItem4,
            this.MenuDownload,
            this.toolStripMenuItem1,
            this.MenuItemNew,
            this.MenuItemUpdate,
            this.MenuItemUpdateCon,
            this.MenuItemLink,
            this.MenuItemWeb,
            this.toolStripSeparator5,
            this.MenuItemMedia,
            this.MenuItemCopyTo,
            this.MenuItemWord,
            this.MenuItemToRTF,
            this.MenuItemCutWord});
                this.ContextMenu1.Name = "ContextMenu1";
                this.ContextMenu1.Size = new System.Drawing.Size(209, 314);
                // 
                // toolStripMenuItem2
                // 
                this.toolStripMenuItem2.Name = "toolStripMenuItem2";
                this.toolStripMenuItem2.Size = new System.Drawing.Size(205, 6);
                // 
                // MenuDownAll
                // 
                this.MenuDownAll.Name = "MenuDownAll";
                this.MenuDownAll.Size = new System.Drawing.Size(208, 22);
                this.MenuDownAll.Text = "下载到本地（全部章节）";
                this.MenuDownAll.Click += new System.EventHandler(this.MenuDownAll_Click);
                // 
                // toolStripMenuItem4
                // 
                this.toolStripMenuItem4.Name = "toolStripMenuItem4";
                this.toolStripMenuItem4.Size = new System.Drawing.Size(205, 6);
                // 
                // MenuDownload
                // 
                this.MenuDownload.Image = global::My.Resources.Resources.workgroup;
                this.MenuDownload.Name = "MenuDownload";
                this.MenuDownload.Size = new System.Drawing.Size(208, 22);
                this.MenuDownload.Text = "下载到本地（当前章节）";
                this.MenuDownload.Click += new System.EventHandler(this.MenuDownload_Click);
                // 
                // toolStripMenuItem1
                // 
                this.toolStripMenuItem1.Name = "toolStripMenuItem1";
                this.toolStripMenuItem1.Size = new System.Drawing.Size(205, 6);
                // 
                // MenuItemNew
                // 
                this.MenuItemNew.Name = "MenuItemNew";
                this.MenuItemNew.Size = new System.Drawing.Size(208, 22);
                this.MenuItemNew.Text = "新建图书章节及内容";
                this.MenuItemNew.Click += new System.EventHandler(this.MenuItemNew_Click);
                // 
                // MenuItemUpdate
                // 
                this.MenuItemUpdate.Name = "MenuItemUpdate";
                this.MenuItemUpdate.Size = new System.Drawing.Size(208, 22);
                this.MenuItemUpdate.Text = "更新章节内容";
                this.MenuItemUpdate.Click += new System.EventHandler(this.MenuItemUpdate_Click);
                // 
                // MenuItemUpdateCon
                // 
                this.MenuItemUpdateCon.Name = "MenuItemUpdateCon";
                this.MenuItemUpdateCon.Size = new System.Drawing.Size(208, 22);
                this.MenuItemUpdateCon.Text = "保存章节内容";
                this.MenuItemUpdateCon.Click += new System.EventHandler(this.MenuItemUpdateCon_Click);
                // 
                // MenuItemLink
                // 
                this.MenuItemLink.Name = "MenuItemLink";
                this.MenuItemLink.Size = new System.Drawing.Size(208, 22);
                this.MenuItemLink.Text = "更新本地文件";
                this.MenuItemLink.Click += new System.EventHandler(this.MenuItemLink_Click);
                // 
                // MenuItemWeb
                // 
                this.MenuItemWeb.Name = "MenuItemWeb";
                this.MenuItemWeb.Size = new System.Drawing.Size(208, 22);
                this.MenuItemWeb.Text = "更新网站链接";
                this.MenuItemWeb.Click += new System.EventHandler(this.MenuItemWeb_Click);
                // 
                // toolStripSeparator5
                // 
                this.toolStripSeparator5.Name = "toolStripSeparator5";
                this.toolStripSeparator5.Size = new System.Drawing.Size(205, 6);
                // 
                // MenuItemMedia
                // 
                this.MenuItemMedia.Name = "MenuItemMedia";
                this.MenuItemMedia.Size = new System.Drawing.Size(208, 22);
                this.MenuItemMedia.Text = "设置关联媒体文件";
                this.MenuItemMedia.Click += new System.EventHandler(this.MenuItemMedia_Click);
                // 
                // MenuItemCopyTo
                // 
                this.MenuItemCopyTo.Name = "MenuItemCopyTo";
                this.MenuItemCopyTo.Size = new System.Drawing.Size(208, 22);
                this.MenuItemCopyTo.Text = "制作电子书副本";
                this.MenuItemCopyTo.Click += new System.EventHandler(this.MenuItemCopyTo_Click);
                // 
                // MenuItemWord
                // 
                this.MenuItemWord.Name = "MenuItemWord";
                this.MenuItemWord.Size = new System.Drawing.Size(208, 22);
                this.MenuItemWord.Text = "从Word文档生成内容";
                this.MenuItemWord.Click += new System.EventHandler(this.MenuItemWord_Click);
                // 
                // MenuItemToRTF
                // 
                this.MenuItemToRTF.Name = "MenuItemToRTF";
                this.MenuItemToRTF.Size = new System.Drawing.Size(208, 22);
                this.MenuItemToRTF.Text = "批量转换为 RTF 格式";
                this.MenuItemToRTF.Click += new System.EventHandler(this.MenuItemToRTF_Click);
                // 
                // ImageList1
                // 
                this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
                this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
                this.ImageList1.Images.SetKeyName(0, "");
                this.ImageList1.Images.SetKeyName(1, "");
                this.ImageList1.Images.SetKeyName(2, "");
                this.ImageList1.Images.SetKeyName(3, "");
                this.ImageList1.Images.SetKeyName(4, "");
                this.ImageList1.Images.SetKeyName(5, "");
                this.ImageList1.Images.SetKeyName(6, "");
                this.ImageList1.Images.SetKeyName(7, "word.ico");
                // 
                // SplitContainer1
                // 
                this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.SplitContainer1.Location = new System.Drawing.Point(2, 49);
                this.SplitContainer1.Margin = new System.Windows.Forms.Padding(2);
                this.SplitContainer1.Name = "SplitContainer1";
                // 
                // SplitContainer1.Panel1
                // 
                this.SplitContainer1.Panel1.Controls.Add(this.Panel2);
                // 
                // SplitContainer1.Panel2
                // 
                this.SplitContainer1.Panel2.BackColor = System.Drawing.Color.WhiteSmoke;
                this.SplitContainer1.Panel2.Controls.Add(this.TableLayoutPanel1);
                this.SplitContainer1.Size = new System.Drawing.Size(1051, 653);
                this.SplitContainer1.SplitterDistance = 207;
                this.SplitContainer1.SplitterWidth = 3;
                this.SplitContainer1.TabIndex = 6;
                // 
                // Panel2
                // 
                this.Panel2.Controls.Add(this.TableLayoutPanel2);
                this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
                this.Panel2.Location = new System.Drawing.Point(0, 0);
                this.Panel2.Margin = new System.Windows.Forms.Padding(2);
                this.Panel2.Name = "Panel2";
                this.Panel2.Size = new System.Drawing.Size(207, 653);
                this.Panel2.TabIndex = 1;
                // 
                // TableLayoutPanel2
                // 
                this.TableLayoutPanel2.BackColor = System.Drawing.Color.White;
                this.TableLayoutPanel2.ColumnCount = 1;
                this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                this.TableLayoutPanel2.Controls.Add(this.oTv, 0, 0);
                this.TableLayoutPanel2.Controls.Add(this.tabVideo, 0, 1);
                this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
                this.TableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
                this.TableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
                this.TableLayoutPanel2.Name = "TableLayoutPanel2";
                this.TableLayoutPanel2.RowCount = 2;
                this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.33721F));
                this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.66279F));
                this.TableLayoutPanel2.Size = new System.Drawing.Size(207, 653);
                this.TableLayoutPanel2.TabIndex = 14;
                // 
                // oTv
                // 
                this.oTv.AllowDrop = true;
                this.oTv.BackColor = System.Drawing.Color.WhiteSmoke;
                this.oTv.ContextMenuStrip = this.ContextMenu1;
                this.oTv.Dock = System.Windows.Forms.DockStyle.Fill;
                this.oTv.ForeColor = System.Drawing.Color.Navy;
                this.oTv.HideSelection = false;
                this.oTv.HotTracking = true;
                this.oTv.ImageIndex = 0;
                this.oTv.ImageList = this.ImageList4;
                this.oTv.Indent = 17;
                this.oTv.ItemHeight = 18;
                this.oTv.LabelEdit = true;
                this.oTv.LineColor = System.Drawing.Color.Red;
                this.oTv.Location = new System.Drawing.Point(2, 2);
                this.oTv.Margin = new System.Windows.Forms.Padding(2);
                this.oTv.Name = "oTv";
                this.oTv.SelectedImageIndex = 0;
                this.oTv.ShowNodeToolTips = true;
                this.oTv.Size = new System.Drawing.Size(203, 396);
                this.oTv.Sorted = true;
                this.oTv.TabIndex = 14;
                this.oTv.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.oTv_AfterCheck);
                this.oTv.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.oTv_AfterLabelEdit);
                this.oTv.DragDrop += new System.Windows.Forms.DragEventHandler(this.oTv_DragDrop);
                this.oTv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.oTv_AfterSelect);
                this.oTv.DragEnter += new System.Windows.Forms.DragEventHandler(this.oTv_DragEnter);
                this.oTv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.oTv_KeyDown);
                this.oTv.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.oTv_AfterExpand);
                this.oTv.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.oTv_ItemDrag);
                // 
                // ImageList4
                // 
                this.ImageList4.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList4.ImageStream")));
                this.ImageList4.TransparentColor = System.Drawing.Color.Transparent;
                this.ImageList4.Images.SetKeyName(0, "shared_pictures.ico");
                this.ImageList4.Images.SetKeyName(1, "my_videos.ico");
                this.ImageList4.Images.SetKeyName(2, "shortcut_overlay.ico");
                this.ImageList4.Images.SetKeyName(3, "sharing_overlay.ico");
                // 
                // tabVideo
                // 
                this.tabVideo.Dock = System.Windows.Forms.DockStyle.Fill;
                this.tabVideo.Font = new System.Drawing.Font("Tahoma", 9F);
                this.tabVideo.Items.AddRange(new FarsiLibrary.Win.FATabStripItem[] {
            this.tabPageWMV,
            this.tabPageSWF});
                this.tabVideo.Location = new System.Drawing.Point(3, 403);
                this.tabVideo.Name = "tabVideo";
                this.tabVideo.SelectedItem = this.tabPageWMV;
                this.tabVideo.Size = new System.Drawing.Size(201, 247);
                this.tabVideo.TabIndex = 15;
                this.tabVideo.Text = "faTabStrip1";
                // 
                // tabPageWMV
                // 
                this.tabPageWMV.Controls.Add(this.axWindowsMediaPlayer1);
                this.tabPageWMV.IsDrawn = true;
                this.tabPageWMV.Name = "tabPageWMV";
                this.tabPageWMV.Selected = true;
                this.tabPageWMV.Size = new System.Drawing.Size(199, 226);
                this.tabPageWMV.TabIndex = 0;
                this.tabPageWMV.Title = "视频";
                // 
                // axWindowsMediaPlayer1
                // 
                this.axWindowsMediaPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.axWindowsMediaPlayer1.Enabled = true;
                this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 0);
                this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
                this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
                this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(199, 226);
                this.axWindowsMediaPlayer1.TabIndex = 0;
                this.axWindowsMediaPlayer1.DoubleClickEvent += new AxWMPLib._WMPOCXEvents_DoubleClickEventHandler(this.axWindowsMediaPlayer1_DoubleClickEvent);
                this.axWindowsMediaPlayer1.Enter += new System.EventHandler(this.axWindowsMediaPlayer1_Enter);
                this.axWindowsMediaPlayer1.ErrorEvent += new System.EventHandler(this.axWindowsMediaPlayer1_ErrorEvent);
                // 
                // tabPageSWF
                // 
                this.tabPageSWF.Controls.Add(this.tableLayoutPanel3);
                this.tabPageSWF.IsDrawn = true;
                this.tabPageSWF.Name = "tabPageSWF";
                this.tabPageSWF.Size = new System.Drawing.Size(199, 226);
                this.tabPageSWF.TabIndex = 1;
                this.tabPageSWF.Title = "视频(SWF)";
                // 
                // tableLayoutPanel3
                // 
                this.tableLayoutPanel3.BackColor = System.Drawing.Color.Black;
                this.tableLayoutPanel3.ColumnCount = 1;
                this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                this.tableLayoutPanel3.Controls.Add(this.axShockwaveFlash1, 0, 0);
                this.tableLayoutPanel3.Controls.Add(this.btnLarge, 0, 1);
                this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
                this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
                this.tableLayoutPanel3.Name = "tableLayoutPanel3";
                this.tableLayoutPanel3.RowCount = 2;
                this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.18584F));
                this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.81416F));
                this.tableLayoutPanel3.Size = new System.Drawing.Size(199, 226);
                this.tableLayoutPanel3.TabIndex = 0;
                // 
                // axShockwaveFlash1
                // 
                this.axShockwaveFlash1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.axShockwaveFlash1.Enabled = true;
                this.axShockwaveFlash1.Location = new System.Drawing.Point(3, 3);
                this.axShockwaveFlash1.Name = "axShockwaveFlash1";
                this.axShockwaveFlash1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axShockwaveFlash1.OcxState")));
                this.axShockwaveFlash1.Size = new System.Drawing.Size(193, 181);
                this.axShockwaveFlash1.TabIndex = 1;
                // 
                // btnLarge
                // 
                this.btnLarge.Dock = System.Windows.Forms.DockStyle.Right;
                this.btnLarge.Location = new System.Drawing.Point(127, 190);
                this.btnLarge.Name = "btnLarge";
                this.btnLarge.Size = new System.Drawing.Size(69, 33);
                this.btnLarge.TabIndex = 2;
                this.btnLarge.Text = "放大";
                this.btnLarge.UseVisualStyleBackColor = true;
                this.btnLarge.Click += new System.EventHandler(this.btnLarge_Click);
                // 
                // TableLayoutPanel1
                // 
                this.TableLayoutPanel1.BackColor = System.Drawing.Color.Black;
                this.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
                this.TableLayoutPanel1.ColumnCount = 1;
                this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
                this.TableLayoutPanel1.Controls.Add(this.TableLayoutPanel5, 0, 1);
                this.TableLayoutPanel1.Controls.Add(this.browserTabControl, 0, 0);
                this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
                this.TableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
                this.TableLayoutPanel1.Name = "TableLayoutPanel1";
                this.TableLayoutPanel1.RowCount = 2;
                this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.69841F));
                this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
                this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                this.TableLayoutPanel1.Size = new System.Drawing.Size(841, 653);
                this.TableLayoutPanel1.TabIndex = 2;
                // 
                // TableLayoutPanel5
                // 
                this.TableLayoutPanel5.BackColor = System.Drawing.Color.Transparent;
                this.TableLayoutPanel5.ColumnCount = 8;
                this.TableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.35217F));
                this.TableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.01695F));
                this.TableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.63089F));
                this.TableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
                this.TableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9F));
                this.TableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
                this.TableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
                this.TableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
                this.TableLayoutPanel5.Controls.Add(this.pb, 0, 0);
                this.TableLayoutPanel5.Controls.Add(this.rtfNote, 4, 0);
                this.TableLayoutPanel5.Controls.Add(this.txtIndex, 3, 0);
                this.TableLayoutPanel5.Controls.Add(this.Label3, 2, 0);
                this.TableLayoutPanel5.Controls.Add(this.lblInfo, 1, 0);
                this.TableLayoutPanel5.Controls.Add(this.btnSearch, 6, 0);
                this.TableLayoutPanel5.Controls.Add(this.pictureBox1, 5, 0);
                this.TableLayoutPanel5.Controls.Add(this.btnQ, 7, 0);
                this.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
                this.TableLayoutPanel5.Location = new System.Drawing.Point(4, 618);
                this.TableLayoutPanel5.Name = "TableLayoutPanel5";
                this.TableLayoutPanel5.RowCount = 1;
                this.TableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                this.TableLayoutPanel5.Size = new System.Drawing.Size(833, 31);
                this.TableLayoutPanel5.TabIndex = 65;
                // 
                // pb
                // 
                this.pb.Dock = System.Windows.Forms.DockStyle.Fill;
                this.pb.Location = new System.Drawing.Point(3, 3);
                this.pb.Name = "pb";
                this.pb.Size = new System.Drawing.Size(113, 25);
                this.pb.TabIndex = 47;
                // 
                // rtfNote
                // 
                this.rtfNote.BackColor = System.Drawing.Color.Red;
                this.rtfNote.ForeColor = System.Drawing.Color.Red;
                this.rtfNote.Location = new System.Drawing.Point(680, 3);
                this.rtfNote.Name = "rtfNote";
                this.rtfNote.Size = new System.Drawing.Size(2, 20);
                this.rtfNote.TabIndex = 5;
                this.rtfNote.Text = "x";
                this.rtfNote.Visible = false;
                // 
                // txtIndex
                // 
                this.txtIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                this.txtIndex.ImeMode = System.Windows.Forms.ImeMode.On;
                this.txtIndex.Location = new System.Drawing.Point(512, 5);
                this.txtIndex.Name = "txtIndex";
                this.txtIndex.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
                this.txtIndex.Size = new System.Drawing.Size(162, 21);
                this.txtIndex.TabIndex = 45;
                this.txtIndex.TextChanged += new System.EventHandler(this.txtIndex_TextChanged);
                // 
                // Label3
                // 
                this.Label3.BackColor = System.Drawing.Color.Transparent;
                this.Label3.ForeColor = System.Drawing.Color.White;
                this.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
                this.Label3.Location = new System.Drawing.Point(432, 0);
                this.Label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
                this.Label3.Name = "Label3";
                this.Label3.Size = new System.Drawing.Size(75, 28);
                this.Label3.TabIndex = 44;
                this.Label3.Text = "搜索关键词:";
                this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // 
                // lblInfo
                // 
                this.lblInfo.AutoEllipsis = true;
                this.lblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
                this.lblInfo.Font = new System.Drawing.Font("宋体", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                this.lblInfo.ForeColor = System.Drawing.Color.Red;
                this.lblInfo.Location = new System.Drawing.Point(122, 0);
                this.lblInfo.Name = "lblInfo";
                this.lblInfo.Size = new System.Drawing.Size(305, 31);
                this.lblInfo.TabIndex = 48;
                this.lblInfo.Text = "提示";
                this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // 
                // btnSearch
                // 
                this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
                this.btnSearch.BackgroundImage = global::My.Resources.Resources.form03;
                this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnSearch.ForeColor = System.Drawing.Color.White;
                this.btnSearch.Location = new System.Drawing.Point(709, 4);
                this.btnSearch.Name = "btnSearch";
                this.btnSearch.Size = new System.Drawing.Size(60, 23);
                this.btnSearch.TabIndex = 46;
                this.btnSearch.Text = "搜索";
                this.btnSearch.UseVisualStyleBackColor = true;
                this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
                // 
                // pictureBox1
                // 
                this.pictureBox1.Location = new System.Drawing.Point(689, 3);
                this.pictureBox1.Name = "pictureBox1";
                this.pictureBox1.Size = new System.Drawing.Size(8, 23);
                this.pictureBox1.TabIndex = 49;
                this.pictureBox1.TabStop = false;
                // 
                // btnQ
                // 
                this.btnQ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.btnQ.BackColor = System.Drawing.Color.Red;
                this.btnQ.Location = new System.Drawing.Point(805, 3);
                this.btnQ.Name = "btnQ";
                this.btnQ.Size = new System.Drawing.Size(25, 25);
                this.btnQ.TabIndex = 50;
                this.btnQ.Text = "Q";
                this.btnQ.UseVisualStyleBackColor = false;
                this.btnQ.Click += new System.EventHandler(this.btnQ_Click);
                // 
                // browserTabControl
                // 
                this.browserTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
                this.browserTabControl.Font = new System.Drawing.Font("Tahoma", 9F);
                this.browserTabControl.Items.AddRange(new FarsiLibrary.Win.FATabStripItem[] {
            this.tabPageWEB,
            this.tabPageCSWF,
            this.tabPageRTF});
                this.browserTabControl.Location = new System.Drawing.Point(4, 4);
                this.browserTabControl.Name = "browserTabControl";
                this.browserTabControl.SelectedItem = this.tabPageWEB;
                this.browserTabControl.Size = new System.Drawing.Size(833, 607);
                this.browserTabControl.TabIndex = 66;
                this.browserTabControl.Text = "faTabStrip1";
                // 
                // tabPageWEB
                // 
                this.tabPageWEB.Controls.Add(this.groupBox1);
                this.tabPageWEB.IsDrawn = true;
                this.tabPageWEB.Name = "tabPageWEB";
                this.tabPageWEB.Selected = true;
                this.tabPageWEB.Size = new System.Drawing.Size(831, 586);
                this.tabPageWEB.TabIndex = 0;
                this.tabPageWEB.Title = "主页";
                // 
                // groupBox1
                // 
                this.groupBox1.Controls.Add(this.WebContent);
                this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.groupBox1.Location = new System.Drawing.Point(0, 0);
                this.groupBox1.Name = "groupBox1";
                this.groupBox1.Size = new System.Drawing.Size(831, 586);
                this.groupBox1.TabIndex = 0;
                this.groupBox1.TabStop = false;
                // 
                // WebContent
                // 
                this.WebContent.Dock = System.Windows.Forms.DockStyle.Fill;
                this.WebContent.Location = new System.Drawing.Point(3, 18);
                this.WebContent.MinimumSize = new System.Drawing.Size(20, 20);
                this.WebContent.Name = "WebContent";
                this.WebContent.Size = new System.Drawing.Size(825, 565);
                this.WebContent.TabIndex = 0;
                // 
                // tabPageCSWF
                // 
                this.tabPageCSWF.Controls.Add(this.groupBox2);
                this.tabPageCSWF.IsDrawn = true;
                this.tabPageCSWF.Name = "tabPageCSWF";
                this.tabPageCSWF.Size = new System.Drawing.Size(831, 586);
                this.tabPageCSWF.TabIndex = 1;
                this.tabPageCSWF.Title = "内容";
                // 
                // groupBox2
                // 
                this.groupBox2.Controls.Add(this.axFlash);
                this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
                this.groupBox2.Location = new System.Drawing.Point(0, 0);
                this.groupBox2.Name = "groupBox2";
                this.groupBox2.Size = new System.Drawing.Size(831, 586);
                this.groupBox2.TabIndex = 0;
                this.groupBox2.TabStop = false;
                this.groupBox2.Text = "groupBox2";
                // 
                // axFlash
                // 
                this.axFlash.Dock = System.Windows.Forms.DockStyle.Fill;
                this.axFlash.Enabled = true;
                this.axFlash.Location = new System.Drawing.Point(3, 18);
                this.axFlash.Name = "axFlash";
                this.axFlash.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axFlash.OcxState")));
                this.axFlash.Size = new System.Drawing.Size(825, 565);
                this.axFlash.TabIndex = 0;
                // 
                // tabPageRTF
                // 
                this.tabPageRTF.Controls.Add(this.groupBox3);
                this.tabPageRTF.IsDrawn = true;
                this.tabPageRTF.Name = "tabPageRTF";
                this.tabPageRTF.Size = new System.Drawing.Size(831, 586);
                this.tabPageRTF.TabIndex = 2;
                this.tabPageRTF.Title = "文档";
                // 
                // groupBox3
                // 
                this.groupBox3.Controls.Add(this.rtfDOC);
                this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
                this.groupBox3.Location = new System.Drawing.Point(0, 0);
                this.groupBox3.Name = "groupBox3";
                this.groupBox3.Size = new System.Drawing.Size(831, 586);
                this.groupBox3.TabIndex = 0;
                this.groupBox3.TabStop = false;
                // 
                // rtfDOC
                // 
                this.rtfDOC.AcceptsTab = true;
                this.rtfDOC.AutoScroll = true;
                this.rtfDOC.AutoWordSelection = true;
                this.rtfDOC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
                this.rtfDOC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.rtfDOC.DetectURLs = true;
                this.rtfDOC.Dock = System.Windows.Forms.DockStyle.Fill;
                this.rtfDOC.ForeColor = System.Drawing.Color.Maroon;
                this.rtfDOC.Location = new System.Drawing.Point(3, 18);
                this.rtfDOC.Name = "rtfDOC";
                this.rtfDOC.ShowBold = true;
                this.rtfDOC.ShowBullet = true;
                this.rtfDOC.ShowCenterJustify = true;
                this.rtfDOC.ShowColors = true;
                this.rtfDOC.ShowCopy = true;
                this.rtfDOC.ShowCut = true;
                this.rtfDOC.ShowFont = true;
                this.rtfDOC.ShowItalic = true;
                this.rtfDOC.ShowLeftJustify = true;
                this.rtfDOC.ShowOpen = true;
                this.rtfDOC.ShowPaste = true;
                this.rtfDOC.ShowRedo = true;
                this.rtfDOC.ShowRightJustify = true;
                this.rtfDOC.ShowSave = true;
                this.rtfDOC.ShowShrink = false;
                this.rtfDOC.ShowStamp = true;
                this.rtfDOC.ShowStrikeout = true;
                this.rtfDOC.ShowUnderline = true;
                this.rtfDOC.ShowUndo = true;
                this.rtfDOC.ShowZoom = false;
                this.rtfDOC.Size = new System.Drawing.Size(825, 565);
                this.rtfDOC.StampAction = RichTextBoxExtended.StampActions.EditedBy;
                this.rtfDOC.StampColor = System.Drawing.Color.Blue;
                this.rtfDOC.TabIndex = 0;
                // 
                // contextMenuStrip1
                // 
                this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemSaveAs,
            this.MenuItemFav});
                this.contextMenuStrip1.Name = "contextMenuStrip1";
                this.contextMenuStrip1.Size = new System.Drawing.Size(185, 48);
                // 
                // MenuItemSaveAs
                // 
                this.MenuItemSaveAs.Image = global::My.Resources.Resources.audio_cd;
                this.MenuItemSaveAs.Name = "MenuItemSaveAs";
                this.MenuItemSaveAs.Size = new System.Drawing.Size(184, 22);
                this.MenuItemSaveAs.Text = "另存为我的书库图书";
                this.MenuItemSaveAs.Click += new System.EventHandler(this.MenuItemSaveAs_Click);
                // 
                // MenuItemFav
                // 
                this.MenuItemFav.Image = global::My.Resources.Resources.network_driver_offline;
                this.MenuItemFav.Name = "MenuItemFav";
                this.MenuItemFav.Size = new System.Drawing.Size(184, 22);
                this.MenuItemFav.Text = "添加到收藏书库";
                this.MenuItemFav.Click += new System.EventHandler(this.MenuItemFav_Click);
                // 
                // TableLayoutPanel4
                // 
                this.TableLayoutPanel4.ColumnCount = 3;
                this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.80982F));
                this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.19019F));
                this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 197F));
                this.TableLayoutPanel4.Controls.Add(this.btnGo, 2, 0);
                this.TableLayoutPanel4.Controls.Add(this.TextBox1, 1, 0);
                this.TableLayoutPanel4.Controls.Add(this.Label5, 0, 0);
                this.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
                this.TableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
                this.TableLayoutPanel4.Name = "TableLayoutPanel4";
                this.TableLayoutPanel4.RowCount = 1;
                this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
                this.TableLayoutPanel4.Size = new System.Drawing.Size(797, 34);
                this.TableLayoutPanel4.TabIndex = 2;
                // 
                // btnGo
                // 
                this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Left;
                this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                this.btnGo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnGo.Image = ((System.Drawing.Image)(resources.GetObject("btnGo.Image")));
                this.btnGo.Location = new System.Drawing.Point(601, 6);
                this.btnGo.Margin = new System.Windows.Forms.Padding(2);
                this.btnGo.Name = "btnGo";
                this.btnGo.Size = new System.Drawing.Size(94, 22);
                this.btnGo.TabIndex = 3;
                this.btnGo.Text = "GOoooo";
                this.btnGo.UseVisualStyleBackColor = true;
                // 
                // TextBox1
                // 
                this.TextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                this.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.TextBox1.Location = new System.Drawing.Point(73, 6);
                this.TextBox1.Name = "TextBox1";
                this.TextBox1.Size = new System.Drawing.Size(523, 21);
                this.TextBox1.TabIndex = 0;
                // 
                // Label5
                // 
                this.Label5.Dock = System.Windows.Forms.DockStyle.Fill;
                this.Label5.Location = new System.Drawing.Point(3, 0);
                this.Label5.Name = "Label5";
                this.Label5.Size = new System.Drawing.Size(64, 34);
                this.Label5.TabIndex = 1;
                this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                // 
                // ImageList3
                // 
                this.ImageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList3.ImageStream")));
                this.ImageList3.TransparentColor = System.Drawing.Color.Transparent;
                this.ImageList3.Images.SetKeyName(0, "home.ico");
                this.ImageList3.Images.SetKeyName(1, "Privado.ico");
                this.ImageList3.Images.SetKeyName(2, "word.ico");
                this.ImageList3.Images.SetKeyName(3, "web.ico");
                // 
                // ImageList2
                // 
                this.ImageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList2.ImageStream")));
                this.ImageList2.TransparentColor = System.Drawing.Color.Transparent;
                this.ImageList2.Images.SetKeyName(0, "");
                this.ImageList2.Images.SetKeyName(1, "");
                this.ImageList2.Images.SetKeyName(2, "");
                this.ImageList2.Images.SetKeyName(3, "");
                this.ImageList2.Images.SetKeyName(4, "");
                this.ImageList2.Images.SetKeyName(5, "");
                this.ImageList2.Images.SetKeyName(6, "");
                this.ImageList2.Images.SetKeyName(7, "");
                this.ImageList2.Images.SetKeyName(8, "");
                this.ImageList2.Images.SetKeyName(9, "");
                this.ImageList2.Images.SetKeyName(10, "");
                this.ImageList2.Images.SetKeyName(11, "");
                // 
                // OpenFileDialog1
                // 
                this.OpenFileDialog1.FileName = "OpenFileDialog1";
                // 
                // ToolTip1
                // 
                this.ToolTip1.AutoPopDelay = 5000;
                this.ToolTip1.BackColor = System.Drawing.SystemColors.Desktop;
                this.ToolTip1.ForeColor = System.Drawing.Color.White;
                this.ToolTip1.InitialDelay = 500;
                this.ToolTip1.IsBalloon = true;
                this.ToolTip1.ReshowDelay = 0;
                // 
                // Timer1
                // 
                this.Timer1.Interval = 600000;
                // 
                // TableLayoutPanel6
                // 
                this.TableLayoutPanel6.ColumnCount = 1;
                this.TableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                this.TableLayoutPanel6.Controls.Add(this.SplitContainer1, 0, 1);
                this.TableLayoutPanel6.Controls.Add(this.TableLayoutPanel7, 0, 0);
                this.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
                this.TableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
                this.TableLayoutPanel6.Name = "TableLayoutPanel6";
                this.TableLayoutPanel6.RowCount = 2;
                this.TableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.692407F));
                this.TableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.30759F));
                this.TableLayoutPanel6.Size = new System.Drawing.Size(1055, 704);
                this.TableLayoutPanel6.TabIndex = 7;
                // 
                // TableLayoutPanel7
                // 
                this.TableLayoutPanel7.BackColor = System.Drawing.Color.White;
                this.TableLayoutPanel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.TableLayoutPanel7.ColumnCount = 1;
                this.TableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1142F));
                this.TableLayoutPanel7.Controls.Add(this.SysToolBar, 0, 0);
                this.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
                this.TableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
                this.TableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
                this.TableLayoutPanel7.Name = "TableLayoutPanel7";
                this.TableLayoutPanel7.RowCount = 1;
                this.TableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                this.TableLayoutPanel7.Size = new System.Drawing.Size(1055, 47);
                this.TableLayoutPanel7.TabIndex = 7;
                // 
                // SysToolBar
                // 
                this.SysToolBar.BackColor = System.Drawing.Color.DarkBlue;
                this.SysToolBar.BackgroundImage = global::My.Resources.Resources.topnav_bar_shadow;
                this.SysToolBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.SysToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Label1,
            this.btnOpen,
            this.ToolStripSeparator2,
            this.btnExpandAll,
            this.btnCollAll,
            this.ToolStripSeparator3,
            this.btnSave,
            this.btnTemp,
            this.btnRead,
            this.btnView,
            this.ToolStripSeparator7,
            this.btnVoice,
            this.btnFilter,
            this.btnSaveFilter,
            this.btnLoad,
            this.btnHelp,
            this.ToolStripSeparator4,
            this.btnAdd,
            this.btnDelete,
            this.btnSaveNode,
            this.btnNew,
            this.btnMagic});
                this.SysToolBar.Location = new System.Drawing.Point(0, 0);
                this.SysToolBar.Name = "SysToolBar";
                this.SysToolBar.Size = new System.Drawing.Size(1142, 47);
                this.SysToolBar.TabIndex = 4;
                this.SysToolBar.Text = "ToolStrip1";
                // 
                // Label1
                // 
                this.Label1.Name = "Label1";
                this.Label1.Size = new System.Drawing.Size(15, 44);
                this.Label1.Text = "0";
                this.Label1.Visible = false;
                // 
                // btnOpen
                // 
                this.btnOpen.ForeColor = System.Drawing.Color.White;
                this.btnOpen.Image = global::My.Resources.Resources.png1014;
                this.btnOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
                this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.btnOpen.Name = "btnOpen";
                this.btnOpen.Size = new System.Drawing.Size(60, 44);
                this.btnOpen.Text = "我的书库";
                this.btnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
                this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
                // 
                // ToolStripSeparator2
                // 
                this.ToolStripSeparator2.Name = "ToolStripSeparator2";
                this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 47);
                // 
                // btnExpandAll
                // 
                this.btnExpandAll.ForeColor = System.Drawing.Color.White;
                this.btnExpandAll.Image = global::My.Resources.Resources.png0586;
                this.btnExpandAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
                this.btnExpandAll.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.btnExpandAll.Name = "btnExpandAll";
                this.btnExpandAll.Size = new System.Drawing.Size(60, 44);
                this.btnExpandAll.Text = "展开目录";
                this.btnExpandAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
                this.btnExpandAll.Click += new System.EventHandler(this.btnExpandAll_Click);
                // 
                // btnCollAll
                // 
                this.btnCollAll.ForeColor = System.Drawing.Color.White;
                this.btnCollAll.Image = global::My.Resources.Resources.png0758;
                this.btnCollAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
                this.btnCollAll.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.btnCollAll.Name = "btnCollAll";
                this.btnCollAll.Size = new System.Drawing.Size(60, 44);
                this.btnCollAll.Text = "折叠目录";
                this.btnCollAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
                this.btnCollAll.Click += new System.EventHandler(this.btnCollAll_Click);
                // 
                // ToolStripSeparator3
                // 
                this.ToolStripSeparator3.Name = "ToolStripSeparator3";
                this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 47);
                // 
                // btnSave
                // 
                this.btnSave.ForeColor = System.Drawing.Color.White;
                this.btnSave.Image = global::My.Resources.Resources.png0291;
                this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
                this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.btnSave.Name = "btnSave";
                this.btnSave.Size = new System.Drawing.Size(60, 44);
                this.btnSave.Text = "我的笔记";
                this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
                this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
                // 
                // btnTemp
                // 
                this.btnTemp.ForeColor = System.Drawing.Color.White;
                this.btnTemp.Image = global::My.Resources.Resources.png0672;
                this.btnTemp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
                this.btnTemp.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.btnTemp.Name = "btnTemp";
                this.btnTemp.Size = new System.Drawing.Size(60, 44);
                this.btnTemp.Text = "状态设置";
                this.btnTemp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
                this.btnTemp.Click += new System.EventHandler(this.btnTemp_Click);
                // 
                // btnRead
                // 
                this.btnRead.ForeColor = System.Drawing.Color.White;
                this.btnRead.Image = global::My.Resources.Resources.png0085;
                this.btnRead.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
                this.btnRead.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.btnRead.Name = "btnRead";
                this.btnRead.Size = new System.Drawing.Size(60, 44);
                this.btnRead.Text = "阅读模式";
                this.btnRead.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
                this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
                // 
                // btnView
                // 
                this.btnView.ForeColor = System.Drawing.Color.White;
                this.btnView.Image = global::My.Resources.Resources.png1166;
                this.btnView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
                this.btnView.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.btnView.Name = "btnView";
                this.btnView.Size = new System.Drawing.Size(60, 44);
                this.btnView.Text = "投影显示";
                this.btnView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
                this.btnView.Click += new System.EventHandler(this.btnView_Click);
                // 
                // ToolStripSeparator7
                // 
                this.ToolStripSeparator7.Name = "ToolStripSeparator7";
                this.ToolStripSeparator7.Size = new System.Drawing.Size(6, 47);
                // 
                // btnVoice
                // 
                this.btnVoice.ForeColor = System.Drawing.Color.White;
                this.btnVoice.Image = global::My.Resources.Resources.png_0003;
                this.btnVoice.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
                this.btnVoice.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.btnVoice.Name = "btnVoice";
                this.btnVoice.Size = new System.Drawing.Size(60, 44);
                this.btnVoice.Text = "语音助手";
                this.btnVoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
                this.btnVoice.Click += new System.EventHandler(this.btnVoice_Click);
                // 
                // btnFilter
                // 
                this.btnFilter.ForeColor = System.Drawing.Color.White;
                this.btnFilter.Image = global::My.Resources.Resources.png1114;
                this.btnFilter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
                this.btnFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.btnFilter.Name = "btnFilter";
                this.btnFilter.Size = new System.Drawing.Size(60, 44);
                this.btnFilter.Text = "显示设置";
                this.btnFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
                this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
                // 
                // btnSaveFilter
                // 
                this.btnSaveFilter.ForeColor = System.Drawing.Color.White;
                this.btnSaveFilter.Image = global::My.Resources.Resources.png0009;
                this.btnSaveFilter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
                this.btnSaveFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.btnSaveFilter.Name = "btnSaveFilter";
                this.btnSaveFilter.Size = new System.Drawing.Size(60, 44);
                this.btnSaveFilter.Text = "保存设置";
                this.btnSaveFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
                this.btnSaveFilter.Click += new System.EventHandler(this.btnSaveFilter_Click);
                // 
                // btnLoad
                // 
                this.btnLoad.ForeColor = System.Drawing.Color.White;
                this.btnLoad.Image = global::My.Resources.Resources.png0072;
                this.btnLoad.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
                this.btnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.btnLoad.Name = "btnLoad";
                this.btnLoad.Size = new System.Drawing.Size(60, 44);
                this.btnLoad.Text = "重新加载";
                this.btnLoad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
                this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
                // 
                // btnHelp
                // 
                this.btnHelp.ForeColor = System.Drawing.Color.White;
                this.btnHelp.Image = global::My.Resources.Resources.png0529;
                this.btnHelp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
                this.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.btnHelp.Name = "btnHelp";
                this.btnHelp.Size = new System.Drawing.Size(60, 44);
                this.btnHelp.Text = "使用帮助";
                this.btnHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
                this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
                // 
                // ToolStripSeparator4
                // 
                this.ToolStripSeparator4.Name = "ToolStripSeparator4";
                this.ToolStripSeparator4.Size = new System.Drawing.Size(6, 47);
                // 
                // btnAdd
                // 
                this.btnAdd.ForeColor = System.Drawing.Color.White;
                this.btnAdd.Image = global::My.Resources.Resources.png0570;
                this.btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
                this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.btnAdd.Name = "btnAdd";
                this.btnAdd.Size = new System.Drawing.Size(60, 44);
                this.btnAdd.Text = "添加章节";
                this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
                this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
                // 
                // btnDelete
                // 
                this.btnDelete.ForeColor = System.Drawing.Color.White;
                this.btnDelete.Image = global::My.Resources.Resources.Delete;
                this.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
                this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.btnDelete.Name = "btnDelete";
                this.btnDelete.Size = new System.Drawing.Size(60, 44);
                this.btnDelete.Text = "删除章节";
                this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
                this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
                // 
                // btnSaveNode
                // 
                this.btnSaveNode.ForeColor = System.Drawing.Color.White;
                this.btnSaveNode.Image = global::My.Resources.Resources.png0590;
                this.btnSaveNode.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
                this.btnSaveNode.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.btnSaveNode.Name = "btnSaveNode";
                this.btnSaveNode.Size = new System.Drawing.Size(60, 44);
                this.btnSaveNode.Text = "保存目录";
                this.btnSaveNode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
                this.btnSaveNode.Click += new System.EventHandler(this.btnSaveNode_Click);
                // 
                // btnNew
                // 
                this.btnNew.ForeColor = System.Drawing.Color.White;
                this.btnNew.Image = global::My.Resources.Resources.png_0279;
                this.btnNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
                this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.btnNew.Name = "btnNew";
                this.btnNew.Size = new System.Drawing.Size(60, 44);
                this.btnNew.Text = "新建图书";
                this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
                this.btnNew.Click += new System.EventHandler(this.btnSaveAs_Click);
                // 
                // btnMagic
                // 
                this.btnMagic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
                this.btnMagic.Image = ((System.Drawing.Image)(resources.GetObject("btnMagic.Image")));
                this.btnMagic.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
                this.btnMagic.ImageTransparentColor = System.Drawing.Color.Magenta;
                this.btnMagic.Name = "btnMagic";
                this.btnMagic.Size = new System.Drawing.Size(36, 44);
                this.btnMagic.Text = "文档助手";
                this.btnMagic.Visible = false;
                // 
                // backgroundWorker1
                // 
                this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
                this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
                this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
                // 
                // notifyIcon1
                // 
                this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
                this.notifyIcon1.Text = "自学成才";
                this.notifyIcon1.Visible = true;
                this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
                // 
                // MenuItemCutWord
                // 
                this.MenuItemCutWord.Name = "MenuItemCutWord";
                this.MenuItemCutWord.Size = new System.Drawing.Size(208, 22);
                this.MenuItemCutWord.Text = "分解Word文档内容";
                this.MenuItemCutWord.Click += new System.EventHandler(this.MenuItemCutWord_Click);
                // 
                // frmMain
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                this.ClientSize = new System.Drawing.Size(1055, 704);
                this.Controls.Add(this.TableLayoutPanel6);
                this.DoubleBuffered = true;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.Margin = new System.Windows.Forms.Padding(2);
                this.Name = "frmMain";
                this.Text = "【书童】电子书阅读器";
                this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                this.Load += new System.EventHandler(this.frmMain_Load);
                this.Activated += new System.EventHandler(this.frmMain_Activated);
                this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
                this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
                this.ContextMenu1.ResumeLayout(false);
                this.SplitContainer1.Panel1.ResumeLayout(false);
                this.SplitContainer1.Panel2.ResumeLayout(false);
                this.SplitContainer1.ResumeLayout(false);
                this.Panel2.ResumeLayout(false);
                this.TableLayoutPanel2.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.tabVideo)).EndInit();
                this.tabVideo.ResumeLayout(false);
                this.tabPageWMV.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
                this.tabPageSWF.ResumeLayout(false);
                this.tableLayoutPanel3.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).EndInit();
                this.TableLayoutPanel1.ResumeLayout(false);
                this.TableLayoutPanel5.ResumeLayout(false);
                this.TableLayoutPanel5.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.browserTabControl)).EndInit();
                this.browserTabControl.ResumeLayout(false);
                this.tabPageWEB.ResumeLayout(false);
                this.groupBox1.ResumeLayout(false);
                this.tabPageCSWF.ResumeLayout(false);
                this.groupBox2.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.axFlash)).EndInit();
                this.tabPageRTF.ResumeLayout(false);
                this.groupBox3.ResumeLayout(false);
                this.contextMenuStrip1.ResumeLayout(false);
                this.TableLayoutPanel4.ResumeLayout(false);
                this.TableLayoutPanel4.PerformLayout();
                this.TableLayoutPanel6.ResumeLayout(false);
                this.TableLayoutPanel7.ResumeLayout(false);
                this.TableLayoutPanel7.PerformLayout();
                this.SysToolBar.ResumeLayout(false);
                this.SysToolBar.PerformLayout();
                this.ResumeLayout(false);

		}
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
		internal System.Windows.Forms.ToolStripMenuItem MenuReport;
		internal System.Windows.Forms.ToolStripMenuItem MenuQuiz;
		internal System.Windows.Forms.ToolStripButton btnSave;
		internal System.Windows.Forms.ToolStripButton btnExpandAll;
		internal System.Windows.Forms.ToolStripButton btnCollAll;
        internal System.Windows.Forms.ToolStrip SysToolBar;
		internal System.Windows.Forms.ContextMenuStrip ContextMenu1;
		internal System.Windows.Forms.ImageList ImageList1;
		internal System.Windows.Forms.SplitContainer SplitContainer1;
		internal System.Windows.Forms.Panel Panel2;
		internal System.Windows.Forms.ImageList ImageList2;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
		internal System.Windows.Forms.ImageList ImageList3;
		internal System.Windows.Forms.ImageList ImageList4;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog1;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator7;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
		internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel4;
		internal System.Windows.Forms.TextBox TextBox1;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Button btnGo;
		internal System.Windows.Forms.ToolTip ToolTip1;
		internal System.Windows.Forms.ToolStripButton btnHelp;
		internal System.Windows.Forms.ToolStripLabel Label1;
		internal System.Windows.Forms.ToolStripButton btnTemp;
		internal System.Windows.Forms.Timer Timer1;
		internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel6;
		internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel7;
		internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
		internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel5;
        internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.RichTextBox rtfNote;
        internal System.Windows.Forms.TextBox txtIndex;
		internal System.Windows.Forms.ToolStripButton btnOpen;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
		internal System.Windows.Forms.Button btnSearch;
		internal System.Windows.Forms.ToolStripButton btnAdd;
		internal System.Windows.Forms.ToolStripButton btnDelete;
		internal System.Windows.Forms.ToolStripButton btnFilter;
		internal System.Windows.Forms.ToolStripButton btnSaveNode;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator4;
		internal System.Windows.Forms.ProgressBar pb;
		internal System.Windows.Forms.ToolStripButton btnLoad;
		internal System.Windows.Forms.ToolStripButton btnVoice;
		internal System.Windows.Forms.ToolStripButton btnView;
		internal System.Windows.Forms.ToolStripButton btnRead;
        internal System.Windows.Forms.ToolStripButton btnSaveFilter;
        private System.ComponentModel.IContainer components;
        private ToolStripButton btnNew;
        private SaveFileDialog saveFileDialog1;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripSeparator toolStripMenuItem1;
        private OpenFileDialog dlg;
        private ToolStripMenuItem MenuDownload;
        private ToolStripMenuItem MenuItemUpdate;
        private ToolStripMenuItem MenuItemLink;
        private ToolStripMenuItem MenuItemWeb;
        private ToolStripMenuItem MenuItemMedia;
        private ToolStripMenuItem MenuDownAll;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem MenuItemNew;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem MenuItemSaveAs;
        private ToolStripMenuItem MenuItemFav;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label lblInfo;
        private ToolStripMenuItem MenuItemCopyTo;
        internal TreeView oTv;
        private PictureBox pictureBox1;
        private ToolStripMenuItem MenuItemWord;
        private FarsiLibrary.Win.FATabStrip browserTabControl;
        private FarsiLibrary.Win.FATabStripItem tabPageWEB;
        private FarsiLibrary.Win.FATabStripItem tabPageCSWF;
        private FarsiLibrary.Win.FATabStripItem tabPageRTF;
        private GroupBox groupBox1;
        private WebBrowser WebContent;
        private GroupBox groupBox2;
        private AxShockwaveFlashObjects.AxShockwaveFlash axFlash;
        private GroupBox groupBox3;
        private FarsiLibrary.Win.FATabStrip tabVideo;
        private FarsiLibrary.Win.FATabStripItem tabPageWMV;
        private FarsiLibrary.Win.FATabStripItem tabPageSWF;
        private AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private RichTextBoxExtended.RichTextBoxExtended rtfDOC;
        private NotifyIcon notifyIcon1;
        private Button btnQ;
        private TableLayoutPanel tableLayoutPanel3;
        private AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlash1;
        private Button btnLarge;
        private ToolStripMenuItem MenuItemUpdateCon;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton btnMagic;
        private ToolStripMenuItem MenuItemToRTF;
        private ToolStripMenuItem MenuItemCutWord;
	}
	
}
