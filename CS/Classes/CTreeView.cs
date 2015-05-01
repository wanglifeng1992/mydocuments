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

//Option Strict On



namespace Solution
{
	public class CTreeView
	{
		
		
		//// m_collDeletedNodes is used to store node deletions in memory.  A call to
		//// CTreeView.SaveNodeCollection() will commit the deletions, and other changes,
		//// to the database.
		Collection m_collDeletedNodes;
		Collection g_collDeletedNodes;
		//Dim m_cn As New SqlConnection()
		
		
		public CTreeView()
		{
			
			//// Initialize the DeletedNodes collection.
			m_collDeletedNodes = new Collection();
			g_collDeletedNodes = new Collection();
			
		}
		
		
		public void DeleteNode(TreeNode tnStart)
		{
			
			//// PURPOSE: This function will delete the designated node (tnStart) and all
			//// of its children.  The deletions will be stored in a collection.  This will
			//// keep the deletions in memory, which configuration will allow us to rollback
			//// deletions.
			
			//// Get a reference to the start node parent.
			TreeNode tnParent = tnStart.Parent;
			
			//// Delete the start node's children.  This is performed via
			//// recursion, which will walk through all children regardless of number or
			//// arrangement.  Walking through each and every child of the start node will
			//// allow us to synchronize node deletions with the database.  Simply calling
			//// the remove function will remove the node and its children, but
			//// will leave orphan records in the database.
			DeleteNodeRecursive(tnStart);
			
			//// Record the deletion of the start node.
			m_collDeletedNodes.Add(tnStart, null, null, null);
			
			//// Remove the start node from the TreeNodeCollection.
			tnStart.Nodes.Remove(tnStart);
			
			//// Update the image of the start node's parent if the start node parent status
			//// changed from a branch to a leaf node.
			if (!(tnParent == null))
			{
				if (tnParent.GetNodeCount(false) == 0)
				{
					if (!(tnParent.Parent == null))
					{
						tnParent.ImageIndex = 3;
						tnParent.SelectedImageIndex = 3;
					}
				}
			}
			
		}
		
		private void DeleteNodeRecursive(TreeNode tnParent)
		{
			
			//// PURPOSE: This function will walk through all the child nodes for a given
			//// node.  It will remove all the nodes from the TreeNodeCollection and will
			//// record all deletions in memory.  Deletions will be committed to the
			//// database when the user calls the CTreeView.SaveNodeCollection() method.
			
			TreeNode tn = null;
			try
			{
				if (tnParent.GetNodeCount(false) > 0)
				{
					tn = tnParent.Nodes[0];
					while (!(tn == null))
					{
						if (tn.GetNodeCount(false) > 0)
						{
							DeleteNodeRecursive(tn);
						}
						m_collDeletedNodes.Add(tn, null, null, null);
						tn = tn.NextNode;
					}
				}
			}
			catch (Exception ex)
			{
				Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, modGlobals.g_myAppConsts.MsgCaption);
			}
			
		}
		
