using System;
using System.Drawing;
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
            const int MercR = 50;
            double alphaMerc = 0;
            const int VenerR = 85;
            double alphaVener = 0;
            const int ZemR = 150;
            double alphaZem = 0;
            const int LunaR = 40;
            double alphaLuna = 0;
            const int MarsR = 230;
            double alphaMars = 0;
            const int uscor = 3;
            Random rand = new Random();
            const int MeteorR = 300;
            const int kolcometeor = 150;
            int[] meteorX = new int[kolcometeor];
            for (int i = 0; i < kolcometeor; i++)
                meteorX[i] = rand.Next(-20, 20);
            int[] meteorY = new int[kolcometeor];
            for (int i = 0; i < kolcometeor; i++)
                meteorY[i] = rand.Next(-20, 20);
            double[] meteorAlpha = new double[kolcometeor];
            for (int i = 0; i < kolcometeor; i++)
                meteorAlpha[i] = Math.PI * rand.NextDouble() * 2;
            double[] meteorAlphaDelta = new double[kolcometeor];
            for (int i = 0; i < kolcometeor; i++)
            {
                double x = rand.NextDouble();
                while (x < 0.6)
                    x = rand.NextDouble();
                meteorAlphaDelta[i] = (Math.PI / 250) * x;
            }
            int[] meteorRand = new int[kolcometeor];
            for (int i = 0; i < kolcometeor; i++)
                meteorRand[i] = rand.Next(3, 7);
            buttonStart.Text = "Запустить заново";
            Form2 f = new Form2();
            a.stop = false;
            if (a.FirstStart) { f.Show(); a.FirstStart = false; }
            Bitmap bit = new Bitmap(a.Width, a.Height);
            Pen p = new Pen(Color.White, 1);
            Graphics g = Graphics.FromImage(bit);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            a.stop = true;
            if (!a.stopButton) a.i = 0;
            progressBar.Maximum = 1000;
            for (int i = a.i; i < 1000; i++)
                if (a.stop)
                {
                    Application.DoEvents();
                    g.FillRectangle(Brushes.Black, 0, 0, a.Width, a.Height);
                    Program.FillCircle(g, Brushes.DarkOrange, a.Width / 2, a.Height / 2, 30);
                    Program.DrawCircle(g, p, a.Width / 2, a.Height / 2, MercR);
                    Program.FillCircle(g, Brushes.Brown, a.Width / 2 + (float)(MercR * Math.Sin(alphaMerc)), a.Height / 2 + (float)(MercR * Math.Cos(alphaMerc)), 10);
                    Program.DrawCircle(g, p, a.Width / 2, a.Height / 2, VenerR);
                    Program.FillCircle(g, Brushes.SandyBrown, a.Width / 2 + (float)(VenerR * Math.Sin(alphaVener)), a.Height / 2 + (float)(VenerR * Math.Cos(alphaVener)), 20);
                    Program.DrawCircle(g, p, a.Width / 2, a.Height / 2, ZemR);
                    Program.FillCircle(g, Brushes.Blue, a.Width / 2 + (float)(ZemR * Math.Sin(alphaZem)), a.Height / 2 + (float)(ZemR * Math.Cos(alphaZem)), 25);
                    Program.DrawCircle(g, p, a.Width / 2 + (float)(ZemR * Math.Sin(alphaZem)), a.Height / 2 + (float)(ZemR * Math.Cos(alphaZem)), LunaR);
                    Program.FillCircle(g, Brushes.Gray, a.Width / 2 + (float)(ZemR * Math.Sin(alphaZem)) + (float)(LunaR * Math.Sin(alphaLuna)), a.Height / 2 + (float)(ZemR * Math.Cos(alphaZem)) + (float)(LunaR * Math.Cos(alphaLuna)), 5);
                    Program.DrawCircle(g, p, a.Width / 2, a.Height / 2, MarsR);
                    Program.FillCircle(g, Brushes.OrangeRed, a.Width / 2 + (float)(MarsR * Math.Sin(alphaMars)), a.Height / 2 + (float)(MarsR * Math.Cos(alphaMars)), 23);
                    Program.DrawCircle(g, p, a.Width / 2, a.Height / 2, MeteorR);
                    for (int j = 0; j < kolcometeor; j++)
                        Program.FillCircle(g, Brushes.SaddleBrown, a.Width / 2 + (float)(MeteorR * Math.Sin(meteorAlpha[j])) + meteorX[j], a.Height / 2 + (float)(MeteorR * Math.Cos(meteorAlpha[j])) + meteorY[j], meteorRand[j]);
                    f.Vivod(bit);
                    progressBar.Value = i;
                    Thread.Sleep((int)(1000 / numeric.Value));
                    alphaMerc += Math.PI / 88 * uscor;
                    alphaVener += Math.PI / 225 * uscor;
                    alphaZem += Math.PI / 365 * uscor;
                    alphaLuna += Math.PI / 27.321661 * uscor;
                    alphaMars += Math.PI / 667 * uscor;
                    for (int j = 0; j < kolcometeor; j++)
                        meteorAlpha[j] += meteorAlphaDelta[j];
                }
            buttonStart.Text = "Запустить мультик";
            f.Close();
        }
        private void ButtonStop_Click(object sender, EventArgs e)
        {
            a.stop = false;
            a.stopButton = true;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            a.stop = false;
        }
    }
}
