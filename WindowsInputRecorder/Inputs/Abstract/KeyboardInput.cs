using System.Windows.Forms;

namespace WindowsInputRecorder.Inputs
{
    public abstract class KeyboardInput : Input
    {
        protected Keys key;

        public KeyboardInput()
        {
        }

        public KeyboardInput(Keys key)
        {
            this.key = key;
        }

        public Keys Key
        {
            get { return key; }
            set { key = value; }
        }
    }
}
