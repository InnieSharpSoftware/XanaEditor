/*
By InnieSharp(ix4/i#)
*/
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FastColoredTextBoxNS;

namespace XanaEditor
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		Style GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Regular);
		Style RedStyle = new TextStyle(Brushes.Red, null, FontStyle.Regular);
		Style PurpleStyle = new TextStyle(Brushes.Purple, null, FontStyle.Regular);
		Style BlueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
		Style YellowStyle = new TextStyle(Brushes.Yellow, null, FontStyle.Regular);
		Style PinkStyle = new TextStyle(Brushes.Pink, null, FontStyle.Regular);
		Style astyle = new TextStyle(Brushes.BlueViolet, null, FontStyle.Regular);
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void OpenToolStripMenuItemClick(object sender, EventArgs e)
		{
			openFileDialog1.ShowDialog();
		}
		void SaveToolStripMenuItemClick(object sender, EventArgs e)
		{
			saveFileDialog1.ShowDialog();
		}
		void RunToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(richTextBox1.Visible == false)
				richTextBox1.Visible = true;
			else
				richTextBox1.Visible = false;
		}
		void FastColoredTextBox1Load(object sender, EventArgs e)
		{
			
		}
		void SaveFileDialog1FileOk(object sender, CancelEventArgs e)
		{
			File.WriteAllLines(saveFileDialog1.FileName, fastColoredTextBox1.Lines);
		}
		void OpenFileDialog1FileOk(object sender, CancelEventArgs e)
		{
			fastColoredTextBox1.OpenFile(openFileDialog1.FileName);
		}
		void FastColoredTextBox1TextChanged(object sender, TextChangedEventArgs e)
		{
			for(int i = 0; i < fastColoredTextBox1.Lines.Count; i++)
			{
				if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("print "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 6, i);
		    		rng.SetStyle(BlueStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("color "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 6, i);
		    		rng.SetStyle(BlueStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("var "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 4, i);
		    		rng.SetStyle(RedStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("caption "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 8, i);
		    		rng.SetStyle(BlueStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("math "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 5, i);
		    		rng.SetStyle(RedStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("set "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 4, i);
		    		rng.SetStyle(RedStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("if "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 3, i);
		    		rng.SetStyle(RedStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower() == "pause")
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 5, i);
		    		rng.SetStyle(YellowStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower() == "exit")
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 4, i);
		    		rng.SetStyle(YellowStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower() == "clear")
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 5, i);
		    		rng.SetStyle(YellowStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("go "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 3, i);
		    		rng.SetStyle(PurpleStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("[") && fastColoredTextBox1.Lines[i].ToLower().EndsWith("]"))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, fastColoredTextBox1.Lines[i].Length, i);
		    		rng.SetStyle(PurpleStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("start "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 6, i);
		    		rng.SetStyle(PinkStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("wait "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 5, i);
		    		rng.SetStyle(BlueStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("readfile "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 9, i);
		    		rng.SetStyle(PinkStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("writefile "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 10, i);
		    		rng.SetStyle(PinkStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("crdir "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 6, i);
		    		rng.SetStyle(PinkStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("rmdir "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 6, i);
		    		rng.SetStyle(PinkStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("crfile "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 7, i);
		    		rng.SetStyle(PinkStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("rmfile "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 7, i);
		    		rng.SetStyle(PinkStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("movedir "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 8, i);
		    		rng.SetStyle(PinkStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("movefile "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 9, i);
		    		rng.SetStyle(PinkStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("copyfile "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 9, i);
		    		rng.SetStyle(PinkStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("addline "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 8, i);
		    		rng.SetStyle(PinkStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("removechars "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 12, i);
		    		rng.SetStyle(RedStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("substring "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 10, i);
		    		rng.SetStyle(RedStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("kill "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 5, i);
		    		rng.SetStyle(PinkStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("stringlength "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 13, i);
		    		rng.SetStyle(RedStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("lineslength "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 12, i);
		    		rng.SetStyle(PinkStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("exists "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 5, i);
		    		rng.SetStyle(PinkStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower() == "shutdown")
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 8, i);
		    		rng.SetStyle(YellowStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower() == "restart")
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 7, i);
		    		rng.SetStyle(YellowStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower() == "sleep")
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 5, i);
		    		rng.SetStyle(YellowStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("keyseta "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 8, i);
		    		rng.SetStyle(RedStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("keysetb "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 8, i);
		    		rng.SetStyle(RedStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("sizedir "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 8, i);
		    		rng.SetStyle(PinkStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("sizefile "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 9, i);
		    		rng.SetStyle(PinkStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("download "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 9, i);
		    		rng.SetStyle(YellowStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("random "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 7, i);
		    		rng.SetStyle(RedStyle);
				}
				else if(fastColoredTextBox1.Lines[i].ToLower().StartsWith("screenshot "))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, 11, i);
		    		rng.SetStyle(PinkStyle);
				}
				else if(fastColoredTextBox1.Lines[i].StartsWith("//"))
				{
					Range rng = new Range(fastColoredTextBox1, 0, i, fastColoredTextBox1.Lines[i].Length, i);
		    		rng.SetStyle(GreenStyle);
				}
			}
			e.ChangedRange.ClearStyle(astyle);
			
			e.ChangedRange.SetStyle(astyle, "&&&", RegexOptions.Multiline);
			e.ChangedRange.SetStyle(astyle, "$", RegexOptions.Multiline);
		}
	}
}
