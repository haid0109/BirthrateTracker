using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

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

        SQLiteConnection Con_UsersDB = new SQLiteConnection(@"Data Source=.\UsersDB.db;Version=3");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Con_UsersDB.Close();
                Con_UsersDB.Open();
                SQLiteDataAdapter SqlDA = new SQLiteDataAdapter();

                if (comboBox1.SelectedIndex == 0) { SqlDA = new SQLiteDataAdapter("SELECT * FROM Users WHERE Usertype = 'Bruger' ORDER BY Username ASC", Con_UsersDB); } //if you selected "Bruger" in the usertype drop down menu, then all users with the usertype "Bruger" will be selected and ordered by ascending usernames
                if (comboBox1.SelectedIndex == 1) { SqlDA = new SQLiteDataAdapter("SELECT * FROM Users WHERE Usertype = 'Superbruger' ORDER BY Username ASC", Con_UsersDB); }
                if (comboBox1.SelectedIndex == 2) { SqlDA = new SQLiteDataAdapter("SELECT * FROM Users WHERE Usertype = 'Administrator' ORDER BY Username ASC", Con_UsersDB); }

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
                SQLiteCommand SqlCmd = new SQLiteCommand();

                if (comboBox1.SelectedIndex == 0) { SqlCmd = new SQLiteCommand("INSERT INTO Users(Username, [Password], Usertype) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', 'Bruger');", Con_UsersDB); } //if you selected "Bruger" in the usertype drop down menu, then an insert query without values, will be saved in "SqlCmd"
                if (comboBox1.SelectedIndex == 1) { SqlCmd = new SQLiteCommand("INSERT INTO Users(Username, [Password], Usertype) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', 'Superbruger');", Con_UsersDB); }
                if (comboBox1.SelectedIndex == 2) { SqlCmd = new SQLiteCommand("INSERT INTO Users(Username, [Password], Usertype) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', 'Administrator');", Con_UsersDB); }

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
                SQLiteCommand SqlCmd = new SQLiteCommand();

                SqlCmd = new SQLiteCommand("UPDATE Users SET [Password] = '" + textBox4.Text + "' WHERE Username = '" + textBox3.Text + "';", Con_UsersDB); //scans through the database and updates the password that matches with the username inputted

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