using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
   public class TimeTracker
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Employee Required")]
        [DisplayName("Employee")]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Client Required")]
        [DisplayName("Client")]
        public int ClientID { get; set; }

        [DisplayName("Project")]
        [Required(ErrorMessage = "Project Required")]
        public int ProjectID { get; set; }

        [DisplayName("Task")]
        [Required(ErrorMessage = "Task Required")]
        public int TaskID { get; set; }
        public Nullable<System.DateTime> CheckInDateTime { get; set; }
        public Nullable<System.DateTime> CheckOutDateTime { get; set; }
        public string ClientName { get; set; }
        public string ProjectName { get; set; }
        public string TaskName { get; set; }
        public string EmployeeName { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> EditedOn { get; set; }
        public string EditedBy { get; set; }

        public string TimeWorked { get; set; }
    }
}
