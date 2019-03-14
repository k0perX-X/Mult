using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            f.Show();
            for (int i = 0; i < 3600; i++)
                if (a.stop)
                {

                }
            buttonStart.Text = "Запустить мультик";
            a.stop = false;
            f.Close();
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            a.stop = true;
        }
    }
}
