using Ejournall.Core.Entities;
using Ejournall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Mapper
{

    public class ClassRoomMapper : BaseMapper<ClassRoom, ClassRoomModel>
    {
        private readonly CorpusMapper corpusMapper = new CorpusMapper();

        public override ClassRoom Map(ClassRoomModel model)
        {
            return new ClassRoom()
            {
                Id = model.Id,  
                ClassNo = model.ClassNo,   
                CorpusID = model.CorpusID
            };
        }

        public override ClassRoomModel Map(ClassRoom entity)
        {
            return new ClassRoomModel()
            {
                Id = entity.Id,  
                ClassNo = entity.ClassNo,
                CorpusID = entity.CorpusID  
            };
        }
    }
}
