using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Business
{
    public class ExpenseDetail
    {
        public int ID { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage = "Please select category")]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int ExpenseSummaryID { get; set; }

        [DisplayName("Currency Bill No")]
        [Required(ErrorMessage = "Please enter currency bill no")]
        public string CurrencyBillNo { get; set; }
      
        [Required(ErrorMessage = "Please enter amount")]
        public Nullable<decimal> Amount { get; set; }

        [DisplayName("Bill Date")]
        [Required(ErrorMessage = "Please select billdate")]
        public Nullable<System.DateTime> BillDate { get; set; }

        [DisplayName("Location")]
        [Required(ErrorMessage = "Please enter Location")]
        public string Location { get; set; }

        [DisplayName("Has Attachment")]
        public bool HasAttachment { get; set; }
        public string Notes { get; set; }

        public HttpPostedFileBase expenseAttachment { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }

        public string Error { get; set; }
    }

    public class ExpenseCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
