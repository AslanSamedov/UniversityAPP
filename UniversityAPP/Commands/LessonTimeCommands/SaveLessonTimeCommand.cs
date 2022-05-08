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

namespace Ejournall.Commands.LessonTimeCommands
{
    public class SaveLessonTimeCommand : BaseCommand
    {
        private readonly LessonTimeControlViewModel viewModel;

        public SaveLessonTimeCommand(LessonTimeControlViewModel viewModel)
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
            if (IsExists(viewModel.CurrentValue) == false)
            {
                viewModel.Message = "This Data Already Exists";
                DoAnimation(viewModel.ErrorDialog);
                return;
            }
           
            LessonTimeMapper mapper = new LessonTimeMapper();

            var lessonTime = mapper.Map(viewModel.CurrentValue);

            if (lessonTime.Id != 0)
            {
                viewModel.DB.LessonTimeRepository.Update(lessonTime);
            }
            else
            {
                viewModel.DB.LessonTimeRepository.Insert(lessonTime);
            }

            viewModel.Message = Constants.OperationSuccessMessage;
            DoAnimation(viewModel.ErrorDialog);

            viewModel.AllValues = viewModel.DataProvider.GetLessonTimes();
            viewModel.Initialize();
        }
        public bool IsExists(LessonTimeModel lessonTime)
        {
            List<LessonTimeModel> list = viewModel.AllValues;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Lesson.Group.Name == lessonTime.Lesson.Group.Name && list[i].StartTime == lessonTime.StartTime &&
                    list[i].Lesson.Subject.Subject.Name == lessonTime.Lesson.Subject.Subject.Name)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
