using Banking.Models;
using Banking.Services.Extensions;

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
        public void CreateCustomerAccount()
        {
            try
            {
                Console.WriteLine("Please Enter the bank id you want to open an account in");
                string? BankID = Console.ReadLine()!;
                Account account = new Account();
                Console.WriteLine("Enter Account holder's name:");
                string? holderName = Console.ReadLine()!;
                account.AccountId = holderName.Substring(0, 3) + DateTime.Today.Toddmmyyyy();
                Console.WriteLine("Enter a password");
                account.Password = Console.ReadLine();
                Console.WriteLine("Enter true if you want to make an opening deposit else false");
                bankingSystem.banks.FirstOrDefault(a => a.BankId == BankID)!.CustomerAccounts.Add(account);
                string? openingDeposit = Console.ReadLine();
                account.Balance = 0;
                if (openingDeposit == "true" || openingDeposit == "True")
                {
                    accountServices.Deposit(account.AccountId, BankID, bankingSystem);
                }
                else
                {
                    account.Balance = 0;
                }
                Console.WriteLine("Your id is:" + account.AccountId + "\nYour password is:" + account.Password);
            }
            catch (Exception) 
            {
                Console.WriteLine("Re-enter");
                CreateCustomerAccount();
            }
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
        public void CustomerLogin()
        {
            try
            {
                Console.WriteLine("Enter your bank id");
                string? bID = Console.ReadLine()!;
                Console.WriteLine("Enter your account id");
                string? ID = Console.ReadLine()!;
                Console.WriteLine("Enter your account password");
                string? PW = Console.ReadLine()!;

                bool Stop = false;
                if (IsValidAccount(bID, ID, PW))
                {
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Make a transaction");
                    Console.WriteLine("3. Show my transactions");
                    Console.WriteLine("4. View Balance");
                    Console.WriteLine("5. Exit");
                    while (!Stop)
                    {
                        Console.WriteLine("Select your option");
                        int option = Convert.ToInt32(Console.ReadLine());

                        switch (option)
                        {
                            case 1:
                                accountServices.Deposit(ID, bID, bankingSystem);
                                break;
                            case 2:
                                accountServices.Transaction(ID, bID, bankingSystem);
                                break;
                            case 3:
                                accountServices.GetTransactions(bID, ID, bankingSystem);
                                break;
                            case 4:
                                Console.WriteLine("Your account balance is:" + bankingSystem.banks.FirstOrDefault(a => a.BankId == bID)!.CustomerAccounts.FirstOrDefault(b => b.AccountId == ID)!.Balance);
                                break;
                            case 5:
                                Stop = true;
                                break;
                            default:
                                Console.WriteLine("Enter a valid option");
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Account. Please Re-enter");
                    CustomerLogin();
                }
            }
            catch (Exception) 
            {
                Console.WriteLine("Re-enter");
                CustomerLogin();
            }
        }

        public void StaffLogin()
        {
            try
            {
                Console.WriteLine("Enter your bank id");
                string? bID = Console.ReadLine()!;
                Console.WriteLine("Enter your account id");
                string? ID = Console.ReadLine()!;
                Console.WriteLine("Enter your account password");
                string? PW = Console.ReadLine()!;

                bool Stop = false;
                if (IsValidStaffAccount(bID, ID, PW))
                {
                    Console.WriteLine("1. Create a customer account");
                    Console.WriteLine("2. Update account details");
                    Console.WriteLine("3. Delete an account");
                    Console.WriteLine("4. Add service charges");
                    Console.WriteLine("5. Add charges for a bank");
                    Console.WriteLine("6. View customer's account transaction history");
                    Console.WriteLine("7. Revert a transaction");

                    while (!Stop)
                    {
                        Console.WriteLine("Select an option");
                        int Option = Convert.ToInt32(Console.ReadLine());
                        switch (Option)
                        {
                            case 1:
                                CreateCustomerAccount();
                                break;
                            case 2:
                                accountServices.UpdateAccountDetails(bID, bankingSystem);
                                break;
                            case 3:
                                accountServices.DeleteAccount(bID, bankingSystem);
                                break;
                            case 4:
                                accountServices.AddCharges(bID, bankingSystem);
                                break;
                            case 5:
                                accountServices.AddChargesforDiffBank(bankingSystem);
                                break;
                            case 6:
                                accountServices.ViewCustomerTransaction(bID, bankingSystem);
                                break;
                            case 7:
                                accountServices.RevertTransaction(bID, bankingSystem);
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Account");
                    StaffLogin();
                }
            }
            catch (Exception) 
            {
                Console.WriteLine("Re-enter");
            }
        }
    }
}
