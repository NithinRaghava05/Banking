using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Models
{
    public class Bank
    {
        public string? BankId { get; set; }
        public int RTGS { get; set; }
        public int IMPS { get; set; }
        public List<Account> CustomerAccounts { get; set; } = new List<Account>();
        public List<Staff> StaffAccounts { get; set; } = new List<Staff>();
    }
}
