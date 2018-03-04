using WindowsInputRecorder.Settings;
using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsInputRecorder.Forms
{
    public partial class OptionsForm : Form
    {
        private Options options;

        private OptionsForm()
        {
            InitializeComponent();
        }

        public OptionsForm(Options options)
            : this()
        {
            this.options = options;

            try
            {
                LoadSettings();
            }
            catch
            {
                Debug.Fail("OptionsForm.LoadSettings failed.");
                options.LoadDefaults();
                LoadSettings();
            }
        }

        private void LoadSettings()
        {
            mouseCheckBox.Checked = options.recordMouse;
            mouseUpCheckBox.Checked = options.recordMouseUp;
            mouseMoveCheckBox.Checked = options.recordMouseMove;

            keyboardCheckBox.Checked = options.recordKeyboard;
            keyboardUpCheckBox.Checked = options.recordKeyboardUp;
            mergeKeyCharCheckBox.Checked = options.mergeKeyChar;

            if (options.recordKeyChar)
                keyCharRadioButton.Checked = true;
            else
                keyInputRadioButton.Checked = true;

            waitCheckBox.Checked = options.recordWait;
            waitNumericUpDown.Value = options.minWaitTime;

            hotkeysCheckBox.Checked = options.hotkeys.Enabled;
            textBox_PreviewKeyDown(stopTextBox, new PreviewKeyDownEventArgs(options.hotkeys[0]));
            textBox_PreviewKeyDown(playTextBox, new PreviewKeyDownEventArgs(options.hotkeys[1]));
            textBox_PreviewKeyDown(recordTextBox, new PreviewKeyDownEventArgs(options.hotkeys[2]));

            clearOnRecordCheckBox.Checked = options.clearOnRecord;
            toggleHotkeysCheckBox.Checked = options.toggleHotkeys;
            filterHotkeysCheckBox.Checked = options.filterHotkeys;

            mouseCheckBox_CheckedChanged(this, EventArgs.Empty);
            keyboardCheckBox_CheckedChanged(this, EventArgs.Empty);
            waitCheckBox_CheckedChanged(this, EventArgs.Empty);
            hotkeysCheckBox_CheckedChanged(this, EventArgs.Empty);
        }

        private void SaveSettings()
        {
            options.recordMouse = mouseCheckBox.Checked;
            options.recordMouseUp = mouseUpCheckBox.Checked;
            options.recordMouseMove = mouseMoveCheckBox.Checked;

            options.recordKeyboard = keyboardCheckBox.Checked;
            options.recordKeyChar = keyCharRadioButton.Checked;
            options.recordKeyboardUp = keyboardUpCheckBox.Checked;
            options.mergeKeyChar = mergeKeyCharCheckBox.Checked;

            options.recordWait = waitCheckBox.Checked;
            options.minWaitTime = Decimal.ToInt32(waitNumericUpDown.Value);

            options.hotkeys.Enabled = hotkeysCheckBox.Checked;
            options.hotkeys[0] = (Keys)stopTextBox.Tag;
            options.hotkeys[1] = (Keys)playTextBox.Tag;
            options.hotkeys[2] = (Keys)recordTextBox.Tag;

            options.clearOnRecord = clearOnRecordCheckBox.Checked;
            options.toggleHotkeys = toggleHotkeysCheckBox.Checked;
            options.filterHotkeys = filterHotkeysCheckBox.Checked;
        }

        private void mouseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool flag = mouseCheckBox.Checked;

            mouseUpCheckBox.Enabled = flag;
            mouseMoveCheckBox.Enabled = flag;
        }

        private void keyboardCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool flag = keyboardCheckBox.Checked;

            keyInputRadioButton.Enabled = flag;
            keyboardUpCheckBox.Enabled = flag && keyInputRadioButton.Checked;
            keyCharRadioButton.Enabled = flag;
            mergeKeyCharCheckBox.Enabled = flag && keyCharRadioButton.Checked;
        }

        private void waitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool flag = waitCheckBox.Checked;

            waitLabel.Enabled = flag;
            waitNumericUpDown.Enabled = flag;
        }

        private void hotkeysCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool flag = hotkeysCheckBox.Checked;

            stopLabel.Enabled = flag;
            playLabel.Enabled = flag;
            recordLabel.Enabled = flag;
            stopTextBox.Enabled = flag;
            playTextBox.Enabled = flag;
            recordTextBox.Enabled = flag;
            clearOnRecordCheckBox.Enabled = flag;
            toggleHotkeysCheckBox.Enabled = flag;
            filterHotkeysCheckBox.Enabled = flag;
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void textBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Keys key = e.KeyData;

            if ((key | Keys.Back) == Keys.Back)
                key = Keys.None;

            TextBox textBox = (TextBox)sender;

            textBox.Text = key.ToString();
            textBox.Tag = key;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            options.LoadDefaults();
            LoadSettings();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
