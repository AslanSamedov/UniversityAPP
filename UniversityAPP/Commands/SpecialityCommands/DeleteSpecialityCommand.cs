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
    public class DeleteSpecialityCommand : BaseCommand
    {
        private SpecialityControlViewModel viewModel;

        public DeleteSpecialityCommand(SpecialityControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            if(CommonFunctions.MakeDeleteSure() == false)
            {
                return;
            }

            viewModel.DB.SpecialityRepository.Delete(viewModel.CurrentValue.Id);

            viewModel.Message = Constants.OperationSuccessMessage;
            DoAnimation(viewModel.ErrorDialog);

            viewModel.AllValues = viewModel.DataProvider.GetSpecialties();
            viewModel.Initialize();
        }
    }
}
