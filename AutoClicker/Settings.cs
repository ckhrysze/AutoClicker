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
        static Thread InfoScrapper;

        static int militime;
        static int xLowerBound;
        static int xUpperBound;
        static int yLowerBound;
        static int yUpperBound;
        static int yCoord;
        public static int WM_HOTKEY = 0x312;


        public void AClick()
        {
            while (true)
            {
                int x = Cursor.Position.X;
                int y = Cursor.Position.Y;
                if (xLowerBound < x && x < xUpperBound && yLowerBound < y && y < yUpperBound)
                {
                    clickAt(Cursor.Position);
                }
                Thread.Sleep(militime);
            }
        }

        public void Scrapper()
        {
            while(true)
            {
                var title = User32DllWrapper.GetActiveWindowTitle();
                activeWindowTitle.Invoke((MethodInvoker)(() =>
                    activeWindowTitle.Text = title
                    ));
                Thread.Sleep(5000);
            }
        }

        private void clickAt(Point p)
        {
            User32DllWrapper.click(p);
        }

        public Settings()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        private void SettingsFormLoad(object sender, EventArgs e)
        {
            User32DllWrapper.RegisterHotKey(this.Handle, (int)Keys.F1, 0, (uint)Keys.F1);

            setupHotKey(Keys.NumPad1);
            setupHotKey(Keys.NumPad2);
            setupHotKey(Keys.NumPad3);
            setupHotKey(Keys.NumPad4);
            setupHotKey(Keys.NumPad5);
            setupHotKey(Keys.NumPad6);
            setupHotKey(Keys.NumPad7);
            setupHotKey(Keys.NumPad8);
            setupHotKey(Keys.NumPad9);

            setupHotKey(Keys.Add);
            setupHotKey(Keys.Subtract);

            AutoClick = new Thread(AClick);
            AutoClick.IsBackground = true;

            InfoScrapper = new Thread(Scrapper);
            InfoScrapper.IsBackground = true;
            InfoScrapper.Start();
        }

        private void setupHotKey(Keys key) { User32DllWrapper.RegisterHotKey(this.Handle, (int)key, 0, (uint)key); }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_HOTKEY)
            {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);

                switch (key)
                {
                    case Keys.F1: this.f1Handler(); break;
                    case Keys.NumPad1: this.levelHero(this.num1); break;
                    case Keys.NumPad2: this.levelHero(this.num2); break;
                    case Keys.NumPad3: this.levelHero(this.num3); break;
                    case Keys.NumPad4: this.levelHero(this.num4); break;
                    case Keys.NumPad5: this.levelHero(this.num5); break;
                    case Keys.NumPad6: this.levelHero(this.num6); break;
                    case Keys.NumPad7: this.levelHero(this.num7); break;
                    case Keys.NumPad8: this.levelHero(this.num8); break;
                    case Keys.NumPad9: this.allUpgrades(); break;
                    case Keys.Add: this.increaseLevelMultiplier(); break;
                    case Keys.Subtract: this.decreaseLevelMultiplier(); break;

                }
            }
        }

        private void decreaseLevelMultiplier()
        {
            int multiplier = int.Parse(levelX.Text);
            switch (multiplier)
            {
                case 100: multiplier = 25; break;
                case 25: multiplier = 10; break;
                case 10: multiplier = 1; break;
            }
            levelX.Text = multiplier.ToString();
        }

        private void increaseLevelMultiplier()
        {
            int multiplier = int.Parse(levelX.Text);
            switch (multiplier)
            {
                case 1: multiplier = 10; break;
                case 10: multiplier = 25; break;
                case 25: multiplier = 100; break;
            }
            levelX.Text = multiplier.ToString();
        }

        private void allUpgrades()
        {
            Label l = num7;
            var offset = 300;
            Point absPoint = this.PointToScreen(l.Location);
            Point toTheRight = new Point(absPoint.X + offset, absPoint.Y);
            User32DllWrapper.clickAndReturn(toTheRight, Cursor.Position);
            
        }

        private void levelHero(Label l)
        {
            checkMultiplier();
            var offset = 100;
            Point absPoint = this.PointToScreen(l.Location);
            Point toTheRight = new Point(absPoint.X + offset, absPoint.Y);
            User32DllWrapper.clickAndReturn(toTheRight, Cursor.Position);
            releaseMultiplier();
        }

        private void releaseMultiplier()
        {
            switch (int.Parse(levelX.Text))
            {
                case 10: User32DllWrapper.SendKeyUp((ushort)Keys.LShiftKey); break;
                case 25: User32DllWrapper.SendKeyUp((ushort)Keys.Z); break;
                case 100: User32DllWrapper.SendKeyUp((ushort)Keys.ControlKey); break;
            }
            Thread.Sleep(25);
        }

        private void checkMultiplier()
        {
            switch (int.Parse(levelX.Text))
            {
                case 10: User32DllWrapper.SendKeyDown((ushort)Keys.LShiftKey); break;
                case 25: User32DllWrapper.SendKeyDown((ushort)Keys.Z); break;
                case 100: User32DllWrapper.SendKeyDown((ushort)Keys.ControlKey); break;
            }
        }

        private void f1Handler()
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
