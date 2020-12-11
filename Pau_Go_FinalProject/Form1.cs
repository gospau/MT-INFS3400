using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Pau_Go_FinalProject
{
    public partial class Form1 : Form
    {
        private string filepath;
        private StreamWriter searchlog;
        public Form1()
        {
            InitializeComponent();
            filepath = "";
            searchlog = new StreamWriter("Pau_searchlog.cvs", true);
            searchlog.WriteLine("personSearch, keywordsSearch, fileName");
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
                MessageBox.Show("Select a file");
                return;
            }

            string cs = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};", filepath);
            OleDbConnection dbConn = new OleDbConnection(cs);
            dbConn.Open();

            OleDbCommand dbCmd = new OleDbCommand();
            dbCmd.CommandText = "SELECT * FROM MoviePlots";
            dbCmd.Connection = dbConn;

            OleDbDataReader dbReader = dbCmd.ExecuteReader();


            int count = 0;
            int max = int.MinValue;
            int maxy = 0;
            string maxt = "";
            string maxd = "";
            string maxa = "";
            string maxp = "";

            var movielist = new List<Movies>();
            var Listkey = new List<Movies>();
            var Listname = new List<Movies>();
            string logname="";
            int countlog = 0;

            string name = "";
            string key = "";

            string[] userNameInput = textBox1.Text.ToLower().Split(' ');
            string[] userKeyword = textBox2.Text.ToLower().Split(' ');

            countlog = textBox1.Text.Replace(" ", "").Count();
            countlog = countlog + textBox2.Text.Replace(" ", "").Count();

            if (textBox1.Text != "")
            {
                for (int i = 0; i < userNameInput.Length; i++)
                {
                    logname += userNameInput[i].ToLower().Substring(0, 1);
                    name += userNameInput[i];

                }
            }

            if (textBox2.Text != "")
            {
                for (int i = 0; i < userKeyword.Length; i++)
                {

                    logname += userKeyword[i].ToLower().Substring(0, 1);

                    key += userKeyword[i];

                }
            }

            while (dbReader.Read())
            {
                int ryear = dbReader.GetInt32(1);
                string title = dbReader["Title"].ToString();
                string director = dbReader["Director"].ToString();
                string actor = dbReader["Actors"].ToString();
                string genre = dbReader["Genre"].ToString();
                string plot = dbReader["Plot"].ToString();
                int total = 0;


                int directorpoint = 0;
                int actorpoint = 0;
                int matchDA = 0;

                int titlepoint = 0;
                int plotpoint = 0;
                int matchTP = 0;

                Movies m = new Movies(director, actor, plot, title, genre, ryear, total);

                if (textBox1.Text != "" && textBox2.Text == "")
                {
                    for (int i = 0; i < userNameInput.Length; i++)
                    {
                        

                        if (director.ToLower().Contains(userNameInput[i]))
                        {
                            directorpoint++;
                        }
                        if (actor.ToLower().Contains(userNameInput[i]))
                        {
                            actorpoint++;
                        }
                    }

                    total = directorpoint + actorpoint;
                    if( total > 0)
                    {
                        count++;
                        m.Total = total;
                        movielist.Add(m);

                    }

                }

                else if (textBox2.Text != "" && textBox1.Text == "")
                {
                    for (int i = 0; i < userKeyword.Length; i++)
                    {


                        if (title.ToLower().Contains(userKeyword[i]))
                        {
                            titlepoint++;
                        }
                        if (plot.ToLower().Contains(userKeyword[i]))
                        {
                            plotpoint++;
                        }
                    }

                    total = titlepoint + plotpoint;
                    if (total > 0)
                    {
                        count++;
                        m.Total = total;
                        movielist.Add(m);
                    }

                }
                else if (textBox1.Text != "" && textBox2.Text != "")
                {

                    for (int i = 0; i < userNameInput.Length; i++)
                    {

                        if (director.ToLower().Contains(userNameInput[i]))
                        {
                            directorpoint++;
                        }
                        if (actor.ToLower().Contains(userNameInput[i]))
                        {
                            actorpoint++;
                        }
                    }


                    for (int i = 0; i < userKeyword.Length; i++)
                    {


                        if (title.ToLower().Contains(userKeyword[i]))
                        {
                            titlepoint++;
                        }
                        if (plot.ToLower().Contains(userKeyword[i]))
                        {
                            plotpoint++;
                        }
                    }

                    total = directorpoint + actorpoint;
                    int total2 = titlepoint + plotpoint;
                    if (total > 0 && total2 > 0)
                    {
                        count++;
                        m.Total = total;
                        m.Total = total2;
                        movielist.Add(m);
                    }

                }
                else
                {
                    MessageBox.Show("Enter name or keyword");
                    return;
                }

            }
            dbReader.Close();
            dbConn.Close();



            richTextBox1.AppendText(String.Format("Found {0} matches\n", count));

            richTextBox1.AppendText(String.Format("The best result:\n"));
            
            for (int i = 0; i < movielist.Count; i++)
            {
                if (movielist[i].Total > max)
                {
                    max = movielist[i].Total;
                    maxy = movielist[i].Year;
                    maxt = movielist[i].Title;
                    maxd = movielist[i].Director;
                    maxa = movielist[i].Actors;
                    maxp = movielist[i].Plot.Substring(0, 25);
                }
            }

            richTextBox1.AppendText(String.Format("{0}, {1}, {2}, {3}, {4}, {5}\n\n", max, maxy, maxt, maxd, maxa, maxp));

            for (int i = 0; i < movielist.Count; i++)
            {
                richTextBox1.AppendText(String.Format("{0}, {1}, {2}, {3}, {4}, {5}\n", movielist[i].Total, movielist[i].Year, movielist[i].Title, movielist[i].Director, movielist[i].Actors, movielist[i].Plot.Substring(0, 25)));
            }


            StreamWriter logfile = new StreamWriter(String.Format("Pau_{0}_{1}.cvs", logname, countlog), true);


            searchlog.WriteLine("{0}, {1}, Pau_{2}_{3}", name, key, logname, countlog);

            logfile.WriteLine("Score,ReleaseYear,Title,Director,Actors,Summary\n");

            for (int i = 0; i < movielist.Count; i++)
            {
                logfile.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", movielist[i].Total, movielist[i].Year, movielist[i].Title, movielist[i].Director, movielist[i].Actors, movielist[i].Plot.Substring(0, 25));
            }


            logfile.Close();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            textBox1.Clear();
            textBox2.Clear();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            searchlog.Close();
        }
    }
}
