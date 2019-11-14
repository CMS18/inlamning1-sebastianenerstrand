using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämning1.WebUI.Models
{
    public class Account
    {
        public int AccountID { get; set; }
        public decimal Balance { get; set; }
        public int CustomerID { get; set; }

        public void Transfer(Account accountFrom, Account accountTo, decimal amountToTransfer)
        {
            if (accountFrom.Balance >= amountToTransfer && amountToTransfer > 0)
            {
                var repo = new BankRepository();
                repo.Withdraw(amountToTransfer, accountFrom);
                repo.Deposit(amountToTransfer, accountTo);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
