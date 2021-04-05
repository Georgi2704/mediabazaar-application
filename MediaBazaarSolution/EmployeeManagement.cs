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
using System.Threading;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;
using System.Text.RegularExpressions;

namespace MediaBazaarSolution
{
    
    public partial class EmployeeManagement : Form
    {
        MainMenu mainMenu;
        MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;database=dbi400999;uid=dbi400999;password=Group6Project;");
        List<Statistics> stats = new List<Statistics>(); // this is is the list only with position "Employee"
        List<Statistics> allEmployees = new List<Statistics>(); //this is the list with all the people in the shop
        private string currentUser;//currently selected user from the lvAllEmployees (Edit Info Tab)
        private CurrentWorkerInfo currentWorkerInfo; //currently selected user from the lvAllEmployees (Edit Info Tab)

        
        public EmployeeManagement(MainMenu mainMenu)
        {
            this.mainMenu = mainMenu;
            InitializeComponent();
            this.MinimumSize = new Size(400, 300);
            // Initialize required object
        }

        void LoadStats()
        {
            stats.Clear();
            lvStats.Items.Clear();
            lbEmployees_Shifts.Items.Clear();
            for (int i = 0; i < allEmployees.Count; i++)
            {
                if (allEmployees[i].position == "Employee")
                {
                    stats.Add(new Statistics(allEmployees[i].id, allEmployees[i].firstName, allEmployees[i].lastName, allEmployees[i].position, allEmployees[i].department));
                }
            }
            for (int i = 0; i < stats.Count; i++)
            {
                string[] row = stats[i].GetDetails();
                lvStats.Items.Add($"{stats[i].firstName} {stats[i].lastName}").SubItems.AddRange(row);
                lbEmployees_Shifts.Items.Add($"{stats[i].firstName} {stats[i].lastName}");
                lbEmployees_Shifts.SelectedIndex = 0;
            }
        }
        void LoadAllEmployees()
        {
            lvAllEmployees.Items.Clear();
            allEmployees.Clear();
            string sql = "SELECT employeeID, firstName, lastName, position, departmentName FROM employee;";
            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                allEmployees.Add(new Statistics(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString()));
            }
            for (int i = 0; i < allEmployees.Count; i++)
            {
                string[] row = allEmployees[i].GetDetails();
                    lvAllEmployees.Items.Add(allEmployees[i].firstName.ToString()).SubItems.AddRange(row); 
                //lvStats.Items.Add(stats[i].id.ToString()).SubItems.AddRange(row);
            }
            conn.Close();
        }

