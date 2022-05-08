using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ejournall.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for SureDialog.xaml
    /// </summary>
    public partial class SureDialog : Window
    {
        public SureDialog()
        {
            InitializeComponent();
        }
        private void YesClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void NoClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
