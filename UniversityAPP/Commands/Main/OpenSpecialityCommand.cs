using Ejournall.Commands.Auth;
using Ejournall.DataAccessLayer.Abstraction;
using Ejournall.DataContext;
using Ejournall.Mapper;
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
    public class OpenSpecialityCommand : BaseCommand
    {
        private readonly MainWindowViewModel viewModel;

        public OpenSpecialityCommand(MainWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            Specialities specialityControl = new Specialities();
            SpecialityControlViewModel specialityControlViewModel = new SpecialityControlViewModel(Kernel.DB);

            specialityControlViewModel.AllValues = viewModel.DataProvider.GetSpecialties();
            specialityControlViewModel.Faculties = viewModel.DataProvider.GetFaculties();

            specialityControlViewModel.Initialize();
            specialityControlViewModel.ErrorDialog = specialityControl.ErrorDialog;
            specialityControl.DataContext = specialityControlViewModel;

            UserControlCaller.AddUserControl(viewModel.CenterGrid, specialityControl);

        }
    }
}
