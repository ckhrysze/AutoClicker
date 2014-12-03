using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;

// Heavily influenced by
// https://alala666888.wordpress.com/2010/09/17/simulate-mouse-event-using-sendinput-and-setcursorpos/
namespace AutoClicker
{
    public class User32DllWrapper
    {

        public static void clickAndReturn(Point p, Point original)
        {
            SetCursorPos(p.X, p.Y);
            click(p);
            SetCursorPos(original.X, original.Y);
        }

        public static void click(Point p)
        {
            INPUT structInput = new INPUT();
            structInput.type = SendInputEventType.InputMouse;
            structInput.mkhi.mi.dwFlags = MouseEventFlags.ABSOLUTE | MouseEventFlags.LEFTDOWN | MouseEventFlags.LEFTUP;
            structInput.mkhi.mi.dx = p.X;
            structInput.mkhi.mi.dy = p.Y;
            uint i = SendInput(1, ref structInput, Marshal.SizeOf(new INPUT()));
        }

        public static void SendKeyDown(ushort keyCode)
        {
            INPUT structInput = new INPUT();
            structInput.type = SendInputEventType.InputKeyboard;
            structInput.mkhi.ki.wVk = keyCode;
            structInput.mkhi.ki.wScan = 0;
            structInput.mkhi.ki.dwFlags = KEY_DOWN;
            structInput.mkhi.ki.time = 0;
            structInput.mkhi.ki.dwExtraInfo = IntPtr.Zero;

            uint i = SendInput(1, ref structInput, Marshal.SizeOf(typeof(INPUT)));
        }

        public static void SendKeyUp(ushort keyCode)
        {
            INPUT structInput = new INPUT();
            structInput.type = SendInputEventType.InputKeyboard;
            structInput.mkhi.ki.wVk = keyCode;
            structInput.mkhi.ki.wScan = 0;
            structInput.mkhi.ki.dwFlags = KEY_UP;
            structInput.mkhi.ki.time = 0;
            structInput.mkhi.ki.dwExtraInfo = IntPtr.Zero;

            uint i = SendInput(1, ref structInput, Marshal.SizeOf(typeof(INPUT)));
        }

        public static void SendKeyPress(ushort keyCode)
        {
            SendKeyDown(keyCode);
            SendKeyUp(keyCode);
        }

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        static extern IntPtr GetMessageExtraInfo();

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint SendInput(uint nInputs, ref INPUT pInputs, int cbSize);

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [Flags]
        public enum MouseEventFlags
        {
            LEFTDOWN = 0x0002,
            LEFTUP = 0x0004,
            MIDDLEDOWN = 0x0020,
            MIDDLEUP = 0x0040,
            MOVE = 0x0001,
            ABSOLUTE = 0x8000,
            RIGHTDOWN = 0x0008,
            RIGHTUP = 0x0010
        }

        const uint KEY_DOWN = 0x0000;
        const uint KEY_UP = 0x0002;

        /// <summary>
        /// The event type contained in the union field
        /// </summary>
        enum SendInputEventType : int
        {
            /// <summary>
            /// Contains Mouse event data
            /// </summary>
            InputMouse,
            /// <summary>
            /// Contains Keyboard event data
            /// </summary>
            InputKeyboard,
            /// <summary>
            /// Contains Hardware event data
            /// </summary>
            InputHardware
        }


        /// <summary>
        /// The mouse data structure
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        struct MouseInputData
        {
            /// <summary>
            /// The x value, if ABSOLUTE is passed in the flag then this is an actual X and Y value
            /// otherwise it is a delta from the last position
            /// </summary>
            public int dx;
            /// <summary>
            /// The y value, if ABSOLUTE is passed in the flag then this is an actual X and Y value
            /// otherwise it is a delta from the last position
            /// </summary>
            public int dy;
            /// <summary>
            /// Wheel event data, X buttons
            /// </summary>
            public uint mouseData;
            /// <summary>
            /// ORable field with the various flags about buttons and nature of event
            /// </summary>
            public MouseEventFlags dwFlags;
            /// <summary>
            /// The timestamp for the event, if zero then the system will provide
            /// </summary>
            public uint time;
            /// <summary>
            /// Additional data obtained by calling app via GetMessageExtraInfo
            /// </summary>
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct HARDWAREINPUT
        {
            public int uMsg;
            public short wParamL;
            public short wParamH;
        }

        /// <summary>
        /// Captures the union of the three three structures.
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        struct MouseKeybdhardwareInputUnion
        {
            /// <summary>
            /// The Mouse Input Data
            /// </summary>
            [FieldOffset(0)]
            public MouseInputData mi;

            /// <summary>
            /// The Keyboard input data
            /// </summary>
            [FieldOffset(0)]
            public KEYBDINPUT ki;

            /// <summary>
            /// The hardware input data
            /// </summary>
            [FieldOffset(0)]
            public HARDWAREINPUT hi;
        }

        /// <summary>
        /// The Data passed to SendInput in an array.
        /// </summary>
        /// <remarks>Contains a union field type specifies what it contains </remarks>
        [StructLayout(LayoutKind.Sequential)]
        struct INPUT
        {
            /// <summary>
            /// The actual data type contained in the union Field
            /// </summary>
            public SendInputEventType type;
            public MouseKeybdhardwareInputUnion mkhi;
        }
    }
}
