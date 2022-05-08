using Ejournall.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Core.Entities
{
    public class Exam : BaseEntity
    {
        public DateTime ExamDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime {get;set; }
        public Lesson Lesson { get; set; }
    }
}
