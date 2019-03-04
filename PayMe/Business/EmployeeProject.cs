using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business
{
    public class EmployeeProject
    {
        [Required(ErrorMessage = "Client Required")]
        [DisplayName("Client")]
        public int ClientID { get; set; }
        public string ClientName { get; set; }

        [DisplayName("Project")]
        [Required(ErrorMessage = "Project Required")]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }


        [DisplayName("Default Task")]
        [Required(ErrorMessage = "Default Task Required")]
        public int TaskID { get; set; }
        public string TaskName { get; set; }

        [DisplayName("Employee Name")]
        [Required(ErrorMessage = "Employee Name Required")]
        public int EmpID { get; set; }
        public string EmployeeName { get; set; }

        [DisplayName("Start Date")]
        [Required(ErrorMessage = "Start Date Required")]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        [Required(ErrorMessage = "End Date Required")]
        public DateTime EndDate { get; set; }

        [DisplayName("Regular Rate")]
        public Decimal RegularRate { get; set; }

        [DisplayName("OT Rate")]
        public Decimal OTRate { get; set; }
        public int Id { get; set; }
        
        
        
        


    }
}
