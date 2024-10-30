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
    public partial class Form3 : Form
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=База данных1.accdb");
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string prtype = textBox1.Text;
            string nm = textBox2.Text;
            string dr = textBox3.Text;
            string email = textBox4.Text;
            string ph = textBox5.Text;
            string adr = textBox6.Text;
            string inn = textBox7.Text;
            string ret = textBox8.Text;
            try
            {
                conn.Open();
                OleDbCommand com = new OleDbCommand("INSERT INTO Partner_import (Partner_type, Name_partner, Director, EMAIL, Phone_partner, Adres_partner, INN, Reiting) VALUES (?, ?, ?, ?, ?, ?, ?, ?)", conn);

                com.Parameters.AddWithValue("?", prtype);
                com.Parameters.AddWithValue("?", nm);
                com.Parameters.AddWithValue("?", dr);
                com.Parameters.AddWithValue("?", email);
                com.Parameters.AddWithValue("?", ph);
                com.Parameters.AddWithValue("?", adr);
                com.Parameters.AddWithValue("?", inn);
                com.Parameters.AddWithValue("?", ret);

                int rowsAffected = com.ExecuteNonQuery();

                if (rowsAffected != 1)
                {
                    MessageBox.Show("Произошла ошибка!", "Внимание!");
                }
                else
                {
                    MessageBox.Show("Данные были добавлены!");
                    Hide();
                    Form1 a = new Form1();
                    a.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 a = new Form1();
            a.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
