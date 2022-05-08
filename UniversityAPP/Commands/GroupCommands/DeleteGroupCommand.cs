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

namespace Ejournall.Commands.GroupCommands
{
    public class DeleteGroupCommand : BaseCommand
    {
        private readonly GroupControlViewModel viewModel;

        public DeleteGroupCommand(GroupControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            if (CommonFunctions.MakeDeleteSure() == false)
            {
                return;
            }

            viewModel.DB.GroupRepository.Delete(viewModel.CurrentValue.Id);

            viewModel.Message = Constants.OperationSuccessMessage;
            DoAnimation(viewModel.ErrorDialog);

            viewModel.AllValues = viewModel.DataProvider.GetGroups();
            viewModel.Initialize();
        }
    }
}
