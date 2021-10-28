
namespace WindowsFormsApp1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnGenerate = new System.Windows.Forms.Button();
            this.tbGeneratedCode = new System.Windows.Forms.TextBox();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.tbOutputName = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.labelClassName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnCut = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnParse = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelGenerateStatus = new System.Windows.Forms.Label();
            this.labelBuildStatus = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tbSource = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioCS = new System.Windows.Forms.RadioButton();
            this.radioVB = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGenerate.BackColor = System.Drawing.Color.Gold;
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(29, 86);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(20, 2, 3, 2);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(149, 39);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // tbGeneratedCode
            // 
            this.tbGeneratedCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGeneratedCode.Enabled = false;
            this.tbGeneratedCode.Location = new System.Drawing.Point(4, 5);
            this.tbGeneratedCode.Margin = new System.Windows.Forms.Padding(2);
            this.tbGeneratedCode.Multiline = true;
            this.tbGeneratedCode.Name = "tbGeneratedCode";
            this.tbGeneratedCode.ReadOnly = true;
            this.tbGeneratedCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbGeneratedCode.Size = new System.Drawing.Size(599, 392);
            this.tbGeneratedCode.TabIndex = 1;
            // 
            // tbStatus
            // 
            this.tbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStatus.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbStatus.Location = new System.Drawing.Point(5, 6);
            this.tbStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbStatus.Multiline = true;
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.ReadOnly = true;
            this.tbStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbStatus.Size = new System.Drawing.Size(599, 67);
            this.tbStatus.TabIndex = 2;
            // 
            // tbOutputName
            // 
            this.tbOutputName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOutputName.Enabled = false;
            this.tbOutputName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOutputName.Location = new System.Drawing.Point(161, 26);
            this.tbOutputName.Margin = new System.Windows.Forms.Padding(2);
            this.tbOutputName.Name = "tbOutputName";
            this.tbOutputName.ReadOnly = true;
            this.tbOutputName.Size = new System.Drawing.Size(136, 23);
            this.tbOutputName.TabIndex = 3;
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.BackColor = System.Drawing.Color.Gold;
            this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Location = new System.Drawing.Point(215, 86);
            this.btnRun.Margin = new System.Windows.Forms.Padding(3, 2, 20, 2);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(149, 39);
            this.btnRun.TabIndex = 5;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // labelClassName
            // 
            this.labelClassName.AutoSize = true;
            this.labelClassName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClassName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelClassName.Location = new System.Drawing.Point(-1, 29);
            this.labelClassName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelClassName.Name = "labelClassName";
            this.labelClassName.Size = new System.Drawing.Size(147, 17);
            this.labelClassName.TabIndex = 6;
            this.labelClassName.Text = "Generate file name";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelClassName);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.tbOutputName);
            this.panel1.Controls.Add(this.btnGenerate);
            this.panel1.Location = new System.Drawing.Point(5, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.panel1.Size = new System.Drawing.Size(397, 141);
            this.panel1.TabIndex = 8;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1061, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator5,
            this.exiteToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.new_file;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(181, 6);
            // 
            // exiteToolStripMenuItem
            // 
            this.exiteToolStripMenuItem.Name = "exiteToolStripMenuItem";
            this.exiteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exiteToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.exiteToolStripMenuItem.Text = "Exit";
            this.exiteToolStripMenuItem.Click += new System.EventHandler(this.exiteToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.parseToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // parseToolStripMenuItem
            // 
            this.parseToolStripMenuItem.Name = "parseToolStripMenuItem";
            this.parseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.parseToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.parseToolStripMenuItem.Text = "Parse";
            this.parseToolStripMenuItem.Click += new System.EventHandler(this.parseToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnNew,
            this.toolStripBtnOpen,
            this.toolStripBtnSave,
            this.toolStripSeparator1,
            this.toolStripBtnCut,
            this.toolStripBtnCopy,
            this.toolStripBtnParse,
            this.toolStripSeparator2,
            this.toolStripBtnUndo,
            this.toolStripBtnRedo,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1061, 27);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripBtnNew
            // 
            this.toolStripBtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnNew.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnNew.Image")));
            this.toolStripBtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnNew.Name = "toolStripBtnNew";
            this.toolStripBtnNew.Size = new System.Drawing.Size(29, 24);
            this.toolStripBtnNew.Text = "toolStripButton1";
            // 
            // toolStripBtnOpen
            // 
            this.toolStripBtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnOpen.Image")));
            this.toolStripBtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnOpen.Name = "toolStripBtnOpen";
            this.toolStripBtnOpen.Size = new System.Drawing.Size(29, 24);
            this.toolStripBtnOpen.Text = "toolStripButton2";
            // 
            // toolStripBtnSave
            // 
            this.toolStripBtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnSave.Image")));
            this.toolStripBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSave.Name = "toolStripBtnSave";
            this.toolStripBtnSave.Size = new System.Drawing.Size(29, 24);
            this.toolStripBtnSave.Text = "toolStripButton3";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripBtnCut
            // 
            this.toolStripBtnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnCut.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnCut.Image")));
            this.toolStripBtnCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnCut.Name = "toolStripBtnCut";
            this.toolStripBtnCut.Size = new System.Drawing.Size(29, 24);
            this.toolStripBtnCut.Text = "toolStripButton4";
            this.toolStripBtnCut.Click += new System.EventHandler(this.toolStripBtnCut_Click);
            // 
            // toolStripBtnCopy
            // 
            this.toolStripBtnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnCopy.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnCopy.Image")));
            this.toolStripBtnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnCopy.Name = "toolStripBtnCopy";
            this.toolStripBtnCopy.Size = new System.Drawing.Size(29, 24);
            this.toolStripBtnCopy.Text = "toolStripButton5";
            this.toolStripBtnCopy.Click += new System.EventHandler(this.toolStripBtnCopy_Click);
            // 
            // toolStripBtnParse
            // 
            this.toolStripBtnParse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnParse.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnParse.Image")));
            this.toolStripBtnParse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnParse.Name = "toolStripBtnParse";
            this.toolStripBtnParse.Size = new System.Drawing.Size(29, 24);
            this.toolStripBtnParse.Text = "toolStripButton6";
            this.toolStripBtnParse.Click += new System.EventHandler(this.toolStripBtnParse_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripBtnUndo
            // 
            this.toolStripBtnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnUndo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnUndo.Image")));
            this.toolStripBtnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnUndo.Name = "toolStripBtnUndo";
            this.toolStripBtnUndo.Size = new System.Drawing.Size(29, 24);
            this.toolStripBtnUndo.Text = "toolStripButton1";
            this.toolStripBtnUndo.Click += new System.EventHandler(this.toolStripBtnUndo_Click);
            // 
            // toolStripBtnRedo
            // 
            this.toolStripBtnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnRedo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnRedo.Image")));
            this.toolStripBtnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnRedo.Name = "toolStripBtnRedo";
            this.toolStripBtnRedo.Size = new System.Drawing.Size(29, 24);
            this.toolStripBtnRedo.Text = "toolStripButton1";
            this.toolStripBtnRedo.Click += new System.EventHandler(this.toolStripBtnRedo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gold;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(17, 103);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3, 2, 11, 2);
            this.panel2.Size = new System.Drawing.Size(409, 153);
            this.panel2.TabIndex = 11;
            // 
            // labelGenerateStatus
            // 
            this.labelGenerateStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelGenerateStatus.AutoSize = true;
            this.labelGenerateStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGenerateStatus.Location = new System.Drawing.Point(19, 71);
            this.labelGenerateStatus.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.labelGenerateStatus.Name = "labelGenerateStatus";
            this.labelGenerateStatus.Size = new System.Drawing.Size(250, 29);
            this.labelGenerateStatus.TabIndex = 8;
            this.labelGenerateStatus.Text = "Specification source";
            // 
            // labelBuildStatus
            // 
            this.labelBuildStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBuildStatus.AutoSize = true;
            this.labelBuildStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBuildStatus.Location = new System.Drawing.Point(427, 507);
            this.labelBuildStatus.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.labelBuildStatus.Name = "labelBuildStatus";
            this.labelBuildStatus.Size = new System.Drawing.Size(152, 29);
            this.labelBuildStatus.TabIndex = 12;
            this.labelBuildStatus.Text = "Build Status";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Gold;
            this.panel3.Controls.Add(this.tbGeneratedCode);
            this.panel3.Location = new System.Drawing.Point(432, 103);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 10, 11, 2);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Size = new System.Drawing.Size(611, 404);
            this.panel3.TabIndex = 12;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Gold;
            this.panel4.Controls.Add(this.tbStatus);
            this.panel4.Location = new System.Drawing.Point(432, 539);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Size = new System.Drawing.Size(611, 79);
            this.panel4.TabIndex = 13;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.Gold;
            this.panel5.Controls.Add(this.tbSource);
            this.panel5.Location = new System.Drawing.Point(17, 263);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 10, 11, 2);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Size = new System.Drawing.Size(409, 354);
            this.panel5.TabIndex = 13;
            // 
            // tbSource
            // 
            this.tbSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSource.Location = new System.Drawing.Point(5, 6);
            this.tbSource.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSource.Multiline = true;
            this.tbSource.Name = "tbSource";
            this.tbSource.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbSource.Size = new System.Drawing.Size(397, 342);
            this.tbSource.TabIndex = 1;
            this.tbSource.TextChanged += new System.EventHandler(this.tbSource_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(427, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 29);
            this.label1.TabIndex = 14;
            this.label1.Text = "Generated code";
            // 
            // radioCS
            // 
            this.radioCS.AutoSize = true;
            this.radioCS.Checked = true;
            this.radioCS.Location = new System.Drawing.Point(225, 28);
            this.radioCS.Name = "radioCS";
            this.radioCS.Size = new System.Drawing.Size(39, 17);
            this.radioCS.TabIndex = 15;
            this.radioCS.TabStop = true;
            this.radioCS.Text = "CS";
            this.radioCS.UseVisualStyleBackColor = true;
            // 
            // radioVB
            // 
            this.radioVB.AutoSize = true;
            this.radioVB.Location = new System.Drawing.Point(270, 28);
            this.radioVB.Name = "radioVB";
            this.radioVB.Size = new System.Drawing.Size(39, 17);
            this.radioVB.TabIndex = 16;
            this.radioVB.Text = "VB";
            this.radioVB.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(796, 510);
            this.Controls.Add(this.radioVB);
            this.Controls.Add(this.radioCS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.labelBuildStatus);
            this.Controls.Add(this.labelGenerateStatus);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Formular Specification";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox tbGeneratedCode;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.TextBox tbOutputName;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label labelClassName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exiteToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripBtnNew;
        private System.Windows.Forms.ToolStripButton toolStripBtnOpen;
        private System.Windows.Forms.ToolStripButton toolStripBtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripBtnCut;
        private System.Windows.Forms.ToolStripButton toolStripBtnCopy;
        private System.Windows.Forms.ToolStripButton toolStripBtnParse;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripBtnUndo;
        private System.Windows.Forms.ToolStripButton toolStripBtnRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelGenerateStatus;
        private System.Windows.Forms.Label labelBuildStatus;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox tbSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioCS;
        private System.Windows.Forms.RadioButton radioVB;
    }
}

