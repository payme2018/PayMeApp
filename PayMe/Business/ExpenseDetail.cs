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

        [DisplayName("Total Amount")]
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

        [DisplayName("Gross Total Amount")]
        [Required(ErrorMessage = "Please enter Gross Total")]
        public Nullable<decimal> GrossTotal { get; set; }

        [DisplayName("Tax Amount")]
        [Required(ErrorMessage = "Please enter tax amount")]
        public Nullable<decimal> TaxAmount { get; set; }

        [DisplayName("Vat Number")]
        [Required(ErrorMessage = "Please enter vat number")]
        public string VatNumber { get; set; }

        [DisplayName("Paid To")]
        [Required(ErrorMessage = "Please enter vendor/company name")]
        public string PaidTo { get; set; }

       
        [DisplayName("Has Bill")]
        [System.ComponentModel.DefaultValue(true)]
        public bool HasBill { get; set; }

        public HttpPostedFileBase expenseAttachment { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }

        public string Error { get; set; }
        public string ProjectName { get; set; }
        public string ClientName { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public string ExpenseStatusName { get; set; }

    }

    public class ExpenseCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
