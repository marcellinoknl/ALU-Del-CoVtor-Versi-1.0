using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelCoVtor
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Form f1 = new Form();
            f1.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();


        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "txt files (*.txt)|*.txt|All Files (*.*)|*.*";
                textBox1.Text = openFileDialog1.FileName;
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName, Encoding.UTF8);
            }
            catch
            {
                MessageBox.Show("File was invalid to read!");
            }
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                openFileDialog2.Filter = "txt files (*.txt)|*.txt|All Files (*.*)|*.*";
                textBox2.Text = openFileDialog2.FileName;
                richTextBox2.Text = File.ReadAllText(openFileDialog2.FileName, Encoding.UTF8);
            }
            catch
            {
                MessageBox.Show("File was invalid to read!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int DaymaxPoint = int.Parse(numericUpDown1.Text);
                if (DaymaxPoint < 0)
                {
                    throw new Exception("Inputan Hari Tidak Boleh negatif!");
                }
                string[] daerahList = richTextBox1.Text.Split('\n');
                Dictionary<string, DaerahInfected> map = new Dictionary<string, DaerahInfected>();
                int i = 0;
                string[] tempStruct = daerahList[i++].Split(' ');
                string rootNode = tempStruct[1]; 
                StrukturGrafDaerahInfected graf = new StrukturGrafDaerahInfected();                  int pls = int.Parse(tempStruct[0]);
                while (pls-- >= 1)
                {
                    string[] line = daerahList[i++].Split(' ');
                    map[line[0]] = new DaerahInfected(line[0], int.Parse(line[1]));
                    graf.MSAGLGraph.AddNode(new Node(line[0]));
                }
                daerahList = richTextBox2.Text.Split('\n');
                i = 0;
                pls = int.Parse(daerahList[i++]);
                while (pls-- >= 1)
                {
                    string[] line = daerahList[i++].Split(' ');
                    graf.AddEdge(map[line[0]], map[line[1]], double.Parse(line[2]));
                }
                graf.DataQuery(map[rootNode], DaymaxPoint);
                SetGraph(graf);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Inputan tidak valid!\n" + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            textBox1.Clear();
            textBox2.Clear();
            numericUpDown1.ResetText();
        }
        private void SetGraph(StrukturGrafDaerahInfected g)
        {
            GViewer viewer = new GViewer();
            viewer.Graph = g.MSAGLGraph;
            panel1.SuspendLayout();
            viewer.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(viewer);
            panel1.ResumeLayout();
        }
    }
    }

    

