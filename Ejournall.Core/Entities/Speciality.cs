using Ejournall.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Entities
{
    public class Speciality : BaseEntity
    {
        public string Name { get; set; }
        public int FacultyId { get; set; }
        //public bool status { get; set; }
        public Faculty Faculty { get; set; }

    }
}
