using Ejournall.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Models
{
    public class SubjectModel : BaseModel<SubjectModel>
    {
        public string Name { get; set; }
        public int Hours { get; set; }
        public int Limit { get; set; }

        public override SubjectModel Clone()
        {
            return new SubjectModel()
            {
                Id = Id,
                No = No,
                Name = Name,
                Hours = Hours,
                Limit = Limit
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
            if (int.TryParse(Hours.ToString(), out int b) == false || Hours <= 0 || Hours > 300 || string.IsNullOrWhiteSpace(Hours.ToString()))
            {
                message = ValidationHelper.GetRequiredMessage("Hours");
                return false;
            }
            if (((int.TryParse(Limit.ToString(),out int a)) == false) || Limit <= 0 || string.IsNullOrWhiteSpace(Limit.ToString()))
            {
                message = ValidationHelper.GetRequiredMessage("Limit");
                return false;
            }
            message = string.Empty;
            return true;
        }
    }
}
