using Ejournall.Commands.Auth;
using Ejournall.Utils;
using Ejournall.ViewModels.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Commands.LessonTimeCommands
{
    public class DeleteLessonTimeCommand : BaseCommand
    {
        private readonly LessonTimeControlViewModel viewModel;
        public DeleteLessonTimeCommand(LessonTimeControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            if (CommonFunctions.MakeDeleteSure() == false)
            {
                return;
            }

            viewModel.DB.LessonTimeRepository.Delete(viewModel.CurrentValue.Id);

            viewModel.Message = Constants.OperationSuccessMessage;
            DoAnimation(viewModel.ErrorDialog);

            viewModel.AllValues = viewModel.DataProvider.GetLessonTimes();
            viewModel.Initialize();
        }
    }
}
