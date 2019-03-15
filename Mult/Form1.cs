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
            buttonStart.Text = "Запустить заново";
            Form2 f = new Form2();
            a.stop = false;
            a.stop = true;
            if (a.FirstStart) { f.Show(); a.FirstStart = false; } 
            if (!a.stopButton) a.i = 0;
            progressBar.Maximum = 3600;
            for (int i = a.i; i < 3600; i++)
                if (a.stop)
                {
                    Application.DoEvents();
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
    }
}
