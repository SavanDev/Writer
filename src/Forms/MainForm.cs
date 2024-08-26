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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Writer.Controls;
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

        private void AbrirToolStripMenuItemClick(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Texto enriquecido (*.rtf)|*.rtf|Todos los archivos (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileContent = File.ReadAllText(openFileDialog.FileName);
                    var tabPage = new TabPage(Path.GetFileName(openFileDialog.FileName));

                    var extension = Path.GetExtension(openFileDialog.FileName);

                    if (extension == ".rtf")
                    {
                        var editor = new RTFTextBox // Puedes cambiar a CodeTextBox si es un archivo de código
                        {
                            Dock = DockStyle.Fill,
                            Text = fileContent,
                            NameFile = Path.GetFileName(openFileDialog.FileName),
                            FileUrl = openFileDialog.FileName,
                            OriginalContent = fileContent
                        };
                        tabPage.Controls.Add(editor);
                        InitializeEvents(editor);
                    }
                    else
                    {
                        var editor = new CodeTextBox
                        {
                            Dock = DockStyle.Fill,
                            Text = fileContent,
                            NameFile = Path.GetFileName(openFileDialog.FileName),
                            FileUrl = openFileDialog.FileName,
                            OriginalContent = fileContent
                        };

                        /*var propertyGrid = new PropertyGrid
                        {
                            SelectedObject = editor,
                            Dock = DockStyle.Right,
                            Width = 200
                        };*/

                        tabPage.Controls.Add(editor);
                        //tabPage.Controls.Add(propertyGrid);
                        InitializeEvents(editor);
                    }
                    
                    tabs.TabPages.Add(tabPage);
                    tabs.SelectedTab = tabPage;
                }
            }
        }


        private void GuardarToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (actualEditor == null) return;

            if (string.IsNullOrEmpty(actualEditor.FileUrl))
            {
                GuardarComoToolStripMenuItemClick(sender, e); // Invoca Guardar Como si no tiene nombre de archivo
            }
            else
            {
                GuardarArchivo(actualEditor.FileUrl);
            }
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

        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (TabPage tab in tabs.TabPages)
            {
                    var editor = tab.Controls[0] as IText;
                    if (editor != null && editor.hasChanges)
                    {
                        Debug.WriteLine(editor.hasChanges);
                        var result = MessageBox.Show($"El archivo '{tab.Text}' tiene cambios no guardados. ¿Desea guardarlos antes de salir?",
                            "Cambios no guardados", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            GuardarArchivo(editor.FileUrl);
                        }
                        else if (result == DialogResult.Cancel)
                        {
                            e.Cancel = true;
                            return;
                        }
                    
                    }
            }
        }

        private void GuardarComoToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (actualEditor == null) return;

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GuardarArchivo(saveFileDialog.FileName);
                }
            }
        }


        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabs.TabCount == 0) return; // Verifica si hay pestañas antes de continuar

            // Desvincula eventos anteriores
            if (actualEditor is RTFTextBox) ((RTFTextBox)actualEditor).TextChanged -= DetectLines;
            if (actualEditor is CodeTextBox) ((CodeTextBox)actualEditor).TextChanged -= DetectLines;

            // Verifica si la pestaña seleccionada es válida y tiene controles
            if (tabs.SelectedTab != null && tabs.SelectedTab.Controls.Count > 0)
            {
                actualEditor = (IText)tabs.SelectedTab.Controls[0];

                if (actualEditor is RTFTextBox)
                {
                    ((RTFTextBox)actualEditor).TextChanged += DetectLines;

                    toolJusLeft.Enabled = toolJusCenter.Enabled = toolJusRight.Enabled = true;
                    toolBullet.Enabled = toolColor.Enabled = toolBackColor.Enabled = true;
                    zoomTool.Visible = true;
                }
                else if (actualEditor is CodeTextBox)
                {
                    ((CodeTextBox)actualEditor).TextChanged += DetectLines;

                    toolJusLeft.Enabled = toolJusCenter.Enabled = toolJusRight.Enabled = false;
                    toolBullet.Enabled = toolColor.Enabled = toolBackColor.Enabled = false;
                    zoomTool.Visible = false;
                }
            }
            else
            {
                actualEditor = null;
                // Deshabilitar herramientas si no hay pestaña seleccionada
                toolJusLeft.Enabled = toolJusCenter.Enabled = toolJusRight.Enabled = false;
                toolBullet.Enabled = toolColor.Enabled = toolBackColor.Enabled = false;
                zoomTool.Visible = false;
            }
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

            /*var propertyGrid = new PropertyGrid
            {
                SelectedObject = editor,
                Dock = DockStyle.Right,
                Width = 200
            };*/

            tabPage.Controls.Add(editor);
            //tabPage.Controls.Add(propertyGrid);
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

        private void textoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrepareRTFTextBox();
        }

        private void códigoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrepareCodeTextBox();
        }

        private void tabs_DrawItem(object sender, DrawItemEventArgs e)
        {
            //This code will render a "x" mark at the end of the Tab caption.
            e.Graphics.DrawString("X", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);
            e.Graphics.DrawString(this.tabs.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }

        private void tabs_MouseDown(object sender, MouseEventArgs e)
        {
            Rectangle r = tabs.GetTabRect(this.tabs.SelectedIndex);
            Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 9, 7);
            if (closeButton.Contains(e.Location))
            {
                if (actualEditor.hasChanges)
                {
                    Debug.WriteLine(actualEditor.hasChanges);
                    var result = MessageBox.Show($"El archivo '{actualEditor.NameFile}' tiene cambios no guardados. ¿Desea guardarlos antes de salir?",
                        "Cambios no guardados", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        GuardarArchivo(actualEditor.FileUrl);
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                this.tabs.TabPages.Remove(this.tabs.SelectedTab);
            }
        }

        private void GuardarArchivo(string fileName)
        {
            if (actualEditor == null) return;

            try
            {
                File.WriteAllText(fileName, fileName.Contains(".txt") ? actualEditor.PlainContent : actualEditor.Content);
                actualEditor.NameFile = Path.GetFileName(fileName); // Actualiza el nombre del archivo
                actualEditor.FileUrl = fileName;
                actualEditor.OriginalContent = actualEditor.Content; // Actualiza el contenido original después de guardar
                MessageBox.Show("Archivo guardado exitosamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
