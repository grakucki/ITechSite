namespace InstrukcjeProdukcyjne
{
    partial class DokumentShowDlg
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.mediaViewerControl1 = new InstrukcjeProdukcyjne.MediaViewerControl();
            this.customPanel1 = new CustomPanelControl.CustomPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.KomunikatLabel = new System.Windows.Forms.Label();
            this.panel2 = new CustomPanelControl.CustomPanel();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelUserNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.customPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.customPanel1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(994, 61);
            this.panel1.TabIndex = 10;
            // 
            // mediaViewerControl1
            // 
            this.mediaViewerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediaViewerControl1.Location = new System.Drawing.Point(0, 61);
            this.mediaViewerControl1.Name = "mediaViewerControl1";
            this.mediaViewerControl1.Size = new System.Drawing.Size(994, 433);
            this.mediaViewerControl1.TabIndex = 9;
            // 
            // customPanel1
            // 
            this.customPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.customPanel1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.customPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel1.BorderWidth = 3;
            this.customPanel1.Controls.Add(this.label1);
            this.customPanel1.Controls.Add(this.KomunikatLabel);
            this.customPanel1.Curvature = 10;
            this.customPanel1.GradientMode = CustomPanelControl.LinearGradientMode.BackwardDiagonal;
            this.customPanel1.Location = new System.Drawing.Point(271, 3);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.customPanel1.Size = new System.Drawing.Size(720, 57);
            this.customPanel1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(569, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dotkni aby zamknąć";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // KomunikatLabel
            // 
            this.KomunikatLabel.BackColor = System.Drawing.Color.Transparent;
            this.KomunikatLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KomunikatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.KomunikatLabel.Location = new System.Drawing.Point(5, 5);
            this.KomunikatLabel.Margin = new System.Windows.Forms.Padding(3);
            this.KomunikatLabel.Name = "KomunikatLabel";
            this.KomunikatLabel.Size = new System.Drawing.Size(710, 47);
            this.KomunikatLabel.TabIndex = 0;
            this.KomunikatLabel.Text = "O dokumencie";
            this.KomunikatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.BorderWidth = 3;
            this.panel2.Controls.Add(this.labelUserName);
            this.panel2.Controls.Add(this.labelUserNo);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Curvature = 10;
            this.panel2.GradientMode = CustomPanelControl.LinearGradientMode.Vertical;
            this.panel2.Location = new System.Drawing.Point(3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(262, 57);
            this.panel2.TabIndex = 1;
            // 
            // labelUserName
            // 
            this.labelUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.labelUserName.Location = new System.Drawing.Point(-2, 24);
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
            this.labelUserNo.Location = new System.Drawing.Point(83, 1);
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
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Operator:";
            // 
            // DokumentShowDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 494);
            this.Controls.Add(this.mediaViewerControl1);
            this.Controls.Add(this.panel1);
            this.Name = "DokumentShowDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DokumentShowDlg";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DokumentShowDlg_Load);
            this.panel1.ResumeLayout(false);
            this.customPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomPanelControl.CustomPanel panel2;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelUserNo;
        private System.Windows.Forms.Label label4;
        private MediaViewerControl mediaViewerControl1;
        private System.Windows.Forms.Panel panel1;
        private CustomPanelControl.CustomPanel customPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label KomunikatLabel;
    }
}