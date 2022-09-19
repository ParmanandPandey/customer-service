using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Repository.Entities
{
    public class CustomerEntity
    {
        [Key]
        public Guid CustomerId { get; set; }

        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        
        public string Password { get; set; }

        public string CustomerFullName { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string Pin { get; set; }

        public string State { get; set; }

        public string Country { get; set; }
    }
}
