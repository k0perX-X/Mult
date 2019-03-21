using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Mult
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public static void DrawCircle(this Graphics g, Pen pen,
                                 float centerX, float centerY, float radius)
        {
            g.DrawEllipse(pen, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }

        public static void FillCircle(this Graphics g, Brush brush,
                                      float centerX, float centerY, float radius)
        {
            g.FillEllipse(brush, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }
    }
    static class a
    {
        static public bool stop = false;
        static public int i = 0;
        static public bool stopButton = false;
        static public bool FirstStart = true;
        static public int Height;
        static public int Width;
        static public int FPS = 0;
        static public string realFPS = "0.0";
    }
    public class mol
    {
        public int radius;
        public int mass;
        public double x;
        public double y;
        public double impulsX;
        public double impulsY;
    }
}