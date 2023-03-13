using Banking.Models;
using Banking.Services.Extensions;
using System.Security.Principal;

namespace Banking.Services
{
    public class BankServices : IBankServices
    {
        private BankingSystem bankingSystem = new BankingSystem();
        private Bank bank = new Bank();
        private AccountServices accountServices = new AccountServices();

        public BankServices(AccountServices accountServices, Bank bank) 
        {

            this.accountServices = accountServices;
            this.bank = bank;
        }

        public BankServices(BankingSystem bankingSystem)
        {
            this.bankingSystem = bankingSystem;
        }

        public string CreateBank(Bank bank)
        {  
            bankingSystem.banks.Add(bank);
            return "Your bank has been created. ID :" + bank.BankId;
            
        }

        public string CreateStaffAccount(string? BankID, Staff staff)
        {
            bankingSystem.banks.FirstOrDefault(a => a.BankId == BankID)!.StaffAccounts.Add(staff);

            return "Your id is:" + staff.StaffId + "\nYour password is:" + staff.Password ;


        }
        public string CreateCustomerAccount(string BankID, Account account, string openingDeposit)
        {
            bankingSystem.banks.FirstOrDefault(a => a.BankId == BankID)!.CustomerAccounts.Add(account);
            account.Balance = 0;
            if (openingDeposit.ToLower() == "true")
            {
                Console.WriteLine("Enter the amount to be deposited:");
                double depositAmount = Convert.ToDouble(Console.ReadLine());
                accountServices.Deposit(account.AccountId, BankID, bankingSystem, depositAmount);
            }
            return "Your id is:" + account.AccountId + "\nYour password is:" + account.Password;
        }

        
        public bool IsValidAccount(string? bId, string? aId, string? password)
        {   
            var acc = bankingSystem.banks.FirstOrDefault(b => b.BankId == bId)!.CustomerAccounts.FirstOrDefault(a => a.AccountId == aId) !;
            if (acc.Password == password)
            {
                return true;
            }
            return false;
        }

        public bool IsValidStaffAccount(string? bId, string? sId, string? password)
        {
            var acc = bankingSystem.banks.FirstOrDefault(b => b.BankId == bId)!.StaffAccounts.FirstOrDefault(a => a.StaffId == sId)!;
            if (acc.Password == password)
            {
                return true;
            }
            return false;
        }
    }
}
