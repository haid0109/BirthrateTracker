using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GeoTema
{
    public partial class BrugerIndstillinger : Form
    {
        public BrugerIndstillinger()
        {
            InitializeComponent();
        }

        private void BrugerIndstillinger_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        SqlConnection Con_UsersDB = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\UsersDB.mdf;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Con_UsersDB.Close();
                Con_UsersDB.Open();
                SqlDataAdapter SqlDA = new SqlDataAdapter();

                SqlDA = new SqlDataAdapter("SELECT * FROM Users ORDER BY Usertype ASC, Username Asc", Con_UsersDB);

                DataTable DT = new DataTable();
                SqlDA.Fill(DT);
                dataGridView1.DataSource = DT;
                Con_UsersDB.Close();
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Con_UsersDB.Close();
                Con_UsersDB.Open();
                SqlCommand SqlCmd = new SqlCommand();

                if (comboBox1.SelectedIndex == 0) { SqlCmd = new SqlCommand("INSERT INTO Users(Username, [Password], Usertype) VALUES(@Username, @Password, 'Bruger');", Con_UsersDB); }
                if (comboBox1.SelectedIndex == 1) { SqlCmd = new SqlCommand("INSERT INTO Users(Username, [Password], Usertype) VALUES(@Username, @Password, 'Superbruger');", Con_UsersDB); }
                if (comboBox1.SelectedIndex == 2) { SqlCmd = new SqlCommand("INSERT INTO Users(Username, [Password], Usertype) VALUES(@Username, @Password, 'Administrator');", Con_UsersDB); }

                SqlCmd.Parameters.Add("@Username", textBox1.Text);
                SqlCmd.Parameters.Add("@Password", textBox2.Text);

                object obj = SqlCmd.ExecuteNonQuery();
                textBox1.Clear();
                textBox2.Clear();
                MessageBox.Show("Data has been submitted");
                Con_UsersDB.Close();
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Con_UsersDB.Close();
                Con_UsersDB.Open();
                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd = new SqlCommand("UPDATE Users SET [Password] = @NewPassword WHERE Username = @Username;", Con_UsersDB);

                SqlCmd.Parameters.Add("@Username", textBox3.Text);
                SqlCmd.Parameters.Add("@NewPassword", textBox4.Text);

                object obj = SqlCmd.ExecuteNonQuery();
                textBox1.Clear();
                textBox2.Clear();
                MessageBox.Show("Data has been submitted");
                Con_UsersDB.Close();
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); }
        }
    }
}
