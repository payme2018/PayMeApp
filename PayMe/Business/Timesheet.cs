using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Timesheet
    {
        public int ID { get; set; }
        public int fkEmpId { get; set; }
        public int fkClientId { get; set; }
        public int fkProjectID { get; set; }
        public int fkTaskID { get; set; }
        public System.DateTime CheckInDate { get; set; }
        public System.DateTime CheckInDateTime { get; set; }
        public System.DateTime CheckOutDatetime { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsBillable { get; set; }
        public Nullable<int> IsApproved { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> EditedOn { get; set; }
        public string EditedBy { get; set; }
        public Nullable<System.DateTime> ApprovedDate { get; set; }
        public string ProjectName { get; set; }
        public string ClientName { get; set; }
        public string EmployeeName { get; set; }
        public string TaskName { get; set; }
    }
}
