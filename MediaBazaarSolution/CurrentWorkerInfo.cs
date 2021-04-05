using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSolution
{
    public class CurrentWorkerInfo
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }

        public CurrentWorkerInfo(int Id, string Position, string Department, int Salary)
        {
            this.Id = Id;
            this.Position = Position;
            this.Department = Department;
            this.Salary = Salary;
        }

        public bool MakeNewContract(string Position, string Department, int Salary)
        {
            if (Position != this.Position || Department != this.Department || Salary != this.Salary)
            {
                return true;
            }
            return false;
        }
    }
}
