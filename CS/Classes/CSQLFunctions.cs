using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data;
using AxWMPLib;
using System.Management;
using System.Security.Cryptography;
using System.Text;
//using System.Math;

namespace Solution
{
	public class CSQLFunctions
	{
		
		//// PURPOSE: This class provides SQL functions that do not exist in the
		//// the .NET framework.
		public string getcode(string mac)
		{
			
			mac = mac.Trim();
			char[] ar = mac.ToCharArray();
			string temp;
			
			Array.Reverse(ar);
			
			temp = new string(ar) + "110108196906209791";
			
			return System.Math.Abs(temp.Replace("0", "*").GetHashCode()).ToString();
			
		}
		
		public string Bios_ID()
		{
			//get the bios information
			ManagementClass BiosClass = new ManagementClass("Win32_BIOS");
			ManagementObjectCollection Bioss = BiosClass.GetInstances();
			ManagementObjectCollection.ManagementObjectEnumerator BiossEnumerator = Bioss.GetEnumerator();
			string bios_IDs = "1";
			while (BiossEnumerator.MoveNext())
			{
				ManagementObject Bios = (ManagementObject) BiossEnumerator.Current;
				//Bios_IDs = Bios("BiosCharacteristics")
				
				//Bios_IDs = Join(Bios("BIOSVersion"))
				//Bios_IDs &= Bios("BuildNumber")
				//Bios_IDs &= Bios("Caption")
				//Bios_IDs &= Bios("IdentificationCode")
				//Bios_IDs &= Bios("Manufacturer")
				//Bios_IDs &= Bios("Name")
				bios_IDs += Bios["SerialNumber"].ToString();
				
			}
			return bios_IDs;
		}
		
		
		public string EscapeSpecialChars(string sInput)
		{
			
			//// PURPOSE: The following function will escape special characters that can
			//// cause SQL statements to error.
			
			char chrCurrent;
			char chrSingleQuote = '\u0027';
			int iCntr;
			string sOutput = "";
			
			try
			{
				for (iCntr = 0; iCntr <= sInput.Length - 1; iCntr++)
				{
					chrCurrent = System.Convert.ToChar(sInput.Substring(iCntr, 1));
					if (chrCurrent == System.Convert.ToChar(chrSingleQuote))
					{
						sOutput = sOutput + chrSingleQuote + chrSingleQuote;
					}
					else
					{
						sOutput = sOutput + chrCurrent;
					}
				}
			}
			catch (Exception ex)
			{
				Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, modGlobals.g_myAppConsts.MsgCaption);
			}
			
			return sOutput;
			
		}
		
		
	}
	
}
