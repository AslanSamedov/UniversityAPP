using Ejournall.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Entities
{
    public class TeacherSubject : BaseEntity
    {
        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }
        
    }
}
