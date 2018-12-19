using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
namespace Business
{
  
    public class Registration
    {
        [Key]
        public int RegistrationID { get; set; }
        [DisplayName("First Name")]
        [Required(ErrorMessage = "Enter First Name")]
        public string  FirstName { get; set; }

        [Required(ErrorMessage = "Enter Last Name")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Mobile No Required")]
        [DisplayName("Mobile No")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong Mobileno")]
        public string MobileNo { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "EmailID Required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string EmailID { get; set; }

        [MinLength(6, ErrorMessage = "Minimum Username must be 6 in charaters")]
        [Required(ErrorMessage = "Username Required")]
        public string Username { get; set; }

        [MinLength(7, ErrorMessage = "Minimum Password must be 7 in charaters")]
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Enter Valid Password")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Gender Required")]
        public int Gender { get; set; }
        [DisplayName("DOB")]
        public DateTime? Birthdate { get; set; }
        public DateTime? DateofJoining { get; set; }
        [DisplayName("Role")]
        [Required(ErrorMessage = "Role Required")]
        public int RoleID { get; set; }

        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ForceChangePassword { get; set; }
        [DisplayName("Employement Location")]
        public int? fkEmploymentLocationID { get; set; }

        [DisplayName("Department")]
        public int? fkDepartmentID { get; set; }

        [DisplayName("Manager")]
        public int? fkManagerId { get; set; }
        public int? fkContactID { get; set; }
        public string Designation { get; set; }
        [Required(ErrorMessage = "Role Required")]
        public string RoleName { get; set; }
        public string GenderName { get; set; }


    }
    public enum Gender
    {
        Male =1,
        Female=2
    }

    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
     
        [NotMapped]
        public SelectList RoleList { get; set; }
    }
}
