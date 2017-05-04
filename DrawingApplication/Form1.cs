using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Pen red = new Pen(Color.Red);
        Pen green = new Pen(Color.Green);
        Pen blue = new Pen(Color.Blue);

        SolidBrush fillRed = new SolidBrush(Color.Red);
        SolidBrush fillGreen = new SolidBrush(Color.Green);
        SolidBrush fillBlue = new SolidBrush(Color.Blue);

        Rectangle rect = new Rectangle(20,20,220,90);
        Rectangle circle = new Rectangle(20, 20, 220, 90);
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawRectangle(red,rect);
            g.DrawEllipse(green,circle);

            g.FillRectangle(fillRed, rect);
            g.FillEllipse(fillGreen, circle);
        }
    }
}
