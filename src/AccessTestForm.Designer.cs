namespace AccessTest
{
    partial class AccessTest
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.textAccdbFilePath = new System.Windows.Forms.TextBox();
            this.buttonChooseFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonAggregateQuery = new System.Windows.Forms.Button();
            this.buttonSelectPivot = new System.Windows.Forms.Button();
            this.buttonCompactDatabase = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.buttonDropTable = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textAccdbFilePath
            // 
            this.textAccdbFilePath.Location = new System.Drawing.Point(6, 18);
            this.textAccdbFilePath.Name = "textAccdbFilePath";
            this.textAccdbFilePath.Size = new System.Drawing.Size(422, 19);
            this.textAccdbFilePath.TabIndex = 1;
            // 
            // buttonChooseFile
            // 
            this.buttonChooseFile.Location = new System.Drawing.Point(6, 43);
            this.buttonChooseFile.Name = "buttonChooseFile";
            this.buttonChooseFile.Size = new System.Drawing.Size(422, 23);
            this.buttonChooseFile.TabIndex = 2;
            this.buttonChooseFile.Text = "既存のaccdbファイルを選択する";
            this.buttonChooseFile.UseVisualStyleBackColor = true;
            this.buttonChooseFile.Click += new System.EventHandler(this.buttonChooseFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textAccdbFilePath);
            this.groupBox1.Controls.Add(this.buttonChooseFile);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 83);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "(1) 操作対象のaccdbファイルを選択してください";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonAggregateQuery);
            this.groupBox2.Controls.Add(this.buttonSelectPivot);
            this.groupBox2.Controls.Add(this.buttonCompactDatabase);
            this.groupBox2.Controls.Add(this.buttonDelete);
            this.groupBox2.Controls.Add(this.buttonUpdate);
            this.groupBox2.Controls.Add(this.buttonSelect);
            this.groupBox2.Controls.Add(this.buttonInsert);
            this.groupBox2.Controls.Add(this.buttonDropTable);
            this.groupBox2.Controls.Add(this.buttonCreate);
            this.groupBox2.Location = new System.Drawing.Point(13, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(433, 365);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "(2) ボタンを押して操作を行ってください";
            // 
            // buttonAggregateQuery
            // 
            this.buttonAggregateQuery.Location = new System.Drawing.Point(216, 179);
            this.buttonAggregateQuery.Name = "buttonAggregateQuery";
            this.buttonAggregateQuery.Size = new System.Drawing.Size(190, 40);
            this.buttonAggregateQuery.TabIndex = 8;
            this.buttonAggregateQuery.Text = "Aggregate Query";
            this.buttonAggregateQuery.UseVisualStyleBackColor = true;
            this.buttonAggregateQuery.Click += new System.EventHandler(this.buttonAggregateQuery_Click);
            // 
            // buttonSelectPivot
            // 
            this.buttonSelectPivot.Location = new System.Drawing.Point(216, 225);
            this.buttonSelectPivot.Name = "buttonSelectPivot";
            this.buttonSelectPivot.Size = new System.Drawing.Size(190, 40);
            this.buttonSelectPivot.TabIndex = 7;
            this.buttonSelectPivot.Text = "PIVOT";
            this.buttonSelectPivot.UseVisualStyleBackColor = true;
            this.buttonSelectPivot.Click += new System.EventHandler(this.buttonSelectPivot_Click);
            // 
            // buttonCompactDatabase
            // 
            this.buttonCompactDatabase.Location = new System.Drawing.Point(20, 120);
            this.buttonCompactDatabase.Name = "buttonCompactDatabase";
            this.buttonCompactDatabase.Size = new System.Drawing.Size(386, 40);
            this.buttonCompactDatabase.TabIndex = 6;
            this.buttonCompactDatabase.Text = "CompactDatabase";
            this.buttonCompactDatabase.UseVisualStyleBackColor = true;
            this.buttonCompactDatabase.Click += new System.EventHandler(this.buttonCompactDatabase_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(20, 317);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(190, 40);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "DELETE";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(20, 271);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(190, 40);
            this.buttonUpdate.TabIndex = 4;
            this.buttonUpdate.Text = "UPDATE";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(20, 225);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(190, 40);
            this.buttonSelect.TabIndex = 3;
            this.buttonSelect.Text = "SELECT * FROM ...";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // buttonInsert
            // 
            this.buttonInsert.Location = new System.Drawing.Point(20, 179);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(190, 40);
            this.buttonInsert.TabIndex = 2;
            this.buttonInsert.Text = "INSERT INTO ...";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // buttonDropTable
            // 
            this.buttonDropTable.Location = new System.Drawing.Point(20, 64);
            this.buttonDropTable.Name = "buttonDropTable";
            this.buttonDropTable.Size = new System.Drawing.Size(386, 40);
            this.buttonDropTable.TabIndex = 1;
            this.buttonDropTable.Text = "DROP TABLE";
            this.buttonDropTable.UseVisualStyleBackColor = true;
            this.buttonDropTable.Click += new System.EventHandler(this.buttonDropTable_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(20, 18);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(386, 40);
            this.buttonCreate.TabIndex = 0;
            this.buttonCreate.Text = "CREATE TABLE";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // AccessTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 475);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AccessTest";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textAccdbFilePath;
        private System.Windows.Forms.Button buttonChooseFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.Button buttonDropTable;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonCompactDatabase;
        private System.Windows.Forms.Button buttonSelectPivot;
        private System.Windows.Forms.Button buttonAggregateQuery;
    }
}

