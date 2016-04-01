namespace Intern_Aanmeldpunt_Wachtlijst
{
    partial class FrmMain
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
            this.mnsMainMenu = new System.Windows.Forms.MenuStrip();
            this.btnNieuweAanmelding = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDienst = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOverzichtDiensten = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConsulentToevoegen = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVoorziening = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOverzichtVoorzieningen = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVoorzieningToevoegen = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMinderjarigen = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOverzichtMinderjarigen = new System.Windows.Forms.ToolStripMenuItem();
            this.icoConnected = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlNieuweAanmelding = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.cbbAanmeldpunt = new System.Windows.Forms.ComboBox();
            this.cbbAanmelder = new System.Windows.Forms.ComboBox();
            this.cbbDienst = new System.Windows.Forms.ComboBox();
            this.dtpAanmelddatum = new System.Windows.Forms.DateTimePicker();
            this.txtVoornaamMJ = new System.Windows.Forms.TextBox();
            this.txtNaamMJ = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlOverzichtDiensten = new System.Windows.Forms.GroupBox();
            this.btnDienstOpenen = new System.Windows.Forms.Button();
            this.lsvDiensten = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlOverzichtVoorziening = new System.Windows.Forms.GroupBox();
            this.lsvVoorzieningen = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOpenVoorziening = new System.Windows.Forms.Button();
            this.pnlOverzichtMinderjarigen = new System.Windows.Forms.GroupBox();
            this.btnOpenMinderjarige = new System.Windows.Forms.Button();
            this.lsvMinderjarige = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.erpAanmelding = new System.Windows.Forms.ErrorProvider(this.components);
            this.mnsMainMenu.SuspendLayout();
            this.pnlNieuweAanmelding.SuspendLayout();
            this.pnlOverzichtDiensten.SuspendLayout();
            this.pnlOverzichtVoorziening.SuspendLayout();
            this.pnlOverzichtMinderjarigen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpAanmelding)).BeginInit();
            this.SuspendLayout();
            // 
            // mnsMainMenu
            // 
            this.mnsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNieuweAanmelding,
            this.btnDienst,
            this.btnVoorziening,
            this.btnMinderjarigen,
            this.icoConnected});
            this.mnsMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mnsMainMenu.Name = "mnsMainMenu";
            this.mnsMainMenu.Size = new System.Drawing.Size(530, 24);
            this.mnsMainMenu.TabIndex = 0;
            this.mnsMainMenu.Text = "menuStrip1";
            // 
            // btnNieuweAanmelding
            // 
            this.btnNieuweAanmelding.Name = "btnNieuweAanmelding";
            this.btnNieuweAanmelding.Size = new System.Drawing.Size(127, 20);
            this.btnNieuweAanmelding.Text = "Nieuwe Aanmelding";
            this.btnNieuweAanmelding.Click += new System.EventHandler(this.btnNieuweAanmelding_Click);
            // 
            // btnDienst
            // 
            this.btnDienst.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOverzichtDiensten,
            this.btnConsulentToevoegen});
            this.btnDienst.Name = "btnDienst";
            this.btnDienst.Size = new System.Drawing.Size(65, 20);
            this.btnDienst.Text = "Diensten";
            // 
            // btnOverzichtDiensten
            // 
            this.btnOverzichtDiensten.Name = "btnOverzichtDiensten";
            this.btnOverzichtDiensten.Size = new System.Drawing.Size(228, 22);
            this.btnOverzichtDiensten.Text = "Overzicht diensten";
            this.btnOverzichtDiensten.Click += new System.EventHandler(this.btnOverzichtDienst_Click);
            // 
            // btnConsulentToevoegen
            // 
            this.btnConsulentToevoegen.Name = "btnConsulentToevoegen";
            this.btnConsulentToevoegen.Size = new System.Drawing.Size(228, 22);
            this.btnConsulentToevoegen.Text = "Nieuwe consulent toevoegen";
            // 
            // btnVoorziening
            // 
            this.btnVoorziening.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOverzichtVoorzieningen,
            this.btnVoorzieningToevoegen});
            this.btnVoorziening.Name = "btnVoorziening";
            this.btnVoorziening.Size = new System.Drawing.Size(95, 20);
            this.btnVoorziening.Text = "Voorzieningen";
            // 
            // btnOverzichtVoorzieningen
            // 
            this.btnOverzichtVoorzieningen.Name = "btnOverzichtVoorzieningen";
            this.btnOverzichtVoorzieningen.Size = new System.Drawing.Size(238, 22);
            this.btnOverzichtVoorzieningen.Text = "Overzicht Voorzieningen";
            this.btnOverzichtVoorzieningen.Click += new System.EventHandler(this.btnOverzichtAanmeldpunt_Click);
            // 
            // btnVoorzieningToevoegen
            // 
            this.btnVoorzieningToevoegen.Name = "btnVoorzieningToevoegen";
            this.btnVoorzieningToevoegen.Size = new System.Drawing.Size(238, 22);
            this.btnVoorzieningToevoegen.Text = "Nieuwe voorziening toevoegen";
            // 
            // btnMinderjarigen
            // 
            this.btnMinderjarigen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOverzichtMinderjarigen});
            this.btnMinderjarigen.Name = "btnMinderjarigen";
            this.btnMinderjarigen.Size = new System.Drawing.Size(93, 20);
            this.btnMinderjarigen.Text = "Minderjarigen";
            // 
            // btnOverzichtMinderjarigen
            // 
            this.btnOverzichtMinderjarigen.Name = "btnOverzichtMinderjarigen";
            this.btnOverzichtMinderjarigen.Size = new System.Drawing.Size(201, 22);
            this.btnOverzichtMinderjarigen.Text = "Overzicht minderjarigen";
            this.btnOverzichtMinderjarigen.Click += new System.EventHandler(this.btnOverzichtMinderjarigen_Click);
            // 
            // icoConnected
            // 
            this.icoConnected.Name = "icoConnected";
            this.icoConnected.Size = new System.Drawing.Size(12, 20);
            this.icoConnected.Click += new System.EventHandler(this.icoConnected_Click);
            // 
            // pnlNieuweAanmelding
            // 
            this.pnlNieuweAanmelding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNieuweAanmelding.Controls.Add(this.btnClear);
            this.pnlNieuweAanmelding.Controls.Add(this.btnSubmit);
            this.pnlNieuweAanmelding.Controls.Add(this.cbbAanmeldpunt);
            this.pnlNieuweAanmelding.Controls.Add(this.cbbAanmelder);
            this.pnlNieuweAanmelding.Controls.Add(this.cbbDienst);
            this.pnlNieuweAanmelding.Controls.Add(this.dtpAanmelddatum);
            this.pnlNieuweAanmelding.Controls.Add(this.txtVoornaamMJ);
            this.pnlNieuweAanmelding.Controls.Add(this.txtNaamMJ);
            this.pnlNieuweAanmelding.Controls.Add(this.label6);
            this.pnlNieuweAanmelding.Controls.Add(this.label5);
            this.pnlNieuweAanmelding.Controls.Add(this.label4);
            this.pnlNieuweAanmelding.Controls.Add(this.label3);
            this.pnlNieuweAanmelding.Controls.Add(this.label2);
            this.pnlNieuweAanmelding.Controls.Add(this.label1);
            this.pnlNieuweAanmelding.Location = new System.Drawing.Point(12, 27);
            this.pnlNieuweAanmelding.Name = "pnlNieuweAanmelding";
            this.pnlNieuweAanmelding.Size = new System.Drawing.Size(506, 182);
            this.pnlNieuweAanmelding.TabIndex = 2;
            this.pnlNieuweAanmelding.TabStop = false;
            this.pnlNieuweAanmelding.Text = "Nieuwe aanmelding";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(325, 44);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Leegmaken";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(325, 15);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "Toevoegen";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // cbbAanmeldpunt
            // 
            this.cbbAanmeldpunt.FormattingEnabled = true;
            this.cbbAanmeldpunt.Location = new System.Drawing.Point(93, 152);
            this.cbbAanmeldpunt.Name = "cbbAanmeldpunt";
            this.cbbAanmeldpunt.Size = new System.Drawing.Size(191, 21);
            this.cbbAanmeldpunt.TabIndex = 6;
            // 
            // cbbAanmelder
            // 
            this.cbbAanmelder.FormattingEnabled = true;
            this.cbbAanmelder.Location = new System.Drawing.Point(93, 73);
            this.cbbAanmelder.Name = "cbbAanmelder";
            this.cbbAanmelder.Size = new System.Drawing.Size(191, 21);
            this.cbbAanmelder.TabIndex = 3;
            // 
            // cbbDienst
            // 
            this.cbbDienst.FormattingEnabled = true;
            this.cbbDienst.Location = new System.Drawing.Point(93, 46);
            this.cbbDienst.Name = "cbbDienst";
            this.cbbDienst.Size = new System.Drawing.Size(191, 21);
            this.cbbDienst.TabIndex = 2;
            this.cbbDienst.SelectedIndexChanged += new System.EventHandler(this.cbbDienst_SelectedIndexChanged);
            // 
            // dtpAanmelddatum
            // 
            this.dtpAanmelddatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAanmelddatum.Location = new System.Drawing.Point(93, 19);
            this.dtpAanmelddatum.Name = "dtpAanmelddatum";
            this.dtpAanmelddatum.Size = new System.Drawing.Size(191, 20);
            this.dtpAanmelddatum.TabIndex = 1;
            // 
            // txtVoornaamMJ
            // 
            this.txtVoornaamMJ.Location = new System.Drawing.Point(93, 125);
            this.txtVoornaamMJ.Name = "txtVoornaamMJ";
            this.txtVoornaamMJ.Size = new System.Drawing.Size(191, 20);
            this.txtVoornaamMJ.TabIndex = 5;
            // 
            // txtNaamMJ
            // 
            this.txtNaamMJ.Location = new System.Drawing.Point(93, 98);
            this.txtNaamMJ.Name = "txtNaamMJ";
            this.txtNaamMJ.Size = new System.Drawing.Size(191, 20);
            this.txtNaamMJ.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Aanmeldpunt:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Voornaam MJ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Naam MJ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Consulent:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Dienst:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Aanmelddatum:";
            // 
            // pnlOverzichtDiensten
            // 
            this.pnlOverzichtDiensten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOverzichtDiensten.Controls.Add(this.btnDienstOpenen);
            this.pnlOverzichtDiensten.Controls.Add(this.lsvDiensten);
            this.pnlOverzichtDiensten.Location = new System.Drawing.Point(12, 215);
            this.pnlOverzichtDiensten.Name = "pnlOverzichtDiensten";
            this.pnlOverzichtDiensten.Size = new System.Drawing.Size(506, 339);
            this.pnlOverzichtDiensten.TabIndex = 5;
            this.pnlOverzichtDiensten.TabStop = false;
            this.pnlOverzichtDiensten.Text = "Overzicht diensten";
            // 
            // btnDienstOpenen
            // 
            this.btnDienstOpenen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDienstOpenen.Location = new System.Drawing.Point(6, 312);
            this.btnDienstOpenen.Name = "btnDienstOpenen";
            this.btnDienstOpenen.Size = new System.Drawing.Size(93, 23);
            this.btnDienstOpenen.TabIndex = 1;
            this.btnDienstOpenen.Text = "Dienst openen";
            this.btnDienstOpenen.UseVisualStyleBackColor = true;
            this.btnDienstOpenen.Click += new System.EventHandler(this.btnDienstOpenen_Click);
            // 
            // lsvDiensten
            // 
            this.lsvDiensten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvDiensten.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lsvDiensten.FullRowSelect = true;
            this.lsvDiensten.GridLines = true;
            this.lsvDiensten.Location = new System.Drawing.Point(6, 19);
            this.lsvDiensten.MultiSelect = false;
            this.lsvDiensten.Name = "lsvDiensten";
            this.lsvDiensten.Size = new System.Drawing.Size(494, 287);
            this.lsvDiensten.TabIndex = 0;
            this.lsvDiensten.UseCompatibleStateImageBehavior = false;
            this.lsvDiensten.View = System.Windows.Forms.View.Details;
            this.lsvDiensten.DoubleClick += new System.EventHandler(this.lsvDiensten_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Naam";
            this.columnHeader1.Width = 219;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Aantal jongeren in wachtlijst";
            this.columnHeader2.Width = 185;
            // 
            // pnlOverzichtVoorziening
            // 
            this.pnlOverzichtVoorziening.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOverzichtVoorziening.Controls.Add(this.lsvVoorzieningen);
            this.pnlOverzichtVoorziening.Controls.Add(this.btnOpenVoorziening);
            this.pnlOverzichtVoorziening.Location = new System.Drawing.Point(12, 217);
            this.pnlOverzichtVoorziening.Name = "pnlOverzichtVoorziening";
            this.pnlOverzichtVoorziening.Size = new System.Drawing.Size(506, 337);
            this.pnlOverzichtVoorziening.TabIndex = 7;
            this.pnlOverzichtVoorziening.TabStop = false;
            this.pnlOverzichtVoorziening.Text = "Overzicht voorzieningen";
            // 
            // lsvVoorzieningen
            // 
            this.lsvVoorzieningen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvVoorzieningen.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lsvVoorzieningen.FullRowSelect = true;
            this.lsvVoorzieningen.GridLines = true;
            this.lsvVoorzieningen.Location = new System.Drawing.Point(6, 19);
            this.lsvVoorzieningen.MultiSelect = false;
            this.lsvVoorzieningen.Name = "lsvVoorzieningen";
            this.lsvVoorzieningen.Size = new System.Drawing.Size(494, 285);
            this.lsvVoorzieningen.TabIndex = 1;
            this.lsvVoorzieningen.UseCompatibleStateImageBehavior = false;
            this.lsvVoorzieningen.View = System.Windows.Forms.View.Details;
            this.lsvVoorzieningen.DoubleClick += new System.EventHandler(this.lsvVoorzieningen_DoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Naam";
            this.columnHeader3.Width = 305;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Aantal jongeren in wachtlijst";
            this.columnHeader4.Width = 154;
            // 
            // btnOpenVoorziening
            // 
            this.btnOpenVoorziening.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenVoorziening.Location = new System.Drawing.Point(6, 308);
            this.btnOpenVoorziening.Name = "btnOpenVoorziening";
            this.btnOpenVoorziening.Size = new System.Drawing.Size(117, 23);
            this.btnOpenVoorziening.TabIndex = 0;
            this.btnOpenVoorziening.Text = "Voorziening openen";
            this.btnOpenVoorziening.UseVisualStyleBackColor = true;
            this.btnOpenVoorziening.Click += new System.EventHandler(this.btnOpenVoorziening_Click);
            // 
            // pnlOverzichtMinderjarigen
            // 
            this.pnlOverzichtMinderjarigen.Controls.Add(this.btnOpenMinderjarige);
            this.pnlOverzichtMinderjarigen.Controls.Add(this.lsvMinderjarige);
            this.pnlOverzichtMinderjarigen.Location = new System.Drawing.Point(12, 217);
            this.pnlOverzichtMinderjarigen.Name = "pnlOverzichtMinderjarigen";
            this.pnlOverzichtMinderjarigen.Size = new System.Drawing.Size(506, 337);
            this.pnlOverzichtMinderjarigen.TabIndex = 8;
            this.pnlOverzichtMinderjarigen.TabStop = false;
            this.pnlOverzichtMinderjarigen.Text = "Overzicht minderjarigen";
            // 
            // btnOpenMinderjarige
            // 
            this.btnOpenMinderjarige.Location = new System.Drawing.Point(6, 308);
            this.btnOpenMinderjarige.Name = "btnOpenMinderjarige";
            this.btnOpenMinderjarige.Size = new System.Drawing.Size(117, 23);
            this.btnOpenMinderjarige.TabIndex = 1;
            this.btnOpenMinderjarige.Text = "Open minderjarige";
            this.btnOpenMinderjarige.UseVisualStyleBackColor = true;
            this.btnOpenMinderjarige.Click += new System.EventHandler(this.btnOpenMinderjarige_Click);
            // 
            // lsvMinderjarige
            // 
            this.lsvMinderjarige.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.lsvMinderjarige.FullRowSelect = true;
            this.lsvMinderjarige.GridLines = true;
            this.lsvMinderjarige.Location = new System.Drawing.Point(6, 19);
            this.lsvMinderjarige.MultiSelect = false;
            this.lsvMinderjarige.Name = "lsvMinderjarige";
            this.lsvMinderjarige.Size = new System.Drawing.Size(494, 285);
            this.lsvMinderjarige.TabIndex = 0;
            this.lsvMinderjarige.UseCompatibleStateImageBehavior = false;
            this.lsvMinderjarige.View = System.Windows.Forms.View.Details;
            this.lsvMinderjarige.DoubleClick += new System.EventHandler(this.lsvMinderjarige_DoubleClick);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Naam";
            this.columnHeader5.Width = 250;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Aantal aanmeldingen";
            this.columnHeader6.Width = 125;
            // 
            // erpAanmelding
            // 
            this.erpAanmelding.ContainerControl = this;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 566);
            this.Controls.Add(this.pnlOverzichtMinderjarigen);
            this.Controls.Add(this.pnlOverzichtVoorziening);
            this.Controls.Add(this.pnlOverzichtDiensten);
            this.Controls.Add(this.pnlNieuweAanmelding);
            this.Controls.Add(this.mnsMainMenu);
            this.MainMenuStrip = this.mnsMainMenu;
            this.Name = "FrmMain";
            this.Text = "Inter aanmeldpunt: Oost-Vlaanderen";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.mnsMainMenu.ResumeLayout(false);
            this.mnsMainMenu.PerformLayout();
            this.pnlNieuweAanmelding.ResumeLayout(false);
            this.pnlNieuweAanmelding.PerformLayout();
            this.pnlOverzichtDiensten.ResumeLayout(false);
            this.pnlOverzichtVoorziening.ResumeLayout(false);
            this.pnlOverzichtMinderjarigen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.erpAanmelding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsMainMenu;
        private System.Windows.Forms.ToolStripMenuItem btnNieuweAanmelding;
        private System.Windows.Forms.ToolStripMenuItem btnDienst;
        private System.Windows.Forms.ToolStripMenuItem btnVoorziening;
        private System.Windows.Forms.ToolStripMenuItem icoConnected;
        private System.Windows.Forms.GroupBox pnlNieuweAanmelding;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ComboBox cbbAanmeldpunt;
        private System.Windows.Forms.ComboBox cbbAanmelder;
        private System.Windows.Forms.ComboBox cbbDienst;
        private System.Windows.Forms.DateTimePicker dtpAanmelddatum;
        private System.Windows.Forms.TextBox txtVoornaamMJ;
        private System.Windows.Forms.TextBox txtNaamMJ;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ToolStripMenuItem btnOverzichtDiensten;
        private System.Windows.Forms.ToolStripMenuItem btnConsulentToevoegen;
        private System.Windows.Forms.ToolStripMenuItem btnOverzichtVoorzieningen;
        private System.Windows.Forms.ToolStripMenuItem btnVoorzieningToevoegen;
        private System.Windows.Forms.ToolStripMenuItem btnMinderjarigen;
        private System.Windows.Forms.ToolStripMenuItem btnOverzichtMinderjarigen;
        private System.Windows.Forms.GroupBox pnlOverzichtDiensten;
        private System.Windows.Forms.Button btnDienstOpenen;
        private System.Windows.Forms.ListView lsvDiensten;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox pnlOverzichtVoorziening;
        private System.Windows.Forms.ListView lsvVoorzieningen;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnOpenVoorziening;
        private System.Windows.Forms.GroupBox pnlOverzichtMinderjarigen;
        private System.Windows.Forms.Button btnOpenMinderjarige;
        private System.Windows.Forms.ListView lsvMinderjarige;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ErrorProvider erpAanmelding;
    }
}

