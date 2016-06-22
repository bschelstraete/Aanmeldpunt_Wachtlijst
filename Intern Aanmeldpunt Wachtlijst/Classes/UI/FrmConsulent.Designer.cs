namespace Intern_Aanmeldpunt_Wachtlijst.Classes.UI
{
    partial class FrmConsulent
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
            this.lsvOverzicht = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmWachttijd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblConsulent = new System.Windows.Forms.Label();
            this.btnOverzichtVoorziening = new System.Windows.Forms.Button();
            this.btnOverzichtMinderjarige = new System.Windows.Forms.Button();
            this.lblAantalMinderjarigen = new System.Windows.Forms.Label();
            this.btnEditConsulent = new System.Windows.Forms.Button();
            this.btnAanmeldingAanpassen = new System.Windows.Forms.Button();
            this.btnSetActiveAanmelding = new System.Windows.Forms.Button();
            this.btnDeleteAanmelding = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsvOverzicht
            // 
            this.lsvOverzicht.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvOverzicht.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.clmWachttijd});
            this.lsvOverzicht.FullRowSelect = true;
            this.lsvOverzicht.GridLines = true;
            this.lsvOverzicht.Location = new System.Drawing.Point(12, 98);
            this.lsvOverzicht.MultiSelect = false;
            this.lsvOverzicht.Name = "lsvOverzicht";
            this.lsvOverzicht.Size = new System.Drawing.Size(693, 275);
            this.lsvOverzicht.TabIndex = 0;
            this.lsvOverzicht.UseCompatibleStateImageBehavior = false;
            this.lsvOverzicht.View = System.Windows.Forms.View.Details;
            this.lsvOverzicht.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lsvOverzicht_ColumnClick);
            this.lsvOverzicht.DoubleClick += new System.EventHandler(this.lsvOverzicht_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Minderjarige";
            this.columnHeader1.Width = 141;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Voorziening";
            this.columnHeader2.Width = 158;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Datum aanmelding";
            this.columnHeader3.Width = 128;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Datum opneming";
            this.columnHeader4.Width = 120;
            // 
            // clmWachttijd
            // 
            this.clmWachttijd.Text = "Tijd in registratielijst (dagen)";
            this.clmWachttijd.Width = 141;
            // 
            // lblConsulent
            // 
            this.lblConsulent.AutoSize = true;
            this.lblConsulent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsulent.Location = new System.Drawing.Point(12, 9);
            this.lblConsulent.Name = "lblConsulent";
            this.lblConsulent.Size = new System.Drawing.Size(0, 20);
            this.lblConsulent.TabIndex = 1;
            // 
            // btnOverzichtVoorziening
            // 
            this.btnOverzichtVoorziening.Location = new System.Drawing.Point(580, 68);
            this.btnOverzichtVoorziening.Name = "btnOverzichtVoorziening";
            this.btnOverzichtVoorziening.Size = new System.Drawing.Size(125, 23);
            this.btnOverzichtVoorziening.TabIndex = 2;
            this.btnOverzichtVoorziening.Text = "Overzicht voorziening";
            this.btnOverzichtVoorziening.UseVisualStyleBackColor = true;
            this.btnOverzichtVoorziening.Click += new System.EventHandler(this.btnOverzichtVoorziening_Click);
            // 
            // btnOverzichtMinderjarige
            // 
            this.btnOverzichtMinderjarige.Location = new System.Drawing.Point(451, 68);
            this.btnOverzichtMinderjarige.Name = "btnOverzichtMinderjarige";
            this.btnOverzichtMinderjarige.Size = new System.Drawing.Size(123, 23);
            this.btnOverzichtMinderjarige.TabIndex = 3;
            this.btnOverzichtMinderjarige.Text = "Overzicht minderjarige";
            this.btnOverzichtMinderjarige.UseVisualStyleBackColor = true;
            this.btnOverzichtMinderjarige.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblAantalMinderjarigen
            // 
            this.lblAantalMinderjarigen.AutoSize = true;
            this.lblAantalMinderjarigen.Location = new System.Drawing.Point(13, 73);
            this.lblAantalMinderjarigen.Name = "lblAantalMinderjarigen";
            this.lblAantalMinderjarigen.Size = new System.Drawing.Size(165, 13);
            this.lblAantalMinderjarigen.TabIndex = 4;
            this.lblAantalMinderjarigen.Text = "Aantal minderjarigen in wachtlijst: ";
            // 
            // btnEditConsulent
            // 
            this.btnEditConsulent.Location = new System.Drawing.Point(582, 379);
            this.btnEditConsulent.Name = "btnEditConsulent";
            this.btnEditConsulent.Size = new System.Drawing.Size(123, 23);
            this.btnEditConsulent.TabIndex = 5;
            this.btnEditConsulent.Text = "Consulent aanpassen";
            this.btnEditConsulent.UseVisualStyleBackColor = true;
            this.btnEditConsulent.Click += new System.EventHandler(this.btnEditConsulent_Click);
            // 
            // btnAanmeldingAanpassen
            // 
            this.btnAanmeldingAanpassen.Location = new System.Drawing.Point(12, 379);
            this.btnAanmeldingAanpassen.Name = "btnAanmeldingAanpassen";
            this.btnAanmeldingAanpassen.Size = new System.Drawing.Size(135, 23);
            this.btnAanmeldingAanpassen.TabIndex = 18;
            this.btnAanmeldingAanpassen.Text = "Aanmelding aanpassen";
            this.btnAanmeldingAanpassen.UseVisualStyleBackColor = true;
            this.btnAanmeldingAanpassen.Click += new System.EventHandler(this.btnAanmeldingAanpassen_Click);
            // 
            // btnSetActiveAanmelding
            // 
            this.btnSetActiveAanmelding.Location = new System.Drawing.Point(153, 379);
            this.btnSetActiveAanmelding.Name = "btnSetActiveAanmelding";
            this.btnSetActiveAanmelding.Size = new System.Drawing.Size(138, 23);
            this.btnSetActiveAanmelding.TabIndex = 17;
            this.btnSetActiveAanmelding.Text = "Aanmelding actief/inactief";
            this.btnSetActiveAanmelding.UseVisualStyleBackColor = true;
            this.btnSetActiveAanmelding.Click += new System.EventHandler(this.btnSetActiveAanmelding_Click);
            // 
            // btnDeleteAanmelding
            // 
            this.btnDeleteAanmelding.Location = new System.Drawing.Point(297, 379);
            this.btnDeleteAanmelding.Name = "btnDeleteAanmelding";
            this.btnDeleteAanmelding.Size = new System.Drawing.Size(127, 23);
            this.btnDeleteAanmelding.TabIndex = 16;
            this.btnDeleteAanmelding.Text = "Aanmelding verwijderen";
            this.btnDeleteAanmelding.UseVisualStyleBackColor = true;
            this.btnDeleteAanmelding.Click += new System.EventHandler(this.btnDeleteAanmelding_Click);
            // 
            // FrmConsulent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 410);
            this.Controls.Add(this.btnAanmeldingAanpassen);
            this.Controls.Add(this.btnSetActiveAanmelding);
            this.Controls.Add(this.btnDeleteAanmelding);
            this.Controls.Add(this.btnEditConsulent);
            this.Controls.Add(this.lblAantalMinderjarigen);
            this.Controls.Add(this.btnOverzichtMinderjarige);
            this.Controls.Add(this.btnOverzichtVoorziening);
            this.Controls.Add(this.lblConsulent);
            this.Controls.Add(this.lsvOverzicht);
            this.Name = "FrmConsulent";
            this.Text = "Overzicht Consulent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsvOverzicht;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label lblConsulent;
        private System.Windows.Forms.Button btnOverzichtVoorziening;
        private System.Windows.Forms.Button btnOverzichtMinderjarige;
        private System.Windows.Forms.Label lblAantalMinderjarigen;
        private System.Windows.Forms.ColumnHeader clmWachttijd;
        private System.Windows.Forms.Button btnEditConsulent;
        private System.Windows.Forms.Button btnAanmeldingAanpassen;
        private System.Windows.Forms.Button btnSetActiveAanmelding;
        private System.Windows.Forms.Button btnDeleteAanmelding;
    }
}