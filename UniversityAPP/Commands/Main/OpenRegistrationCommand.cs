using Ejournall.Commands.Auth;
using Ejournall.DataContext;
using Ejournall.ViewModels;
using Ejournall.ViewModels.Windows;
using Ejournall.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Commands.Main
{
    public class OpenRegistrationCommand : BaseCommand
    {
        private readonly LoginViewModel viewModel;
        public OpenRegistrationCommand(LoginViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            RegistrationPanel registrationPanel = new RegistrationPanel();
            RegistrationViewModel registrationViewModel = new RegistrationViewModel(registrationPanel, Kernel.DB);

            registrationPanel.DataContext = registrationViewModel;
            registrationPanel.Show();

            viewModel.LoginWindow.Close();
        }
    }
}
