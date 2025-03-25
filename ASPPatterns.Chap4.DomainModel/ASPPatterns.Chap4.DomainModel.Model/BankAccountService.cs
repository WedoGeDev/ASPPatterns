using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPPatterns.Chap4.DomainModel.Model
{
    public class BankAccountService
    {
        private IBankAccountRepository _bankAccountRepository;

        public BankAccountService(IBankAccountRepository bankAccountRepository)
        {
            this._bankAccountRepository = bankAccountRepository;
        }

        public void Transfer(Guid accountTo, Guid accountFrom, decimal amount)
        {
            var bankAccountTo = _bankAccountRepository.FindBy(accountTo);
            var bankAccountFrom = _bankAccountRepository.FindBy(accountFrom);

            if (bankAccountFrom.CanWithdraw(amount))
            {
                bankAccountTo.Deposit(amount, $"From Acc {bankAccountFrom.CustomerRef} ");
                bankAccountTo.Withdraw(amount, $"Transfer To Acc {bankAccountTo.CustomerRef} ");

                _bankAccountRepository.Save(bankAccountTo);
                _bankAccountRepository.Save(bankAccountFrom);
            }
            else
            {
                throw new InsufficientFundsException();
            }
        }
    }
}
