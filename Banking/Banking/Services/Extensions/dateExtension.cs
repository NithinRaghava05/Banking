

namespace Banking.Services.Extensions
{
    public static class dateExtension
    {
        public static string Toddmmyyyy(this DateTime date) => date.ToString("ddMMyyyy");
    }
}
