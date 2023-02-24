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
        

        public MainService(IBankServices bankServices)
        {
            this.bankServices = bankServices;
           
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
