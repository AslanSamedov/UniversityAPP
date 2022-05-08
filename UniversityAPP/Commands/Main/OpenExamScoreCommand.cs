using Ejournall.Commands.Auth;
using Ejournall.DataContext;
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
    public class OpenExamScoreCommand : BaseCommand
    {
        private readonly MainWindowViewModel viewModel;
        public OpenExamScoreCommand(MainWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            ExamScores examView = new ExamScores();

            ExamScoreViewModel examViewModel = new ExamScoreViewModel(Kernel.DB);

            examViewModel.AllValues = viewModel.DataProvider.GetExamScores();   

            examViewModel.Exams = viewModel.DataProvider.GetExams();    
            examViewModel.Students = viewModel.DataProvider.GetStudents();

            examViewModel.Initialize();

            examViewModel.ErrorDialog = examView.ErrorDialog;       

            examView.DataContext = examViewModel;
            UserControlCaller.AddUserControl(viewModel.CenterGrid,examView);
        }
    }
}
