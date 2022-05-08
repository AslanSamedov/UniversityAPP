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

namespace Ejournall.Commands.SubjectCommands
{
    public class SaveSubjectCommand : BaseCommand
    {
        private readonly SubjectControlViewModel viewModel;
        public SaveSubjectCommand(SubjectControlViewModel viewModel)
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
        public void Save()
        {
            if (viewModel.CurrentValue.IsValid(out string message) != true)
            {
                viewModel.Message = message;
                DoAnimation(viewModel.ErrorDialog);
                return;
            }

            var mapper = new SubjectMapper();
            var subject = mapper.Map(viewModel.CurrentValue);

            if (subject.Id != 0)
            {
                viewModel.DB.SubjectRepository.Update(subject);
            }
            else
            {
                viewModel.DB.SubjectRepository.Insert(subject);
            }

            viewModel.Message = Constants.OperationSuccessMessage;
            DoAnimation(viewModel.ErrorDialog);

            viewModel.AllValues = viewModel.DataProvider.GetSubjects();
            viewModel.Initialize();
        }
    }
}
