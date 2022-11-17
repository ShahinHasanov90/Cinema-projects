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
using System.Data.OleDb;

namespace Cinema_projects
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection bagla = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\SHAKHAE\Documents\FILMLER.accdb");
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        void films()
        {
            OleDbDataAdapter db = new OleDbDataAdapter("Select * from TBL_FILMLER", bagla);
            DataTable dt = new DataTable();
            db.Fill(dt);
            dataGridView1.DataSource = dt;
            

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            films();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            bagla.Open();
            OleDbCommand kt1 = new OleDbCommand("Insert into TBL_FILMLER (AD,KATOGORI,LINK) VALUES (@p1,@p2,@p3)", bagla);
            kt1.Parameters.AddWithValue("@p1", txtname.Text);
            kt1.Parameters.AddWithValue("@p2", txtcatog.Text);
            kt1.Parameters.AddWithValue("@p3", txtlink.Text);
            kt1.ExecuteNonQuery();
            bagla.Close();
            MessageBox.Show("Lucky is add new film(*_*)");
            films();
                
         }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string link = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            webBrowser1.Navigate(link);
        }

        private void btnabouts_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This project was coded by Shahin Hassan on November 9th.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void color()

        {
            int r, g, b;
            Random rd = new Random();
            r = rd.Next(250);
            g = rd.Next(250);
            b = rd.Next(250);
            this.BackColor = Color.FromArgb(r, g, b);


        }
        private void btnchanged_Click(object sender, EventArgs e)
        {
            color();
        }
       
        private void btnfullsc_Click(object sender, EventArgs e)
        {
            groupBox3.Dock = DockStyle.Fill;
            groupBox4.Hide();




        }

        public void webBrowser1_DockChanged(object sender, EventArgs e)
        {

        }

        public void webBrowser1_Move(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            groupBox3.Size =this.Size;
        }
    }
}
