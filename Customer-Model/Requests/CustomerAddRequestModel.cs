using Customer.Model.Base;
using Customer.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Model.Requests
{
    public class CustomerAddRequestModel: CustomerBaseModel
    {
        [Display(Name = "Office Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        [Required]
        public string EmailId { get; set; }
        [required]
        public string Password { get; set; }
    }
}
