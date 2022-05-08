using Ejournall.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Models
{
    public class UserModel : BaseModel<UserModel>
    {
        public string Mail { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }

        public override UserModel Clone()
        {
            return new UserModel()
            {
                Id = Id,
                No = No,
                UserName = UserName,
                PasswordHash = PasswordHash,
                Mail = Mail
            };
        }

        public override string ExcelToString()
        {
            return UserName;
        }

        public override bool IsValid(out string message)
        {
            if (string.IsNullOrWhiteSpace(UserName))
            {
                message = ValidationHelper.GetRequiredMessage("Username");
                return false;
            }
            if (string.IsNullOrWhiteSpace(Mail))
            {
                message = ValidationHelper.GetRequiredMessage("Mail");
                return false;
            }
            message = string.Empty;
            return true;
        }
    }
}
