using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Mult
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void ButtonStart_Click(object sender, EventArgs e)
        {
            /*const double sunCoef = 1.9855;
            const int sunSt = 30;
            const double grav = 6.6740831 * 0.00000000001;
            const int MercR = 57910000;
            const int VenR = 108000000;
            const int ZemR = 149600000;
            const int LunR = 384403;*/
            int MercR = 80;
            buttonStart.Text = "Запустить заново";
            Form2 f = new Form2();
            a.stop = false;
            a.stop = true;
            if (a.FirstStart) { f.Show(); a.FirstStart = false; } 
            if (!a.stopButton) a.i = 0;
            progressBar.Maximum = 3600;
            Bitmap bit = new Bitmap(a.Width, a.Height);
            for (int i = a.i; i < 3600; i++)
                if (a.stop)
                {
                    Application.DoEvents();
                    Pen p = new Pen(Color.White, 1);
                    Graphics g = Graphics.FromImage(bit);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.FillRectangle(Brushes.Black, 0, 0, a.Width, a.Height);
                    Program.FillCircle(g, Brushes.OrangeRed, a.Width / 2, a.Height / 2, 40);
                    Program.DrawCircle(g, p, a.Width / 2, a.Height / 2, MercR);
                    Program.FillCircle(g, Brushes.Brown, a.Width / 2 + MercR, a.Height / 2 + MercR, 20);

                    f.Vivod(bit);
                    progressBar.Value = i;
                    Thread.Sleep((int)(1000 / numeric.Value));
                }
                else
                {
                    a.i = i;
                }
            buttonStart.Text = "Запустить мультик";
        }
        private void ButtonStop_Click(object sender, EventArgs e)
        {
            a.stop = false;
            a.stopButton = true;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
