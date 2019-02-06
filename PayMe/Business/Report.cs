using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business
{
    public class Report
    {
        [Required(ErrorMessage = "Client Required")]
        [DisplayName("Client")]
        public int ClientID { get; set; }
        public string ClientName { get; set; }

        [DisplayName("Project")]
        [Required(ErrorMessage = "Project Required")]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }


        public int ID { get; set; }
        public string Name { get; set; }
        public int ExpenseStatusID { get; set; }
        public string ExpenseStatusName { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> ApprovedAmount { get; set; }
        public Nullable<int> EmpID { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public string Description { get; set; }
    }
}
