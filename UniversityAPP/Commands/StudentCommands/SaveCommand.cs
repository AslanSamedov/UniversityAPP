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

namespace Ejournall.Commands.StudentCommands
{
    public class SaveCommand : BaseCommand
    {
        private readonly StudentControlViewModel viewModel;

        public SaveCommand(StudentControlViewModel viewModel)
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
                //viewModel.SelectedGroup = viewModel.SelectedValue.Group;
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
            viewModel.CurrentValue.Group = viewModel.SelectedGroup;

            if (viewModel.CurrentValue.IsValid(out string message) != true)
            {
                viewModel.Message = message;
                DoAnimation(viewModel.ErrorDialog);
                return;
            }

            StudentMapper mapper = new StudentMapper();

            var student = mapper.Map(viewModel.CurrentValue);

            if (student.Id != 0)
            {
                viewModel.DB.StudentRepository.Update(student);
            }
            else
            {
                viewModel.DB.StudentRepository.Insert(student);
            }

            viewModel.Message = Constants.OperationSuccessMessage;
            DoAnimation(viewModel.ErrorDialog);

            viewModel.AllValues = viewModel.DataProvider.GetStudents();
            viewModel.Initialize();
        }

    }
}
