namespace Intern_Aanmeldpunt_Wachtlijst.Classes.UI
{
    partial class FrmMinderjarige
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
            this.lblMinderjarige = new System.Windows.Forms.Label();
            this.lsvMinderjarige = new System.Windows.Forms.ListView();
            this.clmConsulent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDienst = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmVoorziening = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmAanmelding = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmOpneming = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOverzichtConsulent = new System.Windows.Forms.Button();
            this.btnOverzichtDienst = new System.Windows.Forms.Button();
            this.btnOverzichtVoorziening = new System.Windows.Forms.Button();
            this.btnDeleteAanmelding = new System.Windows.Forms.Button();
            this.lblAantalAanmeldingen = new System.Windows.Forms.Label();
            this.btnSetActiveAanmelding = new System.Windows.Forms.Button();
            this.clmWachttijd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lblMinderjarige
            // 
            this.lblMinderjarige.AutoSize = true;
            this.lblMinderjarige.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinderjarige.Location = new System.Drawing.Point(12, 9);
            this.lblMinderjarige.Name = "lblMinderjarige";
            this.lblMinderjarige.Size = new System.Drawing.Size(0, 20);
            this.lblMinderjarige.TabIndex = 0;
            // 
            // lsvMinderjarige
            // 
            this.lsvMinderjarige.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvMinderjarige.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmConsulent,
            this.clmDienst,
            this.clmVoorziening,
            this.clmAanmelding,
            this.clmOpneming,
            this.clmWachttijd});
            this.lsvMinderjarige.FullRowSelect = true;
            this.lsvMinderjarige.GridLines = true;
            this.lsvMinderjarige.Location = new System.Drawing.Point(16, 90);
            this.lsvMinderjarige.MultiSelect = false;
            this.lsvMinderjarige.Name = "lsvMinderjarige";
            this.lsvMinderjarige.Size = new System.Drawing.Size(762, 288);
            this.lsvMinderjarige.TabIndex = 1;
            this.lsvMinderjarige.UseCompatibleStateImageBehavior = false;
            this.lsvMinderjarige.View = System.Windows.Forms.View.Details;
            this.lsvMinderjarige.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lsvMinderjarige_ColumnClick);
            // 
            // clmConsulent
            // 
            this.clmConsulent.Text = "Aangemeld door";
            this.clmConsulent.Width = 153;
            // 
            // clmDienst
            // 
            this.clmDienst.Text = "In Dienst";
            this.clmDienst.Width = 91;
            // 
            // clmVoorziening
            // 
            this.clmVoorziening.Text = "In voorziening";
            this.clmVoorziening.Width = 143;
            // 
            // clmAanmelding
            // 
            this.clmAanmelding.Text = "Datum aanmelding";
            this.clmAanmelding.Width = 113;
            // 
            // clmOpneming
            // 
            this.clmOpneming.Text = "Datum opneming";
            this.clmOpneming.Width = 103;
            // 
            // btnOverzichtConsulent
            // 
            this.btnOverzichtConsulent.Location = new System.Drawing.Point(651, 32);
            this.btnOverzichtConsulent.Name = "btnOverzichtConsulent";
            this.btnOverzichtConsulent.Size = new System.Drawing.Size(127, 23);
            this.btnOverzichtConsulent.TabIndex = 3;
            this.btnOverzichtConsulent.Text = "Overzicht consulent";
            this.btnOverzichtConsulent.UseVisualStyleBackColor = true;
            this.btnOverzichtConsulent.Click += new System.EventHandler(this.btnOverzichtConsulent_Click);
            // 
            // btnOverzichtDienst
            // 
            this.btnOverzichtDienst.Location = new System.Drawing.Point(518, 61);
            this.btnOverzichtDienst.Name = "btnOverzichtDienst";
            this.btnOverzichtDienst.Size = new System.Drawing.Size(127, 23);
            this.btnOverzichtDienst.TabIndex = 4;
            this.btnOverzichtDienst.Text = "Overzicht dienst";
            this.btnOverzichtDienst.UseVisualStyleBackColor = true;
            this.btnOverzichtDienst.Click += new System.EventHandler(this.btnOverzichtDienst_Click);
            // 
            // btnOverzichtVoorziening
            // 
            this.btnOverzichtVoorziening.Location = new System.Drawing.Point(651, 61);
            this.btnOverzichtVoorziening.Name = "btnOverzichtVoorziening";
            this.btnOverzichtVoorziening.Size = new System.Drawing.Size(127, 23);
            this.btnOverzichtVoorziening.TabIndex = 5;
            this.btnOverzichtVoorziening.Text = "Overzicht voorziening";
            this.btnOverzichtVoorziening.UseVisualStyleBackColor = true;
            this.btnOverzichtVoorziening.Click += new System.EventHandler(this.btnOverzichtVoorziening_Click);
            // 
            // btnDeleteAanmelding
            // 
            this.btnDeleteAanmelding.Location = new System.Drawing.Point(16, 61);
            this.btnDeleteAanmelding.Name = "btnDeleteAanmelding";
            this.btnDeleteAanmelding.Size = new System.Drawing.Size(127, 23);
            this.btnDeleteAanmelding.TabIndex = 6;
            this.btnDeleteAanmelding.Text = "Aanmelding verwijderen";
            this.btnDeleteAanmelding.UseVisualStyleBackColor = true;
            this.btnDeleteAanmelding.Click += new System.EventHandler(this.btnDeleteAanmelding_Click);
            // 
            // lblAantalAanmeldingen
            // 
            this.lblAantalAanmeldingen.AutoSize = true;
            this.lblAantalAanmeldingen.Location = new System.Drawing.Point(12, 381);
            this.lblAantalAanmeldingen.Name = "lblAantalAanmeldingen";
            this.lblAantalAanmeldingen.Size = new System.Drawing.Size(109, 13);
            this.lblAantalAanmeldingen.TabIndex = 7;
            this.lblAantalAanmeldingen.Text = "Aantal aanmeldingen:";
            // 
            // btnSetActiveAanmelding
            // 
            this.btnSetActiveAanmelding.Location = new System.Drawing.Point(149, 61);
            this.btnSetActiveAanmelding.Name = "btnSetActiveAanmelding";
            this.btnSetActiveAanmelding.Size = new System.Drawing.Size(138, 23);
            this.btnSetActiveAanmelding.TabIndex = 8;
            this.btnSetActiveAanmelding.Text = "Aanmelding actief/inactief";
            this.btnSetActiveAanmelding.UseVisualStyleBackColor = true;
            this.btnSetActiveAanmelding.Click += new System.EventHandler(this.btnSetActiveAanmelding_Click);
            // 
            // clmWachttijd
            // 
            this.clmWachttijd.Text = "Tijd in registratielijst (dagen)";
            this.clmWachttijd.Width = 148;
            // 
            // FrmMinderjarige
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 403);
            this.Controls.Add(this.btnSetActiveAanmelding);
            this.Controls.Add(this.lblAantalAanmeldingen);
            this.Controls.Add(this.btnDeleteAanmelding);
            this.Controls.Add(this.btnOverzichtVoorziening);
            this.Controls.Add(this.btnOverzichtDienst);
            this.Controls.Add(this.btnOverzichtConsulent);
            this.Controls.Add(this.lsvMinderjarige);
            this.Controls.Add(this.lblMinderjarige);
            this.Name = "FrmMinderjarige";
            this.Text = "Overzicht minderjarige";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMinderjarige;
        private System.Windows.Forms.ListView lsvMinderjarige;
        private System.Windows.Forms.ColumnHeader clmConsulent;
        private System.Windows.Forms.ColumnHeader clmVoorziening;
        private System.Windows.Forms.ColumnHeader clmAanmelding;
        private System.Windows.Forms.ColumnHeader clmOpneming;
        private System.Windows.Forms.ColumnHeader clmDienst;
        private System.Windows.Forms.Button btnOverzichtConsulent;
        private System.Windows.Forms.Button btnOverzichtDienst;
        private System.Windows.Forms.Button btnOverzichtVoorziening;
        private System.Windows.Forms.Button btnDeleteAanmelding;
        private System.Windows.Forms.Label lblAantalAanmeldingen;
        private System.Windows.Forms.Button btnSetActiveAanmelding;
        private System.Windows.Forms.ColumnHeader clmWachttijd;
    }
}