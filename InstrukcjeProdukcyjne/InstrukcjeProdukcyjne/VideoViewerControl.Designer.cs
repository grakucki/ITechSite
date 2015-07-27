namespace InstrukcjeProdukcyjne
{
    partial class VideoViewerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoViewerControl));
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.customPanel2 = new CustomPanelControl.CustomPanel();
            this.customPanel5 = new CustomPanelControl.CustomPanel();
            this.button9 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.customPanel2.SuspendLayout();
            this.customPanel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 0);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(639, 801);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // customPanel2
            // 
            this.customPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customPanel2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel2.BorderWidth = 3;
            this.customPanel2.Controls.Add(this.customPanel5);
            this.customPanel2.Controls.Add(this.panel1);
            this.customPanel2.Curvature = 10;
            this.customPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.customPanel2.GradientMode = CustomPanelControl.LinearGradientMode.Vertical;
            this.customPanel2.Location = new System.Drawing.Point(301, 0);
            this.customPanel2.Name = "customPanel2";
            this.customPanel2.Padding = new System.Windows.Forms.Padding(5);
            this.customPanel2.Size = new System.Drawing.Size(338, 801);
            this.customPanel2.TabIndex = 1;
            // 
            // customPanel5
            // 
            this.customPanel5.BackColor = System.Drawing.Color.Gray;
            this.customPanel5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.customPanel5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.customPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel5.BorderWidth = 3;
            this.customPanel5.Controls.Add(this.button9);
            this.customPanel5.Curvature = 10;
            this.customPanel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.customPanel5.GradientMode = CustomPanelControl.LinearGradientMode.Vertical;
            this.customPanel5.Location = new System.Drawing.Point(5, 753);
            this.customPanel5.Name = "customPanel5";
            this.customPanel5.Size = new System.Drawing.Size(328, 43);
            this.customPanel5.TabIndex = 15;
            // 
            // button9
            // 
            this.button9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(0, 0);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(328, 43);
            this.button9.TabIndex = 0;
            this.button9.Text = "Z a m k n i j";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackgroundImage = global::InstrukcjeProdukcyjne.Properties.Resources.szablon_podziału_klatek_z_PLAY;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(8, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(321, 667);
            this.panel1.TabIndex = 14;
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(121, 495);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(103, 111);
            this.button5.TabIndex = 4;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(121, 384);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(103, 111);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(120, 275);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 111);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(121, 165);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 111);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(121, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 111);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // VideoViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customPanel2);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Name = "VideoViewerControl";
            this.Size = new System.Drawing.Size(639, 801);
            this.Load += new System.EventHandler(this.VideoViewerControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.customPanel2.ResumeLayout(false);
            this.customPanel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private CustomPanelControl.CustomPanel customPanel2;
        private CustomPanelControl.CustomPanel customPanel5;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
