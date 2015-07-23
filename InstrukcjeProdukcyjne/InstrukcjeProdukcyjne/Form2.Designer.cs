namespace InstrukcjeProdukcyjne
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.buttonWorkstation = new System.Windows.Forms.Button();
            this.buttonModel = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusITechTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.WorkStationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.KomunikatLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelUserNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelTime = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.klawiaturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testKompetencjiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.synchronizujPlikiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.oAplikacjiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel5 = new System.Windows.Forms.Panel();
            this.elementyComboBox = new System.Windows.Forms.ComboBox();
            this.ModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mediaViewerControl1 = new InstrukcjeProdukcyjne.MediaViewerControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSterownik = new System.Windows.Forms.Button();
            this.imageListSterownik = new System.Windows.Forms.ImageList(this.components);
            this.buttonItech = new System.Windows.Forms.Button();
            this.imageListServer = new System.Windows.Forms.ImageList(this.components);
            this.buttonCzytnik = new System.Windows.Forms.Button();
            this.imageListCzytnik = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WorkStationBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModelBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonWorkstation
            // 
            this.buttonWorkstation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonWorkstation.Location = new System.Drawing.Point(12, 10);
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
            this.buttonModel.Location = new System.Drawing.Point(214, 11);
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
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(13, 187);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(396, 182);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
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
            this.statusStrip1.Location = new System.Drawing.Point(10, 660);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1116, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1058, 17);
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
            // WorkStationBindingSource
            // 
            this.WorkStationBindingSource.DataSource = typeof(ITechInstrukcjeModel.Resource);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1116, 142);
            this.panel1.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 268F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 219F));
            this.tableLayoutPanel3.Controls.Add(this.KomunikatLabel, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel3, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel5, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1116, 127);
            this.tableLayoutPanel3.TabIndex = 14;
            // 
            // KomunikatLabel
            // 
            this.KomunikatLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.KomunikatLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel3.SetColumnSpan(this.KomunikatLabel, 2);
            this.KomunikatLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KomunikatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.KomunikatLabel.Location = new System.Drawing.Point(271, 3);
            this.KomunikatLabel.Margin = new System.Windows.Forms.Padding(3);
            this.KomunikatLabel.Name = "KomunikatLabel";
            this.KomunikatLabel.Size = new System.Drawing.Size(842, 57);
            this.KomunikatLabel.TabIndex = 0;
            this.KomunikatLabel.Text = "Komunikat stanowisko ......";
            this.KomunikatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.labelUserName);
            this.panel2.Controls.Add(this.labelUserNo);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(262, 57);
            this.panel2.TabIndex = 0;
            // 
            // labelUserName
            // 
            this.labelUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.labelUserName.Location = new System.Drawing.Point(-2, 22);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(264, 23);
            this.labelUserName.TabIndex = 11;
            this.labelUserName.Text = "labelUserName";
            this.labelUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelUserNo
            // 
            this.labelUserNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUserNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.labelUserNo.Location = new System.Drawing.Point(89, -1);
            this.labelUserNo.Name = "labelUserNo";
            this.labelUserNo.Size = new System.Drawing.Size(173, 23);
            this.labelUserNo.TabIndex = 10;
            this.labelUserNo.Text = "labelUserNo";
            this.labelUserNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(3, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Operator:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(900, 66);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(213, 58);
            this.panel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Stanowisko:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.WorkStationBindingSource, "Name", true));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.textBox1.Location = new System.Drawing.Point(0, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(208, 22);
            this.textBox1.TabIndex = 12;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.labelTime);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 66);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(262, 58);
            this.panel4.TabIndex = 7;
            // 
            // labelTime
            // 
            this.labelTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.labelTime.Location = new System.Drawing.Point(5, 21);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(204, 23);
            this.labelTime.TabIndex = 12;
            this.labelTime.Text = "label2";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.ContextMenuStrip = this.contextMenuStrip1;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(209, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 48);
            this.button1.TabIndex = 11;
            this.button1.Text = "|";
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
            this.testKompetencjiToolStripMenuItem,
            this.synchronizujPlikiToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripSeparator2,
            this.oAplikacjiToolStripMenuItem,
            this.toolStripMenuItem3});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(348, 366);
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
            // testKompetencjiToolStripMenuItem
            // 
            this.testKompetencjiToolStripMenuItem.Name = "testKompetencjiToolStripMenuItem";
            this.testKompetencjiToolStripMenuItem.Size = new System.Drawing.Size(347, 50);
            this.testKompetencjiToolStripMenuItem.Text = "Test kompetencji";
            this.testKompetencjiToolStripMenuItem.Click += new System.EventHandler(this.testKompetencjiToolStripMenuItem_Click);
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
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.elementyComboBox);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(271, 66);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(623, 58);
            this.panel5.TabIndex = 8;
            // 
            // elementyComboBox
            // 
            this.elementyComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementyComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.elementyComboBox.DataSource = this.ModelBindingSource;
            this.elementyComboBox.DisplayMember = "Name";
            this.elementyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.elementyComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.elementyComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.elementyComboBox.FormattingEnabled = true;
            this.elementyComboBox.Location = new System.Drawing.Point(0, 13);
            this.elementyComboBox.Name = "elementyComboBox";
            this.elementyComboBox.Size = new System.Drawing.Size(621, 32);
            this.elementyComboBox.TabIndex = 6;
            this.elementyComboBox.SelectedIndexChanged += new System.EventHandler(this.elementyComboBox_SelectedIndexChanged);
            // 
            // ModelBindingSource
            // 
            this.ModelBindingSource.DataSource = typeof(ITechInstrukcjeModel.Resource);
            this.ModelBindingSource.PositionChanged += new System.EventHandler(this.ModelBindingSource_PositionChanged);
            // 
            // mediaViewerControl1
            // 
            this.mediaViewerControl1.BackgroundImage = global::InstrukcjeProdukcyjne.Properties.Resources.Logo;
            this.mediaViewerControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.mediaViewerControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mediaViewerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediaViewerControl1.Location = new System.Drawing.Point(0, 0);
            this.mediaViewerControl1.Name = "mediaViewerControl1";
            this.mediaViewerControl1.Size = new System.Drawing.Size(686, 508);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 375);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(394, 127);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // buttonSterownik
            // 
            this.buttonSterownik.BackColor = System.Drawing.Color.Red;
            this.buttonSterownik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSterownik.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSterownik.ImageIndex = 0;
            this.buttonSterownik.ImageList = this.imageListSterownik;
            this.buttonSterownik.Location = new System.Drawing.Point(3, 3);
            this.buttonSterownik.Name = "buttonSterownik";
            this.buttonSterownik.Size = new System.Drawing.Size(125, 121);
            this.buttonSterownik.TabIndex = 0;
            this.toolTip1.SetToolTip(this.buttonSterownik, "Sterownik");
            this.buttonSterownik.UseVisualStyleBackColor = false;
            this.buttonSterownik.Click += new System.EventHandler(this.buttonSterownik_Click);
            // 
            // imageListSterownik
            // 
            this.imageListSterownik.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListSterownik.ImageStream")));
            this.imageListSterownik.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListSterownik.Images.SetKeyName(0, "PLC off 100 X.gif");
            this.imageListSterownik.Images.SetKeyName(1, "PLC on 100.gif");
            // 
            // buttonItech
            // 
            this.buttonItech.BackColor = System.Drawing.Color.Red;
            this.buttonItech.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonItech.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonItech.ImageIndex = 0;
            this.buttonItech.ImageList = this.imageListServer;
            this.buttonItech.Location = new System.Drawing.Point(134, 3);
            this.buttonItech.Name = "buttonItech";
            this.buttonItech.Size = new System.Drawing.Size(125, 121);
            this.buttonItech.TabIndex = 1;
            this.toolTip1.SetToolTip(this.buttonItech, "Itech");
            this.buttonItech.UseVisualStyleBackColor = false;
            this.buttonItech.Click += new System.EventHandler(this.button3_Click);
            // 
            // imageListServer
            // 
            this.imageListServer.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListServer.ImageStream")));
            this.imageListServer.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListServer.Images.SetKeyName(0, "SRV off 100 X.gif");
            this.imageListServer.Images.SetKeyName(1, "SRV on 100.gif");
            // 
            // buttonCzytnik
            // 
            this.buttonCzytnik.BackColor = System.Drawing.Color.Green;
            this.buttonCzytnik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCzytnik.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonCzytnik.ImageIndex = 1;
            this.buttonCzytnik.ImageList = this.imageListCzytnik;
            this.buttonCzytnik.Location = new System.Drawing.Point(265, 3);
            this.buttonCzytnik.Name = "buttonCzytnik";
            this.buttonCzytnik.Size = new System.Drawing.Size(126, 121);
            this.buttonCzytnik.TabIndex = 2;
            this.toolTip1.SetToolTip(this.buttonCzytnik, "Czytnik");
            this.buttonCzytnik.UseVisualStyleBackColor = false;
            this.buttonCzytnik.Click += new System.EventHandler(this.buttonCzytnik_Click);
            // 
            // imageListCzytnik
            // 
            this.imageListCzytnik.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListCzytnik.ImageStream")));
            this.imageListCzytnik.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListCzytnik.Images.SetKeyName(0, "CR off 100 X.gif");
            this.imageListCzytnik.Images.SetKeyName(1, "CR on 100.gif");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(10, 152);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonWorkstation);
            this.splitContainer1.Panel1.Controls.Add(this.buttonModel);
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.mediaViewerControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1116, 508);
            this.splitContainer1.SplitterDistance = 426;
            this.splitContainer1.TabIndex = 9;
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1136, 692);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "ITech - Sitech";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WorkStationBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ModelBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonWorkstation;
        private System.Windows.Forms.Button buttonModel;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox elementyComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label KomunikatLabel;
        private System.Windows.Forms.BindingSource ModelBindingSource;
        private System.Windows.Forms.BindingSource WorkStationBindingSource;
        private MediaViewerControl mediaViewerControl1;
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
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusITechTime;
        private System.Windows.Forms.ToolStripMenuItem synchronizujPlikiToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList imageListServer;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ImageList imageListSterownik;
        private System.Windows.Forms.ImageList imageListCzytnik;
        private System.Windows.Forms.ToolStripMenuItem testKompetencjiToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelUserNo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Timer timer2;
    }
}

