namespace Intern_Aanmeldpunt_Wachtlijst.Classes.UI
{
    partial class FrmStatistics
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dtpVan = new System.Windows.Forms.DateTimePicker();
            this.dtpTot = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnToepassen = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblAanmeldingen = new System.Windows.Forms.Label();
            this.splContainerAanmeldingen = new System.Windows.Forms.SplitContainer();
            this.spcAanmeldingen = new System.Windows.Forms.SplitContainer();
            this.chtDiensten = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chtVoorzieningen = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.spcWachttijd = new System.Windows.Forms.SplitContainer();
            this.chtWachttijdDienst = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chtWachttijdVoorziening = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.splContainerAanmeldingen)).BeginInit();
            this.splContainerAanmeldingen.Panel1.SuspendLayout();
            this.splContainerAanmeldingen.Panel2.SuspendLayout();
            this.splContainerAanmeldingen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcAanmeldingen)).BeginInit();
            this.spcAanmeldingen.Panel1.SuspendLayout();
            this.spcAanmeldingen.Panel2.SuspendLayout();
            this.spcAanmeldingen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtDiensten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtVoorzieningen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcWachttijd)).BeginInit();
            this.spcWachttijd.Panel1.SuspendLayout();
            this.spcWachttijd.Panel2.SuspendLayout();
            this.spcWachttijd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtWachttijdDienst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtWachttijdVoorziening)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpVan
            // 
            this.dtpVan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVan.Location = new System.Drawing.Point(142, 19);
            this.dtpVan.Name = "dtpVan";
            this.dtpVan.Size = new System.Drawing.Size(92, 20);
            this.dtpVan.TabIndex = 5;
            // 
            // dtpTot
            // 
            this.dtpTot.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTot.Location = new System.Drawing.Point(300, 19);
            this.dtpTot.Name = "dtpTot";
            this.dtpTot.Size = new System.Drawing.Size(97, 20);
            this.dtpTot.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Selecteer periode: Van";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "tot en met";
            // 
            // btnToepassen
            // 
            this.btnToepassen.Location = new System.Drawing.Point(403, 16);
            this.btnToepassen.Name = "btnToepassen";
            this.btnToepassen.Size = new System.Drawing.Size(75, 23);
            this.btnToepassen.TabIndex = 9;
            this.btnToepassen.Text = "Toepassen";
            this.btnToepassen.UseVisualStyleBackColor = true;
            this.btnToepassen.Click += new System.EventHandler(this.btnToepassen_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(484, 16);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // lblAanmeldingen
            // 
            this.lblAanmeldingen.AutoSize = true;
            this.lblAanmeldingen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAanmeldingen.Location = new System.Drawing.Point(12, 49);
            this.lblAanmeldingen.Name = "lblAanmeldingen";
            this.lblAanmeldingen.Size = new System.Drawing.Size(175, 13);
            this.lblAanmeldingen.TabIndex = 11;
            this.lblAanmeldingen.Text = "Statistieken i.v.m. Aanmeldingen    -";
            this.lblAanmeldingen.Click += new System.EventHandler(this.lblAanmeldingen_Click);
            // 
            // splContainerAanmeldingen
            // 
            this.splContainerAanmeldingen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splContainerAanmeldingen.Location = new System.Drawing.Point(12, 65);
            this.splContainerAanmeldingen.Name = "splContainerAanmeldingen";
            this.splContainerAanmeldingen.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splContainerAanmeldingen.Panel1
            // 
            this.splContainerAanmeldingen.Panel1.Controls.Add(this.spcAanmeldingen);
            // 
            // splContainerAanmeldingen.Panel2
            // 
            this.splContainerAanmeldingen.Panel2.Controls.Add(this.spcWachttijd);
            this.splContainerAanmeldingen.Size = new System.Drawing.Size(990, 588);
            this.splContainerAanmeldingen.SplitterDistance = 307;
            this.splContainerAanmeldingen.TabIndex = 4;
            // 
            // spcAanmeldingen
            // 
            this.spcAanmeldingen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spcAanmeldingen.Location = new System.Drawing.Point(3, 3);
            this.spcAanmeldingen.Name = "spcAanmeldingen";
            // 
            // spcAanmeldingen.Panel1
            // 
            this.spcAanmeldingen.Panel1.Controls.Add(this.chtDiensten);
            // 
            // spcAanmeldingen.Panel2
            // 
            this.spcAanmeldingen.Panel2.Controls.Add(this.chtVoorzieningen);
            this.spcAanmeldingen.Size = new System.Drawing.Size(960, 301);
            this.spcAanmeldingen.SplitterDistance = 461;
            this.spcAanmeldingen.TabIndex = 2;
            // 
            // chtDiensten
            // 
            this.chtDiensten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chtDiensten.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chtDiensten.Legends.Add(legend1);
            this.chtDiensten.Location = new System.Drawing.Point(3, 3);
            this.chtDiensten.Name = "chtDiensten";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chtDiensten.Series.Add(series1);
            this.chtDiensten.Size = new System.Drawing.Size(443, 295);
            this.chtDiensten.TabIndex = 0;
            this.chtDiensten.Text = "chart1";
            // 
            // chtVoorzieningen
            // 
            this.chtVoorzieningen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chtVoorzieningen.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chtVoorzieningen.Legends.Add(legend2);
            this.chtVoorzieningen.Location = new System.Drawing.Point(3, 3);
            this.chtVoorzieningen.Name = "chtVoorzieningen";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chtVoorzieningen.Series.Add(series2);
            this.chtVoorzieningen.Size = new System.Drawing.Size(477, 295);
            this.chtVoorzieningen.TabIndex = 0;
            this.chtVoorzieningen.Text = "chart1";
            // 
            // spcWachttijd
            // 
            this.spcWachttijd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spcWachttijd.Location = new System.Drawing.Point(3, 3);
            this.spcWachttijd.Name = "spcWachttijd";
            // 
            // spcWachttijd.Panel1
            // 
            this.spcWachttijd.Panel1.Controls.Add(this.chtWachttijdDienst);
            // 
            // spcWachttijd.Panel2
            // 
            this.spcWachttijd.Panel2.Controls.Add(this.chtWachttijdVoorziening);
            this.spcWachttijd.Size = new System.Drawing.Size(960, 271);
            this.spcWachttijd.SplitterDistance = 464;
            this.spcWachttijd.TabIndex = 3;
            // 
            // chtWachttijdDienst
            // 
            this.chtWachttijdDienst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.chtWachttijdDienst.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chtWachttijdDienst.Legends.Add(legend3);
            this.chtWachttijdDienst.Location = new System.Drawing.Point(3, 3);
            this.chtWachttijdDienst.Name = "chtWachttijdDienst";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chtWachttijdDienst.Series.Add(series3);
            this.chtWachttijdDienst.Size = new System.Drawing.Size(445, 265);
            this.chtWachttijdDienst.TabIndex = 0;
            this.chtWachttijdDienst.Text = "chart1";
            // 
            // chtWachttijdVoorziening
            // 
            this.chtWachttijdVoorziening.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea4.Name = "ChartArea1";
            this.chtWachttijdVoorziening.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chtWachttijdVoorziening.Legends.Add(legend4);
            this.chtWachttijdVoorziening.Location = new System.Drawing.Point(5, 3);
            this.chtWachttijdVoorziening.Name = "chtWachttijdVoorziening";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chtWachttijdVoorziening.Series.Add(series4);
            this.chtWachttijdVoorziening.Size = new System.Drawing.Size(471, 265);
            this.chtWachttijdVoorziening.TabIndex = 1;
            this.chtWachttijdVoorziening.Text = "chart1";
            // 
            // FrmStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1020, 658);
            this.Controls.Add(this.splContainerAanmeldingen);
            this.Controls.Add(this.lblAanmeldingen);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnToepassen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpTot);
            this.Controls.Add(this.dtpVan);
            this.Name = "FrmStatistics";
            this.Text = "FrmStatistics";
            this.splContainerAanmeldingen.Panel1.ResumeLayout(false);
            this.splContainerAanmeldingen.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splContainerAanmeldingen)).EndInit();
            this.splContainerAanmeldingen.ResumeLayout(false);
            this.spcAanmeldingen.Panel1.ResumeLayout(false);
            this.spcAanmeldingen.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcAanmeldingen)).EndInit();
            this.spcAanmeldingen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtDiensten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtVoorzieningen)).EndInit();
            this.spcWachttijd.Panel1.ResumeLayout(false);
            this.spcWachttijd.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcWachttijd)).EndInit();
            this.spcWachttijd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtWachttijdDienst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtWachttijdVoorziening)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpVan;
        private System.Windows.Forms.DateTimePicker dtpTot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnToepassen;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblAanmeldingen;
        private System.Windows.Forms.SplitContainer splContainerAanmeldingen;
        private System.Windows.Forms.SplitContainer spcAanmeldingen;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtDiensten;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtVoorzieningen;
        private System.Windows.Forms.SplitContainer spcWachttijd;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtWachttijdDienst;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtWachttijdVoorziening;
    }
}