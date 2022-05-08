using Ejournall.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Models
{
    public class CorpusModel : BaseModel<CorpusModel>
    {
        public string Name { get; set; }
        public int CorpusNo { get; set; }

        public override CorpusModel Clone()
        {
            return new CorpusModel()
            {
                Id = Id,
                No = No,
                CorpusNo = CorpusNo,
                Name = Name
            };
        }

        public override string ExcelToString()
        {
            return Name;
        }

        public override bool IsValid(out string message)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                message = ValidationHelper.GetRequiredMessage("Name");
                return false;
            }
            if (string.IsNullOrWhiteSpace(CorpusNo.ToString()))
            {
                message = ValidationHelper.GetRequiredMessage("CorpusNo");
                return false;
            }

            message = string.Empty;
            return true;
        }
    }
}
