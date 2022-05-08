using Ejournall.Commands;
using Ejournall.Commands.StudentCommands;
using Ejournall.DataAccessLayer.Abstraction;
using Ejournall.Entities;
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
    public class StudentControlViewModel : BaseControlViewModel<StudentModel>
    {
        public StudentControlViewModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region Properties
        public List<GroupModel> Groups { get; set; }
        private GroupModel selectedGroup;
        public GroupModel SelectedGroup
        {
            get => selectedGroup;
            set
            {
                selectedGroup = value;
                OnPropertyChanged(nameof(SelectedGroup));
            }
        }

        #endregion
        //
        #region Commands
        public ExcelExportCommand<StudentModel, GroupModel> ExcelCommand => new ExcelExportCommand<StudentModel, GroupModel>(this);
        public SaveCommand Save => new SaveCommand(this);
        public StudentDeleteCommand Delete => new StudentDeleteCommand(this);   
        public RejectCommand<StudentModel> Reject => new RejectCommand<StudentModel>(this);
        #endregion
        //
        #region Methods
        public override void OnSearch()
        {
            
            var models = AllValues.Where(x => IsCompatibleWithValue(x.Name) ||
                                              IsCompatibleWithValue(x.Surname) ||
                                              IsCompatibleWithValue(x.Birthdate.ToString()) ||
                                              IsCompatibleWithValue(x.Group.Name));

            Values = new ObservableCollection<StudentModel>(models);
        }
        #endregion
    }
}
