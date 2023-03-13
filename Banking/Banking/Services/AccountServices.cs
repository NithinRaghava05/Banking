using Banking.Models;
using Banking.Services.Extensions;

namespace Banking.Services
{
    public class AccountServices : IAccountServices
    {

        public string Deposit(string aID, string bID, BankingSystem bankingSystem, double depositAmount)
        {   
            try
            {  

                List<Account> CustomerAccounts = new List<Account>();
                Bank Bank = bankingSystem.banks.FirstOrDefault(b => b.BankId == bID)!;
                Account Account = Bank.CustomerAccounts.Where(a => a.AccountId == aID).FirstOrDefault()!;
                Account.Balance += depositAmount;
                
                Transaction transaction = new Transaction();

                transaction.TransactionID = TransactionIDExtension.GenerateTransactionID(bID,aID);
                transaction.amount = depositAmount;
                transaction.SentOrRecieved = "Deposit";

                Account.Transactions.Add(transaction);

                return "Amount Deposited";
            }
            catch (Exception) 
            {
                return "Enter a valid deposit amount";
            }
                    
        }

        public string Transaction(string aID, string bID, BankingSystem bankingSystem, string RecievingBank, string TransferAccount, double amount)
        {
            var SenderAccount = bankingSystem.banks.FirstOrDefault(b => b.BankId == bID)!.CustomerAccounts.FirstOrDefault(a => a.AccountId == aID)!;
            var RecieverAccount = bankingSystem.banks.FirstOrDefault(c => c.BankId == RecievingBank)!.CustomerAccounts.FirstOrDefault(d => d.AccountId == TransferAccount)!;
            if (SenderAccount.Balance >= amount)
            {
                SenderAccount.Balance -= amount;
                RecieverAccount.Balance += amount;
                Transaction transaction = new Transaction();
                transaction.amount = amount;

                // Creating Sender's Transaction Id
                transaction.TransactionID = TransactionIDExtension.GenerateTransactionID(bID, aID);
                transaction.SentOrRecieved = "Sent";
                SenderAccount.Transactions.Add(transaction);

                // Creating Reciever's Transaction Id
                transaction.TransactionID = TransactionIDExtension.GenerateTransactionID(RecievingBank, TransferAccount);
                transaction.SentOrRecieved = "Recieved";
                RecieverAccount.Transactions.Add(transaction);

                return "transaction successful";
            }
            else
            {
                return "Amount not sufficient.\n Available balance =" + SenderAccount.Balance;
            }
        }

        public string[] GetTransactions(string BankId, string AccountId, BankingSystem bankingSystem)
        {
            var accounts = bankingSystem.banks.FirstOrDefault(a => a.BankId == BankId)!.CustomerAccounts.FirstOrDefault(b => b.AccountId == AccountId)!.Transactions!;
            string[] transactionList = new string[accounts.Count];
            for( int i = 0; i < accounts.Count; i++ )
            {
                string x = i+1 . ToString();
                string y = accounts[i].amount .ToString();
                transactionList.Append( x + accounts[i].TransactionID + accounts[i].SentOrRecieved + y);
            }
            return transactionList;
        }

        public void UpdateAccountDetails(string BankID, BankingSystem bankingSystem)
        {
            try
            {
                var Bank = bankingSystem.banks.FirstOrDefault(a => a.BankId == BankID)!;
                Console.WriteLine("Enter the customer's account id");
                string? aID = Console.ReadLine();
                var account = Bank.CustomerAccounts.FirstOrDefault(b => b.AccountId == aID);
                if (account != null)
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
                    UpdateAccountDetails(BankID, bankingSystem);
                }
            }
            catch (Exception) 
            { 
                Console.WriteLine("Re-enter");
                UpdateAccountDetails(BankID, bankingSystem);
            }
        }

