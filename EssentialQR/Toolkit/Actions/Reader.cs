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
        public static void TakeAction (string value)
        {
            if (value.StartsWith("http"))
                Browser.OpenAsync(value).Wait();
        }
    }
}
