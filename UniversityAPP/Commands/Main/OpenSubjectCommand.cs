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
    public class OpenSubjectCommand : BaseCommand
    {
        private readonly MainWindowViewModel viewModel;
        public OpenSubjectCommand(MainWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            Subjects subjectControl = new Subjects();
            SubjectControlViewModel subjectControlViewModel = new SubjectControlViewModel(Kernel.DB);

            subjectControlViewModel.AllValues = viewModel.DataProvider.GetSubjects();
            subjectControlViewModel.Initialize();

            subjectControlViewModel.ErrorDialog = subjectControl.ErrorDialog;

            subjectControl.DataContext = subjectControlViewModel;
            UserControlCaller.AddUserControl(viewModel.CenterGrid, subjectControl);
        }
    }
}
