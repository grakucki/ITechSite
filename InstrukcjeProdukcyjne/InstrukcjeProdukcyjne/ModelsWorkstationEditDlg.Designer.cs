namespace InstrukcjeProdukcyjne
{
    partial class ModelsWorkstationEditDlg
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.resourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboTreeBox1 = new ComboTreeBox();
            this.textBoxFiltr = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonCancel.Location = new System.Drawing.Point(248, 674);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(152, 96);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Anuluj";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonOk.Location = new System.Drawing.Point(485, 674);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(147, 96);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(InstrukcjeProdukcyjne.ServiceWorkstation.ModelWorkstationInfo);
            // 
            // resourceBindingSource
            // 
            this.resourceBindingSource.DataSource = typeof(ITechInstrukcjeModel.Resource);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(248, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(388, 49);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(50, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "Stacja robocza";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(149, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 29);
            this.label2.TabIndex = 9;
            this.label2.Text = "model";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(12, 358);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 29);
            this.label3.TabIndex = 11;
            this.label3.Text = "indeks sterownika";
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "SterownikIndex", true));
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox2.Location = new System.Drawing.Point(248, 334);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(190, 62);
            this.textBox2.TabIndex = 10;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(666, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(308, 116);
            this.button1.TabIndex = 12;
            this.button1.Text = "odczytaj index ze sterownika";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBox1.Location = new System.Drawing.Point(248, 252);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(467, 46);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "Pokaż wszystkie modele";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // comboTreeBox1
            // 
            this.comboTreeBox1.DropDownHeight = 600;
            this.comboTreeBox1.DroppedDown = false;
            this.comboTreeBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboTreeBox1.Location = new System.Drawing.Point(248, 173);
            this.comboTreeBox1.Name = "comboTreeBox1";
            this.comboTreeBox1.SelectedNode = null;
            this.comboTreeBox1.Size = new System.Drawing.Size(999, 62);
            this.comboTreeBox1.TabIndex = 14;
            // 
            // textBoxFiltr
            // 
            this.textBoxFiltr.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold);
            this.textBoxFiltr.Location = new System.Drawing.Point(248, 105);
            this.textBoxFiltr.Name = "textBoxFiltr";
            this.textBoxFiltr.Size = new System.Drawing.Size(918, 62);
            this.textBoxFiltr.TabIndex = 15;
            this.toolTip1.SetToolTip(this.textBoxFiltr, "Filtr modeli i wariantów");
            this.textBoxFiltr.TextChanged += new System.EventHandler(this.textBoxFiltr_TextChanged);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(1172, 100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 62);
            this.button2.TabIndex = 16;
            this.button2.Text = "K";
            this.toolTip1.SetToolTip(this.button2, "Klawiatura");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(22, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 62);
            this.label4.TabIndex = 17;
            this.label4.Text = "Filtr modeli i wariantów";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ModelsWorkstationEditDlg
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(1402, 795);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxFiltr);
            this.Controls.Add(this.comboTreeBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Name = "ModelsWorkstationEditDlg";
            this.Text = "Modele na stacji roboczej - Edycja";
            this.Load += new System.EventHandler(this.ModelsWorkstationEditDlg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourceBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource resourceBindingSource;
        private System.Windows.Forms.CheckBox checkBox1;
        private ComboTreeBox comboTreeBox1;
        private System.Windows.Forms.TextBox textBoxFiltr;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label4;
    }
}