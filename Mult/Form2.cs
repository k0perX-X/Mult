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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            a.FirstStart = true;
            a.stop = true;
        }
        public void Vivod(Bitmap bitmap)
        {
            pictureBox1.Image = bitmap;
        }
        public void close()
        {
            this.Close();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            a.Width = pictureBox1.Width;
            a.Height = pictureBox1.Height;
        }
    }
}
