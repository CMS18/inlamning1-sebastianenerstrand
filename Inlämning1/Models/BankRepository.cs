using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämning1.WebUI.Models
{
    public class BankRepository
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Account> Accounts { get; set; } = new List<Account>();

        public BankRepository()
        {
            Customers.Add(new Customer { CustomerID = 1, CustomerName = "Lisa" });
            Customers.Add(new Customer { CustomerID = 2, CustomerName = "Fredrik" });
            Customers.Add(new Customer { CustomerID = 3, CustomerName = "Adam" });

            Accounts.Add(new Account { AccountID = 1, CustomerID = 2, Balance = 50.22M });
            Accounts.Add(new Account { AccountID = 2, CustomerID = 1, Balance = 7224.91M });
            Accounts.Add(new Account { AccountID = 3, CustomerID = 3, Balance = 6123.84M });
        }

        public void Withdraw(decimal amount, Account account)
        {
            if (amount > 0 && account.Balance >= amount)
            {
                account.Balance -= amount;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void Deposit(decimal amount, Account account)
        {
            if (amount > 0)
            {
                account.Balance += amount;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
