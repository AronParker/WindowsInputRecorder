using WindowsInputRecorder.Win32;

namespace WindowsInputRecorder.Inputs
{
    public abstract class MouseInput : Input
    {
        public static int MaxWidth;
        public static int MaxHeight;

        protected int x;
        protected int y;

        static MouseInput()
        {
            GetMaxSize();
        }

        public MouseInput()
        {
        }
         
        public MouseInput(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public static void GetMaxSize()
        {
            MaxWidth = NativeMethods.GetSystemMetrics(0) - 1;
            MaxHeight = NativeMethods.GetSystemMetrics(1) - 1;
        }
    }
}
