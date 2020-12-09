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

namespace Pau_Go_PA3
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            StreamWriter sw = new StreamWriter("Pau_PA3.txt", false);
            sw.WriteLine("Name, Quantity, Totalcost, Costperpart");
            sw.Close();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            

            int q;
            bool a = int.TryParse(textBox2.Text, out q);

            double totalcost;
            bool b = double.TryParse(textBox3.Text, out totalcost);

            


            double cpp = totalcost / q;

            
            if( textBox1.Text == "")
            {
                MessageBox.Show("Please enter a name");
                return;
            }
            if (textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Please enter a number");
                return;
            }

            if (a == false || b == false)
            {
                MessageBox.Show("Please enter a valid number");
                return;
            }
            if ( q <= 0 || totalcost <=0 )
            {
                MessageBox.Show("Please enter a positive number");
                return;
            }
            StreamWriter sw = new StreamWriter("Pau_PA3.txt", true);
            sw.WriteLine("{0}, {1}, {2}, {3}", textBox1.Text, q, totalcost, cpp);
            
            sw.Close(); 

        }
    }
}
