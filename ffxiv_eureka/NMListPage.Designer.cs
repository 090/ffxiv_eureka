namespace ffxiv_eureka
{
    partial class NMListPage
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listView_NM = new System.Windows.Forms.ListView();
            this.chLv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRepop = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox_Chat = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox_Sh = new System.Windows.Forms.CheckBox();
            this.checkBox_Full = new System.Windows.Forms.CheckBox();
            this.checkBox_LvSort = new System.Windows.Forms.CheckBox();
            this.button_Export = new System.Windows.Forms.Button();
            this.button_Copy = new System.Windows.Forms.Button();
            this.button_Paste = new System.Windows.Forms.Button();
            this.button_Import = new System.Windows.Forms.Button();
            this.comboBox_export = new System.Windows.Forms.ComboBox();
            this.cbYamlFile = new System.Windows.Forms.ComboBox();
            this.cbLang = new System.Windows.Forms.ComboBox();
            this.button_Load = new System.Windows.Forms.Button();
            this.listView_Weather = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.tableLayoutPanel1.Controls.Add(this.listView_NM, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Chat, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbYamlFile, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbLang, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.button_Load, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.listView_Weather, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 4, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(744, 380);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // listView_NM
            // 
            this.listView_NM.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chLv,
            this.chName,
            this.chTime,
            this.chRepop});
            this.tableLayoutPanel1.SetColumnSpan(this.listView_NM, 4);
            this.listView_NM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_NM.FullRowSelect = true;
            this.listView_NM.HideSelection = false;
            this.listView_NM.Location = new System.Drawing.Point(3, 3);
            this.listView_NM.Name = "listView_NM";
            this.listView_NM.Size = new System.Drawing.Size(533, 195);
            this.listView_NM.TabIndex = 0;
            this.listView_NM.UseCompatibleStateImageBehavior = false;
            this.listView_NM.View = System.Windows.Forms.View.Details;
            // 
            // chLv
            // 
            this.chLv.Text = "Lv";
            // 
            // chName
            // 
            this.chName.Text = "Name";
            // 
            // chTime
            // 
            this.chTime.Text = "Time";
            // 
            // chRepop
            // 
            this.chRepop.Text = "Repop";
            // 
            // textBox_Chat
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBox_Chat, 4);
            this.textBox_Chat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Chat.Location = new System.Drawing.Point(3, 259);
            this.textBox_Chat.Multiline = true;
            this.textBox_Chat.Name = "textBox_Chat";
            this.textBox_Chat.Size = new System.Drawing.Size(533, 94);
            this.textBox_Chat.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 4);
            this.flowLayoutPanel1.Controls.Add(this.checkBox_Sh);
            this.flowLayoutPanel1.Controls.Add(this.checkBox_Full);
            this.flowLayoutPanel1.Controls.Add(this.checkBox_LvSort);
            this.flowLayoutPanel1.Controls.Add(this.button_Export);
            this.flowLayoutPanel1.Controls.Add(this.button_Copy);
            this.flowLayoutPanel1.Controls.Add(this.button_Paste);
            this.flowLayoutPanel1.Controls.Add(this.button_Import);
            this.flowLayoutPanel1.Controls.Add(this.comboBox_export);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 201);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(484, 55);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // checkBox_Sh
            // 
            this.checkBox_Sh.AutoSize = true;
            this.checkBox_Sh.Location = new System.Drawing.Point(3, 6);
            this.checkBox_Sh.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.checkBox_Sh.Name = "checkBox_Sh";
            this.checkBox_Sh.Size = new System.Drawing.Size(42, 16);
            this.checkBox_Sh.TabIndex = 0;
            this.checkBox_Sh.Text = "/sh";
            this.checkBox_Sh.UseVisualStyleBackColor = true;
            // 
            // checkBox_Full
            // 
            this.checkBox_Full.AutoSize = true;
            this.checkBox_Full.Location = new System.Drawing.Point(51, 6);
            this.checkBox_Full.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.checkBox_Full.Name = "checkBox_Full";
            this.checkBox_Full.Size = new System.Drawing.Size(43, 16);
            this.checkBox_Full.TabIndex = 3;
            this.checkBox_Full.Text = "Full";
            this.checkBox_Full.UseVisualStyleBackColor = true;
            // 
            // checkBox_LvSort
            // 
            this.checkBox_LvSort.AutoSize = true;
            this.checkBox_LvSort.Location = new System.Drawing.Point(100, 6);
            this.checkBox_LvSort.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.checkBox_LvSort.Name = "checkBox_LvSort";
            this.checkBox_LvSort.Size = new System.Drawing.Size(57, 16);
            this.checkBox_LvSort.TabIndex = 4;
            this.checkBox_LvSort.Text = "LvSort";
            this.checkBox_LvSort.UseVisualStyleBackColor = true;
            // 
            // button_Export
            // 
            this.button_Export.Location = new System.Drawing.Point(163, 3);
            this.button_Export.Name = "button_Export";
            this.button_Export.Size = new System.Drawing.Size(75, 23);
            this.button_Export.TabIndex = 1;
            this.button_Export.Text = "↓Export";
            this.button_Export.UseVisualStyleBackColor = true;
            this.button_Export.Click += new System.EventHandler(this.button_Export_Click);
            // 
            // button_Copy
            // 
            this.button_Copy.Location = new System.Drawing.Point(244, 3);
            this.button_Copy.Name = "button_Copy";
            this.button_Copy.Size = new System.Drawing.Size(75, 23);
            this.button_Copy.TabIndex = 1;
            this.button_Copy.Text = "Copy";
            this.button_Copy.UseVisualStyleBackColor = true;
            this.button_Copy.Click += new System.EventHandler(this.button_Copy_Click);
            // 
            // button_Paste
            // 
            this.button_Paste.Location = new System.Drawing.Point(325, 3);
            this.button_Paste.Name = "button_Paste";
            this.button_Paste.Size = new System.Drawing.Size(75, 23);
            this.button_Paste.TabIndex = 2;
            this.button_Paste.Text = "Paste";
            this.button_Paste.UseVisualStyleBackColor = true;
            this.button_Paste.Click += new System.EventHandler(this.button_Paste_Click);
            // 
            // button_Import
            // 
            this.button_Import.Location = new System.Drawing.Point(406, 3);
            this.button_Import.Name = "button_Import";
            this.button_Import.Size = new System.Drawing.Size(75, 23);
            this.button_Import.TabIndex = 0;
            this.button_Import.Text = "↑Import";
            this.button_Import.UseVisualStyleBackColor = true;
            this.button_Import.Click += new System.EventHandler(this.button_Import_Click);
            // 
            // comboBox_export
            // 
            this.comboBox_export.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_export.FormattingEnabled = true;
            this.comboBox_export.Location = new System.Drawing.Point(3, 32);
            this.comboBox_export.Name = "comboBox_export";
            this.comboBox_export.Size = new System.Drawing.Size(148, 20);
            this.comboBox_export.TabIndex = 5;
            // 
            // cbYamlFile
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cbYamlFile, 2);
            this.cbYamlFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbYamlFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYamlFile.Location = new System.Drawing.Point(3, 359);
            this.cbYamlFile.Name = "cbYamlFile";
            this.cbYamlFile.Size = new System.Drawing.Size(306, 20);
            this.cbYamlFile.TabIndex = 4;
            this.cbYamlFile.DropDown += new System.EventHandler(this.cbYamlFile_DropDown);
            this.cbYamlFile.TextChanged += new System.EventHandler(this.cbYamlFile_TextChanged);
            this.cbYamlFile.VisibleChanged += new System.EventHandler(this.cbYamlFile_VisibleChanged);
            // 
            // cbLang
            // 
            this.cbLang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLang.FormattingEnabled = true;
            this.cbLang.Location = new System.Drawing.Point(386, 359);
            this.cbLang.Name = "cbLang";
            this.cbLang.Size = new System.Drawing.Size(150, 20);
            this.cbLang.TabIndex = 5;
            this.cbLang.SelectedIndexChanged += new System.EventHandler(this.cbLang_SelectedIndexChanged);
            this.cbLang.VisibleChanged += new System.EventHandler(this.cbLang_VisibleChanged);
            // 
            // button_Load
            // 
            this.button_Load.Location = new System.Drawing.Point(312, 356);
            this.button_Load.Margin = new System.Windows.Forms.Padding(0);
            this.button_Load.Name = "button_Load";
            this.button_Load.Size = new System.Drawing.Size(71, 23);
            this.button_Load.TabIndex = 6;
            this.button_Load.Text = "Load";
            this.button_Load.UseVisualStyleBackColor = true;
            this.button_Load.Click += new System.EventHandler(this.button_Load_Click);
            // 
            // listView_Weather
            // 
            this.listView_Weather.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView_Weather.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Weather.FullRowSelect = true;
            this.listView_Weather.HideSelection = false;
            this.listView_Weather.Location = new System.Drawing.Point(542, 3);
            this.listView_Weather.Name = "listView_Weather";
            this.tableLayoutPanel1.SetRowSpan(this.listView_Weather, 3);
            this.listView_Weather.Size = new System.Drawing.Size(199, 350);
            this.listView_Weather.TabIndex = 7;
            this.listView_Weather.UseCompatibleStateImageBehavior = false;
            this.listView_Weather.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "LT";
            this.columnHeader1.Width = 47;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ET";
            this.columnHeader2.Width = 43;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Weather";
            this.columnHeader3.Width = 62;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(542, 359);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 18);
            this.button1.TabIndex = 8;
            this.button1.Text = "refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // NMListPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "NMListPage";
            this.Size = new System.Drawing.Size(744, 380);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView listView_NM;
        private System.Windows.Forms.TextBox textBox_Chat;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBox_Sh;
        private System.Windows.Forms.CheckBox checkBox_Full;
        private System.Windows.Forms.Button button_Export;
        private System.Windows.Forms.Button button_Copy;
        private System.Windows.Forms.Button button_Paste;
        private System.Windows.Forms.Button button_Import;
        private System.Windows.Forms.ComboBox cbYamlFile;
        private System.Windows.Forms.ComboBox cbLang;
        private System.Windows.Forms.Button button_Load;
        private System.Windows.Forms.ColumnHeader chLv;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chTime;
        private System.Windows.Forms.ColumnHeader chRepop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListView listView_Weather;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox_LvSort;
        private System.Windows.Forms.ComboBox comboBox_export;
    }
}
