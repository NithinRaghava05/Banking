using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Services
{
    public interface IAccountServices
    {

        void Deposit(string accountId, string bankId);
        void Transaction(string accountId, string bankId);
        void GetTransactions(string bankId, string accountId);
        void UpdateAccountDetails(string bankId);
        void DeleteAccount(string bankId);

    }
}
