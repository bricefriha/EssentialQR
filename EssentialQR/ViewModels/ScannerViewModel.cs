using MvvmHelpers;

namespace EssentialQR.ViewModels
{
    public class ScannerViewModel : BaseViewModel
    {
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

        public ScannerViewModel()
        {
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
            LastResult = result;
        }
    }
}
