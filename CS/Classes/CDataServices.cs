using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data;
using AxWMPLib;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data.OleDb;




namespace Solution
{
	public class CDataServices
	{
		//// PURPOSE: This class is used to abstract data services.  Abstraction
		//// will allow us to substitute different classes to support different
		//// database types.  This class supports MS Access (Jet ver 4.0).
		
		//Dim m_cn As New sqlConnection()
		string db;
		
		public CDataServices()
		{
			db = modGlobals.g_sDbLocation;
			
			
			try
			{
				modGlobals.m_cn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + db + ";Jet OLEDB:Database Password=amymax620000;";
				modGlobals.m_cn.Open();
				modGlobals.g_bOk = true;
			}
			catch (Exception)
			{
				modGlobals.g_bOk = false;
				MessageBox .Show ("您没有图书【" + db + "】的合法帐户，请申请！", "提示",MessageBoxButtons.OK ,MessageBoxIcon.Error );
				modGlobals.m_cn.Close();
				return;
				
			}
			
		}
		
		public void UpdateWebRecord(string sSql, string srtf)
		{
			
			
			OleDbCommand cmd = modGlobals.m_cn.CreateCommand();
			
			
			//MsgBox(sSql, MsgBoxStyle.DefaultButton1, "a")
			try
			{
				cmd.CommandText = sSql;
				
				cmd.Parameters.Add("@mContent", OleDbType.LongVarChar  , srtf.Length  , "mContent").Value = srtf.ToString ();
				
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				MessageBox .Show (ex.Message, modGlobals.g_myAppConsts.MsgCaption,MessageBoxButtons .OK ,MessageBoxIcon.Error );
			}
		}

        public void UpdateLinkRecord(string sSql)
        {


            OleDbCommand cmd = modGlobals.m_cn.CreateCommand();


            //MsgBox(sSql, MsgBoxStyle.DefaultButton1, "a")
            try
            {
                cmd.CommandText = sSql;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, modGlobals.g_myAppConsts.MsgCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdatePdfRecord(string sSql, string srtf)
        {


            OleDbCommand cmd = modGlobals.m_cn.CreateCommand();


            //MsgBox(sSql, MsgBoxStyle.DefaultButton1, "a")
            try
            {
                cmd.CommandText = sSql;

                cmd.Parameters.Add("@mContent", OleDbType.LongVarChar , srtf.Length, "mContent").Value = srtf;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, modGlobals.g_myAppConsts.MsgCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


		public void UpdateIndexRecord(string sSql)
		{
			
			
			OleDbCommand cmd = modGlobals.m_cn.CreateCommand();
			
			
			//MsgBox(sSql, MsgBoxStyle.DefaultButton1, "a")
			try
			{
				cmd.CommandText = sSql;
				
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, modGlobals.g_myAppConsts.MsgCaption);
			}
		}
		
		public void UpdateNoteRecord(string sSql, string srtf)
		{
			
			OleDbCommand cmd = modGlobals.m_cn.CreateCommand();
			
			//MsgBox(sSql, MsgBoxStyle.DefaultButton1, "a")
			try
			{
				cmd.CommandText = sSql;

                byte[] b = System.Text.Encoding.Unicode.GetBytes(srtf.ToString());

				cmd.Parameters.Add("@mNote", OleDbType.LongVarBinary, srtf.Length, "mNote").Value = b;
				
				cmd.ExecuteNonQuery();
			}
			catch (Exception)
			{
				Interaction.MsgBox(sSql, MsgBoxStyle.Critical, modGlobals.g_myAppConsts.MsgCaption);
			}
		}
		
		
		public void UpdatePassword(string sSql)
		{
			OleDbCommand cmd = modGlobals.m_cn.CreateCommand();
			
			try
			{
				cmd.CommandText = sSql;
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, modGlobals.g_myAppConsts.MsgCaption);
			}
		}
		
		public void DeleteRecord(int iRecordID)
		{
			
			//// PURPOSE: The following function will delete the designated record from
			//// the database.
			
			//// NOTE: The brackets '[]' are not required around the table name.  They
			//// are only required if the table name contains spaces.  I have included
			//// them as a matter of style.
			
			string sSql;
			OleDbCommand cmd = modGlobals.m_cn.CreateCommand();
			
			try
			{
				sSql = "DELETE FROM [LogX] WHERE uid=" + iRecordID + ";";
				cmd.CommandText = sSql;
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, modGlobals.g_myAppConsts.MsgCaption);
			}
			
		}
		
		public OleDbDataReader GetReader(string sSql)
		{
			
			//// PURPOSE: This function will return a DataReader object for a given
			//// SQL expression.
			OleDbDataReader rdr;
			OleDbCommand cmd;
			
			//MsgBox(sRtfs.ToString(), MsgBoxStyle.DefaultButton1, "x")
			
			try
			{
				cmd = modGlobals.m_cn.CreateCommand();
				cmd.CommandText = sSql;
				rdr = cmd.ExecuteReader();
				return rdr;
  			}
			catch (Exception ex)
			{
				Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, modGlobals.g_myAppConsts.MsgCaption);
				
			}
			
			return null;
		}
		
		
		public int GetScalar(string sSql)
		{
			
			//// PURPOSE: This function will return a Scalar for a given SQL expression.
			
			try
			{
				OleDbCommand cmd = modGlobals.m_cn.CreateCommand();
				cmd.CommandText = sSql;
				int iNewRecordID;
				iNewRecordID = System.Convert.ToInt32(cmd.ExecuteScalar());
				return iNewRecordID;
			}
			catch (Exception ex)
			{
				Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, modGlobals.g_myAppConsts.MsgCaption);
			}
			
			return 0;
		}
		
		
		public void ExecuteNonQuery(string sSql)
		{
			
			//// PURPOSE: This function will execute a non-query SQL statement such
			//// as an INSERT or UPDATE or DELETE statement.
			
			try
			{
				OleDbCommand cmd = modGlobals.m_cn.CreateCommand();
				cmd.CommandText = sSql;
				cmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, modGlobals.g_myAppConsts.MsgCaption);
			}
			
		}
		
		public string GetColumn(string sSql)
		{
			
			//// PURPOSE: This function will return a Scalar for a given SQL expression.
			
			try
			{
				OleDbCommand cmd = modGlobals.m_cn.CreateCommand();
				cmd.CommandText = sSql;
				return cmd.ExecuteScalar().ToString();
			}
			catch (Exception)
			{
				//MsgBox(ex.Message, MsgBoxStyle.Critical, g_myAppConsts.MsgCaption)
				return string.Empty ;
			}
			
		}
		
	}
	
}
