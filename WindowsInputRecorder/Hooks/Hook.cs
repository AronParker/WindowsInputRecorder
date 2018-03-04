using System;
using System.ComponentModel;
using WindowsInputRecorder.Inputs;
using WindowsInputRecorder.Win32;

namespace WindowsInputRecorder.Hooks
{
    public delegate void InputEventHandler(Input input);

    public abstract class Hook : IDisposable
    {
        private NativeMethods.LowLevelProc proc;
        private SafeHookHandle hhook;

        public Hook()
        {
            this.proc = new NativeMethods.LowLevelProc(LowLevelProc);
        }

        public event InputEventHandler InputEvent;

        public abstract void Start();

        public virtual void Stop()
        {
            if (hhook == null || hhook.IsInvalid)
                return;

            hhook.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected void SetWindowsHookEx(int nCode)
        {
            Stop();

            hhook = NativeMethods.SetWindowsHookEx(nCode, proc, NativeMethods.GetModuleHandle(null), 0);
            
            if (hhook.IsInvalid)
                throw new Win32Exception();
        }

        protected abstract void ProcessHCAction(IntPtr wParam, IntPtr lParam);

        protected virtual void Dispose(bool disposing)
        {
            Stop();
        }

        protected virtual void OnInputEvent(Input input)
        {
            if (InputEvent != null)
                InputEvent(input);
        }

        private IntPtr LowLevelProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
                return NativeMethods.CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);

            if (nCode == 0)
                ProcessHCAction(wParam, lParam);

            return NativeMethods.CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }
    }
}
