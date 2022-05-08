using Ejournall.Commands;
using Ejournall.Commands.SubjectCommands;
using Ejournall.Commands.TeacherCommads;
using Ejournall.DataAccessLayer.Abstraction;
using Ejournall.Enums;
using Ejournall.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.ViewModels.Controls
{
    public class SubjectControlViewModel : BaseControlViewModel<SubjectModel>
    {
        public SubjectControlViewModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #region Commands
        public ExcelExportCommand<SubjectModel, SubjectModel> ExcelCommand => new ExcelExportCommand<SubjectModel, SubjectModel>(this);
        public SaveSubjectCommand Save => new SaveSubjectCommand(this);
        public DeleteSubjectCommand Delete => new DeleteSubjectCommand(this);
        public RejectCommand<SubjectModel> Reject => new RejectCommand<SubjectModel>(this);
        #endregion
        public override void OnSearch()
        {
            var models = AllValues.Where(x => IsCompatibleWithValue(x.Name) ||
                                                       IsCompatibleWithValue(x.Hours.ToString()) ||
                                                       IsCompatibleWithValue(x.Limit.ToString()));

            Values = new ObservableCollection<SubjectModel>(models);
        }
    }
}
