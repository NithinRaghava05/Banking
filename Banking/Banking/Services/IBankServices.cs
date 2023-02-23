using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Services
{
    public interface IBankServices
    {

        void CreateBank();
        void CreateStaffAccount();
        void CreateCustomerAccount();
        bool IsValidAccount(string BankId, string accountId, string password);
        bool IsValidStaffAccount(string BankId, string StaffId, string password);
        void CustomerLogin();
        void StaffLogin();
        
        
    }
}
