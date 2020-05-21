/*
 * MIT License
 * 
 * Copyright (c) 2020 SavanDev
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Writer.Controls;
using Writer.Modules;

namespace Writer
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		ColorDialog colorDialog = new ColorDialog() {
			SolidColorOnly = true
		};
		ToolNumericBox toolFontSize = new ToolNumericBox();

		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			TextHandle.InitializeComponent(rTextBox);

			foreach (FontFamily font in FontFamily.Families) {
				toolFonts.Items.Add(font.Name);
			}
			
			toolFontSize.AddToToolStrip(toolFont);
			
			// Mostrar datos iniciales
			toolFontSize.Value = (decimal)rTextBox.Font.Size;
			toolFonts.Text = rTextBox.Font.Name;
			
			toolFontSize.ValueChanged += ToolFontsSelectedIndexChanged;

			// Clipboard system
			cortarEdicion.Click += (sender, e) => TextClipboard.Cut(rTextBox);
			cortarRTF.Click += (sender, e) => TextClipboard.Cut(rTextBox);
			copiarEdicion.Click += (sender, e) => TextClipboard.Copy(rTextBox);
			copiarRTF.Click += (sender, e) => TextClipboard.Copy(rTextBox);
			pegarEdicion.Click += (sender, e) => TextClipboard.Paste(rTextBox);
			pegarRTF.Click += (sender, e) => TextClipboard.Paste(rTextBox);
			
			#if DEBUG
			Console.WriteLine("DEBUG: Zoom Factor -> " + rTextBox.ZoomFactor);
			#endif
			
			// Zoom system
			zoom50.Click += (sender, e) => Utils.ToogleZoomFactor(0.5F, "50%", rTextBox, zoomTool);
			zoom100.Click += (sender, e) => Utils.ToogleZoomFactor(1F, "100%", rTextBox, zoomTool);
			zoom200.Click += (sender, e) => Utils.ToogleZoomFactor(2F, "200%", rTextBox, zoomTool);
			zoom400.Click += (sender, e) => Utils.ToogleZoomFactor(4F, "400%", rTextBox, zoomTool);
		}
		
		void SalirToolStripMenuItemClick(object sender, EventArgs e)
		{
			Application.Exit();
		}
		
		void AbrirToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (TextHandle.LoadFile())
				TextHandle.LoadToRichTextBox();
		}
		
		void GuardarToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (TextHandle.SaveTextToFile())
				MessageBox.Show("Guardado correctamente");
		}
		
		void NuevoToolStripMenuItemClick(object sender, EventArgs e)
		{
			TextHandle.VerifyChanges(true);
			rTextBox.Clear();
		}
		
		void RTextBoxSelectionChanged(object sender, EventArgs e)
		{
			// Obtener la línea.
			int index = rTextBox.SelectionStart;
			int line = (rTextBox.GetLineFromCharIndex(index));
			
			// Obtener la columna.
			int firstChar = rTextBox.GetFirstCharIndexFromLine(line);
			int column = (index - firstChar);
			
			tStripLblCount.Text = String.Format("Línea: {0} Columna: {1}", ++line, ++column);
			
			// Detectar estilos
			DetectStyle(rTextBox.SelectionFont);
		}
		
		void BarraDeHerramientasToolStripMenuItemClick(object sender, EventArgs e)
		{
			toolStripContainer1.TopToolStripPanelVisible = barraDeHerramientasToolStripMenuItem.Checked ? barraDeHerramientasToolStripMenuItem.Checked = false : barraDeHerramientasToolStripMenuItem.Checked = true;
		}
		
		void BarraDeEstadoToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (barraDeEstadoToolStripMenuItem.Checked)
				barraDeEstadoToolStripMenuItem.Checked = statusBar.Visible = false;
			else
				barraDeEstadoToolStripMenuItem.Checked = statusBar.Visible = true;
		}
		
		void AcerdaDeToolStripMenuItemClick(object sender, EventArgs e)
		{
			var about = new AboutBox();
			about.ShowDialog();
		}
		
		void ToolBoldClick(object sender, EventArgs e)
		{
			Utils.ToogleFontStyle(FontStyle.Bold, rTextBox, toolBold);
		}
		
		void ToolCursiveClick(object sender, EventArgs e)
		{
			Utils.ToogleFontStyle(FontStyle.Italic, rTextBox, toolCursive);
		}
		
		void ToolUnderlineClick(object sender, EventArgs e)
		{
			Utils.ToogleFontStyle(FontStyle.Underline, rTextBox, toolUnderline);
		}
		
		void ToolFontsSelectedIndexChanged(object sender, EventArgs e)
		{
			FontStyle style;
			
			style = rTextBox.SelectionFont != null ? rTextBox.SelectionFont.Style : rTextBox.Font.Style;
			rTextBox.SelectionFont = new Font(toolFonts.Text, (float)toolFontSize.Value, style);
		}
		
		void ToolTachadoClick(object sender, EventArgs e)
		{
			Utils.ToogleFontStyle(FontStyle.Strikeout, rTextBox, toolTachado);
		}
		
		void ToolJusLeftClick(object sender, EventArgs e)
		{
			rTextBox.SelectionAlignment = HorizontalAlignment.Left;
		}
		
		void ToolJusCenterClick(object sender, EventArgs e)
		{
			rTextBox.SelectionAlignment = HorizontalAlignment.Center;
		}
		
		void ToolJusRightClick(object sender, EventArgs e)
		{
			rTextBox.SelectionAlignment = HorizontalAlignment.Right;
		}
		
		void ToolJusFillClick(object sender, EventArgs e)
		{
			// TODO: Justify Text
		}
		
		void ToolColorClick(object sender, EventArgs e)
		{
			if (colorDialog.ShowDialog() == DialogResult.OK) {
				rTextBox.SelectionColor = colorDialog.Color;
			}
		}
		
		void ToolBulletClick(object sender, EventArgs e)
		{
			rTextBox.SelectionBullet = !rTextBox.SelectionBullet;
		}
		
		void ToolBackColorClick(object sender, EventArgs e)
		{
			if (colorDialog.ShowDialog() == DialogResult.OK) {
				rTextBox.SelectionBackColor = colorDialog.Color;
			}
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			TextHandle.VerifyChanges(true);
		}
		
		void DetectStyle(Font actualStyle)
		{
			if (actualStyle != null) {
				toolFonts.Text = actualStyle.Name;
				toolFontSize.Value = (decimal)actualStyle.Size;
				toolBold.Checked = actualStyle.Bold ? true : false;
				toolCursive.Checked = actualStyle.Italic ? true : false;
				toolUnderline.Checked = actualStyle.Underline ? true : false;
				toolTachado.Checked = actualStyle.Strikeout ? true : false;
			}
		}
		
		void RTextBoxTextChanged(object sender, EventArgs e)
		{
			TextHandle.VerifyChanges();
		}
		void GuardarComoToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (TextHandle.SaveTextToFile(true))
				MessageBox.Show("Guardado correctamente");
		}
	}
}
