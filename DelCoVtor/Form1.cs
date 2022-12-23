using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelCoVtor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();

            f2.Show();
            this.Visible = false;
           
            //this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("-Marcellino Lumban Gaol 11420039 :D\n" +
                "-Srinesia C Sitorus 11420084\n" +
                "-Sophia Tambunan 11320048\n" +
                "-Marchellya Luga 11320045\n" +
                "HI Kami Dari Kelompok DelCoVtor ^_^");
        }
    }
}
