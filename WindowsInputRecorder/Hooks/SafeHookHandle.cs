using System;
using System.Runtime.InteropServices;
using WindowsInputRecorder.Win32;

namespace WindowsInputRecorder.Hooks
{
    public class SafeHookHandle : SafeHandle
    {
        public SafeHookHandle() : this(true)
        {
        }

        public SafeHookHandle(bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
        {
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            return NativeMethods.UnhookWindowsHookEx(handle);
        }
    }
}
