using Ejournall.Core.Entities;
using Ejournall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Mapper
{
    public class UserMapper : BaseMapper<User, UserModel>
    {
        public override User Map(UserModel model)
        {
            return new User() 
            { 
                Id = model.Id,
                UserName = model.UserName,
                Mail = model.Mail,
                PasswordHash = model.PasswordHash
            };        
        }

        public override UserModel Map(User entity)
        {
            return new UserModel()
            {
                Id = entity.Id,
                UserName = entity.UserName,
                Mail = entity.Mail,
                PasswordHash = entity.PasswordHash
            };
        }
    }
}
