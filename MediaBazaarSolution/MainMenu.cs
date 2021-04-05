using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaarSolution
{
    public partial class MainMenu : Form
    {
        LoginNew login;
        public MainMenu(LoginNew login)
        {
            this.login = login;
            InitializeComponent();
        }

        private void btnEmployeeManage_Click(object sender, EventArgs e)
        {
            EmployeeManagement employeeManagement = new EmployeeManagement(this);
            employeeManagement.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stocks stocks = new Stocks(this);
            stocks.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DepartmentManagement departmentManagement = new DepartmentManagement(this);
            departmentManagement.Show();
            this.Hide();
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            login.Show();
        }
    }
}
