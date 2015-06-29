namespace InstrukcjeProdukcyjne
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonWorkstation = new System.Windows.Forms.Button();
            this.buttonModel = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusITechTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.stanowiskaComboBox = new System.Windows.Forms.ComboBox();
            this.WorkStationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.klawiaturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.synchronizujPlikiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.oAplikacjiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.elementyComboBox = new System.Windows.Forms.ComboBox();
            this.ModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.KomunikatLabel = new System.Windows.Forms.Label();
            this.labelCzasNews = new System.Windows.Forms.Label();
            this.mediaViewerControl1 = new InstrukcjeProdukcyjne.MediaViewerControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSterownik = new System.Windows.Forms.Button();
            this.buttonItech = new System.Windows.Forms.Button();
            this.buttonCzytnik = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WorkStationBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModelBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonWorkstation
            // 
            this.buttonWorkstation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonWorkstation.Location = new System.Drawing.Point(10, 73);
            this.buttonWorkstation.Name = "buttonWorkstation";
            this.buttonWorkstation.Size = new System.Drawing.Size(193, 169);
            this.buttonWorkstation.TabIndex = 0;
            this.buttonWorkstation.Text = "Instrukcje stanowiskowe";
            this.buttonWorkstation.UseVisualStyleBackColor = true;
            this.buttonWorkstation.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonModel
            // 
            this.buttonModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonModel.Location = new System.Drawing.Point(212, 74);
            this.buttonModel.Name = "buttonModel";
            this.buttonModel.Size = new System.Drawing.Size(192, 168);
            this.buttonModel.TabIndex = 1;
            this.buttonModel.Text = "Instrukcje modeli produkcyjnych";
            this.buttonModel.UseVisualStyleBackColor = true;
            this.buttonModel.Click += new System.EventHandler(this.button2_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(11, 250);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(404, 231);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Image1.bmp");
            this.imageList1.Images.SetKeyName(1, "mp4.bmp");
            this.imageList1.Images.SetKeyName(2, "avi.bmp");
            this.imageList1.Images.SetKeyName(3, "jpg.bmp");
            this.imageList1.Images.SetKeyName(4, "pdf.bmp");
            this.imageList1.Images.SetKeyName(5, "wmv.bmp");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusITechTime});
            this.statusStrip1.Location = new System.Drawing.Point(10, 632);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1437, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1379, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusITechTime
            // 
            this.toolStripStatusITechTime.AutoSize = false;
            this.toolStripStatusITechTime.Name = "toolStripStatusITechTime";
            this.toolStripStatusITechTime.Size = new System.Drawing.Size(43, 17);
            this.toolStripStatusITechTime.Text = "  00:00 ";
            // 
            // stanowiskaComboBox
            // 
            this.stanowiskaComboBox.DataSource = this.WorkStationBindingSource;
            this.stanowiskaComboBox.DisplayMember = "Name";
            this.stanowiskaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stanowiskaComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.stanowiskaComboBox.FormattingEnabled = true;
            this.stanowiskaComboBox.Location = new System.Drawing.Point(115, 13);
            this.stanowiskaComboBox.Name = "stanowiskaComboBox";
            this.stanowiskaComboBox.Size = new System.Drawing.Size(266, 32);
            this.stanowiskaComboBox.TabIndex = 4;
            this.stanowiskaComboBox.ValueMember = "Id";
            // 
            // WorkStationBindingSource
            // 
            this.WorkStationBindingSource.DataSource = typeof(ITechInstrukcjeModel.Resource);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBoxUser);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.elementyComboBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.stanowiskaComboBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1437, 57);
            this.panel1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.ContextMenuStrip = this.contextMenuStrip1;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(1352, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 54);
            this.button1.TabIndex = 11;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.klawiaturaToolStripMenuItem,
            this.synchronizujPlikiToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripSeparator2,
            this.oAplikacjiToolStripMenuItem,
            this.toolStripMenuItem3});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(348, 316);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(347, 50);
            this.toolStripMenuItem1.Text = "Zablokuj stację";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(344, 6);
            // 
            // klawiaturaToolStripMenuItem
            // 
            this.klawiaturaToolStripMenuItem.Name = "klawiaturaToolStripMenuItem";
            this.klawiaturaToolStripMenuItem.Size = new System.Drawing.Size(347, 50);
            this.klawiaturaToolStripMenuItem.Text = "Klawiatura";
            this.klawiaturaToolStripMenuItem.Click += new System.EventHandler(this.klawiaturaToolStripMenuItem_Click);
            // 
            // synchronizujPlikiToolStripMenuItem
            // 
            this.synchronizujPlikiToolStripMenuItem.Name = "synchronizujPlikiToolStripMenuItem";
            this.synchronizujPlikiToolStripMenuItem.Size = new System.Drawing.Size(347, 50);
            this.synchronizujPlikiToolStripMenuItem.Text = "Synchronizuj pliki";
            this.synchronizujPlikiToolStripMenuItem.Click += new System.EventHandler(this.synchronizujPlikiToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(347, 50);
            this.toolStripMenuItem2.Text = "Ustawienia";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(344, 6);
            // 
            // oAplikacjiToolStripMenuItem
            // 
            this.oAplikacjiToolStripMenuItem.Name = "oAplikacjiToolStripMenuItem";
            this.oAplikacjiToolStripMenuItem.Size = new System.Drawing.Size(347, 50);
            this.oAplikacjiToolStripMenuItem.Text = "O Aplikacji";
            this.oAplikacjiToolStripMenuItem.Click += new System.EventHandler(this.oAplikacjiToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(347, 50);
            this.toolStripMenuItem3.Text = "Zakończ";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // textBoxUser
            // 
            this.textBoxUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.textBoxUser.Location = new System.Drawing.Point(1123, 13);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.ReadOnly = true;
            this.textBoxUser.Size = new System.Drawing.Size(223, 29);
            this.textBoxUser.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(1014, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "Użytkownik";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(401, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Model";
            // 
            // elementyComboBox
            // 
            this.elementyComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementyComboBox.DataSource = this.ModelBindingSource;
            this.elementyComboBox.DisplayMember = "Name";
            this.elementyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.elementyComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.elementyComboBox.FormattingEnabled = true;
            this.elementyComboBox.Location = new System.Drawing.Point(470, 12);
            this.elementyComboBox.Name = "elementyComboBox";
            this.elementyComboBox.Size = new System.Drawing.Size(534, 32);
            this.elementyComboBox.TabIndex = 6;
            this.elementyComboBox.SelectedIndexChanged += new System.EventHandler(this.elementyComboBox_SelectedIndexChanged);
            // 
            // ModelBindingSource
            // 
            this.ModelBindingSource.DataSource = typeof(ITechInstrukcjeModel.Resource);
            this.ModelBindingSource.PositionChanged += new System.EventHandler(this.ModelBindingSource_PositionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(4, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Stanowisko";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(10, 597);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1437, 35);
            this.panel2.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.KomunikatLabel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelCzasNews, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1437, 35);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // KomunikatLabel
            // 
            this.KomunikatLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KomunikatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.KomunikatLabel.Location = new System.Drawing.Point(103, 0);
            this.KomunikatLabel.Name = "KomunikatLabel";
            this.KomunikatLabel.Size = new System.Drawing.Size(1331, 35);
            this.KomunikatLabel.TabIndex = 0;
            this.KomunikatLabel.Text = "Komunikat stanowisko ......";
            this.KomunikatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCzasNews
            // 
            this.labelCzasNews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCzasNews.Location = new System.Drawing.Point(3, 0);
            this.labelCzasNews.Name = "labelCzasNews";
            this.labelCzasNews.Size = new System.Drawing.Size(94, 35);
            this.labelCzasNews.TabIndex = 1;
            this.labelCzasNews.Text = "...";
            // 
            // mediaViewerControl1
            // 
            this.mediaViewerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mediaViewerControl1.BackgroundImage = global::InstrukcjeProdukcyjne.Properties.Resources.Logo;
            this.mediaViewerControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.mediaViewerControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mediaViewerControl1.Location = new System.Drawing.Point(421, 74);
            this.mediaViewerControl1.Name = "mediaViewerControl1";
            this.mediaViewerControl1.Size = new System.Drawing.Size(1026, 517);
            this.mediaViewerControl1.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.buttonSterownik, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonItech, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonCzytnik, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 487);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(394, 100);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // buttonSterownik
            // 
            this.buttonSterownik.BackColor = System.Drawing.Color.Red;
            this.buttonSterownik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSterownik.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSterownik.Location = new System.Drawing.Point(3, 3);
            this.buttonSterownik.Name = "buttonSterownik";
            this.buttonSterownik.Size = new System.Drawing.Size(125, 94);
            this.buttonSterownik.TabIndex = 0;
            this.buttonSterownik.Text = "Sterownik";
            this.buttonSterownik.UseVisualStyleBackColor = false;
            // 
            // buttonItech
            // 
            this.buttonItech.BackColor = System.Drawing.Color.Red;
            this.buttonItech.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonItech.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonItech.Location = new System.Drawing.Point(134, 3);
            this.buttonItech.Name = "buttonItech";
            this.buttonItech.Size = new System.Drawing.Size(125, 94);
            this.buttonItech.TabIndex = 1;
            this.buttonItech.Text = "Itech";
            this.buttonItech.UseVisualStyleBackColor = false;
            this.buttonItech.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonCzytnik
            // 
            this.buttonCzytnik.BackColor = System.Drawing.Color.Green;
            this.buttonCzytnik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCzytnik.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonCzytnik.Location = new System.Drawing.Point(265, 3);
            this.buttonCzytnik.Name = "buttonCzytnik";
            this.buttonCzytnik.Size = new System.Drawing.Size(126, 94);
            this.buttonCzytnik.TabIndex = 2;
            this.buttonCzytnik.Text = "Czytnik";
            this.buttonCzytnik.UseVisualStyleBackColor = false;
            this.buttonCzytnik.Click += new System.EventHandler(this.buttonCzytnik_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1457, 664);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.mediaViewerControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.buttonModel);
            this.Controls.Add(this.buttonWorkstation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "ITech - Sitech";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WorkStationBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ModelBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonWorkstation;
        private System.Windows.Forms.Button buttonModel;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ComboBox stanowiskaComboBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox elementyComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label KomunikatLabel;
        private System.Windows.Forms.BindingSource ModelBindingSource;
        private System.Windows.Forms.BindingSource WorkStationBindingSource;
        private MediaViewerControl mediaViewerControl1;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem oAplikacjiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem klawiaturaToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonSterownik;
        private System.Windows.Forms.Button buttonItech;
        private System.Windows.Forms.Button buttonCzytnik;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelCzasNews;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusITechTime;
        private System.Windows.Forms.ToolStripMenuItem synchronizujPlikiToolStripMenuItem;
    }
}

