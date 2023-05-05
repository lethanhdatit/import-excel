namespace export_excel
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
            this.label1 = new System.Windows.Forms.Label();
            this.crawlFilePathTxt = new System.Windows.Forms.TextBox();
            this.crawlFilePathBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.resultFilePathTxt = new System.Windows.Forms.TextBox();
            this.resultFilePathBtn = new System.Windows.Forms.Button();
            this.runBtn = new System.Windows.Forms.Button();
            this.openFileDialogCrawl = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogOutput = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn file crawl:";
            // 
            // crawlFilePathTxt
            // 
            this.crawlFilePathTxt.Location = new System.Drawing.Point(141, 27);
            this.crawlFilePathTxt.Name = "crawlFilePathTxt";
            this.crawlFilePathTxt.ReadOnly = true;
            this.crawlFilePathTxt.Size = new System.Drawing.Size(521, 27);
            this.crawlFilePathTxt.TabIndex = 1;
            // 
            // crawlFilePathBtn
            // 
            this.crawlFilePathBtn.Location = new System.Drawing.Point(677, 26);
            this.crawlFilePathBtn.Name = "crawlFilePathBtn";
            this.crawlFilePathBtn.Size = new System.Drawing.Size(94, 29);
            this.crawlFilePathBtn.TabIndex = 2;
            this.crawlFilePathBtn.Text = "Chọn";
            this.crawlFilePathBtn.UseVisualStyleBackColor = true;
            this.crawlFilePathBtn.Click += new System.EventHandler(this.crawlFilePathBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Chọn file xuất:";
            // 
            // resultFilePathTxt
            // 
            this.resultFilePathTxt.Location = new System.Drawing.Point(141, 69);
            this.resultFilePathTxt.Name = "resultFilePathTxt";
            this.resultFilePathTxt.ReadOnly = true;
            this.resultFilePathTxt.Size = new System.Drawing.Size(521, 27);
            this.resultFilePathTxt.TabIndex = 1;
            // 
            // resultFilePathBtn
            // 
            this.resultFilePathBtn.Location = new System.Drawing.Point(677, 68);
            this.resultFilePathBtn.Name = "resultFilePathBtn";
            this.resultFilePathBtn.Size = new System.Drawing.Size(94, 29);
            this.resultFilePathBtn.TabIndex = 2;
            this.resultFilePathBtn.Text = "Chọn";
            this.resultFilePathBtn.UseVisualStyleBackColor = true;
            this.resultFilePathBtn.Click += new System.EventHandler(this.resultFilePathBtn_Click);
            // 
            // runBtn
            // 
            this.runBtn.Location = new System.Drawing.Point(141, 120);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(521, 29);
            this.runBtn.TabIndex = 2;
            this.runBtn.Text = "Ghi";
            this.runBtn.UseVisualStyleBackColor = true;
            // 
            // openFileDialogCrawl
            // 
            this.openFileDialogCrawl.FileName = "openFileDialog1";
            // 
            // openFileDialogOutput
            // 
            this.openFileDialogOutput.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 176);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.resultFilePathBtn);
            this.Controls.Add(this.crawlFilePathBtn);
            this.Controls.Add(this.resultFilePathTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.crawlFilePathTxt);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(818, 223);
            this.MinimumSize = new System.Drawing.Size(818, 223);
            this.Name = "Form1";
            this.Text = "From DatLT - Import Excel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox crawlFilePathTxt;
        private Button crawlFilePathBtn;
        private Label label2;
        private TextBox resultFilePathTxt;
        private Button resultFilePathBtn;
        private Button runBtn;
        private OpenFileDialog openFileDialogCrawl;
        private OpenFileDialog openFileDialogOutput;
    }
}