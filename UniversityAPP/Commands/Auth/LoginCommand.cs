using Ejournall.Commands.Auth;
using Ejournall.Core.Entities;
using Ejournall.Core.Utils;
using Ejournall.DataAccessLayer.Abstraction;
using Ejournall.DataAccessLayer.SqlServer.Repositories;
using Ejournall.DataContext;
using Ejournall.ViewModels;
using Ejournall.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Ejournall.Commands
{
    public class LoginCommand : BaseCommand
    {
        private readonly LoginViewModel viewModel;

        public LoginCommand(LoginViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            PasswordBox? psbBox = parameter as PasswordBox;

            if (psbBox == null)
                return;

            string password = psbBox.Password;

            User user = viewModel.DB.UserRepository.GetUserByUsername(viewModel.Username);
           
            if (user == null)
            {
                psbBox.Password = null;
                return;
            }

            string passwordHash = SecurityUtil.ComputeSha256Hash(password);

            if (passwordHash == user.PasswordHash)
            {
                MainWindowViewModel mainViewModel = new MainWindowViewModel(Kernel.DB);
                MainWindow mainWindow = new MainWindow();
                mainWindow.DataContext = mainViewModel;

                mainViewModel.CenterGrid = mainWindow.Content;

                mainWindow.Show();
                viewModel.LoginWindow.Close();
            }
            else
            {
                psbBox.Password = null;
            }
        }

    } 
}
