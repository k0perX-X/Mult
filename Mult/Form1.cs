using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

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
            if (FPS.Checked)
            {
                int num = 0;
                TimerCallback tm = new TimerCallback(Count);
                System.Threading.Timer timer = new System.Threading.Timer(tm, num, 0, 500);
                //константы 
                const double radiusB = 50;
                const double radiusM = 10;
                const double massB = 20;
                const double massM = 1;
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
                progressBar.Maximum = 2000;
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                for (int i = a.i; i < 16; i++)
                {
                    //прога
                    a.FPS += 1;
                    labelFPS.Text = a.realFPS;
                }
                stopWatch.Stop();
                int vrem = (int)(stopWatch.ElapsedMilliseconds / 15);
                numeric.Maximum = 1000 / vrem;
                if (!checkBox1.Checked)
                    for (int i = a.i; i < 2000; i++)
                        if (a.stop)
                        {
                            //прога
                            a.FPS += 1;
                            labelFPS.Text = a.realFPS;
                        }
                        else { }
                else
                {
                    progressBar.Value = progressBar.Maximum;
                    while (a.stop)
                    {
                        //прога
                        a.FPS += 1;
                        labelFPS.Text = a.realFPS;
                    }
                }
                buttonStart.Text = "Запустить мультик";
                f.Close();
            }
            else
            {
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
                progressBar.Maximum = 2000;
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                for (int i = a.i; i < 6; i++)
                {
                    //прога
                }
                stopWatch.Stop();
                int vrem = (int)(stopWatch.ElapsedMilliseconds / 5);
                numeric.Maximum = 1000 / vrem;
                if (!checkBox1.Checked)
                    for (int i = a.i; i < 2000; i++)
                        if (a.stop)
                        {
                            //прога
                        }
                        else { }
                else
                {
                    progressBar.Value = progressBar.Maximum;
                    while (a.stop)
                    {
                        //прога
                    }
                }
                buttonStart.Text = "Запустить мультик";
                f.Close();
            }
        }
        private static void Count(object obj)
        {
            a.realFPS = Math.Round(a.FPS / 0.5).ToString();
            a.FPS = 0;
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
        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            labelFPS.Text = "0.0";
        }
    }
}
