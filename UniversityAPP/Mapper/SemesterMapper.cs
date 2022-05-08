using Ejournall.Entities;
using Ejournall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Mapper
{
    public class SemesterMapper : BaseMapper<Semester, SemesterModel>
    {
        public override Semester Map(SemesterModel model)
        {
            return new Semester()
            {
                Id = model.Id,
                Name = model.Name,
                StartDate = model.StartDate,
                EndDate = model.EndDate
            };
        }

        public override SemesterModel Map(Semester entity)
        {
            return new SemesterModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate
            };
        }
    }
}
