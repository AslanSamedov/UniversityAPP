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

namespace Ejournall.Commands.Main
{
    public class OpenTeacherCommand : BaseCommand
    {
        private readonly MainWindowViewModel viewModel;

        public OpenTeacherCommand(MainWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            Teachers teacherControl = new Teachers();
            TeacherControlViewModel teacherControlViewModel = new TeacherControlViewModel(Kernel.DB);

            teacherControlViewModel.AllValues = viewModel.DataProvider.GetTeachers();
            teacherControlViewModel.Initialize();

            teacherControlViewModel.ErrorDialog = teacherControl.ErrorDialog;

            teacherControl.DataContext = teacherControlViewModel;
            UserControlCaller.AddUserControl(viewModel.CenterGrid, teacherControl);

        }
    }
}
