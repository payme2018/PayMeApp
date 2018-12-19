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
    public class Project
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Project Name")]
        [Required(ErrorMessage = "Enter Project Name")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Client Required")]
        [DisplayName("Client")]
        public int ClientID { get; set; }
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
