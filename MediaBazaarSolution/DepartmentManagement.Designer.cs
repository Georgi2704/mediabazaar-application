namespace MediaBazaarSolution
{
    partial class DepartmentManagement
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
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lvProducts_Dep = new System.Windows.Forms.ListView();
            this.chProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.lvEmployees_Dep = new System.Windows.Forms.ListView();
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbDepartmentName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRemoveDep = new System.Windows.Forms.Button();
            this.btnAddDepartment = new System.Windows.Forms.Button();
            this.lbCurrentDep = new System.Windows.Forms.ListBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 22);
            this.label4.TabIndex = 32;
            this.label4.Text = "Current Departments:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(232, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "Products in selected department:";
            // 
            // lvProducts_Dep
            // 
            this.lvProducts_Dep.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvProducts_Dep.BackColor = System.Drawing.Color.LightGreen;
            this.lvProducts_Dep.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chProductName,
            this.chQuantity,
            this.chPrice});
            this.lvProducts_Dep.FullRowSelect = true;
            this.lvProducts_Dep.GridLines = true;
            this.lvProducts_Dep.HideSelection = false;
            this.lvProducts_Dep.Location = new System.Drawing.Point(235, 38);
            this.lvProducts_Dep.Name = "lvProducts_Dep";
            this.lvProducts_Dep.Size = new System.Drawing.Size(506, 190);
            this.lvProducts_Dep.TabIndex = 33;
            this.lvProducts_Dep.UseCompatibleStateImageBehavior = false;
            this.lvProducts_Dep.View = System.Windows.Forms.View.Details;
            // 
            // chProductName
            // 
            this.chProductName.Text = "Name";
            this.chProductName.Width = 135;
            // 
            // chQuantity
            // 
            this.chQuantity.Text = "Quantity";
            this.chQuantity.Width = 82;
            // 
            // chPrice
            // 
            this.chPrice.Text = "Price";
            this.chPrice.Width = 72;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(234, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 20);
            this.label2.TabIndex = 35;
            this.label2.Text = "Employees in selected department:";
            // 
            // lvEmployees_Dep
            // 
            this.lvEmployees_Dep.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvEmployees_Dep.BackColor = System.Drawing.Color.LightGreen;
            this.lvEmployees_Dep.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13,
            this.columnHeader14});
            this.lvEmployees_Dep.FullRowSelect = true;
            this.lvEmployees_Dep.GridLines = true;
            this.lvEmployees_Dep.HideSelection = false;
            this.lvEmployees_Dep.Location = new System.Drawing.Point(238, 265);
            this.lvEmployees_Dep.Name = "lvEmployees_Dep";
            this.lvEmployees_Dep.Size = new System.Drawing.Size(503, 226);
            this.lvEmployees_Dep.TabIndex = 36;
            this.lvEmployees_Dep.UseCompatibleStateImageBehavior = false;
            this.lvEmployees_Dep.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Name";
            this.columnHeader13.Width = 200;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Position";
            this.columnHeader14.Width = 125;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox2.Controls.Add(this.tbDepartmentName);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(751, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 158);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add Department:";
            // 
            // tbDepartmentName
            // 
            this.tbDepartmentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.tbDepartmentName.Location = new System.Drawing.Point(82, 72);
            this.tbDepartmentName.Name = "tbDepartmentName";
            this.tbDepartmentName.Size = new System.Drawing.Size(205, 28);
            this.tbDepartmentName.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 25);
            this.label7.TabIndex = 23;
            this.label7.Text = "Name:";
            // 
            // btnRemoveDep
            // 
            this.btnRemoveDep.BackColor = System.Drawing.Color.Gray;
            this.btnRemoveDep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveDep.ForeColor = System.Drawing.Color.White;
            this.btnRemoveDep.Location = new System.Drawing.Point(12, 404);
            this.btnRemoveDep.Name = "btnRemoveDep";
            this.btnRemoveDep.Size = new System.Drawing.Size(212, 87);
            this.btnRemoveDep.TabIndex = 38;
            this.btnRemoveDep.Text = "Remove selected department";
            this.btnRemoveDep.UseVisualStyleBackColor = false;
            this.btnRemoveDep.Click += new System.EventHandler(this.btnRemoveDep_Click);
            // 
            // btnAddDepartment
            // 
            this.btnAddDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDepartment.BackColor = System.Drawing.Color.Gray;
            this.btnAddDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDepartment.ForeColor = System.Drawing.Color.White;
            this.btnAddDepartment.Location = new System.Drawing.Point(751, 323);
            this.btnAddDepartment.Name = "btnAddDepartment";
            this.btnAddDepartment.Size = new System.Drawing.Size(293, 52);
            this.btnAddDepartment.TabIndex = 39;
            this.btnAddDepartment.Text = "Add department";
            this.btnAddDepartment.UseVisualStyleBackColor = false;
            this.btnAddDepartment.Click += new System.EventHandler(this.btnAddDepartment_Click);
            // 
            // lbCurrentDep
            // 
            this.lbCurrentDep.FormattingEnabled = true;
            this.lbCurrentDep.ItemHeight = 20;
            this.lbCurrentDep.Items.AddRange(new object[] {
            " "});
            this.lbCurrentDep.Location = new System.Drawing.Point(12, 75);
            this.lbCurrentDep.Margin = new System.Windows.Forms.Padding(2);
            this.lbCurrentDep.Name = "lbCurrentDep";
            this.lbCurrentDep.Size = new System.Drawing.Size(212, 324);
            this.lbCurrentDep.TabIndex = 40;
            this.lbCurrentDep.SelectedIndexChanged += new System.EventHandler(this.lbCurrentDep_SelectedIndexChanged);
            // 
            // DepartmentManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 503);
            this.Controls.Add(this.lbCurrentDep);
            this.Controls.Add(this.btnAddDepartment);
            this.Controls.Add(this.btnRemoveDep);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lvEmployees_Dep);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvProducts_Dep);
            this.Controls.Add(this.label4);
            this.Name = "DepartmentManagement";
            this.Text = "DepartmentManagement";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DepartmentManagement_FormClosed);
            this.Load += new System.EventHandler(this.DepartmentManagement_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvProducts_Dep;
        private System.Windows.Forms.ColumnHeader chProductName;
        private System.Windows.Forms.ColumnHeader chQuantity;
        private System.Windows.Forms.ColumnHeader chPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvEmployees_Dep;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbDepartmentName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRemoveDep;
        private System.Windows.Forms.Button btnAddDepartment;
        private System.Windows.Forms.ListBox lbCurrentDep;
    }
}