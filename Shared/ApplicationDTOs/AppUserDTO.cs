using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ApplicationDTOs
{
    public class AppUserDTO
    {
        public AppUserDTO()
        {
            DateOfjoin = DateTime.Today;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The {0} can not have more than {1} characters")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The {0} can not have more than {1} characters")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        public string ProfilePicture { get; set; }

        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be atleast {2} or atmost {1} character long", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string UserName { get; set; }
        public bool IsActive { get; set; }

        public DateTime DateOfjoin { get; set; }
    }
}


//[Required]
//[StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
//[RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$"]
//[DataType(DataType.Password)]
//[Display(Name = "Password")]
//public string Password { get; set; }