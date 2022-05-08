using Ejournall.Commands.Auth;
using Ejournall.Core.Entities;
using Ejournall.DataContext;
using Ejournall.Models;
using Ejournall.Utils;
using Ejournall.ViewModels;
using Ejournall.ViewModels.Controls;
using Ejournall.Views.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Commands.Main
{
    public class OpenLessonCommand : BaseCommand
    {
        private readonly MainWindowViewModel viewModel;
        public OpenLessonCommand(MainWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            Lessons lessonView = new Lessons();

            LessonControlViewModel lessoncontrolViewModel = new LessonControlViewModel(Kernel.DB);

            lessoncontrolViewModel.AllValues = viewModel.DataProvider.GetLessons();
            lessoncontrolViewModel.Groups = viewModel.DataProvider.GetGroups();
            lessoncontrolViewModel.ClassRooms = viewModel.DataProvider.GetClassRooms(); 
            lessoncontrolViewModel.Semesters = viewModel.DataProvider.GetSemesters();
            lessoncontrolViewModel.Subjects = viewModel.DataProvider.GetTeacherSubjects();

            lessoncontrolViewModel.Initialize();

            lessoncontrolViewModel.ErrorDialog = lessonView.ErrorDialog;

            lessonView.DataContext = lessoncontrolViewModel;

            UserControlCaller.AddUserControl(viewModel.CenterGrid, lessonView);
        }
    }
}
