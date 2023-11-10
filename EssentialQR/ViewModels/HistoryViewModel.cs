using EssentialQR.Models;
using MvvmHelpers;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialQR.ViewModels
{
    public class HistoryViewModel : BaseViewModel
    {
        private readonly App _currentApp;
        private ObservableCollection<CodeRecord> _codeRecords;

        public ObservableCollection<CodeRecord> CodeRecords
        {
            get { return _codeRecords; }
            set 
            {
                _codeRecords = value;
                OnPropertyChanged(nameof(CodeRecords));
            }
        }

        public HistoryViewModel()
        {
            _currentApp = (App.Current as App);
            _codeRecords = new ObservableCollection<CodeRecord>(_currentApp.SqLiteConn.GetAllWithChildren<CodeRecord>());
        }
    }
}
