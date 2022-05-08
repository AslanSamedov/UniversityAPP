using Ejournall.Models;
using Ejournall.Views.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Ejournall.Commands.Auth
{
    public abstract class BaseCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }
        
        public abstract void Execute(object? parameter);
        public void DoAnimation(ErrorDialog errorDialog)
        {
            DoubleAnimation da = new DoubleAnimation();
            CircleEase ease = new CircleEase() { EasingMode = EasingMode.EaseOut };

            TimeSpan duration = TimeSpan.FromMilliseconds(3000);

            da.From = 0;
            da.To = 50;
            da.Duration = duration;
            da.EasingFunction = ease;
            errorDialog.BeginAnimation(FrameworkElement.HeightProperty, da);

            DispatcherTimer timer = new DispatcherTimer { Interval = duration };

            timer.Tick += (sender, args) =>
            {
                da.From = 50;
                da.To = 0;
                da.Duration = TimeSpan.FromMilliseconds(1500);
                da.EasingFunction = ease;
                errorDialog.BeginAnimation(FrameworkElement.HeightProperty, da);
                timer.Stop();
            };

            timer.Start();
        }


    }
}
