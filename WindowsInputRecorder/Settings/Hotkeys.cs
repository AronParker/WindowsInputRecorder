using WindowsInputRecorder.Win32;
using System;
using System.Windows.Forms;

namespace WindowsInputRecorder.Settings
{
    public class Hotkeys : IDisposable
    {
        private Keys[] keys;
        private bool[] keyState;
        private IntPtr windowHandle;
        private bool enabled;

        public Hotkeys(IntPtr windowHandle, int count)
        {
            this.keys = new Keys[count];
            this.keyState = new bool[count];
            this.windowHandle = windowHandle;
            this.enabled = false;
        }

        ~Hotkeys()
        {
            Dispose(false);
        }

        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        public Keys[] AllKeyData
        {
            get { return keys; }
        }

        public Keys[] AllKeyCodes
        {
            get
            {
                Keys[] result = new Keys[keys.Length];

                for (int i = 0; i < result.Length; i++)
                    result[i] = keys[i] & Keys.KeyCode;

                return result;
            }
        }

        public Keys this[int index]
        {
            get { return keys[index]; }
            set { keys[index] = value; }
        }

        public void RegisterHotKeys()
        {
            if (!enabled)
                return;

            for (int id = 0; id < keyState.Length; id++)
                if (keys[id] != Keys.None)
                {
                    MOD fsModifiers = ((keys[id] & Keys.Alt) == Keys.Alt) ? MOD.ALT : 0;

                    if ((keys[id] & Keys.Control) == Keys.Control)
                        fsModifiers |= MOD.CONTROL;

                    if ((keys[id] & Keys.Shift) == Keys.Shift)
                        fsModifiers |= MOD.SHIFT;
                    
                    keyState[id] = NativeMethods.RegisterHotKey(windowHandle, id, fsModifiers, (int)(keys[id] & Keys.KeyCode));
                }
        }

        public void UnregisterHotKeys()
        {
            for (int id = 0; id < keyState.Length; id++)
                if (keyState[id])
                    NativeMethods.UnregisterHotKey(windowHandle, id);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            UnregisterHotKeys();

            Array.Clear(keys, 0, keys.Length);
            Array.Clear(keyState, 0, keyState.Length);

            enabled = false;
        }
    }
}
