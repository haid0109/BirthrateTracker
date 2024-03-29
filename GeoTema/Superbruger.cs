﻿using System;
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

        SQLiteConnection Con_fødselsrate_2017 = new SQLiteConnection(@"Data Source=.\fødselsrate_2017.db;Version=3");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Con_fødselsrate_2017.Close();
                Con_fødselsrate_2017.Open();
                SQLiteDataAdapter SqlDA = new SQLiteDataAdapter();

                if (comboBox1.SelectedIndex == 0) { SqlDA = new SQLiteDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Africa", Con_fødselsrate_2017); }
                if (comboBox1.SelectedIndex == 1) { SqlDA = new SQLiteDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Asien", Con_fødselsrate_2017); }
                if (comboBox1.SelectedIndex == 2) { SqlDA = new SQLiteDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Europa", Con_fødselsrate_2017); }
                if (comboBox1.SelectedIndex == 3) { SqlDA = new SQLiteDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Mellemamerika", Con_fødselsrate_2017); }
                if (comboBox1.SelectedIndex == 4) { SqlDA = new SQLiteDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Nordamerika", Con_fødselsrate_2017); }
                if (comboBox1.SelectedIndex == 5) { SqlDA = new SQLiteDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Oceanien", Con_fødselsrate_2017); }
                if (comboBox1.SelectedIndex == 6) { SqlDA = new SQLiteDataAdapter("SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Sydamerika", Con_fødselsrate_2017); }

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
                SQLiteCommand SqlCmd = new SQLiteCommand();

                if (comboBox1.SelectedIndex == 0) { SqlCmd = new SQLiteCommand("INSERT INTO Africa(Land, Fødselsrate) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "');", Con_fødselsrate_2017); } //if you selected "Africa" in the drop down menu, then an insert query without values, will be saved in "SqlCmd"
                if (comboBox1.SelectedIndex == 1) { SqlCmd = new SQLiteCommand("INSERT INTO Asien(Land, Fødselsrate) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "');", Con_fødselsrate_2017); }
                if (comboBox1.SelectedIndex == 2) { SqlCmd = new SQLiteCommand("INSERT INTO Europa(Land, Fødselsrate) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "');", Con_fødselsrate_2017); }
                if (comboBox1.SelectedIndex == 3) { SqlCmd = new SQLiteCommand("INSERT INTO Mellemamerika(Land, Fødselsrate) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "');", Con_fødselsrate_2017); }
                if (comboBox1.SelectedIndex == 4) { SqlCmd = new SQLiteCommand("INSERT INTO Nordamerika(Land, Fødselsrate) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "');", Con_fødselsrate_2017); }
                if (comboBox1.SelectedIndex == 5) { SqlCmd = new SQLiteCommand("INSERT INTO Oceanien(Land, Fødselsrate) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "');", Con_fødselsrate_2017); }
                if (comboBox1.SelectedIndex == 6) { SqlCmd = new SQLiteCommand("INSERT INTO Sydamerika(Land, Fødselsrate) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "');", Con_fødselsrate_2017); }

                object obj = SqlCmd.ExecuteNonQuery(); //executes the query
                textBox1.Clear(); //clears the "Land" text box 
                textBox2.Clear();
                MessageBox.Show("Data has been submitted"); //gives a confirmation that the data has been submitted
                Con_fødselsrate_2017.Close();
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); }
        }
    }
}