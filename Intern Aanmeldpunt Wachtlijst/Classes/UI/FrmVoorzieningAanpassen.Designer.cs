namespace Intern_Aanmeldpunt_Wachtlijst.Classes.UI
{
    partial class FrmVoorzieningAanpassen
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNaam = new System.Windows.Forms.TextBox();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.txtTelefoonnummer = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtContactpersoon = new System.Windows.Forms.TextBox();
            this.btnOpslaan = new System.Windows.Forms.Button();
            this.erpNaam = new System.Windows.Forms.ErrorProvider(this.components);
            this.rbtActief = new System.Windows.Forms.RadioButton();
            this.rbtNietActief = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.erpNaam)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naam:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Adres:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Emailadres:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Telefoonnummer:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Contactpersoon:";
            // 
            // txtNaam
            // 
            this.txtNaam.Location = new System.Drawing.Point(113, 19);
            this.txtNaam.Name = "txtNaam";
            this.txtNaam.Size = new System.Drawing.Size(148, 20);
            this.txtNaam.TabIndex = 6;
            this.txtNaam.TextChanged += new System.EventHandler(this.Text_TextChanged);
            // 
            // txtAdres
            // 
            this.txtAdres.Location = new System.Drawing.Point(113, 42);
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(148, 20);
            this.txtAdres.TabIndex = 7;
            this.txtAdres.TextChanged += new System.EventHandler(this.Text_TextChanged);
            // 
            // txtTelefoonnummer
            // 
            this.txtTelefoonnummer.Location = new System.Drawing.Point(113, 65);
            this.txtTelefoonnummer.Name = "txtTelefoonnummer";
            this.txtTelefoonnummer.Size = new System.Drawing.Size(148, 20);
            this.txtTelefoonnummer.TabIndex = 8;
            this.txtTelefoonnummer.TextChanged += new System.EventHandler(this.Text_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(113, 88);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(148, 20);
            this.txtEmail.TabIndex = 9;
            this.txtEmail.TextChanged += new System.EventHandler(this.Text_TextChanged);
            // 
            // txtContactpersoon
            // 
            this.txtContactpersoon.Location = new System.Drawing.Point(113, 111);
            this.txtContactpersoon.Name = "txtContactpersoon";
            this.txtContactpersoon.Size = new System.Drawing.Size(148, 20);
            this.txtContactpersoon.TabIndex = 10;
            this.txtContactpersoon.TextChanged += new System.EventHandler(this.Text_TextChanged);
            // 
            // btnOpslaan
            // 
            this.btnOpslaan.Location = new System.Drawing.Point(281, 17);
            this.btnOpslaan.Name = "btnOpslaan";
            this.btnOpslaan.Size = new System.Drawing.Size(139, 23);
            this.btnOpslaan.TabIndex = 11;
            this.btnOpslaan.Text = "Aanpassingen opslaan";
            this.btnOpslaan.UseVisualStyleBackColor = true;
            this.btnOpslaan.Click += new System.EventHandler(this.btnOpslaan_Click);
            // 
            // erpNaam
            // 
            this.erpNaam.ContainerControl = this;
            // 
            // rbtActief
            // 
            this.rbtActief.AutoSize = true;
            this.rbtActief.Location = new System.Drawing.Point(281, 46);
            this.rbtActief.Name = "rbtActief";
            this.rbtActief.Size = new System.Drawing.Size(52, 17);
            this.rbtActief.TabIndex = 12;
            this.rbtActief.TabStop = true;
            this.rbtActief.Text = "Actief";
            this.rbtActief.UseVisualStyleBackColor = true;
            this.rbtActief.CheckedChanged += new System.EventHandler(this.Radiobutton_CheckedChanged);
            // 
            // rbtNietActief
            // 
            this.rbtNietActief.AutoSize = true;
            this.rbtNietActief.Location = new System.Drawing.Point(281, 69);
            this.rbtNietActief.Name = "rbtNietActief";
            this.rbtNietActief.Size = new System.Drawing.Size(73, 17);
            this.rbtNietActief.TabIndex = 13;
            this.rbtNietActief.TabStop = true;
            this.rbtNietActief.Text = "Niet actief";
            this.rbtNietActief.UseVisualStyleBackColor = true;
            this.rbtNietActief.CheckedChanged += new System.EventHandler(this.Radiobutton_CheckedChanged);
            // 
            // FrmVoorzieningAanpassen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 142);
            this.Controls.Add(this.rbtNietActief);
            this.Controls.Add(this.rbtActief);
            this.Controls.Add(this.btnOpslaan);
            this.Controls.Add(this.txtContactpersoon);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtTelefoonnummer);
            this.Controls.Add(this.txtAdres);
            this.Controls.Add(this.txtNaam);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmVoorzieningAanpassen";
            this.Text = "Voorziening aanpassen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVoorzieningAanpassen_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.erpNaam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNaam;
        private System.Windows.Forms.TextBox txtAdres;
        private System.Windows.Forms.TextBox txtTelefoonnummer;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtContactpersoon;
        private System.Windows.Forms.Button btnOpslaan;
        private System.Windows.Forms.ErrorProvider erpNaam;
        private System.Windows.Forms.RadioButton rbtNietActief;
        private System.Windows.Forms.RadioButton rbtActief;
    }
}