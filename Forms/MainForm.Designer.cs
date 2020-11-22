﻿namespace Matixs_Mod_Installer
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.imglstModpacks = new System.Windows.Forms.ImageList(this.components);
            this.imglstButtonImgs = new System.Windows.Forms.ImageList(this.components);
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.flpMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnStartMinecraftLauncher = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblStatusInfo = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlLoadingModpacks = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.pnlSearchBoxWrapper = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.flpDetails = new System.Windows.Forms.FlowLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMinecraftVersion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblModpackVersion = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlInstall = new System.Windows.Forms.Panel();
            this.btnUninstall = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnInstallMopack = new System.Windows.Forms.Button();
            this.lblInstallStatus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pcbIcon = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCreator = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblNothingSelected = new System.Windows.Forms.Label();
            this.tltMain = new System.Windows.Forms.ToolTip(this.components);
            this.lvModpacks = new Matixs_Mod_Installer.Controls.ListViewWT();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbSearch = new Matixs_Mod_Installer.Controls.TextBoxWT();
            this.llblForgeFile = new Matixs_Mod_Installer.Controls.LinkLabelWT();
            this.llblSourceFile = new Matixs_Mod_Installer.Controls.LinkLabelWT();
            this.pgbInstallProgress = new Matixs_Mod_Installer.ProgressBarWT();
            this.pnlMenu.SuspendLayout();
            this.flpMenu.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlLoadingModpacks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.pnlSearchBoxWrapper.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.flpDetails.SuspendLayout();
            this.pnlInstall.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbIcon)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imglstModpacks
            // 
            this.imglstModpacks.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imglstModpacks.ImageSize = new System.Drawing.Size(32, 32);
            this.imglstModpacks.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imglstButtonImgs
            // 
            this.imglstButtonImgs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglstButtonImgs.ImageStream")));
            this.imglstButtonImgs.TransparentColor = System.Drawing.Color.Transparent;
            this.imglstButtonImgs.Images.SetKeyName(0, "down-arrow.png");
            this.imglstButtonImgs.Images.SetKeyName(1, "trash.png");
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(177)))), ((int)(((byte)(179)))));
            this.pnlMenu.Controls.Add(this.flpMenu);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1032, 30);
            this.pnlMenu.TabIndex = 5;
            // 
            // flpMenu
            // 
            this.flpMenu.BackColor = System.Drawing.Color.Transparent;
            this.flpMenu.Controls.Add(this.btnOptions);
            this.flpMenu.Controls.Add(this.btnStartMinecraftLauncher);
            this.flpMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMenu.Location = new System.Drawing.Point(0, 0);
            this.flpMenu.Name = "flpMenu";
            this.flpMenu.Size = new System.Drawing.Size(1032, 30);
            this.flpMenu.TabIndex = 0;
            // 
            // btnStartMinecraftLauncher
            // 
            this.btnStartMinecraftLauncher.AutoSize = true;
            this.btnStartMinecraftLauncher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnStartMinecraftLauncher.FlatAppearance.BorderSize = 0;
            this.btnStartMinecraftLauncher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartMinecraftLauncher.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnStartMinecraftLauncher.ForeColor = System.Drawing.Color.White;
            this.btnStartMinecraftLauncher.Location = new System.Drawing.Point(157, 1);
            this.btnStartMinecraftLauncher.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.btnStartMinecraftLauncher.Name = "btnStartMinecraftLauncher";
            this.btnStartMinecraftLauncher.Padding = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.btnStartMinecraftLauncher.Size = new System.Drawing.Size(155, 27);
            this.btnStartMinecraftLauncher.TabIndex = 1;
            this.btnStartMinecraftLauncher.Text = "Start Minecraft Launcher";
            this.btnStartMinecraftLauncher.UseVisualStyleBackColor = false;
            this.btnStartMinecraftLauncher.Click += new System.EventHandler(this.btnStartMinecraftLauncher_Click_1);
            // 
            // btnOptions
            // 
            this.btnOptions.AutoSize = true;
            this.btnOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnOptions.FlatAppearance.BorderSize = 0;
            this.btnOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOptions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnOptions.ForeColor = System.Drawing.Color.White;
            this.btnOptions.Location = new System.Drawing.Point(1, 1);
            this.btnOptions.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Padding = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.btnOptions.Size = new System.Drawing.Size(155, 27);
            this.btnOptions.TabIndex = 2;
            this.btnOptions.Text = "Options";
            this.btnOptions.UseVisualStyleBackColor = false;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlStatus.Controls.Add(this.tableLayoutPanel1);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatus.Location = new System.Drawing.Point(0, 587);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(1032, 23);
            this.pnlStatus.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1032, 23);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lblStatusInfo);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(510, 17);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // lblStatusInfo
            // 
            this.lblStatusInfo.AutoSize = true;
            this.lblStatusInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusInfo.Location = new System.Drawing.Point(3, 0);
            this.lblStatusInfo.Name = "lblStatusInfo";
            this.lblStatusInfo.Size = new System.Drawing.Size(104, 15);
            this.lblStatusInfo.TabIndex = 0;
            this.lblStatusInfo.Text = "Loading Settings...";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel3.Controls.Add(this.lblVersion);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(519, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(510, 17);
            this.flowLayoutPanel3.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::Matixs_Mod_Installer.Properties.Resources.icon_whitesquare;
            this.pictureBox1.Location = new System.Drawing.Point(493, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(17, 17);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(453, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(37, 15);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "v0.0.1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 30);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnRefresh);
            this.splitContainer1.Panel1.Controls.Add(this.pnlLoadingModpacks);
            this.splitContainer1.Panel1.Controls.Add(this.lvModpacks);
            this.splitContainer1.Panel1.Controls.Add(this.pnlSearch);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1MinSize = 201;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlDetails);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.lblNothingSelected);
            this.splitContainer1.Size = new System.Drawing.Size(1032, 557);
            this.splitContainer1.SplitterDistance = 258;
            this.splitContainer1.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(229)))), ((int)(((byte)(230)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(81)))), ((int)(((byte)(82)))));
            this.btnRefresh.Location = new System.Drawing.Point(199, 3);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(56, 25);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlLoadingModpacks
            // 
            this.pnlLoadingModpacks.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlLoadingModpacks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlLoadingModpacks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLoadingModpacks.Controls.Add(this.pictureBox2);
            this.pnlLoadingModpacks.Controls.Add(this.label9);
            this.pnlLoadingModpacks.Location = new System.Drawing.Point(32, 136);
            this.pnlLoadingModpacks.Name = "pnlLoadingModpacks";
            this.pnlLoadingModpacks.Size = new System.Drawing.Size(196, 51);
            this.pnlLoadingModpacks.TabIndex = 2;
            this.pnlLoadingModpacks.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Matixs_Mod_Installer.Properties.Resources.loading;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.label9.Location = new System.Drawing.Point(52, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 19);
            this.label9.TabIndex = 4;
            this.label9.Text = "Loading Modpacks...";
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlSearch.Controls.Add(this.pnlSearchBoxWrapper);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 28);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(258, 31);
            this.pnlSearch.TabIndex = 5;
            // 
            // pnlSearchBoxWrapper
            // 
            this.pnlSearchBoxWrapper.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearchBoxWrapper.BackColor = System.Drawing.Color.White;
            this.pnlSearchBoxWrapper.Controls.Add(this.tbSearch);
            this.pnlSearchBoxWrapper.Location = new System.Drawing.Point(3, 3);
            this.pnlSearchBoxWrapper.Name = "pnlSearchBoxWrapper";
            this.pnlSearchBoxWrapper.Size = new System.Drawing.Size(192, 25);
            this.pnlSearchBoxWrapper.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.AutoSize = true;
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(229)))), ((int)(((byte)(230)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(81)))), ((int)(((byte)(82)))));
            this.btnSearch.Location = new System.Drawing.Point(199, 3);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(56, 25);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Modpacks";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.flpDetails);
            this.pnlDetails.Controls.Add(this.pnlInstall);
            this.pnlDetails.Controls.Add(this.panel1);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetails.Location = new System.Drawing.Point(0, 28);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(770, 529);
            this.pnlDetails.TabIndex = 3;
            this.pnlDetails.Visible = false;
            // 
            // flpDetails
            // 
            this.flpDetails.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.flpDetails.Controls.Add(this.label10);
            this.flpDetails.Controls.Add(this.rtbDescription);
            this.flpDetails.Controls.Add(this.lblDescription);
            this.flpDetails.Controls.Add(this.label3);
            this.flpDetails.Controls.Add(this.lblMinecraftVersion);
            this.flpDetails.Controls.Add(this.label4);
            this.flpDetails.Controls.Add(this.lblModpackVersion);
            this.flpDetails.Controls.Add(this.label6);
            this.flpDetails.Controls.Add(this.llblForgeFile);
            this.flpDetails.Controls.Add(this.label5);
            this.flpDetails.Controls.Add(this.llblSourceFile);
            this.flpDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpDetails.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpDetails.Location = new System.Drawing.Point(0, 111);
            this.flpDetails.Name = "flpDetails";
            this.flpDetails.Size = new System.Drawing.Size(770, 315);
            this.flpDetails.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 15);
            this.label10.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 15);
            this.label10.TabIndex = 11;
            this.label10.Text = "Description";
            // 
            // rtbDescription
            // 
            this.rtbDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.rtbDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDescription.DetectUrls = false;
            this.rtbDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rtbDescription.Location = new System.Drawing.Point(3, 30);
            this.rtbDescription.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.ReadOnly = true;
            this.rtbDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbDescription.Size = new System.Drawing.Size(390, 10);
            this.rtbDescription.TabIndex = 13;
            this.rtbDescription.Text = "";
            this.rtbDescription.Visible = false;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDescription.Location = new System.Drawing.Point(3, 40);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(733, 38);
            this.lblDescription.TabIndex = 12;
            this.lblDescription.Text = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod t" +
    "empor invidunt ut labore et dolore magna aliquyam erat...";
            this.lblDescription.Click += new System.EventHandler(this.lblDescription_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 93);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Minecraft Version:";
            // 
            // lblMinecraftVersion
            // 
            this.lblMinecraftVersion.AutoSize = true;
            this.lblMinecraftVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblMinecraftVersion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMinecraftVersion.Location = new System.Drawing.Point(3, 108);
            this.lblMinecraftVersion.Name = "lblMinecraftVersion";
            this.lblMinecraftVersion.Size = new System.Drawing.Size(47, 19);
            this.lblMinecraftVersion.TabIndex = 3;
            this.lblMinecraftVersion.Text = "1.16.4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 142);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Modpack Version:";
            // 
            // lblModpackVersion
            // 
            this.lblModpackVersion.AutoSize = true;
            this.lblModpackVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblModpackVersion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblModpackVersion.Location = new System.Drawing.Point(3, 157);
            this.lblModpackVersion.Name = "lblModpackVersion";
            this.lblModpackVersion.Size = new System.Drawing.Size(39, 19);
            this.lblModpackVersion.TabIndex = 5;
            this.lblModpackVersion.Text = "0.1.4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 191);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Forge Source File:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 240);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Modpack Source File:";
            // 
            // pnlInstall
            // 
            this.pnlInstall.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlInstall.Controls.Add(this.btnUninstall);
            this.pnlInstall.Controls.Add(this.btnUpdate);
            this.pnlInstall.Controls.Add(this.btnInstallMopack);
            this.pnlInstall.Controls.Add(this.lblInstallStatus);
            this.pnlInstall.Controls.Add(this.pgbInstallProgress);
            this.pnlInstall.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInstall.Location = new System.Drawing.Point(0, 426);
            this.pnlInstall.Name = "pnlInstall";
            this.pnlInstall.Size = new System.Drawing.Size(770, 103);
            this.pnlInstall.TabIndex = 15;
            // 
            // btnUninstall
            // 
            this.btnUninstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUninstall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnUninstall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUninstall.FlatAppearance.BorderSize = 0;
            this.btnUninstall.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnUninstall.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(57)))), ((int)(((byte)(42)))));
            this.btnUninstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUninstall.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUninstall.ForeColor = System.Drawing.Color.White;
            this.btnUninstall.ImageKey = "trash.png";
            this.btnUninstall.ImageList = this.imglstButtonImgs;
            this.btnUninstall.Location = new System.Drawing.Point(719, 4);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Size = new System.Drawing.Size(48, 48);
            this.btnUninstall.TabIndex = 15;
            this.btnUninstall.UseVisualStyleBackColor = false;
            this.btnUninstall.Visible = false;
            this.btnUninstall.Click += new System.EventHandler(this.btnUninstall_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(171)))), ((int)(((byte)(94)))));
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.ImageKey = "(Keine)";
            this.btnUpdate.ImageList = this.imglstButtonImgs;
            this.btnUpdate.Location = new System.Drawing.Point(610, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(98, 48);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnInstallMopack
            // 
            this.btnInstallMopack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstallMopack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnInstallMopack.FlatAppearance.BorderSize = 0;
            this.btnInstallMopack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(171)))), ((int)(((byte)(94)))));
            this.btnInstallMopack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnInstallMopack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstallMopack.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstallMopack.ForeColor = System.Drawing.Color.White;
            this.btnInstallMopack.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInstallMopack.ImageKey = "(Keine)";
            this.btnInstallMopack.ImageList = this.imglstButtonImgs;
            this.btnInstallMopack.Location = new System.Drawing.Point(3, 4);
            this.btnInstallMopack.Name = "btnInstallMopack";
            this.btnInstallMopack.Size = new System.Drawing.Size(763, 48);
            this.btnInstallMopack.TabIndex = 11;
            this.btnInstallMopack.Text = "Download and Install";
            this.btnInstallMopack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInstallMopack.UseVisualStyleBackColor = false;
            this.btnInstallMopack.Click += new System.EventHandler(this.btnInstallMopack_Click);
            // 
            // lblInstallStatus
            // 
            this.lblInstallStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInstallStatus.AutoSize = true;
            this.lblInstallStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstallStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblInstallStatus.Location = new System.Drawing.Point(2, 58);
            this.lblInstallStatus.Name = "lblInstallStatus";
            this.lblInstallStatus.Size = new System.Drawing.Size(64, 17);
            this.lblInstallStatus.TabIndex = 13;
            this.lblInstallStatus.Text = "Loading...";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.pcbIcon);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 111);
            this.panel1.TabIndex = 18;
            // 
            // pcbIcon
            // 
            this.pcbIcon.Location = new System.Drawing.Point(3, 4);
            this.pcbIcon.Name = "pcbIcon";
            this.pcbIcon.Size = new System.Drawing.Size(100, 100);
            this.pcbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbIcon.TabIndex = 16;
            this.pcbIcon.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.lblName);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.lblCreator);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(106, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(660, 100);
            this.flowLayoutPanel1.TabIndex = 17;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblName.Location = new System.Drawing.Point(2, 0);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(145, 25);
            this.lblName.TabIndex = 14;
            this.lblName.Text = "Modpack Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 10, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Creator:";
            // 
            // lblCreator
            // 
            this.lblCreator.AutoSize = true;
            this.lblCreator.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCreator.Location = new System.Drawing.Point(3, 50);
            this.lblCreator.Name = "lblCreator";
            this.lblCreator.Size = new System.Drawing.Size(95, 19);
            this.lblCreator.TabIndex = 1;
            this.lblCreator.Text = "Creator Name";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(770, 28);
            this.label7.TabIndex = 2;
            this.label7.Text = "Details";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNothingSelected
            // 
            this.lblNothingSelected.BackColor = System.Drawing.Color.Transparent;
            this.lblNothingSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNothingSelected.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNothingSelected.Location = new System.Drawing.Point(0, 0);
            this.lblNothingSelected.Name = "lblNothingSelected";
            this.lblNothingSelected.Size = new System.Drawing.Size(770, 557);
            this.lblNothingSelected.TabIndex = 2;
            this.lblNothingSelected.Text = "No Modpack Selected\r\n(Select a Modpack at the left side of the screen)";
            this.lblNothingSelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tltMain
            // 
            this.tltMain.AutoPopDelay = 100000;
            this.tltMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.tltMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.tltMain.InitialDelay = 500;
            this.tltMain.ReshowDelay = 100;
            // 
            // lvModpacks
            // 
            this.lvModpacks.AllowColumnReorder = true;
            this.lvModpacks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvModpacks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvModpacks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvModpacks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvModpacks.FullRowSelect = true;
            this.lvModpacks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvModpacks.HideSelection = false;
            this.lvModpacks.Location = new System.Drawing.Point(0, 59);
            this.lvModpacks.MultiSelect = false;
            this.lvModpacks.Name = "lvModpacks";
            this.lvModpacks.Size = new System.Drawing.Size(258, 498);
            this.lvModpacks.SmallImageList = this.imglstModpacks;
            this.lvModpacks.TabIndex = 0;
            this.lvModpacks.UseCompatibleStateImageBehavior = false;
            this.lvModpacks.View = System.Windows.Forms.View.Details;
            this.lvModpacks.SelectedIndexChanged += new System.EventHandler(this.lvModpacks_SelectedIndexChanged);
            this.lvModpacks.SizeChanged += new System.EventHandler(this.lvModpacks_SizeChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 380;
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbSearch.BackColor = System.Drawing.Color.White;
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSearch.Cue = "Search...";
            this.tbSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(6, 3);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(180, 18);
            this.tbSearch.TabIndex = 0;
            this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
            // 
            // llblForgeFile
            // 
            this.llblForgeFile.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.llblForgeFile.AutoSize = true;
            this.llblForgeFile.BackColor = System.Drawing.Color.Transparent;
            this.llblForgeFile.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.llblForgeFile.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.llblForgeFile.Location = new System.Drawing.Point(3, 206);
            this.llblForgeFile.Name = "llblForgeFile";
            this.llblForgeFile.Size = new System.Drawing.Size(272, 19);
            this.llblForgeFile.TabIndex = 8;
            this.llblForgeFile.TabStop = true;
            this.llblForgeFile.Tag = "https://files.minecraftforge.net/maven/net/minecraftforge/forge/1.16.4-35.0.18/fo" +
    "rge-1.16.4-35.0.18-installer.jar";
            this.llblForgeFile.Text = "https://files.minecraftforge.net/maven/net...";
            this.llblForgeFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
            // 
            // llblSourceFile
            // 
            this.llblSourceFile.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.llblSourceFile.AutoSize = true;
            this.llblSourceFile.BackColor = System.Drawing.Color.Transparent;
            this.llblSourceFile.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.llblSourceFile.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.llblSourceFile.Location = new System.Drawing.Point(3, 255);
            this.llblSourceFile.Name = "llblSourceFile";
            this.llblSourceFile.Size = new System.Drawing.Size(263, 19);
            this.llblSourceFile.TabIndex = 10;
            this.llblSourceFile.TabStop = true;
            this.llblSourceFile.Tag = "https://cdn.matix-media.net/dd/ddca9ada";
            this.llblSourceFile.Text = "https://cdn.matix-media.net/dd/ddca9ada";
            this.llblSourceFile.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.llblSourceFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
            // 
            // pgbInstallProgress
            // 
            this.pgbInstallProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbInstallProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pgbInstallProgress.Location = new System.Drawing.Point(4, 78);
            this.pgbInstallProgress.Maximum = 100;
            this.pgbInstallProgress.Minimum = 0;
            this.pgbInstallProgress.Name = "pgbInstallProgress";
            this.pgbInstallProgress.ProgressBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pgbInstallProgress.Size = new System.Drawing.Size(762, 19);
            this.pgbInstallProgress.TabIndex = 16;
            this.pgbInstallProgress.TabStop = false;
            this.pgbInstallProgress.Value = 0;
            this.pgbInstallProgress.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 610);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(575, 582);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Matix\'s Mod Installer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.pnlMenu.ResumeLayout(false);
            this.flpMenu.ResumeLayout(false);
            this.flpMenu.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlLoadingModpacks.ResumeLayout(false);
            this.pnlLoadingModpacks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlSearchBoxWrapper.ResumeLayout(false);
            this.pnlSearchBoxWrapper.PerformLayout();
            this.pnlDetails.ResumeLayout(false);
            this.flpDetails.ResumeLayout(false);
            this.flpDetails.PerformLayout();
            this.pnlInstall.ResumeLayout(false);
            this.pnlInstall.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbIcon)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ListViewWT lvModpacks;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCreator;
        private System.Windows.Forms.Label lblModpackVersion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMinecraftVersion;
        private System.Windows.Forms.Label label3;
        private Controls.LinkLabelWT llblForgeFile;
        private System.Windows.Forms.Label label6;
        private Controls.LinkLabelWT llblSourceFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnInstallMopack;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel pnlInstall;
        private System.Windows.Forms.Label lblInstallStatus;
        private System.Windows.Forms.ImageList imglstModpacks;
        private System.Windows.Forms.PictureBox pcbIcon;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imglstButtonImgs;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.FlowLayoutPanel flpMenu;
        private System.Windows.Forms.Button btnStartMinecraftLauncher;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.FlowLayoutPanel flpDetails;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblStatusInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNothingSelected;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnUninstall;
        private ProgressBarWT pgbInstallProgress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnlLoadingModpacks;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlSearch;
        private Controls.TextBoxWT tbSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlSearchBoxWrapper;
        private System.Windows.Forms.ToolTip tltMain;
        private System.Windows.Forms.Button btnOptions;
    }
}
