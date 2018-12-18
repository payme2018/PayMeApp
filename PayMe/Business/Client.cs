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

      public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string PrimaryContact { get; set; }
        public string LocationInfo { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
