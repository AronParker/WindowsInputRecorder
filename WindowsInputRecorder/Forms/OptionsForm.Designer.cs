namespace WindowsInputRecorder.Forms
{
    partial class OptionsForm
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
            this.waitLabel = new System.Windows.Forms.Label();
            this.waitNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.mouseMoveCheckBox = new System.Windows.Forms.CheckBox();
            this.stopLabel = new System.Windows.Forms.Label();
            this.playLabel = new System.Windows.Forms.Label();
            this.recordLabel = new System.Windows.Forms.Label();
            this.stopTextBox = new System.Windows.Forms.TextBox();
            this.playTextBox = new System.Windows.Forms.TextBox();
            this.recordTextBox = new System.Windows.Forms.TextBox();
            this.mergeKeyCharCheckBox = new System.Windows.Forms.CheckBox();
            this.mouseUpCheckBox = new System.Windows.Forms.CheckBox();
            this.keyInputRadioButton = new System.Windows.Forms.RadioButton();
            this.keyboardUpCheckBox = new System.Windows.Forms.CheckBox();
            this.keyCharRadioButton = new System.Windows.Forms.RadioButton();
            this.resetButton = new System.Windows.Forms.Button();
            this.mouseCheckBox = new System.Windows.Forms.CheckBox();
            this.keyboardCheckBox = new System.Windows.Forms.CheckBox();
            this.waitCheckBox = new System.Windows.Forms.CheckBox();
            this.hotkeysCheckBox = new System.Windows.Forms.CheckBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.filterHotkeysCheckBox = new System.Windows.Forms.CheckBox();
            this.toggleHotkeysCheckBox = new System.Windows.Forms.CheckBox();
            this.clearOnRecordCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.waitNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // waitLabel
            // 
            this.waitLabel.Location = new System.Drawing.Point(330, 50);
            this.waitLabel.Name = "waitLabel";
            this.waitLabel.Size = new System.Drawing.Size(100, 23);
            this.waitLabel.TabIndex = 9;
            this.waitLabel.Text = "Minimum (ms):";
            // 
            // waitNumericUpDown
            // 
            this.waitNumericUpDown.Location = new System.Drawing.Point(436, 48);
            this.waitNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.waitNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.waitNumericUpDown.Name = "waitNumericUpDown";
            this.waitNumericUpDown.Size = new System.Drawing.Size(136, 23);
            this.waitNumericUpDown.TabIndex = 10;
            this.waitNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // mouseMoveCheckBox
            // 
            this.mouseMoveCheckBox.Location = new System.Drawing.Point(42, 84);
            this.mouseMoveCheckBox.Name = "mouseMoveCheckBox";
            this.mouseMoveCheckBox.Size = new System.Drawing.Size(232, 30);
            this.mouseMoveCheckBox.TabIndex = 2;
            this.mouseMoveCheckBox.Text = "Capture Mouse Movement";
            this.mouseMoveCheckBox.UseVisualStyleBackColor = true;
            // 
            // stopLabel
            // 
            this.stopLabel.Location = new System.Drawing.Point(330, 156);
            this.stopLabel.Name = "stopLabel";
            this.stopLabel.Size = new System.Drawing.Size(100, 23);
            this.stopLabel.TabIndex = 12;
            this.stopLabel.Text = "Stop:";
            this.stopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // playLabel
            // 
            this.playLabel.Location = new System.Drawing.Point(330, 185);
            this.playLabel.Name = "playLabel";
            this.playLabel.Size = new System.Drawing.Size(100, 23);
            this.playLabel.TabIndex = 13;
            this.playLabel.Text = "Play:";
            this.playLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // recordLabel
            // 
            this.recordLabel.Location = new System.Drawing.Point(330, 214);
            this.recordLabel.Name = "recordLabel";
            this.recordLabel.Size = new System.Drawing.Size(100, 23);
            this.recordLabel.TabIndex = 14;
            this.recordLabel.Text = "Record:";
            this.recordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stopTextBox
            // 
            this.stopTextBox.Location = new System.Drawing.Point(436, 156);
            this.stopTextBox.Name = "stopTextBox";
            this.stopTextBox.ShortcutsEnabled = false;
            this.stopTextBox.Size = new System.Drawing.Size(136, 23);
            this.stopTextBox.TabIndex = 15;
            this.stopTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.stopTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox_PreviewKeyDown);
            // 
            // playTextBox
            // 
            this.playTextBox.Location = new System.Drawing.Point(436, 185);
            this.playTextBox.Name = "playTextBox";
            this.playTextBox.ShortcutsEnabled = false;
            this.playTextBox.Size = new System.Drawing.Size(136, 23);
            this.playTextBox.TabIndex = 16;
            this.playTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.playTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox_PreviewKeyDown);
            // 
            // recordTextBox
            // 
            this.recordTextBox.Location = new System.Drawing.Point(436, 214);
            this.recordTextBox.Name = "recordTextBox";
            this.recordTextBox.ShortcutsEnabled = false;
            this.recordTextBox.Size = new System.Drawing.Size(136, 23);
            this.recordTextBox.TabIndex = 17;
            this.recordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.recordTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox_PreviewKeyDown);
            // 
            // mergeKeyCharCheckBox
            // 
            this.mergeKeyCharCheckBox.Location = new System.Drawing.Point(72, 264);
            this.mergeKeyCharCheckBox.Name = "mergeKeyCharCheckBox";
            this.mergeKeyCharCheckBox.Size = new System.Drawing.Size(204, 30);
            this.mergeKeyCharCheckBox.TabIndex = 7;
            this.mergeKeyCharCheckBox.Text = "Merge Characters";
            this.mergeKeyCharCheckBox.UseVisualStyleBackColor = true;
            // 
            // mouseUpCheckBox
            // 
            this.mouseUpCheckBox.Location = new System.Drawing.Point(42, 48);
            this.mouseUpCheckBox.Name = "mouseUpCheckBox";
            this.mouseUpCheckBox.Size = new System.Drawing.Size(232, 30);
            this.mouseUpCheckBox.TabIndex = 1;
            this.mouseUpCheckBox.Text = "Capture Mouse Releases";
            this.mouseUpCheckBox.UseVisualStyleBackColor = true;
            // 
            // keyInputRadioButton
            // 
            this.keyInputRadioButton.Location = new System.Drawing.Point(42, 156);
            this.keyInputRadioButton.Name = "keyInputRadioButton";
            this.keyInputRadioButton.Size = new System.Drawing.Size(232, 30);
            this.keyInputRadioButton.TabIndex = 4;
            this.keyInputRadioButton.TabStop = true;
            this.keyInputRadioButton.Text = "Capture Keyboard Inputs";
            this.keyInputRadioButton.UseVisualStyleBackColor = true;
            this.keyInputRadioButton.CheckedChanged += new System.EventHandler(this.keyboardCheckBox_CheckedChanged);
            // 
            // keyboardUpCheckBox
            // 
            this.keyboardUpCheckBox.Location = new System.Drawing.Point(72, 192);
            this.keyboardUpCheckBox.Name = "keyboardUpCheckBox";
            this.keyboardUpCheckBox.Size = new System.Drawing.Size(204, 30);
            this.keyboardUpCheckBox.TabIndex = 5;
            this.keyboardUpCheckBox.Text = "Capture Keyboard Releases";
            this.keyboardUpCheckBox.UseVisualStyleBackColor = true;
            // 
            // keyCharRadioButton
            // 
            this.keyCharRadioButton.Location = new System.Drawing.Point(42, 228);
            this.keyCharRadioButton.Name = "keyCharRadioButton";
            this.keyCharRadioButton.Size = new System.Drawing.Size(232, 30);
            this.keyCharRadioButton.TabIndex = 6;
            this.keyCharRadioButton.TabStop = true;
            this.keyCharRadioButton.Text = "Capture Keyboard Characters";
            this.keyCharRadioButton.UseVisualStyleBackColor = true;
            this.keyCharRadioButton.CheckedChanged += new System.EventHandler(this.keyboardCheckBox_CheckedChanged);
            // 
            // resetButton
            // 
            this.resetButton.Image = global::WindowsInputRecorder.Properties.Resources.cog_go;
            this.resetButton.Location = new System.Drawing.Point(12, 359);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(150, 30);
            this.resetButton.TabIndex = 21;
            this.resetButton.Text = "Reset Settings";
            this.resetButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // mouseCheckBox
            // 
            this.mouseCheckBox.Image = global::WindowsInputRecorder.Properties.Resources.mouse;
            this.mouseCheckBox.Location = new System.Drawing.Point(12, 12);
            this.mouseCheckBox.Name = "mouseCheckBox";
            this.mouseCheckBox.Size = new System.Drawing.Size(150, 30);
            this.mouseCheckBox.TabIndex = 0;
            this.mouseCheckBox.Text = "Capture Mouse";
            this.mouseCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.mouseCheckBox.UseVisualStyleBackColor = true;
            this.mouseCheckBox.CheckedChanged += new System.EventHandler(this.mouseCheckBox_CheckedChanged);
            // 
            // keyboardCheckBox
            // 
            this.keyboardCheckBox.Image = global::WindowsInputRecorder.Properties.Resources.keyboard;
            this.keyboardCheckBox.Location = new System.Drawing.Point(12, 120);
            this.keyboardCheckBox.Name = "keyboardCheckBox";
            this.keyboardCheckBox.Size = new System.Drawing.Size(150, 30);
            this.keyboardCheckBox.TabIndex = 3;
            this.keyboardCheckBox.Text = "Capture Keyboard";
            this.keyboardCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.keyboardCheckBox.UseVisualStyleBackColor = true;
            this.keyboardCheckBox.CheckedChanged += new System.EventHandler(this.keyboardCheckBox_CheckedChanged);
            // 
            // waitCheckBox
            // 
            this.waitCheckBox.Image = global::WindowsInputRecorder.Properties.Resources.hourglass;
            this.waitCheckBox.Location = new System.Drawing.Point(300, 12);
            this.waitCheckBox.Name = "waitCheckBox";
            this.waitCheckBox.Size = new System.Drawing.Size(150, 30);
            this.waitCheckBox.TabIndex = 8;
            this.waitCheckBox.Text = "Capture Wait Times";
            this.waitCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.waitCheckBox.UseVisualStyleBackColor = true;
            this.waitCheckBox.CheckedChanged += new System.EventHandler(this.waitCheckBox_CheckedChanged);
            // 
            // hotkeysCheckBox
            // 
            this.hotkeysCheckBox.Image = global::WindowsInputRecorder.Properties.Resources.lightning;
            this.hotkeysCheckBox.Location = new System.Drawing.Point(300, 120);
            this.hotkeysCheckBox.Name = "hotkeysCheckBox";
            this.hotkeysCheckBox.Size = new System.Drawing.Size(150, 30);
            this.hotkeysCheckBox.TabIndex = 11;
            this.hotkeysCheckBox.Text = "Keyboard Shortcuts";
            this.hotkeysCheckBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.hotkeysCheckBox.UseVisualStyleBackColor = true;
            this.hotkeysCheckBox.CheckedChanged += new System.EventHandler(this.hotkeysCheckBox_CheckedChanged);
            // 
            // okButton
            // 
            this.okButton.Image = global::WindowsInputRecorder.Properties.Resources.tick;
            this.okButton.Location = new System.Drawing.Point(366, 359);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(100, 30);
            this.okButton.TabIndex = 22;
            this.okButton.Text = "OK";
            this.okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Image = global::WindowsInputRecorder.Properties.Resources.cross;
            this.cancelButton.Location = new System.Drawing.Point(472, 359);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 30);
            this.cancelButton.TabIndex = 23;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // filterHotkeysCheckBox
            // 
            this.filterHotkeysCheckBox.Location = new System.Drawing.Point(330, 315);
            this.filterHotkeysCheckBox.Name = "filterHotkeysCheckBox";
            this.filterHotkeysCheckBox.Size = new System.Drawing.Size(242, 30);
            this.filterHotkeysCheckBox.TabIndex = 20;
            this.filterHotkeysCheckBox.Text = "Filter Hotkeys";
            this.filterHotkeysCheckBox.UseVisualStyleBackColor = true;
            // 
            // toggleHotkeysCheckBox
            // 
            this.toggleHotkeysCheckBox.Location = new System.Drawing.Point(330, 279);
            this.toggleHotkeysCheckBox.Name = "toggleHotkeysCheckBox";
            this.toggleHotkeysCheckBox.Size = new System.Drawing.Size(242, 30);
            this.toggleHotkeysCheckBox.TabIndex = 19;
            this.toggleHotkeysCheckBox.Text = "Toggle Recording && Playing";
            this.toggleHotkeysCheckBox.UseVisualStyleBackColor = true;
            // 
            // clearOnRecordCheckBox
            // 
            this.clearOnRecordCheckBox.Location = new System.Drawing.Point(330, 243);
            this.clearOnRecordCheckBox.Name = "clearOnRecordCheckBox";
            this.clearOnRecordCheckBox.Size = new System.Drawing.Size(242, 30);
            this.clearOnRecordCheckBox.TabIndex = 18;
            this.clearOnRecordCheckBox.Text = "Clear on Record";
            this.clearOnRecordCheckBox.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 401);
            this.Controls.Add(this.mouseCheckBox);
            this.Controls.Add(this.mouseUpCheckBox);
            this.Controls.Add(this.mouseMoveCheckBox);
            this.Controls.Add(this.keyboardCheckBox);
            this.Controls.Add(this.keyInputRadioButton);
            this.Controls.Add(this.keyboardUpCheckBox);
            this.Controls.Add(this.keyCharRadioButton);
            this.Controls.Add(this.mergeKeyCharCheckBox);
            this.Controls.Add(this.waitCheckBox);
            this.Controls.Add(this.waitLabel);
            this.Controls.Add(this.waitNumericUpDown);
            this.Controls.Add(this.hotkeysCheckBox);
            this.Controls.Add(this.stopLabel);
            this.Controls.Add(this.playLabel);
            this.Controls.Add(this.recordLabel);
            this.Controls.Add(this.stopTextBox);
            this.Controls.Add(this.playTextBox);
            this.Controls.Add(this.recordTextBox);
            this.Controls.Add(this.clearOnRecordCheckBox);
            this.Controls.Add(this.toggleHotkeysCheckBox);
            this.Controls.Add(this.filterHotkeysCheckBox);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Recording Options";
            ((System.ComponentModel.ISupportInitialize)(this.waitNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox waitCheckBox;
        private System.Windows.Forms.Label waitLabel;
        private System.Windows.Forms.NumericUpDown waitNumericUpDown;
        private System.Windows.Forms.CheckBox mouseCheckBox;
        private System.Windows.Forms.CheckBox mouseMoveCheckBox;
        private System.Windows.Forms.CheckBox keyboardCheckBox;
        private System.Windows.Forms.CheckBox hotkeysCheckBox;
        private System.Windows.Forms.Label stopLabel;
        private System.Windows.Forms.Label playLabel;
        private System.Windows.Forms.Label recordLabel;
        private System.Windows.Forms.TextBox stopTextBox;
        private System.Windows.Forms.TextBox playTextBox;
        private System.Windows.Forms.TextBox recordTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox mergeKeyCharCheckBox;
        private System.Windows.Forms.CheckBox mouseUpCheckBox;
        private System.Windows.Forms.RadioButton keyInputRadioButton;
        private System.Windows.Forms.CheckBox keyboardUpCheckBox;
        private System.Windows.Forms.RadioButton keyCharRadioButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.CheckBox filterHotkeysCheckBox;
        private System.Windows.Forms.CheckBox toggleHotkeysCheckBox;
        private System.Windows.Forms.CheckBox clearOnRecordCheckBox;
    }
}