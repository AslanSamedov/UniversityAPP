using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ejournall.Utils
{
    public class UserControlCaller
    {
        public static void AddUserControl(Grid grid, UserControl uc)
        {
            if (grid.Children.Count > 0)
            {
                grid.Children.Clear();
                grid.Children.Add(uc);
            }
            else
            {
                grid.Children.Add(uc);
            }
        }
    }
}
