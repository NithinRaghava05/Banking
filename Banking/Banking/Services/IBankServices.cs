using Banking.Models;

namespace Banking.Services
{
    public interface IBankServices
    {

        string CreateBank( Bank bank);
        string CreateStaffAccount(string BankID, Staff staff);
        string CreateCustomerAccount(string BankID, Account account, string openingDeposit);
        bool IsValidAccount(string BankId, string accountId, string password);
        bool IsValidStaffAccount(string BankId, string StaffId, string password);
       
        
        
    }
}
