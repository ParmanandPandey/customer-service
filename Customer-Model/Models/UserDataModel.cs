using Customer.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Model.Models
{
   public class UserDataModel:UserBaseModel
    {
        public Guid UserId { get; set; }
    }
}
