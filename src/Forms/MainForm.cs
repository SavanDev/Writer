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
using ICSharpCode.TextEditor;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Writer.Controls;
using Writer.Forms;
using Writer.Modules;

namespace Writer
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        IText actualEditor = null;

        ColorDialog colorDialog = new ColorDialog()
        {
            SolidColorOnly = true
        };
        ToolNumericBox toolFontSize = new ToolNumericBox();

        public MainForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            toolFontSize.AddToToolStrip(toolStrip1, 2);

            foreach (ToolStripItem item in toolStrip1.Items)
            {
                item.Enabled = false;
            }
        }

        void SalirToolStripMenuItemClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void AbrirToolStripMenuItemClick(object sender, EventArgs e)
        {

        }

        void GuardarToolStripMenuItemClick(object sender, EventArgs e)
        {

        }

        void NuevoToolStripMenuItemClick(object sender, EventArgs e)
        {
            CreateNewFile();
        }

        void BarraDeHerramientasToolStripMenuItemClick(object sender, EventArgs e)
        {
            toolStrip1.Visible = barraDeHerramientasToolStripMenuItem.Checked ? barraDeHerramientasToolStripMenuItem.Checked = false : barraDeHerramientasToolStripMenuItem.Checked = true;
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
            Utils.ToggleFont(FontStyle.Bold, actualEditor, toolBold);
        }

        void ToolCursiveClick(object sender, EventArgs e)
        {
            Utils.ToggleFont(FontStyle.Italic, actualEditor, toolCursive);
        }

        void ToolUnderlineClick(object sender, EventArgs e)
        {
            Utils.ToggleFont(FontStyle.Underline, actualEditor, toolUnderline);
        }

        void ToolFontsSelectedIndexChanged(object sender, EventArgs e)
        {
            Utils.ToggleFont(toolFonts.Text, (float)toolFontSize.Value, actualEditor);
        }

        void ToolTachadoClick(object sender, EventArgs e)
        {
            Utils.ToggleFont(FontStyle.Strikeout, actualEditor, toolTachado);
        }

        void ToolJusLeftClick(object sender, EventArgs e)
        {
            RTFTools.ToggleAligment(HorizontalAlignment.Left, tabs.SelectedTab);
        }

        void ToolJusCenterClick(object sender, EventArgs e)
        {
            RTFTools.ToggleAligment(HorizontalAlignment.Center, tabs.SelectedTab);
        }

        void ToolJusRightClick(object sender, EventArgs e)
        {
            RTFTools.ToggleAligment(HorizontalAlignment.Right, tabs.SelectedTab);
        }

        void ToolColorClick(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                RTFTools.ToggleFontColor(colorDialog.Color, tabs.SelectedTab);
            }
        }

        void ToolBulletClick(object sender, EventArgs e)
        {
            RTFTools.ToogleBullet(tabs.SelectedTab);
        }

        void ToolBackColorClick(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                RTFTools.ToggleBackColor(colorDialog.Color, tabs.SelectedTab);
            }
        }

        void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {

        }
        void GuardarComoToolStripMenuItemClick(object sender, EventArgs e)
        {

        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (actualEditor is RTFTextBox) ((RTFTextBox)actualEditor).TextChanged -= DetectLines;
            if (actualEditor is CodeTextBox) ((CodeTextBox)actualEditor).TextChanged -= DetectLines;

            actualEditor = (IText)tabs.SelectedTab.Controls[0];

            if (actualEditor is RTFTextBox)
            {
                ((RTFTextBox)actualEditor).TextChanged += DetectLines;

                toolJusLeft.Enabled = toolJusCenter.Enabled = toolJusRight.Enabled = true;
                toolBullet.Enabled = toolColor.Enabled = toolBackColor.Enabled = true;
                zoomTool.Visible = true;
            }

            if (actualEditor is CodeTextBox)
            {
                ((CodeTextBox)actualEditor).TextChanged += DetectLines;

                toolJusLeft.Enabled = toolJusCenter.Enabled = toolJusRight.Enabled = false;
                toolBullet.Enabled = toolColor.Enabled = toolBackColor.Enabled = false;
                zoomTool.Visible = false;
            }
        }

        private void CreateNewFile()
        {
            DialogNew dialog = new DialogNew();

            if (dialog.ShowDialog() == DialogResult.OK)
                PrepareRTFTextBox();
            else
                PrepareCodeTextBox();
        }

        private void InitializeEvents(IText initial)
        {
            actualEditor = initial;

            foreach (FontFamily font in FontFamily.Families)
            {
                toolFonts.Items.Add(font.Name);
            }

            // Mostrar datos iniciales
            toolFontSize.Value = (decimal)actualEditor.FontText.Size;
            toolFonts.Text = actualEditor.FontText.Name;

            toolFontSize.ValueChanged += ToolFontsSelectedIndexChanged;
            toolFonts.SelectedIndexChanged += ToolFontsSelectedIndexChanged;

            toolFonts.Enabled = toolFontSize.Enabled = true;
            toolBold.Enabled = toolCursive.Enabled = toolUnderline.Enabled = toolTachado.Enabled = true;

            // Clipboard system
            cortarEdicion.Click += actualEditor.Cut;
            cortarRTF.Click += actualEditor.Cut;
            copiarEdicion.Click += actualEditor.Copy;
            copiarRTF.Click += actualEditor.Copy;
            pegarEdicion.Click += actualEditor.Paste;
            pegarRTF.Click += actualEditor.Paste;

            // Zoom system
            zoom50.Click += (sender, e) => RTFTools.ToggleZoomFactor(0.5F, tabs.SelectedTab, zoomTool);
            zoom100.Click += (sender, e) => RTFTools.ToggleZoomFactor(1F, tabs.SelectedTab, zoomTool);
            zoom200.Click += (sender, e) => RTFTools.ToggleZoomFactor(2F, tabs.SelectedTab, zoomTool);
            zoom400.Click += (sender, e) => RTFTools.ToggleZoomFactor(4F, tabs.SelectedTab, zoomTool);
        }

        private void PrepareCodeTextBox()
        {
            TabPage tabPage = new TabPage();

            var editor = new CodeTextBox
            {
                Dock = DockStyle.Fill,
                NameFile = $"new {tabs.TabPages.Count}",
                OriginalContent = ""
            };

            var propertyGrid = new PropertyGrid
            {
                SelectedObject = editor,
                Dock = DockStyle.Right,
                Width = 200
            };

            tabPage.Controls.Add(editor);
            tabPage.Controls.Add(propertyGrid);
            tabPage.Text = editor.NameFile;

            tabs.TabPages.Add(tabPage);
            tabs.SelectedTab = tabPage;

            if (actualEditor == null)
                InitializeEvents(editor);
            else
                actualEditor = editor;
        }

        private void PrepareRTFTextBox()
        {
            TabPage tabPage = new TabPage();

            var editor = new RTFTextBox
            {
                Dock = DockStyle.Fill,
                NameFile = $"new {tabs.TabPages.Count}",
                OriginalContent = ""
            };

            tabPage.Controls.Add(editor);
            tabPage.Text = editor.NameFile;

            tabs.TabPages.Add(tabPage);
            tabs.SelectedTab = tabPage;

            if (actualEditor == null)
                InitializeEvents(editor);
            else
                actualEditor = editor;
        }

        void DetectLines(object sender, EventArgs e)
        {
            tStripLblCount.Text = Utils.GetLines(actualEditor);
            DetectStyle(actualEditor.FontText);
        }

        void DetectStyle(Font actualStyle)
        {
            if (actualStyle != null)
            {
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
