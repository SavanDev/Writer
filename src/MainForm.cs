/*
 * Created by SharpDevelop.
 * User: Dylan
 * Date: 08/03/2020
 * Time: 03:35 p.m.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Writer.Controls;
using Writer.Handles;

namespace Writer
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private string formTitle = "SD Writer";
		OpenFileDialog openDialog = new OpenFileDialog ()
		{
			Title = "Seleccione un archivo...",
			Filter = TextHandle.SupportedFormats(TextHandle.IOType.Load)
		};
		SaveFileDialog saveDialog = new SaveFileDialog()
		{
			Title = "Seleccione una ruta de guardado...",
			Filter = TextHandle.SupportedFormats(TextHandle.IOType.Save)
		};
		ColorDialog colorDialog = new ColorDialog ()
		{
			SolidColorOnly = true
		};
		private ToolNumericBox toolFontSize = new ToolNumericBox();
		Version versionInfo = Assembly.GetExecutingAssembly().GetName().Version;

		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();

#if DEBUG
			formTitle = String.Format("SD Writer [Build: {0}]", versionInfo.Build);
#endif

			this.Text = String.Format("{0} - {1}", "Sín título", formTitle);
			
			tStripLblCount.Text = "Línea: 1 Columna: 1";

			foreach (FontFamily font in System.Drawing.FontFamily.Families)
			{
				toolFonts.Items.Add(font.Name);
			}
			
			toolFontSize.AddToToolStrip(toolFont);
			
			// Mostrar datos iniciales
			toolFontSize.Value = (decimal)rTextBox.Font.Size;
			toolFonts.Text = rTextBox.Font.Name;
			
			toolFontSize.ValueChanged += ToolFontsSelectedIndexChanged;

			// Clipboard System
			cortarEdicion.Click += (object sender, EventArgs e) => TextClipboard.Cut(rTextBox);
			cortarRTF.Click += (object sender, EventArgs e) => TextClipboard.Cut(rTextBox);
			copiarEdicion.Click += (object sender, EventArgs e) => TextClipboard.Copy(rTextBox);
			copiarRTF.Click += (object sender, EventArgs e) => TextClipboard.Copy(rTextBox);
			pegarEdicion.Click += (object sender, EventArgs e) => TextClipboard.Paste(rTextBox);
			pegarRTF.Click += (object sender, EventArgs e) => TextClipboard.Paste(rTextBox);
		}
		
		void SalirToolStripMenuItemClick(object sender, EventArgs e)
		{
			Application.Exit();
		}
		
		void AbrirToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (openDialog.ShowDialog() == DialogResult.OK) {
				TextHandle tHandle = new TextHandle(openDialog.FileName);
#if DEBUG
				MessageBox.Show(openDialog.FileName);
#endif
				tHandle.LoadToRichTextBox(rTextBox);
			}
		}
		
		void GuardarToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (saveDialog.ShowDialog() == DialogResult.OK) {
				TextHandle tHandle = new TextHandle();
				tHandle.SetTextFromRichTextBox(rTextBox);
				if (tHandle.SaveTextToFile(saveDialog.FileName)) {
					MessageBox.Show("Guardado correctamente");
				}
			}
		}
		
		void NuevoToolStripMenuItemClick(object sender, EventArgs e)
		{
			// TODO: Agregar un controlador para cuando haya cambios sin guardar.
			Utils.VerifyChanges();
			rTextBox.Clear();
		}
		
		void RTextBoxSelectionChanged(object sender, EventArgs e)
		{
			// Obtener la línea.
			int index = rTextBox.SelectionStart;
			int line = (rTextBox.GetLineFromCharIndex(index)) + 1;
			
			// Obtener la columna.
			int firstChar = rTextBox.GetFirstCharIndexFromLine(line);
			int column = (index - firstChar) + 1;
			
			tStripLblCount.Text = String.Format("Línea: {0} Columna: {1}", line, column);
			
			// Detectar estilos
			DetectStyle(rTextBox.SelectionFont);
		}
		
		void BarraDeHerramientasToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (barraDeHerramientasToolStripMenuItem.Checked)
				toolStyles.Visible = barraDeHerramientasToolStripMenuItem.Checked = false;
			else
				toolStyles.Visible = barraDeHerramientasToolStripMenuItem.Checked = true;
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
			AboutBox about = new AboutBox();
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
			
			if (rTextBox.SelectionFont != null)
				style = rTextBox.SelectionFont.Style;
			else
				style = rTextBox.Font.Style;
			
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
			
		}
		
		void ToolColorClick(object sender, EventArgs e)
		{
			if(colorDialog.ShowDialog() == DialogResult.OK)
			{
				rTextBox.SelectionColor = colorDialog.Color;
			}
		}
		
		void ToolBulletClick(object sender, EventArgs e)
		{
			rTextBox.SelectionBullet = !rTextBox.SelectionBullet;
		}
		
		void ToolBackColorClick(object sender, EventArgs e)
		{
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				rTextBox.SelectionBackColor = colorDialog.Color;
			}
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			// TODO: Agregar un controlador para cuando haya cambios sin guardar.
			Utils.VerifyChanges();
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
	}
}