        List<string> GetUsernames()
        {
            List<string> usernames = new List<string>();
            var connectionString = "Server=studmysql01.fhict.local;Uid=dbi400999;Database=dbi400999;Pwd=Group6Project;";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT username FROM employee";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            //cbxInsDepartment.Items.Add(reader.GetString("departmentName"));
                            //comboBox2.Items.Add(reader.GetString("departmentName"));
                            usernames.Add(reader.GetString("username"));
                        }
                    }
                }
            }
            return usernames;
        }

        List<string> GetDepartments()
        {
            List<string> departments = new List<string>();
            var connectionString = "Server=studmysql01.fhict.local;Uid=dbi400999;Database=dbi400999;Pwd=Group6Project;";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT departmentName FROM department";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            //cbxInsDepartment.Items.Add(reader.GetString("departmentName"));
                            //comboBox2.Items.Add(reader.GetString("departmentName"));
                            departments.Add(reader.GetString("departmentName"));
                        }
                    }
                }
            }
            return departments;
        }

        //Form1_Load !!!
        private void EmployeeManagement_Load(object sender, EventArgs e)
        {
            RefreshDate(); //updates the date label in the shifts management
            comboBox1.Items.Add("Manager");
            comboBox1.Items.Add("Administrator");
            comboBox1.Items.Add("Employee");
            cbxInsPosition.Items.Add("Manager");
            cbxInsPosition.Items.Add("Administrator");
            cbxInsPosition.Items.Add("Employee");
            comboBox2.Items.AddRange(GetDepartments().ToArray());
            cbxInsDepartment.Items.AddRange(GetDepartments().ToArray());
            LoadAllEmployees();
            LoadStats();
            UpdateShiftsListView();
            try
            {
                MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;database=dbi400999;uid=dbi400999;password=Group6Project;");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        //Handling various exceptions and check if usernames, passwords, name, etc. are in a correct format
        bool CheckForErrors(TextBox[] textBoxes, ComboBox[]comboBoxes, RichTextBox[] richTextBoxes)
        {
            foreach (TextBox tb in textBoxes)
            {
                tb.BackColor = Color.White;
            }
            foreach (ComboBox cb in comboBoxes)
            {
                cb.BackColor = Color.White;
            }
            foreach (RichTextBox rtb in richTextBoxes)
            {
                rtb.BackColor = Color.White;
            }

            //These are working together
            foreach (TextBox textBox in textBoxes)
            {
                if (String.IsNullOrEmpty(textBox.Text))
                {
                    textBox.BackColor = Color.LightCoral;
                }
            }
            foreach (RichTextBox richTextBox in richTextBoxes)
            {
                if (String.IsNullOrEmpty(richTextBox.Text))
                {
                    richTextBox.BackColor = Color.LightCoral;
                }
            }
            foreach (ComboBox comboBox in comboBoxes)
            {
                if (String.IsNullOrEmpty(comboBox.Text))
                {
                    comboBox.BackColor = Color.LightCoral;
                }
            }
            foreach (TextBox textBox in textBoxes)
            {
                if (String.IsNullOrEmpty(textBox.Text))
                {
                    MessageBox.Show("Please fill all the textboxes");
                    return true;
                }
            }
            foreach (RichTextBox richTextBox in richTextBoxes)
            {
                if (String.IsNullOrEmpty(richTextBox.Text))
                {
                    MessageBox.Show("Please fill all the textboxes");
                    return true;
                }
            }
            ////

            if (textBoxes[6].Text != currentUser)
            {
                if (GetUsernames().Contains(textBoxes[6].Text))
                {
                    textBoxes[6].BackColor = Color.LightCoral;
                    MessageBox.Show("An employee with this username already exists");
                    return true;
                }
            }

            if (Regex.IsMatch(textBoxes[0].Text, @"^[A-Z][a-z]+[a-z]$") == false)
            {
                textBoxes[0].BackColor = Color.LightCoral;
                MessageBox.Show("Please enter a valid First Name");
                return true;
            }

            if (Regex.IsMatch(textBoxes[1].Text, @"^[A-Z][a-z]+[a-z]$") == false)
            {
                textBoxes[1].BackColor = Color.LightCoral;
                MessageBox.Show("Please enter a valid Last Name");
                return true;
            }

            if (Regex.IsMatch(textBoxes[2].Text, @"^([+]|[0-9])[0-9]+[0-9]$") == false)
            {
                textBoxes[2].BackColor = Color.LightCoral;
                MessageBox.Show("Please enter a valid Telephone Number");
                return true;
            }

            if (Regex.IsMatch(textBoxes[4].Text, @"^([+]|[0-9])[0-9]+[0-9]$") == false)
            {
                textBoxes[4].BackColor = Color.LightCoral;
                MessageBox.Show("Please enter a valid Contact Number");
                return true;
            }

            if (Regex.IsMatch(textBoxes[5].Text, @"((^[0-9][0-9]*[0-9]$)|(^[0-9]$))") == false)
            {
                textBoxes[5].BackColor = Color.LightCoral;
                MessageBox.Show("Please enter a valid Salary");
                return true;
            }

            if (comboBoxes[0].Text != "Employee" && comboBoxes[0].Text != "Administrator" && comboBoxes[0].Text != "Manager")
            {
                comboBoxes[0].BackColor = Color.LightCoral;
                MessageBox.Show("Please select a valid position");
                return true ;
            }

            if (!(GetDepartments().Contains(comboBoxes[1].Text)))
            {
                comboBoxes[1].BackColor = Color.LightCoral;
                MessageBox.Show("Please select a valid department.");
                return true;
            }

            if (textBoxes[7].Text != textBoxes[8].Text)
            {
                textBoxes[7].BackColor = Color.LightCoral;
                textBoxes[8].BackColor = Color.LightCoral;
                MessageBox.Show("Please enter matching passwords");
                return true;
            }

            if (textBoxes[7].Text.Length < 8)
            {
                textBoxes[7].BackColor = Color.LightCoral;
                MessageBox.Show("Password must be at least 8 characters long");
                return true;
            }


            return false;
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            MySqlConnection connection;
            string connectionString;
            connectionString = "Server=studmysql01.fhict.local;Uid=dbi400999;Database=dbi400999;Pwd=Group6Project;";
            connection = new MySqlConnection(connectionString);
            TextBox[] textBoxes = new TextBox[] {tbUsername, tbLastName, tbTel, tbContactName, tbContactPhone, tbSalary, tbEmpUsername, tbEmpPassword, tbEmpConfirmPassword  };
            ComboBox[] comboBoxes = new ComboBox[] { comboBox1, comboBox2 };
            RichTextBox[] richTextBoxes = new RichTextBox[] {richTextBox1 };

            //Handling various exceptions and check if usernames, passwords, name, etc. are in a correct format
            if (CheckForErrors(textBoxes, comboBoxes, richTextBoxes) == true)
            {
                return;
            }

            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    MessageBox.Show("Data entered succesfully.");
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO employee (firstName, lastName, dateOfBirth, phone, address, contactFirstName, contactPhone, salary, position, departmentName, pass, username) VALUES (@firstName, @lastName, @dateOfBirth, @phone, @address, @contactFirstName, @contactPhone, @salary, @position, @departmentName, @pass, @username)", connection);
                    //cmd.Parameters.AddWithValue("@employeeID", Convert.ToInt32(tbEmployeeID.Text));
                    cmd.Parameters.AddWithValue("@firstName", Convert.ToString(tbUsername.Text));
                    cmd.Parameters.AddWithValue("@lastName", Convert.ToString(tbLastName.Text));
                    cmd.Parameters.AddWithValue("@dateOfBirth", Convert.ToDateTime(dateTimePicker1.Value));
                    cmd.Parameters.AddWithValue("@phone", Convert.ToString(tbTel.Text));
                    cmd.Parameters.AddWithValue("@address", Convert.ToString(richTextBox1.Text));
                    cmd.Parameters.AddWithValue("@contactFirstName", Convert.ToString(tbContactName.Text));
                    cmd.Parameters.AddWithValue("@contactPhone", Convert.ToString(tbContactPhone.Text));
                    cmd.Parameters.AddWithValue("@salary", Convert.ToDecimal(tbSalary.Text));
                    cmd.Parameters.AddWithValue("@position", Convert.ToString(comboBox1.SelectedItem));
                    cmd.Parameters.AddWithValue("@departmentName", Convert.ToString(comboBox2.SelectedItem));
                    cmd.Parameters.AddWithValue("@pass", Convert.ToString(tbEmpPassword.Text));
                    cmd.Parameters.AddWithValue("@username", Convert.ToString(tbEmpUsername.Text));
                    string[] row = { "tbEmployeeID.Text", tbUsername.Text, Convert.ToString(comboBox1.SelectedItem), Convert.ToString(comboBox2.SelectedItem) };
                    var listViewItem = new ListViewItem(row);
                    lvAllEmployees.Items.Add(listViewItem);
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


            LoadAllEmployees();
            LoadStats();

            int lastEmployeeID = allEmployees[allEmployees.Count - 1].id;
            NewContract(lastEmployeeID, Convert.ToInt32(tbSalary.Text), comboBox2.Text, comboBox1.Text);
        }

        private void btnRemoveEmployee_Click(object sender, EventArgs e)
        {
            if (lvAllEmployees.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an employee from the list");
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete this employee ?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            //variables
            int index;
            index = lvAllEmployees.FocusedItem.Index;

            //function
            //MessageBox.Show(index.ToString());
            //MessageBox.Show(allEmployees[index].id.ToString());
            string sql = $"DELETE FROM employee WHERE employeeID={allEmployees[index].id};";
            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            //cmd.Parameters.AddWithValue("@userId", id); //int id = Convert.ToInt32(tbxId.Text);
            conn.Open();
            int effectedRows = cmd.ExecuteNonQuery();
            conn.Close();

            lvAllEmployees.Items.Clear();
            MessageBox.Show($"Employee with id {allEmployees[index].id.ToString()} removed");
            LoadAllEmployees();
            LoadStats();
            //MessageBox.Show($"Employee with id {allEmployees[index].id.ToString()} removed");
        }
        private void btnConfirmChanges_Click(object sender, EventArgs e)
        {
            if (lvAllEmployees.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an employee from the list");
                return;
            }

            if (MessageBox.Show("Confirm changes ?", "Warning", MessageBoxButtons.YesNo)== DialogResult.No)
            {
                return;
            }

            int index;
            index = lvAllEmployees.FocusedItem.Index;

            TextBox[] textBoxes = new TextBox[] {tbInsFirstName, tbInsLastName, tbInsTelNumber,tbInsContactName, tbInsContactPhone, tbInsSalary, tbInsUsername, tbInsPassword, tbInsConfirmPassword};
            ComboBox[] comboBoxes = new ComboBox[] { cbxInsPosition, cbxInsDepartment };
            RichTextBox[] richTextBoxes = new RichTextBox[] { tbInsAddress };

            if (CheckForErrors(textBoxes, comboBoxes, richTextBoxes) == true)
            {
                return;
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
                    MySqlCommand cmd = new MySqlCommand($"UPDATE employee SET firstName = @firstName, lastName = @lastName, dateOfBirth = @dateOfBirth, phone = @phone, address = @address, contactFirstName = @contactFirstName, contactPhone = @contactPhone, salary = @salary, position = @position, departmentName = @departmentName, pass = @pass, username = @username WHERE employeeID = {allEmployees[index].id}", connection);
                    cmd.Parameters.AddWithValue("@firstName", Convert.ToString(tbInsFirstName.Text));
                    cmd.Parameters.AddWithValue("@lastName", Convert.ToString(tbInsLastName.Text));
                    cmd.Parameters.AddWithValue("@dateOfBirth", Convert.ToDateTime(dateTimePickerIns.Value));
                    cmd.Parameters.AddWithValue("@phone", Convert.ToString(tbInsTelNumber.Text));
                    cmd.Parameters.AddWithValue("@address", Convert.ToString(tbInsAddress.Text));
                    cmd.Parameters.AddWithValue("@contactFirstName", Convert.ToString(tbInsContactName.Text));
                    cmd.Parameters.AddWithValue("@contactPhone", Convert.ToString(tbInsContactPhone.Text));
                    cmd.Parameters.AddWithValue("@salary", Convert.ToDecimal(tbInsSalary.Text));
                    cmd.Parameters.AddWithValue("@position", Convert.ToString(cbxInsPosition.SelectedItem));
                    cmd.Parameters.AddWithValue("@departmentName", Convert.ToString(cbxInsDepartment.SelectedItem));
                    cmd.Parameters.AddWithValue("@pass", Convert.ToString(tbInsPassword.Text));
                    cmd.Parameters.AddWithValue("@username", Convert.ToString(tbInsUsername.Text));

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            connection.Close();

            if (currentWorkerInfo.MakeNewContract(cbxInsPosition.Text, cbxInsDepartment.Text, Convert.ToInt32(tbInsSalary.Text)) == true)
            {
                NewContract(currentWorkerInfo.Id, Convert.ToInt32(tbInsSalary.Text), cbxInsDepartment.Text, cbxInsPosition.Text);
            }

            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand($"UPDATE morningshifts SET {cbxInsDepartment.Text} = @username WHERE {cbxInsDepartment.Text} = '{currentUser}'", connection);
                    MySqlCommand cmd1 = new MySqlCommand($"UPDATE afternoonshifts SET {cbxInsDepartment.Text} = @username WHERE {cbxInsDepartment.Text} = '{currentUser}'", connection);
                    MySqlCommand cmd2 = new MySqlCommand($"UPDATE eveningshifts SET {cbxInsDepartment.Text} = @username WHERE {cbxInsDepartment.Text} = '{currentUser}'", connection);

                    //MySqlCommand cmd = new MySqlCommand($"UPDATE morningshifts SET Electronics = 'j_bond008' WHERE Electronics = 'j_bond007'", connection);

                    cmd.Parameters.AddWithValue("@username", tbInsUsername.Text);
                    cmd1.Parameters.AddWithValue("@username", tbInsUsername.Text);
                    cmd2.Parameters.AddWithValue("@username", tbInsUsername.Text);

                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            connection.Close();


            LoadAllEmployees();
            LoadStats();

            foreach (TextBox textBox in textBoxes)
            {
                textBox.Clear();
            }
            foreach (ComboBox combo in comboBoxes)
            {
                combo.Text = "";
            }
            foreach (RichTextBox rich in richTextBoxes)
            {
                rich.Clear();
            }
            dateTimePickerIns.Value = DateTime.Now;
            MessageBox.Show("Changes confirmed.");
        }

        private void NewContract(int employeeID, int newSalary, string newDepartment, string newPosition)
        {
            MySqlConnection connection;
            string connectionString;
            connectionString = "Server=studmysql01.fhict.local;Uid=dbi400999;Database=dbi400999;Pwd=Group6Project;";
            connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO contracts (employeeID, dateOfChange, newSalary, newDepartment, newPosition) VALUES (@employeeID, @dateOfChange ,@newSalary, @newDepartment, @newPosition)", connection);

                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    cmd.Parameters.AddWithValue("@dateOfChange", Convert.ToDateTime(DateTime.Now));
                    cmd.Parameters.AddWithValue("@newSalary", newSalary);
                    cmd.Parameters.AddWithValue("@newDepartment", newDepartment);
                    cmd.Parameters.AddWithValue("@newPosition", newPosition);

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
        }

        //switch case with all the months
        string CheckMonth()
        {
            string month = cbxMonth.Text;
            string toReturn = "";
            switch (month)
            {
                case "January":
                    toReturn = "2020-01-01' AND '2020-01-31";
                    break;
                case "February":
                    toReturn = "2020-02-01' AND '2020-02-29";
                    break;
                case "March":
                    toReturn = "2020-03-01' AND '2020-03-31";
                    break;
                case "April":
                    toReturn = "2020-04-01' AND '2020-04-30";
                    break;
                case "May":
                    toReturn = "2020-05-01' AND '2020-05-31";
                    break;
                case "June":
                    toReturn = "2020-06-01' AND '2020-06-30";
                    break;
                case "July":
                    toReturn = "2020-07-01' AND '2020-07-31";
                    break;
                case "August":
                    toReturn = "2020-08-01' AND '2020-08-31";
                    break;
                case "September":
                    toReturn = "2020-09-01' AND '2020-09-30";
                    break;
                case "October":
                    toReturn = "2020-10-01' AND '2020-10-31";
                    break;
                case "November":
                    toReturn = "2020-11-01' AND '2020-11-30";
                    break;
                case "December":
                    toReturn = "2020-12-01' AND '2020-12-31";
                    break;
            }
            return toReturn;
        }

        //void method for updating the statistics list
        void UpdateStatistics() 
        {
            //variables
            if (lvStats.SelectedItems.Count > 0)
            {
                int index;
                index = lvStats.FocusedItem.Index;
                string firstName = stats[index].firstName;
                string department = stats[index].department;
                string id = stats[index].id.ToString();

                List<int> morningCount = new List<int>();
                List<int> afternoonCount = new List<int>();
                List<int> eveningCount = new List<int>(); //I made these List,I dk why, they should be int
                int salary = 0;
                int workedHours;
                int payroll;

                //morning shift counter
                string sql = $"SELECT COUNT(*) FROM morningshifts WHERE {department}='{id}' AND date BETWEEN '{CheckMonth()}';";
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    morningCount.Add(Convert.ToInt32(dr[0]));
                }
                conn.Close();

                //afternoon shift counter
                string sqlB = $"SELECT COUNT(*) FROM afternoonshifts WHERE {department}='{id}' AND date BETWEEN '{CheckMonth()}';";
                MySqlCommand cmdB = new MySqlCommand(sqlB, this.conn);
                conn.Open();
                MySqlDataReader drB = cmdB.ExecuteReader();
                while (drB.Read())
                {
                    afternoonCount.Add(Convert.ToInt32(drB[0]));
                }
                conn.Close();

                //evening shift counter
                string sqlC = $"SELECT COUNT(*) FROM eveningshifts WHERE {department}='{id}' AND date BETWEEN '{CheckMonth()}';";
                MySqlCommand cmdC = new MySqlCommand(sqlC, this.conn);
                conn.Open();
                MySqlDataReader drC = cmdC.ExecuteReader();
                while (drC.Read())
                {
                    eveningCount.Add(Convert.ToInt32(drC[0]));
                }
                conn.Close();

                //The number of shifts per selected month Morning, Evening, Afternoon, 
                lblMorning.Text = morningCount[0].ToString();
                lblAfternoon.Text = afternoonCount[0].ToString();
                lblEvening.Text = eveningCount[0].ToString();

                //Favourite shift
                if (morningCount[0] > afternoonCount[0] && morningCount[0] > eveningCount[0])
                {
                    lblFavShift.Text = "Morning";
                    lblFavShift.ForeColor = Color.Gold;
                }
                else if (afternoonCount[0] > morningCount[0] && afternoonCount[0] > eveningCount[0])
                {
                    lblFavShift.Text = "Afternoon";
                    lblFavShift.ForeColor = Color.Orange;
                }
                else if (eveningCount[0] > morningCount[0] && eveningCount[0] > afternoonCount[0])
                {
                    lblFavShift.Text = "Evening";
                    lblFavShift.ForeColor = Color.OrangeRed;
                }
                else if (eveningCount[0] == morningCount[0])
                {
                    lblFavShift.Text = "Evening \nor Morning";
                    lblFavShift.ForeColor = Color.Orange;
                }
                else if (eveningCount[0] == afternoonCount[0])
                {
                    lblFavShift.Text = "Evening \nor Afternoon";
                    lblFavShift.ForeColor = Color.Orange;
                }
                else if (morningCount[0] == afternoonCount[0])
                {
                    lblFavShift.Text = "Morning \nor Afternoon";
                    lblFavShift.ForeColor = Color.Orange;
                }
                //payroll
                string sqlpayroll = $"SELECT salary FROM employee WHERE employeeID='{id}';";
                MySqlCommand cmdpayroll = new MySqlCommand(sqlpayroll, this.conn);
                conn.Open();
                MySqlDataReader drpayroll = cmdpayroll.ExecuteReader();
                while (drpayroll.Read())
                {
                    salary = Convert.ToInt32(drpayroll[0]);
                }
                //MessageBox.Show(salary.ToString(), "salary");
                conn.Close();

                workedHours = Convert.ToInt32(morningCount[0]) + Convert.ToInt32(afternoonCount[0]) + Convert.ToInt32(eveningCount[0]);
                //MessageBox.Show(workedHours.ToString(), "worked hours");

                payroll = salary * workedHours;
                lblPayroll.Text = payroll.ToString() + "€";
                lblWorkedHours.Text = workedHours.ToString() + " hours";
                if (workedHours == 0)
                {
                    lblFavShift.Text = "-";
                    lblFavShift.ForeColor = Color.Red;
                }
            }
        }

        //updates the stats when changing people from the list
        private void lvStats_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateStatistics();
        }

        //updates the stats when changing month from the ComboBox
        private void cbxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateStatistics();

        }

        void LoadInsertTextboxes() // method that loads info into the "edit info" textboxes
        {
            int index;
            index = lvAllEmployees.FocusedItem.Index;

            string sql = $"SELECT employeeID, firstName, lastName, dateOfBirth, phone, address, contactFirstName, contactPhone, salary, position, departmentName, pass, username FROM employee WHERE employeeID={allEmployees[index].id};";
            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int employeeID = Convert.ToInt32(dr[0]);
                tbInsFirstName.Text = dr[1].ToString();
                tbInsLastName.Text = dr[2].ToString();
                dateTimePickerIns.Text = dr[3].ToString();
                tbInsTelNumber.Text = dr[4].ToString();
                tbInsAddress.Text = dr[5].ToString();
                tbInsContactName.Text = dr[6].ToString();
                tbInsContactPhone.Text = dr[7].ToString();
                tbInsSalary.Text = dr[8].ToString();
                cbxInsPosition.Text = dr[9].ToString();
                cbxInsDepartment.Text = dr[10].ToString();
                tbInsPassword.Text = dr[11].ToString();
                tbInsConfirmPassword.Text = dr[11].ToString();
                tbInsUsername.Text = dr[12].ToString();

                //used to create new contract
                currentWorkerInfo = new CurrentWorkerInfo(employeeID, cbxInsPosition.Text, cbxInsDepartment.Text, Convert.ToInt32(tbInsSalary.Text));

                //variable used to change the username
                currentUser = dr[12].ToString();
                //allEmployees.Add(new Statistics(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString()));
            }
            conn.Close();

        }
        private void lvAllEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadInsertTextboxes();
        }


                            //code for shifts starts here

        void UpdateShiftsInfo()
        {
            int index;
            index = lbEmployees_Shifts.SelectedIndex;
            string employeeName, employeeLastName, departmentName;
            employeeName = stats[index].firstName;
            employeeLastName = stats[index].lastName;
            departmentName = stats[index].department;
            lblEmployee_Shifts.Text = $"{employeeName} {employeeLastName}";
            lblDepartment_Shifts.Text = departmentName;

            int indexTwo = tcShifts.SelectedIndex;
            switch (indexTwo)
            {
                case 0:
                    lblShiftType_Shifts.Text = "Morning";
                    break;
                case 1:
                    lblShiftType_Shifts.Text = "Afternoon";
                    break;
                case 2:
                    lblShiftType_Shifts.Text = "Evening";
                    break;
            }
        }
        private void lbEmployees_Shifts_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateShiftsInfo();
        }

        private void tcShifts_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateShiftsInfo();
            UpdateShiftsListView();
        }
        void RefreshDate()
        {
            string date = dtPicker_Shifts.Value.ToString("yyyy-MM-dd");
            lblDate_Shifts.Text = date;
        }
        private void dtPicker_Shifts_ValueChanged(object sender, EventArgs e)
        {
            RefreshDate();
        }
        string CheckShiftType()
        {
            int indexShiftType = tcShifts.SelectedIndex;
            switch (indexShiftType)
            {
                case 0:
                    return "morningshifts";
                case 1:
                    return "afternoonshifts";
                default:
                    return "eveningshifts";
            }
        }
        string DateRange()
        {
            string dateFrom = dtPickerFrom_Shifts.Value.ToString("yyyy-MM-dd");
            string dateTo = dtPickerTo_Shifts.Value.ToString("yyyy-MM-dd");
            return $"'{dateFrom}' AND '{dateTo}'";
        }
        //update shifts info
        void UpdateShiftsListView()
        {
            lvMorning.Columns.Clear();
            lvMorning.Items.Clear();
            lvAfternoon.Columns.Clear();
            lvAfternoon.Items.Clear();
            lvEvening.Columns.Clear();
            lvEvening.Items.Clear();
            int dateCount = testDates();
            string sqlB = $"SELECT `COLUMN_NAME` FROM `INFORMATION_SCHEMA`.`COLUMNS` WHERE `TABLE_SCHEMA` = 'dbi400999' AND `TABLE_NAME`= '{CheckShiftType()}'; ";
            MySqlCommand cmdB = new MySqlCommand(sqlB, this.conn);
            conn.Open();
            MySqlDataReader drB = cmdB.ExecuteReader();

            List<string> departments = new List<string>();
            while (drB.Read())
            {
                departments.Add(drB[0].ToString());
            }
            departments.RemoveAt(0);
            lvMorning.Items[0].BackColor = Color.White;
            lvAfternoon.Items[0].BackColor = Color.White;
            lvEvening.Items[0].BackColor = Color.White;

            conn.Close();

            lvMorning.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvAfternoon.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvEvening.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            FillRows(departments, dateCount);
        }
        //
        private void btnFilterDate_Shifts_Click(object sender, EventArgs e)
        {
            UpdateShiftsListView();
        }

        private void btnAssignShift_Click(object sender, EventArgs e)
        {
            int index = lbEmployees_Shifts.SelectedIndex;
            int employeeID;
            string departmentName;
            employeeID = stats[index].id;
            departmentName = stats[index].department;
            string date = dtPicker_Shifts.Value.ToString("yyyy-MM-dd");

            MySqlConnection connection;
            string connectionString;
            connectionString = "Server=studmysql01.fhict.local;Uid=dbi400999;Database=dbi400999;Pwd=Group6Project;";
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand($"UPDATE {CheckShiftType()} SET {departmentName} = '{employeeID}' WHERE date = '{date}'", connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            connection.Close();
            UpdateShiftsListView();
            UpdateStatistics();
        }

        private void btnRemoveShift_Click(object sender, EventArgs e)
        {
            int index = lbEmployees_Shifts.SelectedIndex;
            string departmentName;
            departmentName = stats[index].department;
            string date = dtPicker_Shifts.Value.ToString("yyyy-MM-dd");

            MySqlConnection connection;
            string connectionString;
            connectionString = "Server=studmysql01.fhict.local;Uid=dbi400999;Database=dbi400999;Pwd=Group6Project;";
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand($"UPDATE {CheckShiftType()} SET {departmentName} = NULL WHERE date = '{date}'", connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            connection.Close();
            UpdateShiftsListView();
            UpdateStatistics();
        }

        int testDates()
        {
            lvMorning.Columns.Add("Department");
            lvAfternoon.Columns.Add("Department");
            lvEvening.Columns.Add("Department");
            string sql = $"SELECT date FROM {CheckShiftType()} WHERE date BETWEEN {DateRange()};";
            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            List<string> dates = new List<string>();
            while (dr.Read())
            {
                string[] row = new string[1];
                row[0] = dr[0].ToString();
                //row[1] = dr[2].ToString();
                //row[2] = dr[3].ToString();
                DateTime dt = DateTime.ParseExact(dr[0].ToString(), "dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
                string s = dt.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                dates.Add(Convert.ToString(s));
            }
            foreach (string item in dates)
            {
                lvMorning.Columns.Add(Convert.ToString(item));
                lvAfternoon.Columns.Add(Convert.ToString(item));
                lvEvening.Columns.Add(Convert.ToString(item));
            }

            string[] days = new string[dates.Count];
            for (int i = 0; i < dates.Count; i++)
            {
                DateTime dt = DateTime.ParseExact(dates[i].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                string s = dt.ToString("dddd", CultureInfo.InvariantCulture);
                days[i] = s;
            }
            lvMorning.Items.Add("").SubItems.AddRange(days);
            lvAfternoon.Items.Add("").SubItems.AddRange(days);
            lvEvening.Items.Add("").SubItems.AddRange(days);
            
            conn.Close();

            return dates.Count;
        }

        void FillRows(List<string> departments, int dateCount)
        {
            for (int i = 0; i < departments.Count; i++)
            {
                string sql = $"SELECT {departments[i]} FROM {CheckShiftType()} WHERE date BETWEEN {DateRange()};";
                MySqlCommand cmd = new MySqlCommand(sql, this.conn);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                string[] row = new string[dateCount];
                int index = 0;
                while (dr.Read())
                {
                    int employeeId = 0;
                    bool tryParse = int.TryParse(dr[0].ToString(), out employeeId);
 
                    //employeeId = Convert.ToInt32(dr[0].ToString());
                    //int employeeId = 101;
                    string name = "";
                    foreach (Statistics employee in allEmployees)
                    {
                        if (employee.id == employeeId)
                        {
                            name = $"{employee.firstName} {employee.lastName}";
                            break;
                        }
                    }
                    row[index] = name;
                    index++;
                }
                lvMorning.Items.Insert(i+1, Convert.ToString(departments[i])).SubItems.AddRange(row);
                lvAfternoon.Items.Insert(i + 1, Convert.ToString(departments[i])).SubItems.AddRange(row);
                lvEvening.Items.Insert(i + 1, Convert.ToString(departments[i])).SubItems.AddRange(row);

                conn.Close();
            }
        }

        private void cbxInsDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentWorkerInfo = null;
            currentUser = "";
            lvAllEmployees.SelectedItems.Clear();
        }

        private void EmployeeManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainMenu.Show();
        }
    }
}
