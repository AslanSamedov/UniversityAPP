using Ejournall.Core.DataAccessLayer.SqlServer.Repositories;
using Ejournall.DataAccessLayer.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Core.Factories
{
    public class DbFactory
    {
        public static IUnitOfWork CreateUnitOfWork(string connectionString)
        {
            return new SqlUnitOfWork(connectionString);
        }
    }
}
