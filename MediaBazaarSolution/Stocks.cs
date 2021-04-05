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
using System.Text.RegularExpressions;

namespace MediaBazaarSolution
{
    public partial class Stocks : Form
    {
        MainMenu mainMenu;
        MySqlConnection conn = new MySqlConnection("server=studmysql01.fhict.local;database=dbi400999;uid=dbi400999;password=Group6Project;");
        List<Product> allProducts = new List<Product>(); 
        public Stocks(MainMenu mainMenu)
        {
            this.mainMenu = mainMenu;
            InitializeComponent();

        }

        private void Stocks_Load(object sender, EventArgs e)
        {
            ReloadProducts();
            RefreshAllProductsListView(lblSortType.Text);
            lbDepartmentsInStocks.Items.AddRange(GetDepartments().ToArray());
            cbProdDepartment.Items.AddRange(GetDepartments().ToArray());
            cbCurrDep.Items.AddRange(GetDepartments().ToArray());
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

        private void LoadEditInfoTextboxes()
        {
            if (lvProducts.SelectedItems.Count > 0)
            {
                string department = lbDepartmentsInStocks.SelectedItem.ToString();
                string name = lvProducts.FocusedItem.Text;
                string price = lvProducts.FocusedItem.SubItems[2].Text;

                cbCurrDep.Text = department;
                tbCurrName.Text = name;
                tbCurrPrice.Text = price;
            }
        }
        
        private void ReloadProducts()
        {
            lvProducts.Items.Clear();
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
            RefreshAllProductsListView(lblSortType.Text);
        }

        private void RefreshListView()
        {
            lvProducts.Items.Clear();
            string departmentName;
            if (lbDepartmentsInStocks.SelectedIndex == -1)
            {
                lbDepartmentsInStocks.SelectedIndex = 0;
                departmentName = lbDepartmentsInStocks.SelectedItem.ToString();
            }
            else
            {
                departmentName = lbDepartmentsInStocks.SelectedItem.ToString();
            }
            for (int i = 0; i < allProducts.Count; i++)
            {
                if (allProducts[i].DepartmentName == departmentName)
                {
                    string[] row = allProducts[i].GetDetails();
                    lvProducts.Items.Add(allProducts[i].Name.ToString()).SubItems.AddRange(row);
                }
            }
        }

        private void ClearAllLabelsAndTexboxes()
        {
            tbCurrPrice.Clear();
            tbCurrName.Clear();
            cbCurrDep.Text = "";
            lblQuantity.Text = "-";
        }

        private void lbDepartmentsInStocks_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvProducts.Items.Clear();
            ClearAllLabelsAndTexboxes();
            if (lbDepartmentsInStocks.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a department");
                return;
            }
            RefreshListView();
        }

        private void UpdateQuantityLabel()
        {
            if (lvProducts.SelectedItems.Count > 0)
            {
                lblQuantity.Text = lvProducts.FocusedItem.SubItems[1].Text;
            }
        }

        private void lvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearAllLabelsAndTexboxes();
            LoadEditInfoTextboxes();
            UpdateQuantityLabel();
            tbCurrPrice.BackColor = Color.White;
            tbCurrName.BackColor = Color.White;
            cbCurrDep.BackColor = Color.White;
        }

