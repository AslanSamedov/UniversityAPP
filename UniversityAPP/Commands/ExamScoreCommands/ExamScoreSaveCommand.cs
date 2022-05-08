using Ejournall.Commands.Auth;
using Ejournall.Enums;
using Ejournall.Mapper;
using Ejournall.Utils;
using Ejournall.ViewModels.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Commands.ExamScoreCommands
{
    public class SaveExmScoreCommand : BaseCommand
    {
        private readonly ExamScoreViewModel viewModel;

        public SaveExmScoreCommand(ExamScoreViewModel viewModel)
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
            viewModel.CurrentValue.Student = viewModel.SelectedStudent;
            viewModel.CurrentValue.Exam = viewModel.SelectedExam;

            if (viewModel.CurrentValue.IsValid(out string message) != true)
            {
                viewModel.Message = message;
                DoAnimation(viewModel.ErrorDialog);

                return;
            }

            ExamScoreMapper mapper = new ExamScoreMapper();

            var entity = mapper.Map(viewModel.CurrentValue);

            if (entity.Id != 0)
            {
                viewModel.DB.ExamScoreRepository.Update(entity);
            }
            else
            {
                viewModel.DB.ExamScoreRepository.Insert(entity);
            }

            viewModel.Message = Constants.OperationSuccessMessage;
            DoAnimation(viewModel.ErrorDialog);

            viewModel.AllValues = viewModel.DataProvider.GetExamScores();

            viewModel.CurrentValue = new Models.ExamScoreModel();

            viewModel.Initialize();

        }
    }
}
