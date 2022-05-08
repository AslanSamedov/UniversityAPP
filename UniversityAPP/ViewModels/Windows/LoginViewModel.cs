using Ejournall.Commands;
using Ejournall.Commands.Main;
using Ejournall.DataAccessLayer.Abstraction;
using Ejournall.Models;
using Ejournall.Views;
using Ejournall.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Ejournall.ViewModels
{
    public class LoginViewModel : BaseWindowViewModel
    {
        public readonly LoginPanel LoginWindow;
        public LoginViewModel(LoginPanel LoginWindow,IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.LoginWindow = LoginWindow;
        }

        #region Commands
        public LoginCommand Login => new LoginCommand(this);
        public OpenForgotPasswordCommand OpenForgotPasswordCommand => new OpenForgotPasswordCommand(this);
        public OpenRegistrationCommand OpenRegistration => new OpenRegistrationCommand(this);
        #endregion
        //
        #region Properties
        public string Username { get; set; }
        #endregion
    }
}
