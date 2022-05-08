using Ejournall.Commands.Auth;
using Ejournall.Utils;
using Ejournall.ViewModels;
using Ejournall.ViewModels.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Commands.SubjectCommands
{
    public class DeleteSubjectCommand : BaseCommand
    {
        private readonly SubjectControlViewModel viewModel;
        public DeleteSubjectCommand(SubjectControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }


        public override void Execute(object? parameter)
        {
            if (CommonFunctions.MakeDeleteSure() == false)
            {
                return;
            }
            viewModel.DB.SubjectRepository.Delete(viewModel.CurrentValue.Id);

            viewModel.Message = Constants.OperationSuccessMessage;
            DoAnimation(viewModel.ErrorDialog);

            viewModel.AllValues = viewModel.DataProvider.GetSubjects();
            viewModel.Initialize();
        }
    }
}
