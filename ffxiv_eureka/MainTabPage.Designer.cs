namespace ffxiv_eureka
{
    partial class MainTabPage
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_folder = new System.Windows.Forms.Button();
            this.textBox_yamlfolder = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_folder);
            this.groupBox1.Controls.Add(this.textBox_yamlfolder);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 58);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Yaml Folder";
            // 
            // button_folder
            // 
            this.button_folder.Location = new System.Drawing.Point(356, 16);
            this.button_folder.Name = "button_folder";
            this.button_folder.Size = new System.Drawing.Size(24, 23);
            this.button_folder.TabIndex = 1;
            this.button_folder.Text = "...";
            this.button_folder.UseVisualStyleBackColor = true;
            this.button_folder.Click += new System.EventHandler(this.button_folder_Click);
            // 
            // textBox_yamlfolder
            // 
            this.textBox_yamlfolder.Location = new System.Drawing.Point(6, 18);
            this.textBox_yamlfolder.Name = "textBox_yamlfolder";
            this.textBox_yamlfolder.Size = new System.Drawing.Size(344, 19);
            this.textBox_yamlfolder.TabIndex = 0;
            this.textBox_yamlfolder.TextChanged += new System.EventHandler(this.textBox_yamlfolder_TextChanged);
            // 
            // MainTabPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "MainTabPage";
            this.Size = new System.Drawing.Size(617, 404);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_folder;
        private System.Windows.Forms.TextBox textBox_yamlfolder;
    }
}
