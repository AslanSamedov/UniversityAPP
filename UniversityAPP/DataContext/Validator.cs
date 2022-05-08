using Ejournall.DataAccessLayer.Abstraction;
using Ejournall.Models;
using Ejournall.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Ejournall.DataContext
{
    public class Validator
    {
        private readonly IUnitOfWork DB;
        public Validator(IUnitOfWork DB)
        {
            this.DB = DB;
        }

        public bool ValidateUser(UserModel user, out string message)
        {
            var users = DB.UserRepository.GetAll();

            if (users.Any(x => x.UserName == user.UserName))
            {
                message = ValidationHelper.GetExsistMessage("Username");
                return false;
            }
            else if (users.Any(x => x.Mail == user.Mail))
            {
                message = ValidationHelper.GetExsistMessage("Email");
                return false;
            }

            message = string.Empty;
            return true;
        }
        //public bool IsValidEmail(string email)
        //{
        //    try
        //    {
        //        var addr = new MailAddress(email);
        //        addr.
        //        return addr.Address == email;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}
