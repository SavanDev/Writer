/*
 * Creado por SharpDevelop.
 * Usuario: Dylan
 * Fecha: 21/03/2020
 * Hora: 03:35 a.m.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Writer.Handles
{
	/// <summary>
	/// Description of Utils.
	/// </summary>
	public static class Utils
	{
		public static void ToogleFontStyle(FontStyle fStyle, RichTextBox rTextBox, ToolStripButton button)
		{
			rTextBox.SelectionFont = new Font(rTextBox.SelectionFont, rTextBox.SelectionFont.Style ^ fStyle);
			// HACK: No lo detecta por si solo.
			button.Checked = !button.Checked;
		}
		
		public static void VerifyChanges()
		{
			MessageBox.Show("Changes Handle event");
		}
	}
}
