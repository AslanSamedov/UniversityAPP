using Ejournall.Commands.Auth;
using Ejournall.Commands.Main;
using Ejournall.DataAccessLayer.Abstraction;
using Ejournall.DataContext;
using Ejournall.Models;
using Ejournall.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.ViewModels.Windows
{
    public class RegistrationViewModel : BaseWindowViewModel
    {
        public RegistrationPanel RegistrationPanel { get; }

        public RegistrationViewModel(RegistrationPanel registrationPanel, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.RegistrationPanel = registrationPanel;
        }

        public UserModel User { get; set; } = new UserModel();
        public string Meessage { get; set; }

        public RegistrationCommand Registration => new RegistrationCommand(this);
        public OpenLoginCommand OpenLogin => new OpenLoginCommand(this);

    }
}
