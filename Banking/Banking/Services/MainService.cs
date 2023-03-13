using Banking.Models;
using System.Security.Cryptography;

namespace Banking.Services
{

    public class MainService
    {
        private IBankServices bankServices;
        private IAccountServices accountServices;

        public MainService(IBankServices bankServices, IAccountServices accountServices)
        {
            this.bankServices = bankServices;
            this.accountServices = accountServices;
           
        }

        public string CreateBank(Bank bank) => bankServices.CreateBank(bank);

        public string CreateCustomerAccount(string BankID, Account account, string openingDeposit) => bankServices.CreateCustomerAccount(BankID, account, openingDeposit);
        

        public string CreateStaffAccount(string BankID, Staff staff) => bankServices.CreateStaffAccount(BankID, staff);

        public bool IsValidStaffAccount(string bankID, string accountID, string password)
        {
            return bankServices.IsValidStaffAccount(bankID, accountID, password);
        }

        public void UpdateAccountDetails(string bankID,BankingSystem bankingSystem)
        {
            accountServices.UpdateAccountDetails(bankID, bankingSystem);
        }

        public void DeleteAccount(string bankID, BankingSystem bankingSystem)
        {
            accountServices.DeleteAccount(bankID, bankingSystem);
        }

        public void AddCharges(string bankID, BankingSystem bankingSystem)
        {
            accountServices.AddCharges(bankID, bankingSystem);
        }

        public void AddChargesforDiffBank(BankingSystem bankingSystem)
        {
            accountServices.AddChargesforDiffBank(bankingSystem);
        }

        public void ViewCustomerTransaction(string bankID, BankingSystem bankingSystem)
        {
            accountServices.ViewCustomerTransaction(bankID, bankingSystem);
        }

        public void RevertTransaction(string bankID, BankingSystem bankingSystem)
        {
            accountServices.RevertTransaction(bankID, bankingSystem);
        }

        public bool IsValidAccount(string bankID, string accountID, string password)
        {
            return bankServices.IsValidAccount(bankID, accountID, password);
        }

        public string Deposit(string accountID, string bankID, BankingSystem bankingSystem, double depositAmount)
        {
            return accountServices.Deposit(accountID, bankID, bankingSystem, depositAmount);
        }

        public string Transaction(string accountID, string bankID, BankingSystem bankingSystem, string RecivingBank, string TransferAccount, double amount)
        {
            return accountServices.Transaction(accountID, bankID, bankingSystem, RecivingBank, TransferAccount, amount);
        }

        public string[] GetTransactions(string bankId, string accountID, BankingSystem bankingSystem)
        {
            return accountServices.GetTransactions(bankId, accountID, bankingSystem);
        }
    }
}
