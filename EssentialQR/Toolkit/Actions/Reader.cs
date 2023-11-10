using Android.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialQR.Toolkit
{
    public static class Reader
    {
        /// <summary>
        /// Take action from a given barcode/qr value
        /// </summary>
        /// <param name="value">barcode/qr value</param>
        public static void Submit (string value)
        {
            if (value.StartsWith("http"))
                Browser.OpenAsync(value).Wait();
        }
    }
}
