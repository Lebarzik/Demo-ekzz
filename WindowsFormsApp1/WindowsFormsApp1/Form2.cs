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

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=База данных1.accdb");
        string id_partner;
    
        public Form2(string ID_partner)
        {
            InitializeComponent();
            id_partner = ID_partner;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand($"select * FROM Partner_import WHERE ID_partner = {id_partner} ", conn);
            var reader = cmd.ExecuteReader();     
            while (reader.Read())
            {
                textBox1.Text = reader["Partner_type"].ToString();
                textBox2.Text = reader["Name_partner"].ToString();
                textBox3.Text = reader["Director"].ToString();
                textBox4.Text = reader["EMAIL"].ToString();
                textBox5.Text = reader["Phone_partner"].ToString();
                textBox6.Text = reader["Adres_partner"].ToString();
                textBox7.Text = reader["INN"].ToString();
                textBox8.Text = reader["Reiting"].ToString();
            }
            conn.Close();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand com = new OleDbCommand($"Update Partner_import set Partner_type = '{textBox1.Text}', Name_partner= '{textBox2.Text}', Director = '{textBox3.Text}', EMAIL = '{textBox4.Text}', Phone_partner= '{textBox5.Text}', Adres_partner = '{textBox6.Text}', INN = '{textBox7.Text}', Reiting = {textBox8.Text}  where ID_partner = {id_partner}  ", conn);
            com.ExecuteNonQuery();
            conn.Close();
            Hide();
            Form1 a = new Form1();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 a = new Form1();
            a.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
