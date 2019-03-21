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
        private double sqr (double x)
        {
            return x * x;
        }
        private void ButtonStart_Click(object sender, EventArgs e)
        {
            if (FPS.Checked)
            {
                Form2 f = new Form2();
                f.Show();
                //константы 
                const int radiusM = 10;
                int radiusB = radiusM * (int)numericSootn.Value;
                const int massM = 1;
                int massB = massM * (int)numericSootn.Value;
                int kolvoB = (int)numericB.Value;
                int kolvoM = (int)numeriсM.Value;
                double[,] rast = new double[kolvoM + kolvoB, kolvoM + kolvoB];
                mol[] broun = new mol[kolvoM + kolvoB];
                for (int i = 0; i < kolvoB + kolvoM; i++)
                    broun[i] = new mol();
                Random rand = new Random();
                bool t;
                double vx;
                double vy;
                double ca;
                double sa;
                double px;
                double py;
                const double dt = 2;
                int jopa = 0;
                bool jepa = false;
                for (int i = 0; i < kolvoB; i++)
                {
                    broun[i].radius = radiusB;
                    broun[i].mass = massB;
                    t = false;
                    while (!t)
                    {
                        t = true;
                        broun[i].x = rand.Next(radiusB, a.Width - radiusB);
                        broun[i].y = rand.Next(radiusB, a.Height - radiusB);
                        jopa = 0;
                        for (int j = 0; j < i; j++)
                        {
                            rast[j, i] = Math.Sqrt(sqr(broun[i].x - broun[j].x) + sqr(broun[i].y - broun[i].y));
                            if (rast[j, i] < broun[i].radius + broun[j].radius)
                                t = false;
                            jopa += 1;
                            if (jopa > 1000)
                            {
                                f.Close();
                                jepa = true;
                                break;
                            }
                        }
                    }
                }
                if (!jepa)
                {

                    for (int i = kolvoB; i < kolvoM + kolvoB; i++)
                    {
                        broun[i].radius = radiusM;
                        broun[i].mass = massM;
                        int random = rand.Next(1, 10) * massM;
                        broun[i].impulsX = random * Math.Cos(rand.Next(360)/360 * Math.PI);
                        broun[i].impulsY = random * Math.Sin(rand.Next(360)/360 * Math.PI);
                        t = false;
                        while (!t)
                        {
                            t = true;
                            broun[i].x = rand.Next(radiusM, a.Width - radiusM);
                            broun[i].y = rand.Next(radiusM, a.Height - radiusM);
                            jopa = 0;
                            for (int j = 0; j < i; j++)
                            {
                                rast[j, i] = Math.Sqrt(sqr(broun[i].x - broun[j].x) + sqr(broun[i].y - broun[j].y));
                                if (rast[j, i] < broun[i].radius + broun[j].radius)
                                    t = false;
                                jopa += 1;
                                if (jopa > 1000)
                                {
                                    f.Close();
                                    jepa = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (!jepa)
                    {
                        buttonStart.Text = "Запустить заново";
                        a.stop = false;
                        Bitmap bit = new Bitmap(a.Width, a.Height);
                        Pen p = new Pen(Color.White, 1);
                        Graphics g = Graphics.FromImage(bit);
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        if (!a.stopButton) a.i = 0;
                        progressBar.Maximum = 2000;
                        Stopwatch stopWatch = new Stopwatch();
                        stopWatch.Start();
                        for (int u = 0; u < 16; u++)
                        {
                            Application.DoEvents();
                            g.FillRectangle(Brushes.Black, 0, 0, a.Width, a.Height);
                            for (int i = kolvoB; i < kolvoB + kolvoM; i++)
                            {
                                if (((broun[i].x <= broun[i].radius) && (broun[i].impulsX < 0)) || ((broun[i].x >= a.Width - broun[i].radius) && (broun[i].impulsX > 0)))
                                    broun[i].impulsX = -broun[i].impulsX;
                                broun[i].x = broun[i].impulsX / broun[i].mass / dt + broun[i].x;
                                if (((broun[i].y <= broun[i].radius) && (broun[i].impulsY < 0)) || ((broun[i].y >= a.Height - broun[i].radius) && (broun[i].impulsY > 0)))
                                    broun[i].impulsY = -broun[i].impulsY;
                                broun[i].y = broun[i].impulsY / broun[i].mass / dt + broun[i].y;
                                Program.FillCircle(g, Brushes.Blue, (float)(broun[i].x), (float)(broun[i].y), broun[i].radius);
                            }
                            for (int i = 0; i < kolvoB; i++)
                            {
                                if (((broun[i].x <= broun[i].radius) && (broun[i].impulsX < 0)) || ((broun[i].x >= a.Width - broun[i].radius) && (broun[i].impulsX > 0)))
                                    broun[i].impulsX = -broun[i].impulsX;
                                broun[i].x = broun[i].impulsX / broun[i].mass / dt + broun[i].x;
                                if (((broun[i].y <= broun[i].radius) && (broun[i].impulsY < 0)) || ((broun[i].y >= a.Height - broun[i].radius) && (broun[i].impulsY > 0)))
                                    broun[i].impulsY = -broun[i].impulsY;
                                broun[i].y = broun[i].impulsY / broun[i].mass / dt + broun[i].y;
                                Program.FillCircle(g, Brushes.Red, (float)(broun[i].x), (float)(broun[i].y), broun[i].radius);
                            }
                            for (int i = 0; i < kolvoB + kolvoM; i++)
                                for (int j = i + 1; j < kolvoM + kolvoB; j++)
                                    rast[i, j] = Math.Sqrt(sqr(broun[i].x - broun[j].x) + sqr(broun[i].y - broun[j].y));
                            for (int i = 0; i < kolvoB + kolvoM; i++)
                                for (int j = i + 1; j < kolvoM + kolvoB; j++)
                                    if (rast[i, j] <= broun[i].radius + broun[j].radius)
                                    {
                                        vx = broun[i].impulsX / broun[i].mass - broun[j].impulsX / broun[j].mass;
                                        vy = broun[i].impulsY / broun[i].mass - broun[j].impulsY / broun[j].mass;
                                        ca = (broun[j].x - broun[i].x) / rast[i, j];
                                        sa = (broun[j].y - broun[i].y) / rast[i, j];
                                        px = 2 * broun[i].mass * broun[j].mass * (vx * ca + vy * sa) / (broun[i].mass + broun[j].mass) * ca;
                                        py = px / ca * sa;
                                        if (px * ca > 0)
                                        {
                                            broun[i].impulsX = vx * broun[i].mass - px + broun[j].impulsX / broun[j].mass * broun[i].mass;
                                            broun[i].impulsY = vy * broun[i].mass - py + broun[j].impulsY / broun[j].mass * broun[i].mass;
                                            broun[j].impulsX = px + broun[j].impulsX;
                                            broun[j].impulsY = py + broun[j].impulsY;
                                        }
                                    }
                            f.Vivod(bit);
                        }
                        stopWatch.Stop();
                        a.stop = true;
                        int num = 0;
                        TimerCallback tm = new TimerCallback(Count);
                        System.Threading.Timer timer = new System.Threading.Timer(tm, num, 0, 500);
                        int vrem = (int)(stopWatch.ElapsedMilliseconds / 15);
                        numeric.Maximum = 1000 / vrem;
                        if (!checkBox1.Checked)
                            for (int u = a.i; u < 2000; u++)
                                if (a.stop)
                                {
                                    Application.DoEvents();
                                    g.FillRectangle(Brushes.Black, 0, 0, a.Width, a.Height);
                                    for (int i = kolvoB; i < kolvoB + kolvoM; i++)
                                    {
                                        if (((broun[i].x <= broun[i].radius) && (broun[i].impulsX < 0)) || ((broun[i].x >= a.Width - broun[i].radius) && (broun[i].impulsX > 0)))
                                            broun[i].impulsX = -broun[i].impulsX;
                                        broun[i].x = broun[i].impulsX / broun[i].mass / dt + broun[i].x;
                                        if (((broun[i].y <= broun[i].radius) && (broun[i].impulsY < 0)) || ((broun[i].y >= a.Height - broun[i].radius) && (broun[i].impulsY > 0)))
                                            broun[i].impulsY = -broun[i].impulsY;
                                        broun[i].y = broun[i].impulsY / broun[i].mass / dt + broun[i].y;
                                        Program.FillCircle(g, Brushes.Blue, (float)(broun[i].x), (float)(broun[i].y), broun[i].radius);
                                    }
                                    for (int i = 0; i < kolvoB; i++)
                                    {
                                        if (((broun[i].x <= broun[i].radius) && (broun[i].impulsX < 0)) || ((broun[i].x >= a.Width - broun[i].radius) && (broun[i].impulsX > 0)))
                                            broun[i].impulsX = -broun[i].impulsX;
                                        broun[i].x = broun[i].impulsX / broun[i].mass / dt + broun[i].x;
                                        if (((broun[i].y <= broun[i].radius) && (broun[i].impulsY < 0)) || ((broun[i].y >= a.Height - broun[i].radius) && (broun[i].impulsY > 0)))
                                            broun[i].impulsY = -broun[i].impulsY;
                                        broun[i].y = broun[i].impulsY / broun[i].mass / dt + broun[i].y;
                                        Program.FillCircle(g, Brushes.Red, (float)(broun[i].x), (float)(broun[i].y), broun[i].radius);
                                    }
                                    for (int i = 0; i < kolvoB + kolvoM; i++)
                                        for (int j = i + 1; j < kolvoM + kolvoB; j++)
                                            rast[i, j] = Math.Sqrt(sqr(broun[i].x - broun[j].x) + sqr(broun[i].y - broun[j].y));
                                    for (int i = 0; i < kolvoB + kolvoM; i++)
                                        for (int j = i + 1; j < kolvoM + kolvoB; j++)
                                            if (rast[i, j] <= broun[i].radius + broun[j].radius)
                                            {
                                                vx = broun[i].impulsX / broun[i].mass - broun[j].impulsX / broun[j].mass;
                                                vy = broun[i].impulsY / broun[i].mass - broun[j].impulsY / broun[j].mass;
                                                ca = (broun[j].x - broun[i].x) / rast[i, j];
                                                sa = (broun[j].y - broun[i].y) / rast[i, j];
                                                px = 2 * broun[i].mass * broun[j].mass * (vx * ca + vy * sa) / (broun[i].mass + broun[j].mass) * ca;
                                                py = px / ca * sa;
                                                if (px * ca > 0)
                                                {
                                                    broun[i].impulsX = vx * broun[i].mass - px + broun[j].impulsX / broun[j].mass * broun[i].mass;
                                                    broun[i].impulsY = vy * broun[i].mass - py + broun[j].impulsY / broun[j].mass * broun[i].mass;
                                                    broun[j].impulsX = px + broun[j].impulsX;
                                                    broun[j].impulsY = py + broun[j].impulsY;
                                                }
                                            }
                                    f.Vivod(bit);
                                    progressBar.Value = u;
                                    Thread.Sleep((int)(1000 / numeric.Value) - vrem);
                                    a.FPS += 1;
                                    labelFPS.Text = a.realFPS;
                                }
                                else { }
                        else
                        {
                            progressBar.Value = progressBar.Maximum;
                            while (a.stop)
                            {
                                Application.DoEvents();
                                g.FillRectangle(Brushes.Black, 0, 0, a.Width, a.Height);
                                for (int i = kolvoB; i < kolvoB + kolvoM; i++)
                                {
                                    if (((broun[i].x <= broun[i].radius) && (broun[i].impulsX < 0)) || ((broun[i].x >= a.Width - broun[i].radius) && (broun[i].impulsX > 0)))
                                        broun[i].impulsX = -broun[i].impulsX;
                                    broun[i].x = broun[i].impulsX / broun[i].mass / dt + broun[i].x;
                                    if (((broun[i].y <= broun[i].radius) && (broun[i].impulsY < 0)) || ((broun[i].y >= a.Height - broun[i].radius) && (broun[i].impulsY > 0)))
                                        broun[i].impulsY = -broun[i].impulsY;
                                    broun[i].y = broun[i].impulsY / broun[i].mass / dt + broun[i].y;
                                    Program.FillCircle(g, Brushes.Blue, (float)(broun[i].x), (float)(broun[i].y), broun[i].radius);
                                }
                                for (int i = 0; i < kolvoB; i++)
                                {
                                    if (((broun[i].x <= broun[i].radius) && (broun[i].impulsX < 0)) || ((broun[i].x >= a.Width - broun[i].radius) && (broun[i].impulsX > 0)))
                                        broun[i].impulsX = -broun[i].impulsX;
                                    broun[i].x = broun[i].impulsX / broun[i].mass / dt + broun[i].x;
                                    if (((broun[i].y <= broun[i].radius) && (broun[i].impulsY < 0)) || ((broun[i].y >= a.Height - broun[i].radius) && (broun[i].impulsY > 0)))
                                        broun[i].impulsY = -broun[i].impulsY;
                                    broun[i].y = broun[i].impulsY / broun[i].mass / dt + broun[i].y;
                                    Program.FillCircle(g, Brushes.Red, (float)(broun[i].x), (float)(broun[i].y), broun[i].radius);
                                }
                                for (int i = 0; i < kolvoB + kolvoM; i++)
                                    for (int j = i + 1; j < kolvoM + kolvoB; j++)
                                        rast[i, j] = Math.Sqrt(sqr(broun[i].x - broun[j].x) + sqr(broun[i].y - broun[j].y));
                                for (int i = 0; i < kolvoB + kolvoM; i++)
                                    for (int j = i + 1; j < kolvoM + kolvoB; j++)
                                        if (rast[i, j] <= broun[i].radius + broun[j].radius)
                                        {
                                            vx = broun[i].impulsX / broun[i].mass - broun[j].impulsX / broun[j].mass;
                                            vy = broun[i].impulsY / broun[i].mass - broun[j].impulsY / broun[j].mass;
                                            ca = (broun[j].x - broun[i].x) / rast[i, j];
                                            sa = (broun[j].y - broun[i].y) / rast[i, j];
                                            px = 2 * broun[i].mass * broun[j].mass * (vx * ca + vy * sa) / (broun[i].mass + broun[j].mass) * ca;
                                            py = px / ca * sa;
                                            if (px * ca > 0)
                                            {
                                                broun[i].impulsX = vx * broun[i].mass - px + broun[j].impulsX / broun[j].mass * broun[i].mass;
                                                broun[i].impulsY = vy * broun[i].mass - py + broun[j].impulsY / broun[j].mass * broun[i].mass;
                                                broun[j].impulsX = px + broun[j].impulsX;
                                                broun[j].impulsY = py + broun[j].impulsY;
                                            }
                                        }
                                f.Vivod(bit);
                                Thread.Sleep((int)(1000 / numeric.Value) - vrem); a.FPS += 1;
                                a.FPS += 1;
                                labelFPS.Text = a.realFPS;
                            }
                        }
                        buttonStart.Text = "Запустить мультик";
                        f.Close();
                    }
                }
            }
            else
            {
                Form2 f = new Form2();
                f.Show();
                //константы 
                const int radiusM = 10;
                int radiusB = radiusM * (int)numericSootn.Value;
                const int massM = 1;
                int massB = massM * (int)numericSootn.Value;
                int kolvoB = (int)numericB.Value;
                int kolvoM = (int)numeriсM.Value;
                double[,] rast = new double[kolvoM + kolvoB, kolvoM + kolvoB];
                mol[] broun = new mol[kolvoM + kolvoB];
                for (int i = 0; i < kolvoB + kolvoM; i++)
                    broun[i] = new mol();
                Random rand = new Random();
                bool t;
                double vx;
                double vy;
                double ca;
                double sa;
                double px;
                double py;
                const double dt = 2;
                int jopa = 0;
                bool jepa = false;
                for (int i = 0; i < kolvoB; i++)
                {
                    broun[i].radius = radiusB;
                    broun[i].mass = massB;
                    t = false;
                    while (!t)
                    {
                        t = true;
                        broun[i].x = rand.Next(radiusB, a.Width - radiusB);
                        broun[i].y = rand.Next(radiusB, a.Height - radiusB);
                        jopa = 0;
                        for (int j = 0; j < i; j++)
                        {
                            rast[j, i] = Math.Sqrt(sqr(broun[i].x - broun[j].x) + sqr(broun[i].y - broun[i].y));
                            if (rast[j, i] < broun[i].radius + broun[j].radius)
                                t = false;
                            jopa += 1;
                            if (jopa > 1000)
                            {
                                f.Close();
                                jepa = true;
                                break;
                            }
                        }
                    }
                }
                if (!jepa)
                {

                    for (int i = kolvoB; i < kolvoM + kolvoB; i++)
                    {
                        broun[i].radius = radiusM;
                        broun[i].mass = massM;
                        int random = rand.Next(1, 10) * massM;
                        broun[i].impulsX = random * Math.Cos(rand.Next(360) / 360 * Math.PI);
                        broun[i].impulsY = random * Math.Sin(rand.Next(360) / 360 * Math.PI);
                        t = false;
                        while (!t)
                        {
                            t = true;
                            broun[i].x = rand.Next(radiusM, a.Width - radiusM);
                            broun[i].y = rand.Next(radiusM, a.Height - radiusM);
                            jopa = 0;
                            for (int j = 0; j < i; j++)
                            {
                                rast[j, i] = Math.Sqrt(sqr(broun[i].x - broun[j].x) + sqr(broun[i].y - broun[j].y));
                                if (rast[j, i] < broun[i].radius + broun[j].radius)
                                    t = false;
                                jopa += 1;
                                if (jopa > 1000)
                                {
                                    f.Close();
                                    jepa = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (!jepa)
                    {
                        buttonStart.Text = "Запустить заново";
                        a.stop = false;
                        Bitmap bit = new Bitmap(a.Width, a.Height);
                        Pen p = new Pen(Color.White, 1);
                        Graphics g = Graphics.FromImage(bit);
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        if (!a.stopButton) a.i = 0;
                        progressBar.Maximum = 2000;
                        Stopwatch stopWatch = new Stopwatch();
                        stopWatch.Start();
                        for (int u = 0; u < 16; u++)
                        {
                            Application.DoEvents();
                            g.FillRectangle(Brushes.Black, 0, 0, a.Width, a.Height);
                            for (int i = kolvoB; i < kolvoB + kolvoM; i++)
                            {
                                if (((broun[i].x <= broun[i].radius) && (broun[i].impulsX < 0)) || ((broun[i].x >= a.Width - broun[i].radius) && (broun[i].impulsX > 0)))
                                    broun[i].impulsX = -broun[i].impulsX;
                                broun[i].x = broun[i].impulsX / broun[i].mass / dt + broun[i].x;
                                if (((broun[i].y <= broun[i].radius) && (broun[i].impulsY < 0)) || ((broun[i].y >= a.Height - broun[i].radius) && (broun[i].impulsY > 0)))
                                    broun[i].impulsY = -broun[i].impulsY;
                                broun[i].y = broun[i].impulsY / broun[i].mass / dt + broun[i].y;
                                Program.FillCircle(g, Brushes.Blue, (float)(broun[i].x), (float)(broun[i].y), broun[i].radius);
                            }
                            for (int i = 0; i < kolvoB; i++)
                            {
                                if (((broun[i].x <= broun[i].radius) && (broun[i].impulsX < 0)) || ((broun[i].x >= a.Width - broun[i].radius) && (broun[i].impulsX > 0)))
                                    broun[i].impulsX = -broun[i].impulsX;
                                broun[i].x = broun[i].impulsX / broun[i].mass / dt + broun[i].x;
                                if (((broun[i].y <= broun[i].radius) && (broun[i].impulsY < 0)) || ((broun[i].y >= a.Height - broun[i].radius) && (broun[i].impulsY > 0)))
                                    broun[i].impulsY = -broun[i].impulsY;
                                broun[i].y = broun[i].impulsY / broun[i].mass / dt + broun[i].y;
                                Program.FillCircle(g, Brushes.Red, (float)(broun[i].x), (float)(broun[i].y), broun[i].radius);
                            }
                            for (int i = 0; i < kolvoB + kolvoM; i++)
                                for (int j = i + 1; j < kolvoM + kolvoB; j++)
                                    rast[i, j] = Math.Sqrt(sqr(broun[i].x - broun[j].x) + sqr(broun[i].y - broun[j].y));
                            for (int i = 0; i < kolvoB + kolvoM; i++)
                                for (int j = i + 1; j < kolvoM + kolvoB; j++)
                                    if (rast[i, j] <= broun[i].radius + broun[j].radius)
                                    {
                                        vx = broun[i].impulsX / broun[i].mass - broun[j].impulsX / broun[j].mass;
                                        vy = broun[i].impulsY / broun[i].mass - broun[j].impulsY / broun[j].mass;
                                        ca = (broun[j].x - broun[i].x) / rast[i, j];
                                        sa = (broun[j].y - broun[i].y) / rast[i, j];
                                        px = 2 * broun[i].mass * broun[j].mass * (vx * ca + vy * sa) / (broun[i].mass + broun[j].mass) * ca;
                                        py = px / ca * sa;
                                        if (px * ca > 0)
                                        {
                                            broun[i].impulsX = vx * broun[i].mass - px + broun[j].impulsX / broun[j].mass * broun[i].mass;
                                            broun[i].impulsY = vy * broun[i].mass - py + broun[j].impulsY / broun[j].mass * broun[i].mass;
                                            broun[j].impulsX = px + broun[j].impulsX;
                                            broun[j].impulsY = py + broun[j].impulsY;
                                        }
                                    }
                            f.Vivod(bit);
                        }
                        stopWatch.Stop();
                        a.stop = true;
                        int vrem = (int)(stopWatch.ElapsedMilliseconds / 15);
                        numeric.Maximum = 1000 / vrem;
                        if (!checkBox1.Checked)
                            for (int u = a.i; u < 2000; u++)
                                if (a.stop)
                                {
                                    Application.DoEvents();
                                    g.FillRectangle(Brushes.Black, 0, 0, a.Width, a.Height);
                                    for (int i = kolvoB; i < kolvoB + kolvoM; i++)
                                    {
                                        if (((broun[i].x <= broun[i].radius) && (broun[i].impulsX < 0)) || ((broun[i].x >= a.Width - broun[i].radius) && (broun[i].impulsX > 0)))
                                            broun[i].impulsX = -broun[i].impulsX;
                                        broun[i].x = broun[i].impulsX / broun[i].mass / dt + broun[i].x;
                                        if (((broun[i].y <= broun[i].radius) && (broun[i].impulsY < 0)) || ((broun[i].y >= a.Height - broun[i].radius) && (broun[i].impulsY > 0)))
                                            broun[i].impulsY = -broun[i].impulsY;
                                        broun[i].y = broun[i].impulsY / broun[i].mass / dt + broun[i].y;
                                        Program.FillCircle(g, Brushes.Blue, (float)(broun[i].x), (float)(broun[i].y), broun[i].radius);
                                    }
                                    for (int i = 0; i < kolvoB; i++)
                                    {
                                        if (((broun[i].x <= broun[i].radius) && (broun[i].impulsX < 0)) || ((broun[i].x >= a.Width - broun[i].radius) && (broun[i].impulsX > 0)))
                                            broun[i].impulsX = -broun[i].impulsX;
                                        broun[i].x = broun[i].impulsX / broun[i].mass / dt + broun[i].x;
                                        if (((broun[i].y <= broun[i].radius) && (broun[i].impulsY < 0)) || ((broun[i].y >= a.Height - broun[i].radius) && (broun[i].impulsY > 0)))
                                            broun[i].impulsY = -broun[i].impulsY;
                                        broun[i].y = broun[i].impulsY / broun[i].mass / dt + broun[i].y;
                                        Program.FillCircle(g, Brushes.Red, (float)(broun[i].x), (float)(broun[i].y), broun[i].radius);
                                    }
                                    for (int i = 0; i < kolvoB + kolvoM; i++)
                                        for (int j = i + 1; j < kolvoM + kolvoB; j++)
                                            rast[i, j] = Math.Sqrt(sqr(broun[i].x - broun[j].x) + sqr(broun[i].y - broun[j].y));
                                    for (int i = 0; i < kolvoB + kolvoM; i++)
                                        for (int j = i + 1; j < kolvoM + kolvoB; j++)
                                            if (rast[i, j] <= broun[i].radius + broun[j].radius)
                                            {
                                                vx = broun[i].impulsX / broun[i].mass - broun[j].impulsX / broun[j].mass;
                                                vy = broun[i].impulsY / broun[i].mass - broun[j].impulsY / broun[j].mass;
                                                ca = (broun[j].x - broun[i].x) / rast[i, j];
                                                sa = (broun[j].y - broun[i].y) / rast[i, j];
                                                px = 2 * broun[i].mass * broun[j].mass * (vx * ca + vy * sa) / (broun[i].mass + broun[j].mass) * ca;
                                                py = px / ca * sa;
                                                if (px * ca > 0)
                                                {
                                                    broun[i].impulsX = vx * broun[i].mass - px + broun[j].impulsX / broun[j].mass * broun[i].mass;
                                                    broun[i].impulsY = vy * broun[i].mass - py + broun[j].impulsY / broun[j].mass * broun[i].mass;
                                                    broun[j].impulsX = px + broun[j].impulsX;
                                                    broun[j].impulsY = py + broun[j].impulsY;
                                                }
                                            }
                                    f.Vivod(bit);
                                    progressBar.Value = u;
                                    Thread.Sleep((int)(1000 / numeric.Value) - vrem);
                                }
                                else { }
                        else
                        {
                            progressBar.Value = progressBar.Maximum;
                            while (a.stop)
                            {
                                Application.DoEvents();
                                g.FillRectangle(Brushes.Black, 0, 0, a.Width, a.Height);
                                for (int i = kolvoB; i < kolvoB + kolvoM; i++)
                                {
                                    if (((broun[i].x <= broun[i].radius) && (broun[i].impulsX < 0)) || ((broun[i].x >= a.Width - broun[i].radius) && (broun[i].impulsX > 0)))
                                        broun[i].impulsX = -broun[i].impulsX;
                                    broun[i].x = broun[i].impulsX / broun[i].mass / dt + broun[i].x;
                                    if (((broun[i].y <= broun[i].radius) && (broun[i].impulsY < 0)) || ((broun[i].y >= a.Height - broun[i].radius) && (broun[i].impulsY > 0)))
                                        broun[i].impulsY = -broun[i].impulsY;
                                    broun[i].y = broun[i].impulsY / broun[i].mass / dt + broun[i].y;
                                    Program.FillCircle(g, Brushes.Blue, (float)(broun[i].x), (float)(broun[i].y), broun[i].radius);
                                }
                                for (int i = 0; i < kolvoB; i++)
                                {
                                    if (((broun[i].x <= broun[i].radius) && (broun[i].impulsX < 0)) || ((broun[i].x >= a.Width - broun[i].radius) && (broun[i].impulsX > 0)))
                                        broun[i].impulsX = -broun[i].impulsX;
                                    broun[i].x = broun[i].impulsX / broun[i].mass / dt + broun[i].x;
                                    if (((broun[i].y <= broun[i].radius) && (broun[i].impulsY < 0)) || ((broun[i].y >= a.Height - broun[i].radius) && (broun[i].impulsY > 0)))
                                        broun[i].impulsY = -broun[i].impulsY;
                                    broun[i].y = broun[i].impulsY / broun[i].mass / dt + broun[i].y;
                                    Program.FillCircle(g, Brushes.Red, (float)(broun[i].x), (float)(broun[i].y), broun[i].radius);
                                }
                                for (int i = 0; i < kolvoB + kolvoM; i++)
                                    for (int j = i + 1; j < kolvoM + kolvoB; j++)
                                        rast[i, j] = Math.Sqrt(sqr(broun[i].x - broun[j].x) + sqr(broun[i].y - broun[j].y));
                                for (int i = 0; i < kolvoB + kolvoM; i++)
                                    for (int j = i + 1; j < kolvoM + kolvoB; j++)
                                        if (rast[i, j] <= broun[i].radius + broun[j].radius)
                                        {
                                            vx = broun[i].impulsX / broun[i].mass - broun[j].impulsX / broun[j].mass;
                                            vy = broun[i].impulsY / broun[i].mass - broun[j].impulsY / broun[j].mass;
                                            ca = (broun[j].x - broun[i].x) / rast[i, j];
                                            sa = (broun[j].y - broun[i].y) / rast[i, j];
                                            px = 2 * broun[i].mass * broun[j].mass * (vx * ca + vy * sa) / (broun[i].mass + broun[j].mass) * ca;
                                            py = px / ca * sa;
                                            if (px * ca > 0)
                                            {
                                                broun[i].impulsX = vx * broun[i].mass - px + broun[j].impulsX / broun[j].mass * broun[i].mass;
                                                broun[i].impulsY = vy * broun[i].mass - py + broun[j].impulsY / broun[j].mass * broun[i].mass;
                                                broun[j].impulsX = px + broun[j].impulsX;
                                                broun[j].impulsY = py + broun[j].impulsY;
                                            }
                                        }
                                f.Vivod(bit);
                                Thread.Sleep((int)(1000 / numeric.Value) - vrem); a.FPS += 1;
                            }
                        }
                        buttonStart.Text = "Запустить мультик";
                        f.Close();
                    }
                }
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