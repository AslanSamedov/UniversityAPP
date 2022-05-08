using Ejournall.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Core.Entities
{
    public class Lesson : BaseEntity
    {
        public Group Group { get; set; }
        public TeacherSubject Subject { get; set; }
        public Semester Semester { get; set; }
        public ClassRoom Classroom { get; set; }    
    }
}
