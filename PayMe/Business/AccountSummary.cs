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
    public class AccountSummary
    {
        public int ID { get; set; }
        [DisplayName("Client Count")]
        public int ClientCount { get; set; }
        [DisplayName("Project Count")]
        public int ProjectCount { get; set; }
        [DisplayName("Employee Count")]
        public int EmployeeCount { get; set; }
        [DisplayName("Total Hour Incurrent Month")]
        public int  TotalHourIncurrentMonth { get; set; }
        [DisplayName("Total Expense Incurrent Month")]
        public int TotalExpenseIncurrentMonth { get; set; }

    }
}
