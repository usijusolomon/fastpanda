using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObjectClass.Objects
{
    public class User
    {
        public long UserId { get; set; }
        [DisplayName("User Password")]
        [Required]
        public string UserPassword { get; set; }
        [DisplayName("Confirm Password")]
        [Required]
        [Compare("UserPassword")]
        public string ConfirmPassword { get; set; }
        [DisplayName("Candidate Number")]
        [Required]
        //Matric Number or Candidate Identity
        public string UserMatric { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [DisplayName("First name")]
        [Required]
        public string UserFirstName { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string UserLastName { get; set; }
        [DisplayName("User Type")]
        public string UserType { get; set; }
        public long? LevelId { get; set; }
        [ForeignKey ("LevelId")]
        public Level Level { get; set; }
        public long? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public long? FacultyId { get; set; }
        [ForeignKey("FacultyId")]
        public Faculty Faculty { get; set; }


    }
}
