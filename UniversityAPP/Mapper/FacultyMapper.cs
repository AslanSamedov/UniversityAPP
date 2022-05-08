using Ejournall.Entities;
using Ejournall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Mapper
{
    public class FacultyMapper : BaseMapper<Faculty, FacultyModel>
    {
        public override Faculty Map(FacultyModel model)
        {
            return new Faculty()
            {
                Id = model.Id,  
                Name = model.Name,
            };
        }

        public override FacultyModel Map(Faculty entity)
        {
            return new FacultyModel()
            {
                Id =entity.Id,  
                Name=entity.Name,
            };
        }
    }
}
