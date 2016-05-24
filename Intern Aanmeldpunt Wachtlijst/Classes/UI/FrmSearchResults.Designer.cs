namespace Intern_Aanmeldpunt_Wachtlijst.Classes.UI
{
    partial class FrmSearchResults
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
            this.lsvResults = new System.Windows.Forms.ListView();
            this.clmNaam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmVoornaam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblResults = new System.Windows.Forms.Label();
            this.btnOpenMJ = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsvResults
            // 
            this.lsvResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmNaam,
            this.clmVoornaam});
            this.lsvResults.FullRowSelect = true;
            this.lsvResults.GridLines = true;
            this.lsvResults.Location = new System.Drawing.Point(12, 47);
            this.lsvResults.MultiSelect = false;
            this.lsvResults.Name = "lsvResults";
            this.lsvResults.Size = new System.Drawing.Size(437, 246);
            this.lsvResults.TabIndex = 0;
            this.lsvResults.UseCompatibleStateImageBehavior = false;
            this.lsvResults.View = System.Windows.Forms.View.Details;
            // 
            // clmNaam
            // 
            this.clmNaam.Text = "Naam";
            this.clmNaam.Width = 177;
            // 
            // clmVoornaam
            // 
            this.clmVoornaam.Text = "Voornaam";
            this.clmVoornaam.Width = 199;
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResults.Location = new System.Drawing.Point(12, 9);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(148, 18);
            this.lblResults.TabIndex = 1;
            this.lblResults.Text = "Zoekresultaten voor: ";
            // 
            // btnOpenMJ
            // 
            this.btnOpenMJ.Location = new System.Drawing.Point(325, 18);
            this.btnOpenMJ.Name = "btnOpenMJ";
            this.btnOpenMJ.Size = new System.Drawing.Size(124, 23);
            this.btnOpenMJ.TabIndex = 2;
            this.btnOpenMJ.Text = "Overzicht Minderjarige";
            this.btnOpenMJ.UseVisualStyleBackColor = true;
            this.btnOpenMJ.Click += new System.EventHandler(this.btnOpenMJ_Click);
            // 
            // FrmSearchResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 305);
            this.Controls.Add(this.btnOpenMJ);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.lsvResults);
            this.Name = "FrmSearchResults";
            this.Text = "Zoekresultaten";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsvResults;
        private System.Windows.Forms.ColumnHeader clmNaam;
        private System.Windows.Forms.ColumnHeader clmVoornaam;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Button btnOpenMJ;
    }
}