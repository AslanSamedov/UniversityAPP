using Ejournall.DataAccessLayer.Abstraction;
using Ejournall.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ejournall.ViewModels
{
    public class BaseWindowViewModel : BaseViewModel
    {
        public readonly IUnitOfWork DB;
        public DataProvider DataProvider { get; }
        public BaseWindowViewModel(IUnitOfWork unitOfWork)
        {
            this.DB = unitOfWork;
            DataProvider = new DataProvider(DB);
        }

    }
}
