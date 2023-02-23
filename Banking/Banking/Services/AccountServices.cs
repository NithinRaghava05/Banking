using Banking.Models;
using Banking.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Services
{
    public class AccountServices : IAccountServices
    {

        private BankingSystem bankingSystem;

        public AccountServices(  BankingSystem bankingSystem)
        {
            
            this.bankingSystem = bankingSystem;
        }

        public void Deposit(string aID, string bID)
        {
            Console.WriteLine("Enter the amount to be deposited:");
            double depositAmount = Convert.ToDouble(Console.ReadLine());
            try
            {
                bankingSystem.banks.FirstOrDefault(b => b.BankId == bID).CustomerAccounts.FirstOrDefault(a => a.AccountId == aID).Balance += depositAmount;
            }
            catch (Exception) 
            {
                Console.WriteLine("Enter a valid deposit amount");
                Deposit( aID, bID);
            }
                         
        }

        public void Transaction(string aID, string bID)
        {
            Console.WriteLine("Enter the recievers bank id");
            string? RecievingBank = Console.ReadLine();
            Console.WriteLine("Enter the account id to transfer");
            string? TransferAccount = Console.ReadLine();
            Console.WriteLine("Enter the amount to be transfered");
            double amount = Convert.ToDouble(Console.ReadLine());

            var SenderAccount = bankingSystem.banks.FirstOrDefault(b => b.BankId == bID).CustomerAccounts.FirstOrDefault(a => a.AccountId == aID);
            var RecieverAccount = bankingSystem.banks.FirstOrDefault(c => c.BankId == RecievingBank).CustomerAccounts.FirstOrDefault(d => d.AccountId == TransferAccount);
            if (SenderAccount.Balance >= amount)
            {
                SenderAccount.Balance -= amount;
                RecieverAccount.Balance += amount;
                Transaction transaction= new Transaction();
                transaction.amount = amount;

                // Creating Sender's Transaction Id
                transaction.TransactionID = TransactionIDExtension.GenerateTransactionID(bID,aID);
                transaction.SentOrRecieved = "Sent";
                SenderAccount.Transactions.Add(transaction);

                // Creating Reciever's Transaction Id
                transaction.TransactionID = TransactionIDExtension.GenerateTransactionID(RecievingBank, TransferAccount);
                transaction.SentOrRecieved = "Recieved";
                RecieverAccount.Transactions.Add(transaction);                
            }
            else
            {
                Console.WriteLine("Amount not sufficient.\n Available balance ="+SenderAccount.Balance);
                Console.WriteLine("Enter the correct amount");
                Transaction(aID, bID);
            }
        }

        public void GetTransactions(string BankId, string AccountId)
        {
            var accounts = bankingSystem.banks.FirstOrDefault(a => a.BankId == BankId).CustomerAccounts.FirstOrDefault(b => b.AccountId == AccountId).Transactions;

            for( int i = 0; i < accounts.Count; i++ )
            {
                Console.WriteLine( (i+1) + accounts[i].TransactionID + accounts[i].SentOrRecieved + accounts[i].amount );
            }
        }

        public void UpdateAccountDetails(string BankID)
        {
            var Bank = bankingSystem.banks.FirstOrDefault(a => a.BankId==BankID);
            Console.WriteLine("Enter the customer's account id");
            string? aID = Console.ReadLine();
            var account = Bank.CustomerAccounts.FirstOrDefault(b => b.AccountId == aID);
            if( account != null ) 
            {
                Console.WriteLine("Change password");
                Console.WriteLine("Enter new password");
                string? NewPassword = Console.ReadLine();
                account.Password = NewPassword;
                Console.WriteLine("Your password has been changed");
            }
            else
            {
                Console.WriteLine("Enter a valid account id");
                UpdateAccountDetails(BankID);
            }
        }

        public void DeleteAccount(string BankID)
        {
            var Bank = bankingSystem.banks.FirstOrDefault(a => a.BankId == BankID);
            Console.WriteLine("Enter the customer's account id");
            string? aID = Console.ReadLine();
            var account = Bank.CustomerAccounts.FirstOrDefault(b => b.AccountId == aID);

            if ( account != null )
            {
                Bank.CustomerAccounts.Remove(account);
                Console.WriteLine("Your account is removed");
            }
            else
            {
                Console.WriteLine("Enter a valid account id");
                DeleteAccount(BankID);
            }
        }
    }
}
