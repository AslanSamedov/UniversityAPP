using Ejournall.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Models
{
    public class ExamScoreModel : BaseModel<ExamScoreModel>
    {
        public StudentModel Student { get; set; }
        public ExamModel Exam { get; set; }
        public int Score { get; set; }


        public override ExamScoreModel Clone()
        {
            return new ExamScoreModel()
            {
                Id = Id,
                Student = Student.Clone(),
                Exam = Exam.Clone(),
                Score = Score
            };
        }
        public override string ExcelToString()
        {
            return $"{Student.Name} {Student.Surname} - {Score}";
        }
        public override bool IsValid(out string message)
        {
            if (Student == null)
            {
                message = ValidationHelper.GetRequiredMessage("Student");
                return false;
            }
            else if (Exam == null)
            {
                message = ValidationHelper.GetRequiredMessage("Exam");
                return false;
            }
            else if (Score < 0)
            {
                message = ValidationHelper.GetRequiredMessage("Score");
                return false;
            }

            message = string.Empty;
            return true;
        }
    }
}
