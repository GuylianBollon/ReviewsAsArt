using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAsArt.DTO
{
    public class RegisterDTO : LoginDTO
    {

        [Required]
        [StringLength(200)]
        public String UserName { get; set; }

        [Required]
        [Compare("Password")]
        [RegularExpression("{8,}$",
            ErrorMessage = "Passwords must be at least 8 characters in length.")]
        public String PasswordConfirmation { get; set; }
    }
}
