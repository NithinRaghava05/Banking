using Banking.Models;
using Banking.Services;
using Banking.Services.Extensions;


namespace Banking
{
    class Banking
    {   
        public static void Main(string[] args)
        {
            BankingSystem bankingSystem = new BankingSystem();
            MainService mainService = new MainService(new BankServices(bankingSystem));

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
                            string? BankID = Console.ReadLine();
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
                        mainService.CreateCustomerAccount();
                        break;
                    case 4:
                        mainService.StaffLogin();
                        break;
                    case 5:
                        mainService.CustomerLogin();
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
