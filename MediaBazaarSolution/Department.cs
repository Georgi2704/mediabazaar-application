using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSolution
{
    public class Department
    {
        public int id { get; set; }
        public string Name { get; set; }

        public Department(int id, string Name)
        {
            this.id = id;
            this.Name = Name;
        }
    }
}
