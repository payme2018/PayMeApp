using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class AccountExpenseSummary
    {

        public int AccountID { get; set; }
        public int projectid { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string ProjectName { get; set; }
        public double TotalExpense { get; set; }
        public double TotalApprovedExpense { get; set; }
    }
}
