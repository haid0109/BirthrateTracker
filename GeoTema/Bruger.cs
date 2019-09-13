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

        SQLiteConnection Con = new SQLiteConnection(@"Data Source=.\fødselsrate_2017.db;Version=3");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Close(); //closes the connection to the database(for some reason, a non-skippable error occurs when i generate two consecutive errors, and the only fix i could find, is to close the connection before opening it)
                Con.Open(); //opens the connection to the database
                SQLiteDataAdapter SqlDA = new SQLiteDataAdapter();

                if (comboBox1.SelectedIndex == 0) { SqlDA = new SQLiteDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Africa", Con); } //if you selected "Africa" in the drop down menu, then all the entries in the "Africa" table will be selected, and ranked by descending birthrates
                if (comboBox1.SelectedIndex == 1) { SqlDA = new SQLiteDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Asien", Con); }
                if (comboBox1.SelectedIndex == 2) { SqlDA = new SQLiteDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Europa", Con); }
                if (comboBox1.SelectedIndex == 3) { SqlDA = new SQLiteDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Mellemamerika", Con); }
                if (comboBox1.SelectedIndex == 4) { SqlDA = new SQLiteDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Nordamerika", Con); }
                if (comboBox1.SelectedIndex == 5) { SqlDA = new SQLiteDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Oceanien", Con); }
                if (comboBox1.SelectedIndex == 6) { SqlDA = new SQLiteDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Sydamerika", Con); }

                DataTable DT = new DataTable(); 
                SqlDA.Fill(DT);
                dataGridView1.DataSource = DT; //shows the data in the "DT" datatable
                Con.Close();
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); }
        }
    }
}