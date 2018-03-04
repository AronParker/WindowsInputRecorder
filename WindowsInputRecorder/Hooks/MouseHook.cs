using WindowsInputRecorder.Inputs;
using WindowsInputRecorder.Win32;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WindowsInputRecorder.Hooks
{
    public class MouseHook : Hook
    {
        private bool mouseMove;

        public MouseHook()
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
                    OnInputEvent(new LeftDownInput(ms.x, ms.y));
                    break;
                case WM.LBUTTONUP:
                    OnInputEvent(new LeftUpInput(ms.x, ms.y));
                    break;
                case WM.RBUTTONDOWN:
                    OnInputEvent(new RightDownInput(ms.x, ms.y));
                    break;
                case WM.RBUTTONUP:
                    OnInputEvent(new RightUpInput(ms.x, ms.y));
                    break;
                case WM.MBUTTONDOWN:
                    OnInputEvent(new MiddleDownInput(ms.x, ms.y));
                    break;
                case WM.MBUTTONUP:
                    OnInputEvent(new MiddleUpInput(ms.x, ms.y));
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
                        OnInputEvent(new X1DownInput(ms.x, ms.y));
                    else if (ms.mouseData == (2 << 16))
                        OnInputEvent(new X2DownInput(ms.x, ms.y));
                    else
                        Debug.Fail("Unknown lParam");

                    break;
                case WM.XBUTTONUP:
                    if (ms.mouseData == (1 << 16))
                        OnInputEvent(new X1UpInput(ms.x, ms.y));
                    else if (ms.mouseData == (2 << 16))
                        OnInputEvent(new X2UpInput(ms.x, ms.y));
                    else
                        Debug.Fail("Unknown lParam");

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
