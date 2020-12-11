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

namespace Pau_Go_PA4
{
    public partial class Form1 : Form
    {
        private string filepath;
        public Form1()
        {
            InitializeComponent();
            filepath = "";
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                filepath = openFileDialog1.FileName;
            }
            else
            {
                filepath = "";
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (filepath == "")
            {
                MessageBox.Show("Select a file first");
                return;
            }

            int countCaramel = 0;

            using (var sr = new StreamReader(filepath))
            {
                while (sr.EndOfStream != true)
                {
                    string line = sr.ReadLine();

                    if (line.StartsWith("competitorname"))
                    {
                        continue;
                    }

                    string[] data = line.Split(',');

                    string caramel;
                    try
                    {
                        caramel = data[3];
                    }
                    catch
                    {
                        MessageBox.Show("Please select the correct file");
                        return;
                    }


                    if (caramel == "1")
                    {
                        countCaramel++;
                    }
                }
            }

            richTextBox1.Text = String.Format("Counted {0} candies with caramel\n\n", countCaramel);


        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (filepath == "")
            {
                MessageBox.Show("Select a file first");
                return;
            }

            List<string> fruityList = new List<string>();
            var sugarper = new List<double>();

            using (var sr = new StreamReader(filepath))
            {
                while (sr.EndOfStream != true)
                {
                    string line = sr.ReadLine();

                    if (line.StartsWith("competitorname"))
                    {
                        continue;
                    }

                    string[] data = line.Split(',');

                    string name = data[0];

                    string fruity;
                    try
                    {
                        fruity = data[2];
                    }
                    catch
                    {
                        MessageBox.Show("That is the wrong file");
                        return;
                    }

                    double sugar = double.Parse(data[10]);
                    if (fruity == "1" && sugar > .5)
                    {
                        fruityList.Add(name);
                        sugarper.Add(sugar);
                    }
                }
            }


            richTextBox1.AppendText(String.Format("Fruity sweet candies:\n"));

            for (int i = 0; i < fruityList.Count; i++)
            {

                richTextBox1.AppendText(String.Format("{0} - {1:F}\n", fruityList[i], sugarper[i]));

            }
            richTextBox1.AppendText(String.Format("\n"));
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (filepath == "")
            {
                MessageBox.Show("Select a file first");
                return;
            }

            int counthard = 0;
            var sugarpert = new List<double>();

            using (var sr = new StreamReader(filepath))
            {
                while (sr.EndOfStream != true)
                {
                    string line = sr.ReadLine();

                    if (line.StartsWith("competitorname"))
                    {
                        continue;
                    }

                    string[] data = line.Split(',');

                    string hard;
                    try
                    {
                        hard = data[7];
                    }
                    catch
                    {
                        MessageBox.Show("Wrong File!");
                        return;
                    }

                    double hardp = double.Parse(data[10]);

                    if (hard == "1")
                    {
                        counthard++;
                        sugarpert.Add(hardp);
                    }
                }
            }

            double total = sugarpert.Sum() / counthard;

            richTextBox1.AppendText(String.Format("Average sugar % in hard candies: {0:F}\n\n", total));

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (filepath == "")
            {
                MessageBox.Show("Select a file first");
                return;
            }

            double maxwin = double.MinValue;
            string maxwinN = "";

            using (var sr = new StreamReader(filepath))
            {
                while (sr.EndOfStream != true)
                {
                    string line = sr.ReadLine();

                    if (line.StartsWith("competitorname"))
                    {
                        continue;
                    }

                    string[] data = line.Split(',');


                    string name = data[0];

                    string crw;
                    try
                    {
                        crw = data[6];
                    }
                    catch
                    {
                        MessageBox.Show("Wrong File!");
                        return;
                    }

                    double win = double.Parse(data[12]);

                    if (crw == "1" && maxwin < win)
                    {
                        maxwin = win;
                        maxwinN = name;
                    }



                }
            }
            richTextBox1.AppendText(String.Format("{0} is the wafer with highest win percentae of {1:F}\n\n", maxwinN, maxwin));


        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (filepath == "")
            {
                MessageBox.Show("Select a file first");
                return;
            }

            double maxratio = 0;
            string maxname = "";

            using (var sr = new StreamReader(filepath))
            {
                while (sr.EndOfStream != true)
                {
                    string line = sr.ReadLine();

                    if (line.StartsWith("competitorname"))
                    {
                        continue;
                    }

                    string[] data = line.Split(',');


                    string name = data[0];

                    double priceper;
                    try
                    {
                        priceper = double.Parse(data[11]);
                    }
                    catch
                    {
                        MessageBox.Show("WRONG File!");
                        return;
                    }

                    double winper = double.Parse(data[12]);

                    double total = winper / priceper;
                    if (total > maxratio)
                    {
                        maxratio = total;
                        maxname = name;

                    }


                }

                richTextBox1.AppendText(String.Format("Candy with hightest Win/Price ratio:\n"));
                richTextBox1.AppendText(String.Format("> {0:F}, {1}\n\n", maxratio, maxname));
            }
        }
    }
}
