using WindowsInputRecorder.Inputs;
using WindowsInputRecorder.Win32;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WindowsInputRecorder.Hooks
{
    public class KeyCharHook : Hook
    {
        private const int BUFFER_SIZE_IN_CHARS = 8;
        private const int VK_NOT_FOUND = -1;

        private IntPtr HKL = IntPtr.Zero;
        private byte[] keyState = new byte[256];
        private byte[] buffer = new byte[BUFFER_SIZE_IN_CHARS * 2];
        private byte[] emptyBuffer = new byte[BUFFER_SIZE_IN_CHARS * 2];
        private int lastVK = VK_NOT_FOUND;
        private byte[] lastKeyState = new byte[256];

        public override void Start()
        {
            SetWindowsHookEx(NativeMethods.WH_KEYBOARD_LL);
        }

        protected override void ProcessHCAction(IntPtr wParam, IntPtr lParam)
        {
            KBDLLHOOKSTRUCT kb = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));

            switch ((WM)wParam.ToInt32())
            {
                case WM.KEYDOWN:
                case WM.SYSKEYDOWN:
                    GetKeyState();
                    VkToChar(kb.vkCode);
                    break;
                case WM.KEYUP:
                case WM.SYSKEYUP:
                    GetKeyState();
                    break;
                default:
                    Debug.Fail("Unknown wParam");
                    break;
            }
        }

        private void VkToChar(int vkCode)
        {
            int size = NativeMethods.ToUnicodeEx(vkCode, 0, keyState, buffer, BUFFER_SIZE_IN_CHARS, 0, HKL);

            if (size == -1)
            {
                NativeMethods.ToUnicodeEx(vkCode, 0, keyState, emptyBuffer, BUFFER_SIZE_IN_CHARS, 0, HKL);
            }
            else if (lastVK != VK_NOT_FOUND)
            {
                NativeMethods.ToUnicodeEx(lastVK, 0, lastKeyState, emptyBuffer, BUFFER_SIZE_IN_CHARS, 0, HKL);
                lastVK = VK_NOT_FOUND;
            }

            if (size == -1)
            {
                lastVK = vkCode;
                Buffer.BlockCopy(keyState, 0, lastKeyState, 0, 256);
            }

            size *= 2;

            for (int i = 0; i < size; i += 2)
                OnInputEvent(new KeyCharInput((char)(buffer[i] | buffer[i + 1] << 8)));
        }

        private void GetKeyState()
        {
            uint sourceThreadID = NativeMethods.GetCurrentThreadId();
            uint targetThreadID = NativeMethods.GetWindowThreadProcessId(NativeMethods.GetForegroundWindow(), IntPtr.Zero);

            if (sourceThreadID != targetThreadID && NativeMethods.AttachThreadInput(sourceThreadID, targetThreadID, true))
            {
                NativeMethods.GetKeyboardState(keyState);
                NativeMethods.AttachThreadInput(sourceThreadID, targetThreadID, false);
            }
            else
                NativeMethods.GetKeyboardState(keyState);

            HKL = NativeMethods.GetKeyboardLayout(targetThreadID);
        }
    }
}
