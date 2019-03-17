using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class EmployeePayRate
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public int PayRateTypeID { get; set; }
        public decimal RegularRate { get; set; }
        public decimal OTRate { get; set; }
        public string Name { get; set; }
    }
}
