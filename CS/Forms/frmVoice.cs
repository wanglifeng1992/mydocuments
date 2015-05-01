using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data;
using AxWMPLib;
using SpeechLib;

namespace Solution
{
	public partial class frmVoice
	{
		public frmVoice()
		{
			InitializeComponent();
		}
		SpVoice oVoice = new SpVoice();
		
		public void btnSpeak_Click(System.Object sender, System.EventArgs e)
		{
			SpeechLib.SpFileStream cpFileStream = new SpeechLib.SpFileStream();
			oVoice.AlertBoundary = SpeechLib.SpeechVoiceEvents.SVEPhoneme;
			try
			{
				oVoice.Voice  = oVoice.GetVoices ("","").Item (cmbVoices.SelectedIndex);
				
				oVoice.Volume = trVolume.Value;
				oVoice.Rate = trRate.Value;
				
				oVoice.Speak(txtSpeach.Text, SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
			this.Cursor = Cursors.Arrow;
		}
		
		public void frmVoice_Load(System.Object sender, System.EventArgs e)
		{
			SpeechLib.SpVoice x = new SpeechLib.SpVoice();
			
			SpeechLib.ISpeechObjectTokens arrVoices = x.GetVoices("","");
			ArrayList arrLst = new ArrayList();
			try
			{
				for (int i = 0; i <= arrVoices.Count - 1; i++)
				{
					arrLst.Add(getToken(arrVoices.Item(i).GetDescription(0)));
				}
				cmbVoices.DataSource = arrLst;
			}
			catch (Exception)
			{
				
			}
			
			try
			{
				if (modGlobals.WordsHaveChinese2(this.txtSpeach.Text))
				{
					cmbVoices.SelectedIndex = 3;
				}
				else
				{
					cmbVoices.SelectedIndex = 0;
				}
			}
			catch (Exception)
			{
				
			}
		}
		private string getToken(string ds)
		{
			switch (ds.Trim())
			{
				case "Microsoft Sam":
				case "Microsoft Mike":
					return "英文（男声）";
				case "Microsoft Mary":
					return "英文（女声）";
				case "Microsoft Simplified Chinese":
					return "中文（男声）";
				default:
					return "英文";
			}
		}
		
		private void LoadFromTextFileToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			flTxtFile.Filter = "Text Files (*.txt)|*.txt";
			if (flTxtFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				//Load File Content
				System.IO.StreamReader strmRedr = new System.IO.StreamReader(flTxtFile.FileName);
				txtSpeach.Text = strmRedr.ReadToEnd();
				strmRedr.Close();
			}
		}
		
		private void btnSavetoFile_Click(System.Object sender, System.EventArgs e)
		{
			
			this.Cursor = Cursors.WaitCursor;
			
			if (SaveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				SpeechLib.SpFileStream cpFileStream = new SpeechLib.SpFileStream();
				cpFileStream.Open(SaveFileDialog1.FileName, SpeechLib.SpeechStreamFileMode.SSFMCreateForWrite, false);
				oVoice.AudioOutputStream = cpFileStream;
				oVoice.Voice = oVoice.GetVoices("","").Item(cmbVoices.SelectedIndex);
				oVoice.Volume = trVolume.Value;
				oVoice.Speak(txtSpeach.Text, SpeechLib.SpeechVoiceSpeakFlags.SVSFDefault);
				
				//oVoice = Nothing
				cpFileStream.Close();
				cpFileStream = null;
			}
			this.Cursor = Cursors.Arrow;
		}
		
		public void btnStop_Click(System.Object sender, System.EventArgs e)
		{
			
			oVoice.Pause();
		}
		
		public void btnResume_Click(System.Object sender, System.EventArgs e)
		{
			oVoice.Resume();
		}
		
		public void btnClose_Click(System.Object sender, System.EventArgs e)
		{
			oVoice.Speak(Constants.vbNull.ToString(), SpeechLib.SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak);
			this.Close();
		}
	}
	
}
