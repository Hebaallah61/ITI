namespace task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
        }

        Color br { get; set; } = Color.White;
       // private SolidBrush br { get; set; } 
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                br = colorDialog1.Color;
            }
        }

        private void Form1_MouseMove_1(object sender, MouseEventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            SolidBrush bs=new SolidBrush(br);
            var penb=new Pen(br);
            if (e.Button == MouseButtons.Left)
            {
                 gr.DrawRectangle(penb, e.X, e.Y, 20, 20);
                 gr.FillRectangle(bs, e.X, e.Y, 20, 20);
                //gr.FillEllipse(br, e.X, e.Y, 20, 20);
            }
            if (e.Button == MouseButtons.Right)
            {
                //br = new SolidBrush(Color.White);
                //gr.FillEllipse(br, e.X, e.Y, 20, 20);
                gr.DrawRectangle(Pens.White, e.X, e.Y, 20, 20);
                gr.FillRectangle(Brushes.White, e.X, e.Y, 20, 20);
            }

        }
    }
}