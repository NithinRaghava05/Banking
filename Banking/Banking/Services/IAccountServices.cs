using Banking.Models;

namespace Banking.Services
{
    public interface IAccountServices
    {

        string Deposit(string accountId, string bankId, BankingSystem bankingSystem, double depositAmount);
        string Transaction(string accountId, string bankId, BankingSystem bankingSystem, string RecivingBank, string TransferAccount, double amount);
        string[] GetTransactions(string bankId, string accountId, BankingSystem bankingSystem);
        void UpdateAccountDetails(string bankId, BankingSystem bankingSystem);
        void DeleteAccount(string bankId, BankingSystem bankingSystem);
        void AddCharges(string bankId, BankingSystem bankingSystem);
        void AddChargesforDiffBank( BankingSystem bankingSystem);
        void ViewCustomerTransaction(string bankID, BankingSystem bankingSystem);
        void RevertTransaction(string bankId, BankingSystem bankingSystem);
    }
}
