﻿namespace InstrukcjeProdukcyjne
{
    partial class PdfViewerControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfViewerControl));
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.customPanel2 = new CustomPanelControl.CustomPanel();
            this.customPanel5 = new CustomPanelControl.CustomPanel();
            this.button9 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            this.customPanel2.SuspendLayout();
            this.customPanel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(0, 0);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(390, 767);
            this.axAcroPDF1.TabIndex = 1;
            this.axAcroPDF1.OnError += new System.EventHandler(this.axAcroPDF1_OnError);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // customPanel2
            // 
            this.customPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))));
            this.customPanel2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))));
            this.customPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel2.BorderWidth = 3;
            this.customPanel2.Controls.Add(this.customPanel5);
            this.customPanel2.Controls.Add(this.panel1);
            this.customPanel2.Curvature = 10;
            this.customPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.customPanel2.GradientMode = CustomPanelControl.LinearGradientMode.Vertical;
            this.customPanel2.Location = new System.Drawing.Point(390, 0);
            this.customPanel2.Name = "customPanel2";
            this.customPanel2.Padding = new System.Windows.Forms.Padding(5);
            this.customPanel2.Size = new System.Drawing.Size(339, 767);
            this.customPanel2.TabIndex = 2;
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
            this.customPanel5.Location = new System.Drawing.Point(5, 719);
            this.customPanel5.Name = "customPanel5";
            this.customPanel5.Size = new System.Drawing.Size(329, 43);
            this.customPanel5.TabIndex = 13;
            // 
            // button9
            // 
            this.button9.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(0, 0);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(329, 43);
            this.button9.TabIndex = 0;
            this.button9.Text = "Z a m k n i j";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackgroundImage = global::InstrukcjeProdukcyjne.Properties.Resources.schemat_bitmap_dla_PDF2;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.button10);
            this.panel1.Controls.Add(this.button11);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(5, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 667);
            this.panel1.TabIndex = 3;
            // 
            // button10
            // 
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Location = new System.Drawing.Point(3, 3);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(103, 111);
            this.button10.TabIndex = 9;
            this.button10.Text = "Szerokość strony";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Location = new System.Drawing.Point(3, 113);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(103, 111);
            this.button11.TabIndex = 8;
            this.button11.Text = "Cała strona";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(122, 553);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(103, 111);
            this.button8.TabIndex = 7;
            this.button8.Text = "Przesuń w dół";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(173, 443);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(103, 111);
            this.button7.TabIndex = 6;
            this.button7.Text = "Przesuń w prawo";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(71, 443);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(103, 111);
            this.button6.TabIndex = 5;
            this.button6.Text = "Przesuń w lewo";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(122, 333);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(103, 111);
            this.button5.TabIndex = 4;
            this.button5.Text = "Przesuń do góry";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            this.button5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button5_MouseDown);
            this.button5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button5_MouseUp);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(173, 223);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(103, 111);
            this.button4.TabIndex = 3;
            this.button4.Text = "Poprzednia strona";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(73, 223);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 111);
            this.button3.TabIndex = 2;
            this.button3.Text = "Następna strona";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(122, 113);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 111);
            this.button2.TabIndex = 1;
            this.button2.Text = "Zmniejsz";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(122, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 111);
            this.button1.TabIndex = 0;
            this.button1.Text = "Zwiększ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PdfViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axAcroPDF1);
            this.Controls.Add(this.customPanel2);
            this.Name = "PdfViewerControl";
            this.Size = new System.Drawing.Size(729, 767);
            this.Load += new System.EventHandler(this.PdfViewerControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            this.customPanel2.ResumeLayout(false);
            this.customPanel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
        private CustomPanelControl.CustomPanel customPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private CustomPanelControl.CustomPanel customPanel5;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Timer timer1;

    }
}
