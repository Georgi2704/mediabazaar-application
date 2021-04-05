using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSolution
{
    class WorkerFullInfo
    {
        public int employeeID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string dateOfBirth { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string contactFirstName { get; set; }
        public string contactPhone { get; set; }
        public double salary { get; set; }
        public string position { get; set; }
        public string departmentName { get; set; }

        public WorkerFullInfo
            (int employeeID,string firstName,string lastName,string dateOfBirth,string phone,
            string address,string contactFirstName,string contactPhone,double salary,
            string position,string departmentName)
        {
            this.employeeID = employeeID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.phone = phone;
            this.address = address;
            this.contactFirstName = contactFirstName;
            this.salary = salary;
            this.position = position;
            this.departmentName = departmentName;
        }
    }
}
