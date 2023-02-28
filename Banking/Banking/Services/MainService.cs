using Banking.Models;

namespace Banking.Services
{

    public class MainService
    {
        private IBankServices bankServices;
        

        public MainService(IBankServices bankServices)
        {
            this.bankServices = bankServices;
           
        }

        public string CreateBank(Bank bank) => bankServices.CreateBank(bank);

        public void CreateCustomerAccount()
        {
            bankServices.CreateCustomerAccount();
        }

        public string CreateStaffAccount(string? BankID, Staff staff) => bankServices.CreateStaffAccount(BankID, staff);

        public void CustomerLogin()
        {
            bankServices.CustomerLogin();
        }

        public void StaffLogin()
        {
            bankServices.StaffLogin();
        }
    }
}
