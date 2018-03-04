using System;
using System.Windows.Forms;
using WindowsInputRecorder.Exceptions;
using WindowsInputRecorder.Packets;
using WindowsInputRecorder.Sessions;
using WindowsInputRecorder.Settings;

namespace WindowsInputRecorder.Forms
{
    public partial class MainForm : Form
    {
        private Session session;
        private Options options;
        private OpenFileDialog open;
        private SaveFileDialog save;
        private bool textChanged = false;

        public MainForm()
        {
            InitializeComponent();

            session = new Session();
            session.StateChanged += session_StateChanged;
            session.PacketRecorded += session_PacketRecorded;
            session_StateChanged(this, EventArgs.Empty);

            options = new Options(this.Handle);
            options.Load();
            options.ApplyTo(session);
            options.Resume();

            open = new OpenFileDialog();
            open.Filter = "Input Recording Script|*.irs|Input Recording|*.ir|All Recording Scripts|*.irs;*.ir";
            open.FilterIndex = 3;

            save = new SaveFileDialog();
            save.Filter = "Input Recording Script|*.irs|Input Recording|*.ir";
        }

        public static void ShowLineError(LineException ex)
        {
            MessageBox.Show(String.Format(
                "An error occured at line {0}:\r\n{1}\r\n\r\nSource:\r\n{2}",
                (ex.LineIndex + 1).ToString(),
                ex.InnerException.Message,
                ex.Line
                ), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            if (drgevent.Data.GetDataPresent(DataFormats.FileDrop))
                drgevent.Effect = DragDropEffects.All;
            else
                drgevent.Effect = DragDropEffects.None;
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            string[] files = (string[])drgevent.Data.GetData(DataFormats.FileDrop, false);

            if (files.Length == 0)
                return;

            open.FileName = files[0];
            Open();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            textChanged = false;
            stopButton_Click(this, EventArgs.Empty);
            options.Save();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.N:
                    newButton.PerformClick();
                    return true;
                case Keys.Control | Keys.O:
                    openButton.PerformClick();
                    return true;
                case Keys.Control | Keys.S:
                    saveButton.PerformClick();
                    return true;
                case Keys.Control | Keys.Shift | Keys.S:
                    saveAsButton.PerformClick();
                    return true;
                case Keys.Control | Keys.R:
                    loopNumericUpDown.Value = 1M;
                    speedNumericTrackBar.Value = 1.0;
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                switch (m.WParam.ToInt32())
                {
                    case 0:
                        stopButton_Click(this, EventArgs.Empty);
                        break;
                    case 1:
                        if (session.Busy && options.toggleHotkeys)
                            stopButton_Click(this, EventArgs.Empty);
                        else
                            playButton_Click(this, EventArgs.Empty);
                        break;
                    case 2:
                        if (session.Busy && options.toggleHotkeys)
                            stopButton_Click(this, EventArgs.Empty);
                        else
                        {
                            if (options.clearOnRecord)
                            {
                                session.Packets.Clear();
                                textBox.Clear();
                            }

                            recordButton_Click(this, EventArgs.Empty);
                        }
                        break;
                }
            }

            base.WndProc(ref m);
        }

        private void session_StateChanged(object sender, EventArgs e)
        {
            SetState(session.State);
        }

        private void SetState(SessionState sessionState)
        {
            try
            {
                if (InvokeRequired)
                {
                    BeginInvoke((Action<SessionState>)SetState, sessionState);
                    return;
                }

                switch (session.State)
                {
                    case SessionState.Idle:
                        newButton.Enabled = true;
                        openButton.Enabled = true;
                        saveButton.Enabled = true;
                        saveAsButton.Enabled = true;
                        optionsButton.Enabled = true;
                        textBox.ReadOnly = false;
                        stopButton.Enabled = false;
                        playButton.Enabled = true;
                        recordButton.Enabled = true;
                        loopImageLabel.Enabled = true;
                        loopNumericUpDown.Enabled = true;
                        speedImageLabel.Enabled = true;
                        speedNumericTrackBar.Enabled = true;

                        if (textChanged)
                        {
                            textBox.Text = session.Packets.ToString();
                            textChanged = false;
                        }
                        break;
                    case SessionState.Recording:
                    case SessionState.Playing:
                        newButton.Enabled = false;
                        openButton.Enabled = false;
                        saveButton.Enabled = false;
                        saveAsButton.Enabled = false;
                        optionsButton.Enabled = false;
                        textBox.ReadOnly = true;
                        stopButton.Enabled = true;
                        playButton.Enabled = false;
                        recordButton.Enabled = false;
                        loopImageLabel.Enabled = false;
                        loopNumericUpDown.Enabled = false;
                        speedImageLabel.Enabled = false;
                        speedNumericTrackBar.Enabled = false;
                        break;
                    default:
                        break;
                }
            }
            catch (ObjectDisposedException)
            {
            }
        }

