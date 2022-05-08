using Ejournall.DataAccessLayer.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.DataContext
{
    public static class Kernel
    {
        public static IUnitOfWork DB { get; set; }
    }
}
