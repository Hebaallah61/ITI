namespace task3
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
        Rectangle rec=new Rectangle(0,0,150,100);
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Violet, rec);
            base.OnPaint(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                rec.X= e.X;
                rec.Y= e.Y;
                Invalidate();
            }
        }
    }
}