
using System.Drawing;
using System.Drawing.Drawing2D;

namespace task4
{
    public partial class Form1 : Form
    {
        int lx=0, ly=0;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle= FormBorderStyle.None;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath gp= new GraphicsPath();
            gp.AddEllipse(50, 0, this.ClientSize.Width/2, this.ClientSize.Height);
            
            gp.AddEllipse(1, 95, 150, 150);
            gp.AddEllipse(360, 95, 150, 150);
            gp.AddEllipse(105, 160, 50, 50);
            e.Graphics.FillEllipse(Brushes.Black, 105, 160, 50, 50);
            gp.AddEllipse(350, 160, 50, 50);
            e.Graphics.FillEllipse(Brushes.Black, 350, 160, 50, 50);
            gp.AddEllipse(227, 200, 60, 60);
            e.Graphics.FillEllipse(Brushes.Black, 227, 200, 60, 60);
           
            PointF[] points1 =
            {
                new Point(151,294),
                new Point(205,310),
                new Point(319,302),
                new Point(353,280)
            };

            PointF[] points2 =
            {
                new Point(151,294),
                new Point(205,350),
                new Point(319,350),
                new Point(353,280)
            };
            e.Graphics.DrawCurve(Pens.Black, points1);
            e.Graphics.DrawCurve(Pens.Black, points2);
            gp.FillMode=FillMode.Winding;
            this.Region = new Region(gp);
            base.OnPaint(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lx += 30;
            ly += 30;
            if (lx > (100)) { ly = 30; }
            if (ly > (100)) { lx= 30; } 
            this.Location=new Point() { X=lx,Y=ly};
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }
    }
}