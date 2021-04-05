using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSolution
{
    public class Product
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string DepartmentName { get; set; }
        public int restocks { get; set; }

        public Product(int id, string Name, int Quantity, double Price, string DepartmentName, int restocks)
        {
            this.id = id;
            this.Name = Name;
            this.Quantity = Quantity;
            this.Price = Price;
            this.DepartmentName = DepartmentName;
            this.restocks = restocks;
        }

        public string[] GetDetails()
        {
            string[] details = new string[3];
            details[0] = Quantity.ToString();
            details[1] = Price.ToString();
            return details;
        }

        public string[] GetFullDetails()
        {
            string[] details = new string[5];
            details[0] = Quantity.ToString();
            details[1] = Price.ToString();
            details[2] = restocks.ToString();
            details[3] = DepartmentName.ToString();
            return details;
        }
    }
}
