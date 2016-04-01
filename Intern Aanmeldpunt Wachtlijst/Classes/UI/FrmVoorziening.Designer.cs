namespace Intern_Aanmeldpunt_Wachtlijst.Classes.UI
{
    partial class FrmVoorziening
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
            this.lsvVoorziening = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblVoorziening = new System.Windows.Forms.Label();
            this.btnVoorzieningAanpassen = new System.Windows.Forms.Button();
            this.btnOverzichtMJ = new System.Windows.Forms.Button();
            this.btnOverzichtConsulent = new System.Windows.Forms.Button();
            this.lblAantalminderjarige = new System.Windows.Forms.Label();
            this.lblAverageWachttijd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lsvVoorziening
            // 
            this.lsvVoorziening.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvVoorziening.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lsvVoorziening.FullRowSelect = true;
            this.lsvVoorziening.GridLines = true;
            this.lsvVoorziening.Location = new System.Drawing.Point(12, 84);
            this.lsvVoorziening.MultiSelect = false;
            this.lsvVoorziening.Name = "lsvVoorziening";
            this.lsvVoorziening.Size = new System.Drawing.Size(578, 300);
            this.lsvVoorziening.TabIndex = 0;
            this.lsvVoorziening.UseCompatibleStateImageBehavior = false;
            this.lsvVoorziening.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Minderjarige";
            this.columnHeader1.Width = 111;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Consulent";
            this.columnHeader2.Width = 169;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Aanmelddatum";
            this.columnHeader3.Width = 98;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Opnemingdatum";
            this.columnHeader4.Width = 94;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Wachtijd (dagen)";
            this.columnHeader5.Width = 95;
            // 
            // lblVoorziening
            // 
            this.lblVoorziening.AutoSize = true;
            this.lblVoorziening.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoorziening.Location = new System.Drawing.Point(12, 9);
            this.lblVoorziening.Name = "lblVoorziening";
            this.lblVoorziening.Size = new System.Drawing.Size(0, 20);
            this.lblVoorziening.TabIndex = 1;
            // 
            // btnVoorzieningAanpassen
            // 
            this.btnVoorzieningAanpassen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVoorzieningAanpassen.Location = new System.Drawing.Point(12, 55);
            this.btnVoorzieningAanpassen.Name = "btnVoorzieningAanpassen";
            this.btnVoorzieningAanpassen.Size = new System.Drawing.Size(126, 23);
            this.btnVoorzieningAanpassen.TabIndex = 2;
            this.btnVoorzieningAanpassen.Text = "Voorziening aanpassen";
            this.btnVoorzieningAanpassen.UseVisualStyleBackColor = true;
            this.btnVoorzieningAanpassen.Click += new System.EventHandler(this.btnVoorzieningAanpassen_Click);
            // 
            // btnOverzichtMJ
            // 
            this.btnOverzichtMJ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOverzichtMJ.Location = new System.Drawing.Point(344, 55);
            this.btnOverzichtMJ.Name = "btnOverzichtMJ";
            this.btnOverzichtMJ.Size = new System.Drawing.Size(126, 23);
            this.btnOverzichtMJ.TabIndex = 3;
            this.btnOverzichtMJ.Text = "Overzicht minderjarige";
            this.btnOverzichtMJ.UseVisualStyleBackColor = true;
            this.btnOverzichtMJ.Click += new System.EventHandler(this.btnOverzichtMJ_Click);
            // 
            // btnOverzichtConsulent
            // 
            this.btnOverzichtConsulent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOverzichtConsulent.Location = new System.Drawing.Point(476, 55);
            this.btnOverzichtConsulent.Name = "btnOverzichtConsulent";
            this.btnOverzichtConsulent.Size = new System.Drawing.Size(114, 23);
            this.btnOverzichtConsulent.TabIndex = 4;
            this.btnOverzichtConsulent.Text = "Overzicht consulent";
            this.btnOverzichtConsulent.UseVisualStyleBackColor = true;
            this.btnOverzichtConsulent.Click += new System.EventHandler(this.btnOverzichtConsulent_Click);
            // 
            // lblAantalminderjarige
            // 
            this.lblAantalminderjarige.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAantalminderjarige.AutoSize = true;
            this.lblAantalminderjarige.Location = new System.Drawing.Point(12, 387);
            this.lblAantalminderjarige.Name = "lblAantalminderjarige";
            this.lblAantalminderjarige.Size = new System.Drawing.Size(165, 13);
            this.lblAantalminderjarige.TabIndex = 5;
            this.lblAantalminderjarige.Text = "Aantal minderjarigen in wachtlijst: ";
            // 
            // lblAverageWachttijd
            // 
            this.lblAverageWachttijd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAverageWachttijd.AutoSize = true;
            this.lblAverageWachttijd.Location = new System.Drawing.Point(341, 387);
            this.lblAverageWachttijd.Name = "lblAverageWachttijd";
            this.lblAverageWachttijd.Size = new System.Drawing.Size(182, 13);
            this.lblAverageWachttijd.TabIndex = 6;
            this.lblAverageWachttijd.Text = "Gemiddelde wachttijd in voorziening: ";
            // 
            // FrmVoorziening
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 409);
            this.Controls.Add(this.lblAverageWachttijd);
            this.Controls.Add(this.lblAantalminderjarige);
            this.Controls.Add(this.btnOverzichtConsulent);
            this.Controls.Add(this.btnOverzichtMJ);
            this.Controls.Add(this.btnVoorzieningAanpassen);
            this.Controls.Add(this.lblVoorziening);
            this.Controls.Add(this.lsvVoorziening);
            this.Name = "FrmVoorziening";
            this.Text = "Overzicht voorziening";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsvVoorziening;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label lblVoorziening;
        private System.Windows.Forms.Button btnVoorzieningAanpassen;
        private System.Windows.Forms.Button btnOverzichtMJ;
        private System.Windows.Forms.Button btnOverzichtConsulent;
        private System.Windows.Forms.Label lblAantalminderjarige;
        private System.Windows.Forms.Label lblAverageWachttijd;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}