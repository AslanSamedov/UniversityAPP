using Ejournall.Commands.Auth;
using Ejournall.Core.Entities;
using Ejournall.DataAccessLayer.Abstraction;
using Ejournall.DataContext;
using Ejournall.Mapper;
using Ejournall.Models;
using Ejournall.Utils;
using Ejournall.ViewModels;
using Ejournall.ViewModels.Windows;
using Ejournall.Views.Controls.UserControls;
using Ejournall.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ejournall.Commands.Main
{
    public class OpenForgotPasswordCommand : BaseCommand
    {
        private readonly LoginViewModel viewModel;
        public OpenForgotPasswordCommand(LoginViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            ForgotPasswordWindow forgotPasswordWindow = new ForgotPasswordWindow();
            ForgotPasswordViewModel forgotPasswordViewModel = new ForgotPasswordViewModel(forgotPasswordWindow, Kernel.DB);

            forgotPasswordViewModel.Username = viewModel.Username;
            User user = forgotPasswordViewModel.DB.UserRepository.GetUserByUsername(forgotPasswordViewModel.Username);

            if (user == null)
            {
                MessageBox.Show("Invalid Username!");
                return;
            }

            UserMapper mapper = new UserMapper();
            forgotPasswordViewModel.User = mapper.Map(user);
           
            forgotPasswordWindow.DataContext = forgotPasswordViewModel;
            forgotPasswordWindow.Show();
        }
    }
}
