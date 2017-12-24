using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private string conn;
        private MySqlConnection connect;
        public Form1()
        {
            InitializeComponent();
        }
        private void dbconnect()
        {
            try
            {
                conn = "Server=localhost;Database=teststeemit;Uid=root;Pwd=;";
                connect = new MySqlConnection(conn);
                connect.Open();
            }
            catch (MySqlException e)
            {
                throw;
            }
        }
        private bool checklogin(string user, string pass)
        {
            dbconnect();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from accounts where username=@user and password=@pass";
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            if (login.Read())
            {
                connect.Close();
                return true;
            }
            else
            {
                connect.Close();
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string user = username.Text;
            string pass = password.Text;
            if (user == "" || pass == "")
            {
                MessageBox.Show("Empty Fields Detected ! Please fill up all the fields");
                return;
            }
            bool r = checklogin(user, pass);
            if (r)
                MessageBox.Show("Correct Login Credentials");
            else
                MessageBox.Show("Incorrect Login Credentials");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You Are Closing!");
            Application.Exit();
        }
    }
}
