using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Core.Entities
{
    public class User : BaseEntity
    {
        public string Mail { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }
}