		public bool IsDropAllowed(TreeNode tnStart, TreeNode tnDrop)
			{
			
			//// PURPOSE: This function will determine if a drop will cause a circular
			//// reference.  A circular reference occurs when a node is dropped onto one
			//// of its children.
			
			TreeNode tnCurrent;
			tnCurrent = tnDrop;
			
			while (!(tnCurrent == null))
			{
				if (tnCurrent == tnStart)
				{
					return false;
				}
				tnCurrent = tnCurrent.Parent;
			}
			
			return true;
			
		}
		
		
		public void PopulateTree(TreeView oTv,bool movable)
		{
			
			
			m_collDeletedNodes = null;
			m_collDeletedNodes = new Collection();
			
			
			OleDbDataReader rdr;
            string sql = string.Empty;

            if (movable)
                sql = "SELECT uid, bDeleted, dCreated, iOwnerID, dLastModified, bMoveable, bRoot, iImageIndex, iParentID, iSelectedImageIndex, iSort, sName, sFullName, iStatus FROM [LogX] Where bMoveable = true Order By iSort;";
            else
                sql = "SELECT uid, bDeleted, dCreated, iOwnerID, dLastModified, bMoveable, bRoot, iImageIndex, iParentID, iSelectedImageIndex, iSort, sName, sFullName, iStatus FROM [LogX] Order By iSort;";

			rdr = modGlobals.CDataSvcs.GetReader(sql);
			
			
			Collection collNodeKeys = new Collection();
			TreeNode tnNew;
			TreeNode tnParent;
			
            
			while (rdr.Read())
			{
				if (System.Convert.ToBoolean(rdr["bRoot"]) == true)
				{
					tnNew = oTv.Nodes.Add(System.Convert.ToString(rdr["sName"]));
					tnNew.Tag = System.Convert.ToString(rdr["uid"]);
					tnNew.ImageIndex = System.Convert.ToInt32(rdr["iImageIndex"]);
					tnNew.SelectedImageIndex = System.Convert.ToInt32(rdr["iSelectedImageIndex"]);
					tnNew.ToolTipText = System.Convert.ToString(rdr["sFullName"]);
					tnNew.Name = System.Convert.ToString(rdr["uid"]);
					tnNew.ForeColor = modGlobals.getStatus(int.Parse(((string.IsNullOrEmpty(rdr["iStatus"].ToString())) ? "0" : (rdr["iStatus"].ToString())).ToString()));
					tnNew .Checked =System.Convert .ToBoolean (rdr["bMoveable"]);
					try
					{
						//// Record the relationship of uid to node.  This will allow
						//// us to retrieve a given node by providing the uid as a
						//// key.
						collNodeKeys.Add(tnNew, System.Convert.ToString(rdr["uid"]), null, null);
					}
					catch (Exception ex)
					{
						MessageBox .Show (ex.Message );
					}
				}
				else
				{
					try
					{
						//// Get the parent node based on the relationship stored in the
						//// database.  This relationship is recorded or updated when a
						//// call is made to CTreeView.SaveTreeNodeCollection().
						tnParent = (TreeNode) (collNodeKeys[System.Convert.ToString(rdr["iParentID"])]);
						//// Add the child to the parent;
						tnNew = tnParent.Nodes.Add(System.Convert.ToString(rdr["sName"]));
						tnNew.Tag = System.Convert.ToString(rdr["uid"]);
						tnNew.ImageIndex = System.Convert.ToInt32(rdr["iImageIndex"]);
						tnNew.SelectedImageIndex = System.Convert.ToInt32(rdr["iSelectedImageIndex"]);
						tnNew.ToolTipText = System.Convert.ToString(rdr["sFullName"]);
						tnNew.Name = System.Convert.ToString(rdr["uid"]);
						tnNew.ForeColor = modGlobals.getStatus(int.Parse(((string.IsNullOrEmpty(rdr["iStatus"].ToString())) ? "0" : (rdr["iStatus"])).ToString()));
                        tnNew.Checked = System.Convert.ToBoolean(rdr["bMoveable"]);

						//// Record the relationship of uid to node.  This will allow
						//// us to retrieve a given node by providing the uid as a
						//// key.
						collNodeKeys.Add(tnNew, System.Convert.ToString(rdr["uid"]), null, null);
					}
					catch (Exception ex)
					{
                        MessageBox.Show(ex.Message);
					}
				}
			}
			
			rdr.Close();
			
			oTv.TreeViewNodeSorter = new NodeSorter();
			//oTv.TreeViewNodeSorter = New NaturalComparer()
			
			
			oTv.Sort();
			
		}
		
		public void SaveNodeCollection(TreeNode tnRootNode)
		{
			
			//// PURPOSE;  This method will save the TreeNodeCollection to the
			//// database.  It uses recursion to walk through the tree.  It must
			//// be called for each root node, if there is more than one root
			//// node.
			
			int iCntr;
			int iRecordID;
			TreeNode tn;
			
			//// Synch all deleted nodes with the database.
			for (iCntr = 1; iCntr <= m_collDeletedNodes.Count; iCntr++)
			{
				tn = (TreeNode) (m_collDeletedNodes[iCntr]);
				if (Strings.Trim(System.Convert.ToString(tn.Tag)) != "")
				{
					iRecordID = System.Convert.ToInt32(tn.Tag);
					
					modGlobals.CDataSvcs.DeleteRecord(iRecordID);
				}
			}
			
			if (!(tnRootNode == null))
			{
				//// Clear the deleted nodes collection because the references
				//// are no longer required.
				m_collDeletedNodes = null;
				m_collDeletedNodes = new Collection();
				
				//// Save all records to the database, starting with the root node.  We
				//// maintain the sort order so that the nodes can be restored in the
				//// order that they were read.  This will prevent adding a node before
				//// adding its parent.
				
				SaveNodeToDb(tnRootNode, 1);
				int temp_int = 1;
				SaveNodeCollectionRecursive(tnRootNode, ref temp_int);
			}
			
		}
		
