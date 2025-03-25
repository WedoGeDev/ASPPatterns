using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPPatterns.Chap4.DomainModel.Model
{
    public class BankAccount
    {
        private Guid _accountNo;
        private decimal _balance;
        private string _customRef;
        private IList<Transaction> _transactions;

        public string CustomerRef
        {
            get { return _customRef; }
            set { _customRef = value; }
        }

        public decimal Balance
        {
            get { return _balance; }
            internal set { _balance = value; }
        }

        public Guid AccountNo
        {
            get { return _accountNo; }
            internal set { _accountNo = value; }
        }

        public BankAccount(Guid accountNo, decimal balance, IList<Transaction> transactions, string customerRef)
        {
            AccountNo = accountNo;
            Balance = balance;
            _transactions = transactions;
            CustomerRef = customerRef;
        }

        public bool CanWithdraw(decimal amount)
        {
            return Balance >= amount;
        }

        public void Withdraw(decimal amount, string reference)
        {
            if (CanWithdraw(amount))
            {
                Balance -= amount;
                _transactions.Add(new Transaction(0m, amount, reference, DateTime.Now));
            }
            else
            {
                throw new InsufficientFundsException();
            }
        }

        public void Deposit(decimal amount, string reference)
        {
            Balance -= amount;
            _transactions.Add(new Transaction(amount, 0m, reference, DateTime.Now));
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            return _transactions;
        }
    }
}
