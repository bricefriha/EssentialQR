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
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public ScannerViewModel()
        {
        }
    }
}
