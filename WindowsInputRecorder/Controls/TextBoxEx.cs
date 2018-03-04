using System.Windows.Forms;

namespace WindowsInputRecorder.Controls
{
    public class TextBoxEx : TextBox
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == (Keys.A | Keys.Control))
            {
                SelectAll();
                e.SuppressKeyPress = true;
                return;
            }

            base.OnKeyDown(e);
        }
    }
}
