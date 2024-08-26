using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.TextEditor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Writer.Modules;

namespace Writer.Controls
{
    public class CodeTextBox : TextEditorControl, IText
    {
        public string Content
        {
            get => this.Text;
            set => this.Text = value;
        }

        public string PlainContent
        {
            get => this.Text;
        }

        public string SelectionText
        {
            get => this.ActiveTextAreaControl.SelectionManager.SelectedText;
            set => Console.WriteLine("TODO: Make a backend for this");
        }

        public string NameFile { get; set; }
        public string FileUrl { get; set; }
        public string OriginalContent { get; set; }
        public bool hasChanges
        {
            get => OriginalContent != Content;
        }

        public Dictionary<string, string> supportedFormats
        {
            get
            {
                return new Dictionary<string, string>()
                {
                    {
                        "Archivo C#", "*.cs"
                    },
                    {
                        "Archivo VB", "*.vb"
                    }
                };
            }
        }

        public void Cut(object sender, EventArgs e)
        {
            this.ActiveTextAreaControl.TextArea.ClipboardHandler.Cut(sender, e);
        }

        public void Copy(object sender, EventArgs e)
        {
            this.ActiveTextAreaControl.TextArea.ClipboardHandler.Copy(sender, e);
        }

        public void Paste(object sender, EventArgs e)
        {
            this.ActiveTextAreaControl.TextArea.ClipboardHandler.Paste(sender, e);
        }

        public Font FontText
        {
            get => this.Font;
            set => this.Font = value;
        }
    }
}
