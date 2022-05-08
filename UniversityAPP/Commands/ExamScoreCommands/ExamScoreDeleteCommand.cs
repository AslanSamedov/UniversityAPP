using Ejournall.Commands.Auth;
using Ejournall.Utils;
using Ejournall.ViewModels.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Commands.ExamScoreCommands
{
    public class DeleteExamScoreCommand : BaseCommand
    {
        private readonly ExamScoreViewModel viewModel;

        public DeleteExamScoreCommand(ExamScoreViewModel viewModel)
        {
            this.viewModel = viewModel;
        }


        public override void Execute(object? parameter)
        {

            if (CommonFunctions.MakeDeleteSure() == false)
            {
                return;
            }

            viewModel.DB.ExamScoreRepository.Delete(viewModel.SelectedValue.Id);

            viewModel.Message = Constants.OperationSuccessMessage;
            DoAnimation(viewModel.ErrorDialog);

            viewModel.AllValues = viewModel.DataProvider.GetExamScores();
            viewModel.Initialize();
        }
    }
}
