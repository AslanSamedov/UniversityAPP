using Ejournall.Entities;
using Ejournall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Mapper
{
    public class GroupMapper : BaseMapper<Group, GroupModel>
    {
        private readonly SpecialityMapper specialityMapper = new SpecialityMapper();    
        public override GroupModel Map(Group group)
        {
            GroupModel groupModel = new GroupModel()
            {
                Id = group.Id,
                Name = group.Name,
                Speciality = specialityMapper.Map(group.Speciality)
            };

            return groupModel;
        }
        public override Group Map(GroupModel groupModel)
        {
            Group group = new Group()
            {
                Id=groupModel.Id,   
                Name = groupModel.Name,
                Speciality=specialityMapper.Map(groupModel.Speciality)
            };

            return group;
        }
    }
}
