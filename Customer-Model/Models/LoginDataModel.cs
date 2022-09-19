using Customer.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Model.Models
{
    public class LoginDataModel
    {
        public Guid UserId { get; set; }

        public Guid CustomerId { get; set; }

        [Display(Name = "Office Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        [Required]
        public string EmailId { get; set; }
        [required]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public DateTime LastLogin { get; set; }



    }
}