        private void session_PacketRecorded(Packet packet)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action<Packet>)session_PacketRecorded, packet);
                return;
            }

            textBox.AppendText(packet.ToString() + Environment.NewLine);
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (open.ShowDialog() != DialogResult.OK)
                return;

            Open();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateSession();
            }
            catch (LineException ex)
            {
                ShowLineErrorInTextBox(ex);
            }

            if (save.FileName == "" && save.ShowDialog() != DialogResult.OK)
                return;

            Save();
        }

        private void saveAsButton_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateSession();
            }
            catch (LineException ex)
            {
                ShowLineErrorInTextBox(ex);
            }

            if (save.ShowDialog() != DialogResult.OK)
                return;

            Save();
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            using (OptionsForm form = new OptionsForm(options))
            {
                options.Suspend();

                if (form.ShowDialog() == DialogResult.OK)
                    options.ApplyTo(session);

                options.Resume();
            }
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by Aron (hl2mukkel)\r\nWebsite: http://www.youtube.com/hl2mukkel", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            textChanged = true;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (!session.Busy)
                return;

            session.Stop();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (session.Busy)
                return;

            try
            {
                if (textChanged)
                {
                    UpdateSession();
                    textChanged = false;
                }

                session.Times = Decimal.ToInt32(loopNumericUpDown.Value);
                session.Speed = speedNumericTrackBar.Value;
                session.Play();
            }
            catch (LineException ex)
            {
                ShowLineErrorInTextBox(ex);
            }
        }

        private void recordButton_Click(object sender, EventArgs e)
        {
            if (session.Busy)
                return;

            if (textBox.TextLength > 0 && !textBox.Text.EndsWith(Environment.NewLine))
                textBox.AppendText(Environment.NewLine);

            textChanged = session.RecordKeyboard && session.RecordKeyChar && session.MergeKeyChar;

            try
            {
                UpdateSession();
                session.Record();
            }
            catch (LineException ex)
            {
                ShowLineErrorInTextBox(ex);
            }
        }

        private void Clear()
        {
            session.Packets.Clear();
            textBox.Text = String.Empty;
        }

        private void Open()
        {
            session.Packets.Clear();

            try
            {
                switch (open.FilterIndex)
                {
                    case 1:
                        session.Packets.AddFromScriptFile(open.FileName);
                        break;
                    case 2:
                        session.Packets.AddFromDataFile(open.FileName);
                        break;
                    case 3:
                        if (open.FileName.EndsWith(".irs"))
                            goto case 1;
                        else if (open.FileName.EndsWith(".ir"))
                            goto case 2;
                        break;
                }
            }
            catch (LineException ex)
            {
                session.Packets.Clear();
                ShowLineError(ex);
            }
            catch (Exception ex)
            {
                session.Packets.Clear();
                ShowError(ex);
            }

            save.FileName = open.FileName;
            UpdateTextBox();
        }

        private void Save()
        {
            try
            {
                switch (save.FilterIndex)
                {
                    case 1:
                        session.Packets.WriteToScriptFile(save.FileName);
                        break;
                    case 2:
                        session.Packets.WriteToDataFile(save.FileName);
                        break;
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void UpdateTextBox()
        {
            textBox.Text = session.Packets.ToString();
        }

        private void UpdateSession()
        {
            session.Packets.Clear();
            session.Packets.AddFromString(textBox.Text);
        }

        private void ShowLineErrorInTextBox(LineException ex)
        {
            ShowLineError(ex);

            int lineStart;
            int lineStop;

            try
            {
                lineStart = textBox.GetFirstCharIndexFromLine(ex.LineIndex);
            }
            catch
            {
                lineStart = 0;
            }

            try
            {
                lineStop = textBox.GetFirstCharIndexFromLine(ex.LineIndex + 1);
            }
            catch
            {
                lineStop = -1;
            }

            if (lineStop == -1)
                lineStop = textBox.TextLength;
            else
                lineStop -= 2;

            textBox.Select();
            textBox.Select(lineStart, lineStop - lineStart);
        }
    }
}
