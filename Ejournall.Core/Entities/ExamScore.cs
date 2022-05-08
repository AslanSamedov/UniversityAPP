using Ejournall.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Core.Entities
{
    public class ExamScore : BaseEntity
    {
        public Student Student { get; set; }
        public Exam Exam { get; set; }
        public int Score { get; set; }
    }
}
