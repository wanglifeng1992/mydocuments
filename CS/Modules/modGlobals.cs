//#define SMHT

using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data;
using AxWMPLib;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;



namespace Solution
{
    public class modGlobals
    {

        //// PURPOSE: This module is used to create global variables, instantiate
        //// global objects, and to start the application.

        public static CDataServices CDataSvcs;
        public static CSQLFunctions ck = new CSQLFunctions();
        public static base64 B64 = new base64();
        public static string g_Key,g_CODE;
        public static bool chk = false;

        public static bool g_bOk;
        public static CConstants g_myAppConsts = new CConstants();
        public static string g_sDbLocation;
        public static string g_sSearch;
        public static string g_sUserName;
        public static string g_sMdiFileName;
        public static string g_SQLDB;
        public static int g_ID;
        public static OleDbConnection m_cn = new OleDbConnection();
        public static bool g_List = false;
        public static string regKey = "BOOKBOY";
        public static ArrayList idList = new ArrayList();
        public static int num = int.MaxValue ;

        //public static string website = "http://cid-f334732b63bdcb28.skydrive.live.com/browse.aspx/.Public/电子书";
        public static string website = "http://www.renwoxue.net/mypage.html";
        public static string title = "【自学成才】专用自学软件";
        public static object  cover = My.Resources.Resources .cover;

        [STAThread]
        public static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Splash.Default.ShowDialog();

            g_SQLDB = " ";

            g_sUserName = "(用户名)";

            g_sDbLocation = ".";

            //System.Windows.Forms.Application.Run(new Form1() );

            System.Windows.Forms.Application.Run(new frmMain());

        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            // 显示全局异常提示
            MessageBox.Show(e.Exception.Message, "全局提示");
        }

        public static string GetAppPath()
        {

            //// PURPOSE: This function returns the path of where the application
            //// is being launched.  This function substitutes for the App.Path
            //// property found in VB6.

            string sPath;

            try
            {
                //sPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                //sPath = sPath.Substring(0, Strings.InStrRev(sPath, "\\", - 1, CompareMethod.Text));
                sPath = System.Windows.Forms.Application.StartupPath + "\\";
                return sPath;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, g_myAppConsts.MsgCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return "";
        }


        public static string GetLikelyDbPath()
        {

            //// PURPOSE: This function returns the most likely place where the database
            //// file will exist.  That place is the one folder level up from the
            //// "\bin\" folder in the project solution.

            int iLoc;
            string sPath;

            sPath = GetAppPath();

            //// Move one folder higher then "\bin" if "\bin" exist.
            iLoc = (GetAppPath().ToUpper()).IndexOf("\\BIN") + 1;
            if (iLoc > 0)
            {
                sPath = sPath.Substring(0, iLoc - 1) + "\\";
            }
            return sPath;

        }
        public static Color getStatus(int i)
        {
            switch (i)
            {
                case 0:
                    return Color.Black;
                case 1:
                    return Color.Blue;
                case 2:
                    return Color.LightSeaGreen;
                case 3:
                    return Color.Purple;
                default:
                    return Color.Black;
            }
        }
        /// <summary>
        /// 判断句子中是否含有中文
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool WordsHaveChinese2(string s)
        {
            for (int i = 0; i <= s.Length - 1; i++)
            {
                if (Convert.ToInt32(Convert.ToChar(s.Substring(i, 1))) >= Convert.ToInt32(Convert.ToChar(128)))
                {
                    return true;
                }
            }
            return false;
        }

    }

}
