using Ejournall.Commands.Auth;
using Ejournall.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejournall.Views.Controls.UserControls;
using Ejournall.Mapper;
using Ejournall.Models;
using Ejournall.Views.Controls;
using Ejournall.DataContext;
using Ejournall.Utils;
using Ejournall.ViewModels.Controls;

namespace Ejournall.Commands.Main
{
    public class OpenLessonTimeCommand : BaseCommand
    {
        private readonly MainWindowViewModel viewModel;
        public OpenLessonTimeCommand(MainWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            LessonTimes lessonTimeControl = new LessonTimes();
            LessonTimeControlViewModel examControlViewModel = new LessonTimeControlViewModel(Kernel.DB);

            examControlViewModel.AllValues = viewModel.DataProvider.GetLessonTimes();
            examControlViewModel.Lessons = viewModel.DataProvider.GetLessons();

            examControlViewModel.Initialize();
            examControlViewModel.ErrorDialog = lessonTimeControl.ErrorDialog;
            lessonTimeControl.DataContext = examControlViewModel;

            UserControlCaller.AddUserControl(viewModel.CenterGrid, lessonTimeControl);
        }
    }

}
