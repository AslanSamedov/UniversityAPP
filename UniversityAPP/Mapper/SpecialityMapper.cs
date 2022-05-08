using Ejournall.Entities;
using Ejournall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Mapper
{
    public class SpecialityMapper : BaseMapper<Speciality, SpecialityModel>
    {
        private readonly FacultyMapper facultyMapper = new FacultyMapper();
        public override Speciality Map(SpecialityModel spModel)
        {
           return new Speciality()
           {
               Id = spModel.Id,
               Name = spModel.Name,
               Faculty = facultyMapper.Map(spModel.Faculty)
           };
        }

        public override SpecialityModel Map(Speciality speciality)
        {
            return new SpecialityModel()
            {
                Id = speciality.Id,
                Name = speciality.Name,
                Faculty = facultyMapper.Map(speciality.Faculty)
            };

        }
    }
}
