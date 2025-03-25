using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPPatterns.Chap4.DomainModel.Model
{
    public class Transaction
    {
        public decimal Deposit { get; internal set; }
        public decimal Withdrawal { get; internal set; }
        public string Reference { get; internal set; }
        public DateTime Date { get; internal set; }

        public Transaction(decimal deposit, decimal withdrawal, string reference, DateTime date)
        {
            Deposit = deposit;
            Withdrawal = withdrawal;
            Reference = reference;
            Date = date;
        }
    }
}
