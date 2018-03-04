namespace WindowsInputRecorder.Forms
{
    partial class MainForm
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
            if (disposing)
            {
                session.Dispose();
                options.Dispose();

                if (components != null)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.loopNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.aboutButton = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.saveAsButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.recordButton = new System.Windows.Forms.Button();
            this.textBox = new WindowsInputRecorder.Controls.TextBoxEx();
            this.loopImageLabel = new WindowsInputRecorder.UserControls.ImageLabel();
            this.speedImageLabel = new WindowsInputRecorder.UserControls.ImageLabel();
            this.speedNumericTrackBar = new WindowsInputRecorder.UserControls.NumericTrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.loopNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // loopNumericUpDown
            // 
            this.loopNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.loopNumericUpDown.Location = new System.Drawing.Point(396, 313);
            this.loopNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.loopNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.loopNumericUpDown.Name = "loopNumericUpDown";
            this.loopNumericUpDown.Size = new System.Drawing.Size(60, 23);
            this.loopNumericUpDown.TabIndex = 11;
            this.loopNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // aboutButton
            // 
            this.aboutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutButton.Image = global::WindowsInputRecorder.Properties.Resources.user;
            this.aboutButton.Location = new System.Drawing.Point(672, 12);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(100, 30);
            this.aboutButton.TabIndex = 5;
            this.aboutButton.Text = "About";
            this.aboutButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // newButton
            // 
            this.newButton.Image = global::WindowsInputRecorder.Properties.Resources.page_white;
            this.newButton.Location = new System.Drawing.Point(12, 12);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(100, 30);
            this.newButton.TabIndex = 0;
            this.newButton.Text = "New";
            this.newButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // openButton
            // 
            this.openButton.Image = global::WindowsInputRecorder.Properties.Resources.folder_go;
            this.openButton.Location = new System.Drawing.Point(118, 12);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(100, 30);
            this.openButton.TabIndex = 1;
            this.openButton.Text = "Open...";
            this.openButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Image = global::WindowsInputRecorder.Properties.Resources.disk;
            this.saveButton.Location = new System.Drawing.Point(224, 12);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 30);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // saveAsButton
            // 
            this.saveAsButton.Image = global::WindowsInputRecorder.Properties.Resources.disk;
            this.saveAsButton.Location = new System.Drawing.Point(330, 12);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(100, 30);
            this.saveAsButton.TabIndex = 3;
            this.saveAsButton.Text = "Save As...";
            this.saveAsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.saveAsButton.UseVisualStyleBackColor = true;
            this.saveAsButton.Click += new System.EventHandler(this.saveAsButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsButton.Image = global::WindowsInputRecorder.Properties.Resources.cog;
            this.optionsButton.Location = new System.Drawing.Point(516, 12);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(150, 30);
            this.optionsButton.TabIndex = 4;
            this.optionsButton.Text = "Recording Options...";
            this.optionsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.optionsButton.UseVisualStyleBackColor = true;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stopButton.Image = global::WindowsInputRecorder.Properties.Resources.control_stop_blue;
            this.stopButton.Location = new System.Drawing.Point(12, 313);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(100, 36);
            this.stopButton.TabIndex = 7;
            this.stopButton.Text = "Stop";
            this.stopButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // playButton
            // 
            this.playButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.playButton.Image = global::WindowsInputRecorder.Properties.Resources.control_play_blue;
            this.playButton.Location = new System.Drawing.Point(118, 313);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(100, 36);
            this.playButton.TabIndex = 8;
            this.playButton.Text = "Play";
            this.playButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // recordButton
            // 
            this.recordButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.recordButton.Image = global::WindowsInputRecorder.Properties.Resources.stop;
            this.recordButton.Location = new System.Drawing.Point(224, 313);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(100, 36);
            this.recordButton.TabIndex = 9;
            this.recordButton.Text = "Record";
            this.recordButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.recordButton_Click);
            // 
            // textBox
            // 
            this.textBox.AcceptsReturn = true;
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Location = new System.Drawing.Point(12, 48);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(760, 259);
            this.textBox.TabIndex = 6;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // loopImageLabel
            // 
            this.loopImageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.loopImageLabel.Caption = "Loop:";
            this.loopImageLabel.Image = global::WindowsInputRecorder.Properties.Resources.control_repeat_blue;
            this.loopImageLabel.Location = new System.Drawing.Point(330, 313);
            this.loopImageLabel.Name = "loopImageLabel";
            this.loopImageLabel.Size = new System.Drawing.Size(60, 23);
            this.loopImageLabel.TabIndex = 10;
            // 
            // speedImageLabel
            // 
            this.speedImageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.speedImageLabel.Caption = "Speed:";
            this.speedImageLabel.Image = global::WindowsInputRecorder.Properties.Resources.control_fastforward_blue;
            this.speedImageLabel.Location = new System.Drawing.Point(462, 313);
            this.speedImageLabel.Name = "speedImageLabel";
            this.speedImageLabel.Size = new System.Drawing.Size(65, 23);
            this.speedImageLabel.TabIndex = 12;
            // 
            // speedNumericTrackBar
            // 
            this.speedNumericTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.speedNumericTrackBar.DecimalPlaces = 1;
            this.speedNumericTrackBar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedNumericTrackBar.Location = new System.Drawing.Point(533, 313);
            this.speedNumericTrackBar.Maximum = 10D;
            this.speedNumericTrackBar.Minimum = 0D;
            this.speedNumericTrackBar.Name = "speedNumericTrackBar";
            this.speedNumericTrackBar.Size = new System.Drawing.Size(239, 36);
            this.speedNumericTrackBar.TabIndex = 13;
            this.speedNumericTrackBar.Value = 1D;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.saveAsButton);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.recordButton);
            this.Controls.Add(this.loopImageLabel);
            this.Controls.Add(this.loopNumericUpDown);
            this.Controls.Add(this.speedImageLabel);
            this.Controls.Add(this.speedNumericTrackBar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 200);
            this.Name = "MainForm";
            this.Text = "Windows Input Recorder";
            ((System.ComponentModel.ISupportInitialize)(this.loopNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowsInputRecorder.Controls.TextBoxEx textBox;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.NumericUpDown loopNumericUpDown;
        private WindowsInputRecorder.UserControls.NumericTrackBar speedNumericTrackBar;
        private UserControls.ImageLabel loopImageLabel;
        private UserControls.ImageLabel speedImageLabel;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button saveAsButton;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.Button aboutButton;
    }
}