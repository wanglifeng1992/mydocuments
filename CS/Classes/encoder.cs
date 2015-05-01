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
	#region Base64 Encoder
	
	public class base64
	{
		
		
		public string encode(string inString)
		{
			System.Text.UnicodeEncoding enc = new System.Text.UnicodeEncoding();
			byte[] Buffer = enc.GetBytes(inString);
			return Convert.ToBase64String(Buffer);
		}
		
		public string decode(string inString)
		{
			System.Text.UnicodeEncoding enc = new System.Text.UnicodeEncoding();
			byte[] Buffer = Convert.FromBase64String(inString);
			return enc.GetString(Buffer);
		}
		
	}
	
	#endregion
	
	
}
