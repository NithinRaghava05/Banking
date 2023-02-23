using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Services.Extensions
{
    public static class dateExtension
    {
        public static string Toddmmyyyy(this DateTime date) => date.ToString("ddMMyyyy");
    }
}
