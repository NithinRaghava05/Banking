using Banking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Services
{
    public interface IAccountServices
    {

        void Deposit(string accountId, string bankId, BankingSystem bankingSystem);
        void Transaction(string accountId, string bankId, BankingSystem bankingSystem);
        void GetTransactions(string bankId, string accountId, BankingSystem bankingSystem);
        void UpdateAccountDetails(string bankId, BankingSystem bankingSystem);
        void DeleteAccount(string bankId, BankingSystem bankingSystem);
        void AddCharges(string bankId, BankingSystem bankingSystem);
        void AddChargesforDiffBank( BankingSystem bankingSystem);
        void RevertTransaction(string bankId, BankingSystem bankingSystem);
    }
}
