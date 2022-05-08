using Ejournall.Commands;
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

namespace Ejournall.ViewModels
{
    public class TeacherControlViewModel : BaseControlViewModel<TeacherModel>
    {
        public TeacherControlViewModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        //
        #region Commands
        public ExcelExportCommand<TeacherModel, TeacherModel> ExcelCommand => new ExcelExportCommand<TeacherModel, TeacherModel>(this);
        public SaveCommand Save => new SaveCommand(this);
        public TeacherDeleteCommand Delete => new TeacherDeleteCommand(this);
        public RejectCommand<TeacherModel> Reject => new RejectCommand<TeacherModel>(this);
        #endregion
        //
        #region Method
        public override void OnSearch()
        {
            var models = AllValues.Where(x => IsCompatibleWithValue(x.Name) ||
                                            IsCompatibleWithValue(x.Surname) ||
                                            IsCompatibleWithValue(x.WorkExperience.ToString()) ||
                                            IsCompatibleWithValue(x.BirthDate.ToString()));

            Values = new ObservableCollection<TeacherModel>(models);
        }
        #endregion
    }
}
