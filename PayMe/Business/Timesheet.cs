using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Timesheet
    {
        public int ID { get; set; }

        [DisplayName("Employee Name")]
        [Required(ErrorMessage = "Employee Required")]
        public int fkEmpId { get; set; }

        [DisplayName("Client")]
        [Required(ErrorMessage = "Client Required")]
        public int fkClientId { get; set; }

        [DisplayName("Project")]
        [Required(ErrorMessage = "Project Required")]
        public int fkProjectID { get; set; }

        [DisplayName("Task")]
        [Required(ErrorMessage = "Task Required")]
        public int fkTaskID { get; set; }

        [DisplayName("Check In Date")]
        public System.DateTime CheckInDate { get; set; }

        [DisplayName("Check In DateTime")]
        public System.DateTime CheckInDateTime { get; set; }

        [DisplayName("Check Out DateTime")]
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

        public string Hours { get; set; }
    }
}
