using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using WindowsInputRecorder.Hooks;

namespace WindowsInputRecorder.Win32
{
    internal enum WM
    {
        KEYDOWN = 0x0100,
        KEYUP = 0x0101,
        SYSKEYDOWN = 0x0104,
        SYSKEYUP = 0x0105,
        MOUSEMOVE = 0x0200,
        LBUTTONDOWN = 0x0201,
        LBUTTONUP = 0x0202,
        RBUTTONDOWN = 0x0204,
        RBUTTONUP = 0x0205,
        MBUTTONDOWN = 0x0207,
        MBUTTONUP = 0x0208,
        MOUSEWHEEL = 0x020A,
        XBUTTONDOWN = 0x020B,
        XBUTTONUP = 0x020C,
        MOUSEHWHEEL = 0x020E,
    }

    internal enum MOUSEEVENTF : uint
    {
        MOVE = 0x0001,
        LEFTDOWN = 0x0002,
        LEFTUP = 0x0004,
        RIGHTDOWN = 0x0008,
        RIGHTUP = 0x0010,
        MIDDLEDOWN = 0x0020,
        MIDDLEUP = 0x0040,
        XDOWN = 0x0080,
        XUP = 0x0100,
        WHEEL = 0x0800,
        HWHEEL = 0x01000,
        MOVE_NOCOALESCE = 0x2000,
        VIRTUALDESK = 0x4000,
        ABSOLUTE = 0x8000,
    }

    internal enum KEYEVENTF : uint
    {
        EXTENDEDKEY = 0x0001,
        KEYUP = 0x0002,
        UNICODE = 0x0004,
        SCANCODE = 0x0008,
    }

    internal enum MOD : uint
    {
        ALT = 0x0001,
        CONTROL = 0x0002,
        SHIFT = 0x0004,
        WIN = 0x0008,
        NOREPEAT = 0x4000,
    }

    internal static class NativeMethods
    {
        internal const int WH_KEYBOARD_LL = 13;
        internal const int WH_MOUSE_LL = 14;

        internal delegate IntPtr LowLevelProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [ResourceExposure(ResourceScope.Process)]
        internal static extern IntPtr GetModuleHandle(String moduleName);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern SafeHookHandle SetWindowsHookEx(int idHook, LowLevelProc lpfn, IntPtr hMod, int threadId);

        [DllImport("user32.dll")]
        internal static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        internal static extern int GetSystemMetrics(int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern int SendInput(int nInputs, INPUT[] pInputs, int cbSize);

        [DllImport("kernel32.dll")]
        internal static extern uint GetCurrentThreadId();

        [DllImport("user32.dll")]
        internal static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr lpdwProcessId);

        [DllImport("user32.dll")]
        internal static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        internal static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

        [DllImport("user32.dll")]
        internal static extern bool GetKeyboardState(byte[] lpKeyState);

        [DllImport("user32.dll")]
        internal static extern IntPtr GetKeyboardLayout(uint idThread);

        [DllImport("user32.dll")]
        internal static extern int ToUnicodeEx(int wVirtKey, int wScanCode, byte[] lpKeyState, byte[] pwszBuff, int cchBuff, int wFlags, IntPtr dwhkl);

        [DllImport("shell32.dll", SetLastError = true)]
        internal static extern IntPtr CommandLineToArgvW([MarshalAs(UnmanagedType.LPWStr)] string lpCmdLine, out int pNumArgs);

        [DllImport("kernel32.dll")]
        internal static extern IntPtr LocalFree(IntPtr hMem);

        [DllImport("user32.dll")]
        internal static extern bool RegisterHotKey(IntPtr hWnd, int id, MOD fsModifiers, int vk);

        [DllImport("user32.dll")]
        internal static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("winmm.dll")]
        internal static extern uint timeBeginPeriod(uint uMilliseconds);

        [DllImport("winmm.dll")]
        internal static extern uint timeEndPeriod(uint uMilliseconds);

        [DllImport("winmm.dll", SetLastError = true)]
        internal static extern UInt32 timeGetDevCaps(ref TimeCaps timeCaps, uint sizeTimeCaps);
    }

#pragma warning disable 0649
    internal struct MSLLHOOKSTRUCT
    {
        internal int x;
        internal int y;
        internal int mouseData;
        internal int flags;
        internal int time;
        internal IntPtr dwExtraInfo;
    }

    internal struct KBDLLHOOKSTRUCT
    {
        internal int vkCode;
        internal int scanCode;
        internal int flags;
        internal int time;
        internal IntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct INPUT
    {
        internal int type;
        internal U inputunion;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct U
    {
        [FieldOffset(0)]
        internal MOUSEINPUT mi;
        [FieldOffset(0)]
        internal KEYBDINPUT ki;
        [FieldOffset(0)]
        internal HARDWAREINPUT hi;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct MOUSEINPUT
    {
        internal int dx;
        internal int dy;
        internal int mouseData;
        internal MOUSEEVENTF dwFlags;
        internal int time;
        internal IntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct KEYBDINPUT
    {
        internal ushort wVk;
        internal ushort wScan;
        internal KEYEVENTF dwFlags;
        internal int time;
        internal IntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct HARDWAREINPUT
    {
        internal uint uMsg;
        internal ushort wParamL;
        internal ushort wParamH;
    }
#pragma warning restore

    [StructLayout(LayoutKind.Sequential)]
    internal struct TimeCaps
    {
        public UInt32 wPeriodMin;
        public UInt32 wPeriodMax;
    }; 
}
