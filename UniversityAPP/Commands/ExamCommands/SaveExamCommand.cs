using Ejournall.Commands.Auth;
using Ejournall.Enums;
using Ejournall.Mapper;
using Ejournall.Models;
using Ejournall.Utils;
using Ejournall.ViewModels.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Commands.ExamCommands
{
    public class SaveExamCommand : BaseCommand
    {
        private readonly ExamControlViewModel viewModel;

        public SaveExamCommand(ExamControlViewModel viewModel)
        {
            this.viewModel= viewModel;
        }
        public override void Execute(object? parameter)
        {
            if (viewModel.CurrentSituation == (byte)Situations.Normal)
            {
                viewModel.CurrentSituation = (byte)Situations.ADD;
            }
            else if (viewModel.CurrentSituation == (byte)Situations.SELECTED)
            {
                viewModel.SelectedLesson = viewModel.SelectedValue.Lesson;
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
            viewModel.CurrentValue.Lesson = viewModel.SelectedLesson;

            if (viewModel.CurrentValue.IsValid(out string result) == false)
            {
                viewModel.Message = result;
                DoAnimation(viewModel.ErrorDialog);
                return;
            }
            if(IsExists(viewModel.CurrentValue) == false)
            {
                viewModel.Message = "This Data Already Exists";
                DoAnimation(viewModel.ErrorDialog);
                return;
            }
            if (IsWrongDay(viewModel.CurrentValue) == false)
            {
                viewModel.Message = $"Group {viewModel.CurrentValue.Lesson.Group.Name} Has Another Exam in {viewModel.CurrentValue.ExamDate.ToString("dd/MM/yyyy")}";
                DoAnimation(viewModel.ErrorDialog);
                return;
            }
            ExamMapper mapper = new ExamMapper();

            var exam = mapper.Map(viewModel.CurrentValue);

            if (exam.Id != 0)
            {
                viewModel.DB.ExamRepository.Update(exam);
            }
            else
            {
                viewModel.DB.ExamRepository.Insert(exam);
            }

            viewModel.Message = Constants.OperationSuccessMessage;
            DoAnimation(viewModel.ErrorDialog);

            viewModel.AllValues = viewModel.DataProvider.GetExams();
            viewModel.Initialize();
        }
        public bool IsExists(ExamModel exam)
        {
            List<ExamModel> list = viewModel.AllValues;
            for(int i = 0; i < list.Count; i++)
            {
                if(list[i].Lesson.Group.Name == exam.Lesson.Group.Name && exam.Id != list[i].Id && 
                    list[i].Lesson.Subject.Subject.Name == exam.Lesson.Subject.Subject.Name && 
                    (list[i].StartTime == exam.StartTime || list[i].EndTime < exam.StartTime))
                {
                    return false;
                }
            }
            return true;
        }
        public bool IsWrongDay(ExamModel exam)
        {
            List<ExamModel> list = viewModel.AllValues;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Lesson.Group.Name == exam.Lesson.Group.Name && list[i].Id != exam.Id &&
                    list[i].ExamDate == exam.ExamDate)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
