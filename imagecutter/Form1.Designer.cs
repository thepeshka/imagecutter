namespace imagecutter
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.tbSourcePath = new System.Windows.Forms.TextBox();
            this.bBrowseSource = new System.Windows.Forms.Button();
            this.tbOutputPath = new System.Windows.Forms.TextBox();
            this.bOutputBrowse = new System.Windows.Forms.Button();
            this.lStatus = new System.Windows.Forms.Label();
            this.bStart = new System.Windows.Forms.Button();
            this.pbMain = new System.Windows.Forms.ProgressBar();
            this.pbSub = new System.Windows.Forms.ProgressBar();
            this.lSubStatus = new System.Windows.Forms.Label();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.dlgBrowseFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.ltbSource = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudIterations = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudChunkSize = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChunkSize)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSourcePath
            // 
            this.tbSourcePath.Location = new System.Drawing.Point(60, 13);
            this.tbSourcePath.Name = "tbSourcePath";
            this.tbSourcePath.Size = new System.Drawing.Size(162, 20);
            this.tbSourcePath.TabIndex = 0;
            this.tbSourcePath.TextChanged += new System.EventHandler(this.tbSourcePath_TextChanged);
            // 
            // bBrowseSource
            // 
            this.bBrowseSource.Location = new System.Drawing.Point(229, 9);
            this.bBrowseSource.Name = "bBrowseSource";
            this.bBrowseSource.Size = new System.Drawing.Size(36, 23);
            this.bBrowseSource.TabIndex = 1;
            this.bBrowseSource.Text = "...";
            this.bBrowseSource.UseVisualStyleBackColor = true;
            this.bBrowseSource.Click += new System.EventHandler(this.bBrowseSource_Click);
            // 
            // tbOutputPath
            // 
            this.tbOutputPath.Location = new System.Drawing.Point(60, 40);
            this.tbOutputPath.Name = "tbOutputPath";
            this.tbOutputPath.Size = new System.Drawing.Size(162, 20);
            this.tbOutputPath.TabIndex = 2;
            // 
            // bOutputBrowse
            // 
            this.bOutputBrowse.Location = new System.Drawing.Point(229, 37);
            this.bOutputBrowse.Name = "bOutputBrowse";
            this.bOutputBrowse.Size = new System.Drawing.Size(36, 23);
            this.bOutputBrowse.TabIndex = 3;
            this.bOutputBrowse.Text = "...";
            this.bOutputBrowse.UseVisualStyleBackColor = true;
            this.bOutputBrowse.Click += new System.EventHandler(this.bOutputBrowse_Click);
            // 
            // lStatus
            // 
            this.lStatus.Location = new System.Drawing.Point(12, 148);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(252, 23);
            this.lStatus.TabIndex = 4;
            this.lStatus.Text = "Please input source path";
            this.lStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(12, 122);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(252, 23);
            this.bStart.TabIndex = 5;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // pbMain
            // 
            this.pbMain.Location = new System.Drawing.Point(12, 174);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(253, 23);
            this.pbMain.TabIndex = 6;
            // 
            // pbSub
            // 
            this.pbSub.Location = new System.Drawing.Point(12, 230);
            this.pbSub.Name = "pbSub";
            this.pbSub.Size = new System.Drawing.Size(252, 23);
            this.pbSub.TabIndex = 7;
            this.pbSub.Click += new System.EventHandler(this.progressBar2_Click);
            // 
            // lSubStatus
            // 
            this.lSubStatus.Location = new System.Drawing.Point(12, 204);
            this.lSubStatus.Name = "lSubStatus";
            this.lSubStatus.Size = new System.Drawing.Size(252, 23);
            this.lSubStatus.TabIndex = 8;
            this.lSubStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.Filter = "PSD|*.psd|PNG|*.png|JPG|*.jpg";
            // 
            // ltbSource
            // 
            this.ltbSource.AutoSize = true;
            this.ltbSource.Location = new System.Drawing.Point(16, 16);
            this.ltbSource.Name = "ltbSource";
            this.ltbSource.Size = new System.Drawing.Size(41, 13);
            this.ltbSource.TabIndex = 9;
            this.ltbSource.Text = "Source";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Output";
            // 
            // nudIterations
            // 
            this.nudIterations.Location = new System.Drawing.Point(72, 70);
            this.nudIterations.Name = "nudIterations";
            this.nudIterations.Size = new System.Drawing.Size(193, 20);
            this.nudIterations.TabIndex = 11;
            this.nudIterations.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Iterations";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // nudChunkSize
            // 
            this.nudChunkSize.Increment = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudChunkSize.Location = new System.Drawing.Point(72, 96);
            this.nudChunkSize.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.nudChunkSize.Name = "nudChunkSize";
            this.nudChunkSize.Size = new System.Drawing.Size(193, 20);
            this.nudChunkSize.TabIndex = 13;
            this.nudChunkSize.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.nudChunkSize.ValueChanged += new System.EventHandler(this.nudChunkSize_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 26);
            this.label3.TabIndex = 14;
            this.label3.Text = "Chunk\r\nSize";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 262);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudChunkSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudIterations);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ltbSource);
            this.Controls.Add(this.lSubStatus);
            this.Controls.Add(this.pbSub);
            this.Controls.Add(this.pbMain);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.lStatus);
            this.Controls.Add(this.bOutputBrowse);
            this.Controls.Add(this.tbOutputPath);
            this.Controls.Add(this.bBrowseSource);
            this.Controls.Add(this.tbSourcePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.Text = "Image Cutter";
            this.Load += new System.EventHandler(this.mainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChunkSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSourcePath;
        private System.Windows.Forms.Button bBrowseSource;
        private System.Windows.Forms.TextBox tbOutputPath;
        private System.Windows.Forms.Button bOutputBrowse;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.ProgressBar pbMain;
        private System.Windows.Forms.ProgressBar pbSub;
        private System.Windows.Forms.Label lSubStatus;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.FolderBrowserDialog dlgBrowseFolder;
        private System.Windows.Forms.Label ltbSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudIterations;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudChunkSize;
        private System.Windows.Forms.Label label3;
    }
}

