using Ejournall.Commands;
using Ejournall.DataAccessLayer.Abstraction;
using Ejournall.DataContext;
using Ejournall.Enums;
using Ejournall.Models;
using Ejournall.Utils;
using Ejournall.Views.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Ejournall.ViewModels
{
    public abstract class BaseControlViewModel<T> : BaseViewModel where T : BaseModel <T> , new ()
    {
        public readonly IUnitOfWork DB;
        public DataProvider DataProvider { get; }
        public BaseControlViewModel(IUnitOfWork unitOfWork)
        {
            this.DB = unitOfWork;
            DataProvider = new DataProvider(DB);
        }

        #region Properties
        private byte currentSituation = (byte)Situations.Normal;
        public byte CurrentSituation
        {
            get => currentSituation;
            set
            {
                currentSituation = value;
                OnPropertyChanged(nameof(CurrentSituation));
            }
        }

        public List<T> AllValues { get; set; }

        private ObservableCollection<T> values = new ObservableCollection<T>();
        public ObservableCollection<T> Values
        {
            get { return values; }
            set
            {
                values = value;
                OnPropertyChanged(nameof(Values));
            }
        }


        private T selectedValue;
        public T SelectedValue
        {
            get
            {
                return selectedValue;
            }
            set
            {
                selectedValue = value;
                CurrentValue = selectedValue?.Clone();
                CurrentSituation = SelectedValue != null ? (byte)Situations.SELECTED : (byte)Situations.Normal;
                OnPropertyChanged(nameof(SelectedValue));
            }
        }


        private T currentValue;
        public T CurrentValue
        {
            get { return currentValue; }
            set
            {
                currentValue = value;
                OnPropertyChanged(nameof(CurrentValue));
            }
        }


        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnSearch();
            }
        }
        #endregion
        //
        #region Methods
        public void Initialize()
        {
            Values = new ObservableCollection<T>(AllValues);
            CurrentSituation = (byte)Situations.Normal;
            CurrentValue = new T();
        }

        public abstract void OnSearch();
        protected bool IsCompatibleWithValue(string value)
        {
            if (value != null && value.ToLower().Contains(SearchText.ToLower()))
            {
                return true;
            }

            return false;
        }
        protected void OnSelectedValueChange()
        {
            
        }
        #endregion
        //
        #region Dialog
        private string message;
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
                OnPropertyChanged(nameof(TextColor));
            }
        }
        public Brush TextColor => Message == Constants.OperationSuccessMessage ? Brushes.White : Brushes.Red;
        public ErrorDialog ErrorDialog { get; set; }

        #endregion
    }
}
