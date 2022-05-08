using Ejournall.Abstraction;
using Ejournall.Core.Factories;
using Ejournall.DataAccessLayer.SqlServer;
using Ejournall.DataContext;
using Ejournall.Mapper;
using Ejournall.Models;
using Ejournall.Utils;
using Ejournall.ViewModels;
using Ejournall.Views;
using Ejournall.Views.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Ejournall
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Dispatcher.UnhandledException += HandleException;

            var connectionString = ConfigurationManager.ConnectionStrings["webConnection"].ConnectionString;
            Kernel.DB = DbFactory.CreateUnitOfWork(connectionString);
            LoginPanel loginPanel = new LoginPanel();
            LoginViewModel loginViewModel = new LoginViewModel(loginPanel,Kernel.DB);

            loginPanel.DataContext = loginViewModel;
            loginPanel.Show();
          
        }

        private void HandleException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Logger.Log(e.Exception);

            ErrorWindow error = new ErrorWindow(SystemParameters.WorkArea.Width * 0.2, SystemParameters.WorkArea.Height * 0.2, Constants.ErrorMessage);
            error.ShowDialog();
         
            e.Handled = true;
        }
    }
}
