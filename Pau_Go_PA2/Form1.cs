using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pau_Go_PA2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Reset();
        }

        private void Reset()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Text = "";
            
        }

        
        private void Button1_Click(object sender, EventArgs e)
        {
            int point = 0;

            if (textBox1.Text == "Mr.Murphy")
            {
                point = point + 2;
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Please answer number 1");
                textBox1.Focus();
                return;
            }
            else
            {
                label4.Visible = true;
                point = point + 0;
            }

            if (radioButton2.Checked == true)
            {
                point = point + 2;
            }
            else if (radioButton1.Checked == true || radioButton3.Checked == true || radioButton4.Checked == true)
            {
                point = point + 0;
                label5.Visible = true;
            }
            else if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false)
            {
                MessageBox.Show("Please answer question number 2.");
                return;
            }

            if (checkBox2.Checked == true)
            {
                point = point + 2;
            }
            else if (checkBox1.Checked == true)
            {
                point = point + 0;
                label6.Visible = true;
            }
            else if (checkBox1.Checked == false && checkBox2.Checked == false)
            {
                MessageBox.Show("Please answer question number 3.");
                return;
            }


            
            if (textBox2.Text == "10")
            {
                point = point + 2;
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Please answer question number 4.");
                textBox2.Focus();
                return;
            }
            else
            {
                point = point + 0;
                label9.Visible = true;
            }

            
            if (textBox3.Text == "No" || textBox3.Text == "no")
            {
                point = point + 2;
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Please answer question number 5.");
                textBox3.Focus();
                return;
            }
            else
            {
                point = point + 0;
                label10.Visible = true;
            }

            
            label11.Text = String.Format("You got {0} points.", point);

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
