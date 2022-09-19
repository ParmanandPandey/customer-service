using Customer.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Model.Responses
{
    public class CustomerDeleteResponseModel: CommonResponseMessages
    {
        public bool IsDeleted { get; set; }
    }
}
