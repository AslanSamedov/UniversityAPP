using Ejournall.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Entities
{
    public class Subject : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public int Limit { get; set; }
    }
}
