using Ejournall.Entities;
using Ejournall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Mapper
{
    public class SubjectMapper : BaseMapper<Subject, SubjectModel>
    {
        public override Subject Map(SubjectModel model)
        {
            return new Subject()
            {
                Id = model.Id,
                Name = model.Name,
                Hours = model.Hours,
                Limit = model.Limit
            };
        }

        public override SubjectModel Map(Subject entity)
        {
            return new SubjectModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Hours = entity.Hours,
                Limit = entity.Limit
            };
        }
    }
}
