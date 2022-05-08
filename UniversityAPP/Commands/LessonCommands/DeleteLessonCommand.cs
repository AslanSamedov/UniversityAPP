using Ejournall.Commands.Auth;
using Ejournall.Utils;
using Ejournall.ViewModels.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Commands.LessonCommands
{
    public class DeleteLessonCommand : BaseCommand
    {
        private readonly LessonControlViewModel viewModel;
        public DeleteLessonCommand(LessonControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            
            if (CommonFunctions.MakeDeleteSure() == false)
            {
                return;
            }

            viewModel.DB.LessonRepository.Delete(viewModel.CurrentValue.Id);

            viewModel.Message = Constants.OperationSuccessMessage;
            DoAnimation(viewModel.ErrorDialog);


            viewModel.AllValues = viewModel.DataProvider.GetLessons();
            viewModel.Initialize();
        }
    }
}
