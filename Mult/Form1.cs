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
            int MercR = 80;
            double alphaMerc = 0;
            buttonStart.Text = "Запустить заново";
            Form2 f = new Form2();
            a.stop = false;
            a.stop = true;
            if (a.FirstStart) { f.Show(); a.FirstStart = false; } 
            if (!a.stopButton) a.i = 0;
            progressBar.Maximum = 3600;
            Bitmap bit = new Bitmap(a.Width, a.Height);
            Pen p = new Pen(Color.White, 1);
            Graphics g = Graphics.FromImage(bit);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            for (int i = a.i; i < 3600; i++)
                if (a.stop)
                {
                    Application.DoEvents();
                    g.FillRectangle(Brushes.Black, 0, 0, a.Width, a.Height);
                    Program.FillCircle(g, Brushes.OrangeRed, a.Width / 2, a.Height / 2, 40);
                    Program.DrawCircle(g, p, a.Width / 2, a.Height / 2, MercR);
                    Program.FillCircle(g, Brushes.Brown, a.Width / 2 + (float)(MercR * Math.Sin(alphaMerc)), a.Height / 2 + (float)(MercR * Math.Cos(alphaMerc)), 20);

                    f.Vivod(bit);
                    progressBar.Value = i;
                    Thread.Sleep((int)(1000 / numeric.Value));
                    alphaMerc += 0.01;
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
            Form2 f = new Form2();
            f.close();
        }
    }
}
