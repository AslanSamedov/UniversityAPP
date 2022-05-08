using Ejournall.Commands;
using Ejournall.Commands.GroupCommands;
using Ejournall.DataAccessLayer.Abstraction;
using Ejournall.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.ViewModels
{
    public class GroupControlViewModel : BaseControlViewModel <GroupModel>
    {
        public GroupControlViewModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region Properties
        public List<SpecialityModel> Speciality { get; set; }

        private SpecialityModel selectedSpeciality;
        public SpecialityModel SelectedSpeciality
        {
            get => selectedSpeciality;
            set
            {
                selectedSpeciality = value;
                OnPropertyChanged(nameof(SelectedSpeciality));
            }
        }
        #endregion
        //
        #region Commands
        public ExcelExportCommand<GroupModel,SpecialityModel> ExcelCommand => new ExcelExportCommand<GroupModel,SpecialityModel>(this);
        public SaveGroupCommand Save => new SaveGroupCommand(this);
        public DeleteGroupCommand Delete => new DeleteGroupCommand(this);
        public RejectCommand<GroupModel> Reject => new RejectCommand<GroupModel>(this);

        #endregion
        //
        #region Methods
        public override void OnSearch()
        {
            var models = AllValues.Where(x => IsCompatibleWithValue(x.Name) ||
                                            IsCompatibleWithValue(x.Speciality.Name));

            Values = new ObservableCollection<GroupModel>(models);
        }
        #endregion
    }
}
