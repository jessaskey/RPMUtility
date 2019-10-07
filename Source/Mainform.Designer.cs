namespace RPMUtility
{
    partial class Mainform
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
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLogFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFirstSoundID = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonParse = new System.Windows.Forms.Button();
            this.buttonDump = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBoxDataParserOutput = new System.Windows.Forms.TextBox();
            this.buttonDataParse = new System.Windows.Forms.Button();
            this.textBoxDataParserInput = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBoxHavocParserInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxHavocParserDataType = new System.Windows.Forms.ComboBox();
            this.buttonHavocParserParseData = new System.Windows.Forms.Button();
            this.textBoxHavocParserOutput = new System.Windows.Forms.TextBox();
            this.textBoxHavocParserVisual = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Log File:";
            // 
            // textBoxLogFile
            // 
            this.textBoxLogFile.Location = new System.Drawing.Point(118, 62);
            this.textBoxLogFile.Name = "textBoxLogFile";
            this.textBoxLogFile.Size = new System.Drawing.Size(505, 20);
            this.textBoxLogFile.TabIndex = 1;
            this.textBoxLogFile.Text = "C:\\SVN\\havoc\\SoundParser\\irobot.log";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "First SoundID:";
            // 
            // textBoxFirstSoundID
            // 
            this.textBoxFirstSoundID.Location = new System.Drawing.Point(118, 91);
            this.textBoxFirstSoundID.Name = "textBoxFirstSoundID";
            this.textBoxFirstSoundID.Size = new System.Drawing.Size(121, 20);
            this.textBoxFirstSoundID.TabIndex = 3;
            this.textBoxFirstSoundID.Text = "02";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.FullRowSelect = true;
            listViewGroup3.Header = "ListViewGroup";
            listViewGroup3.Name = "listViewGroup1";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3});
            this.listView1.Location = new System.Drawing.Point(19, 126);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(872, 361);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Channels";
            this.columnHeader2.Width = 122;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ticks";
            this.columnHeader3.Width = 109;
            // 
            // buttonParse
            // 
            this.buttonParse.Location = new System.Drawing.Point(737, 91);
            this.buttonParse.Name = "buttonParse";
            this.buttonParse.Size = new System.Drawing.Size(73, 23);
            this.buttonParse.TabIndex = 5;
            this.buttonParse.Text = "Parse";
            this.buttonParse.UseVisualStyleBackColor = true;
            this.buttonParse.Click += new System.EventHandler(this.buttonParse_Click);
            // 
            // buttonDump
            // 
            this.buttonDump.Location = new System.Drawing.Point(818, 91);
            this.buttonDump.Name = "buttonDump";
            this.buttonDump.Size = new System.Drawing.Size(73, 23);
            this.buttonDump.TabIndex = 6;
            this.buttonDump.Text = "Dump";
            this.buttonDump.UseVisualStyleBackColor = true;
            this.buttonDump.Click += new System.EventHandler(this.buttonDump_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(916, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(916, 531);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBoxLogFile);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBoxFirstSoundID);
            this.tabPage1.Controls.Add(this.buttonDump);
            this.tabPage1.Controls.Add(this.buttonParse);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(908, 505);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sample Converter";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(19, 15);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(872, 34);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBoxDataParserOutput);
            this.tabPage2.Controls.Add(this.buttonDataParse);
            this.tabPage2.Controls.Add(this.textBoxDataParserInput);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1100, 505);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Shitty Tab";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBoxDataParserOutput
            // 
            this.textBoxDataParserOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDataParserOutput.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDataParserOutput.Location = new System.Drawing.Point(17, 221);
            this.textBoxDataParserOutput.Multiline = true;
            this.textBoxDataParserOutput.Name = "textBoxDataParserOutput";
            this.textBoxDataParserOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDataParserOutput.Size = new System.Drawing.Size(1060, 266);
            this.textBoxDataParserOutput.TabIndex = 5;
            this.textBoxDataParserOutput.WordWrap = false;
            // 
            // buttonDataParse
            // 
            this.buttonDataParse.Location = new System.Drawing.Point(871, 192);
            this.buttonDataParse.Name = "buttonDataParse";
            this.buttonDataParse.Size = new System.Drawing.Size(206, 23);
            this.buttonDataParse.TabIndex = 4;
            this.buttonDataParse.Text = "Parse Envelope from Data Stream";
            this.buttonDataParse.UseVisualStyleBackColor = true;
            this.buttonDataParse.Click += new System.EventHandler(this.ButtonDataParse_Click);
            // 
            // textBoxDataParserInput
            // 
            this.textBoxDataParserInput.Location = new System.Drawing.Point(17, 63);
            this.textBoxDataParserInput.Multiline = true;
            this.textBoxDataParserInput.Name = "textBoxDataParserInput";
            this.textBoxDataParserInput.Size = new System.Drawing.Size(1060, 123);
            this.textBoxDataParserInput.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textBoxHavocParserVisual);
            this.tabPage3.Controls.Add(this.textBoxHavocParserOutput);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.comboBoxHavocParserDataType);
            this.tabPage3.Controls.Add(this.buttonHavocParserParseData);
            this.tabPage3.Controls.Add(this.textBoxHavocParserInput);
            this.tabPage3.Controls.Add(this.textBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(908, 505);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Havoc Converter";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(13, 17);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(1073, 34);
            this.textBox2.TabIndex = 8;
            this.textBox2.Text = "This tab will take assembler formatted bytes and parse them into a well commented" +
    " macro format as well as provide a graphic.\r\n";
            // 
            // textBoxHavocParserInput
            // 
            this.textBoxHavocParserInput.Location = new System.Drawing.Point(13, 46);
            this.textBoxHavocParserInput.Multiline = true;
            this.textBoxHavocParserInput.Name = "textBoxHavocParserInput";
            this.textBoxHavocParserInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxHavocParserInput.Size = new System.Drawing.Size(257, 213);
            this.textBoxHavocParserInput.TabIndex = 9;
            this.textBoxHavocParserInput.Text = ".byte $02,$A0,$01\r\n.byte $0A,$F0,$FF\r\n.byte $FE,$10,$00\r\n.byte $02,$10,$00\r\n.byte" +
    " $02,$D0,$FF\r\n.byte $0A,$10,$00\r\n.byte $02,$20,$00\r\n.byte $02,$70,$F6\r\n.byte $16" +
    ",$00,$00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "DataType:";
            // 
            // comboBoxHavocParserDataType
            // 
            this.comboBoxHavocParserDataType.FormattingEnabled = true;
            this.comboBoxHavocParserDataType.Items.AddRange(new object[] {
            "CTRL",
            "FREQ"});
            this.comboBoxHavocParserDataType.Location = new System.Drawing.Point(348, 54);
            this.comboBoxHavocParserDataType.Name = "comboBoxHavocParserDataType";
            this.comboBoxHavocParserDataType.Size = new System.Drawing.Size(74, 21);
            this.comboBoxHavocParserDataType.TabIndex = 11;
            // 
            // buttonHavocParserParseData
            // 
            this.buttonHavocParserParseData.Location = new System.Drawing.Point(292, 97);
            this.buttonHavocParserParseData.Name = "buttonHavocParserParseData";
            this.buttonHavocParserParseData.Size = new System.Drawing.Size(130, 23);
            this.buttonHavocParserParseData.TabIndex = 10;
            this.buttonHavocParserParseData.Text = "Parse Data";
            this.buttonHavocParserParseData.UseVisualStyleBackColor = true;
            this.buttonHavocParserParseData.Click += new System.EventHandler(this.ButtonHavocParserParseData_Click);
            // 
            // textBoxHavocParserOutput
            // 
            this.textBoxHavocParserOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxHavocParserOutput.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHavocParserOutput.Location = new System.Drawing.Point(446, 46);
            this.textBoxHavocParserOutput.Multiline = true;
            this.textBoxHavocParserOutput.Name = "textBoxHavocParserOutput";
            this.textBoxHavocParserOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxHavocParserOutput.Size = new System.Drawing.Size(454, 213);
            this.textBoxHavocParserOutput.TabIndex = 13;
            this.textBoxHavocParserOutput.WordWrap = false;
            // 
            // textBoxHavocParserVisual
            // 
            this.textBoxHavocParserVisual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxHavocParserVisual.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHavocParserVisual.Location = new System.Drawing.Point(13, 276);
            this.textBoxHavocParserVisual.Multiline = true;
            this.textBoxHavocParserVisual.Name = "textBoxHavocParserVisual";
            this.textBoxHavocParserVisual.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxHavocParserVisual.Size = new System.Drawing.Size(887, 221);
            this.textBoxHavocParserVisual.TabIndex = 14;
            this.textBoxHavocParserVisual.WordWrap = false;
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 556);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Mainform";
            this.Text = "Sound Parser";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Mainform_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLogFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFirstSoundID;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button buttonParse;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button buttonDump;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxDataParserOutput;
        private System.Windows.Forms.Button buttonDataParse;
        private System.Windows.Forms.TextBox textBoxDataParserInput;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBoxHavocParserInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxHavocParserDataType;
        private System.Windows.Forms.Button buttonHavocParserParseData;
        private System.Windows.Forms.TextBox textBoxHavocParserOutput;
        private System.Windows.Forms.TextBox textBoxHavocParserVisual;
    }
}

