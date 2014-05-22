public partial class Form1 : Form
    {
        public static bool Close = false;
        Icon[] images;
        int offset = 0;


        public Form1()
        {
            InitializeComponent();

            notifyIcon1.BalloonTipText = "My application still working...";
            notifyIcon1.BalloonTipTitle = "My Sample Application";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info; 
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                this.Hide();
                notifyIcon1.ShowBalloonTip(500);
                //WindowState = FormWindowState.Minimized;
            }


        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.ShowBalloonTip(1000);
            WindowState = FormWindowState.Normal;

        }

        private void maximizeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Show();
            WindowState = FormWindowState.Normal;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close = true;
            this.Close();  
        }



        // Handle Closing of the Form.
        protected override void OnClosing(CancelEventArgs e)
        {
            if (Close)
            {
                e.Cancel = false;
            }
            else
            {

                WindowState = FormWindowState.Minimized;
                e.Cancel = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load the basic set of eight icons.
            images = new Icon[5];
            images[0] = new Icon("C:\\icon1.ico");
            images[1] = new Icon("C:\\icon2.ico");
            images[2] = new Icon("C:\\icon3.ico");
            images[3] = new Icon("C:\\icon4.ico");
            images[4] = new Icon("C:\\icon5.ico");
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            // Change the icon.
            // This event handler fires once every second (1000 ms).
            if (offset < 5)
            {
                notifyIcon1.Icon = images[offset];
                offset++;
            }
            else
            {
                offset = 0;
            }
        }

    }
    