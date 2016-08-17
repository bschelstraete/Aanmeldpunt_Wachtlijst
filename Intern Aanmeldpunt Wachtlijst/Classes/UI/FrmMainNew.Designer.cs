namespace Intern_Aanmeldpunt_Wachtlijst.Classes.UI
{
    partial class FrmMainNew
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
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnNewAanmelding = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.btnStatistieken = new System.Windows.Forms.Label();
            this.btnMinderjarige = new System.Windows.Forms.Label();
            this.btnVoorzieningen = new System.Windows.Forms.Label();
            this.btnDiensten = new System.Windows.Forms.Label();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblMinimize = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnZoekMJ = new System.Windows.Forms.Label();
            this.txtZoeken = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlNewAanmelding = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClearAanmelding = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddAanmelding = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpAanmelddatum = new System.Windows.Forms.DateTimePicker();
            this.cbbAanmeldpunt = new System.Windows.Forms.ComboBox();
            this.cbbDienst = new System.Windows.Forms.ComboBox();
            this.txtVoornaamMJ = new System.Windows.Forms.TextBox();
            this.cbbAanmelder = new System.Windows.Forms.ComboBox();
            this.txtNaamMJ = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvAanmeldingen = new System.Windows.Forms.DataGridView();
            this.pnlSidebar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlNewAanmelding.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAanmeldingen)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            this.pnlSidebar.Controls.Add(this.btnNewAanmelding);
            this.pnlSidebar.Controls.Add(this.panel1);
            this.pnlSidebar.Controls.Add(this.btnStatistieken);
            this.pnlSidebar.Controls.Add(this.btnMinderjarige);
            this.pnlSidebar.Controls.Add(this.btnVoorzieningen);
            this.pnlSidebar.Controls.Add(this.btnDiensten);
            this.pnlSidebar.Controls.Add(this.pnlLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(184, 634);
            this.pnlSidebar.TabIndex = 0;
            // 
            // btnNewAanmelding
            // 
            this.btnNewAanmelding.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewAanmelding.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnNewAanmelding.Location = new System.Drawing.Point(0, 54);
            this.btnNewAanmelding.Name = "btnNewAanmelding";
            this.btnNewAanmelding.Size = new System.Drawing.Size(184, 54);
            this.btnNewAanmelding.TabIndex = 9;
            this.btnNewAanmelding.Text = "Nieuwe Aanmelding";
            this.btnNewAanmelding.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNewAanmelding.Click += new System.EventHandler(this.btnSidebar_Click);
            this.btnNewAanmelding.MouseEnter += new System.EventHandler(this.btnNewAanmelding_MouseEnter);
            this.btnNewAanmelding.MouseLeave += new System.EventHandler(this.btnNewAanmelding_MouseEnter);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 607);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 27);
            this.panel1.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(5, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(175, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "© Bryan Schelstraete; Jongerenwelzijn";
            // 
            // btnStatistieken
            // 
            this.btnStatistieken.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistieken.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnStatistieken.Location = new System.Drawing.Point(0, 270);
            this.btnStatistieken.Name = "btnStatistieken";
            this.btnStatistieken.Size = new System.Drawing.Size(184, 54);
            this.btnStatistieken.TabIndex = 7;
            this.btnStatistieken.Text = "Statistieken";
            this.btnStatistieken.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnStatistieken.Click += new System.EventHandler(this.btnSidebar_Click);
            this.btnStatistieken.MouseEnter += new System.EventHandler(this.btnNewAanmelding_MouseEnter);
            this.btnStatistieken.MouseLeave += new System.EventHandler(this.btnNewAanmelding_MouseEnter);
            // 
            // btnMinderjarige
            // 
            this.btnMinderjarige.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinderjarige.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnMinderjarige.Location = new System.Drawing.Point(0, 216);
            this.btnMinderjarige.Name = "btnMinderjarige";
            this.btnMinderjarige.Size = new System.Drawing.Size(184, 54);
            this.btnMinderjarige.TabIndex = 6;
            this.btnMinderjarige.Text = "Minderjarigen";
            this.btnMinderjarige.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMinderjarige.Click += new System.EventHandler(this.btnSidebar_Click);
            this.btnMinderjarige.MouseEnter += new System.EventHandler(this.btnNewAanmelding_MouseEnter);
            this.btnMinderjarige.MouseLeave += new System.EventHandler(this.btnNewAanmelding_MouseEnter);
            // 
            // btnVoorzieningen
            // 
            this.btnVoorzieningen.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoorzieningen.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnVoorzieningen.Location = new System.Drawing.Point(0, 162);
            this.btnVoorzieningen.Name = "btnVoorzieningen";
            this.btnVoorzieningen.Size = new System.Drawing.Size(184, 54);
            this.btnVoorzieningen.TabIndex = 5;
            this.btnVoorzieningen.Text = "Voorzieningen";
            this.btnVoorzieningen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnVoorzieningen.Click += new System.EventHandler(this.btnSidebar_Click);
            this.btnVoorzieningen.MouseEnter += new System.EventHandler(this.btnNewAanmelding_MouseEnter);
            this.btnVoorzieningen.MouseLeave += new System.EventHandler(this.btnNewAanmelding_MouseEnter);
            // 
            // btnDiensten
            // 
            this.btnDiensten.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiensten.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDiensten.Location = new System.Drawing.Point(0, 108);
            this.btnDiensten.Name = "btnDiensten";
            this.btnDiensten.Size = new System.Drawing.Size(184, 54);
            this.btnDiensten.TabIndex = 4;
            this.btnDiensten.Text = "Diensten";
            this.btnDiensten.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDiensten.Click += new System.EventHandler(this.btnSidebar_Click);
            this.btnDiensten.MouseEnter += new System.EventHandler(this.btnNewAanmelding_MouseEnter);
            this.btnDiensten.MouseLeave += new System.EventHandler(this.btnNewAanmelding_MouseEnter);
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.pnlLogo.Controls.Add(this.label1);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(184, 48);
            this.pnlLogo.TabIndex = 0;
            this.pnlLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            this.pnlLogo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseMove);
            this.pnlLogo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registratielijst O-Vl";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.pnlHeader.Controls.Add(this.lblClose);
            this.pnlHeader.Controls.Add(this.lblMinimize);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(184, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(785, 48);
            this.pnlHeader.TabIndex = 1;
            this.pnlHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            this.pnlHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseMove);
            this.pnlHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseUp);
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.AutoSize = true;
            this.lblClose.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.Location = new System.Drawing.Point(764, 13);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(18, 20);
            this.lblClose.TabIndex = 2;
            this.lblClose.Text = "X";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            this.lblClose.MouseEnter += new System.EventHandler(this.btnFunctions_Mouse);
            this.lblClose.MouseLeave += new System.EventHandler(this.btnFunctions_Mouse);
            // 
            // lblMinimize
            // 
            this.lblMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinimize.AutoSize = true;
            this.lblMinimize.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinimize.Location = new System.Drawing.Point(741, 13);
            this.lblMinimize.Name = "lblMinimize";
            this.lblMinimize.Size = new System.Drawing.Size(17, 20);
            this.lblMinimize.TabIndex = 1;
            this.lblMinimize.Text = "_";
            this.lblMinimize.Click += new System.EventHandler(this.lblMinimize_Click);
            this.lblMinimize.MouseEnter += new System.EventHandler(this.btnFunctions_Mouse);
            this.lblMinimize.MouseLeave += new System.EventHandler(this.btnFunctions_Mouse);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(22, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(89, 22);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Diensten";
            // 
            // btnZoekMJ
            // 
            this.btnZoekMJ.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoekMJ.Location = new System.Drawing.Point(631, 85);
            this.btnZoekMJ.Name = "btnZoekMJ";
            this.btnZoekMJ.Size = new System.Drawing.Size(100, 23);
            this.btnZoekMJ.TabIndex = 47;
            this.btnZoekMJ.Text = "Zoeken";
            this.btnZoekMJ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtZoeken
            // 
            this.txtZoeken.Location = new System.Drawing.Point(550, 49);
            this.txtZoeken.Name = "txtZoeken";
            this.txtZoeken.Size = new System.Drawing.Size(201, 20);
            this.txtZoeken.TabIndex = 46;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(561, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(170, 21);
            this.label10.TabIndex = 45;
            this.label10.Text = "Minderjarige zoeken:";
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(518, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(2, 185);
            this.label9.TabIndex = 44;
            // 
            // pnlNewAanmelding
            // 
            this.pnlNewAanmelding.AutoScroll = true;
            this.pnlNewAanmelding.BackColor = System.Drawing.SystemColors.Control;
            this.pnlNewAanmelding.Controls.Add(this.panel2);
            this.pnlNewAanmelding.Controls.Add(this.label11);
            this.pnlNewAanmelding.Controls.Add(this.label2);
            this.pnlNewAanmelding.Controls.Add(this.btnClearAanmelding);
            this.pnlNewAanmelding.Controls.Add(this.btnZoekMJ);
            this.pnlNewAanmelding.Controls.Add(this.label3);
            this.pnlNewAanmelding.Controls.Add(this.txtZoeken);
            this.pnlNewAanmelding.Controls.Add(this.btnAddAanmelding);
            this.pnlNewAanmelding.Controls.Add(this.label9);
            this.pnlNewAanmelding.Controls.Add(this.label10);
            this.pnlNewAanmelding.Controls.Add(this.label5);
            this.pnlNewAanmelding.Controls.Add(this.label4);
            this.pnlNewAanmelding.Controls.Add(this.label7);
            this.pnlNewAanmelding.Controls.Add(this.label6);
            this.pnlNewAanmelding.Controls.Add(this.dtpAanmelddatum);
            this.pnlNewAanmelding.Controls.Add(this.cbbAanmeldpunt);
            this.pnlNewAanmelding.Controls.Add(this.cbbDienst);
            this.pnlNewAanmelding.Controls.Add(this.txtVoornaamMJ);
            this.pnlNewAanmelding.Controls.Add(this.cbbAanmelder);
            this.pnlNewAanmelding.Controls.Add(this.txtNaamMJ);
            this.pnlNewAanmelding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNewAanmelding.Location = new System.Drawing.Point(184, 48);
            this.pnlNewAanmelding.Name = "pnlNewAanmelding";
            this.pnlNewAanmelding.Size = new System.Drawing.Size(785, 586);
            this.pnlNewAanmelding.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Location = new System.Drawing.Point(75, 272);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(604, 2);
            this.label11.TabIndex = 65;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 50;
            this.label2.Text = "Aanmelddatum:";
            // 
            // btnClearAanmelding
            // 
            this.btnClearAanmelding.BackColor = System.Drawing.SystemColors.Control;
            this.btnClearAanmelding.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearAanmelding.Location = new System.Drawing.Point(331, 216);
            this.btnClearAanmelding.Name = "btnClearAanmelding";
            this.btnClearAanmelding.Size = new System.Drawing.Size(149, 39);
            this.btnClearAanmelding.TabIndex = 63;
            this.btnClearAanmelding.Text = "Leegmaken";
            this.btnClearAanmelding.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(95, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 51;
            this.label3.Text = "Dienst:";
            // 
            // btnAddAanmelding
            // 
            this.btnAddAanmelding.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddAanmelding.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAanmelding.Location = new System.Drawing.Point(154, 216);
            this.btnAddAanmelding.Name = "btnAddAanmelding";
            this.btnAddAanmelding.Size = new System.Drawing.Size(149, 39);
            this.btnAddAanmelding.TabIndex = 62;
            this.btnAddAanmelding.Text = "Toevoegen";
            this.btnAddAanmelding.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(66, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 20);
            this.label5.TabIndex = 52;
            this.label5.Text = "Consulent:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(69, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 53;
            this.label4.Text = "Naam MJ:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(35, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 20);
            this.label7.TabIndex = 54;
            this.label7.Text = "Voornaam MJ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(53, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 55;
            this.label6.Text = "Voorziening:";
            // 
            // dtpAanmelddatum
            // 
            this.dtpAanmelddatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAanmelddatum.Location = new System.Drawing.Point(158, 17);
            this.dtpAanmelddatum.Name = "dtpAanmelddatum";
            this.dtpAanmelddatum.Size = new System.Drawing.Size(249, 20);
            this.dtpAanmelddatum.TabIndex = 56;
            // 
            // cbbAanmeldpunt
            // 
            this.cbbAanmeldpunt.FormattingEnabled = true;
            this.cbbAanmeldpunt.Location = new System.Drawing.Point(158, 177);
            this.cbbAanmeldpunt.Name = "cbbAanmeldpunt";
            this.cbbAanmeldpunt.Size = new System.Drawing.Size(249, 21);
            this.cbbAanmeldpunt.TabIndex = 61;
            // 
            // cbbDienst
            // 
            this.cbbDienst.FormattingEnabled = true;
            this.cbbDienst.Location = new System.Drawing.Point(158, 48);
            this.cbbDienst.Name = "cbbDienst";
            this.cbbDienst.Size = new System.Drawing.Size(249, 21);
            this.cbbDienst.TabIndex = 57;
            // 
            // txtVoornaamMJ
            // 
            this.txtVoornaamMJ.Location = new System.Drawing.Point(158, 142);
            this.txtVoornaamMJ.Name = "txtVoornaamMJ";
            this.txtVoornaamMJ.Size = new System.Drawing.Size(249, 20);
            this.txtVoornaamMJ.TabIndex = 60;
            // 
            // cbbAanmelder
            // 
            this.cbbAanmelder.FormattingEnabled = true;
            this.cbbAanmelder.Location = new System.Drawing.Point(158, 79);
            this.cbbAanmelder.Name = "cbbAanmelder";
            this.cbbAanmelder.Size = new System.Drawing.Size(249, 21);
            this.cbbAanmelder.TabIndex = 58;
            // 
            // txtNaamMJ
            // 
            this.txtNaamMJ.Location = new System.Drawing.Point(158, 110);
            this.txtNaamMJ.Name = "txtNaamMJ";
            this.txtNaamMJ.Size = new System.Drawing.Size(249, 20);
            this.txtNaamMJ.TabIndex = 59;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvAanmeldingen);
            this.panel2.Location = new System.Drawing.Point(6, 277);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(752, 369);
            this.panel2.TabIndex = 66;
            // 
            // dgvAanmeldingen
            // 
            this.dgvAanmeldingen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAanmeldingen.Location = new System.Drawing.Point(4, 19);
            this.dgvAanmeldingen.Name = "dgvAanmeldingen";
            this.dgvAanmeldingen.Size = new System.Drawing.Size(741, 317);
            this.dgvAanmeldingen.TabIndex = 0;
            // 
            // FrmMainNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(969, 634);
            this.Controls.Add(this.pnlNewAanmelding);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMainNew";
            this.Text = "FrmMainNew";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseUp);
            this.pnlSidebar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlLogo.ResumeLayout(false);
            this.pnlLogo.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlNewAanmelding.ResumeLayout(false);
            this.pnlNewAanmelding.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAanmeldingen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblMinimize;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label btnNewAanmelding;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label btnStatistieken;
        private System.Windows.Forms.Label btnMinderjarige;
        private System.Windows.Forms.Label btnVoorzieningen;
        private System.Windows.Forms.Label btnDiensten;
        private System.Windows.Forms.Label btnZoekMJ;
        private System.Windows.Forms.TextBox txtZoeken;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnlNewAanmelding;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label btnClearAanmelding;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label btnAddAanmelding;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpAanmelddatum;
        private System.Windows.Forms.ComboBox cbbAanmeldpunt;
        private System.Windows.Forms.ComboBox cbbDienst;
        private System.Windows.Forms.TextBox txtVoornaamMJ;
        private System.Windows.Forms.ComboBox cbbAanmelder;
        private System.Windows.Forms.TextBox txtNaamMJ;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvAanmeldingen;
    }
}