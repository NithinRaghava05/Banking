using Banking.Models;
using Banking.Services;
using Banking.Services.Extensions;
using System.Security.Cryptography;


namespace Banking
{
    class Banking
    {   
        public static void Main(string[] args)
        {
            BankingSystem bankingSystem = new BankingSystem();
            MainService mainService = new MainService(new BankServices(bankingSystem) , new AccountServices());

            bool stop = false;

            
            while (!stop)
            {
                Console.WriteLine("1. Create a bank");
                Console.WriteLine("2. Create Staff Account");
                Console.WriteLine("3. Create Customer Account");
                Console.WriteLine("4. Staff Login");
                Console.WriteLine("5. Customer Login");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Select your choice");
                int choice = Convert.ToInt32(Console.ReadLine());    

                switch (choice)
                {
                    case 1:
                        try
                        {
                            Bank bank = new Bank();
                            Console.WriteLine("Enter the bank name");
                            string? bankName = Console.ReadLine()!;
                            bank.BankId = bankName.Substring(0, 3) + DateTime.Today.Toddmmyyyy();
                            Console.WriteLine("Add a RTGS value");
                            bank.RTGS = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Add a IMPS value");
                            bank.IMPS = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(mainService.CreateBank(bank));
                        }
                        catch (Exception )
                        {
                            Console.WriteLine("Entered the wrong details");
                        }
                        break;
                    case 2:
                        try
                        {
                            Console.WriteLine("Please Enter the bank id you want to open an account in");
                            string BankID = Console.ReadLine()!;
                            Staff staff = new Staff();
                            Console.WriteLine("Enter your name:");
                            staff.StaffName = Console.ReadLine()!;
                            staff.StaffId = staff.StaffName.Substring(0, 3) + DateTime.Today.Toddmmyyyy();
                            Console.WriteLine("Your account id is:" + staff.StaffId);
                            Console.WriteLine("Enter your password");
                            staff.Password = Console.ReadLine();
                            Console.WriteLine(mainService.CreateStaffAccount(BankID, staff));
                        }
                        catch (Exception )
                        {
                            Console.WriteLine("Invalid details");
                        }
                        
                        break;
                    case 3:
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
                            string openingDeposit = Console.ReadLine()!;                            
                            Console.WriteLine(mainService.CreateCustomerAccount(BankID, account, openingDeposit));
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Wrong details");
                        }
                        
                        break;
                    case 4:
                        try
                        {
                            Console.WriteLine("Enter your bank id");
                            string? bID = Console.ReadLine()!;
                            Console.WriteLine("Enter your account id");
                            string? ID = Console.ReadLine()!;
                            Console.WriteLine("Enter your account password");
                            string? PW = Console.ReadLine()!;

                            bool Stop = false;
                            if (mainService.IsValidStaffAccount(bID, ID, PW))
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
                                            Console.WriteLine("Please Enter the bank id you want to open an account in");
                                            string? BankID = Console.ReadLine()!;
                                            Account account = new Account();
                                            Console.WriteLine("Enter Account holder's name:");
                                            string? holderName = Console.ReadLine()!;
                                            account.AccountId = holderName.Substring(0, 3) + DateTime.Today.Toddmmyyyy();
                                            Console.WriteLine("Enter a password");
                                            account.Password = Console.ReadLine();
                                            Console.WriteLine("Enter true if you want to make an opening deposit else false");
                                            string openingDeposit = Console.ReadLine()!;

                                            Console.WriteLine(mainService.CreateCustomerAccount(BankID, account, openingDeposit));
                                            break;
                                        case 2:
                                            mainService.UpdateAccountDetails(bID, bankingSystem);
                                            break;
                                        case 3:
                                            mainService.DeleteAccount(bID, bankingSystem);
                                            break;
                                        case 4:
                                            mainService.AddCharges(bID, bankingSystem);
                                            break;
                                        case 5:
                                            mainService.AddChargesforDiffBank(bankingSystem);
                                            break;
                                        case 6:
                                            mainService.ViewCustomerTransaction(bID, bankingSystem);
                                            break;
                                        case 7:
                                            mainService.RevertTransaction(bID, bankingSystem);
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Account");                               
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Re-enter");
                        }
                        break;
                    case 5:
                        try
                        {
                            Console.WriteLine("Enter your bank id");
                            string? bID = Console.ReadLine()!;
                            Console.WriteLine("Enter your account id");
                            string? ID = Console.ReadLine()!;
                            Console.WriteLine("Enter your account password");
                            string? PW = Console.ReadLine()!;

                            bool Stop = false;
                            if (mainService.IsValidAccount(bID, ID, PW))
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
                                            Console.WriteLine("Enter the amount to be deposited:");
                                            double depositAmount = Convert.ToDouble(Console.ReadLine());
                                            Console.WriteLine(mainService.Deposit(ID, bID, bankingSystem, depositAmount));
                                            break;
                                        case 2:
                                            try
                                            {
                                                Console.WriteLine("Enter the recievers bank id");
                                                string? RecievingBank = Console.ReadLine()!;
                                                Console.WriteLine("Enter the account id to transfer");
                                                string? TransferAccount = Console.ReadLine()!;
                                                Console.WriteLine("Enter the amount to be transfered");
                                                double amount = Convert.ToDouble(Console.ReadLine());

                                                mainService.Transaction(ID, bID, bankingSystem,RecievingBank,TransferAccount,amount);
                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("Re-enter");                                                
                                            }
                                            
                                            break;
                                        case 3:
                                            string[] transactionList = mainService.GetTransactions(bID, ID, bankingSystem);
                                            for (int i = 0; i < transactionList.Count(); i++ )
                                            {
                                                Console.WriteLine($"{transactionList[i]}");
                                            }
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
                                
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Re-enter");
                            
                        }                        
                        break;
                    case 6:
                        stop= true;
                        break;
                    default:
                        Console.WriteLine("Enter a valid choice");
                        break;
                }
            }
        }
    }
}
