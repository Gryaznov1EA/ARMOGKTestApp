
namespace FileSearchingApplication
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.fastTree1 = new FastTreeNS.FastTree();
            this.buttonRootChoose = new System.Windows.Forms.Button();
            this.buttonStartSearching = new System.Windows.Forms.Button();
            this.textBoxCatalogue = new System.Windows.Forms.TextBox();
            this.textBoxMask = new System.Windows.Forms.TextBox();
            this.labelCatalogue = new System.Windows.Forms.Label();
            this.labelFileMask = new System.Windows.Forms.Label();
            this.labelCurrentScannedCataloguePath = new System.Windows.Forms.Label();
            this.labelFilesFound = new System.Windows.Forms.Label();
            this.labelScannedFiles = new System.Windows.Forms.Label();
            this.labelNumberOfFilesFound = new System.Windows.Forms.Label();
            this.labelNumberOfScannedFiles = new System.Windows.Forms.Label();
            this.buttonPauseSearch = new System.Windows.Forms.Button();
            this.buttonContinueSearch = new System.Windows.Forms.Button();
            this.labelSearchTime = new System.Windows.Forms.Label();
            this.labelSearchTimeNumber = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // fastTree1
            // 
            this.fastTree1.AutoScroll = true;
            this.fastTree1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.fastTree1.BackColor = System.Drawing.SystemColors.Window;
            this.fastTree1.ImageCheckBoxOff = ((System.Drawing.Image)(resources.GetObject("fastTree1.ImageCheckBoxOff")));
            this.fastTree1.ImageCheckBoxOn = ((System.Drawing.Image)(resources.GetObject("fastTree1.ImageCheckBoxOn")));
            this.fastTree1.ImageCollapse = ((System.Drawing.Image)(resources.GetObject("fastTree1.ImageCollapse")));
            this.fastTree1.ImageDefaultIcon = ((System.Drawing.Image)(resources.GetObject("fastTree1.ImageDefaultIcon")));
            this.fastTree1.ImageEmptyExpand = ((System.Drawing.Image)(resources.GetObject("fastTree1.ImageEmptyExpand")));
            this.fastTree1.ImageExpand = ((System.Drawing.Image)(resources.GetObject("fastTree1.ImageExpand")));
            this.fastTree1.IsEditMode = false;
            this.fastTree1.Location = new System.Drawing.Point(29, 272);
            this.fastTree1.Name = "fastTree1";
            this.fastTree1.ShowExpandBoxes = true;
            this.fastTree1.Size = new System.Drawing.Size(395, 349);
            this.fastTree1.TabIndex = 0;
            // 
            // buttonRootChoose
            // 
            this.buttonRootChoose.Location = new System.Drawing.Point(29, 26);
            this.buttonRootChoose.Name = "buttonRootChoose";
            this.buttonRootChoose.Size = new System.Drawing.Size(75, 23);
            this.buttonRootChoose.TabIndex = 1;
            this.buttonRootChoose.Text = "Выбрать каталог";
            this.buttonRootChoose.UseVisualStyleBackColor = true;
            this.buttonRootChoose.Click += new System.EventHandler(this.buttonRootChoose_Click);
            // 
            // buttonStartSearching
            // 
            this.buttonStartSearching.Location = new System.Drawing.Point(349, 73);
            this.buttonStartSearching.Name = "buttonStartSearching";
            this.buttonStartSearching.Size = new System.Drawing.Size(75, 23);
            this.buttonStartSearching.TabIndex = 2;
            this.buttonStartSearching.Text = "Поиск";
            this.buttonStartSearching.UseVisualStyleBackColor = true;
            this.buttonStartSearching.Click += new System.EventHandler(this.buttonStartSearching_Click);
            // 
            // textBoxCatalogue
            // 
            this.textBoxCatalogue.Location = new System.Drawing.Point(144, 27);
            this.textBoxCatalogue.Name = "textBoxCatalogue";
            this.textBoxCatalogue.Size = new System.Drawing.Size(280, 23);
            this.textBoxCatalogue.TabIndex = 3;
            this.textBoxCatalogue.TextChanged += new System.EventHandler(this.textBoxCatalogue_TextChanged);
            // 
            // textBoxMask
            // 
            this.textBoxMask.Location = new System.Drawing.Point(29, 74);
            this.textBoxMask.Name = "textBoxMask";
            this.textBoxMask.Size = new System.Drawing.Size(280, 23);
            this.textBoxMask.TabIndex = 4;
            this.textBoxMask.TextChanged += new System.EventHandler(this.textBoxMask_TextChanged);
            // 
            // labelCatalogue
            // 
            this.labelCatalogue.AutoSize = true;
            this.labelCatalogue.Location = new System.Drawing.Point(144, 13);
            this.labelCatalogue.Name = "labelCatalogue";
            this.labelCatalogue.Size = new System.Drawing.Size(50, 15);
            this.labelCatalogue.TabIndex = 5;
            this.labelCatalogue.Text = "Каталог";
            // 
            // labelFileMask
            // 
            this.labelFileMask.AutoSize = true;
            this.labelFileMask.Location = new System.Drawing.Point(29, 56);
            this.labelFileMask.Name = "labelFileMask";
            this.labelFileMask.Size = new System.Drawing.Size(84, 15);
            this.labelFileMask.TabIndex = 6;
            this.labelFileMask.Text = "Маска поиска";
            // 
            // labelCurrentScannedCataloguePath
            // 
            this.labelCurrentScannedCataloguePath.AutoSize = true;
            this.labelCurrentScannedCataloguePath.Location = new System.Drawing.Point(29, 154);
            this.labelCurrentScannedCataloguePath.Name = "labelCurrentScannedCataloguePath";
            this.labelCurrentScannedCataloguePath.Size = new System.Drawing.Size(12, 15);
            this.labelCurrentScannedCataloguePath.TabIndex = 8;
            this.labelCurrentScannedCataloguePath.Text = "-";
            // 
            // labelFilesFound
            // 
            this.labelFilesFound.AutoSize = true;
            this.labelFilesFound.Location = new System.Drawing.Point(29, 191);
            this.labelFilesFound.Name = "labelFilesFound";
            this.labelFilesFound.Size = new System.Drawing.Size(100, 15);
            this.labelFilesFound.TabIndex = 10;
            this.labelFilesFound.Text = "Найдено файлов";
            // 
            // labelScannedFiles
            // 
            this.labelScannedFiles.AutoSize = true;
            this.labelScannedFiles.Location = new System.Drawing.Point(236, 191);
            this.labelScannedFiles.Name = "labelScannedFiles";
            this.labelScannedFiles.Size = new System.Drawing.Size(129, 15);
            this.labelScannedFiles.TabIndex = 11;
            this.labelScannedFiles.Text = "Просмотрено файлов";
            // 
            // labelNumberOfFilesFound
            // 
            this.labelNumberOfFilesFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNumberOfFilesFound.AutoSize = true;
            this.labelNumberOfFilesFound.Location = new System.Drawing.Point(171, 191);
            this.labelNumberOfFilesFound.Name = "labelNumberOfFilesFound";
            this.labelNumberOfFilesFound.Size = new System.Drawing.Size(12, 15);
            this.labelNumberOfFilesFound.TabIndex = 12;
            this.labelNumberOfFilesFound.Text = "-";
            // 
            // labelNumberOfScannedFiles
            // 
            this.labelNumberOfScannedFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNumberOfScannedFiles.AutoSize = true;
            this.labelNumberOfScannedFiles.Location = new System.Drawing.Point(412, 191);
            this.labelNumberOfScannedFiles.Name = "labelNumberOfScannedFiles";
            this.labelNumberOfScannedFiles.Size = new System.Drawing.Size(12, 15);
            this.labelNumberOfScannedFiles.TabIndex = 13;
            this.labelNumberOfScannedFiles.Text = "-";
            // 
            // buttonPauseSearch
            // 
            this.buttonPauseSearch.Location = new System.Drawing.Point(29, 225);
            this.buttonPauseSearch.Name = "buttonPauseSearch";
            this.buttonPauseSearch.Size = new System.Drawing.Size(87, 23);
            this.buttonPauseSearch.TabIndex = 14;
            this.buttonPauseSearch.Text = "Пауза";
            this.buttonPauseSearch.UseVisualStyleBackColor = true;
            this.buttonPauseSearch.Click += new System.EventHandler(this.buttonPauseSearch_Click);
            // 
            // buttonContinueSearch
            // 
            this.buttonContinueSearch.Location = new System.Drawing.Point(337, 225);
            this.buttonContinueSearch.Name = "buttonContinueSearch";
            this.buttonContinueSearch.Size = new System.Drawing.Size(87, 23);
            this.buttonContinueSearch.TabIndex = 15;
            this.buttonContinueSearch.Text = "Продолжить";
            this.buttonContinueSearch.UseVisualStyleBackColor = true;
            this.buttonContinueSearch.Click += new System.EventHandler(this.buttonContinueSearch_Click);
            // 
            // labelSearchTime
            // 
            this.labelSearchTime.AutoSize = true;
            this.labelSearchTime.Location = new System.Drawing.Point(29, 123);
            this.labelSearchTime.Name = "labelSearchTime";
            this.labelSearchTime.Size = new System.Drawing.Size(109, 15);
            this.labelSearchTime.TabIndex = 16;
            this.labelSearchTime.Text = "Прошло времени:";
            // 
            // labelSearchTimeNumber
            // 
            this.labelSearchTimeNumber.AutoSize = true;
            this.labelSearchTimeNumber.Location = new System.Drawing.Point(144, 123);
            this.labelSearchTimeNumber.Name = "labelSearchTimeNumber";
            this.labelSearchTimeNumber.Size = new System.Drawing.Size(12, 15);
            this.labelSearchTimeNumber.TabIndex = 17;
            this.labelSearchTimeNumber.Text = "-";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(462, 648);
            this.Controls.Add(this.labelSearchTimeNumber);
            this.Controls.Add(this.labelSearchTime);
            this.Controls.Add(this.buttonContinueSearch);
            this.Controls.Add(this.buttonPauseSearch);
            this.Controls.Add(this.labelNumberOfScannedFiles);
            this.Controls.Add(this.labelNumberOfFilesFound);
            this.Controls.Add(this.labelScannedFiles);
            this.Controls.Add(this.labelFilesFound);
            this.Controls.Add(this.labelCurrentScannedCataloguePath);
            this.Controls.Add(this.labelFileMask);
            this.Controls.Add(this.labelCatalogue);
            this.Controls.Add(this.textBoxMask);
            this.Controls.Add(this.textBoxCatalogue);
            this.Controls.Add(this.buttonStartSearching);
            this.Controls.Add(this.buttonRootChoose);
            this.Controls.Add(this.fastTree1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FastTreeNS.FastTree fastTree1;
        private System.Windows.Forms.Button buttonRootChoose;
        private System.Windows.Forms.Button buttonStartSearching;
        private System.Windows.Forms.TextBox textBoxCatalogue;
        private System.Windows.Forms.TextBox textBoxMask;
        private System.Windows.Forms.Label labelCatalogue;
        private System.Windows.Forms.Label labelFileMask;
        private System.Windows.Forms.Label labelCurrentScannedCataloguePath;
        private System.Windows.Forms.Label labelFilesFound;
        private System.Windows.Forms.Label labelScannedFiles;
        private System.Windows.Forms.Label labelNumberOfFilesFound;
        private System.Windows.Forms.Label labelNumberOfScannedFiles;
        private System.Windows.Forms.Button buttonPauseSearch;
        private System.Windows.Forms.Button buttonContinueSearch;
        private System.Windows.Forms.Label labelSearchTime;
        private System.Windows.Forms.Label labelSearchTimeNumber;
        private System.Windows.Forms.Timer timer1;
    }
}

