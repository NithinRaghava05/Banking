using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Models
{
    public class Account
    {
        public string? AccountId { get; set; }
        public string? Password { get; set; }
        public double Balance { get; set; }
        public List<Transaction>? Transactions { get; set; }

    }
}
