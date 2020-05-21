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
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Writer.Modules
{
	/// <summary>
	/// Clase principal para el control de texto.
	/// </summary>
	public static class TextHandle
	{
		static string fileText;
		static string fileName;
		static string mimeType;
		
		static string fileUrl;
		
		static RichTextBox rTextBox;
		
		enum IO
		{
			Load,
			Save
		}
		
		static readonly Dictionary<string, string> mimeTypes = new Dictionary<string, string> { {
				"Archivos de texto enriquecido",
				"*.rtf"
			}, {
				"Archivos de texto",
				"*.txt"
			}
		};
		
		static OpenFileDialog openDialog = new OpenFileDialog() {
			Title = "Seleccione un archivo...",
			Filter = TextHandle.SupportedFormats(IO.Load, true)
		};
		
		static SaveFileDialog saveDialog = new SaveFileDialog() {
			Title = "Seleccione una ruta de guardado...",
			Filter = TextHandle.SupportedFormats(IO.Save)
		};
		
		public static void InitializeComponent(RichTextBox rBox)
		{
			rTextBox = rBox;
			Create();
		}
		
		public static void Create()
		{
			fileName = "Sín título";
			fileText = null;
			VerifyChanges();
		}
		
		public static bool LoadFile()
		{
			if (openDialog.ShowDialog() == DialogResult.OK) {
				var fName = openDialog.FileName;
				
				mimeType = Path.GetExtension(fName);
				
				#if DEBUG
				Console.WriteLine(string.Format("DEBUG: Trying to load -> {0}", openDialog.FileName));
				Console.WriteLine(string.Format("DEBUG: File Extension -> {0}", mimeType));
				#endif
				
				try {
					fileName = Path.GetFileNameWithoutExtension(fName);
					fileText = File.ReadAllText(fName);
					fileUrl = fName;
					return true;
				} catch (Exception ex) {
					MessageBox.Show(string.Format("Se ha producido un error.\n{0}", ex.Message));
					return false;
				}
			}
			return false;
		}
		
		public static bool LoadToRichTextBox()
		{
			if (fileText != null) {
				if (mimeType == ".rtf")
					rTextBox.Rtf = fileText;
				else
					rTextBox.Text = fileText;
				return true;
			}
			
			return false;
		}
		
		public static bool SaveTextToFile(bool forceDialog = false)
		{
			if (fileText != null) {
				if ((fileUrl == null || forceDialog) && saveDialog.ShowDialog() == DialogResult.OK)
					fileUrl = fileName;
				
				if (fileUrl != null) {
					var name = Path.GetFileNameWithoutExtension(fileUrl);
					var ext = Path.GetExtension(fileUrl);
					
					SetTextFromRichTextBox(name, ext);
					File.WriteAllText(fileUrl, fileText);
					VerifyChanges();
					return true;
				}
			}
			
			return false;
		}
		
		public static void SetTextFromRichTextBox(string name, string ext)
		{
			fileName = name;
			fileText = ext == ".rtf" ? rTextBox.Rtf : rTextBox.Text;
		}
		
		/// <summary>
		/// Devuelve los tipos de archivo soportados.
		/// </summary>
		/// <param name="state">Tipos soportados para leer o guardar.</param>
		/// <param name="allExcept">Agregar la opción "Todos los archivos".</param>
		/// <returns></returns>
		static string SupportedFormats(IO state, bool allExcept = false)
		{
			if (state == IO.Load) {
				string allTypes = string.Join(";", mimeTypes.Values);
				string mime = string.Format("Todos los tipos de archivos soportados ({0})|{0}", allTypes);
				
				foreach (var element in mimeTypes) {
					mime += string.Format("|{0} ({1})|{1}", element.Key, element.Value);
				}
				
				if (allExcept)
					mime += "|Todos los archivos (*.*)|*.*";
				
				#if DEBUG
				Console.WriteLine(string.Format("DEBUG: Available formats -> [{0}]", mime));
				#endif
				
				return mime;
			}
			
			return "Archivos de texto enriquecido (*.rtf)|*.rtf|Archivos de texto (*.txt)|*.txt";
		}
		
		public static void VerifyChanges(bool dialogDetect = false)
		{
			var frm = Form.ActiveForm;
			if (frm != null)
				frm.Text = string.Format("{0}{1} - {2} [Build: {3}]", fileText != rTextBox.Text ? "*" : null, fileName, Application.ProductName, Utils.GetBuildVersion());
			
			if ((dialogDetect && fileText != rTextBox.Text) && MessageBox.Show("¿Desea guardar los cambios?", "Hay cambios sin guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
				SaveTextToFile();
		}
	}
}
