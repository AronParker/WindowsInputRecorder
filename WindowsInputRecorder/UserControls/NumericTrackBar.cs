using System;
using System.Windows.Forms;

namespace WindowsInputRecorder.UserControls
{
    public partial class NumericTrackBar : UserControl
    {
        private double maximum;
        private double minimum;
        private double value;
        private int decimalPlaces;
        private bool disableEvents;
        private bool success = false;

        public NumericTrackBar()
        {
            InitializeComponent();
        }

        public double Minimum
        {
            get { return minimum; }
            set {
                this.trackBar.Minimum = (int)(Math.Ceiling(value * Math.Pow(10.0, decimalPlaces)));
                this.minimum = value;
            }
        }

        public double Maximum
        {
            get { return maximum; }
            set
            {
                this.trackBar.Maximum = (int)(Math.Floor(value * Math.Pow(10.0, decimalPlaces)));
                this.maximum = value;
            }
        }

        public double Value
        {
            get { return value; }
            set
            {
                this.value = value;

                disableEvents = true;
                UpdateTrackBar();
                UpdateTextBox();
                disableEvents = false;
            }
        }

        public int DecimalPlaces
        {
            get { return decimalPlaces; }
            set
            {
                trackBar.Minimum = (int)(Math.Ceiling(minimum * Math.Pow(10.0, value)));
                trackBar.Maximum = (int)(Math.Floor(maximum * Math.Pow(10.0, value)));
                trackBar.TickFrequency = (int)Math.Pow(10.0, value);
                decimalPlaces = value;
            }
        }

        private void UpdateTrackBar()
        {
            if (Double.IsInfinity(value))
            {
                trackBar.Value = trackBar.Maximum;
                return;
            }
            else if (Double.IsNaN(value))
            {
                trackBar.Value = trackBar.Minimum;
                return;
            }

            int dwValue = (int)(value * Math.Pow(10, decimalPlaces));

            if (dwValue > trackBar.Maximum)
                trackBar.Value = trackBar.Maximum;
            else if (dwValue < trackBar.Minimum)
                trackBar.Value = trackBar.Minimum;
            else
                trackBar.Value = (int)dwValue;
        }

        private void UpdateTextBox()
        {
            textBox.Text = value.ToString();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (disableEvents)
                return;

            disableEvents = true;

            success = double.TryParse(textBox.Text, out value) && value >= minimum;
            
            if (success)
                UpdateTrackBar();

            disableEvents = false;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            if (!success)
                Value = 1.0;
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            if (disableEvents)
                return;

            disableEvents = true;

            value = (double)trackBar.Value / Math.Pow(10.0, decimalPlaces);

            UpdateTextBox();

            disableEvents = false;
        }
    }
}
