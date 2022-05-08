using Ejournall.Commands.Auth;
using Ejournall.DataAccessLayer.Abstraction;
using Ejournall.DataContext;
using Ejournall.Mapper;
using Ejournall.Models;
using Ejournall.Utils;
using Ejournall.ViewModels;
using Ejournall.Views.Controls.UserControls;
using Ejournall.Views.Controls.UserControls.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Commands.Main
{
    public class OpenStudentCommand : BaseCommand
    {
        private readonly MainWindowViewModel viewModel;
        public OpenStudentCommand(MainWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            StudenCRUD studentControl = new StudenCRUD();
            StudentControlViewModel studentControlViewModel = new StudentControlViewModel(Kernel.DB);

            studentControlViewModel.AllValues = viewModel.DataProvider.GetStudents();
            studentControlViewModel.Groups = viewModel.DataProvider.GetGroups();

            studentControlViewModel.Initialize();

            studentControlViewModel.ErrorDialog = studentControl.ErrorDialog;

            studentControl.DataContext = studentControlViewModel;
            UserControlCaller.AddUserControl(viewModel.CenterGrid, studentControl);
        }
    }
}
