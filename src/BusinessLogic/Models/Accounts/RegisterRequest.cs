using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models.Accounts
{
    public class RegisterRequest
    {
        [Required]
        public string Login { get; set; }

        [Required] 
        public string FirstName { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Middlename { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Range(typeof(bool), "true", "true")]
        public bool AcceptTerms { get; set; }
    }
}
