/*
 * Creado por SharpDevelop.
 * Usuario: Dylan
 * Fecha: 21/03/2020
 * Hora: 03:17 a.m.
 */
using System;
using System.Windows.Forms;

namespace Writer.Modules.Controls
{
	/// <summary>
	/// Description of ToolNumericBox.
	/// </summary>
	public class ToolNumericBox : NumericUpDown
	{
		private ToolStripControlHost host;
		
		public ToolNumericBox()
		{
			host = new ToolStripControlHost(this);
		}
		
		public void AddToToolStrip(ToolStrip tStrip)
		{
			tStrip.Items.Add(host);
		}
	}
}
