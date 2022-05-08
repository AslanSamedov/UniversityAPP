using Ejournall.Commands.Auth;
using Ejournall.DataAccessLayer.Abstraction;
using Ejournall.DataContext;
using Ejournall.Mapper;
using Ejournall.Models;
using Ejournall.Utils;
using Ejournall.ViewModels;
using Ejournall.Views.Controls.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Commands.Main
{
    public class OpenGroupCommand : BaseCommand
    {
        private readonly MainWindowViewModel viewModel;
        public OpenGroupCommand(MainWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            Groups groupControl = new Groups();
            GroupControlViewModel groupControlViewModel = new GroupControlViewModel(Kernel.DB);

            groupControlViewModel.AllValues = viewModel.DataProvider.GetGroups();   
            groupControlViewModel.Speciality =viewModel.DataProvider.GetSpecialties();

            groupControlViewModel.ErrorDialog = groupControl.ErrorDialog;

            groupControlViewModel.Initialize();


            groupControl.DataContext = groupControlViewModel;
            UserControlCaller.AddUserControl(viewModel.CenterGrid, groupControl);
        }
    }
}
