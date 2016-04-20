namespace Intern_Aanmeldpunt_Wachtlijst.Classes.UI
{
    partial class FrmConsulentAanpassen
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
            this.btnOpslaan = new System.Windows.Forms.Button();
            this.txtVoornaam = new System.Windows.Forms.TextBox();
            this.txtNaam = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.erpNaam = new System.Windows.Forms.ErrorProvider(this.components);
            this.rbtNietActief = new System.Windows.Forms.RadioButton();
            this.rbtActief = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.erpNaam)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpslaan
            // 
            this.btnOpslaan.Location = new System.Drawing.Point(247, 12);
            this.btnOpslaan.Name = "btnOpslaan";
            this.btnOpslaan.Size = new System.Drawing.Size(139, 23);
            this.btnOpslaan.TabIndex = 24;
            this.btnOpslaan.Text = "Opslaan";
            this.btnOpslaan.UseVisualStyleBackColor = true;
            this.btnOpslaan.Click += new System.EventHandler(this.btnOpslaan_Click);
            // 
            // txtVoornaam
            // 
            this.txtVoornaam.Location = new System.Drawing.Point(79, 37);
            this.txtVoornaam.Name = "txtVoornaam";
            this.txtVoornaam.Size = new System.Drawing.Size(148, 20);
            this.txtVoornaam.TabIndex = 20;
            // 
            // txtNaam
            // 
            this.txtNaam.Location = new System.Drawing.Point(79, 14);
            this.txtNaam.Name = "txtNaam";
            this.txtNaam.Size = new System.Drawing.Size(148, 20);
            this.txtNaam.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Voornaam:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Naam:";
            // 
            // erpNaam
            // 
            this.erpNaam.ContainerControl = this;
            // 
            // rbtNietActief
            // 
            this.rbtNietActief.AutoSize = true;
            this.rbtNietActief.Location = new System.Drawing.Point(247, 64);
            this.rbtNietActief.Name = "rbtNietActief";
            this.rbtNietActief.Size = new System.Drawing.Size(73, 17);
            this.rbtNietActief.TabIndex = 26;
            this.rbtNietActief.TabStop = true;
            this.rbtNietActief.Text = "Niet actief";
            this.rbtNietActief.UseVisualStyleBackColor = true;
            // 
            // rbtActief
            // 
            this.rbtActief.AutoSize = true;
            this.rbtActief.Location = new System.Drawing.Point(247, 41);
            this.rbtActief.Name = "rbtActief";
            this.rbtActief.Size = new System.Drawing.Size(52, 17);
            this.rbtActief.TabIndex = 25;
            this.rbtActief.TabStop = true;
            this.rbtActief.Text = "Actief";
            this.rbtActief.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(79, 60);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(148, 21);
            this.comboBox1.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Dienst:";
            // 
            // FrmConsulentAanpassen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 97);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnOpslaan);
            this.Controls.Add(this.txtVoornaam);
            this.Controls.Add(this.txtNaam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbtNietActief);
            this.Controls.Add(this.rbtActief);
            this.Name = "FrmConsulentAanpassen";
            this.Text = "Consulent aanpassen";
            ((System.ComponentModel.ISupportInitialize)(this.erpNaam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpslaan;
        private System.Windows.Forms.TextBox txtVoornaam;
        private System.Windows.Forms.TextBox txtNaam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider erpNaam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton rbtNietActief;
        private System.Windows.Forms.RadioButton rbtActief;
    }
}