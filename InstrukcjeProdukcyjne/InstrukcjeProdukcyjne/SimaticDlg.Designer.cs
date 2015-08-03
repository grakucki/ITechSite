namespace InstrukcjeProdukcyjne
{
    partial class SimaticDlg
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
            System.Windows.Forms.Label sterownik_IpLabel;
            System.Windows.Forms.Label sterownik_ModelLabel;
            System.Windows.Forms.Label Sterownik_DBLabel;
            System.Windows.Forms.Label label1;
            this.sterownik_IpTextBox = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.setrownik_DBTextBox = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            sterownik_IpLabel = new System.Windows.Forms.Label();
            sterownik_ModelLabel = new System.Windows.Forms.Label();
            Sterownik_DBLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // sterownik_IpLabel
            // 
            sterownik_IpLabel.AutoSize = true;
            sterownik_IpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            sterownik_IpLabel.Location = new System.Drawing.Point(58, 88);
            sterownik_IpLabel.Name = "sterownik_IpLabel";
            sterownik_IpLabel.Size = new System.Drawing.Size(135, 25);
            sterownik_IpLabel.TabIndex = 0;
            sterownik_IpLabel.Text = "Sterownik Ip:";
            // 
            // sterownik_ModelLabel
            // 
            sterownik_ModelLabel.AutoSize = true;
            sterownik_ModelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            sterownik_ModelLabel.Location = new System.Drawing.Point(38, 147);
            sterownik_ModelLabel.Name = "sterownik_ModelLabel";
            sterownik_ModelLabel.Size = new System.Drawing.Size(177, 25);
            sterownik_ModelLabel.TabIndex = 2;
            sterownik_ModelLabel.Text = "Sterownik Model:";
            // 
            // Sterownik_DBLabel
            // 
            Sterownik_DBLabel.AutoSize = true;
            Sterownik_DBLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            Sterownik_DBLabel.Location = new System.Drawing.Point(52, 207);
            Sterownik_DBLabel.Name = "Sterownik_DBLabel";
            Sterownik_DBLabel.Size = new System.Drawing.Size(147, 25);
            Sterownik_DBLabel.TabIndex = 4;
            Sterownik_DBLabel.Text = "Sterownik DB:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            label1.Location = new System.Drawing.Point(96, 23);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(396, 25);
            label1.TabIndex = 9;
            label1.Text = "Ustawienia komunikacji ze sterownikiem";
            // 
            // sterownik_IpTextBox
            // 
            this.sterownik_IpTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "Sterownik_Ip", true));
            this.sterownik_IpTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sterownik_IpTextBox.Location = new System.Drawing.Point(221, 88);
            this.sterownik_IpTextBox.Name = "sterownik_IpTextBox";
            this.sterownik_IpTextBox.Size = new System.Drawing.Size(300, 47);
            this.sterownik_IpTextBox.TabIndex = 1;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(ITechInstrukcjeModel.Workstation);
            // 
            // setrownik_DBTextBox
            // 
            this.setrownik_DBTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "Setrownik_DB", true));
            this.setrownik_DBTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.setrownik_DBTextBox.Location = new System.Drawing.Point(221, 207);
            this.setrownik_DBTextBox.Name = "setrownik_DBTextBox";
            this.setrownik_DBTextBox.Size = new System.Drawing.Size(300, 47);
            this.setrownik_DBTextBox.TabIndex = 5;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonOk.Location = new System.Drawing.Point(405, 378);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(116, 65);
            this.buttonOk.TabIndex = 6;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonCancel.Location = new System.Drawing.Point(221, 378);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(109, 65);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Anuluj";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "Sterownik_Model", true));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(221, 147);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(300, 47);
            this.comboBox1.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(392, 260);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 65);
            this.button1.TabIndex = 10;
            this.button1.Text = "Test połączenia";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SimaticDlg
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(677, 485);
            this.Controls.Add(this.button1);
            this.Controls.Add(label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(Sterownik_DBLabel);
            this.Controls.Add(this.setrownik_DBTextBox);
            this.Controls.Add(sterownik_ModelLabel);
            this.Controls.Add(sterownik_IpLabel);
            this.Controls.Add(this.sterownik_IpTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SimaticDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Simatic";
            this.Load += new System.EventHandler(this.SimaticDlg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox sterownik_IpTextBox;
        private System.Windows.Forms.TextBox setrownik_DBTextBox;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
    }
}