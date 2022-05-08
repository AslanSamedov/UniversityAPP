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

namespace Ejournall.Views.Windows
{
    /// <summary>
    /// Interaction logic for RegistrationPanel.xaml
    /// </summary>
    public partial class RegistrationPanel : Window
    {
        private bool IsClicked { get; set; }    
        public RegistrationPanel()
        {
            InitializeComponent();
        }

        private void btnEyeOn_Click_1(object sender, RoutedEventArgs e)
        {
            chkBoxPasswordShow.IsChecked = true;
            btnEyeOn.Visibility = Visibility.Collapsed;
            btnEyeOff.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Visible;
            psbPassword.Visibility = Visibility.Collapsed;
            txtPassword.Text = psbPassword.Password;
            IsClicked = true;
        }

        private void btnEyeOff_Click(object sender, RoutedEventArgs e)
        {
            chkBoxPasswordShow.IsChecked = false;
            btnEyeOff.Visibility = Visibility.Collapsed;
            btnEyeOn.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Collapsed;
            psbPassword.Visibility = Visibility.Visible;
            psbPassword.Password = txtPassword.Text;
            //
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
