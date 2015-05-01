using System;
using System.Text;
using System.IO;
using Shell32;
using System.Collections;

namespace Solution
{
	/// <summary>
	/// Returns the detailed Information of a given file.
	/// </summary>
	public class CFileInfo
	{

		private string sFileName ="",
			sFullFileName="",
			sFileExtension="",
			sFilePath = "",
			sFileComment = "",
			sFileAuthor = "",
			sFileTitle = "",
			sFileSubject = "",
			sFileCategory = "",
			sFileType = "";

		private long lFileLength = 0,
			lFileVersion = 0;

		private DateTime dCreationDate,
			dModificationDate;

		

		public CFileInfo(string sFPath)
		{
			
			// check if the given File exists
			if(File.Exists(sFPath)){

				ArrayList aDetailedInfo = new ArrayList();

				FileInfo oFInfo = new FileInfo(sFPath);

				sFileName = oFInfo.Name;
				sFullFileName = oFInfo.FullName;
				sFileExtension = oFInfo.Extension;
				lFileLength=oFInfo.Length;
				sFilePath = oFInfo.Directory.ToString();
				dCreationDate = oFInfo.CreationTime;
				dModificationDate = oFInfo.LastWriteTime;
				
				#region "read File Details"
				
				aDetailedInfo = GetDetailedFileInfo(sFPath);

				foreach(DetailedFileInfo oDFI in aDetailedInfo){
					switch(oDFI.ID){
						case 2:
							sFileType = oDFI.Value;
							break;
						case 9:
							sFileAuthor = oDFI.Value;
							break;
						case 10:
							sFileTitle = oDFI.Value;
							break;
						case 11:
							sFileSubject = oDFI.Value;
							break;
						case 12:
							sFileCategory = oDFI.Value;
							break;
						case 14:
							sFileComment = oDFI.Value;
							break;
						default:
							break;
					}

				}
				

				#endregion


			}else{
				throw new Exception("文件不存在!");
			}

		}


		#region "Properties"
		public string FileName{
			get{return sFileName;}
			set{sFileName=value;}
		}

		public string FilePath{
			get{return sFilePath;}
			set{sFilePath = value;}
		}

		public string FullFileName{
			get{return sFullFileName;}
			set{sFullFileName=value;}
		}

		public string FileExtension{
			get{return sFileExtension;}
			set{sFileExtension=value;}
		}

	
		public long FileSize{
			get{return lFileLength;}
			set{lFileLength=value;}
		}

		public long FileVersion{
			get{return lFileVersion;}
			set{lFileVersion=value;}
		}

		public DateTime FileCreationDate{
			get{return dCreationDate;}
			set{dCreationDate=value;}
		}

		public DateTime FileModificationDate{
			get{return dModificationDate;}
			set{dModificationDate=value;}
		}
		
		public string FileType{
			get{return sFileType;}
		}


		public string FileTitle{
			get{return sFileTitle;}
		}

		public string FileSubject{
			get{return sFileSubject ;}
		}

		public string FileAuthor{
			get{return sFileAuthor ;}
		}

		public string FileCategory{
			get{return sFileCategory ;}
		}

		public string FileComment{
			get{return sFileComment ;}
		}


		#endregion

		#region "Methods"
		private ArrayList GetDetailedFileInfo(string sFile){
			ArrayList aReturn = new ArrayList();
			if(sFile.Length>0){
				try{

					// Creating a ShellClass Object from the Shell32
					ShellClass sh = new ShellClass();
					// Creating a Folder Object from Folder that inculdes the File
					Folder dir = sh.NameSpace( Path.GetDirectoryName( sFile ) );
					// Creating a new FolderItem from Folder that includes the File
					FolderItem item = dir.ParseName( Path.GetFileName( sFile ) );
					// loop throw the Folder Items
					for( int i = 0; i < 30; i++ ) {
						// read the current detail Info from the FolderItem Object
						//(Retrieves details about an item in a folder. For example, its size, type, or the time of its last modification.)
						// some examples:
						// 0 Retrieves the name of the item. 
						// 1 Retrieves the size of the item. 
						// 2 Retrieves the type of the item. 
						// 3 Retrieves the date and time that the item was last modified. 
						// 4 Retrieves the attributes of the item. 
						// -1 Retrieves the info tip information for the item. 

						string det = dir.GetDetailsOf( item, i );
						// Create a helper Object for holding the current Information
						// an put it into a ArrayList
						DetailedFileInfo oFileInfo = new DetailedFileInfo(i,det);
						aReturn.Add(oFileInfo);
					}

				}catch(Exception){

				}
			}
			return aReturn;
		}
		#endregion
	}


	// Helper Class from holding the detailed File Informations
	// of the System
	public class DetailedFileInfo{
		int iID = 0;
		string sValue ="";

		public int ID{
			get{return iID;}
			set{iID=value;
			}
		}
		public string Value{
			get{return sValue;}
			set{sValue = value;}
		}

		public DetailedFileInfo(int ID, string Value){
			iID = ID;
			sValue = Value;
		}
	}
}
