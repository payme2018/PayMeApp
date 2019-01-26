using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business
{
    public class Task
    {

        [Key]
        public int ID { get; set; }

     

        [Required(ErrorMessage = "Client Required")]
        [DisplayName("Client")]
        public int ClientID { get; set; }
        public string ClientName { get; set; }

        [DisplayName("Project")]
        [Required(ErrorMessage = "Project Required")]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        [DisplayName("Task")]
        [Required(ErrorMessage = "Enter Task Name")]
        public string TaskName { get; set; }

        [DisplayName("Primary Contact")]
        public string PrimaryContact { get; set; }

        [DisplayName("Location Info")]
        public string LocationInfo { get; set; }
        public string Description { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; }

    }
}
