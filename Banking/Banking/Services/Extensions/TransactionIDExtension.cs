

namespace Banking.Services.Extensions
{
    public static class TransactionIDExtension
    {
        public static string GenerateTransactionID(string BankID, string AccountID)
        {
            string transactoinID = "TXN" + BankID + AccountID + DateTime.Today.Toddmmyyyy();

            return transactoinID;
        }
    }
}
