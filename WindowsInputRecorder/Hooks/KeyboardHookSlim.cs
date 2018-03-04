﻿using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WindowsInputRecorder.Inputs;
using WindowsInputRecorder.Win32;

namespace WindowsInputRecorder.Hooks
{
    public class KeyboardHookSlim : Hook
    {
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
                    if ((kb.flags & 1) == 0)
                        OnInputEvent(new KeyPressInput((Keys)kb.vkCode));
                    else
                        OnInputEvent(new KeyPressExtendedInput((Keys)kb.vkCode));
                    break;
                case WM.KEYUP:
                case WM.SYSKEYUP:
                    break;
                default:
                    Debug.Fail("Unknown wParam");
                    break;
            }
        }
    }
}
