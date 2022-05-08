using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Models
{
    public class ClassRoomModel : BaseModel<ClassRoomModel>
    {
        public int ClassNo { get; set; }
        public int CorpusID { get; set; }   

        public override ClassRoomModel Clone()
        {
            return new ClassRoomModel()
            {
                Id = this.Id,   
                CorpusID = this.CorpusID,   
                ClassNo = this.ClassNo,
                No = this.No,   
            };
        }

        public override string ExcelToString()
        {
            throw new NotImplementedException();
        }

        public override bool IsValid(out string message)
        {
            throw new NotImplementedException();
        }
    }
}
