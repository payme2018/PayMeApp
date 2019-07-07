using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TimeSheetSummary
    {
       public int AccountID { get; set; }
        public string AccountName { get; set; }
        public int ProjectID { get; set; }
        public int CompanyID { get; set; }
        public string  CompanyName { get; set; }
        public string ProjectName { get; set; }
        public double Totalhours { get; set; }
    }
}
