namespace Intern_Aanmeldpunt_Wachtlijst.Classes.UI
{
    partial class FrmAanmeldingAanpassen
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
            this.dtpAanmelding = new System.Windows.Forms.DateTimePicker();
            this.dtpOpneming = new System.Windows.Forms.DateTimePicker();
            this.txtMinderjarigeNaam = new System.Windows.Forms.TextBox();
            this.txtMinderjarigeVoornaam = new System.Windows.Forms.TextBox();
            this.cbbDienst = new System.Windows.Forms.ComboBox();
            this.cbbConsulent = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbVoorziening = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkOpgenomen = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dtpAanmelding
            // 
            this.dtpAanmelding.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAanmelding.Location = new System.Drawing.Point(132, 145);
            this.dtpAanmelding.Name = "dtpAanmelding";
            this.dtpAanmelding.Size = new System.Drawing.Size(152, 20);
            this.dtpAanmelding.TabIndex = 0;
            this.dtpAanmelding.ValueChanged += new System.EventHandler(this.txtMinderjarigeNaam_TextChanged);
            // 
            // dtpOpneming
            // 
            this.dtpOpneming.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOpneming.Location = new System.Drawing.Point(132, 171);
            this.dtpOpneming.Name = "dtpOpneming";
            this.dtpOpneming.Size = new System.Drawing.Size(152, 20);
            this.dtpOpneming.TabIndex = 1;
            this.dtpOpneming.ValueChanged += new System.EventHandler(this.txtMinderjarigeNaam_TextChanged);
            // 
            // txtMinderjarigeNaam
            // 
            this.txtMinderjarigeNaam.Location = new System.Drawing.Point(132, 12);
            this.txtMinderjarigeNaam.Name = "txtMinderjarigeNaam";
            this.txtMinderjarigeNaam.Size = new System.Drawing.Size(152, 20);
            this.txtMinderjarigeNaam.TabIndex = 2;
            this.txtMinderjarigeNaam.TextChanged += new System.EventHandler(this.txtMinderjarigeNaam_TextChanged);
            // 
            // txtMinderjarigeVoornaam
            // 
            this.txtMinderjarigeVoornaam.Location = new System.Drawing.Point(132, 38);
            this.txtMinderjarigeVoornaam.Name = "txtMinderjarigeVoornaam";
            this.txtMinderjarigeVoornaam.Size = new System.Drawing.Size(152, 20);
            this.txtMinderjarigeVoornaam.TabIndex = 3;
            this.txtMinderjarigeVoornaam.TextChanged += new System.EventHandler(this.txtMinderjarigeNaam_TextChanged);
            // 
            // cbbDienst
            // 
            this.cbbDienst.FormattingEnabled = true;
            this.cbbDienst.Location = new System.Drawing.Point(132, 64);
            this.cbbDienst.Name = "cbbDienst";
            this.cbbDienst.Size = new System.Drawing.Size(152, 21);
            this.cbbDienst.TabIndex = 4;
            this.cbbDienst.SelectedIndexChanged += new System.EventHandler(this.txtMinderjarigeNaam_TextChanged);
            // 
            // cbbConsulent
            // 
            this.cbbConsulent.FormattingEnabled = true;
            this.cbbConsulent.Location = new System.Drawing.Point(132, 91);
            this.cbbConsulent.Name = "cbbConsulent";
            this.cbbConsulent.Size = new System.Drawing.Size(152, 21);
            this.cbbConsulent.TabIndex = 5;
            this.cbbConsulent.SelectedIndexChanged += new System.EventHandler(this.txtMinderjarigeNaam_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Naam:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Voornaam:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Dienst:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Consulent:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Voorziening:";
            // 
            // cbbVoorziening
            // 
            this.cbbVoorziening.FormattingEnabled = true;
            this.cbbVoorziening.Location = new System.Drawing.Point(132, 118);
            this.cbbVoorziening.Name = "cbbVoorziening";
            this.cbbVoorziening.Size = new System.Drawing.Size(152, 21);
            this.cbbVoorziening.TabIndex = 11;
            this.cbbVoorziening.SelectedIndexChanged += new System.EventHandler(this.txtMinderjarigeNaam_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Datum aanmelding:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Datum opneming:";
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(80, 220);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 14;
            this.BtnSave.Text = "Opslaan";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(161, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkOpgenomen
            // 
            this.chkOpgenomen.AutoSize = true;
            this.chkOpgenomen.Location = new System.Drawing.Point(132, 197);
            this.chkOpgenomen.Name = "chkOpgenomen";
            this.chkOpgenomen.Size = new System.Drawing.Size(90, 17);
            this.chkOpgenomen.TabIndex = 16;
            this.chkOpgenomen.Text = "Opgenomen?";
            this.chkOpgenomen.UseVisualStyleBackColor = true;
            this.chkOpgenomen.CheckedChanged += new System.EventHandler(this.chkOpgenomen_CheckedChanged);
            // 
            // FrmAanmeldingAanpassen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 255);
            this.Controls.Add(this.chkOpgenomen);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbbVoorziening);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbConsulent);
            this.Controls.Add(this.cbbDienst);
            this.Controls.Add(this.txtMinderjarigeVoornaam);
            this.Controls.Add(this.txtMinderjarigeNaam);
            this.Controls.Add(this.dtpOpneming);
            this.Controls.Add(this.dtpAanmelding);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmAanmeldingAanpassen";
            this.Text = "Aanmelding aanpassen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpAanmelding;
        private System.Windows.Forms.DateTimePicker dtpOpneming;
        private System.Windows.Forms.TextBox txtMinderjarigeNaam;
        private System.Windows.Forms.TextBox txtMinderjarigeVoornaam;
        private System.Windows.Forms.ComboBox cbbDienst;
        private System.Windows.Forms.ComboBox cbbConsulent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbVoorziening;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkOpgenomen;
    }
}