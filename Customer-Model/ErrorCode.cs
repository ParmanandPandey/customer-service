using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Model
{
    public class ErrorCode
    {
        public const string UpdateCutomerErrorCode = "100001";
        public const string AddUserErrorCode = "100002";

        public const string UpdateCutomerErrorDesc = "Error occured while updating customer entity";
        public const string AddCutomerErrorDesc = "Error occured while adding customer entity";

    }
    public class UserErrorCode
    {
        public const string UpdateUserErrorCode = "100001";
        public const string AddUserErrorCode = "100002";

        public const string UpdateUserErrorDesc = "Error occured while updating User entity";
        public const string AddUserErrorDesc = "Error occured while adding User entity";

    }
}
