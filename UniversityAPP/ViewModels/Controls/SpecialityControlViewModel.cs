using Ejournall.Commands;
using Ejournall.Commands.SpecialityCommands;
using Ejournall.DataAccessLayer.Abstraction;
using Ejournall.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.ViewModels.Controls
{
    public class SpecialityControlViewModel : BaseControlViewModel<SpecialityModel>
    {
        public SpecialityControlViewModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region Properties
        public List<FacultyModel> Faculties { get; set; }

        private FacultyModel selectedFaculty;
        public FacultyModel SelectedFaculty
        {
            get { return selectedFaculty; }

            set
            {
                selectedFaculty = value;
                OnPropertyChanged(nameof(SelectedFaculty));
            }
        }
        #endregion

        #region Commands
        public ExcelExportCommand<SpecialityModel, FacultyModel> ExcelCommand => new ExcelExportCommand<SpecialityModel, FacultyModel>(this);
        public SaveSpecialityCommand Save => new SaveSpecialityCommand(this);
        public DeleteSpecialityCommand Delete => new DeleteSpecialityCommand(this);
        public RejectCommand<SpecialityModel> Reject => new RejectCommand<SpecialityModel>(this);
        #endregion

        #region Methods
        public override void OnSearch()
        {

            var models = AllValues.Where(x => IsCompatibleWithValue(x.Name) ||
                                              IsCompatibleWithValue(x.Faculty.Name));

            Values = new ObservableCollection<SpecialityModel>(models);
        }
        #endregion
    }
}
