namespace MySQLBuilder
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvMapping = new System.Windows.Forms.DataGridView();
            this.tbInputFilePath = new System.Windows.Forms.TextBox();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.btnSelectDest = new System.Windows.Forms.Button();
            this.tbOutputFile = new System.Windows.Forms.TextBox();
            this.rtbPreview = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.cbOperation = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTableName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pWildcards = new System.Windows.Forms.Panel();
            this.cbDeleteInputOnCompletion = new System.Windows.Forms.CheckBox();
            this.nudVolSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cbWhereID = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbCTIfNotExists = new System.Windows.Forms.CheckBox();
            this.btnCopyNames = new System.Windows.Forms.Button();
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.InputCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutputCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.LengthCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNull = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colPrimary = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIgnore = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMapping)).BeginInit();
            this.pWildcards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVolSize)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMapping
            // 
            this.dgvMapping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMapping.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InputCol,
            this.OutputCol,
            this.DTCol,
            this.LengthCol,
            this.colNull,
            this.colPrimary,
            this.colIgnore});
            this.dgvMapping.Location = new System.Drawing.Point(12, 104);
            this.dgvMapping.Name = "dgvMapping";
            this.dgvMapping.RowHeadersWidth = 51;
            this.dgvMapping.RowTemplate.Height = 29;
            this.dgvMapping.Size = new System.Drawing.Size(894, 250);
            this.dgvMapping.TabIndex = 0;
            this.dgvMapping.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMapping_CellContentClick);
            // 
            // tbInputFilePath
            // 
            this.tbInputFilePath.Location = new System.Drawing.Point(109, 9);
            this.tbInputFilePath.Name = "tbInputFilePath";
            this.tbInputFilePath.Size = new System.Drawing.Size(562, 27);
            this.tbInputFilePath.TabIndex = 1;
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(677, 7);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(111, 29);
            this.btnLoadFile.TabIndex = 2;
            this.btnLoadFile.Text = "Load File";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // btnSelectDest
            // 
            this.btnSelectDest.Location = new System.Drawing.Point(629, 488);
            this.btnSelectDest.Name = "btnSelectDest";
            this.btnSelectDest.Size = new System.Drawing.Size(138, 29);
            this.btnSelectDest.TabIndex = 4;
            this.btnSelectDest.Text = "Select Destination";
            this.btnSelectDest.UseVisualStyleBackColor = true;
            this.btnSelectDest.Click += new System.EventHandler(this.btnSelectDest_Click);
            // 
            // tbOutputFile
            // 
            this.tbOutputFile.Location = new System.Drawing.Point(109, 488);
            this.tbOutputFile.Name = "tbOutputFile";
            this.tbOutputFile.Size = new System.Drawing.Size(514, 27);
            this.tbOutputFile.TabIndex = 3;
            // 
            // rtbPreview
            // 
            this.rtbPreview.Location = new System.Drawing.Point(180, 434);
            this.rtbPreview.Name = "rtbPreview";
            this.rtbPreview.Size = new System.Drawing.Size(726, 45);
            this.rtbPreview.TabIndex = 5;
            this.rtbPreview.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mapping";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(12, 434);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(162, 45);
            this.btnPreview.TabIndex = 8;
            this.btnPreview.Text = "View Preview ==>";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // cbOperation
            // 
            this.cbOperation.FormattingEnabled = true;
            this.cbOperation.Items.AddRange(new object[] {
            "INSERT",
            "UPDATE"});
            this.cbOperation.Location = new System.Drawing.Point(140, 8);
            this.cbOperation.Name = "cbOperation";
            this.cbOperation.Size = new System.Drawing.Size(273, 28);
            this.cbOperation.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Select Operation:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Table Name:";
            // 
            // tbTableName
            // 
            this.tbTableName.Location = new System.Drawing.Point(109, 43);
            this.tbTableName.Name = "tbTableName";
            this.tbTableName.Size = new System.Drawing.Size(562, 27);
            this.tbTableName.TabIndex = 12;
            this.tbTableName.Text = "New Table";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Input File:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 491);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Output File:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileLoad";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(677, 42);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(111, 29);
            this.btnSaveConfig.TabIndex = 15;
            this.btnSaveConfig.Text = "Save Config";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(773, 488);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(133, 29);
            this.btnGenerate.TabIndex = 16;
            this.btnGenerate.Text = "Generate/Save";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // pWildcards
            // 
            this.pWildcards.Controls.Add(this.cbDeleteInputOnCompletion);
            this.pWildcards.Controls.Add(this.nudVolSize);
            this.pWildcards.Controls.Add(this.label2);
            this.pWildcards.Controls.Add(this.cbWhereID);
            this.pWildcards.Controls.Add(this.label7);
            this.pWildcards.Controls.Add(this.cbCTIfNotExists);
            this.pWildcards.Controls.Add(this.cbOperation);
            this.pWildcards.Controls.Add(this.label3);
            this.pWildcards.Location = new System.Drawing.Point(12, 362);
            this.pWildcards.Name = "pWildcards";
            this.pWildcards.Size = new System.Drawing.Size(894, 66);
            this.pWildcards.TabIndex = 17;
            // 
            // cbDeleteInputOnCompletion
            // 
            this.cbDeleteInputOnCompletion.AutoSize = true;
            this.cbDeleteInputOnCompletion.Location = new System.Drawing.Point(566, 37);
            this.cbDeleteInputOnCompletion.Name = "cbDeleteInputOnCompletion";
            this.cbDeleteInputOnCompletion.Size = new System.Drawing.Size(205, 24);
            this.cbDeleteInputOnCompletion.TabIndex = 22;
            this.cbDeleteInputOnCompletion.Text = "Delete File on Completion";
            this.cbDeleteInputOnCompletion.UseVisualStyleBackColor = true;
            this.cbDeleteInputOnCompletion.CheckedChanged += new System.EventHandler(this.cbDeleteInputOnCompletion_CheckedChanged);
            // 
            // nudVolSize
            // 
            this.nudVolSize.Location = new System.Drawing.Point(140, 39);
            this.nudVolSize.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudVolSize.Name = "nudVolSize";
            this.nudVolSize.Size = new System.Drawing.Size(273, 27);
            this.nudVolSize.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Volume Size:";
            // 
            // cbWhereID
            // 
            this.cbWhereID.AutoSize = true;
            this.cbWhereID.Location = new System.Drawing.Point(759, 10);
            this.cbWhereID.Name = "cbWhereID";
            this.cbWhereID.Size = new System.Drawing.Size(130, 24);
            this.cbWhereID.TabIndex = 19;
            this.cbWhereID.Text = "Where ID = _id";
            this.cbWhereID.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(419, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Configuration Flags:";
            // 
            // cbCTIfNotExists
            // 
            this.cbCTIfNotExists.AutoSize = true;
            this.cbCTIfNotExists.Location = new System.Drawing.Point(566, 10);
            this.cbCTIfNotExists.Name = "cbCTIfNotExists";
            this.cbCTIfNotExists.Size = new System.Drawing.Size(189, 24);
            this.cbCTIfNotExists.TabIndex = 0;
            this.cbCTIfNotExists.Text = "Create Table If Not Exist";
            this.cbCTIfNotExists.UseVisualStyleBackColor = true;
            // 
            // btnCopyNames
            // 
            this.btnCopyNames.Location = new System.Drawing.Point(87, 71);
            this.btnCopyNames.Name = "btnCopyNames";
            this.btnCopyNames.Size = new System.Drawing.Size(132, 29);
            this.btnCopyNames.TabIndex = 18;
            this.btnCopyNames.Text = "Copy Names =>";
            this.btnCopyNames.UseVisualStyleBackColor = true;
            this.btnCopyNames.Click += new System.EventHandler(this.button1_Click);
            // 
            // rtbConsole
            // 
            this.rtbConsole.Location = new System.Drawing.Point(11, 23);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.ReadOnly = true;
            this.rtbConsole.Size = new System.Drawing.Size(866, 93);
            this.rtbConsole.TabIndex = 19;
            this.rtbConsole.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "Console Log:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rtbConsole);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(12, 521);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(889, 125);
            this.panel1.TabIndex = 21;
            // 
            // InputCol
            // 
            this.InputCol.HeaderText = "Input Column";
            this.InputCol.MinimumWidth = 6;
            this.InputCol.Name = "InputCol";
            this.InputCol.ReadOnly = true;
            this.InputCol.Width = 175;
            // 
            // OutputCol
            // 
            this.OutputCol.HeaderText = "Target Column";
            this.OutputCol.MinimumWidth = 6;
            this.OutputCol.Name = "OutputCol";
            this.OutputCol.Width = 175;
            // 
            // DTCol
            // 
            this.DTCol.HeaderText = "Data Type";
            this.DTCol.Items.AddRange(new object[] {
            "TINYINT",
            "INT",
            "FLOAT",
            "VARCHAR",
            "TEXT",
            "TEXT",
            "DATE",
            "DATETIME",
            "TIMESTAMP",
            "JSON"});
            this.DTCol.MinimumWidth = 6;
            this.DTCol.Name = "DTCol";
            this.DTCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DTCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DTCol.Width = 125;
            // 
            // LengthCol
            // 
            this.LengthCol.HeaderText = "Length";
            this.LengthCol.MinimumWidth = 6;
            this.LengthCol.Name = "LengthCol";
            this.LengthCol.Width = 125;
            // 
            // colNull
            // 
            this.colNull.HeaderText = "NULL";
            this.colNull.MinimumWidth = 6;
            this.colNull.Name = "colNull";
            this.colNull.Width = 75;
            // 
            // colPrimary
            // 
            this.colPrimary.HeaderText = "isPrimary";
            this.colPrimary.MinimumWidth = 6;
            this.colPrimary.Name = "colPrimary";
            this.colPrimary.Width = 85;
            // 
            // colIgnore
            // 
            this.colIgnore.HeaderText = "Ignore";
            this.colIgnore.MinimumWidth = 6;
            this.colIgnore.Name = "colIgnore";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 649);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCopyNames);
            this.Controls.Add(this.pWildcards);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnSaveConfig);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbTableName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbPreview);
            this.Controls.Add(this.btnSelectDest);
            this.Controls.Add(this.tbOutputFile);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.tbInputFilePath);
            this.Controls.Add(this.dgvMapping);
            this.Name = "Form1";
            this.Text = "MySQL Builder - Map CSV and JSON to MySQL";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMapping)).EndInit();
            this.pWildcards.ResumeLayout(false);
            this.pWildcards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVolSize)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvMapping;
        private TextBox tbInputFilePath;
        private Button btnLoadFile;
        private Button btnSelectDest;
        private TextBox tbOutputFile;
        private RichTextBox rtbPreview;
        private Label label1;
        private Button btnPreview;
        private ComboBox cbOperation;
        private Label label3;
        private Label label4;
        private TextBox tbTableName;
        private Label label5;
        private Label label6;
        private OpenFileDialog openFileDialog1;
        private Button btnSaveConfig;
        private Button btnGenerate;
        private SaveFileDialog saveFileDialog1;
        private Panel pWildcards;
        private Label label7;
        private CheckBox cbCTIfNotExists;
        private CheckBox cbWhereID;
        private Button btnCopyNames;
        private NumericUpDown nudVolSize;
        private Label label2;
        private CheckBox cbDeleteInputOnCompletion;
        private RichTextBox rtbConsole;
        private Label label8;
        private Panel panel1;
        private DataGridViewTextBoxColumn InputCol;
        private DataGridViewTextBoxColumn OutputCol;
        private DataGridViewComboBoxColumn DTCol;
        private DataGridViewTextBoxColumn LengthCol;
        private DataGridViewCheckBoxColumn colNull;
        private DataGridViewCheckBoxColumn colPrimary;
        private DataGridViewCheckBoxColumn colIgnore;
    }
}