using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialQR.ViewModels
{
    public class ScannerViewModel : BaseViewModel
    {
        private string lastResult;

        public string LastResult
        {
            get { return lastResult; }
            set 
            {
                lastResult = value; 
                OnPropertyChanged(nameof(LastResult));
            }
        }

        public ScannerViewModel()
        {
            
        }
        public void RegisterResult (string result)
        {
            LastResult = result;
        }
    }
}