        private void btnAddProd_Click(object sender, EventArgs e)
        {
            TextBox[] textBoxes = new TextBox[] { tbProdName, tbProdPrice };
            ComboBox[] comboBoxes = new ComboBox[] { cbProdDepartment };
            if (CheckForErrors(comboBoxes, textBoxes) == true)
            {
                return;
            }
            foreach (var product in allProducts)
            {
                if (product.Name == textBoxes[0].Text)
                {
                    MessageBox.Show("A product with this name already exists");
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
                    MessageBox.Show("Data entered succesfully.");
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO product (productName, numberInStock, Price, departmentName, restocks) VALUES (@productName, 0, @Price, @departmentName, 0)", connection);
                    cmd.Parameters.AddWithValue("@productName", Convert.ToString(tbProdName.Text));
                    cmd.Parameters.AddWithValue("@Price", Convert.ToDouble(tbProdPrice.Text));
                    cmd.Parameters.AddWithValue("@departmentName", Convert.ToString(cbProdDepartment.Text));
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

            ReloadProducts();
            RefreshListView();
        }

        private void btnRemoveProd_Click(object sender, EventArgs e)
        {
            if (lbDepartmentsInStocks.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a department first");
                return;
            }
            if (lvProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a product from the list");
                return;
            }
            if (MessageBox.Show("Are you sure you want to remove this product ?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            string productName = lvProducts.SelectedItems[0].Text;
            string sql = $"DELETE FROM product WHERE productName='{productName}';";
            MySqlCommand cmd = new MySqlCommand(sql, this.conn);
            conn.Open();
            int effectedRows = cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show($"Product '{productName}' removed"); //dont forget to do this!

            ReloadProducts();
            RefreshListView();
            ClearAllLabelsAndTexboxes();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a product from the list");
                return;
            }
            if (MessageBox.Show("Confirm changes ?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            TextBox[] textBoxes = new TextBox[] { tbCurrName, tbCurrPrice};
            ComboBox[] comboBoxes = new ComboBox[] { cbCurrDep };

            if (CheckForErrors(comboBoxes, textBoxes) == true)
            {
                return;
            }

            foreach (var product in allProducts)
            {
                if (lvProducts.FocusedItem.Text == tbCurrName.Text)
                {
                    break;
                }
                if (product.Name == textBoxes[0].Text)
                {
                    MessageBox.Show("A product with this name already exists");
                    return;
                }
            }

            string productName = lvProducts.FocusedItem.Text;

            MySqlConnection connection;
            string connectionString;
            connectionString = "Server=studmysql01.fhict.local;Uid=dbi400999;Database=dbi400999;Pwd=Group6Project;";
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand($"UPDATE product SET productName = @productName, Price = @Price, departmentName = @departmentName WHERE productName = '{productName}'", connection);
                    cmd.Parameters.AddWithValue("@productName", Convert.ToString(tbCurrName.Text));
                    cmd.Parameters.AddWithValue("@Price", Convert.ToDouble(tbCurrPrice.Text));
                    cmd.Parameters.AddWithValue("@departmentName", Convert.ToString(cbCurrDep.Text));

                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Product edited successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            connection.Close();

            ReloadProducts();
            RefreshListView();
            ClearAllLabelsAndTexboxes();
        }

        bool CheckForErrors(ComboBox[] comboBoxes, TextBox[] textBoxes)
        {
            foreach (TextBox tb in textBoxes)
            {
                tb.BackColor = Color.White;
            }
            foreach (ComboBox cb in comboBoxes)
            {
                cb.BackColor = Color.White;
            }

            foreach (TextBox textBox in textBoxes)
            {
                if (String.IsNullOrEmpty(textBox.Text))
                {
                    textBox.BackColor = Color.LightCoral;
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
            if (!(GetDepartments().Contains(comboBoxes[0].Text)))
            {
                comboBoxes[0].BackColor = Color.LightCoral;
                MessageBox.Show("Please select a valid department.");
                return true;
            }

            if (Regex.IsMatch(textBoxes[1].Text, @"((^\d*\d$)|(^\d*,\d{1,2}$))") == false)
            {
                textBoxes[1].BackColor = Color.LightCoral;
                MessageBox.Show("Please enter a valid Price");
                return true;
            }

            return false;
        }

        private int GetAmountOfRestocks(string name)
        {
            foreach (var product in allProducts)
            {
                if (product.Name == name)
                {
                    return product.restocks;
                }
            }
            return 0;
        }

        private int GetSelectedProductQuantity(string name)
        {
            foreach (var product in allProducts)
            {
                if (product.Name == name)
                {
                    return product.Quantity;
                }
            }
            return 0;
        }

        private void btnRestock_Click(object sender, EventArgs e)
        {
            if (lvProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a product from the list");
                return;
            }
            if (tbNewQty.Value < 0)
            {
                MessageBox.Show("Please enter a valid amount");
                return;
            }

            string productName = lvProducts.FocusedItem.Text;

            MySqlConnection connection;
            string connectionString;
            connectionString = "Server=studmysql01.fhict.local;Uid=dbi400999;Database=dbi400999;Pwd=Group6Project;";
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand($"UPDATE product SET numberInStock = @numberInStock, restocks = @restocks WHERE productName = '{productName}'", connection);
                    int newNumberInStock = Convert.ToInt32(lvProducts.FocusedItem.SubItems[1].Text) + Convert.ToInt32(tbNewQty.Value);
                    int newRestocks = GetAmountOfRestocks(lvProducts.FocusedItem.Text) + 1;
                    cmd.Parameters.AddWithValue("@numberInStock", newNumberInStock);
                    cmd.Parameters.AddWithValue("@restocks", newRestocks);

                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Product restocked successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            connection.Close();

            ReloadProducts();
            RefreshListView();
            ClearAllLabelsAndTexboxes();
        }

        private void btnDecreaseQty_Click(object sender, EventArgs e)
        {
            if (lvProducts.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a product from the list");
                return;
            }
            if (GetSelectedProductQuantity(lvProducts.FocusedItem.Text) < tbNewQty.Value)
            {
                MessageBox.Show("Insufficient Quantity");
                return;
            }

            string productName = lvProducts.FocusedItem.Text;

            MySqlConnection connection;
            string connectionString;
            connectionString = "Server=studmysql01.fhict.local;Uid=dbi400999;Database=dbi400999;Pwd=Group6Project;";
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    MySqlCommand cmd = new MySqlCommand($"UPDATE product SET numberInStock = @numberInStock WHERE productName = '{productName}'", connection);
                    int newNumberInStock = Convert.ToInt32(lvProducts.FocusedItem.SubItems[1].Text) - Convert.ToInt32(tbNewQty.Value);
                    cmd.Parameters.AddWithValue("@numberInStock", newNumberInStock);

                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Product quantity decreased successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            connection.Close();

            ReloadProducts();
            RefreshListView();
            ClearAllLabelsAndTexboxes();
        }

        private void RefreshAllProductsListView(string sortType)
        {
            lvAllProducts.Items.Clear();
            if (sortType == "-")
            {
                List<Product> SortedList = allProducts.OrderBy(o => o.id).ToList();
                foreach (Product product in SortedList)
                {
                    string[] row = product.GetFullDetails();
                    lvAllProducts.Items.Add(product.Name.ToString()).SubItems.AddRange(row);
                }
            }
            else if (sortType == "Restocks")
            {
                List<Product> SortedList = allProducts.OrderByDescending(o => o.restocks).ToList();
                foreach (Product product in SortedList)
                {
                    string[] row = product.GetFullDetails();
                    lvAllProducts.Items.Add(product.Name.ToString()).SubItems.AddRange(row);
                }
            }
            else if (sortType == "Price")
            {
                List<Product> SortedList = allProducts.OrderByDescending(o => o.Price).ToList();
                foreach (Product product in SortedList)
                {
                    string[] row = product.GetFullDetails();
                    lvAllProducts.Items.Add(product.Name.ToString()).SubItems.AddRange(row);
                }
            }
            else if (sortType == "Name")
            {
                List<Product> SortedList = allProducts.OrderBy(o => o.Name).ToList();
                foreach (Product product in SortedList)
                {
                    string[] row = product.GetFullDetails();
                    lvAllProducts.Items.Add(product.Name.ToString()).SubItems.AddRange(row);
                }
            }
            else if (sortType == "Department")
            {
                List<Product> SortedList = allProducts.OrderBy(o => o.DepartmentName).ToList();
                foreach (Product product in SortedList)
                {
                    string[] row = product.GetFullDetails();
                    lvAllProducts.Items.Add(product.Name.ToString()).SubItems.AddRange(row);
                }
            }
            else if (sortType == "Quantity")
            {
                List<Product> SortedList = allProducts.OrderByDescending(o => o.Quantity).ToList();
                foreach (Product product in SortedList)
                {
                    string[] row = product.GetFullDetails();
                    lvAllProducts.Items.Add(product.Name.ToString()).SubItems.AddRange(row);
                }
            }
        }

        private void btnMostRestocked_Click(object sender, EventArgs e)
        {
            lblSortType.Text = "Restocks";
            RefreshAllProductsListView(lblSortType.Text);
        }

        private void btnMostQuantity_Click(object sender, EventArgs e)
        {
            lblSortType.Text = "Quantity";
            RefreshAllProductsListView(lblSortType.Text);
        }

        private void btnSortByPrice_Click(object sender, EventArgs e)
        {
            lblSortType.Text = "Price";
            RefreshAllProductsListView(lblSortType.Text);
        }

        private void btnSortByName_Click(object sender, EventArgs e)
        {
            lblSortType.Text = "Name";
            RefreshAllProductsListView(lblSortType.Text);
        }

        private void btnSortByDepartment_Click(object sender, EventArgs e)
        {
            lblSortType.Text = "Department";
            RefreshAllProductsListView(lblSortType.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblSortType.Text = "-";
            RefreshAllProductsListView(lblSortType.Text);
        }

        private void Stocks_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainMenu.Show();
        }
    }
}
