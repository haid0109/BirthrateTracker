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
    public partial class Bruger : Form
    {
        public Bruger()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        SqlConnection Con = new SqlConnection("Server = 10.0.5.111; Database = fødselsrate_2017; User Id = sa; Password = Passw0rd; ");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Close();
                Con.Open();
                SqlDataAdapter SqlDA = new SqlDataAdapter();

                if (comboBox1.SelectedIndex == 0) { SqlDA = new SqlDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Africa", Con); }
                if (comboBox1.SelectedIndex == 1) { SqlDA = new SqlDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Asien", Con); }
                if (comboBox1.SelectedIndex == 2) { SqlDA = new SqlDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Europa", Con); }
                if (comboBox1.SelectedIndex == 3) { SqlDA = new SqlDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Mellemamerika", Con); }
                if (comboBox1.SelectedIndex == 4) { SqlDA = new SqlDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Nordamerika", Con); }
                if (comboBox1.SelectedIndex == 5) { SqlDA = new SqlDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Oceanien", Con); }
                if (comboBox1.SelectedIndex == 6) { SqlDA = new SqlDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Sydamerika", Con); }

                DataTable DT = new DataTable();
                SqlDA.Fill(DT);
                dataGridView1.DataSource = DT;
                Con.Close();
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); }
        }
    }
}
