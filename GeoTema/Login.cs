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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            textBox2.PasswordChar = ('•'); //makes the characters in the login password box into circles
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs ex)
        {
            try //tests the code for any errors
            {
                SQLiteConnection Con = new SQLiteConnection(@"Data Source=.\UsersDB.db;Version=3");
                SQLiteCommand SqlCmd = new SQLiteCommand("select * from Users where Username = '" + textBox1.Text + "' and [Password]='" + textBox2.Text + "'", Con); //selects all database entries that match the username and password entered
                SQLiteDataAdapter SqlDA = new SQLiteDataAdapter(SqlCmd);
                DataTable DT = new DataTable();
                SqlDA.Fill(DT); //fills the "DT" datatable with the data selected
                string cmbItemValue = comboBox1.SelectedItem.ToString(); //saves the usertype selected, from the usertype drop down menu, into "cmbItemValue"
                if (DT.Rows.Count > 0) //if there is data in the datatable, the code will run 
                {
                    for (int i = 0; i < DT.Rows.Count; i++) //scans through the rows in the datatable
                    {
                        if (DT.Rows[i]["usertype"].ToString() == cmbItemValue) //if the usertype selected is in the datatable, the code will run
                        {
                            if (comboBox1.SelectedIndex == 0) //if you selected the "Bruger" usertype, the "Bruger.cs" window will pop up, and the current window will be hidden
                            {
                                Bruger f = new Bruger();
                                f.Show();
                                this.Hide();
                            }
                            else if (comboBox1.SelectedIndex == 1) //if you selected the "Superbruger" usertype, the "Superbruger.cs" window will pop up, and the current window will be hidden
                        {
                                Superbruger ff = new Superbruger();
                                this.Hide();
                                ff.Show();
                            }
                            else if (comboBox1.SelectedIndex == 2) //if you selected the "Administrator" usertype, the "Administrator.cs" window will pop up, and the current window will be hidden
                        {
                                Administrator fff = new Administrator();
                                this.Hide();
                                fff.Show();
                            }
                        }
                        break; //breaks out of the current scope
                    }
                }
                else //clears the boxes and shows a general error message, if a non-detectable error(i.e. human error) occurs
                {
                textBox1.Clear();
                textBox2.Clear();
                MessageBox.Show("                               Error \n    Login and/or Password were incorrect");
                }
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); } //shows the error message if the code has any errors
        }
    }
}