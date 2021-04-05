using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MediaBazaarSolution
{
    public partial class LoginNew : Form
    {
        MySqlConnection connection = new MySqlConnection("server=studmysql01.fhict.local;database=dbi400999;uid=dbi400999;password=Group6Project;");
        public LoginNew()
        {
            InitializeComponent();
        }

        private void LoginNew_Load(object sender, EventArgs e)
        {
           
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = $"select * from adminlogin where username = '{txt_Username.Text} ' AND password = '{txt_Password.Text}'";
            MySqlDataReader reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count++;
            }
           if (count == 1)
            {
                connection.Close();
                connection.Dispose();
                this.Hide();
                MainMenu mainMenu1 = new MainMenu(this);
                txt_Username.Clear();
                txt_Password.Clear();
                mainMenu1.Show();

            }
            else
            { MessageBox.Show("Incorrect username or password"); }


            connection.Close();

        }
    }
}
