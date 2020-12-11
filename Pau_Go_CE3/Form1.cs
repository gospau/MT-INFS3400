using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Pau_Go_CE3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void LightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Aqua;
        }

        private void DarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkRed;
        }
        int click = 0;
        private void Button1_Click(object sender, EventArgs e)
        {
            
            click++;
            label1.Text = String.Format("Clicked: {0}", click);
        }

        private void ResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            click = 0;
            label1.Text = String.Format("Clicked: 0");
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var sw = new StreamWriter("setting.txt");
            sw.WriteLine("{0}", click);
            sw.Close();
        }
    }
}
