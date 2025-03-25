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
			set { _balance = value; }
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
    }
}
