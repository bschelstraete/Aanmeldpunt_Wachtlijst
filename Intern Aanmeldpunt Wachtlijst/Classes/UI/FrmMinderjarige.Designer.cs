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
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDeleteMinderjarige = new System.Windows.Forms.Button();
            this.btnOverzichtConsulent = new System.Windows.Forms.Button();
            this.btnOverzichtDienst = new System.Windows.Forms.Button();
            this.btnOverzichtVoorziening = new System.Windows.Forms.Button();
            this.btnEditAanmelding = new System.Windows.Forms.Button();
            this.lblAantalAanmeldingen = new System.Windows.Forms.Label();
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
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvMinderjarige.FullRowSelect = true;
            this.lsvMinderjarige.GridLines = true;
            this.lsvMinderjarige.Location = new System.Drawing.Point(16, 90);
            this.lsvMinderjarige.MultiSelect = false;
            this.lsvMinderjarige.Name = "lsvMinderjarige";
            this.lsvMinderjarige.Size = new System.Drawing.Size(608, 288);
            this.lsvMinderjarige.TabIndex = 1;
            this.lsvMinderjarige.UseCompatibleStateImageBehavior = false;
            this.lsvMinderjarige.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Aangemeld door";
            this.columnHeader1.Width = 153;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "In Dienst";
            this.columnHeader5.Width = 91;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "In voorziening";
            this.columnHeader2.Width = 143;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Datum aanmelding";
            this.columnHeader3.Width = 113;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Datum opneming";
            this.columnHeader4.Width = 103;
            // 
            // btnDeleteMinderjarige
            // 
            this.btnDeleteMinderjarige.Location = new System.Drawing.Point(16, 61);
            this.btnDeleteMinderjarige.Name = "btnDeleteMinderjarige";
            this.btnDeleteMinderjarige.Size = new System.Drawing.Size(131, 23);
            this.btnDeleteMinderjarige.TabIndex = 2;
            this.btnDeleteMinderjarige.Text = "Minderjarige verwijderen";
            this.btnDeleteMinderjarige.UseVisualStyleBackColor = true;
            // 
            // btnOverzichtConsulent
            // 
            this.btnOverzichtConsulent.Location = new System.Drawing.Point(497, 32);
            this.btnOverzichtConsulent.Name = "btnOverzichtConsulent";
            this.btnOverzichtConsulent.Size = new System.Drawing.Size(127, 23);
            this.btnOverzichtConsulent.TabIndex = 3;
            this.btnOverzichtConsulent.Text = "Overzicht consulent";
            this.btnOverzichtConsulent.UseVisualStyleBackColor = true;
            this.btnOverzichtConsulent.Click += new System.EventHandler(this.btnOverzichtConsulent_Click);
            // 
            // btnOverzichtDienst
            // 
            this.btnOverzichtDienst.Location = new System.Drawing.Point(364, 61);
            this.btnOverzichtDienst.Name = "btnOverzichtDienst";
            this.btnOverzichtDienst.Size = new System.Drawing.Size(127, 23);
            this.btnOverzichtDienst.TabIndex = 4;
            this.btnOverzichtDienst.Text = "Overzicht dienst";
            this.btnOverzichtDienst.UseVisualStyleBackColor = true;
            this.btnOverzichtDienst.Click += new System.EventHandler(this.btnOverzichtDienst_Click);
            // 
            // btnOverzichtVoorziening
            // 
            this.btnOverzichtVoorziening.Location = new System.Drawing.Point(497, 61);
            this.btnOverzichtVoorziening.Name = "btnOverzichtVoorziening";
            this.btnOverzichtVoorziening.Size = new System.Drawing.Size(127, 23);
            this.btnOverzichtVoorziening.TabIndex = 5;
            this.btnOverzichtVoorziening.Text = "Overzicht voorziening";
            this.btnOverzichtVoorziening.UseVisualStyleBackColor = true;
            this.btnOverzichtVoorziening.Click += new System.EventHandler(this.btnOverzichtVoorziening_Click);
            // 
            // btnEditAanmelding
            // 
            this.btnEditAanmelding.Location = new System.Drawing.Point(153, 61);
            this.btnEditAanmelding.Name = "btnEditAanmelding";
            this.btnEditAanmelding.Size = new System.Drawing.Size(127, 23);
            this.btnEditAanmelding.TabIndex = 6;
            this.btnEditAanmelding.Text = "Aanmelding bewerken";
            this.btnEditAanmelding.UseVisualStyleBackColor = true;
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
            // FrmMinderjarige
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 403);
            this.Controls.Add(this.lblAantalAanmeldingen);
            this.Controls.Add(this.btnEditAanmelding);
            this.Controls.Add(this.btnOverzichtVoorziening);
            this.Controls.Add(this.btnOverzichtDienst);
            this.Controls.Add(this.btnOverzichtConsulent);
            this.Controls.Add(this.btnDeleteMinderjarige);
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
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnDeleteMinderjarige;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnOverzichtConsulent;
        private System.Windows.Forms.Button btnOverzichtDienst;
        private System.Windows.Forms.Button btnOverzichtVoorziening;
        private System.Windows.Forms.Button btnEditAanmelding;
        private System.Windows.Forms.Label lblAantalAanmeldingen;
    }
}