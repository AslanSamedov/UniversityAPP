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

namespace Ejournall.Commands.LessonCommands
{
    public class SaveLessonCommand : BaseCommand
    {
        private readonly LessonControlViewModel viewModel;

        public SaveLessonCommand(LessonControlViewModel viewModel)
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
            viewModel.CurrentValue.Semester = viewModel.SelectedSemesters;
            viewModel.CurrentValue.Classroom = viewModel.SelectedClassRooms;
            viewModel.CurrentValue.Subject = viewModel.SelectedSubject;
            
            if (viewModel.CurrentValue.IsValid(out string result) == false)
            {
                viewModel.Message = result;
                DoAnimation(viewModel.ErrorDialog);
                return;
            }


            LessonMapper mapper = new LessonMapper();

            var lesson = mapper.Map(viewModel.CurrentValue); 

            if (lesson.Id != 0)
            {
                viewModel.DB.LessonRepository.Update(lesson);   
            }
            else
            {
                viewModel.DB.LessonRepository.Insert(lesson);   
            }

            viewModel.Message = Constants.OperationSuccessMessage;
            DoAnimation(viewModel.ErrorDialog); 

            viewModel.AllValues = viewModel.DataProvider.GetLessons();
            viewModel.Initialize();
        }
    }
}
