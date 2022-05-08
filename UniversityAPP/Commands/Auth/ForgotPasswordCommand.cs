using Ejournall.Commands.Auth;
using Ejournall.Core.Entities;
using Ejournall.Core.Utils;
using Ejournall.DataAccessLayer.Abstraction;
using Ejournall.DataAccessLayer.SqlServer.Repositories;
using Ejournall.DataContext;
using Ejournall.Mapper;
using Ejournall.Models;
using Ejournall.ViewModels;
using Ejournall.ViewModels.Windows;
using Ejournall.Views.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace Ejournall.Commands.Auth
{
    public class ForgotPasswordCommand : BaseCommand
    {
        private readonly ForgotPasswordViewModel viewModel;
        private string securityCode;
        public ForgotPasswordCommand(ForgotPasswordViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            Random rd = new Random();
            var user = viewModel.User.Clone();

            string a = viewModel.window.SendCodeBtn.Content.ToString();

            if (a == "Send" || a == "Send Again")
            {
                this.securityCode = rd.Next(1000, 9999).ToString();
                bool isSended = SendEmail(user.UserName, user.Mail, securityCode);

                if (isSended)
                {
                    viewModel.window.SendCodeBtn.Content = "Okay";
                    viewModel.window.reporttxt.Text = "Please Check Your Mail Address ..";
                    viewModel.window.CodeTxtBox.IsEnabled = true;
                }
                else
                {
                    viewModel.window.SendCodeBtn.Content = "Send Again";
                }
            }
            else
            {
                string codeBox = viewModel.window.CodeTxtBox.Text.ToString();
                if (codeBox == this.securityCode)
                {
                    viewModel.window.CodeLbl.Text = "Password ";
                    viewModel.window.SendCodeBtn.Visibility = Visibility.Collapsed;
                    viewModel.window.ChangePassBtn.Visibility = Visibility.Visible;
                    viewModel.window.CodeTxtBox.Visibility = Visibility.Collapsed;
                    viewModel.window.psbPassword.Visibility = Visibility.Visible;
                    viewModel.window.reporttxt.Text = "Please Enter your Password !";
                }
                else
                {
                    viewModel.window.reporttxt.Text = "Security Code Is Wrong !!";
                }
            }
        }

        public bool SendEmail(string userName, string recip, string secCode)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential("Ejournall1@outlook.com", "donAdmin451");


                client.Port = 587;
                client.Host = "smtp.live.com";
                client.EnableSsl = true;
                message.To.Add(recip);
                message.From = new MailAddress("Ejournall1@outlook.com");
                message.Subject = $"Hi {userName}. Security Code {secCode}";
                message.Body = secCode;
                client.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
