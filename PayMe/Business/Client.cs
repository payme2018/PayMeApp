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
    public class Client
    {
        [Key]
        public int ID { get; set; }
        [DisplayName("Client Code")]
        [Required(ErrorMessage = "Enter Client Code")]
        public string ClientCode { get; set; }

        [DisplayName("Client Name")]
        [Required(ErrorMessage = "Enter Client Name")]
        public string ClientName { get; set; }

        [DisplayName("Primary Contact")]
        public string PrimaryContact { get; set; }

        [DisplayName("Location Info")]
        public string LocationInfo { get; set; }
        public string Description { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
    }
}
