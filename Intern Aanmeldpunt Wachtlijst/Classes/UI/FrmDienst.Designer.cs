namespace Intern_Aanmeldpunt_Wachtlijst.Classes.UI
{
    partial class FrmDienst
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
            this.lblOverzicht = new System.Windows.Forms.Label();
            this.lsvDienstOverzicht = new System.Windows.Forms.ListView();
            this.clmMinderjarige = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClmAanmelder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClmVoorziening = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOpenMinderjarige = new System.Windows.Forms.Button();
            this.btnOpenVoorziening = new System.Windows.Forms.Button();
            this.btnOpenConsulent = new System.Windows.Forms.Button();
            this.lblAantalAanmeldingen = new System.Windows.Forms.Label();
            this.lblAverageWachttijd = new System.Windows.Forms.Label();
            this.btnSetActiveAanmelding = new System.Windows.Forms.Button();
            this.btnDeleteAanmelding = new System.Windows.Forms.Button();
            this.clmWachttijd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lblOverzicht
            // 
            this.lblOverzicht.AutoSize = true;
            this.lblOverzicht.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverzicht.Location = new System.Drawing.Point(12, 9);
            this.lblOverzicht.Name = "lblOverzicht";
            this.lblOverzicht.Size = new System.Drawing.Size(0, 20);
            this.lblOverzicht.TabIndex = 0;
            // 
            // lsvDienstOverzicht
            // 
            this.lsvDienstOverzicht.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvDienstOverzicht.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmMinderjarige,
            this.ClmAanmelder,
            this.ClmVoorziening,
            this.columnHeader1,
            this.columnHeader2,
            this.clmWachttijd});
            this.lsvDienstOverzicht.FullRowSelect = true;
            this.lsvDienstOverzicht.GridLines = true;
            this.lsvDienstOverzicht.Location = new System.Drawing.Point(12, 80);
            this.lsvDienstOverzicht.MultiSelect = false;
            this.lsvDienstOverzicht.Name = "lsvDienstOverzicht";
            this.lsvDienstOverzicht.Size = new System.Drawing.Size(814, 327);
            this.lsvDienstOverzicht.TabIndex = 1;
            this.lsvDienstOverzicht.UseCompatibleStateImageBehavior = false;
            this.lsvDienstOverzicht.View = System.Windows.Forms.View.Details;
            this.lsvDienstOverzicht.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lsvDienstOverzicht_ColumnClick);
            this.lsvDienstOverzicht.DoubleClick += new System.EventHandler(this.lsvDienstOverzicht_DoubleClick);
            // 
            // clmMinderjarige
            // 
            this.clmMinderjarige.Text = "Minderjarige";
            this.clmMinderjarige.Width = 147;
            // 
            // ClmAanmelder
            // 
            this.ClmAanmelder.Text = "Aanmelder";
            this.ClmAanmelder.Width = 116;
            // 
            // ClmVoorziening
            // 
            this.ClmVoorziening.Text = "Voorziening";
            this.ClmVoorziening.Width = 144;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Datum aanmelding";
            this.columnHeader1.Width = 139;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Datum opneming";
            this.columnHeader2.Width = 116;
            // 
            // btnOpenMinderjarige
            // 
            this.btnOpenMinderjarige.Location = new System.Drawing.Point(689, 22);
            this.btnOpenMinderjarige.Name = "btnOpenMinderjarige";
            this.btnOpenMinderjarige.Size = new System.Drawing.Size(137, 23);
            this.btnOpenMinderjarige.TabIndex = 2;
            this.btnOpenMinderjarige.Text = "Overzicht minderjarige";
            this.btnOpenMinderjarige.UseVisualStyleBackColor = true;
            this.btnOpenMinderjarige.Click += new System.EventHandler(this.btnOpenMinderjarige_Click);
            // 
            // btnOpenVoorziening
            // 
            this.btnOpenVoorziening.Location = new System.Drawing.Point(551, 51);
            this.btnOpenVoorziening.Name = "btnOpenVoorziening";
            this.btnOpenVoorziening.Size = new System.Drawing.Size(132, 23);
            this.btnOpenVoorziening.TabIndex = 4;
            this.btnOpenVoorziening.Text = "Overzicht voorziening";
            this.btnOpenVoorziening.UseVisualStyleBackColor = true;
            this.btnOpenVoorziening.Click += new System.EventHandler(this.btnOpenVoorziening_Click);
            // 
            // btnOpenConsulent
            // 
            this.btnOpenConsulent.Location = new System.Drawing.Point(689, 51);
            this.btnOpenConsulent.Name = "btnOpenConsulent";
            this.btnOpenConsulent.Size = new System.Drawing.Size(137, 23);
            this.btnOpenConsulent.TabIndex = 5;
            this.btnOpenConsulent.Text = "Overzicht Consulent";
            this.btnOpenConsulent.UseVisualStyleBackColor = true;
            this.btnOpenConsulent.Click += new System.EventHandler(this.btnOpenConsulent_Click);
            // 
            // lblAantalAanmeldingen
            // 
            this.lblAantalAanmeldingen.AutoSize = true;
            this.lblAantalAanmeldingen.Location = new System.Drawing.Point(13, 417);
            this.lblAantalAanmeldingen.Name = "lblAantalAanmeldingen";
            this.lblAantalAanmeldingen.Size = new System.Drawing.Size(165, 13);
            this.lblAantalAanmeldingen.TabIndex = 6;
            this.lblAantalAanmeldingen.Text = "Aantal minderjarigen in wachtlijst: ";
            // 
            // lblAverageWachttijd
            // 
            this.lblAverageWachttijd.AutoSize = true;
            this.lblAverageWachttijd.Location = new System.Drawing.Point(261, 417);
            this.lblAverageWachttijd.Name = "lblAverageWachttijd";
            this.lblAverageWachttijd.Size = new System.Drawing.Size(114, 13);
            this.lblAverageWachttijd.TabIndex = 7;
            this.lblAverageWachttijd.Text = "Gemiddelde wachttijd: ";
            // 
            // btnSetActiveAanmelding
            // 
            this.btnSetActiveAanmelding.Location = new System.Drawing.Point(145, 51);
            this.btnSetActiveAanmelding.Name = "btnSetActiveAanmelding";
            this.btnSetActiveAanmelding.Size = new System.Drawing.Size(138, 23);
            this.btnSetActiveAanmelding.TabIndex = 10;
            this.btnSetActiveAanmelding.Text = "Aanmelding actief/inactief";
            this.btnSetActiveAanmelding.UseVisualStyleBackColor = true;
            this.btnSetActiveAanmelding.Click += new System.EventHandler(this.btnSetActiveAanmelding_Click);
            // 
            // btnDeleteAanmelding
            // 
            this.btnDeleteAanmelding.Location = new System.Drawing.Point(12, 51);
            this.btnDeleteAanmelding.Name = "btnDeleteAanmelding";
            this.btnDeleteAanmelding.Size = new System.Drawing.Size(127, 23);
            this.btnDeleteAanmelding.TabIndex = 9;
            this.btnDeleteAanmelding.Text = "Aanmelding verwijderen";
            this.btnDeleteAanmelding.UseVisualStyleBackColor = true;
            this.btnDeleteAanmelding.Click += new System.EventHandler(this.btnDeleteAanmelding_Click);
            // 
            // clmWachttijd
            // 
            this.clmWachttijd.Text = "Tijd in registratielijst (dagen)";
            this.clmWachttijd.Width = 142;
            // 
            // FrmDienst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 439);
            this.Controls.Add(this.btnSetActiveAanmelding);
            this.Controls.Add(this.btnDeleteAanmelding);
            this.Controls.Add(this.lblAverageWachttijd);
            this.Controls.Add(this.lblAantalAanmeldingen);
            this.Controls.Add(this.btnOpenConsulent);
            this.Controls.Add(this.btnOpenVoorziening);
            this.Controls.Add(this.btnOpenMinderjarige);
            this.Controls.Add(this.lsvDienstOverzicht);
            this.Controls.Add(this.lblOverzicht);
            this.Name = "FrmDienst";
            this.Text = "Overzicht Dienst";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOverzicht;
        private System.Windows.Forms.ListView lsvDienstOverzicht;
        private System.Windows.Forms.ColumnHeader clmMinderjarige;
        private System.Windows.Forms.ColumnHeader ClmAanmelder;
        private System.Windows.Forms.ColumnHeader ClmVoorziening;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnOpenMinderjarige;
        private System.Windows.Forms.Button btnOpenVoorziening;
        private System.Windows.Forms.Button btnOpenConsulent;
        private System.Windows.Forms.Label lblAantalAanmeldingen;
        private System.Windows.Forms.Label lblAverageWachttijd;
        private System.Windows.Forms.Button btnSetActiveAanmelding;
        private System.Windows.Forms.Button btnDeleteAanmelding;
        private System.Windows.Forms.ColumnHeader clmWachttijd;
    }
}