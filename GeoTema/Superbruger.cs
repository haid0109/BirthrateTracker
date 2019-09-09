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
    public partial class Superbruger : Form
    {
        public Superbruger()
        {
            InitializeComponent();
        }

        private void Superbruger_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        SqlConnection Con_fødselsrate_2017 = new SqlConnection("Server = 10.0.5.111; Database = fødselsrate_2017; User Id = sa; Password = Passw0rd; ");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Con_fødselsrate_2017.Close();
                Con_fødselsrate_2017.Open();
                SqlDataAdapter SqlDA = new SqlDataAdapter();

                if (comboBox1.SelectedIndex == 0) { SqlDA = new SqlDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Africa", Con_fødselsrate_2017); }
                if (comboBox1.SelectedIndex == 1) { SqlDA = new SqlDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Asien", Con_fødselsrate_2017); }
                if (comboBox1.SelectedIndex == 2) { SqlDA = new SqlDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Europa", Con_fødselsrate_2017); }
                if (comboBox1.SelectedIndex == 3) { SqlDA = new SqlDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Mellemamerika", Con_fødselsrate_2017); }
                if (comboBox1.SelectedIndex == 4) { SqlDA = new SqlDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Nordamerika", Con_fødselsrate_2017); }
                if (comboBox1.SelectedIndex == 5) { SqlDA = new SqlDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Oceanien", Con_fødselsrate_2017); }
                if (comboBox1.SelectedIndex == 6) { SqlDA = new SqlDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Sydamerika", Con_fødselsrate_2017); }

                DataTable DT = new DataTable();
                SqlDA.Fill(DT);
                dataGridView1.DataSource = DT;
                Con_fødselsrate_2017.Close();
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Con_fødselsrate_2017.Close();
                Con_fødselsrate_2017.Open();
                SqlCommand SqlCmd = new SqlCommand();

                if (comboBox1.SelectedIndex == 0) { SqlCmd = new SqlCommand("INSERT INTO Africa(Land, Fødselsrate) VALUES (@Land, @Fødselsrate);", Con_fødselsrate_2017); }
                if (comboBox1.SelectedIndex == 1) { SqlCmd = new SqlCommand("INSERT INTO Asien(Land, Fødselsrate) VALUES (@Land, @Fødselsrate);", Con_fødselsrate_2017); }
                if (comboBox1.SelectedIndex == 2) { SqlCmd = new SqlCommand("INSERT INTO Europa(Land, Fødselsrate) VALUES (@Land, @Fødselsrate);", Con_fødselsrate_2017); }
                if (comboBox1.SelectedIndex == 3) { SqlCmd = new SqlCommand("INSERT INTO Mellemamerika(Land, Fødselsrate) VALUES (@Land, @Fødselsrate);", Con_fødselsrate_2017); }
                if (comboBox1.SelectedIndex == 4) { SqlCmd = new SqlCommand("INSERT INTO Nordamerika(Land, Fødselsrate) VALUES (@Land, @Fødselsrate);", Con_fødselsrate_2017); }
                if (comboBox1.SelectedIndex == 5) { SqlCmd = new SqlCommand("INSERT INTO Oceanien(Land, Fødselsrate) VALUES (@Land, @Fødselsrate);", Con_fødselsrate_2017); }
                if (comboBox1.SelectedIndex == 6) { SqlCmd = new SqlCommand("INSERT INTO Sydamerika(Land, Fødselsrate) VALUES (@Land, @Fødselsrate);", Con_fødselsrate_2017); }

                SqlCmd.Parameters.Add("@Land", textBox1.Text);
                SqlCmd.Parameters.Add("@Fødselsrate", textBox2.Text);

                object obj = SqlCmd.ExecuteNonQuery();
                textBox1.Clear();
                textBox2.Clear();
                MessageBox.Show("Data has been submitted");
                Con_fødselsrate_2017.Close();
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); }
        }
    }
}
