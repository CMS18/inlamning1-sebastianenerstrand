using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlämning1.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inlämning1.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly BankRepository _repo;

        public AccountController(BankRepository repo)
        {
            _repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Deposit(decimal amount, int accountId)
        {
            var account = _repo.Accounts.Where(a => a.AccountID == accountId).SingleOrDefault();
            if (account != null)
            {
                try
                {
                    _repo.Deposit(amount, account);
                    TempData["balance"] = "New balance: " + account.Balance;
                }
                catch (ArgumentOutOfRangeException)
                {
                    TempData["error"] = "Invalid amount";
                }
            }
            else
            {
                TempData["error"] = "Invalid account ID";
            }
            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Withdraw(decimal amount, int accountId)
        {
            var account = _repo.Accounts.Where(a => a.AccountID == accountId).SingleOrDefault();
            if (account != null)
            {
                try
                {
                    _repo.Withdraw(amount, account);
                    TempData["balance"] = "New balance: " + account.Balance;
                }
                catch (ArgumentOutOfRangeException)
                {
                    TempData["error"] = "Invalid amount";
                }
            }
            else
            {
                TempData["error"] = "Invalid account ID";
            }
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Transfer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Transfer(int accountFromId, int accountToId, decimal amountToTransfer)
        {
            var accountIdFrom = _repo.Accounts.Where(a => a.AccountID == accountFromId).SingleOrDefault();
            var accountIdTo = _repo.Accounts.Where(a => a.AccountID == accountToId).SingleOrDefault();

            if (accountIdFrom != null && accountIdFrom != null)
            {
                try
                {
                    accountIdFrom.Transfer(accountIdFrom, accountIdTo, amountToTransfer);
                    TempData["balance"] = "Transfer successful, the new balance on the from account is: " + accountIdFrom.Balance + "sek and the new balance on the to caaount is: " + accountIdTo.Balance + "sek.";

                }
                catch (ArgumentOutOfRangeException)
                {
                    TempData["error"] = "The amount must be higher than the balance on the fromaccount";
                }
            }
            else
            {
                TempData["error"] = "Invalid accountid, please try again with correct accountid:s";
            }

            return RedirectToAction();
        }
    }
}
