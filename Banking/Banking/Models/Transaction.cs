using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Models
{
    public class Transaction
    {
        public string? TransactionID { get; set; }
        public double amount { get; set; }
        public string? SentOrRecieved { get; set; } 
    }
}
