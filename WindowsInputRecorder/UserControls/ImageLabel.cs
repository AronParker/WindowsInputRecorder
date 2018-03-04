using System.Drawing;
using System.Windows.Forms;

namespace WindowsInputRecorder.UserControls
{
    public partial class ImageLabel : UserControl
    {
        public ImageLabel()
        {
            InitializeComponent();
        }

        public Image Image
        {
            get { return pictureBox.Image; }
            set { pictureBox.Image = value; }
        }

        public string Caption
        {
            get { return label.Text; }
            set { label.Text = value; }
        }
    }
}
