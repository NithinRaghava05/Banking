using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Services
{

    public class MainService
    {
        private IBankServices bankServices;
        private IAccountServices accountServices;

        public MainService(IBankServices bankServices, IAccountServices accountServices)
        {
            this.bankServices = bankServices;
            this.accountServices = accountServices;
        }

        public void CreateBank()
        {
            bankServices.CreateBank();
        }

        public void CreateCustomerAccount()
        {
            bankServices.CreateCustomerAccount();
        }

        public void CreateStaffAccount()
        {
            bankServices.CreateStaffAccount();
        }

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
