using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Writer.Modules
{
    public interface IText
    {
        // Text
        string Content { get; set; }
        string SelectionText { get; set; }

        // File
        string NameFile { get; set; }
        string FileUrl { get; set; }
        string OriginalContent { get; set; }
        bool hasChanges { get; }

        // MIME Support
        Dictionary<string, string> supportedFormats { get; }

        // Clipboard
        void Cut(object sender, EventArgs e);
        void Copy(object sender, EventArgs e);
        void Paste(object sender, EventArgs e);

        // Font
        Font FontText { get; set; }
    }
}
