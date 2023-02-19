using System.Threading.Tasks;
using System.Data;
using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Drawing;
using Timer = System.Windows.Forms.Timer;

namespace task5
{
    public partial class Form1 : Form
    {

        int x = 35;
        public Form1()
        {
            InitializeComponent();
            this.ClientSize = new Size(400, 400);
            Timer t1= new Timer();
            t1.Interval = 100;
            t1.Tick += new EventHandler(t1_tick);
            t1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
          
        }
        

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g= e.Graphics;
            g.FillEllipse(Brushes.BlueViolet, x - 10, this.ClientSize.Height / 2 - 10, 30, 30);
            g.FillEllipse(Brushes.Black, 0, 50 , 50, 50);
            g.FillEllipse(Brushes.Black, 350, 50 , 50, 50);
            g.DrawLine(Pens.Black, 25, 100, 25, 200);
            g.DrawLine(Pens.Black, 380, 100, 380, 200);
            g.DrawLine(Pens.Black, 25, 108, 100, 50);
            g.DrawLine(Pens.Black, 25, 108, 110, 50);
            g.DrawLine(Pens.Black, 380, 108, 300, 50);
            g.DrawLine(Pens.Black, 380, 108, 310, 50);
            g.DrawLine(Pens.Black, 25, 200, 50, 205);
            g.DrawLine(Pens.Black, 380, 200, 350, 202);

            base.OnPaint(e);
        }
        int f = 0;
        private void t1_tick(object sender, EventArgs e)
        {

            if (f==0)
            {
                x += 5;
                if (x >= 350) f = 1;
            }
            else if (f == 1)
            {
                x -= 5;
                if (x <= 35) f = 0;
            }
            
           

            Invalidate();
        }
    }
}