using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Writer.Handles
{
    public static class TextClipboard
    {
        public static void Cut(RichTextBox rtf)
        {
            Clipboard.SetText(rtf.SelectedRtf);
            rtf.SelectedRtf = "";
        }

        public static void Copy(RichTextBox rtf)
        {
            Clipboard.SetText(rtf.SelectedRtf);
        }

        public static void Paste(RichTextBox rtf)
        {
            rtf.SelectedRtf = Clipboard.GetText();
        }
    }
}
