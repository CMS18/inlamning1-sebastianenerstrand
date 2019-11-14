using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Inlämning1.WebUI.Models;
using Inlämning1.WebUI.Models.ViewModels;

namespace Inlämning1.Controllers
{
    public class HomeController : Controller
    {
        private readonly BankRepository _repo;

        public HomeController(BankRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var model = new CustomerAccountViewModel();
            model.Accounts = _repo.Accounts;
            model.Customers = _repo.Customers;

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