		private void SaveNodeCollectionRecursive(TreeNode tnParent, ref int iSort)
		{
			
			//// PURPOSE: This function will save all child nodes in a given order
			//// starting with the root node and working out towards the child nodes.
			//// This function uses recursion, and will walk through any tree structure
			//// regardless of node count or arrangement.
			
			TreeNode tn;
			
			if (tnParent.GetNodeCount(false) > 0)
			{
				tn = tnParent.Nodes[0];
			}
			else
			{
				tn = null;
			}
			
			while (!(tn == null))
			{
				iSort++;
				SaveNodeToDb(tn, iSort);
				if (tn.GetNodeCount(false) > 0)
				{
					SaveNodeCollectionRecursive(tn, ref iSort);
				}
				tn = tn.NextNode;
			}
			
		}
		
		
		private void SaveNodeToDb(TreeNode tn, int iSort)
		{
			
			//// PURPOSE: The following method will save the designated node to the
			//// database.
			
			bool bRoot;
			CSQLFunctions SQLFunctions = new CSQLFunctions();
			int iNewRecordID;
			int iParentID;
			string sName;
			string sFullPath;
			string sSql;
			OleDbCommand cmd = modGlobals.m_cn.CreateCommand();
			
			if (!(tn.Parent == null))
			{
				iParentID = System.Convert.ToInt32(tn.Parent.Tag);
				bRoot = false;
			}
			else
			{
				iParentID = - 1;
				bRoot = true;
			}
			
			//// Need to escape single and double quotes; otherwise, they will cause
			//// exceptions when posting to the database.
			sName = SQLFunctions.EscapeSpecialChars(tn.Text);
			sFullPath = SQLFunctions.EscapeSpecialChars(tn.FullPath);
			
			//// I use the tag value to determine if a record for the node exists
			//// in the database and to hold the value of the primary key if the
			//// the record exists in the database.  If the tag value is empty, then
			//// I know the record is newly created and not yet saved in the database.
			if (Strings.Trim(System.Convert.ToString(tn.Tag)) == "")
			{
				
				//// Insert a record into the database for the node.
				sSql = "INSERT INTO [LogX] (bRoot, dLastModified, iImageIndex," + "iParentID, iSelectedImageIndex, iSort, sName, sFullName) VALUES " + "(" + (bRoot ? 1 : 0).ToString() + ",\'" + DateTime.Now+ "\'," + tn.ImageIndex + "," + iParentID + ", " + tn.SelectedImageIndex + "," + iSort + ",\'" + sName + "\', \'" + sFullPath + "\')";
				//// Execute the INSERT statement against the database.
				modGlobals.CDataSvcs.ExecuteNonQuery(sSql);
				
				//// Get the record ID for the newly created record.  This assumes that
				//// only one person is using the database.
				iNewRecordID = modGlobals.CDataSvcs.GetScalar("SELECT Max(uid) FROM [LogX]");
				
				//// Place the record ID in the node's tag.
				tn.Tag = System.Convert.ToString(iNewRecordID);
				
			}
			else
			{
				
				//// Update the corresponding record in the database for the node.
				sSql = "UPDATE [LogX] " + "SET sName=\'" + sName + "\', " + "bRoot=" + (bRoot ? 1 : 0).ToString() + ", " + "iImageIndex=" + tn.ImageIndex + ", " + "iParentID=" + iParentID + ", " + "iSelectedImageIndex=" + tn.SelectedImageIndex + ", " + "iSort=" + iSort + ", " + "sFullName=\'" + sFullPath + "\' " + "WHERE uid = " + System.Convert.ToInt32(tn.Tag);
				//// Execute the INSERT statement against the database.
				
				modGlobals.CDataSvcs.ExecuteNonQuery(sSql);
				
			}
			
		}
		
		public bool Login(string u, string p)
		{
			OleDbDataReader rdr;
			string sSql;
			
			//MsgBox(m_cn.ConnectionString.ToString, MsgBoxStyle.DefaultButton1, "x")
			
			//CDataSvcs = New CDataServices(g_sDbLocation)
			
			
			if (modGlobals.g_bOk)
			{
				
				sSql = "SELECT * FROM [SharedUsers] WHERE UserName = \'" + u + "\' AND UserPassword = \'" + p + "\';";
				
				rdr = modGlobals.CDataSvcs.GetReader(sSql);
				
				if (rdr.HasRows)
				{
					rdr.Close();
					return true;
				}
				else
				{
					rdr.Close();
					return false;
				}
			}
			else
			{
				return false;
			}
		}
	}
	
}
