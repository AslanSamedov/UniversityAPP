using Ejournall.Commands.Auth;
using Ejournall.Utils;
using Ejournall.ViewModels.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Commands.ExamCommands
{
    public class DeleteExamCommand : BaseCommand
    {
        private readonly ExamControlViewModel viewModel;
        public DeleteExamCommand(ExamControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            if (CommonFunctions.MakeDeleteSure() == false)
            {
                return;
            }

            viewModel.DB.ExamRepository.Delete(viewModel.CurrentValue.Id);

            viewModel.Message = Constants.OperationSuccessMessage;
            DoAnimation(viewModel.ErrorDialog);

            viewModel.AllValues = viewModel.DataProvider.GetExams();
            viewModel.Initialize();
        }
    }
}
