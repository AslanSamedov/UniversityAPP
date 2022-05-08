using Ejournall.Commands.Auth;
using Ejournall.DataAccessLayer.Abstraction;
using Ejournall.Models;
using Ejournall.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.ViewModels.Windows
{
    public class ForgotPasswordViewModel : BaseWindowViewModel
    {
        public readonly ForgotPasswordWindow window;
        public ForgotPasswordViewModel(ForgotPasswordWindow window, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.window = window;
        }

        private UserModel user { get; set; }
        public UserModel User
        {
            get { return user; }
            set { 
                user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        public string Username { get; set; }
        public ForgotPasswordCommand forgotCommand => new ForgotPasswordCommand(this);
        public ChangeUserPasswordCommand ChangeUserPasswordCommand => new ChangeUserPasswordCommand(this);
    }
}
