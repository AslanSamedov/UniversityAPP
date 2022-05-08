using Ejournall.Commands.Auth;
using Ejournall.Core.Entities;
using Ejournall.Core.Utils;
using Ejournall.DataAccessLayer.Abstraction;
using Ejournall.DataAccessLayer.SqlServer.Repositories;
using Ejournall.DataContext;
using Ejournall.Mapper;
using Ejournall.Utils;
using Ejournall.ViewModels;
using Ejournall.ViewModels.Windows;
using Ejournall.Views.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Ejournall.Commands.Auth
{
    public class ChangeUserPasswordCommand : BaseCommand
    {
        private readonly ForgotPasswordViewModel viewModel;
        public ChangeUserPasswordCommand(ForgotPasswordViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            if (viewModel.window.psbPassword.Password != null)
            {
                string password = viewModel.window.psbPassword.Password;
                string passwordHash = SecurityUtil.ComputeSha256Hash(password);

                UserMapper mapper = new UserMapper();

                viewModel.User.PasswordHash = passwordHash;
                var entity = mapper.Map(viewModel.User);
                viewModel.DB.UserRepository.UpdatePassword(entity);
                ErrorWindow error = new ErrorWindow(200,300,Constants.OperationSuccessMessage);
                error.ShowDialog();
                viewModel.window.Close();
            }
        }
    }
}
