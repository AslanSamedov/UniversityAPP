using Ejournall.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Models
{
    public class SemesterModel : BaseModel<SemesterModel>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public override SemesterModel Clone()
        {
            return new SemesterModel()
            {
                Id = Id,
                No = No,
                Name = Name,
                StartDate = StartDate,
                EndDate = EndDate
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
            if (StartDate.Year < 2000 || StartDate.Year > DateTime.Now.Year || StartDate > EndDate ||
                string.IsNullOrWhiteSpace(StartDate.ToString()))
            {
                message = ValidationHelper.GetRequiredMessage("Start Date");
                return false;
            }
            if (EndDate < StartDate || EndDate.Year > StartDate.Month + 6 || string.IsNullOrWhiteSpace(EndDate.ToString()))
            {
                message = ValidationHelper.GetRequiredMessage("End Date");
                return false;
            }
            message = string.Empty;
            return true;
        }
    }
}
