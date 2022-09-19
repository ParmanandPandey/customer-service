using Customer.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Model.Responses
{
    public class CustomerUpdateResponseModel: CommonResponseMessages
    {
        public bool Updated { get; set; }
    }
}
