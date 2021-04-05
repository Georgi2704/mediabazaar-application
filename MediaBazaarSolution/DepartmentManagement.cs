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
    public partial class DepartmentManagement : Form
    {
        MainMenu mainMenu;
        MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;database=dbi400999;uid=dbi400999;password=Group6Project;");
        List<Product> allProducts = new List<Product>();
        List<Statistics> allEmployees = new List<Statistics>();
        List<Department> allDepartments = new List<Department>();
        public DepartmentManagement(MainMenu mainMenu)
        {
            this.mainMenu = mainMenu;
            InitializeComponent();

        }

        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            string lastDepartment = allDepartments[allDepartments.Count - 1].Name;
            string newDepartment = tbDepartmentName.Text;

            foreach (var department in allDepartments)
            {
                if (department.Name == newDepartment)
                {
                    MessageBox.Show("A department with this name already exists");
                    return;
                }
            }

            MySqlConnection connection;
            string connectionString;
            connectionString = "Server=studmysql01.fhict.local;Uid=dbi400999;Database=dbi400999;Pwd=Group6Project;";
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    MessageBox.Show("Department created succesfully.");
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO department (departmentName) VALUES (@departmentName)", connection);
                    cmd.Parameters.AddWithValue("@departmentName", Convert.ToString(tbDepartmentName.Text));
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Failed");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            connection.Close();

            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand($"ALTER TABLE `morningshifts` ADD `{newDepartment}` VARCHAR(30) NULL AFTER `{lastDepartment}`;", connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();

            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand($"ALTER TABLE `afternoonshifts` ADD `{newDepartment}` VARCHAR(30) NULL AFTER `{lastDepartment}`;", connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();

            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand($"ALTER TABLE `eveningshifts` ADD `{newDepartment}` VARCHAR(30) NULL AFTER `{lastDepartment}`;", connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();



            LoadDepartments();
            RefreshListBox();
        }

        private void RefreshListBox()
        {
            lbCurrentDep.Items.Clear();
            for (int i = 0; i < allDepartments.Count; i++)
            {
                lbCurrentDep.Items.Add(allDepartments[i].Name);
            }
        }

        private void LoadEmployees()
        {
            allEmployees.Clear();
            string sql = "SELECT employeeID, firstName, lastName, position, departmentName FROM employee;";
            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                allEmployees.Add(new Statistics(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString()));
            }
            conn.Close();
        }

        private void LoadProducts()
        {
            allProducts.Clear();
            string sql = "SELECT productID, productName, numberInStock, Price, departmentName, restocks FROM product;";
            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                allProducts.Add(new Product(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToInt32(dr[2]), Convert.ToDouble(dr[3]), dr[4].ToString(), Convert.ToInt32(dr[5])));
            }
            conn.Close();
        }

        private void LoadDepartments()
        {
            allDepartments.Clear();
            string sql = "SELECT departmentID, departmentName FROM department;";
            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                allDepartments.Add(new Department(Convert.ToInt32(dr[0]),dr[1].ToString()));
            }
            conn.Close();
        }

        private void DepartmentManagement_Load(object sender, EventArgs e)
        {
            LoadDepartments();
            RefreshListBox();
            LoadProducts();
            LoadEmployees();
        }

        private void btnRemoveDep_Click(object sender, EventArgs e)
        {

            if (lbCurrentDep.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a department first");
                return;
            }

            string selectedDepartment = lbCurrentDep.SelectedItem.ToString();

            if (MessageBox.Show("Are you sure you want to remove this department ?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            if (lvEmployees_Dep.Items.Count > 0 || lvProducts_Dep.Items.Count > 0)
            {
                MessageBox.Show("Can't remove department: There are still products or employees in this department");
                return;
            }
            string sql = $"DELETE FROM department WHERE departmentName='{selectedDepartment}';";
            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            conn.Open();
            int effectedRows = cmd.ExecuteNonQuery();
            conn.Close();

            MySqlConnection connection;
            string connectionString;
            connectionString = "Server=studmysql01.fhict.local;Uid=dbi400999;Database=dbi400999;Pwd=Group6Project;";
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    MySqlCommand cdm = new MySqlCommand($"ALTER TABLE `morningshifts` DROP `{selectedDepartment}`;", connection);
                    cdm.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();

            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    MySqlCommand cdm = new MySqlCommand($"ALTER TABLE `afternoonshifts` DROP `{selectedDepartment}`;", connection);
                    cdm.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();

            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    MySqlCommand cdm = new MySqlCommand($"ALTER TABLE `eveningshifts` DROP `{selectedDepartment}`;", connection);
                    cdm.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();

            MessageBox.Show($"Department '{selectedDepartment}' removed"); //dont forget to do this!

            LoadDepartments();
            RefreshListBox();
        }

        private void RefreshProducts()
        {
            lvProducts_Dep.Items.Clear();
            string departmentName;
            if (lbCurrentDep.SelectedIndex == -1)
            {
                lbCurrentDep.SelectedIndex = 0;
                departmentName = lbCurrentDep.SelectedItem.ToString();
            }
            else
            {
                departmentName = lbCurrentDep.SelectedItem.ToString();
            }
            for (int i = 0; i < allProducts.Count; i++)
            {
                if (allProducts[i].DepartmentName == departmentName)
                {
                    string[] row = allProducts[i].GetDetails();
                    lvProducts_Dep.Items.Add(allProducts[i].Name.ToString()).SubItems.AddRange(row);
                }
            }
        }

        private void RefreshEmployees()
        {
            lvEmployees_Dep.Items.Clear();
            string departmentName;
            if (lbCurrentDep.SelectedIndex == -1)
            {
                lbCurrentDep.SelectedIndex = 0;
                departmentName = lbCurrentDep.SelectedItem.ToString();
            }
            else
            {
                departmentName = lbCurrentDep.SelectedItem.ToString();
            }
            for (int i = 0; i < allEmployees.Count; i++)
            {
                if (allEmployees[i].department == departmentName)
                {
                    string[] row = allEmployees[i].GetDetail();
                    lvEmployees_Dep.Items.Add($"{allEmployees[i].firstName} {allEmployees[i].lastName}").SubItems.AddRange(row);
                }
            }
        }

        private void lbCurrentDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCurrentDep.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a department");
                return;
            }
            RefreshProducts();
            RefreshEmployees();
        }

        private void DepartmentManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainMenu.Show();
        }
    }
}
