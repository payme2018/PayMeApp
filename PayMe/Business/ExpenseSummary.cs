using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business
{
   public class ExpenseSummary
    {
        public int ID { get; set; }
        [DisplayName("Expense Name")]
        [Required(ErrorMessage = "Please enter expense name")]
        public string Name { get; set; }


        public int ExpenseStatusID { get; set; }
        public string ExpenseStatusName { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> ApprovedAmount { get; set; }
        public Nullable<int> EmpID { get; set; }


        [Required(ErrorMessage = "Please select project")]
        [DisplayName("Project")]
        public Nullable<int> ProjectID { get; set; }
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Please select from date")]
        [DisplayName("From Date")]
        public Nullable<System.DateTime> FromDate { get; set; }
        [Required(ErrorMessage = "Please select to date")]
        [DisplayName("To Date")]
        public Nullable<System.DateTime> ToDate { get; set; }
        public string Description { get; set; }
    }
}
