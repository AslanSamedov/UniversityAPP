using Ejournall.Commands.Auth;
using Ejournall.Enums;
using Ejournall.Models;
using Ejournall.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Commands
{
    public class RejectCommand<T> : BaseCommand where T : BaseModel<T> , new()
    {
        private readonly BaseControlViewModel<T> viewModel;

        public RejectCommand(BaseControlViewModel<T> viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            viewModel.SelectedValue = null;
            viewModel.CurrentValue = new T();
        }
    }
}
