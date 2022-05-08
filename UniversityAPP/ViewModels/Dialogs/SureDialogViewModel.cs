using Ejournall.DataAccessLayer.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.ViewModels.Dialogs
{
    public class SureDialogViewModel : BaseViewModel
    {
        private string dialogText;
        public string DialogText
        {
            get => dialogText;
            set
            {
                dialogText = value;
                OnPropertyChanged(nameof(DialogText));
            }
        }
    }
}
