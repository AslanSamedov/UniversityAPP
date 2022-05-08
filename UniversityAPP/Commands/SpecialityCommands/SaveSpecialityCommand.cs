using Ejournall.Commands.Auth;
using Ejournall.Enums;
using Ejournall.Mapper;
using Ejournall.Utils;
using Ejournall.ViewModels;
using Ejournall.ViewModels.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Commands.SpecialityCommands
{
    public class SaveSpecialityCommand : BaseCommand
    {
        private readonly SpecialityControlViewModel viewModel;

        public SaveSpecialityCommand(SpecialityControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            if(viewModel.CurrentSituation == (byte)Situations.Normal)
            {
                viewModel.CurrentSituation = (byte)Situations.ADD;
            }
            else if(viewModel.CurrentSituation == (byte)Situations.SELECTED)
            {
                viewModel.CurrentSituation = (byte)Situations.EDIT;
                viewModel.SelectedFaculty = viewModel.SelectedValue.Faculty;
            }
            else if(viewModel.CurrentSituation == (byte)Situations.ADD || viewModel.CurrentSituation == (byte)Situations.EDIT)
            {
                Save();
            }
        }

        public void Save()
        {
            viewModel.CurrentValue.Faculty = viewModel.SelectedFaculty;

            if(viewModel.CurrentValue.IsValid(out string message) != true)
            {
                viewModel.Message = message;
                DoAnimation(viewModel.ErrorDialog);
                return;
            }
          
            SpecialityMapper mapper = new SpecialityMapper();

            var speciality = mapper.Map(viewModel.CurrentValue);

            if(speciality.Id != 0)
            {
                viewModel.DB.SpecialityRepository.Update(speciality);
            }
            else
            {
                viewModel.DB.SpecialityRepository.Insert(speciality);
            }

            viewModel.Message = Constants.OperationSuccessMessage;
            DoAnimation(viewModel.ErrorDialog);

            viewModel.AllValues = viewModel.DataProvider.GetSpecialties();
            viewModel.Initialize();
        }
    }
}
