using Ejournall.Commands.Auth;
using Ejournall.Utils;
using Ejournall.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Commands.StudentCommands
{
    public class StudentDeleteCommand : BaseCommand
    {
        private readonly StudentControlViewModel viewModel;
        public StudentDeleteCommand(StudentControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            if (CommonFunctions.MakeDeleteSure() == false)
            {
                return;
            }

            viewModel.DB.StudentRepository.Delete(viewModel.CurrentValue.Id);

            viewModel.Message = Constants.OperationSuccessMessage;
            DoAnimation(viewModel.ErrorDialog);

            viewModel.AllValues = viewModel.DataProvider.GetStudents();
            viewModel.Initialize();



        }
    }
}
