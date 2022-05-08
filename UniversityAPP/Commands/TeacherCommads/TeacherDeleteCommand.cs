using Ejournall.Commands.Auth;
using Ejournall.Utils;
using Ejournall.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Commands.TeacherCommads
{
    public class TeacherDeleteCommand : BaseCommand
    {
        private readonly TeacherControlViewModel viewModel;

        public TeacherDeleteCommand(TeacherControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }


        public override void Execute(object? parameter)
        {
            if (CommonFunctions.MakeDeleteSure() == false)
            {
                return;
            }
            viewModel.DB.TeacherRepository.Delete(viewModel.CurrentValue.Id);

            viewModel.Message = Constants.OperationSuccessMessage;
            DoAnimation(viewModel.ErrorDialog);

            viewModel.AllValues = viewModel.DataProvider.GetTeachers();
            viewModel.Initialize();
        }
    }
}
