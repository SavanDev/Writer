/*
 * Created by SharpDevelop.
 * User: Dylan
 * Date: 08/03/2020
 * Time: 03:35 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Writer
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ediciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cortarEdicion = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarEdicion = new System.Windows.Forms.ToolStripMenuItem();
            this.pegarEdicion = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barraDeHerramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barraDeEstadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStyles = new System.Windows.Forms.ToolStrip();
            this.toolBold = new System.Windows.Forms.ToolStripButton();
            this.toolCursive = new System.Windows.Forms.ToolStripButton();
            this.toolUnderline = new System.Windows.Forms.ToolStripButton();
            this.toolTachado = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolJusLeft = new System.Windows.Forms.ToolStripButton();
            this.toolJusCenter = new System.Windows.Forms.ToolStripButton();
            this.toolJusRight = new System.Windows.Forms.ToolStripButton();
            this.toolJusFill = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBullet = new System.Windows.Forms.ToolStripButton();
            this.toolColor = new System.Windows.Forms.ToolStripButton();
            this.toolBackColor = new System.Windows.Forms.ToolStripButton();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.tStripLblCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.rTextBox = new System.Windows.Forms.RichTextBox();
            this.conRichText = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cortarRTF = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarRTF = new System.Windows.Forms.ToolStripMenuItem();
            this.pegarRTF = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolFont = new System.Windows.Forms.ToolStrip();
            this.toolFonts = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.toolStyles.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.conRichText.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolFont.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.ediciónToolStripMenuItem,
            this.verToolStripMenuItem,
            this.opcionesToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(546, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem,
            this.toolStripSeparator1,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Image = global::Writer.media.document_empty;
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.NuevoToolStripMenuItemClick);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Image = global::Writer.media.file_manager;
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.AbrirToolStripMenuItemClick);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Image = global::Writer.media.diskette;
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.GuardarToolStripMenuItemClick);
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Enabled = false;
            this.guardarComoToolStripMenuItem.Image = global::Writer.media.file_save_as;
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.guardarComoToolStripMenuItem.Text = "Guardar como...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.SalirToolStripMenuItemClick);
            // 
            // ediciónToolStripMenuItem
            // 
            this.ediciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cortarEdicion,
            this.copiarEdicion,
            this.pegarEdicion});
            this.ediciónToolStripMenuItem.Name = "ediciónToolStripMenuItem";
            this.ediciónToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.ediciónToolStripMenuItem.Text = "Edición";
            // 
            // cortarEdicion
            // 
            this.cortarEdicion.Image = global::Writer.media.cut;
            this.cortarEdicion.Name = "cortarEdicion";
            this.cortarEdicion.Size = new System.Drawing.Size(180, 22);
            this.cortarEdicion.Text = "Cortar";
            // 
            // copiarEdicion
            // 
            this.copiarEdicion.Image = global::Writer.media.document_copies;
            this.copiarEdicion.Name = "copiarEdicion";
            this.copiarEdicion.Size = new System.Drawing.Size(180, 22);
            this.copiarEdicion.Text = "Copiar";
            // 
            // pegarEdicion
            // 
            this.pegarEdicion.Image = global::Writer.media.clipboard_invoice;
            this.pegarEdicion.Name = "pegarEdicion";
            this.pegarEdicion.Size = new System.Drawing.Size(180, 22);
            this.pegarEdicion.Text = "Pegar";
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barraDeHerramientasToolStripMenuItem,
            this.barraDeEstadoToolStripMenuItem});
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.verToolStripMenuItem.Text = "Ver";
            // 
            // barraDeHerramientasToolStripMenuItem
            // 
            this.barraDeHerramientasToolStripMenuItem.Checked = true;
            this.barraDeHerramientasToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.barraDeHerramientasToolStripMenuItem.Name = "barraDeHerramientasToolStripMenuItem";
            this.barraDeHerramientasToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.barraDeHerramientasToolStripMenuItem.Text = "Barra de herramientas";
            this.barraDeHerramientasToolStripMenuItem.Click += new System.EventHandler(this.BarraDeHerramientasToolStripMenuItemClick);
            // 
            // barraDeEstadoToolStripMenuItem
            // 
            this.barraDeEstadoToolStripMenuItem.Checked = true;
            this.barraDeEstadoToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.barraDeEstadoToolStripMenuItem.Name = "barraDeEstadoToolStripMenuItem";
            this.barraDeEstadoToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.barraDeEstadoToolStripMenuItem.Text = "Barra de estado";
            this.barraDeEstadoToolStripMenuItem.Click += new System.EventHandler(this.BarraDeEstadoToolStripMenuItemClick);
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.AcerdaDeToolStripMenuItemClick);
            // 
            // toolStyles
            // 
            this.toolStyles.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStyles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBold,
            this.toolCursive,
            this.toolUnderline,
            this.toolTachado,
            this.toolStripSeparator3,
            this.toolJusLeft,
            this.toolJusCenter,
            this.toolJusRight,
            this.toolJusFill,
            this.toolStripSeparator4,
            this.toolBullet,
            this.toolColor,
            this.toolBackColor});
            this.toolStyles.Location = new System.Drawing.Point(144, 0);
            this.toolStyles.Name = "toolStyles";
            this.toolStyles.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStyles.Size = new System.Drawing.Size(277, 25);
            this.toolStyles.TabIndex = 1;
            this.toolStyles.Text = "toolStrip1";
            // 
            // toolBold
            // 
            this.toolBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBold.Image = global::Writer.media.text_bold;
            this.toolBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBold.Name = "toolBold";
            this.toolBold.Size = new System.Drawing.Size(23, 22);
            this.toolBold.Text = "Negrita";
            this.toolBold.Click += new System.EventHandler(this.ToolBoldClick);
            // 
            // toolCursive
            // 
            this.toolCursive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCursive.Image = global::Writer.media.text_italic;
            this.toolCursive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCursive.Name = "toolCursive";
            this.toolCursive.Size = new System.Drawing.Size(23, 22);
            this.toolCursive.Text = "Cursiva";
            this.toolCursive.Click += new System.EventHandler(this.ToolCursiveClick);
            // 
            // toolUnderline
            // 
            this.toolUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolUnderline.Image = global::Writer.media.text_underline;
            this.toolUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolUnderline.Name = "toolUnderline";
            this.toolUnderline.Size = new System.Drawing.Size(23, 22);
            this.toolUnderline.Text = "Subrayado";
            this.toolUnderline.Click += new System.EventHandler(this.ToolUnderlineClick);
            // 
            // toolTachado
            // 
            this.toolTachado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolTachado.Image = global::Writer.media.text_strikethroungh;
            this.toolTachado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolTachado.Name = "toolTachado";
            this.toolTachado.Size = new System.Drawing.Size(23, 22);
            this.toolTachado.Text = "Tachado";
            this.toolTachado.Click += new System.EventHandler(this.ToolTachadoClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolJusLeft
            // 
            this.toolJusLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolJusLeft.Image = global::Writer.media.text_align_left;
            this.toolJusLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolJusLeft.Name = "toolJusLeft";
            this.toolJusLeft.Size = new System.Drawing.Size(23, 22);
            this.toolJusLeft.Text = "Alinear a la izquierda";
            this.toolJusLeft.Click += new System.EventHandler(this.ToolJusLeftClick);
            // 
            // toolJusCenter
            // 
            this.toolJusCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolJusCenter.Image = global::Writer.media.text_align_center;
            this.toolJusCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolJusCenter.Name = "toolJusCenter";
            this.toolJusCenter.Size = new System.Drawing.Size(23, 22);
            this.toolJusCenter.Text = "Alinear al centro";
            this.toolJusCenter.Click += new System.EventHandler(this.ToolJusCenterClick);
            // 
            // toolJusRight
            // 
            this.toolJusRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolJusRight.Image = global::Writer.media.text_align_right;
            this.toolJusRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolJusRight.Name = "toolJusRight";
            this.toolJusRight.Size = new System.Drawing.Size(23, 22);
            this.toolJusRight.Text = "Alinear a la derecha";
            this.toolJusRight.Click += new System.EventHandler(this.ToolJusRightClick);
            // 
            // toolJusFill
            // 
            this.toolJusFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolJusFill.Enabled = false;
            this.toolJusFill.Image = global::Writer.media.text_align_justity;
            this.toolJusFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolJusFill.Name = "toolJusFill";
            this.toolJusFill.Size = new System.Drawing.Size(23, 22);
            this.toolJusFill.Text = "Justificado";
            this.toolJusFill.Click += new System.EventHandler(this.ToolJusFillClick);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolBullet
            // 
            this.toolBullet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBullet.Image = global::Writer.media.text_list_bullets;
            this.toolBullet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBullet.Name = "toolBullet";
            this.toolBullet.Size = new System.Drawing.Size(23, 22);
            this.toolBullet.Text = "Viñetas";
            this.toolBullet.Click += new System.EventHandler(this.ToolBulletClick);
            // 
            // toolColor
            // 
            this.toolColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolColor.Image = global::Writer.media.fill_color;
            this.toolColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolColor.Name = "toolColor";
            this.toolColor.Size = new System.Drawing.Size(23, 22);
            this.toolColor.Text = "Color de texto";
            this.toolColor.Click += new System.EventHandler(this.ToolColorClick);
            // 
            // toolBackColor
            // 
            this.toolBackColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBackColor.Image = global::Writer.media.color_wheel;
            this.toolBackColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBackColor.Name = "toolBackColor";
            this.toolBackColor.Size = new System.Drawing.Size(23, 22);
            this.toolBackColor.Text = "Color de fondo";
            this.toolBackColor.Click += new System.EventHandler(this.ToolBackColorClick);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStripLblCount});
            this.statusBar.Location = new System.Drawing.Point(0, 359);
            this.statusBar.Name = "statusBar";
            this.statusBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusBar.Size = new System.Drawing.Size(546, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            // 
            // tStripLblCount
            // 
            this.tStripLblCount.Name = "tStripLblCount";
            this.tStripLblCount.Size = new System.Drawing.Size(118, 17);
            this.tStripLblCount.Text = "toolStripStatusLabel1";
            // 
            // rTextBox
            // 
            this.rTextBox.AcceptsTab = true;
            this.rTextBox.AutoWordSelection = true;
            this.rTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rTextBox.ContextMenuStrip = this.conRichText;
            this.rTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTextBox.Location = new System.Drawing.Point(0, 0);
            this.rTextBox.Name = "rTextBox";
            this.rTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rTextBox.Size = new System.Drawing.Size(546, 310);
            this.rTextBox.TabIndex = 0;
            this.rTextBox.Text = "";
            this.rTextBox.SelectionChanged += new System.EventHandler(this.RTextBoxSelectionChanged);
            // 
            // conRichText
            // 
            this.conRichText.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cortarRTF,
            this.copiarRTF,
            this.pegarRTF});
            this.conRichText.Name = "conRichText";
            this.conRichText.Size = new System.Drawing.Size(110, 70);
            // 
            // cortarRTF
            // 
            this.cortarRTF.Image = global::Writer.media.cut;
            this.cortarRTF.Name = "cortarRTF";
            this.cortarRTF.Size = new System.Drawing.Size(109, 22);
            this.cortarRTF.Text = "Cortar";
            // 
            // copiarRTF
            // 
            this.copiarRTF.Image = global::Writer.media.document_copies;
            this.copiarRTF.Name = "copiarRTF";
            this.copiarRTF.Size = new System.Drawing.Size(109, 22);
            this.copiarRTF.Text = "Copiar";
            // 
            // pegarRTF
            // 
            this.pegarRTF.Image = global::Writer.media.clipboard_invoice;
            this.pegarRTF.Name = "pegarRTF";
            this.pegarRTF.Size = new System.Drawing.Size(109, 22);
            this.pegarRTF.Text = "Pegar";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.rTextBox);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(546, 310);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(546, 335);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolFont);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStyles);
            this.toolStripContainer1.TopToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // toolFont
            // 
            this.toolFont.Dock = System.Windows.Forms.DockStyle.None;
            this.toolFont.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolFonts,
            this.toolStripSeparator2});
            this.toolFont.Location = new System.Drawing.Point(3, 0);
            this.toolFont.Name = "toolFont";
            this.toolFont.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolFont.Size = new System.Drawing.Size(141, 25);
            this.toolFont.TabIndex = 2;
            // 
            // toolFonts
            // 
            this.toolFonts.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolFonts.Name = "toolFonts";
            this.toolFonts.Size = new System.Drawing.Size(121, 25);
            this.toolFonts.SelectedIndexChanged += new System.EventHandler(this.ToolFontsSelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 381);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Writer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStyles.ResumeLayout(false);
            this.toolStyles.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.conRichText.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolFont.ResumeLayout(false);
            this.toolFont.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.ToolStripButton toolBackColor;
		private System.Windows.Forms.ToolStripButton toolColor;
		private System.Windows.Forms.ToolStripButton toolBullet;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem pegarRTF;
		private System.Windows.Forms.ToolStripMenuItem copiarRTF;
		private System.Windows.Forms.ToolStripMenuItem cortarRTF;
		private System.Windows.Forms.ContextMenuStrip conRichText;
		private System.Windows.Forms.ToolStripButton toolJusFill;
		private System.Windows.Forms.ToolStripButton toolJusRight;
		private System.Windows.Forms.ToolStripButton toolJusCenter;
		private System.Windows.Forms.ToolStripButton toolJusLeft;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton toolTachado;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStrip toolFont;
		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.ToolStripComboBox toolFonts;
		private System.Windows.Forms.ToolStripMenuItem pegarEdicion;
		private System.Windows.Forms.ToolStripMenuItem copiarEdicion;
		private System.Windows.Forms.ToolStripMenuItem cortarEdicion;
		private System.Windows.Forms.ToolStripStatusLabel tStripLblCount;
		private System.Windows.Forms.ToolStripButton toolUnderline;
		private System.Windows.Forms.ToolStripButton toolCursive;
		private System.Windows.Forms.ToolStripButton toolBold;
		private System.Windows.Forms.RichTextBox rTextBox;
		private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem barraDeEstadoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem barraDeHerramientasToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ediciónToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.ToolStrip toolStyles;
		private System.Windows.Forms.MenuStrip menuStrip1;
	}
}
