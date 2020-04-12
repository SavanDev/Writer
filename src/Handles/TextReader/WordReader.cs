/*
 * Creado por SharpDevelop.
 * Usuario: Dylan
 * Fecha: 18/03/2020
 * Hora: 05:19 p.m.
 */
using System;
using System.Windows.Forms;
using Code7248.word_reader;

namespace Writer.Handles.TextReader
{
	/// <summary>
	/// Description of WordReader.
	/// </summary>
	public class WordReader
	{
		private TextExtractor reader;
		
		public WordReader(string filename)
		{
			reader = new TextExtractor(filename);
		}
		
		public string GetText()
		{
			return reader.ExtractText();
		}
	}
}
