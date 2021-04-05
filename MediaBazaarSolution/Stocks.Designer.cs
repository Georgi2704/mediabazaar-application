namespace MediaBazaarSolution
{
    partial class Stocks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbDepartmentsInStocks = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lvProducts = new System.Windows.Forms.ListView();
            this.chProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tcStocks = new System.Windows.Forms.TabControl();
            this.tpManageStocks = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.tbNewQty = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.btnDecreaseQty = new System.Windows.Forms.Button();
            this.btnRestock = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbCurrDep = new System.Windows.Forms.ComboBox();
            this.tbCurrPrice = new System.Windows.Forms.TextBox();
            this.tbCurrName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.gbAddProduct = new System.Windows.Forms.GroupBox();
            this.btnAddProd = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.tbProdPrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbProdName = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.cbProdDepartment = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.btnRemoveProd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tpRestock = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.lblSortType = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSortByDepartment = new System.Windows.Forms.Button();
            this.btnSortByName = new System.Windows.Forms.Button();
            this.btnSortByPrice = new System.Windows.Forms.Button();
            this.btnMostQuantity = new System.Windows.Forms.Button();
            this.btnMostRestocked = new System.Windows.Forms.Button();
            this.lvAllProducts = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tcStocks.SuspendLayout();
            this.tpManageStocks.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbNewQty)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.gbAddProduct.SuspendLayout();
            this.tpRestock.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbDepartmentsInStocks
            // 
            this.lbDepartmentsInStocks.FormattingEnabled = true;
            this.lbDepartmentsInStocks.ItemHeight = 20;
            this.lbDepartmentsInStocks.Location = new System.Drawing.Point(16, 43);
            this.lbDepartmentsInStocks.Name = "lbDepartmentsInStocks";
            this.lbDepartmentsInStocks.Size = new System.Drawing.Size(205, 464);
            this.lbDepartmentsInStocks.TabIndex = 0;
            this.lbDepartmentsInStocks.SelectedIndexChanged += new System.EventHandler(this.lbDepartmentsInStocks_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(-117, -69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(197, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Select Department:";
            // 
            // lvProducts
            // 
            this.lvProducts.BackColor = System.Drawing.Color.LightGreen;
            this.lvProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chProductName,
            this.chQuantity,
            this.chPrice});
            this.lvProducts.FullRowSelect = true;
            this.lvProducts.GridLines = true;
            this.lvProducts.HideSelection = false;
            this.lvProducts.Location = new System.Drawing.Point(230, 43);
            this.lvProducts.Name = "lvProducts";
            this.lvProducts.Size = new System.Drawing.Size(402, 211);
            this.lvProducts.TabIndex = 17;
            this.lvProducts.UseCompatibleStateImageBehavior = false;
            this.lvProducts.View = System.Windows.Forms.View.Details;
            this.lvProducts.SelectedIndexChanged += new System.EventHandler(this.lvProducts_SelectedIndexChanged);
            // 
            // chProductName
            // 
            this.chProductName.Text = "Name";
            this.chProductName.Width = 102;
            // 
            // chQuantity
            // 
            this.chQuantity.Text = "Quantity";
            this.chQuantity.Width = 69;
            // 
            // chPrice
            // 
            this.chPrice.Text = "Price";
            this.chPrice.Width = 72;
            // 
            // tcStocks
            // 
            this.tcStocks.Controls.Add(this.tpManageStocks);
            this.tcStocks.Controls.Add(this.tpRestock);
            this.tcStocks.Location = new System.Drawing.Point(12, 19);
            this.tcStocks.Name = "tcStocks";
            this.tcStocks.SelectedIndex = 0;
            this.tcStocks.Size = new System.Drawing.Size(1060, 577);
            this.tcStocks.TabIndex = 18;
            // 
            // tpManageStocks
            // 
            this.tpManageStocks.Controls.Add(this.groupBox2);
            this.tpManageStocks.Controls.Add(this.groupBox3);
            this.tpManageStocks.Controls.Add(this.btnUpdate);
            this.tpManageStocks.Controls.Add(this.gbAddProduct);
            this.tpManageStocks.Controls.Add(this.btnRemoveProd);
            this.tpManageStocks.Controls.Add(this.label1);
            this.tpManageStocks.Controls.Add(this.label10);
            this.tpManageStocks.Controls.Add(this.lvProducts);
            this.tpManageStocks.Controls.Add(this.lbDepartmentsInStocks);
            this.tpManageStocks.Controls.Add(this.label6);
            this.tpManageStocks.Location = new System.Drawing.Point(4, 29);
            this.tpManageStocks.Name = "tpManageStocks";
            this.tpManageStocks.Padding = new System.Windows.Forms.Padding(3);
            this.tpManageStocks.Size = new System.Drawing.Size(1052, 544);
            this.tpManageStocks.TabIndex = 0;
            this.tpManageStocks.Text = "Manage Stocks";
            this.tpManageStocks.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblQuantity);
            this.groupBox2.Controls.Add(this.tbNewQty);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.btnDecreaseQty);
            this.groupBox2.Controls.Add(this.btnRestock);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(645, 313);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(367, 166);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Edit quantity:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(6, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 22);
            this.label3.TabIndex = 33;
            this.label3.Text = "Decrease/ Restock by:";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(246, 35);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(20, 25);
            this.lblQuantity.TabIndex = 32;
            this.lblQuantity.Text = "-";
            // 
            // tbNewQty
            // 
            this.tbNewQty.Location = new System.Drawing.Point(210, 63);
            this.tbNewQty.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.tbNewQty.Name = "tbNewQty";
            this.tbNewQty.Size = new System.Drawing.Size(142, 30);
            this.tbNewQty.TabIndex = 31;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label12.Location = new System.Drawing.Point(6, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(218, 22);
            this.label12.TabIndex = 30;
            this.label12.Text = "Selected product quantity:";
            // 
            // btnDecreaseQty
            // 
            this.btnDecreaseQty.BackColor = System.Drawing.Color.Tomato;
            this.btnDecreaseQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecreaseQty.Location = new System.Drawing.Point(143, 100);
            this.btnDecreaseQty.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDecreaseQty.Name = "btnDecreaseQty";
            this.btnDecreaseQty.Size = new System.Drawing.Size(217, 55);
            this.btnDecreaseQty.TabIndex = 29;
            this.btnDecreaseQty.Text = "Decrease quantity";
            this.btnDecreaseQty.UseVisualStyleBackColor = false;
            this.btnDecreaseQty.Click += new System.EventHandler(this.btnDecreaseQty_Click);
            // 
            // btnRestock
            // 
            this.btnRestock.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnRestock.Location = new System.Drawing.Point(10, 100);
            this.btnRestock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRestock.Name = "btnRestock";
            this.btnRestock.Size = new System.Drawing.Size(125, 55);
            this.btnRestock.TabIndex = 28;
            this.btnRestock.Text = "Restock";
            this.btnRestock.UseVisualStyleBackColor = false;
            this.btnRestock.Click += new System.EventHandler(this.btnRestock_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Silver;
            this.groupBox3.Controls.Add(this.cbCurrDep);
            this.groupBox3.Controls.Add(this.tbCurrPrice);
            this.groupBox3.Controls.Add(this.tbCurrName);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox3.Location = new System.Drawing.Point(230, 313);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(405, 166);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Selected Product Information";
            // 
            // cbCurrDep
            // 
            this.cbCurrDep.FormattingEnabled = true;
            this.cbCurrDep.Location = new System.Drawing.Point(128, 31);
            this.cbCurrDep.Name = "cbCurrDep";
            this.cbCurrDep.Size = new System.Drawing.Size(178, 33);
            this.cbCurrDep.TabIndex = 29;
            // 
            // tbCurrPrice
            // 
            this.tbCurrPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.tbCurrPrice.Location = new System.Drawing.Point(128, 115);
            this.tbCurrPrice.Name = "tbCurrPrice";
            this.tbCurrPrice.Size = new System.Drawing.Size(146, 28);
            this.tbCurrPrice.TabIndex = 29;
            // 
            // tbCurrName
            // 
            this.tbCurrName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.tbCurrName.Location = new System.Drawing.Point(128, 78);
            this.tbCurrName.Name = "tbCurrName";
            this.tbCurrName.Size = new System.Drawing.Size(178, 28);
            this.tbCurrName.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label7.Location = new System.Drawing.Point(9, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 22);
            this.label7.TabIndex = 29;
            this.label7.Text = "Price:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.Location = new System.Drawing.Point(9, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 22);
            this.label5.TabIndex = 29;
            this.label5.Text = "Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(9, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 22);
            this.label4.TabIndex = 29;
            this.label4.Text = "Department:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdate.Location = new System.Drawing.Point(230, 485);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(407, 45);
            this.btnUpdate.TabIndex = 29;
            this.btnUpdate.Text = "Update Info";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // gbAddProduct
            // 
            this.gbAddProduct.BackColor = System.Drawing.Color.Silver;
            this.gbAddProduct.Controls.Add(this.btnAddProd);
            this.gbAddProduct.Controls.Add(this.label13);
            this.gbAddProduct.Controls.Add(this.tbProdPrice);
            this.gbAddProduct.Controls.Add(this.label2);
            this.gbAddProduct.Controls.Add(this.tbProdName);
            this.gbAddProduct.Controls.Add(this.label27);
            this.gbAddProduct.Controls.Add(this.cbProdDepartment);
            this.gbAddProduct.Controls.Add(this.label26);
            this.gbAddProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAddProduct.Location = new System.Drawing.Point(645, 43);
            this.gbAddProduct.Name = "gbAddProduct";
            this.gbAddProduct.Size = new System.Drawing.Size(367, 211);
            this.gbAddProduct.TabIndex = 20;
            this.gbAddProduct.TabStop = false;
            this.gbAddProduct.Text = "Add Product:";
            // 
            // btnAddProd
            // 
            this.btnAddProd.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAddProd.Location = new System.Drawing.Point(7, 150);
            this.btnAddProd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddProd.Name = "btnAddProd";
            this.btnAddProd.Size = new System.Drawing.Size(345, 53);
            this.btnAddProd.TabIndex = 28;
            this.btnAddProd.Text = "Add";
            this.btnAddProd.UseVisualStyleBackColor = false;
            this.btnAddProd.Click += new System.EventHandler(this.btnAddProd_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label13.Location = new System.Drawing.Point(278, 112);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 22);
            this.label13.TabIndex = 27;
            this.label13.Text = "€";
            // 
            // tbProdPrice
            // 
            this.tbProdPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.tbProdPrice.Location = new System.Drawing.Point(120, 109);
            this.tbProdPrice.Name = "tbProdPrice";
            this.tbProdPrice.Size = new System.Drawing.Size(146, 28);
            this.tbProdPrice.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(48, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 22);
            this.label2.TabIndex = 25;
            this.label2.Text = "Price:";
            // 
            // tbProdName
            // 
            this.tbProdName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.tbProdName.Location = new System.Drawing.Point(120, 72);
            this.tbProdName.Name = "tbProdName";
            this.tbProdName.Size = new System.Drawing.Size(178, 28);
            this.tbProdName.TabIndex = 24;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label27.Location = new System.Drawing.Point(42, 75);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(62, 22);
            this.label27.TabIndex = 23;
            this.label27.Text = "Name:";
            // 
            // cbProdDepartment
            // 
            this.cbProdDepartment.FormattingEnabled = true;
            this.cbProdDepartment.Location = new System.Drawing.Point(120, 29);
            this.cbProdDepartment.Name = "cbProdDepartment";
            this.cbProdDepartment.Size = new System.Drawing.Size(178, 33);
            this.cbProdDepartment.TabIndex = 22;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label26.Location = new System.Drawing.Point(6, 34);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(108, 22);
            this.label26.TabIndex = 21;
            this.label26.Text = "Department:";
            // 
            // btnRemoveProd
            // 
            this.btnRemoveProd.BackColor = System.Drawing.Color.Tomato;
            this.btnRemoveProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveProd.ForeColor = System.Drawing.Color.White;
            this.btnRemoveProd.Location = new System.Drawing.Point(230, 262);
            this.btnRemoveProd.Name = "btnRemoveProd";
            this.btnRemoveProd.Size = new System.Drawing.Size(405, 45);
            this.btnRemoveProd.TabIndex = 19;
            this.btnRemoveProd.Text = "Remove selected product";
            this.btnRemoveProd.UseVisualStyleBackColor = false;
            this.btnRemoveProd.Click += new System.EventHandler(this.btnRemoveProd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(232, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 22);
            this.label1.TabIndex = 19;
            this.label1.Text = "Products in selected department:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(181, 22);
            this.label10.TabIndex = 18;
            this.label10.Text = "Select Department:";
            // 
            // tpRestock
            // 
            this.tpRestock.Controls.Add(this.button1);
            this.tpRestock.Controls.Add(this.lblSortType);
            this.tpRestock.Controls.Add(this.label9);
            this.tpRestock.Controls.Add(this.label8);
            this.tpRestock.Controls.Add(this.btnSortByDepartment);
            this.tpRestock.Controls.Add(this.btnSortByName);
            this.tpRestock.Controls.Add(this.btnSortByPrice);
            this.tpRestock.Controls.Add(this.btnMostQuantity);
            this.tpRestock.Controls.Add(this.btnMostRestocked);
            this.tpRestock.Controls.Add(this.lvAllProducts);
            this.tpRestock.Location = new System.Drawing.Point(4, 29);
            this.tpRestock.Name = "tpRestock";
            this.tpRestock.Padding = new System.Windows.Forms.Padding(3);
            this.tpRestock.Size = new System.Drawing.Size(1052, 544);
            this.tpRestock.TabIndex = 1;
            this.tpRestock.Text = "Statistics";
            this.tpRestock.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(783, 423);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(248, 59);
            this.button1.TabIndex = 28;
            this.button1.Text = "Default view";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblSortType
            // 
            this.lblSortType.AutoSize = true;
            this.lblSortType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSortType.Location = new System.Drawing.Point(403, 21);
            this.lblSortType.Name = "lblSortType";
            this.lblSortType.Size = new System.Drawing.Size(21, 29);
            this.lblSortType.TabIndex = 27;
            this.lblSortType.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(285, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 25);
            this.label9.TabIndex = 26;
            this.label9.Text = "Sorted by:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(32, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 22);
            this.label8.TabIndex = 25;
            this.label8.Text = "All Products:";
            // 
            // btnSortByDepartment
            // 
            this.btnSortByDepartment.Location = new System.Drawing.Point(783, 358);
            this.btnSortByDepartment.Name = "btnSortByDepartment";
            this.btnSortByDepartment.Size = new System.Drawing.Size(248, 59);
            this.btnSortByDepartment.TabIndex = 24;
            this.btnSortByDepartment.Text = "Sort By Department";
            this.btnSortByDepartment.UseVisualStyleBackColor = true;
            this.btnSortByDepartment.Click += new System.EventHandler(this.btnSortByDepartment_Click);
            // 
            // btnSortByName
            // 
            this.btnSortByName.Location = new System.Drawing.Point(783, 292);
            this.btnSortByName.Name = "btnSortByName";
            this.btnSortByName.Size = new System.Drawing.Size(248, 59);
            this.btnSortByName.TabIndex = 23;
            this.btnSortByName.Text = "Sort by Name";
            this.btnSortByName.UseVisualStyleBackColor = true;
            this.btnSortByName.Click += new System.EventHandler(this.btnSortByName_Click);
            // 
            // btnSortByPrice
            // 
            this.btnSortByPrice.Location = new System.Drawing.Point(783, 226);
            this.btnSortByPrice.Name = "btnSortByPrice";
            this.btnSortByPrice.Size = new System.Drawing.Size(248, 59);
            this.btnSortByPrice.TabIndex = 21;
            this.btnSortByPrice.Text = "Sort By Price";
            this.btnSortByPrice.UseVisualStyleBackColor = true;
            this.btnSortByPrice.Click += new System.EventHandler(this.btnSortByPrice_Click);
            // 
            // btnMostQuantity
            // 
            this.btnMostQuantity.Location = new System.Drawing.Point(783, 161);
            this.btnMostQuantity.Name = "btnMostQuantity";
            this.btnMostQuantity.Size = new System.Drawing.Size(248, 59);
            this.btnMostQuantity.TabIndex = 20;
            this.btnMostQuantity.Text = "Sort By Quantity";
            this.btnMostQuantity.UseVisualStyleBackColor = true;
            this.btnMostQuantity.Click += new System.EventHandler(this.btnMostQuantity_Click);
            // 
            // btnMostRestocked
            // 
            this.btnMostRestocked.Location = new System.Drawing.Point(783, 94);
            this.btnMostRestocked.Name = "btnMostRestocked";
            this.btnMostRestocked.Size = new System.Drawing.Size(248, 59);
            this.btnMostRestocked.TabIndex = 19;
            this.btnMostRestocked.Text = "View Most Restocked";
            this.btnMostRestocked.UseVisualStyleBackColor = true;
            this.btnMostRestocked.Click += new System.EventHandler(this.btnMostRestocked_Click);
            // 
            // lvAllProducts
            // 
            this.lvAllProducts.BackColor = System.Drawing.Color.LightGreen;
            this.lvAllProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvAllProducts.FullRowSelect = true;
            this.lvAllProducts.GridLines = true;
            this.lvAllProducts.HideSelection = false;
            this.lvAllProducts.Location = new System.Drawing.Point(36, 56);
            this.lvAllProducts.Name = "lvAllProducts";
            this.lvAllProducts.Size = new System.Drawing.Size(724, 463);
            this.lvAllProducts.TabIndex = 18;
            this.lvAllProducts.UseCompatibleStateImageBehavior = false;
            this.lvAllProducts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 102;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Quantity";
            this.columnHeader2.Width = 108;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Price";
            this.columnHeader3.Width = 97;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Restocks";
            this.columnHeader4.Width = 86;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Department";
            this.columnHeader5.Width = 114;
            // 
            // Stocks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1084, 599);
            this.Controls.Add(this.tcStocks);
            this.Name = "Stocks";
            this.Text = "Stocks";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Stocks_FormClosed);
            this.Load += new System.EventHandler(this.Stocks_Load);
            this.tcStocks.ResumeLayout(false);
            this.tpManageStocks.ResumeLayout(false);
            this.tpManageStocks.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbNewQty)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbAddProduct.ResumeLayout(false);
            this.gbAddProduct.PerformLayout();
            this.tpRestock.ResumeLayout(false);
            this.tpRestock.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbDepartmentsInStocks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView lvProducts;
        private System.Windows.Forms.ColumnHeader chProductName;
        private System.Windows.Forms.ColumnHeader chQuantity;
        private System.Windows.Forms.ColumnHeader chPrice;
        private System.Windows.Forms.TabControl tcStocks;
        private System.Windows.Forms.TabPage tpManageStocks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox gbAddProduct;
        private System.Windows.Forms.Button btnRemoveProd;
        private System.Windows.Forms.ComboBox cbProdDepartment;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox tbProdName;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox tbProdPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAddProd;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCurrPrice;
        private System.Windows.Forms.TextBox tbCurrName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbCurrDep;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDecreaseQty;
        private System.Windows.Forms.Button btnRestock;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown tbNewQty;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage tpRestock;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvAllProducts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSortByDepartment;
        private System.Windows.Forms.Button btnSortByName;
        private System.Windows.Forms.Button btnSortByPrice;
        private System.Windows.Forms.Button btnMostQuantity;
        private System.Windows.Forms.Button btnMostRestocked;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label lblSortType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
    }
}