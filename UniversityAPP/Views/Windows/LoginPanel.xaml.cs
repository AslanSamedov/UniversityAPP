using Ejournall.DataContext;
using Ejournall.ViewModels;
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
    /// Interaction logic for LoginPanel.xaml
    /// </summary>
    public partial class LoginPanel : Window
    {
        private bool IsCliked { get; set; }

        public LoginPanel()
        {
            InitializeComponent();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginPanel loginPanel = new LoginPanel();
            LoginViewModel viewModel = new LoginViewModel(loginPanel, Kernel.DB);
            viewModel.Username = UserText.Text;

            if (IsCliked == true)
            {
                psbPassword.Password = txtPassword.Text;
            }

            viewModel.Login.Execute(this.psbPassword);
            this.Close();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void BtnMinimizeClickEvent(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnCloseClickEvent(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEyeOff_Click_1(object sender, RoutedEventArgs e)
        {
            chkBoxPasswordShow.IsChecked = false;
            btnEyeOff.Visibility = Visibility.Collapsed;
            btnEyeOn.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Collapsed;
            psbPassword.Visibility = Visibility.Visible;
            psbPassword.Password = txtPassword.Text;
            //
        }

        private void btnEyeOn_Click_1(object sender, RoutedEventArgs e)
        {
            chkBoxPasswordShow.IsChecked = true;
            btnEyeOn.Visibility = Visibility.Collapsed;
            btnEyeOff.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Visible;
            psbPassword.Visibility = Visibility.Collapsed;
            txtPassword.Text = psbPassword.Password;
            IsCliked = true;
            //
        }

       
    }
}
