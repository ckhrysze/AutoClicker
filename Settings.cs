using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing;

namespace AutoClicker
{
    public partial class Settings : Form
    {
        static Thread AutoClick;
        static int militime;
        static int xLowerBound;
        static int xUpperBound;
        static int yLowerBound;
        static int yUpperBound;
        static int yCoord;
        public static int WM_HOTKEY = 0x312;

        [DllImport("user32.dll")]
        public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr A_0, int A_1, int A_2, int A_3);

        private const int WM_CLOSE = 0x10;
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_LBUTTONUP = 0x202;

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;

        public void AClick()
        {
            while (true)
            {
                int x = Cursor.Position.X;
                int y = Cursor.Position.Y;
                if (xLowerBound < x && x < xUpperBound && yLowerBound < y && y < yUpperBound)
                {
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    Thread.Sleep(2);
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                }
                Thread.Sleep(militime);
            }
        }


        public Settings()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AutoClick = new Thread(AClick);
            RegisterHotKey(this.Handle, (int)Keys.F1, 0, (uint)Keys.F1);
            AutoClick.IsBackground = true;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_HOTKEY)
            {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);

                if (key == Keys.F1)
                {
                    if (!AutoClick.IsAlive)
                    {
                        try { captureInputs(); }
                        catch { setDefaults(); }

                        AutoClick.Start();
                        lstate.Text = "Clicking";
                        lstate.ForeColor = System.Drawing.Color.Green;
                        Controls.Add(lstate);
                    }
                    else
                    {
                        AutoClick.Abort();
                        AutoClick = new Thread(AClick);
                        lstate.Text = "Not Clicking";
                        lstate.ForeColor = System.Drawing.Color.Red;
                        Controls.Add(lstate);
                    }
                }
            }
        }

        private void captureInputs()
        {
            militime = int.Parse(textBox1.Text);
            xLowerBound = int.Parse(xLowerInput.Text);
            xUpperBound = int.Parse(xUpperInput.Text);
            yLowerBound = int.Parse(yLowerInput.Text);
            yUpperBound = int.Parse(yUpperInput.Text);
        }

        private void setDefaults()
        {
            militime = 23;
            xLowerBound = 1200;
            xUpperBound = 1300;
            yLowerBound = 500;
            yUpperBound = 600;
        }

    }
}
