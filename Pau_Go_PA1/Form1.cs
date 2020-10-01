using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pau_Go_PA1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            label4.Text = "";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            double meal;
            double per;
            bool parseOK;

            parseOK = double.TryParse(textBox1.Text, out meal);
            if(parseOK == false || meal < 0)
            {
                MessageBox.Show("Enter valid meal cost");
                return;
            }
            parseOK = double.TryParse(textBox2.Text, out per);
            if (parseOK == false || per < 0)
            {
                MessageBox.Show("Enter valid tip");
                return;
            }
            
            if(per < 1)
            {
                double les = meal * per;
                label4.Text = String.Format("Tip:{0:C}", les);
            }
            else
            {
                double tipper = per / 100;
                double tip = meal * tipper;
                label4.Text = String.Format("Tip:{0:C}", tip);
            }
            
            
        }
    }
}
