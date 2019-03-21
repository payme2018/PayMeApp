using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class EmployeePayRate
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        [DisplayName("Start Date")]
        [Required(ErrorMessage = "Please select start date")]
        public Nullable<System.DateTime> StartDate { get; set; }
        [DisplayName("End Date")]
        [Required(ErrorMessage = "Please select end date")]
        public Nullable<System.DateTime> EndDate { get; set; }
        [DisplayName("Pay Rate")]
        public int PayRateTypeID { get; set; }
        [DisplayName("Regular Rate")]
        [Required(ErrorMessage = "Please enter regular rate")]
        public decimal RegularRate { get; set; }
        [DisplayName("OT Rate")]
        [Required(ErrorMessage = "Please enter OT rate")]
        public decimal OTRate { get; set; }
        public string Name { get; set; }
    }
}
