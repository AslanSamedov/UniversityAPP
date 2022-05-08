using Ejournall.Core.Utils;
using Ejournall.DataContext;
using Ejournall.Mapper;
using Ejournall.Models;
using Ejournall.ViewModels;
using Ejournall.ViewModels.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Ejournall.Commands.Auth
{
    public class RegistrationCommand : BaseCommand
    {
        private readonly RegistrationViewModel viewModel;
        private  string connectionFailedMessage;
        public RegistrationCommand(RegistrationViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            PasswordBox? psbBox = parameter as PasswordBox;

            if (psbBox == null)
            {
                return;
            }

            string password = psbBox.Password;

            string passwordHash = SecurityUtil.ComputeSha256Hash(password);

            Validator validator = new Validator(Kernel.DB);

            if (validator.ValidateUser(viewModel.User, out string message) == false)
            {
                MessageBox.Show("This Mail Address Not Found :( Sorry");
                return;
            }

            viewModel.User.PasswordHash = passwordHash;

            UserMapper mapper = new UserMapper();

            var user = mapper.Map(viewModel.User);  

            viewModel.DB.UserRepository.Insert(user);


            viewModel.OpenLogin.Execute(this.viewModel);
        }
    }
}
