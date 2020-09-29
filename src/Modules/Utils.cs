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
using System.Reflection;
using System.Windows.Forms;
using Writer.Controls;

namespace Writer.Modules
{
    /// <summary>
    /// Description of Utils.
    /// </summary>
    public static class Utils
    {
        public static int GetBuildVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.Build;
        }
        public static void ToggleFont(FontStyle fStyle, IText textBox, ToolStripButton button)
        {
            textBox.FontText = new Font(textBox.FontText, textBox.FontText.Style ^ fStyle);
            button.Checked = !button.Checked;
        }

        public static void ToggleFont(string fontFamily, float fontSize, IText textBox)
        {
            textBox.FontText = new Font(fontFamily, fontSize, textBox.FontText.Style);
        }

        public static string GetLines(IText textBox)
        {
            int line = 0, column = 0;

            if (textBox is RTFTextBox)
            {
                // Obtener la línea.
                int index = ((RTFTextBox)textBox).SelectionStart;
                line = (((RTFTextBox)textBox).GetLineFromCharIndex(index));

                // Obtener la columna.
                int firstChar = ((RTFTextBox)textBox).GetFirstCharIndexFromLine(line);
                column = (index - firstChar);
            }

            if (textBox is CodeTextBox)
            {
                // Obtener la línea.
                line = ((CodeTextBox)textBox).ActiveTextAreaControl.Caret.Line;

                // Obtener la columna.
                column = ((CodeTextBox)textBox).ActiveTextAreaControl.Caret.Column;
            }

            return $"Línea: {++line} Columna: {++column}";
        }
    }

    public static class RTFTools
    {
        public static void ToogleBullet(TabPage tabPage)
        {
            var rTextBox = tabPage.Controls[0];
            if (rTextBox is RTFTextBox)
                ((RTFTextBox)rTextBox).SelectionBullet = !((RTFTextBox)rTextBox).SelectionBullet;
        }
        public static void ToggleFontColor(Color color, TabPage tabPage)
        {
            var rTextBox = tabPage.Controls[0];
            if (rTextBox is RTFTextBox)
                ((RTFTextBox)rTextBox).SelectionColor = color;
        }

        public static void ToggleBackColor(Color color, TabPage tabPage)
        {
            var rTextBox = tabPage.Controls[0];
            if (rTextBox is RTFTextBox)
                ((RTFTextBox)rTextBox).SelectionBackColor = color;
        }

        public static void ToggleAligment(HorizontalAlignment alignment, TabPage tabPage)
        {
            var rTextBox = tabPage.Controls[0];
            if (rTextBox is RTFTextBox)
                ((RTFTextBox)rTextBox).SelectionAlignment = alignment;
        }

        public static void ToggleZoomFactor(float zoom, TabPage tabPage, ToolStripDropDownButton button)
        {
            var rTextBox = tabPage.Controls[0];
            if (rTextBox is RTFTextBox)
            {
                ((RTFTextBox)rTextBox).ZoomFactor = zoom;
                button.Text = $"{zoom * 100}%";
            }
        }
    }
}
