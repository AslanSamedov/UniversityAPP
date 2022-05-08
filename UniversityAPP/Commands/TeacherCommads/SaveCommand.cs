using Ejournall.Commands.Auth;
using Ejournall.Enums;
using Ejournall.Mapper;
using Ejournall.Utils;
using Ejournall.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Commands.TeacherCommads
{
    public class SaveCommand : BaseCommand
    {
        private readonly TeacherControlViewModel viewModel;
        public SaveCommand(TeacherControlViewModel viewModel)
        {
            this.viewModel = viewModel;
        }


        public override void Execute(object? parameter)
        {
            if (viewModel.CurrentSituation == (byte)Situations.Normal)
            {
                viewModel.CurrentSituation = (byte)Situations.ADD;
            }
            else if (viewModel.CurrentSituation == (byte)Situations.SELECTED)
            {
                viewModel.CurrentSituation = (byte)Situations.EDIT;
            }
            else if (viewModel.CurrentSituation == (byte)Situations.ADD ||
                    viewModel.CurrentSituation == (byte)Situations.EDIT)
            {
                Save();
            }
        }

        private void Save()
        {
            if (viewModel.CurrentValue.IsValid(out string message) != true)
            {
                viewModel.Message = message;
                DoAnimation(viewModel.ErrorDialog);
                return;
            }

            var mapper = new TeacherMapper();
            var teacher = mapper.Map(viewModel.CurrentValue);

            if (teacher.Id != 0)
            {
                viewModel.DB.TeacherRepository.Update(teacher);
            }
            else
            {
                viewModel.DB.TeacherRepository.Insert(teacher);
            }

            viewModel.Message = Constants.OperationSuccessMessage;
            DoAnimation(viewModel.ErrorDialog);

            viewModel.AllValues = viewModel.DataProvider.GetTeachers();
            viewModel.Initialize();
        }
    }
}
