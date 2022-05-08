using Ejournall.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Ejournall.DataAccessLayer.Abstraction;
using Ejournall.Core.Entities;

namespace Ejournall.Abstraction
{
    public interface IStudentRepository  : ICRUDRepository <Student>
    {
    }
}
