using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime DOB { get; set; }
        public int fkEmploymentLocationID { get; set; }
        public string Designation { get; set; }
        public int WorkingHoursPerDay { get; set; }
        public string EmployeeCode { get; set; }
        public string InternalCode { get; set; }
        public int fkDepartmentID { get; set; }
        public int fkManagerId { get; set; }
        public int fkContactID { get; set; }
        public bool IsActive { get; set; }
        public DateTime InactiveDate { get; set; }
        public DateTime LastWorkingDate { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string EmployeeName { get; set; }
    }
}
