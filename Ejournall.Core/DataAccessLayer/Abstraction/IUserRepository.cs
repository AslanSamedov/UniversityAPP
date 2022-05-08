using Ejournall.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.DataAccessLayer.Abstraction
{
    public interface IUserRepository :ICRUDRepository<User>
    {
        User GetUserByUsername(string nickName);
        public bool UpdatePassword(User entity);
    }
}
