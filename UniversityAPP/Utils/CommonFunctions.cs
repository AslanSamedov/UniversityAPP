using Ejournall.ViewModels.Dialogs;
using Ejournall.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Utils
{
    public class CommonFunctions
    {
        public static bool MakeSure(string message)
        {
            SureDialogViewModel dialogViewModel = new SureDialogViewModel();

            dialogViewModel.DialogText = message;

            SureDialog dialog = new SureDialog();

            dialog.DataContext = dialogViewModel;

            return dialog.ShowDialog() == true;
        }

        public static bool MakeDeleteSure()
        {
            return MakeSure(Constants.SureDeleteMessage);
        }
    }
}
