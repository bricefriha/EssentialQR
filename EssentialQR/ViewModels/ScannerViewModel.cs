using EssentialQR.Models;
using MvvmHelpers;

namespace EssentialQR.ViewModels
{
    public class ScannerViewModel : BaseViewModel
    {
        private App _currentApp;
        private Command _openResultCommand;

        public Command OpenResultCommand
        {
            get { return _openResultCommand; }
        }

        private string _lastResult;

        public string LastResult
        {
            get { return _lastResult; }
            set 
            {
                _lastResult = value; 
                OnPropertyChanged(nameof(LastResult));
            }
        }

        private Timer _clearResultTimer;

        public ScannerViewModel()
        {
            _currentApp = (App.Current as App);
            _openResultCommand = new Command (() =>
            {
                if (_lastResult.StartsWith("http"))
                    Browser.OpenAsync(LastResult).Wait();
            });
        }
        /// <summary>
        /// Method to register a result
        /// </summary>
        /// <param name="result">value of the qr/bar code</param>
        public void RegisterResult (string result)
        {
            if (result == _lastResult)
                return;

            LastResult = result;
            _currentApp.SqLiteConn.Insert(new CodeRecord
            {
                Value = result,
            });

            _clearResultTimer = new Timer((e) => ClearResult(), null, TimeSpan.FromSeconds(5), Timeout.InfiniteTimeSpan);
        }
        private void ClearResult()
        {
            LastResult = string.Empty;
        }
    }
}
