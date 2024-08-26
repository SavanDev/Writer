using ICSharpCode.TextEditor.Actions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Writer.Modules;

namespace Writer.Controls
{
    public class RTFTextBox : RichTextBox, IText
    {
        public string Content
        {
            get => this.Rtf;
            set => this.Rtf = value;
        }

        public string PlainContent
        {
            get => this.Text;
        }

        public string SelectionText
        {
            get => this.SelectedRtf;
            set => this.SelectedRtf = value;
        }

        public string NameFile { get; set; }
        public string FileUrl { get; set; }
        public string OriginalContent { get; set; }
        public bool hasChanges
        {
            get => !OriginalContent.Equals((Path.GetExtension(FileUrl) == ".txt" ? PlainContent : Content));
        }

        public Dictionary<string, string> supportedFormats
        {
            get
            {
                return new Dictionary<string, string>()
                {
                    {
                        "Archivo de texto enriquecido", "*.rtf"
                    },
                    {
                        "Archivo de texto", "*.txt"
                    }
                };
            }
        }

        public void Cut(object sender, EventArgs e)
        {
            Clipboard.SetText(SelectionText);
            SelectionText = null;
        }

        public void Copy(object sender, EventArgs e)
        {
            Clipboard.SetText(SelectionText);
        }

        public void Paste(object sender, EventArgs e)
        {
            SelectionText = Clipboard.GetText();
        }

        public Font FontText
        {
            get => this.SelectionFont;
            set => this.SelectionFont = value;
        }
    }
}
