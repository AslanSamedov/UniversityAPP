using Ejournall.Core.Entities;
using Ejournall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Mapper
{
    public class ExamScoreMapper : BaseMapper<ExamScore, ExamScoreModel>
    {
        StudentMapper studentMapper = new StudentMapper();
        ExamMapper examMapper = new ExamMapper();

        public override ExamScore Map(ExamScoreModel model)
        {
            return new ExamScore()
            {
                Id = model.Id,
                Score = model.Score,
                Student = studentMapper.Map(model.Student),
                Exam = examMapper.Map(model.Exam)
            };
        }

        public override ExamScoreModel Map(ExamScore entity)
        {
            return new ExamScoreModel()
            {
                Id = entity.Id,
                Score = entity.Score,
                Student = studentMapper.Map(entity.Student),
                Exam = examMapper.Map(entity.Exam)
            };
        }
    }
}
