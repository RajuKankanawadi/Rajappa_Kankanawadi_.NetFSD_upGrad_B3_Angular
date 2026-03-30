using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class ContactInfo
    {
        [Required(ErrorMessage = "Contact Id is required")]
        public int ContactId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "First Name should be between 5 and 15 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Last Name should be between 5 and 15 character")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "EmailId is required")]
        public string EmailId { get; set; }

        [Required (ErrorMessage = "Mobile Number should be 10 Numbers Only")]
        public long MobileNo { get; set; }

        [Required(ErrorMessage = "Designation is required")]
        public string Designation { get; set; }
    }
}