        public void DeleteAccount(string BankID, BankingSystem bankingSystem)
        {
            try
            {
                var Bank = bankingSystem.banks.FirstOrDefault(a => a.BankId == BankID)!;
                Console.WriteLine("Enter the customer's account id");
                string? aID = Console.ReadLine();
                var account = Bank.CustomerAccounts.FirstOrDefault(b => b.AccountId == aID);

                if (account != null)
                {
                    Bank.CustomerAccounts.Remove(account);
                    Console.WriteLine("Your account is removed");
                }
                else
                {
                    Console.WriteLine("Enter a valid account id");
                    DeleteAccount(BankID, bankingSystem);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Re-enter");
                DeleteAccount(BankID, bankingSystem);
            }
        }

        public void AddCharges(string BankID, BankingSystem bankingSystem)
        {
            try
            {

                var Bank = bankingSystem.banks.FirstOrDefault(a => a.BankId == BankID)!;
                Console.WriteLine("Press 1 for changing RGST and 2 for IMPS");
                int opt = Convert.ToInt32(Console.ReadLine());

                if (opt == 1)
                {
                    Console.WriteLine("Enter the new RTGS value");
                    int newRTGS = Convert.ToInt32(Console.ReadLine());
                    Bank.RTGS = newRTGS;
                }
                else if (opt == 2)
                {
                    Console.WriteLine("Enter the new IMPS value");
                    int newIMPS = Convert.ToInt32(Console.ReadLine());
                    Bank.IMPS = newIMPS;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    AddCharges(BankID, bankingSystem);
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Re-enter");
                AddCharges(BankID, bankingSystem);
            }
        }

        public void AddChargesforDiffBank(BankingSystem bankingSystem)
        {
            try
            {
                Console.WriteLine("Enter the bank id");
                string? BankId = Console.ReadLine();
                var Bank = bankingSystem.banks.FirstOrDefault(a => a.BankId == BankId)!;

                Console.WriteLine("Press 1 for changing RGST and 2 for IMPS");
                int opt = Convert.ToInt32(Console.ReadLine());

                if (opt == 1)
                {
                    Console.WriteLine("Enter the new RTGS value");
                    int newRTGS = Convert.ToInt32(Console.ReadLine());
                    Bank.RTGS = newRTGS;
                }
                else if (opt == 2)
                {
                    Console.WriteLine("Enter the new IMPS value");
                    int newIMPS = Convert.ToInt32(Console.ReadLine());
                    Bank.IMPS = newIMPS;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    AddChargesforDiffBank(bankingSystem);
                }
            }
            catch(Exception) 
            {
                Console.WriteLine("Re-enter");
                AddChargesforDiffBank(bankingSystem);
            }
        }   

        public void ViewCustomerTransaction( string? BankId, BankingSystem bankingSystem)
        {
            try
            {
                Console.WriteLine("Enter your account id");
                string? AccountId = Console.ReadLine();

                var Bank = bankingSystem.banks.FirstOrDefault(a => a.BankId == BankId)!;
                var Account = Bank.CustomerAccounts.FirstOrDefault(b => b.AccountId == AccountId)!;

                for (int i = 0; i < Account.Transactions.Count; i++)
                {
                    Console.WriteLine(i + 1 + Account.Transactions[i].TransactionID + Account.Transactions[i].SentOrRecieved + Account.Transactions[i].amount);
                }
            }
            catch( Exception ) 
            {
                Console.WriteLine("Re-enter");
                ViewCustomerTransaction(BankId, bankingSystem); 
            }
        }

        public void RevertTransaction(string? BankId, BankingSystem bankingSystem)
        {
            try
            {
                Console.WriteLine("Enter your account id");
                string? AccountId = Console.ReadLine();

                Console.WriteLine("Enter the second account's bank id");
                string? BankId1 = Console.ReadLine();
                Console.WriteLine("Enter the second account id");
                string? AccountId1 = Console.ReadLine();

                var Bank = bankingSystem.banks.FirstOrDefault(a => a.BankId == BankId)!;
                var Account = Bank.CustomerAccounts.FirstOrDefault(b => b.AccountId == AccountId)!;

                var Bank1 = bankingSystem.banks.FirstOrDefault(c => c.BankId == BankId1)!;
                var Account1 = Bank1.CustomerAccounts.FirstOrDefault(d => d.AccountId == AccountId1)!;

                Console.WriteLine("Enter the transaction id to be reverted");
                string? TransactionID = Console.ReadLine();

                var Transaction = Account.Transactions.FirstOrDefault(e => e.TransactionID == TransactionID)!;
                var Transaction1 = Account1.Transactions.FirstOrDefault(f => f.TransactionID == TransactionID)!;

                if (Transaction!.SentOrRecieved == "Sent")
                {
                    Account.Balance += Transaction.amount;
                    Account1.Balance -= Transaction.amount;
                }
                else if (Transaction.SentOrRecieved == "Recieved" || Transaction.SentOrRecieved == "Deposit")
                {
                    Account.Balance -= Transaction.amount;
                    Account1.Balance += Transaction.amount;
                }
                Account.Transactions.Remove(Transaction);
                Account1.Transactions.Remove(Transaction1);

            }
            catch ( Exception )
            {
                Console.WriteLine("Re-enter");
                RevertTransaction(BankId, bankingSystem);
            }

        }
    }
}
