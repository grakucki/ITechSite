namespace InstrukcjeProdukcyjne
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfViewerControl));
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.customPanel2 = new CustomPanelControl.CustomPanel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            this.customPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(0, 0);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(324, 257);
            this.axAcroPDF1.TabIndex = 1;
            this.axAcroPDF1.OnError += new System.EventHandler(this.axAcroPDF1_OnError);
            // 
            // customPanel2
            // 
            this.customPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customPanel2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel2.BorderWidth = 3;
            this.customPanel2.Controls.Add(this.label1);
            this.customPanel2.Curvature = 10;
            this.customPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.customPanel2.GradientMode = CustomPanelControl.LinearGradientMode.Vertical;
            this.customPanel2.Location = new System.Drawing.Point(138, 0);
            this.customPanel2.Name = "customPanel2";
            this.customPanel2.Padding = new System.Windows.Forms.Padding(5);
            this.customPanel2.Size = new System.Drawing.Size(186, 257);
            this.customPanel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sterowanie pdf";
            // 
            // PdfViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customPanel2);
            this.Controls.Add(this.axAcroPDF1);
            this.Name = "PdfViewerControl";
            this.Size = new System.Drawing.Size(324, 257);
            this.Load += new System.EventHandler(this.PdfViewerControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            this.customPanel2.ResumeLayout(false);
            this.customPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
        private CustomPanelControl.CustomPanel customPanel2;
        private System.Windows.Forms.Label label1;

    }
}
