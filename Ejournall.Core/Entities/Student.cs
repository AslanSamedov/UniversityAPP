using Ejournall.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Entities
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthdate { get; set; }
        public int GroupId { get; set; }
        public bool Status { get; set; }
        public Group Group { get; set; }
    }
}
