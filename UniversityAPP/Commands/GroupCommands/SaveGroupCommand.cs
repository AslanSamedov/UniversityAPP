using Ejournall.Commands.Auth;
using Ejournall.Enums;
using Ejournall.Mapper;
using Ejournall.Models;
using Ejournall.Utils;
using Ejournall.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Commands.GroupCommands
{
    public class SaveGroupCommand : BaseCommand
    {
        private readonly GroupControlViewModel viewModel;

        public SaveGroupCommand(GroupControlViewModel viewModel)
        {
            this.viewModel = viewModel; 
        }

        public override void Execute(object? parameter)
        {
            if (viewModel.CurrentSituation == (byte)Situations.Normal)
            {
                viewModel.CurrentSituation = (byte)Situations.ADD;
            }
            else if (viewModel.CurrentSituation == (byte)Situations.SELECTED)
            {
                viewModel.SelectedSpeciality = viewModel.SelectedValue.Speciality;
                viewModel.CurrentSituation = (byte)Situations.EDIT;
            }
            else if (viewModel.CurrentSituation == (byte)Situations.ADD ||
                    viewModel.CurrentSituation == (byte)Situations.EDIT)
            {
                Save();
            }
        }

        private void Save()
        {
            viewModel.CurrentValue.Speciality = viewModel.SelectedSpeciality;

            if (viewModel.CurrentValue.IsValid(out string message) != true)
            {
                viewModel.Message = message;
                DoAnimation(viewModel.ErrorDialog);
                return;
            }

            GroupMapper groupMapper = new GroupMapper();

            var group = groupMapper.Map(viewModel.CurrentValue);

            if (group.Id != 0)
            {
                viewModel.DB.GroupRepository.Update(group);
            }
            else
            {
                viewModel.DB.GroupRepository.Insert(group);
            }

            viewModel.Message = Constants.OperationSuccessMessage;
            DoAnimation(viewModel.ErrorDialog);

            viewModel.AllValues = viewModel.DataProvider.GetGroups();
            viewModel.Initialize();
        }
    }
}
