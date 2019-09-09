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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            textBox2.PasswordChar = ('•');
        }

        private void button1_Click(object sender, EventArgs ex)
        {
                try
                {
                    SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=UsersDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    SqlCommand SqlCmd = new SqlCommand("select * from Users where Username = '" + textBox1.Text + "' and [Password]='" + textBox2.Text + "'", Con);
                    SqlDataAdapter SqlDA = new SqlDataAdapter(SqlCmd);
                    DataTable DT = new DataTable();
                    SqlDA.Fill(DT);
                    string cmbItemValue = comboBox1.SelectedItem.ToString();
                    if (DT.Rows.Count > 0)
                    {
                        for (int i = 0; i < DT.Rows.Count; i++)
                        {
                            if (DT.Rows[i]["usertype"].ToString() == cmbItemValue)
                            {
                                if (comboBox1.SelectedIndex == 0)
                                {
                                    Bruger f = new Bruger();
                                    f.Show();
                                    this.Hide();
                                }
                                else if (comboBox1.SelectedIndex == 1)
                                {
                                    Superbruger ff = new Superbruger();
                                    this.Hide();
                                    ff.Show();
                                }
                                else if (comboBox1.SelectedIndex == 2)
                                {
                                    Administrator fff = new Administrator();
                                    this.Hide();
                                    fff.Show();
                                }

                            }
                            break;
                        }
                    }
                    else
                    {
                    textBox1.Clear();
                    textBox2.Clear();
                    MessageBox.Show("                               Error \n    Login and/or Password were incorrect");
                    }
                }
                catch (Exception exc) { MessageBox.Show(exc.Message); }
        }
    }
}
