/*
 * Creado por SharpDevelop.
 * Usuario: Dylan
 * Fecha: 08/03/2020
 * Hora: 08:48 p.m.
 */
using System;
using System.IO;
using System.Windows.Forms;
using Writer.Modules.TextReader;

namespace Writer.Modules
{
	/// <summary>
	/// Clase principal para el control de texto.
	/// </summary>
	public class TextHandle
	{	
		private bool isLoaded;
		private string fileText;
		public enum IOType
		{
			Load,
			Save
		}
		
		public TextHandle()
		{
			this.isLoaded = false;
		}
		
		public TextHandle(string fileName)
		{
			string ext = Path.GetExtension(fileName);
			switch (ext)
			{
				case ".docx":
					WordReader reader = new WordReader(fileName);
					this.fileText = reader.GetText();
					break;
					
				default:
					this.fileText = File.ReadAllText(fileName);
					break;
			}
			this.isLoaded = true;
		}
		
		public bool LoadToRichTextBox(RichTextBox rTextBox)
		{
			if (this.isLoaded) {
				rTextBox.Rtf = this.fileText;
				return true;
			} else {
				return false;
			}
		}
		
		public bool SaveTextToFile(string fileName)
		{
			if (this.isLoaded) {
				File.WriteAllText(fileName, this.fileText);
				return true;
			} else {
				return false;
			}
		}
		
		public void SetTextFromRichTextBox(RichTextBox rTextBox)
		{
			this.fileText = rTextBox.Rtf;
			this.isLoaded = true;
		}
		
		/// <summary>
		/// Devuelve los tipos de archivo soportados.
		/// </summary>
		/// <param name="loadSave">Tipos soportados para leer o guardar.</param>
		/// <returns></returns>
		public static string SupportedFormats(IOType loadSave)
		{
			switch (loadSave) {
				case IOType.Load:
					return "Todos los tipos de archivos soportados (*.docx,*.rtf,*.txt)|*.docx;*.txt;*.rtf|Archivos Word (*.docx)|*.docx|Archivos de texto enriquecido (*.rtf)|*.rtf|Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
				case IOType.Save:
					return "Archivos de texto enriquecido (*.rtf)|*.rtf|Archivos de texto (txt)|*.txt";
				default:
					return null;
			}
		}
	}
}
