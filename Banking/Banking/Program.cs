using Banking.Models;
using Banking.Services;
using System;

namespace Banking
{
    class Banking
    {   
        public static void Main(string[] args)
        {
            Bank bank= new Bank();
            BankingSystem bankingSystem = new BankingSystem();
            MainService mainService = new MainService(new BankServices(bankingSystem));

            bool stop = false;

            Console.WriteLine("1. Create a bank");
            Console.WriteLine("2. Create Staff Account");
            Console.WriteLine("3. Create Customer Account");
            Console.WriteLine("4. Staff Login");
            Console.WriteLine("5. Customer Login");
            Console.WriteLine("6. Exit");
            
            while (!stop)
            {
                Console.WriteLine("Select your choice");
                int choice = Convert.ToInt32(Console.ReadLine());    

                switch (choice)
                {
                    case 1:
                        mainService.CreateBank();
                        break;
                    case 2:
                        mainService.CreateStaffAccount();
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
