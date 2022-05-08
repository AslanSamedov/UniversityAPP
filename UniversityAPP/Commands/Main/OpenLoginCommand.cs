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
    public class OpenLoginCommand : BaseCommand
    {
        private readonly RegistrationViewModel viewModel;

        public OpenLoginCommand(RegistrationViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            LoginPanel loginPanel = new LoginPanel();
            LoginViewModel loginViewModel = new LoginViewModel(loginPanel,Kernel.DB);

            loginPanel.DataContext = loginViewModel;    
            loginPanel.Show();

            viewModel.RegistrationPanel.Close();
        }
    }
}
