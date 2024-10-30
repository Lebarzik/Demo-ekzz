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
    public partial class Form1 : Form
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=База данных1.accdb");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            conn.Open();
            string sql = "SELECT * FROM Partner_importZ ";
            OleDbCommand com = new OleDbCommand(sql, conn);
            OleDbDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                string ID_partner = reader["ID_partner"].ToString();
                Panel panel = new Panel();
                panel.Size = new Size(770, 100);
                panel.BackColor = Color.FromArgb(244, 232, 211);
                panel.Top = 5;
                string type__partner = reader["Partner_type"].ToString();
                string name__partner = reader["Name_partner"].ToString();
                Label label1 = new Label();
                label1.Text = type__partner + " | " + name__partner;
                label1.Location = new Point(5, 5);
                label1.AutoSize = true;
                Label label2 = new Label();
                label2.Text = reader["Director"].ToString();
                label2.Location = new Point(5, 25);
                label2.AutoSize = true;
                Label label3 = new Label();
                label3.Text = reader["Phone_partner"].ToString();
                label3.Location = new Point(5, 47);
                label3.AutoSize = true;
                Label label4 = new Label();
                label4.Text = "Рейтинг: " + reader["Reiting"].ToString();
                label4.Location = new Point(5, 67);
                label4.AutoSize = true;
                Label label5 = new Label();     
                label5.Text = reader["Kolich_product"].ToString();
                label5.Location = new Point(650, 5);
                label5.AutoSize = true;
                label5.Visible = false;
                Label label6 = new Label();
                label6.Location = new Point(690, 5);
                label6.AutoSize = true;
                int sum = Convert.ToInt32(label5.Text);
                if (sum <= 10000)
                {
                    label6.Text = "0%";
                }
                else if (sum > 10000 && sum <= 50000)
                {
                    label6.Text = "5%";
                }
                else if (sum > 50000 && sum <= 300000)
                {
                    label6.Text = "10%";
                }
                else if (sum > 300000)
                {
                    label6.Text = "15%";
                }
                flowLayoutPanel1.Controls.Add(panel);
                panel.Controls.Add(label6);
                panel.Controls.Add(label5);
                panel.Controls.Add(label4);
                panel.Controls.Add(label3);
                panel.Controls.Add(label1);
                panel.Controls.Add(label2);
                panel.Click += (senderd, ex) =>
                {
                    Form2 a = new Form2(ID_partner);
                    a.Show();
                    Hide();
                };
            }
            conn.Close();
        }

        private void LoadData()
        {
           
        }
       
        public void panel_Click(object sender, EventArgs e)
        {
            
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
             MessageBox.Show("Вы уверены что хотите выйти из приложения?", "Закрытие", MessageBoxButtons.YesNo);
            Application.Exit();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Form3 a = new Form3();
            a.Show();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
