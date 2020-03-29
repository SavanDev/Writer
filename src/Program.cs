/*
 * Created by SharpDevelop.
 * User: Dylan
 * Date: 08/03/2020
 * Time: 03:35 p.m.
 */
using System;
using System.Windows.Forms;

namespace Writer
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
	}
}
