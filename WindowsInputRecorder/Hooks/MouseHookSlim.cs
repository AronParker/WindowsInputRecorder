using WindowsInputRecorder.Inputs;
using WindowsInputRecorder.Win32;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WindowsInputRecorder.Hooks
{
    public class MouseHookSlim : Hook
    {
        private bool mouseMove;

        public MouseHookSlim()
        {
            mouseMove = false;
        }

        public bool EnableMouseMove
        {
            get { return mouseMove; }
            set { mouseMove = value; }
        }

        public override void Start()
        {
            SetWindowsHookEx(NativeMethods.WH_MOUSE_LL);
        }

        protected override void ProcessHCAction(IntPtr wParam, IntPtr lParam)
        {
            MSLLHOOKSTRUCT ms = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));

            switch ((WM)wParam.ToInt32())
            {
                case WM.MOUSEMOVE:
                    if (mouseMove)
                        OnInputEvent(new MoveInput(ms.x, ms.y));
                    break;
                case WM.LBUTTONDOWN:
                    OnInputEvent(new LeftPressInput(ms.x, ms.y));
                    break;
                case WM.LBUTTONUP:
                    break;
                case WM.RBUTTONDOWN:
                    OnInputEvent(new RightPressInput(ms.x, ms.y));
                    break;
                case WM.RBUTTONUP:
                    break;
                case WM.MBUTTONDOWN:
                    OnInputEvent(new MiddlePressInput(ms.x, ms.y));
                    break;
                case WM.MBUTTONUP:
                    break;
                case WM.MOUSEWHEEL:
                    if (ms.mouseData == (-120 << 16))
                        OnInputEvent(new WheelDownInput(ms.x, ms.y));
                    else if (ms.mouseData == (120 << 16))
                        OnInputEvent(new WheelUpInput(ms.x, ms.y));
                    else
                        Debug.Fail("Unknown lParam");

                    break;
                case WM.XBUTTONDOWN:
                    if (ms.mouseData == (1 << 16))
                        OnInputEvent(new X1PressInput(ms.x, ms.y));
                    else if (ms.mouseData == (2 << 16))
                        OnInputEvent(new X2PressInput(ms.x, ms.y));
                    else
                        Debug.Fail("Unknown lParam");

                    break;
                case WM.XBUTTONUP:
                    break;
                case WM.MOUSEHWHEEL:
                    if (ms.mouseData == (-120 << 16))
                        OnInputEvent(new HWheelLeftInput(ms.x, ms.y));
                    else if (ms.mouseData == (120 << 16))
                        OnInputEvent(new HWheelRightInput(ms.x, ms.y));
                    else
                        Debug.Fail("Unknown lParam");

                    break;
                default:
                    Debug.Fail("Unknown wParam");
                    break;
            }
        }
    }
}
