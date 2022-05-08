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
    public class OpenExamCommand : BaseCommand
    {
        private readonly MainWindowViewModel viewModel;
        public OpenExamCommand(MainWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            Exams examControl = new Exams();
            ExamControlViewModel examControlViewModel = new ExamControlViewModel(Kernel.DB); 

            examControlViewModel.AllValues = viewModel.DataProvider.GetExams();
            examControlViewModel.Lessons = viewModel.DataProvider.GetLessons();

            examControlViewModel.Initialize();
            examControlViewModel.ErrorDialog = examControl.ErrorDialog;
            examControl.DataContext = examControlViewModel;

            UserControlCaller.AddUserControl(viewModel.CenterGrid, examControl);
        }
    }
}
