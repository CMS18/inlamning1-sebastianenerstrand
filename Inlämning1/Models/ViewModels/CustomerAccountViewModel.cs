using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämning1.WebUI.Models.ViewModels
{
    public class CustomerAccountViewModel
    {
        public List<Customer> Customers { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
